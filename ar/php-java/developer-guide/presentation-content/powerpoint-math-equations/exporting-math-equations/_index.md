---
title: تصدير المعادلات الرياضية من العروض التقديمية في PHP
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/php-java/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تصدير المعادلات الرياضية من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **المقدمة**

Aspose.Slides for PHP via Java يتيح لك تصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع لمحتوى الرياضيات يستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير المعادلات الرياضية إلى LaTeX**

Aspose.Slides يمكنه تحويل معادلة PowerPoint الرياضية مباشرة إلى LaTeX؛ لا حاجة إلى ملف MathML وسيط أو محول خارجي. تُخزن المعادلة الرياضية في إطار نص كـ [MathPortion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathportion/). استخدم [MathPortion::getMathParagraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathportion/#getMathParagraph) للحصول على [MathParagraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathparagraph/)، ثم استدعِ [MathParagraph::toLatex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathparagraph/#toLatex). تُرجع الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها لاحقًا.

المثال التالي يمر على كل إطار نص في كل شريحة، ي finds جميع أجزاء الرياضيات، ويكتب كل معادلة إلى ملف `.tex` منفصل:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/#getAllTextBoxes) تُرجع جميع إطارات النص الموجودة في الشريحة. فحص النوع [MathPortion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathportion/) يفرق بين المعادلات القابلة للتحرير الفعلية والنص العادي والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعًا نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المُسترجعة مع محرك LaTeX الذي يستخدمه تطبيقك. إذا كان هناك رمز أو عنصر Office Math لا يوجد له تمثيل مناسب في ذلك البيئة، استبدله في السلسلة بأمر مخصص للمشروع أو تخطَ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ المعادلات الرياضية كـ MathML**

بينما يستطيع البشر كتابة الكود لبعض تنسيقات المعادلات مثل LaTeX بسهولة، يواجهون صعوبة في كتابة الكود لـ MathML لأن هذا الأخير يُقصد به أن يُولَّد تلقائيًا بواسطة التطبيقات. البرامج تقرأ وتُحلل MathML بسهولة لأن كوده مبني على XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات.

هذا البرنامج العيني يُظهر لك كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الأسئلة الشائعة**

**ما ما يتم تصديره إلى MathML بالضبط - فقرة أم كتلة صيغة فردية؟**  
يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathblock/)) إلى MathML. كلا النوعين يوفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على شريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**  
الصيغة توجد داخل [MathPortion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathparagraph/). الصور وأقسام النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي - هل هو خاص بـ PowerPoint أم معيار؟**  
يستهدف التصدير معيار MathML القياسي (XML). Aspose يستخدم Presentation MathML - الجزء المتعلق بالعرض من المعيار - وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**  
نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية بها [MathParagraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فإنها تُصدر. إذا كانت الصيغة مدمجة كصورة، فإنها لا تُصدر.

**هل ي modifies تصدير إلى MathML العرض التقديمي الأصلي؟**  
لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ لا تُغيّر ملف العرض التقديمي الأصلي.