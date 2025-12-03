---
title: تصدير المعادلات الرياضية من العروض التقديمية في جافا
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/java/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides for Java — الحفاظ على التنسيق وتعزيز التوافق."
---

## تصدير المعادلات الرياضية من العروض التقديمية

تتيح لك Aspose.Slides for Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المشابه الذي يُرى على الويب وفي العديد من التطبيقات. 
{{% /alert %}}

في حين أن البشر يكتبون الكود بسهولة لبعض صيغ المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخيرة تُقصد أن تُولد تلقائيًا بواسطة التطبيقات. تقوم البرامج بقراءة وتحليل MathML بسهولة لأن كوده مكتوب بصيغة XML، لذا يُستخدم MathML عادةً كتنسيق إخراج وطباعة في العديد من المجالات.

هذا المثال يوضح كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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


## **الأسئلة الشائعة**

**ما الذي يتم تصديره إلى MathML بالضبط—فقرة أم كتلة صيغة منفردة؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)) أو كتلة منفردة ([MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)) إلى MathML. كلا النوعين يوفر طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة توجد داخل [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). الصور وأجزاء النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

يستهدف التصدير MathML القياسي (XML). تستخدم Aspose نسخة العرض التقديمي من MathML—وهي جزء من المعيار يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يُدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات إلخ؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية بها [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلن يتم تصديرها.

**هل ي modifies تصدير إلى MathML العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُغيّر ملف العرض التقديمي.