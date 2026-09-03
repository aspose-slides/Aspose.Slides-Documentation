---
title: تضمين الخطوط في العروض التقديمية باستخدام PHP
linktitle: الخطوط المضمّنة
type: docs
weight: 40
url: /ar/php-java/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخطوط
- الحصول على خط مضمّن
- إضافة خط مضمّن
- إزالة خط مضمّن
- ضغط خط مضمّن
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة الخطوط المضمّنة في PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java. إضافة، استرجاع، إزالة، وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **المقدمة**

تضمين الخطوط يخزن بيانات الخط داخل عرض تقديمي PowerPoint. عندما يدعم المشاهد الخطوط المضمّنة، يمكنه عرض النص باستخدام تلك الخطوط حتى إذا لم تكن مثبتة على النظام المستهدف. يساعد ذلك في الحفاظ على فواصل الأسطر وتباعد النص وتنسيق الشريحة.

تتيح لك Aspose.Slides for PHP عبر Java استرداد الخطوط المضمّنة وإضافتها وإزالتها من خلال فئة [FontsManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/) التي تُرجعها الدالة [Presentation::getFontsManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getFontsManager). يمكنك أيضًا تقليل حجم بيانات الخط المضمّن عن طريق إزالة الأحرف التي لا يستخدمها العرض التقديمي.

الأمثلة أدناه تعمل مع ملفات PPTX. قبل تضمين أي خط، تأكد من أن بيانات الخط متاحة لـ Aspose.Slides وأن رخصته تسمح بالتضمين.

## **الحصول على الخطوط المضمّنة وإزالتها**

استخدم [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) لسرد الخطوط المخزنة في عرض تقديمي. لإزالة أحدها، مرّر خطًا من تلك القائمة إلى [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont)، ثم احفظ العرض التقديمي.

المثال التالي يسرد الخطوط المضمّنة في الملف `EmbeddedFonts.pptx` ويزيل خط Calibri إذا كان موجودًا:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

إزالة خط مضمّن يزيل بيانات الخط المخزنة؛ لا يغيّر الخط المعين للنص. إذا كان الخط مثبتًا على النظام المستهدف، لا يزال بإمكان النص استخدامه. وإلا، قد يتطلب العرض [استبدال الخط](/slides/ar/php-java/font-substitution/)، مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وأذونات التضمين**

استخدم فئة [FontsManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/) لفحص الخطوط قبل تضمينها. استدعِ [FontsManager::getFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getFonts) لاسترداد الخطوط المستخدمة في العرض التقديمي. لكل خط، مرّر كائن [FontData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontdata/) والقيمة المطلوبة من [FontStyleType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontstyletype/) إلى [FontsManager::getFontBytes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getFontBytes). تُرجع الطريقة البيانات الثنائية لذلك النمط من الخط، أو `null` عندما يكون الخط أو النمط المطلوب غير متوفر. لا تمرّر نتيجة `null` إلى [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel)، لأن هذه الطريقة تتطلب مصفوفة بايت.

