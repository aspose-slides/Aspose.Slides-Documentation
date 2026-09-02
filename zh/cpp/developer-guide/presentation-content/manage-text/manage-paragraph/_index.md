---
title: 在 C++ 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 创建和格式化段落、文本段、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for C++ 将文本表示为文本框、段落和文本段的层次结构：

* [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 表示文本框中的一个段落，并提供对其文本段以及段落级格式的访问。
* [IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/) 表示段落内的文本运行。每个文本段可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个文本段来包含具有不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **创建具有多个文本段的段落**

以下步骤创建一个包含三个段落、每个段落包含三个文本段的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。
5. 使用默认段落并向文本框再添加两个 [IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/) 对象。
6. 为每个段落添加足够的 [IPortion](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/) 对象，使其包含三个文本段。默认段落已包含一个空的文本段。
7. 设置每个文本段的文本。
8. 通过 [IPortion::get_PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/get_portionformat/) 应用字符级格式。
9. 保存修改后的演示文稿。

下面的 C++ 示例实现了这些步骤：

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

## **创建项目符号和编号列表**

### **创建项目符号或编号列表**

项目符号和编号使相关项目更易于浏览。在 Aspose.Slides 中，列表设置通过 [IBulletFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/) 定义。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向所选幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/)。
7. 将 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_type/) 设置为 [BulletType::Symbol](https://reference.aspose.com/slides/zh/cpp/aspose.slides/bullettype/) 并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落，并将 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_type/) 设置为 [BulletType::Numbered](https://reference.aspose.com/slides/zh/cpp/aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

下面的 C++ 示例创建了符号项目符号和编号项目符号：

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

### **使用图片项目符号**

图片项目符号允许使用自定义图像代替符号或数字。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 并访问其 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [IPPImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ippimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/paragraph/) 并设置其文本。
7. 将 [IBulletFormat::set_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_type/) 设置为 [BulletType::Picture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/bullettype/)。
8. 通过 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidespicture/set_image/) 分配图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

下面的 C++ 示例创建了图片项目符号：

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

### **创建多级列表**

将 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_depth/) 设置为在列表中将段落放置在不同层级。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_depth/) 值设置为 `0`、`1`、`2` 和 `3`。
5. 将段落添加到文本框并保存演示文稿。

下面的 C++ 示例创建了一个四级项目符号列表：

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

### **自定义编号列表起始值**

使用 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 设置编号段落的起始数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 并向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
2. 清除形状的文本框中的默认段落。
3. 创建三个编号段落。
4. 将 [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) 分别设置为 `2`、`3` 和 `7`。
5. 将段落添加到文本框并保存演示文稿。

下面的 C++ 示例为每个段落分配自定义起始编号：

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

## **控制段落布局和结束属性**

### **设置首行缩进**

使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 控制段落的首行缩进。此方法仅移动相对于段落左边距的第一行。正值会将首行向右移动，而其余行保持与段落正文对齐。

当需要移动整段时使用 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_marginleft/)。仅需移动首行时使用 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/)。

下面的示例创建了多个段落，并应用不同的 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 值，以演示首行缩进如何影响段落布局。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 并移除默认段落。
5. 创建多个段落，并为它们设置不同的 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

以下代码演示如何设置段落缩进：

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

结果：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，其中第一行位于其余行的左侧。在 Aspose.Slides 中，可通过 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 实现此效果。将缩进设为负值可使第一行相对于段落正文左移。

在实践中，[IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_marginleft/) 定义段落正文的左侧位置，而 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 定义第一行相对于该边距的位置。要创建悬挂缩进，请设置正的 margin-left 值和负的 indent 值。

此格式对参考文献、书目、词汇表条目等段落尤其有用，此类段落的换行行应在段落正文下方对齐，而不是在首行首字符下方对齐。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 并移除默认段落。
5. 创建段落并为每个段落设置一个正的 [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_marginleft/) 值。
6. 将负的 [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_indent/) 值设置为创建悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

以下代码演示如何为段落设置悬挂缩进：

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

结果：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落结束运行属性**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 控制段落结束标记的格式。下面的示例为第二段落的结束标记分配字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 并清除其默认段落。
3. 创建两个段落并向它们添加文本段。
4. 为第二个段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/portionformat/)。
5. 设置 [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_fontheight/) 和 [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_latinfont/)。
6. 使用 [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) 分配该格式并保存演示文稿。

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

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphcollection/addfromhtml/) 将 HTML 标记转换为文本框中的段落和文本段。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例。
2. 访问一张幻灯片并添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphcollection/addfromhtml/)。
6. 保存修改后的演示文稿。

下面的 C++ 示例将 HTML 导入文本框：

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

### **将段落文本导出为 HTML**

使用 [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphcollection/exporttohtml/) 将选定范围的段落导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。
4. 调用 [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphcollection/exporttohtml/)，提供起始段落索引和要导出的段落数量。
5. 将返回的 HTML 字符串写入文件。

下面的 C++ 示例导出第一个文本形状中的所有段落：

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

### **将段落渲染为图像**

[IParagraph::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getimage/) 直接渲染单个段落并返回一个 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/)。使用 [IImage::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/save/) 将结果保存到文件或流。无需渲染包含的形状或手动裁剪位图。

[IParagraph::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getimage/) 在以下情况下可能返回 `nullptr`：段落在其父集合中未找到、没有有效的渲染边界或无法渲染。保存前请检查结果，并在使用后释放返回的图像。

#### **按默认尺度渲染段落**

假设我们有一个名为 sample.pptx 的演示文稿文件，包含一张幻灯片，第一形状是一个包含三段文字的文本框。

下面的示例在默认尺度下渲染常规文本形状中的第二段，并以 PNG 格式保存返回的图像。

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

结果：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中按比例渲染段落**

使用接受 `float scaleX` 和 `float scaleY` 参数的 [IParagraph::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getimage/) 重载来设置水平和垂直比例因子。下面的示例创建一个表格，在其第一个单元格中以默认宽高的两倍渲染段落，并将结果保存为 PNG 图像。

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

因子为 `1` 时保持该轴的默认像素尺寸。例如，两个因子均为 `2` 时，生成的图像宽高约为默认尺寸的两倍，像素数量约为四倍。较大的因子通常能为放大或高分辨率输出提供更清晰的文字，但也会增加内存使用和文件大小。因子低于 `1` 会生成更小、细节更少的图像。使用相同的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

在需要包含形状填充、边框或其他视觉上下文时，使用 [IShape::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/getimage/) 渲染整个形状仍然有用。仅需段落图像时，请使用 [IParagraph::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getimage/)。

## **常见问题**

**我能完全禁用文本框内的换行吗？**

可以。使用 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_wraptext/) 禁用换行，这样行就不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [IParagraph::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/getrect/) 获取段落的边界矩形。 [IPortion::GetRect](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportion/getrect/) 提供单个文本段的边界。

**段落对齐方式（左、右、居中或两端对齐）在哪里控制？**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_alignment/) 是段落级别的设置，适用于整个段落，而不受单个文本段格式的影响。

**我能为段落的部分内容设置校对语言吗？**

可以。对单个文本段使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_languageid/)，因此一个段落可以包含多种语言的文本。