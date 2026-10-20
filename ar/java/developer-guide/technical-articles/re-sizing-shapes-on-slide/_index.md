---
title: تحجيم الأشكال على شرائح العرض التقديمي في Java
type: docs
weight: 130
url: /ar/java/resizing-shapes-on-slide/
aliases:
  - /ar/java/re-sizing-shapes-on-slide/
  /java/تحجيم-الأشكال-على-الشريحة/
keywords:
- تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Java—قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة وضعها لتناسب الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأ shapes يدويًا وكيفية التعامل مع الجداول في الشرائح، والماستر، والتنسيقات.

## **تحجيم الأشكال**

للحفاظ على موضع وحجم كل شكل نسبةً إلى الآخر، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبّق نسبة الارتفاع المقابلة على إحداثياته الرأسية وارتفاعه.

يقوم المثال الأول بتحميل عرض تقديمي لا تحتوي شرائحه على جداول، ويغيّر حجم الشريحة إلى A4، ثم يحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) بحيث تتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدات؛ يتم قياس مواضع الأشكال وأبعادها بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، وتغيير أبعاد الشكل لا يحوّل أحجام الخطوط.

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

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: قم بتحجيم أعمدةها وعرضها وارتفاعات الصفوف بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد تبقى ارتفاعات الصفوف أكبر من المطلوبة إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال في الماستر والتنسيقات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي معاد التحجيم. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) من خلال تحجيم عرض الأعمدة باستخدام [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) وارتفاعات الصف الأدنى باستخدام [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). ثم يحوّل موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // أبعاد الجدول يتم التحكم فيها بواسطة عرض الأعمدة وارتفاعات الصفوف.
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

    // تحجيم الأشكال المعرفة على الماستر والتنسيقات بالإضافة إلى الشرائح الفردية.
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

## **الأسئلة المتكررة**

**لماذا تتشوه أو تُقَطَع الأشكال بعد تغيير حجم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواضعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشوه الأشكال أيضاً.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً وهو مخصص للشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، لا سيما النصوص والجداول، لأن هذه الأمثلة لا تحوّل أحجام الخط ويمكن لمحتوى الجدول أن يحد من ارتفاعات الصفوف.

**كيف يمكنني تغيير حجم الجداول عند تغيير حجم الشريحة؟**

احسب عرض الأعمدة بنسبة عرض الشريحة الجديدة، وارتفاعات الصف الأدنى بنسبة الارتفاع، ثم قم بتحجيم موضع الجدول كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على شرائح الماستر وشرائح التخطيط؟**

نعم. يتنقل المثال الثاني عبر [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) وكل [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) لكل ماستر، ويطبق نفس منطق التحجيم على أعضائه.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. استدعِ [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). تعتمد الأبعاد المدعومة أيضاً على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشوه الأشكال ذات نسبة الأبعاد الثابتة؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتناسب التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكلا البعدين والمواضع. هذا يحافظ على النسب ولكنه قد يترك مساحة غير مُستخدمة على أحد الجوانب.