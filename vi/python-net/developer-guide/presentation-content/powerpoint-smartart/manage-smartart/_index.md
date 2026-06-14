---
title: Quản lý SmartArt trong Bài thuyết trình PowerPoint bằng Python
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/python-net/manage-smartart/
keywords:
- SmartArt
- văn bản từ SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức có hình ảnh
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint với Aspose.Slides cho Python qua .NET bằng các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides for Python qua .NET, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy văn bản từ đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, duyệt qua [SmartArt.all_nodes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/all_nodes/), sau đó đọc [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) được trả về bởi [SmartArtShape.text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Thay đổi kiểu bố cục của đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, thay đổi nó thành giá trị `BASIC_PROCESS` và lưu bản trình bày.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartnode/is_hidden/) cho biết liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các yếu tố sơ đồ nhìn thấy được.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` và kiểm tra trạng thái ẩn của nút.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy hoặc đặt bố cục biểu đồ tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ phía trái, phải hoặc cả hai phía, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo biểu đồ tổ chức có hình ảnh**

Biểu đồ tổ chức có hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các vị trí giữ ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` khi thêm đối tượng SmartArt vào một slide.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Thuộc tính [SmartArt.is_reversed](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/is_reversed/) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm sao tôi có thể sao chép SmartArt sang cùng slide hoặc sang bản trình bày khác mà vẫn giữ nguyên định dạng?**

Bạn có thể [sao chép hình SmartArt](/slides/vi/python-net/shape-manipulations/) bằng [ShapeCollection.add_clone](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_clone/) hoặc [sao chép toàn bộ slide](/slides/vi/python-net/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm thế nào để render SmartArt thành hình ảnh raster để xem trước hoặc xuất ra web?**

[Render slide](/slides/vi/python-net/convert-powerpoint-to-png/) hoặc toàn bộ bản trình bày sang PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều?**

Đặt giá trị [Shape.alternative_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/alternative_text/) hoặc [Shape.name](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/name/) đặc biệt cho hình SmartArt, tìm kiếm giá trị đó trong [Slide.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/shapes/), và sau đó kiểm tra rằng hình tương ứng là một [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/).