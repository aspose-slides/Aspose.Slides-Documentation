---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای Java 15.8.0
linktitle: Aspose.Slides برای Java 15.8.0
type: docs
weight: 160
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای Java را بررسی کنید تا به‌راحتی راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، خصوصیات و غیره که [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) یا [removed](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) شده‌اند و سایر تغییرات معرفی‌شده با API Aspose.Slides برای Java 15.8.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای getDoughnutHoleSize()، setDoughnutHoleSize(byte) به IChartSeries و ChartSeries اضافه شده‌اند**
اندازهٔ سوراخ در یک نمودار دونات را مشخص می‌کند.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```