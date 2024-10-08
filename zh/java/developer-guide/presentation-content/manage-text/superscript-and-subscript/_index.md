---
title: 上标和下标
type: docs
weight: 80
url: /zh/java/superscript-and-subscript/
---

## **管理上标和下标文本**
您可以在任何段落部分中添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用 [**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) 方法，该方法属于 [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat) 类。

此属性返回或设置上标或下标文本（值范围从 -100%（下标）到 100%（上标）。例如：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个类型为 [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) 的 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)。
- 访问与 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) 关联的 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame)。
- 清除现有段落
- 创建一个新的段落对象以保存上标文本，并将其添加到 [IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--) 中的 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame)。
- 创建一个新的部分对象
- 设置该部分的 Escapement 属性为 0 到 100 之间的值以添加上标。（0 表示没有上标）
- 设置一些文本给 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)，然后将其添加到段落的部分集合中。
- 创建一个新的段落对象以保存下标文本，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的部分对象
- 设置该部分的 Escapement 属性为 0 到 -100 之间的值以添加下标。（0 表示没有下标）
- 设置一些文本给 [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)，然后将其添加到段落的部分集合中。
- 将演示文稿保存为 PPTX 文件。

上述步骤的实现如下所示。

```java
// 实例化一个表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 创建文本框
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 创建用于上标文本的段落
    IParagraph superPar = new Paragraph();

    // 创建包含常规文本的部分
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 创建包含上标文本的部分
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 创建用于下标文本的段落
    IParagraph paragraph2 = new Paragraph();

    // 创建包含常规文本的部分
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 创建包含下标文本的部分
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // 将段落添加到文本框
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```