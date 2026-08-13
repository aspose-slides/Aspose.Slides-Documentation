---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides للـ Java 15.4.0"
linktitle: "Aspose.Slides للـ Java 15.4.0"
type: docs
weight: 120
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- "الهجرة"
- "كود قديم"
- "كود حديث"
- "نهج قديم"
- "نهج حديث"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Java"
- "Aspose.Slides"
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides للـ Java لتسهيل ترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP الخاصة بك."
---
{{% alert color="info" %}} 

تُظهر هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)، وأي قيود جديدة و[التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) التي تم تقديمها مع Aspose.Slides for Java 15.4.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
### **تم إضافة تعداد OrganizationChartLayoutType**
يمثل تعداد com.aspose.slides.OrganizationChartLayoutType نوع تنسيق العقد الفرعية في مخطط تنظيمي.
### **تم إضافة طريقة IBulletFormat.applyDefaultParagraphIndentsShifts()**
تُعيّن طريقة com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts القيم الافتراضية غير الصفرية للإزاحات الخاصة بالمسافة البادئة للفقرة والهوامش اليسرى عندما تكون النقاط مفعّلة (كما يفعل PowerPoint عند تفعيل نقاط/ترقيم الفقرات). إذا تم إلغاء تفعيل النقاط، فإنها تعيد تعيين المسافة البادئة للفقرة والهوامش اليسرى إلى القيم الأصلية (كما يفعل PowerPoint عند إلغاء تفعيل نقاط/ترقيم الفقرات).
### **تم إضافة طريقة IConnector.reroute()**
تُعيد طريقة com.aspose.slides.IConnector.reroute() توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الأشكال التي يربطها. للقيام بذلك، قد تُغيّر طريقة reroute() قيمتي StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex.
``` java
import com.aspose.slides.*;


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
### **تم إضافة طريقة IPresentation.getSlideById(long)**
تُعيد طريقة Aspose.Slides.IPresentation.getSlideById(long) شريحة (Slide) أو شريحة رئيسية (MasterSlide) أو شريحة تخطيط (LayoutSlide) بحسب معرّف الشريحة.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **تم إضافة طريقة ISmartArt.getNodes()**
تُعيد طريقة com.aspose.slides.ISmartArt.getNodes() مجموعة من العقد الجذرية في كائن SmartArt.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // اختر العقدة الجذرية الثانية

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تم إضافة طريقة ISmartArt.setLayout(int)**
تم إضافة طريقة للخاصية com.aspose.slides.ISmartArt.setLayout(int). تسمح بتغيير نوع التخطيط لمخطط موجود.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تم إضافة طريقة ISmartArtNode.isHidden()**
تُعيد طريقة com.aspose.slides.ISmartArtNode.isHidden() القيمة true إذا كان هذا العقدة مخفية في نموذج البيانات.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // يرجع true

if(hidden) {

    // قم ببعض الإجراءات أو الإشعارات

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **تم إضافة طرق ISmartArt.isReversed() و setReversed()**
تتيح الخاصية com.aspose.slides.ISmartArt.IsReversed الحصول على أو تعيين حالة مخطط SmartArt بالنسبة للاتجاه من اليسار إلى اليمين (LTR) أو من اليمين إلى اليسار (RTL)، إذا كان المخطط يدعم العكس.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **تم إضافة طرق ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int)**
تسمح طرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int) بالحصول على أو تعيين نوع مخطط التنظيم المرتبط بالعقدة الحالية.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **تم إضافة خاصية IShape.getConnectionSiteCount()**
تُعيد الخاصية com.aspose.slides.getConnectionSiteCount() عدد مواقع الاتصال على الشكل.
``` java
import com.aspose.slides.*;


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
### **تغييرات طفيفة**
هذه قائمة التغييرات الطفيفة في API:

|Enum com.aspose.slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |deleted, unused property |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |added |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |deleted as obsolete |