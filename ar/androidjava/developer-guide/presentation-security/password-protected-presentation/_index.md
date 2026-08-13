---
title: تأمين العروض التقديمية بكلمات مرور على Android
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/androidjava/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل العرض التقديمي
- فتح قفل PowerPoint
- فتح قفل العرض التقديمي
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
description: "قفل وفك قفل عروض PowerPoint وOpenDocument المحمية بكلمة مرور بسهولة باستخدام Aspose.Slides لنظام Android عبر Java. احمِ عروضك التقديمية."
---
## **المقدمة**

عند حماية عرض تقديمي بكلمة مرور، يعني ذلك أنك تحدد كلمة مرور تفرض قيودًا معينة على العرض. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتَبر العرض المحمي بكلمة مرور عرضًا مقفلًا.

عادةً ما يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من تعديل العرض، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ أي شيء في العرض (إلا إذا قدموا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، يستطيع المستخدم الوصول إلى المستند وفتحته. في وضع القراءة فقط، يمكن للمستخدم مشاهدة المحتوى أو العناصر—الروابط التشعبية، الرسوم المتحركة، التأثيرات، وغيرها—داخل العرض، لكنه لا يستطيع نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من فتح العرض، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتوى العرض (إلا إذا قدموا كلمة المرور).

  تقنيًا، قيد الفتح يمنع أيضًا المستخدمين من تعديل العروض: عندما لا يستطيع الأشخاص فتح عرض، لا يستطيعون تعديل أو إجراء تغييرات عليه.

  **ملاحظة** أنه عندما تحمي عرضًا تقديميًا بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **حماية كلمة المرور للعروض التقديمية في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض التقديمية بالصيغة التالية:

- PPTX و PPT - Microsoft PowerPoint Presentation  
- ODP - OpenDocument Presentation  
- OTP - OpenDocument Presentation Template  

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور للعروض التقديمية لمنع التعديلات بالطرق التالية:

- تشفير العرض التقديمي  
- وضع حماية كتابة للعرض التقديمي  

**عمليات أخرى**

يتيح لك Aspose.Slides تنفيذ مهام أخرى تتعلق بحماية كلمة المرور والتشفير بالطرق التالية:

- فك تشفير عرض تقديمي؛ فتح عرض مشفر  
- إزالة التشفير؛ تعطيل حماية كلمة المرور  
- إزالة حماية الكتابة من عرض تقديمي  
- الحصول على خصائص عرض مشفر  
- التحقق مما إذا كان العرض مشفرًا  
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض تقديمي**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. بعد ذلك، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض تقديمي بكلمة مرور، عليك استخدام طريقة `encrypt` من [IProtectionManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager) لتعيين كلمة مرور للعرض. تمرّر كلمة المرور إلى طريقة `encrypt` وتستخدم طريقة `save` لحفظ العرض المشفر الآن.

يظهر هذا المثال البرمجي كيفية تشفير عرض تقديمي:

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

## **وضع حماية كتابة على عرض تقديمي**

يمكنك إضافة علامة “عدم التعديل” إلى عرض تقديمي. بهذه الطريقة، تُخبر المستخدمين بأنك لا تريدهم أن يجريوا تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، إذا رغب المستخدمون—فعليًا—في ذلك، يمكنهم تعديل العرض، لكن لحفظ التغييرات سيتعين عليهم إنشاء عرض باسم مختلف.

لوضع حماية كتابة، عليك استخدام طريقة [setWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). يوضح هذا المثال البرمجي كيفية وضع حماية كتابة على عرض تقديمي:

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

## **تحميل عرض مشفر**

يسمح لك Aspose.Slides بتحميل عرض مشفر عن طريق تمرير كلمة المرور الصحيحة عبر [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/).

يظهر هذا المثال البرمجي كيفية فتح عرض مشفر:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض المفك تشفيره
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض تقديمي. بهذه الطريقة، يصبح المستخدمون قادرين على الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . يوضح هذا المثال البرمجي كيفية إزالة التشفير من عرض تقديمي:

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

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض تقديمي. بهذه الطريقة، يستطيع المستخدمون تعديل ما يشاؤون دون أي تحذيرات عند تنفيذ هذه المهام.

لإزالة حماية الكتابة من عرض تقديمي، استخدم طريقة [removeWriteProtection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . يوضح هذا المثال البرمجي كيفية إزالة حماية الكتابة من عرض تقديمي:

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

## **الحصول على خصائص عرض مشفر**

عادةً ما يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعروض تقديمية مشفرة أو محمية بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تسمح لك بحماية عرض تقديمي بكلمة مرور مع الحفاظ على إمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يقوم Aspose.Slides بتشفير عرض تقديمي، تكون خصائص مستند العرض محمية أيضًا بكلمة مرور. إذا كنت بحاجة لجعل خصائص المستند متاحة حتى بعد التشفير، يتيح لك Aspose.Slides القيام بذلك بدقة.

إذا كنت تريد أن يظل بإمكان المستخدمين الوصول إلى خصائص عرض مشفر، مرّر `false` إلى [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). يوضح هذا المثال البرمجي كيفية تشفير عرض تقديمي مع الحفاظ على إتاحة خصائص المستند للمستخدمين:

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

## **تحميل خصائص المستند فقط من عرض مشفر**

لمعالجة البيانات التعريفية لعرض مشفر دون تحميل الشرائح أو المحتوى الآخر، أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/) ومرّر `true` إلى [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمّل فقط خصائص المستند المتاحة علنًا.

تقرأ مثال الشيفرة التالي الخصائص المدمجة والمخصصة للمستند عبر [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

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

يعمل هذا التدفق فقط عندما تُترك خصائص المستند غير مشفرة (عامّة) عند تشفير العرض. إذا كانت خصائص المستند مشفرة، فإن تمرير `true` إلى `loadOptions.setOnlyLoadDocumentProperties` سيسبب استثناءً لأن كلمة المرور تُهمل في هذا الوضع. للوصول إلى خصائص المستند المشفرة أو تحميل العرض بالكامل، بما في ذلك الشرائح والمحتوى الآخر، قدّم كلمة المرور الصحيحة عبر [ILoadOptions.setPassword](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق والتأكد من أن العرض لم يُحمَ بحماية كلمة مرور. بهذه الطريقة، تتجنّب الأخطاء والمشكلات المشابهة التي تظهر عندما يتم تحميل عرض محمي بكلمة مرور دون كلمة المرور الخاصة به.

يظهر هذا الكود في Java كيفية فحص عرض لتحديد ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **التحقق مما إذا كان العرض مشفّرًا**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض مشفّرًا. للقيام بهذه المهمة، يمكنك استخدام خاصية [isEncrypted](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) التي تُرجع `true` إذا كان العرض مشفّرًا أو `false` إذا لم يكن مشفّرًا.

يظهر هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفّرًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض محميًا من الكتابة. للقيام بهذه المهمة، يمكنك استخدام خاصية [isWriteProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) التي تُرجع `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

يظهر هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **التحقق أو التأكيد على أن كلمة مرور معينة تم استخدامها**

قد ترغب في التحقق والتأكد من أن كلمة مرور معينة قد استُخدمت لحماية مستند عرض تقديمي. يوفر Aspose.Slides الوسيلة لك لتأكيد كلمة المرور.

يظهر هذا المثال البرمجي كيفية التحقق من كلمة مرور:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // تحقق إذا كان "pass" متطابقًا مع
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

يرجع `true` إذا كان العرض محميًا من الكتابة بالكلمة المرور المحددة. وإلا، يرجع `false`.

{{% alert color="info" title="See also" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هي طرق التشفير المدعومة من Aspose.Slides؟**

يدعم Aspose.Slides طرق تشفير حديثة، بما في ذلك الخوارزميات المستندة إلى AES، مما يضمن مستوى عاليًا من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يُلقى استثناء إذا استُخدمت كلمة مرور غير صحيحة، مما يُنبهك إلى رفض الوصول إلى العرض. يساعد ذلك في منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تأثير على الأداء عند العمل مع عروض تقديمية محمية بكلمة مرور؟**

قد تُضيف عمليات التشفير وفك التشفير بعض الحمل الإضافي أثناء فتح وحفظ العروض. في معظم الحالات، يكون هذا التأثير ضئيلًا ولا يؤثر بشكل ملحوظ على الوقت الإجمالي لمعالجة مهام العرض.