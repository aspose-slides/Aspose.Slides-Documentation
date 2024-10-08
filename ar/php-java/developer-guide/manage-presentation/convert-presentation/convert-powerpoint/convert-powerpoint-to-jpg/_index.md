---
title: تحويل Powerpoint إلى JPG
type: docs
weight: 60
url: /ar/php-java/convert-powerpoint-to-jpg/
keywords: "تحويل PowerPoint إلى JPG، PPTX إلى JPEG، PPT إلى JPEG"
description: "تحويل PowerPoint إلى JPG: PPT إلى JPG، PPTX إلى JPG"
---

## **حول تحويل PowerPoint إلى JPG**
باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. من الممكن أيضًا تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. مع هذه الميزات، من السهل تنفيذ عارض العروض التقديمية الخاصة بك، وإنشاء صورة مصغرة لكل شريحة. قد يكون هذا مفيدًا إذا كنت ترغب في حماية شرائح العرض من حقوق الطبع والنشر، أو عرض العرض التقديمي في وضع عرض فقط. يسمح Aspose.Slides بتحويل العرض التقديمي بالكامل أو شريحة معينة إلى تنسيقات صور.

{{% alert color="primary" %}} 

لمعرفة كيف يقوم Aspose.Slides بتحويل PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
إليك الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء مثيل من نوع [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. إنشاء الصورة المصغرة لكل شريحة ثم تحويلها إلى JPG. تُستخدم [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) للحصول على صورة مصغرة للشريحة، تُرجع [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) ككائن كنتيجة. يجب استدعاء [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من نوع [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)، ويتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، قم باستدعاء [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. مرر اسم الملف الناتج ونوع الصورة إليه. 

{{% alert color="primary" %}}

**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى أنواع أخرى في Aspose.Slides API. بالنسبة للأنواع الأخرى، عادة ما تستخدم [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)، ولكن هنا تحتاج إلى [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)). 

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # ينشئ صورة بدقة كاملة
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
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و*ScaleY* من خلال تمريرها إلى [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) الأساليب:

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # يحدد الأبعاد
    $desiredX = 1200;
    $desiredY = 800;
    # يحصل على القيم المخصصة لـ X و Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # ينشئ صورة بدقة كاملة
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

## **رسم التعليقات عند حفظ العرض التقديمي كصورة**
توفر Aspose.Slides لـ PHP عبر Java وسيلة تسمح لك برسم التعليقات في شرائح العرض التقديمي عند تحويل تلك الشرائح إلى صور. يوضح هذا الكود PHP العملية:

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

{{% alert title="نصيحة" color="primary" %}}

توفر Aspose تطبيق ويب [مجاني للكولاج](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضًا**

راجع خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/).