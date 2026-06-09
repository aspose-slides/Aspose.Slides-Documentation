---
title: JavaScript Kullanarak Sunumlarda Baloncuk Grafiklerini Özelleştirme
linktitle: Baloncuk Grafiği
type: docs
url: /tr/nodejs-java/bubble-chart/
keywords:
- baloncuk grafiği
- baloncuk boyutu
- boyut ölçekleme
- boyut temsili
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js via Java kullanarak PowerPoint'te güçlü baloncuk grafiklerini oluşturun ve özelleştirin, veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde baloncuk grafikleriyle nasıl çalışılacağını gösterir. `setBubbleSizeScale` yöntemiyle baloncuk boyutlarını ölçeklendirme ve `setBubbleSizeRepresentation` yöntemiyle baloncuk boyutu değerlerinin nasıl temsil edileceğini kontrol etme olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir baloncuk grafiği oluşturmayı, boyut ölçeklemesini ayarlamayı ve baloncuk boyutu temsilini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca, “3‑D’li Baloncuk” grafik tipinin desteğini açıklayan kısa bir SSS bölümü, pratik grafik limitlerinin performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten bir not ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu açıklayan bir bölüm içerir.

## **Baloncuk Grafik Boyut Ölçeklemesi**
Aspose.Slides for Node.js via Java, Baloncuk grafik boyut ölçeklemesi desteği sağlar. Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--) , [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) ve [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) yöntemleri eklenmiştir. Aşağıdaki örnek kod verilmiştir.  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Verileri Baloncuk Grafik Boyutları Olarak Temsil Et**
[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) ve [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) yöntemleri, [ChartSeries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeries) , [ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesGroup) sınıflarına ve ilgili sınıflara eklenmiştir. **BubbleSizeRepresentation**, baloncuk grafiklerinde baloncuk boyutu değerlerinin nasıl temsil edileceğini belirler. Olası değerler şunlardır: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) ve [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Buna göre, veri baloncuk grafik boyutları olarak nasıl temsil edileceğini belirten olası yolları tanımlamak için [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BubbleSizeRepresentationType) enum’u eklenmiştir. Aşağıda örnek kod verilmiştir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**“3D etkili baloncuk grafik” destekleniyor mu ve normal bir grafikten nasıl farklıdır?**

Evet. “Bubble with 3‑D” adlı ayrı bir grafik tipi vardır. Baloncuklara 3‑D stil uygularken ek bir eksen eklemez; veri X‑Y‑S (boyut) olarak kalır. Bu tip, [grafik tipi](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) enum’unda bulunur.

**Baloncuk grafiğinde serilerin ve noktaların sayısı için bir limit var mı?**

API düzeyinde sabit bir limit yoktur; kısıtlamalar performans ve hedef PowerPoint sürümüne bağlıdır. Okunabilirlik ve render hızı için nokta sayısının makul tutulması önerilir.

**Dışa aktarım baloncuk grafiğinin görünümünü (PDF, görüntüler) nasıl etkiler?**

Desteklenen formatlara dışa aktarım, grafiğin görünümünü korur; renderleme Aspose.Slides motoru tarafından yapılır. Raster/vektör formatları için genel grafik render kuralları (çözünürlük, anti‑aliasing) geçerlidir; bu nedenle yazdırma için yeterli DPI seçilmelidir.