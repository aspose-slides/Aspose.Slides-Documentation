---
title: Python Kullanarak Sunumlarda Grafik Biçimlendirme
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
- yuvarlatılmış kenar
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python ile .NET'te grafik biçimlendirmeyi öğrenin ve PowerPoint ya da OpenDocument sunumunuzu profesyonel, göz alıcı bir stil ile yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Eks eksenleri, ızgara çizgileri, başlıklar, lejandlar, çizim alanı ve duvar doldurmaları gibi temel grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini nasıl artıracağınızı gösterir.

Ayrıca grafik metni için yazı tipi özelliklerini ayarlamayı, grafik verilerine ön tanımlı ve özel sayısal biçimler uygulamayı ve grafik alanı için yuvarlatılmış köşeleri etkinleştirmeyi gösterir. Bu örnekler, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edeceğinizi ortaya koyar.

## **Grafik Öğelerini Biçimlendirme**

Aspose.Slides for Python, geliştiricilerin sıfırdan slaytlarına özel grafikler eklemesini sağlar. Bu bölümde, kategori ve değer eksenleri dahil olmak üzere çeşitli grafik öğelerinin nasıl biçimlendirileceği açıklanır.

Aspose.Slides, grafik öğelerini yönetmek ve özel biçimlendirme uygulamak için basit bir API sunar:

