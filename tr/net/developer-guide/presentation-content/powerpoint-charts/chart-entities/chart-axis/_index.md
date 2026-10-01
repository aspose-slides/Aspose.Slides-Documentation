---
title: PowerPoint Sunumlarında .NET ile Grafik Eksenlerini Özelleştirin
linktitle: Grafik Eksenleri
type: docs
url: /tr/net/chart-axis/
keywords:
- grafik ekseni
- düşey eksen
- yatay eksen
- eksen özelleştir
- eksen manipüle et
- eksen yönet
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih formatı
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for .NET'in nasıl kullanılacağını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve tik işareti aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma ve görüntü birimlerini kapsar.

## **Grafiklerde Düşey Eksenin Azami Değerlerini Alın**

Varsayılan verilerle bir alan grafiği ekleyerek bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun. Hesaplanan eksen değerlerini okumadan önce grafiğin düzeninin güncel olmasını sağlamak için [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) çağırın.

Eksen sınırları için [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) ve [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) okuyun, tik aralıkları için ise [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) ve [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) okuyun. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) ve [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Verileri Eksenler Arasında Değiştirin**

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve düşey eksenleri değişmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` ile (başlık satırı ve kategori sütunu dahil) bağlamak için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Çizgi Grafiklerinde Düşey Eksen'i Devre Dışı Bırakın**

Düşey eksende [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) özelliğini `false` olarak ayarlayarak gizleyin. Örnek, varsayılan veriyle bir çizgi grafiği oluşturur ve düşey ekseni gizli olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Çizgi Grafiklerinde Yatay Eksen'i Devre Dışı Bırakın**

Yatay eksende [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) özelliğini `false` olarak ayarlayarak gizleyin. Örnek, varsayılan veriyle bir çizgi grafiği oluşturur ve yatay ekseni gizli olarak kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Bir Kategori Eksenini Değiştirin**

Tarih veya metin kategori ekseni seçmek için [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) ayarlayın. Bu örnek, `ExistingChart.pptx` dosyasını gerektirir; ilk slayttaki ilk şekil bir grafik ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni olarak değiştirir. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) özelliğini `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) özelliğini `1` ve [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) özelliğini ay ay olarak ayarlamak, ana tikleri bir‑aylık aralıklarla yerleştirir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Kategori Eksen Etiket Aralıklarını Kontrol Edin**

Bir grafiğin birçok kategorisi olduğunda, kategori veya veri noktasını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) özelliğini `false` yapın, ardından istediğiniz kategori aralığını belirtmek için [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) ayarlayın. Normal sıralarındaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir; gösterilen etiketlerin arasında iki etiket gizli kalır. Bu, ilgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi gösterme zorunluluğu yoktur.

Tik işaretlerinin ayrı kontrolleri vardır. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) özelliğini `false` yapın ve aralıklarını ayarlamak için [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) kullanın. Örneğin, `1` ayarı her kategori aralığında bir tik işareti bırakırken etiketler yalnızca her üçüncü kategori için görünür. Görünür bir stil seçmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ayarlayın. Otomatik‑aralık özelliklerinden birini tekrar `true` yaparsanız, grafik tekrar otomatik aralığı seçer.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız tik işaretleriyle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmenizi sağlar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir tik işareti tut.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slayt 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Otomatik aralık (slayt 1):** Bu görüntüde, her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç, grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Otomatik kategori etiketi aralığı, tüm 24 sütun görünür](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, tik işaretleri ise her kategori aralığında kalır. Etiketsiz olanlar dahil tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri yükler.

![Manuel kategori etiketi aralığı üç, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Metin kategori ekseni olan bir sütun, çizgi, alan veya çubuk grafiği gibi grafiklerde bu kategori‑sayısı aralığını kullanın. Bir sütun grafiğinde bu, yatay eksendir. Yatay çubuk grafiğinde kategori ekseni düşey olduğundan bu ayarları [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) için uygulayın. Tik‑işareti aralığı, bir serinin ekseni olan grafiklerde de geçerlidir.

Kategori etiket aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) bir değer farkını belirtir: örneğin `10` bir major unit, eksen sıfırdan başlıyorsa 0, 10, 20 vb. tikler oluşturur. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler, metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman temelli major unit ve ölçekleri kullanın.

## **Kategori Eksen Değerleri İçin Tarih Biçimini Ayarlayın**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri sayıları olarak saklanır. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) özelliğini tarih ekseni olarak ayarlayın, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) özelliğini devre dışı bırakın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört haneli yılları göstermesi için `yyyy` değerini [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) özelliğine atayın.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Grafik Eksen Başlığı İçin Döndürme Açısını Ayarlayın**

Düşey eksende [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) özelliğini etkinleştirin, başlık metnini sağlayın ve başlığı döndürmek için [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) ayarlayın. Açı derece cinsindendir; bu örnek, değer‑eksen başlığını 90 derece döndürerek bir sütun grafiği kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarlayın**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori tik işaretlerinde mi kesmesi gerektiğini kontrol etmek için [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) kullanın. Bu özellik yalnızca kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Grafik Değer Ekseninde Görüntü Birimini Ayarlayın**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) ayarlamak, temel veriyi değiştirmeden değer eksenindeki etiketleri ölçeklendirir. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafiği oluşturur ve düşey eksenine milyon görüntü birimini uygular.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir eksenin diğerini kestiği değeri (eks kesişimi) nasıl ayarlarım?**

Kesişme davranışını seçmek için [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) kullanın. Sayısal bir kesişme değeri belirtmek için [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**Tik etiketlerini eksene göre nasıl konumlandırırım?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) özelliğini [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) ile `Low`, `High`, `NextTo` veya `None` olarak ayarlayın. Tik işaretlerini kontrol etmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) veya [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) kullanın; bunlar etiket konumlandırmadan ayrı olarak çalışır.