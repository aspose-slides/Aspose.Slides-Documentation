---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu với Python
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/python-net/managing-tags-and-custom-data/
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
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách quản lý thẻ và dữ liệu XML tùy chỉnh trong các bản trình chiếu PowerPoint bằng Aspose.Slides cho Python qua .NET, bao gồm việc thêm, đọc, cập nhật, kiểm tra và xóa các phần XML tùy chỉnh."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong bản trình chiếu PowerPoint. Dữ liệu đặc thù cho bản trình chiếu có thể được lưu dưới dạng thẻ hoặc phần XML tùy chỉnh. Thẻ là các cặp khóa-giá trị chuỗi đơn giản, trong khi phần XML tùy chỉnh có thể lưu trữ siêu dữ liệu có cấu trúc và dữ liệu XML đặc thù của ứng dụng.

Aspose.Slides cung cấp API để thêm, đọc, cập nhật, kiểm tra và xóa phần XML tùy chỉnh ở mức bản trình chiếu, slide và shape. Phần XML tùy chỉnh hữu ích cho các tích hợp lưu thông tin như định danh quản lý tài liệu, trạng thái quy trình công việc, siêu dữ liệu tuân thủ, dữ liệu ràng buộc mẫu, hoặc các dữ liệu ứng dụng có cấu trúc khác bên trong bản trình chiếu.

## **Lưu trữ dữ liệu trong tệp bản trình chiếu**

Các tệp PPTX — các tệp có phần mở rộng `.pptx` — được lưu ở định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Office Open XML định nghĩa cấu trúc gói và các mối quan hệ được sử dụng để lưu nội dung bản trình chiếu và dữ liệu liên quan.

Một bản trình chiếu chứa nhiều phần được kết nối bằng các mối quan hệ. Ví dụ, một phần slide chứa nội dung của một slide duy nhất và có thể có các mối quan hệ rõ ràng tới các phần khác được định nghĩa bởi ISO/IEC 29500.

Dữ liệu tùy chỉnh có thể được lưu dưới dạng thẻ ([TagCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/)) hoặc phần XML tùy chỉnh ([CustomXmlPartCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpartcollection/)). Cả hai đều được truy cập qua lớp [`CustomData`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
Thẻ lưu trữ các cặp khóa-giá trị chuỗi đơn giản. Phần XML tùy chỉnh lưu trữ dữ liệu XML có cấu trúc và có thể được liên kết với một bản trình chiếu, slide hoặc shape.
{{% /alert %}}

## **Làm việc với Phần XML tùy chỉnh**

Thuộc tính [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customdata/custom_xml_parts/) trả về bộ sưu tập các phần XML tùy chỉnh được liên kết với một đối tượng bản trình chiếu cụ thể. Ví dụ:

- `presentation.custom_data.custom_xml_parts` chứa các phần XML tùy chỉnh được liên kết với chính bản trình chiếu.
- `slide.custom_data.custom_xml_parts` chứa các phần XML tùy chỉnh được liên kết với một slide cụ thể.
- `shape.custom_data.custom_xml_parts` chứa các phần XML tùy chỉnh được liên kết với một shape cụ thể.

Sử dụng [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/all_custom_xml_parts/) khi bạn cần kiểm tra tất cả các phần XML tùy chỉnh trong bản trình chiếu bất kể chúng được liên kết ở đâu.

### **Thêm một Phần XML tùy chỉnh vào Bản trình chiếu**

Sử dụng [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpartcollection/add/) để thêm dữ liệu XML vào bộ sưu tập phần XML tùy chỉnh. XML phải hợp lệ và không rỗng.

Ví dụ sau thêm siêu dữ liệu có cấu trúc vào bộ sưu tập dữ liệu tùy chỉnh cấp bản trình chiếu:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add tự động gán một định danh. Chỉ đặt GUID cụ thể khi cần thiết.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Phương thức `add` cũng có thể chấp nhận XML dưới dạng mảng byte hoặc luồng, hữu ích khi nội dung XML đã có sẵn ở dạng nhị phân.

### **Thêm một Phần XML tùy chỉnh vào Slide hoặc Shape**

Dữ liệu XML tùy chỉnh có thể được liên kết với một slide hoặc shape cụ thể thay vì toàn bộ bản trình chiếu. Điều này hữu ích khi siêu dữ liệu chỉ mô tả một đối tượng, chẳng hạn như khóa mẫu, định danh bản ghi bên ngoài, hoặc thông tin ràng buộc.

Ví dụ sau thêm một phần XML tùy chỉnh vào một slide và một phần khác vào một shape:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Mức độ mà một phần được thêm vào quyết định bộ sưu tập `custom_data.custom_xml_parts` của đối tượng nào sẽ chứa mối quan hệ tới phần đó. Dữ liệu cấp bản trình chiếu phù hợp cho siêu dữ liệu toàn tài liệu, dữ liệu cấp slide cho thông tin thuộc về một slide cụ thể, và dữ liệu cấp shape cho siêu dữ liệu gắn với một shape đơn lẻ.

### **Liệt kê và Kiểm tra Tất cả các Phần XML tùy chỉnh**

Sử dụng [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/all_custom_xml_parts/) để lấy về tất cả các phần XML tùy chỉnh từ một bản trình chiếu. Mỗi [`CustomXmlPart`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpart/) cung cấp định danh, nội dung XML và các schema không gian tên liên quan.

Ví dụ sau liệt kê toàn bộ các phần XML tùy chỉnh và schema không gian tên của chúng:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpart/namespace_schemas/) trả về các schema XML được liên kết với phần XML tùy chỉnh. Thông tin này hữu ích khi kiểm tra các bản trình chiếu chứa XML được tạo bởi hệ thống bên ngoài.

