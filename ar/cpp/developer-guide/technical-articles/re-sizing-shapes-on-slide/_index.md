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
description: "قم بتغيير حجم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++ — قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

إحدى الأسئلة الأكثر شيوعًا من عملاء Aspose.Slides للغة C++ هي كيفية تغيير حجم الأشكال بحيث لا يتم قطع البيانات عندما يتغير حجم الشريحة. يوضح هذا المقال الفني القصير كيفية القيام بذلك.

## **تغيير حجم الأشكال**

لمنع تشوه الأشكال عندما يتغير حجم الشريحة، قم بتحديث موضع كل شكل وأبعاده لتتوافق مع تخطيط الشريحة الجديد.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// تحميل ملف العرض التقديمي.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Change the slide size without scaling existing shapes.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // تغيير حجم الشكل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // تغيير موضع الشكل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 

إذا كانت الشريحة تحتوي على جدول، فإن الكود أعلاه لن يعمل بشكل صحيح. في هذه الحالة، يجب تغيير حجم كل خلية في الجدول.

{{% /alert %}} 

استخدم الكود التالي على جانبك لتغيير حجم الشرائح التي تحتوي على جداول. بالنسبة للجداول، يعتبر ضبط العرض أو الارتفاع حالة خاصة: يجب تعديل ارتفاعات الصفوف الفردية وعروض الأعمدة لتغيير الحجم الكلي للجدول.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// احصل على حجم الشريحة الأصلي.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// غيّر حجم الشريحة بدون تحجيم الأشكال الموجودة.
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

### لماذا تتشوه الأشكال أو تُقَصّ بعد تعديل حجم الشريحة؟

عند تعديل حجم الشريحة، تحتفظ الأشكال بموضعها وحجمها الأصليين ما لم يتم تغيير المقياس صراحةً. هذا قد يؤدي إلى قطع المحتوى أو تشوش الأشكال.

### هل يعمل الكود المقدم مع جميع أنواع الأشكال؟

يعمل المثال الأساسي مع معظم أنواع الأشكال (صناديق النص، الصور، المخططات، إلخ). ومع ذلك، بالنسبة للجداول، تحتاج إلى معالجة الصفوف والأعمدة بشكل منفصل، لأن ارتفاع وعرض الجدول يحددهما أبعاد الخلايا الفردية.

### كيف يمكن تغيير حجم الجداول عند تعديل حجم الشريحة؟

يجب عليك التنقل عبر جميع الصفوف والأعمدة في الجدول وتغيير ارتفاعها وعرضها بنسبة مئوية، كما هو موضح في مثال الكود الثاني.

### هل سيعمل هذا التغيير على الشرائح الرئيسية وشرائح التخطيط؟

نعم، ولكن يجب أيضًا التنقل عبر [Masters](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_masters/) و[Layout slides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_layoutslides/) وتطبيق نفس منطق التحجيم على أشكالها لضمان الاتساق عبر العرض التقديمي.

### هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تعديل الحجم؟

نعم. يمكنك استخدام [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidesize/set_orientation/) لتغيير الاتجاه. تأكد من ضبط منطق التحجيم وفقًا لذلك للحفاظ على التخطيط.

### هل هناك حد لحجم الشريحة يمكنني ضبطه؟

يدعم Aspose.Slides الأحجام المخصصة، ولكن الأحجام الكبيرة جدًا قد تؤثر على الأداء أو التوافق مع بعض إصدارات PowerPoint.

### كيف يمكنني منع تشوه الأشكال ذات النسبة الثابتة؟

يمكنك التحقق من طريقة `get_AspectRatioLocked` الخاصة بالشكل قبل التحجيم. إذا كانت النسبة مقفلة، قم بضبط العرض أو الارتفاع بنسبة مئوية بدلاً من تحجيمهما بشكل منفصل.