---
title: تغيير حجم الأشكال في شرائح العرض التقديمي
type: docs
weight: 100
url: /ar/cpp/re-sizing-shapes-on-slide/
keywords:
- تغيير حجم الشكل
- تعديل حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قُم بتغيير حجم الأشكال بسهولة في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++ - قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---

## **نظرة عامة**

إحدى أكثر الأسئلة شيوعًا من عملاء Aspose.Slides للغة C++ هي كيفية تغيير حجم الأشكال بحيث لا يتم قطع البيانات عندما يتغير حجم الشريحة. تُظهر هذه المقالة التقنية المختصرة كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع تشويه الأشكال عندما يتغير حجم الشريحة، قم بتحديث موضع كل شكل وأبعاده لتتوافق مع تخطيط الشريحة الجديد.
```cpp
// تحميل ملف العرض التقديمي.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// الحصول على حجم الشريحة الأصلي.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغيير حجم الشريحة دون تعديل حجم الأشكال الحالية.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// الحصول على حجم الشريحة الجديد.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// إعادة تحجيم وإعادة وضع الأشكال على كل شريحة.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // تحجيم حجم الشكل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // تحجيم موضع الشكل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}} 

إذا احتوت الشريحة على جدول، فإن الكود أعلاه لن يعمل بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.

{{% /alert %}} 

استخدم الكود التالي لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، يُعد ضبط العرض أو الارتفاع حالة خاصة: يجب تعديل ارتفاعات الصفوف وعروض الأعمدة الفردية لتغيير الحجم الكلي للجدول.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// احصل على حجم الشريحة الأصلي.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// غيّر حجم الشريحة دون تعديل حجم الأشكال الحالية.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// احصل على حجم الشريحة الجديد.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // تحجيم حجم الشكل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // تحجيم موضع الشكل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // تحجيم حجم الشكل.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // تحجيم موضع الشكل.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // تحجيم حجم الشكل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // تحجيم موضع الشكل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الأسئلة المتكررة**

**لماذا تتشوه الأشكال أو تُقَطَع بعد تغيير حجم الشريحة؟**  

عند تغيير حجم الشريحة، تحتفظ الأشكال بموقعها وحجمها الأصليين ما لم يتم تغيير المقياس صراحةً. قد يؤدي ذلك إلى قص المحتوى أو تشويه الأشكال.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**  

المثال الأساسي يعمل مع معظم أنواع الأشكال (صناديق النص، الصور، المخططات، إلخ). ومع ذلك، بالنسبة للجداول، تحتاج إلى التعامل مع الصفوف والأعمدة بشكل منفصل، لأن ارتفاع وعرض الجدول يُحدَّدان بأبعاد الخلايا الفردية.

**كيف أقوم بتغيير حجم الجداول عند تغيير حجم الشريحة؟**  

يجب عليك المرور على جميع الصفوف والأعمدة في الجدول وتغيير ارتفاعها وعرضها بصورة نسبة، كما هو موضح في مثال الكود الثاني.

**هل سيعمل هذا التغيير على الشرائح الرئيسية وشرائح التخطيط؟**  

نعم، لكن عليك أيضًا المرور على [الماسترات](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) و[شرائح التخطيط](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) وتطبيق نفس منطق التحجيم على أشكالها لضمان التناسق عبر العرض التقديمي.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تغيير الحجم؟**  

نعم. يمكنك استخدام [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/) لتغيير الاتجاه. تأكد من ضبط منطق التحجيم وفقًا لذلك للحفاظ على التخطيط.

**هل هناك حد لحجم الشريحة الذي يمكن تحديده؟**  

يدعم Aspose.Slides أحجامًا مخصصة، لكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

**كيف يمكنني منع تشويه الأشكال ذات نسبة الأبعاد الثابتة؟**  

يمكنك فحص طريقة `get_AspectRatioLocked` للشكل قبل التحجيم. إذا كانت مُقَفلة، قم بضبط العرض أو الارتفاع بشكل نسبي بدلاً من تحجيمهما بشكل منفصل.