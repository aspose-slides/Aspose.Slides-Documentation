---
title: 使用 JavaScript 管理簡報中的 VBA 專案
linktitle: 透過 VBA 的簡報
type: docs
weight: 250
url: /zh-hant/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 透過 Java，在 JavaScript 中以 VBA 產生並操作 PowerPoint 與 OpenDocument 簡報，以簡化您的工作流程。"
---
## **介紹**

Aspose.Slides 提供用於處理巨集和 VBA 程式碼的類別。

{{% alert title="注意" color="warning" %}} 

當您將包含巨集的簡報轉換為其他檔案格式 (PDF、HTML 等) 時，Aspose.Slides 會忽略所有巨集（巨集不會被帶入產生的檔案）。

當您向簡報新增巨集或重新儲存包含巨集的簡報時，Aspose.Slides 只會寫入巨集的位元組。

Aspose.Slides **永不** 執行簡報中的巨集。

{{% /alert %}}

## **新增 VBA 巨集**

Aspose.Slides 提供 [VbaProject] 類別，讓您建立 VBA 專案（以及專案參照）並編輯既有模組。您可以使用 [VbaProject] 類別來管理嵌入於簡報中的 VBA。

1. 建立 [Presentation] 類別的實例。
2. 使用 [VbaProject] 建構函式新增一個 VBA 專案。
3. 將模組新增至 VbaProject。
4. 設定模組的來源程式碼。
5. 新增對 <stdole> 的參照。
6. 新增對 **Microsoft Office** 的參照。
7. 將參照關聯至 VBA 專案。
8. 儲存簡報。

以下 JavaScript 程式碼示範如何從頭為簡報新增 VBA 巨集：

```javascript
// 建立簡報類別的實例
let pres = new aspose.slides.Presentation();
try {
    // 建立新的 VBA 專案
    pres.setVbaProject(new aspose.slides.VbaProject());
    // 向 VBA 專案新增空白模組
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // 設定模組來源程式碼
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // 建立對 <stdole> 的參照
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // 建立對 Office 的參照
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // 向 VBA 專案加入參照
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // 儲存簡報
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

您可能想看看 **Aspose** [Macro Remover](https://products.aspose.app/slides/zh-hant/remove-macros)，這是一個免費的 Web 應用程式，可用於從 PowerPoint、Excel 和 Word 文件中移除巨集。 

{{% /alert %}} 

## **移除 VBA 巨集**

使用 [Presentation] 類別下的 [VbaProject] 屬性，即可移除 VBA 巨集。

1. 建立 [Presentation] 類別的實例，並載入包含巨集的簡報。
2. 存取 Macro 模組並將其移除。
3. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何移除 VBA 巨集：

```javascript
// 載入包含巨集的簡報
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // 存取 Vba 模組並將其移除
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // 儲存簡報
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **擷取 VBA 巨集**

1. 建立 [Presentation] 類別的實例，並載入包含巨集的簡報。
2. 檢查簡報是否包含 VBA 專案。
3. 遍歷 VBA 專案中所有模組，以檢視巨集。

以下 JavaScript 程式碼示範如何從包含巨集的簡報中擷取 VBA 巨集：

```javascript
// 載入包含巨集的簡報
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // 檢查簡報是否包含 VBA 專案
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **檢查 VBA 專案是否受密碼保護**

使用 [VbaProject.isPasswordProtected] 方法，您可以判斷專案的屬性是否受密碼保護。

1. 建立 [Presentation] 類別的實例，並載入包含巨集的簡報。
2. 檢查該簡報是否包含 [VBA project]。
3. 檢查 VBA 專案是否受密碼保護，以查看其屬性。

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // 檢查簡報是否包含 VBA 專案。
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **常見問題**

**如果我將簡報儲存為 PPTX，巨集會發生什麼事？**

巨集會被移除，因為 PPTX 不支援 VBA。若要保留巨集，請選擇 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在簡報內執行巨集，例如刷新資料嗎？**

不能。此函式庫永不執行 VBA 程式碼；僅能在 PowerPoint 中，且具備相應安全設定時才可執行。

**是否支援與連結至 VBA 程式碼的 ActiveX 控制項互動？**

可以，您可以存取現有的 [ActiveX controls](/slides/zh-hant/nodejs-java/activex/)，修改其屬性，並將其移除。當巨集與 ActiveX 互動時，此功能很有用。