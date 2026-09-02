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
description: "Quản lý chủ đề trình chiếu trong Aspose.Slides cho C++ để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với nhận diện thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu xác định một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, màu nền, đường nét và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính hình ảnh dưới dạng giá trị cố định, do đó việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề ở mức trình chiếu có thể truy cập qua [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_mastertheme/). Một trình chiếu cũng có thể chứa các ghi đè chủ đề ở các mức thấp hơn. Một master có thể ghi đè chủ đề trình chiếu qua [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), trong khi một layout hoặc một slide riêng lẻ có thể sử dụng [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Thực tế, chủ đề hiệu lực cho một slide được giải quyết qua chuỗi kế thừa này: chủ đề trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây cho thấy các quy trình làm việc phổ biến nhất với chủ đề: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/mastertheme/) cung cấp các phương thức [get_ColorScheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), và [get_FormatScheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của chủ đề và báo cáo số lượng kiểu nền, màu nền, đường nét và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu lực. Kiểm tra master liên kết với slide, và sử dụng quy trình làm việc chủ đề hiệu lực được trình bày sau trong bài viết khi có thể có các ghi đè layout hoặc slide.

## **Thay đổi màu Chủ đề**

Các màu, đường nét và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/icolorscheme/) của chủ đề, tất cả các đối tượng vẫn tham chiếu đến màu chủ đề đó sẽ được giải quyết theo giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ end‑to‑end sau tạo một shape sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu trình chiếu, mở lại và in màu nền thực tế:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ thành màu đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên shape, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến màu nền đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua [ColorTransformOperation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu nhạt hơn và tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.  
**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

### **Ánh xạ giá trị `SchemeColor` tới các vị trí `IColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/icolorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Sự ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ chủ đề**

Một bộ phông chữ chủ đề chứa một tập phông chính cho tiêu đề và một tập phông phụ cho nội dung. Các phương thức [FontScheme::get_Major()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/fontscheme/get_major/) và [FontScheme::get_Minor()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/fontscheme/get_minor/) cung cấp các tập này.

Các định danh phông chữ chủ đề tương thích với PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn‑lt` - Phông chữ nội dung Latin (Phông chữ Latin phụ)
* `+mj‑lt` - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* `+mn‑ea` - Phông chữ nội dung Đông Á (Phông chữ Đông Á phụ)
* `+mj‑ea` - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Ví dụ sau tạo một tiêu đề sử dụng phông Latin chính và một dòng nội dung sử dụng phông Latin phụ. Sau đó thay đổi các phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi bộ phông chữ chủ đề thay đổi.

Bộ sưu tập phông chữ chính và phụ cũng có thể chứa các ánh xạ phông cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong trình chiếu, xem [PowerPoint Fonts](/slides/vi/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Giữ lại Chủ đề Nguồn Khi Di chuyển các Slide**

Nếu bạn muốn di chuyển một slide sang trình chiếu khác và giữ nguyên thiết kế gốc, sao chép (clone) master nguồn vào trình chiếu đích bằng [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/addclone/), sau đó sao chép slide bằng [ISlideCollection::AddClone()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở điểm đến. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng được điều khiển bởi chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, khởi tạo một ghi đè ở mức slide từ chủ đề nguồn. Các phương thức [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) và [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) sao chép ba thành phần chính của chủ đề vào ghi đè.

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

Điều này thay đổi chủ đề được slide đó sử dụng mà không làm thay đổi chủ đề mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme::Clear()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/overridetheme/clear/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [IOverrideThemeManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/ioverridethememanager/) của layout:

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

Sử dụng chủ đề ở mức master hoặc trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và chỉ sử dụng ghi đè slide cho các ngoại lệ thực sự. Việc ghi đè quá nhiều ở mức slide làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các màu nền của chủ đề được lưu trong [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì giao diện có thể kết hợp màu nền chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background::get_StyleIndex()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` dùng `0` cho không có màu nền chủ đề; các giá trị dương là tham chiếu kiểu nền chủ đề. Điều này khác với việc chỉ mục một bộ sưu tập C++ trực tiếp bằng `idx_get(0)`, trong đó `0` có nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mọi trình chiếu đều chứa cùng số lượng kiểu màu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background::GetEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/background/geteffective/) khi bạn cần biết nền cuối cùng sau khi áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng coi `StyleIndex` như một chỉ mục bộ sưu tập dựa trên số 0. Cũng tránh việc mã hoá cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho mỗi trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Để định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/cpp/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một bộ định dạng chủ đề chứa các bộ sưu tập riêng biệt [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/formatscheme/get_linestyles/), và [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Các chủ đề Office thường chứa ba mục kiểu chính tương ứng về mặt hình ảnh với định dạng nhẹ, vừa và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định một số lượng cố định.

![Hiệu ứng chủ đề nhẹ, vừa và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong C++, chỉ số bộ sưu tập là dựa trên 0: `idx_get(0)` là kiểu đầu tiên được lưu và `idx_get(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của shape là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapestyle/). Sửa đổi một kiểu chủ đề sẽ ảnh hưởng đến các shape tham chiếu kiểu đó; các shape có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các shape tham chiếu các vị trí này, kiểu đường chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu màu nền chủ đề thứ ba sẽ thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có một bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi shape tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Kiểu hiệu ứng chủ đề sau khi thay đổi cài đặt đường, màu nền và bóng](presentation-design_11.png)

## **Đọc các Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở mức cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc shape thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ được giải quyết. Đối với một slide, gọi [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Đối với nền, sử dụng [Background::GetEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/background/geteffective/), và đối với màu nền, sử dụng [FillFormat::GetEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/geteffective/).

Ví dụ sau đọc chủ đề hiệu lực, nền và màu nền shape đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu lực để chẩn đoán, xác nhận và so sánh. Nếu bạn chỉ kiểm tra [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/get_mastertheme/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè shape làm thay đổi giao diện cuối cùng.

## **FAQ**

**Có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [IOverrideThemeManager](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/ioverridethememanager/) của slide và khởi tạo chủ đề ghi đè của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện có.

**Cách an toàn nhất để mang một chủ đề từ một trình chiếu sang trình chiếu khác là gì?**

Khi di chuyển một slide và giữ nguyên giao diện nguồn, sao chép master nguồn vào đích và sao chép slide với master đó bằng [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imasterslidecollection/addclone/) và [ISlideCollection::AddClone()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/addclone/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) cho một slide hoặc layout theme và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background::GetEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/background/geteffective/) và [FillFormat::GetEffective()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fillformat/geteffective/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.