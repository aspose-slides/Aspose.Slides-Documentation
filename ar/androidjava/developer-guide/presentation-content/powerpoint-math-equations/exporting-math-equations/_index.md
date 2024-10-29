---
title: تصدير المعادلات الرياضية
type: docs
weight: 30
url: /ar/androidjava/exporting-math-equations/

---

## تصدير المعادلات الرياضية من العروض التقديمية

تتيح لك Aspose.Slides لنظام Android عبر Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية من الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتويات المماثلة المُشاهدَة على الويب وفي العديد من التطبيقات. 

{{% /alert %}}

بينما يكتب البشر بسهولة الشيفرة لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يكافحون لكتابة الشيفرة لـ MathML لأن هذا الأخير من المفترض أن يتولد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وت解析 MathML بسهولة لأن شيفرته مكتوبة بصيغة XML، لذا فإن MathML يُستخدم عادة كتنسيق للإخراج والطباعة في العديد من المجالات.

تظهر لك هذه الشيفرة المثال كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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