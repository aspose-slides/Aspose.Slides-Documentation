---
title: إدارة خطوط المظهر المخصصة للنصوص في JavaScript
linktitle: خطوط المظهر المخصصة للنصوص
type: docs
weight: 15
url: /ar/nodejs-java/script-specific-font-mappings/
keywords:
- خط مخصص للنص
- تعيين خط المظهر
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلكي
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض
- Node.js
- JavaScript
- Aspose.Slides
description: "فحص، إضافة، استبدال، وإزالة تعيينات خطوط مخصصة للنص في سمات PowerPoint باستخدام Aspose.Slides لـ Node.js."
---
## **نظرة عامة**

يمكن لمظهر العرض اختيار مجموعات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك نصًا متعدد اللغات يستخدم خطوط المظهر مع الحفاظ على نظام خطوط موحد مع استخدام خطوط مناسبة للسيريلية والعربية واليابانية والجورجية والاثانا وغيرها من النصوص.

يحتوي [FontScheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) في المظهر على مجموعة خطوط رئيسية تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية تُستخدم عادةً لنص الجسم. بالإضافة إلى إعدادات الخطوط اللاتينية والآسيوية الشرقية، تُظهر كلتا المجموعتين خرائط من وسوم أنظمة الكتابة إلى أسماء عائلات الخط عبر فئة [Fonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/).

تُظهر هذه المقالة كيفية فحص وتعديل تلك الخرائط في المظهر الرئيسي للعرض والتحقق من بقاء التغييرات بعد دورة الحفظ وإعادة التحميل.

## **فهم وسوم النصوص**

تستخدم طرق الخط النصي وسوم نصية تتكون من أربعة أحرف وفقًا لـ BCP 47 لتحديد أنظمة الكتابة. تشمل القيم الشائعة:

| علامة النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | الأثانا |

تنتمي هذه الخرائط إلى مخطط خطوط المظهر، وليس إلى أجزاء النص الفردية. قد يعرّف العرض خرائط مختلفة للمجموعتين الرئيسيين والفرعيين، وقد يتجاوز تعريف خرائط لبعض النصوص.

## **الوصول إلى وفحص خرائط خطوط النصوص**

استخدم [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/) للوصول إلى مظهر المستوى العام للعرض. تُعيد طُرُق [FontScheme.getMajor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontscheme/) المجموعتين [Fonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/).

استدعِ [Fonts.getScriptFontMap](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/) لاسترجاع جميع الخرائط من مجموعة معينة. للبحث عن نظام كتابة واحد، استدعِ [Fonts.getScriptFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/) بوسم النص الخاص به. تُعيد `getScriptFont` القيمة `null` عندما لا تُعرّف تلك المجموعة الخريطة المطلوبة.

## **تعديل الخرائط والتحقق من الاستمرارية**

استخدم [Fonts.setScriptFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/) لإنشاء خريطة أو استبدال عائلة الخط الحالية. استخدم [Fonts.removeScriptFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/) لإزالة خريطة.

المثال التالي يقرأ جميع الخرائط الرئيسة والفرعية الحالية، يبحث عن الخط الياباني الرئيس، يغيّر الخط السيريلية الرئيس، يزيل خريطة الأثانا الفرعية، يحفظ العرض، ثم يعيده ليتحقق من كِلَ التغييرات. لجعل خطوة الإزالة مستقلة عن المظهر الأولي، يُنشئ المثال خريطة أثانا فقط عندما لا تكون مُعرّفة مسبقًا.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

يستخدم التحقق نفس سلوك `null` كما هو الحال في عملية البحث العادية: بعد حفظ الإزالة، تُعيد `getScriptFont("Thaa")` القيمة `null` للمجموعة الفرعية.

## **تمييز خرائط المظهر عن إعدادات الخط الأخرى**

تشارك خرائط المظهر الخاصة بالنص في اختيار الخط، لكنها تحل مشكلة مختلفة عن تنسيق النص المباشر، والاستبدال، والعودة الافتراضية:

