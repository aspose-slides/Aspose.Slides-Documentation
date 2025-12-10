---
title: فتح العروض التقديمية في .NET
linktitle: فتح العرض التقديمي
type: docs
weight: 20
url: /ar/net/open-presentation/
keywords:
- فتح PowerPoint
- فتح العرض التقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل العرض التقديمي
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
description: "فتح عروض PowerPoint (.pptx, .ppt) وعروض OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لـ .NET—سريع، موثوق، كامل الميزات."
---

## **نظرة عامة**

بخلاف إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides أيضاً فتح العروض التقديمية الموجودة. بعد تحميل العرض، يمكنك استرجاع معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

يظهر المثال التالي بلغة C# كيفية فتح عرض تقديمي والحصول على عدد الشرائح:
```cs
// إنشاء كائن من فئة Presentation وتمرير مسار ملف إلى مُنشئها.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // طباعة إجمالي عدد الشرائح في العرض التقديمي.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر خاصية [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) في فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة C# هذه العملية:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // إجراء عمليات على العرض التقديمي المفكوك.
}
```


## **فتح العروض التقديمية الكبيرة**

توفر Aspose.Slides خيارات—وخاصة خاصية [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) في فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يوضح الكود التالي بلغة C# كيفية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // اختر سلوك KeepLocked — سيظل ملف العرض مقفولًا طوال مدة 
        // مثال Presentation، ولكن لا تحتاج إلى تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 ميجابايت
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // تم تحميل العرض الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // إجراء تغييرات على العرض التقديمي.
    presentation.Slides[0].Name = "Large presentation";

    // احفظ العرض التقديمي إلى ملف آخر. يبقى استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل ذلك! سيتم إلقاء استثناء I/O لأن الملف مقفل حتى يتم التخلص من كائن العرض.
    File.Delete(filePath);
}

// يمكن القيام بذلك هنا. لم يعد ملف المصدر مقفلًا من قبل كائن العرض.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التيارات، قد تقوم Aspose.Slides بنسخ محتويات التيار. تحميل عرض تقديمي كبير من تيار يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التيار.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم بالمصادر الخارجية**

توفر Aspose.Slides واجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يوضح الكود التالي بلغة C# كيفية استخدام واجهة `IResourceLoadingCallback`:
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

        // تجاوز جميع الصور الأخرى.
        return ResourceLoadingAction.Skip;
    }
}
```


## **تحميل العروض التقديمية دون كائنات ثنائية مضمّنة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المضمّنة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- بيانات كائن OLE المضمّنة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- بيانات تحكم ActiveX الثنائية (يمكن الوصول إليها عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) يمكنك تحميل عرض تقديمي بدون أي كائنات ثنائية مضمّنة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون ضارًا. يوضح الكود التالي بلغة C# كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مضمّن:
```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // تنفيذ عمليات على العرض التقديمي.
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستتلقى استثناءً أثناء التحميل يشير إلى خطأ في التحليل/التحقق من التنسيق. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، لكن عملية [العرض/التصدير](/slides/ar/net/convert-presentation/) لاحقًا قد تستبدل الخطوط. يمكنك [تكوين استبدال الخطوط](/slides/ar/net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المضمنة (فيديو/صوت) عند الفتح؟**

تصبح الوسائط متاحة كموارد للعرض. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من أن هذه المسارات متاحة في بيئتك؛ وإلا قد تُهمل عملية [العرض/التصدير](/slides/ar/net/convert-presentation/) تلك الوسائط.