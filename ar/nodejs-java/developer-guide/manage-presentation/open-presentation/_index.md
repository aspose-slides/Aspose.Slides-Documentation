---
title: فتح العروض التقديمية في JavaScript
linktitle: فتح عرض تقديمي
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
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في JavaScript، وتزويد كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides for Node.js via Java."
---
## **المقدمة**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/ar/nodejs-java/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات ومقاطع البيانات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو أي تنسيق آخر مدعوم.

يمكن تخصيص سلوك التحميل عبر فئة [LoadOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/). على سبيل المثال، يمكنك تزويد كلمة مرور الفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Node.js، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض**

بعد تحميل ملف أو تدفق، يمكنك [تحديد تنسيق العرض الأصلي](/slides/ar/nodejs-java/detect-presentation-source-format/) لاختيار طريقة معالجة تطبيقك له.

لفتح عرض موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). حرّر العرض بعد الاستخدام حتى يتم تحرير مقبض الملف والبيانات المؤقتة وغيرها من الموارد بسرعة.

يوضح المثال التالي بلغة JavaScript كيفية فتح عرض والحصول على عدد شرائحه:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **فتح العروض المحمية بكلمة مرور**

تشفّر كلمة مرور الفتح محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

للحصول على معلومات حول اكتشاف كلمة المرور، التحقق، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/nodejs-java/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص دون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/nodejs-java/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) تُعيد خيارات تتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلًا، السماح بالملفات المؤقتة، وتحديد مقدار بيانات BLOB المُحتفظ بها في الذاكرة.

يعرض الكود التالي بلغة JavaScript كيفية تحميل عرض كبير (مثال، 2 جيجابايت):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
باستخدام [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلًا حتى يتم تحرير كائن العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر أثناء بقاء هذا الكائن حيًا.

قد تقوم Aspose.Slides بنسخ محتوى تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عادةً أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/nodejs-java/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) يقبل تنفيذًا لـ[IResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iresourceloadingcallback/). يمكن لواجهة الاستدعاء توفير بيانات بديلة، إعادة توجيه مورد، استخدام المُحمِّل الافتراضي، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **تحميل العروض بدون كائنات ثنائية مدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. من الأمثلة:

- مشاريع VBA، متاحة عبر [Presentation.getVbaProject](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getVbaProject)؛
- بيانات OLE مدمجة، متاحة عبر [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData)؛
- بيانات عناصر تحكم ActiveX، متاحة عبر [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

اضبط [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض الذي تم تحميله للحفاظ على النتيجة المنقاة.

يقلل هذا الخيار من تعرض التطبيق للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرامج الضارة أو تنقية المحتوى.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً يتعلق بالتحليل أو التنسيق أثناء التحميل. تعامل مع هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يظل يُحمّل، لكن قد تستبدل الخطوط أثناء العرض والتصدير. يمكنك [تكوين استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/nodejs-java/custom-font/) لجعل الناتج أكثر توقعًا.

**هل تحميل العرض يقوم أيضًا بتحميل الوسائط المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. يتم حل الموارد الخارجية وفق سلوك تحميل الموارد المُعد وقد تكون غير متاحة إذا تعذر الوصول إلى مواقعها.