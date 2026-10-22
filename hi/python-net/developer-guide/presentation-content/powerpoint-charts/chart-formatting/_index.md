---
title: PowerPoint प्रस्तुतियों में Python का उपयोग करके चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फॉर्मेटिंग
type: docs
weight: 60
url: /hi/python-net/chart-formatting/
keywords:
- चार्ट फॉर्मेट
- चार्ट फॉर्मेटिंग
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में चार्ट फॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, संख्या फ़ॉर्मेट और गोल चार्ट किनारों के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फॉर्मेट करने के तरीके को समझाता है। यह अक्ष, ग्रिड लाइनों, शीर्षकों, लेजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को बेहतर बनाने का प्रदर्शन करता है।

यह यह भी दिखाता है कि चार्ट टेक्स्ट के फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर पूर्वनिर्धारित संख्यात्मक फ़ॉर्मेट लागू करें, और चार्ट एरिया के किनारों को गोल करने की सुविधा कैसे सक्षम करें। ये सभी उदाहरण प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने का तरीका प्रदर्शित करते हैं।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) का उपयोग करके चार्ट शीर्षक, अक्ष, ग्रिड लाइनों, लेजेंड और प्लॉट एरिया को फ़ॉर्मेट करें। यह उदाहरण मार्कर वाले लाइन चार्ट को डिफ़ॉल्ट डेटा के साथ बनाता है, फिर उसके वैल्यू और कैटेगिरी अक्षों पर अलग-अलग टेक्स्ट और लाइन स्टाइल लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट में निर्दिष्ट हैं; कैटेगिरी लेबल 45 डिग्री घुमाए गए हैं।

वैल्यू एक्सिस स्रोत कोशिकाओं से स्वतंत्र रूप से [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) का उपयोग करता है। इसका स्केल -2 से 15 तक है, मुख्य अंतराल 2 और गौण अंतराल 0.5 हैं। उदाहरण प्रतिशत फ़ॉर्मेटिंग को [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) को हज़ार सेट करके भी संयोजित करता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और परिमाण के अनुसार अनुकूलित करें। लेजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) अक्षम है। बैक-वॉल और फ़्लोर फ़िल्स को [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) और [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) के माध्यम से कॉन्फ़िगर किया जाता है, लेकिन ये सतहें केवल 3D चार्ट में दिखाई देती हैं।

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

## **चार्ट के फ़ॉन्ट गुण सेट करें**

[Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/) के माध्यम से चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार सेट करें। यह उदाहरण 20 पॉइंट फ़ॉन्ट वाले क्लस्टर्ड कॉलम चार्ट को बनाता है और पहले सीरीज़ के लिए [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) के द्वारा वैल्यू लेबल सक्षम करता है। अपनी स्वयं की स्पष्ट फ़ॉन्ट सेटिंग्स वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

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

## **संख्यात्मक फ़ॉर्मेट सेट करें**

[ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) का उपयोग करके चार्ट वर्कबुक कोशिकाओं पर निर्मित संख्या फ़ॉर्मेट लागू करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा वाले क्लस्टर्ड कॉलम चार्ट को बनाता है और प्रत्येक सीरीज़ वैल्यू सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को बदलें बिना उनके प्रदर्शन को बदलता है; उदाहरण के लिए, 0.25 को 25.00% के रूप में दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

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

निम्न तालिका में बिल्ट‑इन नंबर फ़ॉर्मेट इंडेक्स और अंग्रेज़ी (संयुक्त राज्य) लोकल के प्रतिनिधि Excel फ़ॉर्मेट सूचीबद्ध हैं। सटीक फ़ॉर्मेट स्ट्रिंग और उनका प्रदर्शन एप्लिकेशन और लोकल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथियों के लिए। कुछ Excel फ़ॉर्मेट OOXML मानक के डिफ़ॉल्ट से भी भिन्न हो सकते हैं, जैसा कि [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| Index | Format |
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

## **चार्ट एरिया के गोल किनारे सेट करें**

[Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) को सक्षम करके चार्ट एरिया के किनारों को गोल बनाएं। यह उदाहरण क्लस्टर्ड कॉलम चार्ट बनाता है और उसके रूपरेखा को ठोस ग्रे रंग और सिंगल‑लाइन स्टाइल देने के लिए [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) का उपयोग करता है, फिर प्रस्तुति को सहेजता है।

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

एक चार्ट में कस्टम शेप, जैसे रिपोर्ट की स्थिति समझाने वाला टेक्स्ट एनोटेशन, हो सकता है। इन शेप तक पहुंचें [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/) से। इसका [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) संग्रह चार्ट‑स्वामित्व वाले शेप शामिल करता है।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा जाता है वह स्लाइड का हिस्सा होता है, भले ही वह चार्ट का हिस्सा जैसा दिखे। [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) के माध्यम से इटरेट करने पर चार्ट और सामान्य स्लाइड शेप मिलते हैं, लेकिन चार्ट के भीतर व्यक्तिगत शेप नहीं मिलेते। चार्ट शीर्षक और डेटा लेबल अलग‑अलग चार्ट तत्व होते हैं, न कि इस संग्रह में कस्टम एनोटेशन।

[chart-annotations.pptx](chart-annotations.pptx) को डाउनलोड करके एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड एनोटेशन “Preliminary results”, एक चार्ट‑स्वामित्व वाली लाइन, और “Slide overlay” लिखी सामान्य स्लाइड टेक्स्ट बॉक्स है। उदाहरण उस स्लाइड पर पहला चार्ट ढूँढ़ता है और रिपोर्ट प्रकाशित होने पर एनोटेशन को “Final results” में बदलता है। यह खाली संग्रह की जाँच करता है और केवल उन [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) को संपादित करता है जिनमें [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) `None` नहीं है और अपेक्षित टेक्स्ट मौजूद है।

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

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहते हैं। नीचे दिए गए चित्र इनपुट और सहेजे गए, फिर से खोले गए परिणाम को दर्शाते हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तरीय चार्ट‑स्वामित्व वाले शेप की जाँच करता है। यदि कोई एनोटेशन [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) के भीतर है, तो उस समूह की [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) संग्रह को भी जाँचें। नेस्टेड समूहों के लिए इसे पुनरावृत्त रूप से करें, और उनके चाइल्ड शेप पर समान टेक्स्ट जाँच लागू करें। एक समूह स्वयं एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्द्ध‑पारदर्शी फ़िल लागू कर सकता हूँ जबकि बॉर्डर अपारदर्शी रहे?**

हाँ। फ़िल ट्रांसपैरेंस और रूपरेखा को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता सुधारने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं क्या करूँ?**

फ़ॉन्ट आकार कम करें, गैर‑आवश्यक लेबल घटकों (जैसे कैटेगिरी) को अक्षम करें, लेबल की स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएं, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल लागू कर सकता हूँ?**

हाँ। सीरीज़ सॉलिड, ग्रेडिएंट और पैटर्न फ़िल को समर्थन देती है। व्यवहार में, ग्रेडिएंट का सीमित उपयोग करें और ऐसी संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट कम कर दें।