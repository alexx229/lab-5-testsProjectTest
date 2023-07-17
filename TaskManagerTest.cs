using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testy_lab5;

namespace testProject
{
    internal class TaskManagerTest
    {

        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new testy_lab5.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new testy_lab5.Task("Test task");
            _taskManager.AddTask(task);

            // Act
            var result = _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.IsTrue(result, "Expected RemoveTask method to return true for an existing task.");
            Assert.AreEqual(0, _taskManager.GetTasks().Count, "Expected the task count to be 0 after removing the task.");
        }

        [Test]
        public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
        {
            // Arrange
            var task = new testy_lab5.Task("Test task");
            _taskManager.AddTask(task);

            // Act
            var nonExistingTaskId = task.Id + 1; // Assuming there is no task with this ID
            var result = _taskManager.RemoveTask(nonExistingTaskId);

            // Assert
            Assert.IsFalse(result, "Expected RemoveTask method to return false for a non-existing task.");
            Assert.AreEqual(1, _taskManager.GetTasks().Count, "Expected the task count to remain unchanged.");
        }

        [Test]
        public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
        {
            // Arrange
            var task = new testy_lab5.Task("Test task");
            _taskManager.AddTask(task);

            // Act
            var result = _taskManager.MarkTaskAsCompleted(task.Id);

            // Assert
            Assert.IsTrue(result, "Expected MarkTaskAsCompleted method to return true for an existing task.");
            var updatedTask = _taskManager.GetTaskById(task.Id);
            Assert.IsTrue(updatedTask.IsCompleted, "Expected the task to be marked as completed.");
        }



    }
}
