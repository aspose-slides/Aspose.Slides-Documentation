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
- نوع العرض المحدد مسبقًا
- تنسيق Strict Office Open XML
- وضع Zip64
- تحديث الصورة المصغرة
- تقدم الحفظ
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في .NET باستخدام Aspose.Slides - التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---
## **نظرة عامة**

[فتح العروض التقديمية في C#](/slides/ar/net/open-presentation/) يوضح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) لفتح عرض تقديمي. توضح هذه المقالة كيفية إنشاء العروض التقديمية وحفظها. تحتوي فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) على محتويات العرض التقديمي. سواءً كنت تنشئ عرضًا تقديميًا من الصفر أو تعدّل عرضًا موجودًا، ستحتاج إلى حفظه عند الانتهاء. مع Aspose.Slides for .NET، يمكنك الحفظ إلى **ملف** أو **دفق**. توضح هذه المقالة الطرق المختلفة لحفظ العرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `Save` في فئة [Presentation]. مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.

```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // قم ببعض الأعمال هنا...

    // احفظ العرض التقديمي إلى ملف.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق إخراج إلى طريقة `Save` في فئة [Presentation]. يمكن كتابة العرض التقديمي إلى عدة أنواع من التدفقات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تدفق ملف.

```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // احفظ العرض التقديمي إلى التدفق.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

يسمح Aspose.Slides لك بتعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض التقديمي المُنشأ عبر فئة [ViewProperties]. عيّن الخاصية [LastView] إلى قيمة من تعداد [ViewType].

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يسمح Aspose.Slides لك بحفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions] وعيّن خاصية التوافق (conformance) عند الحفظ. إذا قمت بتعيين `Conformance.Iso29500_2008_Strict`، سيتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation())
{
    // احفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا بحدود 4 غيغابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، والحجم المضغوط لأي ملف، وإجمالي حجم الأرشيف، كما يحد عدد الملفات إلى 65 535 (2^16‑1). توسعات تنسيق ZIP64 تُرفع هذه الحدود إلى 2^64.

خاصية [IPptxOptions.Zip64Mode] تتيح لك اختيار متى تُستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

هذه الخاصية توفر الأوضاع التالية:

- `IfNecessary` يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `Never` لا يستخدم امتدادات تنسيق ZIP64 أبدًا.
- `Always` يستخدم امتدادات تنسيق ZIP64 دائمًا.

الكود التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:

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
عند الحفظ باستخدام `Zip64Mode.Never`، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

عند العمل مع عروض تقديمية كبيرة، يمكنك تعديل مستوى الضغط لتحقيق توازن بين حجم الملف ووقت المعالجة. حسب متطلباتك، قد تفضّل معالجة أسرع أو ملفات أصغر حجماً.

يوفر Aspose.Slides الخاصية [IPptxOptions.CompressionLevel] التي تسمح لك بتحديد مستوى الضغط المستخدم عند حفظ عرض تقديمي بتنسيق Office Open XML.

المستويات المتاحة للضغط هي:

- **None**: لا يتم تطبيق أي ضغط. تُخزن الملفات كما هي.
- **Level1**: أسرع ضغط مع أقل نسبة ضغط.
- **Level2**: ضغط أسرع مع نسبة ضغط أفضل قليلاً من **Level1**.
- **Level3**: يوفّر ضغطًا أفضل من **Level2** مع تأثير معتدل على وقت المعالجة.
- **Level4**: يوفّر ضغطًا أفضل من **Level3**.
- **Level5**: يوفّر تحسينًا في الضغط عن **Level4** مع وقت معالجة إضافي.
- **Level6**: ضغط قياسي يوفّر توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- **Level7**: يوفّر ضغطًا أفضل من **Level6** مع معالجة أبطأ.
- **Level8**: يوفّر ضغطًا أفضل من **Level7**.
- **Level9**: أقصى ضغط. ينتج أصغر حجم ملف على حساب أطول وقت معالجة.

الكود التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:

```cs
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
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

خاصية [PptxOptions.RefreshThumbnail] تتحكم في إنشاء الصورة المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينها إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم تعيينها إلى `false`، تُحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، فلن يتم إنشاء أي صورة.

في الكود أدناه، يتم حفظ العرض التقديمي إلى PPTX دون تحديث صورته المصغرة.

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
هذه الخاصية تساعد على تقليل الوقت المستغرق لحفظ عرض تقديمي بتنسيق PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم بالنسبة المئوية**

يُستخدم واجهة [IProgressCallback] عبر خاصية `ProgressCallback` المُعرَّفة في واجهة [ISaveOptions] وفئة [SaveOptions] المجردة. عيّن تنفيذًا لـ[IProgressCallback] إلى `ProgressCallback` لتلقي تحديثات التقدم في الحفظ كنسبة مئوية.

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
طوّرت Aspose تطبيقًا مجانيًا لتقسيم PowerPoint باستخدام واجهتها البرمجية. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المختارة كملفات PPTX أو PPT جديدة.
[تطبيق مجاني لتقسيم PowerPoint](https://products.aspose.app/slides/ar/splitter)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يتم دعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. الحفظ يُنشئ الملف الكامل في كل مرة؛ ولا يتم دعم الحفظ السريع (التزايدي).

**هل حفظ نفس كائن Presentation من عدة خيوط آمن؟**

لا. كائن [Presentation] غير آمن لاستخدامه عبر خيوط متعددة [isn’t thread-safe](/slides/ar/net/multithreading/); احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

تُحافظ على [Hyperlinks](/slides/ar/net/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثلاً مقاطع الفيديو عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من أن المسارات المشار إليها لا تزال قابلة للوصول.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تُدعم [document properties](/slides/ar/net/presentation-properties/) القياسية وسيتم كتابتها إلى الملف عند الحفظ.