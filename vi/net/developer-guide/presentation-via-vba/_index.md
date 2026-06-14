---
title: Quản lý Dự án VBA trong Bản trình chiếu với .NET
linktitle: Bản trình chiếu qua VBA
type: docs
weight: 250
url: /vi/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình chiếu PowerPoint và OpenDocument qua VBA bằng Aspose.Slides cho .NET để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

Không gian tên [Aspose.Slides.Vba](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/) chứa các lớp và giao diện để làm việc với macro và mã VBA.

{{% alert title="Note" color="warning" %}} 

Khi bạn chuyển đổi một bản trình chiếu có chứa macro sang định dạng tệp khác (PDF, HTML, v.v.), Aspose.Slides sẽ bỏ qua tất cả các macro (macro sẽ không được chuyển sang tệp kết quả).

Khi bạn thêm macro vào bản trình chiếu hoặc lưu lại một bản trình chiếu có chứa macro, Aspose.Slides chỉ ghi các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong một bản trình chiếu.

{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/vbaproject/) để cho phép bạn tạo các dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng giao diện [IVbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/ivbaproject/) để quản lý VBA nhúng trong bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).
2. Sử dụng hàm khởi tạo [VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) để thêm một dự án VBA mới.
3. Thêm một mô-đun vào VbaProject.
4. Đặt mã nguồn của mô-đun.
5. Thêm tham chiếu tới <stdole>.
6. Thêm tham chiếu tới **Microsoft Office**.
7. Liên kết các tham chiếu với dự án VBA.
8. Lưu bản trình chiếu.

Đoạn mã C# sau đây cho bạn thấy cách thêm một macro VBA từ đầu vào bản trình chiếu:

```c#
    // Tạo một thể hiện của lớp Presentation
using (Presentation presentation = new Presentation())
{
    // Tạo một dự án VBA mới
    presentation.VbaProject = new VbaProject();

    // Thêm một mô-đun rỗng vào dự án VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Đặt mã nguồn cho mô-đun
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Tạo một tham chiếu tới <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Tạo một tham chiếu tới Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Thêm các tham chiếu vào dự án VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Lưu bản trình chiếu
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Bạn có thể muốn xem **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để loại bỏ macro khỏi các tài liệu PowerPoint, Excel và Word.

{{% /alert %}} 

## **Xóa Macro VBA**

Bằng cách sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/vbaproject/) của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải bản trình chiếu có chứa macro.
2. Truy cập mô-đun Macro và xóa nó.
3. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã C# sau đây cho bạn thấy cách xóa một macro VBA:

```c#
    // Tải bản trình chiếu có chứa macro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Truy cập mô-đun Vba và xóa nó 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Lưu bản trình chiếu
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Trích xuất Macro VBA**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải bản trình chiếu có chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một Dự án VBA hay không.
3. Lặp qua tất cả các mô-đun trong Dự án VBA để xem các macro.

Đoạn mã C# sau đây cho bạn thấy cách trích xuất macro VBA từ một bản trình chiếu có chứa macro:

```c#
    // Tải bản trình chiếu có chứa macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Kiểm tra xem bản trình chiếu có chứa dự án VBA không
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Kiểm tra xem Dự án VBA có được bảo vệ bằng mật khẩu hay không**

Bằng cách sử dụng thuộc tính [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), bạn có thể xác định xem các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải một bản trình chiếu có chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa một [dự án VBA](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/vbaproject/) hay không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó hay không.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Kiểm tra xem bản trình chiếu có chứa dự án VBA không.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **Câu hỏi thường gặp**

**Đi gì sẽ xảy ra với macro nếu tôi lưu bản trình chiếu dưới dạng PPTX?**

Macro sẽ bị loại bỏ vì PPTX không hỗ trợ VBA. Để giữ macro, hãy chọn PPTM, PPSM hoặc POTM.

**Aspose.Slides có thể chạy macro trong bản trình chiếu để, ví dụ, làm mới dữ liệu không?**

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện trong PowerPoint với các cài đặt bảo mật phù hợp.

**Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?**

Có, bạn có thể truy cập các [điều khiển ActiveX](/slides/vi/net/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi macro tương tác với ActiveX.