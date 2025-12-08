---
title: حفظ العروض التقديمية في .NET
linktitle: حفظ العروض التقديمية
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
- عرض تقديمي إلى ملف
- عرض تقديمي إلى تيار
- نوع عرض مسبق التعريف
- تنسيق Strict Office Open XML
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في .NET باستخدام Aspose.Slides—تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والمؤثرات."
---

## **نظرة عامة**

[فتح العروض التقديمية في C#](/slides/ar/net/open-presentation/) يوضح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تحتوي على محتويات العرض. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدّل عرضًا موجودًا، فستحتاج إلى حفظه عندما تنتهي. مع Aspose.Slides for .NET يمكنك الحفظ إلى **ملف** أو **تيار**. يوضح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // قم ببعض الأعمال هنا...

    // حفظ العرض التقديمي إلى ملف.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية إلى تيارات**

يمكنك حفظ عرض تقديمي إلى تيار بتمرير تيار إخراج إلى طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يمكن كتابة العرض إلى العديد من أنواع التيارات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تيار ملف.
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

يتيح لك Aspose.Slides تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض المولد عبر فئة [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). عيّن خاصية [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) إلى قيمة من تعداد [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) وعين خاصية التوافق عند الحفظ. إذا عينت `Conformance.Iso29500_2008_Strict`، يتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

يوضح المثال أدناه إنشاء عرض تقديمي وحفظه بتنسيق Strict Office Open XML.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا بحجم 4 GB (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم ضغط أي ملف، وإجمالي حجم الأرشيف، كما يحد عدد الملفات إلى 65 535 (2^16‑1). تمددات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

خاصية [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) تتيح لك اختيار متى تُستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

توفر هذه الخاصية الأوضاع التالية:

- `IfNecessary` يستخدم امتدادات ZIP64 فقط إذا تجاوز العرض القيود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `Never` لا يستخدم امتدادات ZIP64 أبدًا.
- `Always` يستخدم امتدادات ZIP64 دائمًا.

يعرض الكود التالي كيفية حفظ عرض تقديمي كـ PPTX مع تمكين امتدادات تنسيق ZIP64:
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```


{{% alert title="NOTE" color="warning" %}}

عند الحفظ باستخدام `Zip64Mode.Never`، يُطرح استثناء [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) إذا تعذّر حفظ العرض بتنسيق ZIP32.

{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

خاصية [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) تتحكم في إنشاء الصورة المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا عُينت إلى `true`، تُحدث الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا عُينت إلى `false`، تُحفظ الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لن يُنشأ أي شيء.

في الكود أدناه، يُحفظ العرض إلى PPTX دون تحديث صورته المصغرة.
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```


{{% alert title="Info" color="info" %}}

يساعد هذا الخيار في تقليل الزمن المطلوب لحفظ العرض بتنسيق PPTX.

{{% /alert %}}

## **تحديثات حفظ التقدم كنسبة مئوية**

يُستخدم واجهة [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) عبر خاصية `ProgressCallback` التي تعرّضها واجهة [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) إلى `ProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

يعرض مقتطفات الكود التالية كيفية استخدام `IProgressCallback`.
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
        // استخدم قيمة نسبة التقدم هنا.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```


{{% alert title="Info" color="info" %}}

طوّرت Aspose تطبيقًا مجانيًا لتقسيم PowerPoint باستخدام واجهتها البرمجية الخاصة. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة بحفظ الشرائح المختارة كملفات PPTX أو PPT جديدة.

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم "الحفظ السريع" (الحفظ التدريجي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل؛ الحفظ التدريجي "السريع" غير مدعوم.

**هل يمكن حفظ نفس كائن Presentation من عدة خيوط بشكل آمن؟**

لا. كائن [Presentation](/slides/ar/net/multithreading/) غير آمن للخلية المتعددة؛ احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجياً عند الحفظ؟**

يتم الحفاظ على [الروابط التشعبية](/slides/ar/net/manage-hyperlinks/). الملفات المرتبطة خارجياً (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من بقاء المسارات المشار إليها متاحة.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تُدعم خصائص المستند القياسية [/slides/net/presentation-properties/] وسيتم كتابتها إلى الملف عند الحفظ.