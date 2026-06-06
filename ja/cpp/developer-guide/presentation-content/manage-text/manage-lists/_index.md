---
title: C++ でプレゼンテーションの箇条書きおよび番号付きリストを管理する
linktitle: リスト管理
type: docs
weight: 70
url: /ja/cpp/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- 記号箇条書き
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
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションで箇条書き、画像、階層化、番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for C++ を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストや番号付きリストを作成および書式設定できます。リスト項目は、段落の書式設定で箇条書き設定が制御される段落です。

段落レベルのリスト設定にアクセスするには、[IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/get_paragraphformat/) メソッドを使用します。メインのエントリポイントは[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_bullet/) で、[IBulletFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、シンボル、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では、次のことを示します。

- カスタムシンボルで箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して多層リストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式設定を確認および変更する

## **箇条書きリストの作成**

箇条書きリストを作成するには、[Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) オブジェクトを[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) に追加し、[IBulletFormat::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_type/) を[BulletType::Symbol](https://reference.aspose.com/slides/ja/cpp/aspose.slides/bullettype/) に設定します。その後、[IBulletFormat::set_Char](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_char/)、[IBulletFormat::get_Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/get_color/)、[IBulletFormat::set_Height](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_height/) を設定して箇条書きの外観を制御できます。

以下の C++ コードは、スライドで箇条書きリストを作成する方法を示しています。

```cpp
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

結果:

![シンボル箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[IBulletFormat::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_type/) を[BulletType::Numbered](https://reference.aspose.com/slides/ja/cpp/aspose.slides/bullettype/) に設定します。また、[IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) で番号付スタイルを選択したり、リストを 1 以外の値から開始したい場合は[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) を設定できます。

以下の C++ コードは、スライドで番号付きリストを作成する方法を示しています。

```cpp
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

結果:

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides を使用すると、通常の箇条書きシンボルを画像に置き換えることができます。画像箇条書きは、アイコンや小さな透過 PNG ファイルなど、サイズが小さくても読みやすいシンプルな画像で最適に機能します。

 {{% alert color="primary" %}}

理想的には、通常の箇条書きシンボルを画像に置き換える場合、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書きシンボルとしてうまく機能します。

画像は非常に小さなサイズに縮小されることに注意してください。そのため、リストの箇条書きとして使用したときに鮮明で視覚的に有効な画像を選択することを強く推奨します。

{{% /alert %}}

画像箇条書きを作成するには、画像を[IPresentation::get_Images](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_images/) に追加し、返された[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) オブジェクトを[IBulletFormat::get_Picture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/get_picture/) に割り当てます。画像を割り当てる前に、[IBulletFormat::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_type/) を[BulletType::Picture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/bullettype/) に設定します。

たとえば "image.png" があるとします:

![箇条書き用の画像](picture_for_bullets.png)

以下の C++ コードは、スライドで画像箇条書きを作成する方法を示しています。

```cpp
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

結果:

![画像箇条書き](picture_bullets.png)

## **多層リストの作成**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_depth/) を使用して、リスト項目を異なるレベルに配置します。レベル 0 が最上位レベル、レベル 1 がその下位にネストされるというように階層化されます。

以下の C++ コードは、多層箇条書きリストを作成する方法を示しています。

```cpp
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

結果:

![多層リスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリストの書式設定を変更するには、対象の段落にアクセスし、[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定を更新します。リスト作成時に使用したのと同じプロパティを使用して、PPT、PPTX、または ODP ファイルから読み込んだリストを確認または変更できます。

以下の C++ コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```cpp
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

## **FAQ**

**箇条書きおよび番号付きリストは PDF や画像にエクスポートできますか？**

はい。Aspose.Slides は、対象フォーマットが対応するテキストレイアウトと箇条書き機能をサポートしている場合、リストの書式設定を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションを読み込み、対象の段落にアクセスし、[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定を確認または更新し、プレゼンテーションを保存します。

**リストに非ラテン文字テキストを含められますか？**

はい。リスト項目のテキストは Unicode 文字を含むことができるため、マルチ言語プレゼンテーションでリストを作成できます。使用するフォントが必要な文字をサポートしていることを確認してください。