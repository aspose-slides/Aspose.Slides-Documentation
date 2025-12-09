---
title: فتح العروض في .NET
linktitle: فتح عرض
type: docs
weight: 20
url: /ar/net/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض
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
description: "فتح عروض PowerPoint (.pptx، .ppt) وOpenDocument (.odp) بسهولة باستخدام Aspose.Slides لـ .NET—سريعة، موثوقة، ذات ميزات كاملة."
---

## **نظرة عامة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض الحالية. بعد تحميل العرض، يمكنك استرداد معلومات حوله، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الموجودة، وأكثر من ذلك.

## **فتح العروض**

لفتح عرض موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ومرّر مسار الملف إلى المُنشئ الخاص بها.

يوضح المثال التالي بلغة C# كيفية فتح عرض والحصول على عدد الشرائح فيه:
```cs
// إنشاء كائن من الفئة Presentation وتمرير مسار ملف إلى المُنشئ الخاص به.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // طباعة العدد الإجمالي للشرائح في العرض.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **فتح العروض المحمية بكلمة مرور**

عند الحاجة لفتح عرض محمي بكلمة مرور، مرّر كلمة المرور عبر الخاصية [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) من فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة C# هذه العملية:
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // قم بإجراء عمليات على العرض المفكوك تشفيره.
}
```


## **فتح عروض كبيرة**

يوفر Aspose.Slides خيارات—وخاصة الخاصية [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) في فئة [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—للمساعدة في تحميل عروض كبيرة الحجم.

يوضح الكود التالي بلغة C# كيفية تحميل عرض كبير (مثال، 2 جيجابايت):
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // اختر سلوك KeepLocked — سيظل ملف العرض مقفلاً طوال فترة
        // كائن Presentation، ولكن لا يلزم تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 ميجابايت
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // تم تحميل العرض الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // قم بإجراء تغييرات على العرض.
    presentation.Slides[0].Name = "Large presentation";

    // احفظ العرض إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل هذا! سيتم رمي استثناء إدخال/إخراج لأن الملف مقفل حتى يتم تحرير كائن العرض.
    File.Delete(filePath);
}

// يمكن القيام بذلك هنا. الملف الأصلي لم يعد مقفلاً بواسطة كائن العرض.
File.Delete(filePath);
```


{{% alert color="info" title="معلومات" %}}
لتجاوز بعض القيود عند العمل مع التيارات، قد يقوم Aspose.Slides بنسخ محتويات التيار. تحميل عرض كبير من تيار يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التيار.

عند إنشاء عرض يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) التي تُتيح لك إدارة الموارد الخارجية. يوضح الكود التالي بلغة C# كيفية استخدام الواجهة `IResourceLoadingCallback`:
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


## **تحميل العروض دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- بيانات ثنائي للتحكم ActiveX (يمكن الوصول إليها عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

باستخدام الخاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)، يمكنك تحميل عرض دون أي كائنات ثنائية مدمجة.

هذه الخاصية مفيدة لإزالة المحتوى الثنائي الذي قد يكون ضارًا. يوضح الكود التالي بلغة C# كيفية تحميل عرض دون أي محتوى ثنائي مدمج:
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // قم بإجراء عمليات على العرض.
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف معطوب ولا يمكن فتحه؟**

ستحصل على استثناء أثناء التحميل بسبب فشل تحليل/تحقق من التنسيق. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint المكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، ولكن قد يستبدل [التصوير/التصدير](/slides/ar/net/convert-presentation/) الخطوط لاحقًا. قم بـ[تكوين بدائل الخطوط](/slides/ar/net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/net/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تتحول إلى موارد في العرض. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن تلك المسارات متاحة في بيئتك؛ وإلا قد يُغْفَل عن الوسائط في [التصوير/التصدير](/slides/ar/net/convert-presentation/).