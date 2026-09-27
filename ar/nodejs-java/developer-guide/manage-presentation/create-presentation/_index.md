---
title: إنشاء عروض تقديمية بلغة JavaScript
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/nodejs-java/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء عروض تقديمية باستخدام Aspose.Slides — إنشاء ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي في Aspose.Slides، وإضافة مربع نص إلى شريحته الأولى، وحفظ النتيجة كملف.

قبل البدء، قم بتثبيت حزمة `aspose.slides.via.java` من npm، إلى جانب JDK وPython وأدوات البناء لـ C++ التي يحتاجها. راجع [التثبيت](/slides/ar/nodejs-java/installation/).

## **إنشاء عرض PowerPoint**

لإنشاء عرض تقديمي ووضع مربع نص على شريحته الأولى، اتبع الخطوات التالية:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). يحتوي العرض التقديمي الجديد بالفعل على شريحة فارغة واحدة.
2. احصل على تلك الشريحة من [مجموعة الشرائح](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) باستخدام فهرستها، 0.
3. أضف مستطيلاً باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) ثم عيّن نصه باستخدام [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/).
4. احفظ العرض التقديمي كملف PPTX باستخدام طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/).
5. حرّر العرض التقديمي باستخدام طريقة [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/)، ثم أنهِ العملية.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// تعمل Aspose.Slides في آلة افتراضية Java تبقي Node.js قيد التشغيل، لذلك يجب إنهاء العملية صراحةً.
process.exit(0);
```

زاوية المستطيل العلوية اليسرى تبعد 50 نقطة عن الحافة اليسرى و50 نقطة عن الحافة العليا للشريحة، وعرض المستطيل 400 نقطة وارتفاعه 100 نقطة. احفظ الكود كملف *hello.js* في مجلد مشروعك وشغّله باستخدام `node hello.js`: سيقوم بحفظ *hello.pptx*، مع شريحة واحدة تحتوي على ذلك المستطيل ونصه، في المجلد الحالي.

يعمل Aspose.Slides داخل آلة افتراضية Java التي يبدأها حزمة `java` داخل عملية Node.js. تبقي تلك الآلة الافتراضية Node.js من الخروج تلقائيًا بعد انتهاء النص البرمجي، لذلك ينتهي المثال بـ `process.exit(0)`.

بدون ترخيص، يضيف Aspose.Slides أيضًا علامة مائية تقييم على كل شريحة يحفظها؛ راجع [الترخيص](/slides/ar/nodejs-java/licensing/).

## **الأسئلة الشائعة**

### ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟

يمكنك الحفظ إلى [PPTX و PPT و ODP](/slides/ar/nodejs-java/save-presentation/)، وتصدير إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، [SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/)، و[الصور](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، من بين أمور أخرى.

### هل يمكنني البدء من قالب (POTX/POTM) ثم حفظه كـ PPTX عادي؟

نعم. حمّل القالب واحفظه بالصيغ المطلوبة؛ صيغ POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/nodejs-java/supported-file-formats/).

### كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟

حدد [حجم الشريحة](/slides/ar/nodejs-java/slide-size/) (بما في ذلك القوالب مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر كيفية ضبط المحتوى.

### بأي وحدات تُقاس الأحجام والإحداثيات؟

بالنقاط: 1 بوصة يساوي 72 وحدة.

### كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟

استخدم [استراتيجيات إدارة BLOB](/slides/ar/nodejs-java/manage-blob/)، قلل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات في الذاكرة فقط.

### هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟

لا يمكنك التعامل مع نفس مثيل [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/nodejs-java/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

### كيف أزيل علامة المائية التجريبية والقيود؟

[طبق ترخيصًا](/slides/ar/nodejs-java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص دون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك عدة خيوط.

### هل يمكنني توقيع PPTX رقمياً؟

نعم. [التوقيعات الرقمية](/slides/ar/nodejs-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

### هل تدعم الماكرو (VBA) في العروض التقديمية التي تم إنشاؤها؟

نعم. يمكنك [إنشاء/تحرير مشروعات VBA](/slides/ar/nodejs-java/presentation-via-vba/) وحفظ ملفات ممكنة للماكرو مثل PPTM/PPSM.