---
title: प्रस्तुतियों में चार्ट डेटा मार्कर प्रबंधन Python का उपयोग करके
linktitle: डेटा मार्कर
type: docs
url: /hi/python-java/chart-data-marker/
keywords:
- चार्ट
- डेटा बिंदु
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भरण प्रकार
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Python में Java के माध्यम से चार्ट डेटा मार्करों को अनुकूलित करना सीखें, जिससे PPT और PPTX फ़ॉर्मेट में स्पष्ट Python कोड उदाहरणों के साथ प्रेजेंटेशन प्रभाव बढ़ता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्करों के साथ काम करने का तरीका समझाता है। यह दर्शाता है कि चार्ट कैसे बनाएं, एक श्रृंखला और उसके डेटा बिंदुओं तक कैसे पहुँचें, डेटा‑बिंदु स्तर पर मार्करों पर चित्र भराव लागू करें, मार्कर का आकार समायोजित करें, और अपडेटेड प्रेजेंटेशन सहेजें। यह यह भी नोट करता है कि मानक मार्कर आकार [MarkerStyleType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markerstyletype/) enumeration के माध्यम से उपलब्ध हैं और जब चार्ट को रास्टर फ़ॉर्मेट या SVG में निर्यात किया जाता है तो मार्कर की उपस्थिति बरकरार रहती है।

## **चार्ट मार्कर विकल्प सेट करें**
मार्करों को किसी विशिष्ट श्रृंखला के भीतर चार्ट डेटा बिंदुओं पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए, निम्न चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
- डिफ़ॉल्ट चार्ट बनाएं।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला तक पहुँचें।
- नए डेटा बिंदु जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

निम्न उदाहरण डेटा‑बिंदु स्तर पर चार्ट मार्कर विकल्प सेट करता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# एक खाली प्रस्तुति बनाएं।
presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचें
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट चार्ट बनाना
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करें।
    default_worksheet_index = 0

    # चार्ट डेटा वर्कबुक प्राप्त करें।
    workbook = chart.getChartData().getChartDataWorkbook()

    # डेमो श्रृंखला हटाएँ
    chart.getChartData().getSeries().clear()

    # नई श्रृंखला जोड़ें
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # पहली तस्वीर लोड करें।
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # दूसरी तस्वीर लोड करें।
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # पहली चार्ट श्रृंखला तक पहुँचें।
    series = chart.getChartData().getSeries().get_Item(0)

    # डेटा बिंदु जोड़ें।
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # चार्ट श्रृंखला मार्कर आकार बदलें।
    series.getMarker().setSize(15)

    # चार्ट के साथ प्रस्तुति सहेजें
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**डिफ़ॉल्ट रूप से कौन से मार्कर आकार उपलब्ध हैं?**

मानक आकार उपलब्ध हैं (वृत्त, वर्ग, हीरा, त्रिकोण, आदि); सूची को [MarkerStyleType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/markerstyletype/) क्लास द्वारा परिभाषित किया गया है। यदि आपको कोई गैर‑मानक आकार चाहिए, तो कस्टम दृश्य को अनुकूलित करने के लिए चित्र भराव वाले मार्कर का उपयोग करें।

**क्या चार्ट को छवि या SVG में निर्यात करने पर मार्कर संरक्षित रहते हैं?**

हाँ। जब चार्ट को [रास्टर फ़ॉर्मेट](/slides/hi/python-java/convert-powerpoint-to-png/) में रेंडर किया जाता है या [SVG के रूप में आकार](/slides/hi/python-java/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्करों का रूप और सेटिंग्स, जिसमें आकार, भराव और रूपरेखा शामिल हैं, बरकरार रहता है।