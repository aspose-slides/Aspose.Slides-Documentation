---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام C++
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/cpp/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية مخفية
- مخطط المنظمة
- مخطط منظمة بالصور
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرّف على بناء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides للغة C++ من خلال عينات شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد، وأشكال العقد، وتخطيط. باستخدام Aspose.Slides for C++، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط المنظمة، وإنشاء مخططات منظمة بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص من أشكال العقدة، قم بالتكرار عبر [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/)، ثم اقرأ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) الذي تُرجعه [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

يتطلب المثال عرض تقديمي يحتوي على شريحة واحدة على الأقل وكائن SmartArt كشكل أول في تلك الشريحة. يقوم بطباعة كل إطار نص متاح إلى وحدة التحكم.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`، ويغيّرها إلى القيمة `BasicProcess`، ثم يحفظ العرض التقديمي. يتم قياس الموضع والحجم الممررين إلى [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) بالنقاط. استخدم [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) لتغيير التخطيط.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن تكون العقد المخفية موجودة في الهيكل حتى عندما لا يعرض التخطيط المحددها كعناصر مخطط مرئية.

يضيف المثال التالي عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` ويفحص حالة الإخفاء للعقدة المضافة. يطبع رسالة إذا كانت العقدة مخفية ويحفظ المخطط.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الحصول على تخطيط مخطط المنظمة أو تعيينه**

بالنسبة إلى مخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، تحدد [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) و[ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك تعيين العقد الفرعية لتتدلى من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

ينشئ المثال التالي مخطط منظمة ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. يختار الفهرس الصفري `0` العقدة العليا الأولى؛ وتستخدم عقدها الفرعية الترتيب المحدد. ثم يُحفظ العرض التقديمي المعدل.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **إنشاء مخطط منظمة بالصور**

مخطط منظمة بالصور هو تخطيط SmartArt مصمم لمخططات الهرمية التي تتضمن نواقل صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة. يحفظ هذا المثال مخططًا يحتوي على نواقل صور؛ لكنه لا يملأ النواقل بالصور.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تحديث مخطط منظمة تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثل Aspose.Slides هذه المخططات القديمة ككائنات [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). استخدم [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) لتحويل مخطط إلى مجموعة من الأشكال بحيث يمكنك تعديل العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) للحصول على التفاصيل.

تضيف العملية مجموعة جديدة إلى مجموعة الأشكال دون إزالة المخطط الأصلي. بعد التحويل الناجح، احذف الأصلي باستخدام [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) لتجنب المحتوى المكرر. اجمع المخططات القديمة في متجه قبل تحويلها حتى لا يعيق إضافة وإزالة الأشكال عملية التكرار.

يفتح المثال التالي عرضًا تقديميًا، يبحث في كل شريحة، يحول المخططات إلى مجموعات من الأشكال، ثم يحفظ العرض المحدث كملف PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يحتوي العرض المحفوظ على مجموعات من الأشكال يمكن تحريرها بدلًا من المخططات القديمة المحولة، دون بقاء أي مخططات أصلية بجانبها. افتح ملف PPTX في PowerPoint لتعديل العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموضع.

## **الأسئلة الشائعة**

**هل يدعم SmartArt العكس أو الانعكاس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المحدد العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/cpp/shape-manipulations/) باستخدام [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) أو [استنساخ الشريحة بأكملها](/slides/ar/cpp/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموضع والتنسيق.

**كيف يمكنني تصيير SmartArt إلى صورة نقطية للمعاينة أو للتصدير على الويب؟**

[تصيير الشريحة](/slides/ar/cpp/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تصيير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة كائنات؟**

قم بتعيين قيمة مميزة لـ [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) أو [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) على شكل SmartArt، وابحث عن تلك القيمة في [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/)، ثم تحقق من أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).