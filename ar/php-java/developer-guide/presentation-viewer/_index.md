---
title: إنشاء عارض عروض تقديمية في PHP
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/php-java/presentation-viewer/
keywords:
- عرض عرض تقديمي
- عارض العروض التقديمية
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء عارض عروض تقديمية مخصص باستخدام Aspose.Slides لـ PHP عبر Java. عرض ملفات PowerPoint و OpenDocument بسهولة دون الحاجة إلى Microsoft PowerPoint."
---

يُستخدم Aspose.Slides لـ PHP عبر Java لإنشاء ملفات عروض تقديمية تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في مثل هذه الحالات، يتيح Aspose.Slides تصدير شريحة فردية كصورة. تصف هذه المقالة كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض تقديمي باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. احصل على مرجع الشريحة بحسب رقمها.
1. افتح تدفق ملف.
1. احفظ الشريحة كصورة SVG إلى تدفق الملف.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **إنشاء SVG بمعرّف شكل مخصص**

يمكن استخدام Aspose.Slides لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرّف شكل مخصص. للقيام بذلك، استخدم الطريقة `setId` من [SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/). يمكن استخدام `CustomSvgShapeFormattingController` لتعيين معرّف الشكل.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```

```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **إنشاء صورة مصغرة لشريحة**

يساعدك Aspose.Slides على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. احصل على مرجع الشريحة بحسب رقمها.
1. احصل على الصورة المصغرة للشريحة المرجعية بمقياس محدد.
1. احفظ الصورة المصغرة بأي تنسيق صورة ترغب فيه.
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **إنشاء صورة مصغرة لشريحة بأبعاد يحددها المستخدم**

لإنشاء صورة مصغرة لشريحة بأبعاد يحددها المستخدم، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. احصل على مرجع الشريحة بحسب رقمها.
1. احصل على الصورة المصغرة للشريحة المرجعية بالأبعاد المحددة.
1. احفظ الصورة المصغرة بأي تنسيق صورة ترغب فيه.
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **إنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/).
1. استخدم الطريقة `RenderingOptions.setSlidesLayoutOptions` لتعيين موضع ملاحظات المتحدث.
1. إنشاء كائن من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. احصل على مرجع الشريحة بحسب رقمها.
1. احصل على الصورة المصغرة للشريحة المرجعية مع خيارات العرض.
1. احفظ الصورة المصغرة بأي تنسيق صورة ترغب فيه.
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **مثال حي**

يمكنك تجربة التطبيق المجاني [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) لمعرفة ما يمكنك تنفيذه باستخدام Aspose.Slides API:

![عارض PowerPoint عبر الإنترنت](online-PowerPoint-viewer.png)

## **الأسئلة الشائعة**

**هل يمكنني تضمين عارض عروض تقديمية في تطبيق ويب؟**

نعم. يمكنك استخدام Aspose.Slides على الخادم لتوليد الشرائح كصور أو HTML وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير مع JavaScript لتجربة تفاعلية.

**ما هي الطريقة الأفضل لعرض الشرائح داخل عارض مخصص؟**

النهج الموصى به هو توليد كل شريحة كصورة (مثل PNG أو SVG) أو تحويلها إلى HTML باستخدام Aspose.Slides، ثم عرض الناتج داخل صندوق صورة (لسطح المكتب) أو حاوية HTML (للويب).

**كيف أتعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

للعروض الكبيرة، يُنصح بالتحميل الكسول أو توليد الشرائح عند الطلب. هذا يعني توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.