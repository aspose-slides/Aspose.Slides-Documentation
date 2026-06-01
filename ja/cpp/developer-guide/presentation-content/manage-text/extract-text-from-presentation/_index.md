---
title: C++ におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/cpp/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPoint からテキスト抽出
- OpenDocument からテキスト抽出
- PPT からテキスト抽出
- PPTX からテキスト抽出
- ODP からテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPoint からテキスト取得
- OpenDocument からテキスト取得
- PPT からテキスト取得
- PPTX からテキスト取得
- ODP からテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップガイドに従って時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要なタスクです。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキストデータへのアクセスと取得は、分析、自動化、インデックス作成、コンテンツ移行などにおいて重要です。

本記事では、Aspose.Slides for C++ を使用して PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に走査し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出**

Aspose.Slides for C++ は [Aspose.Slides.Util](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライド全体からテキストを抽出するためのオーバーロードされた静的メソッドを複数公開しています。スライド内のテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは [IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/) 型のオブジェクトをパラメータとして受け取ります。実行されると、メソッドはスライド全体を走査してテキストを検索し、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

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

## **プレゼンテーションからテキストを抽出**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextframes/) 静的メソッドを使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象の PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/) オブジェクト。
2. 次に、プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `Boolean` 値。

メソッドは [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキスト書式情報も含まれます。以下のコードは、プレゼンテーション全体（マスタースライドを含む）からテキストと書式の詳細を走査します。

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

[PresentationFactory](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textextractionarrangingmode/) 列挙体引数はテキスト抽出結果の整理方法を示し、次の値に設定できます。
- `Unarranged` - スライド上の位置に関係なく生のテキスト。
- `Arranged` - スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は、整理されていないモード（`Unarranged`）を使用できます。こちらの方が整理されたモード（`Arranged`）よりも高速です。

[IPresentationText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationtext/) はプレゼンテーションから抽出された生のテキストを表します。その `get_SlidesText()` メソッドは [ISlideText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidetext/) 型のオブジェクト配列を返します。各オブジェクトは対応するスライ