---
title: Aspose.Slides 中的多线程
type: docs
weight: 310
url: /java/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片为图像
- Java
- Aspose.Slides for Java
---

## **介绍**

虽然可以对演示文稿进行并行工作（除了解析/加载/克隆），且大多数时候一切顺利，但在多个线程中使用库时，你可能会遇到小概率的不正确结果。

我们强烈建议你**不要**在多线程环境中使用单个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 实例，因为这可能会导致无法预测的错误或故障，而这些错误或故障并不容易被发现。

在多个线程中加载、保存和/或克隆 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例是**不安全**的。这种操作是**不支持**的。如果你需要执行此类任务，必须使用多个单线程进程进行并行操作——这些进程中的每一个都应该使用自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们想要将 PowerPoint 演示文稿中的所有幻灯片并行转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例是不安全的，我们将演示文稿幻灯片拆分为单独的演示文稿，并在并行中将幻灯片转换为图像，每个演示文稿在一个独立的线程中使用。以下示例代码展示了如何做到这一点。

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
    // 将幻灯片 i 提取到一个单独的演示文稿中。
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