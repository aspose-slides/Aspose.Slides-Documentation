---
title: Python Kullanarak Sunumlarda Grafikleri Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/python-net/chart-formatting/
keywords:
- grafik biçimlendirme
- grafik formatlama
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlak kenar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile .NET üzerinden grafik biçimlendirmeyi öğrenin ve özel eksenler, yazı tipleri, sayı formatları ve yuvarlak grafik kenarlarıyla PowerPoint sunumunuzu yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında nasıl grafik biçimlendireceğini açıklar. Ekseni, ızgara çizgileri, başlıklar, açıklama kutuları, çizim alanı ve duvar doldurmaları gibi temel grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca, grafik metni için yazı tipi özelliklerini nasıl ayarlayacağınızı, grafik verilerine önceden tanımlı sayısal biçimleri nasıl uygulayacağınızı ve grafik alanının köşelerini yuvarlatmayı nasıl etkinleştireceğinizi gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edeceğinizi gösterir.

## **Grafik Varlıklarını Biçimlendir**

Grafik başlıklarını, eksenleri, ızgara çizgilerini, açıklama kutularını ve çizim alanını biçimlendirmek için [Grafik](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) kullanın. Bu örnek, işaretçili ve varsayılan veri içeren bir çizgi grafik oluşturur, ardından değer ve kategori eksenlerine ayrı metin ve çizgi stilleri uygular. Yazı tipi boyutları ve çizgi kalınlıkları nokta biriminde belirtilir; kategori etiketleri 45 derece döndürülür.

Değer ekseni, kaynak hücrelerden bağımsız olarak [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) kullanır. Ölçeği -2 ile 15 arasında, ana aralıkları 2 ve alt aralıkları 0,5 olarak ayarlar. Örnek ayrıca yüzde biçimlendirmesini [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) binler olarak ayarlanmış şekilde birleştirir; bu ayarları verinizin anlamına ve büyüklüğüne göre uyarlayın. Açıklama kutusu, [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) devre dışı olduğu için çizim alanının dışında kalır. Arka duvar ve zemin doldurmaları [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) ve [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) aracılığıyla yapılandırılır, ancak bu yüzeyler yalnızca 3B grafiklerde görünür.

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

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**

Grafik metni için varsayılan yazı tipi boyutunu [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) aracılığıyla ayarlayın. Örnek, 20 puanlık bir yazı tipine sahip bir küme sütun grafiği oluşturur ve [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) kullanarak ilk seriye değer etiketlerini etkinleştirir. Kendi açık yazı tipi ayarlarına sahip metin öğeleri, grafik varsayılanını geçersiz kılabilir.

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

## **Sayısal Biçimi Ayarlama**

[ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) kullanarak grafik çalışma kitabı hücrelerine yerleşik bir sayı biçimi uygulayın. Bu örnek, varsayılan hücre tabanlı veri ile bir küme sütun grafiği oluşturur ve her seri değer hücresine format indeksi 10 (`0.00%`) uygular. Bu, temel sayıları değiştirmeden değerlerin çalışma kitabında nasıl görüntüleneceğini değiştirir; örneğin 0.25, 25,00% olarak gösterilir. Eksen ve veri etiketi biçimleri ayrı ayrı yapılandırılabilir.

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

Aşağıdaki tablo, İngilizce (Amerika Birleşik Devletleri) yerel ayarı için temsilci Excel biçimleriyle yerleşik sayı biçimi indekslerini listeler. Tam biçim dizgileri ve görüntülenmeleri uygulamaya ve yere göre değişebilir, özellikle para birimi ve tarihlerde. Bazı Excel biçimleri ayrıca OOXML standardındaki varsayılanlardan farklıdır; bu, [Microsoft'un sayı biçimi uygulama notları](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) içinde açıklanmıştır.

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

## **Grafik Alanı Yuvarlak Kenarları Ayarlama**

[Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) etkinleştirerek grafik alanının köşelerini yuvarlayın. Örnek bir küme sütun grafiği oluşturur ve [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) kullanarak kenarlığına katı gri renk ve tek çizgi stili verir, ardından sunumu kaydeder.

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

Bir grafik, rapor durumunu açıklayan bir metin açıklaması gibi özel şekiller içerebilir. Bu şekillere [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) aracılığıyla erişin. Bunun [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonu, grafik tarafından sahip olunan şekilleri içerir.

Bir grafik üzerine yerleştirilen sıradan bir metin kutusu, grafik parçası gibi görünse de slayta aittir. [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) içinde döngü yapıldığında grafik ve sıradan slayt şekilleri bulunur, ancak grafiğin içindeki ayrı ayrı şekiller listelenmez. Grafik başlıkları ve veri etiketleri ayrı grafik öğeleridir, bu koleksiyonda özel açıklama olarak yer almaz.

[chart-annotations.pptx](chart-annotations.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, “Preliminary results” metniyle bir gruplandırılmamış açıklama, grafik tarafından sahip olunan bir çizgi ve “Slide overlay” metniyle bir normal slayt metin kutusu içeren bir grafik içerir. Örnek, o slayttaki ilk grafiği bulur ve rapor yayınlanmaya hazır olduğunda açıklamayı “Final results” olarak değiştirir. Boş bir koleksiyon olup olmadığını kontrol eder ve yalnızca `None` olmayan ve beklenen metni içeren bir [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) içinde [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) düzenler.

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

Çizgi ve slayt metin kutusu değişmeden kalır. Aşağıdaki görüntüler giriş ve kaydedilip yeniden açılmış sonucu gösterir:

| Düzenlemeden önce | Düzenledikten sonra |
| --- | --- |
| ![‘Preliminary results’ okuyan grafik açıklaması](chart-annotations-before.png) | ![‘Final results’ okuyan grafik açıklaması](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Örnek yalnızca üst‑seviye grafik‑sahibi şekilleri inceler. Bir açıklama bir [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) içinde ise, o grubun [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonunu da inceleyin. Görevi iç içe gruplar için yineleyerek, çocuk şekillerine aynı metin kontrollerini uygulayın. Bir grup kendisi bir kapsayıcıdır; onu bir metin kutusu gibi ele almayın.
{{% /alert %}}

## **SSS**

**Sütunlar/alanlar için yarı şeffaf doldurmalar ayarlayabilir ve kenarlığı opak tutabilir miyim?**

Evet. Doldurma şeffaflığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri üst üste geldiğinde nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket konumunu ayarlayın, gerekirse sadece seçili noktalar için etiketleri gösterin veya biçimi “değer + açıklama” şeklinde değiştirin.

**Serilere degrade veya desen doldurmaları uygulayabilir miyim?**

Evet. Seriler katı, degrade ve desen doldurmaları destekler. Uygulamada, degradeleri ölçülü kullanın ve ızgara ile metin arasındaki kontrastı azaltan kombinasyonlardan kaçının.