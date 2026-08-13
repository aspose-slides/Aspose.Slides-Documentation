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
- MathML
- LaTeX
- PowerPoint
- "عرض تقديمي"
- Android
- Java
- Aspose.Slides
description: "تصدير المعادلات الرياضية من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرة باستخدام Aspose.Slides لنظام Android عبر Java."
---
## **المقدمة**

تتيح لك Aspose.Slides لنظام Android عبر Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="info" %}} 
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير المعادلات الرياضية إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة رياضية في PowerPoint مباشرة إلى LaTeX؛ لا يلزم ملف MathML وسيط ولا محول خارجي. تُخزن المعادلة الرياضية في إطار نص كـ [IMathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/). استخدم [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathparagraph/)، ثم استدعِ [IMathParagraph.toLatex](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathparagraph/#toLatex--). تُعيد الطريقة سلسلة يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها لاحقًا.

المثال التالي يفحص كل إطار نص في كل شريحة، ويجد جميع أجزاء الرياضيات، ويكتب كل معادلة إلى ملف `.tex` منفصل:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) يُعيد كل إطارات النص الموجودة في الشريحة. يُميّز فحص النوع [IMathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imathportion/) المعادلات القابلة للتحرير الحقيقية عن النص العادي والصور.

لا تدعم جميع محركات LaTeX وقوالب المستندات نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المُعادَة باستخدام محرك LaTeX الذي يستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في ذلك البيئة، استبدله في السلسلة بأمر مخصص للمشروع أو تخطَ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ المعادلات الرياضية كـ MathML**

بينما يمكن للبشر كتابة الشيفرة لبعض صيغ المعادلات مثل LaTeX بسهولة، يواجهون صعوبة في كتابة الشيفرة لـ MathML لأن الأخيرة تُقصد لتُولد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شيفرتها في XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يعرض لك هذا الكود النموذجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**ما الذي يتم تصديره إلى MathML بالضبط—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/)) أو كتلة صيغة فردية ([MathBlock](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathblock/)) إلى MathML. كلتا النوعين توفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

توجد الصيغة في [MathPortion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/). الصور وأجزاء النص العادي التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خصيصة لـ PowerPoint أم معيار عام؟**

يستهدف التصدير MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء التقديمي من المعيار—وهو مستخدم على نطاق واسع في التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**

نعم، إذا احتوت تلك الكائنات على أجزاء نصية تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا تم تضمين الصيغة كصورة، فلن يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي تسلسل لمحتوى الصيغة؛ ولا تُعدِّل ملف العرض التقديمي.