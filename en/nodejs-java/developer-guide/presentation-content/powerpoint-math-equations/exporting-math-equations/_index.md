---
title: Export Math Equations from Presentations in JavaScript
linktitle: Export Equations
type: docs
weight: 30
url: /nodejs-java/exporting-math-equations/
keywords:
- export math equations
- export equations to LaTeX
- PowerPoint to LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Export math equations from PowerPoint presentations to LaTeX or MathML directly with Aspose.Slides for Node.js via Java."
---

## **Introduction**

Aspose.Slides allows you to export math equations from presentations. For example, you may need to extract the mathematical equations on slides (from a specific presentation) and use them in another program or platform. 

{{% alert color="primary" %}} 

You can export equations directly to LaTeX or to MathML, a popular standard for mathematical content used on the web and in many applications.

{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides can convert a PowerPoint math equation directly to LaTeX; an intermediate MathML file and an external converter are not required. A math equation is stored in a text frame as a [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/). Use [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) to get a [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/), and then call [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex--). The method returns a string that you can save, display, send to another application, or process further.

The following example examines every text frame on every slide, finds all math portions, and writes each equation to a separate `.tex` file:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) returns all text frames found on a slide. The [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) type check separates genuine editable equations from ordinary text and images.

LaTeX engines and document templates do not all support the same commands, packages, or Unicode characters. Test the returned string with the LaTeX engine used by your application. If a symbol or Office Math element has no suitable representation in that environment, replace it in the returned string with a project-specific command or skip the equation and record the issue for review.

## **Save Math Equations as MathML**

While humans easily write the code for some equation formats like LaTeX, they struggle to write the code for MathML because the latter is meant to be generated automatically by apps. Programs read and parse MathML easily because its code is in XML, so MathML is commonly used as an output and printing format in many fields. 

This sample code shows you how to export a math equation from a presentation to MathML:

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

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

You can export either an entire math paragraph ([MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)) or an individual block ([MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)) to MathML. Both types provide a method to write to MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

A formula lives in a [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) and has a [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). Images and regular text portions without a [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) are not exportable formulas.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

The export targets standard MathML (XML). Aspose uses Presentation MathML—the presentation subset of the standard—which is widely used across applications and the web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Yes, if those objects contain text portions with a [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) (i.e., genuine PowerPoint formulas), they are exported. If a formula is embedded as an image, it is not.

**Does exporting to MathML modify the original presentation?**

No. Writing MathML is a serialization of the formula’s content; it does not modify the presentation file.