| الآلية | الغرض | تأثير تغيير تعيين الخط في السمة |
|---|---|---|
| تعيين خط المظهر الخاص بالنص | يختار خطًا رئيسيًا أو فرعيًا من المظهر لنظام كتابة معين. | النص الذي لا يزال يستخدم خط المظهر المقابل يمكنه حل إلى عائلة الخط الجديدة المحددة. |
| الخط المعيّن صراحةً لجزء نص | يثبت عائلة الخط المطلوبة لهذا الجزء بدلاً من الاعتماد على المظهر. | قد يظل الجزء بدون تغيير لأن التنسيق المباشر يتجاوز اختيار المظهر. |
| استبدال الخط | يستبدل الخط المطلوب عندما يكون غير متوفر أو عندما تنطبق قاعدة استبدال. | يعمل بعد طلب الخط؛ لا يعيد تعريف خريطة النص في المظهر. |
| العودة الافتراضية للخط | تزود بالحروف التي لا يحتويها الخط المحدد، غالبًا لنطاقات يونيكود معينة. | يملأ الفجوات في الحروف؛ لا يغيّر خريطة المظهر المخزنة. |

لمزيد من المعلومات حول الآليتين الأخيرتين، انظر [Font Substitution](/slides/ar/nodejs-java/font-substitution/) و[Fallback Fonts](/slides/ar/nodejs-java/fallback-font/).

تغيير خريطة في [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getmastertheme/) يؤثر فقط على المحتوى الذي لا يزال تنسيقه الفعلي يعتمد على ذلك المظهر. قد يرث النص بدلاً من ذلك تجاوز المظهر من ماستر أو تخطيط أو شريحة، أو يستخدم خطًا مُعيّنًا صراحةً. افحص تلك المستويات عندما لا يتبع النتيجة الظاهرة خريطة المستوى العام للعرض.

## **إتاحة الخطوط المُحددة والتحقق من النتيجة**

تخزن خريطة النص اسم عائلة الخط؛ لا تقوم بتثبيت أو تحميل ملف الخط المقابل. لضمان عرض وتصدير متسق، يجب تثبيت كل خط مُحدّد في البيئة أو إمداده إلى Aspose.Slides عبر مصدر مخصص مثل [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) أو [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/). راجع [Custom Fonts](/slides/ar/nodejs-java/custom-font/) للخيارات المتاحة للتحميل.

يؤكد التحقق من الخريطة المحفوظة فقط أن تعريف المظهر تم الحفاظ عليه. لا يثبت أن الخط متاح، أو يحتوي على جميع الحروف المطلوبة، أو ينتج التخطيط المقصود. قم بإنشاء نص تمثيلي لكل نظام كتابة مطلوب إلى صورة أو PDF وافحص الناتج. يكتشف ذلك الخطوط المفقودة، ونقص تغطية الحروف، وسلوك العودة الافتراضية، وتغييرات التخطيط قبل توزيع العرض. انظر [Convert PowerPoint Presentations](/slides/ar/nodejs-java/convert-powerpoint/) لأمثلة العرض والتصدير.

## **الأسئلة المتكررة**

**ماذا تُعيد `getScriptFont` عندما لا تكون النصوص مُحدّدة؟**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/) تُعيد `null` عندما لا تكون خريطة النص المطلوبة مُعرّفة في تلك المجموعة الرئيسة أو الفرعية.

**هل `setScriptFont` يضيف خريطة ثانية عندما يكون النص موجودًا بالفعل؟**

لا. [Fonts.setScriptFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fonts/) تُنشئ الخريطة عندما تكون مفقودة وتستبدل عائلة الخط المُحددة عندما يكون وسم النص نفسه موجودًا بالفعل.

**لماذا لم يُغيّر تعديل خريطة المظهر بعض النصوص؟**

قد يكون للنص خط مُعيّن صراحةً، أو يرث مظهرًا مختلفًا عبر تجاوز، أو يتأثر بالاستبدال أو العودة الافتراضية أثناء العرض. خريطة النص على مستوى العرض تتحكم فقط في النص الذي لا يزال تنسيقه الفعلي يشير إلى مجموعة خطوط المظهر تلك.

**هل يكفي حفظ وإعادة الفتح للتحقق من المخرجات متعددة اللغات؟**

لا. إعادة الفتح تُؤكّد بقاء بيانات المظهر. يجب أيضًا عرض نص تمثيلي من كل نظام كتابة مطلوب للتحقق من أن الخطوط المُحدّدة متاحة وتحتوي على الحروف اللازمة.