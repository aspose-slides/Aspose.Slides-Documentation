---
title: Экспортировать график
type: документы
weight: 90
url: /java/export-chart/
---

## **Получить изображение графика**
Aspose.Slides для Java предоставляет поддержку для извлечения изображения конкретного графика. Ниже приведён пример.

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