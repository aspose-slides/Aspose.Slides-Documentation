---
title: تحويل شرائح العرض التقديمي إلى صور في PHP
linktitle: شريحة إلى صورة
type: docs
weight: 35
url: /ar/php-java/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى Bitmap
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحويل الشرائح من PPT وPPTX وODP إلى صور باستخدام Aspose.Slides for PHP عبر Java — تصوير سريع وعالي الجودة مع أمثلة شفرة واضحة."
---
## **مقدمة**

تمكنك Aspose.Slides for PHP عبر Java من تحويل شرائح عروض PowerPoint وOpenDocument بسهولة إلى صيغ صور مختلفة، بما في ذلك BMP وPNG وJPG (JPEG) وGIF وغيرها.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حدد إعدادات التحويل المطلوبة واختر الشرائح التي تريد تصديرها باستخدام:
    - الفئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/) أو
    - الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/) .
2. أنشئ صورة الشريحة عن طريق استدعاء الطريقة [getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage).

في Aspose.Slides for PHP عبر Java، تُعد فئة [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) فئة تتيح لك التعامل مع الصور المعرفة ببيانات البكسل. يمكنك استخدام هذه الفئة لحفظ الصور بمجموعة واسعة من الصيغ (BMP، JPG، PNG، إلخ).

## **تحويل الشرائح إلى صور نقطية وحفظ الصور بصيغة PNG**

يمكنك تحويل شريحة إلى كائن Bitmap واستخدامه مباشرة في تطبيقك. بدلاً من ذلك، يمكنك تحويل شريحة إلى Bitmap ثم حفظ الصورة بصيغة JPEG أو أي صيغة مفضلة أخرى.

يظهر هذا المثال كيفية تحويل الشريحة الأولى في العرض التقديمي إلى كائن Bitmap ثم حفظ الصورة بصيغة PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية.
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

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام نسخة مُحمَّلة من الطريقة [getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage)، يمكنك تحويل شريحة إلى صورة بأبعاد محددة (العرض والارتفاع).

يعرض هذا المثال البرمجي كيفية القيام بذلك:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // تحويل الشريحة الأولى في العرض التقديمي إلى صورة نقطية بالحجم المحدد.
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

## **تحويل الشرائح التي تحتوي على ملاحظات وتعليقات إلى صور**

قد تحتوي بعض الشرائح على ملاحظات وتعليقات.

توفر Aspose.Slides فئتين [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/) و[RenderingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/) تسمحان بالتحكم في تحويل شرائح العرض التقديمي إلى صور. تتضمن كلتا الفئتين طريقة `setSlidesLayoutOptions`، التي تمكنك من تكوين تحويل الملاحظات والتعليقات على الشريحة عند تحويلها إلى صورة.

باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notescommentslayoutingoptions/)، يمكنك تحديد الموضع المفضل للملاحظات والتعليقات في الصورة الناتجة.

يظهر هذا المثال كيفية تحويل شريحة تحتوي على ملاحظات وتعليقات:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // تعيين موضع الملاحظات.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // تعيين موضع التعليقات.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // تحديد عرض منطقة التعليقات.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // تحديد اللون لمنطقة التعليقات.

    // إنشاء خيارات التصيير.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // تحويل الشريحة الأولى من العرض التقديمي إلى صورة.
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

في أي عملية تحويل شريحة إلى صورة، لا يجوز للطريقة [setNotesPosition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) تطبيق القيمة `BottomFull` (لتحديد موضع الملاحظات) لأن نص الملاحظة قد يكون كبيرًا جدًا، مما يجعله غير قادر على الالتحاق بالحجم المحدد للصورة.

{{% /alert %}} 

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

توفر الفئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/) تحكمًا أكبر في صورة TIFF الناتجة من خلال السماح لك بتحديد معلمات مثل الحجم، الدقة، لوحة الألوان، وغيرها.

يظهر هذا المثال عملية تحويل يتم فيها استخدام خيارات TIFF لإنتاج صورة بالأبيض والأسود بدقة 300 نقطة في البوصة (DPI) وحجم 2160 × 2800:

```php
// تحميل ملف عرض تقديمي.
$presentation = new Presentation("sample.pptx");
try {
    // الحصول على الشريحة الأولى من العرض التقديمي.
    $slide = $presentation->getSlides()->get_Item(0);

    // تكوين إعدادات صورة TIFF الناتجة.
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

تسمح لك Aspose.Slides بتحويل جميع الشرائح في عرض تقديمي إلى صور، مما يحول العرض التقديمي بالكامل إلى سلسلة من الصور.

يعرض هذا المثال البرمجي كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور باستخدام PHP:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // تصيير العرض التقديمي إلى صور شريحة بشريحة.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // التحكم في الشرائح المخفية (عدم تصيير الشرائح المخفية).
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

## **عرض الرموز التعبيرية الملونة**

{{% alert title="Note" color="warning" %}} 
لعرض الرموز التعبيرية الملونة بشكل صحيح عند تحويل شرائح العروض التقديمية إلى صور، يجب تثبيت خطوط الرموز التعبيرية المستخدمة في العرض وتوافرها على النظام الذي يُجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكان هذا الخط غير موجود، قد تظهر الرموز التعبيرية بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides عرض الشرائح المتحركة؟**

لا، طريقة `getImage` تحفظ فقط صورة ثابتة للشريحة، دون أي رسومات متحركة.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم، يمكن معالجة الشرائح المخفية بنفس طريقة الشرائح العادية. فقط تأكد من تضمينها في حلقة المعالجة.

**هل يمكن حفظ الصور مع الظلال والتأثيرات؟**

نعم، تدعم Aspose.Slides عرض الظلال، الشفافية، وغيرها من التأثيرات الرسومية عند حفظ الشرائح كصور.