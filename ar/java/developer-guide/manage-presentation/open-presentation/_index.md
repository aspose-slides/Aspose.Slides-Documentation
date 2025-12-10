---
title: فتح العروض التقديمية في Java
linktitle: فتح العرض التقديمي
type: docs
weight: 20
url: /ar/java/open-presentation/
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
- Java
- Aspose.Slides
description: "افتح عروض PowerPoint (.pptx, .ppt) و OpenDocument (.odp) بسهولة باستخدام Aspose.Slides for Java — سريع، موثوق، غني بالمميزات."
---

## **نظرة عامة**

إلى جانب إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل العرض التقديمي، يمكنك استخراج معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ومرر مسار الملف إلى منشئها.

يظهر المثال التالي بلغة Java كيفية فتح عرض تقديمي والحصول على عدد الشرائح فيه:
```java
// إنشاء كائن من الفئة Presentation وتمرير مسار الملف إلى منشئها.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر طريقة [setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) في الفئة [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة Java هذه العملية:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // تنفيذ العمليات على العرض التقديمي المفكوك.
} finally {
    presentation.dispose();
}
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—خاصة طريقة [getBlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) في الفئة [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)—لمساعدتك على تحميل العروض التقديمية ذات الحجم الكبير.

يظهر الكود التالي بلغة Java كيفية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Choose the KeepLocked behavior — سيظل ملف العرض مقفلًا طوال مدة
// كائن Presentation، ولكن لا يلزم تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 ميجابايت

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // قم بإجراء تغييرات على العرض التقديمي.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // احفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا خلال هذه العملية.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تقم بذلك! سيُرمى استثناء إدخال/إخراج لأن الملف مقفل حتى يتم تحرير كائن العرض التقديمي.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// لا بأس بأن تقوم بذلك هنا. الملف الأصلي لم يعد مقفلًا بواسطة كائن العرض التقديمي.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [إدارة BLOB](/slides/ar/java/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يوضح الكود التالي بلغة Java كيفية استخدام واجهة `IResourceLoadingCallback`:
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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getVbaProject--));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- بيانات التحكم ActiveX الثنائية (يمكن الوصول إليها عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

باستخدام طريقة [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

تُستخدم هذه الطريقة لإزالة المحتوى الثنائي المحتمل أن يكون ضارًا. يوضح الكود التالي بلغة Java كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مدمج:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // قم بتنفيذ العمليات على العرض التقديمي.
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف معطوب ولا يمكن فتحه؟**

ستتلقى استثناءً يتعلق بالتحليل أو التحقق من صحة التنسيق أثناء التحميل. غالبًا ما تُشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، ولكن قد يستبدل [العرض/التصدير](/slides/ar/java/convert-presentation/) الخطوط لاحقًا. يمكنك [تكوين استبدال الخطوط](/slides/ar/java/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/java/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح الوسائط متاحة كموارد للعرض التقديمي. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من أن هذه المسارات قابلة للوصول في بيئتك؛ وإلا قد تُهمل أثناء [العرض/التصدير](/slides/ar/java/convert-presentation/).