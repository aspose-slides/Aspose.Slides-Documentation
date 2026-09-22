---
title: استرجاع وتحديث معلومات العرض التقديمي في PHP
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/php-java/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات التعريفية في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة PHP للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة بياناته التعريفية دون إنشاء نموذج كائن العرض التقديمي الكامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض التقديمي.

توضح هذه المقالة فحصًا خفيف الوزن عبر [PresentationFactory](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/) و[PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/)، بالإضافة إلى تحديثات مستهدفة عبر [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/).

## **التحقق من تنسيق العرض التقديمي**

إذا كان لديك عرض تقديمي محمَّل بالفعل، راجع [Determine the Original Presentation Format](/slides/ar/php-java/detect-presentation-source-format/) للتحديد بعد التحميل وقيود تدفقات PPT وPPS وPOT القديمة.

استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). تُبلغ طريقة [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#getLoadFormat) عن التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **إنشاء جرد عرض تقديمي خفيف الوزن**

عند معالجة عدد كبير من ملفات العروض التقديمية، قد تحتاج إلى جرد مُدمج للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/)، ثم استدعِ [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة بيانات التعريف الخاصة بالمستند. لا يؤدي هذا النهج إلى إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) أو يتطلب تجوالك عبر نموذج كائن العرض الكامل.

توفر الخصائص الموسعة التي يكشف عنها [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/) القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getSlides) | إجمالي عدد الشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getHiddenSlides) | عدد الشرائح المخفية. |
| [getNotes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getNotes) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getParagraphs) | إجمالي عدد الفقرات، إذا كانت متاحة. |
| [getWords](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getWords) | إجمالي عدد الكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getMultimediaClips) | إجمالي عدد مقاطع الصوت والفيديو. |

تقرأ المثال التالي هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، ويطبع جردًا مُدمجًا. كما يجمع بين [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getHeadingPairs) و[DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getTitlesOfParts) لعرض مجموعات المحتوى مثل الخطوط، الأنماط، وعناوين الشرائح.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

كل [HeadingPair](https://reference.aspose.com/slides/ar/php-java/aspose.slides/headingpair/) يوفر اسم المجموعة وعدد العناصر في تلك المجموعة. تُعيد [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getTitlesOfParts) مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحددة بواسطة كل زوج عنوان.

### **البيانات التعريفية المخزنة وقيود التنسيق**

تعكس خصائص الجرد التي تُعيدها [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#readDocumentProperties) البيانات التعريفية المتوفرة في المستند المصدر. لا تقوم Aspose.Slides بتحميل وتصفح نموذج كائن العرض لإعادة حساب هذه القيم في هذا الاستدعاء. تُمثل الخصائص المفقودة بالقيم الافتراضية، وقد تكون القيم المخزنة قديمة إذا لم تقم التطبيق الذي حفظ الملف آخرًا بتحديث خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، والوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد الإتاحة على الخصائص التي كتبها مُنتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غير موجودة أو لم يتم تحديثها من قبل مُنتج المستند، تعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات تعريف OpenDocument إحصاءات عامة للمستند، مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة مخصصة لـ PowerPoint. قد تكون بيانات التعريف للشرائح المخفية، الشرائح ذات الملاحظات، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متوفرة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تعتبر القيمة الصفرية أو المصفوفة الفارغة دليلًا قاطعًا على عدم وجود المحتوى المقابل.

استخدم نهج البيانات التعريفية الخفيفة للجرد والفحوص الأولية. حمِّل العرض التقديمي وافعله نموذج كائنه الحي عندما يجب أن يعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُعيدها [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#readDocumentProperties) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). طبّق التغييرات باستخدام [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#updateDocumentProperties)، ثم احفظ العرض المرتبط باستخدام [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

الصورة التالية تُظهر خصائص المستند الأصلية لعرض PowerPoint:

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

الصورة التالية تُظهر خصائص المستند المحدثة:

![خصائص المستند المتغيّرة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية ذات الصلة وإعدادات الحماية، راجع المقالات التالية:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/)
- [حماية كتابة العروض التقديمية](/slides/ar/php-java/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وأيها؟**

حمِّل العرض التقديمي واستخدم [Presentation::getFontsManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getFontsManager). استدعِ [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) للحصول على الخطوط المضمَّنة و[FontsManager::getFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getFonts) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين للعثور على الخطوط المطلوبة للعرض ولكنها غير مضمّنة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كون بيانات التعريف المخزنة كافية، اقرأ [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getHiddenSlides) عبر [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/) و[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#readDocumentProperties). هذا مناسب لجرد خفيف الوزن. إذا تم تعديل العرض في الذاكرة، قد تكون بيانات التعريف المخزنة مفقودة أو قديمة، أو إذا كنت بحاجة للتحقق من القيم الحية، استعرض [Presentation::getSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSlides) وتفقد طريقة [Slide::getHidden](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#getHidden) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم ودوران مخصص للشرائح، وما إذا كان يختلفان عن الإعدادات الافتراضية؟**

نعم. حمِّل العرض التقديمي واستدعِ [Presentation::getSlideSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSlideSize). استخدم [SlideSize::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/#getSize) و[SlideSize::getOrientation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/#getOrientation) لمقارنة الإعدادات الحالية مع الإعدادات المسبقة المتوقعة والأبعاد.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. ابحث عن كل [Chart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/) واستدعِ [ChartData::getDataSourceType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/#getDataSourceType). لدفتر عمل خارجي، استدعِ [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). يحدد نوع مصدر البيانات والمسار إشارة خارجية، لكن التحقق من توفر الهدف يتطلب فحص موارد منفصل.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation::getSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSlides) ومجموعة [BaseSlide::getShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getShapes) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، تحريكات أو وسائط متعددة كإشارات فحص، وقم بقياس عرض أو تصدير تمثيلي قبل اعتبار الشريحة عنق زجاجة أداء مؤكد.