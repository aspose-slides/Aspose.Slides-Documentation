---
title: تحسين إدارة الصور في العروض التقديمية باستخدام PHP
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/php-java/image/
keywords:
- إضافة صورة
- إضافة صورة
- استبدال صورة
- مجموعة الصور
- إطار صورة
- صورة مرتبطة
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- SVG إلى أشكال
- موارد SVG الخارجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إضافة الصور وإعادة استخدامها وربطها واستبدالها وإدارة الصور النقطية وSVG في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **المقدمة**

Aspose.Slides for PHP via Java يوفر عدة طرق للعمل مع الصور، وكل طريقة تخدم غرضًا مختلفًا. يمكنك تخزين صورة في العرض التقديمي، عرضها في إطار صورة، استخدامها كخلفية شريحة، ربطها بصورة خارجية، استبدال مورد صورة مشترك، أو تحويل محتوى SVG إلى أشكال قابلة للتحرير.

تركز هذه المقالة على موارد الصورة وكيفية استخدامها عبر العرض التقديمي. للتقصير، الشفافية، التأثيرات، التمدد، وتنسيقات أخرى تُطبق على إطار صورة فردي، راجع [Picture Frame](/slides/ar/php-java/picture-frame/).

## **فهم نموذج الصورة**

المفاهيم التالية في API مرتبطة ارتباطًا وثيقًا لكنها ليست قابلة للاستبدال:

- الـ[presentation image collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) يخزن موارد الصور المستخدمة في العرض التقديمي. استخدم [ImageCollection::addImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) لإضافة بيانات الصورة والحصول على مورد [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/).
- الـ[picture frame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/) هو شكل يعرض صورة على شريحة أو تخطيط أو ماستر. استخدم [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addpictureframe/) لوضع مورد صورة على شريحة.
- خلفية الشريحة تستخدم الصورة كجزء من تعبئة الشريحة بدلاً من شكل. لذلك لا تتصرف كإطار صورة.
- [PPImage::replaceImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) يستبدل مورد صورة. إذا استخدمت عدة عناصر في العرض التقديمي ذلك المورد، فإن جميعها ستستخدم الاستبدال.
- تحويل SVG إلى أشكال ينشئ أشكال شريحة قابلة للتحرير. بعد التحويل، لا يُدار المحتوى كموارد صورة واحدة.

وبالتالي فإن سير العمل النموذجي هو: إضافة بيانات الصورة إلى مجموعة الصور، الحصول على [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/)، ثم استخدام ذلك المورد في إطار صورة واحد أو أكثر أو في تعبئات.

## **إضافة صورة مدمجة**

لإدراج صورة محلية، حمّل الملف، أضفه إلى مجموعة الصور، وأنشئ إطار صورة يستخدم `PPImage` المرجع.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الصورة التي تُضاف بهذه الطريقة مدمجة في العرض التقديمي، لذا فإن الملف الناتج لا يعتمد على بقاء ملف الصورة الأصلي متاحًا.

### **إضافة صورة من الويب**

عند توفر صورة عبر HTTP أو HTTPS، قم بتنزيل بايتاتها، أضفها إلى مجموعة صور العرض التقديمي، واستخدم مورد الصورة المرجع بنفس طريقة الصورة المحلية.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في التطبيقات طويلة العمر، أعد استخدام عميل HTTP أو استراتيجية إدارة اتصالات مناسبة للتطبيق بدلاً من إنشاء بنية شبكة غير ضرورية بشكل متكرر. كما يجب التحقق من صحة عناوين URL البعيدة، أحجام الاستجابة، وأنواع المحتوى عندما يكون المصدر غير موثوق.

## **إعادة استخدام الصور عبر الشرائح**

إذا كانت هناك حاجة لاستخدام نفس الصورة أكثر من مرة، أضفها إلى العرض التقديمي مرة واحدة وأعد استخدام [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) المرجع عند إنشاء أطر صور إضافية. هذا يجنب تحميل بيانات المصدر نفسها مرارًا ويجعل العلاقة بين مورد الصورة المشترك واستخداماته واضحة.

للرسومات التي يجب أن تظهر تلقائيًا على العديد من الشرائح، مثل شعار الشركة، ضع إطار الصورة على [slide master](/slides/ar/php-java/slide-master/) أو التخطيط بدلًا من إضافة شكل مكافئ إلى كل شريحة.

## **استخدام صورة كخلفية شريحة**

تُعيّن صورة الخلفية إلى تعبئة الشريحة؛ لا تُضاف كشكل إطار صورة. هذا مفيد عندما يجب أن تغطي الصورة خلفية الشريحة ويجب ألا تُعامل ككائن شريحة عادي.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لخيارات خلفية إضافية، بما في ذلك خلفيات الماستر والتخطيط، راجع [Presentation Background](/slides/ar/php-java/presentation-background/).

