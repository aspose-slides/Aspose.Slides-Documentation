---
title: Quản lý Thuộc tính Bản trình bày trong Python
linktitle: Thuộc tính Bản trình bày
type: docs
weight: 70
url: /vi/python-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính bản trình bày
- Thuộc tính tài liệu
- Thuộc tính có sẵn
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
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý các thuộc tính của bản trình bày trong Aspose.Slides cho Python thông qua Java và tối ưu hóa tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides cho Python thông qua Java hỗ trợ các thuộc tính tài liệu **có sẵn** và **tùy chỉnh**. Sử dụng các thuộc tính này để đọc và cập nhật siêu dữ liệu bản trình bày, chẳng hạn như tác giả, tiêu đề và các giá trị do người dùng định nghĩa.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu bản trình bày thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) . Một thể hiện của lớp này được trả về bởi [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) . Các ví dụ sau đây minh họa cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Note" %}}
Aspose.Slides quản lý siêu dữ liệu ứng dụng và nhà sản xuất khi lưu bản trình bày; các trường này xác định phần mềm đã tạo ra tệp đầu ra.
{{% /alert %}}

## **Quản lý Thuộc tính Bản trình bày**

Các thuộc tính tài liệu lưu trữ thông tin mô tả cùng với nội dung bản trình bày. Chúng chia thành hai loại:

- **Thuộc tính có sẵn** chứa siêu dữ liệu tiêu chuẩn, chẳng hạn như tiêu đề, tác giả và thống kê tài liệu.
- **Thuộc tính tùy chỉnh** lưu trữ các cặp tên/giá trị do người dùng định nghĩa.

Aspose.Slides cho Python thông qua Java cung cấp quyền truy cập vào cả hai loại. Trong PowerPoint, chọn **File → Info → Properties → Advanced Properties** để kiểm tra siêu dữ liệu tài liệu. Hộp thoại nhóm thông tin thành các tab như **Summary**, **Statistics**, **Contents**, và **Custom**. Sử dụng tab **Custom** để quản lý các thuộc tính do người dùng định nghĩa.

## **Đọc Thuộc tính Công khai từ Bản trình bày Được Mã hóa**

Mật khẩu mở thường bảo vệ cả nội dung bản trình bày và các thuộc tính tài liệu. Khi một bản trình bày được mã hóa sau khi gọi [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) với `False`, các thuộc tính tài liệu của nó vẫn công khai. Ứng dụng sau đó có thể gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) với `True` và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) điều khiển những gì Aspose.Slides tải; nó không giải mã bất kỳ thứ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hóa, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình bày không được mã hóa, tùy chọn sẽ bị bỏ qua và toàn bộ bản trình bày sẽ được tải.

Ví dụ yêu cầu một bản trình bày được mã hóa mà các thuộc tính tài liệu của nó được để công khai. Nó xác minh chế độ tải thông qua [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) và sau đó đọc các thuộc tính có sẵn qua [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng khác của bản trình bày không khả dụng. Ứng dụng nên luôn kiểm tra [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) trước khi thực hiện thao tác đòi hỏi mô hình đối tượng bản trình bày đầy đủ.

{{% alert color="warning" title="Warning" %}}
Siêu dữ liệu công khai có thể lộ tên tác giả, tiêu đề, đề mục, từ khóa, thông tin công ty, bình luận và các giá trị tùy chỉnh. Hãy mã hóa các thuộc tính nhạy cảm cùng với bản trình bày. Chỉ để chúng công khai khi việc lập chỉ mục, phân loại, tìm kiếm hoặc hệ thống quản lý tài liệu có yêu cầu cụ thể để truy cập mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật Thuộc tính của Bản trình bày Được Mã hóa**

Đối với tệp PPTX được mã hóa, một bản trình bày được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) với `True` nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ chứa siêu dữ liệu này vì các thuộc tính công khai phải nhất quán với dữ liệu tương ứng trong bản trình bày đã mã hóa. Do đó, việc cập nhật chúng yêu cầu mật khẩu mở đúng và một lần tải đầy đủ.

Ví dụ yêu cầu một bản trình bày PPTX được mã hóa với các thuộc tính tài liệu công khai và một mật khẩu mở đã biết. Nó mở toàn bộ bản trình bày bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), cập nhật các thuộc tính có sẵn công khai, và lưu kết quả. Sau đó nó sử dụng [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) để xác minh rằng việc mã hóa vẫn được duy trì và mở lại siêu dữ liệu công khai mà không cần mật khẩu để xác nhận các giá trị mới:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình bày, nó phải coi các thuộc tính công khai của tệp PPTX được mã hóa là chỉ đọc.

## **Truy cập Thuộc tính Có sẵn**

