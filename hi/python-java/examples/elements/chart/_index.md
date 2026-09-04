---
title: चार्ट
type: docs
weight: 60
url: /hi/python-java/examples/elements/chart/
keywords:
- चार्ट
- चार्ट जोड़ें
- चार्ट पहुँचें
- चार्ट हटाएँ
- चार्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में चार्ट बनाएँ, पहुँचें, हटाएँ और अपडेट करें।"
---
यह लेख प्रस्तुति में चार्ट जोड़ने, एक्सेस करने, हटाने और अपडेट करने का प्रदर्शन करता है, **Aspose.Slides for Python via Java** का उपयोग करके।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण `asposeslides` को JVM शुरू करने से पहले इम्पोर्ट करता है, फिर JVM चलने के बाद API को इम्पोर्ट करता है। शेष उदाहरणों के लिए `chart.pptx` बनाने हेतु पहले addition उदाहरण चलाएँ।

## **चार्ट जोड़ें**

पहली स्लाइड में एक एरिया चार्ट जोड़ें और प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # पहली स्लाइड में एक एरिया चार्ट जोड़ें।
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट तक पहुंचें**

पहली स्लाइड पर शैप संग्रह में पहला चार्ट खोजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड पर पहला चार्ट एक्सेस करें।
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **चार्ट हटाएँ**

स्लाइड से पहला चार्ट हटाएँ और संशोधित प्रस्तुति को सहेजें।

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड पर पहला चार्ट खोजें और हटाएँ।
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चार्ट डेटा अपडेट करें**

चार्ट शीर्षक प्रदर्शित करें, उसका टेक्स्ट बदलें, और अपडेटेड प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड पर पहला चार्ट खोजें।
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # चार्ट शीर्षक प्रदर्शित करें और उसके पाठ को बदलें।
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```