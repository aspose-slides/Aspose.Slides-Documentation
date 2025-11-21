---
title: فتح العروض التقديمية في .NET
linktitle: فتح عرض تقديمي
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
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- .NET
- C#
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx, .ppt) و OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لـ .NET — سريع، موثوق، كامل الميزات."
---

## **نظرة عامة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرجاع معلومات عنه، تحرير محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ومرّر مسار الملف إلى المُنشئ الخاص بها.

المثال التالي بلغة C# يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح الخاصة به:
```cs
// إنشاء كائن من الفئة Presentation وتمرير مسار الملف إلى المُنشئ الخاص بها.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // طباعة العدد الكلي للشرائح في العرض التقديمي.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة لفتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر خاصية [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) في الفئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) لتشفيرها وتحميلها. يُظهر الكود التالي بلغة C# هذه العملية:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // تنفيذ عمليات على العرض التقديمي المفكوك.
}
```


## **فتح العروض التقديمية الكبيرة**

توفر Aspose.Slides خيارات—وخاصة خاصية [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) في الفئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

الكود التالي بلغة C# يوضح تحميل عرض تقديمي كبير (مثلاً، 2 جيجابايت):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // اختر سلوك KeepLocked — سيظل ملف العرض مقفولًا طوال فترة
        // كائن Presentation، ولكن لا يحتاج إلى تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 ميغابايت
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // إجراء تغييرات على العرض التقديمي.
    presentation.Slides[0].Name = "Large presentation";

    // حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل ذلك! سيطلق استثناء إدخال/إخراج لأن الملف مقفل حتى يتم التخلص من كائن العرض التقديمي.
    File.Delete(filePath);
}

// يمكن القيام بذلك هنا. لم يعد ملف المصدر مقفلًا بواسطة كائن العرض التقديمي.
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التيارات، قد تقوم Aspose.Slides بنسخ محتويات التيار. تحميل عرض تقديمي كبير من تيار يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التيار.

عند إنشاء عرض يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

توفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. يُظهر الكود التالي بلغة C# كيفية استخدام واجهة `IResourceLoadingCallback`:
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
            // تعيين URL بديل.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // تخطي جميع الصور الأخرى.
        return ResourceLoadingAction.Skip;
    }
}
```


## **تحميل العروض التقديمية بدون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (متاح عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- بيانات كائن OLE المدمجة (متاح عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- بيانات ثنائية للتحكم ActiveX (متاح عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)، يمكنك تحميل عرض تقديمي بدون أي كائنات ثنائية مدمجة.

تُعد هذه الخاصية مفيدة لإزالة المحتوى الثنائي الذي قد يكون خبيثًا. يُظهر الكود التالي بلغة C# كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مدمج:
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

ستتلقى استثناءً أثناء التحميل يتعلق بتحليل/تحقق من تنسيق الملف. غالبًا ما تُشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، لكن عملية [العرض/التصدير](/slides/ar/net/convert-presentation/) قد تستبدل الخطوط. يمكنك [تكوين استبدالات الخطوط](/slides/ar/net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح الوسائط متاحة كموارد للعرض. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من أن تلك المسارات قابلة للوصول في بيئتك؛ وإلا قد تُهمل أثناء عملية [العرض/التصدير](/slides/ar/net/convert-presentation/).