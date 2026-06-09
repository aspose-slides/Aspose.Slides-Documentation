---
title: Python'da Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-net/chart-series/
keywords:
- grafik serileri
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri aralığı
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) için Python'da grafik veri serilerini nasıl yöneteceğinizi, veri sunumlarınızı geliştirecek pratik kod örnekleri ve en iyi uygulamalarla öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python'da [ChartSeries](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/) rolünü, verilerin sunumlarda nasıl yapılandırıldığını ve görselleştirildiğini açıklamaktadır. Bu nesneler, bir grafikteki veri noktaları, kategoriler ve görünüm parametreleri için temel öğeleri tanımlar. [ChartSeries](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/) ile çalışarak geliştiriciler, altyapı veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilgilerin nasıl gösterileceği üzerinde tam kontrol sağlayabilir; bu da içgörü ve analizleri net bir şekilde ileten dinamik, veri odaklı sunumlar ortaya çıkarır.

Bir seri, bir grafikte çizilen satır veya sütun sayılarından oluşur.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Seri Çakışmasını Ayarla**

[ChartSeries.overlap](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/overlap/) özelliği, -100 ile 100 arasında bir aralık belirleyerek 2D bir grafikte çubukların ve sütunların nasıl çakışacağını kontrol eder. Bu özellik, bireysel grafik serileri yerine seri grubu ile ilişkilidir ve seri seviyesinde yalnızca okunabilir durumdadır. Çakışma değerlerini yapılandırmak için, belirtilen çakışmayı gruptaki tüm serilere uygulayan `parent_series_group.overlap` okuma/yazma özelliğini kullanın.

Aşağıda, bir sunum oluşturmayı, kümelenmiş sütun grafiği eklemeyi, ilk grafik serisine erişmeyi, çakışma ayarını yapılandırmayı ve sonucu PPTX dosyası olarak kaydetmeyi gösteren bir Python örneği bulunmaktadır:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Varsayılan verilerle kümelenmiş sütun grafiği ekle.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Seri çakışmasını ayarla.
        series.parent_series_group.overlap = series_overlap

    # Sunum dosyasını diske kaydet.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştir**

Aspose.Slides, grafik serilerinin dolgu renklerini özelleştirmeyi kolaylaştırır; böylece belirli veri noktalarını vurgulayabilir ve görsel açıdan çekici grafikler oluşturabilirsiniz. Bu, çeşitli dolgu türlerini, renk yapılandırmalarını ve diğer gelişmiş stil seçeneklerini destekleyen [Format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/format/) nesnesi aracılığıyla gerçekleştirilir. Bir slayta grafik ekleyip istenen seriye eriştikten sonra, seriyi alın ve uygun dolgu rengini uygulayın. Katı dolguların yanı sıra, tasarım esnekliğini artırmak için degrade veya desen dolgularını da kullanabilirsiniz. Gereksinimlerinize göre renkleri ayarladıktan sonra, sunumu kaydederek güncellenmiş görünümü tamamlayın.

Aşağıdaki Python kod örneği, ilk serinin rengini nasıl değiştireceğinizi göstermektedir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Varsayılan verilerle kümelenmiş sütun grafiği ekle.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # İlk serinin rengini ayarla.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Sunum dosyasını diske kaydet.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri rengi](series_color.png)

## **Bir Seriyi Yeniden Adlandır**

Aspose.Slides, grafik serilerinin adlarını değiştirmek için basit bir yol sunar; bu, verileri net ve anlamlı bir şekilde etiketlemeyi kolaylaştırır. Grafik verilerindeki ilgili çalışma sayfası hücresine erişerek geliştiriciler, verinin nasıl sunulduğunu özelleştirebilir. Bu değişiklik, serilerin adları veri bağlamına göre güncellenmesi veya açıklığa kavuşturulması gerektiğinde özellikle faydalıdır. Seriyi yeniden adlandırdıktan sonra, değişikliklerin kalıcı olması için sunumu kaydedebilirsiniz.

Aşağıda bu süreci gösteren bir Python kod parçacığı bulunmaktadır.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Varsayılan verilerle kümelenmiş sütun grafiği ekle.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # İlk serinin adını ayarla.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Sunum dosyasını diske kaydet.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki Python kodu, seri adını değiştirmenin alternatif bir yolunu gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Varsayılan verilerle kümelenmiş sütun grafiği ekle.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # İlk serinin adını ayarla.
    series.name.as_cells[0].value = series_name

    # Sunum dosyasını diske kaydet.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

