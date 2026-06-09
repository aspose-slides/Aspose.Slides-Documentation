---
title: Python ile Sunumlarda Balon Grafiklerini Özelleştirin
linktitle: Balon Grafiği
type: docs
url: /tr/python-net/bubble-chart/
keywords:
- balon grafik
- balon boyutu
- boyut ölçekleme
- boyut temsili
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument'te güçlü balon grafikler oluşturun ve özelleştirin, veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'da balon grafiklerle nasıl çalışılacağını gösterir. `bubble_size_scale` özelliğiyle balon boyutlarını ölçeklendirme ve `bubble_size_representation` özelliğiyle balon boyutu değerlerinin nasıl temsil edileceğini kontrol etme olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir balon grafiği nasıl oluşturulacağını, boyut ölçeklemesinin nasıl ayarlanacağını ve balon boyutu temsilinin genişlik kullanacak şekilde nasıl değiştirileceğini gösterir. Makale ayrıca, “3-D etkili balon” grafik türünün desteğini açıklayan, pratik grafik sınırlamalarının performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu açıklayan kısa bir SSS bölümü içerir.

## **Balon Grafiği Boyut Ölçekleme**
Aspose.Slides for Python via .NET, Balon grafiği boyut ölçeklemesi desteği sağlar. Aspose.Slides for Python via .NET **ChartSeries.bubble_size_scale** ve **ChartSeriesGroup.bubble_size_scale** özellikleri eklenmiştir. Aşağıda örnek bir örnek verilmiştir. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Verileri Balon Grafiği Boyutları Olarak Temsil Et**
ChartSeries ve ChartSeriesGroup sınıflarına **bubble_size_representation** özelliği eklenmiştir. **bubble_size_representation**, balon grafiğinde balon boyutu değerlerinin nasıl temsil edileceğini belirtir. Olası değerler: **BubbleSizeRepresentationType.AREA** ve **BubbleSizeRepresentationType.WIDTH**. Bu doğrultuda, verileri balon grafiği boyutları olarak temsil etmenin olası yollarını belirten **BubbleSizeRepresentationType** enumu eklenmiştir. Aşağıda örnek kod verilmiştir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**"3-D etkili balon grafiği" destekleniyor mu ve normal birinden nasıl farklıdır?**

Evet. "Bubble with 3-D" adlı ayrı bir grafik türü vardır. Balonlara 3-D stil uygular ancak ek bir eksen eklemez; veriler X-Y-S (boyut) olarak kalır. Bu tür, [chart type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) enumunda mevcuttur.

**Balon grafiğinde seri ve nokta sayısı için bir limit var mı?**

API seviyesinde katı bir limit yoktur; sınırlamalar performans ve hedef PowerPoint sürümüne göre belirlenir. Okunabilirlik ve render hızı için nokta sayısının makul tutulması önerilir.

**Dışa aktarma, bir balon grafiğinin görünümünü (PDF, görüntüler) nasıl etkiler?**

Desteklenen formatlara dışa aktarma, grafiğin görünümünü korur; renderleme Aspose.Slides motoru tarafından gerçekleştirilir. Raster/vektör formatları için genel grafik render kuralları (çözünürlük, anti-aliasing) geçerlidir, bu yüzden baskı için yeterli DPI seçilmelidir.