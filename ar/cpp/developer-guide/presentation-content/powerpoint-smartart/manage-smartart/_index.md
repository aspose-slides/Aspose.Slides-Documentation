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
- مخطط تنظيم
- مخطط تنظيم بالصور
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides للغة C++ من خلال أمثلة شفرة واضحة تسرّع تصميم الشرائح وأتمتتها."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides for C++، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخططات التنظيم، وإنشاء مخططات تنظيم بصور.

## **استخراج النص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartart/get_allnodes/)، ثم اقرأ الـ[ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/) الذي يتم إرجاعه من قبل [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في طريقة ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`، ثم يغيّرها إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد عقد مخفية في الهيكل حتى عندما لا يعرض التخطيط المحددها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الحصول على أو تعيين تخطيط مخطط التنظيم**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط تنظيم، يحدد كل من [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) و[ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) طريقة ترتيب العقد الفرعية تحت العقدة الأم. على سبيل المثال، يمكنك تعيين العقد الفرعية لتتدلى من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/organizationchartlayouttype/).

المثال التالي ينشئ مخطط تنظيم ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **إنشاء مخطط تنظيم بصورة**

مخطط التنظيم بالصورة هو تخطيط SmartArt مصمم لمخططات الهرمية التي تتضمن نوافل صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة الشائعة**

**هل يدعم SmartArt المرآة أو العكس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt::set_IsReversed](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartart/set_isreversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [نسخ شكل SmartArt](/slides/ar/cpp/shape-manipulations/) باستخدام [ShapeCollection::AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapecollection/addclone/) أو [نسخ الشريحة كاملة](/slides/ar/cpp/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بتصوير SmartArt كصورة نقطية للمعاينة أو التصدير إلى الويب؟**

يمكنك [تصوير الشريحة](/slides/ar/cpp/convert-powerpoint-to-png/) أو العرض التقديمي كاملًا إلى PNG أو JPEG. يتم تصوير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt معين في شريحة إذا كان هناك عدة كائنات؟**

عيّن قيمة مميزة لـ[Shape::set_AlternativeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/set_alternativetext/) أو لـ[Shape::set_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/set_name/) على شكل SmartArt، وابحث عن تلك القيمة في [BaseSlide::get_Shapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseslide/get_shapes/)، ثم تأكد من أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/ismartart/).