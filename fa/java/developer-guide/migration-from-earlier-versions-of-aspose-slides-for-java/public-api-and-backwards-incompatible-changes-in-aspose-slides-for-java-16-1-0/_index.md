---
title: API عمومی و تغییرات ناسازگار با نسخه قبلی در Aspose.Slides برای Java 16.1.0
linktitle: Aspose.Slides برای Java 16.1.0
type: docs
weight: 200
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}}

این صفحه تمام [اضافه](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) یا [حذف](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) کلاس‌ها، متدها، ویژگی‌ها و غیره، و سایر تغییراتی که با API Aspose.Slides برای Java 16.1.0 معرفی شده‌اند را فهرست می‌کند.

{{% /alert %}}
## **تغییرات API عمومی**

#### **متدهای getRotationAngle() و setRotationAngle() به رابط‌های IChartTextBlockFormat و ITextFrameFormat اضافه شده‌اند**

متدهای getRotationAngle() و setRotationAngle() به رابط‌های com.aspose.slides.IChartTextBlockFormat و com.aspose.slides.ITextFrameFormat اضافه شده‌اند.
آنها دسترسی به چرخش سفارشی که بر متن داخل جعبه مرزی اعمال می‌شود را فراهم می‌کنند.

``` java



Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```