## **الصور المدمجة والمرتبطة**

لدى الصور المدمجة والمرتبطة مقايضات مختلفة من حيث القابلية للنقل وحجم الملف:

- **Embedded image:** تُخزن بيانات الصورة داخل العرض التقديمي. يكون العرض التقديمي معبأ ذاتيًا، لكن حجم الملف يتضمن بيانات الصورة.
- **Linked image:** يخزن العرض التقديمي مسارًا أو URL لصورة خارجية. يمكن أن يقلل ذلك من حجم العرض التقديمي، لكن المورد الخارجي يجب أن يظل متاحًا عند فتح أو عرض العرض.

يمكن إنشاء صورة مرتبطة عن طريق تعيين المسار أو URL الخارجي عبر [Picture::setLinkPathLong](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picture/) بدلاً من دمج بيانات الصورة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

استخدم الصور المرتبطة فقط عندما يكون بيئة النشر قادرة على الوصول إلى المورد الخارجي بثقة. بالنسبة للعرض التقديمي الذي يجب أن يعمل دون اتصال أو يُنقل بين الأنظمة، تكون الصور المدمجة عادةً أكثر أمانًا.

## **العمل مع صور SVG**

SVG هو تنسيق متجه، لذا يمكن أن يكون مفيدًا للرموز والرسومات الأخرى التي يجب أن تتوسع دون فقدان التفاصيل كما يحدث مع الصور النقطية. يدعم Aspose.Slides SVG كموارد صورة وكذلك كمصدر لأشكال شريحة قابلة للتحرير.

### **إضافة SVG كصورة**

أنشئ [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/)، أضفه إلى مجموعة الصور، وضع مورد الصورة الناتج في إطار صورة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ملفات SVG مع موارد خارجية**

