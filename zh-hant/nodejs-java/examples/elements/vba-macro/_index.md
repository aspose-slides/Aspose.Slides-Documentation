---
title: VBA 巨集
type: docs
weight: 150
url: /zh-hant/nodejs-java/examples/elements/vba-macro/
keywords:
- 程式碼範例
- VBA
- 巨集
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 自動化簡報：透過清晰的 JavaScript 範例在 PPT、PPTX 與 ODP 中建立、匯入與保護 VBA 巨集。"
---
本文示範如何使用 **Aspose.Slides for Node.js via Java** 新增、存取以及移除 VBA 巨集。

## **新增 VBA 巨集**

建立具備 VBA 專案與簡易巨集模組的簡報。

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // 假設簡報至少有一個 VBA 模組。
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **移除 VBA 巨集**

從 VBA 專案中刪除模組。

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // 假設簡報至少有一個 VBA 模組。
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```