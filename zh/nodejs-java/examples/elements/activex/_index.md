---
title: ActiveX
type: docs
weight: 200
url: /zh/nodejs-java/examples/elements/activex/
keywords:
- 代码示例
- ActiveX
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "查看 Aspose.Slides for Node.js ActiveX 示例：在 PPT 和 PPTX 演示文稿中插入、配置和控制 ActiveX 对象，使用清晰的 JavaScript 代码。"
---
本文演示了如何在演示文稿中使用 **Aspose.Slides for Node.js via Java** 添加、访问、删除和配置 ActiveX 控件。

## **添加 ActiveX 控件**

向幻灯片添加一个新的 ActiveX 控件。

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 添加一个新的 ActiveX 控件。
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的信息。

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 访问第一个 ActiveX 控件。
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **删除 ActiveX 控件**

从幻灯片中删除已有的 ActiveX 控件。

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 删除第一个 ActiveX 控件。
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **设置 ActiveX 属性**

配置多个 ActiveX 属性。

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```