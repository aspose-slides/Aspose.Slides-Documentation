---
title: 使用 Java 在簡報中管理 VBA 專案
linktitle: 簡報透過 VBA
type: docs
weight: 250
url: /zh-hant/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 透過 VBA 產生和操作 PowerPoint 與 OpenDocument 簡報，以簡化您的工作流程。"
---
## **簡介**

Aspose.Slides 提供用於處理巨集和 VBA 程式碼的類別與介面。

{{% alert title="Note" color="warning" %}} 
當您將含有巨集的簡報轉換為其他檔案格式 (PDF、HTML 等) 時，Aspose.Slides 會忽略所有巨集（巨集不會被寫入產生的檔案）。
當您向簡報加入巨集或重新儲存含有巨集的簡報時，Aspose.Slides 只會寫入巨集的位元組。
Aspose.Slides **永遠不會** 執行簡報中的巨集。
{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/vbaproject/) 類別，讓您建立 VBA 專案（以及專案參考）並編輯現有模組。您可以使用 [IVbaProject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivbaproject/) 介面來管理簡報中嵌入的 VBA。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/vbaproject/#VbaProject--) 建構函式新增一個 VBA 專案。
1. 將模組加入 VbaProject。
1. 設定模組的來源程式碼。
1. 新增對 <stdole> 的參考。
1. 新增對 **Microsoft Office** 的參考。
1. 將參考與 VBA 專案關聯。
1. 儲存簡報。

以下 Java 程式碼示範如何從頭新增 VBA 巨集至簡報：

```java
// 建立簡報類別的實例
Presentation pres = new Presentation();
try {
    // 建立新 VBA 專案
    pres.setVbaProject(new VbaProject());
    
    // 向 VBA 專案新增空模組
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // 設定模組的來源程式碼
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

{{% alert color="primary" %}} 
您可能想要查看 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)，這是一個用於從 PowerPoint、Excel 與 Word 文件中移除巨集的免費網路應用程式。 
{{% /alert %}} 

## **移除 VBA 巨集**

透過 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的 [VbaProject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#getVbaProject--) 屬性，您可以移除 VBA 巨集。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例，並載入含有巨集的簡報。
1. 取得巨集模組並將其移除。
1. 儲存已修改的簡報。

以下 Java 程式碼示範如何移除 VBA 巨集：

```java
// 載入包含巨集的簡報
Presentation pres = new Presentation("VBA.pptm");
try {
    // 存取 Vba 模組並將其移除 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // 儲存簡報
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **擷取 VBA 巨集**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例，並載入含有巨集的簡報。
2. 檢查簡報是否包含 VBA 專案。
3. 迭代 VBA 專案中所有模組以檢視巨集。

以下 Java 程式碼示範如何從含有巨集的簡報中擷取 VBA 巨集：

```java
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

## **檢查 VBA 專案是否受密碼保護**

使用 [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) 方法，您可以判斷專案屬性是否受到密碼保護。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例，並載入包含巨集的簡報。
2. 檢查簡報是否包含 [VBA project](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/vbaproject/)。
3. 檢查 VBA 專案是否受密碼保護，以查看其屬性。

```java
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

## **常見問題**

**如果我將簡報儲存為 PPTX，巨集會怎樣？**

巨集會被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報內執行巨集，例如重新整理資料嗎？**

不能。函式庫永遠不會執行 VBA 程式碼；執行只能在具有適當安全設定的 PowerPoint 中完成。

**是否支援與 VBA 程式碼連結的 ActiveX 控制項？**

支援，您可以存取現有的 [ActiveX controls](/slides/zh-hant/java/activex/)、修改其屬性，並將其移除。這在巨集與 ActiveX 互動時非常有用。