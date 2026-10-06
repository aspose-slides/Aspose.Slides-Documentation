---
title: Quản lý SmartArt trong bản trình chiếu PowerPoint bằng C++
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/cpp/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- Kiểu bố cục
- Thuộc tính ẩn
- Biểu đồ tổ chức
- Biểu đồ tổ chức dạng ảnh
- PowerPoint
- Bản trình chiếu
- C++
- Aspose.Slides
description: "Học cách xây dựng và chỉnh sửa SmartArt trong PowerPoint bằng Aspose.Slides cho C++ sử dụng các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides cho C++, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức dạng ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng của nút, lặp qua [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) được trả về bởi [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Ví dụ yêu cầu một bản trình chiếu có ít nhất một slide và một đối tượng SmartArt là hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản có sẵn ra console.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Thay đổi Kiểu Bố cục của Đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu. Vị trí và kích thước được truyền tới [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) được đo bằng điểm. Sử dụng [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) để thay đổi bố cục.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kiểm tra Nút SmartArt có bị ẩn không**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các yếu tố sơ đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút đã thêm. Nó in một thông báo nếu nút bị ẩn và lưu sơ đồ.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) và [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ trái, phải, hoặc cả hai phía, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Chỉ mục bắt đầu từ 0 (`0`) chọn nút cấp đầu tiên; các nút con của nó sẽ sử dụng cách sắp xếp đã chọn. Bản trình chiếu đã chỉnh sửa sau đó được lưu.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tạo Biểu đồ Tổ chức Dạng Ảnh**

Biểu đồ tổ chức dạng ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có bao gồm các chỗ dành cho ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide. Ví dụ này lưu một sơ đồ có các chỗ dành cho ảnh; nó không điền ảnh vào các chỗ đó.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Chuyển Đổi Sơ đồ Cũ thành Nhóm Hình Dạng**

Khi hiện đại hoá một bản trình chiếu hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo ban đầu trong PowerPoint 97–2003. Aspose.Slides biểu diễn các sơ đồ cũ này dưới dạng đối tượng [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). Sử dụng [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) để chuyển đổi một sơ đồ thành một nhóm hình dạng để bạn có thể chỉnh sửa các yếu tố hình ảnh riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) để biết chi tiết.

Quá trình chuyển đổi sẽ thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) để tránh nội dung trùng lặp. Thu thập các sơ đồ cũ vào một vector trước khi chuyển đổi chúng để việc thêm và xóa hình dạng không làm gián đoạn vòng lặp.

Ví dụ sau mở một bản trình chiếu, tìm kiếm trên mọi slide, chuyển đổi các sơ đồ thành nhóm hình dạng, và lưu bản trình chiếu đã cập nhật dưới dạng PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bản trình chiếu đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay thế cho các sơ đồ cũ đã chuyển đổi, mà không còn sơ đồ gốc bên cạnh chúng. Mở tệp PPTX trong PowerPoint để chỉnh sửa các thành phần riêng lẻ trong mỗi nhóm, như văn bản, màu nền hoặc vị trí của chúng.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Phương thức [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ việc đảo ngược.

**Làm sao tôi có thể sao chép SmartArt vào cùng một slide hoặc sang bản trình chiếu khác mà vẫn giữ định dạng?**

Bạn có thể [clone hình dạng SmartArt](/slides/vi/cpp/shape-manipulations/) bằng [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) hoặc [clone toàn bộ slide](/slides/vi/cpp/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi render SmartArt thành hình ảnh raster để xem trước hoặc xuất web?**

[Render slide](/slides/vi/cpp/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu thành PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên một slide nếu có nhiều?**

Đặt giá trị đặc trưng cho [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) hoặc [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) trên hình dạng SmartArt, tìm kiếm giá trị đó trong [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), sau đó kiểm tra rằng hình dạng khớp là một [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).