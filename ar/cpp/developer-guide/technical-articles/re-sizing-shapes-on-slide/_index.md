---
title: تحجيم الأشكال على شرائح العرض التقديمي في C++
type: docs
weight: 130
url: /ar/cpp/resizing-shapes-on-slide/
aliases:
  - /ar/cpp/re-sizing-shapes-on-slide/
  /cpp/re-sizing-shapes-on-slide/
keywords:
  - تحجيم الشكل
  - تغيير حجم الشكل
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - C++
  - Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ C++ — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة عرض تقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة وضعها لتناسب الأبعاد الجديدة. يوضح هذا المقال كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول في الشرائح، والماسترات، والتخطيطات.

## **تحجيم الأشكال**

للحفاظ على الوضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبق نسبة الارتفاع المقابلة على إحداثياته الرأسية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغير حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) مع [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب ليست ذات وحدة؛ مواضع الأشكال وأبعادها تُقاس بالنقاط. يمكن أن تُشوه النسب المختلفة للعرض والارتفاع الأشكال، وتغيير أبعاد الشكل لا يغير أحجام الخطوط الخاصة به.

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

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: قم بتحجيم أعرض الأعمدة وارتفاعات الصفوف بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد تظل ارتفاعات الصفوف أكبر مما طُلب إذا كان محتوى الخلية يحتاج إلى مساحة إضافية.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال في الماسترات والتخطيطات بالإضافة إلى الشرائح الفردية قبل حفظ العرض التقديمي المُعدل. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) من خلال تحجيم [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) و[IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). ثم يحجم موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

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
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// احسب عوامل التحجيم الأفقية والعمودية المستقلة.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // أبعاد الجدول تتحكم فيها أعرض الأعمدة وارتفاعات الصفوف.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// تحجيم الأشكال المعرفة على الماسترات والتخطيطات وكذلك الشرائح الفردية.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة الشائعة**

**لماذا تُشوه الأشكال أو تُقطع بعد تغيير حجم الشريحة؟**

إذا غيرت حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواضعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

المثال الأول يغير حدود الشكل مباشرةً ومُصمم للشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصة النص والجداول، لأن هذه الأمثلة لا تحجم أحجام الخطوط ويمكن لمحتوى الجدول أن يقيّد ارتفاعات الصفوف.

**كيف يمكنني تحجيم الجداول عند تغيير حجم الشريحة؟**

قم بتحجيم أعرض الأعمدة بنسبة عرض الشريحة وارتفاعات الصفوف الدنيا بنسبة ارتفاع الشريحة، ثم حجم موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم مع شرائح الماستر وشرائح التخطيط؟**

نعم. يت iterates المثال الثاني عبر [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) وكل [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) للماستر ويطبق نفس منطق التحجيم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. اضبط [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع الأشكال ذات النسبة الثابتة من التشويه؟**

استخدم عامل التحجيم نفسه للعرض والارتفاع. لتناسب التخطيط الأصلي ضمن أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكل من الأبعاد والمواضع. هذا يحافظ على النسب ولكنه قد يترك مساحة غير مستخدمة على أحد الجوانب.