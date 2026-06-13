---
title: Python के साथ प्रस्तुतियों में चार्ट डेटा मार्कर प्रबंधित करें
linktitle: डेटा मार्कर
type: docs
url: /hi/python-net/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भरन प्रकार
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides में चार्ट डेटा मार्करों को अनुकूलित करना सीखें, स्पष्ट कोड उदाहरणों के साथ PPT, PPTX और ODP फ़ॉर्मैट में प्रस्तुति प्रभाव को बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्कर के साथ कैसे काम किया जाए, यह समझाता है। यह दिखाता है कि चार्ट कैसे बनाया जाए, किसी श्रृंखला और उसके डेटा पॉइंट्स तक कैसे पहुंचा जाए, डेटा‑पॉइंट स्तर पर मार्करों पर चित्र भराव कैसे लागू किया जाए, मार्कर का आकार कैसे समायोजित किया जाए, और अद्यतन प्रस्तुति को कैसे सहेजा जाए। यह यह भी बताता है कि मानक मार्कर आकार `MarkerStyleType` enumeration के माध्यम से उपलब्ध हैं और चार्ट को रास्टर फ़ॉर्मैट या SVG में निर्यात करने पर मार्कर का रूप बरकरार रहता है।

## **चार्ट मार्कर विकल्प सेट करें**
मार्करों को विशिष्ट श्रृंखला के अंदर चार्ट डेटा पॉइंट्स पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए कृपया नीचे दिए गए चरणों का पालन करें:

- एक नया [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- नया डेटा पॉइंट जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation क्लास का एक उदाहरण बनाएं
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # डिफ़ॉल्ट चार्ट बनाना
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करना
    defaultWorksheetIndex = 0

    # चार्ट डेटा वर्कशीट प्राप्त करना
    fact = chart.chart_data.chart_data_workbook

    # डेमो श्रृंखला हटाएँ
    chart.chart_data.series.clear()

    # नई श्रृंखला जोड़ें
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # चित्र सेट करें
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # चित्र सेट करें
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # पहली चार्ट श्रृंखला लें
    series = chart.chart_data.series[0]

    # वहाँ नया बिंदु (1:3) जोड़ें।
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # चार्ट श्रृंखला मार्कर बदलना
    series.marker.size = 15

    # प्रस्तुति को डिस्क पर लिखें
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**डिफ़ॉल्ट रूप से कौन से मार्कर आकार उपलब्ध हैं?**

मानक आकार उपलब्ध हैं (वृत्त, वर्ग, हीरा, त्रिकोण, आदि); यह सूची [MarkerStyleType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/markerstyletype/) enumeration द्वारा परिभाषित है। यदि आपको कोई गैर‑मानक आकार चाहिए, तो कस्टम विज़ुअल्स को अनुकरण करने के लिए चित्र भराव वाले मार्कर का उपयोग करें।

**क्या चार्ट को छवि या SVG में निर्यात करने पर मार्कर बरकरार रहते हैं?**

हां। जब चार्ट को [raster formats](/slides/hi/python-net/convert-powerpoint-to-png/) में रेंडर किया जाता है या [shapes as SVG](/slides/hi/python-net/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर अपना रूप और सेटिंग्स बरकरार रखते हैं, जिसमें आकार, भराव और रूपरेखा शामिल हैं।