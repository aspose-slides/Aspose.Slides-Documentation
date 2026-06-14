---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/nodejs-java/examples/elements/ink/
keywords:
- 程式碼範例
- 墨跡
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用墨跡：繪製、匯入與編輯筆畫，調整顏色與寬度，並使用範例匯出為 PPT、PPTX 與 ODP。"
---
本文提供了使用 **Aspose.Slides for Node.js via Java** 存取現有墨跡形狀並將其移除的範例。

> ❗ **注意:** 墨跡形狀代表來自專用裝置的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆畫，但您可以讀取並修改現有的墨跡。

## **存取 Ink**

取得投影片上第一個墨跡形狀。

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除 Ink**

從投影片中刪除墨跡形狀。

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設墨跡形狀是投影片上的第一個形狀。
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```