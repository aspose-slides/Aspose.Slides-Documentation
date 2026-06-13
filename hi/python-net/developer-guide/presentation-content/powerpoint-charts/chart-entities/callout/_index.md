---
title: Python के साथ प्रस्तुति चार्ट में कॉलआउट प्रबंधित करें
linktitle: कॉलआउट
type: docs
url: /hi/python-net/callout/
keywords:
- चार्ट कॉलआउट
- कॉलआउट का उपयोग
- डेटा लेबल
- लेबल फ़ॉर्मेट
- Python
- Aspose.Slides
description: "Aspose.Slides for Python .NET में कॉलआउट बनाएं और स्वरूपित करें, संक्षिप्त कोड उदाहरणों के साथ, PPT, PPTX और ODP के साथ संगत, जिससे प्रस्तुति कार्यप्रवाह को स्वचालित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा लेबल के लिए कॉलआउट के साथ काम करने का तरीका समझाता है। यह दिखाता है कि `show_label_as_data_callout` प्रॉपर्टी का उपयोग करके लेबल को कॉलआउट के रूप में कैसे प्रदर्शित किया जाए, डोनट चार्ट के लिए कॉलआउट‑संबंधित लेबल सेटिंग्स को कैसे कॉन्फ़िगर किया जाए, और यह नोट करता है कि प्रस्तुति को PDF, HTML5, SVG और रास्टर इमेज फ़ॉर्मेट्स में निर्यात करने पर कॉलआउट और उनकी उपस्थिति संरक्षित रहती है।

## **कॉलआउट का उपयोग**
नई प्रॉपर्टी **show_label_as_data_callout** को **DataLabelFormat** क्लास में जोड़ा गया है, जो निर्धारित करता है कि निर्दिष्ट चार्ट का डेटा लेबल डेटा कॉलआउट के रूप में दिखाया जाएगा या डेटा लेबल के रूप में। नीचे दिए गए उदाहरण में, हमने कॉलआउट सेट किए हैं।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **डोनट चार्ट के लिए कॉलआउट सेट करें**
Aspose.Slides for Python via .NET डोनट चार्ट के लिए श्रृंखला डेटा लेबल कॉलआउट आकार सेट करने का समर्थन प्रदान करता है। नीचे एक नमूना उदाहरण दिया गया है।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**प्रस्तुति को PDF, HTML5, SVG, या इमेज़ में कन्वर्ट करने पर क्या कॉलआउट संरक्षित रहते हैं?**

हाँ। कॉलआउट चार्ट रेंडरिंग का हिस्सा हैं, इसलिए जब आप प्रस्तुति को [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/hi/python-net/export-to-html5/), [SVG](/slides/hi/python-net/render-a-slide-as-an-svg-image/), या [raster images](/slides/hi/python-net/convert-powerpoint-to-png/) में निर्यात करते हैं, तो वे स्लाइड के फॉर्मेटिंग के साथ संरक्षित रहते हैं।

**क्या कस्टम फ़ॉन्ट कॉलआउट्स में काम करते हैं, और क्या उनका रूप निर्यात पर संरक्षित रहता है?**

हाँ। Aspose.Slides प्रस्तुति में [embedding fonts](/slides/hi/python-net/embedded-font/) को समर्थन देता है और निर्यात जैसे कि [PDF](/slides/hi/python-net/convert-powerpoint-to-pdf/) के दौरान फ़ॉन्ट एम्बेडिंग को नियंत्रित करता है, जिससे कॉलआउट विभिन्न सिस्टमों पर समान दिखते हैं।