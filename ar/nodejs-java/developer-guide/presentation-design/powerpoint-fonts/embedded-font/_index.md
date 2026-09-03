---
title: تضمين الخطوط في العروض التقديمية بلغة JavaScript
linktitle: خطوط مضمّنة
type: docs
weight: 40
url: /ar/nodejs-java/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على الخط المضمن
- إضافة خط مضمن
- إزالة الخط المضمن
- ضغط الخط المضمن
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة الخطوط المضمنة في PowerPoint باستخدام Aspose.Slides لـ Node.js عبر Java. إضافة، استرجاع، إزالة، وضغط الخطوط للحفاظ على مظهر النص وتقليل حجم الملف."
---
## **المقدمة**

يؤدي تضمين الخطوط إلى تخزين بيانات الخط داخل عرض تقديمي PowerPoint. عندما يدعم عارض الخطوط المضمّنة، يمكنه عرض النص باستخدام تلك الخطوط حتى وإن لم تكن مُثبتة على نظام الهدف. يساعد ذلك في الحفاظ على فواصل الأسطر، وتوزيع النص، وتنسيق الشرائح.

تتيح لك Aspose.Slides for Node.js عبر Java استرجاع وإضافة وإزالة الخطوط المضمّنة من خلال فئة FontsManager التي تُرجعها الدالة Presentation.getFontsManager. يمكنك أيضًا تقليل حجم بيانات الخط المضمن بإزالة الأحرف التي لا يستخدمها العرض التقديمي.

تعمل الأمثلة أدناه مع ملفات PPTX. قبل تضمين خطٍ ما، تأكد من توفر بيانات الخط لـ Aspose.Slides وأن رخصته تسمح بالتضمين.

## **الحصول على الخطوط المضمّنة وإزالتها**

استخدم FontsManager.getEmbeddedFonts لسرد الخطوط المخزنة في عرض تقديمي. لإزالة أحدها، مرّر خطًا من تلك القائمة إلى FontsManager.removeEmbeddedFont، ثم احفظ العرض التقديمي.

تقوم المثال التالي بسرد الخطوط المضمّنة في `EmbeddedFonts.pptx` وإزالة Calibri إذا كان موجودًا:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

إزالة خط مضمّن تزيل بيانات الخط المخزنة؛ ولا تغير الخط المعيّن للنص. إذا كان الخط مثبتًا على نظام الهدف، يمكن للنص الاستمرار في استخدامه. وإلا، قد يتطلب العرض [font substitution](/slides/ar/nodejs-java/font-substitution/) مما قد يؤثر على التخطيط.

## **فحص بيانات الخط وإذونات التضمين**

استخدم فئة FontsManager لفحص الخطوط قبل تضمينها. استدعِ FontsManager.getFonts لاسترجاع الخطوط المستخدمة في العرض التقديمي. لكل خط، مرّر كائن FontData والقيمة المطلوبة من FontStyleType إلى FontsManager.getFontBytes. تُعيد الطريقة البيانات الثنائية لهذا النمط من الخط، أو `null` عندما يكون الخط أو النمط المطلوب غير متوفر. لا تُمرّر نتيجة `null` إلى FontsManager.getFontEmbeddingLevel، لأن هذه الطريقة تتطلب مصفوفة بايت. في Node.js، حوّل المصفوفة التي تم إرجاعها من JavaScript إلى مصفوفة بايت جافا باستخدام `java.newArray` قبل تمريرها إلى `getFontEmbeddingLevel`.

[EmbeddingLevel] تُبلغ عن قيود التضمين المخزنة في الخط كمجموعة من العلامات:
- `Installable` يسمح بالتضمين والتثبيت الدائم على نظام آخر، وفقًا لترخيص الخط.
- `Restricted` يمنع التضمين إلا إذا تم الحصول على إذن من مالك الخط القانوني عندما يكون هذا هو علم إذن الاستخدام الوحيد.
- `PreviewPrint` يسمح بالاستخدام المؤقت للعرض والطباعة؛ يجب أن يكون المستند الذي يحتوي الخط للقراءة فقط.
- `Editable` يسمح بالاستخدام المؤقت ويتيح تحرير المستند وحفظه.
- `NoSubsetting` هو قيد إضافي يمنع تضمين جزء فقط من الحروف. يجب تضمين جميع الأحرف عندما يكون هذا العلم موجودًا.
- `BitmapOnly` هو قيد إضافي يسمح بتضمين ضربات البت ماب فقط، وليس بيانات المخطط. إذا لم يحتوي الخط على ضربات بت ماب، لا يمكن تضمينه.

