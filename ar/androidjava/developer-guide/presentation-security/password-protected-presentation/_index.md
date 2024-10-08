---
title: تقديم محمي بكلمة مرور
type: docs
weight: 20
url: /ar/androidjava/password-protected-presentation/
keywords: "قفل عرض PowerPoint في جافا"
description: "قفل عرض PowerPoint. عرض PowerPoint محمي بكلمة مرور في جافا"
---

## **حول حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للعرض؟**
عندما تقوم بحماية عرض بكلمة مرور، فهذا يعني أنك تحدد كلمة مرور تفرض قيوداً معينة على العرض. لإزالة القيود، يجب إدخال كلمة المرور. يعتبر العرض المحمي بكلمة مرور عرضاً مقفلاً.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت ترغب في السماح لمستخدمين معينين فقط بتعديل عرضك، يمكنك تعيين قيد تعديل. هنا يمنع القيد الأشخاص من تعديل أو تغيير أو نسخ الأشياء في عرضك (ما لم يقدموا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيكون لدى المستخدم إمكانية الوصول إلى مستندك وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتويات أو الأشياء - الروابط، الرسومات المتحركة، التأثيرات، وغيرها - داخل عرضك، ولكن لا يمكنهم نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت ترغب في السماح لمستخدمين معينين فقط بفتح عرضك، يمكنك تعيين قيد فتح. يمنع القيد هنا الأشخاص من حتى مشاهدة محتويات عرضك (ما لم يقدموا كلمة المرور).

  تقنياً، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك: عندما لا يمكن للناس فتح عرض، لا يمكنهم تعديل أو إجراء تغييرات عليه.

  **ملاحظة** أنه عندما تحمي عرضاً بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفراً.

## **كيفية حماية عرض بكلمة مرور عبر الإنترنت**

1. انتقل إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **سحب أو تحميل الملفات الخاصة بك**.

3. اختر الملف الذي تريد حمايته بكلمة مرور على جهاز الكمبيوتر الخاص بك.

4. أدخل كلمة المرور المفضلة لديك لحماية التحرير؛ أدخل كلمة المرور المفضلة لديك لحماية العرض.

5. إذا كنت ترغب في رؤية المستخدمين لعرضك كنسخة نهائية، حدد خانة **تحديد كنسخة نهائية**.

6. انقر على **احم الآن.**

7. انقر على **قم بالتنزيل الآن.**

## **حماية كلمة المرور للعروض في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض في هذه الصيغ:

- PPTX و PPT - عرض PowerPoint من Microsoft
- ODP - عرض OpenDocument
- OTP - قالب عرض OpenDocument

**العمليات المدعومة**

يسمح لك Aspose.Slides باستخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض
- تعيين حماية كتابة لعرض

**عمليات أخرى**

يسمح لك Aspose.Slides بتنفيذ مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان العرض مشفراً
- التحقق مما إذا كان العرض محمي بكلمة مرور.

## **تشفير عرض**

يمكنك تشفير عرض عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض بكلمة مرور، عليك استخدام طريقة التشفير (من [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)) لتحديد كلمة مرور للعرض. تمرر كلمة المرور إلى طريقة التشفير وتستخدم طريقة الحفظ لحفظ العرض المشفر الآن.

يعرض هذا الكود النموذجي كيفية تشفير عرض:

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

يمكنك إضافة علامة تنص على "لا تعديل" إلى عرض. بهذه الطريقة، تخبر المستخدمين أنك لا ترغب في أن يقوموا بإجراء تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين - إذا كانوا يرغبون في ذلك - تعديل العرض، لكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف.

لتعيين حماية الكتابة، عليك استخدام [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) method. يعرض هذا الكود النموذجي كيفية تعيين حماية الكتابة لعرض:

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

يسمح لك Aspose.Slides بتحميل ملف مشفر عن طريق تمرير كلمته المرور. لفك تشفير عرض، عليك استدعاء [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) method بدون معلمات. ستحتاج بعد ذلك إلى إدخال كلمة المرور الصحيحة لتحميل العرض.

يعرض هذا الكود النموذجي كيفية فك تشفير عرض:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض المفكوك تشفيره
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور على عرض. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، عليك استدعاء [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) method. يعرض هذا الكود النموذجي كيفية إزالة التشفير من عرض:

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

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض. بهذه الطريقة، يتمكن المستخدمون من التعديل كما يريدون - ولا يحصلون على أي تحذيرات عند تنفيذ مثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض عن طريق استخدام [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) method. يعرض هذا الكود النموذجي كيفية إزالة حماية الكتابة من عرض:

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

عادةً ما يعاني المستخدمون من صعوبة الحصول على خصائص الوثيقة لعروض مشفرة أو محمية بكلمة مرور. ومع ذلك، يقدم Aspose.Slides آلية تسمح لك بحماية عرض بكلمة مرور مع الاحتفاظ بوسائل تمكن المستخدمين من الوصول إلى خصائص ذلك العرض.

**ملاحظة** أنه عندما يشفر Aspose.Slides عرضاً، يتم أيضاً حماية خصائص وثيقة العرض بكلمة مرور بشكل افتراضي. ولكن إذا كنت بحاجة إلى جعل خصائص العرض قابلة للوصول (حتى بعد تشفير العرض)، يسمح لك Aspose.Slides بفعل ذلك بالضبط.

إذا كنت تريد من المستخدمين الاحتفاظ بالقدرة على الوصول إلى خصائص عرض قمت بتشفيره، يمكنك تعيين [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) property إلى `true`. يعرض هذا الكود النموذجي كيفية تشفير عرض مع توفير وسائل للمستخدمين للوصول إلى خصائص وثيقته:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان عرض محمي بكلمة مرور قبل تحميله**

قبل تحميل عرض، قد ترغب في التحقق والتأكيد أنه لم يتم حماية العرض بكلمة مرور. بهذه الطريقة، يمكنك تجنب الأخطاء والقضايا المماثلة، التي تحدث عندما يتم تحميل عرض محمي بكلمة مرور بدون كلمته المرور.

يوضح هذا الكود java كيفية فحص عرض لرؤية ما إذا كان محمي بكلمة مرور (دون تحميل العرض نفسه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("العرض محمي بكلمة مرور: " + presentationInfo.isPasswordProtected());
```

## **التحقق مما إذا كان عرض مشفراً**

يسمح لك Aspose.Slides بالتحقق مما إذا كان عرض مشفراً. لأداء هذه المهمة، يمكنك استخدام [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) property، والذي يعيد `true` إذا كان العرض مشفراً أو `false` إذا لم يكن العرض مشفراً.

يعرض هذا الكود النموذجي كيفية التحقق مما إذا كان عرض مشفراً:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان عرض محمي بالكتابة**

يسمح لك Aspose.Slides بالتحقق مما إذا كان عرض محمي بالكتابة. لأداء هذه المهمة، يمكنك استخدام [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) property، والذي يعيد `true` إذا كان العرض مشفراً أو `false` إذا لم يكن العرض مشفراً.

يعرض هذا الكود النموذجي كيفية التحقق مما إذا كان عرض محمي بالكتابة:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق أو تأكيد أن كلمة مرور معينة تم استخدامها لحماية عرض**

قد ترغب في التحقق والتأكيد أن كلمة مرور معينة قد تم استخدامها لحماية وثيقة عرض. يوفر Aspose.Slides الوسائل لك للتحقق من كلمة المرور.

يعرض هذا الكود النموذجي كيفية التحقق من كلمة مرور:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // التحقق مما إذا كانت "pass" تتطابق
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

يعود `true` إذا كان العرض قد تم تشفيره بكلمة المرور المحددة. خلاف ذلك، يعود `false`.

{{% alert color="primary" title="راجع أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}