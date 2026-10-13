---
title: PowerPoint Sunumlarında .NET ile Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/net/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
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

Bu makale, Aspose.Slides for .NET ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaret aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Dikey Eksende Maksimum Değerleri Almak**

Bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun ve varsayılan veri ile bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafik düzeninin güncel olmasını sağlamak için [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) metodunu çağırın.

Eksen sınırları için [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) ve [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) değerlerini, işaret aralıkları için ise [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) ve [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) değerlerini okuyun. Tarih eksenleriyle ilgili olan zaman birimi ölçeklerini [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) ve [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) sağlar. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Verileri Eksenler Arasında Değiştirmek**

Grafik verilerinde seriler ve kategorilerin rollerini takas etmek için [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) metodunu kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve düşey eksenleri takas etmez. Örnek, varsayılan verileri `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) kullanır ve ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırakmak**

Dikey ekseni gizlemek için [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) özelliğini `false` olarak ayarlayın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırakmak**

Yatay ekseni gizlemek için [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) özelliğini `false` olarak ayarlayın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

## **Bir Kategori Eksenini Değiştirmek**

Tarih ya da metin kategori ekseni seçmek için [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) özelliğini ayarlayın. Bu örnek `ExistingChart.pptx` dosyasını gerektirir; ilk slayttaki ilk şekil bir grafik ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni olarak değiştirir. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) özelliğini `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) özelliğini `1` ve [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) özelliğini `Months` yaparak ana işaretleri bir‑ay aralıklarla yerleştirir.

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

## **Kategori Ekseni Etiket Aralıklarını Kontrol Etmek**

Bir grafikte çok sayıda kategori varsa, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) özelliğini `false` yapın, ardından istediğiniz kategori aralığını belirlemek için [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) özelliğini ayarlayın. Normal sıradaki metin kategorileri için sayım ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` aralık, her üçüncü etiketi gösterir; görüntülenen etiketler arasında iki etiket gizlenir. Bu, ilgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; mutlaka her etiketi göstermez.

İşaret çizgileri ayrı kontrol edilebilir. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) özelliğini `false` yapın ve aralıklarını ayarlamak için [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) özelliğini kullanın. Örneğin, `1` her kategori aralığında bir işaret bırakırken etiketler yalnızca her üçüncü kategoride görülür. Görünür bir stil seçmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) özelliğini ayarlayın. Otomatik‑aralık özelliğini tekrar `true` yaparsanız grafik yeniden o aralığı seçer.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaret çizgileriyle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya da orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni yoğunluk farkını görmeyi kolaylaştırır.

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

// Slide 2: her üçüncü etiketi göster, ancak her kategori için bir işaret çizgisi tut.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Otomatik aralık (slayt 1):** Bu gösterimde her ikinci kategori etiketi görüntülenir ve iki satıra kayar. Otomatik sonuç grafik boyutu, yazı tipleri ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda görüntülenir, işaret çizgeleri ise her kategori aralığında kalır. Etiketsiz olanlar dahil tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünüme geri döner.

![Tüm 24 sütun görünürken üç ayrı kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seçmek**

Bu kategori‑sayısı aralığını bir metin kategori ekseni için kullanın; örneğin sütun, çizgi, alan veya çubuk grafiklerinde kategori ekseni yataydır. Yatay çubuk grafiklerde ise kategori ekseni düşeydir; bu ayarları [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) üzerinde uygulayın. İşaret çizgisi aralığı aynı zamanda bir seriler eksenine sahip grafiklerde de geçerlidir.

Kategori etiketi aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) bir değer farkını belirtir: örneğin `10` ana birim, eksen sıfırdan başlıyorsa 0, 10, 20 vb. noktalarda işaret oluşturur. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑tabanlı ana birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarlamak**

Örnek, varsayılan grafik verisini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak depolanır. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) özelliğini tarih ekseni olarak ayarlayın, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) özelliğini devre dışı bırakın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört haneli yıl göstermesi için `yyyy` değerini [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) özelliğine atayın.

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

## **Grafik Eksen Başlığı için Döndürme Açısı Ayarlamak**

Dikey eksende [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) özelliğini etkinleştirin, başlık metnini sağlayın ve başlığı döndürmek için [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) özelliğini ayarlayın. Açı derece cinsindendir; bu örnek, değer‑ekseni başlığı 90 derecelik bir döndürme ile bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarlamak**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretlerinde mi geçeceğini kontrol etmek için [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) özelliğini kullanın. Bu özellik yalnızca kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu özelliği `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Görüntü Birimini Ayarlamak**

