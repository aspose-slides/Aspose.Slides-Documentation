---
title: الترخيص بحسب العداد
type: docs
weight: 100
url: /ar/nodejs-java/metered-licensing/
keywords:
- ترخيص
- ترخيص بحسب العداد
- Node.js
- Java
- Aspose.Slides for Node.js via Java
---

## **تطبيق مفاتيح الترخيص بحسب العداد**

{{% alert color="primary" %}} 

الترخيص بحسب العداد هو آلية ترخيص جديدة يمكن استخدامها جنبًا إلى جنب مع طرق الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فاختر الترخيص بحسب العداد.

عند شراء ترخيص بحسب العداد، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح باستخدام فئة [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) التي توفرها Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. إنشاء نسخة من فئة [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

2. تمرير المفاتيح العامة والخاصة إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

3. تنفيذ بعض المعالجة (أداء المهام).

4. استدعاء طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) من فئة `Metered`.

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

هذا مثال يوضح كيفية استخدام الترخيص بحسب العداد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء نسخة من فئة Metered
var metered = new aspose.slides.Metered();

// تمرير المفاتيح العامة والخاصة إلى كائن Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// الحصول على قيمة الكمية المستهلكة قبل استدعاءات API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// تنفيذ عملية باستخدام Aspose.Slides API هنا
// ...

// الحصول على قيمة الكمية المستهلكة بعد استدعاءات API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="ملاحظة" %}} 

لاستخدام الترخيص بحسب العداد، تحتاج إلى اتصال إنترنت مستقر لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة المتكررة**

**هل يمكنني استخدام ترخيص بحسب العداد مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. الترخيص بحسب العداد هو آلية ترخيص إضافية يمكن استخدامها جنبًا إلى جنب مع [طرق الترخيص](/slides/ar/nodejs-java/licensing/). يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما الذي يُحسب كاستهلاك تحت ترخيص بحسب العداد: عمليات أم ملفات؟**

يُحسب استهلاك API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**هل الترخيص بحسب العداد مناسب للمايكرو سيرفيسز والبيئات الخالية من الخوادم حيث يعاد تشغيل المثيلات بشكل متكرر؟**

نعم. نظرًا لأن المحاسبة تتم على مستوى استدعاءات API، فإن السيناريوهات التي تتضمن عمليات تشغيل باردة متكررة متوافقة، بشرط وجود اتصال شبكة ثابت لحسابات الترخيص بحسب العداد.

**هل تختلف وظيفة المكتبة عند استخدام ترخيص بحسب العداد مقارنةً بترخيص دائم؟**

لا. هذه فقط آلية الترخيص والفوترة؛ قدرات المنتج تبقى نفسها.

**كيف يرتبط الترخيص بحسب العداد بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، بينما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يومًا، والترخيص بحسب العداد يزيل القيود ويتقاضى رسومًا بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عبر رد فعل تلقائي عند تجاوز عتبة الاستهلاك؟**

نعم. ممارسة شائعة هي قراءة الاستهلاك الحالي دوريًا عبر [طرق التتبع](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) وتنفيذ حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.