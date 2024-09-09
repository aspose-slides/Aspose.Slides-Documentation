---
title: Export Chart
type: docs
weight: 90
url: /java/export-chart/
---

## **Get Chart Image**
Aspose.Slides for Java provides support for extracting image of specific chart. Below sample example is given. 

```javascript
    var pres = new  com.aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
        var slideImage = chart.getImage();
        try {
            slideImage.save("image.jpg", com.aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
