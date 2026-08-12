---
title: حفظ العروض التقديمية في JavaScript
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/nodejs-java/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تيار
- نوع عرض مسبق التعريف
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف طريقة حفظ العروض التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java—تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والمؤثرات."
---
## **نظرة عامة**

[Open Presentations in JavaScript](/slides/ar/nodejs-java/open-presentation/) يصف كيفية استخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. تحتوي الفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) على محتويات العرض التقديمي. سواءً كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل أحد العروض الموجودة، فستحتاج إلى حفظه عند الانتهاء. باستخدام Aspose.Slides لـ Node.js، يمكنك الحفظ إلى **ملف** أو **تيار**. يوضح هذا المقال الطرق المختلفة لحفظ العرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // أجرِ بعض الأعمال هنا...

    // احفظ العرض التقديمي إلى ملف.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تيار عن طريق تمرير تدفق إخراج إلى طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى عدة أنواع من التيارات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تدفق ملف.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // احفظ العرض التقديمي إلى التدفق.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

تتيح لك Aspose.Slides تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض المولد عبر الفئة [ViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/). استخدم طريقة [setLastView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#setLastView) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية في تنسيق Office Open XML الصارم**

تتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Office Open XML الصارم. استخدم الفئة [PptxOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/) وقم بتعيين خاصية التوافق عند الحفظ. إذا قمت بتعيين [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)، سيتم حفظ الملف الناتج بتنسيق Office Open XML الصارم.

يظهر المثال أدناه كيفية إنشاء عرض تقديمي وحفظه بتنسيق Office Open XML الصارم.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // احفظ العرض التقديمي بالتنسيق الصارم Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وعلى الحجم المضغوط لأي ملف، وعلى إجمالي حجم الأرشيف، كما يحد من عدد الملفات إلى 65 535 (2^16‑1). ترفع امتدادات تنسيق ZIP64 هذه الحدود إلى 2^64.

تتيح لك طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأوضاع التالية:

- [IfNecessary](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#IfNecessary) يستخدم امتدادات ZIP64 فقط إذا تجاوز العرض الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#Never) لا يستخدم امتدادات ZIP64 أبدًا.
- [Always](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#Always) يستخدم امتدادات ZIP64 دائمًا.

المثال التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zip64mode/#Never)، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

عند العمل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق توازن بين حجم الملف وزمن المعالجة. بناءً على متطلباتك، قد تفضّل معالجة أسرع أو ملفات ناتجة أصغر.

توفر Aspose.Slides طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) التي تسمح لك بتحديد مستوى الضغط المستخدم عند حفظ عرض تقديمي بتنسيق Office Open XML.

المستويات المتاحة هي:

- [**None**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#None): لا يُطبق ضغط. تُخزن الملفات كما هي.
- [**Level1**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level1): أسرع ضغط مع أقل نسبة ضغط.
- [**Level2**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level2): ضغط أسرع مع نسبة ضغط أفضل قليلاً من **Level1**.
- [**Level3**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level3): يوفر ضغطًا أفضل من **Level2** مع تأثير متوسط على زمن المعالجة.
- [**Level4**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level4): يوفر ضغطًا أفضل من **Level3**.
- [**Level5**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level5): يحسن الضغط مقارنةً بـ **Level4** مع زمن معالجة إضافي.
- [**Level6**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level6): ضغط قياسي يقدّم توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- [**Level7**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level7): يوفر ضغطًا أفضل من **Level6** مع معالجة أبطأ.
- [**Level8**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level8): يوفر ضغطًا أفضل من **Level7**.
- [**Level9**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compressionlevel/#Level9): أقصى ضغط. ينتج أصغر حجم ملف على حساب أطول زمن معالجة.

المثال التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

هذا المثال يوضح كيفية حفظ عرض تقديمي كملف PPTX مع *أقصى ضغط*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) في توليد الصورة المصغرة عند حفظ العرض إلى PPTX:

- إذا تم تعيينها إلى `true`، يتم تجديد الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم تعيينها إلى `false`، تُحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض مصغرة، لا تُولد أي صورة.

في الشيفرة أدناه، يُحفظ العرض إلى PPTX دون تجديد الصورة المصغرة.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
هذا الخيار يساعد على تقليل الوقت المطلوب لحفظ عرض تقديمي بتنسيق PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يتم تكوين تقارير تقدم الحفظ عبر طريقة [setProgressCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) على الفئة [SaveOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/saveoptions/) وفئاتها الفرعية. قدّم وكيل Java يطبق واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprogresscallback/); أثناء التصدير، يتلقى النداء العكسي تحديثات دورية بالنسب المئوية.

المقتطفات البرمجية التالية توضح كيفية استخدام `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // استخدم قيمة النسبة المئوية للتقدم هنا.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
طورت Aspose تطبيقًا مجانيًا لتقسيم PowerPoint باستخدام API الخاص بها. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المختارة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يتم دعم "الحفظ السريع" (الحفظ المتدرج) بحيث يتم كتابة التغييرات فقط؟**

لا. كل مرة يتم الحفظ يُنشئ ملف الهدف بالكامل؛ لا يُدعم الحفظ المتدرج "السريع".

**هل حفظ نفس مثيل [Presentation] من عدة خيوط آمن من حيث الخيوط؟**

لا. مثيل [Presentation] غير آمن للخيوط [ليس خيطيًا](/slides/ar/nodejs-java/multithreading/); احفظه من خيط واحد.

**ماذا يحدث لل[الروابط](/slides/ar/nodejs-java/manage-hyperlinks/) والملفات المرتبطة خارجيًا عند الحفظ؟**

تُحفظ الروابط كما هي. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—يجب التأكد من بقاء المسارات المشار إليها قابلة للوصول.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تدعم خصائص المستند القياسية [خصائص المستند](/slides/ar/nodejs-java/presentation-properties/) وسيتم كتابتها إلى الملف عند الحفظ.