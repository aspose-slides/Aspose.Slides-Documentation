---
title: Python'da PowerPoint Sunum Grafiklerini Oluşturma ve Güncelleme
linktitle: Grafik Oluşturma veya Güncelleme
type: docs
weight: 10
url: /tr/python-java/create-chart/
keywords:
- grafik ekle
- grafik oluştur
- grafik düzenle
- grafik değiştir
- grafik güncelle
- dağınık grafik
- pasta grafik
- çizgi grafik
- ağaç harita grafik
- stok grafik
- kutu ve çan grafik
- huni grafik
- güneş patlaması grafik
- histogram grafik
- radar grafik
- çoklu kategori grafik
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Java aracılığıyla Python için Aspose.Slides kullanarak PowerPoint sunumlarında grafik oluşturun ve özelleştirin. Grafik ekleyin, biçimlendirin ve Python'da pratik kod örnekleriyle düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak grafik oluşturma ve özelleştirme konusunda kapsamlı bir rehber sunar. Programlı olarak bir slayta grafik eklemeyi, verileri doldurmayı ve belirli tasarım gereksinimlerinize uygun çeşitli biçimlendirme seçeneklerini uygulamayı öğreneceksiniz. Makale boyunca, sunumu ve grafik nesnesini başlatmaktan serileri, eksenleri ve lejandları yapılandırmaya kadar her adımı gösteren ayrıntılı kod örnekleri bulunmaktadır. Bu rehberi izleyerek, uygulamalarınıza dinamik grafik oluşturmayı entegre etme konusunda sağlam bir anlayış kazanacak ve veri odaklı sunumlar oluşturma sürecini hızlandıracaksınız.

## **Grafik Oluşturma**

Grafikler, verileri hızlı bir şekilde görselleştirerek bir tablo veya elektronik tablodan hemen anlaşılmayabilecek içgörüler elde etmeyi sağlar.

**Grafik Neden Oluşturulur?**

Grafik kullanarak şunları yapabilirsiniz:

* bir sunumdaki tek bir slaytta büyük miktarda veriyi toplamak, sıkıştırmak veya özetlemek
* verilerdeki kalıp ve eğilimleri ortaya çıkarmak
* zaman içinde veya belirli bir ölçüm birimiyle ilgili verinin yönünü ve momentumunu çıkarmak
* aykırı değerler, sapmalar, hatalar, mantıksız veriler vb. tespit etmek
* karmaşık verileri iletişim kurmak veya sunmak

PowerPoint'te, *Insert* işlevi aracılığıyla birçok grafik türü için şablonlar sağlayan grafikler oluşturabilirsiniz. Aspose.Slides kullanarak hem popüler grafik türlerine dayalı normal grafikler hem de özelleştirilmiş grafikler oluşturabilirsiniz.

{{% alert color="info" title="Note" %}}

Grafik oluşturmak için [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) sınıfını kullanın. Bu sınıftaki alanlar farklı grafik türlerine karşılık gelir.

{{% /alert %}}

### **Küme Sütun Grafiklerini Oluşturma**

Bu bölüm, Aspose.Slides kullanarak küme sütun grafiklerinin nasıl oluşturulacağını açıklar. Bir sunumu başlatmayı, bir grafik eklemeyi ve başlık, veri, seri, kategori ve stil gibi öğelerini özelleştirmeyi öğreneceksiniz. Aşağıdaki adımları izleyerek standart bir küme sütun grafiğinin nasıl üretildiğini görebilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Dizini kullanarak bir slayta referans alın.
1. `ChartType.ClusteredColumn` türünü belirterek bazı verilerle bir grafik ekleyin.
1. Grafik'e bir başlık ekleyin.
1. Grafiğin veri çalışma sayfasına erişin.
1. Tüm varsayılan serileri ve kategorileri temizleyin.
1. Yeni seriler ve kategoriler ekleyin.
1. Grafik serileri için yeni grafik verileri ekleyin.
1. Grafik serilerine bir dolgu rengi uygulayın.
1. Grafik serilerine etiketler ekleyin.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu C# kodu, bir küme sütun grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

    # Bir PPTX dosyasını temsil eden sunum sınıfının bir örneğini oluşturur.
