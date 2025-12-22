---
title: الترخيص
type: docs
weight: 90
url: /ar/androidjava/licensing/
keywords:
- ترخيص
- ترخيص مؤقت
- تعيين ترخيص
- استخدام ترخيص
- التحقق من الترخيص
- ملف الترخيص
- نسخة تجريبية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق وإدارة واستكشاف أخطاء الترخيص في Aspose.Slides for Android via Java. ضمان وصول غير منقطع إلى جميع المميزات مع دليل الترخيص الخاص بنا."
---

## **تقييم Aspose.Slides**

{{% alert color="primary" %}} 

يمكنك تنزيل نسخة تجريبية من **Aspose.Slides for Android via Java** من صفحة [صفحة التحميل](https://releases.aspose.com/slides/androidjava/). النسخة التجريبية توفر نفس الوظائف كالنسخة المرخصة من المنتج. حزمة التجربة هي نفسها حزمة الشراء. تصبح النسخة التجريبية مرخصة بمجرد إضافة بضع أسطر من الكود إليها (لتطبيق الترخيص).

بمجرد رضاك عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). نوصي بالاطلاع على أنواع الاشتراكات المختلفة. إذا كان لديك أسئلة، تواصل مع فريق مبيعات Aspose.

كل ترخيص Aspose يأتي مع اشتراك سنة واحدة لتحديثات مجانية إلى النسخ الجديدة أو الإصلاحات الصادرة خلال فترة الاشتراك. يحصل المستخدمون الذين يمتلكون منتجات مرخصة (أو حتى النسخ التجريبية) على دعم فني مجاني وغير محدود.

{{% /alert %}} 

**قيود النسخة التجريبية**

* بينما نسخة **Aspose.Slides** التجريبية (بدون ترخيص محدد) توفر كل وظائف المنتج، فإنها تُدرج علامة مائية تجريبية في أعلى المستند عند عمليات الفتح والحفظ. 
* يُسمح لك باستخراج نصوص من شريحة واحدة فقط عند استخراج النصوص من شرائح العرض.

{{% alert color="primary" %}} 

لاختبار Aspose.Slides بدون قيود، يمكنك طلب **رخصة مؤقتة لمدة 30 يوماً**. راجع صفحة [كيفية الحصول على رخصة مؤقتة](https://purchase.aspose.com/temporary-license) للمزيد من المعلومات.

{{% /alert %}}

## **الترخيص في Aspose.Slides**

* تُصبح النسخة التجريبية مرخصة بعد شراء ترخيص وإضافة بضع أسطر من الكود إليها (لتطبيق الترخيص).
* الترخيص هو ملف XML نصّي بسيط يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وغيرها.
* ملف الترخيص موقع رقمياً، لذا لا يجب تعديل الملف. حتى إضافة غير مقصودة لسطر جديد إلى محتوى الملف سيجعله غير صالح.
* عادةً ما تحاول **Aspose.Slides for Android via Java** العثور على الترخيص في المواقع التالية:
  * مسار صريح
  * المجلد الذي يحتوي على Aspose.Slides.jar
* لتجنب القيود المرتبطة بالنسخة التجريبية، يجب عليك تعيين ترخيص قبل استخدام **Aspose.Slides**. يكفي تعيين الترخيص مرة واحدة لكل تطبيق أو عملية.

{{% alert color="primary" %}} 

ربما ترغب في الاطلاع على [الترخيص القائم على القياس](/slides/ar/androidjava/metered-licensing/).

{{% /alert %}} 


## **تطبيق الترخيص**

يمكن تحميل الترخيص من **ملف** أو **دفق**.

{{% alert color="primary" %}}

توفر Aspose.Slides فئة [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) لعمليات الترخيص.

{{% /alert %}} 

{{% alert color="warning" %}}

يمكن للتراخيص الجديدة تفعيل Aspose.Slides فقط مع الإصدار 21.4 أو أحدث. الإصدارات السابقة تستخدم نظام ترخيص مختلف ولن تتعرف على هذه التراخيص.

{{% /alert %}}

### **ملف**

أسهل طريقة لتعيين ترخيص هي وضع ملف الترخيص في المجلد الذي يحتوي على Aspose.Slides.jar أو ملف jar الخاص بالتطبيقات.

هذا الكود Java يوضح لك كيفية تعيين ملف الترخيص:
``` java
// إنشاء مثيل للفئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// تعيين مسار ملف الترخيص
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

إذا وضعت ملف الترخيص في دليل مختلف، عند استدعاء طريقة [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) يجب أن يكون اسم ملف الترخيص في نهايته الصريحة هو نفسه اسم ملف الترخيص لديك.

على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى *Aspose.Slides.Android.via.Java.lic.xml*. ثم، في الشيفرة الخاصة بك، يجب تمرير المسار إلى الملف (الذي ينتهي بـ *Aspose.Slides.Android.via.Java.lic.xml*) إلى طريقة [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **دفق**

يمكنك تحميل ترخيص من دفق. هذا الكود Java يوضح لك كيفية تطبيق ترخيص من دفق:
``` java
// إنشاء مثيل للفئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// تعيين الترخيص عبر تدفق
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **التحقق من الترخيص**

للتحقق مما إذا تم تعيين الترخيص بشكل صحيح، يمكنك التحقق منه. هذا الكود Java يوضح لك كيفية التحقق من الترخيص:
```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **سلامة الخيوط**

{{% alert title="ملاحظة" color="warning" %}} 

طريقة [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) غير آمنة للاستخدام من عدة خيوط في آن واحد. إذا كان لابد من استدعاء هذه الطريقة من عدة خيوط في الوقت نفسه، قد ترغب في استخدام آليات التزامن (مثل القفل) لتجنب المشاكل. 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تطبيق الترخيص في بيئة غير متصلة بالإنترنت تمامًا (بدون وصول إلى الإنترنت؟)**

نعم. يتم التحقق من الترخيص محليًا باستخدام ملف الترخيص؛ لا يلزم اتصال بالإنترنت.

**ماذا يحدث بعد انتهاء الاشتراك السنوي؟ هل سيتوقف المكتبة عن العمل؟**

لا. الترخيص دائم: يمكنك الاستمرار في استخدام الإصدارات التي صدرت قبل تاريخ انتهاء اشتراكك؛ فقط لن تكون مؤهلاً لاستخدام الإصدارات الأحدث دون تجديد.