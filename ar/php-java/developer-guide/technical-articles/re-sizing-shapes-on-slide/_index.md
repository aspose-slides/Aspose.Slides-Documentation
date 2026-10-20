---
title: "تحجيم الأشكال على شرائح العرض التقديمي في PHP"
type: docs
weight: 130
url: /ar/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /ar/php-java/re-sizing-shapes-on-slide/
keywords:
  - "تحجيم الشكل"
  - "تغيير حجم الشكل"
  - "PowerPoint"
  - "OpenDocument"
  - "عرض تقديمي"
  - "PHP"
  - "Aspose.Slides"
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java—آليًا تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تعديل حجم الأشكال وإعادة ضبط مواضعها لتتناسب مع الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول على الشرائح والماسترات والتصميمات.

## **تغيير حجم الأشكال**

للحفاظ على الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبّق نسبة الارتفاع المقابلة على إحداثياته العمودية وارتفاعه.

المثال الأول يقوم بتحميل عرض تقديمي لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) مع [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدات؛ مواضع الأشكال وأبعادها تُقاس بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، كما أن تعديل أبعاد الشكل لا يغير حجم الخطوط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // احسب عوامل التحجيم الأفقي والعمودي المستقلة.
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

{{% alert color="info" title="ملاحظة" %}}
تتطلب الجداول معالجة منفصلة: قم بتحجيم عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الإجماليين للجدول. قد تظل ارتفاعات الصفوف أكبر من المطلوب إذا كان محتوى الخلية يتطلب مساحة أكبر.
{{% /alert %}}

المثال الثاني يدعم الجداول ويعالج الأشكال على الماسترات والتصميمات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي بعد تغيير حجمه. يتعامل المُساعد الخاص به مع كل [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) عن طريق تحجيم عرض الأعمدة باستخدام [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) والحد الأدنى لارتفاع الصفوف باستخدام [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). ثم يُحجم موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

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
                // أبعاد الجدول يتم التحكم فيها عبر عرض الأعمدة وارتفاعات الصفوف.
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
    // احسب عوامل التحجيم الأفقي والعمودي المستقلة.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // قم بتحجيم الأشكال المعرفة على الماسترات والتصميمات وكذلك الشرائح الفردية.
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

## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقطَع بعد تغيير حجم الشريحة؟**  
إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**  
المثال الأول يغيّر حدود الشكل مباشرةً ويُعنى بالشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصة النصوص والجداول، لأن هذه الأمثلة لا تُحجم أحجام الخطوط ومحتوى الجداول يمكن أن يقيّد ارتفاعات الصفوف.

**كيف أقوم بتغيير حجم الجداول عند تعديل حجم الشريحة؟**  
قم بتحجيم عرض الأعمدة بنسبة عرض الشريحة، والحد الأدنى لارتفاع الصفوف بنسبة ارتفاع الشريحة، ثم حجم موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على ماسترات الشرائح وتصميمات الشرائح؟**  
نعم. المثال الثاني يتنقل عبر [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) وكل [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) للماسترات ويطبق نفس منطق تغيير الحجم على الأشكال الموجودة فيها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تغيير الحجم؟**  
نعم. استدعِ [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، حتى تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تعيينه؟**  
يمكنك تحديد أبعاد مخصصة للشريحة باستخدام [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). كما تعتمد الأبعاد المدعومة على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشويه الأشكال التي لها نسبة أبعاد ثابتة؟**  
استخدم عامل التحجيم نفسه للعرض والارتفاع. لتناسب التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استعمل الأصغر بين نسب العرض والارتفاع لكل من الأبعاد والمواضع. هذا يحافظ على النسب لكنه قد يترك مساحة غير مستخدمة على أحد الحواف.