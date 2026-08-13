---
title: Quản lý dự án VBA trong các bản trình chiếu bằng C++
linktitle: Bản trình chiếu qua VBA
type: docs
weight: 250
url: /vi/cpp/presentation-via-vba/
keywords:
- macro
- VBA
- VBA macro
- thêm macro
- xóa macro
- trích xuất macro
- thêm VBA
- xóa VBA
- trích xuất VBA
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá cách tạo và thao tác các bản trình chiếu PowerPoint và OpenDocument thông qua VBA với Aspose.Slides cho C++ để tối ưu hóa quy trình làm việc của bạn."
---
## **Giới thiệu**

Tên không gian [Aspose.Slides.Vba](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.vba/) chứa các lớp và giao diện để làm việc với macro và mã VBA.

{{% alert title="Note" color="warning" %}} 
Khi bạn chuyển đổi một bản trình chiếu chứa macro sang định dạng file khác (PDF, HTML, v.v.), Aspose.Slides bỏ qua tất cả các macro (macro không được chuyển sang file kết quả).

Khi bạn thêm macro vào bản trình chiếu hoặc lưu lại bản trình chiếu có chứa macro, Aspose.Slides chỉ ghi lại các byte của macro.

Aspose.Slides **không bao giờ** chạy các macro trong một bản trình chiếu.
{{% /alert %}}

## **Thêm Macro VBA**

Aspose.Slides cung cấp lớp [VbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.vba.vba_project) để cho phép bạn tạo dự án VBA (và các tham chiếu dự án) và chỉnh sửa các mô-đun hiện có. Bạn có thể sử dụng giao diện [IVbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.vba.i_vba_project/) để quản lý VBA nhúng trong bản trình chiếu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
1. Sử dụng hàm khởi tạo [VbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) để thêm một dự án VBA mới.
1. Thêm một mô-đun vào VbaProject.
1. Đặt mã nguồn cho mô-đun.
1. Thêm tham chiếu tới <stdole>.
1. Thêm tham chiếu tới **Microsoft Office**.
1. Liên kết các tham chiếu với dự án VBA.
1. Lưu bản trình chiếu.

Mã C++ này cho bạn thấy cách thêm macro VBA từ đầu vào một bản trình chiếu: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Tạo một thể hiện của lớp Presentation
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

// Lưu bản trình chiếu
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 
Bạn có thể muốn kiểm tra **Aspose** [Macro Remover](https://products.aspose.app/slides/vi/remove-macros), một ứng dụng web miễn phí dùng để loại bỏ macro khỏi tài liệu PowerPoint, Excel và Word. 
{{% /alert %}} 

## **Xóa Macro VBA**

Sử dụng thuộc tính [VbaProject](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) trong lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation), bạn có thể xóa một macro VBA.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu chứa macro.
1. Truy cập mô-đun Macro và xóa nó.
1. Lưu bản trình chiếu đã chỉnh sửa.

Mã C++ này cho bạn thấy cách xóa một macro VBA: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Tải bản trình chiếu chứa macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Truy cập mô-đun Vba và xóa nó
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Lưu bản trình chiếu
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Trích xuất Macro VBA**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa VBA Project hay không.
3. Lặp qua tất cả các mô-đun trong VBA Project để xem các macro.

Mã C++ này cho bạn thấy cách trích xuất macro VBA từ một bản trình chiếu có chứa macro: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// Đường dẫn tới thư mục tài liệu.
	const String templatePath = u"../templates/VBA.pptm";

	// Tải bản trình chiếu chứa macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không
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

## **Kiểm tra xem một VBA Project có được bảo vệ bằng mật khẩu hay không**

Sử dụng thuộc tính [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/vi/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) , bạn có thể xác định liệu các thuộc tính của dự án có được bảo vệ bằng mật khẩu hay không.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và tải một bản trình chiếu chứa macro.
2. Kiểm tra xem bản trình chiếu có chứa [VBA project](https://reference.aspose.com/slides/vi/cpp/aspose.slides.vba/vbaproject/) không.
3. Kiểm tra xem VBA project có được bảo vệ bằng mật khẩu để xem các thuộc tính của nó hay không.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Kiểm tra xem bản trình chiếu có chứa dự án VBA hay không.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **Câu hỏi thường gặp**

### Điều gì xảy ra với các macro nếu tôi lưu bản trình chiếu dưới dạng PPTX?

Macro sẽ bị xóa vì PPTX không hỗ trợ VBA. Để giữ macro, hãy chọn PPTM, PPSM hoặc POTM.

### Aspose.Slides có thể chạy macro trong bản trình chiếu để, ví dụ, làm mới dữ liệu không?

Không. Thư viện không bao giờ thực thi mã VBA; việc thực thi chỉ có thể thực hiện trong PowerPoint với các cài đặt bảo mật phù hợp.

### Có hỗ trợ làm việc với các điều khiển ActiveX liên kết với mã VBA không?

Có, bạn có thể truy cập các [ActiveX controls](/slides/vi/cpp/activex/), sửa đổi thuộc tính của chúng và xóa chúng. Điều này hữu ích khi các macro tương tác với ActiveX.