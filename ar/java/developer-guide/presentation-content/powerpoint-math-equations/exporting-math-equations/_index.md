---
title: تصدير المعادلات الرياضية
type: docs
weight: 30
url: /java/exporting-math-equations/

---

## تصدير المعادلات الرياضية من العروض التقديمية

تتيح لك Aspose.Slides لـ Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية من الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المماثل الذي يُرى على الويب وفي العديد من التطبيقات.

{{% /alert %}}

بينما يكتب البشر بسهولة الكود لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخير مصمم ليتم توليده تلقائيًا بواسطة التطبيقات. تقرأ البرامج وت解析 MathML بسهولة لأن كوده في XML، لذا يُستخدم MathML بشكل شائع كتنسيق للإخراج والطباعة في العديد من المجالات.

يوضح لك هذا الكود النموذجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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