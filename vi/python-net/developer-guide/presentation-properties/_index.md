---
title: Quản lý Thuộc tính Bài thuyết trình bằng Python
linktitle: Thuộc tính Bài thuyết trình
type: docs
weight: 70
url: /vi/python-net/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bài thuyết trình
- thuộc tính tài liệu
- thuộc tính tích hợp
- thuộc tính tùy chỉnh
- thuộc tính nâng cao
- quản lý thuộc tính
- sửa đổi thuộc tính
- siêu dữ liệu tài liệu
- chỉnh sửa siêu dữ liệu
- ngôn ngữ kiểm tra chính tả
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Nắm vững các thuộc tính bài thuyết trình trong Aspose.Slides cho Python qua .NET và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu bài thuyết trình thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/). Một thể hiện của lớp này được trả về bởi thuộc tính [Presentation.document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/document_properties/). Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="primary" %}} 
Xin lưu ý rằng bạn không thể đặt giá trị cho các trường **Application** và **Producer**, vì sẽ hiển thị Aspose Ltd. và Aspose.Slides for Python via .NET x.x.x ở các trường này.
{{% /alert %}} 

## **Quản lý Thuộc tính Bài thuyết trình**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào các tệp bài thuyết trình. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (tệp bài thuyết trình). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính Được định nghĩa Hệ thống (Built-in)
- Thuộc tính Được định nghĩa Người dùng (Custom)

**Built-in** properties chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. **Custom** properties là những thuộc tính được người dùng định nghĩa dưới dạng cặp **Name/Value**, trong đó cả tên và giá trị do người dùng xác định. Sử dụng Aspose.Slides for Python via .NET, các nhà phát triển có thể truy cập và sửa đổi giá trị của các thuộc tính built-in cũng như custom. Microsoft PowerPoint 2007 cho phép quản lý các thuộc tính tài liệu của các tệp bài thuyết trình. Bạn chỉ cần nhấn vào biểu tượng Office và sau đó chọn mục **Prepare | Properties | Advanced Properties** trong Microsoft PowerPoint 2007. Khi bạn chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint. Trong **Properties Dialog**, bạn sẽ thấy có nhiều tab như **General, Summary, Statistics, Contents và Custom**. Tất cả các tab này cho phép cấu hình các loại thông tin khác nhau liên quan tới các tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính custom của các tệp PowerPoint.

## **Truy cập Thuộc tính Built-in**

Các thuộc tính này được **IDocumentProperties** cung cấp bao gồm: **Creator(Author)**, **Description**, **Keywords**, **Created** (Ngày tạo), **Modified** (Ngày sửa đổi), **Printed** (Ngày in cuối cùng), **LastModifiedBy**, **Keywords**, **SharedDoc** (Có được chia sẻ giữa các nhà sản xuất khác nhau không?), **PresentationFormat**, **Subject** và **Title**.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho bài thuyết trình
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Tạo một tham chiếu tới đối tượng liên kết với Presentation
    documentProperties = pres.document_properties

    # Hiển thị các thuộc tính tích hợp
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Sửa đổi Thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp bài thuyết trình cũng dễ dàng như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã trình bày cách chúng ta có thể sửa đổi các thuộc tính tài liệu built-in của tệp bài thuyết trình.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho bài thuyết trình
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Tạo một tham chiếu tới đối tượng liên kết với Presentation
    documentProperties = presentation.document_properties

    # Đặt các thuộc tính tích hợp
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # lưu bài thuyết trình của bạn vào tệp
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Thuộc tính Bài thuyết trình Tùy chỉnh**

Aspose.Slides for Python via .NET cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho các thuộc tính tài liệu của bài thuyết trình. Một ví dụ dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một bài thuyết trình.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation
with slides.Presentation() as presentation:
    # Lấy các Thuộc tính Tài liệu
    documentProperties = presentation.document_properties

    # Thêm các thuộc tính Tùy chỉnh
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Lấy tên thuộc tính tại chỉ mục cụ thể
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Xóa thuộc tính đã chọn
    documentProperties.remove_custom_property(getPropertyName)

    # Lưu bài thuyết trình
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Aspose.Slides for Python via .NET cũng cho phép các nhà phát triển truy cập các giá trị của các thuộc tính tùy chỉnh. Một ví dụ dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh này cho một bài thuyết trình.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Tạo một tham chiếu tới đối tượng document_properties liên kết với Presentation
    documentProperties = presentation.document_properties

    # Truy cập và sửa đổi các thuộc tính tùy chỉnh
    for i in range(documentProperties.count_of_custom_properties):
        # Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Sửa đổi giá trị của các thuộc tính tùy chỉnh
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # lưu bài thuyết trình của bạn vào tệp
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp thuộc tính `Language_Id` (được cung cấp bởi lớp [PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/)) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint sẽ được kiểm tra.

Đoạn mã Python này cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # đặt Id của ngôn ngữ kiểm tra chính tả
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Đặt Ngôn ngữ Mặc định**

Đoạn mã Python này cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bài thuyết trình PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Ví dụ Thực tế**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API Aspose.Slides:

[![Xem & Chỉnh sửa Metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xóa một thuộc tính built-in khỏi bài thuyết trình?**

Các thuộc tính built-in là một phần không thể tách rời của bài thuyết trình và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bài thuyết trình mà không tải toàn bộ bài thuyết trình không?**

Có, bạn có thể truy cập các thuộc tính bài thuyết trình mà không cần tải toàn bộ bài thuyết trình bằng cách sử dụng phương thức [get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) từ lớp [PresentationFactory](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/). Sau đó, sử dụng phương thức [read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) được cung cấp bởi lớp [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/) để đọc các thuộc tính một cách hiệu quả, tiết kiệm bộ nhớ và cải thiện hiệu năng.