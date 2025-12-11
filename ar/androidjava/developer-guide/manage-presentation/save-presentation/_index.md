---
title: حفظ العروض التقديمية على Android
linktitle: حفظ عرض تقديمي
type: docs
weight: 80
url: /ar/androidjava/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ عرض تقديمي
- حفظ شريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- عرض تقديمي إلى ملف
- عرض تقديمي إلى تدفق
- نوع عرض محدد مسبقًا
- تنسيق Strict Office Open XML
- وضع Zip64
- تجديد المصغّر
- حفظ التقدم
- Android
- Java
- Aspose.Slides
description: "اكتشف طريقة حفظ العروض التقديمية في Java باستخدام Aspose.Slides for Android — تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والمؤثرات."
---

## **نظرة عامة**

[Open Presentations on Android](/slides/ar/androidjava/open-presentation/) وصف كيف يتم استخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لفتح عرض تقديمي. يوضح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. تحتوي الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) على محتويات العرض. سواء كنت تقوم بإنشاء عرض من الصفر أو تعديل عرض موجود، ستحتاج إلى حفظه عند الانتهاء. باستخدام Aspose.Slides for Android، يمكنك الحفظ إلى **ملف** أو **دفق**. يشرح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` في الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // قم ببعض العمل هنا...

    // احفظ العرض التقديمي إلى ملف.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق إخراج إلى طريقة `save` في الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). يمكن كتابة العرض إلى عدة أنواع من التدفقات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تدفق ملف.
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // حفظ العرض التقديمي إلى التدفق.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يتيح لك Aspose.Slides تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض التقديمي المُولّد عبر الفئة [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/). استخدم طريقة [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/).
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض التقديمية بالتنسيق الصارم Office Open XML**

يتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم الفئة [PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/) وقم بتعيين خاصية الامتثال عند الحفظ. إذا قمت بتعيين [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)، سيتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Strict Office Open XML.
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso2950_2008_Strict);

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدًا قدره 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، والحجم المضغوط لأي ملف، وإجمالي حجم الأرشيف، كما يحد من عدد الملفات إلى 65,535 (2^16-1). توسعات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

تتيح طريقة [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) لك اختيار متى تستخدم توسعات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأنماط التالية:

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) يستخدم توسعات تنسيق ZIP64 فقط إذا تجاوز العرض القيود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) لا يستخدم توسعات تنسيق ZIP64 أبداً.
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) يستخدم توسعات تنسيق ZIP64 دائماً.

الكود التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين توسعات تنسيق ZIP64:
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never)، يتم رفع استثناء [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بدون تحديث المصغّر**

طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) تتحكم في إنشاء المصغّر عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينه إلى `true`، يتم تحديث المصغّر أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم تعيينه إلى `false`، يتم الحفاظ على المصغّر الحالي. إذا لم يكن للعرض مصغّر، فلن يتم إنشاء أي مصغّر.

في الكود أدناه، يتم حفظ العرض إلى PPTX بدون تحديث المصغّر الخاص به.
```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
هذا الخيار يساعد على تقليل الوقت المطلوب لحفظ العرض بتنسيق PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يتم استخدام الواجهة [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) عبر طريقة `setProgressCallback` التي تُظهرها الواجهة [ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/). عيّن تنفيذًا للواجهة [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) باستخدام `setProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

الكود التالي يوضح كيفية استخدام `IProgressCallback`.
```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // استخدم قيمة النسبة المئوية للتقدم هنا.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/splitter) باستخدام واجهة برمجة التطبيقات الخاصة بها. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتداولة**

**هل يتم دعم "الحفظ السريع" (الحفظ المتدرج) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ ملف الهدف الكامل؛ لا يُدعم "الحفظ السريع" المتدرج.

**هل من الآمن من الناحية المتعددة الخيوط حفظ نفس كائن Presentation من خيوط متعددة؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) [ليس آمنًا للاستخدام عبر الخيوط](/slides/ar/androidjava/multithreading/); احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

[Hyperlinks](/slides/ar/androidjava/manage-hyperlinks/) تُحفظ. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا — تأكد من أن المسارات المشار إليها لا تزال متاحة.

**هل يمكنني تعيين/حفظ بيانات تعريف الوثيقة (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تُدعم خصائص الوثيقة القياسية [document properties](/slides/ar/androidjava/presentation-properties/) وسيتم كتابتها إلى الملف عند الحفظ.