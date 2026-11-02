---
title: C++ のプレゼンテーションで箇条書きと番号付きリストを管理する
linktitle: リストを管理する
type: docs
weight: 70
url: /ja/cpp/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- シンボル箇条書き
- 画像箇条書き
- カスタム箇条書き
- 多層リスト
- 箇条書き作成
- 箇条書き追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションで箇条書き、画像箇条書き、多層リスト、番号付きリストの作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for C++ は、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストと番号付きリストを作成および書式設定できるようにします。リスト項目は、段落書式を介して箇条書き設定が制御される段落です。

段落レベルのリスト設定にアクセスするには、[IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) メソッドを使用します。主なエントリーポイントは [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) で、[IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、シンボル、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では、以下の方法を示します：

- カスタムシンボルを使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して多層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリスト書式を検査および変更する
- 段落テキストとともに実際のリストマーカーと番号を読み取る

## **箇条書きリストの作成**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) オブジェクトを [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) に追加し、[IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) を [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) に設定します。次に、[IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/)、[IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/)、[IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) を設定して箇条書きの外観を制御できます。

以下の C++ コードは、スライド内で箇条書きリストを作成する方法を示しています。

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) を [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) に設定します。また、[IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) で番号付形式を選択したり、リストを 1 以外の値から開始したい場合は [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) を設定したりできます。

以下の C++ コードは、スライド内で番号付きリストを作成する方法を示しています。

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides では、通常の箇条書きシンボルを画像で置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

{{% alert color="info" title="Note" %}}
理想的には、通常の箇条書きシンボルを画像で置き換える場合、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書きシンボルとしてうまく機能します。

画像は非常に小さなサイズに縮小されることを念頭に置いてください。そのため、リストの箇条書きとして使用しても鮮明で視覚的に効果的な画像を選択することを強く推奨します。
{{% /alert %}}

画像箇条書きを作成するには、[IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) に画像を追加し、返された [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) オブジェクトを [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/) に割り当てます。画像を割り当てる前に、[IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) を [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) に設定してください。

例えば、"image.png" があるとします：

![箇条書き用の画像](picture_for_bullets.png)

以下の C++ コードは、スライド内で画像箇条書きを作成する方法を示しています。

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![画像箇条書き](picture_bullets.png)

## **多層リストの作成**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位レベルで、レベル 1 はその下にネストされ、以下同様です。

以下の C++ コードは、多層箇条書きリストを作成する方法を示しています。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![多層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリスト書式を変更するには、対象の段落にアクセスし、その [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定を更新します。リスト作成時に使用したプロパティは、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更する際にも使用できます。

以下の C++ コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **実際の箇条書き値の取得**

プレゼンテーションの内容を抽出する際は、段落テキストとともにリストマーカーを保持します。[IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) を呼び出し、[IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/) にアクセスして有効な箇条書き書式を取得します。[get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) を読む前に、その [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/) を確認してください。

番号付きリストの場合、次の 3 つの値を区別します：

- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/) は、アラビア数字にピリオドが続く形式や小文字のアルファベットにピリオドが続く形式など、フォーマットを決定します。
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/) は、番号付き段落のグループの開始番号を指定します。
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) は、特定の段落に対する書式化されたマーカーを返します。例えば、5 から開始するリストの 2 番目の項目は `6.` を返します。

各段落に対して [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/) を保持し、ネストレベルを維持してください。実際のマーカーは完全な階層をエンコードしません。ネストされた項目は `6.c.` のような複合ラベルではなく、`c.` と返すことがあります。

以下の単体サンプルは、リストを作成しプレゼンテーションに保存し、プレゼンテーションを再読込みして各段落のテキスト、深さ、箇条書きタイプ、実際の値をレポートします。小さな青色の画像マーカーはインライン SVG から作成されています。

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IBulletFormatEffectiveData.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

