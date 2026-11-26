---
title: Quản lý Thuộc tính Bản trình chiếu bằng Python
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/python-net/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- thuộc tính bản trình chiếu
- thuộc tính tài liệu
- thuộc tính tích hợp
- thuộc tính tùy chỉnh
- thuộc tính nâng cao
- quản lý thuộc tính
- sửa đổi thuộc tính
- siêu dữ liệu tài liệu
- chỉnh sửa siêu dữ liệu
- ngôn ngữ kiểm tra
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý toàn diện các thuộc tính bản trình chiếu trong Aspose.Slides cho Python qua .NET và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint của bạn."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET hỗ trợ các thuộc tính tài liệu **built-in** và **custom**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu của bản trình chiếu, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Một thể hiện của lớp này được trả về bởi [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Các ví dụ dưới đây minh họa cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Aspose.Slides quản lý siêu dữ liệu ứng dụng và nhà sản xuất khi lưu bản trình chiếu; các trường này xác định phần mềm đã tạo ra đầu ra.
{{% /alert %}}

## **Quản lý Thuộc tính Bản trình chiếu**

Các thuộc tính tài liệu lưu trữ thông tin mô tả cùng với nội dung bản trình chiếu. Chúng chia thành hai loại:

- **Built-in properties** chứa siêu dữ liệu tiêu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Custom properties** lưu các cặp tên/giá trị do người dùng định nghĩa.

Aspose.Slides for Python via .NET cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các tab như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng tab **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công cộng từ Bản trình chiếu Được Mã hoá**

Mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi một bản trình chiếu được mã hoá bằng [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) đặt thành `False`, các thuộc tính tài liệu của nó vẫn công cộng. Ứng dụng có thể sau đó đặt [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) thành `True` và đọc siêu dữ liệu công cộng mà không cần cung cấp mật khẩu mở.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) kiểm soát những gì Aspose.Slides tải; nó không giải mã gì cả. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tùy chọn này bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ yêu cầu một bản trình chiếu đã được mã hoá mà các thuộc tính tài liệu của nó được để công cộng. Nó kiểm tra chế độ tải thông qua [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) và sau đó đọc các thuộc tính built‑in thông qua [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Trong chế độ này, nội dung slide không được tải. Slides, masters, layouts, shapes, media và các đối tượng khác của bản trình chiếu sẽ không khả dụng. Ứng dụng luôn nên kiểm tra [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình chiếu hoàn chỉnh.

{{% alert color="warning" title="Security" %}}
Siêu dữ liệu công cộng có thể lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng công cộng khi hệ thống lập chỉ mục, phân loại, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể để truy cập chúng mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình chiếu Được Mã hoá**

Đối với tệp PPTX đã được mã hoá, bản trình chiếu được tải bằng [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) chỉ nhằm mục đích đọc siêu dữ liệu công cộng. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ chứa siêu dữ liệu này vì các thuộc tính công cộng phải nhất quán với dữ liệu tương ứng trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng đòi hỏi mật khẩu mở đúng và tải toàn bộ bản trình chiếu.

Ví dụ yêu cầu một bản trình chiếu PPTX đã được mã hoá với các thuộc tính tài liệu công cộng và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình chiếu bằng [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), cập nhật các thuộc tính built‑in công cộng, và lưu kết quả. Sau đó sử dụng [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) để xác minh rằng việc mã hoá vẫn được giữ và mở lại siêu dữ liệu công cộng mà không có mật khẩu để kiểm tra các giá trị mới:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải coi các thuộc tính công cộng của tệp PPTX đã mã hoá là chỉ đọc.

## **Truy cập Thuộc tính Built‑in**

Lớp [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) cung cấp siêu dữ liệu built‑in thông qua các thuộc tính kiểu, bao gồm [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) và [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Ví dụ này mở một bản trình chiếu hiện có và in siêu dữ liệu đã lưu ra console. Các giá trị phụ thuộc vào bản trình chiếu đầu vào; một số trường có thể trống.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **Báo cáo Số Phiên bản và Thời gian Chỉnh sửa**

Để báo cáo số phiên bản và tổng thời gian chỉnh sửa cho mỗi tệp PPTX trong thư mục `presentations`, sử dụng [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) để lấy [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) mà không tải các slide để chỉnh sửa. Python hiển thị khoảng thời gian dưới dạng `timedelta`, bao gồm số ngày khi thời gian ghi lại đạt 24 giờ.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

Đối với một bản trình chiếu có 1 ngày, 2 giờ và 5 phút thời gian chỉnh sửa được ghi lại, báo cáo sẽ chứa dòng sau.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) là siêu dữ liệu có thể ghi. Giá trị của nó một mình không thể xác định bao nhiêu lần bản trình chiếu đã được lưu hoặc tái tạo lịch sử phiên bản.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) báo cáo thời lượng chỉnh sửa được lưu trong tệp. Giá trị `0:00:00` có nghĩa là thời lượng ghi lại bằng không, ngay cả khi ai đó đã chỉnh sửa bản trình chiếu.

## **Sửa đổi Thuộc tính Built‑in**

Để cập nhật siêu dữ liệu built‑in, gán giá trị cho các thuộc tính có thể ghi được mà [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) công bố. Ví dụ này mở một bản trình chiếu hiện có, đặt [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) và [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), sau đó lưu bản trình chiếu đã cập nhật bằng [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Tệp PPTX đã lưu chứa siêu dữ liệu mới.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản lý Cơ sở Siêu liên kết**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) lưu trữ cơ sở ở mức tài liệu cho các siêu liên kết tương đối. Điều này hữu ích khi di chuyển một bản trình chiếu và các tệp liên kết sang vị trí khác. Nó tách biệt với [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) của một siêu liên kết riêng lẻ: việc thay đổi cơ sở không ghi lại lại địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình chiếu chứa cả một liên kết tương đối, chẳng hạn `target.html`, và một liên kết tuyệt đối tới tệp hoặc trang web. Nó đọc cơ sở hiện có, gán một địa chỉ cơ sở mới, và lưu rồi mở lại bản trình chiếu để kiểm tra giá trị. Sau đó xóa cơ sở bằng `""` và xác minh giá trị rỗng trong một tệp đã lưu riêng. Thay địa chỉ cơ sở mẫu bằng vị trí các tệp được liên kết của bạn.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Hai thông báo xác minh nên in ra `True`. Xóa cơ sở không làm thay đổi các địa chỉ siêu liên kết riêng lẻ.

Một liên kết tương đối tới `target.pptx` đã mở `old/target.pptx` khi cơ sở trỏ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình chiếu, cùng một liên kết sẽ mở `new/target.pptx`. Một liên kết tuyệt đối vẫn mở cùng tệp. Hãy kiểm tra các liên kết tương đối của bạn trong PowerPoint trước và sau khi di chuyển bản trình chiếu hoặc thay đổi cơ sở.

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình chiếu**

Các thuộc tính tùy chỉnh lưu trữ siêu dữ liệu không có trường built‑in tương ứng. Phương thức [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) cho phép bạn gán giá trị bằng tên thuộc tính. Ví dụ này tạo một bản trình chiếu, thêm hai giá trị văn bản và một giá trị version dạng số nguyên, và lưu bản trình chiếu bằng [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Gán giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập và Sửa đổi Các Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình chiếu có chứa các thuộc tính tùy chỉnh và sử dụng [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) để duyệt qua chúng. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) nhận một chỉ mục bắt đầu từ 0 và trả về tên được sử dụng bởi [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Ví dụ yêu cầu một bản trình chiếu mà tất cả các thuộc tính tùy chỉnh đều là chuỗi. Nó in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi có số thứ tự, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh nào, vòng lặp sẽ không thực hiện thay đổi nào.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) trả về giá trị thông qua danh sách một phần tử được truyền làm đối số thứ hai. Trình giữ chỗ phải khớp với kiểu của thuộc tính đã lưu: dùng `[""]` cho chuỗi hoặc `[0]` cho số nguyên. Kiểu không khớp sẽ gây ra `InvalidCastException`; hãy chọn trình giữ chỗ phù hợp với sơ đồ thuộc tính tùy chỉnh của bạn.

## **Ví dụ Trực tiếp**

Thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/metadata) để xem cách làm việc với các thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xóa một thuộc tính built-in khỏi bản trình chiếu?**

Các thuộc tính built-in là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) rồi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) để đọc siêu dữ liệu tài liệu đã lưu mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Xem [Build a Lightweight Presentation Inventory](/slides/vi/python-net/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công cộng của một bản trình chiếu được mã hoá mà không có mật khẩu mở không?**

Có. Bản trình chiếu phải được mã hoá bằng [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) đặt thành `False`, và phải được tải bằng [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) đặt thành `True`.

**Tôi có thể cập nhật một tệp PPTX đã mã hoá ở chế độ chỉ tải tài liệu không?**

Không. Dữ liệu thuộc tính công cộng và đã mã hoá phải đồng nhất, vì vậy việc cập nhật một tệp PPTX đã mã hoá đòi hỏi phải tải toàn bộ bản trình chiếu với mật khẩu mở đúng.