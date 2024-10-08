---
title: 导出数学方程
type: docs
weight: 30
url: /zh/androidjava/exporting-math-equations/

---

## 从演示文稿中导出数学方程

Aspose.Slides for Android via Java 允许您从演示文稿中导出数学方程。例如，您可能需要提取幻灯片上的数学方程（来自特定的演示文稿）并在另一个程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将方程导出为 MathML，一种流行的数学方程及类似内容的格式或标准，在网络和许多应用程序中都可以看到。 

{{% /alert %}}

尽管人类可以轻松编写某些方程格式的代码，如 LaTeX，但他们在编写 MathML 的代码时却感到困难，因为后者是为了由应用程序自动生成。程序可以轻松读取和解析 MathML，因为其代码是 XML 格式，因此 MathML 通常被用作许多领域的输出和打印格式。

以下示例代码展示了如何将数学方程从演示文稿导出为 MathML：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```