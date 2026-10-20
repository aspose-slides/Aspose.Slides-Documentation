---
title: تحجيم الأشكال على شرائح العرض التقديمي في جافا
type: docs
weight: 130
url: /ar/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /ar/java/re-sizing-shapes-on-slide/
keywords:
- تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لجافا—قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغييرك لحجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة وضعها لتلائم الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح، القوالب الرئيسة، والتنسيقات.

## **تحجيم الأشكال**

للحفاظ على الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبّق نسبة الارتفاع المقابلة على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدات؛ يتم قياس مواضع الأشكال وأبعادها بالنقاط. قد تُشوه النسب المختلفة للعرض والارتفاع الأشكال، وتغيير أبعاد الشكل لا يحدّ من أحجام الخطوط.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // احسب عوامل التحجيم الأفقية والرأسية المستقلة.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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
تتطلب الجداول معالجة منفصلة: احسب عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الإجمالي للجدول. قد يبقى ارتفاع الصفوف أكبر مما هو مطلوب إذا كان محتوى الخلية يحتاج إلى مساحة إضافية.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال على القوالب الرئيسة والتنسيقات بالإضافة إلى الشرائح الفردية قبل حفظ العرض التقديمي المُحَجّم. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) عبر تحجيم عرض الأعمدة باستخدام [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) وأدنى ارتفاعات للصفوف باستخدام [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). ثم يحسب موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // أبعاد الجدول تُتحكم بها عبر عرض الأعمدة وارتفاع الصفوف.
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
    // احسب عوامل التحجيم الأفقية والرأسية المستقلة.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // قم بتحجيم الأشكال المعرفة على القوالب الرئيسة والتنسيقات وكذلك على الشرائح الفردية.
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

**لماذا تتشوه الأشكال أو تُقص بعد تغيير حجم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج الشريحة. إن تحجيم العرض والارتفاع بنسب مختلفة قد يسبب أيضًا تشوه الأشكال.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

يقوم المثال الأول بتغيير حدود الشكل مباشرةً ومُصمم للشرائح التي لا تحتوي على جداول. يتعامل المثال الثاني مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خصوصًا النصوص والجداول، لأن هذه الأمثلة لا تقوم بتحجيم أحجام الخط وقد يحد محتوى الجدول من ارتفاع الصفوف.

**كيف يمكنني تغيير حجم الجداول عند تغيير حجم الشريحة؟**

احسب عرض الأعمدة وفقًا لنسبة العرض وارتفاع الصفوف الدنيا وفقًا لنسبة الارتفاع، ثم احسب موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على الشرائح الرئيسية وشرائح التخطيط؟**

نعم. يتنقل المثال الثاني عبر [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) وكل [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) للماستر، ويطبق نفس منطق التحجيم على أشكاله.

**هل يمكنني تغيير اتجاه الشريحة (رأسي/أفقي) مع التحجيم؟**

نعم. استدعِ [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، حتى تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). كما أن الأبعاد المدعومة تعتمد على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع الأشكال ذات نسبة الأبعاد الثابتة من التشوه؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم أصغر نسبة بين عرض وارتفاع لكلا البعدين والمواقع. هذا يحافظ على النسب ولكنه قد يترك مساحة غير مستخدمة على أحد الحواف.