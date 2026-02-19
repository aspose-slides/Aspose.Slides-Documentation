---
title: 幻灯片转场
type: docs
weight: 110
url: /zh/nodejs-java/examples/elements/slide-transition/
keywords:
- 代码示例
- 幻灯片转场
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中掌握幻灯片转场：添加、定制和排序效果及持续时间，并提供 PPT、PPTX 和 ODP 演示文稿的示例。"
---
本文演示了如何使用 **Aspose.Slides for Node.js via Java** 应用幻灯片转场效果和计时。

## **添加幻灯片转场**

对第一张幻灯片应用淡入转场效果。

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 应用淡入转场。
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **获取幻灯片转场**

读取当前分配给幻灯片的转场类型。

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 访问转场类型。
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **移除幻灯片转场**

通过将类型设置为 `None` 来清除任何转场效果。

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 通过将类型设置为 None 移除转场。
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **设置转场持续时间**

指定幻灯片在自动前进之前显示的时长。

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // 毫秒。

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```