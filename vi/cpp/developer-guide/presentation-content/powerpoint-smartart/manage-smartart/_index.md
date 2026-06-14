---
title: Quản lý SmartArt trong các bản trình chiếu PowerPoint bằng C++
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/cpp/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- Loại bố cục
- Thuộc tính ẩn
- Biểu đồ tổ chức
- Biểu đồ tổ chức hình ảnh
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint với Aspose.Slides cho C++ bằng các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides for C++, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, lặp qua [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartart/get_allnodes/), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) được trả về bởi [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Thay đổi Loại Bố cục của Đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị `BasicBlockList` của [SmartArtLayoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartlayouttype/), thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kiểm tra xem Nút SmartArt có bị Ẩn hay không**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục được chọn không hiển thị chúng như các thành phần sơ đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị `RadialCycle` của [SmartArtLayoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartlayouttype/), và kiểm tra trạng thái ẩn của nút.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) và [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ bên trái, bên phải, hoặc cả hai phía, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/organizationchartlayouttype/) được chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị `LeftHanging` của [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/organizationchartlayouttype/).

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tạo Biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có bao gồm các vị trí giữ ảnh. Sử dụng giá trị `PictureOrganizationChart` của [SmartArtLayoutType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartlayouttype/) khi thêm đối tượng SmartArt vào một slide.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Phương thức [SmartArt::set_IsReversed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartart/set_isreversed/) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt được chọn hỗ trợ việc đảo ngược.

**Làm sao tôi có thể sao chép SmartArt vào cùng slide hoặc sang bản trình chiếu khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/cpp/shape-manipulations/) bằng [ShapeCollection::AddClone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapecollection/addclone/) hoặc [sao chép cả slide](/slides/vi/cpp/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi render SmartArt thành hình raster để xem trước hoặc xuất ra web?**

[Render slide](/slides/vi/cpp/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu sang PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều?**

Đặt giá trị đặc trưng cho [Shape::set_AlternativeText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/set_alternativetext/) hoặc [Shape::set_Name](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/set_name/) trên hình dạng SmartArt, tìm kiếm giá trị đó trong [BaseSlide::get_Shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseslide/get_shapes/), và sau đó kiểm tra xem hình dạng khớp có phải là một [ISmartArt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/ismartart/) không.