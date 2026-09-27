---
title: الترخيص
type: docs
weight: 80
url: /ar/nodejs-java/licensing/
keywords:
- ترخيص
- ترخيص مؤقت
- تعيين الترخيص
- استخدام الترخيص
- التحقق من الترخيص
- ملف الترخيص
- نسخة التقييم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تطبيق وإدارة وحل المشكلات المتعلقة بالترخيص في Aspose.Slides لـ Node.js. ضمان الوصول غير المتقطع إلى جميع الميزات من خلال دليل الترخيص خطوة بخطوة."
---
## **مقدمة**

أحيانًا، للحصول على أفضل نتائج التقييم، قد يكون من الضروري اتباع نهج عملي. لهذا السبب، تقدم Aspose.Slides خطط شراء مختلفة وتوفر أيضًا نسخة تجريبية مجانية ورخصة مؤقتة لمدة 30 يومًا للتقييم.

{{% alert color="info" title="Note" %}}
لاحظ أن هناك عددًا من السياسات والممارسات العامة التي توجهك حول كيفية تقييم منتجاتنا، الترخيص الصحيح، وشراءها. يمكنك العثور عليها في قسم ["سياسات الشراء والأسئلة الشائعة"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **تقييم Aspose.Slides**
يمكنك بسهولة تنزيل Aspose.Slides للتقييم. حزمة التقييم هي نفس حزمة الشراء. نسخة التقييم تصبح مرخصة بمجرد إضافة بضعة أسطر من الشيفرة لتطبيق الترخيص.

## **قيود نسخة التقييم**
توفر نسخة التقييم من Aspose.Slides (بدون ترخيص محدد) جميع وظائف المنتج، مع قيودين:

* تُضيف مربع نص علامة مائية للتقييم إلى كل شريحة في كل عرض تقديمي يتم حفظه.
* النص الذي يزيد عن خمسة أحرف والذي تقرأه الشيفرة من عرض تقديمي يُقص إلى أول خمسة أحرف، متبوعًا بـ `... text has been truncated due to evaluation version limitation.` النص الذي يتكون من خمسة أحرف أو أقل يُعاد دون تغيير، والنص الذي تكتبه الشيفرة يُحفظ بالكامل.

{{% alert color="info" title="Note" %}}
إذا كنت تريد اختبار Aspose.Slides دون قيود نسخة التقييم، يمكنك طلب **رخصة مؤقتة لمدة 30 يومًا**. يرجى الرجوع إلى [كيفية الحصول على رخصة مؤقتة؟](https://purchase.aspose.com/temporary-license) للمزيد من المعلومات.
{{% /alert %}}

## **حول الترخيص**
يمكنك بسهولة تنزيل نسخة تقييم من Aspose.Slides لـ Node.js عبر Java من [صفحة التحميل](https://releases.aspose.com/slides/ar/nodejs-java/). نسخة التقييم تحتوي على نفس الميزات مثل النسخة المرخصة، مع القيود المذكورة أعلاه. علاوة على ذلك، تصبح نسخة التقييم مرخصة بمجرد شرائك رخصة وإضافة بضع أسطر من الشيفرة لتطبيق الترخيص.

الترخيص هو ملف XML نصي بسيط يحتوي على تفاصيل مثل اسم المنتج، عدد المطورين المرخص لهم، تاريخ انتهاء الاشتراك، وما إلى ذلك. الملف موقع رقمياً، لذا لا تقم بتعديل الملف. حتى إضافة سطر فارغ غير مقصودة إلى محتوى الملف سيجعل الترخيص غير صالح.

لتجنب القيود المرتبطة بنسخة التقييم، تحتاج إلى ضبط ترخيص قبل استخدام **Aspose.Slides**. يلزم ضبط الترخيص مرة واحدة فقط لكل تطبيق أو عملية.

{{% alert color="info" title="Note" %}}
قد ترغب في الاطلاع على [الترخيص القائم على القياس](/slides/ar/nodejs-java/metered-licensing/).
{{% /alert %}}

## **رخصة تم شراؤها**
بعد الشراء، تحتاج إلى تطبيق ملف الترخيص أو التدفق.

{{% alert color="info" title="Note" %}}
يجب ضبط الترخيص:
* مرة واحدة فقط لكل عملية
* قبل استخدام أي فئة أخرى من Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
يمكنك العثور على معلومات الأسعار في صفحة [معلومات التسعير](https://purchase.aspose.com/pricing/slides/ar/family).
{{% /alert %}}

### **ضبط الترخيص في Aspose.Slides لـ Node.js عبر Java**

يمكن تطبيق الترخيص من المواقع التالية:

* مسار صريح
* تدفق
* كترخيص قائم على القياس – آلية ترخيص جديدة

{{% alert color="info" title="Note" %}}
استخدم طريقة **setLicense** لترخيص مكوّن.
بينما استدعاءات متعددة لـ **setLicense** ليست ضارة، فهي مضيعة للموارد (المعالج).
{{% /alert %}}

#### **تطبيق الترخيص باستخدام ملف**

يُستخدم هذا المقتطف لضبط ملف الترخيص:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides يعمل في آلة افتراضية جافا تُبقي Node.js قيد التشغيل، لذا يجب إنهاء العملية صراحةً.
process.exit(0);
```

عند استدعاء طريقة setLicense، يجب أن يكون اسم الترخيص هو نفسه كما هو في ملف الترخيص الخاص بك. على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى "Aspose.Slides.lic.xml". ثم، في الشيفرة، عليك تمرير الاسم الجديد (Aspose.Slides.lic.xml) إلى طريقة setLicense. إذا كان الملف مفقودًا أو لا يحتوي على ترخيص صالح، فإن [setLicense](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/license/setlicense/) يطرح استثناءً، وينهي البرنامج النصي بخطأ.

#### **تطبيق الترخيص من تدفق**

لتطبيق ترخيص من تدفق، مرّر كائن [License](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/license/) وتدفق قابل للقراءة إلى الطريقة الساكنة [setLicenseFromStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/license/setlicense/). يُقرأ التدفق بشكل غير متزامن، ويتلقى الاستدعاء الرجعي خطأ إذا لم يحتوي التدفق على ترخيص صالح:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides يعمل في آلة افتراضية جافا تُبقي Node.js قيد التشغيل، لذا يجب إنهاء العملية صراحةً.
    process.exit(0);
});
```

يُطبق الترخيص عندما يكتمل قراءة التدفق بالكامل، مباشرةً قبل تشغيل الاستدعاء الرجعي، لذا ابدأ أعمال Aspose.Slides الأخرى من داخل الاستدعاء الرجعي.

كلا العيّنتين تستدعيان `process.exit(0)` عند الانتهاء، لأن آلة Java الافتراضية التي تشغل Aspose.Slides تبقي Node.js قيد التشغيل. في تطبيق، استمر في شيفرة Aspose.Slides الخاصة بك بدلاً من إنهاء العملية.

## **الأسئلة المتكررة**

### هل يمكنني تطبيق الترخيص في بيئة غير متصلة بالإنترنت تمامًا (بدون اتصال إنترنت)؟
نعم. يتم إجراء التحقق من صحة الترخيص محليًا باستخدام ملف الترخيص؛ لا يلزم اتصال إنترنت.

### ماذا يحدث بعد انتهاء الاشتراك السنوي؟ هل سيتوقف المكتبة عن العمل؟
لا. الترخيص دائم: يمكنك الاستمرار في استخدام الإصدارات التي صدرت قبل تاريخ انتهاء اشتراكك؛ فقط لن تكون مؤهلاً لاستخدام الإصدارات الأحدث دون تجديد.