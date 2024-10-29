---
title: Aspose.Slides中的多线程
type: docs
weight: 200
url: /zh/cpp/multithreading/
keywords:
- PowerPoint
- 演示文稿
- 多线程
- 并行工作
- 转换幻灯片
- 幻灯片转图片
- C++
- Aspose.Slides for C++
---

## **介绍**

在演示文稿中进行并行工作是可能的（除了解析/加载/克隆），并且大多数情况下运行良好，但在使用库的多个线程时，您可能会在少数情况下获得不正确的结果。

我们强烈建议您在多线程环境中**不**使用单个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)实例，因为这可能导致不可预测的错误或故障，这些错误或故障并不易被检测到。

在多个线程中加载、保存和/或克隆[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例是**不安全**的。这种操作**不**被支持。如果您需要执行此类任务，您必须使用多个单线程进程并行操作——每个进程应使用自己的演示文稿实例。

## **并行转换演示文稿幻灯片为图像**

假设我们想将PowerPoint演示文稿中的所有幻灯片并行转换为PNG图像。由于在多个线程中使用单个`Presentation`实例是不安全的，我们将演示文稿幻灯片拆分为单独的演示文稿，并在并行中将幻灯片转换为图像，每个演示文稿在单独的线程中使用。以下代码示例演示了如何做到这一点。

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // 将幻灯片i提取到一个单独的演示文稿中。
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