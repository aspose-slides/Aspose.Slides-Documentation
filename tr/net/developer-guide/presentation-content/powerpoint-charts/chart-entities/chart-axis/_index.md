---
title: Presentasyonlarda .NET ile Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/net/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen üzerinde işlem
- eksen yönetimi
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i kullanarak PowerPoint sunumlarında raporlar ve görselleştirmeler için grafik eksenlerini nasıl özelleştireceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET ile grafik eksenlerini özelleştirmeyi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçik aralıkları, tarih kategorileri ve biçimlendirme, başlık dönüşü, eksen konumlandırma, görüntüleme birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Alın**

Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) çağırın, böylece grafik düzeni güncel olur.

[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) ve [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) okuyun, işaretçi aralıkları için [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) ve [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) okuyun. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) ve [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) zaman birimi ölçeklerini sağlar; bu, tarih eksenleriyle ilgilidir. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştirin**

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) kullanın. Her önceki kategori bir seri, her önceki seri bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, varsayılan verileri `Sheet1!A1:D5` adresine, başlık satırı ve kategori sütunu dahil olacak şekilde bağlamak için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) kullanır, ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevirin**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) kullanarak bir kategori veya değer eksenini tersine çevirin. Örneğin, bir yatay çubuk grafik, projenin aşamalarını çalışma sayfasındaki aynı sırayla üstten alta gösterebilir: Planlama, Geliştirme, Test. Bir ekseni tersine çevirmek, çizim yönünü değiştirir; verileri sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) seriler ve kategorilerin rollerini değiştirir.

Sonraki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Normal sıra, ters kategoriler ve ters değerler olmak üzere üç slayt içeren bir sunum kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slayt 2: ilk kategoriyi üstte göster.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Yatay değer eksenini altta tut.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slayt 3: sadece yatay sayısal ölçeği tersine çevir.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Bir ekseni tersine çevirmek, dik olan ekseni grafiğin karşı tarafına da taşıyabilir. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) diğer eksenin yapılandırılan ekseni nerede kestiğini kontrol eder. 2. slaytta, ters kategori ekseninde onu `Maximum` olarak ayarlamak, yatay değer eksenini altta tutar. Belirli bir kesişme noktası için [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) kullanın. Yön değiştirirken kesişme ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişme noktasına sahipse. Normal çizim yönünü geri getirmek için `IsPlotOrderReversed` özelliğini `false` yapın; kesişme ayarları ayrı bir konudur.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafik](axis-order-categories-reversed.png) | ![Ters değer ekseni ve sağda sıfır bulunan yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru ilerler; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta doğru ilerler. Değerler ve çalışma sayfası satır sırası değişmez. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Eksen'i Devre Dışı Bırakın**

[Dikey eksende](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) `IsVisible` özelliğini `false` olarak ayarlayın, böylece gizlenir. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Eksen'i Devre Dışı Bırakın**

[Yatay eksende](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) `IsVisible` özelliğini `false` olarak ayarlayın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

## **Bir Kategori Ekseni Değiştirin**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) ayarlayarak tarih veya metin kategori ekseni seçin. Bu örnek, `ExistingChart.pptx` dosyasını gerektirir; ilk slayttaki ilk şekil bir grafik ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni olarak değiştirir. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) özelliğini `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) `1` ve [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) `Months` olarak ayarlamak, ana işaretçileri bir‑ay aralıklarla yerleştirir.

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

## **Kategori Eksen Etiketi Aralıklarını Kontrol Edin**

Bir grafikte çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) `false` yapın, ardından istediğiniz kategori aralığı için [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) ayarlayın. Metin kategorileri normal sırada iken, sayım ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir ve gösterilen etiketler arasında iki etiket gizlenir. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi göstermeyebilir.

İşaretçikler ayrı kontrolere sahiptir. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) `false` yapın ve aralıklarını ayarlamak için [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) kullanın. Örneğin, `1` her kategori aralığında bir işaretçik bırakırken etiketler sadece her üçüncü kategori için görünür. [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) görünür bir stil olarak ayarlayın, böylece sonucu görebilirsiniz. Otomatik‑aralık özelliğini tekrar `true` yaparsanız, grafik tekrar bu aralığı seçer.

İşte kendi içinde çalışan örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçiklerle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekli değildir. Yatay etiket metni, yoğunluğu fark etmeyi kolaylaştırır.

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

// Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaretçik tut.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slayt 3: grafiğin her iki aralığı da yeniden seçmesine izin ver.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Otomatik aralık (slayt 1):** Bu renderda, her ikinci kategori etiketi gösterilir ve iki satıra kayar. Otomatik sonuç grafik boyutu, yazı tipleri ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünen otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket bir satırda gösterilir, işaretçikler ise her kategori aralığında kalır. Etiketsiz olanlar dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. 3. slayt, yukarıdaki otomatik görünümü geri yükler.

![Üçüncü manuel kategori etiketi aralığı, 24 sütunun tümü görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Bu kategori‑sayım aralığını, sütun, çizgi, alan veya çubuk grafiğin kategori ekseni gibi bir metin kategori ekseni için kullanın. Bir sütun grafiğinde, bu yatay eksendir. Yatay çubuk grafiğinde, kategori ekseni dikeydir; bu ayarları [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) üzerine uygulayın. İşaretçik aralığı, bir seri ekseni bulunan grafiklerde de geçerlidir.

Kategori etiketi aralığını bir değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) bir değer farkını belirtir: örneğin `10` bir major unit, eksen sıfırdan başladıysa 0,10,20 vb. işaretçikler üretir. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑bazlı major unit ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarlayın**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) bir tarih ekseni olarak ayarlayın, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) devre dışı bırakın ve kategori etiketlerinin hücre biçimlemesinden bağımsız olarak dört basamaklı yıl göstermesi için [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) `yyyy` olarak atayın.

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

## **Grafik Eksen Başlığı İçin Döndürme Açısı Ayarlayın**

Dikey eksende [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) etkinleştirin, başlık metni sağlayın ve [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) ayarlayarak başlığı döndürün. Açı derecelerle ölçülür; bu örnek, değer ekseni başlığı 90 derece döndürülmüş bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlayın**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) kullanarak değer ekseninin kategori eksenini kategoriler arasından mı yoksa kategori işaretçiklerinde mi kestiğini kontrol edin. Bu özellik kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Görüntüleme Birimini Ayarlayın**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) ayarlayarak değer eksenindeki etiketleri temel veriyi değiştirmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` olarak ayarlandığında, 60.000.000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dikey eksenine milyon görüntüleme birimini uygular.

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

## **Logaritmik Değer Ekseni Konfigüre Edin**

Pozitif değerler birden fazla büyüklük derecesi kapsadığında logaritmik değer ekseni faydalıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1.000, 10.000 ve 100.000 istek alabilir. Doğrusal ölçekte, daha küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, bunların göreli büyümesini karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) özelliğini değer ekseninde `true` yapın ve tabanı seçmek için [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) kullanın. Bu, mevcut değerlerin nasıl gösterildiğini değiştirir; verileri değiştirmez veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki uyarlanmış ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçin**

Çizgi veya sütun grafiği için değer ekseni [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) dur. Yatay çubuk grafik için [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) dur. Dağılım ve balon grafiklerin iki değer ekseni vardır; X değerleri için yatay ekseni, Y değerleri için dikey ekseni veya ikisini seçin. Bir kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerde, 2 ile 1000 arasında (dahil) bir taban kullanın; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` uygulandığında, 10, 100, 1.000 ve 10.000 gibi ardışık katlar eşit aralıkta olur.

### **Doğrusal ve Logaritmik Ölçeklemeyi Karşılaştırın**

Aşağıdaki kendi içinde çalışan örnek, ilk slaytta beş istek sayısı ile bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta 10 tabanlı bir logaritmik değer ekseni etkinleştirir. Her iki slayt da aynı veriyi korur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// İlk slaytı doğrusal tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, daha küçük değerler ayırt edilmesi zor olur.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint'teki çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem, bir önceki dönemden on kat fazla istek alır; bu nedenle noktalar, 10 tabanlı ölçekte düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısı, 10 tabanlı logaritmik değer ekseninde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerlerle Başa Çıkma**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği koruyun veya bunları ayrı gösterin. Analiz için bu değerleri dışlamak uygun ise, dışlamayı açıklayın. Onları sessizce küçük pozitif sayılarla değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum değerler de pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**  
[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak verir.

**İşaretçi etiketlerini eksene göre nasıl konumlandırabilirim?**  
[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) ayarlarken [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) değerlerinden birini kullanın: `Low`, `High`, `NextTo` veya `None`. İşaretçikleri kontrol etmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) veya [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) kullanın; bunlar etiket konumlandırmadan bağımsızdır.