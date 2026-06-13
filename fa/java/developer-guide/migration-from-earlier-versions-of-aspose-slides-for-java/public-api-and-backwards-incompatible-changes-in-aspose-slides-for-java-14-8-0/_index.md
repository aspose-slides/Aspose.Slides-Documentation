---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای Java 14.8.0
linktitle: Aspose.Slides برای Java 14.8.0
type: docs
weight: 70
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای Java را مرور کنید تا به‌صورت روان ارائه‌های PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام کلاس‌ها، متدها، خصوصیات و غیره‌ٔ {{added}}(/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) را فهرست می‌کند، هر محدودیت جدید و سایر {{changes}}(/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) معرفی‌شده با API Aspose.Slides for Java 14.8.0.
{{% /alert %}} 
## **تغییرات API عمومی**
### **اضافه شد Aspose.Slides.Charts.IChartSeries.getOverlap()، IChartSeriesGroup.getOverlap() و setOverlap(byte) متدها**
متد Aspose.Slides.Charts.IChartSeries.getOverlap() مقدار همپوشانی میله‌ها و ستون‌ها را در نمودارهای دو‑بعدی (در بازه ‑100 تا 100) به دست می‌آورد. این متد نه فقط برای سری خاصی بلکه برای تمام سری‌های گروه سری والد است – این یک انتساب از خصوصیت مناسب گروه است.

- از متد IChartSeries.getParentSeriesGroup() برای دسترسی به گروه سری والد استفاده کنید.
- از متدهای IChartSeriesGroup.getOverlap() و setOverlap(byte) برای مدیریت مقدار استفاده کنید.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **اضافه شد مقدار Enum ShapeThumbnailBounds.Appearance**
این روش ایجاد تصویرهای بندانگشتی شکل به توسعه‌دهندگان اجازه می‌دهد تا تصویر بندانگشتی یک شکل را در محدوده ظاهر آن تولید کنند. تمام اثرات شکل در نظر گرفته می‌شوند. تصویر بندانگشتی تولید شده توسط محدوده اسلاید محدود می‌شود.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **اضافه شد کلاس VbaProject و اینترفیس IVbaProject، متدهای Presentation.getVbaProject() و setVbaProject(VbaProject) تغییر یافتند**
یک ویژگی جدید به توسعه‌دهندگان اجازه می‌دهد تا پروژه‌های VBA را در یک ارائه ایجاد و ویرایش کنند.

``` java

 Presentation pres = new Presentation();

// ایجاد پروژه VBA جدید

pres.setVbaProject(new VbaProject());

// افزودن ماژول خالی به پروژه VBA

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// تنظیم کد منبع ماژول

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// ایجاد مرجع به <stdole>

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// ایجاد مرجع به Office

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// افزودن مراجعات به پروژه VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```