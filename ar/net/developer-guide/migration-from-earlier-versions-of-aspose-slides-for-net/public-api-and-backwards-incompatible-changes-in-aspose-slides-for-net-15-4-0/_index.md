---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides for .NET 15.4.0"
linktitle: "Aspose.Slides for .NET 15.4.0"
type: docs
weight: 150
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- ترحيل
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides for .NET للترحيل السلس لحلول العروض التقديمية PowerPoint PPT و PPTX و ODP."
---

{{% alert color="primary" %}} 
هذه الصفحة تسرد جميع الفئات أو الأساليب أو الخصائص أو غيرها من العناصر التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 15.4.0 API.
{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة Enum OrganizationChartLayoutType**
يُمثل تعداد Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع تنسيق العقد الفرعية في مخطط المنظمة.
#### **تمت إضافة طريقة IBulletFormat.ApplyDefaultParagraphIndentsShifts**
طريقة Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts تُعيّن الإزاحات غير الصفرية الافتراضية للمسافة البادئة للفقرة (Indent) والهوامش اليسرى (MarginLeft) عندما تكون النقاط مفعّلة (كما تفعل PowerPoint عند تمكين النقاط/الترقيم للفقرة). إذا كانت النقاط معطّلة يتم فقط إعادة تعيين المسافة البادئة والهوامش اليسرى (كما تفعل PowerPoint عند تعطيل النقاط/الترقيم للفقرة).

اطلع على الأمثلة [here](/slides/ar/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **تمت إضافة طريقة IConnector.Reroute**
طريقة Aspose.Slides.IConnector.Reroute تعيد توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الشكلين المتصلين. للقيام بذلك قد تقوم طريقة Reroute() بتغيير الخاصيتين StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex.

``` csharp
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
#### **تمت إضافة طريقة IPresentation.GetSlideById**
طريقة Aspose.Slides.IPresentation.GetSlideById(System.UInt32) تُعيد شريحة Slide أو MasterSlide أو LayoutSlide بحسب معرف الشريحة.

``` csharp
using (Presentation presentation = new Presentation())
{
    uint id = presentation.Slides[0].SlideId;
    IBaseSlide slide = presentation.GetSlideById(id);
    Debug.Assert(presentation.Slides[0] == slide);
}
``` 
#### **تمت إضافة خاصية IShape.ConnectionSiteCount**
خاصية Aspose.Slides.IShape.ConnectionSiteCount تُعيد عدد مواقع الاتصال على الشكل.

``` csharp
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
#### **تمت إضافة خاصية ISmartArt.IsReversed**
خاصية Aspose.Slides.SmartArt.ISmartArt.IsReversed تسمح بالحصول على حالة مخطط SmartArt أو تعيينها فيما يتعلق بالاتجاه من اليسار إلى اليمين (LTR) أو من اليمين إلى اليسار (RTL) إذا كان المخطط يدعم الانعكاس.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
  smart.IsReversed = true;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **تمت إضافة خاصية ISmartArt.Nodes**
خاصية Aspose.Slides.SmartArt.ISmartArt.Nodes تُعيد مجموعة الجذور في كائن SmartArt.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);
  ISmartArtNode node = smart.Nodes[1]; // اختيار العقدة الجذرية الثانية
  node.TextFrame.Text = "Second root node";
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **تمت إضافة خاصية ISmartArtNode.IsHidden**
خاصية Aspose.Slides.SmartArt.ISmartArtNode.IsHidden تُعيد true إذا كانت هذه العقدة مخفية في نموذج البيانات.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
  ISmartArtNode node = smart.AllNodes.AddNode();
  bool hidden = node.IsHidden; // returns true
  if(hidden)
  {
    // قم ببعض الإجراءات أو الإشعارات
  }
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **تمت إضافة خاصية ISmartArtNode.OrganizationChartLayout**
خاصية Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout تسمح بالحصول على نوع مخطط المنظمة المرتبط بالعقدة الحالية أو تعيينه.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **تمت إضافة طريقة تعيين للخاصية ISmartArt.Layout**
تمت إضافة طريقة تعيين للخاصية Aspose.Slides.SmartArt.ISmartArt.Layout. تسمح بتغيير نوع تخطيط مخطط موجود.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
  smart.Layout = SmartArtLayoutType.BasicProcess;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **تغييرات API طفيفة**
**هذه هي قائمة التغييرات الطفيفة في API:**

|Enum Aspose.Slides.BevelColorMode |محذوف، تعداد غير مستخدم |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |محذوف، خاصية غير مستخدمة |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |مضافة |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |محذوف |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |محذوف باعتباره غير صالح |