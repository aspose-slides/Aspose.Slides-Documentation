---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 15.4.0
type: docs
weight: 120
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

تستعرض هذه الصفحة جميع [الفئات المضافة](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) والطرق والخصائص وما إلى ذلك، وأي قيود جديدة وأي [تغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 15.4.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تمت إضافة Enum OrganizationChartLayoutType**
يمثل Enum com.aspose.slides.OrganizationChartLayoutType نوع تنسيق العقد الفرعية في مخطط التنظيم.
### **تمت إضافة الطريقة IBulletFormat.applyDefaultParagraphIndentsShifts()**
تحدد الطريقة com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts الإزاحات الافتراضية غير الصفرية لتراجع الفقرة الفعال وMarginLeft عند تفعيل النقاط (كما تفعل PowerPoint إذا تم تفعيل النقاط/التعداد في الفقرة). إذا تم تعطيل النقاط، فقط أعد تعيين تراجع الفقرة وMarginLeft (كما تفعل PowerPoint إذا تم تعطيل النقاط/التعداد في الفقرة).
### **تمت إضافة الطريقة IConnector.reroute()**
تعيد الطريقة com.aspose.slides.IConnector.reroute() توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الأشكال التي يرتبط بها. لتحقيق ذلك، قد تغير الطريقة reroute() مؤشر موقع اتصال الشكل بداية ونهاية.

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
تعيد الطريقة Aspose.Slides.IPresentation.getSlideById(int) شريحة أو شريحة أساسية أو شريحة تخطيط بواسطة معرف الشريحة.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **تمت إضافة الطريقة ISmartArt.getNodes()**
تعيد الطريقة com.aspose.slides.ISmartArt.getNodes() مجموعة من العقد الجذرية في كائن SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // اختر العقدة الجذرية الثانية

node.getTextFrame().setText("العقدة الجذرية الثانية");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقة ISmartArt.setLayout(int)**
تمت إضافة الطريقة لخاصية com.aspose.slides.ISmartArt.setLayout(int). تتيح تغيير نوع تخطيط المخطط الموجود.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقة ISmartArtNode.isHidden()**
تعيد الطريقة com.aspose.slides.ISmartArtNode.isHidden() القيمة true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //تعيد true

if(hidden) {

    //قم ببعض الإجراءات أو الإشعارات

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقتين ISmartArt.isReversed() وsetReserved()**
تسمح خاصية com.aspose.slides.ISmartArt.IsReversed بالحصول على حالة مخطط SmartArt أو تعيينها فيما يتعلق بـ (من اليسار إلى اليمين) LTR أو (من اليمين إلى اليسار) RTL، إذا كان المخطط يدعم المراجعة.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الطريقتين ISmartArtNode.getOrganizationChartLayout() وsetOrganizationChartLayout(int)**
تسمح الطريقتان com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() وsetOrganizationChartLayout(int) بالحصول على نوع مخطط التنظيم المرتبط بالعقدة الحالية أو تعيينه.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تمت إضافة الخاصية IShape.getConnectionSiteCount()**
تعيد خاصية com.aspose.slides.getConnectionSiteCount() عدد مواقع الاتصال على الشكل.

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

| Enum com.aspose.slides.BevelColorMode | محذوف، لا تُستخدم |
| :- | :- |
| Method ThreeDFormatEffectiveData.getBevelColorMode() | محذوف، خاصية غير مستخدمة |
| Method com.aspose.slides.ChartSeriesGroup.getChart() | تمت الإضافة |
| وراثة IParagraphFormatEffectiveData من ISlideComponent <br> وراثة IThreeDFormat من ISlideComponent | محذوف |
| Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br> Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() | محذوف كغير صالح |