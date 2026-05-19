---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام .NET
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/net/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية مخفية
- مخطط المنظمة
- مخطط منظمة بالصور
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides لـ .NET مع عينات كود C# واضحة تسرع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكون من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides for .NET، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط المنظمة، وإنشاء مخططات منظمة بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن لعقدة SmartArt احتواء شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [ISmartArt.AllNodes](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartart/allnodes/)، ثم اقرأ الـ[ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/) التي تم إرجاعها بواسطة [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`، ويغيّرها إلى القيمة `BasicProcess`، ثم يحفظ العرض التقديمي.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartartnode/ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد عقد مخفية في البنية حتى عندما لا يعرض التخطيط المحددها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **الحصول على أو تعيين تخطيط مخطط المنظمة**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، يحدد [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك ضبط العقد الفرعية لتتدلى من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/organizationchartlayouttype/) المحدد.

المثال التالي ينشئ مخطط منظمة ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **إنشاء مخطط منظمة بصورة**

مخطط المنظمة بالصورة هو تخطيط SmartArt مصمم لمخططات الهرمية التي تتضمن نوافير صورة. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة المتكررة**

**هل يدعم SmartArt النسخ أو العكس للغات من اليمين إلى اليسار؟**

نعم. الخاصية [IsReversed](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/smartart/isreversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المحدد العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/net/shape-manipulations/) باستخدام [ShapeCollection.AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/shapecollection/addclone/) أو [استنساخ الشريحة بأكملها](/slides/ar/net/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموضع والتنسيق.

**كيف أقوم بعرض SmartArt كصورة نقطية للمعاينة أو التصدير إلى الويب؟**

[اعرض الشريحة](/slides/ar/net/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم عرض SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة؟**

قم بتعيين قيمة مميزة لـ[AlternativeText](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/alternativetext/) أو [Name](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/name/) على شكل SmartArt، ابحث عن تلك القيمة في [Slide.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides/baseslide/shapes/)، ثم تحقق من أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/ismartart/).