---
title: حفظ العروض التقديمية على Android
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/androidjava/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تدفق
- نوع عرض محدد مسبقًا
- تنسيق Strict Office Open XML
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في Java باستخدام Aspose.Slides لأجهزة Android—تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[Open Presentations on Android](/slides/ar/androidjava/open-presentation/) يشرح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لفتح عرض تقديمي. يوضح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) تحتوي على محتوى العرض التقديمي. سواءً كنت تنشئ عرضًا من الصفر أو تعدل عرضًا موجودًا، فستحتاج إلى حفظه عند الانتهاء. مع Aspose.Slides for Android، يمكنك الحفظ إلى **ملف** أو **دفق**. يوضح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

يمكنك حفظ عرض تقديمي إلى تدفق بتمرير تدفق إخراج إلى طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى العديد من أنواع التدفقات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تدفق ملف.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

تتيح لك Aspose.Slides تعيين طريقة العرض الأولية التي يستخدمها PowerPoint عند فتح العرض التقديمي المُولد عبر فئة [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/). استخدم طريقة [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/).
```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض التقديمية بصيغة Strict Office Open XML**

تتيح لك Aspose.Slides حفظ عرض تقديمي بصيغة Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/) واضبط الخاصية `conformance` عند الحفظ. إذا ضبطت [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict)، يتم حفظ الملف الناتج بصيغة Strict Office Open XML.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بصيغة Strict Office Open XML.
```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation();
try {
    // حفظ العرض التقديمي بصيغة Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا تبلغ 4 GB (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الضغط لأي ملف، وإجمالي حجم الأرشيف، ويقيد الأرشيف بـ 65 535 (2^16‑1) ملفًا. توسعات صيغة ZIP64 ترفع هذه الحدود إلى 2^64.

طريقة [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) تتيح لك اختيار متى تستخدم توسعات صيغة ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأنماط التالية:

- [IfNecessary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#IfNecessary) يستخدم توسعات ZIP64 فقط إذا تجاوز العرض التقديمي القيود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never) لا يستخدم توسعات ZIP64 مطلقًا.
- [Always](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Always) يستخدم توسعات ZIP64 دائمًا.

الكود التالي يوضح كيفية حفظ عرض تقديمي كـ PPTX مع تمكين توسعات صيغة ZIP64:
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
عند الحفظ باستخدام [Zip64Mode.Never](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zip64mode/#Never)، يتم رمي استثناء [PptxException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بصيغة ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) تتحكم في توليد الصورة المصغرة عند حفظ العرض التقديمي كـ PPTX:

- إذا تم ضبطها إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم ضبطها إلى `false`، يتم الحفاظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، لن تُولد أي صورة.

في الكود أدناه، يتم حفظ العرض التقديمي إلى PPTX دون تحديث صورته المصغرة.
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
هذه الخاصية تساعد على تقليل الوقت المطلوب لحفظ العرض التقديمي بصيغة PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يتم استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) عبر طريقة `setProgressCallback` التي تُعرضها واجهة [ISaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/). عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprogresscallback/) باستخدام `setProgressCallback` لتلقي تحديثات التقدم في الحفظ كنسبة مئوية.

المقاطع البرمجية التالية توضح كيفية استخدام `IProgressCallback`.
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
        // استخدم قيمة نسبة التقدم هنا.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}
طورت Aspose تطبيقًا مجانيًا لتقسيم ملفات PowerPoint باستخدام API الخاص بها. يتيح التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم دعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف الكامل من جديد؛ الحفظ التزايدي "السريع" غير مدعوم.

**هل يمكن حفظ نفس كائن Presentation من عدة خيوط بشكل آمن؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) غير آمن للاستخدام المتعدد الخيوط؛ احفظه من خيط واحد فقط.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

[Hyperlinks](/slides/ar/androidjava/manage-hyperlinks/) يتم الحفاظ عليها. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من بقاء المسارات المشار إليها متاحة.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم خصائص [document properties](/slides/ar/androidjava/presentation-properties/) القياسية وسيتم كتابتها إلى الملف عند الحفظ.