### **Đọc và Cập nhật Nội dung XML và ItemId**

Sử dụng [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpart/xml_as_string/) để làm việc với XML dưới dạng chuỗi UTF-8, hoặc [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpart/xml_data/) để làm việc với dữ liệu XML thô. Cả hai thuộc tính đều có thể đọc và cập nhật.

Thuộc tính [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpart/item_id/) chứa GUID xác định phần XML tùy chỉnh trong tài liệu Office Open XML. GUID này cũng có thể được thay đổi khi một tích hợp yêu cầu định danh mới.

Ví dụ sau cập nhật nội dung XML và định danh:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Đọc XML hiện tại dưới dạng văn bản.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Cập nhật XML dưới dạng chuỗi UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data cung cấp cùng nội dung XML dưới dạng byte thô.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Thay thế định danh khi tích hợp yêu cầu.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Khi gán `xml_as_string` hoặc `xml_data`, hãy cung cấp XML hợp lệ, không rỗng. Sử dụng một trong hai biểu diễn tùy theo ứng dụng làm việc chủ yếu với chuỗi hoặc dữ liệu byte.

### **Xóa một Phần XML tùy chỉnh**

Aspose.Slides cung cấp một số cách để xóa dữ liệu XML tùy chỉnh:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpart/remove/) xóa phần XML tùy chỉnh khỏi bản trình chiếu.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpartcollection/remove/) xóa một phần cụ thể khỏi bộ sưu tập phần XML tùy chỉnh.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpartcollection/remove_at/) xóa phần tại một chỉ mục bộ sưu tập nhất định.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/customxmlpartcollection/clear/) xóa tất cả các phần khỏi một bộ sưu tập cụ thể.

Ví dụ sau xóa một phần XML tùy chỉnh cấp bản trình chiếu bằng tham chiếu:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn đã có một `CustomXmlPart` và muốn xóa phần đó khỏi bản trình chiếu thay vì thông qua một bộ sưu tập cụ thể, gọi `custom_xml_part.remove()`.

Bạn cũng có thể xóa mục theo chỉ mục:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Xóa toàn bộ Phần XML tùy chỉnh khỏi một Bộ sưu tập**

