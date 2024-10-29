---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.4.0
type: docs
weight: 120
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [التي تمت إضافتها](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) من الفئات، والطُرق، والخصائص، وما إلى ذلك، وأي قيود جديدة، وأخرى [التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.4.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة Enum OrganizationChartLayoutType**
يمثل Enum com.aspose.slides.OrganizationChartLayoutType نوع التنسيق للعقد الفرعية في مخطط المنظمة.
### **تمت إضافة الطريقة IBulletFormat.applyDefaultParagraphIndentsShifts()**
تقوم الطريقة com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts بتعيين تحولات افتراضية غير صفرية لفراغ الفقرة الفعال وMarginLeft عند تمكين الفقاعات (كما تفعل PowerPoint إذا قمت بتمكين فقاعات/ترقيم الفقرات فيها). إذا كانت الفقاعات معطلة، فإنها تعيد تعيين فراغ الفقرة وMarginLeft فقط (كما تفعل PowerPoint إذا قمت بإلغاء تمكين فقاعات/ترقيم الفقرات فيها).
### **تمت إضافة الطريقة IConnector.reroute()**
تقوم الطريقة com.aspose.slides.IConnector.reroute() بإعادة توجيه الموصل بحيث يأخذ أقصر طريق ممكن بين الأشكال التي يتصل بها. لتحقيق ذلك، قد تقوم الطريقة reroute() بتغيير StartShapeConnectionSiteIndex وEndShapeConnectionSiteIndex.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقة IPresentation.getSlideById(long)**
تقوم الطريقة Aspose.Slides.IPresentation.getSlideById(int) بإرجاع شريحة أو MasterSlide أو LayoutSlide بواسطة معرف الشريحة.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **تمت إضافة الطريقة ISmartArt.getNodes()**
تقوم الطريقة com.aspose.slides.ISmartArt.getNodes() بإرجاع مجموعة من العقد الجذرية في كائن SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // اختر العقدة الجذرية الثانية

node.getTextFrame().setText("العقدة الجذرية الثانية");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقة ISmartArt.setLayout(int)**
تمت إضافة الطريقة لخصائص com.aspose.slides.ISmartArt.setLayout(int). يسمح بتغيير نوع التخطيط لرسم بياني موجود.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقة ISmartArtNode.isHidden()**
تقوم الطريقة com.aspose.slides.ISmartArtNode.isHidden() بإرجاع true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // يعيد true

if(hidden) {

    // قم ببعض الإجراءات أو الإشعارات

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقتين ISmartArt.isReversed() وsetReserved()**
تسمح الخاصية com.aspose.slides.ISmartArt.IsReversed بالحصول على حالة الرسم البياني لـ SmartArt فيما يتعلق بـ (من اليسار إلى اليمين) LTR أو (من اليمين إلى اليسار) RTL، إذا كان الرسم البياني يدعم العكس.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقتين ISmartArtNode.getOrganizationChartLayout() وsetOrganizationChartLayout(int)**
تسمح الطريقتان com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() وsetOrganizationChartLayout(int) بالحصول على نوع مخطط المنظمة المرتبط بالعقدة الحالية أو تعيينه.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الخاصية IShape.getConnectionSiteCount()**
تقوم الخاصية com.aspose.slides.getConnectionSiteCount() بإرجاع عدد مواقع الاتصال على الشكل.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **التغييرات الطفيفة**
هذه هي قائمة بالتغييرات الطفيفة في واجهة برمجة التطبيقات:

| Enum com.aspose.slides.BevelColorMode | تم الحذف، enum غير مستخدم |
| :- | :- |
| Method ThreeDFormatEffectiveData.getBevelColorMode() | تم الحذف، خاصية غير مستخدمة |
| Method com.aspose.slides.ChartSeriesGroup.getChart() | تمت الإضافة |
| وراثة IParagraphFormatEffectiveData من ISlideComponent <br> وراثة IThreeDFormat من ISlideComponent | تم الحذف |
| Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() | تم الحذف باعتبارها قديمة |