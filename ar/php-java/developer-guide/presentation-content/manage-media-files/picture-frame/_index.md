---
title: إدارة إطارات الصور في العروض التقديمية باستخدام PHP
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مدمجة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- اقتصاص صورة
- حذف المناطق المقتصة
- ضغط صورة
- StretchOffset
- تنسيق إطار صورة
- مقياس نسبي
- تأثير صورة
- نسبة أبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتنسيق وربط واقتصاص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مصدر الصورة والشكل الذي يعرضها كائنات منفصلة: الـ[العرض التقديمي](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) يمتلك موارد الصور المضمَّنة عبر الـ[مجموعة الصور](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/)، بينما يتحكم الـ[إطار الصورة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوران والاقتصاص وتأثيرات الصورة وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما يتم عرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بالـ[PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) المسترجعة، واستخدم ذلك المصدر عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور متجهة SVG. كما يمكنها الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مدمجة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/). تصبح الصورة جزءًا من حزمة العرض، لذا يبقى العرض مكتملًا عندما يُنقل إلى حاسوب آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغير أبعاد البكسل الأصلية المخزنة في مصدر الصورة المدمج. هذا التمييز يصبح مهمًا عند اقتصاص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

يُظهر الـ[PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/setrelativescalewidth/) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/setrelativescaleheight/). القيمة `1.0` تمثل 100 % من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يعيد تشكيل أو ضغط الصورة المدمجة.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تُخزّن بيانات الصورة داخل العرض وبالتالي تُعد الخيار الأكثر أمانًا للقدرة على النقل والعرض المتناسق. الصورة المرتبطة تُخزن موقعًا خارجيًا عبر طريقة [Picture::setLinkPathLong](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/setlinkpathlong/) بدلاً من دمج بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو نُقل الملف أو أصبح المورد غير متوفر، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المدمجة عادةً أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمَج عمدًا في هذا المثال.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: PPTX صغير يحتوي على اعتمادات صور مكسورة يكون عادةً أقل فائدة من عرض تقديمي مكتمل أكبر.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض تقديمي موجود، تحقق من أن الشكل هو فعلاً [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مدمجة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

يستخدم API الصورة الحديث الـ[IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

الحفظ عبر [IImage::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/#save) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوَّل، استخدم بيانات المصدر الثنائي للصورة.

### **استخراج صورة SVG**

لصورة SVG، يُظهر الـ[PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/). يتيح لك ذلك استرداد بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولاً.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

الحفاظ على محتوى SVG كـ SVG يحفظ المصدر المتجهي داخل العرض. تصدير النقطية مثل PNG أو JPEG يضرّ بالضرورة المحتوى المتجهي إلى بكسلات. تصدير الشريحة كـ PDF أو SVG هو أيضًا عملية عرض، لذا لا يجب التعامل مع الرسومات المصدَّرة كنسخة byte‑for‑byte من SVG المدمج؛ استخدم بيانات [SvgImage::getSvgData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/getsvgdata/) المدمجة عندما يكون المورد المتجهي الأصلي مطلوبًا.

## **اقتصاص صورة**

يغيّر الاقتصاص الجزء المرئي من الصورة داخل الإطار. قيم الاقتصاص على [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف الاقتصاص البكسلات المخفية من الصورة المدمجة في البداية؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتصاص:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من إمكانية العكس، يمكن إزالة المناطق المقتصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقتصة**

يُزيل [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) بيانات الصورة خارج مستطيل الاقتصاص الحالي ويُعيد مورد الصورة الناتج. يمكن أن يقلل ذلك من حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تكون البكسلات التي أُزيلت متاحة لعملية إلغاء الاقتصاص لاحقًا.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا في إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقتصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحوِّل النتيجة المقتصة إلى PNG.

## **ضغط الصور النقطية**

يُقلل [PictureFillFormat::compressImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) دقة الصورة النقطية بالنسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقتصة في نفس العملية. تُعيد الطريقة `true` عندما تم تغيير حجم الصورة أو اقتصاصها و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturescompression/) المحددة مسبقًا عندما تكون دقة الهدف القياسية كافية:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

يمكن تمرير قيمة DPI موجبة مخصصة بدلًا من القيمة المحددة مسبقًا عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتافايل بهذه العملية. تذكّر أيضًا أن الدقة المنخفضة والمناطق المقتصة المحذوفة لا يمكن استعادتها من العرض المُحسَّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض فيه الصورة فعليًا أو يُصدَّر، لا بتطبيق أقل DPI عالميًا.

## **فحص تأثيرات الصورة**

تُخزن تأثيرات الصورة على الصورة المستخدمة في الإطار. يمكن أن تحتوي مجموعة تحويلات الصورة على تأثيرات مثل تعديل ألفا ثابت للشفافية والسطوع للإنارة والتباين. يقرأ المثال أدناه كلا النوعين من التأثيرات بأمان من أول إطار صورة على شريحة:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

هذه التأثيرات تُغيّر طريقة عرض الصورة في الإطار؛ لا تُعيد كتابة بايتات الصورة المدمجة الأصلية.

## **قفل هندسة إطار الصورة**

تتحكم إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/) في عمليات التحرير التي تُعطل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) يحافظ على نسبة أبعاد الشكل أثناء تغيير حجمه.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة تشكيل أو تغيير دائم لنفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تُحدد قيم الـ stretch‑offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) مستطيل الملء بالنسبة لصندوق حدود إطار الصورة. النسب المئوية الإيجابية تُنشئ تقليلًا من الحافة، بينما النسب السالبة تُنشئ توسيعًا.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تحدد أي جزء من الصورة المصدر يُظهر؛ قيم الـ stretch‑offset تُغيّر المستطيل الذي يُتمدد فيه ملء الصورة المرئي.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

