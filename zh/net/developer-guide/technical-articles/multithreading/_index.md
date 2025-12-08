---
title: Aspose.Slides 中的多线程
type: docs
weight: 310
url: /zh/net/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片转图片
- C#
- .NET
- Aspose.Slides for .NET
---

## **简介**

虽然在并行工作时（除了解析/加载/克隆）大多数情况下都能正常运行，但在多线程使用库时仍有小概率出现错误结果。

我们强烈建议**不要**在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)实例，因为这可能导致难以检测的不可预测错误或失败。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例是**不安全**的，此类操作**不受支持**。如果需要执行此类任务，必须使用多个单线程进程并行处理——每个进程使用其自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们想并行将 PowerPoint 演示文稿的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例不安全，我们将演示文稿的幻灯片拆分为多个独立的演示文稿，并在每个线程中使用各自的演示文稿并行转换为图像。下面的代码示例演示了如何实现此操作。
```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // 提取第 i 张幻灯片到独立的演示文稿。
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // 在独立任务中将幻灯片转换为图像。
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```


## **常见问题**

**我需要在每个线程中调用许可证设置吗？**

不需要。只需在启动线程之前在每个进程/应用域中调用一次即可。如果[license setup](/slides/zh/net/licensing/)可能会并发调用（例如在延迟初始化期间），请同步该调用，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“活动”演示文稿对象：请为每个线程使用独立实例，或为每个线程预先创建单独的演示文稿/幻灯片容器。这一做法遵循不在多个线程间共享单个演示文稿实例的一般建议。

**如果每个线程都有自己的 `Presentation` 实例，是否安全并行导出为不同格式（PDF、HTML、图像）？**

是的。只要使用独立实例并指定不同的输出路径，此类任务通常可以正确并行化；请避免共享演示文稿对象和共享 I/O 流。

**在多线程环境中全局字体设置（文件夹、替换）该怎么办？**

在启动线程之前初始化所有全局字体设置，并且在并行工作期间不要更改它们。这可以消除访问共享字体资源时的竞争。