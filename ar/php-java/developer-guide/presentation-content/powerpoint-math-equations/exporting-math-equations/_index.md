---
title: تصدير المعادلات الرياضية
type: docs
weight: 30
url: /ar/php-java/exporting-math-equations/

---

## تصدير المعادلات الرياضية من العروض

يتيح لك Aspose.Slides لـ PHP عبر Java تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية ومحتوى مشابه يُرى على الويب وفي العديد من التطبيقات. 

{{% /alert %}}

بينما يكتب البشر بسهولة كود لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة كود لـ MathML لأن الأخير مصمم ليتم توليده تلقائياً بواسطة التطبيقات. تقرأ البرامج وتحلل MathML بسهولة لأن كوده في XML، لذا يتم استخدام MathML عادة كتنسيق للإخراج والطباعة في العديد من المجالات.

يوضح لك هذا الكود المثال كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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