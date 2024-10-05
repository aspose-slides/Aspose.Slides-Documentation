---
title: Aspose.Slidesにおけるマルチスレッド
type: docs
weight: 200
url: /cpp/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッド
- 並列作業
- スライド変換
- スライドを画像に
- C++
- Aspose.Slides for C++
---

## **はじめに**

プレゼンテーションを使った並列作業は可能ですが（解析/ロード/クローンを除く）、すべてが順調に進むこと（ほとんどの場合）を価値できない場合があります。ライブラリを複数のスレッドで使用した場合、誤った結果が得られる可能性がわずかにあります。

複数のスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)インスタンスを使用することは**強く推奨されません**。予測不可能なエラーや簡単には検出できない失敗を招く可能性があります。

複数のスレッドで[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスをロード、保存、またはクローンすることは**安全ではありません**。そのような操作は**サポートされていません**。そのようなタスクを実行する必要がある場合は、いくつかの単一スレッドプロセスを使用して操作を並列化する必要があります。これらのプロセスのそれぞれは、独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションスライドを並列で画像に変換する**

すべてのスライドをPowerPointプレゼンテーションからPNG画像に並列で変換したいとしましょう。複数のスレッドで単一の`Presentation`インスタンスを使用することは安全ではないため、プレゼンテーションスライドを別のプレゼンテーションに分割し、各プレゼンテーションを別のスレッドで使用してスライドを画像に並列で変換します。以下のコード例は、その方法を示しています。

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // スライドiを別のプレゼンテーションに抽出します。
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // 別のタスクでスライドを画像に変換します。
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

// すべてのタスクが完了するのを待ちます。
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```