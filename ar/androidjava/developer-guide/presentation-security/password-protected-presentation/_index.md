---
title: العروض التقديمية الآمنة بكلمات مرور على Android
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/androidjava/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل العرض التقديمي
- فتح قفل PowerPoint
- فتح القفل عن العرض التقديمي
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
- Android
- Java
- Aspose.Slides
description: "قفل وفتح العروض التقديمية المحمية بكلمة مرور من نوع PowerPoint وOpenDocument بسهولة باستخدام Aspose.Slides للأندرويد عبر Java. احمِ عروضك التقديمية."
---
## **المقدمة**

عند حماية عرض تقديمي بكلمة مرور، يعني ذلك أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض التقديمي. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُنظر إلى العرض التقديمي المحمَّى بكلمة مرور على أنه عرض مؤمن.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض التقديمي:

- **التعديل**

  إذا كنت تريد أن يتمكن فقط بعض المستخدمين من تعديل عرضك التقديمي، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ أي شيء في عرضك التقديمي (إلا إذا قدموا كلمة المرور). 

  مع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيتمكن المستخدم من الوصول إلى المستند وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتوى أو العناصر—الروابط التشعبية، الرسوم المتحركة، التأثيرات، وغيرها—داخل عرضك التقديمي، لكنه لا يمكنه نسخ العناصر أو حفظ العرض. 

- **الفتح**

  إذا كنت تريد أن يتمكن فقط بعض المستخدمين من فتح عرضك التقديمي، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتوى عرضك التقديمي (إلا إذا قدموا كلمة المرور).

  من الناحية التقنية، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك التقديمية: عندما لا يتمكن الأشخاص من فتح العرض، لا يمكنهم تعديل أو إجراء تغييرات عليه. 
  
  **ملاحظة** أنه عند حماية عرض تقديمي بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **حماية كلمة المرور للعروض التقديمية في Aspose.Slides**
**الصيغ المدعومة**

Aspose.Slides يدعم حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض التقديمية بهذه الصيغ: 

- PPTX و PPT - عرض Microsoft PowerPoint 
- ODP - عرض OpenDocument 
- OTP - قالب عرض OpenDocument 

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور على العروض التقديمية لمنع التعديلات بهذه الطرق:

- تشفير عرض تقديمي
- تعيين حماية كتابة للعرض التقديمي

**عمليات أخرى**

يتيح لك Aspose.Slides تنفيذ مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض تقديمي؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض تقديمي
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض تقديمي**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المؤمن، يجب على المستخدم تقديم كلمة المرور. 

لتشفير أو حماية عرض تقديمي بكلمة مرور، عليك استخدام طريقة encrypt (from [IProtectionManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager)) لتعيين كلمة مرور للعرض. تمرر كلمة المرور إلى طريقة encrypt وتستخدم طريقة save لحفظ العرض المشفر الآن.

هذا المثال يوضح لك كيفية تشفير عرض تقديمي:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تعيين حماية كتابة للعرض التقديمي**

يمكنك إضافة علامة تقول “عدم التعديل” إلى عرض تقديمي. بهذه الطريقة، تخبر المستخدمين أنك لا تريدهم إجراء تغييرات على العرض.  

**ملاحظة** أن عملية حماية الكتابة لا تقوم بتشفير العرض. لذلك، يمكن للمستخدمين—إذا أرادوا فعلًا—تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف. 

لتعيين حماية كتابة، عليك استخدام طريقة [setWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . هذا المثال يوضح لك كيفية تعيين حماية كتابة للعرض التقديمي:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تحميل عرض مشفر**

يتيح لك Aspose.Slides تحميل ملف مشفر بتمرير كلمة مروره. لفك تشفير عرض تقديمي، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) بدون أي معلمات. ثم سيتعين عليك إدخال كلمة المرور الصحيحة لتحميل العرض.

هذا المثال يوضح لك كيفية فك تشفير عرض تقديمي: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض الذي تم فك تشفيره
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض تقديمي. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود. 

لإزالة التشفير أو حماية كلمة المرور، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . هذا المثال يوضح لك كيفية إزالة التشفير من عرض تقديمي:

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

