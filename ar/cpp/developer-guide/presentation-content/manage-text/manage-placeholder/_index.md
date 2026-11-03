---
title: إدارة عناصر النائب في العرض التقديمي بـ C++
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
- نص توجيهي
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير عناصر النائب للنص، الصورة، المخطط، والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

العنصر النائب هو شكل يحتفظ بموقع لنوع معين من المحتوى في قالب عرض تقديمي. أمثلة شائعة هي العنوان، النص الأساسي، الصورة، المخطط، والعناصر النائبة للمحتوى العامة. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موقعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides تعرض معلومات العنصر النائب من خلال طريقة [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) . ترجع الطريقة كائنًا من نوع [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) أو `nullptr` لشكل عادي. استخدم [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) لتحديد ما يُقصد أن يحتويه العنصر النائب.

ما زال واجهة الشكل مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل العنصر النائب الفارغ للنص أو الصورة أو المخطط أو المحتوى بـ [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) .
- يمكن تمثيل العنصر النائب المملوء للصورة بواسطة [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) .
- يمكن تمثيل العنصر النائب المملوء للمخطط بواسطة [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) .
- يمكن للعنصر النائب للمحتوى أن يحتوي على عدة أنواع من المحتوى. تحقق من كل من [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) وواجهة الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) .

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) يصف دور العنصر النائب؛ لا يضمن نوع الشكل في وقت التشغيل. يجب دائمًا إجراء فحص للنوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تشكل تسلسلًا هرميًا:

1. تحدد شريحة الماستر أنماطًا قابلة لإعادة الاستخدام، وفي بعض الحالات، عناصر نائبة على مستوى الماستر.
2. تحدد شريحة التخطيط الترتيب المستخدم من قبل شريحة واحدة أو أكثر عادية ويمكن أن ترث من الماستر.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكنها أن ترث من تخطيطها.

استدعِ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) للانتقال مستوى واحد أعلى في هذا التسلسل الهرمي. عادةً ما يُعيد العنصر النائب للشريحة العنصر النائب الخاص بالتخطيط؛ ويمكن للعنصر النائب للتخطيط أن يُعيد العنصر النائب للماستر. تُرجع الطريقة `nullptr` عندما لا يكون للشكل عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويُبلغ عن العناصر النائبة الأساسية لها:

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

تحرير عنصر نائب في شريحة عادية ينشئ أو يغير تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الماستر المرتبط قد يؤثر على جميع الشرائح التي لا تزال ترث هذا الإعداد. الشكل العادي المحلي لا يملك عنصرًا نائبًا أساسيًا ولا يبدأ في الوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **إزالة حالة العنصر النائب**

عند تعديل قالب، استخدم [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) لإبقاء كائن موجود كشكل عادي. تُعيد طريقة [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) القيمة `nullptr`، لكن الشكل يبقى في مجموعة الشرائح. على النقيض من ذلك، تحذف [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) الشكل من تلك المجموعة.

المثال التالي يتطلب ملف `template.pptx` يحتوي على شريحة واحدة على الأقل وعنصر نائب نص غير فارغ في الشريحة الأولى. استخدم عنصر نائب بتنسيق موروث من تخطيطه أو ماستر لتلاحظ تأثير إزالة تلك العلاقة. يتحقق المثال من بقاء الشكل نفسه، يستدعي الطريقة مرة أخرى على الشكل العادي الآن، ويحفظ النتيجة.

{{% alert color="warning" title="Warning" %}}
إزالة حالة العنصر النائب لا يحافظ تلقائيًا على إعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات دون تغيير عمداً، لذا قد يبدو الناتج مختلفًا. الشكل الذي يتم وراثة موقعه وحجمه بالكامل قد يصبح إحداثياته وأبعاده صفرًا بعد الاستدعاء ويصبح غير مرئي رغم بقاءه في المجموعة.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // استدعاء الطريقة على شكل عادي ليس له أي تأثير.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

 في حال وجود عنصر نائب مطابق، تطبع الفحوصات الثلاثة القيمة `True`. يبقى النص، لكن قد تتغير المواقف الموروثة مثل الموقع، الحجم، الدوران، الخط، محاذاة الفقرة، هوامش إطار النص، التثبيت العمودي، التعبئة وإعدادات الخط عند إزالة علاقة العنصر النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. راجع [Slide Layout](/slides/ar/cpp/slide-layout/) للمزيد عن التخطيطات.

