---
title: Định dạng Văn bản Trình chiếu trong C++
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/cpp/text-formatting/
keywords:
- đánh dấu văn bản
- biểu thức chính quy
- căn chỉnh đoạn văn
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
- căn tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Định dạng và tạo kiểu cho văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn thế nữa."
---
## **Tổng quan**

Bài viết này mô tả cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho C++. Nó đề cập đến việc tô sáng, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, dấu tab và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng tôi sẽ sử dụng tệp có tên "sample.pptx", trong đó chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Tô sáng Văn bản**

Sử dụng phương thức [ITextFrame.HighlightText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlighttext/) khi bạn cần tô sáng văn bản khớp với một mẫu cụ thể trong khung văn bản. Phương thức áp dụng màu tô sáng cho các đoạn văn bản khớp và có thể được dùng cùng với [ITextSearchOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextsearchoptions/) để kiểm soát cách tìm kiếm, ví dụ, chỉ khớp toàn từ.

Ví dụ mã dưới đây tô sáng tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ tô sáng từ đầy đủ **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Lấy hình dạng đầu tiên từ slide đầu tiên.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Tô sáng từ "try" trong hình dạng.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Tô sáng từ "to" trong hình dạng.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Văn bản được tô sáng](highlighted_text.png)

## **Tô sáng Văn bản bằng Biểu thức Chính quy**

Phương thức [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/highlightregex/) tô sáng các kết quả khớp được tìm thấy bằng biểu thức chính quy. Trong C++, API này được cung cấp trên [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/).

Ví dụ mã dưới đây tô sáng tất cả các từ chứa **bảy ký tự trở lên**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Tô sáng tất cả các từ có bảy ký tự trở lên.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Văn bản được tô sáng bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt Màu Nền cho Văn bản**

Sử dụng `DefaultPortionFormat` của [IParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/) để đặt màu tô sáng mặc định cho một đoạn, hoặc sử dụng `HighlightColor` của [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/) cho các phần văn bản riêng lẻ.

Ví dụ mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây cho thấy cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Đặt màu tô sáng cho phần văn bản.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh Đoạn Văn bản**

Sử dụng `Alignment` của [IParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn văn **ở giữa**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Đặt căn chỉnh của đoạn văn thành trung tâm.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Đoạn văn đã được căn giữa](aligned_paragraph.png)

## **Đặt Độ Trong Suốt cho Văn bản**

Độ trong suốt của văn bản được kiểm soát qua thành phần alpha của màu được gán cho `FillFormat` của [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0‑255, không phải là phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Đặt màu tô cho văn bản thành màu trong suốt.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Đặt độ trong suốt cho phần văn bản.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự cho Văn bản**

Sử dụng `Spacing` của [IBasePortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Mã C++ sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô hiệu hoá Kerning cho Các Phông Chữ Cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ đó chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để làm cho đầu ra render gần giống hơn với PowerPoint trong những trường hợp như vậy, bạn có thể vô hiệu hoá kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt `KerningMinimalSize` của [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/) thành một giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
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

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ việc render của Aspose.Slides với kết quả hiển thị của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint.

## **Quản lý Thuộc tính Phông chữ Văn bản**

Các thuộc tính phông chữ có thể được đặt ở mức đoạn qua `DefaultPortionFormat` của [IParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/) hoặc trên các phần riêng lẻ qua [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: áp dụng kích thước phông chữ, in đậm, in nghiêng, gạch chân chấm, và phông Times New Roman cho tất cả các phần trong đoạn.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Đặt các thuộc tính phông chữ cho đoạn văn.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thuộc tính phông chữ cho đoạn văn](font_properties_for_paragraph.png)

Ví dụ mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ in đậm**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // Đặt các thuộc tính phông chữ cho phần văn bản.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn bản**

Sử dụng `TextVerticalType` của [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) để đặt hướng văn bản định sẵn trong một hình.

Mã dưới đây đặt hướng văn bản trong hình thành `Vertical270`, làm xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy chỉnh cho Khung Văn bản**

Sử dụng `RotationAngle` của [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/).

Mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng cách Dòng cho Đoạn Văn bản**

Aspose.Slides cung cấp `SpaceAfter`, `SpaceBefore` và `SpaceWithin` của [IParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng tỷ lệ phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Đặt Kiểu Tự động Vừa cho Khung Văn bản**

`AutofitType` của [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) xác định cách văn bản hành xử khi vượt quá ranh giới của container. Sử dụng nó để kiểm soát việc văn bản thu nhỏ, tràn, hay tự động thay đổi kích thước hình.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Neo cho Khung Văn bản**

`AnchoringType` của [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) định nghĩa cách văn bản được định vị theo chiều dọc bên trong một hình, ví dụ ở trên, giữa hoặc dưới.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Tab cho Văn bản**

Sử dụng `DefaultTabSize` và `Tabs` của [IParagraphFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/) để cấu hình các dấu tab trong một đoạn.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kết quả:

![Các tab trong đoạn văn](paragraph_tabs.png)

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp `LanguageId` của [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này xác định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Mã dưới đây cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Đặt Id của ngôn ngữ kiểm tra.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Đặt Ngôn ngữ Mặc định**

Sử dụng `DefaultTextLanguage` của [ILoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iloadoptions/) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Thêm một hình chữ nhật mới có văn bản.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Đặt Kiểu Văn bản Mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng `DefaultTextStyle` của [IPresentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/).

Mã dưới đây cho thấy cách đặt phông chữ in đậm mặc định kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Lấy định dạng đoạn văn cấp cao nhất.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Trích xuất Văn bản với Hiệu ứng Viết Hoa Tất Cả**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** khiến văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra `TextCapType` và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng Viết hoa toàn bộ](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** được áp dụng:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Cách sửa văn bản trong bảng trên một slide?**

Để sửa văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/). Duyệt qua các ô và cập nhật từng ô thông qua `TextFrame` của [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) và định dạng đoạn qua `ParagraphFormat` của [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/).

**Cách áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng `FillFormat` của [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/). Đặt `FillType` của [IFillFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifillformat/) thành `Gradient` và cấu hình các điểm dừng gradient, hướng và độ trong suốt.