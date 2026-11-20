---
title: Sunumlarda .NET ile Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
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

Bu makale, Aspose.Slides for .NET ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçik aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürmesi, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Dikey Eksen Üzerindeki Maksimum Değerleri Alma**

Bir [Sunum](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafiğin düzeninin güncel olması için [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) metodunu çağırın.

Eksen limitleri için [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) ve [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/), işaretçi aralıkları için ise [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) ve [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) okunur. Tarih eksenleriyle ilgili zaman birimi ölçekleri, [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) ve [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) tarafından sağlanır. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Verileri Eksenler Arasında Değiştirme**

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori haline gelir. Bu, verilerin gruplanma biçimini değiştirir; yatay ve düşey eksenlerin yerini değiştirmez. Örnek, varsayılan verileri `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) metodunu kullanır, ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Ters Çevirme**

Bir kategori veya değer eksenini tersine çevirmek için [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) özelliğini kullanın. Örneğin, yatay çubuk grafik, proje aşamalarını çalışma sayfasındaki aynı sırada (Planlama, Geliştirme, Test) üstten alta gösterebilir. Bir eksenin ters çevrilmesi çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Buna karşılık, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) seri ve kategori rollerini değiştirir.

Aşağıdaki örnek, üç aşamalı bir yatay çubuk grafik oluşturur ve bir sunumda üç slayt kaydeder: normal sıra, ters kategori ve ters değer. Her kopya aynı veri kümesini kullanır ve yalnızca bir eksen her kopyada ters çevrilir.

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

// Slayt 3: yalnızca yatay sayısal ölçeği ters çevir.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Bir ekseni ters çevirmek, dik ekseni grafiğin karşı tarafına taşıyabilir. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) ayarı, yapılandırılan eksenin diğer ekseni nerede kesişeceğini belirler. 2. slaytta, ters kategori ekseninde `Maximum` olarak ayarlandığında, yatay değer ekseni altta kalır. Belirli bir kesişim noktası için [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) kullanılabilir. Yön değiştirilirken kesişim ayarlarını kontrol edin; özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri getirmek için `IsPlotOrderReversed` değerini `false` yapın; kesişim ayarları bağımsızdır.

| Normal sıra (slayt 1) | Ters kategori (slayt 2) | Ters değer (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer eksen sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Kategoriler üstten alta görüntülenen yatay çubuk grafik](axis-order-categories-reversed.png) | ![Sağda sıfırda kesişen ters değer eksenli yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alttan üste; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta sıralanır. Değerler ve çalışma sayfası satır sırası değişmez. | Kategoriler normal sırada kalır; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Eksenin Devre Dışı Bırakılması**

Dikey ekseni gizlemek için [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) özelliğini `false` yapın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dik ekseni gizlenmiş olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Eksenin Devre Dışı Bırakılması**

Yatay ekseni gizlemek için [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) özelliğini `false` yapın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizlenmiş olarak kaydeder.

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

## **Grafik Izgara Çizgilerini Gösterme veya Gizleme**

Bir eksenin hangi ızgara çizgilerini görüntülediğini öğrenmek için [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) ve [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) okunur. Her iki özellik de salt‑okunurdur. Küçük ızgara çizgilerini göstermek veya gizlemek için [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) öğesinin çizgi dolgusunu kullanın. Görünür bir renk ile katı dolgu ayarlayın; gizlemek için `FillType.NoFill` kullanın. Büyük ızgara çizgileri için karşılık gelen ayar [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`’dır. Bir ızgara çizgisinin dolgusunu değiştirmek eksen görünürlüğü ve işaretçikleri etkilemez.

Bu gruplanmış sütun grafiğinin dik ekseni, büyük ızgara çizgileri görünür, küçük ızgara çizgileri gizli olarak başlar. Örnek, küçük ızgara çizgilerini turuncu renkte gösterir, ardından tekrar gizler ve sunumu kaydeder.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| Küçük ızgara çizgileri etkin | Küçük ızgara çizgileri gizli |
| --- | --- |
| ![Dikey eksende büyük ızgara çizgileri arasında turuncu küçük ızgara çizgileri](minor-gridlines-enabled.png) | ![Yalnızca büyük ızgara çizgileri görünür aynı sütun grafik](minor-gridlines-hidden.png) |

## **Bir Kategori Ekseni Değiştirme**

[Tarih veya metin kategori ekseni seçmek için CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren ve kategori hücrelerinde sayısal Excel tarih değerleri bulunan `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni bir tarih ekseni haline getirir. [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) `1` ve [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) `Months` ayarları, ana işaretçileri bir‑ay aralıklarla yerleştirir.

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

### **Verilerden Kategori Ekseni Türünü Belirleme**

Kategorileri doldurduktan sonra [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) çağırın, ardından seçimi incelemek için [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) okunur. Aynı grafik hem metin etiketleri hem de sayısal tarih değerleri alabilirken faydalıdır. Metod çağrıldığında tür belirlenir; daha sonraki veri değişikliklerini yeniden değerlendiren kalıcı bir mod etkinleştirmez. Kategorileri değiştirdikten sonra tekrar çağırın.

Aşağıdaki örnek, metin kategorili bir grafik oluşturur ve `Text` yazar. Ardından kategori hücre değerlerini tarihlere çevirir ve metodu yeniden çağırır; bu sefer `Date` yazar. Tarihler, [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate) tarafından döndürülen sayısal OLE Automation değerleri olarak saklanır, tarih dizesi olarak değil. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) bu değerlerin nasıl gösterileceğini denetler; metni sayısal tarihlere dönüştürmez. Kategori hücreleri hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/net/chart-workbook/) sayfasına bakın.

Girdi, metin kategorileri mi yoksa sayısal tarihler mi içeriyorsa otomatik belirleme kullanın. Normal sayısal etiketler, karışık kategoriler veya boş veri için, [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) özelliğini amaçlanan anlama göre açıkça ayarlayın. Yalnızca sayısal değerler, kategorilerin tarihleri temsil ettiğini göstermez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Metin

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Tarih

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **Kategori Ekseni Etiket Aralıklarını Kontrol Etme**

Bir grafikte çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) `false` yapın, ardından istediğiniz kategori aralığını belirtmek için [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) ayarlayın. Normal sıradaki metin kategorileri için sayım ilk kategoriyle başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` aralığı her üçüncü etiketi gösterir, iki etiket gizli kalır. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut alana göre bir değer seçer; her etiketi göstermek zorunda değildir.

İşaretçiklerin ayrı kontrolleri vardır. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) `false` yapın ve [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) ile aralıklarını ayarlayın. Örneğin, `1` her kategori aralığında bir işaretçik bırakırken etiketler sadece her üçüncü kategori için görünür. Görünür bir stil seçmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ayarlayın. Otomatik‑aralık özelliklerinden birini tekrar `true` yaparsanız grafik yeniden ona göre ayar seçer.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçiklere sahip manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmeyi sağlar.

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

**Otomatik aralık (slayt 1):** Bu gösterimde her ikinci kategori etiketi görüntülenir ve iki satıra sarktılır. Otomatik sonuç grafik boyutu, yazı tipi ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünür otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçikler ise her kategori aralığında kalır. Etiketsiz kalan 24 sütun da aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri yükler.

![Üçlü manuel kategori etiketi aralığı, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçme**

Bu kategori‑sayım aralığını metin kategori ekseni için kullanın; örneğin sütun, çizgi, alan veya çubuk grafiğin kategori ekseni. Bir sütun grafiğinde bu yatay eksendir. Yatay çubuk grafiğinde kategori ekseni düşeydir, bu yüzden ayarları [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) üzerine uygulayın. İşaretçik aralığı, bir seriye ait eksenleri olan grafiklerde seriler eksenine de uygulanabilir.

Değer ekseninin sayısal ölçeğini kategori etiketi aralığı ile ayarlamaya çalışmayın. Değer ekseninde [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) değerin farkını belirler; örneğin `10` birim, eksen sıfırdan başlıyorsa 0, 10, 20… noktalarını üretir. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılma ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑bazlı birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarlama**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasının (`0` indeks) OLE Automation seri numaraları olarak saklanır. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) bir tarih ekseni olarak ayarlanır, [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) devre dışı bırakılır ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl gösterebilmesi için `yyyy` değeri [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)’a atanır.

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

## **Grafik Eksen Başlığı İçin Döndürme Açısı Ayarlama**

Dikey eksende [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) özelliğini etkinleştirin, başlık metnini sağlayın ve başlığı döndürmek için [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) ayarlayın. Açı derece cinsindedir; örnek, değer‑eksen başlığını 90 derece döndürerek bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlama**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) özelliği, değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçiklerinde mi kesiştireceğini kontrol eder. Bu özellik yalnızca kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu özelliği `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Görüntü Birimini Ayarlama**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) ayarı, temel veriyi değiştirmeden değer eksenindeki etiketleri ölçeklendirir. [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve düşey eksenine milyon görüntü birimini uygular.

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

## **Logaritmik Değer Eksenini Yapılandırma**

Pozitif değerlerin birden fazla mertebe aralığı kapsadığı durumlarda logaritmik değer ekseni yararlıdır. Örneğin bir hizmet, beş dönem boyunca 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, bu değerlerin göreli büyümesini karşılaştırmayı kolaylaştırır: eşit uzaklıklar eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) `true` yapılır ve taban seçimi için [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) ayarlanır. Bu, mevcut değerlerin gösterimini değiştirir; veriyi ya da logaritmik trend çizgisini eklemez. Trend çizgisi, veriye uydurulan ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçme**

Çizgi veya sütun grafiklerde değer ekseni [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)’dir. Yatay çubuk grafiklerde ise [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) kullanılır. Dağılma ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay, Y değerleri için düşey eksen seçilir veya her ikisi kullanılabilir. Kategori eksenine logaritmik ölçek uygulanmaz.

Varsayılan logaritmik taban `10`’dur. PPTX grafiklerinde `2`‑`1000` aralığındaki bir taban kullanılabilir; kesirli tabanlar (`2.5` gibi) da desteklenir. `10` tabanında ardışık kuvvetler (10, 100, 1 000, 10 000) eşit aralıklıdır.

### **Doğrusal ve Logaritmik Ölçek Karşılaştırması**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını gösteren bir çizgi grafik oluşturur, ardından ikinci slaytı klonlar ve taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

// Keep the first slide linear and change only the copy's value-axis scale.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Doğrusal ölçek (slayt 1):** Eşit düşey mesafeler istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerler ayırt edilmesi zorlaşır.

![Doğrusal değer ekseninde beş istek sayısını gösteren çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit düşey mesafeler eşit oranları temsil eder. Her dönem önceki döneme göre on kat daha fazla istek alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![Taban‑10 logaritmik değer ekseninde aynı beş istek sayısını gösteren çizgi grafik](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerlerin Ele Alınması**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlam taşıyorsa, doğrusal ölçek kullanın ya da ayrı bir şekilde gösterin. Bu değerleri analizden çıkarmak uygunsa, eksikliğin nedenini açıklayın. Küçük pozitif sayılarla gizlice değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini nerede kestiği (eks kesişimi) değerini nasıl ayarlarım?**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) ile kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**İşaretçi etiketlerini eksene göre nasıl konumlandırabilirim?**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) özelliğini, [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) ile `Low`, `High`, `NextTo` veya `None` olarak ayarlayın. İşaretçikleri kontrol etmek için [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) veya [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) kullanılabilir; bunlar etiket konumlandırmadan bağımsızdır.