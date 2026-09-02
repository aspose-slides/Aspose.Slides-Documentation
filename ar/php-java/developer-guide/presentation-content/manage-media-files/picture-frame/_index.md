---
title: إدارة إطارات الصور في العروض التقديمية باستخدام PHP
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/php-java/picture-frame/
keywords:
- إطار الصورة
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
- StretchOffset
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
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنات منفصلة: يمتلك كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) موارد الصور المضمنة عبر [ImageCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/)، بينما يتحكم كائن [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوارة والقص وتأثيرات الصورة وغيرها من إعدادات المستوى الإطاري.

هذا الفصل مفيد عندما تُعرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) المرجعي، واستخدم هذا المورد عند إنشاء إطارات الصورة.

يمكن لإطارات الصورة احتواء صور نقطية مثل PNG أو JPEG وصور SVG متجهة. كما يمكنها الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مدمجة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/). تصبح الصورة جزءًا من حزمة العرض، لذا يظل العرض مكتفٍ ذاتيًا عندما يُنقل إلى كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوارة:

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

إطار الصورة يتحكم في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمج. يصبح هذا التمييز مهمًا عند قص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

[PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) يعرض توسيع العرض والارتفاع النسبي للإطار عبر [setRelativeScaleWidth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/setrelativescalewidth/) و[setRelativeScaleHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/setrelativescaleheight/). القيمة `1.0` تمثل 100 % من حجم الصورة الأصلي. يكون المقياس النسبي مفيدًا عندما تحتاج سيرورة العمل إلى الحفاظ على علاقة مع حجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يعيد أخذ العينات أو ضغط الصورة المدمجة.

## **الصور المضمنة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض، وبالتالي تُعد الخيار الأكثر أمانًا للنقل والعرض المتوقع. الصورة المرتبطة تخزن موقعًا خارجيًا عبر طريقة [Picture::setLinkPathLong](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/setlinkpathlong/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل اعتمادًا خارجيًا. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو نُقل الملف أو أصبح المورد غير متاح، قد لا تُعرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المدمجة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: عادةً ما يكون PPTX صغير مع تبعيات صور مكسورة أقل فائدة من عرض مكتفٍ ذاتيًا أكبر.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تحقق من أن الشكل فعليًا هو [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) وأنه يحتوي على صورة مدمجة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

تستخدم واجهة برمجة تطبيقات الصورة الحديثة [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/#save) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

لصورة SVG، يعرّف [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) كائنًا من نوع [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/). يتيح لك هذا استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولاً.

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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. الصادرات النقطية مثل PNG أو JPEG تُعيد بالضرورة تمثيل ذلك المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المصدرة نسخة بايتية مطابقة تمامًا للـ SVG المدمج الأصلي؛ استخدم بيانات [SvgImage::getSvgData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/getsvgdata/) المدمجة عندما تكون الحاجة إلى المورد المتجه ذاته.

## **قص صورة**

يغيّر القص أي جزء من الصورة يُظهر داخل الإطار. قيم القص على [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد صورة المصدر. لا يحذف القص في البداية البكسلات المخفية من الصورة المدمجة؛ فهو يغيّر فقط المنطقة المرئية.

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير القص لاحقًا دون فقد البكسلات الأصلية. إذا كان حجم الملف أهم من قابلية العكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) يزيل بيانات الصورة خارج مستطيل القص الحالي ويُعيد مورد الصورة الناتج. يمكن لهذا أن يقلل من حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تصبح البكسلات المزالة متاحة لإجراء إلغاء القص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا بواسطة إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا لا يؤدي حذف المناطق المقصوصة بالضرورة إلى تقليل إجمالي عدد الصور. قص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقصوصة إلى PNG نقطيًا.

## **ضغط الصور النقطية**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) يقلل من دقة الصورة النقطية نسبةً إلى الحجم الذي تُعرض عليه الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في نفس العملية. تُعيد الطريقة `true` عندما يُعاد تحجيم الصورة أو تُقص، وتُعيد `false` عندما لا تكون هناك حاجة إلى تغيير.

استخدم قيمة مسبقة التعريف من [PicturesCompression](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturescompression/) عندما تكون دقة الهدف القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلًا من القيمة المسبقة عندما يكون هدف محدد مطلوبًا.

الضغط مُصمم للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتافيلي بهذه العملية. تذكر أيضًا أن الدقة المنخفضة والمناطق المقصوصة المحذوفة لا يمكن استعادتها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض أو تُصدّر فيه الصورة فعليًا بدلاً من تطبيق أدنى DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات اللون، الضبابية، تأثيرات الشفافية، السلاسل المرتبة، الفحص، الإزالة، والتحقق من دورة الحياة، راجع [تأثيرات تحويل الصورة](/slides/ar/php-java/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/) تتحكم في عمليات التحرير التي تُعطّل لإطار الصورة. على سبيل المثال، [setAspectRatioLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) يحافظ على نسب الشكل أثناء إعادة حجمه.

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

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ العينات أو تغيير دائم لنفس نسبة الأبعاد.

## **تعديل قيم StretchOffset**

عند كون وضع تعبئة الصورة هو "stretch"، تحدد قيم stretch-offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) مستطيل التعبئة نسبةً إلى الصندوق المحيط لإطار الصورة. النسب المئوية الموجبة تُنشئ مسافة داخلية من الحافة، بينما النسب السالبة تُنشئ مسافة خارجية.

