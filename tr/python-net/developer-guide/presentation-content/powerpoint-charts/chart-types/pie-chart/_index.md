---
title: Python ile Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/python-net/pie-chart/
keywords:
- pasta grafiği
- grafiği yönet
- grafiği özelleştir
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Python ve Aspose.Slides ile pasta grafikleri oluşturmayı ve özelleştirmeyi öğrenin, PowerPoint ve OpenDocument olarak dışa aktarılabilir, veri hikaye anlatımınızı saniyeler içinde artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklerinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seriler ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenen sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkincil Çizim Seçenekleri**

Aspose.Slides for Python via .NET artık Pie of Pie veya Bar of Pie grafiği için ikincil çizim seçeneklerini destekliyor. Bu konuda, Aspose.Slides kullanarak bu seçeneklerin nasıl belirtileceğini bir örnekle göreceğiz. Özellikleri belirtmek için lütfen aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıf nesnesi başlatın.
1. Slayta bir grafik ekleyin.
1. Grafiğin ikincil çizim seçeneklerini belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnekte, Pie of Pie grafiğinin farklı özelliklerini ayarladık.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur
with slides.Presentation() as presentation:
    # Slayta grafik ekle
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Farklı özellikleri ayarla
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Sunumu diske kaydet
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Otomatik Pasta Grafik Dilim Renklerini Ayarlama**

Aspose.Slides for Python via .NET, otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sağlar. Örnek kod, yukarıda bahsedilen özelliklerin ayarlanmasını uygular.

1. Presentation sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Grafik başlığını ayarlayın.
1. İlk seriyi Değerleri Göster olarak ayarlayın.
1. Grafik veri sayfasının dizinini ayarlayın.
1. Grafik veri çalışma sayfasını alıyor.
1. Varsayılan oluşturulan serileri ve kategorileri silin.
1. Yeni kategoriler ekleyin.
1. Yeni seriler ekleyin.

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluştur
with slides.Presentation() as presentation:
	# İlk slayta eriş
	slide = presentation.slides[0]

	# Varsayılan verilerle grafik ekle
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Grafik başlığını ayarlama
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# İlk seriyi Değerleri Göster olarak ayarla
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Grafik veri sayfasının dizinini ayarlama
	defaultWorksheetIndex = 0

	# Grafik veri çalışma sayfasını alıyor
	fact = chart.chart_data.chart_data_workbook

	# Varsayılan oluşturulan serileri ve kategorileri sil
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Yeni kategoriler ekleme
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Yeni seri ekleme
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Şimdi seri verileri dolduruluyor
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane pasta grafikler için ikincil bir çizimi, 'Pie of Pie' ve 'Bar of Pie' tipleri dahil olmak üzere, [destekler](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/).

**Grafiği yalnızca bir görüntü (örneğin, PNG) olarak dışa aktarabilir miyim?**

Evet, tüm sunumu dışarı aktarmadan grafiği doğrudan bir görüntü (örneğin PNG) olarak [dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/get_image/).