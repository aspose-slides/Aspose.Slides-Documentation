---
title: حماية العروض التقديمية بكلمة مرور في JavaScript
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/nodejs-java/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور افتتاحية
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تشفير، كشف، التحقق، فتح، وفك تشفير عروض PowerPoint PPT و PPTX المحمية بكلمة مرور في JavaScript باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة المرور الافتتاحية تقوم بتشفير العرض التقديمي. يُتطلب كلمة المرور الصحيحة لتحميل وعرض محتوى العرض التقديمي، وبالتالي توفر هذه الحماية السرية.

كلمة المرور الافتتاحية تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيّد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/nodejs-java/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا الصيغتين حيث يكون سلوكهما القائم على الملفات أو التدفقات مهمًا.

## **تشفير عرض تقديمي بكلمة مرور افتتاحية**

استخدم [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#encrypt) لتعيين كلمة مرور افتتاحية. ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لحفظ العرض التقديمي المشفر.

المثال التالي يشفر عرض PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اجعل خصائص المستند عامة**

بشكل افتراضي، تتضمن Aspose.Slides خصائص المستند في تشفير العرض التقديمي. تتحكم الطريقة [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) في هذا السلوك بشكل مستقل عن تشفير محتوى الشرائح. مرّر `false` قبل استدعاء [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#encrypt) عندما يتعين على نظام الفهرسة أو التصنيف أو البحث أو إدارة الوثائق قراءة البيانات الوصفية دون كلمة المرور الافتتاحية.

المثال التالي ينشئ عرض PPTX مشفر مع ترك خصائص المستند المدمجة عامة:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تمرير `false` إلى [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو غيرها من محتوى العرض التقديمي عامة. يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [Manage Presentation Properties](/slides/ar/nodejs-java/presentation-properties/).

## **تحميل عرض تشفير**

عيّن [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword) إلى كلمة المرور الافتتاحية ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) عند تحميل الملف. سيظهر فشل في التحميل عندما تكون كلمة المرور الافتتاحية مطلوبة ولكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي المفكّ تشفيره.
} finally {
    presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض التقديمي باستخدام كلمة المرور الافتتاحية، استدعِ [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#removeEncryption)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض التقديمي المحفوظ دون كلمة مرور.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق من كلمة المرور الافتتاحية قبل التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) للحصول على [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض التقديمي. افحص [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من القيمة التي تم التحقق منها باستخدام [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **سير عمل المسار إلى الملف**

المثال التالي يتحقق من كلمة مرور افتتاحية لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword)، ثم يحمل العرض التقديمي الكامل:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **سير عمل التدفق**

استخدم [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) لفحص تدفق قابل للقراءة في Node.js. بعد استهلاك تدفق الفحص، أنشئ تدفقًا جديدًا قبل تحميل العرض التقديمي الكامل باستخدام [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

المثال التالي يستخدم ملف PPT:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **قيم الإرجاع لدالة checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkPassword) تُعيد `true` فقط عندما يكون للعرض التقديمي كلمة مرور افتتاحية وكانت كلمة المرور المقدمة صحيحة. تُعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض التقديمي لا يحتوي على كلمة مرور افتتاحية.
- الكلمة المقدمة هي `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض التقديمي المحمّل مشفرًا**

بعد تحميل عرض تقديمي باستخدام كلمة المرور الصحيحة، افحص [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) للتأكد من أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة المرور الافتتاحية قبل التحميل، استخدم [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) كما هو موضح أعلاه.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **توصيات الأمان**

{{% alert color="warning" title="Security" %}}
لا تقم بتسجيل كلمات المرور الافتتاحية أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط طالما يلزم، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض التقديمي مباشرة.

قد تكشف خصائص المستند العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة رغم أن محتوى العرض التقديمي مشفر. قم بتشفير البيانات الوصفية الحساسة مع العرض التقديمي. يجب أن يكون ترك الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما تحتاج الأنظمة إلى الفهرسة أو التصنيف أو البحث أو إدارة الملف دون كلمة مرور افتتاحية.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. حدد أو حمّل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض.
1. اختياريًا، أدخل كلمة مرور منفصلة لحماية التعديل.
1. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [حماية العروض من الكتابة](/slides/ar/nodejs-java/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين كلمة المرور الافتتاحية وكلمة مرور الحماية من الكتابة؟**

كلمة المرور الافتتاحية تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيّد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة المرور الافتتاحية دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض التقديمي، وتحقق ما إذا كانت حماية كلمة المرور الافتتاحية موجودة، وحقق من صحة كلمة المرور قبل إنشاء نسخة كاملة من العرض التقديمي.

**هل يمكن للتطبيق قراءة البيانات الوصفية دون كلمة المرور الافتتاحية؟**

نعم، ولكن فقط عندما يكون العرض التقديمي مشفرًا مع تعطيل تشفير خصائص المستند. يجب على التطبيق حينئذٍ استخدام وضع التحميل الذي يقتصر على خصائص المستند كما هو موضح في [Manage Presentation Properties](/slides/ar/nodejs-java/presentation-properties/).

**هل تدعم سير عمل فحص كلمة المرور كلًا من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها عبر مسار الملف أو التدفق يعملان بنفس الطريقة بالنسبة لعروض PPT و PPTX.