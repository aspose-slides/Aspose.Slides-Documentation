---
title: Lấy Thuộc tính Hiệu lực của Hình dạng từ Bản trình bày trong C++
linktitle: Thuộc tính Hiệu lực
type: docs
weight: 50
url: /vi/cpp/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- hệ thống ánh sáng
- hình dạng bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng đổ màu
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho C++ tính toán và áp dụng các thuộc tính hình dạng hiệu lực để render PowerPoint một cách chính xác."
---
## **Tổng quan**

Chủ đề này giải thích sự khác biệt giữa các thuộc tính **cục bộ** và **hiệu lực**. Giá trị cục bộ là các giá trị được đặt trực tiếp ở một mức định dạng cụ thể, chẳng hạn như:

1. Thuộc tính phần trên một slide.
1. Kiểu văn bản hình dạng mẫu trên bố cục hoặc slide chủ, khi hình dạng khung văn bản của phần có một kiểu.
1. Cài đặt văn bản toàn cục trong một bản trình bày.

Giá trị cục bộ có thể được xác định hoặc bỏ qua ở bất kỳ mức nào. Khi Aspose.Slides cần định dạng cuối cùng "như đã hiển thị", nó giải quyết chuỗi kế thừa và trả về các giá trị **hiệu lực**. Bạn có thể lấy chúng bằng cách gọi phương thức `GetEffective` trên đối tượng định dạng cục bộ.

Ví dụ sau đây cho thấy cách lấy các giá trị hiệu lực. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản và ít nhất một phần.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Dữ liệu định dạng hiệu lực đại diện cho định dạng hiện tại đã được tính toán sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu hiệu lực, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformateffectivedata/), có thể được lưu trong bộ nhớ đệm nội bộ. Gọi lại `GetEffective` sau khi thay đổi định dạng cha hoặc kế thừa có thể làm mới dữ liệu được lưu, và đối tượng đã lấy trước đó có thể không còn đại diện cho trạng thái trước. Nếu bạn cần lưu trữ các giá trị hiệu lực để sử dụng lại sau, sao chép các thuộc tính cần thiết, như chiều cao phông chữ, màu nền, kiểu phông chữ hoặc căn chỉnh, vào đối tượng dữ liệu của riêng bạn.
{{% /alert %}}

## **Lấy Thuộc tính Hiệu lực của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của một camera. Giao diện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icameraeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính camera hiệu lực. Một thể hiện [ICameraEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icameraeffectivedata/) được hiển thị thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị hiệu lực cho [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/).

Mẫu mã sau đây cho thấy cách lấy các thuộc tính hiệu lực cho camera. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```cpp
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

## **Lấy Thuộc tính Hiệu lực của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của một light rig. Giao diện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrigeffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính light rig hiệu lực. Một thể hiện [ILightRigEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrigeffectivedata/) được hiển thị thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị hiệu lực cho [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/).

Mẫu mã sau đây cho thấy cách lấy các thuộc tính hiệu lực cho light rig. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```cpp
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

## **Lấy Thuộc tính Hiệu lực của Bevel Shape**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của bevel hình dạng. Giao diện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapebeveleffectivedata/) đại diện cho một đối tượng bất biến chứa các thuộc tính relief mặt cho một hình dạng. Một thể hiện [IShapeBevelEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapebeveleffectivedata/) được hiển thị thông qua [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/), cung cấp các giá trị hiệu lực cho [IThreeDFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/).

Mẫu mã sau đây cho thấy cách lấy các thuộc tính hiệu lực cho bevel trên của một hình dạng. Giả sử hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```cpp
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

## **Lấy Thuộc tính Hiệu lực của Text Frame**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu lực của một khung văn bản. Giao diện [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformateffectivedata/) chứa các thuộc tính định dạng khung văn bản hiệu lực.

Mẫu mã sau đây cho thấy cách lấy các thuộc tính định dạng khung văn bản hiệu lực. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản.

```cpp
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

## **Lấy Thuộc tính Hiệu lực của Text Style**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu lực của một kiểu văn bản. Giao diện [ITextStyleEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextstyleeffectivedata/) chứa các thuộc tính kiểu văn bản hiệu lực.

Mẫu mã sau đây cho thấy cách lấy các thuộc tính kiểu văn bản hiệu lực. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản.

```cpp
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

## **Lấy Giá trị Chiều cao Phông chữ Hiệu lực**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ hiệu lực. Đoạn mã sau minh họa cách chiều cao phông chữ hiệu lực của một phần thay đổi sau khi các giá trị chiều cao phông chữ cục bộ được đặt ở các mức cấu trúc bản trình bày khác nhau.

```cpp
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

