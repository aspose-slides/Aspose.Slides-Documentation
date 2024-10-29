---
title: الترخيص
type: docs
weight: 90
url: /ar/java/licensing/
---

## **تقييم Aspose.Slides**

{{% alert color="primary" %}} 

يمكنك تنزيل إصدار تجريبي من **Aspose.Slides for Java** من [صفحة التنزيل](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). يوفر الإصدار التجريبي نفس وظائف الإصدار المرخّص من المنتج. حزمة التقييم هي نفسها حزمة الشراء. يصبح الإصدار التجريبي مرخصًا بعد إضافة بضع سطور من التعليمات البرمجية إليه (لتطبيق الترخيص).

بمجرد أن تكون راضيًا عن تقييمك لـ **Aspose.Slides**، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). نوصي بأن تتعرف على أنواع الاشتراكات المختلفة. إذا كانت لديك أي أسئلة، تواصل مع فريق مبيعات Aspose.

كل ترخيص من Aspose يأتي مع اشتراك مجاني لمدة عام لترقيات جديدة أو إصلاحات يتم إصدارها خلال فترة الاشتراك. يحصل المستخدمون الذين لديهم منتجات مرخصة (أو حتى إصدارات تجريبية) على الدعم الفني المجاني وغير المحدود.

{{% /alert %}} 

**قيود إصدار التقييم**

* بينما يوفر إصدار التقييم من Aspose.Slides (بدون ترخيص محدد) الوظائف الكاملة للمنتج، فإنه يضيف علامة مائية خاصة بالتقييم في أعلى الوثيقة عند فتحها أو حفظها. 
* يقتصر الأمر على شريحة واحدة عند استخراج النصوص من شرائح العرض.

{{% alert color="primary" %}} 

لاختبار Aspose.Slides دون قيود، يمكنك طلب **ترخيص مؤقت لمدة 30 يومًا**. راجع [كيفية الحصول على ترخيص مؤقت](https://purchase.aspose.com/temporary-license) لمزيد من المعلومات.

{{% /alert %}}

## **الترخيص في Aspose.Slides**

* يصبح إصدار التقييم مرخصًا بعد شراء ترخيص وإضافة بعض سطور التعليمات البرمجية إليه (لتطبيق الترخيص).
* الترخيص هو ملف XML نصي يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وما إلى ذلك. 
* ملف الترخيص موقع رقميًا، لذا يجب ألا تعدل الملف. حتى إضافة غير مقصودة لفراغ سطر إضافي لمحتويات الملف ستجعله غير صالح.
* تحاول Aspose.Slides for Java عادةً العثور على الترخيص في هذه المواقع:
  * مسار صريح
  * المجلد الذي يحتوي على Aspose.Slides.jar
* لتجنب القيود المرتبطة بإصدار التقييم، تحتاج إلى تعيين ترخيص قبل استخدام **Aspose.Slides**. عليك فقط تعيين ترخيص مرة واحدة لكل تطبيق أو عملية.

{{% alert color="primary" %}} 

قد ترغب في رؤية [الترخيص المتقطع](/slides/ar/java/metered-licensing/).

{{% /alert %}} 

## **تطبيق الترخيص**

يمكن تحميل الترخيص من **ملف** أو **تيار**.

{{% alert color="primary" %}}

توفر Aspose.Slides فئة [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) لعمليات الترخيص.

{{% /alert %}} 

### **ملف**

أسهل طريقة لتعيين ترخيص تتطلب منك وضع ملف الترخيص في المجلد الذي يحتوي على Aspose.Slides.jar أو jar تطبيقك.

يوضح لك هذا الكود البرمجي بلغة Java كيفية تعيين ملف الترخيص:

``` java
// ينشئ كائن من فئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// يحدد مسار ملف الترخيص
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

إذا وضعت ملف الترخيص في دليل مختلف، عند استدعاء طريقة [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) يجب أن يكون اسم ملف الترخيص في نهاية المسار المحدد هو نفسه اسم ملف الترخيص الخاص بك.

على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى *Aspose.Slides.Java.lic.xml*. ثم، في شفرتك، يجب عليك تمرير المسار إلى الملف (الذي ينتهي بـ *Aspose.Slides.Java.lic.xml*) إلى طريقة [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) .

{{% /alert %}}

### **تيار**

يمكنك تحميل ترخيص من تيار. يوضح لك هذا الكود البرمجي بلغة Java كيفية تطبيق ترخيص من تيار:

``` java
// ينشئ كائن من فئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// يحدد الترخيص من خلال تيار
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **جسر PHP/Java**

إذا كنت تستخدم Aspose.Slides لـ PHP عبر Java، يمكنك تعيين ترخيص من خلال جسر PHP/Java. يتيح لك هذا الجسر استخدام فئات Java في صياغة PHP. لمزيد من المعلومات، انظر [الترخيص في PHP](/slides/ar/php-java/licensing/).

## **التحقق من الترخيص**

للتحقق مما إذا كان الترخيص قد تم تعيينه بشكل صحيح، يمكنك التحقق منه. يوضح لك هذا الكود البرمجي بلغة Java كيفية التحقق من الترخيص:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("الترخيص صحيح!");
}
```

## **أمان الخيوط**

{{% alert title="ملاحظة" color="warning" %}} 

طريقة [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) ليست آمنة للخيوط. إذا كان يجب استدعاء هذه الطريقة بشكل متزامن من عدة خيوط، قد ترغب في استخدام بدائل التزامن (مثل قفل) لتجنب المشاكل. 

{{% /alert %}}