presentation = Presentation()
try:
    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan verileriyle bir grafik ekler
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Grafik başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Grafik veri sayfası için dizini ayarlar
    default_worksheet_index = 0

    # Grafik veri çalışma sayfasını alır
    workbook = chart.getChartData().getChartDataWorkbook()

    # Varsayılan oluşturulan serileri ve kategorileri siler
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Yeni seriler ekler
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Yeni kategoriler ekler
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # İlk grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(0)

    # Şimdi seri verilerini doldurur
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Seri için dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1)

    # Seri verilerini doldurur
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Seri için dolgu rengini ayarlar
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Yeni seri için her kategoriye özel etiketler oluşturur
    # İlk etiketi kategori adını gösterecek şekilde ayarlar
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Üçüncü etiket için değeri gösterir
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Grafikli sunumu kaydeder
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Saçılım Grafiklerini Oluşturma**

Saçılım grafikleri (diğer adıyla saçılım diyagramları veya x‑y grafikleri), iki değişken arasındaki desenleri kontrol etmek veya korelasyonları göstermek için sıkça kullanılır.

Bir saçılım grafiği şu durumlarda kullanılır:

* eşleştirilmiş sayısal verileriniz varsa
* birbiriyle iyi eşleşen iki değişkeniniz varsa
* iki değişkenin ilişkili olup olmadığını belirlemek istiyorsanız
* bağımsız bir değişkenin bağımlı bir değişken için birden fazla değeri varsa

1. [Küme Sütun Grafiklerini Oluşturma](#create-clustered-column-charts) bölümündeki adımları izleyin.
2. Üçüncü adım için bir grafik ekleyin ve grafik tipinizi aşağıdakilerden biri olarak belirtin:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Saçılım grafiği temsil eder._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Eğrilerle bağlanan, veri işaretçileri olan bir saçılım grafiği temsil eder._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Eğrilerle bağlanan, veri işaretçileri olmayan bir saçılım grafiği temsil eder._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Çizgilerle bağlanan, veri işaretçileri olan bir saçılım grafiği temsil eder._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Çizgilerle bağlanan, veri işaretçileri olmayan bir saçılım grafiği temsil eder._

Bu Python kodu, her seri için farklı işaretçilerle bir saçılım grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Bir PPTX dosyasını temsil eden bir sunum sınıfının örneğini oluşturur.
presentation = Presentation()
try:
    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan grafiği oluşturur
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Varsayılan grafik veri çalışma sayfası dizinini alır
    default_worksheet_index = 0

    # Grafik veri çalışma sayfasını alır
    workbook = chart.getChartData().getChartDataWorkbook()

    # Demo serilerini siler
    chart.getChartData().getSeries().clear()

    # Yeni seriler ekler
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # İlk grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(0)

    # Seriye yeni bir nokta (1:3) ekler
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Yeni bir nokta (2:10) ekler
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Seri tipini değiştirir
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Grafik seri işaretçisini değiştirir
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1)

    # Orada yeni bir nokta (5:2) ekler
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Yeni bir nokta (3:1) ekler
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Yeni bir nokta (2:2) ekler
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Yeni bir nokta (5:1) ekler
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Grafik seri işaretçisini değiştirir
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pasta Grafiklerini Oluşturma**

Pasta grafikler, özellikle veri kategorik etiketlerle sayısal değerler içerdiğinde, parçanın bütünle ilişkisinin gösterilmesi için en iyi yöntemdir. Ancak verinizde çok sayıda parça veya etiket bulunuyorsa, bir çubuk grafik kullanmayı düşünebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Pasta dilimlerine özel renkler uygulayarak yeni noktalar ekleyin.
9. Seriler için etiketler belirleyin.
10. Seri etiketleri için lider çizgileri etkinleştirin.
11. Pasta dilimlerinin dönüş açılarını ayarlayın.
12. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir pasta grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# PPTX dosyasını temsil eden bir sunum sınıfının bir örneğini oluşturur.
presentation = Presentation()
try:
    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan verilerle bir grafik ekler
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Grafik başlığını ayarlar
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Grafik veri sayfası için dizini ayarlar
    default_worksheet_index = 0

    # Grafik veri çalışma sayfasını alır
    workbook = chart.getChartData().getChartDataWorkbook()

    # Varsayılan oluşturulan serileri ve kategorileri siler
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Yeni kategoriler ekler
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Yeni seriler ekler
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Seri verilerini doldurur
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Yeni noktalar ekleyerek dilim rengini ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Dilim kenarlığını ayarlar
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Dilim kenarlığını ayarlar
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Dilim kenarlığını ayarlar
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Yeni seri için her kategoriye özel etiketler oluşturur
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Grafik için lider çizgileri gösterir
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Pasta grafik dilimleri için dönüş açısını ayarlar
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Grafikli sunumu kaydeder
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Çizgi Grafiklerini Oluşturma**

