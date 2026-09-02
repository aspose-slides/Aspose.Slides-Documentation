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
- قص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- إزاحة التمدد
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **Overview**

إطار الصورة هو شكل شريحة يُظهر صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنان منفصلان: يملك الـ[Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) موارد الصور المدمجة عبر الـ[ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/)، بينما يتحكم الـ[PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخط وتدويرها واقتطاعها وتأثيرات الصورة وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما تُعرض الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ[PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) الذي تم إرجاعه، واستخدم مورد الصورة هذا عند إنشاء إطارات الصورة.

يمكن لإطارات الصورة أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلًا من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على قابلية النقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **Add and Format an Embedded Image**

للصورة المدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/). تصبح الصورة جزءًا من حزمة العرض، لذا يبقى العرض مكتملًا ذاتيًا عند نقله إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، يخلق إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والتدوير:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمجة. يصبح هذا التمييز مهمًا عند اقتطاع الصورة أو ضغطها لاحقًا.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) يتيح تحديد مقياس العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/setrelativescalewidth/) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/setrelativescaleheight/). القيمة `1.0` تمثل 100 ٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

## **Embedded and Linked Images**

الصورة المدمجة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أمانًا للنقل وعرض ثابت. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [Picture::setLinkPathLong](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/setlinkpathlong/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو تم نقل الملف أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعرض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المدمجة عادةً أكثر موثوقية.

### **Add a Linked Image**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها مجرد بديل للضغط: ملف PPTX صغير به تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مكتمل ذاتيًا.

## **Extract Images from Picture Frames**

قبل استخراج صورة من عرض موجود، تحقق من أن الشكل هو فعلاً [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مدمجة. إطارات الصورة المرتبطة قد لا تحتوي على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **Extract a Raster Image**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/#save) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوّل، استخدم بيانات الصورة الثنائية بدلاً من ذلك.

### **Extract an SVG Image**

بالنسبة لصورة SVG، يُظهر [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/). يتيح لك هذا استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة أولاً إلى نقطية.

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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصديرات النقطية مثل PNG أو JPEG تُجبر على تحويل ذلك المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا يجب اعتبار الرسومات المُصدرة نسخة بايت-للبايت من SVG الأصلي؛ استخدم بيانات [SvgImage::getSvgData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/getsvgdata/) المدمجة عندما تحتاج إلى المورد المتجه الأصلي نفسه.

## **Crop an Image**

القص يغيّر أي جزء من الصورة يظهر داخل الإطار. قيم القص على [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد صورة المصدر. القص لا يحذف البكسلات المخفية من الصورة المدمجة في البداية؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم القص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **Remove Cropped Image Data**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض، لا تتوفر البكسلات التي أزيلت لعملية إلغاء القص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا في إطارات صورة أخرى، فإن تلك الإطارات لا تزال بحاجة إلى موردها الحالي، لذا حذف المناطق المقصوصة لا يقلل بالضرورة من إجمالي عدد الصور. قص محتوى WMF أو EMF بهذه الطريقة يُحوّل النتيجة المقصوصة إلى PNG.

## **Compress Raster Images**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) يقلل دقة الصورة النقطية نسبةً إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في نفس العملية. تُعيد الطريقة `true` عندما تم إعادة تحجيم أو قص الصورة و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturescompression/) مُعرفة مسبقًا عندما يكون هدف الدقة القياسي كافيًا:

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

يمكن تمرير قيمة DPI إيجابية مخصصة بدلاً من قيمة مُعرفة مسبقًا عندما يكون هناك هدف محدد مطلوب.

الضغط مخصص للصور النقطية. لا يُقلل من محتوى SVG أو ملفات الميتافايل. وتذكر أن الدقة الأقل والمناطق المقصوصة المحذوفة لا يمكن استرجاعها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض فيه الصورة فعليًا أو يُصدّر، وليس باستخدام أقل DPI على مستوى الكل.

## **Manage Image Transform Effects**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات الألوان، الضبابية، تأثيرات الألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق من الخطوة إلى الخطوة، راجع [Image Transform Effects](/php-java/image-transform-effects/).

## **Lock Picture Frame Geometry**

إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/) تتحكم في أي عمليات تحرير تُعطل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على أن تُعاد تشكيلها أو تُغيّر بشكل دائم لتتناسب مع نفس النسبة.

## **Adjust the StretchOffset Values**

عند وضع تعبئة الصورة على وضع "تمدد"، تحدد قيم stretch-offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) مستطيل التعبئة بالنسبة إلى الصندوق المحيط لإطار الصورة. النسب المئوية الإيجابية تُنشئ إدخالًا من الحافة، بينما النسب السالبة تُنشئ خروجًا.

هذا مختلف عن القص. قيم القص تحدد أي جزء من صورة المصدر يُظهر، بينما تغيّر قيم التمدد المستطيل الذي تُمتد فيه تعبئة الصورة المرئية.

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

استخدم قيم التمدد لتحديد موقع التعبئة. استخدم خصائص القص عندما يكون الهدف إخفاء حواف صورة المصدر.

## **Storage, File Size, and Export Considerations**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المدمجة** تجعل العرض مكتملًا ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض من جانب الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغر حجم الحزمة، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **القص** في البداية غير تدميري. البكسلات المخفية تبقى مدمجة حتى يتم حذف المناطق المقصوصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الكبيرة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم المقصود على الشريحة.
- **صور SVG** يجب أن تُبقى كـ SVG عندما يكون الحفاظ على المتجه مهمًا. استخرج SVG المدمج مباشرةً عندما تحتاج إلى المورد المتجه نفسه. تصدير الشرائح إلى نمط نقطي دائمًا ما يحول الشريحة إلى بكسلات.
- **الصور المتكررة** يجب أن تعيد استخدام مورد [PPImage] الموجود عندما يكون ذلك ممكنًا بدلًا من تحميل نفس الملف مرارًا وتكرارًا في سير عمل العرض.

للعروض الكبيرة، يكون تحسين الصور أكثر فاعلية عادةً عندما يُطبق انتقائيًا: حافظ على الشعارات والرسوم التخطيطية كمتجه، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، أزل البكسلات المقصوصة فقط عندما لا تكون التعديلات المستقبلية مطلوبة، وتجنب الروابط الخارجية إلا إذا كان إدارة الاعتماد جزءًا من تصميم النشر.

## **FAQ**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[PPImage] يمثل مورد صورة مرتبط بالعرض. [PictureFrame] هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، التدوير، قيم القص، التأثيرات، والقفل.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض محمولًا أو مؤرشفًا أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون إبقاء ملفات الصورة خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تُخفي أجزاء من صورة المصدر لكنها تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat::deletePictureCroppedAreas] أو ضغط الصورة مع إزالة المناطق المقصوصة عندما يمكن حذف هذه البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة النقطية المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا قد تحتاج إلى تعديل عالي الدقة لاحقًا.

**كيفية التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما يكون الحفاظ على الدقة المتجهة مهمًا. يمكن استخراج الـ[SvgImage] المدمج مباشرةً. تحويل الشريحة إلى تنسيق نقطي مثل PNG أو JPEG يُحول الـSVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكنني تجنب التحويلات غير الآمنة عند قراءة شرائح موجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. فحص `java_instanceof` ضد [PictureFrame] يجنب التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي على إطارات صورة.