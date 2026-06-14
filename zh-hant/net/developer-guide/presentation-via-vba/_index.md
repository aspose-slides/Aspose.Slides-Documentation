---
title: 在 .NET 中管理簡報的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 透過 VBA 產生與操作 PowerPoint 與 OpenDocument 簡報，以簡化工作流程。"
---
## **簡介**

[ Aspose.Slides.Vba](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/) 命名空間包含用於處理巨集和 VBA 程式碼的類別與介面。

{{% alert title="注意" color="warning" %}} 

當您將包含巨集的簡報轉換為其他檔案格式（PDF、HTML 等）時，Aspose.Slides 會忽略所有巨集（巨集不會被帶入產生的檔案）。

當您向簡報加入巨集或重新儲存包含巨集的簡報時，Aspose.Slides 僅會寫入巨集的位元組。

Aspose.Slides **永遠不會** 執行簡報中的巨集。

{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/vbaproject/) 類別，以允許您建立 VBA 專案（以及專案參考）並編輯現有模組。您可以使用 [IVbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/ivbaproject/) 介面來管理簡報中嵌入的 VBA。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
1. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) 建構函式新增一個 VBA 專案。  
1. 向 VbaProject 新增模組。  
1. 設定模組的原始程式碼。  
1. 新增對 <stdole> 的參考。  
1. 新增對 **Microsoft Office** 的參考。  
1. 將參考與 VBA 專案關聯。  
1. 儲存簡報。

以下 C# 程式碼示範如何從頭開始為簡報新增 VBA 巨集：

```c#
    // 建立 Presentation 類別的實例
using (Presentation presentation = new Presentation())
{
    // 建立新的 VBA 專案
    presentation.VbaProject = new VbaProject();

    // 向 VBA 專案新增空模組
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // 設定模組的原始程式碼
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // 建立對 <stdole> 的參考
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // 建立對 Office 的參考
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // 向 VBA 專案新增參考
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // 儲存簡報
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

您可能想檢視 **Aspose**[Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)——這是一個用於移除 PowerPoint、Excel 與 Word 文件中巨集的免費網路應用程式。 

{{% /alert %}} 

## **移除 VBA 巨集**
使用位於 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別下的 [VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/vbaproject/) 屬性，即可移除 VBA 巨集。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例，並載入含有巨集的簡報。  
1. 取得巨集模組並將其移除。  
1. 儲存已修改的簡報。

以下 C# 程式碼示範如何移除 VBA 巨集：

```c#
    // 載入含有巨集的簡報
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // 存取 Vba 模組並將其移除 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // 儲存簡報
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **擷取 VBA 巨集**
1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例，並載入含有巨集的簡報。  
2. 檢查簡報是否包含 VBA 專案。  
3. 迴圈遍歷 VBA 專案中所有模組，以檢視巨集內容。

以下 C# 程式碼示範如何從含有巨集的簡報中擷取 VBA 巨集：

```c#
    // 載入包含巨集的簡報
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // 檢查簡報是否包含 VBA 專案
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **檢查 VBA 專案是否受密碼保護**

使用 [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) 屬性，您可以判斷專案的屬性是否受密碼保護。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。  
2. 檢查簡報是否包含 [VBA project](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/vbaproject/)。  
3. 檢查該 VBA 專案是否受密碼保護，以檢視其屬性。

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // 檢查簡報是否包含 VBA 專案。
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **常見問題**

**如果我將簡報另存為 PPTX，巨集會發生什麼事？**

巨集會被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報內執行巨集，例如刷新資料嗎？**

不能。此函式庫永遠不會執行 VBA 程式碼；執行僅在 PowerPoint 中且必須符合相應的安全性設定時才可能。

**是否支援與 VBA 程式碼連結的 ActiveX 控制項？**

支援，您可以存取現有的 [ActiveX controls](/slides/zh-hant/net/activex/)、修改其屬性，並將其移除。這在巨集與 ActiveX 互動時非常有用。