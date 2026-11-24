---
title: Quản lý Chủ đề Trình chiếu trong C++
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/cpp/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- chủ đề ngoại bộ
- THMX
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- trình chiếu
- C++
- Aspose.Slides
description: "Quản trị các chủ đề trình chiếu trong Aspose.Slides cho C++ để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu định nghĩa một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, tô màu, đường kẻ và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu tới các định nghĩa chia sẻ này thay vì lưu trữ từng thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề cấp trình chiếu có sẵn thông qua [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). Một trình chiếu cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề trình chiếu thông qua [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), trong khi một layout hoặc một slide riêng lẻ có thể sử dụng [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Trên thực tế, chủ đề hiệu lực cho một slide được quyết định thông qua chuỗi kế thừa này: chủ đề trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Các phần dưới đây trình bày các luồng công việc chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu sắc và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) cung cấp các phương thức [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), và [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, tô, đường kẻ và hiệu ứng được lưu trong chủ đề:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu lực. Kiểm tra master liên quan đến slide, và sử dụng luồng công việc chủ đề‑hiệu lực được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi Màu sắc Chủ đề**

Các tô màu, đường kẻ và văn bản nhận thức chủ đề có thể tham chiếu tới một màu hợp logic từ liệt kê [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) của chủ đề, mọi đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện dưới đây tạo một hình có sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành đỏ, lưu trình chiếu, mở lại và in ra màu tô hiệu lực:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu nhìn thấy của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu hợp bằng một màu trực tiếp trên hình, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới tô màu đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – Các màu chủ đề chính.

**2** – Các biến thể sáng hơn và tối hơn được tạo ra từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí `IColorScheme`**

Liệt kê [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bảng ánh xạ cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các vị trí chủ đề; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một sơ đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) và [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được dùng trong định dạng văn bản:

* `+mn‑lt` – Phông chữ nội dung Latin (Minor Latin Font)
* `+mj‑lt` – Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn‑ea` – Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj‑ea` – Phông chữ tiêu đề Đông Á (Major East Asian Font)
* `+mn‑cs` – Phông chữ nội dung Kịch bản phức hợp (Minor Complex Script Font)
* `+mj‑cs` – Phông chữ tiêu đề Kịch bản phức hợp (Major Complex Script Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ chủ đề và lưu kết quả:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Tiêu đề theo phông chữ chính và nội dung theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script‑Specific Theme Fonts](/slides/vi/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong trình chiếu, xem [PowerPoint Fonts](/slides/vi/cpp/powerpoint-fonts/).
{{% /alert %}}

### **Giải quyết Tham chiếu Phông chữ Chủ đề**

Khi kiểm tra văn bản, [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) có thể chứa một tham chiếu chủ đề như `+mn‑lt` thay vì tên họ phông. Gọi [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) với [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) thích hợp để giải quyết tham chiếu đó. Tiền tố `+mj` và `+mn` chọn bộ phông chữ chính và phụ; hậu tố `-lt`, `-ea` và `-cs` chọn phông Latin, Đông Á và Kịch bản phức hợp tương ứng.

Lấy chủ đề hiệu lực thông qua [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) trên đối tượng mà chủ đề áp dụng cho văn bản được kiểm tra. Đối với văn bản thường trên một slide, dùng `slide->CreateThemeEffective()` để ngữ cảnh bao gồm chủ đề kế thừa của slide và các ghi đè cục bộ. Khi kiểm tra một layout hoặc master, dùng chủ đề hiệu lực của chúng. Đừng giả định rằng chủ đề của master đầu tiên áp dụng cho mọi slide.

Ví dụ sau tạo một đoạn văn bản tham chiếu rõ ràng tới phông chữ Latin phụ. Nó khởi tạo sơ đồ phông chữ slide qua [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) và đặt họ phông Latin chính và phụ thành `Arial` và `Calibri`, làm cho kết quả có thể tái tạo mà không cần tệp đầu vào.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

Kết quả là `+mn‑lt -> Calibri` tiếp theo là `Verdana -> Verdana`. Tham chiếu được lưu vẫn không đổi, trong khi một họ phông cụ thể được trả về nguyên vẹn. Nếu đoạn văn sử dụng `+mj‑lt`, nó sẽ giải quyết thành `Arial` trong chủ đề này.

Giải quyết một tham chiếu chủ đề xác định họ phông chữ mà chủ đề chỉ định. Nó không kiểm tra tính khả dụng của phông hoặc xác định tệp phông cuối cùng được dùng sau khi thay thế hoặc fallback glyph trong quá trình render. Xem [Font Selection Sequence](/slides/vi/cpp/font-selection-sequence/) và [Font Substitution](/slides/vi/cpp/font-substitution/) cho các bước riêng biệt đó.

## **Sao chép hoặc Áp dụng một Chủ đề**

Các luồng công việc dưới đây giải quyết các vấn đề khác nhau liên quan đến chủ đề.

### **Áp dụng Chủ đề Ngoại bộ cho Các Slide Phụ Thuộc vào Master**

Sử dụng [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề ngoại bộ vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) mới được tạo.

Ví dụ sau áp dụng một chủ đề ngoại bộ vào các slide phụ thuộc vào master đầu tiên và lưu trình chiếu:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);

auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");
Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());

presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) hoặc một trong các lớp con liên quan tới định dạng. Xác thực đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và chỉ lưu trình chiếu sau khi chủ đề đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác vẫn giữ master và chủ đề hiện tại. Các màu, phông chữ, tô, đường kẻ, nền và hiệu ứng nhận thức chủ đề được giải quyết dựa trên chủ đề ngoại bộ. Các màu, phông chữ, tô và định dạng rõ ràng được gán trực tiếp có thể không thay đổi. Các ghi đè ở cấp layout và slide cũng có thể ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu tới các phông chữ không có trong môi trường runtime. Để đảm bảo việc render và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông chữ tùy chỉnh](/slides/vi/cpp/custom-font/), hoặc cấu hình [thay thế phông chữ](/slides/vi/cpp/font-substitution/).

Đây là một luồng công việc cấp master trực tiếp: phương thức nhận một đường dẫn tới tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở cấp slide hoặc layout.

### **Áp dụng Các Chủ đề Ngoại bộ Khác nhau trong Một Trình chiếu Đa‑Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện thông qua [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) và [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong trình chiếu.

Ví dụ sau sử dụng các slide từ hai phần để xác định master của chúng và áp dụng một chủ đề ngoại bộ khác nhau cho mỗi nhóm:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());

        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Lệnh gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lệnh gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang một trình chiếu khác và bảo tồn thiết kế gốc, sao chép master nguồn vào trình chiếu đích bằng [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), sau đó sao chép slide với [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");

auto sourceSlide = source->get_Slide(0);

auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);

target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Đây là luồng công việc ưu tiên khi slide nguồn phải trông giống hệt trong điểm đến. Chỉ sao chép nội dung vào một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Một Slide hiện có**

Nếu slide đích phải ở trên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), và [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) sao chép ba thành phần chính của chủ đề vào ghi đè.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Điều này thay đổi chủ đề được slide sử dụng mà không thay đổi chủ đề kế thừa bởi các slide khác. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Chủ đề cho Một Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được dùng qua [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) của layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Sử dụng một chủ đề cấp master hoặc trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, một ghi đè layout khi một nhóm layout cần kiểu dáng khác, và một ghi đè slide chỉ cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi chủ đề toàn cục sau này trở nên khó dự đoán.

## **Cập nhật Kiểu nền Chủ đề**

