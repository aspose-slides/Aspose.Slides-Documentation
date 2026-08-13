---
title: API عمومی و تغییرات ناسازگار با عقب‌گرد در Aspose.Slides برای جاوا 14.5.0
linktitle: Aspose.Slides برای جاوا 14.5.0
type: docs
weight: 40
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- انتقال
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای جاوا را بررسی کنید تا بتوانید راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را به‌صورت روان منتقل کنید."
---
{{% alert color="info" %}} 

این صفحه تمام [اضافه شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) کلاس‌ها، متدها، ویژگی‌ها و غیره، هر [محدودیت](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) معرفی‌شده با Aspose.Slides for Java 14.5.0 API را فهرست می‌کند.

{{% /alert %}} 
## **API عمومی و تغییرات ناسازگار با عقب‌گرد**
### **کلاس‌ها و متدهای اضافه‌شده**
#### **اضافه شدهٔ رابط Aspose.Slides.IPresentationInfo و کلاس‌های PresentationInfo**
نمایش اطلاعات درباره ارائه.

متد Boolean isEncrypted() مقدار True را برمی‌گرداند اگر ارائه رمزگذاری شده باشد، در غیر این صورت مقدار False را برمی‌گرداند.

متد LoadFormat getLoadFormat() نوع ارائه را برمی‌گرداند.
#### **متد Aspose.Slides.IShape.isGrouped() اضافه شد**
متد Aspose.Slides.IShape.isGrouped() تعیین می‌کند که آیا شکل گروه‌بندی شده است یا خیر.
#### **متد Aspose.Slides.IShape.getParentGroup() اضافه شد**
متد Aspose.Slides.IShape.getParentGroup() در صورتی که شکل گروه‌بندی شده باشد، شیء GroupShape والد را برمی‌گرداند. در غیر این صورت null برمی‌گرداند.
#### **متد Aspose.Slides.IShapeCollection.addGroupShape() اضافه شد**
متد Aspose.Slides.IShapeCollection.addGroupShape() یک GroupShape جدید ایجاد کرده و آن را به انتهای مجموعه اضافه می‌کند.

اندازه و موقعیت فریم GroupShape با محتوای آن هنگام افزودن شکل جدید به GroupShape منطبق خواهد شد.
#### **متد Aspose.Slides.IShapeCollection.clear() اضافه شد**
متد Aspose.Slides.IShapeCollection.clear() تمام شکل‌ها را از مجموعه حذف می‌کند.
#### **متد Aspose.Slides.IShapeCollection.insertGroupShape(int) اضافه شد**
متد Aspose.Slides.IShapeCollection.insertGroupShape(int) یک GroupShape جدید ایجاد کرده و آن را در ایندکس مشخص به مجموعه اضافه می‌کند.

اندازه و موقعیت فریم GroupShape با محتوای آن هنگام افزودن شکل جدید به GroupShape منطبق خواهد شد.
#### **متدهای IPresentationFactory.getPresentationInfo(string file)، IPresentatoinFactory.getPresentationInfo(InputStream stream) اضافه شدند**
این متدها به توسعه‌دهندگان امکان دریافت اطلاعات درباره یک فایل/جریان ارائه را بدون بارگذاری کامل ارائه می‌دهند.
#### **متد IPresentationFactory PresentationFactory.getInstance() اضافه شد**
امکان استفاده از عملکرد کارخانه بدون ایجاد نمونه را می‌دهد.
### **محدودیت‌ها**
#### **محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده در IShape.getFrame() اضافه شده‌اند**
کدی که سعی می‌کند یک فریم تعریف‌نشده را به IShape.setFrame(IShapeFrame) اختصاص دهد، در موارد عمومی منطقی نیست (به‌ویژه وقتی که GroupShape والد چندین بار درون دیگر {{GroupShape}}ها تو در تو باشد). به عنوان مثال:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // یک ArgumentException پرتاب می‌کند: مقادیر فریم باید تعریف شوند.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

or

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // یک ArgumentException پرتاب می‌کند: مقادیر x، y، width و height باید تعریف شوند.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

چنین کدی می‌تواند به وضعیت‌های مبهم منجر شود. بنابراین محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده در IShape.Frame اضافه شده‌اند. مقادیر x، y، width، height، flipH، flipV و rotationAngle باید تعریف شوند (نه Float.NaN یا NullableBool.NotDefined). کد نمونه بالا اکنون یک استثنای ArgumentException را پرتاب می‌کند.

این امر برای موارد استفاده زیر صادق است:

``` java
// فریم پاس داده شده به IShape.setFrame(IShapeFrame) نمی‌تواند شامل مقادیر تعریف‌نشده باشد.

// پارامترهای x، y، width و height متدهای زیر IShapeCollection
// نمی‌توانند Float.NaN باشند همچنین:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

اما فریم IShape.getRawFrame() می‌تواند تعریف‌نشده باشد. این مورد وقتی مفید است که یک شکل به یک placeholder لینک شده باشد. در این صورت مقادیر فریم تعریف‌نشده شکل توسط شکل placeholder والد بازنویسی می‌شوند. اگر برای آن شکل placeholder والد وجود نداشته باشد، مقادیر پیش‌فرض هنگام ارزیابی فریم مؤثر بر اساس IShape.getRawFrame() استفاده می‌شوند. مقادیر پیش‌فرض برای x، y، width، height، flipH، flipV و rotationAngle به ترتیب 0 و NullableBool.False است. به عنوان مثال:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // شکل به یک placeholder لینک شده است.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // اکنون شکل مقادیر x، y، height، flipH و flipV را از placeholder به ارث می‌برد
    // و مقدار width = 100 و rotationAngle = 0 را بازنویسی می‌کند.
} finally {
    if (pres != null) pres.dispose();
}
```
### **ویژگی‌های تغییر یافته**
#### **نوع و نام متد Aspose.Slides.IShapeCollection.getParent() تغییر کرد**
نوع ویژگی Aspose.Slides.IShapeCollection.Parent از ISlideComponent به رابط جدید IGroupShape تغییر یافت. رابط IGroupShape از ISlideComponent ارث می‌برد، بنابراین کدهای موجود نیازی به تطبیق ندارند.

نام متد Aspose.Slides.IShapeCollection.getParent() از getParent به getParentGroup() تغییر یافت.
#### **تغییر نوع متدهای Aspose.Slides.IShapeFrame.getFlipH() و .getFlipV()**
نوع متد Aspose.Slides.IShapeFrame.getFlipH() از bool به NullableBool تغییر یافت.

متد IShape.getFrame() یک نمونه مؤثر از IShapeFrame را بازمی‌گرداند (همهٔ خصوصیات آن دارای مقادیر مؤثر تعریف‌شده هستند).

متد IShape.getRawFrame() یک نمونه IShapeFrame را برمی‌گرداند که هر خصوصیت می‌تواند مقدار تعریف‌نشده داشته باشد (به‌ویژه FlipH یا FlipV می‌توانند مقدار NullableBool.NotDefined داشته باشند).