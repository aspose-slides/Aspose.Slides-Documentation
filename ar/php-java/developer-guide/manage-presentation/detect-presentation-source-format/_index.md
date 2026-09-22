---
title: تحديد تنسيق العرض التقديمي الأصلي في PHP
linktitle: تنسيق المصدر
type: docs
weight: 35
url: /ar/php-java/detect-presentation-source-format/
keywords:
- تنسيق المصدر
- اكتشاف تنسيق العرض التقديمي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "قراءة تنسيق العرض التقديمي الأصلي للعرض الذي تم تحميله في PHP باستخدام Aspose.Slides for PHP عبر Java، مقارنة واجهات برمجة التطبيقات للكشف، والتعامل مع الملفات، التدفقات، والصيغ القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، استدعِ الطريقة [Presentation::getSourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSourceFormat) لتحديد تنسيقه الأصلي. استخدمها عندما يعتمد المعالجة اللاحقة على التنسيق الذي تمّ تحميل المثيل الحالي منه.

تنسيق المصدر مختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) المحدد لملف الإخراج. حفظ الملف بتنسيق آخر لا يغيّر تنسيق المصدر للمثيل الحالي.

## **قراءة تنسيق المصدر لملف**

هذا المثال يتطلّب ملف `sample.pptx` موجود. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation::getSourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSourceFormat) ، بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة تنسيقات أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **التعرف على القيم المدعومة**

الفئة [SourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sourceformat/) تُعرّف ثوابت عددية تُميّز صيغ العروض التقديمية التالية. الامتدادات أدناه هي امتدادات تقليدية، ليست إعادة بناء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | الصيغة |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض Office Open XML |
| `Pptm` | `.pptm` | عرض Office Open XML مع ماكرو |
| `Pps` | `.pps` | عرض شريحة PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شريحة Office Open XML |
| `Ppsm` | `.ppsm` | عرض شريحة Office Open XML مع ماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML مع ماكرو |
| `Odp` | `.odp` | عرض OpenDocument |
| `Otp` | `.otp` | قالب OpenDocument |
| `Fodp` | `.fodp` | عرض Flat XML ODF |
| `Xml` | `.xml` | عرض PowerPoint XML |

## **قراءة تنسيق المصدر لتدفق بيانات**

هذا المثال يتطلّب ملف `sample.pps` موجود. قراءة بايتاته إلى تدفق ذاكرة يُحاكي إدخالاً يُستقبل بدون اسم ملف، مثل قيمة قاعدة بيانات أو مصفوفة بايتات تم تحميلها. يتلقى المُنشئ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) التدفق فقط.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

تستخدم الصيغ PPT و PPS و POT نفس بنية البايناري الأساسية. عند التحميل عبر مسار الملف، يمكن للامتداد أن يساعد في تمييز عرض شريحة أو قالب. بدون اسم ملف، قد يتم الإبلاغ عن محتوى PPS و POT القديم كـ `SourceFormat::Ppt`؛ المثال السابق للـ PPS يطبع القيمة العددية لـ `SourceFormat::Ppt`.

إذا كان تطبيقك يحتاج إلى الحفاظ على هذا التمييز، احتفظ باسم الملف الأصلي أو بيانات التعريف الفرعية بشكل منفصل. الامتداد يُعدّ تلميحًا مفيدًا لهذه الأنواع القديمة، لكنه لا ينبغي أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#getLoadFormat) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض الكامل. استخدم [Presentation::getSourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSourceFormat) عندما تكون المثيلة موجودة بالفعل.

هذا المثال يتطلّب `sample.pptx` ويطبع القيم العددية لـ `LoadFormat::Pptx` و `SourceFormat::Pptx` على التوالي. في بيئة الإنتاج، اختر الـ API المناسب لمرحلة المعالجة؛ العرض الذي تم تحميله بالفعل لا يحتاج إلى فحص ثانٍ فقط للحصول على تنسيق المصدر.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

