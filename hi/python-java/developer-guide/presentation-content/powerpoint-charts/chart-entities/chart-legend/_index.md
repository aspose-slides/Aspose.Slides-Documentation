---
title: Python का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करें
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
description: "PowerPoint प्रस्तुतियों को अनुकूलित करने के लिए Aspose.Slides for Python via Java के साथ चार्ट लेजेंड को अनुकूलित करें, जिससे लेजेंड फॉर्मेटिंग को विशेष रूप से तैयार किया जा सके।"
---
## **अवलोकन**

Aspose.Slides for Python via Java PowerPoint प्रस्तुतियों में चार्ट लीजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दिखाता है कि लीजेंड को कैसे स्थित और आकार दिया जाए, पूरे लीजेंड के फ़ॉन्ट आकार को सेट किया जाए, एक व्यक्तिगत लीजेंड प्रविष्टि को फॉर्मेट किया जाए, और चयनित प्रविष्टियों को छुपाया या पुनर्स्थापित किया जाए।

FAQ संबंधित व्यवहारों को कवर करता है, जिसमें लीजेंड के लिए स्थान आरक्षित करना, बहु-लाइन लेबल प्रदर्शित करना, और प्रस्तुति थीम से फॉर्मेटिंग विरासत में लेना शामिल है।

## **लीजेंड की स्थिति निर्धारण**

लीजेंड की [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), और [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) विधियों का उपयोग करके उसकी स्थिति और आकार को चार्ट के आयामों के अंश के रूप में निर्दिष्ट करें।

यह उदाहरण एक प्रस्तुति बनाता है और पहले स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। इच्छित लीजेंड ऑफ़सेट और आयामों को चार्ट की चौड़ाई और ऊँचाई से विभाजित करने से वे सापेक्ष मानों में परिवर्तित हो जाते हैं: लीजेंड चार्ट के शीर्ष-बाएँ कोने से 50 पॉइंट्स की दूरी पर स्थित है और इसका आकार 100 बाय 100 पॉइंट्स है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # चार्ट के सापेक्ष लेजेंड की स्थिति और आकार व्यक्त करें।
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **लीजेंड का फ़ॉन्ट आकार सेट करें**

लीजेंड के [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) का उपयोग करके उसके टेक्स्ट फॉर्मेटिंग तक पहुँचें और [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) को फ़ॉन्ट आकार को पॉइंट्स में सेट करने के लिए उपयोग करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है और लीजेंड टेक्स्ट को 20 पॉइंट्स पर सेट करता है। यह वर्टिकल अक्ष के लिए स्वचालित बाउंड्स को भी निष्क्रिय करता है और उसकी रेंज को -5 से 10 तक सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **व्यक्तिगत लीजेंड प्रविष्टि का फ़ॉन्ट आकार सेट करें**

लीजेंड के [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) मेथड द्वारा लौटाए गए संग्रह का उपयोग करके किसी विशेष प्रविष्टि के फ़ॉर्मेटिंग तक पहुँचें। प्रविष्टि सूचकांक शून्य-आधारित होते हैं, इसलिए सूचकांक `1` दूसरा प्रविष्टि दर्शाता है।

यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है जिसका डिफ़ॉल्ट डेटा कम से कम दो सीरीज़ शामिल करता है। यह दूसरे लीजेंड प्रविष्टि को बोल्ड, इटैलिक और 20 पॉइंट ब्लू टेक्स्ट के साथ फ़ॉर्मेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **व्यक्तिगत लीजेंड प्रविष्टियों को छुपाएँ**

एक सहायक सीरीज़ को लीजेंड से बाहर करने के लिए जबकि उसका डेटा दृश्य रहना चाहिए, [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) को `True` के साथ कॉल करें, इसे [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) के माध्यम से प्राप्त किया जाता है। यह केवल चयनित लीजेंड प्रविष्टि को छुपाता है; यह सीरीज़ या उसके डेटा पॉइंट्स को नहीं हटाता। इसके विपरीत, [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) को `False` के साथ कॉल करने से पूरा लीजेंड छुप जाता है।

निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ कई सीरीज़ वाले एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी सीरीज़ की लीजेंड प्रविष्टि (सूचकांक `1`) को छुपाता है और प्रस्तुति को सहेजता है। बाद में यह प्रविष्टि को [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) को `False` के साथ कॉल करके पुनर्स्थापित करता है और दूसरी प्रति सहेजता है। दोनों फाइलों में कॉलम दृश्य रहते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # चर्ट डेटा को बदले बिना वही प्रविष्टि पुनर्स्थापित करें।
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

नीचे दिया गया तुलना समान चार्ट को दिखाती है जिसमें सभी प्रविष्टियाँ दृश्यमान हैं और दूसरी प्रविष्टि छुपी हुई है। दूसरी सीरीज़ के कॉलम अपरिवर्तित रहते हैं।

![सभी लीजेंड प्रविष्टियों के दृश्यमान और सीरीज़ 2 को लीजेंड से छुपाए गए चार्ट की तुलना; सभी कॉलम दृश्यमान रहते हैं।](hide-legend-entry.png)

कॉलम, बार और लाइन चार्ट में, लीजेंड प्रविष्टियाँ सीरीज़ को पहचानती हैं। पाई चार्ट में, वे व्यक्तिगत डेटा पॉइंट्स (स्लाइस) को पहचानती हैं, इसलिए चयनित स्लाइस पर [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) का उपयोग करें। API इस डेटा-पॉइंट मेथड को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ित करता है। यह मानें नहीं कि यह डोनट चार्ट पर लागू होता है, जो इस सूची में शामिल नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट को लीजेंड के लिए स्थान आरक्षित करने के लिए बना सकता हूँ बजाय उसे ओवरले करने के?**  
हां। [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) को `False` के साथ कॉल करके लीजेंड के लिए स्थान आरक्षित करें, बजाय उसे प्लॉट एरिया के ऊपर ओवरले करने के।

**क्या मैं बहु-लाइन लीजेंड लेबल बना सकता हूँ?**  
हां। जब उपलब्ध चौड़ाई अपर्याप्त हो तो लंबे लेबल रैप हो सकते हैं। आप सीरीज़ नामों में newline कैरेक्टर का उपयोग करके लाइन ब्रेक भी जोड़ सकते हैं।

**मैं लीजेंड को प्रस्तुति थीम की रंग योजना के अनुसार कैसे बनाऊँ?**  
लीजेंड के रंग, भराव और फ़ॉन्ट को अनसेट रखें ताकि वह थीम फॉर्मेटिंग को विरासत में ले सके। स्पष्ट फॉर्मेटिंग संबंधित थीम सेटिंग्स को ओवरराइड करती है।