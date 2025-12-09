---
title: عرض تقديمي محمي بكلمة مرور
type: docs
weight: 20
url: /ar/nodejs-java/password-protected-presentation/
keywords: "قفل عرض PowerPoint في JavaScript"
description: "قفل عرض PowerPoint. عرض PowerPoint محمي بكلمة مرور في JavaScript"
---

## **حول حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للعرض التقديمي؟**
عند حماية عرض تقديمي بكلمة مرور، يعني ذلك أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمي بكلمة مرور عرضًا مقفلًا.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من تعديل عرضك التقديمي، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ محتوى العرض (ما لم يقدموا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيتمكن المستخدم من الوصول إلى مستندك وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتويات أو العناصر—مثل الروابط، والرسوم المتحركة، والمؤثرات، وغيرها— داخل عرضك التقديمي، لكنه لا يستطيع نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من فتح عرضك التقديمي، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتويات العرض (ما لم يقدموا كلمة المرور).

  تقنياً، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك: عندما لا يستطيع الأشخاص فتح العرض، لا يمكنهم إجراء تعديلات أو تغييرات عليه.  

  **ملاحظة** أنه عندما تحمِِّي عرضًا تقديميًا بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **كيفية حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. اذهب إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) الخاصة بنا. 

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **اسحب أو حمّل ملفاتك**.

3. اختر الملف الذي تريد حمايته بكلمة مرور على جهاز الكمبيوتر الخاص بك. 

4. أدخل كلمة المرور المفضلة لديك لحماية التعديل؛ أدخل كلمة المرور المفضلة لديك لحماية العرض. 

5. إذا كنت تريد أن يرى المستخدمون عرضك كنسخة نهائية، ضع علامة على خانة **Mark as final**.

6. انقر على **PROTECT NOW.** 

7. انقر على **DOWNLOAD NOW.**

## **حماية كلمة المرور للعروض التقديمية في Aspose.Slides**
**الصيغ المدعومة**

Aspose.Slides يدعم حماية كلمة المرور، التشفير، وغيرها من العمليات للعروض التقديمية بالصيغات التالية: 

- PPTX و PPT - عرض Microsoft PowerPoint 
- ODP - عرض OpenDocument 
- OTP - قالب عرض OpenDocument 

**العمليات المدعومة**

Aspose.Slides يتيح لك استخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض تقديمي
- تعيين حماية كتابة للعرض

**عمليات أخرى**

Aspose.Slides يسمح لك بأداء مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض تقديمي؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من العرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض تقديمي**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور. 

لتشفير أو حماية عرض تقديمي بكلمة مرور، عليك استخدام طريقة encrypt (من [ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager)) لتعيين كلمة مرور للعرض. تمرر كلمة المرور إلى طريقة encrypt وتستخدم طريقة save لحفظ العرض المشفر الآن.

يظهر لك هذا المثال البرمجي كيفية تشفير عرض تقديمي:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **تعيين حماية كتابة للعرض**

يمكنك إضافة علامة تقول “Do not modify” إلى العرض. بهذه الطريقة، تخبر المستخدمين أنك لا تريدهم أن يجروا تغييرات على العرض.  

**ملاحظة** أن عملية حماية الكتابة لا تقوم بتشفير العرض. لذلك، يمكن للمستخدمين—إذا رغبوا فعلاً—تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف. 

لتعيين حماية كتابة، عليك استخدام طريقة [setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). يوضح لك هذا المثال البرمجي كيفية تعيين حماية كتابة للعرض:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **فك تشفير عرض تقديمي؛ فتح عرض مشفر**

Aspose.Slides يسمح لك بتحميل ملف مشفر عن طريق تمرير كلمة مروره. لفك تشفير عرض تقديمي، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) دون أي معاملات. ثم سيتعين عليك إدخال كلمة المرور الصحيحة لتحميل العرض.

يوضح لك هذا المثال البرمجي كيفية فك تشفير عرض تقديمي:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // العمل مع العرض المفكوك
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور على عرض تقديمي. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، عليك استدعاء طريقة [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). يوضح لك هذا المثال البرمجي كيفية إزالة التشفير من عرض تقديمي:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **إزالة حماية الكتابة من عرض تقديمي**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة في ملف عرض تقديمي. بهذه الطريقة، يستطيع المستخدمون تعديل العرض كما يشاؤون—دون أي تحذير عند تنفيذ هذه المهام.

