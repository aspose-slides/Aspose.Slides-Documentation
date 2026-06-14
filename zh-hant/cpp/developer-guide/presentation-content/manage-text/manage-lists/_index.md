---
title: 在 C++ 簡報中管理項目符號與編號清單
linktitle: 管理清單
type: docs
weight: 70
url: /zh-hant/cpp/manage-lists/
keywords:
- 項目符號
- 項目符號清單
- 編號清單
- 符號項目符號
- 圖片項目符號
- 自訂項目符號
- 多層次清單
- 建立項目符號
- 新增項目符號
- 新增清單
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號、圖片、多層次與編號清單。"
---
## **概述**

Aspose.Slides for C++ 讓您能在 PowerPoint 和 OpenDocument 簡報中建立與格式化項目符號和編號清單。清單項目是一個段落，其項目符號設定由段落格式控制。

使用 [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/get_paragraphformat/) 方法存取段落層級的清單設定。主要入口是 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/get_bullet/)，它會回傳一個 [IBulletFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/) 物件。透過此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式以及起始編號。

本文章說明如何：

- 建立具有自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層次清單
- 建立編號清單
- 檢視並變更既有簡報中的清單格式

## **建立項目符號清單**

若要建立項目符號清單，請將 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 物件新增至 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)，並將 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為 [BulletType::Symbol](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。之後即可設定 [IBulletFormat::set_Char](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_char/)、[IBulletFormat::get_Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/get_color/) 與 [IBulletFormat::set_Height](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_height/) 以控制項目符號外觀。

以下 C++ 程式碼示範如何在投影片中建立項目符號清單：

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

結果：

![符號項目符號](symbol_bullets.png)

## **建立編號清單**

當項目順序重要時，請使用編號清單。將 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為 [BulletType::Numbered](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。您亦可使用 [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) 來選擇編號格式，或在清單需從非 1 的數值開始時使用 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)。

以下 C++ 程式碼示範如何在投影片中建立編號清單：

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

結果：

![編號項目符號](numbered_bullets.png)

## **建立圖片項目符號**

Aspose.Slides 允許您以影像取代一般的項目符號。圖片項目符號最適合使用在小尺寸仍能保持可讀性的簡單圖像，例如圖示或小型透明 PNG 檔。

{{% alert color="primary" %}}
理想情況下，如果您計畫以影像取代一般的項目符號，最好選擇具有透明背景的簡單圖形。此類圖像非常適合作為自訂的項目符號。
{{% /alert %}}

請記得影像會被縮小至非常小的尺寸。因此，我們強烈建議選擇在作為清單項目符號使用時仍能保持清晰且視覺有效的圖像。

若要建立圖片項目符號，請將影像新增至 [IPresentation::get_Images](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_images/)，並將回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件指派給 [IBulletFormat::get_Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/get_picture/)。在指派影像之前，先將 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為 [BulletType::Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。

假設我們有一個「image.png」：

![用於項目符號的圖片](picture_for_bullets.png)

以下 C++ 程式碼示範如何在投影片中建立圖片項目符號：

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

結果：

![圖片項目符號](picture_bullets.png)

## **建立多層次清單**

使用 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_depth/) 可將清單項目放在不同層級。層級 0 為最上層，層級 1 為其下的嵌套層，依此類推。

以下 C++ 程式碼示範如何建立多層次項目符號清單：

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

結果：

![多層次清單](multilevel_list.png)

## **變更既有清單**

若要變更既有簡報中的清單格式，請取得目標段落並更新其 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定。建立清單時使用的相同屬性也可用於檢視或修改從 PPT、PPTX 或 ODP 檔案載入的清單。

以下 C++ 程式碼將文字框中的第一個段落改為使用編號清單樣式：

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

## **常見問題**

**是否可以將項目符號和編號清單匯出為 PDF 或影像？**

可以。當目標格式支援相應的文字版面配置與項目符號功能時，Aspose.Slides 會保留清單格式。

**我能在既有簡報中編輯清單嗎？**

可以。載入簡報後，取得目標段落，檢視或更新其 [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定，然後儲存簡報。

**清單可以包含非拉丁文字嗎？**

可以。清單項目文字支援 Unicode 字元，您可以在多語言簡報中建立清單。請確保簡報使用的字型支援您所需的字元。