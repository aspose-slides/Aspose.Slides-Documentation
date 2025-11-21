---
title: حفظ العروض التقديمية في جافا سكريبت
linktitle: حفظ العروض التقديمية
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
- العرض إلى ملف
- العرض إلى تدفق
- نوع عرض مسبق التعريف
- تنسيق Strict Office Open XML
- وضع Zip64
- تجديد الصورة المصغرة
- حفظ التقدم
- Node.js
- جافا سكريبت
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في جافا سكريبت باستخدام Aspose.Slides—تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[فتح العروض التقديمية في جافا سكريبت](/slides/ar/nodejs-java/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) لفتح عرض تقديمي. تشرح هذه المقالة كيفية إنشاء العروض وتخزينها. فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) تحتوي على محتويات العرض. سواء كنت تنشئ عرضًا من الصفر أو تعدل عرضًا موجودًا، ستحتاج إلى حفظه عندما تنتهي. مع Aspose.Slides لـ Node.js، يمكنك الحفظ إلى **ملف** أو **تيار**. توضح هذه المقالة الطرق المختلفة لحفظ العرض.

## **حفظ العروض إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // تنفيذ بعض الأعمال هنا...

    // حفظ العرض التقديمي إلى ملف.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض إلى التيارات**

يمكنك حفظ عرض تقديمي إلى تيار بتمرير تيار إخراج إلى طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). يمكن كتابة العرض إلى أنواع متعددة من التيارات. في المثال أدناه، نقوم بإنشاء عرض جديد ونحفظه إلى تيار ملف.
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // حفظ العرض التقديمي إلى التيار.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **حفظ العروض بنوع عرض مسبق التعريف**

Aspose.Slides يتيح لك تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض المُنشأ من خلال فئة [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/). استخدم طريقة [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/).
```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض بتنسيق Strict Office Open XML**

Aspose.Slides يتيح لك حفظ العرض بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) وحدد خاصية `conformance` عند الحفظ. إذا ضبطت [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)، يتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

المثال أدناه يُنشئ عرضًا ويحفظه بتنسيق Strict Office Open XML.
```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation();
try {
    // حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدود 4 GB (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الضغط لأي ملف، وإجمالي حجم الأرشيف، كما يحد من عدد الملفات إلى 65 535 (2^16‑1). امتدادات صيغة ZIP64 ترفع هذه الحدود إلى 2^64.

طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) تتيح لك اختيار متى تستخدم امتدادات صيغة ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأنماط التالية:

- [IfNecessary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#IfNecessary) يستخدم امتدادات صيغة ZIP64 فقط إذا تجاوز العرض الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) لا يستخدم امتدادات صيغة ZIP64 أبداً.
- [Always](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Always) يستخدم امتدادات صيغة ZIP64 دائماً.

المقطع البرمجي التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات صيغة ZIP64:
```js
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
عند الحفظ باستخدام Zip64Mode.Never، يتم طرح استثناء PptxException إذا تعذر حفظ العرض بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض دون تجديد الصورة المصغرة**

طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) تتحكم في توليد الصورة المصغرة عند حفظ العرض إلى PPTX:

- إذا تم تعيينه إلى `true`، يتم تجديد الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم تعيينه إلى `false`، يتم الحفاظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لن يتم إنشاء أي واحدة.

في الكود أدناه، يتم حفظ العرض إلى PPTX دون تجديد صورته المصغرة.
```js
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
هذا الخيار يساعد على تقليل الوقت المطلوب لحفظ العرض بتنسيق PPTX.
{{% /alert %}}

## **تحديثات حفظ التقدم بالنسبة المئوية**

تقارير تقدم الحفظ تُضبط عبر طريقة [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) في فئة [SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) وفئاتها الفرعية. قدم وكيل Java يطبق واجهة [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/); أثناء التصدير، يستقبل النداء التلقائي تحديثات دورية بنسب مئوية.

المقاطع البرمجية التالية توضح كيفية استخدام `IProgressCallback`.
```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // استخدم قيمة نسبة التقدم هنا.
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
قامت Aspose بتطوير تطبيق مجاني لتقسيم عروض PowerPoint باستخدام واجهتها البرمجية الخاصة. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتداولة**

**هل يتم دعم "الحفظ السريع" (الحفظ التدريجي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل في كل مرة؛ الحفظ التدريجي "السريع" غير مدعوم.

**هل حفظ نفس كائن Presentation من عدة خيوط آمن من ناحية التزامن؟**

لا. كائن [Presentation](/slides/ar/nodejs-java/multithreading/) غير آمن للتزامن؛ احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [Hyperlinks](/slides/ar/nodejs-java/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من بقاء المسارات المشار إليها قابلة للوصول.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم خصائص المستند القياسية وستُكتب إلى الملف عند الحفظ.