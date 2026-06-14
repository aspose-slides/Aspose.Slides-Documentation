---
title: Quản lý dự án VBA trong bản trình bày bằng C++
linktitle: Bản trình bày qua VBA
type: docs
weight: 250
url: /vi/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình bày PowerPoint và OpenDocument qua VBA với Aspose.Slides cho C++ để tối ưu hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

Khi bạn chuyển đổi một bản trình bày có chứa macro sang định dạng tệp khác (PDF, HTML, v.v.), Aspose.Slides sẽ bỏ qua tất cả các macro (macro sẽ không được chuyển sang tệp kết quả).

Khi bạn thêm macro vào một bản trình bày hoặc lưu lại một bản trình bày có chứa macro, Aspose.Slides chỉ ghi lại các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong bản trình bày.

{{% /alert %}}

## **Thêm VBA Macro**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.vba.vba_project) để cho phép bạn tạo dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng giao diện [IVbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.vba.i_vba_project/) để quản lý VBA nhúng trong một bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
1. Sử dụng constructor của [VbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) để thêm một dự án VBA mới.
1. Thêm một mô-đun vào VbaProject.
1. Đặt mã nguồn cho mô-đun.
1. Thêm tham chiếu tới <stdole>.
1. Thêm tham chiếu tới **Microsoft Office**.
1. Liên kết các tham chiếu với dự án VBA.
1. Lưu bản trình bày.

Đoạn mã C++ này cho bạn thấy cách thêm một VBA macro từ đầu vào bản trình bày:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Tạo một thể hiện của lớp presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Tạo một dự án VBA mới
presentation->set_VbaProject(MakeObject<VbaProject>());

// Thêm một mô-đun trống vào dự án VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Đặt mã nguồn cho mô-đun
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Tạo một tham chiếu tới <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Tạo một tham chiếu tới Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Thêm các tham chiếu vào dự án VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Lưu bản trình bày
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

Bạn có thể muốn thử **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để loại bỏ macro khỏi tài liệu PowerPoint, Excel và Word. 

{{% /alert %}} 

## **Xóa VBA Macro**

Sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) trong lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation), bạn có thể xóa một VBA macro.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình bày chứa macro.
1. Truy cập mô-đun Macro và xóa nó.
1. Lưu bản trình bày đã sửa đổi.

Đoạn mã C++ này cho bạn thấy cách xóa một VBA macro:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Tải bản trình bày chứa macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Truy cập mô-đun Vba và xóa nó 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Lưu bản trình bày
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Trích xuất VBA Macro**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình bày chứa macro.
2. Kiểm tra xem bản trình bày có chứa VBA Project không.
3. Duyệt qua tất cả các mô-đun trong VBA Project để xem các macro.

Đoạn mã C++ này cho bạn thấy cách trích xuất VBA macro từ một bản trình bày có chứa macro:

```c++

	// Đường dẫn tới thư mục tài liệu.
	const String templatePath = u"../templates/VBA.pptm";

	// Tải bản trình bày chứa macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Kiểm tra xem Presentation có chứa VBA Project hay không
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Kiểm tra xem VBA Project có được bảo vệ bằng mật khẩu không**

Sử dụng thuộc tính [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), bạn có thể xác định xem các thuộc tính của dự án có được bảo mật bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và tải một bản trình bày chứa macro.
2. Kiểm tra xem bản trình bày có chứa một [VBA project](https://reference.aspose.com/slides/vi/cpp/aspose.slides.vba/vbaproject/) không.
3. Kiểm tra xem VBA project có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Kiểm tra xem bản trình bày có chứa dự án VBA hay không.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Điều gì xảy ra với macro nếu tôi lưu bản trình bày dưới dạng PPTX?**

Macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ macro, chọn PPTM, PPSM hoặc POTM.

**Aspose.Slides có thể chạy macro trong bản trình bày để, ví dụ, làm mới dữ liệu không?**

Không. Thư viện này không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện trong PowerPoint với cài đặt bảo mật phù hợp.

**Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?**

Có, bạn có thể truy cập các [ActiveX controls](/slides/vi/cpp/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi macro tương tác với ActiveX.