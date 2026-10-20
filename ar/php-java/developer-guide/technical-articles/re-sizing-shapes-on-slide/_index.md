---
title: تغيير حجم الأشكال على شرائح العرض التقديمي باستخدام PHP
type: docs
weight: 130
url: /ar/php-java/resizing-shapes-on-slide/
aliases:
  - /ar/php-java/re-sizing-shapes-on-slide/
keywords:
  - تغيير حجم الشكل
  - تعديل حجم الشكل
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - PHP
  - Aspose.Slides
description: "قُم بسهولة بتغيير حجم الأشكال على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تعديل حجم الأشكال وإعادة وضعها لتتناسب مع الأبعاد الجديدة. يوضح هذا المقال كيفية تكبير الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح، والقوالب، وتنسيقات التخطيط.

## **تعديل حجم الأشكال**

للحفاظ على الموقع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه بنسبة عرض الشريحة الجديد إلى العرض الأصلي. طبق النسبة المقابلة للارتفاع على إحداثياته الرأسية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ثم يحفظ النتيجة. يستخدم [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) مع [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) بحيث يتحكم الحلقة اللاحقة في التكبير. النسب غير مرتبطة بوحدات؛ تُقاس مواقع الأشكال وأبعادها بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، ولا يقوم تغيير أبعاد الشكل بتكبير حجم الخطوط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // احسب عوامل القياس الأفقية والرأسية المستقلة.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

تتطلب الجداول معالجة منفصلة: قم بتكبير عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد يبقى ارتفاع الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة إضافية.

{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال على القوالب وتنسيقات التخطيط بالإضافة إلى الشرائح الفردية قبل حفظ العرض التقديمي المعدل. يتعامل المساعد الخاص به مع كل [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) عن طريق تكبير عرض الأعمدة باستخدام [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) وأقل ارتفاع للصفوف باستخدام [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). ثم يقوم بتكبير موضع الجدول دون تكبير أبعاده الكلية بشكل منفصل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // أبعاد الجدول يتم التحكم فيها عبر عرض الأعمدة وارتفاع الصفوف.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
        // احسب عوامل القياس الأفقية والرأسية المستقلة.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // غير حجم الأشكال المعرفة على القوالب وتنسيقات التخطيط وكذلك على الشرائح الفردية.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**لماذا تتشوه الأشكال أو تُقَطَع بعد تعديل حجم الشريحة؟**

إذا غيرت حجم الشريحة دون تكبير الأشكال، ستظل تحتفظ بأماكنها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن تشوه الأشكال أيضًا إذا تم تكبير العرض والارتفاع بنسب مختلفة.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً ومخصص للشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، وخاصة النصوص والجداول، لأن هذه الأمثلة لا تكبر أحجام الخطوط ويمكن لمحتوى الجدول أن يحد من ارتفاعات الصفوف.

**كيف أقوم بتعديل حجم الجداول عند تعديل حجم الشريحة؟**

قم بتكبير عرض الأعمدة بنسبة عرض الشريحة، وارتفاع الصفوف الأدنى بنسبة ارتفاع الشريحة، ثم قم بتكبير موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التعديل على شرائح القوالب وشرائح التخطيط؟**

نعم. يت遍 المثال الثاني عبر [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) ويعالج كل [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) ويطبق نفس منطق تعديل الحجم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تعديل الحجم؟**

نعم. استدعِ [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، حتى تعكس عوامل التكبير الاتجاه النهائي.

**هل هناك حد أقصى لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشويه الأشكال التي لها نسبة عرض إلى ارتفاع ثابتة؟**

استخدم نفس عامل التكبير للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكلا البُعدين والمواقع. يضمن ذلك الحفاظ على النسب، لكن قد يترك مساحة غير مستخدمة على أحد الحواف.