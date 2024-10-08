---
title: تقديم محمي بكلمة مرور
type: docs
weight: 20
url: /ar/java/password-protected-presentation/
keywords: "قفل عرض PowerPoint في Java"
description: "قفل عرض PowerPoint. تقديم محمي بكلمة مرور في Java"
---

## **حول حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للتقديم؟**
عندما تحمي عرضًا بكلمة مرور، فهذا يعني أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض. لإزالة القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمي بكلمة مرور عرضًا مقفلاً.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد أن يتمكن مستخدمون معينون فقط من تعديل العرض الخاص بك، يمكنك ضبط قيد تعديل. يمنع القيد هنا الأشخاص من تعديل أو تغيير أو نسخ الأشياء في العرض الخاص بك (ما لم يقوموا بتقديم كلمة المرور). 

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيتمكن المستخدم من الوصول إلى مستندك وفتحه. في هذا الوضع للقراءة فقط، يمكن للمستخدم عرض المحتويات أو الأشياء - روابط، رسوم متحركة، تأثيرات، وغيرها - داخل العرض الخاص بك، لكن لا يمكنهم نسخ العناصر أو حفظ العرض. 

- **الفتح**

  إذا كنت تريد أن يتمكن مستخدمون معينون فقط من فتح عرضك، يمكنك ضبط قيد فتح. يمنع القيد هنا الأشخاص حتى من عرض محتويات العرض الخاص بك (ما لم يقوموا بتقديم كلمة المرور).

  تقنيًا، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك: عندما لا يتمكن الأشخاص من فتح عرض، لا يمكنهم تعديله أو إجراء تغييرات عليه. 

  **ملاحظة** أنه عند حماية عرض بكلمة مرور لمنع الفتح، تصبح ملف العرض مشفرًا.

## **كيفية حماية عرض بكلمة مرور عبر الإنترنت**

