---
title: تحويل شرائح العرض التقديمي إلى صور في PHP
linktitle: الشريحة إلى صورة
type: docs
weight: 35
url: /ar/php-java/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى EMF
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى صورة نقطية
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT و PPTX و ODP إلى PNG و JPEG و GIF و TIFF و EMF وغيرها من صيغ الصور في PHP باستخدام Aspose.Slides."
---
## **المقدمة**

يمكن لـ Aspose.Slides for PHP عبر Java عرض الشرائح الفردية من عروض PowerPoint و OpenDocument كصيغ PNG و JPEG و GIF و TIFF وغيرها من صيغ الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. قم بتحميل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) .
2. اختر الشريحة التي تريد عرضها.
3. إذا لزم الأمر، قم بتهيئة العرض باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/) أو الفئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/) .
4. استدعِ الطريقة [Slide::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage). تُعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) .
5. استدعِ الطريقة [IImage::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/#save) وحدد صيغة الإخراج باستخدام قيمة من نوع [ImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/) .

## **تحويل شريحة إلى صورة PNG**

أبسط طريقة تحويل تستخدم إعدادات العرض الافتراضية. يمكن معالجة كائن [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) الناتج في الذاكرة أو حفظه إلى ملف.

مثال PHP التالي يعرض الشريحة الأولى ويحفظها كصورة PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم التحميل الزائد للطريقة [Slide::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage) الذي يقبل قيمة [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) لعرض شريحة بأبعاد بكسلية دقيقة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040 بكسل:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

افتراضيًا، لا تشمل صور الشرائح الملاحظات أو التعليقات. مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notescommentslayoutingoptions/) إلى الطريقة [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع ملاحظات مقصوصة أسفل الشريحة وتعليقات إلى يمينها:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
لتحويل الشرائح إلى صور، لا تُمرّر [BottomFull](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notespositions/) إلى الطريقة [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). قد تحتوي الملاحظات على نص أكثر مما يمكن لحجم الصورة الثابت استيعابه. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notespositions/) بدلاً من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

تتيح لك الفئة [TiffOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tiffoptions/) التحكم في الحجم والدقة وغيرها من خصائص صورة TIFF المُعَدَّة.

المثال التالي يعرض الشريحة الأولى كصورة TIFF بحجم 2160 × 2880 بكسل وعلى 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
دعم TIFF غير مضمون في إصدارات Java الأقدم من JDK 9.
{{% /alert %}}

## **تحويل جميع الشرائح إلى صور**

قم بالتجول عبر مجموعة الشرائح لتحويل العرض الكامل إلى سلسلة من الصور. تُضمن الشرائح المخفية ما لم تقم بتخطيها صراحة.

المثال التالي يعرض كل شريحة كصورة JPEG بعامل تكبير أفقي ورأسي قدره 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **إنشاء إخراج Enhanced Metafile**

يُعد Enhanced Metafile (EMF) مفيدًا عندما يجب تبادل الرسومات القائمة على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات الميتا. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهية التي تتوسع دون فقدان الحدة. ومع ذلك، فإن EMF هو أساسًا تنسيق توافق لتطبيقات تدعم ملفات ميتا Windows، وليس تنسيق تبادل عالمي. بالإضافة إلى ذلك، قد يتم تخزين محتوى الشرائح المعقد، مثل الصور النقطية وبعض التأثيرات، كعناصر مُرصّصة داخل حاوية ملف الميتا المتجهي.

### **تصدير شريحة إلى EMF**

تكتب الطريقة [Slide::writeAsEmf](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#writeAsEmf) شريحة إلى تدفق هدف بصيغة EMF. المثال التالي يحمل عرضًا، يختار الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

المستدعي يمتلك التدفق الممرّر إلى [Slide::writeAsEmf](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#writeAsEmf) وهو مسؤول عن إغلاقه، كما هو موضح أعلاه.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض**

استخدم [SvgImage::writeAsEmf](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/#writeAsEmf) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [ImageCollection::addImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/#addImage) ووضعها على شريحة باستخدام [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/#addPictureFrame).

المثال التالي ينشئ كائن [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) من ترميز SVG، يحوله إلى EMF داخل الذاكرة، يدرج ملف الميتا على الشريحة الأولى، ويحفظ العرض:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

طريقة [SvgImage::writeAsEmf](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/#writeAsEmf) لا تتملك تدفق الوجهة. يُخزّن [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) جميع البيانات المُولَّدة في الذاكرة، لذا لا يلزم إعادة ضبط الموضع قبل استدعاء `toByteArray`. يظل مصفوفة البايتات المُرجعة صالحة بعد إغلاق التدفق.

إن توليد EMF متاح على أنظمة التشغيل المدعومة من قبل Aspose.Slides for PHP عبر Java وإعداد JDK المختار، لكن قد يختلف العرض عبر المنصات عندما تكون الخطوط أو تبعيات الرسومات غير متوفرة. قم بتثبيت الخطوط المستخدمة في المحتوى الأصلي أو اضبط البدائل المناسبة، اتبع [متطلبات المنصة](/slides/ar/php-java/system-requirements/) لـ Aspose.Slides for PHP عبر Java، وتحقق من النتيجة في التطبيق المستهلك لـ EMF. غالبًا ما تكون تطبيقات Linux و macOS ذات دعم محدود أو غير متسق لعرض وتحرير ملفات ميتا Windows.

## **عرض رموز الإيموجي الملونة**

{{% alert title="Note" color="info" %}}
لعرض رموز الإيموجي الملونة بشكل صحيح عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الإيموجي المستخدمة في العرض وتوافرها على النظام الذي يجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخط غير موجودة، قد تظهر الإيموجي بالأبيض والأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides عرض الشرائح مع الحركات؟**

لا. الطريقة [Slide::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getImage) تُنتج صورة ثابتة للشريحة ولا تصدر الحركات.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن عرض الشرائح المخفية مثل الشرائح العادية. قم بتضمينها في حلقة المعالجة، كما هو موضح في المثال أعلاه.

**هل تُحافظ صور الشرائح على الظلال وغيرها من التأثيرات؟**

نعم. تقوم Aspose.Slides بعرض الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.