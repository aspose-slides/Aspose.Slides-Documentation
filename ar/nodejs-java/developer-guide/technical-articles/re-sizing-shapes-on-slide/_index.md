---
title: تحجيم الأشكال على شرائح العرض التقديمي في Node.js
type: docs
weight: 130
url: /ar/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /ar/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java—قم بأتمتة تعديلات تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغييرك لحجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة وضعها لتناسب الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح، والماستَر، والتخطيطات.

## **تحجيم الأشكال**

للحفاظ على الموقع النسبي والحجم لكل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبّق نسبة الارتفاع المقابلة على إحداثياته الرأسية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب بلا وحدات؛ تُقاس مواضع الأشكال وأبعادها بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، ولا يؤدي تغيير أبعاد الشكل إلى تحجيم أحجام الخطوط الخاصة به.

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
تتطلب الجداول معالجة منفصلة: يتم تحجيم عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الكليين للجدول. قد يظل ارتفاع الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال على الماستَر والتخطيطات وكذلك على الشرائح الفردية قبل حفظ العرض التقديمي الذي تم تحجيمه. يتعامل المساعد الخاص به مع كل [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) عبر تحجيم أعرض الأعمدة باستخدام [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) والارتفاعات الدنيا للصفوف باستخدام [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). ثم يحجم موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // أبعاد الجدول يتم التحكم فيها بعرض الأعمدة وارتفاعات الصفوف.
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

    // احجم الأشكال المحددة على الماستَر والتخطيطات وكذلك على الشرائح الفردية.
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

## **الأسئلة المتكررة**

**لماذا تتشوه الأشكال أو تُقطع بعد تغيير حجم الشريحة؟**

إذا غيرت حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. كما أن تحجيم العرض والارتفاع بنسب مختلفة يمكن أن يشوه الأشكال.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصةً النصوص والجداول، لأن هذه الأمثلة لا تحجم أحجام الخطوط وقد يقيد محتوى الجدول ارتفاعات الصفوف.

**كيف أقوم بتحجيم الجداول عند تغيير حجم الشريحة؟**

احجم عرض الأعمدة بنسبة عرض الشريحة وقم بتحديد الحد الأدنى لارتفاع الصفوف بنسبة ارتفاع الشريحة، ثم احجم موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على شرائح الماستَر وشرائح التخطيط؟**

نعم. يتنقل المثال الثاني عبر [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) و[MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) لكل ماستر ويطبق نفس منطق التحجيم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. استدعِ [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع الأشكال ذات النسبة الثابتة من التشوه؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأقل بين نسب العرض والارتفاع لكل من الأبعاد والمواقع. يحافظ هذا على النسب لكن قد يترك مساحة غير مستخدمة على أحد الجوانب.