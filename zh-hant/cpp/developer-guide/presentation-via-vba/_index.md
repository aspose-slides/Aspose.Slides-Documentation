---
title: 使用 C++ 管理簡報中的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/cpp/presentation-via-vba/
keywords:
- 巨集
- VBA
- VBA 巨集
- 新增巨集
- 移除巨集
- 擷取巨集
- 新增 VBA
- 移除 VBA
- 擷取 VBA
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 透過 VBA 產生與操作 PowerPoint 與 OpenDocument 簡報，以簡化工作流程。"
---
## **簡介**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.vba.vba_project) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.vba.i_vba_project/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) class.  
1. Use the [VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) constructor to add a new VBA project.  
1. Add a module to the VbaProject.  
1. Set the module source code.  
1. Add references to <stdole>.  
1. Add references to **Microsoft Office**.  
1. Associate the references with the VBA project.  
1. Save the presentation.

This C++ code shows you how to add a VBA macro from scratch to a presentation: 

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

// 文件目錄的路徑。
const String outPath = u"../out/AddVBAMacros_out.pptm";

// 建立 Presentation 類別的實例
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 建立新的 VBA 專案
presentation->set_VbaProject(MakeObject<VbaProject>());

// 向 VBA 專案新增空白模組
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// 設定模組的原始碼
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// 建立對 <stdole> 的參考
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// 建立對 Office 的參考
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// 將參考加入 VBA 專案
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// 儲存簡報
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **移除 VBA 巨集**

Using the [VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) property under the [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.  
1. Access the Macro module and remove it.  
1. Save the modified presentation.

This C++ code shows you how to remove a VBA macro: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// 文件目錄的路徑。
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// 載入包含巨集的簡報
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// 取得 Vba 模組並將其移除
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// 儲存簡報
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **擷取 VBA 巨集**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.  
2. Check if the presentation contains a VBA Project.  
3. Loop through all the modules contained in the VBA Project to view the macros.

This C++ code shows you how to extract VBA macros from a presentation containing macros: 

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

	// 文件目錄的路徑。
	const String templatePath = u"../templates/VBA.pptm";

	// 載入包含巨集的簡報
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // 檢查簡報是否包含 VBA 專案
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

## **檢查 VBA 專案是否設定密碼保護**

Using the [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) class and load a presentation that contains a macro.  
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.vba/vbaproject/).  
3. Check whether the VBA project is password-protected to view its properties.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // 檢查簡報是否包含 VBA 專案。
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### What happens to macros if I save the presentation as PPTX?

Macros will be removed because PPTX does not support VBA. To keep macros, choose PPTM, PPSM, or POTM.

### Can Aspose.Slides run macros inside a presentation to, for example, refresh data?

No. The library never executes VBA code; execution is only possible inside PowerPoint with the appropriate security settings.

### Is working with ActiveX controls linked to VBA code supported?

Yes, you can access existing [ActiveX controls](/slides/zh-hant/cpp/activex/), modify their properties, and remove them. This is useful when macros interact with ActiveX.