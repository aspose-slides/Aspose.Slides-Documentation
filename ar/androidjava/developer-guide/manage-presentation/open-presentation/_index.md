---
title: فتح العروض التقديمية على Android
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/androidjava/open-presentation/
keywords:
- فتح PowerPoint
- فتح OpenDocument
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
- Android
- Java
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx, .ppt) وOpenDocument (.odp) بسهولة باستخدام Aspose.Slides لنظام Android عبر Java—سريع، موثوق، كامل الميزات."
---

## **نظرة عامة**

بعيدًا عن إنشاء عروض PowerPoint من الصفر، يتيح Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرداد معلومات عنه، تعديل محتوى الشريحة، إضافة شرائح جديدة، إزالة الشرائح القائمة، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ومرّر مسار الملف إلى المُنشئ.

يوضح المثال التالي بلغة Java كيفية فتح عرض تقديمي والحصول على عدد الشرائح:
```java
// إنشاء كائن من الفئة Presentation وتمرير مسار ملف إلى المُنشئ.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر طريقة [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) في الفئة [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة Java هذه العملية:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // تنفيذ عمليات على العرض التقديمي المفك.
} finally {
    presentation.dispose();
}
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وبشكل خاص طريقة [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) في الفئة [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض التقديمية الكبيرة.

يوضح الكود التالي بلغة Java كيفية تحميل عرض تقديمي كبير (مثلاً 2 جيجابايت):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// اختر سلوك KeepLocked—ملف العرض سيبقى مقفلًا طوال مدة
// كائن Presentation، لكن لا يلزم تحميله إلى الذاكرة أو نسخه إلى ملف مؤقت.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 ميغابايت

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // إجراء تغييرات على العرض التقديمي.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا خلال هذه العملية.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل ذلك! سيُرمى استثناء I/O لأن الملف مقفل حتى يتم التخلص من كائن العرض.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// يمكن فعل ذلك هنا. الملف المصدر لم يعد مقفلًا بواسطة كائن العرض.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/androidjava/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. يوضح الكود التالي بلغة Java كيفية استخدام واجهة `IResourceLoadingCallback`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // تحميل صورة بديلة.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // استخدم أي طريقة للحصول على البايتات
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // تعيين عنوان URL بديل.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // تخطي جميع الصور الأخرى.
        return ResourceLoadingAction.Skip;
    }
}
```


## **تحميل العروض التقديمية دون كائنات ثنائية مضمّنة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المضمّنة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- بيانات كائن OLE المضمّنة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- بيانات ثنائية لعنصر تحكم ActiveX (يمكن الوصول إليها عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

باستخدام طريقة [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مضمّنة.

هذه الطريقة مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون ضارًا. يوضح الكود التالي بلغة Java كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مضمّن:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // تنفيذ عمليات على العرض التقديمي.
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستتلقى استثناءً أثناء التحميل يشير إلى فشل تحليل/تحقق من الصيغة. غالبًا ما تُشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، ولكن قد يستبدل [العرض/التصدير](/slides/ar/androidjava/convert-presentation/) الخطوط لاحقًا. يمكنك [تهيئة استبدال الخطوط](/slides/ar/androidjava/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المضمّنة (فيديو/صوت) عند الفتح؟**

ستصبح متاحة كموارد للعرض التقديمي. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن تلك المسارات قابلة للوصول في بيئتك؛ وإلا قد يُغفل [العرض/التصدير](/slides/ar/androidjava/convert-presentation/) عن الوسائط.