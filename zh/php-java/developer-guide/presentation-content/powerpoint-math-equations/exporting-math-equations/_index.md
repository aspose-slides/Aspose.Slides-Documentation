---
title: 从 PHP 导出演示文稿中的数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/php-java/exporting-math-equations/
keywords:
- 导出数学公式
- 导出公式到 LaTeX
- PowerPoint 到 LaTeX
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将 PowerPoint 演示文稿中的数学公式直接导出为 LaTeX 或 MathML。"
---
## **介绍**

Aspose.Slides for PHP via Java 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片（特定演示文稿）中的数学公式，并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 

您可以将公式直接导出为 LaTeX 或 MathML，后者是一种在网络和许多应用中使用的流行数学内容标准。

{{% /alert %}}

## **导出数学公式为 LaTeX**

Aspose.Slides 可以将 PowerPoint 数学公式直接转换为 LaTeX；无需中间的 MathML 文件或外部转换器。数学公式存储在文本框中，形式为 [MathPortion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathportion/)。使用 [MathPortion::getMathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathportion/#getMathParagraph) 获取 [MathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/)，然后调用 [MathParagraph::toLatex](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/#toLatex)。该方法返回一个字符串，您可以保存、显示、发送到其他应用程序或进一步处理。

以下示例检查每张幻灯片上的每个文本框，查找所有数学部分，并将每个公式写入单独的 `.tex` 文件：

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideutil/#getAllTextBoxes) 返回在幻灯片上找到的所有文本框。[MathPortion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathportion/) 类型检查将真正可编辑的公式与普通文本和图像区分开来。

LaTeX 引擎和文档模板并非都支持相同的命令、宏包或 Unicode 字符。请使用您应用程序所使用的 LaTeX 引擎对返回的字符串进行测试。如果某个符号或 Office Math 元素在该环境中没有合适的表示，请在返回的字符串中用项目特定的命令替换，或跳过该公式并记录问题以供审查。

## **将数学公式保存为 MathML**

虽然人们可以轻松编写 LaTeX 等某些公式格式的代码，但编写 MathML 的代码却比较困难，因为 MathML 通常由应用程序自动生成。程序可以轻松读取和解析 MathML，因为它的代码是 XML，故 MathML 在许多领域常被用作输出和打印格式。

下面的示例代码演示了如何将演示文稿中的数学公式导出为 MathML：

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

## **FAQ**

**导出到 MathML 的到底是段落还是单个公式块？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathblock/)）导出为 MathML。两种类型均提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathportion/) 中，并拥有一个 [MathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来源是什么——是特定于 PowerPoint 还是一个标准？**

导出目标是标准 MathML（XML）。Aspose 使用的是 Presentation MathML——该标准的呈现子集，已在众多应用和网络中广泛使用。

**是否支持导出表格、SmartArt、组合等中的公式？**

是的，如果这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），则会被导出。若公式以图像形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 是对公式内容的序列化，不会修改演示文稿文件。