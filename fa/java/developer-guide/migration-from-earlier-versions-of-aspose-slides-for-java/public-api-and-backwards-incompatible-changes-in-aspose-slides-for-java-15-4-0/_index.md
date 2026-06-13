---
title: "API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای Java 15.4.0"
linktitle: "Aspose.Slides برای Java 15.4.0"
type: docs
weight: 120
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- مهاجرت
- کد میراثی
- کد مدرن
- رویکرد میراثی
- رویکرد مدرن
- پاورپوینت
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکست‌پذیر در Aspose.Slides برای Java را بررسی کنید تا به‌صورت روان راه‌حل‌های ارائهٔ PowerPoint PPT، PPTX و ODP خود را منتقل کنید."
---
{{% alert color="primary" %}} 

این صفحه تمام [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) کلاس‌ها، متدها، خصوصیات و غیره‌ای که افزوده شده‌اند، هر محدودیت جدید و سایر [changes](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) معرفی‌شده در API Aspose.Slides for Java 15.4.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **Enum OrganizationChartLayoutType اضافه شده است**
enum com.aspose.slides.OrganizationChartLayoutType نوع قالب‌بندی گره‌های فرزند در یک نمودار سازمانی را نمایندگی می‌کند.

### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() اضافه شده است**
متد com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts جابجایی‌های پیش‌فرض غیر صفر برای تورفتگی پاراگراف و MarginLeft مؤثر را وقتی گلوله‌ها فعال هستند تنظیم می‌کند (مانند کاری که PowerPoint هنگام فعال‌سازی گلوله‌ها/شماره‌گذاری پاراگراف انجام می‌دهد). اگر گلوله‌ها غیرفعال باشند، تنها تورفتگی پاراگراف و MarginLeft را بازنشانی می‌کند (مانند کاری که PowerPoint هنگام غیرفعال‌سازی گلوله‌ها/شمامه‌گذاری پاراگراف انجام می‌دهد).

### **Method IConnector.reroute() اضافه شده است**
متد com.aspose.slides.IConnector.reroute() مسیر اتصال‌کننده را طوری تنظیم می‌کند که کوتاه‌ترین مسیر ممکن بین اشکالی که به هم متصل می‌کند را بگیرد. برای این کار، متد reroute() ممکن است مقادیر StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex را تغییر دهد.

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
### **Method IPresentation.getSlideById(long) اضافه شده است**
متد Aspose.Slides.IPresentation.getSlideById(int) یک Slide، MasterSlide یا LayoutSlide را بر اساس شناسه اسلاید بر می‌گرداند.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() اضافه شده است**
متد com.aspose.slides.ISmartArt.getNodes() مجموعه‌ای از گره‌های ریشه در شیء SmartArt را بر می‌گرداند.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // انتخاب گره ریشه دوم

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) اضافه شده است**
متد برای خصوصیت com.aspose.slides.ISmartArt.setLayout(int) اضافه شده است. این متد امکان تغییر نوع چینش یک نمودار موجود را می‌دهد.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() اضافه شده است**
متد com.aspose.slides.ISmartArtNode.isHidden() در صورتی که این گره در مدل داده مخفی باشد، مقدار true را بر می‌گرداند.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //true برمی‌گرداند

if(hidden) {

    //برخی اقدامات یا اعلان‌ها را انجام بدهید

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved() اضافه شده‌اند**
خصوصیت com.aspose.slides.ISmartArt.IsReversed امکان دریافت یا تنظیم وضعیت نمودار SmartArt نسبت به (چپ به راست) LTR یا (راست به چپ) RTL را فراهم می‌کند، در صورتی که نمودار از وارون شدن پشتیبانی کند.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) اضافه شده‌اند**
متدهای com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int) امکان دریافت یا تنظیم نوع نمودار سازمانی مرتبط با گره فعلی را فراهم می‌کنند.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() اضافه شده است**
خاصیت com.aspose.slides.getConnectionSiteCount() تعداد نقاط اتصال روی شکل را بر می‌گرداند.

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
### **تغییرات جزئی**
این فهرست تغییرات جزئی API است:

|Enum com.aspose.slides.BevelColorMode |حذف شد، enum استفاده نشده |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |حذف شد، خصوصیت استفاده نشده |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |اضافه شد |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |حذف شد |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |حذف شد به عنوان منسوخ |