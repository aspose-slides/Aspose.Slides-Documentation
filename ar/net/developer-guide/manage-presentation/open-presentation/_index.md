---
title: فتح العرض التقديمي في C#
linktitle: فتح العرض التقديمي
type: docs
weight: 20
url: /net/open-presentation/
keywords: "فتح باوربوينت, PPTX, PPT, فتح العرض التقديمي, تحميل العرض التقديمي, C#, Csharp, .NET"
description: "فتح أو تحميل عرض تقديمي PPT, PPTX, ODP في C# أو .NET"
---

بجانب إنشاء عروض باوربوينت من الصفر، يسمح Aspose.Slides بفتح العروض الموجودة. بعد تحميل العرض التقديمي، يمكنك الحصول على معلومات حول العرض، تعديل العرض (المحتوى الموجود على شرائحه)، إضافة شرائح جديدة أو إزالة الموجودة منها، إلخ.

## فتح العرض التقديمي

لفتح عرض تقديمي موجود، عليك ببساطة إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتمرير مسار الملف (إلى العرض الذي تريد فتحه) إلى مُنشئه.

هذا الكود في C# يوضح لك كيفية فتح عرض تقديمي ومعرفة عدد الشرائح التي يحتوي عليها:

```c#
// إنشاء كائن من فئة Presentation وتمرير مسار الملف إلى مُنشئه
Presentation pres = new Presentation("OpenPresentation.pptx");

// طباعة العدد الكلي للشرائح الموجودة في العرض
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **فتح العرض التقديمي المحمي بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، يمكنك تمرير كلمة المرور من خلال خاصية [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) (من فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)) لفك تشفير العرض وتحميله. هذا الكود في C# يوضح العملية:

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // قم ببعض العمل مع العرض المفكوك التشفير
	}
```

## فتح عرض تقديمي كبير

يوفر Aspose.Slides خيارات (خاصية [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) بشكل خاص) ضمن فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) لتمكينك من تحميل العروض الكبيرة.

هذا الكود في C# يوضح عملية تحميل عرض تقديمي كبير (على سبيل المثال 2 جيجابايت في الحجم):

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // لنقم باختيار سلوك KeepLocked - "veryLargePresentation.pptx" سيتم قفله طوال
        // عمر كائن العرض، ولكننا لا نحتاج إلى تحميله في الذاكرة أو نسخه إلى
        // ملف مؤقت
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // تم تحميل العرض الكبير ويمكن استخدامه، لكن استهلاك الذاكرة لا يزال منخفضًا.

    // إجراء تغييرات على العرض.
    pres.Slides[0].Name = "عرض كبير جداً";

    // سيتم حفظ العرض في ملف آخر. يبقى استهلاك الذاكرة منخفضاً خلال العملية
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا يمكن القيام بذلك! سيتم رمي استثناء IO، لأن الملف مقفل بينما لن يتم
    // إتلاف كائنات pres
    File.Delete(pathToVeryLargePresentationFile);
}

// من الجيد القيام بذلك هنا، حيث أن الملف المصدر ليس مقفلاً بواسطة كائن pres
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند التفاعل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من خلال تدفقه سيؤدي إلى نسخ محتويات العرض وقد يتسبب في تحميل بطيء. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.

عندما تريد إنشاء عرض يحتوي على كائنات كبيرة (فيديو، صوت، صور كبيرة، إلخ)، يمكنك استخدام [تسهيلات Blob](https://docs.aspose.com/slides/net/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}} 


## تحميل العرض التقديمي
يوفر Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) مع طريقة واحدة تتيح لك إدارة الموارد الخارجية. هذا الكود في C# يوضح لك كيفية استخدام واجهة `IResourceLoadingCallback`:

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // تحميل صورة بديلة
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // تعيين عنوان URL بديل
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // تخطى جميع الصور الأخرى
        return ResourceLoadingAction.Skip;
    }
}
```

## تحميل العرض التقديمي دون كائنات ثنائية مدمجة

يمكن أن يحتوي العرض التقديمي على أنواع محددة من الكائنات الثنائية المدمجة:

- مشروع VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- بيانات كائن OLE المدمجة ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- بيانات التحكم ActiveX الثنائية ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) ، يمكنك تحميل العرض دون أي كائنات ثنائية مدمجة.

يمكن أن تكون هذه الخاصية مفيدة لإزالة المحتوى الثنائي الضار المحتمل.

هذا الكود في C# يظهر كيفية تحميل وحفظ عرض دون أي محتوى ضار:

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>فتح وحفظ العرض التقديمي</h2>

<a name="csharp-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في C#</strong></a>

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) وتمرير الملف الذي تريد فتحه.
2. احفظ العرض التقديمي.

```c#
// تحميل أي عرض تقديمي مدعوم مثل ppt, pptx, odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```