{
    auto presentation = System::MakeObject<Presentation>();
    presentation->get_SlideSize()->SetSize(720, 440, SlideSizeScaleType::DoNotScale);
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_Paragraphs()->Clear();

    // 外部画像ファイルなしで画像マーカーを作成します。
    auto svg = System::MakeObject<SvgImage>(u"<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    auto bulletImage = presentation->get_Images()->AddImage(svg);

    auto addParagraph = [&](System::String text, int16_t depth, BulletType type, int16_t start = 1, NumberedBulletStyle style = NumberedBulletStyle::BulletArabicPeriod)
    {
        auto paragraph = System::MakeObject<Paragraph>();
        paragraph->set_Text(text);

        auto format = paragraph->get_ParagraphFormat();
        format->set_Depth(depth);
        format->set_MarginLeft(30 + depth * 40);
        format->set_Indent(-28);
        format->set_SpaceAfter(8);
        format->get_DefaultPortionFormat()->set_FontHeight(22);
        format->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
        auto bullet = format->get_Bullet();
        bullet->set_Type(type);
        bullet->set_IsBulletHardColor(NullableBool::True);
        bullet->get_Color()->set_Color(Color::get_Black());
        if (type == BulletType::Numbered)
        {
            bullet->set_NumberedBulletStyle(style);
            bullet->set_NumberedBulletStartWith(start);
        }
        else if (type == BulletType::Symbol)
        {
            bullet->set_Char(u'\u2022');
        }
        else if (type == BulletType::Picture)
        {
            bullet->get_Picture()->set_Image(bulletImage);
        }

        textFrame->get_Paragraphs()->Add(paragraph);
    };

    addParagraph(u"First item", 0, BulletType::Numbered, 5);
    addParagraph(u"Second item", 0, BulletType::Numbered, 5);
    addParagraph(u"Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    addParagraph(u"Back to top level", 0, BulletType::Numbered, 5);
    addParagraph(u"Symbol marker", 0, BulletType::Symbol);
    addParagraph(u"No bullet", 0, BulletType::None);
    addParagraph(u"Picture marker", 0, BulletType::Picture);
    presentation->Save(u"actual_bullet_values.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}

auto loadedPresentation = System::MakeObject<Presentation>(u"actual_bullet_values.pptx");
auto loadedShape = System::ExplicitCast<IAutoShape>(loadedPresentation->get_Slide(0)->get_Shape(0));
System::Console::WriteLine(u"Text | Depth | Type | Actual value");
for (auto paragraph : loadedShape->get_TextFrame()->get_Paragraphs())
{
    auto bullet = paragraph->get_ParagraphFormat()->GetEffective()->get_Bullet();
    auto actualValue = bullet->get_ActualBulletValue();
    System::String marker;
    switch (bullet->get_Type())
    {
        case BulletType::Numbered:
        case BulletType::Symbol:
            marker = actualValue;
            break;
        case BulletType::None:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (no bullet)";
            break;
        case BulletType::Picture:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (image required)";
            break;
        default:
            marker = u"unsupported bullet type";
            break;
    }
    System::Console::WriteLine(u"{0} | {1} | {2} | {3}", paragraph->get_Text(), paragraph->get_ParagraphFormat()->get_Depth(), bullet->get_Type(), marker);
}
loadedPresentation->Dispose();
```

以下にソースリストを示します。

![5から開始するリスト、ネストされた文字およびローマ数字項目、シンボルマーカー、箇条書きなしの段落、青い画像マーカー](actual_bullet_values.png)

レポートは PowerPoint に表示されるマーカーと一致します：

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

[BulletType::None および BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) の場合、[get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) は空文字列ではなく null の `System::String` を返します。`IsNull` を使用してこの値をチェックしてください。これらのタイプは別々に処理します。前者はマーカーがなく、後者は箇条書き画像を別途抽出する必要があります。画像箇条書きはテキストマーカーだけを抽出して再現することはできません。

## **よくある質問**

**箇条書きおよび番号付きリストは PDF や画像にエクスポートできますか？**

はい。対象フォーマットが対応するテキストレイアウトおよび箇条書き機能をサポートしている場合、Aspose.Slides はリスト書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションをロードし、対象の段落にアクセスして、その [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定を検査または更新し、プレゼンテーションを保存します。

**リストに非ラテン文字を含めることはできますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。プレゼンテーションで使用するフォントが必要な文字をサポートしていることを確認してください。