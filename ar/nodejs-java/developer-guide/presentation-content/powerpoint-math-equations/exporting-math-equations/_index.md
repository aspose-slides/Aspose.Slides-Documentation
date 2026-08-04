---
title: تصدير المعادلات الرياضية من العروض التقديمية بلغة JavaScript
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/nodejs-java/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تصدير المعادلات الرياضية من عروض PowerPoint إلى LaTeX أو MathML مباشرة باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **المقدمة**

تتيح لك Aspose.Slides تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="primary" %}}يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.{{% /alert %}}

## **تصدير المعادلات الرياضية إلى LaTeX**

Aspose.Slides يمكنه تحويل معادلة رياضية في PowerPoint مباشرة إلى LaTeX؛ لا يلزم ملف MathML وسيط ولا محول خارجي. تُخزن المعادلة الرياضية في إطار نصي كـ [MathPortion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathportion/). استخدم [MathPortion.getMathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) للحصول على [MathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/)، ثم استدعِ [MathParagraph.toLatex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/#toLatex--). تُرجع الطريقة سلسلة يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها لاحقًا.

المثال التالي يفحص كل إطار نصي في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) تُرجع جميع إطارات النص الموجودة في الشريحة. تحقق النوع [MathPortion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathportion/) يفصل المعادلات القابلة للتحرير الحقيقية عن النص العادي والصور.

لا تدعم جميع محركات LaTeX وقوالب المستندات نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المُرجعة باستخدام محرك LaTeX الذي يستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في ذلك البيئة، استبدله في السلسلة المُرجعة بأمر مخصص للمشروع أو تجاهل المعادلة وسجّل المشكلة للمراجعة.

## **حفظ المعادلات الرياضية كـ MathML**

في حين أن البشر يمكنهم كتابة الشيفرة بسهولة لبعض صيغ المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الشيفرة لـ MathML لأن الأخيرة تُصمم لتُولَّد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شيفرتها في XML، لذا يُستخدم MathML غالبًا كصيغة إخراج وطباعة في العديد من المجالات. 

يُظهر لك هذا الكود التجريبي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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

## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**  
يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathblock/)) إلى MathML. كلا النوعين يوفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا في الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**  
توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/). الصور وأجزاء النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**  
يستهدف التصدير معيار MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء التقديمي من المعيار—وهو مُستخدم على نطاق واسع في التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات، إلخ؟**  
نعم، إذا احتوت تلك الكائنات على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، يتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلا يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**  
لا. كتابة MathML هي تسلسل لمحتوى الصيغة؛ ولا تُغيّر ملف العرض التقديمي.