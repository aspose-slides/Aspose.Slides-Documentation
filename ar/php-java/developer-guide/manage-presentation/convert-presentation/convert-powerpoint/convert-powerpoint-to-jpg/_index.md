---
title: تحويل ملفات PPT و PPTX إلى JPG في PHP
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
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG ذات جودة عالية في PHP باستخدام Aspose.Slides للـ PHP مع أمثلة شفرة سريعة وموثوقة."
---

## **حول تحويل PowerPoint إلى JPG**

مع [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. كما يمكنك أيضًا تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. باستخدام هذه الميزات يصبح من السهل تنفيذ عارض العروض الخاص بك، وإنشاء صورة مصغرة لكل شريحة. قد يكون هذا مفيدًا إذا كنت تريد حماية شرائح العرض من النسخ، أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة معينة إلى صيغ صور.

{{% alert color="primary" %}} 
لمشاهدة كيفية تحويل Aspose.Slides لملفات PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
فيما يلي الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء نسخة من النوع [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. إنشاء صورة مصغرة لكل شريحة ثم تحويلها إلى JPG. تُستخدم طريقة [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) للحصول على صورة مصغرة للشريحة، وتُعيد كائن [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) كنتيجة. يجب استدعاء طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من النوع [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)، حيث يتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، استدعِ طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. مرّر اسم الملف الناتج وصيغة الصورة إليها.

{{% alert color="primary" %}}
**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى الأنواع الأخرى في Aspose.Slides API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم طريقة [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)، لكن هنا تحتاج إلى طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)). 
{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # ينشئ صورة بمقياس كامل
      $slideImage = $sld->getImage(1.0, 1.0);
      # يحفظ الصورة على القرص بتنسيق JPEG
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
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و *ScaleY* بتمريرهما إلى طرق [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-).

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # يعرّف الأبعاد
    $desiredX = 1200;
    $desiredY = 800;
    # يحصل على القيم المقاسة لـ X و Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # ينشئ صورة بمقياس كامل
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # يحفظ الصورة على القرص بتنسيق JPEG
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
يوفر Aspose.Slides للـ PHP عبر Java ميزة تتيح لك عرض التعليقات في شرائح العرض عند تحويل تلك الشرائح إلى صور. يوضح هذا الكود PHP العملية:

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
Aspose يقدم تطبيق ويب [FREE Collage](https://products.aspose.app/slides/collage) مجاني. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم هذه الطريقة التحويل على دفعات؟**
نعم، يتيح Aspose.Slides التحويل الجماعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية وغيرها من الكائنات المعقدة؟**
نعم، يقوم Aspose.Slides بعرض جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. ومع ذلك، قد تختلف دقة العرض قليلًا مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**
لا يفرض Aspose.Slides نفسه أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور ذات دقة عالية.

## **انظر أيضًا**

انظر خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/).