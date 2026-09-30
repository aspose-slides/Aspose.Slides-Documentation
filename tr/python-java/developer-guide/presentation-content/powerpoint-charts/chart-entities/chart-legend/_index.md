---
title: Python Kullanarak Sunumlarda Grafik Açıklamalarını Özelleştirme
linktitle: Grafik Açıklaması
type: docs
url: /tr/python-java/chart-legend/
keywords:
- grafik açıklaması
- açıklama konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile grafik açıklamalarını özelleştirerek, özel açıklama biçimlendirmesiyle PowerPoint sunumlarını optimize edin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, PowerPoint sunumlarındaki grafik açıklamalarını özelleştirme seçenekleri sunar. Bu makale, bir açıklamanın konumunu ve boyutunu nasıl ayarlayacağınızı, tüm açıklama için yazı tipi boyutunu nasıl belirleyeceğinizi, tek bir açıklama girişini nasıl biçimlendireceğinizi ve seçili girişleri nasıl gizleyip geri getireceğinizi gösterir.

SSS, açıklama için alan ayırma, çok satırlı etiket gösterme ve sunum temasından biçimlendirme devralma gibi ilgili davranışları kapsar.

## **Açıklama Konumlandırma**

Açıklamanın [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) ve [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) yöntemlerini kullanarak konumunu ve boyutunu, grafiğin boyutlarının kesirleri olarak belirleyin.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan veriyle bir kümelenmiş sütun grafik ekler. İstenen açıklama kaydırma ve boyutlarını grafiğin genişliği ve yüksekliğiyle bölmek, bunları göreli değerlere çevirir: açıklama, grafiğin sol üst köşesinden 50 puan kaydırılır ve 100x100 puan boyutlandırılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Açıklamanın konumunu ve boyutunu grafik göreceli olarak belirtin.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Açıklamanın Yazı Tipi Boyutunu Ayarlama**

Açıklamanın [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) yöntemini kullanarak metin biçimlendirmesine erişin ve [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi boyutunu puan cinsinden ayarlayın.

Bu örnek, varsayılan veriyle bir grafik oluşturur ve açıklama metnini 20 puana ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığını -5 ile 10 arasında belirler.

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

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tek Bir Açıklama Girişinin Yazı Tipi Boyutunu Ayarlama**

Açıklamanın [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) yöntemiyle dönen koleksiyonu kullanarak belirli bir girişin biçimlendirmesine erişin. Giriş indeksleri sıfır tabanlıdır, bu yüzden `1` indeksi ikinci girişi ifade eder.

Bu örnek, varsayılan verisi en az iki seriyi içeren bir kümelenmiş sütun grafik oluşturur. İkinci açıklama girişini kalın, italik ve 20 puan mavi metinle biçimlendirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tek Tek Açıklama Girişlerini Gizleme**

Verileri görünür tutarken yardımcı bir seriyi açıklamadan hariç tutmak için, [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) yöntemini `True` ile ve [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) aracılığıyla çağırın. Bu, yalnızca seçilen açıklama girişini gizler; seriyi veya veri noktalarını kaldırmaz. Buna karşılık, [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) yöntemini `False` ile çağırmak tüm açıklamayı gizler.

Aşağıdaki örnek, varsayılan veriyle birden fazla seri içeren bir kümelenmiş sütun grafik oluşturur. İkinci serinin açıklama girişini (indeks `1`) gizler ve sunumu kaydeder. Ardından, [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) yöntemini `False` ile çağırarak girişi geri getirir ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

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
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Grafik verisini değiştirmeden aynı girişi geri yükleyin.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki karşılaştırma, tüm girişlerin görünür olduğu ve ikinci girişin gizlendiği aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm açıklama girişleri görünür ve Seri 2 açıklamadan gizli olduğu bir grafiğin karşılaştırması; tüm sütunlar görünür kalır.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerde, açıklama girişleri serileri tanımlar. Pasta grafiklerde ise ayrı veri noktalarını (dilimleri) tanımlar, bu yüzden seçili dilim üzerinde [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) kullanın. API, bu veri noktası yöntemini `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik türleri için belgeler. Bu yöntemin, listede yer almayan çember grafiklerinde geçerli olduğunu varsaymayın.

## **SSS**

**Grafiğin açıklama için alan ayırmasını, üzerine bindirmesini önleyebilir miyim?**

Evet. Açıklamanın çizim alanını kaplamasına izin vermek yerine alan ayırmak için [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) yöntemini `False` ile çağırın.

**Çok satırlı açıklama etiketleri oluşturabilir miyim?**

Evet. Genişlik yetersiz olduğunda uzun etiketler satır sonu ekleyerek kayabilir. Ayrıca seri adlarında yeni satır karakterleri kullanarak satır sonları isteyebilirsiniz.

**Açıklamanın sunum temasının renk şemasını izlemesini nasıl sağlarım?**

Açıklamanın renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın; böylece tema biçimlendirmesini devralır. Açık biçimlendirme ilgili tema ayarlarını geçersiz kılar.