---
title: حماية العروض التقديمية من الكتابة في PHP
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/php-java/write-protected-presentation/
keywords:
- حماية الكتابة
- حماية كتابة PowerPoint
- كلمة مرور للتعديل
- تقييد تحرير العرض التقديمي
- إزالة حماية الكتابة
- التحقق من صحة كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعيين كلمة مرور حماية الكتابة، واكتشافها، والتحقق من صحتها، وإزالتها في عروض PowerPoint بصيغة PPT و PPTX باستخدام Aspose.Slides للـ PHP."
---
## **المقدمة**

كلمة مرور حماية الكتابة تقيد تعديل العرض التقديمي لكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض محمي ضد الكتابة دون كلمة المرور. اعتمادًا على التطبيق، قد يكون بإمكانهم أيضًا تحرير المحتوى وحفظه باسم مختلف، لذا لا ينبغي اعتبار حماية الكتابة كآلية للسرية.

كلمة مرور الفتح لها غرض مختلف: فهي تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. لتشفير عرض تقديمي أو للتحقق من صحة كلمة مرور الفتح، انظر [العروض المحمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/).

تنطبق سير العمل في هذه المقالة على كل من عروض PPT و PPTX. الأمثلة تستخدم ملفات PPTX؛ عند الحفظ بصيغة PPT، استخدم الامتداد `.ppt` وصيغة الحفظ المقابلة لـ PPT.

## **تعيين حماية الكتابة على عرض تقديمي**

استخدم [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#setWriteProtection) لتعيين كلمة مرور لتعديل العرض التقديمي. يحفظ حفظ العرض التقديمي إعداد الحماية.

المثال التالي يضع حماية كتابة على عرض PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تحميل عرض محمي ضد الكتابة**

نظرًا لأن حماية الكتابة لا تشفر محتوى العرض التقديمي، لا يلزم كلمة مرور لتحميل العرض. تكون كلمة المرور ذات صلة فقط عند التحقق من التفويض لتعديل العرض المحمي.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

لا تمرر كلمة مرور حماية الكتابة إلى [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword). هذه الطريقة تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض التقديمي كلا النوعين من الحماية، قدم كلمة مرور الفتح لتحميله وتعامل مع كلمة مرور حماية الكتابة بشكل منفصل.

## **إزالة حماية الكتابة من عرض تقديمي**

استخدم [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#removeWriteProtection) لإزالة قيود التعديل، ثم احفظ العرض التقديمي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) كامل، استدعِ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) وتفقد [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isWriteProtected). تستخدم الطريقة فئة [NullableBool](https://reference.aspose.com/slides/ar/php-java/aspose.slides/nullablebool/) وتعيد `NullableBool::True` عندما يتم اكتشاف حماية الكتابة.

يوفر التحميل عبر التدفق للـ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) نفس المعلومات لعرض تقديمي مقدم كتيار.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

## **التحقق من صحة كلمة مرور حماية الكتابة**

استخدم [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkWriteProtection) للتحقق من كلمة مرور التعديل دون تحميل العرض بالكامل. تحقق أولًا من [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isWriteProtected) حتى يطلب التطبيق كلمة مرور أو يتحقق منها فقط عندما تكون حماية الكتابة موجودة.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkWriteProtection) يتحقق فقط من كلمة مرور حماية الكتابة. لا يتحقق من كلمة مرور الفتح أو يحدد ما إذا كان يمكن تحميل المحتوى المشفر. بالمقابل، [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkPassword) يتحقق فقط من كلمة مرور الفتح. إذا كان قد تم تحميل عرض تقديمي كامل بالفعل، توفر [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#checkWriteProtection) فحص حماية الكتابة المكافئ عبر مدير الحماية.

في التطبيقات الإنتاجية، لا تقم بتسجيل كلمات المرور أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط للطول اللازم.

{{% alert color="info" title="انظر أيضًا" %}}
- [العروض المحمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/)
- [العروض للقراءة فقط](/slides/ar/php-java/read-only-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**هل تقوم حماية الكتابة بتشفير العرض التقديمي؟**

لا. إنها تقيد التعديل لكن تترك محتوى العرض التقديمي متاحًا للتحميل والعرض.

**هل كلمة مرور حماية الكتابة مطلوبة لفتح العرض التقديمي؟**

لا. كلمة مرور الفتح فقط مطلوبة لتحميل محتوى العرض المشفر.

**هل يمكن أن يحتوي عرض تقديمي على كل من كلمة مرور الفتح وكلمة مرور حماية الكتابة؟**

نعم. قدّم كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من كلمة مرور حماية الكتابة بشكل منفصل عندما يتطلب التفويض للتعديل.