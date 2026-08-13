---
title: "API عمومی و تغییرات ناسازگار با نسخه پیشین در Aspose.Slides برای .NET 14.5.0"
linktitle: "Aspose.Slides برای .NET 14.5.0"
type: docs
weight: 70
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای .NET را مرور کنید تا به‌راحتی راه‌حل‌های ارائهٔ PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)، هر [محدودیت](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) جدید و سایر [تغییرات](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) معرفی‌شده با Aspose.Slides for .NET 14.5.0 API را فهرست می‌کند.
{{% /alert %}} 
## **API عمومی و تغییرات ناسازگار با نسخه قبلی**
### **رابط‌ها، کلاس‌ها، ویژگی‌ها و متدهای اضافه شده**
#### **اضافه شد Interface Aspose.Slides.IPresentationInfo و کلاس PresentationInfo**
نمایش اطلاعات دربارهٔ ارائه.

- ویژگی Boolean IsEncrypted مقدار True را برمی‌گرداند اگر ارائه رمزگذاری شده باشد، در غیر اینصورت مقدار False را برمی‌گرداند.
- ویژگی LoadFormat نوع ارائه را برمی‌گرداند.
#### **اضافه شد ویژگی Aspose.Slides.IShape.IsGrouped**
ویژگی Aspose.Slides.IShape.IsGrouped تعیین می‌کند که آیا یک شکل گروه‌بندی شده است یا نه.
#### **اضافه شد ویژگی Aspose.Slides.IShape.ParentGroup**
ویژگی Aspose.Slides.IShape.ParentGroup شیء GroupShape والد را در صورتی که شکل گروه‌بندی شده باشد باز می‌گرداند. در غیر اینصورت مقدار null را برمی‌گرداند.
#### **اضافه شد متد Aspose.Slides.IShapeCollection.AddGroupShape()**
متد Aspose.Slides.IShapeCollection.AddGroupShape() یک GroupShape جدید ایجاد کرده و به انتهای مجموعه اضافه می‌کند.
اندازه و موقعیت چارچوب GroupShape هنگام افزودن شکل جدید به محتوا منطبق خواهد شد.
#### **اضافه شد متد Aspose.Slides.IShapeCollection.Clear()**
متد Aspose.Slides.IShapeCollection.Clear() تمام اشکال را از مجموعه حذف می‌کند.
#### **اضافه شد متد Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
متد Aspose.Slides.IShapeCollection.InsertGroupShape(int) یک GroupShape جدید ایجاد کرده و آن را در موقعیت ایندکس مشخص به مجموعه وارد می‌کند.
اندازه و موقعیت چارچوب GroupShape هنگام افزودن شکل جدید به محتوا منطبق خواهد شد.
#### **اضافه شد متدهای IPresentationFactory.GetPresentationInfo(string file)، IPresentatoinFactory.GetPresentationInfo(Stream stream)**
این متدها امکان دریافت اطلاعات دربارهٔ فایل یا جریان ارائه را بدون بارگذاری کامل ارائه فراهم می‌کنند.
#### **اضافه شد ویژگی IPresentationFactory PresentationFactory.Instance**
این ویژگی به توسعه‌دهندگان اجازه می‌دهد بدون ایجاد نمونه، از عملکرد کارخانه استفاده کنند.
### **محدودیت‌ها**
#### **محدودیت‌ها برای IShape.Frame**
محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده برای IShape.Frame اضافه شده است. کدی که سعی می‌کند یک چارچوب تعریف‌نشده را به IShape.Frame اختصاص دهد در بیشتر موارد منطقی نیست (به ویژه زمانی که GroupShape والد چندین بار در داخل سایر {{GroupShape}}ها تو در تو باشد). برای مثال:
``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// استثنای ArgumentException صادر می‌شود: مقادیر چارچوب باید تعریف شوند.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 
یا
``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// استثنای ArgumentException صادر می‌شود: مقدارهای x، y، عرض و ارتفاع باید تعریف شوند.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 
چنین کدی می‌تواند به وضعیت‌های نامشخص منجر شود. بنابراین محدودیت‌هایی برای استفاده از مقادیر تعریف‌نشده برای IShape.Frame اضافه شده است. مقادیر x، y، width، height، flipH، flipV و rotationAngle باید تعریف شوند (و نه به float.NaN یا NullableBool.NotDefined تنظیم شوند). کد مثال بالا اکنون یک استثنای ArgumentException تولید می‌کند.
این محدودیت‌ها در موارد زیر اعمال می‌شود:
``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// پارامترهای x، y، عرض و ارتفاع نمی‌توانند float.NaN باشند، و flipH، flipV
// نمی‌توانند NullableBool.NotDefined باشند:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// همان محدودیت برای هر متدی که یک شکل ایجاد می‌کند اعمال می‌شود:
AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 
اما ویژگی‌های چارچوب IShape.RawFrame می‌توانند تعریف‌نشده باشند. این مورد زمانی که یک شکل به یک placeholder لینک شده باشد منطقی است. سپس مقادیر تعریف‌نشده چارچوب شکل از شکل placeholder والد بازنویسی می‌شوند. اگر placeholder والد وجود نداشته باشد، آن شکل هنگام محاسبه چارچوب مؤثر بر پایه IShape.RawFrame از مقادیر پیش‌فرض استفاده می‌کند. مقادیر پیش‌فرض برای x، y، width، height، flipH، flipV و rotationAngle برابر 0 و NullableBool.False هستند. برای مثال:
``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // شکل به یک placeholder لینک شده است
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // اکنون شکل مقادیر x، y، height، flipH، flipV را از placeholder ارث‌برداری می‌کند و عرض=100 و rotationAngle=0 را بازنویسی می‌کند.
}
``` 
### **ویژگی‌های تغییر یافته**
#### **تغییر نام و نوع ویژگی Aspose.Slides.IShapeCollection.Parent**
- نوع ویژگی Aspose.Slides.IShapeCollection.Parent از ISlideComponent به اینترفیس جدید IGroupShape تغییر پیدا کرده است. اینترفیس IGroupShape یک نوادگان ISlideComponent است، بنابراین کدهای موجود نیازی به تغییر ندارند.
- نام ویژگی Aspose.Slides.IShapeCollection.Parent از Parent به ParentGroup تغییر یافته است.
#### **تغییر نوع ویژگی‌های Aspose.Slides.IShapeFrame.FlipH، .FlipV**
- نوع ویژگی Aspose.Slides.IShapeFrame.FlipH از bool به NullableBool تغییر یافته است.
- ویژگی IShape.Frame یک نمونه مؤثر از IShapeFrame را برمی‌گرداند (همهٔ ویژگی‌های آن دارای مقادیر مؤثر تعریف‌شده هستند).
- ویژگی IShape.RawFrame یک نمونه از IShapeFrame را برمی‌گرداند که هر ویژگی می‌تواند مقدار تعریف‌نشده داشته باشد (به‌ویژه FlipH یا FlipV می‌توانند مقدار NullableBool.NotDefined داشته باشند).