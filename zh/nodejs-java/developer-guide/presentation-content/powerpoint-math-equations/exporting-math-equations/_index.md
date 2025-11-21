---
title: 导出数学公式
type: docs
weight: 30
url: /zh/nodejs-java/exporting-math-equations/
---

## **从演示文稿导出数学公式**

Aspose.Slides for Node.js via Java 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片（特定演示文稿）上的数学公式，并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 
您可以将公式导出为 MathML，这是一种在网络和许多应用程序中常见的数学公式及类似内容的流行格式或标准。 
{{% /alert %}}

虽然人类可以轻松编写像 LaTeX 这样的某些公式格式的代码，但他们在编写 MathML 代码时会遇到困难，因为后者旨在由应用程序自动生成。程序能够轻松读取和解析 MathML，因为其代码采用 XML，因此 MathML 在许多领域常被用作输出和打印格式。

以下示例代码展示了如何将演示文稿中的数学公式导出为 MathML：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**到底是导出段落还是单个公式块到 MathML？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)）导出为 MathML。这两种类型都提供了写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 中，并拥有一个 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来源是什么——是 PowerPoint 特有的还是标准？**

导出目标是标准的 MathML（XML）。Aspose 使用演示文稿 MathML——该标准的演示子集，广泛用于各种应用程序和网络。

**是否支持导出表格、SmartArt、组等内部的公式？**

是的，如果这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) 的文本部分（即真实的 PowerPoint 公式），它们将被导出。如果公式以图片形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。