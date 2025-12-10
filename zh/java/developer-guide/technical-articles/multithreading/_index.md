---
title: Aspose.Slides for Java 中的多线程
linktitle: 多线程
type: docs
weight: 310
url: /zh/java/multithreading/
keywords:
- 多线程
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片转图像
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 的多线程功能提升了 PowerPoint 和 OpenDocument 的处理效率。了解实现高效演示文稿工作流的最佳实践。"
---

## **介绍**

虽然在演示文稿上进行并行操作（除了解析/加载/克隆）是可能的，并且大多数情况下都能正常工作，但在多线程使用库时仍有少量可能会得到不正确的结果。

我们强烈建议您 **不要** 在多线程环境中使用单个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 实例，因为这可能导致不可预料的错误或故障，且难以检测。

在多个线程中加载、保存和/或克隆 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例是 **不安全** 的。这类操作 **不受支持**。如果需要执行此类任务，您必须使用多个单线程进程并行操作——每个进程应使用其自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们想要并行地将 PowerPoint 演示文稿的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例是不安全的，我们将演示文稿的幻灯片拆分为多个独立的演示文稿，并在每个线程中使用各自的演示文稿并行地将幻灯片转换为图像。下面的代码示例演示了如何实现。
```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // 提取第 i 张幻灯片到单独的演示文稿。
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // 在单独的任务中将幻灯片转换为图像。
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// 等待所有任务完成。
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```


## **常见问题**

**我需要在每个线程中调用许可证设置吗？**

不需要。只需在启动线程之前在每个进程/应用域中调用一次即可。如果 [许可证设置](/slides/zh/java/licensing/) 可能会并发调用（例如在惰性初始化期间），请对该调用进行同步，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递 “活动” 的演示文稿对象：请为每个线程使用独立的实例，或为每个线程预先创建单独的演示文稿/幻灯片容器。此做法遵循不在多个线程之间共享单个演示文稿实例的一般建议。

**如果每个线程都有自己的 `Presentation` 实例，是否安全并行导出为不同格式（PDF、HTML、图像）？**

是的。只要使用独立的实例并且输出路径各自分离，此类任务通常能够安全并行；请避免共享任何演示文稿对象或共享 I/O 流。

**在多线程环境下全局字体设置（文件夹、替代）该如何处理？**

在启动线程之前初始化所有全局 [字体设置](/slides/zh/java/powerpoint-fonts/)，并且在并行工作期间不要更改它们。这样可消除访问共享字体资源时的竞争。