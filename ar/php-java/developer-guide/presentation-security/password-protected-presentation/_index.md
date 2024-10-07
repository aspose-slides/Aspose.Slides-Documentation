---
title: تقديم محمي بكلمة مرور
type: docs
weight: 20
url: /php-java/password-protected-presentation/
keywords: "قفل عرض PowerPoint"
description: "قفل عرض PowerPoint. عرض PowerPoint محمي بكلمة مرور."
---

## **حول حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للعروض؟**
عندما تقوم بحماية عرض بكلمة مرور، فهذا يعني أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض. لإزالة القيود، يجب إدخال كلمة المرور. يعتبر العرض المحمي بكلمة مرور عرضًا مقفلاً.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت ترغب في أن يتمكن بعض المستخدمين فقط من تعديل عرضك، يمكنك تعيين قيود التعديل. هذه القيود تمنع الأشخاص من تعديل أو تغيير أو نسخ الأشياء في عرضك (ما لم يقدموا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيتمكن المستخدم من الوصول إلى المستند وفتحه. في وضع القراءة فقط، يمكن للمستخدم رؤية المحتويات أو الأشياء—الروابط، الرسوم المتحركة، التأثيرات، وغيرها—داخل عرضك، ولكن لا يمكنهم نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت ترغب في أن يتمكن بعض المستخدمين فقط من فتح عرضك، يمكنك تعيين قيود الفتح. تمنع هذه القيود الأشخاص حتى من مشاهدة محتويات عرضك (ما لم يقدموا كلمة المرور).

  تقنيًا، تمنع قيود الفتح أيضًا المستخدمين من تعديل عروضك: عندما لا يمكن للناس فتح عرض، لا يمكنهم تعديل أو إجراء تغييرات عليه.

  **ملاحظة** أنه عندما تقوم بحماية عرض بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **كيفية حماية عرض بكلمة مرور عبر الإنترنت**

1. انتقل إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **اسحب أو ارفع ملفاتك**.

3. اختر الملف الذي تريد حماية بكلمة مرور على جهاز الكمبيوتر الخاص بك.

4. أدخل كلمة المرور المفضلة لديك للحماية من التعديل؛ أدخل كلمة المرور المفضلة لديك لحماية العرض.

5. إذا كنت ترغب في أن يرى المستخدمون عرضك كنسخة نهائية، قم بتحديد مربع **تحديد كنهائي**.

6. انقر على **احمي الآن.**

7. انقر على **قم بتنزيل الآن.**

## **حماية كلمة المرور للعروض في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور والتشفير والعمليات المماثلة للعروض في هذه الصيغ:

- PPTX وPPT - عرض PowerPoint من Microsoft
- ODP - عرض OpenDocument
- OTP - قالب عرض OpenDocument

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض
- تعيين حماية للكتابة على عرض

**عمليات أخرى**

يتيح لك Aspose.Slides إجراء مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان عرض مشفرًا
- التحقق مما إذا كان عرض محميًا بكلمة مرور.

## **تشفير عرض**

يمكنك تشفير عرض عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يتعين على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض بكلمة مرور، يجب عليك استخدام طريقة التشفير (من [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) لتعيين كلمة مرور للعرض. تقوم بتمرير كلمة المرور إلى طريقة التشفير وتستخدم طريقة الحفظ لحفظ العرض المشفر الآن.

يعرض هذا الكود العيني كيفية تشفير عرض:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تعيين حماية الكتابة على عرض**

يمكنك إضافة علامة تشير إلى "عدم التعديل" إلى عرض. بهذه الطريقة، يمكنك إخبار المستخدمين أنك لا ترغب في إجراء تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين—إذا أرادوا فعلاً—تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف.

لتعيين حماية الكتابة، يجب عليك استخدام [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) الطريقة. يعرض هذا الكود العيني كيفية تعيين حماية الكتابة على عرض:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **فك تشفير عرض؛ فتح عرض مشفر**

يتيح لك Aspose.Slides تحميل ملف مشفر عن طريق تمرير كلمة مروره. لفك تشفير عرض، يجب عليك استدعاء [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) الطريقة بدون أي معلمات. بعد ذلك، سيتعين عليك إدخال كلمة المرور الصحيحة لتحميل العرض.

يعرض هذا الكود العيني كيفية فك تشفير عرض:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # العمل مع العرض الذي تم فك تشفيره
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور على عرض. بهذه الطريقة، تصبح إمكانية الوصول إلى العرض أو تعديله مفتوحة بدون قيود.

لإزالة التشفير أو حماية كلمة المرور، يجب عليك استدعاء [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) الطريقة. يعرض هذا الكود العيني كيفية إزالة التشفير من عرض:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **إزالة حماية الكتابة من عرض**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض. بهذه الطريقة، يمكن للمستخدمين التعديل كما يحلو لهم—ويحصلون على أي تحذيرات عند أداء مثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض باستخدام [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--) الطريقة. يعرض هذا الكود العيني كيفية إزالة حماية الكتابة من عرض:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **الحصول على خصائص عرض مشفر**

عادةً، يعاني المستخدمون من الحصول على خصائص الوثيقة لعرض مشفر أو محمي بكلمة مرور. ومع ذلك، يقدم Aspose.Slides آلية تتيح لك حماية عرض بكلمة مرور مع الاحتفاظ بالوسائل التي تتيح للمستخدمين الوصول إلى خصائص ذلك العرض.

**ملاحظة** أنه عند تشفير عرض بواسطة Aspose.Slides، يتم أيضًا حماية خصائص مستند العرض بكلمة مرور بشكل افتراضي. ولكن إذا كنت بحاجة إلى جعل خصائص العرض قابلة للوصول (حتى بعد تشفير العرض)، يتيح لك Aspose.Slides القيام بذلك بالضبط.

إذا كنت ترغب في أن يحتفظ المستخدمون بالقدرة على الوصول إلى خصائص عرض قمت بتشفيره، يمكنك تعيين [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) الخاصية إلى `true`. يعرض هذا الكود العيني كيفية تشفير عرض مع توفير وسائل للمستخدمين للوصول إلى خصائص مستنداته:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **التحقق مما إذا كان عرض محمي بكلمة مرور قبل تحميله**

قبل تحميل عرض، قد ترغب في التحقق والتأكد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، يمكنك تجنب الأخطاء والمشكلات المماثلة، التي تظهر عند تحميل عرض محمي بكلمة مرور دون كلمة المرور الخاصة به.

يعرض هذا الكود PHP كيفية فحص عرض لمعرفة ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("العرض محمي بكلمة مرور: " . $presentationInfo->isPasswordProtected());
```

## **التحقق مما إذا كان عرض مشفرًا**

يتيح لك Aspose.Slides التحقق مما إذا كان عرض مشفرًا. لأداء هذه المهمة، يمكنك استخدام [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--) الخاصية، والتي ترجع `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن العرض مشفرًا.

يعرض هذا الكود العيني كيفية التحقق مما إذا كان عرض مشفرًا:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **التحقق مما إذا كان عرض محميًا ضد الكتابة**

يتيح لك Aspose.Slides التحقق مما إذا كان عرض محميًا ضد الكتابة. لأداء هذه المهمة، يمكنك استخدام [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--) الخاصية، والتي ترجع `true` إذا كان العرض محميًا ضد الكتابة أو `false` إذا لم يكن العرض كذلك.

يعرض هذا الكود العيني كيفية التحقق مما إذا كان عرض محميًا ضد الكتابة:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **التحقق أو التأكد من أن كلمة مرور معينة قد تم استخدامها لحماية عرض**

قد ترغب في التحقق والتأكيد من أن كلمة مرور معينة قد تم استخدامها لحماية وثيقة العرض. يوفر Aspose.Slides الوسائل لك للتحقق من كلمة المرور.

يعرض هذا الكود العيني كيفية التحقق من كلمة مرور:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # تحقق مما إذا كانت "pass" مطابقة
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

ترجع `true` إذا كان العرض قد تم تشفيره بكلمة المرور المحددة. خلاف ذلك، ترجع `false`.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}