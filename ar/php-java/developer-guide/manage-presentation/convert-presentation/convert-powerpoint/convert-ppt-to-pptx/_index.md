---
title: تحويل PPT إلى PPTX في PHP
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/php-java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في PHP باستخدام Aspose.Slides. يتضمن أمثلة PHP للتحويل الفردي والتحويل على دفعات، ومعالجة الأخطاء، وملاحظات الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. Aspose.Slides for PHP عبر Java يمكنه تحميل ملف PPT وحفظه كـ PPTX بدون Microsoft PowerPoint. توضح هذه المقالة كيفية تحويل ملف واحد أو دليل من الملفات وتشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

حمّل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) ، ثم استدعِ [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/#Pptx). يقوم كتلة `finally` بتحرير العرض وإطلاق موارده.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// تحميل عرض PPT القديم.
$presentation = new Presentation("presentation.ppt");
try {
    // حفظ العرض بتنسيق PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

امتداد الملف لا يحدد صيغة الإخراج بمفرده؛ إنما معامل [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/#Pptx) هو الذي يفعل ذلك. احفظ مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بالملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذلك فشل تحويل واحد لا يوقف بقية الدفعة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

في بيئات الإنتاج، سجّل الاستثناء كاملًا، وحدد ما إذا كان يمكن استبدال ملف الإخراج الموجود، واكتب أسماء الملفات الفاشلة إلى طابور إعادة المحاولة أو المراجعة. يمكن أن تسبب الملفات التالفة، والملفات المحمية بكلمة مرور تم فتحها بدون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعًا فشل التحويل. راجع [Password-Protected Presentations](/slides/ar/php-java/password-protected-presentation/) لتحميل الملفات المشفرة.

## **الدقة والميزات القديمة**

عادةً ما تحافظ عملية التحويل على الشرائح، القوالب الرئيسية، التخطيطات، النصوص، الأشكال، الصور، الجداول، والمخططات. ومع ذلك، لا تمثل صيغتي PPT و PPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تطبيع أو حذف أو عرض بشكل مختلف ميزة قديمة لا توجد لها مكافئ في PPTX أو لا يدعمها المكتبة.

تحقق من الملف المحول عندما يحتوي على رسومات متحركة، انتقالات، كائنات OLE مدمجة أو مرتبطة، عناصر تحكم ActiveX، وسائط مدمجة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس صيغة تدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن يبقى VBA متاحًا. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المحول.

بالنسبة للمستندات المهمة، أعد فتح ملف PPTX الذي تم إنشاؤه برمجيًا وافحص عدد الشرائح والمحتوى الرئيسي، ثم قارن مظهره وسلوك عرض الشرائح في المشغل المستهدف. لا تعتبر استدعاء [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) الناجح دليلًا على أن كل ميزة قديمة لها تمثيل PPTX دقيق.

## **متى نستخدم PPTX**

استخدم PPTX عندما سيتم تعديل العرض في إصدارات PowerPoint الحالية، أو تبادله مع أنظمة تعمل مع حزم Open XML، أو حفظه بصيغة أسهل للفحص والاستعادة مقارنةً بـ PPT الثنائي القديم. احتفظ بالملف PPT الأصلي كنسخة أرشيفية أو للعودة إليها حتى يمر العرض المحول بفحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو نوع إخراج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/slides/ar/php-java/convert-presentation/) بدلاً من الافتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **محول على الإنترنت**

لملف عرضي أو مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة، أو المعالجة على دفعات، أو معالجة الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات PHP.

## **مقالات ذات صلة**
- [PPT مقابل PPTX](/slides/ar/php-java/ppt-vs-pptx/)
- [حفظ العروض التقديمية في PHP](/slides/ar/php-java/save-presentation/)
- [تنسيقات الملفات المدعومة](/slides/ar/php-java/supported-file-formats/)
- [فتح العروض التقديمية في PHP](/slides/ar/php-java/open-presentation/)

## **الأسئلة المتكررة**

**هل يمكنني تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم. Aspose.Slides for PHP عبر Java يقوم بتحميل وحفظ ملفات العرض دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على جميع المحتويات بدقة؟**

إنه يحافظ على محتوى العرض الشائع، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف الذي تم إنشاؤه عندما يحتوي على ماكرو، كائنات OLE أو ActiveX، وسائط، رسوم متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قدمت كلمة المرور الصحيحة عند تحميل الملف. عدم وجود كلمة مرور أو كلمة مرور غير صحيحة يتسبب في فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالملف الأصلي حتى تتحقق من PPTX في المشغلات وسير العمل التي تهمك. هذا يوفر نسخة للعودة إليها إذا تم تحويل ميزة قديمة بطريقة مختلفة.