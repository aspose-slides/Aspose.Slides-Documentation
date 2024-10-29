---
title: Aspose.Slides中的多线程
type: docs
weight: 310
url: /zh/net/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片到图像
- C#
- .NET
- Aspose.Slides for .NET
---

## **介绍**

尽管在处理演示文稿时可以进行并行工作（除了解析/加载/克隆），并且大多数时候一切都很顺利，但在多线程环境中使用库时，您可能会遇到小概率的错误结果。

我们强烈建议您**不要**在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)实例，因为这可能会导致不可预测的错误或故障，这些问题不容易被检测到。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例是**不安全的**。此类操作**不受支持**。如果您需要执行此类任务，您必须使用多个单线程进程来并行操作——而且这些进程中的每一个都应该使用自己的演示文稿实例。

## **并行转换演示文稿幻灯片为图像**

假设我们想要将PowerPoint演示文稿中的所有幻灯片并行转换为PNG图像。由于在多个线程中使用单个`Presentation`实例是不安全的，因此我们将演示文稿幻灯片拆分为单独的演示文稿，并在每个线程中使用每个演示文稿并行转换幻灯片为图像。以下代码示例展示了如何做到这一点。

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
    // 将幻灯片i提取到一个单独的演示文稿中。
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // 在一个单独的任务中将幻灯片转换为图像。
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