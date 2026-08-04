---
title: تأمين العروض التقديمية باستخدام كلمات المرور في جافا
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/java/password-protected-presentation/
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
- حماية الكتابة
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
- Java
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل عروض PowerPoint وOpenDocument المحمية بكلمة مرور بسهولة باستخدام Aspose.Slides للغة Java. احمِ عروضك التقديمية."
---
## **المقدمة**

عند حماية عرض تقديمي بكلمة مرور، يعني ذلك أنك تقوم بتعيين كلمة مرور تفرض قيوداً معينة على العرض. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمّى بكلمة مرور عرضاً مقفلاً.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد أن يتمكن مستخدمون معينون فقط من تعديل عرضك، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ العناصر في العرض ما لم يقدموا كلمة المرور.

  ومع ذلك، حتى بدون كلمة المرور، سيظل المستخدم قادرًا على الوصول إلى المستند وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتوى—بما في ذلك الروابط التشعبية، والرسوم المتحركة، والتأثيرات، والعناصر الأخرى—داخل العرض، لكنه لا يستطيع نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد أن يتمكن مستخدمون معينون فقط من فتح عرضك، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتويات العرض ما لم يقدموا كلمة المرور.

  تقنيًا، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك—إذا لم يتمكن الأشخاص من فتح العرض، فلا يمكنهم تعديله أو إجراء تغييرات عليه.

**ملاحظة:** عندما تحمي عرضًا تقديميًا بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفّراً.

## **حماية كلمة المرور في Aspose.Slides**
**التنسيقات المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، والتشفير، والعمليات المشابهة للعروض بالتنسيقات التالية:

- PPTX و PPT - عرض Microsoft PowerPoint
- ODP - عرض OpenDocument
- OTP - قالب عرض OpenDocument

**العمليات المدعومة**

يسمح Aspose.Slides باستخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض تقديمي
- تعيين حماية كتابة للعرض

**عمليات أخرى**

يسمح Aspose.Slides بتنفيذ مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض تقديمي؛ فتح عرض مشفّر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من العرض
- الحصول على خصائص عرض مشفّر
- التحقق مما إذا كان العرض مشفّراً
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **حماية عرض تقديمي بكلمة مرور**

يمكنك تشفير عرض تقديمي بتعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض تقديمي بكلمة مرور، عليك استخدام طريقة **encrypt** (من [IProtectionManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager)) لتعيين كلمة مرور للعرض. تمرّر كلمة المرور إلى طريقة **encrypt** وتستخدم طريقة **save** لحفظ العرض المشفّر الآن.

هذا مثال يوضح كيفية تشفير عرض تقديمي:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تعيين حماية كتابة للعرض**

يمكنك إضافة علامة تقول “لا تقم بالتعديل” إلى العرض. بهذه الطريقة، تخبر المستخدمين أنك لا تريدهم أن يجريوا تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين—إذا أرادوا—تعديل العرض، ولكن لحفظ التغييرات سيحتاجون إلى إنشاء عرض باسم مختلف.

