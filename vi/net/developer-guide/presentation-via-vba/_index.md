---
title: Quản lý các dự án VBA trong bản trình bày trên .NET
linktitle: Bản trình bày qua VBA
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình bày PowerPoint và OpenDocument qua VBA với Aspose.Slides cho .NET để tối ưu quy trình làm việc của bạn."
---
## **Giới thiệu**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 
Khi bạn chuyển đổi một bản trình bày chứa macro sang định dạng tệp khác (PDF, HTML, v.v.), Aspose.Slides sẽ bỏ qua tất cả các macro (macro không được chuyển sang tệp kết quả).

Khi bạn thêm macro vào bản trình bày hoặc lưu lại một bản trình bày chứa macro, Aspose.Slides chỉ ghi lại các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong bản trình bày.
{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/vbaproject/) cho phép bạn tạo các dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng giao diện [IVbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/ivbaproject/) để quản lý VBA được nhúng trong một bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) class.
1. Sử dụng constructor [VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) để thêm một dự án VBA mới.
1. Thêm một mô-đun vào VbaProject.
1. Đặt mã nguồn của mô-đun.
1. Thêm các tham chiếu tới <stdole>.
1. Thêm các tham chiếu tới **Microsoft Office**.
1. Liên kết các tham chiếu với dự án VBA.
1. Lưu bản trình bày.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Tạo một thể hiện của lớp Presentation
using (Presentation presentation = new Presentation())
{
    // Tạo một dự án VBA mới
    presentation.VbaProject = new VbaProject();

    // Thêm một mô-đun rỗng vào dự án VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Đặt mã nguồn của mô-đun
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

    // Lưu bản trình bày
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 
Bạn có thể muốn xem **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để xóa macro khỏi tài liệu PowerPoint, Excel và Word. 
{{% /alert %}} 

## **Xóa Macro VBA**
Sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/vbaproject/) trong lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) , bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải bản trình bày chứa macro.
1. Truy cập mô-đun Macro và xóa nó.
1. Lưu bản trình bày đã sửa đổi.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Tải bản trình bày chứa macro
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Truy cập mô-đun Vba và xóa nó
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Lưu bản trình bày
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Trích xuất Macro VBA**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải bản trình bày chứa macro.
2. Kiểm tra xem bản trình bày có chứa dự án VBA hay không.
3. Duyệt qua tất cả các mô-đun trong Dự án VBA để xem các macro.

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Tải bản trình bày chứa macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Kiểm tra xem Presentation có chứa dự án VBA không
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

Sử dụng thuộc tính [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) , bạn có thể xác định xem các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và tải một bản trình bày chứa macro.
2. Kiểm tra xem bản trình bày có chứa một [VBA project](https://reference.aspose.com/slides/vi/net/aspose.slides.vba/vbaproject/) hay không.
3. Kiểm tra xem dự án VBA có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó hay không.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Kiểm tra xem bản trình bày có chứa dự án VBA không.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### What happens to macros if I save the presentation as PPTX?

Macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ macro, chọn PPTM, PPSM hoặc POTM.

### Can Aspose.Slides run macros inside a presentation to, for example, refresh data?

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện trong PowerPoint với các cài đặt bảo mật thích hợp.

### Is working with ActiveX controls linked to VBA code supported?

Có, bạn có thể truy cập các [ActiveX controls](/slides/vi/net/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi macro tương tác với ActiveX.