---
title: Exporting Math Equations
type: docs
weight: 30
url: /nodejs-java/exporting-math-equations/

---

## Exporting Math Equations from Presentations

Aspose.Slides for Java allows you to export math equations from presentations. For example, you may need to extract the mathematical equations on slides (from a specific presentation) and use them in another program or platform. 

{{% alert color="primary" %}} 

You can export equations to MathML, a popular format or standard for mathematical equations and similar content seen on the web and in many applications. 

{{% /alert %}}

While humans easily write the code for some equation formats like LaTeX, they struggle to write the code for MathML because the latter is meant to be generated automatically by apps. Programs read and parse MathML easily because its code is in XML, so MathML is commonly used as an output and printing format in many fields. 

This sample code shows you how to export a math equation from a presentation to MathML:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
        var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.add(new  aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new  aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new  aspose.slides.MathematicalText("c").setSuperscript("2")));
        var stream = java.newInstanceSync("java.io.FileOutputStream", "mathml.xml");
        mathParagraph.writeAsMathMl(stream);
    } catch (e) {
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