Sử dụng `clear` khi muốn xóa tất cả các phần XML tùy chỉnh liên kết với một đối tượng bản trình chiếu cụ thể.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` chỉ ảnh hưởng tới bộ sưu tập đã chọn. Ví dụ, xóa bộ sưu tập của một slide sẽ không xóa các bộ sưu tập cấp bản trình chiếu hoặc cấp shape.

Để xóa mọi phần XML tùy chỉnh trong bản trình chiếu, lặp qua `all_custom_xml_parts` và xóa từng phần:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Xử lý các Phần XML tùy chỉnh Liên kết hoặc Chia sẻ**

Trong một bản trình chiếu Office Open XML, cùng một phần XML tùy chỉnh có thể được tham chiếu từ hơn một đối tượng bản trình chiếu. Ví dụ, một tệp tồn tại có thể chứa các mối quan hệ từ nhiều slide hoặc shape tới cùng một phần XML tùy chỉnh nền tảng.

Một phần chia sẻ nên được xem như một đối tượng dữ liệu duy nhất với nhiều tham chiếu:

- Cập nhật `xml_as_string`, `xml_data` hoặc `item_id` của nó sẽ thay đổi phần XML tùy chỉnh nền tảng, vì vậy thay đổi sẽ áp dụng ở mọi nơi phần đó được tham chiếu.
- `item_id` có thể được dùng để xác định cùng một phần XML tùy chỉnh khi kiểm tra các bộ sưu tập cấp đối tượng.
- Xóa một phần khỏi một bộ sưu tập `custom_xml_parts` cụ thể chỉ xóa nó khỏi bộ sưu tập đó. Dùng `CustomXmlPart.remove()` khi muốn xóa phần đó khỏi toàn bộ bản trình chiếu.
- Trước khi xóa hoặc thay thế một phần chia sẻ, hãy kiểm tra các bộ sưu tập cấp đối tượng để xác định liệu các slide hoặc shape khác còn tham chiếu đến nó hay không.

Các overload `add` tạo một phần XML tùy chỉnh mới từ nội dung XML; chúng không chấp nhận một `CustomXmlPart` hiện có. Do đó, các mối quan hệ chia sẻ thường xuất hiện nhất khi tải các bản trình chiếu đã chứa chúng.

Ví dụ sau kiểm tra các bộ sưu tập cấp bản trình chiếu, slide và shape bằng `item_id` và báo cáo các phần được tham chiếu từ hơn một vị trí:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Loại kiểm tra này hữu ích trước khi sửa đổi hoặc xóa dữ liệu XML tùy chỉnh trong các bản trình chiếu được tạo bởi hệ thống bên ngoài, vì cùng một phần siêu dữ liệu có thể tham gia vào hơn một mối quan hệ.

## **Lấy Giá trị của Thẻ**

Trong Slides, một thẻ tương ứng với thuộc tính `DocumentProperties.keywords`. Đoạn mã mẫu dưới đây cho biết cách lấy giá trị thẻ bằng Aspose.Slides for Python via .NET cho [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Thêm Thẻ vào Bản trình chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình chiếu. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh, ví dụ `MyTag`;
- giá trị của thuộc tính tùy chỉnh, ví dụ `My Tag Value`.

Nếu bạn cần phân loại bản trình chiếu dựa trên một quy tắc hoặc thuộc tính cụ thể, bạn có thể thêm thẻ cho mục đích đó. Ví dụ, nếu muốn phân loại các bản trình chiếu từ các quốc gia Bắc Mỹ, bạn có thể tạo một thẻ Bắc Mỹ và gán quốc gia tương ứng làm giá trị.

Đoạn mã mẫu dưới đây cho biết cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) bằng Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Thẻ cũng có thể được đặt cho một [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Hoặc cho một [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) riêng lẻ:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Giới hạn**

Thẻ được thêm qua bộ sưu tập `custom_data.tags` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Cách khắc phục**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.alternative_text = "MyId"`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác duy nhất không?**

Có. Bộ sưu tập [thẻ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/clear/) để xóa mọi cặp khóa-giá trị cùng một lúc.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không cần lặp qua toàn bộ bộ sưu tập?**

Sử dụng [remove(name)](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao để lấy danh sách đầy đủ các tên thẻ cho việc phân tích hoặc lọc?**

Sử dụng [get_names_of_tags](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/get_names_of_tags/) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/python-net/aspose.slides/tagcollection/); nó trả về một mảng các tên thẻ.

**Làm sao để tìm tất cả các phần XML tùy chỉnh bất kể chúng được lưu ở đâu?**

Sử dụng [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/all_custom_xml_parts/) để lấy mọi phần XML tùy chỉnh trong bản trình chiếu.

**Nên dùng `xml_as_string` hay `xml_data` để cập nhật một phần XML tùy chỉnh?**

Dùng `xml_as_string` khi ứng dụng làm việc với văn bản XML UTF-8. Dùng `xml_data` khi XML đã có sẵn dưới dạng mảng byte hoặc khi xử lý ở mức nhị phân thuận tiện hơn. Cả hai thuộc tính đều đại diện cho nội dung XML của cùng một phần XML tùy chỉnh.