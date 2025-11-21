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
- العرض التقديمي إلى تدفق
- نوع عرض مسبق التعريف
- تنسيق Strict Office Open XML
- وضع Zip64
- تجديد الصورة المصغرة
- حفظ التقدم
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في .NET باستخدام Aspose.Slides—التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[Open Presentations in C#](/slides/ar/net/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) تحتوي على محتويات العرض التقديمي. سواءً كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل عرضًا موجودًا، ستحتاج إلى حفظه عندما تنتهي. مع Aspose.Slides لـ .NET، يمكنك الحفظ إلى **ملف** أو **دفق**. يشرح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

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


## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق إخراج إلى طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى أنواع متعددة من التدفقات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تدفق ملف.
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // حفظ العرض التقديمي إلى التدفق.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

يتيح لك Aspose.Slides تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض التقديمي المُنشأ عبر فئة [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). اضبط خاصية [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) على قيمة من تعداد [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) واضبط خاصية الالتزام عند الحفظ. إذا قمت بضبط `Conformance.Iso29500_2008_Strict`، سيتم حفظ الملف الناتج بتنسيق Strict Office Open XML.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Strict Office Open XML.
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

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا بحجم 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الضغط لأي ملف، وإجمالي حجم الأرشيف، كما يحد من الأرشيف إلى 65 535 (2^16‑1) ملف. امتدادات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

خاصية [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) تسمح لك باختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

توفر هذه الخاصية الأوضاع التالية:

- `IfNecessary` يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `Never` لا يستخدم امتدادات تنسيق ZIP64 أبدًا.
- `Always` يستخدم دائمًا امتدادات تنسيق ZIP64.

الكود التالي يوضح كيفية حفظ عرض تقديمي كـ PPTX مع تمكين امتدادات تنسيق ZIP64:
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
عند الحفظ باستخدام `Zip64Mode.Never`، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

خاصية [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) تتحكم في توليد الصورة المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينها إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. وهذا هو الإعداد الافتراضي.
- إذا تم تعيينها إلى `false`، تُحفظ الصورة المصغرة الحالية كما هي. إذا لم يكن للعرض التقديمي صورة مصغرة، لن يتم إنشاء واحدة.

في الكود أدناه، يُحفظ العرض التقديمي إلى PPTX دون تحديث الصورة المصغرة.
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
هذا الخيار يساعد في تقليل الوقت المستغرق لحفظ العرض التقديمي بصيغة PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يتم استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) عبر الخاصية `ProgressCallback` التي تقدمها واجهة [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) إلى `ProgressCallback` لتستقبل تحديثات تقدم الحفظ كنسبة مئوية.

الكود التالي يوضح كيفية استخدام `IProgressCallback`.
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


{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير تطبيق مجاني لتقسيم PowerPoint ([free PowerPoint Splitter app](https://products.aspose.app/slides/splitter)) باستخدام واجهتها البرمجية الخاصة. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يتم دعم "الحفظ السريع" (الحفظ التدريجي) بحيث تُكتب فقط التغييرات؟**

لا. كل عملية حفظ تُنشئ الملف الهدف كاملًا في كل مرة؛ لا يُدعم الحفظ التدريجي "fast save".

**هل يمكن حفظ نفس مثيل Presentation من عدة خيوط في آن واحد بأمان؟**

لا. مثيل [Presentation](/slides/ar/net/multithreading/) غير آمن للاستخدام المتعدد الخيوط؛ احفظه من خيط واحد فقط.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [Hyperlinks](/slides/ar/net/manage-hyperlinks/). الملفات المرتبطة خارجيا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من أن المسارات المشار إليها ما زالت متاحة.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم خصائص المستند القياسية [/slides/net/presentation-properties/]، وستُكتب إلى الملف عند الحفظ.