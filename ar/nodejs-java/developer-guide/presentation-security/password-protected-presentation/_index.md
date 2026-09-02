---
title: حماية العروض التقديمية بكلمة مرور في JavaScript
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/nodejs-java/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- تحقق من صحة كلمة مرور العرض
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
description: تشفير، اكتشاف، التحقق، فتح، وفك تشفير العروض التقديمية المحمية بكلمة مرور بصيغة PowerPoint PPT و PPTX في JavaScript باستخدام Aspose.Slides.
---
## **نظرة عامة**

كلمة مرور الفتح تقوم بتشفير عرض تقديمي. يلزم وجود كلمة المرور الصحيحة لتحميل محتوى العرض وعرضه، وبالتالي توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيّد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض. لإدارة كلمات المرور الخاصة بتعديل العروض، راجع [Write-Protect Presentations](/slides/ar/nodejs-java/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تُظهر الأمثلة كلا التنسيقين حيث يكون سلوكهما القائم على الملفات أو التيارات مهمًا.

## **تشفير عرض تقديمي باستخدام كلمة مرور الفتح**

استخدم [ProtectionManager.encrypt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#encrypt) لتعيين كلمة مرور الفتح. ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لحفظ العرض المشفر.

المثال التالي يقوم بتشفير عرض PPTX:

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

## **تحميل عرض مشفر**

عيّن [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل إذا كانت كلمة مرور الفتح مطلوبة ولكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // العمل مع العرض المفكوك.
} finally {
    presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مرور الفتح الخاصة به، واستدعِ [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#removeEncryption)، ثم احفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

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

## **التحقق من كلمة مرور الفتح قبل التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من القيمة التي تم تقديمها باستخدام [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **سير عمل المسار الملف**

المثال التالي يتحقق من صحة كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword)، ثم يحمل العرض الكامل:

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

### **سير عمل التيار**

استخدم [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) لفحص تيار قراءة Node.js. بعد استهلاك تيار الفحص، أنشئ تيارًا جديدًا قبل تحميل العرض الكامل باستخدام [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

### **قيم إرجاع checkPassword**

تُعيد [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkPassword) القيمة `true` فقط عندما يحتوي العرض على كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. تُعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك هو نفسه لعروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمّل مشفرًا**

بعد تحميل عرض باستخدام كلمة المرور الصحيحة، افحص [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) للتأكد من أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) كما هو موضح أعلاه.

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
لا تُسجّل كلمات مرور الفتح أو تُدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط للمدة المطلوبة، وأعِد استخدام نتيجة تحقق ناجحة عند تحميل العرض فورًا.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
2. اختر أو حمّل العرض.
3. أدخل كلمة مرور لحماية العرض.
4. (اختياري) أدخل كلمة مرور منفصلة لحماية التحرير.
5. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ar/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تقوم بتشفير العرض وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، تحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل تدعم سير عمل التحقق من كلمة المرور كلًا من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها بناءً على مسار الملف أو التيار يعمل بنفس الطريقة لعروض PPT و PPTX.