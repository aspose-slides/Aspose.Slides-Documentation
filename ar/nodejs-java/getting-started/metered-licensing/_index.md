---
title: الترخيص القابل للعداد
type: docs
weight: 100
url: /ar/nodejs-java/metered-licensing/
keywords:
- ترخيص
- الترخيص القابل للعداد
- Node.js
- Java
- Aspose.Slides لـ Node.js عبر Java
---

## **تطبيق المفاتيح المتقاسة**

{{% alert color="primary" %}} 

الترخيص القابل للعداد هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الحالية. إذا رغبت في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فأنت تختار الترخيص القابل للعداد.

عند شراء ترخيص قابل للعداد، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح القابل للعداد باستخدام الفئة [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) التي توفرها Aspose لعمليات العد. للمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. أنشئ نسخة من الفئة [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

2. مرّر المفاتيح العامة والخاصة إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

3. نفّذ بعض المعالجة (قم بالمهام).

4. استدعِ طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) في فئة `Metered`.

ستظهر لك كمية/عدد طلبات API التي استهلكتها حتى الآن.

يعرض مثال الشيفرة التالي كيفية استخدام الترخيص القابل للعداد:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء نسخة من فئة Metered
var metered = new aspose.slides.Metered();

// يمرر المفاتيح العامة والخاصة إلى كائن Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// يحصل على قيمة الكمية المستهلكة قبل استدعاءات API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// نفّذ شيئًا باستخدام Aspose.Slides API هنا
// ...

// يحصل على قيمة الكمية المستهلكة بعد استدعاءات API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="NOTE"  %}} 

لاستخدام الترخيص القابل للعداد، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص قابل للعداد مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. الترخيص القابل للعداد هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/nodejs-java/licensing/) الموجودة. تختار أي آلية تريد تطبيقها عندما يبدأ التطبيق.

**ما الذي يُحسب كاستهلاك تحت الترخيص القابل للعداد: العمليات أم الملفات؟**

يُحتسب استهلاك API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**هل الترخيص القابل للعداد مناسب للمايكروسيرفيس والبيئات الخالية من الخوادم حيث يُعاد تشغيل المثيلات بشكل متكرر؟**

نعم. بما أن المحاسبة تُجرى على مستوى طلبات API، فإن السيناريوهات التي تشهد عمليات بدء باردة متكررة متوافقة، بشرط وجود اتصال شبكة ثابت لحسابات الترخيص القابل للعداد.

**هل تختلف وظائف المكتبة عند استخدام ترخيص قابل للعداد مقارنةً بالترخيص الدائم؟**

لا. هذا يتعلق فقط بآلية الترخيص والفوترة؛ قدرات المنتج تظل كما هي.

**كيف يرتبط الترخيص القابل للعداد بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، بينما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يومًا، والترخيص القابل للعداد يزيل القيود ويُحاسب بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية من خلال رد فعل تلقائي عند تجاوز عتبة الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي دوريًا عبر [طرق التتبع](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) وتطبيق حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.