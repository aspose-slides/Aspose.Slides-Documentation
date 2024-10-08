---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 15.4.0
type: docs
weight: 150
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع الفئات والطرق والخصائص [المضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) أو [المزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) وما إلى ذلك، والتغييرات الأخرى التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 15.4.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
#### **تمت إضافة تعداد OrganizationChartLayoutType**
يمثل تعداد Aspose.Slides.SmartArt.OrganizationChartLayoutType نوع التنسيق لعقد الأطفال في مخطط تنظيمي.
#### **تمت إضافة طريقة IBulletFormat.ApplyDefaultParagraphIndentsShifts**
تقوم طريقة Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts بتعيين انزلاقات افتراضية غير صفرية لـ effective paragraph Indent و MarginLeft عند تمكين النقاط (كما يفعل PowerPoint إذا تم تمكين نقاط/ترقيم الفقرات فيه). إذا تم تعطيل النقاط، فإنه يقوم ببساطة بإعادة تعيين الفقرات Indent و MarginLeft (كما يفعل PowerPoint إذا تم تعطيل نقاط/ترقيم الفقرات فيه).

انظر الأمثلة [هنا](/slides/ar/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **تمت إضافة طريقة IConnector.Reroute**
تقوم طريقة Aspose.Slides.IConnector.Reroute بإعادة توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الأشكال التي يتصل بها. للقيام بذلك، قد تقوم طريقة Reroute() بتغيير StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex.

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
تقوم طريقة Aspose.Slides.IPresentation.GetSlideById(System.UInt32) بإرجاع شريحة أو MasterSlide أو LayoutSlide بواسطة Id الشريحة.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **تمت إضافة خاصية IShape.ConnectionSiteCount**
تقوم خاصية Aspose.Slides.IShape.ConnectionSiteCount بإرجاع عدد مواقع الاتصال على الشكل.

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
تسمح خاصية Aspose.Slides.SmartArt.ISmartArt.IsReversed بالحصول على أو تعيين حالة رسم SmartArt فيما يتعلق بـ (من اليسار إلى اليمين) LTR أو (من اليمين إلى اليسار) RTL، إذا كان الرسم يدعم العكس.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تمت إضافة خاصية ISmartArt.Nodes**
تقوم خاصية Aspose.Slides.SmartArt.ISmartArt.Nodes بإرجاع مجموعة من العقد الجذرية في كائن SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // اختيار العقدة الجذرية الثانية

  node.TextFrame.Text = "العقدة الجذرية الثانية";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تمت إضافة خاصية ISmartArtNode.IsHidden**
تقوم خاصية Aspose.Slides.SmartArt.ISmartArtNode.IsHidden بإرجاع true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //يرجع true

  if(hidden)

  {

    //قم ببعض الإجراءات أو الإشعارات

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تمت إضافة خاصية ISmartArtNode.OrganizationChartLayout**
تسمح خاصية Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout بالحصول على أو تعيين نوع المخطط التنظيمي المرتبط بالعقدة الحالية.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تمت إضافة طريقة set لخاصية ISmartArt.Layout**
تمت إضافة طريقة set لخاصية Aspose.Slides.SmartArt.ISmartArt.Layout. يسمح بتغيير نوع التخطيط لرسم موجود.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **تغييرات طفيفة في واجهة برمجة التطبيقات**
**هذه هي قائمة التغييرات الطفيفة في واجهة برمجة التطبيقات:**

|التعداد Aspose.Slides.BevelColorMode |محذوف، تعداد غير مستخدم |
| :- | :- |
|خاصية ThreeDFormatEffectiveData.BevelColorMode |محذوف، خاصية غير مستخدمة |
|خاصية Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>خاصية Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |مضافة |
|خاصية Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>وراثة IParagraphFormatEffectiveData من ISlideComponent <br>خاصية Aspose.Slides.IThreeDFormat.AsISlideComponent <br>وراثة IThreeDFormat من ISlideComponent |محذوف |
|خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>خاصية Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |محذوفة كمتهور |

