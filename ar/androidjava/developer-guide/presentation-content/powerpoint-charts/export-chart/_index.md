---
title: تصدير الرسم البياني
type: docs
weight: 90
url: /androidjava/export-chart/
---

## **احصل على صورة الرسم البياني**
توفر Aspose.Slides لنظام Android عبر Java دعمًا لاستخراج صورة للرسم البياني المحدد.  المثال التالي موضح أدناه. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```