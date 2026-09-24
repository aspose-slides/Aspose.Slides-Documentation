---
title: Python Kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştir
linktitle: Veri Tablosu
type: docs
url: /tr/python-java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint sunumlarında grafik veri tablosu yazı tiplerini, kenarlıklarını ve legend anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, bir grafik veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarlıklarını ve legend anahtarlarını özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenarlık tipini nasıl kontrol edeceğinizi ve legend anahtarlarını nasıl göstereceğinizi veya gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarla**

Bir grafik veri tablosunu görüntülemek için `True` değerini [setDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDataTable) metoduna geçirin. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [getChartDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#getChartDataTable) metodunu kullanın.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. İlk slayta bir kümelenmiş sütun grafiği ekleyin.
1. Grafiğin veri tablosunu etkinleştirin.
1. Kalın metni [setFontBold](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setFontBold) ile etkinleştirin ve 20 puanlık metin için `20` değerini [setFontHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setFontHeight) metoduna geçirin.
1. Değiştirilen sunumu kaydedin.

İşte örnek, çalışma dizininde en az bir slayt içeren `test.pptx` dosyasını gerektirir. Varsayılan verilerle (50, 50) konumunda, 600 nokta genişliğinde ve 400 nokta yüksekliğinde bir grafik ekler. Kaydedilen `output.pptx` dosyası, veri tablosu etkinleştirilmiş ve belirtilen yazı tipi ayarları uygulanmış grafiği içerir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veri Tablosu Kenarlıklarını Özelleştir**

Tabloyu [Chart.setDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDataTable) ile etkinleştirin ve [Chart.getChartDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#getChartDataTable) üzerinden erişin. Üç kenarlık tipini bağımsız olarak kontrol edebilirsiniz:

- [setBorderHorizontal](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setBorderHorizontal) yatay hücre kenarlıklarını kontrol eder.
- [setBorderVertical](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setBorderVertical) dikey hücre kenarlıklarını kontrol eder.
- [setBorderOutline](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setBorderOutline) tablonun dış kenarlığını kontrol eder.

Her metoda `True` geçirerek kenarlıkları gösterin veya `False` geçirerek gizleyin. Aşağıdaki örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur, yatay kenarlıkları ve dış kenarlığı gösterir ve dikey kenarlıkları gizler. Giriş dosyası gerektirmez. Grafik konumu ve boyutu nokta cinsinden belirtilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki karşılaştırma, dört durumda aynı grafik verisi ve legend anahtarı ayarını kullanır. Tüm kenarlıklar etkinleştirilmiş olarak başlar, kalan her varyant yalnızca bir kenarlık ayarını devre dışı bırakır. Sol alt varyant, örnekteki kenarlık ayarlarıyla eşleşir.

![Grafik veri tabloları, tüm kenarlıklar etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık yok](data-table-borders.png)

## **Legend Anahtarlarını Göster veya Gizle**

Legend anahtarları, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretlerdir. Okuyucuların her tablo satırını bir grafik serisiyle eşleştirmesine yardımcı olurlar. Bu işaretleri göstermek için `True` değerini [setShowLegendKey](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setShowLegendKey) metoduna, gizlemek için `False` değerini geçirin.

Grafiğin ayrı legend'i, [Chart.setLegend](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setLegend) ile kontrol edilir. Bu ayarlar birbirinden bağımsızdır: ayrı legend'in gizlenmesi veri tablosundaki anahtarları gizlemez ve tablo anahtarlarının gizlenmesi ayrı legend'i gizlemez.

Aşağıdaki örnek, varsayılan verilerle bir grafik oluşturur, veri tablosunu etkinleştirir ve ayrı legend'i gizlerken içinde legend anahtarlarını gösterir. Tüm tablo kenarlıkları açıkça etkinleştirilir. Giriş sunumu gerekmez. Yalnızca tablo anahtarlarını gizlemek için `False` değerini [setShowLegendKey](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setShowLegendKey) metoduna geçirin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki karşılaştırma, aynı tabloyu legend anahtarları etkin ve devre dışı bırakılmış olarak gösterir. Tüm kenarlıklar etkin kalır ve ayrı grafik legend'i her iki durumda da gizlidir.

![Grafik veri tabloları, sol tarafta legend anahtarları gösterilirken sağ tarafta gizlenmiş](data-table-legend-keys.png)

## **SSS**

**Bir grafik veri tablosunda legend anahtarlarını gösterebilir miyim?**

Evet. Legend anahtarlarını göstermek için `True` değerini [setShowLegendKey](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datatable/#setShowLegendKey), gizlemek için `False` değerini geçirin.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides, grafiği ve gösterilen veri tablosunu, [PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/) veya [images](/slides/tr/python-java/convert-powerpoint-to-png/) dışa aktarırken slaytın bir parçası olarak işler.

**Şablondan yüklenen grafiklerde veri tablolarıyla çalışabilir miyim?**

Evet. Mevcut bir sunumdan veya şablondan yüklenen bir grafik için, veri tablosunun gösterilip gösterilmediğini kontrol etmek veya değiştirmek için [hasDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#hasDataTable) ve [setDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDataTable) metodlarını kullanın.

**Veri tablosu etkin olan grafikleri nasıl bulabilirim?**

Her slayttaki şekiller üzerinden döngü yapın, grafikleri tespit edin ve onların [hasDataTable](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#hasDataTable) metodunu çağırın. `True` değeri, veri tablosunun etkin olduğunu gösterir.