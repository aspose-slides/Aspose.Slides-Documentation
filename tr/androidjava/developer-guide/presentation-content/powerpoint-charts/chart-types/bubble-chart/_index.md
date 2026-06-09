---
title: Android'de Sunumlarda Balon Grafiklerini Özelleştirme
linktitle: Balon Grafik
type: docs
url: /tr/androidjava/bubble-chart/
keywords:
- balon grafik
- balon boyutu
- boyut ölçeklendirme
- boyut temsil
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint'te güçlü balon grafikler oluşturun ve özelleştirin, veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'da balon grafiklerle nasıl çalışılacağını gösterir. `setBubbleSizeScale` yöntemiyle balon boyutlarını ölçeklendirme ve `setBubbleSizeRepresentation` yöntemiyle balon boyutu değerlerinin nasıl temsil edileceğini kontrol etme gibi iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir balon grafik oluşturmayı, boyut ölçeklendirmesini ayarlamayı ve balon boyutu temsilini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca “Bubble with 3-D” grafik türünün desteklendiğini açıklayan, pratik grafik sınırlamalarının performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten ve dışa aktarmanın grafik görünümünü Aspose.Slides işleme motoru aracılığıyla koruduğunu anlatan kısa bir SSS bölümü içerir.

## **Balon Grafik Boyut Ölçeklendirme**
Aspose.Slides for Android via Java, balon grafik boyut ölçeklendirmesini destekler. Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) ve [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) yöntemleri eklendi. Aşağıda örnek kod verilmiştir.

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

## **Verileri Balon Grafik Boyutları Olarak Temsil Et**
Metotlar [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) ve [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) [IChartSeries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesGroup) arayüzlerine ve ilgili sınıflara eklenmiştir. **BubbleSizeRepresentation**, balon grafik içinde balon boyutu değerlerinin nasıl temsil edildiğini belirler. Olası değerler: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) ve [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). Bu doğrultuda, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/BubbleSizeRepresentationType) enum’u, verileri balon grafik boyutları olarak temsil etmenin olası yollarını belirtmek için eklenmiştir. Aşağıda örnek kod verilmiştir.

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

**"3-B boyutlu efekti olan balon grafik" destekleniyor mu ve normal bir grafikten nasıl farklıdır?**

Evet. Ayrı bir grafik türü, "Bubble with 3-D" mevcuttur. Bu, balonlara 3‑B stil uygular ancak ek bir eksen eklemez; veriler X‑Y‑S (boyut) olarak kalır. Bu tür, [chart type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) sınıfında bulunur.

**Balon grafikinde seri ve nokta sayısı için bir sınırlama var mı?**

API seviyesinde kesin bir sınırlama yoktur; kısıtlamalar performans ve hedef PowerPoint sürümüne göre belirlenir. Okunabilirlik ve işleme hızı açısından nokta sayısının makul tutulması önerilir.

**Dışa aktarma, bir balon grafiğinin (PDF, görüntüler) görünümünü nasıl etkiler?**

Desteklenen formatlara dışa aktarım, grafiğin görünümünü korur; işleme Aspose.Slides motoru tarafından yapılır. Raster/vektör formatları için genel grafik işleme kuralları (çözünürlük, anti-aliasing) geçerlidir; bu nedenle baskı için yeterli DPI seçilmelidir.