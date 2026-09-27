---
title: تحويل شرائح العروض التقديمية إلى صور في Node.js عبر .NET
linktitle: شريحة إلى صورة
type: docs
weight: 40
url: /ar/nodejs-net/convert-slide/
keywords:
- تحويل شريحة
- شريحة إلى صورة
- شريحة إلى PNG
- حفظ الشريحة كصورة
- تصيير الشريحة
- مصغرة الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تصيير الشرائح من عروض PPTX و PPT و ODP كصور PNG في JavaScript باستخدام Aspose.Slides لـ Node.js عبر .NET، إما بعامل مقياس أو بحجم دقيق بالبكسل."
---
## **نظرة عامة**

Aspose.Slides for Node.js عبر .NET يحول الشرائح من عروض PowerPoint و OpenDocument إلى صور، على سبيل المثال لعرض معاينات الشرائح على صفحة ويب. يوضح هذا المقال طريقتين لاختيار حجم الصورة: عامل مقياس نسبة إلى حجم الشريحة، وحجم دقيق بوحدات البكسل. كلا المثالين يحفظان ملفات PNG.

يتوقع الأمثلة وجود عرض تقديمي باسم `sample.pptx` في مجلد المشروع الذي قمت بإعداده في [التثبيت](/slides/ar/nodejs-net/installation/). أي عرض PowerPoint صالح. احفظ كل مثال كملف `.js` في مجلد المشروع وشغله من ذلك المجلد باستخدام `node`.

{{% alert color="info" title="Note" %}}
لا يحتوي Aspose.Slides for Node.js عبر .NET على مرجع API خاص به. فهو يعكس API الخاص بـ Aspose.Slides for .NET بأسماء camelCase، لذا فإن روابط API في هذا المقال تؤدي إلى الفئات والأعضاء المطابقة في [مرجع API الخاص بـ Aspose.Slides for .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. افتح العرض التقديمي باستخدام مُنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/).
2. احصل على شريحة من مجموعة [الشرائح](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) باستخدام `get(index)`. تبدأ الفهارس من 0.
3. صوّر الشريحة باستخدام `getImageWithScale` أو `getImageWithImageSize`. في مرجع API الخاص بـ .NET، كلاهما إصدارات متراكبة من [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). تُعيد كائن صورة يتطابق مع [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
4. احفظ الصورة باستخدام طريقة [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) وقيمة من نوع [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، ثم استدعِ طريقة `dispose` الخاصة بها.

## **تحويل كل شريحة إلى صورة PNG**

`getImageWithScale` يأخذ عامل مقياس أفقي وعمودي. عند مقياس 1، يصبح كل نقطة من الشريحة بكسلًا واحدًا في الصورة. المثال التالي يصور كل شريحة بمقياس 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// مقياس 1 يصدر بكسل واحد لكل نقطة؛ 2 يضاعف العرض والارتفاع.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

يكتب السكريبت ملفًا واحدًا لكل شريحة، `slide_1.png`، `slide_2.png`، وهكذا، مرقمةً من 1. بالنسبة لعرض تقديمي بنسبة 16:9 مع شرائح بحجم 960 × 540 نقطة، تكون كل صورة 1920 × 1080 بكسل. يتم تصيير الشرائح المخفية أيضًا؛ لتخطيها، تحقق من خاصية [مخفي](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) للشريحة. يتم تحرير كل صورة في كتلة `finally` خاصة بها، مما يحررها قبل تصيير الشريحة التالية. بدون ترخيص، تظهر علامة مائية توضيحية على الصور؛ راجع [التراخيص](/slides/ar/nodejs-net/licensing/).

## **تحويل شريحة إلى صورة بحجم محدد**

`getImageWithImageSize` يأخذ كائنًا يحتوي على `width` و `height` بوحدات البكسل. المثال التالي يصور الشريحة الأولى بعرض 1280 بكسل ويحساب الارتفاع بناءً على حجم الشريحة، بحيث تحافظ الصورة على نسبة أبعاد الشريحة:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

خاصية [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) تُعيد عرض وارتفاع الشريحة بالنقاط. بالنسبة لعرض تقديمي بنسبة 16:9، يطبع السكريبت `Saved a 1280 x 720 image` ويكتب `slide_1_1280px.png`؛ بالنسبة لعرض 4:3، تكون الصورة 1280 × 960 بكسل.

## **الأسئلة الشائعة**

**لماذا تكون الصورة الناتجة من `getImage` بدون معلمات صغيرة جدًا؟**

بدون معلمات، تقوم `getImage` بتصوير الشريحة بنسبة 20٪ من حجمها بالنقاط، لذا تصبح شريحة بحجم 960 × 540 نقطة صورة بحجم 192 × 108 بكسل. استخدم `getImageWithScale` أو `getImageWithImageSize` لاختيار الحجم.

**كيف أحفظ بصيغة JPEG أو بصيغ صور أخرى؟**

مرّر قيمة `ImageFormat` أخرى إلى طريقة `save` الخاصة بالصورة، على سبيل المثال `image.save("slide_1.jpg", ImageFormat.Jpeg)`. يتم تحديد الصيغة من قيمة `ImageFormat`، وليس من امتداد الملف، لذا حافظ على التناسق بينهما.

**لماذا يظهر النص في الصور بشكل مختلف على Linux؟**

يمكن لـ Aspose.Slides استخدام الخطوط المثبتة فقط على الجهاز الذي يقوم بتصوير الشرائح. عندما يستخدم عرض تقديمي خطًا غير موجود، مثل Calibri على خادم Linux شائع، يستخدم Aspose.Slides خطًا مثبتًا بدلاً منه، مما قد يغير مظهر النص ومكان انقسام السطور. قم بتثبيت الخطوط التي يستخدمها عروضك للحصول على نفس الصور كما في Windows.

**لماذا تفشل `getThumbnailWithImageSize` بخطأ TypeError؟**

يستخدم ملف README الخاص بالحزمة `getThumbnailWithImageSize`، لكن الحزمة لا تحتوي على طرق `getThumbnail`. استخدم `getImageWithImageSize` بدلًا منها؛ فهي تأخذ نفس المعامل `{ width, height }`.