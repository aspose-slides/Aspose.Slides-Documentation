---
title: 在 JavaScript 中从演示文稿导出数学公式
linktitle: 导出公式
type: docs
weight: 30
url: /zh/nodejs-java/exporting-math-equations/
keywords:
- 导出数学公式
- 导出公式为 LaTeX
- PowerPoint 转 LaTeX
- MathML
- LaTeX
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（通过 Java）直接将 PowerPoint 演示文稿中的数学公式导出为 LaTeX 或 MathML。"
---
## **简介**

Aspose.Slides 允许您从演示文稿中导出数学公式。例如，您可能需要提取幻灯片（来自特定演示文稿）上的数学公式，并在其他程序或平台中使用它们。

{{% alert color="primary" %}} 
您可以直接将公式导出为 LaTeX 或 MathML，后者是 Web 和许多应用程序中使用的流行数学内容标准。
{{% /alert %}}

## **将数学公式导出为 LaTeX**

Aspose.Slides 可以将 PowerPoint 数学公式直接转换为 LaTeX；无需中间 MathML 文件或外部转换器。数学公式以 [MathPortion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathportion/) 的形式存储在文本框中。使用 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) 获取 [MathParagraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathparagraph/)，随后调用 [MathParagraph.toLatex](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathparagraph/#toLatex--)。该方法返回一个字符串，您可以保存、显示、发送到其他应用程序或进一步处理。

以下示例遍历每张幻灯片上的所有文本框，查找所有数学段落，并将每个公式写入单独的 `.tex` 文件：

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) 返回幻灯片上找到的所有文本框。[MathPortion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathportion/) 类型检查可将真正可编辑的公式与普通文本和图像区分开来。

LaTeX 引擎和文档模板并非都支持相同的命令、包或 Unicode 字符。请使用您的应用程序所使用的 LaTeX 引擎测试返回的字符串。如果某个符号或 Office Math 元素在该环境中没有合适的表示，请在返回的字符串中用项目特定的命令替换，或跳过该公式并记录问题以供审查。

## **将数学公式保存为 MathML**

虽然人类可以轻松编写诸如 LaTeX 等某些公式格式的代码，但编写 MathML 代码却比较困难，因为后者通常由应用程序自动生成。程序能够轻松读取和解析 MathML，因为其代码采用 XML 编写，因此 MathML 在许多领域被广泛用作输出和打印格式。

以下示例代码演示如何将演示文稿中的数学公式导出为 MathML：

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

**导出到 MathML 的究竟是段落还是单个公式块？**

您可以将整个数学段落（[MathParagraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathparagraph/)）或单个块（[MathBlock](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathblock/)）导出为 MathML。两种类型都提供写入 MathML 的方法。

**如何判断幻灯片上的对象是数学公式而不是普通文本或图像？**

公式存在于 [MathPortion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathportion/) 中，并拥有 [MathParagraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathparagraph/)。没有 [MathParagraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathparagraph/) 的图像和普通文本部分不是可导出的公式。

**演示文稿中的 MathML 来自哪里——是 PowerPoint 特有的还是标准的？**

导出目标是标准 MathML（XML）。Aspose 使用的是 Presentation MathML——标准的演示子集，已在各类应用和 Web 中广泛使用。

**是否支持导出表格、SmartArt、组合等内部的公式？**

是的，只要这些对象包含带有 [MathParagraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/mathparagraph/) 的文本部分（即真正的 PowerPoint 公式），就会被导出。如果公式以图像形式嵌入，则不会导出。

**导出为 MathML 会修改原始演示文稿吗？**

不会。写入 MathML 只是对公式内容的序列化，不会修改演示文稿文件。