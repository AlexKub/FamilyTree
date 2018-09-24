using Microsoft.VisualStudio.TestTools.UnitTesting;
using FamilyTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTree.Controls.TreeCanvasHelpers;

namespace FamilyTreeTests
{
    [TestClass]
    public class TimeLinesManagerTests
    {
        /// <summary>
        /// Проверка на проброс исключения при создании экземпляра по пустой ссылке
        /// </summary>
        [TestMethod]
        public void NullRefInitFail()
        {
            bool inited = false;
            try
            {
                var m = new TimeLinesManager(null);
                inited = true;
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(NullReferenceException), "Исключение не соответствует ожидаемому типу");
            }

            if(inited)
                Assert.Fail("Инициализация по пустому указателю не предполагалась");
        }

        /// <summary>
        /// Проверка на проброс исключения при создании экземпляра в другом потоке
        /// </summary>
        [TestMethod]
        public void WrongThreadInitFail()
        {
            bool inited = false;
            try
            {
                var canvas = new FamilyTree.Controls.TreeCanvas();

                Task.Run(() => new TimeLinesManager(canvas));
                inited = true;
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException), "Исключение не соответствует ожидаемому типу");
            }

            if (inited)
                Assert.Fail("Инициализация в другом потоке не предполагалась");
        }
    }
}
