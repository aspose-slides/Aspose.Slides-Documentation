---
title: Lấy các Thuộc tính Effective của Hình dạng từ Bản trình chiếu trong C++
linktitle: Các Thuộc tính Effective
type: docs
weight: 50
url: /vi/cpp/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- light rig
- hình bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng fill
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho C++ tính toán và áp dụng các thuộc tính shape effective nhằm đảm bảo việc hiển thị PowerPoint một cách chính xác."
---
## **Tổng quan**

Bài viết này giải thích sự khác biệt giữa các thuộc tính **local** và **effective**. Giá trị local là các giá trị được đặt trực tiếp ở một mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính phần (portion) trên một slide.  
1. Kiểu chữ văn bản hình mẫu (prototype shape) trên một layout hoặc master slide, khi hình dạng khung văn bản của phần có kiểu này.  
1. Cài đặt văn bản toàn cục trong một bản thuyết trình.  

Giá trị local có thể được định nghĩa hoặc bỏ qua ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng "as rendered", nó giải quyết chuỗi kế thừa và trả về các giá trị **effective**. Bạn có thể lấy chúng bằng cách gọi phương thức `GetEffective` trên đối tượng định dạng local.

Ví dụ sau minh họa cách lấy các giá trị effective. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản và ít nhất một portion.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
Dữ liệu định dạng effective đại diện cho định dạng tính toán hiện tại sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu effective, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformateffectivedata/), có thể được lưu trong bộ nhớ cache nội bộ. Gọi lại `GetEffective` sau khi thay đổi định dạng cha hoặc định dạng được kế thừa có thể làm mới dữ liệu được cache, và một đối tượng đã lấy trước đó có thể không còn phản ánh trạng thái trước nữa. Nếu bạn cần bảo tồn các giá trị effective để sử dụng lại sau này, hãy sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu nền, kiểu phông chữ hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy các Thuộc tính Effective của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một camera. Giao diện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icameraeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính camera effective. Một thể hiện của [ICameraEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icameraeffectivedata/) được mở ra qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/).

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính effective cho camera. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Lấy các Thuộc tính Effective của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một Light Rig. Giao diện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrigeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính light rig effective. Một thể hiện của [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrigeffectivedata/) được mở ra qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/).

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính effective cho Light Rig. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Lấy các Thuộc tính Effective của Đối tượng Bevel**

Aspose.Slides cho phép bạn lấy các thuộc tính effective của một bevel hình dạng. Giao diện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapebeveleffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính relief mặt cho một hình dạng. Một thể hiện của [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapebeveleffectivedata/) được mở ra qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị effective cho [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/).

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính effective cho bevel phía trên của một hình dạng. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Lấy các Thuộc tính Effective của Khung Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính effective của một khung văn bản. Giao diện [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformateffectivedata/) chứa các thuộc tính định dạng khung văn bản effective.

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính định dạng khung văn bản effective. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Lấy các Thuộc tính Effective của Kiểu Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính effective của một kiểu văn bản. Giao diện [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextstyleeffectivedata/) chứa các thuộc tính kiểu văn bản effective.

Mã mẫu dưới đây cho thấy cách lấy các thuộc tính kiểu văn bản effective. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Lấy Giá trị Chiều cao Phông chữ Effective**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ effective. Đoạn mã dưới đây minh họa cách chiều cao phông chữ effective của một portion thay đổi sau khi các giá trị chiều cao phông chữ local được đặt ở các mức cấu trúc bản thuyết trình khác nhau.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lấy Định dạng Fill Effective cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng fill effective cho các phần khác nhau của bảng. Giao diện [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifillformateffectivedata/) chứa các thuộc tính định dạng fill effective. Định dạng ô có độ ưu tiên cao hơn định dạng hàng, định dạng hàng cao hơn định dạng cột, và định dạng cột cao hơn định dạng toàn bảng.

Kết quả là, các thuộc tính của [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icellformateffectivedata/) được sử dụng để vẽ ô bảng. Mã mẫu dưới đây cho thấy cách lấy định dạng fill effective cho các phần khác nhau của bảng. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **Câu hỏi thường gặp**

### `GetEffective` có trả về một bản sao lưu không?

Không phải luôn luôn. Dữ liệu effective đại diện cho định dạng đã được tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu effective có thể được lưu trong bộ nhớ cache nội bộ. Lần gọi `GetEffective` tiếp theo có thể tính lại định dạng và làm mới dữ liệu cache, vì vậy một đối tượng đã lấy trước không nên được coi là một bản sao lưu bền vững.

### Khi nào tôi nên đọc lại các thuộc tính effective?

Hãy gọi lại `GetEffective` sau khi thay đổi định dạng local, kiểu cha, định dạng layout, định dạng master, hoặc các mặc định ở mức bản thuyết trình. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả effective hiện tại.

### Việc thay đổi hoặc xóa một layout/master slide có ảnh hưởng đến các thuộc tính effective đã được lấy không?

Có, nhưng sự thay đổi sẽ được phản ánh ở lần gọi `GetEffective` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xóa, dữ liệu effective đã lấy trước có thể lỗi thời. Khi `GetEffective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc các giá trị khác có thể thay đổi.

### Tôi có thể sửa đổi giá trị thông qua các đối tượng dữ liệu effective không?

Không. Các đối tượng dữ liệu effective chỉ cung cấp các giá trị đã được tính toán. Hãy thực hiện thay đổi trong các đối tượng định dạng local, sau đó lại lấy các giá trị effective.

### Điều gì xảy ra nếu một thuộc tính không được đặt ở mức hình dạng, cũng không ở layout/master, cũng không trong cài đặt toàn cục?

Giá trị effective được xác định bằng cơ chế mặc định, bao gồm các mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết đó trở thành một phần của dữ liệu effective hiện tại.

### Từ một giá trị phông chữ effective, tôi có thể biết mức nào đã cung cấp kích thước hoặc kiểu chữ không?

Không trực tiếp. Dữ liệu effective trả về giá trị cuối cùng. Để tìm nguồn, hãy kiểm tra các giá trị local ở mức portion, paragraph, khung văn bản và các kiểu văn bản ở layout, master và mức bản thuyết trình để xem định nghĩa rõ ràng đầu tiên xuất hiện ở đâu.

### Tại sao giá trị effective đôi khi trông giống hệt với giá trị local?

Bởi vì giá trị local cuối cùng đã là giá trị cuối cùng (không cần kế thừa ở mức cao hơn). Trong những trường hợp này, giá trị effective trùng với giá trị local.

### Khi nào tôi nên sử dụng các thuộc tính effective, và khi nào chỉ nên làm việc với các thuộc tính local?

Hãy sử dụng dữ liệu effective khi bạn cần kết quả "as rendered" sau khi tất cả các cấp kế thừa được áp dụng, chẳng hạn để căn chỉnh màu sắc, lề hoặc kích thước. Nếu bạn cần bảo tồn các giá trị này bất kể các thay đổi định dạng sau này, hãy sao chép các thuộc tính cần thiết vào đối tượng của riêng bạn. Nếu bạn cần thay đổi định dạng ở một mức cụ thể, hãy sửa đổi các thuộc tính local và sau đó, nếu cần, đọc lại dữ liệu effective để xác nhận kết quả.