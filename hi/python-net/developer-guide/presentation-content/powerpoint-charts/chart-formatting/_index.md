---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट स्वरूपित करना
linktitle: चार्ट स्वरूपण
type: docs
weight: 60
url: /hi/python-net/chart-formatting/
keywords:
- चार्ट स्वरूपित करना
- चार्ट स्वरूपण
- चार्ट इकाई
- चार्ट गुण
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट गुण
- गोल किनारा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: Aspose.Slides for Python में .NET के द्वारा चार्ट स्वरूपण सीखें और अपने PowerPoint या OpenDocument प्रस्तुति को पेशेवर, आकर्षक शैली के साथ उन्नत बनाएं।
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने के तरीके को समझाता है। यह अक्ष, ग्रिड लाइनों, शीर्षक, लेजेंड, प्लॉट क्षेत्र, और वॉल फ़िल्स जैसे प्रमुख चार्ट तत्वों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता को सुधारने के तरीकों को दर्शाता है।

यह 또한 चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण सेट करने, चार्ट डेटा पर प्रीसेट और कस्टम न्यूमेरिक फ़ॉर्मैट लागू करने, तथा चार्ट एरिया के लिए गोल कोनों को सक्षम करने के उदाहरण भी दिखाता है। ये सभी उदाहरण प्रस्तुतियों में चार्ट की दृश्य शैली और डेटा प्रस्तुति दोनों को नियंत्रित करने के उपाय प्रदान करते हैं।

## **चार्ट तत्वों का फ़ॉर्मेट**

Aspose.Slides for Python डेवलपर्स को शून्य से अपने स्लाइड में कस्टम चार्ट जोड़ने की अनुमति देता है। यह भाग विभिन्न चार्ट तत्वों, जिसमें श्रेणी और वैल्यू अक्ष शामिल हैं, को फ़ॉर्मेट करने का तरीका समझाता है।

Aspose.Slides चार्ट तत्वों को प्रबंधित करने और कस्टम फ़ॉर्मेटिंग लागू करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. इच्छित प्रकार (इस उदाहरण में `ChartType.LINE_WITH_MARKERS`) के साथ डिफ़ॉल्ट डेटा वाला एक चार्ट जोड़ें।
1. चार्ट के वैल्यू अक्ष तक पहुंचें और निम्न सेट करें:
   1. वैल्यू-एक्सिस मुख्य ग्रिडलाइन के लिए **लाइन फ़ॉर्मैट** सेट करें।
   1. वैल्यू-एक्सिस गौण ग्रिडलाइन के लिए **लाइन फ़ॉर्मैट** सेट करें।
   1. वैल्यू अक्ष के लिए **नंबर फ़ॉर्मैट** सेट करें।
   1. वैल्यू अक्ष के लिए **न्यूनतम, अधिकतम, मुख्य और गौण इकाइयाँ** सेट करें।
   1. वैल्यू-एक्सिस लेबल के लिए **टेक्स्ट गुण** सेट करें।
   1. वैल्यू अक्ष के लिए **शीर्षक** सेट करें।
   1. वैल्यू अक्ष के लिए **लाइन फ़ॉर्मैट** सेट करें।
1. चार्ट के श्रेणी अक्ष तक पहुंचें और निम्न सेट करें:
   1. श्रेणी-एक्सिस मुख्य ग्रिडलाइन के लिए **लाइन फ़ॉर्मैट** सेट करें।
   1. श्रेणी-एक्सिस गौण ग्रिडलाइन के लिए **लाइन फ़ॉर्मैट** सेट करें।
   1. श्रेणी-एक्सिस लेबल के लिए **टेक्स्ट गुण** सेट करें।
   1. श्रेणी अक्ष के लिए **शीर्षक** सेट करें।
   1. श्रेणी अक्ष के लिए **लेबल पोजिशनिंग** सेट करें।
   1. श्रेणी-एक्सिस लेबल के लिए **रोटेशन एंगल** सेट करें।
1. चार्ट लेजेंड तक पहुंचें और इसके **टेक्स्ट गुण** सेट करें।
1. चार्ट लेजेंड को इस प्रकार दिखाएँ कि वह चार्ट के ऊपर ओवरलैप न हो।
1. चार्ट के **सेकेंडरी वैल्यू अक्ष** तक पहुंचें और निम्न सेट करें:
   1. सेकेंडरी **वैल्यू अक्ष** को सक्षम करें।
   1. सेकेंडरी वैल्यू अक्ष के लिए **लाइन फ़ॉर्मैट** सेट करें।
   1. सेकेंडरी वैल्यू अक्ष के लिए **नंबर फ़ॉर्मैट** सेट करें।
   1. सेकेंडरी वैल्यू अक्ष के लिए **न्यूनतम, अधिकतम, मुख्य और गौण इकाइयाँ** सेट करें।
