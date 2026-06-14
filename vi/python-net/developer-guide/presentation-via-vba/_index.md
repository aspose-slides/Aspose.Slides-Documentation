---
title: Quản lý dự án VBA trong bản trình bày bằng Python
linktitle: Bản trình bày qua VBA
type: docs
weight: 250
url: /vi/python-net/presentation-via-vba/
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
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình bày PowerPoint và OpenDocument thông qua VBA với Aspose.Slides cho Python qua .NET để tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Bài viết này xem xét các khả năng chính của Aspose.Slides cho Python thông qua .NET để làm việc với macro trong các bản trình bày PowerPoint. Thư viện cung cấp các công cụ tiện lợi để thêm, xóa và trích xuất macro, cho phép bạn tự động hóa việc tạo và chỉnh sửa bản trình bày.

Với Aspose.Slides, bạn có thể:

- Tăng tốc phát triển bản trình bày — tự động hoá các công việc thường lệ giảm thời gian chuẩn bị tài liệu.
- Đảm bảo tính linh hoạt — khả năng quản lý macro cho phép bạn tùy chỉnh bản trình bày cho các nhiệm vụ và kịch bản cụ thể.
- Tích hợp dữ liệu — việc tích hợp đơn giản với các nguồn dữ liệu bên ngoài giúp giữ nội dung slide luôn cập nhật.
- Đơn giản hoá bảo trì — quản lý macro tập trung giúp dễ dàng áp dụng các thay đổi và cập nhật bản trình bày.

Bài viết tiếp tục trình bày các ví dụ thực tế về cách sử dụng Aspose.Slides để làm việc hiệu quả với macro trong PowerPoint.

Không gian tên [aspose.slides.vba](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/) cung cấp các lớp để làm việc với macro và mã VBA.

{{% alert title="Lưu ý" color="warning" %}}
Khi bạn chuyển đổi một bản trình bày chứa macro sang định dạng khác (PDF, HTML, v.v.), Aspose.Slides sẽ bỏ qua các macro — chúng không được chuyển sang tệp đầu ra.

Khi bạn thêm macro vào bản trình bày hoặc lưu lại một bản trình bày có chứa macro, Aspose.Slides sẽ ghi các byte macro nguyên trạng.

Aspose.Slides **không bao giờ** thực thi macro trong bản trình bày.
{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/vbaproject/) để tạo dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Sử dụng hàm khởi tạo [VbaProject](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/vbaproject/#constructors) để thêm một dự án VBA mới.
3. Thêm một mô-đun vào dự án VBA.
4. Đặt mã nguồn của mô-đun.
5. Thêm một tham chiếu tới `<stdole>`.
6. Thêm một tham chiếu tới **Microsoft Office**.
7. Liên kết các tham chiếu với dự án VBA.
8. Lưu bản trình bày.

Mã Python dưới đây cho thấy cách thêm một macro VBA từ đầu vào bản trình bày:

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    # Tạo một dự án VBA mới.
    presentation.vba_project = slides.vba.VbaProject()

    # Thêm một mô-đun trống vào dự án VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Đặt mã nguồn cho mô-đun.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Tạo một tham chiếu tới <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Tạo một tham chiếu tới Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Thêm các tham chiếu vào dự án VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Lưu bản trình bày.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Bạn có thể muốn thử công cụ **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí để loại bỏ macro khỏi tài liệu PowerPoint, Excel và Word.
{{% /alert %}}

## **Xóa Macro VBA**

Bằng cách sử dụng thuộc tính [vba_project](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/vba_project/) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình bày chứa macro.
2. Truy cập mô-đun macro và xóa nó.
3. Lưu bản trình bày đã sửa đổi.

Mã Python dưới đây cho thấy cách xóa một macro VBA:

```python
import aspose.slides as slides

# Tải bản trình bày chứa macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Truy cập mô-đun VBA.
    vba_module = presentation.vba_project.modules[0]

    # Xóa mô-đun VBA.
    presentation.vba_project.modules.remove(vba_module)

    # Lưu bản trình bày.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Trích xuất Macro VBA**

Bằng cách sử dụng thuộc tính `modules` trong lớp [VbaProject](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/vbaproject/), bạn có thể truy cập tất cả các mô-đun của một dự án VBA. Lớp [VbaModule](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/vbamodule/) có thể được dùng để trích xuất các thuộc tính của mô-đun như tên và mã.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình bày chứa macro.
2. Kiểm tra xem bản trình bày có chứa dự án VBA hay không.
3. Duyệt qua tất cả các mô-đun trong dự án VBA để xem các macro.

Mã Python dưới đây cho thấy cách trích xuất macro VBA từ một bản trình bày:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Kiểm tra xem bản trình bày có chứa dự án VBA hay không.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu hay không**

Bằng cách sử dụng thuộc tính [VbaProject.is_password_protected](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/vbaproject/is_password_protected/), bạn có thể xác định xem các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải một bản trình bày chứa macro.
2. Kiểm tra xem bản trình bày có chứa [dự án VBA](https://reference.aspose.com/slides/vi/python-net/aspose.slides.vba/vbaproject/) hay không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó hay không.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Kiểm tra xem bản trình bày có chứa dự án VBA hay không.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**Đi gì sẽ xảy ra với macro nếu tôi lưu bản trình bày dưới dạng PPTX?**

Macro sẽ bị loại bỏ vì PPTX không hỗ trợ VBA. Để giữ macro, chọn PPTM, PPSM hoặc POTM.

**Aspose.Slides có thể chạy macro trong bản trình bày để, ví dụ, làm mới dữ liệu không?**

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện trong PowerPoint với các cài đặt bảo mật phù hợp.

**Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?**

Có, bạn có thể truy cập các [điều khiển ActiveX](/slides/vi/python-net/activex/), chỉnh sửa thuộc tính của chúng và xóa chúng. Điều này hữu ích khi macro tương tác với ActiveX.