---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bài thuyết trình bằng Python
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/python-java/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- XML tùy chỉnh
- phần XML tùy chỉnh
- siêu dữ liệu XML
- ItemId
- thêm thẻ
- cặp giá trị
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bài thuyết trình PowerPoint với Aspose.Slides cho Python qua Java, bao gồm việc thêm, đọc, cập nhật, kiểm toán và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bài thuyết trình PowerPoint. Dữ liệu đặc thù cho bài thuyết trình có thể được lưu dưới dạng thẻ hoặc phần XML tùy chỉnh. Thẻ là các cặp chuỗi khóa-giá trị đơn giản, trong khi phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và các tải XML riêng của ứng dụng.

Aspose.Slides cung cấp API để thêm, đọc, cập nhật, kiểm toán và xóa phần XML tùy chỉnh ở cấp độ bài thuyết trình, slide và shape. Phần XML tùy chỉnh hữu ích cho các tích hợp lưu trữ thông tin như định danh quản lý tài liệu, trạng thái quy trình công việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác bên trong một bài thuyết trình.

## **Lưu trữ dữ liệu trong tệp bài thuyết trình**

Các tệp PPTX—các tệp có phần mở rộng `.pptx`—được lưu ở định dạng PresentationML, là một phần của thông số kỹ thuật Office Open XML. Office Open XML định nghĩa cấu trúc gói và các quan hệ được sử dụng để lưu trữ nội dung bài thuyết trình và dữ liệu liên quan.

