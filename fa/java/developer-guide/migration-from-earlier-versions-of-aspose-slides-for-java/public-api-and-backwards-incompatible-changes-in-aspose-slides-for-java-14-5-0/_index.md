---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای Java 14.5.0
linktitle: Aspose.Slides برای Java 14.5.0
type: docs
weight: 40
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- مهاجرت
- کد ارثی
- کد مدرن
- رویکرد ارثی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای Java را مرور کنید تا به‌صورت روان پروژه‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، خصوصیات و غیره‌ای که [افزوده شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) هستند، هر [محدودیت](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) معرفی‌شده با Aspose.Slides for Java 14.5.0 API را فهرست می‌کند.

{{% /alert %}} 
## **API عمومی و تغییرات ناسازگار به عقب**
### **کلاس‌ها و متدهای افزوده شده**
#### **افزودن اینترفیس Aspose.Slides.IPresentationInfo و کلاس‌های PresentationInfo**
نمایانگر اطلاعات درباره ارائه است.

متد Boolean isEncrypted() مقدار True را برمی‌گرداند اگر ارائه رمزگذاری شده باشد، در غیر اینصورت مقدار False را برمی‌گرداند.

متد LoadFormat getLoadFormat() نوع ارائه را برمی‌گرداند.
#### **افزودن متد Aspose.Slides.IShape.isGrouped()**
متد Aspose.Slides.IShape.isGrouped() تعیین می‌کند که آیا شکل گروه‌بندی شده است یا نه.
#### **افزودن متد Aspose.Slides.IShape.getParentGroup()**
متد Aspose.Slides.IShape.getParentGroup() در صورتی که شکل گروه‌بندی شده باشد، شیء GroupShape والد را برمی‌گرداند. در غیر اینصورت مقدار null را برمی‌گرداند.
#### **افزودن متد Aspose.Slides.IShapeCollection.addGroupShape()**
متد Aspose.Slides.IShapeCollection.addGroupShape() یک GroupShape جدید ایجاد کرده و آن را به انتهای مجموعه اضافه می‌کند.

اندازه و موقعیت فریم GroupShape با محتوای آن منطبق می‌شود زمانی که شکل جدیدی به GroupShape اضافه شود.
#### **افزودن متد Aspose.Slides.IShapeCollection.clear()**
متد Aspose.Slides.IShapeCollection.clear() تمام شکل‌ها را از مجموعه حذف می‌کند.
#### **افزودن متد Aspose.Slides.IShapeCollection.insertGroupShape(int)**
متد Aspose.Slides.IShapeCollection.insertGroupShape(int) یک GroupShape جدید ایجاد کرده و آن را در ایندکس مشخص‌شده به مجموعه وارد می‌کند.

اندازه و موقعیت فریم GroupShape با محتوای آن منطبق می‌شود زمانی که شکل جدیدی به GroupShape اضافه شود.
#### **افزودن متدهای IPresentationFactory.getPresentationInfo(string file)، IPresentatoinFactory.getPresentationInfo(InputStream stream)**
این متدها به توسعه‌دهندگان امکان دریافت اطلاعات درباره فایل/جریان ارائه را بدون بارگذاری کامل ارائه می‌دهند.
#### **افزودن متد IPresentationFactory PresentationFactory.getInstance()**
امکان استفاده از عملکرد کارخانه بدون نمونه‌سازی را فراهم می‌کند.
### **محدودیت‌ها**
#### **محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده در IShape.getFrame() اضافه شده‌اند**
کدی که سعی می‌کند فریم تعریف‌نشده‌ای را به IShape.setFrame(IShapeFrame) اختصاص دهد، در موارد کلی منطقی نیست (به‌ویژه زمانی که GroupShape والد چندین بار در {{GroupShape}}های دیگر تو در تو باشد). برای مثال:
``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

یا
``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

چنین کدی می‌تواند به وضعیت‌های نامشخص منجر شود. بنابراین محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده در IShape.Frame اضافه شده‌اند. مقادیر x، y، width، height، flipH، flipV و rotationAngle باید تعریف شوند (نه Float.NaN یا NullableBool.NotDefined). کد نمونه‌ی فوق اکنون استثنای ArgumentException را پرتاب می‌کند.
این موارد برای موارد استفاده زیر اعمال می‌شود:
``` java

 IShape shape = ...;

shape.setFrame(...); // نمی‌تواند تعریف‌نشده باشد

IShapeCollection shapes = ...;

// پارامترهای x، y، width، height نمی‌توانند Float.NaN باشند:

{
    shapes.addAudioFrameCD(...);
    shapes.addAudioFrameEmbedded(...);
    shapes.addAudioFrameLinked(...);
    shapes.addAutoShape(...);
    shapes.addChart(...);
    shapes.addConnector(...);
    shapes.addOleObjectFrame(...);
    shapes.addPictureFrame(...);
    shapes.addSmartArt(...);
    shapes.addTable(...);
    shapes.addVideoFrame(...);
    shapes.insertAudioFrameEmbedded(...);
    shapes.insertAudioFrameLinked(...);
    shapes.insertAutoShape(...);
    shapes.insertChart(...);
    shapes.insertConnector(...);
    shapes.insertOleObjectFrame(...);
    shapes.insertPictureFrame(...);
    shapes.insertTable(...);
    shapes.insertVideoFrame(...);
}
```

اما فریم IShape.getRawFrame() می‌تواند تعریف‌نشده باشد. این منطقی است زمانی که شکلی به یک placeholder لینک شده باشد. در این حالت مقادیر فریم تعریف‌نشده شکل از شکل placeholder والد بازنویسی می‌شوند. اگر برای آن شکل placeholder والد وجود نداشته باشد، هنگام ارزیابی فریم مؤثر بر پایه IShape.getRawFrame() از مقادیر پیش‌فرض استفاده می‌کند. مقادیر پیش‌فرض 0 و NullableBool.False برای x، y، width، height، flipH، flipV و rotationAngle هستند. برای مثال:
``` java

 IShape shape = ...; // شکل به placeholder لینک شده است

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// حالا shape ویژگی‌های x، y، height، flipH، flipV را از placeholder ارث می‌برد و مقدار width=100 و rotationAngle=0 را بازنویسی می‌کند.

```
### **خصوصیات تغییر یافته**
#### **تغییر نوع و نام متد Aspose.Slides.IShapeCollection.getParent()**
نوع ویژگی Aspose.Slides.IShapeCollection.Parent از ISlideComponent به رابط جدید IGroupShape تغییر یافته است. رابط IGroupShape فرزند ISlideComponent است، بنابراین کدهای موجود نیازی به سازگاری ندارند.

نام متد Aspose.Slides.IShapeCollection.getParent() از getParent به getParentGroup() تغییر یافته است.
#### **تغییر نوع متدهای Aspose.Slides.IShapeFrame.getFlipH() و .getFlipV()**
نوع متد Aspose.Slides.IShapeFrame.getFlipH() از bool به NullableBool تغییر یافته است.

متد IShape.getFrame() نمونه مؤثر IShapeFrame را برمی‌گرداند (تمامی ویژگی‌های آن دارای مقادیر مؤثر تعریف‌شده هستند).

متد IShape.getRawFrame() یک نمونه IShapeFrame را برمی‌گرداند که هر ویژگی می‌تواند مقدار تعریف‌نشده داشته باشد (به‌ویژه FlipH یا FlipV می‌توانند مقدار NullableBool.NotDefined داشته باشند).