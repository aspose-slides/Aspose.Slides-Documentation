---
title: فتح عرض تقديمي في جافا
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/androidjava/open-presentation/
keywords: "فتح PowerPoint، PPTX، PPT، فتح عرض تقديمي، تحميل عرض تقديمي، جافا"
description: "فتح أو تحميل عرض تقديمي PPT، PPTX، ODP في جافا"
---

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك الحصول على معلومات حول العرض التقديمي، تحرير العرض التقديمي (المحتوى على الشرائح الخاصة به)، إضافة شرائح جديدة أو إزالة الشرائح الموجودة، إلخ.

## فتح عرض تقديمي

لفتح عرض تقديمي موجود، يجب عليك ببساطة إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتمرير مسار الملف (للعرض الذي تريد فتحه) إلى مُنشئه.

يوضح هذا الكود الجافا كيفية فتح عرض تقديمي وأيضًا معرفة عدد الشرائح التي يحتوي عليها:

```java
// ينشئ كائن من فئة Presentation ويمرر مسار الملف إلى مُنشئه
Presentation pres = new Presentation("Presentation.pptx");
try {
    // يطبع العدد الإجمالي للشرائح الموجودة في العرض التقديمي
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **فتح عرض تقديمي محمي بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، يمكنك تمرير كلمة المرور عبر خاصية [Password](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getPassword--) (من فئة [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)) لفك تشفير العرض التقديمي وتحميله. يُظهر هذا الكود الجافا العملية:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");
Presentation pres = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي المفكوك تشفيره
} finally {
    if (pres != null) pres.dispose();
}
```

## فتح عرض تقديمي كبير

يوفر Aspose.Slides خيارات (خاصية [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) بشكل خاص) ضمن فئة [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions) للسماح لك بتحميل العروض التقديمية الكبيرة.

يوضح هذا المثال الجافا عملية تحميل عرض تقديمي كبير (كما نقول 2 جيجابايت في الحجم):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، لكن استهلاك الذاكرة لا يزال منخفضًا.
    // إجراء تغييرات على العرض التقديمي.
    pres.getSlides().get_Item(0).setName("عرض تقديمي كبير جداً");

    // سيتم حفظ العرض التقديمي في ملف آخر. يبقى استهلاك الذاكرة منخفضًا خلال العملية
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند التفاعل مع دفق، قد يقوم Aspose.Slides بنسخ محتوى الدفق. سيؤدي تحميل عرض تقديمي كبير من خلال دفقه إلى نسخ محتويات العرض التقديمي والتسبب في بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس دفقه.

عندما تريد إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور كبيرة، إلخ)، يمكنك استخدام [تسهيلات Blob](https://docs.aspose.com/slides/androidjava/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}} 

## تحميل عرض تقديمي

يوفر Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) مع طريقة واحدة للسماح لك بإدارة الموارد الخارجية. يوضح هذا الكود الجافا كيفية استخدام واجهة `IResourceLoadingCallback`:

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // يحمل صورة بديلة
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // يحدد عنوان URL بديلاً
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // يتخطى جميع الصور الأخرى
        return ResourceLoadingAction.Skip;
    }
}
```

## تحميل عرض تقديمي بدون كائنات ثنائية مدمجة

قد يحتوي عرض PowerPoint التقديمي على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/));
- بيانات كائن OLE مدمجة ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- بيانات ثنائية لـ ActiveX Control ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--));

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)، يمكنك تحميل العرض التقديمي بدون أي كائنات ثنائية مدمجة.

يمكن أن تكون هذه الخاصية مفيدة لإزالة المحتوى الثنائي الضار المحتمل.

يظهر الكود كيفية تحميل وحفظ عرض تقديمي بدون أي محتوى ضار:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## فتح وحفظ عرض تقديمي

خطوات فتح وحفظ عرض تقديمي:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) وتمرير الملف الذي تريد فتحه.
2. حفظ العرض التقديمي.  

```java
// ينشئ كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    // ...قم ببعض العمل هنا...
    
    // يحفظ عرضك التقدمي في ملف
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```