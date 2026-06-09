---
title: .NET'te Sunum Grafiklerinin Çizim Alanlarını Özelleştirme
linktitle: Çizim Alanı
type: docs
url: /tr/net/chart-plot-area/
keywords:
- grafik
- çizim alanı
- çizim alanı genişliği
- çizim alanı yüksekliği
- çizim alanı boyutu
- yerleşim modu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarındaki grafik çizim alanlarını nasıl özelleştireceğinizi keşfedin. Kaydırak görsellerinizi zahmetsizce iyileştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te bir grafiğin çizim alanı (plot area) ile nasıl çalışılacağını gösterir. Grafiğin düzenini doğrulayıp X, Y, genişlik ve yükseklik değerlerini okuyarak çizim alanının gerçek konum ve boyutlarını nasıl alacağınızı açıklar.

Ayrıca, düzen manuel olarak ayarlandığında `LayoutTargetType` kullanarak çizim alanının iç bölgesi mi yoksa eksenler ve eksen etiketleri dahil dış bölgesi mi temel alınarak hesaplanacağını tanımlayarak çizim alanının düzen modunun nasıl yapılandırılacağını gösterir.

## **Bir Grafik Çizim Alanının Genişlik ve Yüksekliğini Almak**
Aspose.Slides for .NET basit bir API sağlar.

1. Bir [Sunum](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan verilerle bir grafik ekleyin.
4. Gerçek değerleri almak için önce IChart.ValidateChartLayout() metodunu çağırın.
5. Grafik öğesinin sol üst köşesine göre gerçek X konumunu (sol) alır.
6. Grafik öğesinin sol üst köşesine göre gerçek üst konumunu alır.
7. Grafik öğesinin gerçek genişliğini alır.
8. Grafik öğesinin gerçek yüksekliğini alır.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Grafikli sunumu kaydet
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **Bir Grafik Çizim Alanının Yerleşim Modunu Ayarlama**
Aspose.Slides for .NET, grafik çizim alanının yerleşim modunu ayarlamak için basit bir API sağlar. **LayoutTargetType** özelliği **ChartPlotArea** ve **IChartPlotArea** sınıflarına eklenmiştir. Çizim alanının düzeni manuel olarak tanımlanırsa, bu özellik alanın iç bölgesi (eksen ve eksen etiketleri hariç) mi yoksa dış bölgesi (eksen ve eksen etiketleri dahil) mi kullanılacağını belirtir. **LayoutTargetType** enum'unda tanımlı iki olası değer vardır.

- **LayoutTargetType.Inner** – Çizim alanının boyutunun, işaret çizgileri ve eksen etiketleri dahil olmaksızın iç bölgeyi belirleyeceğini belirtir.
- **LayoutTargetType.Outer** – Çizim alanının boyutunun, işaret çizgileri ve eksen etiketleri dahil olmak üzere dış bölgeyi belirleyeceğini belirtir.

Aşağıda örnek kod verilmiştir.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**ActualX, ActualY, ActualWidth ve ActualHeight hangi birimlerde döndürülür?**

Puan (point) cinsindendir; 1 inç = 72 puan. Bunlar Aspose.Slides koordinat birimleridir.

**Plot Area içeriği Chart Area'dan nasıl farklıdır?**

Plot Area, veri çizim bölgesidir (seriler, ızgara çizgileri, eğri çizgileri vb.); Chart Area ise çevresel öğeleri (başlık, lejand vb.) içerir. 3D grafiklerde Plot Area, duvarları/kapak ve eksenleri de kapsar.

**Düzen manuel olduğunda Plot Area’nın X, Y, Genişlik ve Yükseklik değerleri nasıl yorumlanır?**

Grafiğin toplam boyutunun kesirleri (0–1) olarak kabul edilir; bu modda otomatik konumlandırma devre dışı bırakılır ve belirttiğiniz kesirler kullanılır.

**Lejant eklendikten/taşındırıldıktan sonra Plot Area konumu neden değişti?**

Lejant, Plot Area dışındaki grafik alanında yer alır ancak düzeni ve kullanılabilir alanı etkiler; otomatik konumlandırma etkinse Plot Area kayabilir. (Bu, PowerPoint grafiklerinin standart davranışıdır.)