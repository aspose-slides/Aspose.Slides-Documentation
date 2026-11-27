---
title: Python Kullanarak Sunumlarda Grafikleri Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/python-net/chart-formatting/
keywords:
- grafiği biçimlendir
- grafik biçimlendirme
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenarlık
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python üzerinden .NET ile grafik biçimlendirmeyi öğrenin ve özel eksenler, yazı tipleri, sayı formatları ve yuvarlatılmış grafik kenarlarıyla PowerPoint sunumunuzu yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Ekseler, ızgara çizgileri, başlıklar, açıklama kutuları, çizim alanı ve duvar dolgu gibi temel grafik öğelerinin nasıl özelleştirileceğini göstererek grafik verilerinin görünümünü ve okunabilirliğini artırır.

Grafik metni için yazı tipi özelliklerinin nasıl ayarlanacağını, grafik verilerine önceden tanımlı sayısal biçimlerin nasıl uygulanacağını ve grafik alanı için yuvarlatılmış köşelerin nasıl etkinleştirileceğini de gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edebileceğinizi gösterir.

Yükselen ve düşen aralıklar için ayrı dolgu ve kenarlıklar hakkında, [hisse senedi grafik örneği](/slides/tr/python-net/create-chart/#create-stock-charts) bölümüne bakın.

## **Grafik Varlıklarını Biçimlendirme**

Grafik başlıkları, ekseler, ızgara çizgileri, açıklama kutuları ve çizim alanını biçimlendirmek için [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) kullanın. Bu örnek, işaretçiler ve varsayılan verilerle bir çizgi grafik oluşturur, ardından değer ve kategori eksenlerine ayrı metin ve çizgi stilleri uygular. Yazı tipi boyutları ve çizgi kalınlıkları nokta biriminde belirtilir; kategori etiketleri 45 derece döndürülür.

Değer ekseni, kaynak hücrelerden bağımsız olarak [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) kullanır. Ölçeği -2 ile 15 arasındadır, ana aralıklar 2, yan aralıklar 0.5'tir. Örnek ayrıca yüzde biçimlendirmesini, binlere ayarlanmış [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ile birleştirir; bu ayarları verilerinizin anlamına ve ölçeğine göre uyarlayın. Açıklama kutusu, [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) devre dışı olduğu için çizim alanının dışında kalır. Arka duvar ve taban dolgu renkleri, [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) ve [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) üzerinden yapılandırılır, ancak bu yüzeyler yalnızca 3B grafiklerde görülür.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik için Yazı Tipi Özelliklerini Ayarlama**

Grafik metni için varsayılan yazı tipi boyutunu [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) aracılığıyla ayarlayın. Örnek, 20 puanlık bir yazı tipiyle bir kümelenmiş sütun grafik oluşturur ve [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ile ilk seri için değer etiketlerini etkinleştirir. Kendi açık yazı tipi ayarlarına sahip metin öğeleri, grafik varsayılanını geçersiz kılabilir.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Grafik Açıklaması için Metin Çerçevesi Biçimlendirmesini Yeniden Kullanma**

Açıklama kutusunu slayt başlığıyla eşleştirmek için, başlığın ilk paragrafındaki yazı tipini [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) üzerinden ayarlayın. Açıklamanın [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) üzerinde [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) çağrısında bulunun. Bu işlem, metin çerçevesi ayarlarını, ilk paragrafın biçimlendirmesini ve o paragrafın varsayılan yazı tipi özelliklerini kopyalar. Bireysel bölümlere ya da sonraki paragraflara doğrudan uygulanan biçimlendirme kaynakta kalır.

Örnek, kalın, lacivert, 26 puan Calibri bir başlığı şablon olarak kullanır. Açıklamayı stilize ettikten sonra, aynı biçimlendirmeyi ayrı bir başlığa uygulamak için [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) kullanır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

Kaydedilen sunumda, açıklama ve başlık boyut, kalınlık ve renk bakımından başlıkla eşleşir. Açıklama hâlâ seri adlarını gösterir, başlık ise kendi metnini korur. Başlıkta zaten açık bir yazı tipi boyutu belirlenmiş bir bölüm varsa, bu boyut kopyalanan paragraf varsayılanının üzerine geçer.

| Kopyalamadan önce | Kopyaladıktan sonra |
| --- | --- |
| ![Dönemsel satış grafiği, normal siyah açıklama etiketleri ve siyah başlık ile](legend-formatting-before.png) | ![Aynı grafik, daha büyük, kalın lacivert açıklama etiketleri ve eşleşen başlık ile](legend-formatting.png) |

## **Sayısal Biçimi Ayarlama**

Grafik çalışma kitabı hücrelerine yerleşik bir sayı biçimi uygulamak için [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) kullanın. Bu örnek, varsayılan hücre‑destekli veriyle bir kümelenmiş sütun grafik oluşturur ve her seri değer hücresine biçim indeks 10 (`0.00%`) uygular. Bu, sayıları değiştirmeden çalışma kitabında değerlerin nasıl gösterileceğini değiştirir; örneğin 0.25, %25.00 olarak görünür. Ekseler ve veri‑etiket biçimleri ayrı ayrı yapılandırılabilir.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki tablo, İngiliz (Amerika Birleşik Devletleri) yerel ayarı için temsilci Excel biçimleriyle yerleşik sayı biçimi indekslerini listeler. Kesin biçim dizgileri ve gösterimleri uygulamaya ve yerel ayara göre değişebilir, özellikle para birimi ve tarih biçimleri için. Bazı Excel biçimleri, OOXML standardındaki varsayılanlardan farklıdır; bununla ilgili ayrıntılar [Microsoft'un sayı biçimi uygulama notlarında](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) açıklanmıştır.

| İndeks | Biçim |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Grafik Alanı Yuvarlatılmış Kenarlıklar Ayarlama**

Grafik alanının köşelerini yuvarlatmak için [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) etkinleştirin. Örnek, bir kümelenmiş sütun grafik oluşturur ve kaydetmeden önce [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) ile kenarına düz gri renk ve tek çizgi stili verir.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Mevcut Grafik Açıklamalarını Düzenleme**

Bir grafik, rapor durumunu açıklayan bir metin açıklaması gibi özel şekiller içerebilir. Bu şekillere [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) üzerinden erişin. Its [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonu, grafik‑sahibi şekilleri içerir.

Grafiğin üzerine konulan sıradan bir metin kutusu slayta aittir, grafik parçası gibi görünse de. [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) içinde döngü yapmak, grafiği ve sıradan slayt şekillerini bulur, ancak grafiğin içindeki bireysel şekilleri listelemez. Grafik başlıkları ve veri etiketleri ayrı grafik öğeleridir, bu koleksiyonda özel açıklama değildir.

[chart-annotations.pptx](chart-annotations.pptx) dosyasını indirin ve uygulamanın çalışma dizinine koyun. İlk slaytı, “Ön sonuçlar” metniyle bir gruplamadan çıkarılmış açıklama, grafik‑sahibi bir çizgi ve “Slayt yerleşimi” metniyle bir sıradan slayt metin kutusu içerir. Örnek, o slayttaki ilk grafiği bulur ve rapor yayımlamaya hazır olduğunda açıklamayı “Son sonuçlar” olarak değiştirir. Boş bir koleksiyon olup olmadığını kontrol eder ve yalnızca `None` olmayan ve beklenen metni içeren bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ve [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) düzenler.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

Çizgi ve slayt metin kutusu değişmeden kalır. Aşağıdaki görseller giriş ve kaydedilip yeniden açılmış sonucu gösterir:

| Düzenlemeden önce | Düzenledikten sonra |
| --- | --- |
| ![Grafik açıklaması: Ön sonuçlar](chart-annotations-before.png) | ![Grafik açıklaması: Son sonuçlar](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Örnek yalnızca en üst düzeydeki grafik‑sahibi şekilleri inceler. Bir açıklama bir [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) içinde ise, o grubun [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonunu da inceleyin. İç içe gruplar için bu işlemi yineleyerek, alt şekillerine aynı metin kontrollerini uygulayın. Bir grup kendisi bir kapsayıcıdır; onu bir metin kutusu gibi işlemeyin.
{{% /alert %}}

## **SSS**

**Sütunlar/alanlar için yarı saydam dolgu ayarlayabilir miyim, kenarlık opak kalırken?**

Evet. Dolgu şeffaflığı ve çerçeve ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verinin okunabilirliğini artırmak için yararlıdır.

**Etiketler üst üste geldiğinde nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategoriler), etiket konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiketleri gösterin veya biçimi “değer + açıklama” olarak değiştirin.

**Serilere degrade veya desen dolguları uygulayabilir miyim?**

Evet. Seriler katı, degrade ve desen dolgularını destekler. Pratikte, degradeleri ölçülü kullanın ve ızgara ile metin arasındaki kontrastı azaltan kombinasyonlardan kaçının.