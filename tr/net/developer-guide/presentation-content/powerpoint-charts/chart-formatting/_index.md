---
title: .NET'te Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/net/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik öğesi
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET içinde grafik biçimlendirmeyi öğrenin ve özel eksenler, yazı tipleri, sayı biçimleri ve yuvarlatılmış grafik kenarlarıyla PowerPoint sunumunuzu yükseltin.
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Eksenler, ızgara çizgileri, başlıklar, lejantlar, çizim alanı ve duvar doldurmaları gibi temel grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca grafik metni için yazı tipi özelliklerini nasıl ayarlayacağınızı, grafik verilerine önceden ayarlanmış sayısal biçimleri nasıl uygulayacağınızı ve grafik alanı için yuvarlatılmış köşeleri nasıl etkinleştireceğinizi gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edebileceğinizi gösterir.

## **Grafik Varlıklarını Biçimlendir**

Grafik başlıklarını, eksenleri, ızgara çizgilerini, lejantları ve çizim alanını biçimlendirmek için [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) kullanın. Bu örnek, işaretçili ve varsayılan verili bir çizgi grafik oluşturur, ardından değer ve kategori eksenlerine ayrı metin ve çizgi stilleri uygular. Yazı tipi boyutları ve çizgi kalınlıkları puan cinsinden belirtilir; kategori etiketleri 45 derece döndürülür.

Değer ekseni, kaynak hücrelerden bağımsız olarak [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) kullanır. Ölçeği -2 ile 15 arasında olup, ana aralıklar 2 ve alt aralıklar 0.5 olarak ayarlanmıştır. Örnek ayrıca yüzde biçimlendirmesini binlere ayarlanmış [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ile birleştirir; bu ayarları verinizin anlamına ve büyüklüğüne göre uyarlayın. Lejant, [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) devre dışı bırakıldığı için çizim alanının dışında kalır. Arka duvar ve zemin doldurmaları [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) ve [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) aracılığıyla yapılandırılır, ancak bu yüzeyler yalnızca 3D grafiklerde görülür.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**

[Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) aracılığıyla grafik metni için varsayılan yazı tipi boyutunu ayarlayın. Örnek, 20 puan yazı tipine sahip bir küme sütun grafiği oluşturur ve [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) kullanarak ilk seriye değer etiketlerini etkinleştirir. Kendi açık yazı tipi ayarlarına sahip metin öğeleri, grafik varsayılanını geçersiz kılabilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Sayısal Biçimi Ayarlama**

[IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) kullanarak grafik çalışma kitabı hücrelerine yerleşik bir sayı biçimi uygulayın. Bu örnek, varsayılan hücre destekli veri ile bir küme sütun grafiği oluşturur ve her seri değer hücresine format indeksi 10 (`0.00%`) uygular. Bu, temel sayıları değiştirmeden değerlerin çalışma kitabında nasıl göründüğünü değiştirir; örneğin 0.25, %25.00 olarak gösterilir. Eksen ve veri etiketi biçimleri ayrı ayrı yapılandırılabilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Aşağıdaki tablo, İngilizce (Amerika Birleşik Devletleri) yerel ayarı için temsilci Excel biçimleriyle birlikte yerleşik sayı biçim indeklerini listeler. Kesin biçim dizgileri ve bunların gösterimi uygulama ve yerel ayara göre değişebilir, özellikle para birimi ve tarih için. Bazı Excel biçimleri ayrıca OOXML standardındaki varsayılanlardan farklıdır; bu, [Microsoft'un sayı biçimi uygulama notlarında](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) açıklanmıştır.

| İndeks | Biçim |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Grafik Alanı Yuvarlatılmış Kenarlıklarını Ayarlama**

[IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) etkinleştirerek grafik alanının köşelerini yuvarlatın. Örnek bir küme sütun grafiği oluşturur ve [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) kullanarak kenarlığına sade gri bir renk ve tek satır stili verir, ardından sunumu kaydeder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Mevcut Grafik Açıklamalarını Düzenleme**

Bir grafik, rapor durumunu açıklayan bir metin açıklaması gibi özel şekiller içerebilir. Bu şekillere [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) aracılığıyla erişilir; ayrıca Grafik API Referansında [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) altında listelenir. Bunun [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) koleksiyonu grafik tarafından sahip olunan şekilleri içerir.

Grafiğin üzerine yerleştirilen sıradan bir metin kutusu, grafik parçası gibi görünse bile slayta aittir. [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) üzerinde döngü yaptığınızda grafik ve sıradan slayt şekilleri bulunur, ancak grafik içindeki bireysel şekiller listelenmez. Grafik başlıkları ve veri etiketleri ayrı grafik öğeleridir, bu koleksiyondaki özel açıklama değildir.

[chart-annotations.pptx](chart-annotations.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, "Preliminary results" metninde bir ayrılmış açıklama, grafik tarafından sahip olunan bir çizgi ve "Slide overlay" metninde bir sıradan slayt metin kutusu içeren bir grafik içerir. Örnek, o slayttaki ilk grafiği bulur ve rapor yayınlanmaya hazır olduğunda açıklamayı "Final results" olarak değiştirir. Boş bir koleksiyon olup olmadığını kontrol eder ve yalnızca null olmayan bir [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) içeren ve beklenen metni taşıyan bir [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) düzenler.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

Çizgi ve slayt metin kutusu değişmeden kalır. Aşağıdaki görseller giriş ve kaydedilip yeniden açılan sonucu gösterir:

| Düzenlemeden önce | Düzenledikten sonra |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Örnek yalnızca üst düzey grafik sahip şekilleri inceler. Bir açıklama bir [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) içinde ise o grubun [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) koleksiyonunu da inceleyin. İç içe gruplar için bunu yineleyerek aynı metin kontrollerini alt şekillere uygulayın. Bir grup kendisi bir konteynerdir; onu bir metin kutusu olarak değerlendirmeyin.
{{% /alert %}}

## **SSS**

**Sütunlar/alanlar için yarı saydam doldurmalar ayarlayıp kenarlığı opak tutabilir miyim?**  
Evet. Dolgu şeffaflığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgaranın ve verinin okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri üst üste geldiğinde nasıl başa çıkabilirim?**  
Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategoriler), etiket konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiketleri gösterin veya formatı "değer + lejant" olarak değiştirin.

**Serilere degrade veya desen dolguları uygulayabilir miyim?**  
Evet. Seriler, katı, degrade ve desen doldurmaları destekler. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.