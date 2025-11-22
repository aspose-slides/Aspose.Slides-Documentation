---
title: Aspose.Slides 中的多线程
type: docs
weight: 310
url: /zh/nodejs-java/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片转图像
- JavaScript
- Aspose.Slides for Node.js via Java
---

## **简介**

虽然在并行工作时（除了解析/加载/克隆之外）大多数情况下都能正常运行，但在多线程使用库时仍有小概率会得到不正确的结果。

我们强烈建议您**不要**在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)实例，因为这可能导致难以检测的不可预测错误或失败。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例**不安全**。此类操作**不受支持**。如果需要执行此类任务，必须使用多个单线程进程并行处理——每个进程使用其自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们想并行地将 PowerPoint 演示文稿的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例不安全，我们将演示文稿的幻灯片拆分为多个独立的演示文稿，并在每个线程中使用各自的演示文稿将幻灯片转换为图像。以下代码示例演示了如何实现此操作。
```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // 提取第 i 张幻灯片为单独的演示文稿。
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // 等待所有任务完成。
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **常见问题**

**我需要在每个线程中都调用许可证设置吗？**

不需要。只需在启动线程之前在每个进程/应用程序域中调用一次即可。如果[license setup](/slides/zh/nodejs-java/licensing/)可能会并发调用（例如在延迟初始化期间），请同步该调用，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“活跃”的演示文稿对象：请为每个线程使用独立的实例，或预先为每个线程创建单独的演示文稿/幻灯片容器。这符合不在多个线程之间共享单个演示文稿实例的一般建议。

**如果每个线程都有自己的 `Presentation` 实例，是否安全并行导出为不同格式（PDF、HTML、图像）？**

是的。只要使用独立的实例和单独的输出路径，此类任务通常可以正确并行化；避免共享演示文稿对象和共享 I/O 流。

**在多线程环境中全局字体设置（文件夹、替代）应该如何处理？**

在启动线程之前初始化所有全局字体设置，并且在并行工作期间不要更改它们。这样可以消除访问共享字体资源时的竞争。