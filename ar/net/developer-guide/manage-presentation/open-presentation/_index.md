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
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في C#، وتزويد كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides للـ .NET."
---
## **المقدمة**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ar/net/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات والتيارات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بأي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج الذاكرة المُدارة، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض**

لفتح عرض موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). قم بتحرير العرض بعد الاستخدام حتى يتم تحرير مقبض الملف والبيانات المؤقتة والموارد الأخرى بسرعة.

المثال التالي بلغة C# يوضح كيفية فتح عرض والحصول على عدد الشرائح:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **فتح العروض المحمية بكلمة مرور**

كلمة مرور الفتح تشفّر محتوى العرض. لتحميل العرض بالكامل، عيّن كلمة المرور الصحيحة إلى [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). يفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

للكشف عن كلمة المرور، التحقق، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/net/password-protected-presentation/). إذا تم حفظ عرض مشفّر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/net/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/blobmanagementoptions/) يتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفلًا، السماح بالملفات المؤقتة، وتحديد حجم بيانات الـ BLOB التي تُحتفظ في الذاكرة.

الكود التالي بلغة C# يوضح تحميل عرض كبير (مثلاً 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
مع `PresentationLockingBehavior.KeepLocked` يبقى ملف المصدر مقفلاً حتى يتم تحرير كائن `Presentation`. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما يبقى هذا الكائن نشطًا.

قد تقوم Aspose.Slides بنسخ محتويات التيار أثناء التحميل. بالنسبة للعروض الكبيرة، يكون مسار الملف عمومًا أكثر كفاءة من التيار. راجع [Manage BLOBs](/slides/ar/net/manage-blob/) للحصول على خيارات إضافية لتخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/resourceloadingcallback/) تقبل تنفيذًا لـ[IResourceLoadingCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/iresourceloadingcallback/). يمكن للرد الندائي توفير بيانات بديلة، إعادة توجيه المورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما يحتوي العرض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **تحميل العروض دون كائنات ثنائية مدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/vbaproject/);
- بيانات OLE المدمجة، متاحة عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- بيانات التحكم ActiveX، متاحة عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ar/net/aspose.slides/icontrol/activexcontrolbinary/).

عيّن [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض الذي تم تحميله لتثبيت النتيجة المعالجة.

هذا الخيار يقلل من التعرض للحمولات الضارة المدمجة، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتداولة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

يطرح Aspose.Slides استثناءً يتعلق بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يُحمَّل، لكن قد يتم استبدال الخطوط أثناء العرض أو التصدير. يمكنك [configure font substitution](/slides/ar/net/font-substitution/) أو [provide custom fonts](/slides/ar/net/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل تحميل العرض يحمل أيضًا الوسائط المدمجة؟**

يصبح الصوت والفيديو المدمجين متاحين عبر نموذج كائن العرض. تُحل الموارد الخارجية وفق سلوك تحميل الموارد المُكوَّن وقد تكون غير متوفرة إذا تعذّر الوصول إلى مواقعها.