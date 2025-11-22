---
title: فتح عرض تقديمي بلغة C#
linktitle: فتح العروض التقديمية
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
- مصدر خارجي
- كائن ثنائي
- .NET
- C#
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx, .ppt) و OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لـ .NET—سريع، موثوق، ومزود بجميع الميزات."
---

## **نظرة عامة**

بعيدًا عن إنشاء عروض PowerPoint من الصفر، Aspose.Slides يتيح لك أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرجاع معلومات حوله، تحرير محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ومرّر مسار الملف إلى المُنشئ الخاص بها.

```cs
// إنشاء كائن من فئة Presentation وتمرير مسار ملف إلى المُنشئ الخاص به.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر خاصية [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) لكائن [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) لفك التشفير وتحميله. يُظهر مثال C# التالي هذه العملية:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // إجراء عمليات على العرض التقديمي المفكك.
}
```


## **فتح العروض التقديمية الكبيرة**

Aspose.Slides يوفر خيارات—وخاصة خاصية [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) في كائن [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)—لمساعدتك على تحميل عروض تقديمية كبيرة.

يُظهر مثال C# التالي تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // اختر سلوك KeepLocked — سيستمر ملف العرض مقفولًا طوال فترة 
        // كائن Presentation، ولكن لا يلزم تحميله إلى الذاكرة أو نسخه إلى ملف مؤقت.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 ميغابايت
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // إجرِ تغييرات على العرض التقديمي.
    presentation.Slides[0].Name = "Large presentation";

    // احفظ العرض التقديمي إلى ملف آخر. يبقى استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل ذلك! سيتم إلقاء استثناء إدخال/إخراج لأن الملف مقفول حتى يتم التخلص من كائن Presentation.
    File.Delete(filePath);
}

// لا مشكلة في القيام بذلك هنا. لم يعد ملف المصدر مقفولًا بواسطة كائن Presentation.
File.Delete(filePath);
```


{{% alert color="info" title="معلومات" %}}
لتجاوز بعض القيود عند العمل مع التيارات، قد تقوم Aspose.Slides بنسخ محتوى التيار. تحميل عرض تقديمي كبير من تيار يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التيار.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/net/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

Aspose.Slides يوفر الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. يُظهر مثال C# التالي كيفية استخدام الواجهة `IResourceLoadingCallback`:

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


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint التقديمي على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- بيانات ثنائية لعنصر تحكم ActiveX (يمكن الوصول إليها عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/)).

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

تُعد هذه الخاصية مفيدة لإزالة المحتوى الثنائي الذي قد يكون خبيثًا. يُظهر مثال C# التالي كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مدمج:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // إجراء عمليات على العرض التقديمي.
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستحصل على استثناء أثناء التحليل/التحقق من الصيغة عند التحميل. غالبًا ما تشير مثل هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، لكن قد يستبدل [التصوير/التصدير](/slides/ar/net/convert-presentation/) الخطوط لاحقًا. قم بـ[تهيئة استبدال الخطوط](/slides/ar/net/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/net/custom-font/) إلى بيئة الوقت التشغيلي.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح الوسائط متاحة كموارد للعرض التقديمي. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من توفر تلك المسارات في بيئتك؛ وإلا قد تُهمل [التصوير/التصدير](/slides/ar/net/convert-presentation/) تلك الوسائط.