---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/nodejs-java/examples/elements/activex/
keywords:
- 程式碼範例
- ActiveX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "查看 Aspose.Slides for Node.js 的 ActiveX 範例：在 PPT 和 PPTX 簡報中插入、設定及控制 ActiveX 物件，並附有清晰的 JavaScript 程式碼。"
---
本篇文章示範如何在簡報中使用 **Aspose.Slides for Node.js via Java** 新增、存取、刪除及設定 ActiveX 控制項。

## **新增 ActiveX 控制項**

在投影片中新增一個 ActiveX 控制項。

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 新增一個 ActiveX 控制項。
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **存取 ActiveX 控制項**

讀取投影片上第一個 ActiveX 控制項的資訊。

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 存取第一個 ActiveX 控制項。
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除 ActiveX 控制項**

從投影片中刪除現有的 ActiveX 控制項。

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 移除第一個 ActiveX 控制項。
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **設定 ActiveX 屬性**

設定多個 ActiveX 屬性。

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