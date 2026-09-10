---
title: Python Kullanarak Sunumlarda 3B Grafikleri Özelleştirme
linktitle: 3B Grafik
type: docs
url: /tr/python-java/3d-chart/
keywords:
- 3B grafik
- dönüş
- derinlik
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da 3‑B grafikler oluşturmayı ve özelleştirmeyi öğrenin, PPT ve PPTX dosyalarını destekler—sunumlarınızı bugün güçlendirin."
---
## **Overview**

Bu makale, Aspose.Slides'ta 3B bir grafiği, [Rotation3D](https://reference.aspose.com/slides/tr/python-java/aspose.slides/rotation3d/) ayarlarını [setRotationX](https://reference.aspose.com/slides/tr/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/tr/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/tr/python-java/aspose.slides/rotation3d/#setDepthPercents) ve [setRightAngleAxes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/rotation3d/#setRightAngleAxes) gibi yapılandırarak özelleştirmenin nasıl yapılacağını açıklar. Sunum oluşturma, varsayılan verilerle bir 3B grafik ekleme, gerekli 3B görünüm ayarlarını uygulama ve değiştirilmiş sunumu PPTX dosyası olarak kaydetme adımlarını gösterir.

## **Set X Rotation, Y Rotation, and Depth of a 3D Chart**
Aspose.Slides for Python via Java, bu özellikleri ayarlamak için basit bir API sağlar. Aşağıdaki örnek, bir 3B grafiğin X dönüşünü, Y dönüşünü ve derinliğini nasıl ayarlayacağınızı gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan veriyle bir grafik ekleyin.
4. 3B dönüş özelliklerini ayarlayın.
5. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # İlk slayta erişin.
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan veriyle bir grafik ekleyin.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Grafik veri çalışma sayfası indeksini ayarlayın.
    default_worksheet_index = 0

    # Grafik veri çalışma kitabını alın.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Seri ekleyin.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Kategoriler ekleyin.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 3B dönüş özelliklerini ayarlayın.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # İkinci grafik serisine erişin.
    series = chart.getChartData().getSeries().get_Item(1)

    # Seri verilerini doldurun.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Sunumu kaydedin.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides'ta hangi grafik türleri 3B modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3B varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3B tipleri destekler. Tam ve güncel liste için yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3B grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [chart API](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage) üzerinden görüntüye dışa aktarabilir veya [tam slaytı render ederek](/slides/tr/python-java/convert-powerpoint-to-png/) PNG veya JPEG gibi formatlara dönüştürebilirsiniz. Bu, piksel bazında mükemmel bir ön izleme gerektiğinde veya grafiği belge, gösterge panosu ya da web sayfasına PowerPoint gerektirmeden gömmek istediğinizde faydalıdır.

**Büyük 3B grafikleri oluşturma ve render etme performansı nasıldır?**

Performans veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3B efektleri minimumda tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri nokta sayısını sınırlayın ve hedef ekran ya da baskı ihtiyacına uygun çözünürlük ve boyutlarda bir çıktı üretecek şekilde render edin.