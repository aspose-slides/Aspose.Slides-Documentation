---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة إلى الخلف في Aspose.Slides لـ .NET 15.4.0"
linktitle: "Aspose.Slides لـ .NET 15.4.0"
type: docs
weight: 150
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- ترحيل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "راجع تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسورة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول العروض التقديمية PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تُدرج جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) أو [إزالتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ، بالإضافة إلى التغييرات الأخرى التي تم إدخالها مع Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تم إضافة تعداد OrganizationChartLayoutType**
يمثل تعداد Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع تنسيق العقد الفرعية في مخطط تنظيم.

#### **تم إضافة طريقة IBulletFormat.ApplyDefaultParagraphIndentsShifts**
تقوم الطريقة Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts بتعيين إزاحات غير صفرية افتراضية لتراجع الفقرة الفعّال وMarginLeft عندما تكون النقاط مفعلة (كما يفعل PowerPoint إذا تم تفعيل نقاط/ترقيم الفقرات). إذا تم إلغاء تفعيل النقاط يتم فقط إعادة تعيين تراجع الفقرة وMarginLeft (كما يفعل PowerPoint إذا تم إلغاء تفعيل نقاط/ترقيم الفقرات).

انظر الأمثلة [هنا](/slides/ar/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):

#### **تم إضافة طريقة IConnector.Reroute**
تقوم الطريقة Aspose.Slides.IConnector.Reroute بإعادة توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الأشكال التي يربطها. للقيام بذلك، قد تقوم طريقة Reroute() بتغيير StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex.

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
تُرجِع الطريقة Aspose.Slides.IPresentation.GetSlideById(System.UInt32) شريحة Slide أو MasterSlide أو LayoutSlide حسب معرف الشريحة.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **تم إضافة خاصية IShape.ConnectionSiteCount**
تُعيد الخاصية Aspose.Slides.IShape.ConnectionSiteCount عدد مواقع الاتصال على الشكل.

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
تسمح الخاصية Aspose.Slides.SmartArt.ISmartArt.IsReversed بالحصول على أو تعيين حالة مخطط SmartArt بالنسبة إلى (من اليسار إلى اليمين) LTR أو (من اليمين إلى اليسار) RTL، إذا كان المخطط يدعم العكس.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تم إضافة خاصية ISmartArt.Nodes**
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArt.Nodes مجموعة العقد الجذرية في كائن SmartArt.

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
تُعيد الخاصية Aspose.Slides.SmartArt.ISmartArtNode.IsHidden القيمة true إذا كانت هذه العقدة مخفية في نموذج البيانات.

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
تسمح الخاصية Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout بالحصول على أو تعيين نوع مخطط التنظيم المرتبط بالعقدة الحالية.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تم إضافة طريقة ضبط الخاصية ISmartArt.Layout**
تم إضافة طريقة الضبط للخاصية Aspose.Slides.SmartArt.ISmartArt.Layout. تتيح تعديل نوع التخطيط لمخطط موجود.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تغييرات API طفيفة**
**هذه قائمة بتغييرات API الطفيفة:**

|Enum Aspose.Slides.BevelColorMode |محذوف، تعداد غير مستخدم |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |محذوف، خاصية غير مستخدمة |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |مضافة |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |محذوف |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |محذوف كمهمل |