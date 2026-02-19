---
title: VBA 宏
type: docs
weight: 150
url: /zh/nodejs-java/examples/elements/vba-macro/
keywords:
- 代码示例
- VBA
- 宏
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 自动化演示文稿：通过清晰的 JavaScript 示例在 PPT、PPTX 和 ODP 中创建、导入并保护 VBA 宏。"
---
本文演示如何使用 **Aspose.Slides for Node.js via Java** 添加、访问和删除 VBA 宏。

## **添加 VBA 宏**

创建一个包含 VBA 项目和简单宏模块的演示文稿。

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

## **访问 VBA 宏**

从 VBA 项目中检索第一个模块。

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // 假设演示文稿至少有一个 VBA 模块。
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // 假设演示文稿至少有一个 VBA 模块。
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```