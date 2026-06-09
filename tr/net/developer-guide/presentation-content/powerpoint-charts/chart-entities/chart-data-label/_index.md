---
title: .NET'te Sunumlarda Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/net/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint sunumlarında grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, daha etkileyici slaytlar oluşturun."
---
## **Giriş**

Bir grafikteki veri etiketleri, grafik veri serileri veya tek tek veri noktaları hakkında ayrıntılar gösterir. Okuyucuların veri serilerini hızla tanımlamasını sağlar ve aynı zamanda grafikleri daha kolay anlaşılır hale getirir.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Bu C# kodu, bir grafik veri etiketinde veri hassasiyetinin nasıl ayarlanacağını gösterir:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Yüzdeyi Etiket Olarak Göster**

Aspose.Slides for .NET, görüntülenen grafiklerde yüzde etiketleri ayarlamanıza olanak tanır. Bu C# kodu işlemi gösterir:

```c#
 // Presentation sınıfının bir örneğini oluşturur
 Presentation presentation = new Presentation();

 ISlide slide = presentation.Slides[0];
 IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
 IChartSeries series = chart.ChartData.Series[0];
 IChartCategory cat;
 double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
 for (int k = 0; k < chart.ChartData.Categories.Count; k++)
 {
     cat = chart.ChartData.Categories[k];

     for (int i = 0; i < chart.ChartData.Series.Count; i++)
     {
         total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
     }
 }

 double dataPontPercent = 0f;

 for (int x = 0; x < chart.ChartData.Series.Count; x++)
 {
     series = chart.ChartData.Series[x];
     series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

     for (int j = 0; j < series.DataPoints.Count; j++)
     {
         IDataLabel lbl = series.DataPoints[j].Label;
         dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

         IPortion port = new Portion();
         port.Text = String.Format("{0:F2} %", dataPontPercent);
         port.PortionFormat.FontHeight = 8f;
         lbl.TextFrameForOverriding.Text = "";
         IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
         para.Portions.Add(port);

         lbl.DataLabelFormat.ShowSeriesName = false;
         lbl.DataLabelFormat.ShowPercentage = false;
         lbl.DataLabelFormat.ShowLegendKey = false;
         lbl.DataLabelFormat.ShowCategoryName = false;
         lbl.DataLabelFormat.ShowBubbleSize = false;
     }
 }

 // Grafiği içeren sunumu kaydeder
 presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarla**

Bu C# kodu, bir grafik veri etiketi için yüzde işaretinin nasıl ayarlanacağını gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturur
Presentation presentation = new Presentation();

 // Gets a slide's reference through its index
ISlide slide = presentation.Slides[0];

// Bir slaytta PercentsStackedColumn grafiğini oluşturur
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// NumberFormatLinkedToSource özelliğini false olarak ayarlar
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Grafik veri çalışma sayfasını alır
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Yeni seri ekler
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Serinin dolgu rengini ayarlar
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// LabelFormat özelliklerini ayarlar
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Yeni seri ekler
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Dolgu tipini ve rengini ayarlar
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Sunumu diske yazar
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Bir Eksenden Etiket Mesafesini Ayarla**

Bu C# kodu, eksenlerden çizilen bir grafikle çalışırken kategori ekseninden etiket mesafesinin nasıl ayarlanacağını gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturur
Presentation presentation = new Presentation();

// Bir slaytın referansını alır
ISlide sld = presentation.Slides[0];

// Slaytta bir grafik oluşturur
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Etiketin eksenden uzaklığını ayarlar
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Sunumu diske yazar
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Etiket Konumunu Ayarla**

Eksenlere dayanmayan bir grafik (örneğin bir pasta grafik) oluşturduğunuzda, grafiğin veri etiketleri kenara çok yakın olabilir. Böyle bir durumda, veri etiketinin konumunu ayarlamanız gerekir, böylece lider çizgileri net bir şekilde görüntülenir.

Bu C# kodu, bir pasta grafiğinde etiket konumunun nasıl ayarlanacağını gösterir: 

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste gelmesini nasıl önleyebilirim?**

Otomatik etiket konumlandırma, lider çizgileri ve küçültülmüş yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin, kategori) gizleyin veya sadece uç/anahtar noktalara etiket gösterin.

**Sıfır, negatif veya boş değerler için yalnızca etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için gösterimi kapatın.

**PDF/görüntülere dışa aktarırken tutarlı bir etiket stilini nasıl sağlayabilirim?**

Yazı tiplerini (aile, boyut) açıkça ayarlayın ve geri dönüşüm olmaması için render tarafında yazı tipinin mevcut olduğunu doğrulayın.