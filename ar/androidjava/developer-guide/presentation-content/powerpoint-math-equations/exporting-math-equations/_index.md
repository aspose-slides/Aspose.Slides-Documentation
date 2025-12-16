---
title: تصدير المعادلات الرياضية من العروض التقديمية على Android
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/androidjava/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بتمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides لأندرويد عبر Java—احتفظ بالتنسيق وعزز التوافق."
---

## **تصدير المعادلات الرياضية من العروض التقديمية**

تسمح لك Aspose.Slides for Android via Java بتصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المماثل الذي يُرى على الويب وفي العديد من التطبيقات. 
{{% /alert %}}

بينما يكتب البشر بسهولة الكود لبعض تنسيقات المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخير يُقصد أن يتم إنشاؤه تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتفسر MathML بسهولة لأن الكود الخاص به مكتوب في XML، لذلك يُستخدم MathML عادةً كتنسيق للإخراج والطباعة في العديد من المجالات. 

يُظهر لك هذا المثال البرمجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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


## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML — فقرة أم كتلة صيغة فردية؟**  
يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**  
توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) ولها [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). الصور وأقسام النص العادي التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي — هل هو خاص بـ PowerPoint أم معيار عام؟**  
يستهدف التصدير MathML القياسي (XML). تستخدم Aspose Presentation MathML — مجموعة العرض التقديمي من المعيار — والذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول، SmartArt، المجموعات، إلخ؟**  
نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مضمنة كصورة، فلن تُصدر.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**  
لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُعدِّل ملف العرض التقديمي.