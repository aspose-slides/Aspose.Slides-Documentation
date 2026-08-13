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
description: "探索如何使用 Aspose.Slides for .NET 透過 VBA 產生與操作 PowerPoint 與 OpenDocument 簡報，以簡化您的工作流程。"
---
## **簡介**

[Aspose.Slides.Vba](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/) 命名空間包含用於處理巨集和 VBA 程式碼的類別和介面。

{{% alert title="Note" color="warning" %}} 
當您將包含巨集的簡報轉換為其他檔案格式 (PDF、HTML 等) 時，Aspose.Slides 會忽略所有巨集（巨集不會被帶入最終檔案）。
當您向簡報加入巨集或重新儲存包含巨集的簡報時，Aspose.Slides 只會寫入巨集的位元組。
Aspose.Slides **永不** 在簡報中執行巨集。
{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/vbaproject/) 類別，允許您建立 VBA 專案（以及專案參照）並編輯現有模組。您可以使用 [IVbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/ivbaproject/) 介面來管理嵌入於簡報中的 VBA。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) 建構函式新增一個 VBA 專案。
1. 向 VbaProject 新增模組。
1. 設定模組的來源程式碼。
1. 新增對 <stdole> 的參照。
1. 新增對 **Microsoft Office** 的參照。
1. 將這些參照與 VBA 專案關聯。
1. 儲存簡報。

以下 C# 程式碼示範如何從頭為簡報新增 VBA 巨集：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// 建立簡報類別的實例
using (Presentation presentation = new Presentation())
{
    // 建立新的 VBA 專案
    presentation.VbaProject = new VbaProject();

    // 在 VBA 專案中新增空白模組
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // 設定模組的來源程式碼
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // 建立對 <stdole> 的參照
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // 建立對 Office 的參照
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // 將參照加入 VBA 專案
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // 儲存簡報
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 
您可能想了解 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)，這是一個免費的 Web 應用程式，用於從 PowerPoint、Excel 和 Word 文件中移除巨集。 
{{% /alert %}} 

## **移除 VBA 巨集**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別下的 [VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/vbaproject/) 屬性，您可以移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。
1. 取得 Macro 模組並將其移除。
1. 儲存已修改的簡報。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 載入包含巨集的簡報
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // 取得 Vba 模組並將其移除
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // 儲存簡報
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **擷取 VBA 巨集**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。
2. 檢查簡報是否包含 VBA 專案。
3. 逐一迴圈遍歷 VBA 專案中所有模組，以檢視巨集。

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

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

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。
2. 檢查簡報是否包含 [VBA 專案](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.vba/vbaproject/)。
3. 檢查 VBA 專案是否受密碼保護，以檢視其屬性。

```cs
using Aspose.Slides;

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

### 如果我將簡報儲存為 PPTX，巨集會發生什麼情況？

巨集將被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

### Aspose.Slides 能在簡報內執行巨集，例如重新整理資料嗎？

不能。此函式庫永不執行 VBA 程式碼；只有在 PowerPoint 中且具備適當安全設定時才可能執行。

### 是否支援與連結至 VBA 程式碼的 ActiveX 控制項的操作？

是的，您可以存取現有的 [ActiveX controls](/slides/zh-hant/net/activex/)，修改其屬性，並將其移除。當巨集與 ActiveX 互動時，這很有用。