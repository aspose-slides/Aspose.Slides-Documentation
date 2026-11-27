---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट स्वरूपित करें
linktitle: चार्ट स्वरूपण
type: docs
weight: 60
url: /hi/python-net/chart-formatting/
keywords:
- चार्ट स्वरूपित करें
- चार्ट स्वरूपण
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में चार्ट स्वरूपण सीखें और अपनी PowerPoint प्रस्तुति को कस्टम अक्ष, फ़ॉन्ट, संख्या स्वरूप और गोल चार्ट किनारों के साथ उन्नत बनाएं।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को स्वरूपित करने का तरीका समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट क्षेत्र और दीवार भराइयों जैसे प्रमुख चार्ट तत्वों को निजीकरण करके चार्ट डेटा की उपस्थिति और पठनीयता को बेहतर बनाता है।

यह चार्ट टेक्स्ट के फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर पूर्वनिर्धारित संख्या स्वरूप लागू करने, और चार्ट क्षेत्र के कोनों को गोल करने का प्रदर्शन भी करता है। ये सभी उदाहरण मिलकर प्रस्तुति में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने के तरीके दिखाते हैं।

उत्थान और पतन अंतराल के लिए अलग-अलग भराइयाँ और outlines के बारे में, देखें [स्टॉक चार्ट उदाहरण](/slides/hi/python-net/create-chart/#create-stock-charts)।

## **चार्ट इकाइयों को स्वरूपित करें**

[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) का उपयोग करके चार्ट शीर्षक, अक्ष, ग्रिड रेखाएँ, लीजेंड और प्लॉट क्षेत्र को स्वरूपित करें। यह उदाहरण मार्कर वाले एक लाइन चार्ट को डिफ़ॉल्ट डेटा के साथ बनाता है, फिर उसके मान और श्रेणी अक्षों पर अलग‑अलग टेक्स्ट और लाइन शैलियों को लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट में निर्दिष्ट हैं; श्रेणी लेबल 45 डिग्री घुमाए गये हैं।

मान अक्ष [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) को स्रोत कोशिकाओं से स्वतंत्र रूप से उपयोग करता है। इसका स्केल -2 से 15 तक है, प्रमुख अंतराल 2 और गौण अंतराल 0.5 के साथ। यह उदाहरण प्रतिशत स्वरूपण को [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) को हजारों में सेट करने के साथ जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और आकार के अनुसार समायोजित करें। लीजेंड प्लॉट क्षेत्र के बाहर रहता है क्योंकि [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) निष्क्रिय है। बैक‑वॉल और फ़्लोर भराइयाँ [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) और [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) के माध्यम से कॉन्फ़िगर की जाती हैं, लेकिन ये सतहें केवल 3D चार्ट में ही दिखाई देती हैं।

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

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

[Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) के माध्यम से चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार सेट करें। यह उदाहरण 20‑पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) के द्वारा पहली श्रृंखला के लिए मान लेबल सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

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

## **चार्ट लीजेंड के लिए टेक्स्ट फ्रेम स्वरूपण पुन: उपयोग करें**

स्लाइड शीर्षक से लीजेंड को मिलाने के लिए, शीर्षक के पहले पैराग्राफ पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से फ़ॉन्ट सेट करें। लीजेंड के [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) पर [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) को कॉल करें। यह टेक्स्ट फ्रेम सेटिंग्स, पहले पैराग्राफ का स्वरूप, और उस पैराग्राफ के डिफ़ॉल्ट फ़ॉन्ट गुणों को कॉपी करता है। व्यक्तिगत भागों या बाद के पैराग्राफ पर सीधे लागू स्वरूपण स्रोत तक सीमित रहता है।

उदाहरण में टेम्पलेट के रूप में बोल्ड, नेवी‑रंग, 26‑पॉइंट Calibri शीर्षक उपयोग किया गया है। लीजेंड को स्टाइल करने के बाद, समान स्वरूपण को अलग कैप्शन पर लागू करने के लिए [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) का उपयोग किया जाता है।

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

सहेजी गई प्रस्तुति में, लीजेंड और कैप्शन आकार, वजन और रंग में शीर्षक से मेल खाते हैं। लीजेंड अभी भी श्रृंखला नाम दिखाता है, और कैप्शन अपना स्वयं का टेक्स्ट रखता है। यदि कैप्शन के किसी भाग में स्पष्ट फ़ॉन्ट आकार पहले से निर्धारित है, तो वह आकार कॉपी किए गए पैराग्राफ डिफ़ॉल्ट पर प्राथमिकता लेता है।

