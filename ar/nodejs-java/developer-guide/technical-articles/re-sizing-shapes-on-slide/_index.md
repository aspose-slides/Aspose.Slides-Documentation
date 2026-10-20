---
title: تعديل حجم الأشكال على شرائح العرض التقديمي في Node.js
type: docs
weight: 130
url: /ar/nodejs-java/resizing-shapes-on-slide/
aliases:
  /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Node.js عبر Java—قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وتغيير موضعها لتناسب الأبعاد الجديدة. توضح هذه المقالة كيفية تحجيم الأ shapes يدويًا وكيفية التعامل مع الجداول في الشرائح والماستر والتخطيطات.

## **تحجيم الأشكال**

لحفاظ على موضع وحجم كل شكل بنسبة إلى الآخر، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديدة إلى العرض الأصلي. طبّق النسبة المقابلة للارتفاع على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب لا تحتوي على وحدات؛ مواضع الأشكال وأبعادها تُقاس بالنقاط. يمكن أن تشوّه النسب المختلفة للعرض والارتفاع الأشكال، وتغيير أبعاد الشكل لا يغيّر حجم الخطوط.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // احسب عوامل التحجيم الأفقية والرأسية المستقلة.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: قم بتغيير عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الكليين للجدول. قد تبقى ارتفاعات الصفوف أكبر من المطلوبة إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال في الماسترات والتخطيطات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي المُعاد تحجيمه. يتعامل المساعد الخاص به مع كل [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) عن طريق تحجيم عرض الأعمدة باستخدام [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) والارتفاع الأدنى للصفوف باستخدام [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). ثم يحجم موقع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // أبعاد الجدول تتحكم فيها عروض الأعمدة وارتفاعات الصفوف.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // احسب عوامل التحجيم الأفقية والرأسية المستقلة.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // تحجيم الأشكال المعرفة على الماسترات والتخطيطات وكذلك الشرائح الفردية.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**لماذا تتشوّه الأشكال أو تُقصّ بعد تغيير حجم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسبة مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ومصمم للشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التنسيق الناتج، وخاصة النص والجداول، لأن هذه الأمثلة لا تحجم أحجام الخطوط ومحتوى الجدول قد يحدّ من ارتفاعات الصفوف.

**كيف يمكنني تغيير حجم الجداول عند تغيير حجم الشريحة؟**

قم بتحجيم عرض الأعمدة بنسبة عرض الشريحة، والارتفاع الأدنى للصفوف بنسبة ارتفاع الشريحة، ثم حجم موقع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على شرائح الماستر وشرائح التخطيط؟**

نعم. يمرّ المثال الثاني عبر [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) وكل ماستر عبر [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) ويطبق نفس منطق التحجيم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. استدعِ [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة التي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشوه الأشكال التي لها نسبة عرض إلى ارتفاع ثابتة؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكل من الأبعاد والمواضع. هذا يحافظ على النسب لكنه قد يترك مساحة غير مستخدمة على أحد الجانبين.