---
title: C++ 用 Aspose.Slides のマルチスレッド処理
linktitle: マルチスレッド
type: docs
weight: 200
url: /ja/cpp/multithreading/
keywords:
- マルチスレッド
- 複数スレッド
- 並列処理
- スライド変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides のマルチスレッドは PowerPoint と OpenDocument の処理を強化します。効率的なプレゼンテーション ワークフローのベストプラクティスをご確認ください。"
---

## **Introduction**

プレゼンテーションでの並列作業は（解析/ロード/クローン以外でも）可能で、ほとんどの場合うまくいきますが、ライブラリを複数スレッドで使用すると結果が正しくない可能性がわずかにあります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)インスタンスを使用し**ない**ことを強く推奨します。予測できないエラーや検出が容易でない失敗が発生する可能性があります。  

複数スレッドで[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスをロード、保存、またはクローンすることは**安全ではありません**。このような操作は**サポートされていません**。このようなタスクを実行する必要がある場合は、複数のシングルスレッドプロセスを使用して操作を並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。  

## **Convert Presentation Slides to Images in Parallel**

PowerPointプレゼンテーションのすべてのスライドをPNG画像に並列で変換したいとします。複数スレッドで単一の`Presentation`インスタンスを使用することは安全でないため、プレゼンテーションスライドを別々のプレゼンテーションに分割し、各スレッドで各プレゼンテーションを使用してスライドを画像に並列変換します。以下のコード例がその方法を示しています。  
```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // スライド i を別のプレゼンテーションに抽出します。
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // スライドを別のタスクで画像に変換します。
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


## **FAQ**

**すべてのスレッドでライセンス設定を呼び出す必要がありますか？**  

いいえ。スレッドが開始する前にプロセス/アプリドメインごとに一度実行すれば十分です。[license setup](/slides/ja/cpp/licensing/) が同時に呼び出される可能性がある場合（例えば遅延初期化時）、その呼び出しを同期してください。ライセンス設定メソッド自体がスレッドセーフではありません。  

**`Presentation` または `Slide` オブジェクトをスレッド間で渡すことはできますか？**  

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に別々のプレゼンテーション/スライドコンテナを事前に作成してください。このアプローチは、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨に沿ったものです。  

**各スレッドが独自の `Presentation` インスタンスを持つ場合、異なるフォーマット（PDF、HTML、画像）へのエクスポートを並列化しても安全ですか？**  

はい。独立したインスタンスと別々の出力パスを使用すれば、通常このようなタスクは正しく並列化できます。プレゼンテーションオブジェクトや I/O ストリームを共有しないでください。  

**マルチスレッド環境でのグローバルフォント設定（フォルダ、置換など）はどうすべきですか？**  

スレッド開始前にすべてのグローバルフォント設定を初期化し、並列作業中に変更しないでください。これにより、共有フォントリソースへのアクセス時の競合がなくなります。