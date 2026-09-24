---
title: 使用 C++ 管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- 新增文字
- 新增段落
- 管理文字
- 管理段落
- 管理項目符號
- 段落縮排
- 懸掛縮排
- 段落項目符號
- 編號清單
- 項目符號清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉影像
- 文字轉影像
- 匯出段落
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for C++ 建立與格式化段落、文字區塊、項目符號、編號清單、縮排、HTML 內容與段落影像。"
---
## **概觀**

Aspose.Slides for C++ 以文字框、段落與文字區塊的階層結構表示文字：

* [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 表示形狀中的文字容器，並提供對其段落集合的存取。
* [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 表示文字框中的一個段落，並提供對其文字區塊與段落層級格式的存取。
* [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 表示段落內的文字執行區塊。每個文字區塊可以擁有自己的文字與字元層級格式。

因此，段落可以透過多個文字區塊包含不同字型、顏色、大小與其他格式的文字。

## **建立與格式化段落**

### **建立具有多個文字區塊的段落**

以下步驟會建立一個文字框，內含三個段落，每個段落各有三個文字區塊：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在投影片上加入矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 使用預設段落，並再加入兩個 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/) 物件到文字框。
6. 為每個段落加入足夠的 [IPortion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/) 物件，使其包含三個文字區塊。預設段落已包含一個空的文字區塊。
7. 設定每個文字區塊的文字內容。
8. 透過 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/get_portionformat/) 套用字元層級格式。
9. 儲存已修改的簡報。

以下 C++ 範例實作上述步驟：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **建立項目符號與編號清單**

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易掃描。在 Aspose.Slides 中，清單設定透過 [IBulletFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/) 定義。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在選取的投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/)。
7. 將 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為 [BulletType::Symbol](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/) 並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，將 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為 [BulletType::Numbered](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。
11. 設定編號項目樣式，並將段落加入文字框。
12. 儲存簡報。

以下 C++ 範例會建立符號項目與編號項目：

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **使用圖片項目符號**

圖片項目符號讓您使用自訂影像取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 並取得其 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號影像，並以 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 加入簡報的影像集合。
6. 建立 [Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraph/) 並設定文字。
7. 將 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_type/) 設為 [BulletType::Picture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/bullettype/)。
8. 透過 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/set_image/) 指定影像並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

以下 C++ 範例會建立圖片項目符號：

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **建立多層次清單**

將 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_depth/) 設為不同值，即可將段落放置於清單的不同層級。最高層的深度為 `0`。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 並取得投影片。
2. 加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 並清除其文字框中的預設段落。
3. 建立四個段落並設定其項目符號字元。
4. 將它們的 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_depth/) 設為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框並儲存簡報。

以下 C++ 範例會建立四層項目符號清單：

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **自訂編號項目的起始值**

使用 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 來設定編號段落的起始數字。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 並在投影片上加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
2. 清除形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 分別將 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 設為 `2`、`3`、`7`。
5. 將段落加入文字框並儲存簡報。

以下 C++ 範例會為每個段落指定自訂的起始編號：

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **控制段落佈局與結尾屬性**

### **設定首行縮排**

使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 來控制段落的首行縮排。此方法僅移動首行相對於段落左邊距的水平位置。正值會將首行向右移，其餘行則保持與段落本體對齊。

若需移動整段文字，請使用 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginleft/)；若只需移動首行，則使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/)。

以下範例建立多個段落，並套用不同的 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 值，以示範首行縮排對段落佈局的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上加入矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 並移除預設段落。
5. 建立數個段落，為它們設定不同的 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

以下程式碼示範如何設定段落縮排：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落的首行縮排](first_line_indent.png)

### **設定懸掛縮排**

懸掛縮排是指第一行位於其餘行左側的段落佈局。於 Aspose.Slides 中，可透過 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 並將縮排設為負值，以將第一行向左移動。

實務上，[IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginleft/) 定義段落本體的左側位置，而 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 定義第一行相對於該左側位置的偏移。若要產生懸掛縮排，請將左側邊距設為正值，縮排設為負值。

此格式在參考文獻、書目、詞彙表等段落中特別有用，因為換行後的文字需對齊於段落本體而非第一行的第一個字元。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上加入矩形 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
4. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 並移除預設段落。
5. 為每個段落設定正的 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginleft/) 值。
6. 設定負的 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_indent/) 值，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

以下程式碼示範如何為段落設定懸掛縮排：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落的懸掛縮排](hanging_indent.png)

### **設定段落結尾執行屬性**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 控制段落結尾標記的格式。以下範例為第二個段落的結尾標記指定字型大小與拉丁字型：

