---
title: API عمومی و تغییرات ناسازگار به سمت عقب در Aspose.Slides برای .NET 14.9.0
linktitle: Aspose.Slides برای .NET 14.9.0
type: docs
weight: 110
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- اسناد باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بازبینی به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET برای مهاجرت یکپارچهٔ راه‌حل‌های ارائهٔ PowerPoint PPT، PPTX و ODP."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، خواص و غیرهٔ [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) را فهرست می‌کند و سایر تغییرات معرفی‌شده با API Aspose.Slides برای .NET 14.9.0.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **ارث‌بری از اینترفیس‌های ICollection و Generic IEnumerable به ISmartArtNodeCollection اضافه شد**
کلاس Aspose.Slides.SmartArt.SmartArtNodeCollection (و اینترفیس مرتبط Aspose.Slides.SmartArt.ISmartArtNodeCollection) اینترفیس عمومی IEnumerable<ISmartArtNode> و اینترفیس ICollection را به ارث می‌برند.
#### **مقدار Enum SmartArtLayoutType.Custom اضافه شد**
نوع چیدمان سفارشی SmartArt نمایانگر یک نمودار با الگوی سفارشی است. نمودارهای سفارشی فقط می‌توانند از یک فایل ارائه بارگذاری شوند و نمی‌توانند با متد ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) ایجاد شوند.
#### **کلاس SmartArtShape و اینترفیس ISmartArtShape اضافه شد**
کلاس Aspose.Slides.SmartArt.SmartArtShape (و اینترفیس Aspose.Slides.SmartArt.ISmartArtShape) دسترسی به اشکال فردی در یک نمودار SmartArt را فراهم می‌کند. می‌توان از SmartArtShape برای تغییر FillFormat، LineFormat، افزودن Hyperlink و سایر تسک‌ها استفاده کرد.

{{% alert color="primary" %}} 

**نکته**: SmartArtShape از خواص IShape شامل RawFrame، Frame، Rotation، X، Y، Width و Height پشتیبانی نمی‌کند و هنگام دسترسی به آن‌ها یک System.NotSupportedException بر می‌گرداند.

مثال استفاده:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **کلاس SmartArtShapeCollection، اینترفیس ISmartArtShapeCollection و ویژگی ISmartArtNode.Shapes اضافه شد**
کلاس Aspose.Slides.SmartArt.SmartArtShapeCollection (و اینترفیس Aspose.Slides.SmartArt.ISmartArtShapeCollection) دسترسی به اشکال فردی در یک نمودار SmartArt را اضافه می‌کند. این مجموعه شامل اشکالی است که با SmartArtNode مرتبط هستند. ویژگی SmartArtNode.Shapes مجموعه‌ای از تمام اشکال مرتبط با گره را بازمی‌گرداند.

{{% alert color="primary" %}} 

**نکته**: بسته به مقدار SmartArtLayoutType، یک SmartArtShape می‌تواند بین چند گره به‌اشتراک گذاشته شود.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **متدهای ذخیره‌سازی اسلایدها با حفظ شماره صفحات اضافه شد**
متدهای زیر اضافه شده‌اند:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

این متدها به توسعه‌دهندگان اجازه می‌دهند اسلایدهای مشخص شده‌ی ارائه را به فرمت‌های PDF، XPS، TIFF، HTML ذخیره کنند. آرایه ‘slides’ برای تعیین شماره صفحات استفاده می‌شود و از ۱ شروع می‌گردد.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //آرایه‌ای از موقعیت‌های اسلایدها
presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **متدهای جایگزینی تصویر به PPImage، IPPImage اضافه شد**
متدهای جدید اضافه شده‌اند:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//روش اول

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//روش دوم

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//روش سوم

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```