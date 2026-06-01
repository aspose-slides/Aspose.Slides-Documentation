---
title: "C++ によるプレゼンテーションの高度なテキスト抽出"
linktitle: "テキスト抽出"
type: docs
weight: 90
url: /ja/cpp/extract-text-from-presentation/
keywords:
- "テキスト抽出"
- "スライドからテキストを抽出"
- "プレゼンテーションからテキストを抽出"
- "PowerPoint からテキストを抽出"
- "OpenDocument からテキストを抽出"
- "PPT からテキストを抽出"
- "PPTX からテキストを抽出"
- "ODP からテキストを抽出"
- "テキスト取得"
- "スライドからテキストを取得"
- "プレゼンテーションからテキストを取得"
- "PowerPoint からテキストを取得"
- "OpenDocument からテキストを取得"
- "PPT からテキストを取得"
- "PPTX からテキストを取得"
- "ODP からテキストを取得"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルでステップバイステップのガイドに従い、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的かつ重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキストデータへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などの目的で重要です。

この記事では、Aspose.Slides for C++ を使用して PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出する包括的な手順を紹介します。プレゼンテーション要素を体系的に走査し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for C++ は、[Aspose.Slides.Util](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/) 名前空間を提供し、そこに [SlideUtil](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライド全体のテキストを抽出するためのオーバーロードされた静的メソッドを複数公開しています。スライド内のテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは、[IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/) 型のオブジェクトをパラメータとして受け取ります。実行すると、スライド全体を走査してテキストを検出し、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 型オブジェクトの配列を返し、テキストの書式情報も保持します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **プレゼンテーションからテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextframes/) 静的メソッドを使用します。 このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/) オブジェクト。
1. 次に、プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `Boolean` 値。

メソッドは、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 型オブジェクトの配列を返し、テキストの書式情報も含みます。以下のコードは、プレゼンテーション全体（マスタースライドを含む）のテキストと書式詳細を走査します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **カテゴリ別かつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供しています。

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

`TextExtractionArrangingMode` 列挙体引数は、テキスト抽出結果の整理方法を示し、次の値に設定できます。
- `Unarranged` – スライド上の位置を考慮しない生テキスト。
- `Arranged` – スライド上の表示順序と同じ順序でテキストが整理されます。

速度が重要な場合は `Unarranged` モードを使用できます。`Arranged` モードよりも高速です。

[IPresentationText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationtext/) は、プレゼンテーションから抽出された生テキストを表します。その `get_SlidesText()` メソッドは、[ISlideText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidetext/) 型オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。`ISlideText` 型オブジェクトには次のメソッドがあります。

- `get_Text()` – スライドのシェイプ内のテキスト。
- `get_MasterText()` – 当該スライドに関連付けられたマスタースライドのシェイプ内のテキスト。
- `get_LayoutText()` – 当該スライドに関連付けられたレイアウトスライドのシェイプ内のテキスト。
- `get_NotesText()` – 当該スライドのノートスライドのシェイプ内のテキスト。
- `get_CommentsText()` – 当該スライドに付随するコメントのテキスト。

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Aspose.Slides は大規模なプレゼンテーションのテキスト抽出をどれくらい高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/cpp/open-presentation/) でもリアルタイムまたはバルク処理シナリオに適した速度で処理できます。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい。Aspose.Slides は表やグラフ関連オブジェクトを含む多くのスライド要素からテキストを抽出できるため、一般的