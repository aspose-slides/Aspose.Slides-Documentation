---
title: Flash
type: docs
weight: 10
url: /zh/nodejs-java/flash/
description: 使用 JavaScript 从 PowerPoint 演示文稿中提取 Flash 对象
---

## **从演示文稿中提取 Flash 对象**

Aspose.Slides for Node.js via Java 提供了从演示文稿中提取 Flash 对象的功能。您可以按名称访问 Flash 控件并将其从演示文稿中提取出来，包括存储 SWF 对象数据。
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**在提取 Flash 内容时支持哪些演示文稿格式？**

[Aspose.Slides supports](/slides/zh/nodejs-java/supported-file-formats/) 主要的 PowerPoint 格式，如 PPT 和 PPTX，因为它可以加载这些容器并访问其中的控件，包括与 Flash 相关的 ActiveX 元素。

**我可以将包含 Flash 的演示文稿转换为 HTML5 并保留 Flash 的交互性吗？**

不可以。Aspose.Slides 不会执行 SWF 内容或转换其交互性。虽然支持导出为 [HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/zh/nodejs-java/export-to-html5/)，但由于已停止支持，Flash 在现代浏览器中无法播放。建议在导出之前将 Flash 替换为视频或 HTML5 动画等替代方案。

**从安全角度来看，Aspose.Slides 在读取演示文稿时会执行 SWF 文件吗？**

不会。Aspose.Slides 将 Flash 视为嵌入文件中的二进制数据，在处理过程中不执行 SWF 内容。

**当演示文稿中包含 Flash 以及通过 OLE 嵌入的其他文件时，我该如何处理？**

Aspose.Slides 支持 [extracting embedded OLE objects](/slides/zh/nodejs-java/manage-ole/)，因此您可以一次性处理所有相关的嵌入内容，同时处理 Flash 控件和其他 OLE 嵌入的文档。