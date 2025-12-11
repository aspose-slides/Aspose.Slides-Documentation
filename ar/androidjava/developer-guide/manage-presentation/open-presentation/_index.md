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
description: "افتح عروض PowerPoint (.pptx, .ppt) و OpenDocument (.odp) بسهولة مع Aspose.Slides لنظام Android عبر Java—سريعة، موثوقة، ذات ميزات كاملة."
---

## **نظرة عامة**

إلى جانب إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرجاع معلومات حوله، تعديل محتوى الشرائح، إضافة شرائح جديدة، إزالة الشرائح الحالية، وأكثر من ذلك.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ومرّر مسار الملف إلى المُنشيء الخاص بها.
```java
// إنشاء كائن من الفئة Presentation وتمرير مسار الملف إلى المنشئ الخاص بها.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر طريقة [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) في الفئة [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود Java التالي هذه العملية:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // تنفيذ عمليات على العرض التقديمي المفكك تشفيره.
} finally {
    presentation.dispose();
}
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وخاصة طريقة [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) في الفئة [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)—لمساعدتك في تحميل عروض تقديمية كبيرة.

يوضح الكود Java التالي عملية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// اختر سلوك KeepLocked — سيبقى ملف العرض مؤمنًا طوال مدة
// مثيل Presentation، ولكن لا يلزم تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 ميغابايت

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

    // إجراء تغييرات على العرض التقديمي.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // لا تفعل هذا! سيتم رمي استثناء I/O لأن الملف مؤمن حتى يتم تحرير كائن العرض التقديمي.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// من المقبول فعل ذلك هنا. لم يعد ملف المصدر مؤمنًا من قبل كائن العرض التقديمي.
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عند الحاجة إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/androidjava/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) التي تمكنك من إدارة الموارد الخارجية. يوضح الكود Java التالي كيفية استخدام واجهة `IResourceLoadingCallback`:
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


## **تحميل العروض التقديمية بدون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- بيانات مدمجة لكائن OLE (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- بيانات ثنائية للتحكم ActiveX (يمكن الوصول إليها عبر [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

باستخدام طريقة [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

تُفيد هذه الطريقة في إزالة المحتوى الثنائي المحتمل أن يكون خبيثًا. يوضح الكود Java التالي كيفية تحميل عرض تقديمي بدون أي محتوى ثنائي مدمج:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // إجراء عمليات على العرض التقديمي.
} finally {
    presentation.dispose();
}
```


## **الأسئلة المتداولة**

**كيف يمكنني معرفة أن الملف معطوب ولا يمكن فتحه؟**

ستتلقى استثناءً متعلقًا بتحليل/تحقق من الصيغة أثناء التحميل. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint معطوبة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، ولكن قد تستبدل الخطوط لاحقًا أثناء [التصيير/التصدير](/slides/ar/androidjava/convert-presentation/). يمكنك [تكوين استبدالات الخطوط](/slides/ar/androidjava/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح هذه الوسائط متاحة كموارد للعرض التقديمي. إذا تم الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن تلك المسارات متاحة في بيئتك؛ وإلا قد [يتغاضى التصيير/التصدير](/slides/ar/androidjava/convert-presentation/) عن الوسائط.