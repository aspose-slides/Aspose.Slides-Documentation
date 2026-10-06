---
title: Quản lý SmartArt trong Bản trình chiếu PowerPoint bằng Python
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/python-java/manage-smartart/
keywords:
- SmartArt
- văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức hình ảnh
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho Python thông qua Java bằng các ví dụ mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo nên từ các nút, hình dạng nút và một bố cục. Với Aspose.Slides cho Python thông qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng của nút, lặp qua [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), sau đó đọc [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) được trả về bởi [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

Ví dụ yêu cầu một bản trình chiếu có ít nhất một slide và một đối tượng SmartArt làm hình dạng đầu tiên trên slide đó. Nó sẽ in mỗi khung văn bản có sẵn ra console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Thay đổi Kiểu bố cục của Đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ dưới đây tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess` và lưu bản trình chiếu. Vị trí và kích thước được truyền cho [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) được đo bằng điểm. Sử dụng [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) để thay đổi bố cục.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm tra liệu một nút SmartArt có bị ẩn hay không**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các yếu tố sơ đồ có thể nhìn thấy.

Ví dụ dưới đây thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút vừa thêm. Nó sẽ in thông báo nếu nút bị ẩn và lưu sơ đồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) và [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo ở phía trái, phải hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) đã chọn.

Ví dụ dưới đây tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Chỉ mục bắt đầu từ 0 chọn nút cấp cao nhất đầu tiên; các nút con của nó sẽ sử dụng cách sắp xếp đã chọn. Bản trình chiếu đã chỉnh sửa sau đó được lưu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các trình giữ chỗ hình ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào slide. Ví dụ này lưu một sơ đồ có các trình giữ chỗ hình ảnh; nó không điền hình ảnh vào các trình giữ chỗ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Chuyển đổi Sơ đồ Cũ thành Nhóm Hình dạng**

Khi hiện đại hoá một bản trình chiếu hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo trong PowerPoint 97–2003. Aspose.Slides biểu diễn các sơ đồ kế thừa này dưới dạng các đối tượng [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Sử dụng [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) để chuyển đổi một sơ đồ thành một nhóm hình dạng để bạn có thể chỉnh sửa các yếu tố hình ảnh riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) để biết chi tiết.

Quá trình chuyển đổi sẽ thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) để tránh nội dung trùng lặp. Thu thập các sơ đồ kế thừa vào một danh sách trước khi chuyển đổi để việc thêm và xóa hình dạng không làm gián đoạn quá trình lặp.

Ví dụ dưới đây mở một bản trình chiếu, tìm kiếm mọi slide, chuyển đổi các sơ đồ thành nhóm hình dạng và lưu bản trình chiếu đã cập nhật dưới dạng PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bản trình chiếu đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay cho các sơ đồ kế thừa đã chuyển đổi, không còn sơ đồ gốc nào còn lại bên cạnh chúng. Mở tệp PPTX trong PowerPoint để chỉnh sửa các yếu tố riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền hoặc vị trí của chúng.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Phương thức [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm thế nào để sao chép SmartArt vào cùng một slide hoặc sang bản trình chiếu khác mà vẫn giữ nguyên định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/python-java/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) hoặc [sao chép toàn bộ slide](/slides/vi/python-java/clone-slides/) chứa SmartArt. Cả hai cách đều bảo toàn kích thước, vị trí và định dạng.

**Làm sao để render SmartArt thành hình ảnh raster để xem trước hoặc xuất web?**

[Render slide](/slides/vi/python-java/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu sang PNG hoặc JPEG. SmartArt sẽ được render như một phần của slide.

**Làm thế nào tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều đối tượng?**

Sử dụng [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) hoặc [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) để gán văn bản thay thế hoặc tên đặc trưng cho hình dạng SmartArt, tìm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), sau đó kiểm tra xem hình dạng khớp có phải là một [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) hay không.