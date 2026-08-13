---
title: تأمين العروض التقديمية بكلمات المرور في Java
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
- Java
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل العروض التقديمية المحمية بكلمة مرور في PowerPoint وOpenDocument بسهولة باستخدام Aspose.Slides للـ Java. احمِ عروضك التقديمية."
---
## **المقدمة**

عندما تقوم بحماية عرض تقديمي بكلمة مرور، فهذا يعني أنك تحدد كلمة مرور تفرض قيودًا معينة على العرض. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتَبَر العرض التقديمي المحمي بكلمة مرور عرضًا مؤمّنًا.

عادةً، يمكنك تعيين كلمة مرور لتطبيق هذه القيود على العرض التقديمي:

- **تعديل**

إذا كنت تريد أن يتم تعديل عرضك التقديمي فقط من قبل مستخدمين محددين، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ العناصر في العرض ما لم يقدموا كلمة المرور.

ومع ذلك، حتى بدون كلمة المرور، سيظل المستخدم قادرًا على الوصول إلى وثيقتك وفتحها. في وضع القراءة فقط، يمكن للمستخدم عرض المحتوى—including الروابط التشعبية، الرسوم المتحركة، التأثيرات والعناصر الأخرى—داخل العرض، لكنه لا يستطيع نسخ العناصر أو حفظ العرض.

- **فتح**

إذا كنت تريد أن يتم فتح عرضك التقديمي فقط من قبل مستخدمين محددين، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتويات العرض ما لم يقدموا كلمة المرور.

من الناحية التقنية، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضهم—إذا لم يتمكن الأشخاص من فتح العرض، فلا يمكنهم تعديل أو إجراء تغييرات عليه.

**ملاحظة:** عندما تقوم بحماية عرض تقديمي بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **حماية كلمة المرور في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض التقديمية بالصيغات التالية:

- PPTX و PPT - عرض Microsoft PowerPoint  
- ODP - عرض OpenDocument  
- OTP - قالب عرض OpenDocument  

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور على العروض التقديمية لمنع التعديلات بهذه الطرق:

- تشفير عرض تقديمي  
- تعيين حماية كتابة للعرض التقديمي  

**عمليات أخرى**

يتيح لك Aspose.Slides تنفيذ مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض تقديمي؛ فتح عرض تم تشفيره  
- إزالة التشفير؛ تعطيل حماية كلمة المرور  
- إزالة حماية الكتابة من عرض تقديمي  
- الحصول على خصائص عرض تقديمي مشفر  
- التحقق مما إذا كان العرض مشفرًا  
- التحقق مما إذا كان العرض محميًا بكلمة مرور.  

## **حماية عرض تقديمي بكلمة مرور**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المؤمّن، يتوجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض تقديمي بكلمة مرور، يجب عليك استخدام طريقة `encrypt` (من [IProtectionManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager)) لتعيين كلمة مرور للعرض. تقوم بتمرير كلمة المرور إلى طريقة `encrypt` وتستخدم طريقة `save` لحفظ العرض المشفر الآن.

يوضح لك هذا المثال البرمجي كيفية تشفير عرض تقديمي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تعيين حماية كتابة للعرض التقديمي**

يمكنك إضافة علامة “لا تعدل” إلى عرض تقديمي. بهذه الطريقة، تخبر المستخدمين أنك لا تريدهم أن يجريوا تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تقوم بتشفير العرض. لذلك، يمكن للمستخدمين—إذا أرادوا حقًا—تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف.

