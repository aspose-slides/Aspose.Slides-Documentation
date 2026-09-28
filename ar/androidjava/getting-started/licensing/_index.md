---
title: الترخيص
type: docs
weight: 90
url: /ar/androidjava/licensing/
keywords:
- ترخيص
- رخصة مؤقتة
- تعيين الترخيص
- استخدام الترخيص
- التحقق من الترخيص
- ملف الترخيص
- نسخة التقييم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تطبيق وإدارة وحل مشاكل التراخيص في Aspose.Slides لنظام Android عبر Java. ضمان الوصول غير المتقطع إلى جميع الميزات مع دليل الترخيص الخاص بنا."
---
## **نظرة عامة**

يمكن استخدام Aspose.Slides في وضع التقييم أو باستخدام ترخيص صالح. يوفر إصدار التقييم نفس وظائف الإصدار المرخص، لكنه يضيف علامة مائية للتقييم إلى كل شريحة من كل عرض تقديمي يتم حفظه ويقطع النص الذي يقرأه الكود من العروض التقديمية.

تشرح هذه المقالة كيفية عمل الترخيص في Aspose.Slides وكيفية تطبيق الترخيص قبل استخدام المكتبة. يمكن تحميل الترخيص من ملف أو تدفق أو مورد مضمّن باستخدام فئة [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). كما تُظهر المقالة كيفية التحقق مما إذا تم تطبيق الترخيص بصورة صحيحة.

## **تقييم Aspose.Slides**

{{% alert color="info" title="Note" %}}