Değer eksenindeki etiketleri temel veriyi değiştirmeden ölçeklemek için [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) özelliğini ayarlayın. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak görüntülenir. Örnek bir sütun grafik oluşturur ve dikey eksenine milyon görüntü birimini uygular.

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

## **Logaritmik Değer Eksenini Yapılandırmak**

Pozitif değerler birkaç mertebe fark ediyorsa logaritmik değer ekseni faydalıdır. Örneğin bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekle daha küçük değerler sıfıra yakın bir yerde toplanır. Logaritmik ölçek, eşit uzaklıkların eşit oranları temsil etmesini sağlar; yani fark yerine oran karşılaştırılır.

Değer ekseninde [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) özelliğini `true` yapın ve tabanı seçmek için [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) özelliğini kullanın. Bu, mevcut değerlerin nasıl gösterileceğini değiştirir; veriyi ya da bir logaritmik trend çizgisini eklemez. Trend çizgisi, verideki ilişkiyi modelleyen ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçmek**

Çizgi veya sütun grafiklerde, değer ekseni [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) olur. Yatay çubuk grafiklerde ise [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) olur. Dağılım ve balon grafiklerde iki değer ekseni bulunduğundan X değerleri için yatay ekseni, Y değerleri için düşey ekseni veya ikisini de seçebilirsiniz. Logaritmik ölçeklemeyi kategori eksenine uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerinde taban `2` ile `1000` arasında bir değer olabilir; kesirli tabanlar (`2.5` gibi) da desteklenir. Tabana `10` verildiğinde 10, 100, 1 000, 10 000 gibi ardışık kuvvetler eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçeklemeyi Karşılaştırmak**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını içeren bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

// İlk slaytı lineer tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Doğrusal ölçek (slayt 1):** Eşit düşey mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit düşey mesafeler eşit oranları temsil eder. Her dönem önceki dönemin on katı istek alır; bu da taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Ekseni etiketleri hâlâ özgün istek sayılarını gösterir.

![PowerPoint'te taban‑10 logaritmik değer ekseninde aynı beş istek sayısını gösteren grafik](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerlerle Baş Etmek**

Logaritmik ölçek yalnızca sıfırdan büyük değerleri gösterebilir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlam taşıyorsa, doğrusal ölçeği koruyun veya bunları ayrı ayrı gösterin. Bu değerleri dışlamak analiz için uygunsa, eksikliği açıklayın. Küçük pozitif sayılarla gizlice değiştirmeyin; bu, verinin anlamını değiştirir. Logaritmik eksen için elle ayarlanan minimum veya maksimum değerlerin de pozitif olması gerekir.

## **SSS**

**Bir eksenin diğerini kestiği noktayı (eks kesişimi) nasıl ayarlarım?**

Kesme davranışını seçmek için [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) kullanın. Sayısal bir kesişim değeri belirtmek için [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) özelliğini ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak tanır.

**İşaret etiketlerini eksene göre nasıl konumlandırırım?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) özelliğini [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) ile `Low`, `High`, `NextTo` ya da `None` olarak ayarlayın. İşaret çizgilerini kontrol etmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) ya da [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) özelliklerini kullanın; bunlar etiket konumlandırmadan ayrı olarak yönetilir.