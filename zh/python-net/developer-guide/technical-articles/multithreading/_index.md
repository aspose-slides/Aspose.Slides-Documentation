---
title: Aspose.Slides for Python 的多线程
linktitle: 多线程
type: docs
weight: 200
url: /zh/python-net/multithreading/
keywords:
- 多线程
- 多个线程
- 并行工作
- 转换幻灯片
- 幻灯片转图像
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 多线程的 Aspose.Slides for Python 可提升 PowerPoint 和 OpenDocument 的处理性能。了解高效演示工作流的最佳实践。"
---

## **简介**

虽然可以对演示文稿进行并行操作（除了解析/加载/克隆之外），并且大多数情况下运行良好，但在多线程使用库时仍有小概率出现结果不正确的情况。

我们强烈建议您 **不要** 在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)实例，因为这可能导致不可预测的错误或故障，且不易被检测到。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例是 **不安全** 的。这类操作 **不受支持**。如果需要执行此类任务，必须使用多个单线程进程并行操作——每个进程应使用自己的演示实例。

## **并行将演示幻灯片转换为图像**

假设我们想要并行地将 PowerPoint 演示的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例是不安全的，我们将演示幻灯片拆分为多个独立的演示，并在各自的线程中并行转换为图像。以下代码示例演示了如何实现。

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # 将第 i 张幻灯片提取到单独的演示中。
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # 将幻灯片转换为图像。
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# 等待所有任务完成。
for task in conversion_tasks:
    task.result()

del presentation
```

## **常见问题**

**我是否需要在每个线程中调用许可证设置？**

不需要。在所有线程启动之前，只需在每个进程/应用域中调用一次即可。如果[license setup](/slides/zh/python-net/licensing/)可能被并发调用（例如在惰性初始化期间），请对该调用进行同步，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“实时”演示对象；请为每个线程使用独立的实例，或预先为每个线程创建单独的演示/幻灯片容器。这一做法遵循了不在多个线程间共享单个演示实例的通用建议。

**只要每个线程拥有自己的 `Presentation` 实例，是否可以安全地并行导出为不同格式（PDF、HTML、图像）？**

可以。只要使用独立的实例并指定不同的输出路径，此类任务通常能够正确并行；请避免共享演示对象和共享 I/O 流。

**在多线程环境下，如何处理全局字体设置（文件夹、替代）？**

在启动线程之前初始化所有全局字体设置，并且在并行工作期间不要更改它们。这样可消除访问共享字体资源时的竞争。