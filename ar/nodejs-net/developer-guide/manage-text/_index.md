---
title: إدارة نص العرض التقديمي في Node.js عبر .NET
linktitle: إدارة النص
type: docs
weight: 50
url: /ar/nodejs-net/manage-text/
keywords:
- نص
- مربع نص
- إضافة نص
- تغيير النص
- تنسيق النص
- حجم الخط
- نص غامق
- إطار النص
- فقرة
- جزء
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة مربع نص إلى شريحة، ثم تغيير نصه، حجم الخط، ونمط الغامق باستخدام JavaScript مع Aspose.Slides لـ Node.js عبر .NET."
---
## **نظرة عامة**

في Aspose.Slides، النص الموجود على الشريحة ينتمي إلى شكل. الشكل التلقائي، مثل المستطيل، يحتوي على إطار نص؛ يحتوي إطار النص على فقرات، وكل فقرة تحتوي على أجزاء، وهي مقاطع نصية ذات تنسيق موحد. تقوم بتغيير النص عبر إطار النص وتغيير الخط عبر تنسيق الجزء.

تضيف هذه المقالة صندوق نص إلى شريحة وتحفظ العرض التقديمي. ثم تفتح الملف المحفوظ وتغيّر نص صندوق النص، حجم الخط، ونمط الغامق.

تحتاج الأمثلة إلى مشروع تم إعداده كما هو موضح في [Installation](/slides/ar/nodejs-net/installation/). احفظ كل مثال كملف `.js` في مجلد المشروع وشغّله من ذلك المجلد باستخدام `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js عبر .NET لا يحتوي على مرجع API خاص به. فهو يعكس API الخاص بـ Aspose.Slides for .NET بأسماء camelCase، لذا توجه روابط API في هذه المقالة إلى الفئات والأعضاء المطابقة في [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **إضافة مربع نص**

لإضافة مربع نص، أضف شكلاً تلقائيًا إلى شريحة باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) ومنحه نصًا باستخدام طريقة [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/). المثال التالي يضيف مستطيلًا إلى الشريحة الأولى من عرض تقديمي جديد ويحفظ العرض باسم `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // الموضع (x, y) والحجم (العرض، الارتفاع) بوحدات النقاط.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

تحتوي الشريحة في `text-box.pptx` على مستطيل عرضه 500 نقطة وارتفاعه 80 نقطة، ويتضمن النص "Quarterly report" بالخط الافتراضي وحجمه. المثال التالي يغيّر هذا الصندوق النصي.

## **تغيير النص وتنسيقه**

يفتح المثال التالي ملف `text-box.pptx`، الذي أنشأه المثال السابق، ويحصل على الشكل الأول في الشريحة الأولى. الأشكال مثل الصور والجداول لا تملك إطار نص، لذا يتحقق المثال من أن الشكل هو [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) قبل أن يستخدم [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) الخاص بالشكل. ثم يقوم بما يلي:

1. يستبدل النص عبر خاصية [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) لإطار النص. بعد ذلك يحتوي إطار النص على فقرة واحدة مع جزء واحد.
2. يحصل على ذلك الجزء من مجموعتي [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) و[portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) ويقرأ [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/) الخاص به.
3. يعيّن [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)، حجم الخط بالنقاط، و[fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/)، التي تأخذ قيمة [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

في `text-box-updated.pptx`، يظهر صندوق النص "Quarterly report: third quarter" بخط غامق بحجم 32 نقطة. لأن النص الجديد هو جزء واحد، فإن خاصيتي التنسيق تنطبقان على كامل النص. بدون ترخيص، يضيف كل حفظ علامة مائية للتقييم. وبما أن `text-box.pptx` تم حفظه في وضع التقييم، فإن `text-box-updated.pptx` يحتوي على علامتين؛ راجع [Evaluate Aspose.Slides](/slides/ar/nodejs-net/evaluate-aspose-slides/).

## **الأسئلة المتكررة**

**لماذا تأخذ الخاصية `fontBold` قيمة `NullableBool` بدلاً من `true` أو `false`؟**

يمكن للجزء أن يترك خاصية غير معرفة ويرثها من الفقرة أو الشكل أو تخطيط الشريحة والماستر. `NullableBool.NotDefined` يعني "وراثة"، بينما `NullableBool.True` و`NullableBool.False` يتجاوزان القيمة الموروثة. تعيين `true` أو `false` يسبب خطأ. لنفس السبب، `fontHeight` يرجع `NaN` عندما يرث الجزء حجم الخط.

**كيف يمكنني تغيير لون النص؟**

قم بتعيين تعبئة تنسيق الجزء: عيّن `FillType.Solid` إلى `portionFormat.fillFormat.fillType`، ثم عيّن لونًا مثل `"#FF0000"` إلى `portionFormat.fillFormat.solidFillColor.color`. أضف `FillType` إلى الأسماء التي تستوردها من الحزمة.

**كيف يمكنني تنسيق جزء فقط من النص؟**

التنسيق يتعلق بالأجزاء، لذا ضع ذلك الجزء من النص في جزء منفصل. أنشئ الجزء باستخدام `Portion.CreatePortionFromText`، أضفه إلى فقرة باستخدام طريقة `add` لمجموعة `portions` في الفقرة، ثم عيّن `portionFormat` للجزء الجديد. أضف `Portion` إلى الأسماء التي تستوردها من الحزمة.

**لماذا تُعيد قراءة النص الرسالة "... text has been truncated due to evaluation version limitation"?**

بدون ترخيص، تُعيد Aspose.Slides فقط أول خمسة أحرف من أي نص أطول تقرأه، مثل `textFrame.text`، متبوعة بهذه الملاحظة. النص الذي تكتبه يُحفظ بالكامل. طبّق ترخيصًا كما هو موضح في [Licensing](/slides/ar/nodejs-net/licensing/) لقراءة النص الكامل.