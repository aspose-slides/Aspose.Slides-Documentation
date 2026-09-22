---
title: تحديد تنسيق العرض الأصلي في Node.js
linktitle: تنسيق المصدر
type: docs
weight: 35
url: /ar/nodejs-java/detect-presentation-source-format/
keywords:
- تنسيق المصدر
- اكتشاف تنسيق العرض
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "قراءة التنسيق الأصلي لعرض تم تحميله في Node.js باستخدام Aspose.Slides for Node.js عبر Java، مقارنة واجهات الكشف، ومعالجة الملفات، التدفقات، والتنسيقات القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، استدعِ طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSourceFormat) لتحديد تنسيقه الأصلي. استخدمها عندما تعتمد المعالجة اللاحقة على التنسيق الذي تم تحميل المثيل الحالي منه.

تنسيق المصدر يختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) المحدد لملف الإخراج. الحفظ إلى تنسيق آخر لا يغيّر تنسيق المصدر للمثيل الحالي.

## **قراءة تنسيق المصدر لملف**

هذا المثال يتطلب وجود ملف `sample.pptx`. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSourceFormat)، بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة صيغ أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **التعرف على القيم المدعومة**

الفئة [SourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sourceformat/) تعرف ثابتات عددية تميز صيغ العروض التقديمية التالية. الامتدادات أدناه هي امتدادات تقليدية، ليست إعادة إنشاء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | التنسيق |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض Office Open XML |
| `Pptm` | `.pptm` | عرض Office Open XML مع تمكين الماكرو |
| `Pps` | `.pps` | عرض شرائح PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شرائح Office Open XML |
| `Ppsm` | `.ppsm` | عرض شرائح Office Open XML مع تمكين الماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML مع تمكين الماكرو |
| `Odp` | `.odp` | عرض OpenDocument |
| `Otp` | `.otp` | قالب عرض OpenDocument |
| `Fodp` | `.fodp` | عرض Flat XML ODF |
| `Xml` | `.xml` | عرض PowerPoint XML |

## **قراءة تنسيق المصدر لتدفق**

هذا المثال يتطلب وجود ملف `sample.pps`. قراءة بايتاته في تدفق ذاكرة يحاكي الإدخال المستلم دون اسم ملف، مثل قيمة قاعدة بيانات أو مصفوفة بايتات تم تحميلها. يستقبل المُنشئ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) التدفق فقط.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT وPPS وPOT تستخدم نفس التنسيق الثنائي الأساسي. عند التحميل عبر مسار ملف، يمكن للامتداد أن يساعد في تمييز عرض الشرائح أو القالب. بدون اسم ملف، قد يُبلّغ عن محتوى PPS أو POT قديم كـ `SourceFormat.Ppt`؛ يطبع مثال PPS أعلاه القيمة العددية لـ `SourceFormat.Ppt`.

إذا كان تطبيقك بحاجة إلى الحفاظ على التمييز، احتفظ باسم الملف الأصلي أو بيانات التعريف الفرعية بشكل منفصل. يعتبر الامتداد إشارة مفيدة لهذه الأنواع القديمة، لكنه لا يجب أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) و[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) عندما تحتاج لفحص ملف قبل تحميل نموذج كائن العرض التقديمي بالكامل. استخدم [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSourceFormat) عندما يكون المثيل موجوداً بالفعل.

هذا المثال يتطلب `sample.pptx` ويطبع القيم العددية لـ `LoadFormat.Pptx` و`SourceFormat.Pptx` على التوالي. في بيئة الإنتاج، اختر الـ API المناسب لمرحلة المعالجة؛ العرض المحمّل مسبقاً لا يحتاج إلى فحص ثانٍ فقط للحصول على تنسيق المصدر.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

تستخدم النتائج ثابتات من فئات مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadformat/) و[SourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sourceformat/). لا تقارن قيمها العددية ولا تفترض أن كل تنسيق له نتائج كشف متماثلة. قد يُبلّغ عن PowerPoint XML كـ `LoadFormat.Unknown` قبل التحميل و`SourceFormat.Xml` بعد التحميل.

## **الحفاظ على فصل تنسيقات المصدر والإخراج**

هذا المثال يتطلب `sample.pptx` ويكتب `converted.odp`. يطبع القيمة العددية لـ `SourceFormat.Pptx` قبل وبعد حفظ المثيل الأصلي. فقط المثيل الجديد المحمّل من مخرجات ODP يُبلغ عن `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

العرض الذي يُنشأ من الصفر باستخدام `new Presentation()` يُبلغ عن `SourceFormat.Pptx`. لا يوجد له ملف إدخال: هذه هي القيمة الافتراضية لمثيل تم إنشاؤه حديثاً، وليست دليلًا على تحميل ملف PPTX. تابع ما إذا كان تطبيقك قد أنشأ أو حمّل المثيل بشكل منفصل إذا كان هذا التمييز مهمًا.

## **ربط تنسيق المصدر بامتداد**

المثال التالي يتطلب `sample.pptx`. يربط كل قيمة من قيم [SourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sourceformat/) المدعومة حالياً بامتداد تقليدي، دون تحليل اسم الملف المدخل. يتجنب fallback إسناد امتداد بصمت لقيمة غير معروفة.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

هذا الربط لا يُحوِّل ملفًا ولا يستعيد نوع فرعي قديم PPS/POT ضائع أثناء تحميل التدفق. للحفظ الفعلي، اختر [SaveFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveformat/) صراحةً، أو استخدم التحويل المذكور في [Save Presentations in Their Original Format](/slides/ar/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **تحقق من التنسيقات عن طريق الحفظ وإعادة الفتح**

هذا المثال المستقل يُنشئ عرضًا تقديميًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلاً الملفات ذات الأسماء نفسها. يعيد فتح كل مخرج إما عبر المسار أو عبر تدفق ذاكرة. بالنسبة إلى PPTX وODP، كلا المسارين يُبلغان عن التنسيق المحفوظ. بالنسبة إلى PPS، يُبلغ التحميل عبر المسار عن `Pps`، بينما يُبلغ تحميل البايتات نفسها دون اسم ملف عن `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

الجدول التالي يلخّص تعريف تنسيق المصدر للعروض التي لها امتدادات متطابقة. الأسماء تشير إلى ثابتات؛ الأمثلة بجافاسكريبت تطبع قيمها العددية:

| التنسيق المحفوظ | SourceFormat من مسار ملف | SourceFormat من تدفق بلا اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | نفس مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | نفس مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | نفس مسار الملف |
| ODP, OTP | `Odp`, `Otp` respectively | نفس مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

يُحدد محتوى PPS/POT كـ `Ppt` في التدفقات بلا اسم. يصف الجدول تعريف التنسيق وليس الحفاظ على كل ميزات العرض أثناء التحويل.

## **الأسئلة المتكررة**

**هل يحفظ إلى ODP يغيّر تنسيق المصدر لعرض تم تحميله من PPTX؟**

لا. المثيل الحالي لا يزال يُبلغ عن `Pptx`. المثيل المحمّل من ملف ODP المحفوظ يُبلغ عن `Odp`.

**هل يمكن للتدفق دائمًا التمييز بين عرض قديم، عرض شرائح، وقالب؟**

لا. PPT وPPS وPOT تشترك في التنسيق الثنائي. احتفظ باسم الملف أو بيانات التعريف الفرعية بشكل منفصل عندما يكون هذا التمييز مطلوبًا.

**أي API يجب أن أستخدمه إذا كان العرض محمَّلاً مسبقًا؟**

اقرأ [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSourceFormat). استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) للفحص قبل التحميل.