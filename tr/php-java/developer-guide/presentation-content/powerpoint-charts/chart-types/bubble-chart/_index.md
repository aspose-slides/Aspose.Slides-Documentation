---
title: PHP kullanarak Sunumlarda Balon Grafiklerini Özelleştirin
linktitle: Balon Grafik
type: docs
url: /tr/php-java/bubble-chart/
keywords:
- balon grafik
- balon boyutu
- boyut ölçeklendirme
- boyut temsili
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint'te Aspose.Slides for PHP via Java kullanarak güçlü balon grafikler oluşturun ve özelleştirin, veri görselleştirmenizi kolayca geliştirin."
---
## **Overview**

Bu makale Aspose.Slides'te balon grafiklerle nasıl çalışılacağını gösterir. `setBubbleSizeScale` yöntemiyle balon boyutlarını ölçeklendirme ve `setBubbleSizeRepresentation` yöntemiyle balon boyutu değerlerinin nasıl temsil edileceğini kontrol etme olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler bir balon grafik oluşturmayı, boyut ölçeklendirmesini ayarlamayı ve balon boyutu temsiliyetini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca “Bubble with 3‑D” grafik tipi desteğini açıklayan, pratik grafik sınırlarının performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu açıklayan kısa bir FAQ bölümü içerir.

## **Bubble Chart Size Scaling**
Aspose.Slides for PHP via Java, balon grafik boyut ölçeklendirme desteği sağlar. Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) ve [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) yöntemleri eklenmiştir. Aşağıda örnek bir örnek verilmiştir.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Represent Data as Bubble Chart Sizes**
Metotlar [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) ve [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) [ChartSeries](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartseriesgroup/) sınıflarına ve ilgili sınıflara eklenmiştir. **BubbleSizeRepresentation**, balon grafiklerde balon boyutu değerlerinin nasıl temsil edileceğini belirtir. Olası değerler şunlardır: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/BubbleSizeRepresentationType#Area) ve [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Buna göre, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/BubbleSizeRepresentationType) enum’u, verinin balon grafik boyutları olarak temsil edilmesinin olası yollarını belirtmek için eklenmiştir. Aşağıda örnek kod verilmiştir.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Evet. “Bubble with 3‑D” adında ayrı bir grafik tipi bulunur. Balonlara 3‑D stil uygular ancak ek bir eksen eklemez; veriler X‑Y‑S (boyut) olarak kalır. Bu tip, [chart type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) sınıfında mevcuttur.

**Is there a limit on the number of series and points in a bubble chart?**

API düzeyinde kesin bir sınırlama yoktur; kısıtlamalar performans ve hedef PowerPoint sürümüne göre belirlenir. Okunabilirlik ve render hızı için nokta sayısının makul tutulması önerilir.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Desteklenen formatlara dışa aktarma, grafiğin görünümünü korur; renderleme Aspose.Slides motoru tarafından gerçekleştirilir. Raster/vektör formatları için genel grafik render kuralları geçerlidir (çözünürlük, anti‑aliasing), bu yüzden baskı için yeterli DPI seçilmelidir.