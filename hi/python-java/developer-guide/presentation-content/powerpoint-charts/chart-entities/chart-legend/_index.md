---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/python-java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के लिए Aspose.Slides via Java के साथ चार्ट लेजेंड को कस्टमाइज़ करें ताकि PowerPoint प्रस्तुतियों को अनुकूलित लेजेंड फ़ॉर्मेटिंग के साथ ऑप्टिमाइज़ किया जा सके।"
---
## **अवलोकन**

Aspose.Slides PowerPoint प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दिखाता है कि लेजेंड की स्थिति और आकार कैसे निर्धारित करें, पूरे लेजेंड के लिए फ़ॉन्ट आकार कैसे सेट करें, और व्यक्तिगत लेजेंड प्रविष्टि पर स्वरूपण कैसे लागू करें।

यह FAQ में कई संबंधित व्यवहारों को भी कवर करता है, जिसमें नॉन-ओवरले मोड का उपयोग करके प्लॉट क्षेत्र को लेजेंड के लिए स्थान देने, लंबे लेजेंड लेबल को रैप या लाइन ब्रेक्स का उपयोग करने, और जब स्पष्ट टेक्स्ट और फ़िल सेटिंग्स लागू नहीं की गई हों तो लेजेंड फ़ॉर्मेटिंग को प्रस्तुति थीम से विरासत में प्राप्त करने शामिल है।

## **लेजेंड स्थिति**

लेजेंड गुण सेट करने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक चार्ट जोड़ें।
4. लेजेंड गुण सेट करें।
5. प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

निम्न उदाहरण चार्ट लेजेंड की स्थिति और आकार सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# एक खाली प्रस्तुति बनाएं।
presentation = Presentation()
try:
    # स्लाइड का संदर्भ प्राप्त करें।
    slide = presentation.getSlides().get_Item(0)

    # स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # लेजेंड गुण सेट करें।
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लेजेंड का फ़ॉन्ट आकार सेट करें**

Aspose.Slides for Python via Java आपको लेजेंड का फ़ॉन्ट आकार सेट करने की अनुमति देता है। निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. डिफ़ॉल्ट चार्ट बनाएं।
3. फ़ॉन्ट आकार सेट करें।
4. न्यूनतम अक्ष मान सेट करें।
5. अधिकतम अक्ष मान सेट करें।
6. प्रस्तुति को डिस्क पर सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# एक खाली प्रस्तुति बनाएं।
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **व्यक्तिगत लेजेंड प्रविष्टि का फ़ॉन्ट आकार सेट करें**

Aspose.Slides for Python via Java आपको व्यक्तिगत लेजेंड प्रविष्टियों का फ़ॉन्ट आकार सेट करने की अनुमति देता है। निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. डिफ़ॉल्ट चार्ट बनाएं।
3. एक लेजेंड प्रविष्टि तक पहुँचें।
4. फ़ॉन्ट आकार सेट करें।
5. प्रस्तुति को डिस्क पर सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# एक खाली प्रस्तुति बनाएं।
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

हाँ। लेजेंड को गैर-ओवरले मोड में सक्षम करने के लिए `False` के साथ [setOverlay](https://reference.aspose.com/slides/hi/python-java/aspose.slides/legend/#setOverlay) का उपयोग करें; इस स्थिति में, प्लॉट एरिया लेजेंड को समायोजित करने के लिए छोटा हो जाएगा।

**Can I make multi-line legend labels?**

हाँ। जब स्थान अपर्याप्त हो तो लंबे लेबल स्वतः रैप हो जाते हैं; श्रृंखला नाम में नई पंक्ति वर्णों के द्वारा मैन्युअल लाइन ब्रेक समर्थित हैं।

**How do I make the legend follow the presentation theme’s color scheme?**

स्पष्ट रंग, भराव, या फ़ॉन्ट सेट न करें। तब वे थीम से विरासत में मिलेंगे और डिज़ाइन बदलने पर सही ढंग से अपडेट होंगे।