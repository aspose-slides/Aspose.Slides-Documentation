---
title: Quản lý các nút hình SmartArt trong bản trình chiếu sử dụng Python
linktitle: Nút Hình SmartArt
type: docs
weight: 30
url: /vi/python-java/manage-smartart-shape-node/
keywords:
- nút SmartArt
- nút con
- thêm nút
- vị trí nút
- truy cập nút
- xóa nút
- vị trí tùy chỉnh
- nút trợ lý
- định dạng tô đầy
- kết xuất nút
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các nút hình SmartArt trong PPT và PPTX bằng Aspose.Slides cho Python thông qua Java. Nhận các ví dụ mã rõ ràng và mẹo để tối ưu hóa bản trình chiếu của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản trình chiếu PowerPoint được tổ chức thông qua các nút chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này một cách lập trình: thêm nút mới và nút con, chèn nút con vào vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình SmartArt. Nó chỉ ra cách xóa nút, làm việc với các nút con theo chỉ mục hoặc vị trí, chuyển một nút trợ lý thành nút thường, điều chỉnh vị trí, kích thước và góc quay của các hình nút SmartArt, đặt định dạng tô đầy cho nút, và tạo hình thu nhỏ cho một nút con của SmartArt.

## **Thêm một nút SmartArt**
Aspose.Slides cho Python thông qua Java cung cấp API để quản lý các hình SmartArt. Ví dụ sau thêm một nút và một nút con vào hình SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Duyệt qua mọi hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. [Thêm một nút mới](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnodecollection/#addNode) vào [bộ sưu tập nút](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#getAllNodes) của hình SmartArt và đặt văn bản của nó thông qua [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/).
6. [Thêm](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnodecollection/#addNode) một [nút con](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#getChildNodes) vào nút mới và đặt văn bản của nó thông qua [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/).
7. Lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm một nút SmartArt ở vị trí cụ thể**
Ví dụ sau thêm một nút con vào vị trí cụ thể trong một nút SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Thêm một hình [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) với bố cục [StackedList](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/#StackedList) vào slide.
4. Truy cập nút đầu tiên trong hình SmartArt vừa thêm.
5. Thêm một nút con vào nút đã chọn ở vị trí 2 bằng cách sử dụng [addNodeByPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) và đặt văn bản cho nó.
6. Lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập một nút SmartArt**
Ví dụ sau truy cập các nút trong một hình SmartArt. Bố cục trả về bởi [getLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#getLayout) là chỉ đọc và được thiết lập khi hình SmartArt được thêm vào.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Duyệt qua mọi hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Duyệt qua tất cả [các nút](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#getAllNodes) trong hình SmartArt.
6. Đọc và hiển thị vị trí, cấp độ và văn bản của mỗi nút SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Truy cập một nút con SmartArt**
Ví dụ sau truy cập các nút con của mỗi nút trong một hình SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Duyệt qua mọi hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Duyệt qua tất cả [các nút](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#getAllNodes) trong hình SmartArt.
6. Đối với mỗi nút, duyệt qua [các nút con](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#getChildNodes) của nó.
7. Đọc và hiển thị vị trí, cấp độ và văn bản của [nút con](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Truy cập một nút con SmartArt ở vị trí cụ thể**
Ví dụ sau truy cập một nút con tại một chỉ mục cụ thể trong bộ sưu tập của nút cha.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Thêm một hình SmartArt với bố cục [StackedList](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/#StackedList).
4. Truy cập hình SmartArt đã thêm.
5. Truy cập nút tại chỉ mục 0 trong hình SmartArt.
6. Truy cập nút con tại chỉ mục 1 bằng cách sử dụng [get_Item](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnodecollection/#get_Item).
7. Đọc và hiển thị vị trí, cấp độ và văn bản của [nút con](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Xóa một nút SmartArt**
Ví dụ sau xóa một nút khỏi hình SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Duyệt qua mọi hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Kiểm tra rằng hình [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) chứa ít nhất một nút.
6. Chọn nút SmartArt cần xóa.
7. Xóa nút đã chọn bằng cách sử dụng [removeNode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnodecollection/#removeNode).
8. Lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa một nút SmartArt từ vị trí cụ thể**
Ví dụ sau xóa một nút con tại một chỉ mục cụ thể trong bộ sưu tập của một nút SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Duyệt qua mọi hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Truy cập nút SmartArt tại chỉ mục 0 nếu tồn tại.
6. Kiểm tra rằng nút SmartArt đã chọn có ít nhất hai nút con.
7. Xóa nút con tại chỉ mục 1 bằng cách sử dụng [removeNode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnodecollection/#removeNode).
8. Lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt vị trí tùy chỉnh cho nút con trong đối tượng SmartArt**
Aspose.Slides cho Python thông qua Java hỗ trợ đặt vị trí của một [SmartArtShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartshape/) bằng cách sử dụng [setX](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setX) và [setY](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setY). Ví dụ sau đặt vị trí, kích thước và góc quay tùy chỉnh cho các hình nút SmartArt. Thêm các nút mới sẽ tính lại vị trí và kích thước của mọi nút. Định vị tùy chỉnh cho phép bạn sắp xếp các nút theo yêu cầu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm tra nút trợ lý**
{{% alert color="info" title="Note" %}} 

Phần này khám phá các hình SmartArt được thêm vào các slide trình chiếu một cách lập trình bằng cách sử dụng Aspose.Slides cho Python thông qua Java.

{{% /alert %}} 

Hình SmartArt nguồn được sử dụng trong ví dụ này.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Hình: Hình SmartArt nguồn trên một slide**|

Ví dụ sau xác định các nút trợ lý trong bộ sưu tập nút SmartArt và chuyển chúng thành nút thường.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Duyệt qua mọi hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Duyệt qua tất cả các nút trong hình SmartArt và kiểm tra xem chúng có phải là [Assistant Nodes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#isAssistant) hay không.
6. Chuyển mỗi nút trợ lý thành nút thường.
7. Lưu bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Hình: Các nút trợ lý đã được chuyển đổi trong một hình SmartArt trên một slide**|

## **Đặt định dạng tô đầy cho nút**
Aspose.Slides cho Python thông qua Java cho phép thêm các hình SmartArt tùy chỉnh và đặt định dạng tô đầy cho chúng. Bài viết này giải thích cách tạo và truy cập các hình SmartArt và đặt định dạng tô đầy cho chúng bằng cách sử dụng Aspose.Slides cho Python thông qua Java.

Vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy một slide theo chỉ mục của nó.
3. Thêm một [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) với bố cục [ClosedChevronProcess](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) .
4. Đặt [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getFillFormat) cho các nút của hình SmartArt.
5. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo hình thu nhỏ của nút con SmartArt**
Để tạo hình thu nhỏ của một nút con SmartArt, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. [Thêm một hình SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addSmartArt) .
3. Lấy một nút theo chỉ mục của nó.
4. Lấy hình ảnh thu nhỏ.
5. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng hình ảnh nào mong muốn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Có hỗ trợ hoạt ảnh SmartArt không?**

Có. SmartArt được xem như một hình dạng thông thường, vì vậy bạn có thể [áp dụng các hoạt ảnh chuẩn](/slides/vi/python-java/shape-animation/) (xuất hiện, biến mất, nhấn mạnh, đường chuyển động) và điều chỉnh thời gian. Bạn cũng có thể tạo hoạt ảnh cho các hình bên trong các nút SmartArt khi cần.

**Làm thế nào để tôi có thể xác định đáng tin cậy một SmartArt cụ thể trên slide nếu ID nội bộ của nó không được biết?**

Gán và tìm kiếm bằng [văn bản thay thế](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getAlternativeText). Việc đặt văn bản thay thế đặc trưng cho SmartArt cho phép bạn tìm nó một cách lập trình mà không phụ thuộc vào các định danh nội bộ.

**Giao diện SmartArt có được bảo tồn khi chuyển đổi bản trình chiếu sang PDF không?**

Có. Aspose.Slides render SmartArt với độ trung thực hình ảnh cao trong quá trình [xuất PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), bảo tồn bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh của toàn bộ SmartArt (cho bản xem trước hoặc báo cáo) không?**

Có. Bạn có thể render một hình SmartArt sang [định dạng raster](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) hoặc sang [SVG](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#writeAsSvgToBytes) để có đầu ra vector có thể mở rộng, phù hợp cho hình thu nhỏ, báo cáo hoặc sử dụng trên web.