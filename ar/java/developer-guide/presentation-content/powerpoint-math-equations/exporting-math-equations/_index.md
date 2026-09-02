---
title: تصدير معادلات الرياضيات من العروض التقديمية في Java
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/java/exporting-math-equations/
keywords:
- تصدير معادلات الرياضيات
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: تصدير معادلات الرياضيات من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرة باستخدام Aspose.Slides for Java.
---
## **مقدمة**

Aspose.Slides تسمح لك بتصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.

{{% /alert %}}

## **تصدير معادلات الرياضيات إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة PowerPoint الرياضية مباشرة إلى LaTeX؛ لا تحتاج إلى ملف وسطى MathML أو إلى محول خارجي. تُخزن المعادلة الرياضية في إطار نص كـ [IMathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/). استخدم [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/#getMathParagraph--) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathparagraph/)، ثم استدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathparagraph/#toLatex--). تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها بشكل إضافي.

المثال التالي يفحص كل إطار نص في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

```java
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
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) تُعيد جميع إطارات النص الموجودة في الشريحة. فحص النوع [IMathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/) يفصل المعادلات القابلة للتحرير الحقيقية عن النص العادي والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعها نفس الأوامر أو الحزم أو الأحرف اليونية. اختبر السلسلة المرجعة مع محرك LaTeX الذي يستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في تلك البيئة، استبدله في السلسلة المرجعة بأمر خاص بالمشروع أو تخطِ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ معادلات الرياضيات كـ MathML**

بينما يكتب البشر بسهولة الشيفرة لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الشيفرة لـ MathML لأن الأخير يُقصد به أن يُولد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شيفرتها في XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يُظهر لك هذا الكود العيني كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني التمييز بين كائن على الشريحة هو صيغة رياضية أم نص عادي أو صورة؟**

الصيغة توجد في [MathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/). الصور والنصوص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

تستهدف عملية التصدير MathML القياسي (XML). يستخدم Aspose Presentation MathML—الفرع العرضي من المعيار—والذي يُستَخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وغيرها؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلن تُصدَّر.

**هل تعديل التصدير إلى MathML يغيّر العرض التقديمي الأصلي؟**

لا. كتابة MathML هي تسلسل تسلسلي لمحتوى الصيغة؛ لا تُغيّر ملف العرض التقديمي.