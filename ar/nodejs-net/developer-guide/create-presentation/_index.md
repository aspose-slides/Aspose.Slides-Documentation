---
title: إنشاء عروض تقديمية في Node.js عبر .NET
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/nodejs-net/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PowerPoint
- إنشاء PPTX
- إضافة مربع نص
- إضافة شريحة
- حجم الشريحة
- شاشة عريضة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إنشاء عروض PowerPoint في JavaScript باستخدام Aspose.Slides لـ Node.js عبر .NET: إضافة مربع نص وشريحة، ضبط حجم الشريحة 16:9، وحفظ النتيجة كملف PPTX."
---
## **نظرة عامة**

يوضح هذا المقال كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides لـ Node.js عبر .NET، وإضافة مربع نص إلى الشريحة الأولى، وحفظ النتيجة كملف PPTX. كما يوضح كيفية إضافة المزيد من الشرائح وكيفية تحويل العرض إلى شرائح widescreen (16:9).

تحتاج الأمثلة إلى إعداد مشروع كما هو موضح في [Installation](/slides/ar/nodejs-net/installation/). احفظ كل مثال كملف `.js` في مجلد المشروع وشغله من ذلك المجلد باستخدام `node`، على سبيل المثال `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
ليس لدى Aspose.Slides لـ Node.js عبر .NET مرجع API خاص به. فهو يعكس API الخاص بـ Aspose.Slides لـ .NET بأسماء camelCase، لذا فإن الروابط في هذا المقال تؤدي إلى الفئات والأعضاء المطابقة في [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **إنشاء عرض تقديمي مع مربع نص**

لإنشاء عرض تقديمي ووضع مربع نص على الشريحة الأولى، اتبع الخطوات التالية:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). يحتوي العرض الجديد بالفعل على شريحة فارغة واحدة.  
2. احصل على تلك الشريحة من مجموعة [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). تُقرأ المجموعات في هذه الحزمة باستخدام `get(index)`، وتبدأ الفهارس من 0.  
3. أضف مستطيلاً باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) واضبط [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) الخاص بـ [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).  
4. احفظ العرض باستخدام طريقة [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) والقيمة `SaveFormat.Pptx`.  
5. استدعِ `dispose` داخل كتلة `finally` لتحرير موارد .NET التي تدعم العرض.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // الموضع (x, y) والحجم (العرض, الارتفاع) بوحدات النقاط.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

يكتب السكربت `new-presentation.pptx` إلى مجلد المشروع. يحتوي الملف على شريحة واحدة بها مستطيل مملوء تكون زاويةه العليا اليسرى على بعد 50 نقطة من الحواف اليسرى والعلوية للشريحة. عرض المستطيل 400 نقطة وارتفاعه 100 نقطة، ونصه مركّز. النقطة الواحدة تعادل 1/72 بوصة. بدون ترخيص، يضيف Aspose.Slides علامة مائية للتقييم إلى الشريحة؛ راجع [Licensing](/slides/ar/nodejs-net/licensing/).

## **إضافة شرائح**

يحتوي العرض الجديد على شريحة واحدة. لإضافة المزيد، مرّر شريحة تخطيط إلى طريقة [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) لمجموعة `slides`. تُعيد طريقة [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) لمجموعة [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) أول تخطيط من نوع معين من [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

المثال التالي يضيف شريحتين بتخطيط Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تطبع السكربت `Slide count: 3` وتكتب `three-slides.pptx`. تُضاف الشرائح الجديدة بعد الأولى ولا تحتوي على أي أشكال. يحتوي العرض الجديد دائمًا على تخطيط Blank، لكن العرض الذي تفتحه من ملف قد لا يحتوي على تخطيط من النوع المطلوب؛ في هذه الحالة تُعيد `getByType` القيمة `null`، لذا تحقق من النتيجة قبل تمريرها.

## **تعيين حجم الشريحة**

يستخدم العرض الجديد شرائح بنسبة 4:3 بحجم 720 × 540 نقطة (10 × 7.5 بوصة). لإنشاء شرائح widescreen بدلاً من ذلك، استدعِ طريقة [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) لخاصية [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) في العرض مع قيمة من نوع [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) وقيمة من نوع [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). تُحدد نوعية المقياس ما يجب على Aspose.Slides القيام به مع الأشكال الموجودة بالفعل على الشرائح؛ `DoNotScale` يتركها كما هي، وهو الاختيار الصحيح لعرض لا يحتوي على محتوى بعد.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تطبع السكربت `Slide size: 960 x 540 points`، وهو ما يعادل 13.33 × 7.5 بوصة، وتكتب `widescreen.pptx`. يمتلك `SlideSizeType.OnScreen16x9` نفس نسبة العرض إلى الارتفاع 16:9 ولكنه أصغر: 720 × 405 نقطة.

## **الأسئلة المتكررة**

**ما هي الوحدات التي تُقاس بها المواضع والأحجام؟**  
بالنقاط. البوصة الواحدة تساوي 72 نقطة، لذا فإن الشريحة الافتراضية 4:3 هي 720 × 540 نقطة، وشريحة widescreen 16:9 هي 960 × 540 نقطة.

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**  
أي قيمة من تعداد [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)، على سبيل المثال `SaveFormat.Ppt` لبرنامج PowerPoint 97–2003، `SaveFormat.Odp` لملف OpenDocument، أو `SaveFormat.Pdf`. للحصول على إخراج PDF، راجع [Convert PowerPoint to PDF](/slides/ar/nodejs-net/convert-powerpoint-to-pdf/).

**لماذا يحتوي العرض المحفوظ على النص "Evaluation only"؟**  
بدون ترخيص، يضيف Aspose.Slides علامة مائية للتقييم إلى الشرائح التي يحفظها. قم بتطبيق ترخيص كما هو موضح في [Licensing](/slides/ar/nodejs-net/licensing/) لإزالتها.

**لماذا يجب علي استدعاء `dispose`؟**  
كائن `Presentation` مدعوم بكيان .NET يحتفظ بالذاكرة وغيرها من الموارد. استدعاء `dispose` يحرّرها بمجرد عدم حاجتك للعرض، واستدعاؤه داخل كتلة `finally` يحرّرها حتى في حال حدوث خطأ.