---
title: تحويل شرائح العرض التقديمي إلى صور SVG في PHP
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- عرض الشريحة
- تحويل الشريحة
- تصدير الشريحة
- صورة متجهة
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides للـ PHP عبر Java. رسومات عالية الجودة مع أمثلة شفرة بسيطة."
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومي قياسي يُستخدم لتصيير الصور ثنائيّة الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من التنسيقات للصور التي تلبي معايير عالية جداً فيما يتعلق بالقابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذه الأسباب يُستخدم عادةً في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقدّمي بصيغة *كبيرة جداً*.** يمكن للصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تعديل حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانيّة من شرائحك في *وسائط أو منصات مختلفة***. معظم القارئات يمكنها تفسير ملفات SVG. 
- **استخدام *أصغر أحجام ممكنة للصور***. عادةً ما تكون ملفات SVG أصغر من نظيراتها ذات الدقة العالية في تنسيقات أخرى، خصوصاً تلك المستندة إلى البت ممّابس (JPEG أو PNG).

## **عرض شريحة كصورة SVG**

Aspose.Slides for PHP عبر Java يتيح لك تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

1. أنشئ مثيلاً من الفئة Presentation.
2. تكرَّر عبر جميع الشرائح في العرض التقديمي.
3. اكتب كل شريحة إلى ملف SVG خاص بها عبر FileOutputStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفّذنا فيه وظيفة تحويل PPT إلى SVG باستخدام Aspose.Slides for PHP عبر Java.

{{% /alert %}} 

يعرض لك هذا المثال البرمجي كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**لماذا قد يبدو SVG الناتج مختلفاً بين المتصفحات؟**

يتم تنفيذ دعم ميزات SVG المحددة بطرق مختلفة بواسطة محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) في تخفيف عدم التوافق.

**هل يمكن تصدير ليس فقط الشرائح بل أيضاً الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [shape كملف SVG منفصل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)، وهو ما يُسهّل استخدامه للأيقونات، والرسوم التوضيحية، وإعادة استعمال الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُنفَّذ على مستوى التطبيق.