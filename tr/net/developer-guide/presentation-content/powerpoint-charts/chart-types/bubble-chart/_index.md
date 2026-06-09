---
title: ".NET’te Sunumlarda Balon Grafiklerini Özelleştirme"
linktitle: "Balon Grafik"
type: docs
url: /tr/net/bubble-chart/
keywords:
- "balon grafik"
- "balon boyutu"
- "boyut ölçeklendirme"
- "boyut temsili"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile PowerPoint’te güçlü balon grafikler oluşturun ve özelleştirin, veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te balon grafiklerle nasıl çalışılacağını gösterir. `BubbleSizeScale` özelliğiyle balon boyutlarının ölçeklendirilmesi ve `BubbleSizeRepresentation` özelliğiyle balon boyutu değerlerinin nasıl temsil edileceği olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir balon grafiği oluşturmayı, boyut ölçeklendirmesini ayarlamayı ve balon boyutu temsilini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca “3‑B Özelikli Balon” grafik tipinin desteklenmesi, pratik grafik sınırlamalarının performans ve hedef PowerPoint sürümüne bağlı olduğu ve dışa aktarmanın grafiğin görünümünü Aspose.Slides işleme motoru aracılığıyla koruduğunu açıklayan kısa bir SSS bölümü içerir.

## **Balon Grafik Boyut Ölçekleme**
Aspose.Slides for .NET, Balon grafik boyut ölçeklemesi desteği sağlar. Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** ve **IChartSeriesGroup.BubbleSizeScale** özellikleri eklenmiştir. Aşağıda örnek bir kod verilmiştir.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Verileri Balon Grafik Boyutları Olarak Temsil Et**
**BubbleSizeRepresentation** özelliği IChartSeries, IChartSeriesGroup arayüzlerine ve ilgili sınıflara eklenmiştir. **BubbleSizeRepresentation**, balon grafiğinde balon boyutu değerlerinin nasıl temsil edileceğini belirtir. Olası değerler: **BubbleSizeRepresentationType.Area** ve **BubbleSizeRepresentationType.Width**. Buna göre, **BubbleSizeRepresentationType** enumu, verilerin balon grafik boyutları olarak temsil edilmesinin olası yollarını tanımlamak için eklenmiştir. Aşağıda örnek kod bulunmaktadır.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**“3‑B Özelikli balon grafik” destekleniyor mu ve normal grafikten nasıl farklılık gösterir?**

Evet. “Bubble with 3-D” adlı ayrı bir grafik tipi vardır. Balonlara 3‑B stil uygulanır ancak ek bir eksen eklenmez; veriler X‑Y‑S (boyut) olarak kalır. Bu tip, [chart type](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) enumunda bulunur.

**Balon grafiğinde seri ve nokta sayısı için bir sınırlama var mı?**

API düzeyinde katı bir sınırlama yoktur; kısıtlamalar performans ve hedef PowerPoint sürümüne bağlıdır. Okunabilirlik ve işleme hızını korumak için nokta sayısının makul düzeyde tutulması önerilir.

**Dışa aktarma balon grafiğinin (PDF, görüntüler) görünümünü nasıl etkiler?**

Desteklenen formatlara dışa aktarım, grafiğin görünümünü korur; işleme Aspose.Slides motoru tarafından yapılır. Raster/vektör formatları için genel grafik işleme kuralları geçerlidir (çözünürlük, anti-aliasing), bu nedenle baskı için yeterli DPI seçilmelidir.