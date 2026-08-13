---
title: "تغییرات API عمومی و ناسازگاری‌های عقب‌گرد در Aspose.Slides برای Java 15.4.0"
linktitle: "Aspose.Slides برای Java 15.4.0"
type: docs
weight: 120
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "مروری بر به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java به منظور مهاجرت آسان راهکارهای ارائه پاورپوینت (PPT، PPTX) و ODP شما."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره افزوده‌شده، هر محدودیت جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) معرفی‌شده با API Aspose.Slides for Java 15.4.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
### **Enum OrganizationChartLayoutType اضافه شده است**
Enum com.aspose.slides.OrganizationChartLayoutType نشان‌دهنده نوع قالب‌بندی گره‌های فرزند در یک نمودار سازمانی است.
### **متد IBulletFormat.applyDefaultParagraphIndentsShifts() اضافه شده است**
متد com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts برای تنظیم جابجایی‌های پیش‌فرض غیر صفر برای تو رفتگی پاراگراف و MarginLeft مؤثر هنگامی که گلوله‌ها فعال هستند (مانند PowerPoint هنگامی که پاراگراف گلوله‌دار/شماره‌دار می‌شود) استفاده می‌شود. اگر گلوله‌ها غیرفعال باشند، فقط تو رفتگی پاراگراف و MarginLeft بازنشانی می‌شود (مانند PowerPoint وقتی گلوله‌ها غیرفعال می‌شوند).
### **متد IConnector.reroute() اضافه شده است**
متد com.aspose.slides.IConnector.reroute() مسیر اتصال را طوری تنظیم می‌کند که کوتاه‌ترین مسیر ممکن بین اشکالی که به هم وصل می‌شوند را بگیرد. برای این کار، متد reroute() ممکن است مقدار StartShapeConnectionSiteIndex و EndShapeConnectionSiteIndex را تغییر دهد.

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
### **متد IPresentation.getSlideById(long) اضافه شده است**
متد Aspose.Slides.IPresentation.getSlideById(long) یک Slide، MasterSlide یا LayoutSlide را بر اساس شناسه اسلاید برمی‌گرداند.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **متد ISmartArt.getNodes() اضافه شده است**
متد com.aspose.slides.ISmartArt.getNodes() مجموعه‌ای از گره‌های ریشه در شیء SmartArt را برمی‌گرداند.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // انتخاب گره ریشه دوم

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **متد ISmartArt.setLayout(int) اضافه شده است**
متد برای ویژگی com.aspose.slides.ISmartArt.setLayout(int) اضافه شده است. این متد امکان تغییر نوع طرح‌بندی یک نمودار موجود را فراهم می‌کند.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **متد ISmartArtNode.isHidden() اضافه شده است**
متد com.aspose.slides.ISmartArtNode.isHidden() در صورتی که این گره یک گره مخفی در مدل داده باشد، مقدار true را برمی‌گرداند.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // برمی‌گرداند true

if(hidden) {

    // انجام برخی عملیات یا اعلان‌ها

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **متدهای ISmartArt.isReversed()، setReversed() اضافه شده‌اند**
ویژگی com.aspose.slides.ISmartArt.IsReversed امکان دریافت یا تنظیم وضعیت نمودار SmartArt نسبت به جهت چپ به راست (LTR) یا راست به چپ (RTL) را فراهم می‌کند، در صورتی که نمودار از معکوس شدن پشتیبانی کند.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **متدهای ISmartArtNode.getOrganizationChartLayout()، setOrganizationChartLayout(int) اضافه شده‌اند**
متدهای com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() و setOrganizationChartLayout(int) امکان دریافت یا تنظیم نوع نمودار سازمانی مرتبط با گره فعلی را فراهم می‌کنند.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **ویژگی IShape.getConnectionSiteCount() اضافه شده است**
ویژگی com.aspose.slides.getConnectionSiteCount() تعداد سایت‌های اتصال روی شکل را برمی‌گرداند.

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
### **تغییرات جزئی**
این فهرست تغییرات جزئی API است:

|Enum com.aspose.slides.BevelColorMode |حذف شد، enum استفاده نشده |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |حذف شد، property استفاده نشده |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |اضافه شد |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |حذف شد |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |حذف شد به عنوان منسوخ |