## **إزالة حماية الكتابة من عرض تقديمي**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف العرض التقديمي. بهذه الطريقة، يمكن للمستخدمين تعديل ما يشاؤون—ولا يحصلون على أي تحذيرات عند تنفيذ هذه المهام.

يمكنك إزالة حماية الكتابة من عرض تقديمي باستخدام طريقة [removeWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . هذا المثال يوضح لك كيفية إزالة حماية الكتابة من عرض تقديمي:

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

عادةً، يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعرض مشفر أو محمي بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تتيح لك حماية عرض تقديمي بكلمة مرور مع الحفاظ على إمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يقوم Aspose.Slides بتشفير عرض تقديمي، تكون خصائص مستند العرض محمية أيضًا بكلمة مرور. إذا كنت بحاجة لجعل خصائص المستند متاحة حتى بعد التشفير، يتيح لك Aspose.Slides القيام بذلك.

إذا أردت أن يحتفظ المستخدمون بقدرتهم على الوصول إلى خصائص عرض مشفر، مرر القيمة `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). هذا المثال يوضح لك كيفية تشفير عرض تقديمي مع الاستمرار في تمكين المستخدمين من الوصول إلى خصائص مستنده:

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

## **تحميل خصائص المستند فقط من عرض مشفر**

لفحص بيانات التعريف لعرض مشفر دون تحميل شرائحه أو محتوياته الأخرى، أنشئ كائنًا من النوع [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/) ومرّر القيمة `true` إلى [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمل فقط خصائص المستند المتاحة علنًا.

يعرض المثال التالي كيفية قراءة خصائص المستند المدمجة والمخصصة عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

يعمل هذا التدفق فقط عندما تُترك خصائص المستند غير مُشفرة (عامة) عند تشفير العرض. إذا كانت خصائص المستند مُشفرة، فإن تمرير القيمة `true` إلى `loadOptions.setOnlyLoadDocumentProperties` يتسبب في استثناء لأن كلمة المرور تُهمل في هذا الوضع. للوصول إلى خصائص المستند المشفرة أو تحميل العرض بالكامل، بما في ذلك شرائحه ومحتوياته الأخرى، قدّم كلمة المرور الصحيحة عبر [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق والتأكد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، تتجنب الأخطاء والمشكلات المماثلة التي تظهر عندما يتم تحميل عرض محمي بكلمة مرور دون كلمة المرور.

هذا الكود Java يوضح لك كيفية فحص عرض تقديمي لمعرفة ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **التحقق مما إذا كان العرض مشفرًا**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض مشفرًا. لأداء هذه المهمة، يمكنك استخدام الخاصية [isEncrypted](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) التي تُعيد القيمة `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن مشفرًا.

هذا المثال يوضح لك كيفية التحقق مما إذا كان العرض مشفرًا:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض محميًا من الكتابة. لأداء هذه المهمة، يمكنك استخدام الخاصية [isWriteProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) التي تُعيد القيمة `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

هذا المثال يوضح لك كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق أو التأكيد على أن كلمة مرور معينة قد استُخدمت**

قد ترغب في التحقق والتأكيد على أن كلمة مرور معينة قد استُخدمت لحماية مستند العرض التقديمي. يوفر لك Aspose.Slides الوسيلة للتحقق من صحة كلمة المرور. 

هذا المثال يوضح لك كيفية التحقق من صحة كلمة المرور:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // التحقق مما إذا كانت "pass" مطابقة
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

تُعيد القيمة `true` إذا تم تشفير العرض باستخدام كلمة المرور المحددة. وإلا، تُعيد القيمة `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ar/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتداولة**

**ما هي طرق التشفير المدعومة من قبل Aspose.Slides؟**

يدعم Aspose.Slides طرق تشفير حديثة، بما في ذلك خوارزميات مبنية على AES، مما يضمن مستوى عاليًا من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إلقاء استثناء إذا تم استخدام كلمة مرور غير صحيحة، ما ينبهك إلى رفض الوصول إلى العرض. يساعد ذلك في منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تبعات على الأداء عند التعامل مع عروض محمية بكلمة مرور؟**

قد يضيف عمليتا التشفير وفك التشفير بعض العبء الطفيف أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون تأثير الأداء ضئيلًا ولا يؤثر بشكل كبير على الوقت الإجمالي لمعالجة مهام العرض التقديمي.