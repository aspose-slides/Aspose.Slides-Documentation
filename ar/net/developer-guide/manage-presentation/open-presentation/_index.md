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
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في C#، وتوفير كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides لـ .NET."
---
## **المقدمة**

[Aspose.Slides لـ .NET](https://products.aspose.com/slides/ar/net/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات وتدفقات البيانات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالصيغ الأصلية أو أي صيغة مدعومة أخرى.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج الذاكرة المُدارة، التحكم بالموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

بعد تحميل ملف أو تدفق، يمكنك [تحديد صيغة العرض الأصلية](/slides/ar/net/detect-presentation-source-format/) لاختيار طريقة معالجة تطبيقك لها.

لفتح عرض تقديمي موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). حرّر موارد العرض بعد الاستخدام لكي يتم تحرير مؤشرات الملفات والبيانات المؤقتة وغيرها من الموارد فوراً.

المثال التالي بلغة C# يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

كلمة مرور الفتح تشفر محتوى العرض. لتحميل العرض بالكامل، عيّن كلمة المرور الصحيحة إلى [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

لإجراءات اكتشاف كلمة المرور، التحقق، وتشفير، راجع [حماية العروض التقديمية بكلمة مرور](/slides/ar/net/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ راجع [إدارة خصائص العرض](/slides/ar/net/presentation-properties/).

## **فتح العروض التقديمية الكبيرة**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/blobmanagementoptions/) يتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفولاً، السماح بملفات مؤقتة، وتقييد كمية بيانات الـ BLOB المحتفظ بها في الذاكرة.

المثال التالي بلغة C# يوضح تحميل عرض تقديمي كبير (مثال: 2 جيجابايت):

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
مع `PresentationLockingBehavior.KeepLocked` يبقى ملف المصدر مقفولاً حتى يتم تحرير كائن `Presentation`. لا تقم بنقل، استبدال، أو حذف ملف المصدر بينما هذا الكائن ما زال حياً.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء التحميل. بالنسبة للعروض الكبيرة، غالباً ما يكون مسار الملف أكثر كفاءة من التدفق. راجع [إدارة الـ BLOBs](/slides/ar/net/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/resourceloadingcallback/) يقبل تنفيذًا لـ [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/iresourceloadingcallback/). يمكن للنداء الرجعي توفير بيانات بديلة، إعادة توجيه مورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفق قواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض التقديمية بدون كائنات ثنائية مدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. من الأمثلة:

- مشاريع VBA، متاحة عبر [IPresentation.VbaProject](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/vbaproject/)؛
- بيانات OLE المدمجة، متاحة عبر [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/)؛
- بيانات تحكم ActiveX، متاحة عبر [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ar/net/aspose.slides/icontrol/activexcontrolbinary/)؛

قم بتعيين [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمل لتثبيت النتيجة المنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

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

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ترمي Aspose.Slides استثناءً يتعلق بالتحليل أو الصيغة أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة لكي يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يظل يُحمَّل، لكن قد تستبدل الخطوط أثناء العرض والتصدير. يمكنك [تكوين استبدال الخطوط](/slides/ar/net/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/net/custom-font/) لجعل النتيجة أكثر توقعًا.

**هل تحميل العرض يؤدي أيضًا إلى تحميل الوسائط المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. يتم حل الموارد الخارجية وفق سلوك تحميل الموارد المُكوَّن وقد تكون غير متاحة إذا تعذر الوصول إلى مواقعها.