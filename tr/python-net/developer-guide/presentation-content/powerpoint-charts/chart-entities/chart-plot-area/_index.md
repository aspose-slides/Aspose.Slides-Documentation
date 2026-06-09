---
title: Python'da Sunum Grafiklerinin Plot Alanlarını Özelleştirme
linktitle: Plot Alanı
type: docs
url: /tr/python-net/chart-plot-area/
keywords:
- grafik
- plot alanı
- plot alanı genişliği
- plot alanı yüksekliği
- plot alanı boyutu
- yerleşim modu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint ve OpenDocument sunumlarındaki grafik plot alanlarını nasıl özelleştireceğinizi keşfedin. Slayt görsellerinizi zahmetsizce geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir grafiğin plot area ile nasıl çalışılacağını gösterir. Grafik düzenini doğrulayarak ve ardından X, Y, genişlik ve yükseklik değerlerini okuyarak plot area'nın gerçek konum ve boyutunu nasıl alacağınızı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında plot area'nın yerleşim modunun nasıl yapılandırılacağını, `LayoutTargetType` kullanarak plot area'nın iç bölgesiyle mi yoksa eksenler ve eksen etiketleriyle birlikte dış bölgesiyle mi hesaplanacağını gösterir.

## **Grafik Plot Area'nın Genişlik ve Yüksekliğini Al**
Aspose.Slides for Python via .NET, basit bir API sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan verilerle bir grafik ekleyin.
4. Gerçek değerleri almak için önce IChart.ValidateChartLayout() yöntemini çağırın.
5. Grafik unsurunun sol üst köşesine göre gerçek X konumunu (sol) alır.
6. Grafik unsurunun sol üst köşesine göre gerçek üst konumunu alır.
7. Grafik unsurunun gerçek genişliğini alır.
8. Grafik unsurunun gerçek yüksekliğini alır.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Grafik ile sunumu kaydet
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Plot Area'nın Yerleşim Modunu Ayarla**
Aspose.Slides for Python via .NET, grafik plot areaının yerleşim modunu ayarlamak için basit bir API sağlar. **LayoutTargetType** özelliği **ChartPlotArea** ve **IChartPlotArea** sınıflarına eklenmiştir. Plot area'nın yerleşimi manuel olarak tanımlanırsa, bu özellik alanın iç (ekseni ve eksen etiketlerini içermez) ya da dış (ekseni ve eksen etiketlerini içerir) kısmına göre yerleştirilip yerleştirilmeyeceğini belirler. **LayoutTargetType** enum'ında tanımlı iki olası değer vardır.

- **LayoutTargetType.Inner** - plot area boyutunun, plot area boyutunu belirleyeceğini, işaretçileri ve eksen etiketlerini içermeyeceğini belirtir.
- **LayoutTargetType.Outer** - plot area boyutunun, plot area, işaretçilerin ve eksen etiketlerinin boyutunu belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**actual_x, actual_y, actual_width ve actual_height hangi birimlerde döndürülür?**  
Puan (point) cinsindendir; 1 inç = 72 puandır. Bunlar Aspose.Slides koordinat birimleridir.

**Plot Area içeriği açısından Chart Area'dan nasıl farklıdır?**  
Plot Area, veri çizim bölgesidir (seri, ızgara çizgileri, trend çizgileri vb.); Chart Area çevredeki öğeleri (başlık, lejand vb.) içerir. 3B grafiklerde Plot Area ayrıca duvarları/tabanı ve eksenleri kapsar.

**Plot Area'nin X, Y, Genişlik ve Yükseklikleri, yerleşim manuel olduğunda nasıl yorumlanır?**  
Grafiğin genel boyutunun fraksiyonlarıdır (0–1); bu modda otomatik konumlandırma devre dışı bırakılır ve ayarladığınız fraksiyonlar kullanılır.

**Lejand eklenip/taşındırıldıktan sonra Plot Area konumu neden değişti?**  
Lejand, Plot Area'nın dışındaki grafik alanına yerleşir ancak yerleşimi ve kullanılabilir alanı etkiler, bu yüzden otomatik konumlandırma etkinken Plot Area kayabilir. (Bu, PowerPoint grafiklerinin standart davranışıdır.)