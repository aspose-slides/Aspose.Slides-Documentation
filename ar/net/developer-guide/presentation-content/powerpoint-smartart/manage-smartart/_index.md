---
title: إدارة SmartArt في عروض PowerPoint التقديمية في .NET
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
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides لـ .NET مع أمثلة شفرة C# واضحة تسرع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من عقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides لـ .NET، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط المنظمة، وإنشاء مخططات منظمة بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص من أشكال العقدة، قم بالتكرار عبر [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/)، ثم اقرأ [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) المرجع من [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

يتطلب المثال عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل وكائن SmartArt كشكل أول في تلك الشريحة. يقوم بطباعة كل إطار نص متاح إلى وحدة التحكم.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`، يغيّرها إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي. يتم قياس الموضع والحجم الممررين إلى [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) بالنقاط. قم بتعيين [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) لتغيير التخطيط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) يُشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في الهيكل حتى عندما لا يُظهر التخطيط المحدد العناصر المخططة كمرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة المضافة. يطبع رسالة إذا كانت العقدة مخفية ويحفظ المخطط.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **الحصول على أو تعيين تخطيط مخطط المنظمة**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، يُعرّف [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك تعيين العقد الفرعية لتعلق من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) المحدد.

المثال التالي ينشئ مخطط منظمة ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. يُحدد الفهرس الصفري `0` العقدة العليا الأولى؛ تستخدم العقد الفرعية الترتيب المحدد. يتم بعد ذلك حفظ العرض التقديمي المعدل.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **إنشاء مخطط منظمة بالصور**

مخطط المنظمة بالصور هو تخطيط SmartArt مصمم لمخططات الهيكل الهرمي التي تتضمن نوافير صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة. يحفظ هذا المثال مخططًا بنوافير صور؛ لا يملأ نوافير الصور بالصور.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تحديث مخطط منظمة تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثل Aspose.Slides هذه المخططات القديمة ككائنات [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). استخدم [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) لتحويل مخطط إلى مجموعة من الأشكال بحيث يمكنك تحرير العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) للحصول على التفاصيل.

تضيف عملية التحويل مجموعة جديدة إلى مجموعة الأشكال دون إزالة المخطط الأصلي. بعد إكمال التحويل بنجاح، احذف الأصلي باستخدام [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) لتجنّب المحتوى المكرر. اجمع المخططات القديمة في مصفوفة قبل تحويلها حتى لا يتسبب إضافة وإزالة الأشكال في إيقاف التكرار.

المثال التالي يفتح عرضًا تقديميًا، يبحث في كل شريحة، يحوّل المخططات إلى مجموعات من الأشكال، ويحفظ العرض المحدث كملف PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

يحتوي العرض المحفوظ على مجموعات ألوان قابلة للتعديل بدلاً من المخططات القديمة المحوّلة، دون بقاء أي مخططات أصلية بجانبها. افتح ملف PPTX في PowerPoint لتحرير العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموقع.

## **الأسئلة الشائعة**

**هل يدعم SmartArt انعكاس أو عكس للغات من اليمين إلى اليسار؟**  
نعم. الخاصية [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المحدد الانعكاس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**  
يمكنك [استنساخ شكل SmartArt](/slides/ar/net/shape-manipulations/) باستخدام [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) أو [استنساخ الشريحة بالكامل](/slides/ar/net/clone-slides/) التي تحتوي على SmartArt. كلا النهجين يحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني تصيير SmartArt إلى صورة نقطية للمعاينة أو لتصدير الويب؟**  
[تصيير الشريحة](/slides/ar/net/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تصيير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد على شريحة إذا كان هناك عدة كائنات؟**  
قم بتعيين قيمة مميزة لـ [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) أو [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) على شكل SmartArt، ابحث عن تلك القيمة في [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)، ثم تحقق من أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).