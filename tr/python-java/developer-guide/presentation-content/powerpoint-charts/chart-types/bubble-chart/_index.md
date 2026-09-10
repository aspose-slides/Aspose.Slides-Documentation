---
title: Python Kullanarak Sunumlarda Balon Grafiklerini Özelleştirme
linktitle: Balon Grafiği
type: docs
url: /tr/python-java/bubble-chart/
keywords:
- balon grafiği
- balon boyutu
- boyut ölçeklendirme
- boyut temsili
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint'te güçlü balon grafikler oluşturun ve özelleştirin; veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde balon grafiklerle nasıl çalışılacağını gösterir. İki özel özelleştirme seçeneğini kapsar: balon boyutlarını [setBubbleSizeScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) yöntemiyle ölçeklendirme ve balon boyutu değerlerinin nasıl temsil edileceğini [setBubbleSizeRepresentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) yöntemiyle kontrol etme.

Örnekler, bir balon grafik oluşturmayı, boyut ölçeklendirmesini ayarlamayı ve balon boyutu temsilini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca, “Bubble with 3-D” grafik türünün desteğini açıklayan, pratik grafik limitlerinin performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu anlatan kısa bir **SSS** bölümü içerir.

## **Balon Grafik Boyut Ölçeklendirmesi**

Aspose.Slides for Python via Java, balon grafik boyut ölçeklendirmesini [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) ve [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) yöntemleriyle destekler. Aşağıdaki örnek, balon boyutlarını nasıl ölçeklendireceğinizi gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verileri Balon Grafik Boyutları Olarak Temsil Et**

[setBubbleSizeRepresentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) ve [getBubbleSizeRepresentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) yöntemleri, [ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/) sınıfında mevcuttur. Balon boyutu temsili, balon grafik içinde balon boyutu değerlerinin nasıl temsil edileceğini belirler. Olası değerler [BubbleSizeRepresentationType.Area](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bubblesizerepresentationtype/#Area) ve [BubbleSizeRepresentationType.Width](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bubblesizerepresentationtype/#Width)'tir. [BubbleSizeRepresentationType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/bubblesizerepresentationtype/) enum'ı, verileri balon grafik boyutları olarak temsil etmenin olası yollarını belirtir. Aşağıdaki örnek, genişlik kullanarak balon boyutlarını nasıl temsil edeceğinizi gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**“3-D efektli balon grafik” destekleniyor mu ve normal bir grafikten nasıl farklıdır?**

Evet. “Bubble with 3-D” adlı ayrı bir grafik türü vardır. Bu, balonlara 3‑B stil uygular ancak ek bir eksen eklemez; veriler X‑Y‑S (boyut) olarak kalır. Bu tür, [chart type](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/) sınıfında mevcuttur.

**Bir balon grafiğinde seri ve nokta sayısı için bir sınırlama var mı?**

API seviyesinde sabit bir sınırlama yoktur; kısıtlamalar performans ve hedef PowerPoint sürümüne göre belirlenir. Okunabilirlik ve render hızını korumak için nokta sayısının makul düzeyde tutulması önerilir.

**Dışa aktarma, bir balon grafiğinin görünümünü (PDF, görüntüler) nasıl etkiler?**

Desteklenen formatlara dışa aktarma, grafiğin görünümünü korur; renderleme Aspose.Slides motoru tarafından gerçekleştirilir. Raster/vektör formatları için genel grafik render kuralları (çözünürlük, anti-aliasing) geçerlidir; bu yüzden baskı için yeterli DPI seçilmelidir.