---
title: فتح عرض تقديمي في JavaScript
linktitle: فتح العروض
type: docs
weight: 20
url: /ar/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "فتح عروض PowerPoint (.pptx, .ppt) و OpenDocument (.odp) بسهولة باستخدام Aspose.Slides لـ Node.js — سريع، موثوق، ذو ميزات كاملة."
---

## **نظرة عامة**

بالإضافة إلى إنشاء عروض PowerPoint من الصفر، يتيح Aspose.Slides أيضًا فتح العروض الحالية. بعد تحميل عرض تقديمي، يمكنك استرجاع معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، حذف الشرائح الموجودة، وغير ذلك.

## **فتح العروض**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

النموذج التالي بلغة JavaScript يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح:
```js
// إنشاء كائن من فئة Presentation وتمرير مسار ملف إلى مُنشئها.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // طباعه إجمالي عدد الشرائح في العرض التقديمي.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **فتح العروض المحمية بكلمة مرور**

عند الحاجة لفتح عرض محمي بكلمة مرور، مرّر كلمة المرور عبر طريقة [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword) من فئة [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي ذلك:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // تنفيذ عمليات على العرض التقديمي المفكوك.
} finally {
    presentation.dispose();
}
```


## **فتح العروض الكبيرة**

يوفر Aspose.Slides خيارات—خصوصًا طريقة [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) في فئة [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)—لمساعدتك في تحميل العروض الكبيرة.

الكود التالي بلغة JavaScript يوضح تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// اختر سلوك KeepLocked — سيبقى ملف العرض مقفولًا طوال مدة
// كائن Presentation، لكن لا يحتاج إلى تحميله في الذاكرة أو نسخه إلى ملف مؤقت.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 ميجابايت

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // تم تحميل العرض الكبير ويمكن استخدامه، بينما يظل استهلاك الذاكرة منخفضًا.
    
    // إجراء تغييرات على العرض.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // حفظ العرض إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // لا تفعل هذا! سيتم إثارة استثناء إدخال/إخراج لأن الملف مقفول حتى يتم التخلص من كائن العرض.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// يمكن فعل ذلك هنا. الملف المصدر لم يعد مقفولًا بواسطة كائن العرض.
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التيارات، قد يقوم Aspose.Slides بنسخ محتويات التيار. تحميل عرض تقديمي كبير من تيار يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التيار.

عند إنشاء عرض يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/nodejs-java/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) التي تسمح لك بإدارة الموارد الخارجية. يوضح الكود التالي بلغة JavaScript كيفية استخدام الواجهة `IResourceLoadingCallback`:
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // تحميل صورة بديلة.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // تعيين عنوان URL بديل.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // تخطي جميع الصور الأخرى.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **تحميل العروض دون كائنات ثنائية مضمّنة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المضمّنة:

- مشروع VBA (يمكن الوصول إليه عبر [Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject));
- بيانات كائن OLE المضمّنة (يمكن الوصول إليها عبر [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- بيانات ثنائية لعنصر تحكم ActiveX (يمكن الوصول إليها عبر [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

باستخدام طريقة [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مضمّنة.

هذه الطريقة مفيدة لإزالة المحتوى الثنائي الذي قد يكون ضارًا. يوضح الكود التالي بلغة JavaScript كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مضمّن:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // قم بتنفيذ عمليات على العرض التقديمي.
} finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستحصل على استثناء أثناء التحميل يوضح حدوث خطأ في التحليل/التحقق من الصيغة. غالبًا ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint معطوبة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، لكن عملية [التصيير/التصدير](/slides/ar/nodejs-java/convert-presentation/) قد تستبدل الخطوط. يمكنك [تهيئة استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/nodejs-java/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المضمّنة (فيديو/صوت) عند الفتح؟**

تتحول إلى موارد داخل العرض. إذا كانت الوسائط مُشار إليها عبر مسارات خارجية، تأكد من أن هذه المسارات متاحة في بيئتك؛ وإلا قد تقوم عملية [التصيير/التصدير](/slides/ar/nodejs-java/convert-presentation/) بإغفال الوسائط.