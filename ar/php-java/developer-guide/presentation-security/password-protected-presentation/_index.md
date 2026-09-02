---
title: تأمين العروض التقديمية بكلمات مرور في PHP
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/php-java/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل العرض التقديمي
- إلغاء قفل PowerPoint
- إلغاء قفل العرض التقديمي
- حماية PowerPoint
- حماية العرض التقديمي
- تعيين كلمة مرور
- إضافة كلمة مرور
- تشفير PowerPoint
- تشفير العرض التقديمي
- فك تشفير PowerPoint
- فك تشفير العرض التقديمي
- حماية كتابة
- أمان PowerPoint
- أمان العرض التقديمي
- إزالة كلمة المرور
- إزالة الحماية
- إزالة التشفير
- تعطيل كلمة المرور
- تعطيل الحماية
- إزالة حماية الكتابة
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية قفل وفك قفل عروض PowerPoint وعروض OpenDocument المحمية بكلمة مرور بسهولة باستخدام Aspose.Slides للغة PHP. أمان عروضك."
---
## **المقدمة**

عند حماية عرض تقديمي بكلمة مرور، يعني ذلك أنك تحدد كلمة مرور تُفرض قيودًا معينة على العرض. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمي بكلمة مرور عرضًا مقفلًا.

عادةً يمكنك تعيين كلمة مرور لتطبيق هذه القيود على العرض:

- **التعديل**

  إذا رغبت في أن يتمكن مستخدمون معينون فقط من تعديل العرض، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ محتويات العرض (إلا إذا قدموا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيتمكن المستخدم من الوصول إلى المستند وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتويات أو العناصر—الروابط التشعبية، الرسوم المتحركة، التأثيرات، وغيرها—داخل العرض، لكنه لا يستطيع نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا رغبت في أن يتمكن مستخدمون معينون فقط من فتح العرض، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتويات العرض (إلا إذا قدموا كلمة المرور).

  تقنيًا، يمنع قيد الفتح أيضًا تعديل العروض: عندما لا يستطيع الأشخاص فتح العرض، لا يمكنهم تعديل أو إجراء تغييرات عليه. 

  **ملاحظة** عند حماية عرض تقديمي بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **كيفية حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. انتقل إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/ar/lock).

   ![todo:image_alt_text](slides-lock.png)

2. اضغط على **Drop or upload your files**.

3. اختر الملف الذي تريد حمايته بكلمة مرور من على جهازك.

4. أدخل كلمة المرور المفضلة للحماية أثناء التحرير؛ أدخل كلمة المرور المفضلة للحماية أثناء العرض.

5. إذا رغبت في أن يرى المستخدمون عرضك كنسخة نهائية، ضع علامة في مربع **Mark as final**.

6. اضغط **PROTECT NOW.** 

7. اضغط **DOWNLOAD NOW.**

## **حماية كلمة المرور للعروض في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، والتشفير، والعمليات المماثلة للعروض بهذه الصيغ:

- PPTX و PPT - عرض Microsoft PowerPoint  
- ODP - عرض OpenDocument  
- OTP - قالب OpenDocument للعرض  

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور على العروض لمنع التعديلات بالطرق التالية:

- تشفير العرض  
- تعيين حماية كتابة للعرض  

**عمليات أخرى**

يتيح لك Aspose.Slides تنفيذ مهام أخرى تتعلق بحماية كلمة المرور والتشفير بالطرق التالية:

- فك تشفير عرض؛ فتح عرض مشفر  
- إزالة التشفير؛ إلغاء حماية كلمة المرور  
- إزالة حماية الكتابة من العرض  
- الحصول على خصائص عرض مشفر  
- التحقق مما إذا كان العرض مشفرًا  
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض تقديمي**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض تقديمي بكلمة مرور، استخدم طريقة encrypt من [ProtectionManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/) لتعيين كلمة مرور للعرض. تمرّر كلمة المرور إلى طريقة encrypt وتستخدم طريقة save لحفظ العرض المشفر الآن.

يعرض هذا المثال البرمجي كيفية تشفير عرض تقديمي:

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

## **تعيين حماية كتابة للعرض**

يمكنك إضافة علامة “لا تعدّل” إلى العرض. بهذه الطريقة، تخبر المستخدمين أنك لا تريدهم أن يجريوا تغييرات على العرض.  

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين—إذا رغبوا فعلاً—تعديل العرض، ولكن لحفظ التغييرات سيحتاجون إلى إنشاء نسخة باسم مختلف.

