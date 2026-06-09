---
title: ".NET'te Sunum Grafiklerini Biçimlendirme"
linktitle: "Grafik Biçimlendirme"
type: docs
weight: 60
url: /tr/net/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlak kenar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı stil ile yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Eksenler, ızgara çizgileri, başlıklar, lejandlar, çizim alanı ve duvar dolgu gibi temel grafik öğelerinin nasıl özelleştirileceğini göstererek grafik verilerinin görünümünü ve okunabilirliğini artırır.

Ayrıca grafik metni için yazı tipi özelliklerinin nasıl ayarlanacağını, grafik verilerine önceden tanımlı ve özel sayısal biçimlerin nasıl uygulanacağını ve grafik alanı için yuvarlak köşelerin nasıl etkinleştirileceğini gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edebileceğinizi gösterir.

## **Grafik Öğelerini Biçimlendirme**
Aspose.Slides for .NET, geliştiricilerin slaytlarına sıfırdan özel grafikler eklemelerine olanak tanır. Bu makale, grafik kategori ve değer ekseni dahil olmak üzere farklı grafik öğelerinin nasıl biçimlendirileceğini açıklar.

Aspose.Slides for .NET, farklı grafik öğelerini yönetmek ve bunları özel değerlerle biçimlendirmek için basit bir API sağlar:

1. **Presentation** sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayın referansını alın.  
1. İstenilen türden (bu örnekte ChartType.LineWithMarkers kullanacağız) varsayılan veriyle bir grafik ekleyin.  
1. Grafiğin Değer Eksenine erişin ve aşağıdaki özellikleri ayarlayın:
   1. Değer Ekseni Ana Izgara Çizgileri için **Line format** ayarlanması  
   1. Değer Ekseni Alt Izgara Çizgileri için **Line format** ayarlanması  
   1. Değer Ekseni için **Number Format** ayarlanması  
   1. Değer Ekseni için **Min, Max, Major and Minor units** ayarlanması  
   1. Değer Ekseni verileri için **Text Properties** ayarlanması  
   1. Değer Ekseni için **Title** ayarlanması  
   1. Değer Ekseni için **Line Format** ayarlanması  
1. Grafiğin Kategori Eksenine erişin ve aşağıdaki özellikleri ayarlayın:
   1. Kategori Ekseni Ana Izgara Çizgileri için **Line format** ayarlanması  
   1. Kategori Ekseni Alt Izgara Çizgileri için **Line format** ayarlanması  
   1. Kategori Ekseni verileri için **Text Properties** ayarlanması  
   1. Kategori Ekseni için **Title** ayarlanması  
   1. Kategori Ekseni için **Label Positioning** ayarlanması  
   1. Kategori Ekseni etiketleri için **Rotation Angle** ayarlanması  
1. Grafiğin Lejantına erişin ve **Text Properties** ayarlayın.  
1. Grafik Lejantalarının grafik ile çakışmayacak şekilde gösterilmesini ayarlayın.  
1. Grafiğin **Secondary Value Axis** öğesine erişin ve aşağıdaki özellikleri ayarlayın:
   1. İkincil **Value Axis** etkinleştirin.  
   1. İkincil Value Axis için **Line Format** ayarlanması.  
   1. İkincil Value Axis için **Number Format** ayarlanması.  
   1. İkincil Value Axis için **Min, Max, Major and Minor units** ayarlanması.  
