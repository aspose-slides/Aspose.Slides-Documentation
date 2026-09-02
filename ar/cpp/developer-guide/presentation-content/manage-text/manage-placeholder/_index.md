---
title: إدارة عناصر النائب في العروض التقديمية بلغة C++
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/cpp/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص إرشادي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير عناصر النائب النصية، الصورة، المخطط، والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موقعًا لنوع معين من المحتوى في قالب عرض تقديمي. من الأمثلة الشائعة العناوين، الجسم، الصورة، المخطط، وعناصر المحتوى العامة. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة التخطيط أو الشريحة الرئيسية.

Aspose.Slides تطرح معلومات العنصر النائب من خلال طريقة [IShape::get_Placeholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_placeholder/) . تُعيد الطريقة كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iplaceholder/) أو `nullptr` لشكل عادي. استخدم [IPlaceholder::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iplaceholder/get_type/) لتحديد ما يُقصد للعنصر النائب أن يحتويه.

لا يزال واجهة الشكل ذات أهمية بعد معرفة نوع العنصر النائب:

- عنصر نائب نص، صورة، مخطط أو محتوى فارغ يُمثَّل عادةً بـ [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) .
- عنصر نائب صورة مُعبأ يمكن تمثيله بـ [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) .
- عنصر نائب مخطط مُعبأ يمكن تمثيله بـ [IChart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/) .
- عنصر نائب محتوى يمكن أن يحتوي عدة أنواع من المحتوى. افحص كلًّا من [IPlaceholder::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iplaceholder/get_type/) وواجهة الشكل في وقت التشغيل بدلاً من الافتراض بأن كل عنصر نائب هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) .

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iplaceholder/get_type/) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى الأعضاء المتخصصة في النص أو الصورة أو المخطط أو الجدول أو الوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تُنشئ هيكلًا هرميًا:

1. تُعرّف الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات العناصر النائبة على مستوى الرئيسي.
2. تُعرّف شريحة التخطيط التوزيع الذي تُستخدمه شريحة أو أكثر عادية ويمكن أن ترث من الرئيسي.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكن أن ترث من التخطيط الخاص بها.

استدعِ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getbaseplaceholder/) للتحرك بمستوى واحد أعلى في هذا الهرم. عادةً ما تُعيد شريحة العنصر النائب العنصر النائب في التخطيط؛ ويمكن لعناصر النائب في التخطيط أن تُعيد العنصر النائب في الرئيسي. تُعيد الطريقة `nullptr` عندما لا يكون للشكل عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويُبلغ عن عناصرها النائبة الأساسية:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

تحرير عنصر نائب في شريحة عادية يُنشئ أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيسي المتعلق يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث ذلك الإعداد. الشكل العادي المحلي لا يملك عنصر نائب أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في عنصر نائب**

عادةً ما تدعم عناوين، عناوين مُوسَّطة، عناوين فرعية، أجسام، وعناصر نصية النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) قبل استخدام طريقة [get_TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/get_textframe/) الخاصة به.

المثال التالي يحدّث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

هذا النمط يتجنب تحويل عناصر النائب للصور أو المخططات أو الجداول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/). كما يحدد العنصر النائب حسب الغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص الإرشاد في التخطيط**

نص الإرشاد هو التعليمات المعروضة في عنصر نائب فارغ أثناء التصميم، مثل *انقر لإضافة عنوان*. عيّن نص إرشاد مخصص في عنصر النائب الخاص بالتخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. يمكنك الوصول إلى التخطيط عبر [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/get_layoutslide/) وتكرار [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/get_shapes/).

المثال التالي يغيّر نصي الإرشاد للعنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

نص الإرشاد ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى فعلي، لم يعد نص الإرشاد معروضًا. تغيير نص الإرشاد لا يستبدل النص الموجود على الشرائح التي تستخدم ذلك التخطيط.

## **تحديث عنصر نائب صورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر النائب للصورة مُعبأً بالفعل ومُمثَّلًا بـ [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/)، استبدل الصورة عبر [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/get_picture/) و [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/set_image/) .
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة في إحداثيات العنصر النائب باستخدام [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addpictureframe/) وأزل العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

الاستبدال المُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصر نائب جديد، لأن [IShape::get_Placeholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_placeholder/) للقراءة فقط. فهو يحتفظ بالموقع المحجوز لكن لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، حضّر العنصر النائب واملأه في PowerPoint أولاً، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، القص، وغير ذلك من التأثيرات الخاصة بالصورة، راجع [Manage Picture Frames](/slides/ar/cpp/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات تعريف العنصر النائب.

## **العمل مع عناصر نائب المخطط والمحتوى**

يمكن تمثيل مخطط مُعبأ بواسطة [IChart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/). هذا المثال يجد مثل هذا المخطط عبر كلٍ من نوع العنصر النائب والواجهة في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

عادةً ما يكون عنصر نائب المحتوى العام له [PlaceholderType::Object](https://reference.aspose.com/slides/ar/cpp/aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق للعديد من أنواع المحتوى، بما في ذلك المخططات، الجداول، المخططات التوضيحية، الصور، والوسائط. بعد تعبئته، افحص واجهة الشكل الفعلية لمعرفة ما يحتويه. يمكن أن تكشف التخطيطات المتخصصة أيضًا عن [PlaceholderType::Chart](https://reference.aspose.com/slides/ar/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Table](https://reference.aspose.com/slides/ar/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/ar/cpp/aspose.slides/placeholdertype/), أو [PlaceholderType::Diagram](https://reference.aspose.com/slides/ar/cpp/aspose.slides/placeholdertype/).

Aspose.Slides لا يحول عنصر نائب [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) فارغ إلى [IChart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/) بمجرد تغيير [IPlaceholder::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iplaceholder/get_type/); النوع للقراءة فقط. لملء مخطط أو مساحة محتوى فارغة برمجيًا، أضف الكائن المطلوب في إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يوضح ذلك لمخطط:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

المخطط المُضاف هو مخطط محلي عادي. يحتل مساحة العنصر النائب لكنه لا يرث من عنصر النائب في التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/cpp/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث نص أو محتوى صورة**

المثال التالي من البداية إلى النهاية يفتح قالبًا، يبحث في الشريحة الأولى عن عنوان أو عنصر نائب صورة، يتحقق من نوع العنصر النائب والشكل، يحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال الافتراض بوجود فهرس شكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **الأسئلة الشائعة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل في التخطيط أو الرئيسي الذي يرث منه عنصر نائب آخر. استخدم [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getbaseplaceholder/) لاسترجاعه. الشكل المحلي العادي يُعيد `nullptr` لأنه ليس جزءًا من هيكلية العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص الإرشاد عبر التخطيط، لكن محتوى العنوان الموجود يُخزن على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض التقديمي كله، كرّر على الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ ورقم الشريحة والرأس وتذييل الصفحة؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة، التخطيط، الرئيسي، الملاحظات أو كتيب اليد. راجع [Manage Presentation Header and Footer](/slides/ar/cpp/presentation-header-and-footer/) للحصول على أمثلة كاملة.