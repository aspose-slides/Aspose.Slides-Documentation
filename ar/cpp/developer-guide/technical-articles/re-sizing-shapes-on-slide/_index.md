---
title: تحجيم الأشكال على شرائح العرض التقديمي بلغة C++
type: docs
weight: 130
url: /ar/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /ar/cpp/re-sizing-shapes-on-slide/
keywords:
  - تحجيم الشكل
  - تغيير حجم الشكل
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - C++
  - Aspose.Slides
description: "قم بتحجيم الأشكال بسهولة على شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++ — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغييرك لحجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تعديل حجم الأشكال وإعادة وضعها لتتناسب مع الأبعاد الجديدة. توضح هذه المقالة كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول في الشرائح، والماستر، وتخطيطات الشرائح.

## **تحجيم الأشكال**

للحفاظ على الموضع النسبي والحجم لكل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديدة إلى العرض الأصلي. طبق نسبة الارتفاع المقابلة على إحداثياته الرأسية وارتفاعه.

المثال الأول يحمل عرض تقديمي لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) مع [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدة؛ مواضع الأشكال وأبعادها مقاسة بالنقاط. يمكن أن تؤدي نسب العرض والارتفاع المختلفة إلى تشويه الأشكال، وتغيير أبعاد الشكل لا يحجّم أحجام الخطوط.

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
تتطلب الجداول معالجة منفصلة: قم بتحجيم عرض أعمدتها وارتفاع صفوفها بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد تبقى ارتفاعات الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال في الماستر والتخطيطات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي المعاد تحجيمه. يتعامل المساعد الخاص به مع كل [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) عبر تحجيم [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) و [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). ثم يحجّم موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

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
            // أبعاد الجدول تتحكم فيها عرض الأعمدة وارتفاع الصفوف.
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

// تحجيم الأشكال المعرفة على الماستر والتخطيطات وكذلك الشرائح الفردية.
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

## **الأسئلة المتكررة**

**لماذا تتشوه الأشكال أو تُقَصّ بعد تحجيم الشريحة؟**

إذا قمت بتغيير حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم لجميع أنواع الأشكال؟**

المثال الأول يغيّر حدود الشكل مباشرةً وهو مخصص للشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خصوصًا النص والجداول، لأن هذه الأمثلة لا تحجّم أحجام الخطوط وقد يحد محتوى الجدول من ارتفاع الصفوف.

**كيف أقوم بتحجيم الجداول عند تحجيم الشريحة؟**

قم بتحجيم عرض الأعمدة بنسبة عرض الشريحة، وارتفاع الحد الأدنى للصفوف بنسبة ارتفاع الشريحة، ثم احجّم موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على شرائح الماستر وتخطيطات الشرائح؟**

نعم. يتنقل المثال الثاني عبر [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) وكل [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) للماستر، ويطبق نفس منطق التحجيم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. حدد [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد مخصصة للشريحة باستخدام [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشويه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكلا البعدين والمواضع. هذا يحافظ على النسب ولكن قد يترك مساحة غير مستخدمة على أحد الجوانب.