Çizgi grafikler (diğer adıyla çizgi diyagramları), zaman içinde değer değişimlerini göstermek istediğiniz durumlarda en uygunudur. Bir çizgi grafik kullanarak büyük miktarda veriyi bir kerede karşılaştırabilir, zaman içinde değişiklik ve eğilimleri izleyebilir, veri serilerindeki anormallikleri vurgulayabilir ve daha fazlasını yapabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizini kullanarak bir slayta referans alın.
1. [ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line) türünü belirterek varsayılan verilerle bir grafik ekleyin.
1. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir çizgi grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Varsayılan olarak, bir çizgi grafiğindeki noktalar düz sürekli çizgilerle birleştirilir. Noktaların tireli çizgilerle birleştirilmesini istiyorsanız, tercih ettiğiniz tire tipini aşağıdaki gibi belirtebilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ağaç Haritası Grafiklerini Oluşturma**

Ağaç haritası grafikler, her kategori içinde büyük katkıda bulunan öğelere hızlıca dikkat çekmek istediğiniz satış verileri için en uygunudur.

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir ağaç haritası grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #dal 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #dal 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Stok Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Yüksek-düşük çizgi formatını belirleyin.
9. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir stok grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kutu ve Çan Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir kutu ve çan grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Huni Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir huni grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Güneş Patlaması Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir güneş patlaması grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #dal 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #dal 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Histogram Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir histogram grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Radar Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. Bazı verilerle bir grafik ekleyin ve tercih ettiğiniz grafik türünü belirleyin ([ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar) bu örnekte).
4. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir radar grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Çoklu Kategori Grafiklerini Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. [ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn) türünü belirterek varsayılan verilerle bir grafik ekleyin.
4. Grafik veri çalışma kitabına [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) erişin.
5. Varsayılan serileri ve kategorileri temizleyin.
6. Yeni seriler ve kategoriler ekleyin.
7. Grafik serileri için yeni grafik verileri ekleyin.
8. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, çoklu kategori grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Seri ekleme
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Grafikli sunumu kaydet
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Harita Grafiklerini Oluşturma**

Harita grafikleri coğrafi verileri görselleştirir ve bölgeler arasındaki değerleri karşılaştırmaya yardımcı olur.

Bu Python kodu, bir harita grafiği oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kombinasyon Grafiklerini Oluşturma**

Kombinasyon grafiği (veya combo grafiği), tek bir grafikte iki veya daha fazla grafik türünü birleştirir. Bu grafik, iki veya daha fazla veri kümesi arasındaki farkları vurgulamanıza, karşılaştırmanıza veya incelemenize olanak tanır ve aralarındaki ilişkileri belirlemenize yardımcı olur.

![Kombinasyon grafiği](combination_chart.png)

Aşağıdaki Python kodu, yukarıda gösterilen kombinasyon grafiğini bir PowerPoint sunumunda oluşturmayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Grafik başlığını ayarlar.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Grafik lejandını ayarlar.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Varsayılan oluşturulan serileri ve kategorileri siler.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Yeni kategoriler ekler.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # İlk seriyi ekler.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Yatay ekseni ayarlar.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Dikey ekseni ayarlar.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Dikey ana ızgara çizgileri rengini ayarlar.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # İkincil yatay ekseni ayarlar.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # İkincil dikey ekseni ayarlar.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Grafikleri Güncelleme**