| कॉपी करने से पहले | कॉपी करने के बाद |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **संख्यात्मक स्वरूप सेट करें**

[ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) का उपयोग करके चार्ट वर्कबुक कोशिकाओं पर निर्मित संख्या स्वरूप लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा वाले एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक श्रृंखला मान कोशिका पर फ़ॉर्मेट सूचकांक 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को बदले बिना उनके प्रदर्शित रूप को बदलता है; उदाहरण के तौर पर, 0.25 को 25.00 % दिखाया जाता है। अक्ष और डेटा‑लेबल स्वरूपों को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका में निर्मित संख्या स्वरूप सूचकांक और उनके प्रतिनिधि Excel स्वरूप अंग्रेज़ी (United States) locale के लिए दर्शाए गये हैं। सटीक स्वरूप स्ट्रिंग और उनका प्रदर्शन अनुप्रयोग और locale के अनुसार बदल सकता है, विशेषकर मुद्रा और तिथियों के लिए। कुछ Excel स्वरूप OOXML मानक के डिफ़ॉल्ट से भी भिन्न होते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में बताया गया है।

| सूचकांक | फ़ॉर्मेट |
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

## **चार्ट क्षेत्र के गोल किनारे सेट करें**

[Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) को सक्षम करके चार्ट क्षेत्र के कोनों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) का उपयोग करके उसकी रूपरेखा को ठोस धूसर रंग और एक‑लाइनी शैली देता है, फिर प्रस्तुति सहेजता है।

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

## **मौजूदा चार्ट एनोटेशन संपादित करें**

एक चार्ट में कस्टम शेप्स हो सकती हैं, जैसे कि रिपोर्ट की स्थिति बताने वाला टेक्स्ट एनोटेशन। इन शेप्स तक पहुंचने के लिए [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) का उपयोग करें। इसके [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) संग्रह में चार्ट‑स्वामित्व वाली शेप्स होती हैं।

एक साधारण टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा गया है, वह स्लाइड की शेप मानी जाती है, भले ही वह चार्ट का भाग जैसा दिखे। [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) के माध्यम से इटरनेट करने पर चार्ट और सामान्य स्लाइड शेप्स मिलते हैं, लेकिन चार्ट के भीतर की व्यक्तिगत शेप्स की सूची नहीं मिलती। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) डाउनलोड करें और इसे एप्लिकेशन की कार्यशील निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है, जिसमें एक अनग्रुप्ड एनोटेशन “Preliminary results” के साथ, एक चार्ट‑स्वामित्व वाली लाइन, और “Slide overlay” टेक्स्ट वाला साधारण स्लाइड टेक्स्ट बॉक्स है। उदाहरण उस स्लाइड पर पहला चार्ट खोजता है और रिपोर्ट तैयार होने पर एनोटेशन को “Final results” में बदलता है। यह खाली संग्रह की जाँच करता है और केवल उन [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) को संपादित करता है जिनके पास [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) न तो `None` है और अपेक्षित टेक्स्ट मौजूद है।

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

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। नीचे दी गई छवियां इनपुट और सहेजे गये, फिर से खोले गये परिणाम को दिखाती हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तरीय चार्ट‑स्वामित्व वाले शेप्स को ही निरीक्षण करता है। यदि कोई एनोटेशन किसी [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) के भीतर है, तो उस समूह के [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) संग्रह को भी जांचें। नेस्टेड समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, और उनके चाइल्ड शेप्स पर समान टेक्स्ट जाँच लागू करें। समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/क्षेत्रों के लिए अर्ध‑पारदर्शी भराइयाँ सेट कर सकता हूं जबकि बॉर्डर अपारदर्शी रहे?**

हाँ। भरावट की पारदर्शिता और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घने विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या कर सकता हूं?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (जैसे श्रेणियां) को निष्क्रिय करें, लेबल स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या स्वरूप को “value + legend” में बदल दें।

**क्या मैं श्रृंखला पर ग्रेडिएंट या पैटर्न भराइयाँ लागू कर सकता हूं?**

हाँ। श्रृंखलाएँ ठोस, ग्रेडिएंट और पैटर्न भराइयों का समर्थन करती हैं। व्यवहार में, ग्रेडिएंट का संयमित प्रयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के बीच कंट्रास्ट घटा दें।