---
title: تصدير الرسم البياني
type: docs
weight: 90
url: /ar/java/export-chart/
---

## **احصل على صورة الرسم البياني**
توفر Aspose.Slides لـ Java دعمًا لاستخراج صورة لرسم بياني محدد. المثال التالي موضح أدناه.

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