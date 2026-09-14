---
title: Quản lý thuộc tính bản trình chiếu trong Python
linktitle: Thuộc tính Bản trình chiếu
type: docs
weight: 70
url: /vi/python-java/presentation-properties/
keywords:
- Thuộc tính PowerPoint
- Thuộc tính bản trình chiếu
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
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các thuộc tính bản trình chiếu trong Aspose.Slides cho Python qua Java và tối ưu hoá việc tìm kiếm, thương hiệu và quy trình làm việc trong các tệp PowerPoint và OpenDocument của bạn."
---
## **Giới thiệu**

Aspose.Slides hỗ trợ hai loại thuộc tính tài liệu: **Built-in** và **Custom**. Cả hai loại thuộc tính này đều có thể được truy cập và quản lý dễ dàng bằng API của Aspose.Slides.

Aspose.Slides cho phép bạn làm việc với các thuộc tính tài liệu của bản trình chiếu thông qua lớp [DocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/) . Một thể hiện của lớp này được trả về bởi [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDocumentProperties) . Các ví dụ sau cho thấy cách đọc, sửa đổi và quản lý các thuộc tính này.

{{% alert color="info" title="Lưu ý" %}}
Xin lưu ý rằng các trường **Application** và **AppVersion** không thể được sửa đổi. Aspose.Slides ghi lại chúng mỗi khi lưu, vì vậy một bản trình chiếu đã lưu luôn báo cáo "Aspose.Slides for Java" và phiên bản của thư viện đã tạo ra nó. Bất kỳ giá trị nào được truyền vào [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#setNameOfApplication) đều bị bỏ qua khi bản trình chiếu được ghi.
{{% /alert %}}

## **Thuộc tính tài liệu trong PowerPoint**

Microsoft PowerPoint 2007 cho phép bạn quản lý các thuộc tính tài liệu của tệp bản trình chiếu. Nhấp vào biểu tượng Office và chọn **Prepare | Properties | Advanced Properties**, như hình dưới:

|**Chọn mục menu Advanced Properties**|
| :- |
|![Thuộc tính tài liệu PowerPoint](https://i.imgur.com/ZrmuCD6.jpg)|

Sau khi bạn chọn **Advanced Properties**, một hộp thoại xuất hiện, cho phép bạn quản lý các thuộc tính tài liệu của tệp PowerPoint:

|**Hộp thoại Thuộc tính**|
| :- |
|![Thuộc tính tài liệu PowerPoint](https://i.imgur.com/LibmdQd.jpg)|

Hộp thoại **Properties Dialog** chứa các tab như **General**, **Summary**, **Statistics**, **Contents**, và **Custom**. Các tab này cho phép bạn cấu hình các loại thông tin khác nhau về tệp PowerPoint. Sử dụng tab **Custom** để quản lý các thuộc tính tùy chỉnh.

## **Làm việc với Thuộc tính Tài liệu bằng Aspose.Slides cho Python qua Java**

Như đã mô tả ở trên, Aspose.Slides cho Python qua Java hỗ trợ cả các thuộc tính **Built-in** và **Custom**. Lớp [DocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/) đại diện cho các thuộc tính tài liệu liên kết với một tệp bản trình chiếu.

Sử dụng [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDocumentProperties) để truy cập các thuộc tính này như mô tả bên dưới.

## **Đọc các thuộc tính công khai từ một bản trình chiếu đã mã hoá**

Một mật khẩu mở thường bảo vệ cả nội dung bản trình chiếu và các thuộc tính tài liệu. Khi bản trình chiếu được mã hoá bằng cách truyền `false` vào [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , các thuộc tính tài liệu vẫn công khai. Ứng dụng sau đó có thể truyền `true` vào [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) và đọc siêu dữ liệu công khai mà không cần cung cấp mật khẩu mở.

Tùy chọn chỉ tải tài liệu‑properties kiểm soát những gì Aspose.Slides tải; nó không giải mã bất kỳ thứ gì. Nếu các thuộc tính đã được bao gồm trong quá trình mã hoá, việc tải chúng mà không có mật khẩu sẽ thất bại. Nếu bản trình chiếu không được mã hoá, tùy chọn này sẽ bị bỏ qua và toàn bộ bản trình chiếu sẽ được tải.

Ví dụ sau xác minh chế độ tải qua [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) và sau đó đọc các thuộc tính tích hợp qua [Presentation.getDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDocumentProperties) :

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

Trong chế độ này, nội dung slide không được tải. Các slide, master, layout, shape, media và các đối tượng trình chiếu khác sẽ không khả dụng. Ứng dụng nên luôn kiểm tra [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/vi/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) trước khi thực hiện thao tác yêu cầu mô hình đối tượng bản trình chiếu đầy đủ.

{{% alert color="warning" title="Cảnh báo" %}}
Siêu dữ liệu công khai có thể tiết lộ tên tác giả, tiêu đề, chủ đề, từ khóa, thông tin công ty, chú thích và các giá trị tùy chỉnh. Hãy mã hoá các thuộc tính nhạy cảm cùng với bản trình chiếu. Chỉ để chúng công khai khi hệ thống lập chỉ mục, phân lớp, tìm kiếm hoặc quản lý tài liệu có yêu cầu cụ thể truy cập mà không cần mật khẩu.
{{% /alert %}}

## **Cập nhật thuộc tính của một bản trình chiếu đã mã hoá**

Đối với tệp PPTX đã mã hoá, một bản trình chiếu được tải ở chế độ chỉ‑tài‑liệu‑công‑khai nhằm mục đích đọc siêu dữ liệu công khai. Aspose.Slides không thể lưu các thuộc tính đã thay đổi từ đối tượng chỉ‑có‑siêu‑dữ‑liệu vì các thuộc tính công khai phải đồng nhất với dữ liệu tương ứng bên trong bản trình chiếu đã mã hoá. Do đó, việc cập nhật chúng đòi hỏi mật khẩu mở chính xác và một lần tải đầy đủ.

Ví dụ sau mở bản trình chiếu bằng [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword) , cập nhật các thuộc tính tích hợp công khai, và lưu kết quả. Sau đó sử dụng [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#isEncrypted) để xác minh rằng việc mã hoá vẫn được giữ và mở lại siêu dữ liệu công khai mà không cần mật khẩu để kiểm tra các giá trị mới:

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

Nếu một ứng dụng không được phép giải mã hoặc tải nội dung bản trình chiếu, nó phải xem các thuộc tính công khai của tệp PPTX đã mã hoá như là chỉ‑đọc.

## **Truy cập các thuộc tính tích hợp**

Các thuộc tính tích hợp được [DocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/) cung cấp bao gồm: **Creator** (Author), **Description**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject**, và **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Khởi tạo lớp Presentation đại diện cho bản trình chiếu
presentation = Presentation("Presentation.pptx")
try:
    # Tạo tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    properties = presentation.getDocumentProperties()

    # Hiển thị các thuộc tính tích hợp
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Sửa đổi các thuộc tính tích hợp**

Việc sửa đổi các thuộc tính tích hợp đơn giản như việc truy cập chúng. Sử dụng setter tương ứng để gán giá trị mới. Ví dụ sau sửa đổi các thuộc tính tài liệu tích hợp bằng Aspose.Slides cho Python qua Java.

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Tạo tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    properties = presentation.getDocumentProperties()

    # Đặt các thuộc tính tích hợp
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Lưu bản trình chiếu của bạn vào một tệp
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ví dụ này sửa đổi các thuộc tính tích hợp của bản trình chiếu và có thể xem như hình dưới:

|**Thuộc tính tài liệu tích hợp sau khi sửa đổi**|
| :- |
|![Thuộc tính tài liệu PowerPoint](https://i.imgur.com/zz1N9de.jpg)|

## **Thêm các Thuộc tính Tài liệu Tùy chỉnh**

Aspose.Slides cho Python qua Java cũng cho phép các nhà phát triển thêm các thuộc tính tài liệu tùy chỉnh vào bản trình chiếu. Ví dụ dưới đây thêm ba thuộc tính tùy chỉnh, sau đó tra cứu tên lưu tại chỉ mục 2 và xóa thuộc tính đó, vì vậy bản trình chiếu đã lưu giữ lại hai thuộc tính. Các thuộc tính tùy chỉnh được sắp xếp theo thứ tự chữ cái, không phải theo thứ tự thêm vào.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Lấy các Thuộc tính Tài liệu
    properties = presentation.getDocumentProperties()

    # Thêm các thuộc tính Tùy chỉnh
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Lấy tên thuộc tính tại chỉ mục nhất định
    property_name = properties.getCustomPropertyName(2)

    # Xóa thuộc tính đã chọn
    properties.removeCustomProperty(property_name)

    # Lưu bản trình chiếu
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Thuộc tính Tài liệu Tùy chỉnh Đã Thêm**|
| :- |
|![Thuộc tính tài liệu PowerPoint](https://i.imgur.com/HdKcxI9.png)|

## **Truy cập và Sửa đổi Các Thuộc tính Tùy chỉnh**

Aspose.Slides cho Python qua Java cũng cho phép các nhà phát triển truy cập các giá trị của thuộc tính tùy chỉnh. Ví dụ dưới đây cho thấy cách truy cập và sửa đổi tất cả các thuộc tính tùy chỉnh trong một bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Tạo tham chiếu tới đối tượng DocumentProperties liên kết với Presentation
    properties = presentation.getDocumentProperties()

    # Truy cập và sửa đổi các thuộc tính tùy chỉnh
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Hiển thị tên và giá trị của các thuộc tính tùy chỉnh
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Sửa đổi giá trị của các thuộc tính tùy chỉnh
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Lưu bản trình chiếu của bạn vào một tệp
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ví dụ này sửa đổi các thuộc tính tùy chỉnh của bản trình chiếu [PPTX](https://docs.fileformat.com/presentation/pptx/). Các hình dưới đây hiển thị các thuộc tính tùy chỉnh của bản trình chiếu trước và sau khi sửa đổi:

|**Thuộc tính tùy chỉnh trước khi sửa đổi**|
| :- |
|![Thuộc tính tài liệu PowerPoint](https://i.imgur.com/Ze7YHvi.jpg)|

|**Thuộc tính tùy chỉnh sau khi sửa đổi**|
| :- |
|![Thuộc tính tài liệu PowerPoint](https://i.imgur.com/Tofu0CL.jpg)|

## **Thuộc tính Tài liệu Nâng cao**

{{% alert color="info" title="Lưu ý" %}}
Các phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), và [writeBindedPresentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) đã được thêm vào [PresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/) , và hành vi của phương thức [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#setLastSavedTime) đã thay đổi.
{{% /alert %}}

Hai phương thức mới [readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) và [updateDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) đã được thêm vào lớp [PresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/) . Chúng cung cấp cách truy cập nhanh vào các thuộc tính tài liệu và cho phép bạn thay đổi và cập nhật các thuộc tính mà không cần tải toàn bộ bản trình chiếu.

Quy trình thường gặp của việc tải các thuộc tính, thay đổi giá trị và cập nhật tài liệu có thể được thực hiện như sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Đọc thông tin bản trình chiếu
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Lấy các thuộc tính hiện tại
properties = presentation_info.readDocumentProperties()

# Đặt giá trị mới cho các trường Tác giả và Tiêu đề
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Cập nhật bản trình chiếu với các giá trị mới
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Có một cách khác để sử dụng các thuộc tính của một bản trình chiếu cụ thể làm mẫu để cập nhật thuộc tính trong các bản trình chiếu khác:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Một mẫu mới có thể được tạo từ đầu và sau đó dùng để cập nhật nhiều bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp phương thức [PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#setLanguageId) để cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho tài liệu PowerPoint. Ngôn ngữ kiểm tra chính tả là ngôn ngữ mà trình kiểm tra chính tả và ngữ pháp của bản trình chiếu sẽ sử dụng.

Mã Python này cho thấy cách đặt ngôn ngữ kiểm tra chính tả cho một bản PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # đặt Id của ngôn ngữ kiểm tra chính tả

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Đặt Ngôn ngữ Mặc định**

Mã Python này cho thấy cách đặt ngôn ngữ mặc định cho toàn bộ bản trình chiếu PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Thêm một hình chữ nhật có văn bản
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Kiểm tra ngôn ngữ của phần đầu tiên
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Ví dụ Trực tiếp**

Hãy thử ứng dụng trực tuyến [**Aspose.Slides Metadata**](https://products.aspose.app/slides/vi/metadata) để xem cách làm việc với các thuộc tính tài liệu qua API của Aspose.Slides:

[![Xem & Chỉnh sửa siêu dữ liệu PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/vi/metadata)

## **Câu hỏi thường gặp**

**Làm thế nào để xóa một thuộc tính tích hợp khỏi bản trình chiếu?**

Các thuộc tính tích hợp là một phần không thể tách rời của bản trình chiếu và không thể bị xóa hoàn toàn. Tuy nhiên, bạn có thể thay đổi giá trị của chúng hoặc đặt chúng thành rỗng nếu thuộc tính cụ thể cho phép.

**Điều gì sẽ xảy ra nếu tôi thêm một thuộc tính tùy chỉnh đã tồn tại?**

Nếu bạn thêm một thuộc tính tùy chỉnh đã tồn tại, giá trị hiện tại của nó sẽ bị ghi đè bằng giá trị mới. Bạn không cần phải xóa hoặc kiểm tra thuộc tính trước, vì Aspose.Slides sẽ tự động cập nhật giá trị của thuộc tính.

**Tôi có thể truy cập các thuộc tính bản trình chiếu mà không tải toàn bộ bản trình chiếu không?**

Có. Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) và sau đó [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu được lưu mà không cần tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) . Xem [Build a Lightweight Presentation Inventory](/slides/vi/python-java/examine-presentation/) để biết ví dụ báo cáo đầy đủ và các hạn chế theo định dạng.

**Tôi có thể đọc các thuộc tính công khai của một bản trình chiếu đã mã hoá mà không có mật khẩu mở không?**

Có. Việc mã hoá thuộc tính tài liệu phải đã bị tắt trước khi bản trình chiếu được mã hoá, và bản trình chiếu phải được tải ở chế độ chỉ‑tài‑liệu‑công‑khai.

**Tôi có thể cập nhật một tệp PPTX đã mã hoá ở chế độ chỉ‑tài‑liệu‑công‑khai không?**

Không. Dữ liệu thuộc tính công khai và đã mã hoá phải đồng nhất, do đó việc cập nhật tệp PPTX đã mã hoá yêu cầu tải đầy đủ bản trình chiếu với mật khẩu mở đúng.