يمكنك إزالة حماية الكتابة من عرض تقديمي باستخدام طريقة [removeWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). يوضح لك هذا المثال البرمجي كيفية إزالة حماية الكتابة من عرض تقديمي:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **الحصول على خصائص عرض مشفر**

عادةً، يواجه المستخدمون صعوبة في الحصول على خصائص المستند لعروض مشفرة أو محمية بكلمة مرور. ومع ذلك، يقدم Aspose.Slides آلية تسمح لك بحماية عرض تقديمي بكلمة مرور مع الحفاظ على إمكانية وصول المستخدمين إلى خصائص ذلك العرض.

**ملاحظة** عندما يقوم Aspose.Slides بتشفير عرض تقديمي، يتم حماية خصائص مستند العرض أيضًا بكلمة مرور بشكل افتراضي. ولكن إذا كنت بحاجة إلى جعل خصائص العرض متاحة (حتى بعد تشفير العرض)، يتيح لك Aspose.Slides القيام بذلك تمامًا.

إذا كنت تريد أن يحتفظ المستخدمون بالقدرة على الوصول إلى خصائص عرض قمت بتشفيره، يمكنك تعيين الخاصية [encryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) إلى `true`. يوضح لك هذا المثال البرمجي كيفية تشفير عرض تقديمي مع تمكين المستخدمين من الوصول إلى خصائص المستند الخاصة به:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله**

قبل تحميل عرض تقديمي، قد ترغب في التحقق والتأكد من أن العرض لم يُحمى بكلمة مرور. بهذه الطريقة، يمكنك تجنب الأخطاء والمشاكل المشابهة التي تحدث عندما يتم تحميل عرض محمي بكلمة مرور دون كلمة المرور.

يوضح لك هذا الكود JavaScript كيفية فحص عرض تقديمي لمعرفة ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **التحقق مما إذا كان العرض مشفرًا**

Aspose.Slides يتيح لك التحقق مما إذا كان العرض مشفرًا. للقيام بذلك، يمكنك استخدام الخاصية [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) التي تُعيد `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن مشفرًا.

يظهر لك هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفرًا:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **التحقق مما إذا كان العرض محميًا من الكتابة**

Aspose.Slides يتيح لك التحقق مما إذا كان العرض محميًا من الكتابة. للقيام بذلك، يمكنك استخدام الخاصية [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) التي تُعيد `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن محميًا.

يوضح لك هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **التحقق أو التأكد من أن كلمة مرور محددة قد استُخدمت لحماية عرض تقديمي**

قد ترغب في التحقق والتأكد من أن كلمة مرور محددة قد استُخدمت لحماية مستند عرض تقديمي. يوفر لك Aspose.Slides الوسيلة للتحقق من صحة كلمة المرور.  

يوضح لك هذا المثال البرمجي كيفية التحقق من صحة كلمة المرور:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // تحقق مما إذا كانت كلمة المرور "pass" مطابقة
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


يُعيد `true` إذا تم تشفير العرض باستخدام كلمة المرور المحددة. وإلا، يُعيد `false`. 

{{% alert color="primary" title="انظر أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هي طرق التشفير التي يدعمها Aspose.Slides؟**

Aspose.Slides يدعم طرق تشفير حديثة، بما في ذلك الخوارزميات القائمة على AES، مما يضمن مستوى عالٍ من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إلقاء استثناء إذا تم استخدام كلمة مرور غير صحيحة، مما يُنبهك بأن الوصول إلى العرض مرفوض. يساعد ذلك في منع الوصول غير المصرح به ويحمي محتوى العرض.

**هل هناك أي تأثير على الأداء عند العمل مع عروض محمية بكلمة مرور؟**

قد يؤدي عملية التشفير وفك التشفير إلى إحداث تحميل طفيف أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون لهذا التأثير على الأداء حدٌ ضئيل ولا يؤثر بشكل كبير على الوقت الإجمالي لمعالجة مهام العرض التقديمي.