استخدم قيم الـ stretch‑offset لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المدمجة** تجعل العرض مكتملًا وتُعد الأكثر موثوقية للمشاركة والعرض على الخادم، ولكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على صغر حجم الحزمة، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **الاقتصاص** غير مدمر في البداية. تظل البكسلات المخفية مدمجة حتى يتم حذف المناطق المقتصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل ملحوظ للصور النقطية الضخمة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تظل كـ SVG عندما تكون الحفاظ على المتجهات مهمًا. استخرج الـ SVG المدمج مباشرةً عندما تحتاج إلى المورد المتجهي ذاته. تصدير الشرائح كصورة نقطية دائمًا يحول الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** يجب إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) الموجود عندما يكون ذلك ممكنًا بدلًا من تحميل نفس الملف مرارًا وتكرارًا في سير عمل العرض.

للعروض الكبيرة، عادةً ما تكون تحسينات الصور أكثر فاعلية عندما تُجرى انتقائيًا: احتفظ بالشعارات والرسوم التخطيطية كمحتوى متجهي، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، احذف البكسلات المقتصة فقط عندما لا يكون التحرير لاحقًا مطلوبًا، وتجنب الروابط الخارجية إلا إذا كان إدارة الاعتمادات جزءًا من تصميم النشر.

## **الأسئلة الشائعة**

**ما الفرق بين إطار الصورة ومصدر الصورة؟**

يمثل [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) مصدر صورة مرتبط بالعرض. أما [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) فهو شكل على شريحة يعرض صورة ويخزن إعدادات الإطار مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقلLocks.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض قابلًا للنقل، أرشفة، أو عرضًا دون الوصول إلى موارد خارجية. اربط الصور فقط عندما يكون إبقاء ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تخفي أجزاء من الصورة المصدر لكنها تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) أو ضغط الصورة مع إزالة المناطق المقتصة عندما يمكن التخلص من تلك البكسلات نهائيًا.

**هل يمكنني استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقتصة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يلزم تحرير عالي الدقة لاحقًا.

**كيف ينبغي التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج الـ [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) المدمج مباشرةً. تحويل شريحة إلى تنسيق نقطي مثل PNG أو JPEG يحول SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكنني تجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `java_instanceof` مقابل [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) يمنع التحويلات غير الصالحة ويسمح للكود بمعالجة الشرائح التي لا تحتوي على إطارات صورة.