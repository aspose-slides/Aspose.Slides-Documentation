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
- نوع عرض محدد مسبقًا
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث المصغرة
- تقدم الحفظ
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في .NET باستخدام Aspose.Slides—التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---
## **نظرة عامة**

[Open Presentations in C#](/slides/ar/net/open-presentation/) وصفت كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض وتخزينها. فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) تحتوي على محتويات العرض. سواءً كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل عرضًا موجودًا، فستحتاج إلى حفظه عند الانتهاء. مع Aspose.Slides for .NET، يمكنك الحفظ إلى **ملف** أو **دفق**. يوضح هذا المقال الطرق المختلفة لحفظ العرض.

## **حفظ العروض إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `Save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // قم ببعض الأعمال هنا...

    // احفظ العرض التقديمي إلى ملف.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **حفظ العروض إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق إخراج إلى طريقة `Save` لفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). يمكن كتابة العرض إلى العديد من أنواع التدفقات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تدفق ملف.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **حفظ العروض بنوع عرض محدد مسبقًا**

تتيح لك Aspose.Slides ضبط العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض المولد عبر فئة [ViewProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/). اضبط خاصية [LastView](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/lastview/) إلى قيمة من تعداد [ViewType](https://reference.aspose.com/slides/ar/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **حفظ العروض بتنسيق Office Open XML الصارم**

تتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Office Open XML الصارم. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pptxoptions/) واضبط خاصية التوافق عند الحفظ. إذا قمت بتعيين `Conformance.Iso29500_2008_Strict`، سيتم حفظ ملف الإخراج بتنسيق Office Open XML الصارم.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Office Open XML الصارم.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // حفظ العرض التقديمي بتنسيق Office Open XML الصارم.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **حفظ العروض بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الضغط لأي ملف، وإجمالي حجم الأرشيف، كما يحد من عدد الملفات إلى 65 535 (2^16‑1) ملف. تُرفع امتدادات تنسيق ZIP64 هذه الحدود إلى 2^64.

تتيح لك خاصية [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ipptxoptions/zip64mode/) اختيار متى يستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

توفر هذه الخاصية الأنماط التالية:

- `IfNecessary` يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض القيود المذكورة أعلاه. هذا هو النمط الافتراضي.
- `Never` لا يستخدم امتدادات تنسيق ZIP64 أبدًا.
- `Always` يستخدم امتدادات تنسيق ZIP64 دائمًا.

الكود التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام `Zip64Mode.Never`، يتم رمي استثناء [PptxException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxexception/) إذا تعذر حفظ العرض في تنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض بتنسيق Office Open XML مع مستويات الضغط**

عند التعامل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق توازن بين حجم الملف ووقت المعالجة. بناءً على متطلباتك، قد تفضّل معالجة أسرع أو ملفات أصغر.

توفر Aspose.Slides خاصية [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ipptxoptions/compressionlevel/) التي تسمح لك بتحديد مستوى الضغط المستخدم عند حفظ عرض تقديمي بتنسيق Office Open XML.

مستويات الضغط المتاحة هي:

- **None**: لا يُطبق ضغط. تُحفظ الملفات كما هي.
- **Level1:** أسرع ضغط مع أقل نسبة ضغط.
- **Level2:** ضغط أسرع مع نسبة ضغط أفضل قليلاً من **Level1**.
- **Level3:** يوفر ضغطًا أفضل من **Level2** مع تأثير متوسط على وقت المعالجة.
- **Level4:** يوفر ضغطًا أفضل من **Level3**.
- **Level5:** يوفر تحسينًا في الضغط مقارنةً بـ **Level4** مع وقت معالجة إضافي.
- **Level6:** ضغط قياسي يقدم توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- **Level7:** يوفر ضغطًا أفضل من **Level6** مع معالجة أبطأ.
- **Level8:** يوفر ضغطًا أفضل من **Level7**.
- **Level9:** أقصى ضغط. ينتج أصغر حجم ملف لكن بأطول زمن معالجة.

المثال التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

هذا المثال يوضح كيفية حفظ عرض تقديمي كملف PPTX مع *أقصى ضغط*:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **حفظ العروض دون تحديث المصغرة**

تتحكم خاصية [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) في إنشاء المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينها إلى `true`، يتم تحديث المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم تعيينها إلى `false`، تُحفظ المصغرة الحالية. إذا لم يكن للعرض مصغرة، لن تُنشأ أي مصغرة.

في الشيفرة أدناه، يتم حفظ العرض إلى PPTX دون تحديث مصغرته.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
هذا الخيار يساعد على تقليل الوقت المطلوب لحفظ عرض تقديمي بصيغة PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم بالنسبة المئوية**

يتم استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/iprogresscallback/) عبر خاصية `ProgressCallback` التي تُعرض من قبل واجهة [ISaveOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveoptions/). عين تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/iprogresscallback/) إلى `ProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

المقاطع البرمجية التالية توضح كيفية استخدام `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

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
قامت Aspose بتطوير تطبيق [مجاني لتقسيم PowerPoint](https://products.aspose.app/slides/ar/splitter) باستخدام واجهتها البرمجية. يتيح التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف المستهدف بالكامل كل مرة؛ لا يُدعم "الحفظ السريع" التزايدي.

**هل حفظ نفس كائن Presentation من عدة خيوط آمن؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) [ليس آمنًا للخطوط المتعددة](/slides/ar/net/multithreading/); احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

[الروابط التشعبية](/slides/ar/net/manage-hyperlinks/) تُحفظ. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من أن المسارات المشار إليها ما زالت قابلة للوصول.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تُدعم [خصائص المستند القياسية](/slides/ar/net/presentation-properties/) وسيتم كتابتها إلى الملف عند الحفظ.