1. पहली चार्ट सीरीज़ को सेकेंडरी वैल्यू अक्ष पर प्लॉट करें।
1. चार्ट बैक‑वॉल फ़िल रंग सेट करें।
1. चार्ट प्लॉट‑एरिया फ़िल रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक उदाहरण बनाएं।
with slides.Presentation() as presentation:

    # पहले स्लाइड तक पहुँचें।
    slide = presentation.slides[0]

    # एक नमूना चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # चार्ट शीर्षक सेट करें।
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # वैल्यू अक्ष के लिए मुख्य ग्रिडलाइन फ़ॉर्मेट सेट करें।
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # वैल्यू अक्ष के लिए गौण ग्रिडलाइन फ़ॉर्मेट सेट करें।
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # वैल्यू अक्ष का नंबर फ़ॉर्मेट सेट करें।
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # वैल्यू-एक्सिस के अधिकतम, न्यूनतम, मुख्य इकाई, और गौण इकाई सेट करें।
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # वैल्यू-एक्सिस के टेक्स्ट गुण सेट करें।
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # वैल्यू अक्ष का शीर्षक सेट करें।
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # श्रेणी अक्ष के लिए मुख्य ग्रिडलाइन फ़ॉर्मेट सेट करें।
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # श्रेणी अक्ष के लिए गौण ग्रिडलाइन फ़ॉर्मेट सेट करें।
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # श्रेणी-एक्सिस के टेक्स्ट गुण सेट करें।
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # श्रेणी अक्ष का शीर्षक सेट करें।
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # श्रेणी-एक्सिस लेबल की स्थिति सेट करें।
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # श्रेणी-एक्सिस लेबल का घूर्णन कोण सेट करें।
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # लेजेंड के टेक्स्ट गुण सेट करें।
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # चार्ट लेजेंड को चार्ट के ऊपर ओवरलैप करके दिखाएं।
    chart.legend.overlay = True
                
    # चार्ट बैक वॉल का रंग सेट करें।
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # प्लॉट एरिया का रंग सेट करें।
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # प्रस्तुति सहेजें।
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट फ़ॉन्ट गुण सेट करना**

Aspose.Slides for Python चार्ट के फ़ॉन्ट‑संबंधित गुणों को सेट करने का समर्थन करता है। नीचे दिए गए चरणों का पालन करके चार्ट फ़ॉन्ट गुण कॉन्फ़िगर करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट बनाएँ।
1. स्लाइड में एक चार्ट जोड़ें।
1. फ़ॉन्ट की ऊँचाई सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना कोड प्रदान किया गया है।

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

## **न्यूमेरिक फ़ॉर्मैट सेट करना**

Aspose.Slides for Python चार्ट डेटा फ़ॉर्मैट को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
1. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. किसी भी इच्छित प्रकार के साथ डिफ़ॉल्ट डेटा वाला एक चार्ट जोड़ें।
1. उपलब्ध प्रीसेट मानों में से एक प्रीसेट नंबर फ़ॉर्मैट चुनें।
1. प्रत्येक सीरीज़ में चार्ट डेटा सेल्स को पार करते हुए नंबर फ़ॉर्मैट सेट करें।
1. प्रस्तुति को सहेजें।
1. एक कस्टम नंबर फ़ॉर्मैट सेट करें।
1. प्रत्येक सीरीज़ में चार्ट डेटा सेल्स को पार करते हुए अलग नंबर फ़ॉर्मैट सेट करें।
1. प्रस्तुति को सहेजें।

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # पहले स्लाइड तक पहुंचें।
    slide = presentation.slides[0]

    # एक डिफ़ॉल्ट क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # प्रीसेट नंबर फ़ॉर्मैट सेट करें।
    # प्रत्येक चार्ट सीरीज़ को पार करें।
    for series in chart.chart_data.series:
        # सीरीज़ में प्रत्येक डेटा पॉइंट को पार करें।
        for cell in series.data_points:
            # नंबर फ़ॉर्मैट सेट करें।
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # प्रस्तुति सहेजें।
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

नीचे उपलब्ध प्रीसेट नंबर फ़ॉर्मैट और उनके संबंधित इंडेक्स सूचीबद्ध हैं।

|**0**|सामान्य|
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

## **चार्ट एरिया के लिए गोल किनारे सेट करना**

Aspose.Slides for Python `Chart.has_rounded_corners` प्रॉपर्टी का उपयोग करके चार्ट एरिया को कॉन्फ़िगर करने का समर्थन करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट बनाएँ।
2. स्लाइड में एक चार्ट जोड़ें।
3. चार्ट का फ़िल टाइप और फ़िल रंग सेट करें।
4. गोल‑कोनों की प्रॉपर्टी को `True` सेट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे एक नमूना प्रदान किया गया है।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध-पारदर्शी फ़िल्स सेट कर सकता हूँ जबकि बॉर्डर अपारदर्शी रहे?**

हाँ। फ़िल ट्रांसपेरेंसी और आउटलाइन को अलग‑अलग कॉन्फ़िगर किया जाता है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता को बेहतर बनाने में उपयोगी है।

**जब डेटा लेबल ओवरलैप हो जाएँ तो मैं क्या करूँ?**

फ़ॉन्ट आकार घटाएँ, अनावश्यक लेबल घटकों (जैसे श्रेणियाँ) को अक्षम करें, लेबल ऑफ़सेट/पोजिशन सेट करें, आवश्यक होने पर केवल चयनित पॉइंट्स के लिए लेबल दिखाएँ, या फ़ॉर्मेट को “value + legend” में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल्स लागू कर सकता हूँ?**

हाँ। सॉलिड तथा ग्रेडिएंट/पैटर्न फ़िल्स दोनों आम तौर पर उपलब्ध होते हैं। व्यावहारिक रूप से, ग्रेडिएंट को सीमित मात्रा में उपयोग करें और ऐसे संयोजन से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को कम कर दें।