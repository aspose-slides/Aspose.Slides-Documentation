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
- تحديث الصورة المصغرة
- تقدم الحفظ
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في .NET باستخدام Aspose.Slides — تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[Open Presentations in C#](/slides/ar/net/open-presentation/) يوضح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لفتح عرض تقديمي. تشرح هذه المقالة كيفية إنشاء العروض التقديمية وحفظها. تحتوي فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) على محتويات العرض التقديمي. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدّل أحدًا موجودًا، فستحتاج إلى حفظه عند الانتهاء. مع Aspose.Slides لـ .NET، يمكنك حفظه إلى **ملف** أو **تيار**. توضح هذه المقالة الطرق المختلفة لحفظ العرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

يمكن حفظ عرض تقديمي إلى ملف باستدعاء طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). قم بتمرير اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```cs
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // قم ببعض العمل هنا...

    // حفظ العرض التقديمي إلى ملف.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية إلى التيارات**

يمكنك حفظ عرض تقديمي إلى تيار بتمرير تيار إخراج إلى طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى عدة أنواع من التيارات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تيار ملف.
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


## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يتيح لك Aspose.Slides ضبط طريقة العرض الأولية التي يستخدمها PowerPoint عند فتح العرض التقديمي المُنشأ عبر فئة [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). قم بتعيين الخاصية [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) إلى قيمة من تعداد [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) وقم بتعيين خاصية التوافق عند الحفظ. إذا قمت بتعيين `Conformance.Iso29500_2008_Strict`، يتم حفظ الملف الناتج بتنسيق Strict Office Open XML.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // حفظ العرض التقديمي في تنسيق Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدًا قدره 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الملف المضغوط، وإجمالي حجم الأرشيف، كما يقتصر الأرشيف على 65,535 (2^16-1) ملفًا. امتدادات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

تتيح لك الخاصية [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

توفر هذه الخاصية الأوضاع التالية:

- `IfNecessary` يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض التقديمي القيود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `Never` لا يستخدم امتدادات تنسيق ZIP64 أبدًا.
- `Always` يستخدم امتدادات تنسيق ZIP64 دائمًا.

يعرض الشيفرة التالية كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:
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
عند الحفظ باستخدام `Zip64Mode.Never`، يتم رمي استثناء [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم الخاصية [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) في إنشاء الصورة المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينها إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم تعيينها إلى `false`، تُحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، فلن يتم إنشاء أي منها.

في الشيفرة أدناه، يتم حفظ العرض التقديمي كملف PPTX دون تحديث صوّرته المصغرة.
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
هذا الخيار يساعد على تقليل الوقت المطلوب لحفظ العرض التقديمي بتنسيق PPTX.
{{% /alert %}}

## **تحديثات تقدم الحفظ بنسبة مئوية**

يتم استخدام الواجهة [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) عبر الخاصية `ProgressCallback` التي تعرضها الواجهة [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). قم بإسناد تنفيذ [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) إلى `ProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

تظهر مقاطع الشيفرة التالية كيفية استخدام `IProgressCallback`.
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
قامت Aspose بتطوير تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/splitter) باستخدام واجهة برمجة التطبيقات الخاصة بها. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **FAQ**

**هل يتم دعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تنشئ الملف الهدف بالكامل؛ لا يتم دعم "الحفظ السريع" التزايدي.

**هل الحفظ من نفس كائن Presentation آمن في تعدد الخيوط؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) [ليس آمنًا في تعدد الخيوط](/slides/ar/net/multithreading/); يجب حفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [Hyperlinks](/slides/ar/net/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا — تأكد من أن المسارات المرجعية لا تزال قابلة للوصول.

**هل يمكنني ضبط/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم [خصائص المستند](/slides/ar/net/presentation-properties/) القياسية وسيتم كتابتها إلى الملف عند الحفظ.