[EmbeddingLevel](https://reference.aspose.com/slides/ar/php-java/aspose.slides/embeddinglevel/) هو تعداد للعلامات يُظهر قيود التضمين المخزنة في الخط:

- `Installable` يتيح التضمين والتثبيت الدائم على نظام آخر، وفقًا لرخصة الخط.
- `Restricted` يحظر التضمين ما لم يحصل المستخدم على إذن من صاحب الخط القانوني عندما يكون هذا هو علم الإذن الوحيد.
- `PreviewPrint` يتيح الاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي على الخط للقراءة فقط.
- `Editable` يتيح الاستخدام المؤقت ويسمح بتحرير المستند وحفظه.
- `NoSubsetting` هو قيد إضافي يمنع تضمين جزء فقط من الأحرف. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قيد إضافي يتيح تضمين ضربات البت ماب فقط، وليس بيانات المخطط. إذا لم يحتوي الخط على ضربات بت ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن دمج `NoSubsetting` و `BitmapOnly` معه. تحقق من المعدلات باستخدام عمليات البيتية. لأن قيمة `Installable` هي صفر، قم بتمييز بتات إذن الاستخدام وقارن النتيجة بـ `Installable` بدلًا من التحقق منها كعلامة. يجب أن تحدد الخطوط الحالية بتًا واحدًا على الأكثر لإذن الاستخدام. لضمان التوافق مع الخطوط القديمة التي قد تحدد أكثر من بت واحد، يختار المساعد أدناه أقل إذن تقييدي: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

المثال التالي يراجع بيانات الخط العادي، الغامق، المائل، والغامق المائل المتاحة لكل خط تُرجعه الدالة `FontsManager::getFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط التي تدعم البت ماب فقط، الخطوط المحدودة للعرض والطباعة لأن المخرجات تظل قابلة للتحرير، والخطوط التي تم تضمينها بالفعل. إذا كان لأي نمط متاح علم `NoSubsetting`، يتم تضمين جميع الأحرف لتلك العائلة من الخطوط.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هذا الفحص يُبلغ عن القيود المشفرة في كل ملف خط. لا يمنحك رخصة، ولا يثبت أنك حصلت على الخط بشكل قانوني، ولا يُستبدل بفحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمّنة.

## **إضافة خطوط مضمّنة**

استخدم [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) لتضمين خط. تتقبل التحميلات المتعددة إما كائن [FontData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontdata/) أو مصفوفة بايت تحتوي على بيانات الخط. يتحكم تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/ar/php-java/aspose.slides/embedfontcharacters/) في الأحرف التي سيتم تضمينها:

- [All](https://reference.aspose.com/slides/ar/php-java/aspose.slides/embedfontcharacters/) يضمّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المستقبلون إلى تحرير العرض التقديمي وإدخال نص جديد.
- [OnlyUsed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/embedfontcharacters/) يضمّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار لعرض تقديمي نهائي يهدف أساسًا إلى العرض.

المثال التالي يستخدم [FontsManager::getFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getFonts) لاسترداد الخطوط المستخدمة في الملف `Fonts.pptx` ويضمّن تلك التي لم تُضمّن بعد. يجب أن تكون الخطوط المراد إضافتها متاحة على الجهاز الذي يشغل الكود. تحتفظ الخطوط المضمّنة الحالية بمجموعة الأحرف الحالية.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ضغط الخطوط المضمّنة**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#compressEmbeddedFonts) يقلل من بيانات الخط المضمّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها بالفعل، لذا يعتمد تقليل الحجم على مقدار البيانات غير المستخدمة في الخط داخل العرض التقديمي.

المثال التالي يضغط الخطوط في الملف `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

احتفظ بالملف الأصلي إذا كان المستقبلون قد يحتاجون لإضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لن تكون متاحة بعد الآن من الخط المضمّن، حتى لو كنت قد ضمّنت جميع الأحرف في البداية.

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كان الخط المضمّن سيظل يُستبدَل أثناء العرض؟**

استدعِ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/#getSubstitutions) في البيئة التي تُعرض فيها العرض التقديمي لمعرفة الخطوط التي سيستبدلها Aspose.Slides. تحقق أيضًا من إعدادات [استبدال الخط](/slides/ar/php-java/font-substitution/) وقواعد [الخط البديل](/slides/ar/php-java/fallback-font/). يتعامل الـ fallback مع الأحرف المفقودة، لذا فإن تضمين خط لا يحل الأحرف التي لا يحتويها الخط نفسه.

**هل يجب عليّ تضمين الخطوط الشائعة مثل Arial و Calibri؟**

استند إلى بيئة الهدف عند اتخاذ القرار. إذا كانت الخطوط المطلوبة متوفرة على كل جهاز يفتح أو يعرض العرض التقديمي، قد يؤدي تضمينها إلى زيادة حجم الملف دون فائدة. إذا كان من المحتمل أن يفتقر المستقبلون أو الخوادم إلى تلك الخطوط، فإن تضمينها يمكن أن يساعد في الحفاظ على المظهر المقصود، شريطة أن تسمح رخصها بذلك.