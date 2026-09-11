---
title: Quản lý SmartArt trong các bản thuyết trình PowerPoint bằng Python
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/python-java/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức hình ảnh
- PowerPoint
- bản thuyết trình
- Python
- Aspose.Slides
description: "Học cách tạo và chỉnh sửa SmartArt trong PowerPoint với Aspose.Slides cho Python qua Java bằng các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và một bố cục. Với Aspose.Slides for Python qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức dạng hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, lặp qua [SmartArt.getAllNodes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#getAllNodes), sau đó đọc [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) được trả về bởi [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartshape/#getTextFrame).

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

## **Thay đổi Loại Bố cục của Đối tượng SmartArt**

Bố cục SmartArt điều khiển cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị `BasicBlockList` của [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/), thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#isHidden) cho biết liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục được chọn không hiển thị chúng như các thành phần biểu đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị `RadialCycle` của [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/), và kiểm tra trạng thái ẩn của nút.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) và [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ bên trái, bên phải, hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị `LeftHanging` của [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo Biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các chỗ giữ hình ảnh. Sử dụng giá trị `PictureOrganizationChart` của [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/) khi thêm đối tượng SmartArt vào slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Phương thức [SmartArt.setReversed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#setReversed) chuyển hướng biểu đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt được chọn hỗ trợ việc đảo ngược.

**Làm thế nào tôi có thể sao chép SmartArt vào cùng một slide hoặc vào một bản trình chiếu khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình SmartArt](/slides/vi/python-java/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addClone), hoặc [sao chép toàn bộ slide](/slides/vi/python-java/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi có thể render SmartArt thành ảnh raster để xem trước hoặc xuất web?**

[Render slide](/slides/vi/python-java/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu thành PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều?**

Đặt giá trị [Shape.getAlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText) hoặc [Shape.getName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getName) đặc trưng cho hình SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getShapes), và sau đó kiểm tra xem hình phù hợp có phải là [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.