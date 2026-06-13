---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 14.8.0
linktitle: Aspose.Slides برای .NET 14.8.0
type: docs
weight: 100
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا به‌راحتی راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام [اضافه شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) یا [حذف شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) کلاس‌ها، متدها، خصوصیات و غیره، و سایر تغییرات معرفی‌شده با Aspose.Slides for .NET 14.8.0 API را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
### **خواص تغییر یافته**
#### **اضافه شد رابط IVbaProject، تغییر یافت ویژگی Presentation.VbaProject**
ویژگی VbaProject کلاس Presentation جایگزین شده است. به جای نمایش بایت خام پروژه VBA در ویژگی VbaProject، پیاده‌سازی جدید رابط IVbaProject اضافه شده است.

از ویژگی IVbaProject برای مدیریت پروژه‌های VBA تعبیه‌شده در یک ارائه استفاده کنید. می‌توانید ارجاعات پروژه جدید اضافه کنید، ماژول‌های موجود را ویرایش کنید و ماژول‌های جدید ایجاد کنید.

همچنین می‌توانید با استفاده از کلاس VbaProject که رابط IVbaProject را پیاده‌سازی می‌کند، یک پروژه VBA جدید ایجاد کنید.

مثال زیر ایجاد یک پروژه VBA ساده شامل یک ماژول و افزودن دو مرجع ضروری به کتابخانه‌ها را نشان می‌دهد.

``` csharp

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

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **رابط‌ها، ویژگی‌ها و گزینه‌های شمارش اضافه شده**
#### **قابلیت Overlap در Aspose.Slides.Charts.IChartSeries اضافه شد**
ویژگی Aspose.Slides.Charts.IChartSeries.Overlap مشخص می‌کند که نوارها و ستون‌ها در نمودارهای دو‑بعدی تا چه حد بر هم هم پوشانده شوند (محدود به بازه -100 تا 100).

این ویژگی نه فقط برای این سری بلکه برای تمام سری‌ها در گروه سری والد است - این یک انعکاس از ویژگی مناسب گروه می‌باشد. بنابراین این ویژگی فقط خواندنی است.

- از ویژگی ParentSeriesGroup برای دسترسی به گروه سری والد استفاده کنید.
- از ویژگی ParentSeriesGroup.Overlap (خواندن/نوشتن) برای تغییر مقدار استفاده کنید.

``` csharp

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
#### **قابلیت Overlap در Aspose.Slides.Charts.IChartSeriesGroup اضافه شد**
ویژگی Aspose.Slides.Charts.IChartSeriesGroup.Overlap مشخص می‌کند که نوارها و ستون‌ها در نمودارهای دو‑بعدی تا چه حد بر هم هم پوشانده شوند (از -100 تا 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **مقدار Appearance در Enum ShapeThumbnailBounds اضافه شد**
این روش ایجاد تصویر کوچک شکل به شما امکان می‌دهد تصویر کوچک شکلی را در مرزهای ظاهر آن تولید کنید. تمام اثرات شکل در نظر گرفته می‌شوند. تصویر کوچک تولید شده توسط مرزهای اسلاید محدود می‌شود.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```