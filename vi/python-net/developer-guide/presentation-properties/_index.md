---
title: Quản lý Thuộc tính Trình chiếu với Python
linktitle: Thuộc tính Trình chiếu
type: docs
weight: 70
url: /vi/python-net/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính trình chiếu
- Thuộc tính tài liệu
- Thuộc tính tích hợp
- Thuộc tính tùy chỉnh
- Thuộc tính nâng cao
- Quản lý thuộc tính
- Sửa đổi thuộc tính
- Siêu dữ liệu tài liệu
- Chỉnh sửa siêu dữ liệu
- Ngôn ngữ kiểm tra chính tả
- Ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- Trình chiếu
- Python
- Aspose.Slides
description: "Nắm vững các thuộc tính trình chiếu trong Aspose.Slides cho Python qua .NET và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình công việc trong các tệp PowerPoint của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với thuộc tính tài liệu của trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/). Một thể hiện của lớp này được trả về bởi thuộc tính [Presentation.document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/document_properties/). Các ví dụ dưới đây cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Vui lòng lưu ý rằng bạn không thể đặt giá trị cho các trường **Application** và **Producer**, vì Aspose Ltd. và Aspose.Slides for Python via .NET x.x.x sẽ được hiển thị trong các trường này.
{{% /alert %}} 

## **Quản lý thuộc tính trình chiếu**

Microsoft PowerPoint cung cấp tính năng thêm một số thuộc tính vào các tệp trình chiếu. Các thuộc tính tài liệu này cho phép lưu trữ một số thông tin hữu ích cùng với tài liệu (tệp trình chiếu). Có hai loại thuộc tính tài liệu như sau

- Thuộc tính được định nghĩa hệ thống (Built-in) Properties
- Thuộc tính do người dùng định nghĩa (Custom) Properties

**Built-in** properties chứa thông tin chung về tài liệu như tiêu đề tài liệu, tên tác giả, thống kê tài liệu, v.v. **Custom** properties là những thuộc tính được người dùng định nghĩa dưới dạng cặp **Tên/Giá trị**, trong đó cả tên và giá trị đều do người dùng quyết định. Sử dụng Aspose.Slides for Python via .NET, các nhà phát triển có thể truy cập và sửa đổi giá trị của các thuộc tính built-in cũng như custom. Microsoft PowerPoint 2007 cho phép quản lý thuộc tính tài liệu của các tệp trình chiếu. Bạn chỉ cần nhấp vào biểu tượng Office và tiếp tục mục **Prepare | Properties | Advanced Properties** trong Microsoft PowerPoint 2007. Sau khi chọn mục **Advanced Properties**, một hộp thoại sẽ xuất hiện cho phép bạn quản lý thuộc tính tài liệu của tệp PowerPoint. Trong **Properties Dialog**, bạn sẽ thấy nhiều tab như **General, Summary, Statistics, Contents and Custom**. Tất cả các tab này cho phép cấu hình các loại thông tin khác nhau liên quan đến tệp PowerPoint. Tab **Custom** được dùng để quản lý các thuộc tính tùy chỉnh của tệp PowerPoint.

## **Truy cập thuộc tính Built-in**
Những thuộc tính được đưa ra bởi đối tượng **IDocumentProperties** bao gồm: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** và **Title**
```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho bản trình chiếu
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Tạo một tham chiếu tới đối tượng liên kết với Presentation
    documentProperties = pres.document_properties

    # Hiển thị các thuộc tính tích hợp sẵn
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

## **Sửa đổi thuộc tính Built-in**

Việc sửa đổi các thuộc tính built-in của tệp trình chiếu đơn giản như việc truy cập chúng. Bạn chỉ cần gán một giá trị chuỗi cho bất kỳ thuộc tính nào mong muốn và giá trị thuộc tính sẽ được thay đổi. Trong ví dụ dưới đây, chúng tôi đã minh họa cách chúng ta có thể sửa đổi các thuộc tính tài liệu built-in của tệp trình chiếu.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Tạo một tham chiếu tới đối tượng liên kết với Presentation
    documentProperties = presentation.document_properties

    # Đặt các thuộc tính tích hợp sẵn
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Lưu bản trình chiếu của bạn vào tệp
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm thuộc tính tùy chỉnh cho trình chiếu**

Aspose.Slides for Python via .NET cũng cho phép các nhà phát triển thêm các giá trị tùy chỉnh cho thuộc tính tài liệu của trình chiếu. Một ví dụ được đưa ra dưới đây cho thấy cách đặt các thuộc tính tùy chỉnh cho một trình chiếu.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation
with slides.Presentation() as presentation:
    # Lấy thuộc tính tài liệu
    documentProperties = presentation.document_properties

    # Thêm thuộc tính tùy chỉnh
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Lấy tên thuộc tính tại chỉ mục cụ thể
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Xóa thuộc tính đã chọn
    documentProperties.remove_custom_property(getPropertyName)

    # Lưu bản trình chiếu
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập và sửa đổi thuộc tính Custom**

Aspose.Slides for Python via .NET cũng cho phép các nhà phát triển truy cập giá trị của các thuộc tính tùy chỉnh. Một ví dụ được đưa ra dưới đây cho thấy cách bạn có thể truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh này cho một trình chiếu.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Tạo một tham chiếu tới đối tượng document_properties liên kết với Presentation
    documentProperties = presentation.document_properties

    # Truy cập và sửa đổi các thuộc tính tùy chỉnh
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Sửa đổi giá trị của các thuộc tính tùy chỉnh
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Lưu bản trình chiếu của bạn vào tệp
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` trả về giá trị thông qua danh sách một phần tử được truyền làm đối số thứ hai, và giá trị được lưu trữ sẽ được ép kiểu sang kiểu của phần tử đã có trong danh sách đó. Ví dụ trên sử dụng `[""]`, vì vậy nó đọc các thuộc tính kiểu chuỗi; để đọc một thuộc tính lưu dưới dạng số, truyền một placeholder số như `[0]`—nếu không, cuộc gọi sẽ ném ra một `InvalidCastException`.

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp thuộc tính `Language_Id` (được đưa ra bởi lớp [PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/)) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà chính tả và ngữ pháp trong PowerPoint được kiểm tra.

Đoạn mã Python sau cho bạn thấy cách đặt ngôn ngữ kiểm tra chính tả cho một PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
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

## **Đặt ngôn ngữ mặc định**

Đoạn mã Python sau cho bạn thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

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

## **Ví dụ thực tế**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với thuộc tính tài liệu thông qua API Aspose.Slides:

[![Xem & Chỉnh sửa siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xóa một thuộc tính Built-in khỏi trình chiếu?**

Các thuộc tính Built-in là một phần không thể tách rời của trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính Custom đã tồn tại?**

Nếu bạn thêm một thuộc tính Custom đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập thuộc tính trình chiếu mà không tải toàn bộ trình chiếu không?**

Có. Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) rồi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) để đọc siêu dữ liệu tài liệu được lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/python-net/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.