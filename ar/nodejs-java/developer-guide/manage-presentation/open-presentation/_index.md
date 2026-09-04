---
title: فتح العروض التقديمية في JavaScript
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/nodejs-java/open-presentation/
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
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint وOpenDocument في JavaScript، وتوفير كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **المقدمة**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/ar/nodejs-java/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات وتدفقات البيانات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالصيغ الأصلية أو بأي صيغة مدعومة أخرى.

يمكن تخصيص سلوك التحميل عبر الفئة [LoadOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور الفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Node.js، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، مرّر مسار ملفه إلى منشئ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). احرص على تحرير العرض بعد الاستخدام حتى يتم تحرير مقبض الملف والبيانات المؤقتة وغيرها من الموارد بسرعة.

يعرض المثال التالي بلغة JavaScript كيفية فتح عرض تقديمي والحصول على عدد الشرائح الخاصة به:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

كلمة المرور تشفر محتوى العرض التقديمي. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword) وقدم الخيارات إلى منشئ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

للاطلاع على اكتشاف كلمة المرور، والتحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/nodejs-java/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/nodejs-java/presentation-properties/).

## **فتح عروض تقديمية ضخمة**

تُعيد الدالة [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) خيارات تتحكم في كيفية تعامل Aspose.Slides مع الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بالملفات المؤقتة، وتحديد مقدار بيانات BLOB المحتفظ بها في الذاكرة.

يُظهر الكود التالي بلغة JavaScript تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):

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

{{% alert color="info" title="ملاحظة" %}}
مع [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلاً حتى يتم تحرير كائن العرض التقديمي. لا تقم بنقل الملف أو استبداله أو حذفه بينما يكون هذا الكائن نشطًا.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عادةً أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/nodejs-java/manage-blob/) للحصول على خيارات إضافية لتخزين البيانات وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

تقبل الدالة [LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) تنفيذًا لـ [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iresourceloadingcallback/). يمكن للاستدعاء إمداد بيانات بديلة، إعادة توجيه مورد، استخدام المحمل الافتراضي، أو تخطي المورد. يُستخدم هذا عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

قد يحتوي العرض التقديمي على بيانات ثنائية مدمجة لا تحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [Presentation.getVbaProject](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getVbaProject)؛
- بيانات OLE مدمجة، متاحة عبر [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData)؛
- بيانات عناصر تحكم ActiveX، متاحة عبر [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

قم بتعيين [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض الذي تم تحميله لتثبيت النتيجة المنقاة.

يقلل هذا الخيار من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الضارة أو تنقية المحتوى.

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

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً متعلقًا بالتحليل أو تنسيق الملف أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض التقديمي أن يظل يُحمَّل، لكن قد يستبدل المحرك الخطوط أثناء العرض والتصدير. يمكنك [configure font substitution](/slides/ar/nodejs-java/font-substitution/) أو [provide custom fonts](/slides/ar/nodejs-java/custom-font/) لجعل المخرجات أكثر قابلية للتنبؤ.

**هل تحميل العرض يحمِّل أيضًا الوسائط المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض التقديمي. تُحل الموارد الخارجية وفق سلوك تحميل الموارد المكوَّن وقد تكون غير متاحة إذا تعذّر الوصول إلى مواقعها.