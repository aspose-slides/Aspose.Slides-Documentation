---
title: تصدير المعادلات الرياضية
type: docs
weight: 30
url: /ar/nodejs-java/exporting-math-equations/
---

## **تصدير المعادلات الرياضية من العروض التقديمية**

يتيح لك Aspose.Slides for Node.js عبر Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المماثل الذي يُرى على الويب وفي العديد من التطبيقات. 
{{% /alert %}}

بينما يستطيع البشر كتابة الكود بسهولة لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخيرة تُستَهدف لتُولد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن كودها في XML، لذا تُستخدم MathML عادةً كتنسيق للإخراج والطباعة في العديد من المجالات. 

يعرض لك هذا الكود النموذجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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


## **الأسئلة الشائعة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**  
يمكنك تصدير إما فقرة رياضية بالكامل ([MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)) إلى MathML. توفر كلا النوعين طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن عنصرًا ما على الشريحة هو صيغة رياضية بدلاً من نص عادي أو صورة؟**  
توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). الصور وأجزاء النص العادي التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**  
يستهدف التصدير MathML القياسي (XML). يستخدم Aspose Presentation MathML—الجزء المتعلق بالعروض من المعيار—وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**  
نعم، إذا احتوت تلك العناصر على أجزاء نصية تحتوي على [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا تم تضمين صيغة كصورة، فلن يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**  
لا. كتابة MathML هي تسلسل لمحتوى الصيغة؛ ولا تعدل ملف العرض التقديمي.