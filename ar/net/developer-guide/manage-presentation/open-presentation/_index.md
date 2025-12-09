---
title: فتح العروض في .NET
linktitle: فتح عرض
type: docs
weight: 20
url: /ar/net/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- .NET
- C#
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx, .ppt) وعروض OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لـ .NET - سريعة، موثوقة، ومزودة بجميع المميزات."
---

## **نظرة عامة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض الموجودة. بعد تحميل العرض، يمكنك استرداد معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وغير ذلك.

## **فتح العروض**

لفتح عرض موجود، قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

يعرض المثال التالي بلغة C# كيفية فتح عرض والحصول على عدد الشرائح الخاصة به:
```cs
// إنشاء كائن من فئة Presentation وتمرير مسار ملف إلى المنشئ الخاص بها.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // طباعة العدد الإجمالي للشرائح في العرض.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **فتح العروض المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض محمي بكلمة مرور، مرّر كلمة المرور عبر الخاصية [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) في فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة C# هذه العملية:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // تنفيذ عمليات على العرض المفكك التشفير.
}
```


## **فتح العروض الكبيرة**

يوفر Aspose.Slides خيارات—خاصة الخاصية [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) في فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض الكبيرة.

يوضح الكود التالي بلغة C# كيفية تحميل عرض كبير (على سبيل المثال، 2 جيجابايت):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // اختر سلوك KeepLocked — سيبقى ملف العرض مقفلاً طوال عمر
        // كائن Presentation، لكنه لا يحتاج إلى تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 ميغابايت
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // تم تحميل العرض الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // قم بإجراء تغييرات على العرض.
    presentation.Slides[0].Name = "Large presentation";

    // احفظ العرض إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل هذا! سيتم رمي استثناء I/O لأن الملف مقفل حتى يتم التخلص من كائن العرض.
    File.Delete(filePath);
}

// من المقبول فعل ذلك هنا. لم يعد ملف المصدر مقفلاً بواسطة كائن العرض.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. يؤدي تحميل عرض كبير من تدفق إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يعرض الكود التالي بلغة C# كيفية استخدام الواجهة `IResourceLoadingCallback`:
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // تحميل صورة بديلة.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // تعيين عنوان URL بديل.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // تخطي جميع الصور الأخرى.
        return ResourceLoadingAction.Skip;
    }
}
```


## **تحميل العروض بدون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- بيانات كائن OLE مدمجة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- بيانات ثنائية للتحكم ActiveX (يمكن الوصول إليها عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

باستخدام الخاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)، يمكنك تحميل عرض بدون أي كائنات ثنائية مدمجة.

تكون هذه الخاصية مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون ضارًا. يوضح الكود التالي بلغة C# كيفية تحميل عرض بدون أي محتوى ثنائي مدمج:
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // تنفيذ عمليات على العرض.
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستتلقى استثناءً يتعلق بتحليل/تحقق من صحة الصيغة أثناء التحميل. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint معطوبة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، لكن عملية [rendering/export](/slides/ar/net/convert-presentation/) قد تستبدل الخطوط. يمكنك [Configure font substitutions](/slides/ar/net/font-substitution/) أو [add the required fonts](/slides/ar/net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح متاحة كموارد للعرض. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من أن هذه المسارات متاحة في بيئتك؛ وإلا قد تتغاضى عملية [rendering/export](/slides/ar/net/convert-presentation/) عن الوسائط.