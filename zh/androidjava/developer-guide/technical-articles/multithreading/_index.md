---
title: Aspose.Slides for Android via Java 的多线程
linktitle: 多线程
type: docs
weight: 310
url: /zh/androidjava/multithreading/
keywords:
- 多线程
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片转图像
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java 的多线程提升了 PowerPoint 和 OpenDocument 处理。了解高效演示文稿工作流的最佳实践。"
---

## **介绍**

虽然可以在并行情况下处理演示文稿（除了解析/加载/克隆之外），并且大多数情况下运行正常，但在多线程使用库时仍有小概率得到错误结果。

我们强烈建议您 **不** 在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)实例，因为这可能导致不可预测的错误或故障，且不易被检测到。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例是不安全的。这类操作 **不** 被支持。如果需要执行此类任务，必须使用多个单线程进程并行处理——每个进程应使用自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们想要并行地将 PowerPoint 演示文稿的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个`Presentation`实例不安全，我们将演示文稿的幻灯片拆分为多个独立的演示文稿，并在各自的线程中并行转换为图像。以下代码示例展示了如何实现。

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
	// 提取第 i 张幻灯片到一个单独的演示文稿中。
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// 在单独的任务中将幻灯片转换为图像。
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


## **常见问题**

**我是否需要在每个线程中调用许可证设置？**

不。只需在进程/应用程序域启动线程之前调用一次即可。如果[许可证设置](/slides/zh/androidjava/licensing/) 可能被并发调用（例如在延迟初始化期间），请对该调用进行同步，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“活动”演示文稿对象：每个线程使用独立实例，或预先为每个线程创建单独的演示文稿/幻灯片容器。此做法遵循不在多个线程之间共享单个演示文稿实例的一般建议。

**只要每个线程拥有自己的 `Presentation` 实例，是否安全地并行导出为不同格式（PDF、HTML、图像）？**

是的。使用独立的实例和单独的输出路径，这类任务通常可以正确并行化；请避免共享演示文稿对象和共享 I/O 流。

**在多线程环境下，全球字体设置（文件夹、替代）应如何处理？**

在启动线程之前初始化所有全局[字体设置](/slides/zh/androidjava/powerpoint-fonts/)，并且在并行工作期间不要更改它们。这可以消除访问共享字体资源时的竞争。