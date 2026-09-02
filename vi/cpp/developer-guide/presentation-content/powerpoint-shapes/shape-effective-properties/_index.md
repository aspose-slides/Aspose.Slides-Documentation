---
title: Lấy Thuộc tính Hiệu lực của Hình từ Bản trình chiếu trong C++
linktitle: Thuộc tính Hiệu lực
type: docs
weight: 50
url: /vi/cpp/shape-effective-properties/
keywords:
- thuộc tính hình
- thuộc tính máy ảnh
- bộ ánh sáng
- hình bevel
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng tô đầy
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách sử dụng Aspose.Slides cho C++ để phân biệt định dạng hình cục bộ, kế thừa và hiệu lực trong các bản trình chiếu PowerPoint."
---
## **Hiểu về Thuộc tính Cục bộ, Kế thừa và Hiệu lực**

Định dạng PowerPoint có thể đến từ nhiều nguồn. Giá trị được lưu trực tiếp trên một đối tượng là **giá trị cục bộ**. Nếu giá trị đó không được đặt, PowerPoint sẽ tìm các nguồn định dạng cha, chẳng hạn như mặc định đoạn văn, kiểu văn bản, bố cục hoặc slide master, chủ đề, hoặc mặc định cấp trình chiếu. Những giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ phân cấp được giải quyết là **giá trị hiệu lực** — giá trị được dùng để hiển thị đối tượng.

Ví dụ, một phần văn bản có thể không xác định chiều cao phông chữ của riêng mình. Giá trị cục bộ [chiều cao phông chữ](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ibaseportionformat/) của nó sẽ là `std::numeric_limits<float>::quiet_NaN()`, có nghĩa là “không được đặt ở đây”. Phần này có thể kế thừa chiều cao từ đoạn văn, kiểu văn bản mặc định của trình chiếu, hoặc nguồn áp dụng khác. Gọi [GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/) trên định dạng phần sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [IPortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/), khi bạn cần kiểm soát nơi một giá trị được định nghĩa.
- Đọc một đối tượng dữ liệu hiệu lực, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformateffectivedata/), khi bạn cần kết quả cuối cùng đã được hiển thị. Dữ liệu hiệu lực chỉ đọc.

## **So sánh Giá trị Cục bộ, Kế thừa và Hiệu lực**

Ví dụ đầy đủ sau tạo một hình và áp dụng chiều cao phông chữ ở các mức trình chiếu, đoạn văn và phần. Mỗi bước in ra các giá trị được định nghĩa ở các mức đó và giá trị hiệu lực kết quả cho cùng một phần văn bản. Nó cũng minh họa tại sao dữ liệu hiệu lực phải được đọc lại sau khi thay đổi định dạng.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Định nghĩa các giá trị kế thừa ở hai mức độ khác nhau.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Đọc dữ liệu hiệu lực sau các thay đổi trước đó.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Giá trị cục bộ trên phần ghi đè cả hai giá trị kế thừa.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Thay đổi một giá trị kế thừa không ghi đè giá trị cục bộ hiện có.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Xóa giá trị cục bộ. Phần hiện nay lại kế thừa từ đoạn văn.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Xóa giá trị đoạn văn. Mặc định trình chiếu bây giờ cung cấp kết quả.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ưu tiên trong ví dụ này là định dạng cục bộ của phần, sau đó là định dạng đoạn văn, cuối cùng là mặc định trình chiếu. Các đối tượng khác có thể có chuỗi kế thừa khác, nhưng nguyên tắc vẫn giống: giá trị cụ thể hơn sẽ thắng, và [GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/) trả về kết quả cuối cùng.

## **Lấy Thuộc tính Văn bản Hiệu lực**

Định dạng văn bản được chia thành nhiều đối tượng:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/) giải quyết các thuộc tính khung văn bản như lề, neo, tự động vừa, và hướng văn bản dọc.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextstyle/) giải quyết định dạng đoạn văn cho mỗi cấp độ kiểu văn bản.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/) giải quyết các thuộc tính đoạn văn như căn chỉnh, thụt lề và dấu đầu dòng.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iportionformat/) giải quyết các thuộc tính ký tự như chiều cao phông chữ, họ phông, màu, in đậm và in nghiêng.

