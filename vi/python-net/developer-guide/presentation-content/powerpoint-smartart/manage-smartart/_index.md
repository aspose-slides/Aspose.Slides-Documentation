---
title: Quản lý SmartArt trong Bản trình bày PowerPoint bằng Python
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/python-net/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức hình ảnh
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint bằng Aspose.Slides cho Python qua .NET với các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và một bố cục. Với Aspose.Slides cho Python qua .NET, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng nút, lặp qua [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), sau đó đọc [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) được trả về bởi [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Ví dụ yêu cầu một bản trình bày có ít nhất một slide và một đối tượng SmartArt là hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản khả dụng ra console.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Thay đổi Loại Bố cục của Đối tượng SmartArt**

Bố cục SmartArt điều khiển cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, thay đổi nó thành giá trị `BASIC_PROCESS`, và lưu bản trình bày. Vị trí và kích thước truyền cho [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) được đo bằng điểm. Đặt [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) để thay đổi bố cục.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm tra xem một Nút SmartArt có bị Ẩn hay không**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các yếu tố sơ đồ nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` và kiểm tra trạng thái ẩn của nút vừa thêm. Nó in thông báo nếu nút bị ẩn và lưu sơ đồ.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ trái, phải hoặc cả hai phía, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. Chỉ số bắt đầu từ 0 chọn nút cấp cao nhất đầu tiên; các nút con của nó sẽ sử dụng cách sắp xếp đã chọn. Bản trình bày đã chỉnh sửa sau đó được lưu.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo Biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các trình giữ chỗ ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` khi thêm đối tượng SmartArt vào slide. Ví dụ này lưu một sơ đồ có các trình giữ chỗ hình ảnh; nó không điền các trình giữ chỗ bằng ảnh.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Chuyển đổi Các Sơ đồ Cũ thành Nhóm Hình dạng**

Khi hiện đại hoá một bản trình bày hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo trong PowerPoint 97–2003. Aspose.Slides đại diện cho các sơ đồ cũ này dưới dạng các đối tượng [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Sử dụng [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) để chuyển đổi một sơ đồ thành một nhóm hình dạng nhằm cho phép chỉnh sửa các yếu tố hình ảnh riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) để biết chi tiết.

Việc chuyển đổi thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) để tránh nội dung trùng lặp. Thu thập các sơ đồ cũ vào một danh sách trước khi chuyển đổi để việc thêm và xóa hình dạng không làm gián đoạn vòng lặp.

Ví dụ sau mở một bản trình bày, tìm kiếm mọi slide, chuyển đổi các sơ đồ thành nhóm hình dạng và lưu bản trình bày đã cập nhật dưới dạng PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

Bản trình bày đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay cho các sơ đồ cũ đã chuyển đổi, không còn sơ đồ gốc bên cạnh chúng. Mở file PPTX trong PowerPoint để chỉnh sửa các yếu tố riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền hoặc vị trí của chúng.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Thuộc tính [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm thế nào để sao chép SmartArt vào cùng một slide hoặc sang bản trình bày khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/python-net/shape-manipulations/) với [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) hoặc [sao chép toàn bộ slide](/slides/vi/python-net/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi có thể render SmartArt thành ảnh raster để xem trước hoặc xuất ra web?**

[Render slide](/slides/vi/python-net/convert-powerpoint-to-png/) hoặc toàn bộ bản trình bày thành PNG hoặc JPEG. SmartArt sẽ được render như một phần của slide.

**Làm thế nào tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều đối tượng?**

Đặt một giá trị [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) hoặc [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) đặc trưng cho hình dạng SmartArt, tìm kiếm giá trị đó trong [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), và sau đó kiểm tra xem hình dạng khớp có phải là một [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) hay không.