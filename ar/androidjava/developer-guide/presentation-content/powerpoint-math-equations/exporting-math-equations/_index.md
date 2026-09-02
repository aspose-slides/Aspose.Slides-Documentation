---
title: "تصدير المعادلات الرياضية من العروض التقديمية على Android"
linktitle: "تصدير المعادلات"
type: docs
weight: 30
url: /ar/androidjava/exporting-math-equations/
keywords:
  - "تصدير المعادلات الرياضية"
  - "تصدير المعادلات إلى LaTeX"
  - "PowerPoint إلى LaTeX"
  - "MathML"
  - "LaTeX"
  - "PowerPoint"
  - "عرض تقديمي"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "تصدير المعادلات الرياضية من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرة باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **مقدمة**

تتيح لك Aspose.Slides لنظام Android عبر Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.

{{% /alert %}}

## **تصدير المعادلات الرياضية إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة رياضية في PowerPoint مباشرة إلى LaTeX؛ لا حاجة إلى ملف MathML وسيط أو إلى محول خارجي. يتم تخزين المعادلة الرياضية في إطار نص كـ [IMathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/). استخدم [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathparagraph/)، ثم استدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathparagraph/#toLatex--). تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها بصورة إضافية.

المثال التالي يفحص كل إطار نصي في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) يُرجع جميع إطارات النص الموجودة في شريحة. فحص النوع عبر [IMathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/) يفصل بين المعادلات القابلة للتحرير الحقيقية والنصوص العادية والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعها نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المرجعة باستخدام محرك LaTeX الذي تستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في تلك البيئة، استبدله في السلسلة المرجعة بأمر خاص بالمشروع أو تخطَ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ المعادلات الرياضية كـ MathML**

بينما يستطيع البشر كتابة شفرة بعض صيغ المعادلات مثل LaTeX بسهولة، يواجهون صعوبة في كتابة شفرة MathML لأن الأخيرة يُقصد بها أن تُولد تلقائياً بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شفرتها في XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يعرض لك هذا المثال البرمجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا في شريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathportion/) ولها [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/). الصور والأجزاء النصية العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار عام؟**

يستهدف التصدير MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء العرضي من المعيار—والذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**

نعم، إذا احتوت تلك الكائنات على أجزاء نصية تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا تم تضمين الصيغة كصورة، فلن تُصدر.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي تسلسل لمحتوى الصيغة؛ ولا تُعدِّل ملف العرض التقديمي.