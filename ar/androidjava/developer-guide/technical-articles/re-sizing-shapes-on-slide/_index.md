---
title: تعديل حجم الأشكال على شرائح العرض التقديمي على Android
type: docs
weight: 130
url: /ar/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
  - /ar/androidjava/re-sizing-shapes-on-slide/
keywords:
- تعديل حجم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Aspose.Slides
description: "قم بتعديل حجم الأشكال بسهولة على شرائح PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تعديل حجم الأشكال وإعادة وضعها لتناسب الأبعاد الجديدة. يوضح هذا المقال كيفية تكبير وتصغير الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح، والماستر، والتصاميم.

## **تغيير حجم الأشكال**

لحفظ الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. ثم طبّق نسبة الارتفاع المقابلة على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، ويغيّر حجم الشريحة إلى A4، ثم يحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) بحيث تتحكم الحلقة اللاحقة في التكبير. النسب غير معتمدة على وحدات؛ تُقاس مواضع الأشكال وأبعادها بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، ولا يؤدي تغيير أبعاد الشكل إلى تكبير أحجام الخطوط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // حساب عوامل المقياس الأفقية والرأسية المستقلة.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="ملاحظة" %}}
تتطلب الجداول معالجة منفصلة: قم بتكبير عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الإجماليين للجدول. قد يبقى ارتفاع الصفوف أكبر من المطلوب إذا كان محتوى الخلية يتطلب مساحة أكبر.
{{% /alert %}}

المثال الثاني يدعم الجداول ويعالج الأشكال على الماستر والتصاميم بالإضافة إلى الشرائح الفردية قبل حفظ العرض التقديمي المُعدّل. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) عن طريق تكبير عرض الأعمدة باستخدام [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) والارتفاع الأدنى للصفوف باستخدام [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). ثم يقوم بتكبير موضع الجدول دون تكبير أبعاده الإجمالية بشكل منفصل.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // أبعاد الجدول يتم التحكم فيها بواسطة عرض الأعمدة وارتفاع الصفوف.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // احسب عوامل المقياس الأفقية والرأسية المستقلة.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // قم بتكبير/تصغير الأشكال المعرفة على الماستر والتصاميم وكذلك الشرائح الفردية.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقطَع بعد تغيير حجم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تكبير الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. أيضاً، يمكن أن يؤدي تكبير العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. المثال الثاني يعالج الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصة النصوص والجداول، لأن هذه الأمثلة لا تُكَبِّر أحجام الخطوط وقد يقيّد محتوى الجدول ارتفاعات الصفوف.

**كيف يمكنني تغيير حجم الجداول عند تعديل حجم الشريحة؟**

قم بتكبير عرض الأعمدة وفق نسبة العرض وارتفاع الصفوف الأدنى وفق نسبة الارتفاع، ثم قم بتكبير موضع الجدول دون تكبير أبعاده الإجمالية بشكل منفصل، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التغيير في الحجم على شرائح الماستر وشرائح التصميم؟**

نعم. المثال الثاني يتجول عبر [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) وعلى كل ماستر عبر [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) ويطبق نفس منطق تعديل الحجم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تعديل الحجم؟**

نعم. استدعِ [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، حتى تعكس عوامل التكبير الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تعيينه؟**

يمكنك تحديد أبعاد مخصصة للشريحة باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). كما تعتمد الأبعاد المدعومة على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشوه الأشكال ذات النسبة الثابتة؟**

استخدم نفس عامل التكبير للعرض والارتفاع. لضبط التخطيط الأصلي ضمن أبعاد الشريحة الجديدة، استخدم النسبة الأصغر بين نسبة العرض ونسبة الارتفاع لكل من الأبعاد والمواضع. هذا يحافظ على النسب ولكن قد يترك مساحة غير مستخدمة على أحد الأطراف.