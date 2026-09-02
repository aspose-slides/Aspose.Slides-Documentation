---
title: تحسين إدارة الصور في العروض التقديمية باستخدام PHP
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/php-java/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة رسم نقطي
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- موارد SVG الخارجية
- محلل SVG
- صور SVG المرتبطة
- خطوط SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- EMF
- SVG
- PHP
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides لـ PHP عبر Java، تحسين الأداء وأتمتة سير العمل الخاص بك."
---
## **المقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وجمالًا بصريًا. في Microsoft PowerPoint، يمكنك إدراج صور في الشرائح من ملفات أو من الإنترنت أو من مصادر أخرى. بالمثل، يتيح لك Aspose.Slides إضافة صور إلى شرائح العرض بعدة طرق.

{{% alert  title="Tip" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تسمح لك بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

إذا كنت تريد إضافة صورة كإطار صورة—خاصةً إذا كنت تخطط لتغيير حجمها أو تطبيق تأثيرات أو استخدام خيارات تنسيق قياسية أخرى—اطلع على [إطار الصورة](/slides/ar/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

يمكنك تحويل الصور من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/image-to-jpg/)، [JPG إلى صورة](https://products.aspose.com/slides/ar/php-java/conversion/jpg-to-image/)، [JPG إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/jpg-to-png/)، [PNG إلى JPG](https://products.aspose.com/slides/ar/php-java/conversion/png-to-jpg/)، [PNG إلى SVG](https://products.aspose.com/slides/ar/php-java/conversion/png-to-svg/)، و[SVG إلى PNG](https://products.aspose.com/slides/ar/php-java/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides الصور بالتنسيقات الشائعة مثل JPEG وPNG وBMP وGIF وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو أكثر مخزنة على جهازك إلى شريحة عرض. يوضح مثال PHP التالي كيفية إضافة صورة إلى شريحة:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **إضافة صور من الويب إلى الشرائح**

إذا لم تكن الصورة المطلوبة مخزنة على جهازك، يمكنك إضافتها مباشرة من الويب. 

يظهر مثال PHP التالي كيفية إضافة صورة من الويب إلى شريحة:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **إضافة صور إلى أسس الشرائح (Slide Masters)**

يخزن أساس الشريحة معلومات مثل السمة وتنسيق الشرائح التي تستخدمه. عندما تضيف صورة إلى أساس الشريحة، تظهر الصورة على كل شريحة تستند إلى ذلك الأساس. 

يظهر مثال PHP التالي طريقة إضافة صورة إلى أساس شريحة:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **إضافة صور كخلفيات للشرائح**

يمكنك استخدام صورة كخلفية لشريحة واحدة أو أكثر. للحصول على تفاصيل، راجع *[تعيين الصور كخلفيات للشرائح](/slides/ar/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/). يمكن بعد ذلك إضافة كائن صورة SVG الناتج إلى مجموعة صور العرض واستخدامه لإنشاء إطار صورة.

يظهر مثال PHP التالي استيراد سلسلة SVG ذاتية الاحتواء. يتم تضمين جميع الصور والأنماط والموارد الأخرى المستخدمة في هذا SVG مباشرةً في محتوى SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استيراد محتوى SVG مع موارد خارجية**

قد تشير ملفات SVG المصدرة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط أنابيب الويب إلى موارد مخزنة خارج مستند SVG. على سبيل المثال، قد يحتوي SVG على رابط صورة مثل `images/photo.png` أو قيمة CSS `url(...)` أو عنوان URL لخط.

لاستيراد مثل هذا المحتوى، أنشئ تنفيذًا لـ [ExternalResourceResolver](https://reference.aspose.com/slides/ar/php-java/aspose.slides/externalresourceresolver/) ومرره، مع عنوان URI أساسي، إلى منشئ [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) المناسب. يحدد العنوان الأساسي موقع مستند SVG ويستخدم لحل الروابط النسبية.

يوفر كائن صورة SVG الوصول إلى معلومات حول SVG المستورد:

- `getSvgContent()` يرجع ترميز SVG كسلسلة.
- `getSvgData()` يرجع محتوى SVG كمصفوفة بايت.
- `getBaseUri()` يرجع العنوان الأساسي المستخدم للروابط النسبية.
- `getExternalResourceResolver()` يرجع المحلّل المعين لصورة SVG.

### **تنفيذ محلّل موارد خارجية**

للمحلّل طريقتان:

- `resolveUri` يدمج العنوان الأساسي ورابط المورد النسبي ويعيد عنوان URI مطلق. أرجع `null` عندما لا يمكن حل الرابط أو غير مسموح به.
- `getEntity` يرجع تدفقًا قابلًا للقراءة لمورد URI مطلق. أرجع `null` عندما يكون المورد مفقودًا أو محظورًا أو غير متوفر. يمكن أيضًا إرجاع تدفق احتياطي عند اللزوم.

يظهر المثال التالي محلّلًا يحمل الموارد المرتبطة فقط من دليل محلي مسموح به. تُحجب الموارد الشبكية والمسارات خارج الدليل المسموح. يتم إرجاع صورة احتياطية اختيارية للروابط غير المحلولة.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // هذا المحلّل يسمح عمداً بالملفات المحلية فقط.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // استخدم بديلًا فقط لموارد الصور. إرجاع تدفق صورة
            // من أجل خط أو ورقة أنماط مفقودة لن يكون ذلك صالحًا.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **حل الموارد المرتبطة أثناء استيراد SVG**

افترض أن `assets/diagram.svg` يحتوي على إشارة نسبية مثل:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

يمرر المثال التالي في PHP عنوان URI لملف SVG كالعنوان الأساسي ويقدم محلّلًا مخصصًا. يحوّل المحلّل رابط الصورة النسبي إلى عنوان URI مطلق ويعيد تدفقًا يحتوي على المورد المرتبط أثناء معالجة Aspose.Slides للـ SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// يمثل عنوان URI الأساسي موقع مستند SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// كائن صورة SVG يعرض المحتوى الأصلي والبيانات الثنائية وعنوان URI الأساسي والمحلّل.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

توفر الفئة `SvgImage` أيضًا تحميلات مفرطة تقبل بيانات SVG كمصفوفة بايت أو تدفق إدخال، إلى جانب محلّل موارد خارجية وعنوان URI أساسي.

{{% alert title="Important" color="warning" %}}

يجعل محلّل الموارد الموارد الخارجية متاحة أثناء معالجة Aspose.Slides للـ SVG وعرضه. لا يغيّر ترميز SVG الأصلي ولا يدمج الموارد المحلولة تلقائيًا فيه.

عند إضافة صورة SVG إلى مجموعة صور العرض، قد يحتوي ملف PPTX على كل من تمثيل SVG الأصلي وصورة نقطية احتياطية. يمكن أن يظهر مورد مرتبط في الصورة الاحتياطية المولدة بينما يبقى الرابط النسبي مثل `images/photo.png` دون تغيير في SVG المخزن. لذلك قد يتغاضى تطبيق يعرض تمثيل SVG الأصلي عن المحتوى المرتبط عندما يكون المورد الخارجي الأصلي غير متوفر.

{{% /alert %}}

### **إنشاء صورة SVG محمولة**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل SVG ذاتيًا قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـ URIs من النوع `data:` التي تحتوي على بيانات الصورة:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد تضمين جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، أضفه إلى مجموعة صور العرض، وأدرجه في إطار صورة كما في المثال السابق.

### **معالجة الموارد المفقودة أو المحظورة**

أرجع `null` من `resolveUri` عندما يكون عنوان URI للمورد غير صالح أو محظور أو لا يمكن حله. أرجع `null` من `getEntity` عندما لا يمكن قراءة المورد. يواصل Aspose.Slides معالجة SVG بدون ذلك المورد إن أمكن.

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن محتواه يجب أن يكون متوافقًا مع نوع المورد المطلوب. على سبيل المثال، أرجع تدفق صورة فقط لمورد صورة مفقود، وليس لخط أو ورقة أنماط.

{{% alert title="Security" color="warning" %}}

لا تحلّ مسارات ملفات عشوائية أو عناوين URL شبكة غير مقيدة من ملفات SVG غير موثوقة. قيد المخططات المسموح بها، الأدلة، والمضيفين. بالنسبة للموارد الشبكية، طبّق أيضًا مهلات الاتصال، حدود حجم الاستجابة، والتحقق من صحة المحتوى.

{{% /alert %}}

## **تحويل SVG إلى مجموعة أشكال**

يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مشابهًا للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة من خلال تحميل مفرط للطريقة [addGroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addgroupshape/) في فئة [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/) التي تقبل كائن [SvgImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgimage/) كوسيط أول.

يظهر مثال PHP التالي كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة أشكال:

```php
// اسم ملف SVG المصدر.
$svgFileName = "sample.svg";

// اسم ملف العرض الناتج.
$outPptxPath = "presentation.pptx";

// إنشاء عرض تقديمي جديد.
$presentation = new Presentation();
try {
    // قراءة محتوى ملف SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // إنشاء كائن SvgImage.
    $svgImage = new SvgImage($svgContent);

    // الحصول على حجم الشريحة.
    $slideSize = $presentation->getSlideSize()->getSize();

    // تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتناسب حجم الشريحة.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // حفظ العرض بتنسيق PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **إضافة صور كـ EMF إلى الشرائح**

يتيح Aspose.Slides for PHP via Java إنشاء صور EMF من أوراق عمل Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض.

يظهر مثال PHP التالي كيفية القيام بذلك:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// احفظ المصنف إلى تدفق.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // أضف الملف كما هو حتى يبقى الصورة كـ EMF متجهة بدلاً من تحويلها إلى نقطية.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **استبدال الصور في مجموعة الصور**

يتيح Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض، بما في ذلك الصور المستخدمة في أشكال الشرائح. تصف هذه الفقرة عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات أدناه:

1. حمّل ملف العرض الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
1. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
1. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) واستبدل الصورة المستهدفة بهذا الكائن.
1. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.
1. احفظ العرض المعدل كملف PPTX.

```php
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation("sample.pptx");
try {
    // الطريقة الأولى.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // الطريقة الثانية.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // الطريقة الثالثة.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // حفظ العرض التقديمي إلى ملف.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

مع محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/ar/text-to-gif)، يمكنك بسهولة تحريك النص وإنشاء ملفات GIF من النص. 

{{% /alert %}}

## **الأسئلة المتكررة**

**هل تظل دقة الصورة الأصلية محفوظة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية توسعة [الصورة](/slides/ar/php-java/picture-frame/) على الشريحة وأي ضغط يتم تطبيقه عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عشرات الشرائح مرة واحدة؟**

ضع الشعار على شريحة الأساس أو على تخطيط واستبدله في مجموعة صور العرض—ستنتقل التحديثات إلى جميع العناصر التي تستخدم ذلك المورد.

**هل يمكن تحويل SVG مُدرج إلى أشكال قابلة للتعديل؟**

نعم. يمكنك تحويل SVG إلى مجموعة أشكال، ثم تصبح الأجزاء الفردية قابلة للتعديل باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/php-java/presentation-background/) على شريحة الأساس أو على التخطيط المناسب—ستورث جميع الشرائح التي تستخدم ذلك الأساس/التخطيط الخلفية.

**كيف أمنع أن يصبح العرض كبيرًا جدًا بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المتكررة، اختر دقة معقولة، طبّق ضغطًا عند الحفظ، وحافظ على الرسومات المتكررة على الأساس عند الحاجة.