Sonuç:

![Seri adı](series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

Aspose.Slides for Python, bir çizim alanındaki grafik serileri için otomatik dolgu rengini almanıza olanak tanır. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturduktan sonra, indeksle istediğiniz slayta referans alabilir, ardından tercih ettiğiniz türde (örneğin `ChartType.CLUSTERED_COLUMN`) bir grafik ekleyebilirsiniz. Grafikteki seriye erişerek otomatik dolgu rengini alabilirsiniz.

Aşağıdaki Python kodu bu süreci detaylı olarak göstermektedir.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Varsayılan verilerle kümelenmiş sütun grafiği ekle.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Serinin dolgu rengini al.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

Örnek Çıktı:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Bir Seri için Ters Dolgu Renklerini Ayarla**

Veri seriniz hem pozitif hem de negatif değerler içeriyorsa, tüm sütun veya çubukları aynı renkle boyamak grafiği okunamaz hale getirebilir. Aspose.Slides for Python, sıfırın altındaki veri noktalarına otomatik olarak uygulanan ayrı bir dolgu olan ters dolgu rengini atamanıza olanak tanır; böylece negatif değerler bir bakışta öne çıkar. Bu bölümde, bu seçeneği nasıl etkinleştireceğinizi, uygun rengi nasıl seçeceğinizi ve güncellenmiş sunumu nasıl kaydedeceğinizi öğreneceksiniz.

Aşağıdaki kod örneği işlemi göstermektedir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Yeni kategoriler ekle.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Yeni bir seri ekle.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Seri verilerini doldur.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Seri için renk ayarlarını belirle.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Tek bir veri noktası için tüm seriyi değil, sadece o noktayı ters dolgu rengine çevirebilirsiniz. İlgili `ChartDataPoint` nesnesine erişip `invert_if_negative` özelliğini `True` olarak ayarlamanız yeterlidir.

Aşağıdaki kod örneği bunu nasıl yapacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Veri Noktaları için Veriyi Temizle**

Bazen bir grafikte test değerleri, aykırı değerler veya artık girişler bulunur ve tüm seriyi yeniden oluşturmak yerine bunları kaldırmak isteyebilirsiniz. Aspose.Slides for Python, herhangi bir veri noktasını indeksine göre hedeflemenize, içeriğini temizlemenize ve kalan noktalar kayarak eksenlerin otomatik yeniden ölçeklenmesini sağlar.

Aşağıdaki kod örneği işlemi göstermektedir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Seri Aralığı Genişliğini Ayarla**

Aralık genişliği, yan yana bulunan sütunlar veya çubuklar arasındaki boşluk miktarını kontrol eder; daha geniş aralıklar bireysel kategorileri vurgularken, daha dar aralıklar daha yoğun ve sıkışık bir görünüm sağlar. Aspose.Slides for Python ile bu parametreyi tüm bir seri için ince ayar yapabilir, veri setinizi değiştirmeden sunumunuzun görsel dengesini tam olarak elde edebilirsiniz.

Aşağıdaki kod örneği bir serinin aralık genişliğini nasıl ayarlayacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Boş bir sunum oluştur.
with slides.Presentation() as presentation:

    # İlk slayta eriş.
    slide = presentation.slides[0]

    # Varsayılan verilerle bir grafik ekle.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Sunumu diske kaydet.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # gap_width değerini ayarla.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Sunumu diske kaydet.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Aralık genişliği](gap_width.png)

## **SSS**

**Bir grafikte bulunabilecek seri sayısında bir sınırlama var mı?**

Aspose.Slides, eklediğiniz seri sayısında sabit bir üst limit koymaz. Pratik sınır, grafiğin okunabilirliği ve uygulamanızın kullandığı bellek miktarı ile belirlenir.

**Küme içindeki sütunlar çok yakından ya da çok uzaktan mı?**

O serinin (veya üst seri grubunun) [gap_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/gap_width/) ayarını değiştirin. Değeri artırmak sütunlar arasındaki boşluğu genişletir, azaltmak ise onları birbirine yaklaştırır.