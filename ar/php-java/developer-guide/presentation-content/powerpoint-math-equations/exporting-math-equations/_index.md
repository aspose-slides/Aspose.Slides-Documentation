---
title: تصدير المعادلات الرياضية من العروض التقديمية في PHP
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/php-java/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides للـ PHP عبر Java — الحفاظ على التنسيق وتعزيز التوافق."
---

## **تصدير المعادلات الرياضية من العروض التقديمية**

Aspose.Slides for PHP عبر Java يتيح لك تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المشابه الذي يُرى على الويب وفي العديد من التطبيقات. 

{{% /alert %}}

في حين أن البشر يكتبون الكود بسهولة لبعض صيغ المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخير يُقصد أن يتم إنشاؤه تلقائيًا بواسطة التطبيقات. التطبيقات تقرأ وتُحلل MathML بسهولة لأن كوده مكتوب بصيغة XML، لذا يُستخدم MathML عادةً كتنسيق إخراج وطباعة في العديد من المجالات. 

يظهر هذا المثال البرمجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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


## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة منفردة؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)) أو كتلة منفردة ([MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)) إلى MathML. كلا النوعين يوفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة تكمن في [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) وتحتوي على [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). الصور وأقسام النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار عام؟**

هدف التصدير هو MathML القياسي (XML). Aspose يستخدم Presentation MathML—الجزء الفرعي من المعيار المتعلق بالعروض التقديمية—والذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يُدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات، إلخ؟**

نعم، إذا كانت تلك الكائنات تحتوي على أقسام نصية مع [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلن يتم تصديرها.

**هل modifies تصدير إلى MathML العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُعدّل ملف العرض التقديمي.