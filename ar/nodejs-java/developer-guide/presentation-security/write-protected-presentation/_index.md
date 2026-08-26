---
title: حماية العروض التقديمية من الكتابة في JavaScript
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/nodejs-java/write-protected-presentation/
keywords:
- حماية الكتابة
- حماية الكتابة لبرنامج PowerPoint
- كلمة مرور للتعديل
- تقييد تحرير العرض التقديمي
- إزالة حماية الكتابة
- التحقق من صحة كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعيين، اكتشاف، التحقق من صحة وإزالة كلمات مرور حماية الكتابة في عروض PowerPoint بصيغ PPT و PPTX باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **المقدمة**

كلمة مرور حماية الكتابة تقيّد تعديل العرض التقديمي لكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض تقديمي محمي من الكتابة بدون كلمة المرور. بناءً على التطبيق، قد يكون بإمكانهم أيضًا تحرير المحتوى وحفظه باسم مختلف، لذا لا يجب اعتبار حماية الكتابة آلية سرية.

كلمة مرور الفتح لها غرض مختلف: فهي تشفر العرض التقديمي وتُطلب لتحميل محتواه. لتشفير عرض تقديمي أو للتحقق من كلمة مرور الفتح، راجع [حماية العروض التقديمية بكلمة مرور](/slides/ar/nodejs-java/password-protected-presentation/).

تنطبق سير العمل في هذه المقالة على كل من عروض PPT و PPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ كـ PPT، استخدم الامتداد `.ppt` وتنسيق الحفظ المناسب لـ PPT.

## **تعيين حماية الكتابة على عرض تقديمي**

استخدم [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) لتعيين كلمة مرور لتعديل العرض التقديمي. حفظ العرض التقديمي يُحافظ على إعداد الحماية.

المثال التالي يحدد حماية الكتابة على عرض تقديمي بصيغة PPTX:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحميل عرض تقديمي محمي من الكتابة**

لأن حماية الكتابة لا تشفر محتوى العرض التقديمي، لا يلزم كلمة مرور لتحميل العرض. كلمة المرور ذات صلة فقط عند التحقق من التفويض لتعديل العرض المحمي.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

لا تمرر كلمة مرور حماية الكتابة إلى [LoadOptions.setPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setPassword). هذه الطريقة تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض كلا النوعين من الحماية، قدّم كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور حماية الكتابة بشكل منفصل.

## **إزالة حماية الكتابة من عرض تقديمي**

استخدم [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) لإزالة قيود التعديل، ثم احفظ العرض التقديمي.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق مما إذا كان العرض التقديمي محميًا من الكتابة**

لتفقد ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) كامل، استدعِ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) وتفقد [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). تستخدم الطريقة [NullableBool](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/nullablebool/) وتعيد `NullableBool.True` عندما يتم اكتشاف حماية الكتابة.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

الطريقة المستندة إلى التدفق [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) توفر نفس المعلومات لعرض تقديمي يُزود كدفق قابل للقراءة في Node.js.

## **التحقق من صحة كلمة مرور الحماية من الكتابة**

استخدم [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) للتحقق من كلمة مرور التعديل دون تحميل العرض الكامل. افحص [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) أولاً حتى يطلب التطبيق أو يتحقق من كلمة المرور فقط عندما تكون حماية الكتابة موجودة.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) يتحقق فقط من كلمة مرور حماية الكتابة. لا يتحقق من كلمة مرور الفتح أو يحدد ما إذا كان يمكن تحميل المحتوى المشفر. بالمقابل، [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/#checkPassword) يتحقق فقط من كلمة مرور الفتح. إذا تم تحميل عرض كامل مسبقًا، فإن [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) يقدم فحص حماية الكتابة المكافئ عبر مدير الحماية الخاص به.

في التطبيقات الإنتاجية، لا تسجّل كلمات المرور ولا تضمّنها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط للفترة المطلوبة.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض التقديمية بكلمة مرور](/slides/ar/nodejs-java/password-protected-presentation/)
- [عروض تقديمية للقراءة فقط](/slides/ar/nodejs-java/read-only-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تقوم حماية الكتابة بتشفير العرض التقديمي؟**

لا. إنها تقيد التعديل لكن تترك محتوى العرض التقديمي متاحًا للتحميل والعرض.

**هل كلمة مرور حماية الكتابة مطلوبة لفتح عرض تقديمي؟**

لا. فقط كلمة مرور الفتح مطلوبة لتحميل محتوى العرض المشفر.

**هل يمكن للعرض التقديمي أن يكون له كل من كلمة مرور الفتح وكلمة مرور حماية الكتابة؟**

نعم. قدّم كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وقم بالتحقق من كلمة مرور حماية الكتابة بشكل منفصل عندما تكون تفويض التعديل مطلوبًا.