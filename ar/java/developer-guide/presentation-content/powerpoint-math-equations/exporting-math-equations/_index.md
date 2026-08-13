---
title: تصدير معادلات الرياضيات من العروض التقديمية بلغة Java
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
description: "تصدير معادلات الرياضيات من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides لــ Java."
---
## **المقدمة**

تتيح لك Aspose.Slides تصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="info" %}} 
يمكنك تصدير المعادلات مباشرةً إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير معادلات الرياضيات إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة رياضية في PowerPoint مباشرةً إلى LaTeX؛ لا يلزم ملف وسيط MathML ولا محول خارجي. تُخزن المعادلة الرياضية في إطار نصي كـ[IMathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/). استخدم[IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/#getMathParagraph--) للحصول على[IMathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathparagraph/)، ثم استدعِ[IMathParagraph.toLatex](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathparagraph/#toLatex--) . تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها بصورة أخرى.

المثال التالي يفحص كل إطار نصي في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة إلى ملف `.tex` منفصل:

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) تُرجع جميع الأطر النصية الموجودة في الشريحة. فحص النوع [IMathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imathportion/) يفصل بين المعادلات القابلة للتحرير الحقيقية والنص العادي والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعًا نفس الأوامر أو الحزم أو الأحرف Unicode. اختبر السلسلة المُعادة باستخدام محرك LaTeX الذي يستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في ذلك البيئة، استبدله في السلسلة بأمر مخصص للمشروع أو تخطَ المعادلة وسجل المشكلة للمراجعة.

## **حفظ معادلات الرياضيات كـ MathML**

بينما يكتب البشر بسهولة الشفرة لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الشفرة لـ MathML لأن الأخير يُقصد به أن يُنشأ تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شفرته في XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يعرض هذا الكود المثال كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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

## **الأسئلة المتكررة**

**ما ما يُصدَّر بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما الفقرة الرياضية الكاملة ([MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة موجودة في [MathPortion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/). الصور والنصوص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/) لا يمكن تصديرها كصيغ.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

يتم التصدير إلى MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء المتعلق بالتقديم من المعيار—والذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يُدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات إلخ؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فإنها تُصدّر. إذا تم تضمين الصيغة كصورة، فلن تُصدّر.

**هل تعديل العرض التقديمي الأصلي يحدث عند تصدير إلى MathML؟**

لا. كتابة MathML هي مجرد تسلسل لمحتوى الصيغة؛ ولا تُغيّر ملف العرض التقديمي الأصلي.