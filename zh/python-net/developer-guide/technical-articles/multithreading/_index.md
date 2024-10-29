---
title: Aspose.Slides中的多线程
type: docs
weight: 200
url: /zh/python-net/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片为图像
- Python
- Aspose.Slides for Python
---

## **介绍**

虽然在演示文稿中进行并行工作是可能的（除了解析/加载/克隆），且大多数情况下运行良好，但在多线程中使用库时，您可能会获得不正确结果的可能性较小。

我们强烈建议您**不要**在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)实例，因为这可能导致不可预测的错误或故障，这些问题不易被检测到。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例是**不安全**的。这种操作**不**受支持。如果您需要执行此类任务，您必须使用多个单线程进程并行处理操作——每个进程都应使用其自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们想要将PowerPoint演示文稿中的所有幻灯片并行转换为PNG图像。由于在多个线程中使用单个`Presentation`实例是不安全的，因此我们将演示文稿幻灯片拆分为单独的演示文稿，并在并行中将幻灯片转换为图像，每个演示文稿在单独的线程中使用。以下代码示例演示了如何做到这一点。

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # 将幻灯片i提取到单独的演示文稿中。
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