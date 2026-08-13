---
title: 在 Android 上管理簡報中的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android（Java）透過 VBA 產生和操作 PowerPoint 與 OpenDocument 簡報，以簡化工作流程。"
---
## **Introduction**

Aspose.Slides 為處理巨集與 VBA 程式碼提供類別與介面。

{{% alert title="Note" color="warning" %}} 

當您將含有巨集的簡報轉換為其他檔案格式（PDF、HTML 等）時，Aspose.Slides 會忽略所有巨集（巨集不會被寫入產生的檔案）。

當您在簡報中加入巨集或重新儲存已含巨集的簡報時，Aspose.Slides 只會寫入巨集的位元組。

Aspose.Slides **永不** 執行簡報中的巨集。

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/vbaproject/) 類別，讓您建立 VBA 專案（以及專案參考）並編輯現有模組。您可以使用 [IVbaProject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivbaproject/) 介面來管理簡報中嵌入的 VBA。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。  
1. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/vbaproject/#VbaProject--) 建構函式新增 VBA 專案。  
1. 將模組新增至 VbaProject。  
1. 設定模組的原始程式碼。  
1. 加入對 <stdole> 的參考。  
1. 加入 **Microsoft Office** 的參考。  
1. 將參考與 VBA 專案關聯。  
1. 儲存簡報。

此 Java 程式碼展示如何從頭為簡報加入 VBA 巨集：

```java
import com.aspose.slides.*;

// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 建立新的 VBA 專案
    pres.setVbaProject(new VbaProject());
    
    // 向 VBA 專案新增空白模組
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // 設定模組的原始程式碼
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // 建立對 <stdole> 的參考
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // 建立對 Office 的參考
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // 將參考加入 VBA 專案
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // 儲存簡報
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

您可能想了解 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)，這是一個可免費使用的網路應用程式，可從 PowerPoint、Excel 與 Word 文件中移除巨集。 

{{% /alert %}} 

## **Remove VBA Macros**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別下的 [VbaProject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getVbaProject--) 屬性，即可移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例並載入含有巨集的簡報。  
1. 取得巨集模組並將其移除。  
1. 儲存已修改的簡報。

此 Java 程式碼展示如何移除 VBA 巨集：

```java
import com.aspose.slides.*;

// 載入包含巨集的簡報
Presentation pres = new Presentation("VBA.pptm");
try {
    // 取得 Vba 模組並將其移除
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // 儲存簡報
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract VBA Macros**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例並載入含有巨集的簡報。  
2. 檢查簡報是否包含 VBA 專案。  
3. 迴圈遍歷 VBA 專案中所有模組，以檢視巨集內容。

此 Java 程式碼展示如何從含有巨集的簡報中擷取 VBA 巨集：

```java
import com.aspose.slides.*;

// 載入包含巨集的簡報
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // 檢查簡報是否包含 VBA 專案
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Check Whether a VBA Project Is Password-Protected**

使用 [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) 方法，可判斷專案的屬性是否受密碼保護。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例並載入含有巨集的簡報。  
2. 檢查簡報是否包含 [VBA project](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/vbaproject/)。  
3. 檢查該 VBA 專案是否受密碼保護，以查看其屬性。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // 檢查簡報是否包含 VBA 專案。
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### What happens to macros if I save the presentation as PPTX?

巨集會被移除，因為 PPTX 不支援 VBA。若需保留巨集，請選擇 PPTM、PPSM 或 POTM。

### Can Aspose.Slides run macros inside a presentation to, for example, refresh data?

不會。此函式庫永不執行 VBA 程式碼；執行僅能在 PowerPoint 中，且必須具備相應的安全設定。

### Is working with ActiveX controls linked to VBA code supported?

是的，您可以存取既有的 [ActiveX controls](/slides/zh-hant/androidjava/activex/)，修改其屬性，或將其移除。這在巨集與 ActiveX 互動時相當有用。