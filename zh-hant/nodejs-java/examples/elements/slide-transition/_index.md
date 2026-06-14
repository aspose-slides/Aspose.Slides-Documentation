---
title: 投影片轉場
type: docs
weight: 110
url: /zh-hant/nodejs-java/examples/elements/slide-transition/
keywords:
- 程式碼範例
- 投影片轉場
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中精通投影片轉場：新增、客製化並排序效果與持續時間，並提供 PPT、PPTX 與 ODP 簡報的範例。"
---
本文示範如何在 **Aspose.Slides for Node.js via Java** 中套用投影片轉場效果與時間設定。

## **新增投影片轉場**

將淡入轉場效果套用於第一張投影片。

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 套用淡入轉場。
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取投影片轉場**

讀取目前指派給投影片的轉場類型。

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 取得轉場類型。
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **移除投影片轉場**

將類型設定為 `None` 以清除所有轉場效果。

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 將轉場設定為 none 以移除。
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **設定轉場持續時間**

指定投影片在自動前進前顯示的時間長度。

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // 以毫秒為單位。

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```