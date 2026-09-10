---
title: पाइथन का उपयोग कर प्रस्तुतियों में 3D चार्ट को कस्टमाइज़ करें
linktitle: 3D चार्ट
type: docs
url: /hi/python-java/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में 3-D चार्ट बनाना और कस्टमाइज़ करना सीखें, PPT और PPTX फ़ाइलों के समर्थन के साथ—आज ही अपनी प्रस्तुतियों को बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में 3D चार्ट को कस्टमाइज़ करने के लिए [Rotation3D](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotation3d/) सेटिंग्स जैसे [setRotationX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotation3d/#setDepthPercents), और [setRightAngleAxes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotation3d/#setRightAngleAxes) को कॉन्फ़िगर करने के बारे में समझाता है। यह एक प्रेज़ेंटेशन बनाना, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ना, आवश्यक 3D व्यू सेटिंग्स लागू करना, और संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजना दिखाता है।

## **3D चार्ट का X रोटेशन, Y रोटेशन, और डेप्थ सेट करें**
Aspose.Slides for Python via Java इन प्रॉपर्टीज़ को सेट करने के लिए एक सरल API प्रदान करता है। निम्न उदाहरण दिखाता है कि 3D चार्ट का X रोटेशन, Y रोटेशन, और डेप्थ कैसे सेट किया जाए।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएँ।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
4. 3D रोटेशन प्रॉपर्टीज़ सेट करें।
5. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # चार्ट डेटा वर्कशीट इंडेक्स सेट करें।
    default_worksheet_index = 0

    # चार्ट डेटा वर्कबुक प्राप्त करें।
    workbook = chart.getChartData().getChartDataWorkbook()

    # सीरीज जोड़ें।
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # श्रेणियाँ जोड़ें।
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # 3D रोटेशन प्रॉपर्टीज़ सेट करें।
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # दूसरी चार्ट सीरीज तक पहुँचें।
    series = chart.getChartData().getSeries().get_Item(1)

    # सीरीज डेटा भरें।
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # प्रेज़ेंटेशन सहेजें।
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट, जैसे Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D, तथा संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) क्लास के माध्यम से उपलब्ध हैं, का समर्थन करता है। सटीक और अद्यतन सूची के लिए अपने इंस्टॉल किए गए संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/charttype/) सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हाँ। आप चार्ट को इमेज में निर्यात करने के लिए [chart API](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) या पूरी स्लाइड को [render the entire slide](/slides/hi/python-java/convert-powerpoint-to-png/) करके PNG या JPEG जैसे फॉर्मेट में बदल सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल‑परफेक्ट प्रीव्यू चाहिए या चार्ट को दस्तावेज़, डैशबोर्ड, या वेब पेज में एम्बेड करना हो बिना PowerPoint की आवश्यकता के।

**बड़ी 3D चार्ट्स को निर्माण और रेंडर करने में प्रदर्शन कैसा होता है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए 3D प्रभावों को न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रति सीरीज़ डेटा पॉइंट्स की संख्या सीमित रखें, और आउटपुट (रेज़ोल्यूशन और डाइमेंशन) को लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार आकार दें।