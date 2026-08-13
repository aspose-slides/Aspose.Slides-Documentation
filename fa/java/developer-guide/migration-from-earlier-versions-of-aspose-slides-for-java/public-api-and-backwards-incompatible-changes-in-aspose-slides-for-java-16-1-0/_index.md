---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای Java 16.1.0
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
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای Java را بررسی کنید تا بتوانید به‌صورت یکپارچه راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}}
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) یا [removed](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) شده‌اند و سایر تغییراتی که با API Aspose.Slides for Java 16.1.0 معرفی شده‌اند را فهرست می‌کند.
{{% /alert %}}
## **تغییرات API عمومی**

#### **متدهای getRotationAngle() و setRotationAngle() به اینترفیس‌های IChartTextBlockFormat و ITextFrameFormat اضافه شده‌اند**
متدهای getRotationAngle() و setRotationAngle() به اینترفیس‌های com.aspose.slides.IChartTextBlockFormat و com.aspose.slides.ITextFrameFormat اضافه شده‌اند. آن‌ها دسترسی به چرخش سفارشی که بر روی متن داخل جعبه مرز اعمال می‌شود را فراهم می‌کنند.

``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```