القيم الأربعة الأولى تصف إذن الاستخدام، بينما يمكن الجمع بين `NoSubsetting` و `BitmapOnly` معها. تحقق من المعدّلات باستخدام عمليات البت. لأن `Installable` يساوي صفر، قم بإخفاء بتات إذن الاستخدام وقارن النتيجة بـ `Installable` بدلاً من فحصها كعلامة. يجب أن تحدد الخطوط الحالية بتًا واحدًا كحد أقصى لإذن الاستخدام. لضمان التوافق مع الخطوط القديمة التي قد تحدد أكثر من واحد، يختار المساعد أدناه الإذن الأقل تقييدًا: `Editable`، ثم `PreviewPrint`، ثم `Restricted`.

يُجري المثال التالي مراجعة بيانات الخط العادي، العريض، المائل، والعريض المائل المتوفرة لكل خط يُرجَع بواسطة `getFonts`. يتخطى الأنماط غير المتوفرة، الخطوط المقيدة، الخطوط ذات البت ماب فقط، الخطوط المحدودة للمعاينة والطباعة لأن المخرجات تبقى قابلة للتعديل، والخطوط التي تم تضمينها بالفعل. إذا كان لأي نمط متوفر علامة `NoSubsetting`, فإنه يضمّن جميع الأحرف لتلك العائلة من الخطوط.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذا الفحص يُبلغ عن القيود المشفّرة في كل ملف خط. لا يمنح رخصة، ولا يثبت أنك حصلت على الخط قانونيًا، ولا يبدّل فحص اتفاقية ترخيص الخط قبل توزيع نسخة مضمّنة.

## **إضافة خطوط مضمّنة**

استخدم FontsManager.addEmbeddedFont لتضمين خط. تُقبل التحميلات المتعددة إما كائن FontData أو مصفوفة بايت تحتوي على بيانات الخط. تتحكم EmbedFontCharacters في الأحرف التي يتم تضمينها:
- `All` يضمّن جميع الأحرف في الخط. استخدم هذا الخيار عندما يحتاج المستلمون إلى تحرير العرض وإدخال نص جديد.
- `OnlyUsed` يضمّن فقط الأحرف المستخدمة في العرض لتقليل حجم الملف. اختر هذا الخيار للعرض النهائي الذي يُقصد منه العرض الأساسي.

يستخدم المثال التالي FontsManager.getFonts لاسترجاع الخطوط المستخدمة في `Fonts.pptx` ويضمّن الخطوط التي لم تُضمّن بعد. يجب أن تكون الخطوط المراد إضافتها متاحة على الجهاز الذي يُشغّل الشيفرة. تحتفظ الخطوط المضمّنة الحالية بمجموعة الأحرف الخاصة بها.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضغط الخطوط المضمّنة**

[Compress.compressEmbeddedFonts] يقلل من بيانات الخط المضمّن بإزالة الأحرف غير المستخدمة. يعمل على الخطوط التي تم تضمينها بالفعل، لذا يعتمد تقليل الحجم على مقدار بيانات الخط غير المستخدمة الموجودة في العرض.

يقوم المثال التالي بضغط الخطوط في `EmbeddedFonts.pptx` ويحفظ النتيجة كملف منفصل:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

احتفظ بالملف الأصلي إذا قد يحتاج المستلمون إلى إضافة نص لاحقًا. الأحرف التي أزيلت أثناء الضغط لم تعد متاحة من الخط المضمّن، حتى وإن كنت قد ضمنت جميع الأحرف في البداية.

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كان الخط المضمّن سيظل يُستبدل أثناء العرض؟**

استدعِ FontsManager.getSubstitutions في البيئة التي تعرض فيها العرض لتعرف الخطوط التي سيستبدلها Aspose.Slides. تحقق أيضًا من إعدادات [font substitution](/slides/ar/nodejs-java/font-substitution/) وقواعد [font fallback](/slides/ar/nodejs-java/fallback-font/). يتعامل fallback مع الأحرف المفقودة، لذلك لا يُحلّ تضمين الخط الأحرف التي لا يحتويها الخط نفسه.

**هل ينبغي عليّ تضمين الخطوط الشائعة مثل Arial و Calibri؟**

اعتمد القرار على بيئة الهدف. إذا كانت الخطوط المطلوبة متاحة على كل جهاز يفتح أو يعرض العرض، قد يؤدي تضمينها إلى زيادة حجم الملف دون حاجة. إذا كان من الممكن أن يفتقر المستلمون أو الخوادم إلى تلك الخطوط، فإن تضمينها قد يساعد في الحفاظ على المظهر المقصود، بشرط أن تسمح تراخيصها بذلك.