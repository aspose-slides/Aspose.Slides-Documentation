---
title: 使用 JavaScript 在演示文稿中管理文本框
linktitle: 管理文本框
type: docs
weight: 20
url: /zh/nodejs-java/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文本
- 更新文本
- 创建文本框
- 检查文本框
- 添加文本列
- 添加超链接
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 使在 PowerPoint 和 OpenDocument 文件中创建、编辑和克隆文本框变得轻松，提升您的演示文稿自动化。"
---
## **介绍**

幻灯片上的文本通常存在于文本框或形状中。因此，要向幻灯片添加文本，必须先添加一个文本框，然后在文本框中放入一些文本。Aspose.Slides for Node.js via Java 提供了允许您添加包含文本的形状的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/AutoShape) 类。

{{% alert title="Info" color="info" %}}
Aspose.Slides 还提供了 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Shape) 类，允许您向幻灯片添加形状。但并非所有通过 `Shape` 类添加的形状都能容纳文本。而通过 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/AutoShape) 类添加的形状可能包含文本。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，在处理想要添加文本的形状时，您可能需要检查并确认它是通过 `AutoShape` 类转换的。只有这样，您才能使用 `AutoShape` 下的属性 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrame)。请参阅本页的 [Update Text](https://docs.aspose.com/slides/zh/nodejs-java/manage-textbox/#update-text) 部分。
{{% /alert %}}

## **在幻灯片上创建文本框**

要在幻灯片上创建文本框，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 获取新创建的演示文稿中第一张幻灯片的引用。 
3. 在幻灯片的指定位置添加一个 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/AutoShape) 对象，`ShapeType` 设置为 `Rectangle`，并获取新添加的 `AutoShape` 对象的引用。
4. 向 `AutoShape` 对象添加 `TextFrame` 属性，以容纳文本。在下面的示例中，我们添加了以下文本：*Aspose TextBox*。
5. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

以下 JavaScript 代码实现了上述步骤，演示了如何向幻灯片添加文本：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化 Presentation
var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加类型为 Rectangle 的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 向矩形添加 TextFrame
    ashp.addTextFrame(" ");
    // 访问文本框架
    var txtFrame = ashp.getTextFrame();
    // 为文本框架创建 Paragraph 对象
    var para = txtFrame.getParagraphs().get_Item(0);
    // 为段落创建 Portion 对象
    var portion = para.getPortions().get_Item(0);
    // 设置文本
    portion.setText("Aspose TextBox");
    // 将演示文稿保存到磁盘
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **检查文本框形状**

Aspose.Slides 提供了 [isTextBox](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/#isTextBox) 方法（来自 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 类），可帮助您检查形状并识别文本框。

![文本框和形状](istextbox.png)

以下 JavaScript 代码演示了如何检查形状是否被创建为文本框：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

请注意，如果仅使用 [ShapeCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/) 类的 `addAutoShape` 方法添加 AutoShape，则该 AutoShape 的 `isTextBox` 方法将返回 `false`。但是，在使用 `addTextFrame` 方法或 `setText` 方法向该 AutoShape 添加文本后，`isTextBox` 属性将返回 `true`。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() 返回 false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() 返回 true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() 返回 false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() 返回 true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() 返回 false
shape3.addTextFrame("");
// shape3.isTextBox() 返回 false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() 返回 false
shape4.getTextFrame().setText("");
// shape4.isTextBox() 返回 false
```

## **查找拥有 TextFrame 的形状**

在通用文本处理代码中，您可能会收到一个 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) ，但尚未知道它属于哪个演示文稿对象。使用 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/#getParentShape--) 方法可以返回其所属的 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/)。

对于属于 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 或其他包含文本的形状的 TextFrame，`TextFrame.getParentShape` 返回所有者，而 `TextFrame.getParentCell` 返回 `null`。这两种方法均提供只读导航，调用它们不会更改所有权。访问形状前，请始终检查返回值是否为 `null`。

有关完整示例（包括识别形状和表格单元格所有者以及与 SmartArt 节点关联的形状），请参阅 [Search and Replace Text](/slides/zh/nodejs-java/search-and-replace-text/)。

## **在文本框中添加列**

Aspose.Slides 提供了 [setColumnCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 和 [setColumnSpacing](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) 方法（来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrameFormat) 类），可以在文本框中添加列。您可以指定文本框的列数并设置列之间的点距。

以下 JavaScript 代码演示了上述操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加类型为 Rectangle 的 AutoShape
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 向矩形添加 TextFrame
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // 获取 TextFrame 的文本格式
    var format = aShape.getTextFrame().getTextFrameFormat();
    // 指定 TextFrame 中的列数
    format.setColumnCount(3);
    // 指定列之间的间距
    format.setColumnSpacing(10);
    // 保存演示文稿
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在 TextFrame 中添加列**

Aspose.Slides for Node.js via Java 提供了来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrameFormat) 类的 [setColumnCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 方法，允许您在 TextFrame 中添加列。通过此属性，您可以指定 TextFrame 中所需的列数。

以下 JavaScript 代码展示了如何在 TextFrame 中添加列：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // 列间距从未设置，因此显示为 NaN。
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **更新文本**

Aspose.Slides 允许您更改或更新文本框中的文本，或更新演示文稿中所有文本。

以下 JavaScript 代码演示了将演示文稿中所有文本更新或更改的操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 检查形状是否支持文本框架 (IAutoShape)。
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // 遍历文本框中的段落
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // 遍历段落中的每个部分
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// 更改文本
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 更改格式
                    }
                }
            }
        }
    }
    // 保存修改后的演示文稿
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **添加带超链接的文本框** 

您可以在文本框内插入链接。单击文本框时，用户将被引导打开该链接。

要添加包含链接的文本框，请按照以下步骤操作：

1. 创建 `Presentation` 类的实例。 
2. 获取新创建的演示文稿中第一张幻灯片的引用。 
3. 在幻灯片的指定位置添加一个 `AutoShape` 对象，`ShapeType` 设置为 `Rectangle`，并获取新添加的 AutoShape 对象的引用。
4. 向 `AutoShape` 对象添加 `TextFrame`，并设置其第一段的文本。下面的示例使用了以下文本：*Aspose.Slides*。
5. 通过该段落的 `PortionFormat` 获取 `HyperlinkManager`。 
6. 调用 `setExternalHyperlinkClick` 将链接附加到该段落。 
7. 最后，通过 `Presentation` 对象写入 PPTX 文件。 

以下 JavaScript 代码实现了上述步骤，演示了如何在幻灯片中添加带超链接的文本框：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化一个表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加类型为 Rectangle 的 AutoShape 对象
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // 将形状转换为 AutoShape
    var pptxAutoShape = shape;
    // 访问与 AutoShape 关联的 ITextFrame 属性
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // 向框中添加一些文本
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // 为该段落文本设置超链接
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // 保存 PPTX 演示文稿
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常见问题**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

[占位符](/slides/zh/nodejs-java/manage-placeholder/) 继承自 [母版](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/) 的样式/位置，并且可以在 [布局](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/) 上被覆盖，而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在整个演示文稿中批量替换文本，而不影响图表、表格和 SmartArt 中的文本？**

遍历仅包含文本框的自动形状（auto‑shapes），排除嵌入对象（[图表](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/)、[表格](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/smartart/)），可以通过单独遍历它们的集合或跳过这些对象类型来实现。