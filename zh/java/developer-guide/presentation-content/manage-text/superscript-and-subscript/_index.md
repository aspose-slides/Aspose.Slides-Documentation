---
title: 使用 Java 管理演示文稿中的上标和下标
linktitle: 上标和下标
type: docs
weight: 80
url: /zh/java/superscript-and-subscript/
keywords:
- 上标
- 下标
- 添加上标
- 添加下标
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通上标和下标，并通过专业的文本格式提升演示文稿的效果，实现最大冲击力。"
---

## **管理上标和下标文本**
您可以在任何段落文本块中添加上标和下标文本。要在 Aspose.Slides 文本框中添加上标或下标文本，必须使用[**setEscapement**](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-)方法，该方法属于[PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/PortionFormat)类。

此属性返回或设置上标或下标文本（取值范围为 -100%（下标）到 100%（上标））。例如：

- 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
- 通过其索引获取幻灯片的引用。
- 向幻灯片添加一个类型为[Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle)的[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)。
- 访问与[IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)关联的[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame)。
- 清除现有段落。
- 创建一个用于保存上标文本的新段落对象，并将其添加到[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame)的[IParagraphs collection](https://reference.aspose.com/slides/java/com.aspose.slides/ITextFrame#getParagraphs--)中。
- 创建一个新的 Portion 对象。
- 将该 Portion 的 Escapement 属性设置为 0 到 100 之间的值以添加上标。（0 表示无上标）
- 为[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)设置一些文本，然后将其添加到段落的 Portion 集合中。
- 创建一个用于保存下标文本的新段落对象，并将其添加到 ITextFrame 的 IParagraphs 集合中。
- 创建一个新的 Portion 对象。
- 将该 Portion 的 Escapement 属性设置为 0 到 -100 之间的值以添加下标。（0 表示无下标）
- 为[Portion](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)设置一些文本，然后将其添加到段落的 Portion 集合中。
- 将演示文稿保存为 PPTX 文件。

下面给出上述步骤的实现代码。
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

    // 创建普通文本的 Portion
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 创建上标文本的 Portion
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 创建用于下标文本的段落
    IParagraph paragraph2 = new Paragraph();

    // 创建普通文本的 Portion
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 创建下标文本的 Portion
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


## **常见问题**

**将演示文稿导出为 PDF 或其他格式时，上标和下标会被保留吗？**

是的，Aspose.Slides 在将演示文稿导出为 PDF、PPT/PPTX、图像以及其他支持的格式时，会正确保留上标和下标的格式。专业的格式在所有输出文件中保持完整。

**上标和下标可以与其他格式（如加粗或斜体）组合使用吗？**

是的，Aspose.Slides 允许在同一段文字的 Portion 中混合多种文本样式。您可以通过在[PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/)中设置相应属性来启用加粗、斜体、下划线，并同时应用上标或下标。

**上标和下标格式在表格、图表或 SmartArt 中的文字也适用吗？**

是的，Aspose.Slides 支持在大多数对象（包括表格和图表元素）中进行格式设置。使用 SmartArt 时，需要访问相应的元素（如[SmartArtNode](https://reference.aspose.com/slides/java/com.aspose.slides/smartartnode/)）及其文本容器，然后以类似方式配置[PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/)的属性。