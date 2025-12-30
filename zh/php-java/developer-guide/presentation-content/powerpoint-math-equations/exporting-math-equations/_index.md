---
title: 在 PHP 中从演示文稿导出数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/php-java/exporting-math-equations/
keywords:
- 导出数学公式
- MathML
- LaTeX
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，实现从 PowerPoint 到 MathML 的无缝导出数学公式——保持格式并提升兼容性。"
---

## **从演示文稿导出数学公式**

Aspose.Slides for PHP via Java 允许您从演示文稿中导出数学公式。例如，您可能需要提取特定演示文稿中幻灯片上的数学公式，并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 
您可以将公式导出为 MathML，这是一种在 Web 和众多应用程序中常见的数学公式及类似内容的流行格式或标准。 
{{% /alert %}}

虽然人们可以轻松编写某些公式格式（如 LaTeX）的代码，但编写 MathML 代码却比较困难，因为后者通常由应用程序自动生成。程序能够轻松读取和解析 MathML，因为它的代码基于 XML，所以 MathML 在许多领域被广泛用作输出和打印格式。

下面的示例代码展示了如何将演示文稿中的数学公式导出为 MathML：
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


## **常见问题**

**到底导出到 MathML 的是段落还是单个公式块？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)）或单个公式块（[MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)）导出为 MathML。这两种类型都提供了写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图片？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) 中，并且拥有一个 [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) 的图片和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来源于哪里——是 PowerPoint 特有的还是标准的？**

导出目标是标准的 MathML（XML）。Aspose 使用的是 Presentation MathML——标准的演示子集，已在众多应用程序和 Web 中得到广泛使用。

**是否支持导出表格、SmartArt、组合等内部的公式？**

支持。如果这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），则会被导出。若公式以图片形式嵌入，则不会被导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。