لتعيين حماية كتابة، يجب عليك استخدام طريقة [setWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . يوضح لك هذا المثال البرمجي كيفية تعيين حماية كتابة لعرض تقديمي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تحميل عرض تقديمي مشفر**

يتيح لك Aspose.Slides تحميل عرض تقديمي مشفر بتمرير كلمة المرور الصحيحة عبر [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/).

يوضح لك هذا المثال البرمجي كيفية تحميل عرض تقديمي مشفر:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض غير المشفر
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

يمكنك إزالة التشفير أو حماية كلمة المرور عن عرض تقديمي. بهذه الطريقة يصبح المستخدمون قادرين على الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، يجب عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#removeEncryption--) . يوضح لك هذا المثال البرمجي كيفية إزالة التشفير من عرض تقديمي:

```java
import com.aspose.slides.*;

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

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض تقديمي. بهذه الطريقة يصبح للمستخدمين حرية التعديل دون أي تحذيرات عند قيامهم بهذه المهام.

يمكنك إزالة حماية الكتابة من عرض تقديمي باستخدام طريقة [removeWriteProtection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . يوضح لك هذا المثال البرمجي كيفية إزالة حماية الكتابة من عرض تقديمي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **الحصول على خصائص عرض تقديمي مشفر**

عادةً ما يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعرض تقديمي مشفر أو محمي بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تسمح لك بحماية العرض بكلمة مرور مع الاحتفاظ بإمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** افتراضيًا، عندما يقوم Aspose.Slides بتشفير عرض تقديمي، تكون خصائص مستند العرض محمية أيضًا بكلمة مرور. إذا كنت تحتاج إلى جعل خصائص المستند قابلة للوصول حتى بعد التشفير، يسمح لك Aspose.Slides بفعل ذلك بالضبط.

إذا كنت تريد أن يظل بإمكان المستخدمين الوصول إلى خصائص عرض مشفر، مرِّر `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). يوضح لك هذا المثال البرمجي كيفية تشفير عرض تقديمي مع الإبقاء على وصول المستخدمين إلى خصائص المستند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تحميل خصائص المستند فقط من عرض تقديمي مشفر**

لتفحص بيانات التعريف لعرض مشفر دون تحميل شرائحه أو محتوياته الأخرى، أنشئ كائنًا من فئة [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/) ومرّر `true` إلى [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمل فقط الخصائص العامة للمستند المتاحة للجمهور.

يقوم المثال البرمجي التالي بقراءة الخصائص المدمجة والمخصصة للمستند عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

يعمل هذا التدفق فقط عندما تُركت خصائص المستند غير مشفرة (عامة) عند تشفير العرض. إذا كانت خصائص المستند مشفَّرة، فإن تمرير `true` إلى `loadOptions.setOnlyLoadDocumentProperties` سيسبب استثناءً لأن كلمة المرور تُتجاهل في هذا الوضع. للوصول إلى خصائص المستند المشفَّرة أو تحميل العرض كاملًا، بما في ذلك الشرائح ومحتوياته الأخرى، قدم كلمة المرور الصحيحة عبر [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق والتأكيد أن العرض غير محمي بكلمة مرور. بهذه الطريقة، تتجنب الأخطاء والمشكلات المماثلة التي تحدث عند تحميل عرض محمي بكلمة مرور دون توفر كلمة المرور.

يظهر لك هذا الكود بلغة Java كيفية فحص عرض لمعرفة ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **التحقق مما إذا كان العرض مشفرًا**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض مشفرًا. للقيام بذلك، يمكنك استخدام الخاصية [isEncrypted](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#isEncrypted--) التي تُعيد `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن مشفرًا.

يوضح لك هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفرًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محمى من الكتابة**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض محميًا من الكتابة. للقيام بذلك، يمكنك استخدام الخاصية [isWriteProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IProtectionManager#isWriteProtected--) التي تُعيد `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

يوضح لك هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق أو التأكيد على استخدام كلمة مرور محددة**

قد ترغب في التحقق والتأكيد أن كلمة مرور معينة قد استُخدمت لحماية مستند العرض. يوفر Aspose.Slides الوسيلة لك للتحقق من صحة كلمة المرور.

يظهر لك هذا المثال البرمجي كيفية التحقق من كلمة مرور:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // تحقق مما إذا كانت كلمة المرور متطابقة
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

إنه يُعيد `true` إذا كان العرض محميًا من الكتابة باستخدام كلمة المرور المحددة. وإلا، يُعيد `false`.

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ar/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتداولة**

**ما هي طرق التشفير المدعومة من قبل Aspose.Slides؟**

يدعم Aspose.Slides طرق تشفير حديثة، بما في ذلك الخوارزميات القائمة على AES، مما يضمن مستوى عالٍ من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إلقاء استثناء إذا تم استخدام كلمة مرور غير صحيحة، مما يُنبهك إلى أن الوصول إلى العرض مرفوض. يساعد ذلك في منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تأثيرات على الأداء عند التعامل مع عروض تقديمية محمية بكلمة مرور؟**

قد يضيف عملية التشفير وفك التشفير بعض العبء البسيط أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون تأثير الأداء ضئيلاً ولا يؤثر بشكل ملحوظ على الوقت الإجمالي لمعالجة مهام العرض.