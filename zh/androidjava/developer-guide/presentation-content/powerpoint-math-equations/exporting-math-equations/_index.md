---
title: 在 Android 上从演示文稿导出数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/androidjava/exporting-math-equations/
keywords:
- 导出数学公式
- 导出公式至 LaTeX
- PowerPoint 转 LaTeX
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将 PowerPoint 演示文稿中的数学公式直接导出为 LaTeX 或 MathML。"
---
## **简介**

Aspose.Slides for Android via Java 允许您从演示文稿中导出数学公式。例如，您可能需要提取特定演示文稿中幻灯片上的数学公式，并在其他程序或平台中使用它们。

{{% alert color="info" %}} 

您可以将公式直接导出为 LaTeX 或 MathML，后者是网页和众多应用中常用的数学内容标准。

{{% /alert %}}

## **将数学公式导出为 LaTeX**

Aspose.Slides 能够将 PowerPoint 数学公式直接转换为 LaTeX；无需中间的 MathML 文件或外部转换器。数学公式存储在文本框中，作为一个 [IMathPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathportion/)。使用 [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) 获取一个 [IMathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathparagraph/)，随后调用 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathparagraph/#toLatex--)。该方法返回一个字符串，您可以保存、显示、发送至其他应用或进一步处理。

下面的示例遍历每张幻灯片上的所有文本框，查找所有数学部分，并将每个公式写入单独的 `.tex` 文件：

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) 返回幻灯片上找到的所有文本框。对 [IMathPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imathportion/) 的类型检查可以将真正可编辑的公式与普通文本和图像区分开来。

LaTeX 引擎和文档模板并不全部支持相同的命令、宏包或 Unicode 字符。请使用您应用程序所采用的 LaTeX 引擎测试返回的字符串。如果某个符号或 Office Math 元素在该环境中没有合适的表示，请在返回的字符串中用项目特定的命令替换，或跳过该公式并记录问题以供审查。

## **将数学公式保存为 MathML**

虽然人们可以轻松手写 LaTeX 等公式格式的代码，但编写 MathML 代码却比较困难，因为后者通常由应用程序自动生成。程序可以轻松读取和解析 MathML，因为其代码是 XML，所以 MathML 在许多领域被广泛用作输出和打印格式。

下面的示例代码展示了如何将演示文稿中的数学公式导出为 MathML：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **常见问题**

**究竟导出到 MathML 的是段落还是单个公式块？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathblock/)）导出为 MathML。这两种类型都提供了写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathportion/) 中，并具有一个 [MathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来自何处——是 PowerPoint 特有的还是标准的？**

导出目标是标准的 MathML（XML）。Aspose 使用 Presentation MathML——标准的呈现子集，已在各种应用和网页中广泛使用。

**是否支持导出表格、SmartArt、组等内部的公式？**

是的，只要这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），就会被导出。如果公式以图像形式嵌入，则不会被导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。