1. [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı indeksine göre referans alın.
1. İstenilen türde (bu örnekte `ChartType.LINE_WITH_MARKERS`) varsayılan verilerle bir grafik ekleyin.
1. Grafiğin değer eksenine erişin ve aşağıdakileri ayarlayın:
   1. Değer ekseni ana ızgara çizgileri için **çizgi biçimini** ayarlayın.
   1. Değer ekseni yan ızgara çizgileri için **çizgi biçimini** ayarlayın.
   1. Değer ekseni için **sayı biçimini** ayarlayın.
   1. Değer ekseni için **min, max, ana ve yan birimleri** ayarlayın.
   1. Değer ekseni etiketleri için **metin özelliklerini** ayarlayın.
   1. Değer ekseni için **başlığı** ayarlayın.
   1. Değer ekseni için **çizgi biçimini** ayarlayın.
1. Grafiğin kategori eksenine erişin ve aşağıdakileri ayarlayın:
   1. Kategori ekseni ana ızgara çizgileri için **çizgi biçimini** ayarlayın.
   1. Kategori ekseni yan ızgara çizgileri için **çizgi biçimini** ayarlayın.
   1. Kategori ekseni etiketleri için **metin özelliklerini** ayarlayın.
   1. Kategori ekseni için **başlığı** ayarlayın.
   1. Kategori ekseni için **etiket konumlandırmasını** ayarlayın.
   1. Kategori ekseni etiketleri için **dönme açısını** ayarlayın.
1. Grafik lejandına erişin ve **metin özelliklerini** ayarlayın.
1. Grafiğin üzerine gelmeden lejandı gösterin.
1. Grafiğin **ikincil değer eksenine** erişin ve aşağıdakileri ayarlayın:
   1. İkincil **değer eksenini** etkinleştirin.
   1. İkincil değer ekseni için **çizgi biçimini** ayarlayın.
   1. İkincil değer ekseni için **sayı biçimini** ayarlayın.
   1. İkincil değer ekseni için **min, max, ana ve yan birimleri** ayarlayın.
1. İlk grafik serisini ikincil değer eksenine çizin.
1. Grafiğin arka duvar doldurma rengini ayarlayın.
1. Grafiğin çizim alanı doldurma rengini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Presentation sınıfının bir örneğini oluştur.
    with slides.Presentation() as presentation:

        # İlk slayta eriş.
        slide = presentation.slides[0]

        # Örnek bir grafik ekle.
        chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

        # Grafiğin başlığını ayarla.
        chart.has_title = True
        chart.chart_title.add_text_frame_for_overriding("")
        chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
        chart_title.text = "Sample Chart"
        chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
        chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
        chart_title.portion_format.font_height = 20
        chart_title.portion_format.font_bold = 1
        chart_title.portion_format.font_italic = 1

        # Değer ekseni için ana ızgara çizgisi biçimini ayarla.
        chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
        chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
        chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

        # Değer ekseni için yan ızgara çizgisi biçimini ayarla.
        chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
        chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

        # Değer ekseni sayı biçimini ayarla.
        chart.axes.vertical_axis.is_number_format_linked_to_source = False
        chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
        chart.axes.vertical_axis.number_format = "0.0%"

        # Değer ekseni maksimum, minimum, ana birim ve yan birimi ayarla.
        chart.axes.vertical_axis.is_automatic_major_unit = False
        chart.axes.vertical_axis.is_automatic_max_value = False
        chart.axes.vertical_axis.is_automatic_minor_unit = False
        chart.axes.vertical_axis.is_automatic_min_value = False

        chart.axes.vertical_axis.max_value = 15
        chart.axes.vertical_axis.min_value = -2
        chart.axes.vertical_axis.minor_unit = 0.5
        chart.axes.vertical_axis.major_unit = 2.0

        # Değer ekseni metin özelliklerini ayarla.
        vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
        vertical_axis_portion_format.font_bold = 1
        vertical_axis_portion_format.font_height = 16
        vertical_axis_portion_format.font_italic = 1
        vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
        vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
        vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

        # Değer ekseni başlığını ayarla.
        chart.axes.vertical_axis.has_title = True
        chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
        vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
        vertical_axis_title.text = "Primary Axis"
        vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
        vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
        vertical_axis_title.portion_format.font_height = 20
        vertical_axis_title.portion_format.font_bold = 1
        vertical_axis_title.portion_format.font_italic = 1

        # Kategori ekseni için ana ızgara çizgisi biçimini ayarla.
        chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
        chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

        # Kategori ekseni için yan ızgara çizgisi biçimini ayarla.
        chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
        chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
        chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

        # Kategori ekseni metin özelliklerini ayarla.
        horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
        horizontal_axis_portion_format.font_bold = 1
        horizontal_axis_portion_format.font_height = 16
        horizontal_axis_portion_format.font_italic = 1
        horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
        horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
        horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

        # Kategori ekseni başlığını ayarla.
        chart.axes.horizontal_axis.has_title = True
        chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

        horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
        horizontal_axis_title.text = "Sample Category"
        horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
        horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
        horizontal_axis_title.portion_format.font_height = 20
        horizontal_axis_title.portion_format.font_bold = 1
        horizontal_axis_title.portion_format.font_italic = 1

        # Kategori ekseni etiket konumunu ayarla.
        chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

        # Kategori ekseni etiket döndürme açısını ayarla.
        chart.axes.horizontal_axis.tick_label_rotation_angle = 45

        # Lejant metin özelliklerini ayarla.
        legend_portion_format = chart.legend.text_format.portion_format
        legend_portion_format.font_bold = 1
        legend_portion_format.font_height = 16
        legend_portion_format.font_italic = 1
        legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
        legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

        # Grafiğin üzerine gelecek şekilde lejandı göster.
        chart.legend.overlay = True
                
        # Grafiğin arka duvar rengini ayarla.
        chart.back_wall.thickness = 1
        chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
        chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

        chart.floor.format.fill.fill_type = slides.FillType.SOLID
        chart.floor.format.fill.solid_fill_color.color = draw.Color.red

        # Çizim alanı rengini ayarla.
        chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
        chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

        # Sunumu kaydet.
        presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Yazı Tipi Özelliklerini Ayarlama**

Aspose.Slides for Python, grafikler için yazı tipi ile ilgili özellikleri ayarlamayı destekler. Aşağıdaki adımları izleyerek grafik yazı tipi özelliklerini yapılandırın:

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Yazı tipi yüksekliğini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir kod verilmiştir.

```py
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

Aspose.Slides for Python, grafik veri biçimlerini yönetmek için basit bir API sunar:

1. [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı indeksine göre referans alın.
1. İstenen herhangi bir türde varsayılan verilerle bir grafik ekleyin.
1. Kullanılabilir ön tanımlı değerlerden bir ön ayarlı sayı biçimini ayarlayın.
1. Her serideki grafik veri hücrelerini dolaşın ve sayı biçimini ayarlayın.
1. Sunumu kaydedin.
1. Özel bir sayı biçimi ayarlayın.
1. Her serideki grafik veri hücrelerini dolaşın ve farklı bir sayı biçimi ayarlayın.
1. Sunumu kaydedin.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation sınıfının bir örneğini oluştur.
with slides.Presentation() as presentation:
    # İlk slayta eriş.
    slide = presentation.slides[0]

    # Varsayılan bir kümelenmiş sütun grafik ekle.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Ön ayarlı sayı biçimini ayarla.
    # Her grafik serisini dolaş.
    for series in chart.chart_data.series:
        # Serideki her veri noktasını dolaş.
        for cell in series.data_points:
            # Sayı biçimini ayarla.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Sunumu kaydet.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Kullanılabilir ön tanımlı sayı biçimleri ve karşılık gelen dizinleri aşağıda listelenmiştir.

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

## **Grafik Alanı için Yuvarlatılmış Kenarlıkları Ayarlama**

Aspose.Slides for Python, `Chart.has_rounded_corners` özelliği ile grafik alanını yapılandırmayı destekler.

1. Bir [Sunum](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesi oluşturun.
2. Slayta bir grafik ekleyin.
3. Grafiğin doldurma tipini ve doldurma rengini ayarlayın.
4. Yuvarlatılmış köşe özelliğini `True` olarak ayarlayın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıda bir örnek verilmiştir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Sütun/alan doldurmalarını yarı saydam yaparken kenarı opak tutabilir miyim?**

Evet. Doldurma saydamlığı ve dış hat ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve veri okunabilirliğini artırmak için faydalıdır.

**Etiketler çakıştığında ne yapmalıyım?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini (örneğin kategori) devre dışı bırakın, etiket ofset/konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiket gösterin veya biçimi “değer + lejand” olarak değiştirin.

**Serilere degrade veya desen doldurması uygulayabilir miyim?**

Evet. Hem katı hem de degrade/desen doldurmaları genellikle mevcuttur. Pratikte, degradeleri sınırlı kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.