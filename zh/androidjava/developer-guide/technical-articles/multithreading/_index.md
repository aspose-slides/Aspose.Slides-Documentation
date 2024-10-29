---
title: Aspose.Slides 中的多线程
type: docs
weight: 310
url: /zh/androidjava/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片为图像
- Android
- Java
- Aspose.Slides for Android via Java
---

## **介绍**

虽然可以对演示文稿进行并行工作（除了解析/加载/克隆），并且一切正常（大多数情况下），但在多个线程中使用库时，你可能会遇到小概率的错误结果。

我们强烈建议你**不要**在多线程环境中使用单个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 实例，因为这可能导致不可预测的错误或故障，这些错误不易被发现。

在多个线程中加载、保存和/或克隆 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例是**不安全**的。此类操作**不**被支持。如果需要执行此类任务，您必须使用几个单线程进程并行执行操作——每个进程应使用自己的演示文稿实例。

## **并行转换演示文稿幻灯片为图像**

假设我们想将 PowerPoint 演示文稿中的所有幻灯片并行转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例不安全，我们将演示文稿的幻灯片拆分为单独的演示文稿，并使用每个演示文稿在单独的线程中并行转换幻灯片为图像。以下代码示例演示了如何实现这一点。

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// 提取幻灯片 i 到一个单独的演示文稿中。
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// 在一个单独的任务中将幻灯片转换为图像。
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
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
		}
	}));
}

// 等待所有任务完成。
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```