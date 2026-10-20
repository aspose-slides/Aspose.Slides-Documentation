---
title: تحجيم الأشكال على شرائح العرض التقديمي على Android
type: docs
weight: 130
url: /ar/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/re-sizing-shapes-on-slide/
keywords:
  - تحجيم الشكل
  - تغيير حجم الشكل
  - PowerPoint
  - OpenDocument
  - العرض التقديمي
  - Android
  - Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Android عبر Java — أتمتة تعديل تخطيط الشرائح وتعزيز الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تعديل حجم الأشكال وإعادة وضعها لتتناسب مع الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح والسابقة والطبقات.

## **تحجيم الأشكال**

للحفاظ على الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديدة إلى العرض الأصلي. طبق نسبة الارتفاع المقابلة على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) بحيث تتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدة؛ مواضع الأشكال وأبعادها مقاسة بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، وتغيير أبعاد الشكل لا يحفظ أحجام الخطوط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // حساب عوامل مقياس أفقية ور垂ية مستقلة.
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

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: يجب تحجيم عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد تظل ارتفاعات الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال على القوالب والطبقات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي المعاد تحجيمه. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) عن طريق تحجيم عرض الأعمدة باستخدام [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) والحد الأدنى لارتفاع الصفوف باستخدام [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). ثم يقوم بتحجيم موضع الجدول دون تحجيم أبعاده العامة بشكل منفصل.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // أبعاد الجدول تتحكم فيها عرض الأعمدة وارتفاع الصفوف.
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
    // احسب عوامل المقياس الأفقي والعمودي المستقلة.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // قُم بتحجيم الأشكال المعرفة على القوالب والطبقات وكذلك الشرائح الفردية.
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

**لماذا تشوه الأشكال أو تُقطع بعد إعادة تحجيم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها ستبقى في مواضعها وأبعادها الأصلية وقد تمتد خارج الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ومُصمم للشرائح دون جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصة النص والجداول، لأن هذه الأمثلة لا تحجم أحجام الخطوط ومحتوى الجداول يمكن أن يقيّد ارتفاع الصفوف.

**كيف أقوم بإعادة تحجيم الجداول عند تغيير حجم الشريحة؟**

قم بتحجيم عرض الأعمدة بنسبة العرض وارتفاع الصفوف الأدنى بنسبة الارتفاع، ثم احجم موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على الشرائح الرئيسية وشرائح التخطيط؟**

نعم. يتنقّط المثال الثاني عبر [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) و[IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) لكل قالب ويطبق نفس منطق التحجيم على أشكاله.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. استخدم [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، حتى تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد مخصصة للشرائح باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشوه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكلا البعدين والمواضع. يحافظ ذلك على النسب لكن قد يترك مساحة غير مستخدمة على أحد الحواف.