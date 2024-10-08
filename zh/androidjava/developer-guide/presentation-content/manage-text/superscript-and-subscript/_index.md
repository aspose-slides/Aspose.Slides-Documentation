---
title: 上标和下标
type: docs
weight: 80
url: /androidjava/superscript-and-subscript/
---

## **管理上标和下标文本**
您可以在任何段落部分添加上标和下标文本。要在Aspose.Slides文本框中添加上标或下标文本，必须使用[**setEscapement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setEscapement-float-)方法，该方法属于[PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PortionFormat)类。

此属性返回或设置上标或下标文本（值从-100%（下标）到100%（上标）。例如：

- 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)类的实例。
- 通过使用其索引获取幻灯片的引用。
- 向幻灯片添加一个[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)类型的[Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle)。
- 访问与[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)关联的[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame)。
- 清除现有段落
- 创建一个新的段落对象以保存上标文本，并将其添加到[IParagraphs collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame#getParagraphs--)的[ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITextFrame)中。
- 创建一个新的部分对象
- 将Escapement属性设置为0到100之间以添加上标。（0表示无上标）
- 为[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)设置一些文本，然后将其添加到段落的部分集合中。
- 创建一个新的段落对象以保存下标文本，并将其添加到ITextFrame的IParagraphs集合中。
- 创建一个新的部分对象
- 将Escapement属性设置为0到-100之间以添加下标。（0表示无下标）
- 为[Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)设置一些文本，然后将其添加到段落的部分集合中。
- 将演示文稿保存为PPTX文件。

上述步骤的实现如下所示。

```java
// 实例化一个表示PPTX的Presentation类
Presentation pres = new Presentation();
try {
    // 获取幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 创建文本框
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // 为上标文本创建段落
    IParagraph superPar = new Paragraph();

    // 创建常规文本的部分
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // 创建上标文本的部分
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // 为下标文本创建段落
    IParagraph paragraph2 = new Paragraph();

    // 创建常规文本的部分
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // 创建下标文本的部分
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // 将段落添加到文本框中
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```