لتعيين حماية كتابة، استخدم طريقة [setWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#setWriteProtection). يوضح هذا المثال البرمجي كيفية تعيين حماية كتابة للعرض:

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

## **تحميل عرض مشفر**

يسمح لك Aspose.Slides بتحميل ملف مشفر بتمرير كلمة مروره. لفك تشفير عرض، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#removeEncryption) دون معلمات. ثم سيتوجب عليك إدخال كلمة المرور الصحيحة لتحميل العرض.

يعرض هذا المثال البرمجي كيفية فك تشفير عرض:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # العمل مع العرض غير المشفر
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **إزالة التشفير من العرض**

يمكنك إزالة التشفير أو حماية كلمة المرور من العرض. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، استدعِ طريقة [removeEncryption](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#removeEncryption). يوضح هذا المثال البرمجي كيفية إزالة التشفير من العرض:

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

## **إزالة حماية الكتابة من العرض**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف العرض. بهذه الطريقة، يستطيع المستخدمون التعديل بحرية ولا يتلقون تحذيرات عند القيام بذلك.

إزالة حماية الكتابة من العرض تتم عبر طريقة [removeWriteProtection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#removeWriteProtection). يوضح هذا المثال البرمجي كيفية إزالة حماية الكتابة من العرض:

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

عادةً يواجه المستخدمون صعوبة في استرداد خصائص المستند لعروض مشفرة أو محمية بكلمة مرور. ومع ذلك، يقدم Aspose.Slides آلية تسمح لك بحماية العرض بكلمة مرور مع الحفاظ على إمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يقوم Aspose.Slides بتشفير عرض، تُحمي خصائص المستند لكلمة مرور أيضًا. إذا كنت بحاجة إلى جعل خصائص المستند قابلة للوصول حتى بعد التشفير، يتيح لك Aspose.Slides فعل ذلك.

إذا رغبت في تمكين المستخدمين من الوصول إلى خصائص عرض مشفر، مرّر `false` إلى [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). يوضح هذا المثال البرمجي كيفية تشفير عرض مع السماح للمستخدمين بالوصول إلى خصائص المستند:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تحميل خصائص المستند فقط من عرض مشفر**

لفحص بيانات التعريف لعرض مشفر دون تحميل شرائحه أو محتوياته الأخرى، أنشئ كائن [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/) ومرّر `true` إلى [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمل فقط خصائص المستند المتاحة للجمهور.

يعرض المثال التالي قراءة خصائص المستند المدمجة والمخصصة عبر [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # قراءة خصائص المستند المدمجة.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # قراءة خصائص المستند المخصصة.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

يعمل هذا التدفق فقط عندما تكون خصائص المستند غير مشفرة (متاحة للعموم) عند تشفير العرض. إذا كانت خصائص المستند مشفرة، فإن تمرير `true` إلى [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) يتسبب في استثناء لأن كلمة المرور تُتجاهل في هذا الوضع. للوصول إلى خصائص المستند المشفرة أو تحميل العرض بالكامل بما في ذلك الشرائح ومحتوياته الأخرى، قدّم كلمة المرور الصحيحة عبر [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض، قد ترغب في التحقق من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، تتجنب الأخطاء والمشكلات المشابهة التي تظهر عند تحميل عرض محمي بدون كلمة المرور.

يعرض شفرة PHP التالية كيفية فحص عرض للتأكد إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **التحقق مما إذا كان العرض مشفرًا**

يسمح لك Aspose.Slides بالتحقق مما إذا كان العرض مشفرًا. للقيام بذلك، يمكنك استخدام طريقة [isEncrypted](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#isEncrypted) التي تُرجع `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن مشفرًا.

يعرض هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفرًا:

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

## **التحقق مما إذا كان العرض محميًا من الكتابة**

يسمح لك Aspose.Slides بالتحقق مما إذا كان العرض محميًا من الكتابة. للقيام بذلك، يمكنك استخدام طريقة [isWriteProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#isWriteProtected) التي تُرجع `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

يعرض هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

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

## **التحقق من صحة أو تأكيد استخدام كلمة مرور محددة**

قد ترغب في التحقق من أن كلمة مرور معينة قد استُخدمت لحماية مستند العرض. يوفر لك Aspose.Slides وسيلة للتحقق من صحة كلمة المرور. 

يعرض هذا المثال البرمجي كيفية التحقق من كلمة مرور:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # تحقق مما إذا كانت "pass" متطابقة
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

تُرجع `true` إذا تم تشفير العرض باستخدام كلمة المرور المحددة. وإلا تُرجع `false`. 

{{% alert color="primary" title="انظر أيضًا" %}} 
- [Digital Signature in PowerPoint](/slides/ar/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هي أساليب التشفير التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides أساليب التشفير الحديثة، بما في ذلك الخوارزميات المستندة إلى AES، مما يضمن مستوى عاليًا من أمان البيانات لعروضك.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض؟**

يتم رفع استثناء إذا استُخدمت كلمة مرور غير صحيحة، مما يُنبهك بأن الوصول إلى العرض مرفوض. يساعد ذلك في منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تأثير على الأداء عند التعامل مع عروض محمية بكلمة مرور؟**

قد يُحدث عملية التشفير وفك التشفير بعض العبء البسيط أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون هذا التأثير ضئيلًا ولا يؤثر بشكل كبير على الوقت الإجمالي لمعالجة مهام العرض.