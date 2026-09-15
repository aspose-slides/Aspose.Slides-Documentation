---
title: Quản lý Dự án VBA trong Bản trình chiếu bằng Python
linktitle: Bản trình chiếu qua VBA
type: docs
weight: 250
url: /vi/python-java/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- thêm macro
- xóa macro
- trích xuất macro
- thêm VBA
- xóa VBA
- trích xuất VBA
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình chiếu PowerPoint và OpenDocument qua VBA với Aspose.Slides cho Python qua Java để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Aspose.Slides cung cấp các lớp và giao diện để làm việc với macro và mã VBA.

{{% alert title="Cảnh báo" color="warning" %}} 

Khi bạn chuyển đổi một bản trình chiếu chứa macro sang định dạng tệp khác (PDF, HTML, v.v.), Aspose.Slides sẽ bỏ qua tất cả các macro (macro sẽ không được đưa vào tệp kết quả).

Khi bạn thêm macro vào một bản trình chiếu hoặc lưu lại một bản trình chiếu chứa macro, Aspose.Slides chỉ ghi các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong một bản trình chiếu.

{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/vbaproject/) cho phép bạn tạo các dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng lớp [VbaProject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/vbaproject/) để quản lý VBA được nhúng trong một bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Sử dụng hàm khởi tạo [VbaProject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/vbaproject/#vbaproject) để thêm một dự án VBA mới.
1. Thêm một mô-đun vào dự án VBA.
1. Đặt mã nguồn cho mô-đun.
1. Thêm tham chiếu tới `stdole`.
1. Thêm tham chiếu tới **Microsoft Office**.
1. Liên kết các tham chiếu với dự án VBA.
1. Lưu bản trình chiếu.

Đoạn mã Python này cho bạn thấy cách thêm một macro VBA từ đầu vào một bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Tạo một dự án VBA mới.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Thêm một mô-đun trống và đặt mã nguồn của nó.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Tạo các tham chiếu tới stdole và Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Thêm các tham chiếu vào dự án VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Lưu bản trình chiếu.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Ghi chú" %}} 

Bạn có thể muốn xem **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), là một ứng dụng web miễn phí dùng để loại bỏ macro khỏi các tài liệu PowerPoint, Excel và Word. 

{{% /alert %}} 

## **Xóa Macro VBA**

Sử dụng phương thức [getVbaProject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getvbaproject) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa macro.
1. Truy cập mô-đun macro và xóa nó.
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Python này cho bạn thấy cách xóa một macro VBA:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Tải bản trình chiếu chứa macro.
presentation = Presentation("VBA.pptm")
try:
    # Truy cập mô-đun VBA và xóa nó.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Lưu bản trình chiếu.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Trích xuất Macro VBA**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một VBA Project hay không.
3. Duyệt qua tất cả các mô-đun trong VBA Project để xem các macro.

Đoạn mã Python này cho bạn thấy cách trích xuất macro VBA từ một bản trình chiếu chứa macro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Tải bản trình chiếu chứa macro.
presentation = Presentation("VBA.pptm")
try:
    # Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Kiểm tra xem Dự án VBA có được bảo vệ bằng mật khẩu hay không**

Sử dụng phương thức [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/vi/python-java/aspose.slides/vbaproject/#ispasswordprotected), bạn có thể xác định xem thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải một bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một [VBA project](https://reference.aspose.com/slides/vi/python-java/aspose.slides/vbaproject/) hay không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Điều gì xảy ra với macro nếu tôi lưu bản trình chiếu dưới dạng PPTX?**

Macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ macro, chọn PPTM, PPSM hoặc POTM.

**Aspose.Slides có thể chạy macro trong một bản trình chiếu để, ví dụ, làm mới dữ liệu không?**

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể xảy ra trong PowerPoint với các cài đặt bảo mật phù hợp.

**Có hỗ trợ làm việc với điều khiển ActiveX được liên kết với mã VBA không?**

Có, bạn có thể truy cập các [ActiveX controls](/slides/vi/python-java/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi các macro tương tác với ActiveX.