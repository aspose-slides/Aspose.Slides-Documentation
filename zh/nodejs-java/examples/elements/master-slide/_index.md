---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/nodejs-java/examples/elements/master-slide/
keywords:
- 代码示例
- 母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解 Aspose.Slides for Node.js 的母版幻灯片示例：在 PPT、PPTX 和 ODP 中创建、编辑和设置母版、占位符和主题，代码清晰明了。"
---
母版幻灯片构成 PowerPoint 中幻灯片继承层次结构的顶层。**母版幻灯片**定义诸如背景、徽标和文本格式等通用设计元素。**布局幻灯片**继承自母版幻灯片，**普通幻灯片**继承自布局幻灯片。

本文演示如何使用 Aspose.Slides for Node.js via Java 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

此示例展示了如何通过克隆默认母版创建新的母版幻灯片。随后通过布局继承向所有幻灯片添加公司名称横幅。

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 克隆默认母版幻灯片。
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // 在母版幻灯片顶部添加包含公司名称的横幅。
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // 将新母版幻灯片分配给布局幻灯片。
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // 将布局幻灯片分配给演示文稿中的第一张幻灯片。
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意 1:** 母版幻灯片提供了一种在所有幻灯片上应用一致品牌或共享设计元素的方式。对母版所做的任何更改都会自动反映在依赖的布局和普通幻灯片上。

> 💡 **注意 2:** 添加到母版幻灯片的任何形状或格式都会被布局幻灯片继承，进而被使用这些布局的所有普通幻灯片继承。  
> 下图示例说明了在母版幻灯片上添加的文本框如何自动在最终幻灯片中呈现。

![母版继承示例](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用演示文稿的母版集合访问母版幻灯片。以下示例演示如何检索和使用它们：

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // 更改背景类型。
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **移除母版幻灯片**

可以通过索引或引用来移除母版幻灯片。

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 按索引移除母版幻灯片。
        presentation.getMasters().removeAt(0);

        // 按引用移除母版幻灯片。
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **移除未使用的母版幻灯片**

某些演示文稿包含未使用的母版幻灯片。移除这些幻灯片可以帮助减小文件大小。

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 移除所有未使用的母版幻灯片（即使标记为 Preserve）。
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```