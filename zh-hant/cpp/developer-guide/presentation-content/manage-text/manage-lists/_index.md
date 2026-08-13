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
## **概觀**

Aspose.Slides for C++ 讓您能在 PowerPoint 和 OpenDocument 簡報中建立與格式化項目符號與編號清單。清單項目是一個段落，其項目符號設定透過段落格式來控制。

使用[IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/get_paragraphformat/) 方法存取段落層級的清單設定。主要入口是[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/get_bullet/)，它會回傳一個[IBulletFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/) 物件。使用此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式以及起始編號。

本文章說明如何：

- 建立使用自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層次清單
- 建立編號清單
- 檢視並變更既有簡報中的清單格式

## **建立項目符號清單**

若要建立項目符號清單，將[Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 物件新增至[ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)，並將[IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為[BulletType::Symbol](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。之後您可以設定[IBulletFormat::set_Char](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_char/)、[IBulletFormat::get_Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/get_color/) 與[IBulletFormat::set_Height](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_height/) 以控制項目符號外觀。

以下 C++ 程式碼示範如何在投影片中建立項目符號清單：

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

![符號項目符號](symbol_bullets.png)

## **建立編號清單**

當項目順序很重要時，請使用編號清單。將[IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為[BulletType::Numbered](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。您也可以使用[IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) 選擇編號格式，或在清單需從非 1 的值開始時使用[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/)。

以下 C++ 程式碼示範如何在投影片中建立編號清單：

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

![編號項目符號](numbered_bullets.png)

## **建立圖片項目符號**

Aspose.Slides 允許您以圖片取代一般的項目符號。圖片項目符號最適合使用簡單且在小尺寸下仍可辨識的圖像，例如圖示或小型透明 PNG 檔。

{{% alert color="info" %}}
理想情況下，如果您打算以圖片取代一般的項目符號，最好選擇具有透明背景的簡易圖形。此類圖像非常適合作為自訂項目符號。

請記住，圖片會被縮小到非常小的尺寸。因此，我們強烈建議選擇在作為清單項目符號使用時仍保持清晰且視覺有效的圖片。
{{% /alert %}}

若要建立圖片項目符號，先將圖片新增至[IPresentation::get_Images](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_images/)，並將回傳的[IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 物件指派給[IBulletFormat::get_Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/get_picture/)。在指派圖片之前，先將[IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為[BulletType::Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。

假設我們有一個 "image.png"：

![用於項目符號的圖片](picture_for_bullets.png)

以下 C++ 程式碼示範如何在投影片中建立圖片項目符號：

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

![圖片項目符號](picture_bullets.png)

## **建立多層次清單**

使用[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_depth/) 可將清單項目放置於不同層級。層級 0 為最高層，層級 1 為其下的子層，依此類推。

以下 C++ 程式碼示範如何建立多層次項目符號清單：

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

![多層次清單](multilevel_list.png)

## **變更既有清單**

若要變更既有簡報中的清單格式，存取目標段落並更新其[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定。建立清單時使用的相同屬性亦可用於檢視或修改從 PPT、PPTX 或 ODP 檔載入的清單。

以下 C++ 程式碼將文字框中的第一個段落改為使用編號清單樣式：

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

## **常見問題**

### 可以將項目符號與編號清單匯出為 PDF 或影像嗎？

可以。Aspose.Slides 會在目標格式支援相應文字排版與項目符號功能時保留清單格式。

### 我可以編輯既有簡報中的清單嗎？

可以。載入簡報後，存取目標段落，檢視或更新其[IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/get_bullet/) 設定，然後儲存簡報。

### 清單可以包含非拉丁文字嗎？

可以。清單項目文字可以包含 Unicode 字元，因此您可以在多語言簡報中建立清單。請確保簡報使用的字型支援所需的字元。