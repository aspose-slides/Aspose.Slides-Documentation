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
當您將包含巨集的簡報轉換為其他檔案格式 (PDF、HTML 等) 時，Aspose.Slides 會忽略所有巨集 (巨集不會被帶入產生的檔案)。

當您向簡報加入巨集或重新儲存含有巨集的簡報時，Aspose.Slides 只會寫入巨集的位元組。

Aspose.Slides **永不**執行簡報中的巨集。
{{% /alert %}}

## **加入 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.vba.vba_project) 類別，讓您建立 VBA 專案 (和專案參考) 及編輯現有模組。您可以使用 [IVbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.vba.i_vba_project/) 介面來管理簡報中嵌入的 VBA。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
1. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) 建構式新增一個 VBA 專案。  
1. 向 VbaProject 新增模組。  
1. 設定模組的來源程式碼。  
1. 新增對 <stdole> 的參考。  
1. 新增對 **Microsoft Office** 的參考。  
1. 將參考與 VBA 專案關聯。  
1. 儲存簡報。

以下 C++ 程式碼示範如何從頭開始為簡報加入 VBA 巨集：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddVBAMacros_out.pptm";

// 建立 presentation 類別的實例
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 建立新的 VBA 專案
presentation->set_VbaProject(MakeObject<VbaProject>());

// 向 VBA 專案新增空白模組
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// 設定模組的原始程式碼
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// 建立對 <stdole> 的參考
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// 建立對 Office 的參考
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// 向 VBA 專案新增參考
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// 儲存簡報
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 
您可以試試 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)，這是一個免費的 Web 應用程式，可用來移除 PowerPoint、Excel 與 Word 文件中的巨集。 
{{% /alert %}} 

## **移除 VBA 巨集**

使用位於 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別下的 [VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) 屬性，您可以移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例，並載入包含巨集的簡報。  
1. 取得巨集模組並將其移除。  
1. 儲存已修改的簡報。

以下 C++ 程式碼示範如何移除 VBA 巨集：

```c++
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

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例，並載入包含巨集的簡報。  
2. 檢查簡報是否包含 VBA 專案。  
3. 逐一遍歷 VBA 專案中的所有模組，以檢視巨集內容。

以下 C++ 程式碼示範如何從包含巨集的簡報中擷取 VBA 巨集：

```c++

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

## **檢查 VBA 專案是否有設定密碼保護**

使用 [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) 屬性，您可以判斷專案的屬性是否受到密碼保護。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。  
2. 檢查簡報是否包含 [VBA 專案](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.vba/vbaproject/)。  
3. 檢查 VBA 專案是否受到密碼保護，以檢視其屬性。

```cpp
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

## **常見問題**

**如果我將簡報儲存為 PPTX，巨集會發生什麼事？**

巨集會被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報內執行巨集以，例如重新整理資料嗎？**

不能。此函式庫永不執行 VBA 程式碼；執行只能在 PowerPoint 中，且需符合相應的安全設定。

**是否支援與 VBA 程式碼連結的 ActiveX 控制項？**

支援，您可以存取現有的 [ActiveX controls](/slides/zh-hant/cpp/activex/)、修改其屬性，並將其移除。這在巨集與 ActiveX 互動時非常有用。