هذا مختلف عن القص. قيم القص تحدد أي جزء من صورة المصدر يُظهر؛ قيم stretch-offset تغير المستطيل الذي تُمدد إليه تعبئة الصورة المرئية.

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

استخدم stretch offsets لتحديد موضع التعبئة. استخدم خصائص القص عندما يكون الهدف إخفاء حواف صورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المفاضلات الرئيسية أسهل في الإدارة عندما يُعامل تخزين الصور وتنسيق إطارات الصور بصورة منفصلة:

- **الصور المدمجة** تجعل العرض مكتفٍ ذاتيًا وهي الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغر حجم الحزمة، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **القص** في البداية غير مدمر. تظل البكسلات المخفية مدمجة حتى يتم حذف المناطق المقصوصة صراحة أو إزالتها أثناء الضغط.
- **الضغط** يمكنه تقليل حجم الملف بشكل كبير للصور النقطية ذات الأحجام الكبيرة، لكنه يزيل دقة المصدر. يُطبق بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تظل كـ SVG عندما تكون المحافظة على المتجهي مهمًا. استخرج SVG المدمج مباشرةً عندما تحتاج إلى المورد المتجه نفسه. تصدير الشرائح إلى PNG أو JPEG يُحول دائمًا الـ SVG إلى بكسلات.
- **الصور المتكررة** يجب إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) الموجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا في سير عمل العرض.

للعروض الكبيرة، يكون تحسين الصور عادةً أكثر فاعلية عندما يُطبق انتقائيًا: حافظ على الشعارات والمخططات كمحتوى متجه، اضغط الصور الفوتوغرافية وفق حجم العرض الفعلي، أزل البكسلات المقصوصة فقط عندما لا تكون هناك حاجة لتحرير لاحق، وتجنب الروابط الخارجية ما لم تكن إدارة الاعتماد جزءًا من تصميم النشر.

## **الأسئلة الشائعة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) يمثل مورد صورة مرتبط بالعرض. [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة وإعدادات الإطار مثل الحجم، الدوران، قيم القص، التأثيرات، والقُفل.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يحتاج العرض إلى أن يكون قابلًا للنقل، مؤرشفًا, أو مُعرضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما تكون إزالة ملفات الصور من PPTX مقصودة ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تخفي أجزاء من صورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) أو الضغط مع إزالة المناطق المقصوصة عندما يمكن التخلص من هذه البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. يمكن للضغط أن يقلل من دقة الصورة المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يُحتاج إلى تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

ابقِ محتوى SVG كـ SVG عندما تكون الدقة المتجهية مهمة. يمكن استخراج [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) المدمج مباشرةً. عرض الشريحة إلى تنسيق نقطي مثل PNG أو JPEG يحوِّل الـ SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء إطار الصورة. فحص `java_instanceof` ضد [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) يجنب التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي على إطارات صور.