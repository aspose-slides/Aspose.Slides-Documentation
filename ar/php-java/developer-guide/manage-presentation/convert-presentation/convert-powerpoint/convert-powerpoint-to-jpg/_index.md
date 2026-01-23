---
title: تحويل PPT و PPTX إلى JPG في PHP
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/php-java/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض التقديمي كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- PHP
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في PHP باستخدام Aspose.Slides للـ PHP مع أمثلة شيفرة سريعة وموثوقة."
---

## **حول تحويل PowerPoint إلى JPG**
مع [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. كما يمكن أيضًا تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. باستخدام هذه الميزات، يصبح من السهل تنفيذ عارض عروضك الخاص، وإنشاء المصغرات لكل شريحة. قد يكون هذا مفيدًا إذا كنت تريد حماية شرائح العرض من النسخ، أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة معينة إلى صيغ صور.

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides لعروض PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
إليك الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء مثيل من نوع [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على كائن الشريحة من نوع [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) من مجموعة [Presentation::getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. إنشاء صورة مصغرة لكل شريحة ثم تحويلها إلى JPG. تُستخدم طريقة [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) للحصول على صورة مصغرة لشريحة. يجب استدعاء طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) من الشريحة المطلوبة من نوع [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)، ويتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على صورة مصغرة للشريحة، استدعِ طريقة [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. مرّر اسم الملف الناتج وتنسيق الصورة إليها. 

{{% alert color="primary" %}}

**ملاحظة**: تحويل PPT/PPTX إلى JPG يختلف عن التحويل إلى الأنواع الأخرى في Aspose.Slides API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم طريقة [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ، ولكن هنا تحتاج إلى طريقة [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)). 

{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # ينشئ صورة بمقياس كامل
      $slideImage = $sld->getImage(1.0, 1.0);
      # يحفظ الصورة إلى القرص بتنسيق JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحويل PowerPoint PPT/PPTX إلى JPG بأبعاد مخصصة**
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و *ScaleY* بتمريرهما إلى طرق [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage). 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # يحدد الأبعاد
    $desiredX = 1200;
    $desiredY = 800;
    # يحصل على القيم المقاسة للـ X و Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # ينشئ صورة بمقياس كامل
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # يحفظ الصورة إلى القرص بتنسيق JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **عرض التعليقات عند حفظ الشرائح كصور**
يوفر Aspose.Slides لـ PHP عبر Java ميزة تتيح لك عرض التعليقات في شرائح العرض عند تحويل تلك الشرائح إلى صور. يوضح هذا الكود PHP العملية:
```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب [FREE Collage](https://products.aspose.app/slides/collage) مجاني. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وغيرها. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/); تحويل [PNG إلى JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/); تحويل [SVG إلى PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم هذا الأسلوب التحويل الدفعي؟**

نعم، يتيح Aspose.Slides تحويل دفعات من عدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية وغيرها من الكائنات المعقدة؟**

نعم، يقوم Aspose.Slides بعرض جميع المحتويات بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وأكثر. ومع ذلك، قد تختلف دقة العرض قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides نفسه أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل مع عروض تقديمية كبيرة أو صور عالية الدقة.

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:
- [تحويل PPT/PPTX إلى SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/).