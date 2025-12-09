---
title: حفظ العروض التقديمية في .NET
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/net/save-presentation/
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
- تنسيق Strict Office Open XML
- وضع Zip64
- تجديد الصورة المصغرة
- تقدم الحفظ
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في .NET باستخدام Aspose.Slides — تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[Open Presentations in C#](/slides/ar/net/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء وحفظ العروض التقديمية. فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تحتوي على محتويات العرض. سواء كنت تقوم بإنشاء عرض من الصفر أو تعديل عرض موجود، ستحتاج إلى حفظه عند الانتهاء. باستخدام Aspose.Slides for .NET، يمكنك الحفظ إلى **ملف** أو **تيار**. يشرح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```cs
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // قم ببعض الأعمال هنا...

    // احفظ العرض التقديمي إلى ملف.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية إلى تيارات**

يمكنك حفظ عرض تقديمي إلى تيار بتمرير تيار إخراج إلى طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يمكن كتابة العرض إلى أنواع عديدة من التيارات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تيار ملف.
```cs
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // حفظ العرض التقديمي إلى التيار.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

تتيح لك Aspose.Slides ضبط طريقة العرض الأولية التي يستخدمها PowerPoint عندما يُفتح العرض المولد عبر فئة [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). اضبط الخاصية [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) إلى قيمة من تعداد [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

تتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) واضبط خاصية التوافق عند حفظه. إذا ضبطت `Conformance.Iso29500_2008_Strict`، يتم حفظ الملف الناتج بتنسيق Strict Office Open XML.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Strict Office Open XML.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدًا أقصاه 4 جيجابايت (2^32 بايت) لحجم أي ملف غير مضغوط، وحجم أي ملف مضغوط، وإجمالي حجم الأرشيف، كما يحد عدد الملفات إلى 65 535 (2^16‑1). تمتد تنسيقات ZIP64 هذه الحدود إلى 2^64.

خاصية [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) تتيح لك اختيار متى يتم استخدام امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

توفر هذه الخاصية الأوضاع التالية:

- `IfNecessary` يستخدم امتدادات ZIP64 فقط إذا تجاوز العرض القيود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `Never` لا يستخدم أبداً امتدادات ZIP64.
- `Always` يستخدم دائماً امتدادات ZIP64.

يوضح الكود التالي كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات ZIP64:
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```


{{% alert title="ملاحظة" color="warning" %}}
عند الحفظ باستخدام `Zip64Mode.Never`، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) إذا تعذّر حفظ العرض بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم الخاصية [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) في توليد الصورة المصغرة عند حفظ العرض إلى PPTX:

- إذا تم ضبطها على `true`، تُجدد الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم ضبطها على `false`، تُحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لن يتم توليد أي صورة.

في الكود أدناه، يُحفظ العرض إلى PPTX دون تجديد صورته المصغرة.
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```


{{% alert title="معلومات" color="info" %}}
يساعد هذا الخيار في تقليل الوقت اللازم لحفظ عرض تقديمي بتنسيق PPTX.
{{% /alert %}}

## **تحديثات تقدم الحفظ بالنسبة المئوية**

يُستخدم واجهة [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) عبر الخاصية `ProgressCallback` التي تكشفها واجهة [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). عيّن تنفيذًا لواجهة [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) إلى `ProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

تظهر مقتطفات الشيفرة التالية كيفية استخدام `IProgressCallback`.
```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // استخدم قيمة النسبة المئوية للتقدم هنا.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="معلومات" color="info" %}}
طورت Aspose تطبيقًا مجانيًا لتقسيم PowerPoint ([Free PowerPoint Splitter app](https://products.aspose.app/slides/splitter)) باستخدام واجهتها البرمجية. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عبر حفظ الشرائح المختارة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل؛ لا يُدعم الحفظ التزايدي "السريع".

**هل يمكن حفظ نفس كائن Presentation من عدة خيوط بشكل آمن؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) **ليس آمنًا للخطوط المتعددة**؛ احفظه من خيط واحد فقط.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [الروابط التشعبية](/slides/ar/net/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من بقاء المسارات المشار إليها متاحة.

**هل يمكن ضبط/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم خصائص المستند القياسية [document properties](/slides/ar/net/presentation-properties/) وسيتم كتابتها إلى الملف عند الحفظ.