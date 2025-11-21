---
title: 上标和下标
type: docs
weight: 80
url: /zh/nodejs-java/superscript-and-subscript/
---

## **管理上标和下标文本**

您可以在任何段落部分中添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用 [**setEscapement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) 方法的 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat) 类。

此属性返回或设置上标或下标文本（取值范围为 -100%（下标）到 100%（上标））。例如：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 向幻灯片添加类型为 [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)。
- 访问与 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) 关联的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame)。
- 清除现有段落。
- 创建一个用于保存上标文本的新段落对象，并将其添加到 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) 的 [Paragraphs collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getParagraphs--) 中。
- 创建一个新的 Portion 对象。
- 将该 Portion 的 Escapement 属性设为 0 到 100 之间，以添加上标。（0 表示无上标）
- 为 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 设置文本，然后将其添加到段落的 Portion 集合中。
- 创建一个用于保存下标文本的新段落对象，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的 Portion 对象。
- 将该 Portion 的 Escapement 属性设为 0 到 -100 之间，以添加下标。（0 表示无下标）
- 为 [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) 设置文本，然后将其添加到段落的 Portion 集合中。
- 将演示文稿保存为 PPTX 文件。

下面给出上述步骤的实现代码。
```javascript
// 实例化一个表示 PPTX 的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 获取幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 创建文本框
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // 创建上标文本的段落
    var superPar = new aspose.slides.Paragraph();
    // 创建普通文本的 Portion
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // 创建上标文本的 Portion
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // 创建下标文本的段落
    var paragraph2 = new aspose.slides.Paragraph();
    // 创建普通文本的 Portion
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // 创建下标文本的 Portion
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // 将段落添加到文本框
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

是的，Aspose.Slides 在将演示文稿导出为 PDF、PPT/PPTX、图像以及其他受支持格式时，能够正确保留上标和下标的格式。专门的格式在所有输出文件中保持完整。

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

是的，Aspose.Slides 允许在同一 Portion 文本中混合多种样式。您可以在配置 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) 的相应属性时，同时启用粗体、斜体、下划线以及上标或下标。

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

是的，Aspose.Slides 支持在大多数对象内部进行格式设置，包括表格和图表元素。对 SmartArt 进行操作时，您需要访问相应的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/)）及其文本容器，然后以类似方式配置 [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) 的属性。