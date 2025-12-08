---
title: 管理占位符
type: docs
weight: 10
url: /zh/nodejs-java/manage-placeholder/
description: 使用 JavaScript 在 PowerPoint 幻灯片中更改占位符文本。使用 JavaScript 在 PowerPoint 幻灯片中设置占位符提示文本。
---

## **更改占位符中的文本**

使用 [Aspose.Slides for Node.js via Java](/slides/zh/nodejs-java/)，您可以在演示文稿的幻灯片上查找并修改占位符。Aspose.Slides 允许您更改占位符中的文本。

**先决条件**：您需要一个包含占位符的演示文稿。您可以在标准的 Microsoft PowerPoint 应用程序中创建此类演示文稿。

以下示例演示如何使用 Aspose.Slides 替换该演示文稿中占位符的文本：

1. 实例化 [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类，并将演示文稿作为参数传入。
2. 通过索引获取幻灯片的引用。
3. 遍历形状以查找占位符。
4. 将占位符形状强制转换为 [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)，并使用与该 [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 关联的 [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 来更改文本。
5. 保存修改后的演示文稿。

以下 JavaScript 代码示例展示了如何更改占位符中的文本：
```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 遍历形状以查找占位符
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // 更改每个占位符中的文本
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // 将演示文稿保存到磁盘
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **在占位符中设置提示文本**

标准和预构建布局包含占位符提示文本，例如 ***Click to add a title*** 或 ***Click to add a subtitle***。使用 Aspose.Slides，您可以将自定义提示文本插入到占位符布局中。

以下 JavaScript 代码展示了如何在占位符中设置提示文本：
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 遍历幻灯片
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint 显示 "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // 添加副标题
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置占位符图像透明度**

Aspose.Slides 允许您设置文本占位符中背景图像的透明度。通过调整该框架内图片的透明度，您可以使文本或图像突出显示（取决于文本和图片的颜色）。

以下 JavaScript 代码展示了如何为形状内的图片背景设置透明度：
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **常见问题**

**什么是基础占位符，它与幻灯片上的本地形状有何区别？**  
基础占位符是布局或母版上原始的形状，幻灯片的形状会从其继承——类型、位置以及部分格式都会来自该占位符。本地形状是独立的；如果没有基础占位符，则不存在继承。

**如何在不遍历每张幻灯片的情况下更新整个演示文稿中的所有标题或说明文字？**  
在布局或母版上编辑相应的占位符。基于这些布局/母版的幻灯片会自动继承该更改。

**如何控制标准的页眉/页脚占位符——日期和时间、幻灯片编号以及页脚文本？**  
在相应的作用域（普通幻灯片、布局、母版、备注/讲义）使用 HeaderFooter 管理器，打开或关闭这些占位符并设置其内容。