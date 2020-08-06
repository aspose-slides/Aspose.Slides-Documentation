---
title: Aspose.Slides for Android via Java 20.7 Release Notes
type: docs
weight: 70
url: /java/aspose-slides-for-android-via-java-20-7-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for Aspose.Slides for Android via Java 20.7

{{% /alert %}} 

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESANDROID-241|[Use Aspose.Slides for Java 20.7 features](/slides/java/aspose-slides-for-java-20-7-release-notes/)|Enhancement|

## **Public API Changes**

### **Exporting mathematical equations to MathML format**

[**IMathParagraph.writeAsMathMl**](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IMathParagraph#writeAsMathMl-java.io.OutputStream-) and [**IMathBlock.writeAsMathMl**](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/IMathBlock#writeAsMathMl-java.io.OutputStream-) methods have been added. You can use them to export a mathematical paragraph or block to MathML format. The presentation MathML markup is used.


{{< highlight java >}}
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").setSuperscript("2").join("+").join(new MathematicalText("b").setSuperscript("2")).join("=").join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = null;
    try {
        stream = new FileOutputStream("mathml.xml");
        mathParagraph.writeAsMathMl(stream);
    } finally {
        if (stream != null) stream.close();
    }
} finally {
    if (pres != null) pres.dispose();
}
{{< /highlight >}}

Contents of the resulting file:
```
<math display='block' xmlns="http://www.w3.org/1998/Math/MathML">
    <mrow>
        <msup>
            <mi>a</mi>
            <mn>2</mn>
        </msup>
        <mo>+</mo>
        <msup>
            <mi>b</mi>
            <mn>2</mn>
        </msup>
        <mo>=</mo>
        <msup>
            <mi>c</mi>
            <mn>2</mn>
        </msup>
    </mrow>
</math>
```

### **New method iteratorJava() has been added to MathBlock and MathParagraph**

A new **iteratorJava()** method has been added to [**MathBlock**](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock#iteratorJava--) and [**MathParagraph**](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph#iteratorJava--) classes.

This method allows to get an iterator that is fully complied with the Java Iterator logic.

