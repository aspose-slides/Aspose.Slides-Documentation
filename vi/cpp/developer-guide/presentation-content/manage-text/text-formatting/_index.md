---
title: Định dạng văn bản trình chiếu trong C++
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/cpp/text-formatting/
keywords:
- căn đoạn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động vừa
- neo khung văn bản
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Nó bao gồm các màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, tab stop và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng ta sẽ sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên bản hoặc các khớp biểu thức chính quy, xem [Tìm và Thay thế Văn bản](/slides/vi/cpp/search-and-replace-text/).

## **Đặt Màu Nền Văn Bản**

Sử dụng [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) để đặt màu nền mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) cho các phần văn bản riêng lẻ.

Ví dụ mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// Đặt màu nổi cho toàn bộ đoạn.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Đoạn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông đậm**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Đặt màu nổi cho phần văn bản.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn Lề Đoạn Văn Bản**

Sử dụng [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_alignment/) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn **ở giữa**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Đặt căn chỉnh của đoạn văn tại trung tâm.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Đoạn đã căn chỉnh](aligned_paragraph.png)

## **Đặt Độ Trong Suốt Cho Văn Bản**

Độ trong suốt văn bản được kiểm soát thông qua thành phần alpha của màu được chỉ định qua [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0‑255, không phải là phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Đặt màu tô của văn bản thành màu trong suốt.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Đoạn trong suốt](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông đậm**:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Đặt độ trong suốt cho phần văn bản.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự Cho Văn Bản**

Sử dụng [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_spacing/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Mã C++ sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // Mở rộng khoảng cách ký tự.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông đậm**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
        portionFormat->set_Spacing(3.0f); // Mở rộng khoảng cách ký tự.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Tắt Kerning Cho Các Phông Chỉ Định**

Trong một số trường hợp, văn bản được Aspose.Slides hiển thị có thể hơi chặt hơn so với cùng văn bản trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho kết quả hiển thị gần hơn với PowerPoint trong những trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Sử dụng [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) để đặt một giá trị lớn hơn đáng kể so với kích thước phông thực tế:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng nhất việc hiển thị của Aspose.Slides với PowerPoint đối với các phông chữ bị hành vi đặc thù của PowerPoint ảnh hưởng.

## **Quản Lý Thuộc Tính Phông Chữ Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) hoặc ở mức phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: áp dụng kích thước phông, đậm, nghiêng, gạch chân chấm, và phông Times New Roman cho tất cả các phần trong đoạn.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Đặt thuộc tính phông chữ cho đoạn.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thuộc tính phông cho đoạn](font_properties_for_paragraph.png)

Ví dụ mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông đậm**:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // Đặt thuộc tính phông chữ cho phần văn bản.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thuộc tính phông cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn Bản**

Sử dụng [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_textverticaltype/) để đặt hướng văn bản được định sẵn trong một hình dạng.

Mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType::Vertical270](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textverticaltype/), quay văn bản **90 độ ngược chiều kim đồng hồ**:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy Chỉnh Cho Khung Văn Bản**

Sử dụng [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_rotationangle/) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/).

Mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Xoay tùy chỉnh cho văn bản](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng Cho Các Đoạn**

Aspose.Slides cung cấp [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_spaceafter/), [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_spacebefore/) và [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_spacewithin/) để kiểm soát khoảng cách đoạn. Các phương thức này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Đặt Kiểu Tự Động Vừa Cho Khung Văn Bản**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_autofittype/) xác định cách văn bản hoạt động khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát việc văn bản co lại, tràn ra hoặc tự động thay đổi kích thước hình dạng.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Để đếm số dòng sau khi tự động ngắt dòng và xem cách văn bản hoặc chiều rộng hình dạng thay đổi, xem [Đếm Các Dòng Được Render](/slides/vi/cpp/manage-paragraph/). Số dòng chỉ đơn thuần không cho biết liệu văn bản có tràn ra ngoài vùng chứa hay không.

## **Đặt Neo Cho Khung Văn Bản**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_anchoringtype/) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Tab Cho Văn Bản**

Sử dụng [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) và [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/get_tabs/) để cấu hình tab stop trong một đoạn.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Tab trong đoạn](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/set_languageid/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được sử dụng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Mã dưới đây cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// Đặt Id của một ngôn ngữ kiểm tra chính tả.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bài thuyết trình.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Thêm một hình chữ nhật mới với văn bản.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bài thuyết trình, sử dụng [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_defaulttextstyle/).

Mã dưới đây cho thấy cách đặt phông chữ đậm mặc định với kích thước 14 pt cho tất cả văn bản trên các slide trong một bài thuyết trình mới.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// Lấy định dạng đoạn cấp độ cao nhất.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Trích Xuất Văn Bản Với Hiệu Ứng All‑Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** khiến văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là [TextCapType::All](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textcaptype/).

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu Hỏi Thường Gặp**

**Cách chỉnh sửa văn bản trong bảng trên slide?**

Để chỉnh sửa văn bản trong bảng trên slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell::get_TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/get_textframe/) và định dạng đoạn qua [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/get_paragraphformat/).

**Cách áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/get_fillformat/). Đặt [IFillFormat::set_FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifillformat/set_filltype/) thành [FillType::Gradient](https://reference.aspose.com/slides/vi/cpp/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.