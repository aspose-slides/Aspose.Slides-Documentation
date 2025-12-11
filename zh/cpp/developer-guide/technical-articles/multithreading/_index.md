---
title: C++ 版 Aspose.Slides 的多线程
linktitle: 多线程
type: docs
weight: 200
url: /zh/cpp/multithreading/
keywords:
- 多线程
- 多个线程
- 并行工作
- 转换幻灯片
- 幻灯片转图像
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 的多线程提升 PowerPoint 和 OpenDocument 处理。了解高效演示工作流的最佳实践。"
---

## **介绍**

虽然可以对演示文稿进行并行操作（除了解析/加载/克隆），并且大多数情况下运行良好，但在多线程使用库时仍有小概率会得到不正确的结果。

我们强烈建议您**不要**在多线程环境中使用单个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)实例，因为这可能导致不可预知的错误或故障，且难以检测。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例**不安全**。此类操作**不受支持**。如果需要执行此类任务，必须使用多个单线程进程并行操作——每个进程应使用其自己的演示文稿实例。

## **并行将演示文稿幻灯片转换为图像**

假设我们希望并行将 PowerPoint 演示文稿中的所有幻灯片转换为 PNG 图像。由于在多个线程中使用单个 `Presentation` 实例不安全，我们将演示文稿的幻灯片拆分为多个独立的演示文稿，并在各自的线程中并行将幻灯片转换为图像。以下代码示例演示了如何实现。
```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // 将第 i 张幻灯片提取到单独的演示文稿中。
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // 在单独的任务中将幻灯片转换为图像。
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// 等待所有任务完成。
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```


## **常见问题**

**我是否需要在每个线程中调用许可证设置？**

不需要。只需在启动线程之前于每个进程/应用域调用一次即可。如果[license setup](/slides/zh/cpp/licensing/)可能被并发调用（例如在惰性初始化期间），请对该调用进行同步，因为许可证设置方法本身不是线程安全的。

**我可以在线程之间传递 `Presentation` 或 `Slide` 对象吗？**

不建议在线程之间传递“活动”演示文稿对象：请为每个线程使用独立的实例，或预先为每个线程创建单独的演示文稿/幻灯片容器。此做法遵循不在多线程中共享单个演示文稿实例的一般建议。

**如果每个线程拥有自己的 `Presentation` 实例，是否安全并行导出为不同格式（PDF、HTML、图像）？**

是的。使用独立的实例和各自的输出路径，这类任务通常可以正确并行化；请避免共享演示文稿对象和共享 I/O 流。

**在多线程环境中，如何处理全局字体设置（文件夹、替代）？**

在启动线程之前初始化所有全局字体设置，并且在并行工作期间不要更改它们。这可以消除访问共享字体资源时的竞争条件。