1. Şimdi ilk grafik serisini İkincil Value Axis üzerinde çizin.  
1. Grafik arka duvar dolgu rengini ayarlayın.  
1. Grafik çizim alanı dolgu rengini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```c#
// Sunumu başlatma// Sunumu başlatma
Presentation pres = new Presentation();

// İlk slayta erişme
ISlide slide = pres.Slides[0];

// Örnek grafiği ekleme
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Grafik Başlığını Ayarlama
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Değer ekseni için Ana ızgara çizgileri biçimini ayarlama
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Değer ekseni için Alt ızgara çizgileri biçimini ayarlama
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Değer ekseni sayı formatını ayarlama
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Grafiğin maksimum ve minimum değerlerini ayarlama
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Değer Ekseni Metin Özelliklerini Ayarlama
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Değer ekseni başlığını ayarlama
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Değer ekseni çizgi biçimini ayarlama : Şimdi Kullanımdan Kaldırıldı
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Kategori ekseni için Ana ızgara çizgileri biçimini ayarlama
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Kategori ekseni için Alt ızgara çizgileri biçimini ayarlama
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Kategori Ekseni Metin Özelliklerini Ayarlama
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Kategori Başlığını Ayarlama
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Kategori ekseni etiket konumunu ayarlama
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Kategori ekseni etiket dönüş açısını ayarlama
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Lejant Metin Özelliklerini Ayarlama
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Grafiğin üst üste binmeden lejantları gösterilmesini ayarla
chart.Legend.Overlay = true;
            
// İlk seriyi ikincil değer ekseninde çizme
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Grafiğin arka duvar rengini ayarlama
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for .NET, grafik için yazı tipiyle ilgili özellikleri ayarlama desteği sağlar. Lütfen grafik için yazı tipi özelliklerini ayarlamak için aşağıdaki adımları izleyin.

- **Presentation** sınıfı nesnesini örnekleyin.  
- Slayta bir grafik ekleyin.  
- Yazı tipi yüksekliğini ayarlayın.  
- Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **Sayısal Biçimi Ayarlama**
Aspose.Slides for .NET, grafik veri biçimini yönetmek için basit bir API sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayın referansını alın.  
1. İstenilen türden (bu örnek **ChartType.ClusteredColumn** kullanır) varsayılan veriyle bir grafik ekleyin.  
1. Mümkün olan ön ayar değerlerinden bir ön tanımlı sayı biçimini ayarlayın.  
1. Her grafik serisindeki grafik veri hücrelerini dolaşın ve grafik veri sayı biçimini ayarlayın.  
1. Sunumu kaydedin.  
1. Özel sayı biçimini ayarlayın.  
1. Her grafik serisindeki veri hücrelerini dolaşın ve farklı bir sayı biçimi ayarlayın.  
1. Sunumu kaydedin.

```c#
// Sunumu başlatma// Sunumu başlatma
Presentation pres = new Presentation();

// İlk sunum slaytına erişme
ISlide slide = pres.Slides[0];

// Varsayılan bir birleştirilmiş sütun grafiği ekleme
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Grafik serileri koleksiyonuna erişme
IChartSeriesCollection series = chart.ChartData.Series;

// Ön ayarlı sayı biçimini ayarlama
// Her grafik serisi üzerinden dolaşma
foreach (ChartSeries ser in series)
{
    // Serideki her veri hücresi üzerinden dolaşma
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Sayı biçimini ayarlama
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Sunumu kaydetme
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Aşağıda, kullanılabilecek olası ön tanımlı sayı biçimi değerleri ve bunların ön tanımlı indeksleri verilmiştir:

|**0**|Genel|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Grafik Alanı Yuvarlak Köşeler Ayarlama**
Aspose.Slides for .NET, grafik alanı ayarlama desteği sağlar. **IChart.HasRoundedCorners** ve **Chart.HasRoundedCorners** özellikleri Aspose.Slides'e eklenmiştir.

1. `Presentation` sınıfı nesnesini örnekleyin.  
1. Slayta bir grafik ekleyin.  
1. Grafiğin dolgu türünü ve dolgu rengini ayarlayın.  
1. Yuvarlak köşe özelliğini True olarak ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **SSS**

**Sütunlar/alanlar için yarı saydam dolgu ayarlayıp kenarlığı opak tutabilir miyim?**  
Evet. Dolgu şeffaflığı ve dış kenar ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Etiketler üst üste bindiğinde nasıl başa çıkabilirim?**  
Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket ofsetini/konumunu ayarlayın, gerekiyorsa yalnızca seçili noktalar için etiketleri gösterin veya biçimi "değer + lejant" olarak değiştirin.

**Serilere degrade veya desen dolgular uygulayabilir miyim?**  
Evet. Katı ve degrade/desen dolgular genellikle mevcuttur. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle olan kontrastı düşüren kombinasyonlardan kaçının.