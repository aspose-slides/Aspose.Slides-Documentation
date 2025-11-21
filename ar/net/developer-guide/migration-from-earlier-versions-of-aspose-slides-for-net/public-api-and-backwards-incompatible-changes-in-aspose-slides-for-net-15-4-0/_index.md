---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 15.4.0
linktitle: Aspose.Slides لـ .NET 15.4.0
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint PPT، PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تُدرج جميع الفئات [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) أو [المحذوفة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)، والطرق، والخصائص وما إلى ذلك، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
#### **تم إضافة تعداد OrganizationChartLayoutType**
يُمثل تعداد Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع تنسيق العقد الفرعية في مخطط تنظيمي.
#### **تم إضافة طريقة IBulletFormat.ApplyDefaultParagraphIndentsShifts**
طريقة Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts تضبط الانزاحات الافتراضية غير الصفرية للفقرة الفعّالة للهوامش اليسرى والبادئة عندما تكون الرصاصات مفعلة (كما يفعل PowerPoint إذا تم تمكين رصاصات/تعداد الفقرة فيه). إذا تم تعطيل الرصاصات فإنها تعيد ضبط الهوامش اليسرى والبادئة (كما يفعل PowerPoint إذا تم تعطيل رصاصات/تعداد الفقرة فيه).

انظر أمثلة [هنا](/slides/ar/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **تم إضافة طريقة IConnector.Reroute**
طريقة Aspose.Slides.IConnector.Reroute تعيد توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الأشكال التي يربطها. للقيام بذلك، قد تقوم طريقة Reroute() بتغيير StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex.

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
#### **تم إضافة طريقة IPresentation.GetSlideById**
طريقة Aspose.Slides.IPresentation.GetSlideById(System.UInt32) تُعيد شريحة Slide أو MasterSlide أو LayoutSlide بحسب معرف الشريحة.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **تم إضافة خاصية IShape.ConnectionSiteCount**
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
#### **تم إضافة خاصية ISmartArt.IsReversed**
خاصية Aspose.Slides.SmartArt.ISmartArt.IsReversed تتيح الحصول أو ضبط حالة مخطط SmartArt بالنسبة إلى (من اليسار إلى اليمين) LTR أو (من اليمين إلى اليسار) RTL، إذا كان المخطط يدعم العكس.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تم إضافة خاصية ISmartArt.Nodes**
خاصية Aspose.Slides.SmartArt.ISmartArt.Nodes تُعيد مجموعة العقد الجذرية في كائن SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // select second root node

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تم إضافة خاصية ISmartArtNode.IsHidden**
خاصية Aspose.Slides.SmartArt.ISmartArtNode.IsHidden تُعيد true إذا كانت هذه العقدة مخفية في نموذج البيانات.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returns true

  if(hidden)

  {

    //do some actions or notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تم إضافة خاصية ISmartArtNode.OrganizationChartLayout**
خاصية Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout تتيح الحصول أو ضبط نوع مخطط التنظيم المرتبط بالعقدة الحالية.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تم إضافة طريقة الضبط للخاصية ISmartArt.Layout**
تم إضافة طريقة الضبط للخاصية Aspose.Slides.SmartArt.ISmartArt.Layout. تتيح تغيير نوع تخطيط مخطط موجود.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تغييرات API صغيرة**
**هذه هي قائمة التغييرات الصغيرة في API:**

|Enum Aspose.Slides.BevelColorMode |محذوف، تعداد غير مستخدم |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |محذوف، خاصية غير مستخدمة |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |مضافة |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |محذوف |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |محذوفة لأنها قديمة |