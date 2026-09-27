---
title: فتح العروض في Node.js عبر .NET
linktitle: فتح عرض
type: docs
weight: 20
url: /ar/nodejs-net/open-presentation/
keywords:
- فتح عرض
- فتح PowerPoint
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض
- عرض من Buffer
- عدد الشرائح
- تحويل العرض
- PowerPoint
- OpenDocument
- عرض
- Node.js
- JavaScript
- Aspose.Slides
description: "فتح عروض PPTX وPPT وODP في JavaScript باستخدام Aspose.Slides لـ Node.js عبر .NET: التحميل من مسار ملف أو Buffer، قراءة عدد الشرائح، وحفظها بتنسيق آخر."
---
## **نظرة عامة**

يفتح Aspose.Slides لـ Node.js عبر .NET عروض PowerPoint وOpenDocument، مثل ملفات PPTX وPPT وODP، من مسار ملف أو من `Buffer` في Node.js. توضح هذه المقالة الطريقتين، وتقرأ عدد الشرائح، وتحفظ العرض المفتوح بتنسيق آخر.

تتوقع الأمثلة عرضًا باسم `sample.pptx` في مجلد المشروع الذي قمت بإعداده في [التثبيت](/slides/ar/nodejs-net/installation/). أي عرض PowerPoint سيعمل. احفظ كل مثال كملف `.js` في مجلد المشروع وشغله من ذلك المجلد باستخدام `node`.

{{% alert color="info" title="Note" %}}
لا يحتوي Aspose.Slides لـ Node.js عبر .NET على مرجع API خاص به. إنه يطابق API الخاص بـ Aspose.Slides لـ .NET بأسماء camelCase، لذا فإن روابط API في هذه المقالة توجه إلى الفئات والأعضاء المطابقة في [مرجع API لـ Aspose.Slides لـ .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **فتح عرض من ملف**

لفتح عرض، مرّر مساره إلى المُنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). يكتشف Aspose.Slides التنسيق من محتوى الملف بدلاً من الامتداد، لذا يفتح نفس الكود ملفات PPTX وPPT وODP. يتم حل المسار النسبي بالنسبة إلى دليل العمل الحالي، وهو مجلد المشروع عندما تشغّل النص البرمجي من هناك.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

يطبع النص البرمجي عدد الشرائح في `sample.pptx`، على سبيل المثال `Slide count: 9`. خاصية `count` لمجموعة [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) تشمل الشرائح المخفية. استدعِ `dispose` داخل كتلة `finally`، كما هو موضح، حتى يتم تحرير موارد .NET وراء العرض حتى إذا فشل الكود.

## **فتح عرض من Buffer**

عند جلب عرض من قاعدة بيانات أو تحميل HTTP أو مصدر آخر يقدم لك بايتات بدلاً من مسار ملف، مرّر `Buffer` في Node.js كمعامل المُنشئ الثاني و`null` كالأول. المثال التالي يقرأ `sample.pptx` إلى ذاكرة `buffer` لتقليد مثل هذا المصدر:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

يطبع النص البرمجي نفس عدد الشرائح كما في المثال السابق. يجب أن يكون المعامل الثاني من نوع `Buffer`. لأي نوع آخر، مثل `Uint8Array`، لا يُبلغ المُنشئ عن خطأ؛ بل يُنشئ عرضًا جديدًا بشريحة فارغة واحدة بدلاً من ذلك. حوِّل الأنواع الثنائية الأخرى باستخدام `Buffer.from` أولاً.

## **حفظ عرض بتنسيق آخر**

لتحويل عرض إلى تنسيق عرض آخر، افتحه واحفظه بقيمة مختلفة من [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). المثال التالي يطبع التنسيق الذي كشفه Aspose.Slides، والذي تُرجعه خاصية [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/)، ويحفظ العرض كعرض OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

يطبع النص البرمجي `Source format: Pptx` ويكتب ملف `sample.odp`، الذي يحتوي على نفس الشرائح. تُعيد `sourceFormat` القيم `Ppt` أو `Pptx` أو `Odp`. لحفظه كملف PDF أو كصور بدلاً من ذلك، راجع [تحويل PowerPoint إلى PDF](/slides/ar/nodejs-net/convert-powerpoint-to-pdf/) و[تحويل الشرائح إلى صور](/slides/ar/nodejs-net/convert-slide/).

## **الأسئلة المتكررة**

**كيف يمكنني فتح عرض محمي بكلمة مرور؟**

أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)، عيّن خاصية [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) الخاصة به، ومرّر الكائن كثالث معطى للمُنشئ: `new Presentation("protected.pptx", null, loadOptions)`. بدون كلمة المرور الصحيحة، يُطلق المُنشئ خطأ.

**لماذا يطرح المُنشئ `Error` برسالة فارغة؟**

عندما يفشل المُنشئ `Presentation` في .NET، على سبيل المثال بسبب فقدان الملف، أو كونه ليس عرضًا، أو الحاجة إلى كلمة مرور مختلفة، تتلقى JavaScript خطأ `Error` تكون رسالته فارغة. قبل فتح ملف، تحقق من أنه موجود بالنسبة إلى دليل العمل، على سبيل المثال باستخدام `fs.existsSync`.

**ما هي الصيغ التي يمكنني فتحها؟**

صيغ عروض PowerPoint وOpenDocument، بما في ذلك PPT وPPTX وPPS وPOT وPOTX وPPTM وODP وOTP وFODP.