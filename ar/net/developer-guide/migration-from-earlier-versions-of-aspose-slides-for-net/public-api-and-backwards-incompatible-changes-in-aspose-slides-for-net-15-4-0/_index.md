---
title: API العامة والتغييرات غير المتوافقة للخلف في Aspose.Slides لـ .NET 15.4.0
linktitle: Aspose.Slides لـ .NET 15.4.0
type: docs
weight: 150
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- الترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "مراجعة تحديثات API العامة والتغييرات الجذرية في Aspose.Slides لـ .NET للترحيل السلس لحلول عروض PowerPoint PPT، PPTX و ODP الخاصة بك."
---
{{% alert color="info" %}} 

هذه الصفحة تُدرج جميع الفئات، الأساليب، الخصائص وغيرها، التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
#### **تم إضافة Enum OrganizationChartLayoutType**
يمثل تعداد Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع تنسيق العقد الفرعية في مخطط المنظمة.
#### **تم إضافة Method IBulletFormat.ApplyDefaultParagraphIndentsShifts**
تقوم الطريقة Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts بتعيين إزاحات غير صفرية افتراضية للمسافة البادئة للفقرة (Indent) والهامش الأيسر (MarginLeft) عندما تكون القوائم النقطية مفعلة (كما يفعل PowerPoint عند تمكين القوائم النقطية/الترقيم للفقرة). إذا تم تعطيل القوائم النقطية، فإنها تعيد تعيين المسافة البادئة للفقرة والهامش الأيسر (كما يفعل PowerPoint عند تعطيل القوائم النقطية/الترقيم للفقرة).

راجع الأمثلة [هنا](/slides/ar/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **تم إضافة Method IConnector.Reroute**
تقوم الطريقة Aspose.Slides.IConnector.Reroute بإعادة توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الشكلين المتصلين. للقيام بذلك، قد تقوم طريقة Reroute() بتغيير القيم StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **تم إضافة Method IPresentation.GetSlideById**
تُرجع الطريقة Aspose.Slides.IPresentation.GetSlideById(System.UInt32) شريحة (Slide) أو شريحة رئيسية (MasterSlide) أو شريحة تخطيط (LayoutSlide) بناءً على معرف الشريحة.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **تم إضافة Property IShape.ConnectionSiteCount**
تُعيد الخاصية Aspose.Slides.IShape.ConnectionSiteCount عدد نقاط الاتصال على الشكل.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **تم إضافة Property ISmartArt.IsReversed**
تتيح الخاصية Aspose.Slides.SmartArt.ISmartArt.IsReversed الحصول على أو تعيين حالة مخطط SmartArt فيما يتعلق بالاتجاه من اليسار إلى اليمين (LTR) أو من اليمين إلى اليسار (RTL)، إذا كان المخطط يدعم العكس.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **تم إضافة Property ISmartArt.Nodes**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArt.Nodes مجموعة من العقد الجذرية في كائن SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // اختر العقدة الجذرية الثانية

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **تم إضافة Property ISmartArtNode.IsHidden**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.IsHidden القيمة true إذا كانت هذه العقدة مخفية في نموذج البيانات.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //يرجع true

  if(hidden)

  {

    //قم ببعض الإجراءات أو الإشعارات

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **تم إضافة Property ISmartArtNode.OrganizationChartLayout**
تتيح الخاصية Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout الحصول على أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **تم إضافة طريقة set للخاصية ISmartArt.Layout**
تم إضافة طريقة set للخاصية Aspose.Slides.SmartArt.ISmartArt.Layout. تسمح بتغيير نوع التخطيط لمخطط موجود.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **تغييرات طفيفة في واجهة برمجة التطبيقات**
**هذه هي قائمة التغييرات الطفيفة في واجهة برمجة التطبيقات:**

|تعداد Aspose.Slides.BevelColorMode |محذوف، تعداد غير مستخدم |
| :- | :- |
|خاصية ThreeDFormatEffectiveData.BevelColorMode |محذوفة، خاصية غير مستخدمة |
|خاصية Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>خاصية Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |مضافة |
|خاصية Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>وراثة IParagraphFormatEffectiveData من ISlideComponent <br>خاصية Aspose.Slides.IThreeDFormat.AsISlideComponent <br>وراثة IThreeDFormat من ISlideComponent |محذوف |
|خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |محذوف باعتبارها قديمة |