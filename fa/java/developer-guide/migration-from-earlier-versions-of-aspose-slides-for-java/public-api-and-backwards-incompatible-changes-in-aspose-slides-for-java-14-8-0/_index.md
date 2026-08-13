---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 14.8.0
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا بتوانید راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را به‌سلاست منتقل کنید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌های [اضافه شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)، متدها، خصوصیات و غیره، هر محدودیت جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) معرفی‌شده با API Aspose.Slides for Java 14.8.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
### **متدهای Aspose.Slides.Charts.IChartSeries.getOverlap()، IChartSeriesGroup.getOverlap() و setOverlap(byte) اضافه شد**
متد Aspose.Slides.Charts.IChartSeries.getOverlap() مقدار همپوشانی نوارها و ستون‌ها در نمودارهای 2D را (در بازه‌ای از -100 تا 100) بر می‌گرداند. این متد نه تنها برای سری خاص بلکه برای تمام سری‌های گروه سری والد است - این یک نمایش از خصوصیت گروه مناسب است.

- از متد IChartSeries.getParentSeriesGroup() برای دسترسی به گروه سری والد استفاده کنید.
- از متدهای IChartSeriesGroup.getOverlap() و setOverlap(byte) برای مدیریت مقدار استفاده کنید.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **مقدار Enum ShapeThumbnailBounds.Appearance اضافه شد**
این روش ایجاد تصویرک‌های شکل به توسعه‌دهندگان امکان می‌دهد تصویرک شکلی را در محدوده ظاهر آن تولید کنند. تمام افکت‌های شکل در نظر گرفته می‌شود. تصویرک تولیدشده توسط محدودهٔ اسلاید محدود می‌شود.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **کلاس VbaProject و اینترفیس IVbaProject اضافه شد، متدهای Presentation.getVbaProject() و setVbaProject(VbaProject) تغییر یافت**
یک ویژگی جدید به توسعه‌دهندگان اجازه می‌دهد پروژه‌های VBA را در یک ارائه ایجاد و ویرایش کنند.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// ایجاد پروژه VBA جدید

pres.setVbaProject(new VbaProject());

// اضافه کردن ماژول خالی به پروژه VBA

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

// اضافه کردن مراجع به پروژه VBA

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```