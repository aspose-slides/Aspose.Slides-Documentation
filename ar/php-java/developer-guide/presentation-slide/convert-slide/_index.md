---
title: تحويل شرائح العروض التقديمية إلى صور في PHP
linktitle: الشريحة إلى صورة
type: docs
weight: 35
url: /ar/php-java/convert-slide/
keywords:
- تحويل الشريحة
- تصدير الشريحة
- الشريحة إلى صورة
- حفظ الشريحة كصورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى bitmap
- الشريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحويل الشرائح من PPT وPPTX وODP إلى صور باستخدام Aspose.Slides for PHP عبر Java — تحويل سريع وعالي الجودة مع أمثلة شفرة واضحة."
---

## **نظرة عامة**

تمكنك Aspose.Slides for PHP via Java من تحويل شرائح PowerPoint وOpenDocument إلى صيغ صور متنوعة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. عرّف إعدادات التحويل المطلوبة وحدد الشرائح التي تريد تصديرها باستخدام:
    - الفئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)، أو
    - الفئة [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) .
2. أنشئ صورة الشريحة عن طريق استدعاء طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) .

في Aspose.Slides for PHP via Java، تُعد الفئة [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) فئة تُتيح لك العمل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الفئة لحفظ الصور بصيغ متعددة (BMP وJPG وPNG وغيرها).

## **تحويل الشرائح إلى صور نقطية وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل الشريحة إلى bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة أخرى تفضلها.

يوضح هذا الكود كيفية تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap ثم حفظ الصورة بصيغة PNG:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // حفظ الصورة بصيغة PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام أحد إصدارات طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يوضح هذا المثال كيفية القيام بذلك:
```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى كائن bitmap بالحجم المحدد.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // حفظ الصورة بصيغة JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides فئتين[TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) و[RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/)—تسمحان لك بالتحكم في تحويل شرائح العرض إلى صور. كلا الفئتين تتضمنان طريقة `setSlidesLayoutOptions`، والتي تمكنك من ضبط طريقة عرض الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد موضعك المفضل للملاحظات والتعليقات في الصورة الناتجة.

يوضح هذا الكود كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:
```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // تحديد موضع الملاحظات.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // تحديد موضع التعليقات.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // تحديد عرض مساحة التعليقات.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // تحديد لون مساحة التعليقات.

    // إنشاء خيارات الإخراج.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // تحويل الشريحة الأولى من العرض إلى صورة.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // حفظ الصورة بصيغة GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


{{% alert title="Note" color="warning" %}} 

في أي عملية تحويل من شريحة إلى صورة، لا يمكن لطريقة [setNotesPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) تطبيق `BottomFull` (لتحديد موضع الملاحظات) لأنه قد يكون نص الملاحظة كبيرًا جدًا ولا يستطيع أن يتناسب مع حجم الصورة المحدد.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر فئة [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) تحكمًا أكبر في الصورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم والدقة ولوحة الألوان وغيرها.

يوضح هذا الكود عملية تحويل حيث تُستخدم خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 DPI وحجم 2160 × 2800:
```php
// تحميل ملف عرض تقديمي.
$presentation = new Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض التقديمي.
    $slide = $presentation->getSlides()->get_Item(0);

    // تهيئة إعدادات صورة TIFF الناتجة.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // تحديد حجم الصورة.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // تحديد تنسيق البكسل (أبيض وأسود).
    $options->setDpiX(300);                                              // تحديد الدقة الأفقية.
    $options->setDpiY(300);                                              // تحديد الدقة العمودية.
    
    // تحويل الشريحة إلى صورة باستخدام الخيارات المحددة.
    $image = $slide->getImage($options);
    try {
        // حفظ الصورة بصيغة TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```


{{% alert title="Note" color="warning" %}} 

دعم TIFF غير مضمون في الإصدارات الأقدم من JDK 9.

{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

تمكنك Aspose.Slides من تحويل جميع الشرائح في عرض تقديمي إلى صور، مما يجعل من الممكن تحويل العرض بأكمله إلى سلسلة من الصور.

يوضح هذا المثال كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام PHP:
```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // تحويل العرض التقديمي إلى صور شريحة بشريحة.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // التحكم في الشرائح المخفية (عدم تحويل الشرائح المخفية).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // تحويل الشريحة إلى صورة.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // حفظ الصورة بصيغة JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**هل تدعم Aspose.Slides تحويل الشرائح التي تحتوي على رسوم متحركة؟**

لا، طريقة `getImage` تحفظ صورة ثابتة فقط للشفرة، دون أي رسوم متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية مثل الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور بظلال وتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال والشفافية وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.