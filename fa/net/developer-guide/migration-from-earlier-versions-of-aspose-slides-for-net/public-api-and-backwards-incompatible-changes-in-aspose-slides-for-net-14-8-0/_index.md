---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 14.8.0
linktitle: Aspose.Slides برای .NET 14.8.0
type: docs
weight: 100
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات شکستنی در Aspose.Slides برای .NET را مرور کنید تا به‌صورت روان برنامه‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) یا [removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) هستند، و سایر تغییرات معرفی‌شده در API Aspose.Slides for .NET 14.8.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
### **ویژگی‌های تغییر یافته**
#### **افزودن رابط IVbaProject، تغییر ویژگی Presentation.VbaProject**
ویژگی VbaProject کلاس Presentation جایگزین شده است. به جای h3. Added Interfaces, Properties and Enumeration Options، نمایش بایت خام پروژه VBA، پیاده‌سازی جدید رابط IVbaProject اضافه شده است.

از ویژگی IVbaProject برای مدیریت پروژه‌های VBA که در یک ارائه جاسازی شده‌اند استفاده کنید. می‌توانید مراجع پروژه جدید اضافه کنید، ماژول‌های موجود را ویرایش کنید و ماژول‌های جدید ایجاد کنید.

همچنین، می‌توانید با استفاده از کلاس VbaProject که رابط IVbaProject را پیاده‌سازی می‌کند، یک پروژه VBA جدید ایجاد کنید.

مثال زیر ایجاد یک پروژه VBA ساده شامل یک ماژول و افزودن دو مرجع ضروری به کتابخانه‌ها را نشان می‌دهد.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())
{

    // ایجاد پروژه VBA جدید
    pres.VbaProject = new VbaProject();
    // افزودن ماژول خالی به پروژه VBA
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");
    // تنظیم کد منبع ماژول
    module.SourceCode =
        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // ایجاد مرجع به <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // ایجاد مرجع به Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // افزودن مراجع به پروژه VBA
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

این مثال نشان می‌دهد که چگونه یک پروژه VBA را از یک ارائه موجود به یک ارائه جدید کپی کنید.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **رابط‌ها، ویژگی‌ها و مقادیر شمارشی افزوده شده**
#### **افزودن ویژگی Aspose.Slides.Charts.IChartSeries.Overlap**
ویژگی Aspose.Slides.Charts.IChartSeries.Overlap تعیین می‌کند که ستون‌ها و نوارها در نمودارهای دو بعدی تا چه اندازه هم‌پوشانی داشته باشند (محدوده از -100 تا 100).

این ویژگی نه تنها برای این سری، بلکه برای تمام سری‌های گروه سری والد است - این یک نمایش از ویژگی گروه مربوطه است. به همین دلیل این ویژگی فقط‑خواندنی است.

- برای دسترسی به گروه سری والد از ویژگی ParentSeriesGroup استفاده کنید.
- برای تغییر مقدار، از ویژگی ParentSeriesGroup.Overlap که قابلیت خواندن/نوشتن دارد استفاده کنید.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **افزودن ویژگی Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
ویژگی Aspose.Slides.Charts.IChartSeriesGroup.Overlap تعیین می‌کند که ستون‌ها و نوارها در نمودارهای دو بعدی تا چه میزان هم‌پوشانی داشته باشند (از -100 تا 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **افزودن مقدار Enum ShapeThumbnailBounds.Appearance**
این روش ایجاد تصویر کوچک شکل به شما امکان می‌دهد تا یک تصویر کوچک شکل را در محدوده ظاهر آن تولید کنید. تمام افکت‌های شکل در نظر گرفته می‌شود. تصویر کوچک شکل تولید شده توسط مرزهای اسلاید محدود می‌شود.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```