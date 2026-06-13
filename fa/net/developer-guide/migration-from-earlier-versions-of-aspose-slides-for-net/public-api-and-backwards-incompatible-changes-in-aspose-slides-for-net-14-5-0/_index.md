---
title: "API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 14.5.0"
linktitle: "Aspose.Slides برای .NET 14.5.0"
type: docs
weight: 70
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- "مهاجرت"
- "کد قدیمی"
- "کد مدرن"
- "روش قدیمی"
- "روش مدرن"
- "پاورپوینت"
- "OpenDocument"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا راه‌حل‌های ارائهٔ PowerPoint (PPT، PPTX) و ODP خود را به‌صورت روان مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، خواص و غیره‌ی [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) را فهرست می‌کند، هر [محدودیت](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) جدید و سایر [تغییرات](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) معرفی شده با Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **API عمومی و تغییرات ناسازگار به عقب**
### **رابط‌ها، کلاس‌ها، خواص و متدهای اضافه شده**
#### **افزودن رابط Aspose.Slides.IPresentationInfo و کلاس PresentationInfo**
نمایانگر اطلاعات دربارهٔ ارائه.

- ویژگی بولی IsEncrypted مقدار True را می‌گیرد اگر ارائه رمزنگاری شده باشد، در غیر این صورت مقدار False را می‌گیرد.
- ویژگی LoadFormat نوع ارائه را دریافت می‌کند.
#### **افزودن ویژگی Aspose.Slides.IShape.IsGrouped**
ویژگی Aspose.Slides.IShape.IsGrouped تعیین می‌کند که آیا یک شکل گروه‌بندی شده است یا خیر.
#### **افزودن ویژگی Aspose.Slides.IShape.ParentGroup**
ویژگی Aspose.Slides.IShape.ParentGroup شیء GroupShape والد را برمی‌گرداند اگر شکل گروه‌بندی شده باشد. در غیر این صورت مقدار null را برمی‌گرداند.
#### **افزودن متد Aspose.Slides.IShapeCollection.AddGroupShape()**
متد Aspose.Slides.IShapeCollection.AddGroupShape() یک GroupShape جدید ایجاد می‌کند و به انتهای مجموعه اضافه می‌گیرد.
اندازه و موقعیت فریم GroupShape با محتوا منطبق می‌شود زمانی که شکل جدید اضافه می‌شود.
#### **افزودن متد Aspose.Slides.IShapeCollection.Clear()**
متد Aspose.Slides.IShapeCollection.Clear() همهٔ شکل‌ها را از مجموعه حذف می‌کند.
#### **افزودن متد Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
متد Aspose.Slides.IShapeCollection.InsertGroupShape(int) یک GroupShape جدید ایجاد می‌کند و آن را در مجموعه در موقعیت ایندکس مشخص شده وارد می‌سازد.
اندازه و موقعیت فریم GroupShape با محتوا منطبق می‌شود وقتی شکل جدید اضافه می‌شود.
#### **افزودن متدهای IPresentationFactory.GetPresentationInfo(string file)، IPresentatoinFactory.GetPresentationInfo(Stream stream)**
این متدها امکان دریافت اطلاعات دربارهٔ فایل یا جریان ارائه را بدون بارگذاری کامل ارائه فراهم می‌کنند.
#### **افزودن ویژگی IPresentationFactory PresentationFactory.Instance**
این ویژگی به توسعه‌دهندگان اجازه می‌دهد تا از عملکرد کارخانه بدون نمونه‌سازی استفاده کنند.
### **محدودیت‌ها**
#### **محدودیت‌ها برای IShape.Frame**
محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده برای IShape.Frame افزوده شده‌اند. کدی که سعی می‌کند یک فریم تعریف‌نشده را به IShape.Frame اختصاص دهد در بیشتر موارد معنا ندارد (به‌ویژه وقتی GroupShape والد چندین بار در {{GroupShape}}های دیگر تو در تو باشد). برای مثال:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

یا

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

چنین کدی می‌تواند به موقعیت‌های نامشخص منجر شود. بنابراین محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده برای IShape.Frame افزوده شده است. مقادیر x، y، عرض، ارتفاع، flipH، flipV و rotationAngle باید تعریف شوند (و نه به float.NaN یا NullableBool.NotDefined تنظیم شوند). کد نمونهٔ بالا اکنون یک استثنای ArgumentException می‌اندازد.
این برای موارد استفاده زیر اعمال می‌شود:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // نمی‌تواند تعریف‌نشده باشد

IShapeCollection shapes = ...;

// پارامترهای x، y، عرض، ارتفاع نمی‌توانند float.NaN باشند:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

اما خواص فریم IShape.RawFrame می‌توانند تعریف‌نشده باشند. این منطقی است وقتی یک شکل به یک placeholder لینک شده باشد. سپس مقادیر فریم تعریف‌نشدهٔ شکل از شکل placeholder والد بازنویسی می‌شوند. اگر placeholder والد وجود نداشته باشد، آن شکل از مقادیر پیش‌فرض استفاده می‌کند وقتی فریم مؤثر را بر پایهٔ IShape.RawFrame ارزیابی می‌کند. مقادیر پیش‌فرض برای x، y، عرض، ارتفاع، flipH، flipV و rotationAngle برابر 0 و NullableBool.False هستند. برای مثال:

``` csharp

 IShape shape = ...; // شکل به placeholder لینک شده است

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// اکنون shape مقادیر x، y، height، flipH، flipV را از placeholder به ارث می‌برد و width=100 و rotationAngle=0 را بازنویسی می‌کند.

``` 
### **خواص تغییر یافته**
#### **تغییر نام و نوع ویژگی Aspose.Slides.IShapeCollection.Parent**
- نوع ویژگی Aspose.Slides.IShapeCollection.Parent از ISlideComponent به اینترفیس جدید IGroupShape تغییر کرده است. اینترفیس IGroupShape فرزند ISlideComponent است، بنابراین کد موجود نیازی به اصلاح ندارد.
- نام ویژگی Aspose.Slides.IShapeCollection.Parent از Parent به ParentGroup تغییر یافته است.
#### **تغییر نوع ویژگی‌های Aspose.Slides.IShapeFrame.FlipH و .FlipV**
- نوع ویژگی Aspose.Slides.IShapeFrame.FlipH از bool به NullableBool تغییر یافته است.
- ویژگی IShape.Frame یک نمونهٔ مؤثر از IShapeFrame را بر می‌گرداند (همهٔ خواص آن مقادیر مؤثر تعریف‌شده دارند).
- ویژگی IShape.RawFrame یک نمونهٔ IShapeFrame را بر می‌گرداند که هر ویژگی می‌تواند مقدار تعریف‌نشده داشته باشد (به‌ویژه FlipH یا FlipV می‌تواند مقدار NullableBool.NotDefined داشته باشد).