## **Lấy Định dạng Đổ màu Hiệu lực cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng đổ màu hiệu lực cho các phần khác nhau của bảng. Giao diện [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifillformateffectivedata/) chứa các thuộc tính định dạng đổ màu hiệu lực. Định dạng ô có ưu tiên cao hơn định dạng hàng, định dạng hàng có ưu tiên cao hơn định dạng cột, và định dạng cột có ưu tiên cao hơn định dạng toàn bảng.

Do đó, các thuộc tính của [ICellFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icellformateffectivedata/) được sử dụng để vẽ ô bảng. Mẫu mã sau đây cho thấy cách lấy định dạng đổ màu hiệu lực cho các phần khác nhau của bảng. Giả sử hình dạng đầu tiên trên slide đầu tiên là một [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/).

```cpp
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

**`GetEffective` có trả về một ảnh chụp nhanh không?**

Không phải luôn luôn. Dữ liệu hiệu lực đại diện cho định dạng đã được tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu hiệu lực có thể được lưu trong bộ nhớ đệm nội bộ. Lần gọi `GetEffective` tiếp theo có thể tính lại định dạng và làm mới dữ liệu được lưu, vì vậy đối tượng đã lấy trước đó không nên được coi là một ảnh chụp dài hạn.

**Khi nào tôi nên đọc lại các thuộc tính hiệu lực?**

Gọi lại `GetEffective` sau khi thay đổi định dạng cục bộ, kiểu cha, định dạng bố cục, định dạng master hoặc các mặc định ở mức bản trình bày. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả hiệu lực hiện tại.

**Việc thay đổi hoặc xoá một slide bố cục/master có ảnh hưởng đến các thuộc tính hiệu lực đã được lấy trước không?**

Có, nhưng thay đổi sẽ được phản ánh trong lần gọi `GetEffective` tiếp theo. Nếu nguồn định dạng cha được thay đổi hoặc xoá, dữ liệu hiệu lực đã lấy trước có thể lỗi thời. Khi `GetEffective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc các giá trị khác có thể thay đổi.

**Tôi có thể sửa đổi giá trị thông qua các đối tượng dữ liệu hiệu lực không?**

Không. Các đối tượng dữ liệu hiệu lực chỉ cung cấp các giá trị đã được tính toán. Thực hiện các thay đổi trong các đối tượng định dạng cục bộ, sau đó lại lấy các giá trị hiệu lực.

**Điều gì xảy ra nếu một thuộc tính không được đặt ở mức hình dạng, cũng không ở bố cục/master, cũng không trong cài đặt toàn cục?**

Giá trị hiệu lực sẽ được xác định bởi cơ chế mặc định, bao gồm các giá trị mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết đó sẽ trở thành một phần của dữ liệu hiệu lực hiện tại.

**Từ một giá trị phông chữ hiệu lực, tôi có thể biết mức nào đã cung cấp kích thước hoặc kiểu chữ không?**

Không trực tiếp. Dữ liệu hiệu lực chỉ trả về giá trị cuối cùng. Để tìm nguồn, kiểm tra các giá trị cục bộ ở mức phần, đoạn, khung văn bản và các kiểu văn bản ở bố cục, master và mức bản trình bày để xem định nghĩa rõ ràng đầu tiên xuất hiện ở đâu.

**Tại sao các giá trị hiệu lực đôi khi trông giống hệt với các giá trị cục bộ?**

Bởi vì giá trị cục bộ cuối cùng đã là giá trị cuối cùng (không cần kế thừa từ mức cao hơn). Trong trường hợp này, giá trị hiệu lực trùng với giá trị cục bộ.

**Khi nào tôi nên sử dụng các thuộc tính hiệu lực, và khi nào chỉ làm việc với các thuộc tính cục bộ?**

Sử dụng dữ liệu hiệu lực khi bạn cần kết quả "như đã hiển thị" sau khi áp dụng toàn bộ kế thừa, chẳng hạn để đồng bộ màu sắc, lề hoặc kích thước. Nếu bạn cần giữ lại các giá trị này bất kể các thay đổi định dạng sau này, sao chép các thuộc tính cần thiết vào đối tượng của riêng bạn. Nếu bạn cần thay đổi định dạng ở một mức cụ thể, chỉnh sửa các thuộc tính cục bộ và sau đó, nếu cần, đọc lại dữ liệu hiệu lực để xác nhận kết quả.