يمكنك تنزيل نسخة التقييم من **Aspose.Slides for Android via Java** من صفحة [download page](https://releases.aspose.com/slides/androidjava/). يوفر إصدار التقييم نفس الوظائف التي يوفرها الإصدار المرخص من المنتج. حزمة التقييم هي نفسها الحزمة المشتراة. يصبح إصدار التقييم مرخصًا بمجرد إضافة بضع أسطر من الكود إليه (لتطبيق الترخيص).

بعد أن تكون راضٍ عن تقييمك لـ **Aspose.Slides**، يمكنك [purchase a license](https://purchase.aspose.com/pricing/slides/android-java/). نوصي بأن تتصفح أنواع الاشتراكات المختلفة. إذا كانت لديك أسئلة، فاتصل بفريق مبيعات Aspose.

كل ترخيص Aspose يأتي مع اشتراك سنة واحدة لتحديثات مجانية إلى الإصدارات الجديدة أو الإصلاحات التي تُصدر ضمن فترة الاشتراك. يحصل المستخدمون الذين لديهم منتجات مرخصة (أو حتى إصدارات تقييم) على دعم فني مجاني وغير محدود.

{{% /alert %}} 

**قيود نسخة التقييم**

* نسخة التقييم (بدون ترخيص محدد) توفر وظائف المنتج بالكامل، لكنها تضيف صندوق نص علامة مائية تقييم إلى كل شريحة من كل عرض تقديمي يتم حفظه.
* يتم قطع النص الذي يقرأه الكود من العرض التقديمي إلى أول عدة أحرف، متبوعًا بإشعار حول قيود التقييم. النص الذي يكتبه الكود يُحفظ بالكامل.

{{% alert color="info" title="Note" %}}

لاختبار Aspose.Slides بدون قيود، يمكنك طلب **رخصة مؤقتة لمدة 30 يومًا**. راجع صفحة [How to get a Temporary License](https://purchase.aspose.com/temporary-license) لمزيد من المعلومات.

{{% /alert %}}

## **الترخيص في Aspose.Slides**

* يتحول إصدار التقييم إلى مرخص بعد شراء ترخيص وإضافة بضع أسطر من الكود لتطبيق الترخيص.
* الترخيص هو ملف XML نصي بسيط يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وما إلى ذلك.
* ملف الترخيص موقع رقمياً، لذا لا يجب تعديل الملف. حتى إضافة سطر فارغ غير مقصودة إلى محتويات الملف ستجعله غير صالح.
* عادةً ما تحاول Aspose.Slides for Android via Java العثور على الترخيص في المواقع التالية:
  * مسار صريح
  * المجلد الذي يحتوي على Aspose.Slides.jar
* لتجنب القيود المرتبطة بإصدار التقييم، تحتاج إلى تعيين ترخيص قبل استخدام **Aspose.Slides**. لا تحتاج إلى تعيين الترخيص إلا مرة واحدة لكل تطبيق أو عملية.

## **تطبيق الترخيص**

يمكن تحميل الترخيص من **ملف** أو **تدفق**.

{{% alert color="info" title="Note" %}}

توفر Aspose.Slides فئة [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) لعمليات الترخيص.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

يمكن للترخيص الجديد تفعيل Aspose.Slides فقط مع الإصدار 21.4 أو أحدث. الإصدارات السابقة تستخدم نظام ترخيص مختلف ولن تتعرف على هذه التراخيص.

{{% /alert %}}

### **ملف**

أسهل طريقة لتعيين ترخيص هي وضع ملف الترخيص في المجلد الذي يحتوي على Aspose.Slides.jar أو ملف jar الخاص بتطبيقك.

{{% alert color="info" title="Note" %}}

في Android، تُحزم المكتبة وتطبيقك في ملف APK، لذا لا يوجد مجلد يحتوي على ملف JAR الخاص بالمكتبة، والمسار النسبي مثل *Aspose.Slides.Android.via.Java.lic* لا يشير إلى ملف في تطبيقك. أضف ملف الترخيص إلى مجلد assets في تطبيقك وحمّله من تدفق، كما هو موضح في [Stream from App Assets](#stream-from-app-assets).

{{% /alert %}}

هذا الكود Java يوضح لك كيفية تعيين ملف الترخيص:

``` java
// ينشئ مثيل من الفئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// يحدد مسار ملف الترخيص
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

إذا وضعت ملف الترخيص في دليل مختلف، عند استدعاء طريقة [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) يجب أن يكون اسم ملف الترخيص في نهاية المسار المحدد هو نفسه اسم ملف الترخيص الخاص بك.

على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى *Aspose.Slides.Android.via.Java.lic.xml*. ثم، في الكود الخاص بك، عليك تمرير المسار إلى الملف (الذي ينتهي بـ *Aspose.Slides.Android.via.Java.lic.xml*) إلى طريقة [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **تدفق**

يمكنك تحميل ترخيص من تدفق. هذا الكود Java يوضح لك كيفية تطبيق ترخيص من تدفق:

``` java
// ينشئ مثيل من الفئة License
com.aspose.slides.License license = new com.aspose.slides.License();

// يعيّن الترخيص عبر تدفق
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **تدفق من موارد التطبيق**

في تطبيق Android، ضع ملف الترخيص في مجلد *assets* داخل وحدة التطبيق، *app/src/main/assets*، بحيث يُحصَّل داخل ملف APK. افتح الملف باستخدام طريقة [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) ومرّر التدفق إلى طريقة [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). يعمل الكود داخل `Activity`، على سبيل المثال في طريقة `onCreate`، قبل أن يستخدم التطبيق Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

اسم الملف الممرّر إلى طريقة [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) يكون نسبياً إلى مجلد *assets*. إذا لم يكن الملف هناك، يسجل الكود الخطأ، وتظل Aspose.Slides في وضع التقييم. للتحقق مما إذا تم تطبيق الترخيص، راجع قسم [Validating a License](#validating-a-license).

## **التحقق من الترخيص**

للتحقق مما إذا تم تعيين الترخيص بصورة صحيحة، يمكنك التحقق منه. هذا الكود Java يوضح لك كيفية التحقق من الترخيص:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **السلامة في بيئات متعددة الخيوط**

{{% alert color="warning" title="Warning" %}}

طريقة [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) ليست آمنة للاستخدام المتعدد الخيوط. إذا كان لابد من استدعاء هذه الطريقة في وقت واحد من خيوط متعددة، قد ترغب في استخدام آليات التزامن (مثل القفل) لتجنب المشكلات.

{{% /alert %}}

## **الأسئلة المتكررة**

### هل يمكنني تطبيق الترخيص في بيئة غير متصلة بالإنترنت تمامًا (بدون وصول إلى الإنترنت)؟

نعم. يتم التحقق من الترخيص محليًا باستخدام ملف الترخيص؛ لا يلزم اتصال إنترنت.

### ماذا يحدث بعد انتهاء الاشتراك السنوي؟ هل تتوقف المكتبة عن العمل؟

لا. الترخيص دائم: يمكنك الاستمرار في استخدام الإصدارات التي أُصدرت قبل تاريخ انتهاء اشتراكك؛ لن تكون مؤهلاً لاستخدام الإصدارات الأحدث دون تجديد.