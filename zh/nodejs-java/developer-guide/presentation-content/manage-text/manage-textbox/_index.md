---
title: 管理文本框
type: docs
weight: 20
url: /zh/nodejs-java/manage-textbox/
keywords:
- 文本框
- 文本框架
- 添加文字
- 更新文字
- 带超链接的文本框
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "使用 JavaScript 在 PowerPoint 演示文稿中管理文本框或文本框架"
---

幻灯片上的文字通常位于文本框或形状中。因此，要在幻灯片上添加文字，需要先添加一个文本框，然后在文本框中放入文字。Aspose.Slides for Node.js via Java 提供了[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)类，允许您添加包含文字的形状。

{{% alert title="Info" color="info" %}}

Aspose.Slides 还提供了[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape)类，可用于向幻灯片添加形状。但并非所有通过`Shape`类添加的形状都能容纳文字。而通过[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)类添加的形状可以包含文字。

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

因此，在处理需要添加文字的形状时，您可能需要检查并确认它是通过`AutoShape`类创建的。只有这样才能使用`AutoShape`下的属性[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)。请参阅本页的[Update Text](https://docs.aspose.com/slides/nodejs-java/manage-textbox/#update-text)章节。

{{% /alert %}}

## **Create Text Box on Slide**

要在幻灯片上创建文本框，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。  
2. 获取新创建演示文稿中第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个`ShapeType`设置为`Rectangle`的[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)对象，并获取新添加的`AutoShape`对象的引用。  
4. 为该`AutoShape`对象添加`TextFrame`属性，以便容纳文字。下面的示例中，我们添加的文字是 *Aspose TextBox*。  
5. 最后，通过`Presentation`对象写出 PPTX 文件。  

下面的 JavaScript 代码实现了上述步骤，演示了如何向幻灯片添加文字：
```javascript
// 实例化 Presentation
var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加 AutoShape，类型设置为 Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 向 Rectangle 添加 TextFrame
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


## **Check for Text Box Shape**

Aspose.Slides 提供了[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)类的[isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox)方法，允许您检查形状并识别文本框。

![文本框和形状](istextbox.png)

下面的 JavaScript 代码展示了如何检查形状是否被创建为文本框：
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```


请注意，如果仅使用[ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)类的`addAutoShape`方法添加 AutoShape，则该 AutoShape 的`isTextBox`方法返回`false`。但在使用`addTextFrame`方法或`setText`方法向 AutoShape 添加文字后，`isTextBox`属性将返回`true`。
```javascript
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


## **Add Column In Text Box**

Aspose.Slides 提供了[TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)类的[setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)和[setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-)方法，允许您在文本框中添加列。您可以指定文本框的列数并设置列之间的间距（单位为磅）。

下面的 JavaScript 代码演示了上述操作：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加 AutoShape，类型设置为 Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 向 Rectangle 添加 TextFrame
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
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


## **Add Column In Text Frame**

Aspose.Slides for Node.js via Java 提供了[TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)类的[setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)方法，允许在文本框架中添加列。通过此属性，您可以指定文本框架中的列数。

下面的 JavaScript 代码展示了如何在文本框架中添加列：
```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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


## **Update Text**

Aspose.Slides 允许您更改或更新文本框中的文字，或更新演示文稿中所有文字。

下面的 JavaScript 代码演示了将演示文稿中所有文字进行更新或更改的操作：
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 检查形状是否支持文本框架 (IAutoShape)。
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // 遍历文本框架中的段落
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


## **Add Text Box with Hyperlink** 

您可以在文本框中插入超链接。单击该文本框时，用户会打开链接。

要添加包含链接的文本框，请按以下步骤操作：

1. 创建`Presentation`类的实例。  
2. 获取新创建演示文稿中第一张幻灯片的引用。  
3. 在幻灯片的指定位置添加一个`ShapeType`设置为`Rectangle`的`AutoShape`对象，并获取新添加的 AutoShape 对象的引用。  
4. 为该`AutoShape`对象添加一个`TextFrame`，默认文字为 *Aspose TextBox*。  
5. 实例化`HyperlinkManager`类。  
6. 将`HyperlinkManager`对象分配给`TextFrame`中您希望设置超链接的文本段落的[HyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick--)属性。  
7. 最后，通过`Presentation`对象写出 PPTX 文件。  

下面的 JavaScript 代码实现了上述步骤，演示了如何向幻灯片添加带超链接的文本框：
```javascript
// 实例化表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取演示文稿中的第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加一个类型设置为 Rectangle 的 AutoShape 对象
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // 将形状转换为 AutoShape
    var pptxAutoShape = shape;
    // 访问与 AutoShape 关联的 ITextFrame 属性
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // 向框架添加一些文本
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // 为该文本部分设置超链接
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


## **FAQ**

**在使用母版幻灯片时，文本框和文本占位符有什么区别？**

占位符[placeholder](/slides/zh/nodejs-java/manage-placeholder/)会从[母版](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/)继承样式/位置，并且可以在[布局](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)上被覆盖；而普通文本框是特定幻灯片上的独立对象，切换布局时不会改变。

**如何在不影响图表、表格和 SmartArt 中的文字的情况下，批量替换演示文稿中的文字？**

将遍历范围限制在具有文本框架的自动形状上，排除嵌入对象（如[图表](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)、[表格](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/)），可以通过分别遍历它们的集合或跳过这些对象类型来实现。