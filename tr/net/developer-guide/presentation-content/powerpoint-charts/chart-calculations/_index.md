---
title: Sunumlarda .NET için Grafik Hesaplamalarını Optimize Et
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/net/chart-calculations/
keywords:
- grafik hesaplamaları
- grafik öğeleri
- öğe konumu
- gerçek konum
- alt öğe
- üst öğe
- grafik değerleri
- gerçek değer
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te PPT ve PPTX için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü, pratik C# kod örnekleriyle anlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve düzen verileriyle çalışmak için API'ler sağlar. Bu makale, `IActualLayout` arayüzünü uygulayan öğelerin gerçek konum ve boyutu dahil olmak üzere grafik öğelerinin gerçek değerlerini ve grafik eksenlerinin gerçek değerlerini nasıl alacağınızı gösterir. Ayrıca bu değerlerin grafik düzeni doğrulamasından sonra doldurulduğunu açıklar.

Ek olarak, makale ebeveyn grafik öğelerinin gerçek konumunu nasıl alacağınızı ve başlık, eksenler, efsane ve ızgara çizgileri gibi grafik bileşenlerini nasıl gizleyeceğinizi gösterir. Bu örnekler, grafik düzeni bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesaplama**
Aspose.Slides for .NET, bu özellikleri almanız için basit bir API sağlar. Bu, grafik öğelerinin gerçek değerlerini hesaplamanıza yardımcı olur. Gerçek değerler, IActualLayout arayüzünü uygulayan öğelerin konumunu (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) ve gerçek eksen değerlerini (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale) içerir.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Sunumu kaydet
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Ebeveyn Grafik Öğelerinin Gerçek Konumunu Hesaplama**
Aspose.Slides for .NET, bu özellikleri almanız için basit bir API sağlar. IActualLayout özellikleri, ebeveyn grafik öğesinin gerçek konumu hakkında bilgi verir. Özelliklerin gerçek değerlerle doldurulması için önce IChart.ValidateChartLayout() metodunu çağırmak gerekir.

```c#
// Boş sunum oluşturma
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Grafik Öğelerini Gizleme**
Bu konu, grafikten bilgiyi nasıl gizleyeceğinizi anlamanıza yardımcı olur. Aspose.Slides for .NET kullanarak grafikten **Başlığı, Dikey Eksen, Yatay Eksen** ve **Izgara Çizgilerini** gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Grafik Başlığını Gizleme
    chart.HasTitle = false;

    ///Değer eksenini gizleme
    chart.Axes.VerticalAxis.IsVisible = false;

    //Kategori ekseninin görünürlüğü
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Efsaneyi gizleme
    chart.HasLegend = false;

    //Ana ızgara çizgilerini gizleme
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Seri çizgi rengini ayarlama
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Harici Excel çalışma kitapları veri kaynağı olarak çalışıyor mu ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik harici bir çalışma kitabına başvurabilir: harici kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açık/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, harici çalışma kitabının yolunu [specify the external workbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/setexternalworkbook/) belirtmenize ve bağlı verileri yönetmenize olanak tanır.

**Regresyonu kendim uygulamadan trend çizgilerini hesaplayıp gösterebilir miyim?**

Evet. [Trendlines](/slides/tr/net/trend-line/) (doğrusal, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri serilerden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı yapmanız gerekmez.

**Bir sunumda harici bağlantılara sahip birden fazla grafik varsa, her grafik için hangi çalışma kitabının hesaplanan değerler için kullanılacağını kontrol edebilir miyim?**

Evet. Her grafik kendi [external workbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdata/setexternalworkbook/) adresine işaret edebilir veya diğerlerinden bağımsız olarak grafik başına harici bir çalışma kitabı oluşturabilir/değiştirebilirsiniz.