لتعيين حماية كتابة، عليك استخدام طريقة [setWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . هذا المثال يوضح كيفية تعيين حماية كتابة للعرض:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تحميل عرض مشفّر**

يسمح Aspose.Slides بتحميل ملف مشفّر بتمرير كلمة مرورته. لفك تشفير عرض تقديمي، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#removeEncryption--) دون أي معلمات. سيتوجب عليك بعد ذلك إدخال كلمة المرور الصحيحة لتحميل العرض.

هذا المثال يوضح كيفية فك تشفير عرض تقديمي:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع عرض تقديمي مفكك التشفير
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة التشفير من العرض**

يمكنك إزالة التشفير أو حماية كلمة المرور من العرض. بهذه الطريقة يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#removeEncryption--) . هذا المثال يوضح كيفية إزالة التشفير من العرض:

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

## **إزالة حماية الكتابة من العرض**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف العرض. بهذه الطريقة يتمكن المستخدمون من تعديل ما يشاءون دون أي تحذيرات عند تنفيذ هذه المهام.

يمكنك إزالة حماية الكتابة من العرض باستخدام طريقة [removeWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . هذا المثال يوضح كيفية إزالة حماية الكتابة من العرض:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **الحصول على خصائص عرض مشفّر**

عادةً ما يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعروض محمية بكلمة مرور أو مشفّرة. ومع ذلك، يوفر Aspose.Slides آلية تسمح لك بحماية عرض تقديمي بكلمة مرور مع الحفاظ على تمكين المستخدمين من الوصول إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يقوم Aspose.Slides بتشفير عرض تقديمي، تُحمي خصائص مستند العرض أيضًا بكلمة مرور. إذا كنت بحاجة إلى جعل خصائص المستند متاحة حتى بعد التشفير، يتيح لك Aspose.Slides القيام بذلك بدقة.

إذا كنت تريد أن يظل بإمكان المستخدمين الوصول إلى خصائص عرض مشفّر، مرّر `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). هذا المثال يوضح كيفية تشفير عرض تقديمي مع الاستمرار في توفير وصول للمستخدمين إلى خصائص المستند:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تحميل خصائص المستند فقط من عرض مشفّر**

لفحص بيانات التعريف لعروض مشفّرة دون تحميل الشرائح أو المحتوى الآخر، أنشئ كائنًا من نوع [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/) ومرّر `true` إلى [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمل فقط خصائص المستند المتاحة علنًا.

تقرأ الشيفرة التالية خصائص المستند المدمجة والمخصصة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // قراءة خصائص المستند المدمجة.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // قراءة خصائص المستند المخصصة.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

يعمل هذا السيناريو فقط عندما تكون خصائص المستند غير مشفرة (عامة) عند تشفير العرض. إذا كانت خصائص المستند مشفرة، فإن تمرير `true` إلى `loadOptions.setOnlyLoadDocumentProperties` يتسبب في استثناء لأن كلمة المرور تُهمل في هذا الوضع. للوصول إلى خصائص المستند المشفّرة أو لتحميل العرض بالكامل بما في ذلك الشرائح والمحتوى الآخر، قدّم كلمة المرور الصحيحة عبر [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق والتأكد من أن العرض غير محمي بكلمة مرور. بهذه الطريقة تتجنب الأخطاء والمشكلات المماثلة التي تظهر عند تحميل عرض محمي بكلمة مرور دون كلمة المرور الخاصة به.

تظهر الشيفرة التالية في Java كيفية فحص عرض لتحديد ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **التحقق مما إذا كان العرض مشفّراً**

يسمح Aspose.Slides بالتحقق مما إذا كان العرض مشفّراً. للقيام بذلك، يمكنك استخدام خاصية [isEncrypted](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#isEncrypted--) التي تُعيد `true` إذا كان العرض مشفّراً أو `false` إذا لم يكن مشفّراً.

هذا المثال يوضح كيفية التحقق مما إذا كان العرض مشفّراً:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

يسمح Aspose.Slides بالتحقق مما إذا كان العرض محميًا من الكتابة. للقيام بذلك، يمكنك استخدام خاصية [isWriteProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#isWriteProtected--) التي تُعيد `true` إذا كان العرض مشفّراً أو `false` إذا لم يكن مشفّراً.

هذا المثال يوضح كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق أو التأكد من استخدام كلمة مرور محددة**

قد ترغب في التحقق والتأكد من أن كلمة مرور معينة تم استخدامها لحماية مستند العرض. يوفر Aspose.Slides الوسيلة لك لتأكيد صحة كلمة المرور.

هذا المثال يوضح كيفية التحقق من صحة كلمة المرور:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // تحقق مما إذا كان "pass" متطابقًا مع
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

يُعيد `true` إذا كان العرض مشفّراً باستخدام كلمة المرور المحددة. وإلا يُعيد `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ar/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هي طرق التشفير المدعومة من قبل Aspose.Slides؟**

يدعم Aspose.Slides طرق تشفير حديثة، بما في ذلك الخوارزميات القائمة على AES، مما يضمن مستوى عالٍ من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إلقاء استثناء إذا تم استخدام كلمة مرور غير صحيحة، مما يُنبهك إلى أن الوصول إلى العرض مرفوض. يساعد ذلك على منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تأثير على الأداء عند العمل مع عروض محمية بكلمة مرور؟**

قد يضيف عملية التشفير وفك التشفير عبئًا طفيفًا أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون تأثير الأداء محدودًا ولا يؤثر بشكل كبير على الوقت الإجمالي لمعالجة مهام العرض.