---
title: C++ におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
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
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションからテキストを素早く抽出します。シンプルで段階的なガイドに従って時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライド コンテンツを扱う開発者にとって一般的でありながら重要なタスクです。Microsoft PowerPoint の PPT または PPTX 形式のファイル、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキスト データへのアクセスと取得は、分析、 自動化、インデックス作成、またはコンテンツ 移行の目的で重要になることがあります。

本記事では、Aspose.Slides for C++ を使用して PPT、PPTX、ODP などさまざまなプレゼンテーション形式からテキストを効率的に抽出するための包括的な手順を示します。プレゼンテーション要素を体系的に反復処理し、必要なテキスト コンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for C++ は [Aspose.Slides.Util](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/) クラスが含まれます。このクラスはプレゼンテーションまたはスライドからすべてのテキストを抽出するための、複数のオーバーロードされた静的メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは [IBaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/) 型のオブジェクトをパラメータとして受け取ります。実行すると、メソッドはスライド全体を走査してテキストを検索し、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式設定を保持します。

以下のコード スニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

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

プレゼンテーション全体のテキストをスキャンするには、[SlideUtil](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextframes/) 静的メソッドを使用します。 このメソッドは 2 つのパラメータを受け取ります。

1. まず、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/) オブジェクト。
1. 次に、プレゼンテーションのテキストをスキャンする際にマスタ スライドを含めるかどうかを示す `Boolean` 値。

このメソッドは [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報も含みます。以下のコードは、マスタ スライドを含めてプレゼンテーションのテキストと書式詳細をスキャンします。

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

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textextractionarrangingmode/) 列挙体の引数は、テキスト抽出結果の整理方法を示し、以下の値に設定できます。
- `Unarranged` - スライド上の位置に関係なく取得した生テキスト。
- `Arranged` - スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は `Unarranged` モードを使用できます。こちらの方が `Arranged` モードより高速です。

[IPresentationText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationtext/) はプレゼンテーションから抽出された生テキストを表します。その `get_SlidesText()` メソッドは [ISlideText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidetext/) 型のオブジェクト配列を返します。各オブジェクトは該当スライド上のテキストを表します。型 [ISlideText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidetext/) のオブジェクトは以下のメソッドを持ちます。

- `get_Text()` - スライドのシェイプ内のテキスト。
- `get_MasterText()` - 当該スライドに関連付けられたマスタ スライドのシェイプ内のテキスト。
- `get_LayoutText()` - 当該スライドに関連付けられたレイアウト スライドのシェイプ内のテキスト。
- `get_NotesText()` - 当該スライドのノート スライドのシェイプ内のテキスト。
- `get_CommentsText()` - 当該スライドに関連付けられたコメント内のテキスト。

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

**Aspose.Slides は大規模なプレゼンテーションをテキスト抽出する際、どれくらいの速度で処理しますか？**

Aspose.Slides は高性能に最適化されており、[large presentations](/slides/ja/cpp/open-presentation/) さえも高速に処理できるため、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やグラフからテキストを抽出できますか？**

はい。Aspose.Slides は表やチャート関連オブジェクトを含む多数のスライド要素からテキストを抽出できるため、一般的なプレゼンテーション構造内のテキスト コンテンツにアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

無料体験版の Aspose.Slides でもテキストを抽出できますが、[certain limitations](/slides/ja/cpp/licensing/) があり、たとえば処理できるスライド数が制限されます。制限なしで利用し、より大きなプレゼンテーションを扱うには、フル ライセンスの購入が推奨されます。