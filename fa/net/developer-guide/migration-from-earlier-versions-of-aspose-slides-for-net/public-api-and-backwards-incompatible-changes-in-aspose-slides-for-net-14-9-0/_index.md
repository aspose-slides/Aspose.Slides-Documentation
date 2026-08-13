---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 14.9.0
linktitle: Aspose.Slides برای .NET 14.9.0
type: docs
weight: 110
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا به‌صورت یکپارچه ارائه‌های PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، خصوصیت‌ها و غیره که [added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) یا [removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) شده‌اند و سایر تغییرات معرفی‌شده با Aspose.Slides for .NET 14.9.0 API را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **ارث‌بری از رابط‌های ICollection و Generic IEnumerable به ISmartArtNodeCollection اضافه شد**
کلاس Aspose.Slides.SmartArt.SmartArtNodeCollection (و رابط مرتبط Aspose.Slides.SmartArt.ISmartArtNodeCollection) رابط عمومی IEnumerable<ISmartArtNode> و رابط ICollection را ارث می‌برند.
#### **مقدار Enum SmartArtLayoutType.Custom اضافه شد**
نوع چیدمان سفارشی SmartArt نشان‌دهنده یک نمودار با الگوی سفارشی است. نمودارهای سفارشی فقط می‌توانند از یک فایل ارائه بارگذاری شوند و نمی‌توان آنها را با متد ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) ایجاد کرد.
#### **کلاس SmartArtShape و رابط ISmartArtShape اضافه شدند**
کلاس Aspose.Slides.SmartArt.SmartArtShape (و رابط آن Aspose.Slides.SmartArt.ISmartArtShape) دسترسی به اشکال منفرد در یک نمودار SmartArt را فراهم می‌کند. می‌توان از SmartArtShape برای تغییر FillFormat، LineFormat، افزودن Hyperlinkها و سایر کارها استفاده کرد.

{{% alert color="info" %}} 

**توجه**: SmartArtShape از ویژگی‌های IShape شامل RawFrame، Frame، Rotation، X، Y، Width و Height پشتیبانی نمی‌کند و در هنگام تلاش برای دسترسی به آن‌ها یک System.NotSupportedException ایجاد می‌کند.

مثال استفاده:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **کلاس SmartArtShapeCollection، رابط ISmartArtShapeCollection و ویژگی ISmartArtNode.Shapes اضافه شدند**
کلاس Aspose.Slides.SmartArt.SmartArtShapeCollection (و رابط آن Aspose.Slides.SmartArt.ISmartArtShapeCollection) دسترسی به اشکال منفرد در یک نمودار SmartArt را فراهم می‌کند. این مجموعه شامل اشکالی است که به SmartArtNode مرتبط هستند. ویژگی SmartArtNode.Shapes مجموعه‌ای از تمام اشکال مرتبط با گره را بر می‌گرداند.

{{% alert color="info" %}} 

**توجه**: بسته به SmartArtLayoutType یک SmartArtShape می‌تواند بین چندین گره به اشتراک گذاشته شود.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **متدهای ذخیره‌سازی اسلایدها با حفظ شماره صفحات اضافه شدند**
متدهای زیر اضافه شده‌اند:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

این متدها به توسعه‌دهندگان امکان می‌دهند اسلایدهای مشخصی از ارائه را به فرمت‌های PDF، XPS، TIFF، HTML ذخیره کنند. آرایه `slides` برای مشخص کردن شماره صفحات (از ۱ شروع) استفاده می‌شود.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //آرایه‌ای از موقعیت اسلایدها

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **متدهای جایگزینی تصویر به PPImage، IPPImage اضافه شدند**
متدهای جدید اضافه شده‌اند:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //روش اول

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //روش دوم

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //روش سوم

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```