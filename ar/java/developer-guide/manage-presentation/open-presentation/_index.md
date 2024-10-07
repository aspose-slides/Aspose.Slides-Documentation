---
title: فتح عرض تقديمي في جافا
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /java/open-presentation/
keywords: "فتح PowerPoint, PPTX, PPT, فتح عرض تقديمي, تحميل عرض تقديمي, جافا"
description: "فتح أو تحميل عرض تقديمي PPT, PPTX, ODP في جافا"
---

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides فتح العروض التقديمية الحالية. بعد تحميل عرض تقديمي، يمكنك الحصول على معلومات حول العرض التقديمي، تعديل العرض التقديمي (المحتوى على شرائحه)، إضافة شرائح جديدة أو إزالة الموجودة، إلخ.

## فتح عرض تقديمي

لفتح عرض تقديمي موجود، عليك ببساطة إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) وتمرير مسار الملف (للعرض الذي ترغب في فتحه) إلى المنشئ الخاص بها.

هذا الكود بلغة جافا يوضح لك كيفية فتح عرض تقديمي وأيضًا معرفة عدد الشرائح الموجودة فيه:

```java
// إنشاء كائن من فئة Presentation وتمرير مسار الملف إلى منشئه
Presentation pres = new Presentation("Presentation.pptx");
try {
    // طباعة العدد الإجمالي للشرائح الموجودة في العرض التقديمي
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **فتح عرض تقديمي محمي بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، يمكنك تمرير كلمة المرور من خلال خاصية [Password](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getPassword--) (من فئة [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)) لفك تشفير العرض التقديمي وتحميله. هذا الكود بلغة جافا يوضح العملية:

```java
 LoadOptions loadOptions = new LoadOptions();
 loadOptions.setPassword("YOUR_PASSWORD");
 Presentation pres = new Presentation("pres.pptx", loadOptions);
 try {
 // قم بعمل بعض الأعمال مع العرض التقديمي المفكوك
 } finally {
     if (pres != null) pres.dispose();
 }
```

## فتح عرض تقديمي كبير

تقدم Aspose.Slides خيارات (خاصية [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) بشكل خاص) تحت فئة [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions) للسماح لك بتحميل العروض التقديمية الكبيرة.

هذا المثال بلغة جافا يوضح عملية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت في الحجم):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، لكن استهلاك الذاكرة لا يزال منخفضًا.
    // أجر تغييرات على العرض التقديمي.
    pres.getSlides().get_Item(0).setName("عرض تقديمي كبير جدًا");

    // سيتم حفظ العرض التقديمي إلى ملف آخر. يبقى استهلاك الذاكرة منخفضًا أثناء العملية
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند التفاعل مع تيار، قد تقوم Aspose.Slides بنسخ محتوى التيار. سيتسبب تحميل عرض تقديمي كبير من خلال تياره في نسخ محتويات العرض التقديمي ويتسبب في تحميل بطيء. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس تياره.

عندما ترغب في إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور كبيرة، إلخ)، يمكنك استخدام [تسهيلات Blob](https://docs.aspose.com/slides/java/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}} 

## تحميل عرض تقديمي

تقدم Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) مع طريقة واحدة للسماح لك بإدارة الموارد الخارجية. يوضح لك هذا الكود بلغة جافا كيفية استخدام واجهة `IResourceLoadingCallback`:

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
            try // تحميل صورة بديلة
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
            // تعيين عنوان URL بديل
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // تخطي جميع الصور الأخرى
        return ResourceLoadingAction.Skip;
    }
}
```

## تحميل عرض تقديمي بدون كائنات ثنائية مضمنة

يمكن أن يحتوي العرض التقديمي PowerPoint على الأنواع التالية من الكائنات الثنائية المضمنة:

- مشروع VBA ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- بيانات مدمجة كائن OLE ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- بيانات ثنائية تحكم ActiveX ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

باستخدام خاصية [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)، يمكنك تحميل العرض التقديمي بدون أي كائنات ثنائية مضمنة.

يمكن أن تكون هذه الخاصية مفيدة لإزالة المحتوى الثنائي الخبيث المحتمل.

يظهر الكود كيفية تحميل وحفظ عرض تقديمي بدون أي محتوى برمجي ضار:

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

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) وتمرير الملف الذي ترغب في فتحه.
2. حفظ العرض التقديمي.

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();
try {
    // ...قم ببعض الأعمال هنا...
    
    // حفظ عرضك التقديمي إلى ملف
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```