1. 載入 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 並取得投影片。
2. 加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 並清除其預設段落。
3. 建立兩個段落，並為它們加入文字區塊。
4. 為第二個段落的結尾標記建立 [PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portionformat/)。
5. 設定 [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_fontheight/) 與 [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_latinfont/)。
6. 透過 [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 套用格式，並儲存簡報。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **計算呈現行數**

使用 [IParagraph::GetLinesCount](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getlinescount/) 可取得段落在排版後實際佔用的行數，包含自動換行。此功能在檢查簡報範本中文本長度與佈局時相當有用。

段落是 [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_paragraphs/) 中的一個項目，可能會佔用多個呈現行。段落內的顯式換行會強制產生新行，但不會建立新段落。自動換行則根據可用寬度產生行，而不會在文字中插入換行字元。因此，僅計算段落或換行字元無法得到實際的呈現行數。

以下範例建立文字形狀，計算其行數，縮小形狀，然後以較短的字串取代文字。範例啟用換行並停用自動調整大小，以讓形狀寬度控制換行而不自動縮小文字或調整形狀大小。形狀尺寸以點為單位。最後，範例再加入另一個段落，並將整個文字框的行數相加。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

使用此文字與這些尺寸時，縮小形狀會增加行數，而以短字串取代文字會減少行數。精確的行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動調整設定而異；請在檢查範本時使用目標環境的字型與佈局設定。

僅憑行數並無法判斷文字是否會溢出其容器。可用高度、行高、段落與行間距以及自動調整行為同樣重要；即使只有一行，若關閉換行，仍可能超出可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphcollection/addfromhtml/) 可將 HTML 標記轉換為文字框中的段落與文字區塊。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 取得投影片並加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
3. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳遞給 [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphcollection/addfromhtml/)。
6. 儲存已修改的簡報。

以下 C++ 範例將 HTML 匯入文字框：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **將段落文字匯出為 HTML**

使用 [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphcollection/exporttohtml/) 可將選取的段落範圍匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例，並載入目標簡報。
2. 取得投影片，找出包含文字的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/)。
3. 取得形狀的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。
4. 使用起始段落索引與欲匯出的段落數目呼叫 [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphcollection/exporttohtml/)。
5. 將回傳的 HTML 字串寫入檔案。

以下 C++ 範例會匯出第一個文字形狀中的所有段落：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **將段落渲染為影像**

[IParagraph::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getimage/) 直接渲染單一段落，並回傳 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/)。您可以使用 [IImage::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/) 將結果儲存為檔案或串流，無需先渲染整個形狀或自行裁切點陣圖。

如果段落在父集合中找不到、沒有有效的渲染邊界，或無法渲染，[IParagraph::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getimage/) 可能會回傳 `nullptr`。請在儲存之前檢查結果，使用完畢後記得釋放影像。

#### **以預設比例渲染段落**

假設我們有一個名為 sample.pptx 的簡報檔，內含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下範例會以預設比例渲染第二個段落，並以 PNG 格式儲存回傳的影像。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

結果：

![段落影像](paragraph_to_image_output.png)

#### **在表格儲存格中以縮放渲染段落**

使用接受 `float scaleX` 與 `float scaleY` 參數的 [IParagraph::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getimage/) 版本，可設定水平與垂直的縮放係數。以下範例建立一個表格，於其第一個儲存格中以兩倍寬度與高度渲染段落，並將結果存為 PNG 影像。

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

縮放係數為 `1` 時表示該軸維持預設像素大小。例如，兩個係數皆為 `2` 時，產生的影像寬度與高度約為預設的兩倍，像素數量則為四倍。較大的係數一般可提供更銳利的文字，適合放大或高解析度輸出，但也會增加記憶體使用與檔案大小。小於 `1` 的係數會產生較小且細節較少的影像。使用相同的係數可保留段落的長寬比；不同的水平與垂直係數則會分別拉伸輸出。

在需要同時呈現形狀填色、邊框或其他視覺資訊時，仍可使用 [IShape::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/getimage/) 來渲染整個形狀。若僅需段落影像，請使用 [IParagraph::GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getimage/)。

## **常見問題**

**可以完全停用文字框內的換行嗎？**

可以。使用 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/set_wraptext/) 來停用換行，使行不會在文字框邊緣斷開。

**如何取得特定段落在投影片上的精確邊界？**

使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/getrect/) 取得段落的外接矩形。[IPortion::GetRect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportion/getrect/) 則提供單一文字區塊的邊界。

**段落對齊方式（左、右、置中或兩端對齊）在哪裡設定？**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_alignment/) 為段落層級設定，會套用於整個段落，與個別文字區塊的格式無關。

**可以為段落的部分文字設定校對語言嗎？**

可以。使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/set_languageid/) 為個別文字區塊指定語言，讓同一段落內包含多種語言的文字。