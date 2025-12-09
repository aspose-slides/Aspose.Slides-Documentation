---
title: Aspose.Slides for .NET 中的多线程
linktitle: 多线程
type: docs
weight: 310
url: /zh/net/multithreading/
keywords:
- 多线程
- 多个线程
- 并行工作
- 转换幻灯片
- 幻灯片转图像
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 的多线程提升了 PowerPoint 和 OpenDocument 的处理效率。了解高效演示文稿工作流的最佳实践。"
---

## **介绍**

虽然可以在多个线程中并行处理演示文稿（除了解析/加载/克隆之外），并且大多数情况下运行良好，但在多线程使用库时仍有可能得到不正确的结果。

我们强烈建议您**不要**在多线程环境中使用单个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 实例，因为这可能导致不可预测的错误或故障，且这些错误不易被检测到。 

在多个线程中加载、保存和/或克隆 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例**不是**安全的。这类操作**不受支持**。如果需要执行此类任务，必须使用多个单线程进程并行操作——每个进程应使用自己的演示文稿实例。 

## **并行将演示文稿幻灯片转换为图像**

假设我们想并行将 PowerPoint 演示文稿的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例是不安全的，我们将演示文稿的幻灯片拆分为多个独立的演示文稿，并在每个线程中使用各自的演示文稿将幻灯片转换为图像。以下代码示例展示了如何完成此操作。
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
    // 将幻灯片 i 提取到单独的演示文稿中。
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // 在单独的任务中将幻灯片转换为图像。
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


## **常见问答**

**我需要在每个线程中调用许可证设置吗？**

不需要。在进程或应用程序域启动线程之前调用一次即可。如果 [license setup](/slides/zh/net/licensing/) 可能被并发调用（例如在懒加载期间），请同步该调用，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“活动”的演示文稿对象：请为每个线程使用独立实例，或为每个线程预先创建单独的演示文稿/幻灯片容器。此做法遵循不在多个线程中共享单个演示文稿实例的一般建议。

**在每个线程拥有自己的 `Presentation` 实例的前提下，将导出并行化为不同格式（PDF、HTML、图像）安全吗？**

是的。使用独立的实例并指定不同的输出路径，此类任务通常可以正确并行化；请避免共享演示文稿对象和共享的 I/O 流。

**在多线程环境中，全球字体设置（文件夹、替代）该如何处理？**

在启动线程之前初始化所有全局字体设置，并且在并行工作期间不要更改它们。这可以消除访问共享字体资源时的竞争。