Lớp [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) cung cấp siêu dữ liệu có sẵn thông qua các phương thức getter, bao gồm [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) và [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Ví dụ này mở một bản trình bày hiện có và in siêu dữ liệu đã lưu ra console. Giá trị phụ thuộc vào bản trình bày đầu vào; một số trường có thể để trống.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

## **Sửa đổi Thuộc tính Có sẵn**

Để cập nhật siêu dữ liệu có sẵn, sử dụng các phương thức setter trên đối tượng trả về bởi [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties). Ví dụ này mở một bản trình bày hiện có, gọi [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) và [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), sau đó lưu bản trình bày đã cập nhật bằng [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Tệp PPTX đã lưu chứa siêu dữ liệu mới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Quản lý Cơ sở Siêu liên kết**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) trả về cơ sở cấp độ tài liệu cho các siêu liên kết tương đối. Sử dụng [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) để thay đổi hoặc xóa nó. Điều này hữu ích khi di chuyển một bản trình bày và các tệp liên kết sang vị trí khác. Nó riêng biệt với [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) của một siêu liên kết cá nhân: việc thay đổi cơ sở không ghi lại lại các địa chỉ liên kết đã lưu hoặc thay đổi đích tuyệt đối.

Ví dụ yêu cầu một bản trình bày chứa cả liên kết tương đối, chẳng hạn `target.html`, và liên kết tuyệt đối, chẳng hạn `https://example.org/absolute.html`. Nó đọc cơ sở hiện có, gán một địa chỉ cơ sở mới, và lưu rồi mở lại bản trình bày để kiểm tra giá trị. Sau đó nó xóa cơ sở bằng một chuỗi trống và xác minh giá trị trống trong một tệp đã lưu riêng. Thay địa chỉ cơ sở mẫu bằng vị trí của các tệp liên kết của bạn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

Hai thông báo xác minh nên in ra `True`. Xóa cơ sở vẫn giữ nguyên các địa chỉ siêu liên kết cá nhân.

Một liên kết tương đối tới `target.pptx` mở `old/target.pptx` khi cơ sở chỉ tới thư mục `old`. Sau khi thay đổi cơ sở thành thư mục `new`, lưu và mở lại bản trình bày, cùng một liên kết sẽ mở `new/target.pptx`. Một liên kết tuyệt đối vẫn mở cùng tệp. Hãy thử các liên kết tương đối trong PowerPoint trước và sau khi di chuyển bản trình bày hoặc thay đổi cơ sở của nó.

## **Thêm Thuộc tính Tùy chỉnh cho Bản trình bày**

Các thuộc tính tùy chỉnh lưu trữ siêu dữ liệu không có trường có sẵn tương ứng. Phương thức [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) cho phép bạn gán giá trị theo tên thuộc tính. Ví dụ này tạo một bản trình bày, thêm hai giá trị văn bản và một giá trị phiên bản nguyên (sử dụng `jpype.JInt` để truyền một số nguyên Java), và lưu bản trình bày bằng [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Gán giá trị cho một tên đã tồn tại sẽ thay thế giá trị của thuộc tính đó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập và Sửa đổi Thuộc tính Tùy chỉnh**

Ví dụ này mở một bản trình bày chứa các thuộc tính tùy chỉnh và sử dụng [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) để lặp qua chúng. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) nhận một chỉ số bắt đầu từ 0 và trả về tên được sử dụng bởi [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item). Ví dụ in mỗi tên và giá trị gốc, thay thế mọi giá trị bằng một chuỗi có số thứ tự bất kể kiểu dữ liệu gốc, và lưu các thay đổi. Nếu không có thuộc tính tùy chỉnh nào, vòng lặp sẽ không thực hiện thay đổi nào.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ví dụ Trực tiếp**

Thử ứng dụng trực tuyến [**Xem & Chỉnh sửa Siêu dữ liệu PowerPoint**](https://products.aspose.app/slides/metadata) để xem cách làm việc với thuộc tính tài liệu bằng API Aspose.Slides:

[![Xem & Chỉnh sửa Siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xoá một thuộc tính có sẵn khỏi bản trình bày?**

Các thuộc tính có sẵn là một phần không thể thiếu của bản trình bày và không thể bị xoá hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện có sẽ bị ghi đè bởi giá trị mới. Bạn không cần phải xoá hoặc kiểm tra thuộc tính trước, vì Aspose.Slides tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình bày mà không tải toàn bộ bản trình bày không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) sau đó [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu đã lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) . Xem [Xây dựng Kiểm kê Bản trình bày Nhẹ](/slides/vi/python-java/examine-presentation/) để có ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của bản trình bày đã mã hóa mà không có mật khẩu mở không?**

Có. Bản trình bày phải đã được mã hóa sau khi gọi [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) với `False`, và phải được tải sau khi gọi [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) với `True`.

**Tôi có thể cập nhật một tệp PPTX đã mã hóa ở chế độ chỉ tải thuộc tính tài liệu không?**

Không. Dữ liệu thuộc tính công khai và đã mã hóa phải duy trì tính nhất quán, do đó việc cập nhật một tệp PPTX đã mã hóa yêu cầu tải toàn bộ bản trình bày với mật khẩu mở đúng.