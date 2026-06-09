---
title: Java Kullanarak Sunumlarda Balon Grafiklerini Özelleştirin
linktitle: Balon Grafiği
type: docs
url: /tr/java/bubble-chart/
keywords:
- balon grafiği
- balon boyutu
- boyut ölçekleme
- boyut temsili
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint'te güçlü balon grafikler oluşturun ve özelleştirin, veri görselleştirmelerinizi kolayca iyileştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde balon grafiklerle nasıl çalışılacağını gösterir. `setBubbleSizeScale` yöntemiyle balon boyutlarını ölçeklendirme ve `setBubbleSizeRepresentation` yöntemiyle balon boyutu değerlerinin nasıl temsil edildiğini kontrol etme olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir balon grafiği oluşturmayı, boyut ölçeklemesini ayarlamayı ve balon boyutu temsiliyetini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca “Bubble with 3‑D” grafik türünün desteklenmesini açıklayan, pratik grafik limitlerinin performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu anlatan kısa bir SSS bölümü içerir.

## **Balon Grafiği Boyut Ölçekleme**
Aspose.Slides for Java, Balon grafik boyut ölçeklemesi için destek sağlar. Aspose.Slides for Java içinde [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) ve [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) yöntemleri eklendi. Aşağıda örnek bir kod verilmiştir.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verileri Balon Grafik Boyutları Olarak Temsil Etme**
Metotlar [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) ve [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) [IChartSeries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesGroup) arayüzlerine ve ilgili sınıflara eklenmiştir. **BubbleSizeRepresentation**, balon grafik içinde balon boyutu değerlerinin nasıl temsil edildiğini belirtir. Olası değerler şunlardır: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/BubbleSizeRepresentationType#Area) ve [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Bu doğrultuda, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/BubbleSizeRepresentationType) enumu, verileri balon grafik boyutları olarak temsil etmenin olası yollarını belirtmek için eklenmiştir. Aşağıda örnek kod verilmiştir.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**“3‑D etkili balon grafik” destekleniyor mu ve normal bir grafikten nasıl farklıdır?**

Evet. “Bubble with 3‑D” adlı ayrı bir grafik türü vardır. Bu, balonlara 3‑D stil uygular ancak ekstra bir eksen eklemez; veriler X‑Y‑S (boyut) olarak kalır. Bu tür, [chart type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) sınıfında mevcuttur.

**Balon grafiklerinde seri ve nokta sayısı için bir limit var mı?**

API seviyesinde katı bir limit yoktur; sınırlamalar performans ve hedef PowerPoint sürümüne bağlıdır. Okunabilirlik ve render hızını korumak için nokta sayısının makul tutulması önerilir.

**Dışa aktarma, bir balon grafiğinin görünümünü (PDF, görüntüler) nasıl etkiler?**

Desteklenen formatlara dışa aktarım, grafiğin görünümünü korur; renderleme Aspose.Slides motoru tarafından yapılır. Raster/vektör formatları için genel grafik renderleme kuralları (çözünürlük, anti‑aliasing) geçerlidir; bu nedenle baskı için yeterli DPI seçilmelidir.