Một bài thuyết trình chứa nhiều phần được kết nối bằng các quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các quan hệ rõ ràng tới các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([TagCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/)) hoặc phần XML tùy chỉnh ([CustomXmlPartCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/)). Cả hai đều có sẵn thông qua lớp [CustomData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Note" %}}
Thẻ lưu trữ các cặp khóa-giá trị chuỗi đơn giản. Phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bài thuyết trình, slide hoặc shape.
{{% /alert %}}

## **Làm việc với phần XML tùy chỉnh**

Phương thức [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getCustomXmlParts) trả về bộ sưu tập các phần XML tùy chỉnh liên kết với một đối tượng bài thuyết trình cụ thể. Ví dụ:

- Bộ sưu tập [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getCustomXmlParts) của bài thuyết trình chứa các phần XML tùy chỉnh liên kết với chính bài thuyết trình.
- Bộ sưu tập [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getCustomXmlParts) của slide chứa các phần XML tùy chỉnh liên kết với slide cụ thể.
- Bộ sưu tập [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getCustomXmlParts) của shape chứa các phần XML tùy chỉnh liên kết với shape cụ thể.

Sử dụng [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bài thuyết trình bất kể chúng được liên kết ở đâu.

### **Thêm một phần XML tùy chỉnh vào bài thuyết trình**

Sử dụng [CustomXmlPartCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#add) để thêm dữ liệu XML vào bộ sưu tập phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ sưu tập dữ liệu tùy chỉnh cấp độ bài thuyết trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add tự động gán một định danh. Chỉ đặt UUID cụ thể khi cần thiết.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Phương thức [add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#add) cũng có thể nhận XML dưới dạng mảng byte hoặc luồng đầu vào, hữu ích khi nội dung XML đã có dạng nhị phân.

### **Thêm một phần XML tùy chỉnh vào slide hoặc shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bài thuyết trình. Điều này hữu ích khi siêu dữ liệu mô tả chỉ một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cấp độ mà phần được thêm vào quyết định bộ sưu tập [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getCustomXmlParts) của đối tượng nào sẽ chứa quan hệ tới phần đó. Dữ liệu cấp độ bài thuyết trình phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu cấp độ slide cho thông tin thuộc về một slide cụ thể, và dữ liệu cấp độ shape cho siêu dữ liệu gắn với một shape cá nhân.

### **Liệt kê và kiểm toán tất cả các phần XML tùy chỉnh**

Sử dụng [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) để lấy tất cả các phần XML tùy chỉnh từ một bài thuyết trình. Mỗi [CustomXmlPart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê tất cả các phần XML tùy chỉnh và schema không gian tên của chúng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) trả về các schema XML liên quan tới phần XML tùy chỉnh. Thông tin này hữu ích khi kiểm toán các bài thuyết trình có chứa XML được tạo bởi hệ thống bên ngoài.

### **Đọc và cập nhật nội dung XML và ItemId**

Sử dụng [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getXmlAsString) và [setXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlAsString) để làm việc với XML dưới dạng chuỗi UTF-8, hoặc [getXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getXmlData) và [setXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlData) để làm việc với các byte XML thô.

Phương thức [CustomXmlPart.getItemId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getItemId) trả về UUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. Sử dụng [setItemId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setItemId) khi một tích hợp yêu cầu một định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Đọc XML hiện tại dưới dạng văn bản.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Cập nhật XML dưới dạng chuỗi UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData cung cấp cùng nội dung XML dưới dạng byte thô.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Thay thế định danh khi tích hợp yêu cầu.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

Khi gọi [setXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlAsString) hoặc [setXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlData), cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai biểu diễn tùy thuộc vào việc ứng dụng của bạn làm việc chủ yếu với chuỗi hay dữ liệu byte.

### **Xóa một phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#remove) xóa phần XML tùy chỉnh khỏi bài thuyết trình.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#remove) xóa một phần cụ thể khỏi bộ sưu tập phần XML tùy chỉnh.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#removeAt) xóa phần tại một chỉ mục bộ sưu tập xác định.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#clear) xóa tất cả các phần khỏi một bộ sưu tập cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh cấp độ bài thuyết trình bằng tham chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nếu bạn đã có một [CustomXmlPart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/) và muốn xóa phần đó khỏi bài thuyết trình thay vì xử lý một bộ sưu tập cụ thể, hãy gọi [CustomXmlPart.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#remove).

Bạn cũng có thể xóa một mục theo chỉ mục:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Xóa toàn bộ các phần XML tùy chỉnh khỏi một bộ sưu tập**

Sử dụng [clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#clear) khi tất cả các phần XML tùy chỉnh liên kết với một đối tượng bài thuyết trình cụ thể cần được xóa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#clear) chỉ ảnh hưởng đến bộ sưu tập được chọn. Ví dụ, xóa bộ sưu tập của một slide không xóa các bộ sưu tập cấp độ bài thuyết trình hoặc shape.

Để xóa mọi phần XML tùy chỉnh trong bài thuyết trình, duyệt qua [getAllCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) và xóa từng phần:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Xử lý các phần XML tùy chỉnh được liên kết hoặc chia sẻ**

Trong một bài thuyết trình Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ nhiều đối tượng bài thuyết trình. Ví dụ, một tệp hiện có có thể chứa quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh cơ bản.

Một phần chia sẻ nên được coi là một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật nó bằng [setXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlData) hoặc [setItemId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setItemId) sẽ thay đổi phần XML tùy chỉnh nền, do đó thay đổi sẽ áp dụng ở mọi nơi mà phần đó được tham chiếu.
- [getItemId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getItemId) có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm toán các bộ sưu tập cấp độ đối tượng.
- Xóa một phần khỏi một bộ sưu tập [getCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getCustomXmlParts) cụ thể sẽ xóa nó chỉ khỏi bộ sưu tập đó. Sử dụng [CustomXmlPart.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#remove) khi phần đó cần được xóa hoàn toàn khỏi bài thuyết trình.
- Trước khi xóa hoặc thay thế một phần được chia sẻ, kiểm tra các bộ sưu tập cấp độ đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu tới nó hay không.

Các overload của [add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpartcollection/#add) tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một [CustomXmlPart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/) đã tồn tại. Do đó, các quan hệ chia sẻ thường gặp nhất khi tải các bài thuyết trình đã chứa chúng.

Ví dụ sau kiểm toán các bộ sưu tập cấp độ bài thuyết trình, slide và shape theo `ItemId` và báo cáo các phần được tham chiếu từ hơn một nơi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Kiểm toán kiểu này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bài thuyết trình được tạo bởi hệ thống bên ngoài, vì cùng một phần siêu dữ liệu có thể tham gia vào hơn một quan hệ.

## **Lấy giá trị của các thẻ**

Trong Slides, một thẻ tương ứng với phương thức [DocumentProperties.getKeywords](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getKeywords). Đoạn mã mẫu này cho thấy cách lấy giá trị thẻ bằng Aspose.Slides for Python via Java cho [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Thêm thẻ vào bài thuyết trình**

Aspose.Slides cho phép bạn thêm thẻ vào các bài thuyết trình. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ, `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ, `My Tag Value`.

Nếu bạn cần phân loại các bài thuyết trình dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bài thuyết trình từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ North American và gán quốc gia liên quan làm giá trị.

Đoạn mã mẫu này cho thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) bằng Aspose.Slides for Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) riêng lẻ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Giới hạn**

Các thẻ được thêm thông qua bộ sưu tập [CustomData.getTags](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customdata/#getTags) chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bài thuyết trình được xuất sang PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF có thẻ.

**Cách khắc phục**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, [Shape.setAlternativeText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setAlternativeText) với giá trị `"MyId"`). Sau khi xuất sang PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **FAQ**

**Tôi có thể xóa tất cả thẻ khỏi một bài thuyết trình, slide hoặc shape trong một thao tác không?**

Có. Bộ sưu tập [tag collection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/#clear) để xóa toàn bộ các cặp khóa-giá trị cùng một lúc.

**Làm thế nào để xóa một thẻ đơn lẻ theo tên mà không cần duyệt qua toàn bộ bộ sưu tập?**

Sử dụng [remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/#remove) trên [tag collection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/#getNamesOfTags) trên [tag collection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.

**Làm sao tôi có thể tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getAllCustomXmlParts) để lấy tất cả các phần XML tùy chỉnh trong bài thuyết trình.

**Nên sử dụng [getXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlAsString) hay [getXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlData) để cập nhật một phần XML tùy chỉnh?**

Sử dụng [getXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getXmlAsString) và [setXmlAsString](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlAsString) khi ứng dụng làm việc với văn bản XML UTF-8. Sử dụng [getXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#getXmlData) và [setXmlData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/customxmlpart/#setXmlData) khi XML đã có sẵn dưới dạng mảng byte hoặc khi xử lý dạng nhị phân thuận lợi hơn. Cả hai biểu diễn đều đề cập tới nội dung XML của cùng một phần XML tùy chỉnh.