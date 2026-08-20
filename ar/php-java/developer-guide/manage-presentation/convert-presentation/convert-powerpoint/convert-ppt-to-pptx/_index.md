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
  - عرض تقديمي
  - PHP
  - Aspose.Slides
description: "تحويل ملفات PPT القديمة إلى PPTX في PHP باستخدام Aspose.Slides. يتضمن أمثلة PHP للتحويل الفردي والدفعي، ومعالجة الأخطاء، وملاحظات الدقة."
---
## **نظرة عامة**

PPT هو تنسيق PowerPoint الثنائي القديم، بينما PPTX هو تنسيق Open XML الأحدث. يمكن لـ Aspose.Slides for PHP عبر Java تحميل ملف PPT وحفظه كـ PPTX دون الحاجة إلى Microsoft PowerPoint. يوضح هذا المقال كيفية تحويل ملف واحد أو دليل من الملفات ويشرح ما يجب التحقق منه بعد التحويل.

## **تحويل ملف PPT إلى PPTX**

قم بتحميل ملف المصدر باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) ثم استدعِ [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) مع [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/#Pptx). يُفرغ كتلة `finally` العرض ويطلق موارده.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// تحميل عرض PPT القديم.
$presentation = new Presentation("presentation.ppt");
try {
    // حفظ العرض التقديمي بتنسيق PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

امتداد الملف لا يحدد تنسيق الإخراج بمفرده؛ إنّ معامل [SaveFormat::Pptx](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/#Pptx) هو الذي يحدده. احرص على أن تكون مسارات الإدخال والإخراج مختلفة إذا كنت بحاجة إلى الاحتفاظ بملف PPT الأصلي.

## **تحويل ملفات PPT متعددة**

المثال التالي يحول كل ملف `.ppt` في دليل واحد. يتم معالجة كل ملف بشكل مستقل، لذا لا يؤدي فشل تحويل أحدها إلى إيقاف باقي الدفعة.

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

في بيئات الإنتاج، سجّل الاستثناء الكامل، وقرر ما إذا كان يمكن الكتابة فوق ملف الإخراج الموجود، واكتب أسماء الملفات التي فشل تحويلها إلى صفٍ لإعادة المحاولة أو المراجعة. يمكن أن تتسبب الملفات الفاسدة، والملفات المحمية بكلمة مرور والتي تُفتح دون كلمة المرور المطلوبة، والمسارات غير القابلة للوصول، والمحتوى غير المدعوم جميعها في فشل التحويل. راجع [Password-Protected Presentations](/php-java/password-protected-presentation/) لتحميل الملفات المشفّرة.

## **الدقة والميزات القديمة**

عادةً ما يحافظ التحويل على الشرائح، القوالب الرئيسية، التخطيطات، النصوص، الأشكال، الصور، الجداول، والرسوم البيانية. ومع ذلك، لا تمثّل PPT وPPTX كل ميزة بنفس الطريقة تمامًا. قد يتم تطبيع أو حذف أو عرض مختلف لميزة قديمة لا يوجد لها مكافئ في PPTX أو لا يدعمها المكتبة.

تحقق من الملف المحوّل عندما يحتوي على رسوم متحركة، انتقالات، كائنات OLE مدمجة أو مرتبطة، عناصر تحكم ActiveX، وسائط مدمجة، خطوط غير شائعة، أو ماكرو VBA. ملف PPTX العادي ليس تنسيقًا يدعم الماكرو، لذا استخدم سير عمل يدعم الماكرو عندما يجب أن تظل VBA متاحة. كما يجب التأكد من وجود الخطوط المطلوبة والموارد الخارجية في البيئة التي سيفتح أو يُعرض فيها العرض المحوّل.

بالنسبة للمستندات المهمة، أعد فتح ملف PPTX المُنشأ برمجيًا وتفقد عدد الشرائح الرئيسية ومحتواها، ثم قارن مظهره وسلوك عرض الشرائح في المشاهد المقصود. لا تتعامل مع استدعاء [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) الناجح كدليل على أن كل ميزة قديمة لها تمثيل دقيق في PPTX.

## **متى ينبغي استخدام PPTX**

استخدم PPTX عندما يتم تحرير العرض التقديمي في إصدارات PowerPoint الحالية، أو تبادله مع أنظمة تتعامل مع حزم Open XML، أو تخزينه بتنسيق يسهل فحصه واسترداده مقارنةً بملف PPT الثنائي القديم. احتفظ بنسخة PPT الأصلية كنسخة أرشيفية أو للعودة إليها حتى يجتاز العرض المحوّل فحوصات الدقة الخاصة بك.

إذا كنت تحتاج إلى PDF أو HTML أو صور أو XPS أو أي نوع إخراج آخر، استخدم الإرشادات الخاصة بالتنسيق في [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) بدلاً من افتراض أن جميع الأهداف تحافظ على ميزات PowerPoint القابلة للتحرير.

## **المحول عبر الإنترنت**

لملف عرضي أو لإجراء مقارنة سريعة، يمكنك استخدام [online PPT to PPTX converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx). للتحويلات المتكررة أو المعالجة الدفعية أو معالجة الأخطاء على مستوى التطبيق، استخدم واجهة برمجة تطبيقات PHP.

## **مقالات ذات صلة**

- [PPT مقابل PPTX](/php-java/ppt-vs-pptx/)
- [حفظ العروض التقديمية في PHP](/php-java/save-presentation/)
- [تنسيقات الملفات المدعومة](/php-java/supported-file-formats/)
- [فتح العروض التقديمية في PHP](/php-java/open-presentation/)

## **الأسئلة الشائعة**

**هل يمكنني تحويل PPT إلى PPTX بدون تثبيت Microsoft PowerPoint؟**

نعم. تقوم Aspose.Slides for PHP عبر Java بتحميل وحفظ ملفات العروض التقديمية دون الحاجة إلى Microsoft PowerPoint.

**هل سيحافظ التحويل من PPT إلى PPTX على جميع المحتويات بدقة تامة؟**

إنه يحافظ على المحتوى الشائع للعرض التقديمي، لكن الدقة الكاملة غير مضمونة لكل ميزة قديمة أو غير مدعومة. راجع الملف المُنشأ عندما يحتوي على ماكرو، كائنات OLE أو ActiveX، وسائط، رسومات متحركة متخصصة، أو خطوط غير شائعة.

**هل يمكنني تحويل ملف PPT محمي بكلمة مرور؟**

نعم، إذا قمت بتوفير كلمة المرور الصحيحة عند تحميل الملف. عدم وجود كلمة مرور أو كلمة مرور غير صحيحة يؤدي إلى فشل عملية التحميل.

**هل يجب حذف ملف PPT بعد التحويل؟**

احتفظ بالأصلي حتى تتحقق من صحة ملف PPTX في العارضات وسير العمل التي تهمك. هذا يوفر نسخة للرجوع إليها إذا تم تحويل ميزة قديمة بشكل مختلف.