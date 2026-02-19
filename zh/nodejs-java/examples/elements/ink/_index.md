---
title: 墨迹
type: docs
weight: 180
url: /zh/nodejs-java/examples/elements/ink/
keywords:
- 代码示例
- 墨迹
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用墨迹：绘制、导入和编辑笔画，调整颜色和宽度，并使用示例导出为 PPT、PPTX 和 ODP。"
---
本文提供了使用 **Aspose.Slides for Node.js via Java** 访问现有墨迹形状并将其删除的示例。

> ❗ **注意:** 墨迹形状表示来自专用设备的用户输入。Aspose.Slides 无法以编程方式创建新的墨迹笔画，但您可以读取和修改现有的墨迹。

## **访问墨迹**

检索幻灯片上的第一个墨迹形状。

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

## **删除墨迹**

从幻灯片中删除墨迹形状。

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假设墨迹形状是幻灯片上的第一个形状。
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```