النتائج تستخدم ثوابت من فئات مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sourceformat/). لا تقارن قيمها العددية ولا تفترض أن كل تنسيق له نتائج كشف متطابقة. قد يتم الإبلاغ عن PowerPoint XML كـ `LoadFormat::Unknown` قبل التحميل و `SourceFormat::Xml` بعد التحميل.

## **الحفاظ على تنسيقات المصدر والإخراج منفصلة**

هذا المثال يتطلّب `sample.pptx` ويكتب `converted.odp`. يطبع القيمة العددية لـ `SourceFormat::Pptx` قبل وبعد حفظ المثيل الأصلي. فقط المثيل الجديد المُحمّل من إخراج ODP يُبلغ عن `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

العرض الذي يُنشأ من الصفر باستخدام `new Presentation()` يُبلغ عن `SourceFormat::Pptx`. لا يوجد ملف إدخال: هذه هي القيمة الافتراضية لمثيل تم إنشاؤه حديثًا، وليست دليلًا على تحميل ملف PPTX. تتبع ما إذا كان تطبيقك قد أنشأ المثيلة أو حمّلها بشكل منفصل إذا كان هذا التمييز مهمًا.

## **تحويل تنسيق المصدر إلى امتداد**

المثال التالي يتطلّب `sample.pptx`. يرمّز كل قيمة من قيم [SourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/sourceformat/) المدعومة حاليًا إلى امتداد تقليدي، دون تحليل اسم الملف المدخل. يضمن fallback عدم تعيين امتداد بصمت لقيمة غير معروفة.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

هذا التحويل لا يُحوّل ملفًا أو يستعيد نوع PPS/POT القديم الفاقد أثناء تحميل التدفق. للحفظ الفعلي، حدّد [SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) صراحة، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/php-java/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من الصيغ عبر الحفظ وإعادة الفتح**

هذا المثال المستقل يُنشئ عرضًا ويكتب ثلاثة ملفات في دليل العمل، مع استبدال الملفات ذات الأسماء نفسها. يعيد فتح كل مخرج إما عبر المسار أو من خلال تدفق ذاكرة. بالنسبة إلى PPTX و ODP، كلا المسارين يُبلغان عن الصيغة المحفوظة. بالنسبة إلى PPS، يُبلغ التحميل عبر المسار عن `Pps`، بينما يُبلغ تحميل نفس البايتات بدون اسم ملف عن `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

الجدول التالي يلخّص التعرف على تنسيق المصدر للعرض وفقًا للامتدادات المطابقة. الأسماء تمثل ثوابت؛ الأمثلة بلغة PHP تطبع القيم العددية لها:

| الصيغة المحفوظة | SourceFormat من مسار ملف | SourceFormat من تدفق بلا اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` على التوالي | نفس قيمة مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` على التوالي | نفس قيمة مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` على التوالي | نفس قيمة مسار الملف |
| ODP, OTP | `Odp`, `Otp` على التوالي | نفس قيمة مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوى PPS/POT يُعرَّف كـ `Ppt` في التدفقات بلا اسم. يصف الجدول طريقة التعرف على الصيغة، وليس الحفاظ على جميع ميزات العرض أثناء التحويل.

## **الأسئلة المتكررة**

**هل يُغيّر حفظ العرض إلى ODP تنسيق المصدر لعرض تم تحميله من PPTX؟**

لا. المثيل الحالي لا يزال يُبلغ عن `Pptx`. المثيل المحمّل من ملف ODP المحفوظ يُبلغ عن `Odp`.

**هل يمكن للتدفق دائمًا تمييز عرض تقديمي قديم، عرض شريحة، أو قالب؟**

لا. الصيغ PPT و PPS و POT تشترك في بنية البايناري. احتفظ باسم الملف أو بيانات التعريف الفرعية بشكل منفصل عندما يكون هذا التمييز مطلوبًا.

**أي API يجب أن أستخدمه إذا كان العرض مُحمَّلاً بالفعل؟**

اقرأ [Presentation::getSourceFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSourceFormat). استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) للفحص قبل التحميل.