Các tô nền của chủ đề được lưu trong [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint có thể hiển thị nhiều tùy chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa tô màu thực tế trong bộ sưu tập này vì UI có thể kết hợp các tô chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` dùng `0` cho không có tô nền chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ mục trực tiếp một bộ sưu tập C++ bằng `idx_get(0)`, trong đó `0` nghĩa là mục đầu tiên được lưu. Đừng giả định mọi trình chiếu đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền khả dụng, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu trình chiếu:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);

    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}
Đừng coi `StyleIndex` là chỉ mục bộ sưu tập dựa trên chỉ số 0. Cũng tránh việc cứng mã một số kiểu từ một tệp và giả định nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho mỗi trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/cpp/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/), và [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Các chủ đề Office điển hình thường chứa ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong C++, chỉ mục bộ sưu tập bắt đầu từ 0: `idx_get(0)` là kiểu đầu tiên được lưu và `idx_get(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình là một khái niệm riêng, được cung cấp qua [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Thay đổi một kiểu chủ đề ảnh hưởng tới các hình tham chiếu kiểu đó; các hình có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu yêu cầu, thay đổi kiểu đường kẻ đầu tiên, thay đổi kiểu tô thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Đối với các hình tham chiếu các vị trí này, kiểu đường kẻ chủ đề đầu tiên trở thành đỏ, kiểu tô chủ đề thứ ba trở thành xanh rừng đặc, và kiểu hiệu ứng thứ ba nhận bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào việc mỗi hình tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Chọn Kiểu Tô và Đường kẻ Chủ đề cho Một Hình**

Một hình có thể chọn tô và viền một cách độc lập qua [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) và [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). Đối với cả hai setter, chỉ mục `1` chọn mục đầu tiên trong bộ sưu tập chủ đề tương ứng (`idx_get(0)`), và chỉ mục `2` chọn mục thứ hai.

Ví dụ sau thiết lập hai kiểu tô (vàng và xanh trời) và hai kiểu đường kẻ (xanh đậm 6 pt và đỏ đậm 12 pt) trong chủ đề mặc định của một trình chiếu mới. Nó lưu slide ở ba giai đoạn để bạn có thể so sánh kết quả trong PowerPoint.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| Kiểu ban đầu | Thay đổi viền bên phải | Chỉnh sửa tô chủ đề đầu tiên |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Chọn một kiểu đường kẻ khác chỉ thay đổi viền của hình chữ nhật bên phải. Chỉnh sửa tô chủ đề đầu tiên cập nhật mọi hình sử dụng nó. Ở đây, chỉ hình chữ nhật bên trái trở thành xanh lá.

Trên một hình đã tồn tại, một màu tô cục bộ, màu đường kẻ hoặc độ rộng đường kẻ có thể ghi đè phần đó của kiểu chủ đề. Nếu việc thay đổi chỉ mục kiểu không có hiệu ứng hiển thị, hãy kiểm tra [định dạng trực tiếp](/slides/vi/cpp/shape-formatting/) của hình.

## **Xác định Liệu một Tô Đặc sắc Hiệu lực có Sử dụng Màu Chủ đề hay Không**

Một tô có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, kiểu chủ đề, hoặc một mức định dạng khác. Gọi [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) để giải quyết thứ tự phân cấp thành một [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/) bất biến. Đầu tiên kiểm tra [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Chỉ khi nó là `FillType::Solid` bạn mới nên đọc các thuộc tính tô đặc.

Đối với tô đặc, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) trả về giá trị RGB cuối cùng sau khi kế thừa, tra cứu chủ đề và áp dụng biến đổi màu. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) trả về vị trí logic [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor::NotDefined` nghĩa là tô đặc hiệu lực không dựa trên màu hợp.

Đừng chỉ dùng giá trị [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) cục bộ để phân loại một tô. Ví dụ, một đoạn văn có thể không có màu hợp được định nghĩa cục bộ, vì vậy giá trị cục bộ là `NotDefined`, trong khi tô hiệu lực kế thừa một màu chủ đề và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `get_SolidFillSchemeColor` cho bạn biết vị trí hợp nào tạo ra màu hiệu lực, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay cấp độ định dạng nào khác.

Ví dụ sau tải một trình chiếu, kiểm tra cả tô hình và tô đoạn văn bản, in mỗi giá trị RGB cuối cùng và màu hợp tương ứng, và đánh dấu các tô đặc sẽ không theo dõi thay đổi màu chủ đề:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

Nhánh `NotDefined` cung cấp danh sách kiểm tra các tô đặc sẽ không phản hồi với các thay đổi trong các vị trí màu chủ đề. Xem lại các đối tượng này khi một trình chiếu phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn hiển thị giao diện hiện tại, trong khi giá trị hợp giải thích liệu giao diện đó có liên kết với chủ đề hay không.

Các đối tượng định dạng‑hiệu lực là ảnh chụp. Sau khi thay đổi chủ đề trình chiếu, một ghi đè chủ đề, hoặc bất kỳ định dạng kế thừa nào, gọi lại `GetEffective` và đọc một `IFillFormatEffectiveData` mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở một cấp độ cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc hình thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Đối với nền, dùng [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), và đối với tô, dùng [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

Ví dụ sau đọc chủ đề hiệu lực, nền và tô của hình đầu tiên từ một slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Sử dụng dữ liệu hiệu lực cho việc chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), bạn có thể bỏ lỡ một master, layout, slide, hoặc ghi đè hình thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề ngoại bộ có ảnh hưởng tới mọi slide trong trình chiếu không?**

Không. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide dùng các master khác vẫn giữ chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để mang một chủ đề từ trình chiếu này sang trình chiếu khác là gì?**

Khi di chuyển một slide và bảo tồn giao diện nguồn, sao chép master nguồn vào đích và sao chép slide với master đó bằng [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) và [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Điều này giữ lại master, các layout và chủ đề cùng nhau.

**Làm sao để xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) cho một slide hoặc layout và các phương thức dữ liệu‑hiệu lực tương ứng cho các đối tượng định dạng như [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) và [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.