1. Güncellemek istediğiniz grafiği içeren sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) örneği oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. İstenilen grafiği bulmak için tüm şekillerde dolaşın.
4. Grafik veri çalışma sayfasına erişin.
5. Seri değerlerini değiştirerek grafik veri serilerini düzenleyin.
6. Yeni bir seri ekleyin ve verilerini doldurun.
7. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir grafiği güncellemeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Güncellenecek grafiği içeren sunumu açar
presentation = Presentation("ExistingChart.pptx")
try:
    # İlk slayta erişir
    slide = presentation.getSlides().get_Item(0)

    # Slayttan grafiği alır
    chart = slide.getShapes().get_Item(0)

    # Grafik veri sayfasının dizinini ayarlar
    default_worksheet_index = 0

    # Grafik veri çalışma sayfasını alır
    workbook = chart.getChartData().getChartDataWorkbook()

    # Grafik kategori adını değiştirir
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # İlk grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(0)

    # Şimdi seri verilerini günceller
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Seri adını değiştirir
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # İkinci grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(1)

    # Şimdi seri verilerini günceller
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Seri adını değiştirir
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Şimdi yeni bir seri ekler
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Üçüncü grafik serisini alır
    series = chart.getChartData().getSeries().get_Item(2)

    # Şimdi seri verilerini doldurur
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Grafikli sunumu kaydeder
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Grafiğin Veri Aralığını Ayarlama**

Mevcut bir grafik tarafından zaten kullanılan aralığı incelemek için [Retrieve a Chart's Data Range](/slides/tr/python-java/chart-workbook/#retrieve-a-charts-data-range) bölümüne bakın.

Bir grafik için veri aralığını ayarlamak için şu adımları izleyin:

1. Grafiği içeren bir sunumu temsil eden bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) örneği oluşturun.
2. Dizini kullanarak bir slayta referans alın.
3. İstenilen grafiği bulmak için tüm şekillerde dolaşın.
4. Grafiğin verisine erişin ve aralığı ayarlayın.
5. Değiştirilmiş sunumu bir PPTX dosyası olarak kaydedin.

Bu Python kodu, bir grafik için veri aralığını ayarlamayı gösterir:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Grafiği içeren sunumu açar
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafiklerde Varsayılan İşaretçileri Kullanma**

Grafiklerde varsayılan işaretçiler kullanıldığında, her grafik serisi otomatik olarak farklı bir işaretçi sembolü alır.

Bu Python kodu, bir grafik serisi işaretçisini otomatik olarak ayarlamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #İkinci grafik serisini al
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Şimdi seri verilerini doldur
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Aspose.Slides tarafından hangi grafik türleri destekleniyor?**

Aspose.Slides, çubuk, çizgi, pasta, alan, saçılım, histogram, radar ve daha birçok [grafik türü](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) dahil olmak üzere geniş bir yelpazede destek sunar. Bu esneklik, veri görselleştirme ihtiyaçlarınıza en uygun grafik türünü seçmenize olanak tanır.

**Bir slayta yeni bir grafik nasıl eklenir?**

Bir grafik eklemek için önce bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun, istediğiniz slaytı diziniyle alın ve ardından grafik tipini ve başlangıç verilerini belirterek grafiği ekleme metodunu çağırın. Bu işlem, grafiği doğrudan sunumunuza entegre eder.

**Grafikte gösterilen veriler nasıl güncellenir?**

Bir grafiğin verilerini, veri çalışma kitabına ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)) erişerek, varsayılan serileri ve kategorileri temizleyip özel verilerinizi ekleyerek güncelleyebilirsiniz. Böylece grafiği en son verileri yansıtacak şekilde yenileyebilirsiniz.

**Grafiğin görünümü özelleştirilebilir mi?**

Evet, Aspose.Slides kapsamlı özelleştirme seçenekleri sunar. Renkleri, yazı tiplerini, etiketleri, lejandları ve diğer [biçimlendirme öğelerini](/slides/tr/python-java/chart-entities/) değiştirerek grafiğin görünümünü belirli tasarım gereksinimlerinize göre uyarlayabilirsiniz.