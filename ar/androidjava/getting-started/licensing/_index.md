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
- نسخة تقييم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق وإدارة وحل مشاكل الترخيص في Aspose.Slides لـ Android عبر Java. احرص على الحصول على وصول غير متقطع إلى جميع الميزات من خلال دليل الترخيص الخاص بنا."
---

## **تقييم Aspose.Slides**

{{% alert color="primary" %}} 

يمكنك تنزيل نسخة التقييم من **Aspose.Slides for Android via Java** من [صفحة التحميل](https://releases.aspose.com/slides/androidjava/). توفر نسخة التقييم نفس الوظائف التي تقدمها النسخة المرخصة من المنتج. حزمة التقييم هي نفسها الحزمة المشتراة. تصبح نسخة التقييم مرخصة ببساطة بعد أن تضيف بضع أسطر من الشيفرة لتطبيق الترخيص.

بمجرد أن تكون راضيًا عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). نوصيك بالاطلاع على أنواع الاشتراكات المختلفة. إذا كان لديك أسئلة، تواصل مع فريق مبيعات Aspose.

كل ترخيص Aspose يأتي مع اشتراك سنة واحدة للحصول على ترقيات مجانية إلى الإصدارات الجديدة أو التصحيحات التي تم إصدارها خلال فترة الاشتراك. يحصل المستخدمون الذين لديهم منتجات مرخصة (أو حتى نسخ تقييم) على دعم فني مجاني ولا محدود.

{{% /alert %}} 

**قيود نسخة التقييم**

* بينما نسخة التقييم من Aspose.Slides (بدون ترخيص محدد) توفر جميع وظائف المنتج، فإنها تضيف علامة مائية للتقييم في أعلى المستند عند عمليات الفتح والحفظ. 
* يُستثنى استخراج النصوص من شرائح العرض إلى شريحة واحدة فقط.

{{% alert color="primary" %}} 

لاختبار Aspose.Slides دون قيود، يمكنك طلب **ترخيص مؤقت لمدة 30 يومًا**. راجع صفحة [كيفية الحصول على ترخيص مؤقت](https://purchase.aspose.com/temporary-license) لمزيد من المعلومات.

{{% /alert %}}

## **الترخيص في Aspose.Slides**

* تصبح نسخة التقييم مرخصة بعد أن تشتري ترخيصًا وتضيف بضع أسطر من الشيفرة لتطبيق الترخيص.
* الترخيص هو ملف XML نص عادي يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وما إلى ذلك.
* ملف الترخيص موقع رقمياً، لذا لا يجب تعديل الملف. حتى إضافة غير مقصودة لسطر جديد إلى محتوى الملف سيجعله غير صالح.
* عادةً ما يحاول Aspose.Slides for Android via Java العثور على الترخيص في المواقع التالية:
  * مسار صريح
  * المجلد الذي يحتوي على Aspose.Slides.jar
* لتجنب القيود المرتبطة بنسخة التقييم، تحتاج إلى تعيين ترخيص قبل استخدام **Aspose.Slides**. يكفي تعيين الترخيص مرة واحدة لكل تطبيق أو عملية.

## **تطبيق الترخيص**

يمكن تحميل الترخيص من **ملف** أو **دفق**.

{{% alert color="primary" %}}

يوفر Aspose.Slides الفئة [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) لعمليات الترخيص.

{{% /alert %}} 

{{% alert color="warning" %}}

يمكن للتراخيص الجديدة تفعيل Aspose.Slides فقط مع الإصدار 21.4 أو أحدث. الإصدارات السابقة تستخدم نظام ترخيص مختلف ولن تتعرف على هذه التراخيص.

{{% /alert %}}

### **ملف**

أسهل طريقة لتعيين الترخيص تتطلب وضع ملف الترخيص في المجلد الذي يحتوي على Aspose.Slides.jar أو ملف jar الخاص بتطبيقك.

هذا الكود Java يوضح لك كيفية تعيين ملف ترخيص:
``` java
// يقوم بإنشاء فئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// يحدد مسار ملف الترخيص
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

إذا وضعت ملف الترخيص في دليل مختلف، عند استدعاء طريقة [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) يجب أن يكون اسم ملف الترخيص في نهاية المسار الصريح هو نفسه اسم ملف الترخيص الخاص بك.

على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى *Aspose.Slides.Android.via.Java.lic.xml*. ثم في الشيفرة الخاصة بك، يجب تمرير المسار إلى الملف (المنتهي بـ *Aspose.Slides.Android.via.Java.lic.xml*) إلى طريقة [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **دفق**

يمكنك تحميل الترخيص من دفق. هذا الكود Java يوضح لك كيفية تطبيق الترخيص من دفق:
``` java
// يقوم بإنشاء فئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// يحدد الترخيص عبر دفق
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **التحقق من صحة الترخيص**

للتحقق مما إذا تم تعيين الترخيص بشكل صحيح، يمكنك التحقق من صحته. هذا الكود Java يوضح لك كيفية التحقق من صحة الترخيص:
```java
License license = new License();
license.setLicense("Aspize.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **أمان الخيوط**

{{% alert title="Note" color="warning" %}} 

طريقة [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) غير آمنة في بيئات متعددة الخيوط. إذا كان يجب استدعاء هذه الطريقة في وقت واحد من عدة خيوط، قد ترغب في استخدام آليات تزامن (مثل القفل) لتجنب المشكلات. 

{{% /alert %}}

## **FAQ**

**هل يمكنني تطبيق الترخيص في بيئة غير متصلة بالإنترنت تمامًا (بدون اتصال بالإنترنت)؟**

نعم. يتم التحقق من صحة الترخيص محليًا باستخدام ملف الترخيص؛ لا يتطلب اتصالًا بالإنترنت.

**ماذا يحدث بعد انتهاء الاشتراك لمدة سنة واحدة؟ هل سيتوقف المكتبة عن العمل؟**

لا. الترخيص دائم: يمكنك الاستمرار في استخدام الإصدارات الصادرة قبل تاريخ انتهاء اشتراكك؛ لكن لن تتمكن من استخدام الإصدارات الأحدث دون التجديد.