Đối với ví dụ tiếp theo, tệp `text-formatting.pptx` phải chứa ít nhất một slide và một [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) có khung văn bản không rỗng. IAutoShape có thể xuất hiện ở bất kỳ vị trí nào trong bộ sưu tập hình; mã sẽ tìm một đối tượng phù hợp và xác thực nó trước khi sử dụng.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Lấy Thuộc tính 3D Hiệu lực**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformat/) trả về một đối tượng [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ithreedformateffectivedata/) nhóm tất cả các cài đặt 3D đã được giải quyết. Dữ liệu [camera](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapebeveleffectivedata/) và [bottom bevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapebeveleffectivedata/) hiển thị các cài đặt hiệu lực tương ứng. Đọc các cài đặt liên quan này cùng nhau giúp dễ hiểu hơn về ngoại hình 3D cuối cùng của một hình.

Đối với ví dụ này, tệp `shape-3d.pptx` phải chứa ít nhất một hình trên slide đầu tiên. Áp dụng cấu hình camera, ánh sáng hoặc bevel 3D cho hình đó nếu bạn muốn đầu ra chứa các giá trị khác với mặc định.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Lấy Định dạng Bảng Hiệu lực**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng áp dụng cho toàn bộ bảng, cột, hàng hoặc ô riêng lẻ. Khi có xung đột giữa các fill được xác định rõ ràng, thứ tự ưu tiên là ô, hàng, cột, rồi toàn bộ bảng. Định dạng hiệu lực của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, tệp `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm một [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) thay vì giả định rằng hình đầu tiên là một bảng.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Nếu bạn cần màu thay vì chỉ loại fill, trước tiên kiểm tra [FillType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifillformateffectivedata/) hiệu lực, sau đó đọc thuộc tính tương ứng với loại đó — ví dụ, [SolidFillColor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ifillformateffectivedata/) cho fill đặc.

## **Đọc lại Dữ liệu Hiệu lực Sau Khi Thay đổi**

Dữ liệu hiệu lực mô tả phân cấp định dạng tại thời điểm nó được giải quyết. Gọi `GetEffective` lại sau khi thay đổi bất kỳ yếu tố nào có thể tham gia vào phân cấp đó, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn văn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide master;
- dữ liệu chủ đề hoặc mặc định cấp trình chiếu;
- bố cục hoặc master được gán cho một slide.

Không giữ một đối tượng dữ liệu hiệu lực như một ảnh chụp nhanh vĩnh viễn. Aspose.Slides có thể lưu một số dữ liệu hiệu lực trong bộ nhớ đệm nội bộ, và một lời gọi `GetEffective` sau này có thể làm mới dữ liệu đó. Nếu bạn cần so sánh các giá trị trước và sau khi thay đổi, sao chép các giá trị vô hướng bạn cần — chẳng hạn như chiều cao phông, màu, căn chỉnh hoặc độ rộng bevel — vào các biến của riêng bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ thích hợp rồi gọi `GetEffective` để xác minh kết quả. Các đối tượng dữ liệu hiệu lực tự chúng chỉ đọc.

## **FAQ**

**Làm sao tôi biết cấp độ nào đã cung cấp giá trị hiệu lực?**

Dữ liệu hiệu lực chỉ chứa giá trị cuối cùng, không kèm nguồn gốc. Kiểm tra các đối tượng cục bộ áp dụng từ cấp độ cụ thể nhất ra bên ngoài. Đối với văn bản, điều này có thể bao gồm phần, đoạn, khung văn bản, bố cục, master, chủ đề và mặc định trình chiếu. Các giá trị không xác định như `std::numeric_limits<float>::quiet_NaN()` hoặc `nullptr` cho biết việc tìm kiếm sẽ tiếp tục ở cấp độ khác.

**Điều gì xảy ra khi không có cấp độ nào định nghĩa thuộc tính?**

Aspose.Slides sẽ giải quyết giá trị mặc định thích hợp của PowerPoint hoặc thư viện. Giá trị đã giải quyết đó sẽ xuất hiện trong dữ liệu hiệu lực mặc dù không có đối tượng cục bộ nào xác định rõ ràng.

**Tại sao một giá trị hiệu lực đôi khi bằng giá trị cục bộ?**

Giá trị cục bộ đã thắng trong phép tính kế thừa. Điều này xảy ra khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè nó.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu lực?**

Sử dụng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa một mức định dạng cụ thể. Sử dụng dữ liệu hiệu lực khi bạn cần kết quả cuối cùng sau khi kế thừa, quy tắc chủ đề và các kiểu áp dụng đã được giải quyết. Ví dụ so sánh đầy đủ ([compare-local-inherited-and-effective-values](#compare-local-inherited-and-effective-values)) minh họa cả hai trong cùng một quy trình.