1. انتقل إلى صفحتنا [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **إسقاط أو تحميل ملفاتك**.

3. حدد الملف الذي تريد حماية بكلمة مرور على جهاز الكمبيوتر الخاص بك.

4. أدخل كلمة المرور المفضلة لديك لحماية التعديل؛ أدخل كلمة المرور المفضلة لديك لحماية العرض. 

5. إذا كنت تريد من المستخدمين رؤية عرضك كنسخة نهائية، قم بتحديد خانة **وضع علامة كنهائي**.

6. انقر على **احمي الآن.** 

7. انقر على **قم بالتحميل الآن.**

## **حماية كلمة المرور للعروض في Aspose.Slides**
**الصيغ المدعومة**

تدعم Aspose.Slides حماية بكلمة مرور، والتشفير، وعمليات مماثلة للعروض بهذه الصيغ: 

- PPTX و PPT - عرض PowerPoint من Microsoft 
- ODP - عرض OpenDocument 
- OTP -  قالب عرض OpenDocument 

**العمليات المدعومة**

تتيح لك Aspose.Slides استخدام حماية بكلمة مرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض
- تعيين حماية الكتابة لعرض

**عمليات أخرى**

تتيح لك Aspose.Slides تنفيذ مهام أخرى تتعلق بحماية بكلمة مرور والتشفير بهذه الطرق:

- فك تشفير عرض؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض**

يمكنك تشفير عرض من خلال تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور. 

لتشفير أو حماية عرض بكلمة مرور، تحتاج إلى استخدام طريقة التشفير (من [IProtectionManager](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager)) لتعيين كلمة مرور للعرض. تقوم بتمرير كلمة المرور إلى طريقة التشفير وتستخدم طريقة الحفظ لحفظ العرض المشفر الآن. 

يوضح هذا الكود النموذجي كيفية تشفير عرض:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تعيين حماية الكتابة لعرض**

يمكنك إضافة علامة تشير إلى "عدم التعديل" لعرض. بهذه الطريقة، يمكنك إخبار المستخدمين أنك لا تريد منهم إجراء تغييرات على العرض.  

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين - إذا أرادوا ذلك - تعديل العرض، لكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف. 

لتعيين حماية الكتابة، تحتاج إلى استخدام طريقة [setWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . يوضح هذا الكود النموذجي كيفية تعيين حماية الكتابة لعلاقة:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **فك تشفير عرض؛ فتح عرض مشفر**

تتيح لك Aspose.Slides تحميل ملف مشفر من خلال تمرير كلمة المرور الخاصة به. لفك تشفير عرض، تحتاج إلى استدعاء [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) بدون أي معلمات. سيتعين عليك بعد ذلك إدخال كلمة المرور الصحيحة لتحميل العرض. 

يوضح هذا الكود النموذجي كيفية فك تشفير عرض: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض المفكوك التشفير
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله بدون قيود. 

لإزالة التشفير أو حماية كلمة مرور، تحتاج إلى استدعاء [removeEncryption](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) . يوضح هذا الكود النموذجي كيفية إزالة التشفير من عرض:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة حماية الكتابة من عرض**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض. بهذه الطريقة، يمكن للمستخدمين التعديل كما يريدون - ولا يحصلون على تحذيرات عند تنفيذ مثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض باستخدام طريقة [removeWriteProtection](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . يوضح هذا الكود النموذجي كيفية إزالة حماية الكتابة من عرض:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **الحصول على خصائص عرض مشفر**

عادةً، يواجه المستخدمون صعوبة في الحصول على خصائص الوثيقة لعرض مشفر أو محمي بكلمة مرور. ومع ذلك، تقدم Aspose.Slides آلية تتيح لك حماية عرض بكلمة مرور مع الاحتفاظ بالوسائل التي تسمح للمستخدمين بالوصول إلى خصائص هذا العرض.

**ملاحظة** أنه عندما تشفر Aspose.Slides عرضًا، يتم حماية الخصائص الوثائقية للعرض بكلمة مرور أيضًا بشكل افتراضي. ولكن إذا كنت بحاجة إلى جعل خصائص العرض متاحة (حتى بعد تشفير العرض)، فإن Aspose.Slides تتيح لك القيام بذلك بدقة.

إذا كنت تريد من المستخدمين الاحتفاظ بإمكانية الوصول إلى خصائص العرض الذي قمت بتشفيره، يمكنك تعيين [encryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--)  إلى `true`. يوضح هذا الكود النموذجي كيفية تشفير عرض مع توفير الوسائل للمستخدمين للوصول إلى خصائص الوثيقة الخاصة به:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله**

قبل تحميل عرض، قد ترغب في التحقق والتأكد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، تتجنب الأخطاء وغيرها من المشكلات المشابهة التي تحدث عند تحميل عرض محمي بكلمة مرور بدون كلمة المرور الخاصة به.

يوضح هذا الكود في Java كيفية فحص عرض لمعرفة ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("العرض محمي بكلمة مرور: " + presentationInfo.isPasswordProtected());
```

## **التحقق مما إذا كان العرض مشفرًا**

تتيح لك Aspose.Slides التحقق مما إذا كان العرض مشفرًا. لأداء هذه المهمة، يمكنك استخدام خاصية [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--)، التي تعيد `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن العرض مشفرًا. 

يوضح هذا الكود النموذجي كيفية التحقق مما إذا كان العرض مشفرًا:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محميًا للكتابة**

تتيح لك Aspose.Slides التحقق مما إذا كان العرض محميًا للكتابة. لأداء هذه المهمة، يمكنك استخدام خاصية [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--)، التي تعيد `true` إذا كان العرض محميًا للكتابة أو `false` إذا لم يكن العرض محميًا للكتابة. 

يوضح هذا الكود النموذجي كيفية التحقق مما إذا كان العرض محميًا للكتابة:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق أو التأكد من أن كلمة مرور معينة تم استخدامها لحماية عرض**

قد ترغب في التحقق والتأكد من أن كلمة مرور معينة تم استخدامها لحماية مستند العرض. تقدم Aspose.Slides الوسائل لك للتحقق من كلمة المرور. 

يوضح هذا الكود النموذجي كيفية التحقق من كلمة مرور:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // تحقق مما إذا كانت "pass" تتطابق مع
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

تعيد `true` إذا تم تشفير العرض باستخدام كلمة المرور المحددة. بخلاف ذلك، ستعيد `false`. 

{{% alert color="primary" title="اطلع أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}