للحفاظ على المظهر المقصود، احفظ الموقع، الحجم، والدوران المحسوبين قبل الاستدعاء، وانسخ قيم التنسيق الفعّال المطلوبة إلى متغيّرات منفصلة. استدعِ تلك القيم عبر [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), و[ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). لا تعتمد على الاحتفاظ فقط بكائنات التنسيق الفعّال، لأن قيم تنسيق النص قد تتغير بعد إزالة العلاقة. طبّق القيم الملتقطة صراحةً على الشكل العادي بعد ذلك، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة، والخط المستخدم في القالب الخاص بك.

قد تحتاج هندسة الشكل الموروثة أيضًا إلى تعيين صريح عبر [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). بالنسبة لعنصر نائب نص مستطيل، يعني ذلك تعيين [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); قد لا يؤدي استعادة التعبئة والخط فقط إلى استعادة المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيق أكثر تعقيدًا تتطلب معالجة تلك الإعدادات أيضًا.

## **تغيير النص في عنصر نائب**

عادةً ما تدعم عناصر نائب العنوان، والعنوان الأوسط، والعنوان الفرعي، والنص الأساسي، والنص العادي النص. تحقق من وجود [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) قبل استخدام طريقة [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) .

هذا المثال يحدث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب تحويل عناصر نائب الصورة أو المخطط أو الجدول أو الوسائط إلى [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). كما يحدد العنصر النائب حسب الغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص التلميح في التخطيط**

نص التلميح هو التعليمات الخاصة بوقت التصميم المعروضة في عنصر نائب فارغ، مثل *انقر لإضافة عنوان*. عيّن نص تلميح مخصص على عنصر نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. احصل على التخطيط عبر [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) وتكرّر عبر [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/) .

المثال التالي يغيّر تلميحات العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

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

نص التلميح ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، لا يُعرض التلميح بعد ذلك. تغيير التلميح لا يستبدل أيضًا النص الموجود على الشرائح التي تستخدم هذا التخطيط.

## **تحديث عنصر نائب صورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر نائب الصورة مملوءًا بالفعل وممثلاً بـ [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), استبدل الصورة عبر [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) و[ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) .
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) وأزل العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض:

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

الإبدال الذي يُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) للقراءة فقط. يحتفظ بالموقع المحجوز لكنه لم يعد يرث سلوك العنصر النائب. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، قم بإعداد وتعبئة العنصر النائب في PowerPoint أولاً، ثم حدّث [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، والاقتصاص، وغيرها من التأثيرات الخاصة بالصورة، راجع [Manage Picture Frames](/slides/ar/cpp/picture-frame/). تلك العمليات تخص إطار الصورة أو تعبئة الصورة، وليس بيانات تعريف العنصر النائب.

## **العمل مع عناصر نائب المخطط والمحتوى**

يمكن تمثيل عنصر نائب مخطط مملوء بـ [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). هذا المثال يبحث عن مثل هذا المخطط عبر نوع العنصر النائب والواجهة في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

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

عادةً ما يكون للعنصر النائب العام للمحتوى قيمة [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). في PowerPoint يعمل كمنقٍّ للعديد من أنواع المحتوى، بما في ذلك المخططات، الجداول، المخططات البيانية، الصور والوسائط. بعد تعبئته، افحص واجهة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), أو [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) .

Aspose.Slides لا يحول عنصر نائب فارغ من نوع [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) بمجرد تغيير [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); النوع للقراءة فقط. لتعبئة مخطط فارغ أو مساحة محتوى برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يقوم بذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يحتل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم مقالات إدارة المخططات المخصصة [chart management articles](/slides/ar/cpp/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث محتوى النص أو الصورة**

المثال الشامل التالي يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يتحقق من نوع العنصر النائب والشكل، يحدث المحتوى المناسب، ويحفظ المخرج. يتجنب المثال عمدًا افتراض فهرس شكل أو تحويل كل عنصر نائب إلى نفس الواجهة.

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

## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الماستر الذي يرث منه عنصر نائب آخر. استخدم [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) لاسترجاعه. الشكل العادي المحلي يُعيد `nullptr` لأنه ليس جزءًا من تسلسل العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص التلميح عبر التخطيط، لكن محتوى العنوان الموجود يُخزن في الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض بأكمله، كرّر على الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة المناسبة، التخطيط، الماستر، الملاحظات، أو الملاحظات الموزعة. راجع [Manage Presentation Header and Footer](/slides/ar/cpp/presentation-header-and-footer/) للحصول على أمثلة كاملة.