يمكن لملف SVG الإشارة إلى صور أو أوراق أنماط أو خطوط خارجية. لهذا الغرض، يوفر [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) مُنشئات تقبل [ExternalResourceResolver](https://reference.aspose.com/slides/ar/php-java/aspose.slides/externalresourceresolver/) وURI أساسي. يمكن للمحلِّل تحويل URI نسبي إلى URI مطلق مسموح وإرجاع تدفق للمورد المطلوب.

يُتيح المحلِّل الموارد الخارجية أثناء معالجة Aspose.Slides لـ SVG، لكنه لا يعيد كتابة SVG إلى مستند مستقل. إذا كان SVG يجب أن يبقى قابلاً للنقل، دمج موارده المطلوبة داخل ملف SVG نفسه، على سبيل المثال باستخدام عناوين `data:` للصور المرتبطة.

عند التعامل مع ملفات SVG من مصادر غير موثوقة، قصر المخططات ومواقع الملفات والمضيفين التي يمكن للمحلِّل الوصول إليها. يجب أن تطبق حلول الشبكة مهلات، حدود حجم الاستجابة، والتحقق من صحة المحتوى.

### **تحويل SVG إلى أشكال قابلة للتحرير**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من أشكال شريحة قابلة للتحرير، مشابهة لأمر PowerPoint المقابل.

![PowerPoint Popup Menu](img_01_01.png)

استخدم تحميل [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addgroupshape/) الذي يقبل [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) لإجراء التحويل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

استخدم تحويل SVG إلى أشكال عندما تحتاج عناصر المتجه الفردية إلى تعديل كأشكال PowerPoint. إذا كان الـ SVG يقتصر على العرض فقط، يبقى الاحتفاظ به كصورة أبسط ويجنب إنشاء عدد كبير من الأشكال المنفصلة.

## **استبدال مورد صورة موجود**

استخدم [PPImage::replaceImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) عندما تريد استبدال مورد صورة موجود. هذا مفيد بشكل خاص للرسومات المشتركة مثل الشعارات.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

إذا استخدمت أطر صور أو خلفيات أو ماسترات أو تخطيطات متعددة نفس مورد الصورة، فإن استبدال ذلك المورد سيُحدّث جميع الاستخدامات. إذا كان ينبغي تغيير إطار صورة واحد فقط، عيّن صورة مختلفة لذلك الإطار بدلاً من استبدال المورد المشترك.

`PPImage::replaceImage` يوفر أيضًا تحميلات تقبل مصفوفة بايت أو [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) آخر.

## **إرشادات عملية لإدارة الصور**

### **التحكم في حجم العرض التقديمي**

يمكن للصور النقطية الكبيرة أن تجعل العرض التقديمي كبيرًا بشكل غير ضروري. استخدم صورًا بأبعاد مناسبة لحجم العرض المقصود، وأعد استعمال موارد الصور المشتركة حيثما أمكن، وتجنب دمج نسخ متكررة من نفس الرسمة عالية الدقة.

بالنسبة للصور النقطية التي تم وضعها بالفعل في أطر صورة، يمكن لـ [PictureFillFormat::compressImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/picturefillformat/) تقليل بيانات الصورة وفقًا للدقة المختارة وإعدادات الاقتصاص. هذا يُعد معالجة لإطار الصورة وليس لإدارة مجموعة الصور، لذا راجع [Picture Frame](/slides/ar/php-java/picture-frame/) للعمليات التنسيقية ذات الصلة.

### **اختر بين المحتوى المدمج والمرتبط**

يجعل الدمج العرض التقديمي قابلًا للنقل لأن جميع بيانات الصورة المطلوبة تسافر مع الملف. يمكن للربط أن يقلل من حجم الملف، لكنه يُدخل اعتمادًا خارجيًا. استخدم الروابط فقط عندما يكون هذا الاعتماد مقبولًا وثابتًا.

### **إعادة استخدام العلامة التجارية المشتركة**

للشعارات أو العلامات المائية أو الرسومات الزخرفية المتكررة، استخدم مورد صورة واحد وأعد استعماله. إذا كانت الرسمة تخص تصميم العرض التقديمي بدلاً من محتوى الشرائح، ضعها على ماستر أو تخطيط لتُورث إلى الشرائح المناسبة.

### **الحفاظ على موارد SVG قابلة للنقل**

SVG مستقل سهل نقله وعرضه بشكل متسق مقارنةً بـ SVG يعتمد على ملفات أو موارد شبكة خارجية. عندما يكون ذلك ممكنًا، دمج الموارد المطلوبة قبل استيراد SVG. حوّل SVG إلى أشكال فقط عندما تحتاج العناصر المتجهية الفردية إلى تعديل.

### **استخدام واجهة برمجة تطبيقات الصور الحديثة متعددة المنصات**

للكود الجديد PHP عبر Java، استخدم واجهات Aspose.Slides [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) و[Images](https://reference.aspose.com/slides/ar/php-java/aspose.slides/images/) بدلاً من API العام القديم القائم على `java.awt.image.BufferedImage`. راجع [Modern API](/slides/ar/php-java/modern-api/) للحصول على إرشادات الترحيل.

تتطلب صياغات WMF وEMF اعتبارًا خاصًا. عند تمرير هذه الصيغ عبر [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/)، يحول [ImageCollection::addImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) ملف الميتا إلى تمثيل PNG نقطي قبل الإدراج. إذا كان الحفاظ على بيانات الميتا مهمة، استخدم تحميل [ImageCollection::addImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imagecollection/) القائم على التدفق بدلاً من ذلك. إنشاء محتوى EMF من جداول البيانات أو منتجات أخرى هو سير عمل تكاملي منفصل وخارج نطاق هذه المقالة.

## **الأسئلة الشائعة**

**ما الفرق بين مجموعة الصور وإطار الصورة؟**

مجموعة الصور تخزن موارد صور قابلة لإعادة الاستخدام. إطار الصورة هو شكل شريحة يعرض أحد تلك الموارد ويوفر تنسيقات خاصة بالصورة مثل الاقتصاص والتأثيرات.

**ما أفضل طريقة لاستبدال الشعار نفسه في كل مكان؟**

إذا كان الشعار مُشارَك كموارد صورة واحدة، استبدل ذلك المورد باستخدام [PPImage::replaceImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/). بالنسبة للعلامة التجارية على مستوى العرض، وضع الشعار على ماستر أو تخطيط يمكن أن يقلل من تكرار محتوى الشرائح.

**لماذا تختفي صورة مرتبطة على جهاز كمبيوتر آخر؟**

الصورة المرتبطة تعتمد على ملفها الخارجي أو URL. إذا تعذر الوصول إلى ذلك المورد من الجهاز الآخر، قد تكون الصورة غير متوفرة. دمج الصورة عندما يجب أن يكون العرض التقديمي مستقلًا.

**هل يمكن تعديل SVG مدخَل كأشكال PowerPoint؟**

نعم. حوّل SVG باستخدام [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addgroupshape/); المجموعة الناتجة تحتوي على أشكال شريحة قابلة للتحرير بدلاً من صورة SVG واحدة.

**كيف يمكن الحفاظ على عروض تقديمية تحتوي على العديد من الصور أصغر حجمًا؟**

أعد استعمال موارد الصور المشتركة، تجنّب مصادر نقطية كبيرة الحجم غير ضرورية، ضغط الصور النقطية المناسبة عند الحاجة، وضع العلامات التجارية المتكررة على ماسترات أو تخطيطات، واستخدم الصور المرتبطة فقط عندما تكون الاعتمادية الخارجية مقبولة.