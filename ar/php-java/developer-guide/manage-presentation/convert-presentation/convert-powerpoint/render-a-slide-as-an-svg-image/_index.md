---
title: قم بعرض شريحة كصورة SVG
type: docs
weight: 50
url: /php-java/render-a-slide-as-an-svg-image/
---

SVG—اختصار لرسومات المتجهات القابلة للتغيير—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. تخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

تُعد SVG واحدة من القليل من التنسيقات للصور التي تلبي معايير عالية جداً في هذه الجوانب: القابلية للتغيير، التداخل، الأداء، الوصول، البرمجة، وغيرها. لهذه الأسباب، يتم استخدامها عادةً في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي في *تنسيق كبير جداً*.** يمكن أن تتسلم صور SVG إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عدة مرات كما هو مطلوب دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة***. يمكن لمعظم القراء تفسير ملفات SVG.
- **استخدام *أصغر أحجام ممكنة من الصور***. تكون ملفات SVG عموماً أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، خاصة تلك التنسيقات المعتمدة على صورة نقطية (JPEG أو PNG).

تتيح لك Aspose.Slides لـ PHP عبر Java تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

1. إنشاء مثيل من فئة Presentation.
2. التكرار عبر جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG خاص بها من خلال FileOutputStream.

{{% alert color="primary" %}}

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides لـ PHP عبر Java.

{{% /alert %}}

تظهر لك هذه الشفرة النموذجية كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:

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