---
title: 导出数学方程
type: docs
weight: 30
url: /zh/php-java/exporting-math-equations/

---

## 从演示文稿导出数学方程

Aspose.Slides for PHP via Java 允许您从演示文稿中导出数学方程。例如，您可能需要提取幻灯片上的数学方程（来自特定演示文稿），并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将方程导出为 MathML，这是一种流行的格式或标准，用于在网页和许多应用程序中看到的数学方程和类似内容。

{{% /alert %}}

虽然人们可以轻松地为某些方程格式（如 LaTeX）编写代码，但他们在编写 MathML 代码时会遇到困难，因为后者是为应用程序自动生成的。程序可以轻松读取和解析 MathML，因为它的代码是 XML，因此常常在许多领域用作输出和打印格式。

此示例代码演示了如何将数学方程从演示文稿导出为 MathML：

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```