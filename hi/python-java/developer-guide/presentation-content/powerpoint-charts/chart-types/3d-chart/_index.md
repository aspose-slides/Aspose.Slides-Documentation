---
title: प्रस्तुतियों में Python का उपयोग करके 3D चार्ट को अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/python-java/3d-chart/
keywords:
- 3D चार्ट
- घूर्णन
- गहराई
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। Python उदाहरणों के साथ घूर्णन, ऊँचाई अनुपात, चार्ट गहराई और श्रृंखलाओं के बीच की दूरी को समायोजित करें।"
---
## **सारांश**

Aspose.Slides for Python via Java आपको 3D चार्ट के दृश्य को [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) मेथड के माध्यम से अनुकूलित करने देता है। यह लेख दिखाता है कि कैसे घूर्णन, ऊँचाई अनुपात, गहराई, लम्बकोण अक्ष, और श्रृंखला के बीच की दूरी को समायोजित किया जाए, और फिर प्रस्तुति को PPTX फ़ॉर्मेट में सहेजा जाए।

## **3D चार्ट का घूर्णन और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाता है और [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट श्रृंखला और श्रेणियों को दो श्रृंखलाओं से बदल देता है, जिनमें प्रत्येक में तीन मान होते हैं। वर्कशीट इंडेक्स `0` चार्ट की पहली डेटा वर्कशीट की पहचान करता है; पंक्ति `0` में श्रृंखला के नाम होते हैं, और कॉलम `0` में श्रेणी लेबल होते हैं।

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) और [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) मेथड क्रमशः चार्ट का घूर्णन 40 और 270 डिग्री पर सेट करते हैं। [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) इसकी गहराई को उसकी चौड़ाई का 150% सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) परिप्रेक्ष्य के बजाय लम्बकोण अक्ष सक्षम करता है। परिणामी प्रस्तुति में इन 3D दृश्य सेटिंग्स के साथ भरपूर चार्ट सम्मिलित होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **3D चार्ट की ऊँचाई अनुपात को समायोजित करें**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) का उपयोग करके 3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करें। यह स्लाइड पर चार्ट ऑब्जेक्ट को पुनः आकार दिए बिना 3D दृश्य के अनुपात को बदलता है।

निचला उदाहरण डिफ़ॉल्ट डेटा के साथ एक [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) चार्ट बनाता है: तीन श्रृंखलाएँ और चार श्रेणियाँ। यह 50 %, 100 % और 200 % ऊँचाई अनुपात के साथ तीन प्रस्तुतियों को सहेजता है। चार्ट का स्थान, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घूर्णन, गहराई, श्रृंखला की दूरी और स्वरूपण सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्न छवियाँ समान ऊँचाई सेटिंग को समान .NET उदाहरण में दर्शाती हैं और Microsoft PowerPoint का उपयोग करके निर्यात की गई हैं। छोटी प्रतिशत flatter दृश्य बनाती है, जबकि बड़ी प्रतिशत समान चार्ट ऑब्जेक्ट के भीतर ऊँचा दृश्य बनाती है। PowerPoint दृश्य में फिट होने के लिए अक्ष टिक अंतराल और लेबल स्थान को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 50 % पर सेट है](height_percent_50.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 100 % पर सेट है](height_percent_100.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 200 % पर सेट है](height_percent_200.png) |

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D दृश्य की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करता है। |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D दृश्य की गहराई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करता है। |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | मार्कर की चौड़ाई के प्रतिशत के रूप में गहराई अक्ष पर श्रृंखलाओं के बीच की दूरी। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट, जिसमें सिलिंडर, शंकु और पिरामिड वेरिएंट शामिल हैं, साथ ही 3D लाइन, एरिया, पाई और सतह चार्ट को प्रभावित करती है। ऊपर का तुलना सत्यापित `Column3D` प्रकार का उपयोग करता है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट के स्वरूप को नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास के सदस्य हैं। अन्य चार्ट स्वरूप सेटिंग्स के लिए देखें [चार्ट फ़ॉर्मेटिंग](/slides/hi/python-java/chart-formatting/)।

## **श्रृंखलाओं के बीच की दूरी समायोजित करें**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) का उपयोग करके 3D चार्ट के गहराई अक्ष पर डेटा श्रृंखलाओं के बीच की दूरी को मार्कर की चौड़ाई के प्रतिशत के रूप में नियंत्रित करें। **0 से 500** तक के मान उपयोग करें: `0` दूरी हटाता है, जबकि बड़े मान दूरी बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, दूरी बढ़ाने से मार्कर गहराई अक्ष पर पतले हो जाते हैं।

समूह तक पहुँचने के लिए [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) का उपयोग करें। यह सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है, न कि केवल उस श्रृंखला पर जिससे इसे पहुँचा गया हो। [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) गहराई की दूरी लौटाता है और मूल समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट, उनके सिलिंडर, शंकु और पिरामिड वेरिएंट, साथ ही 3D लाइन और एरिया चार्ट को प्रभावित करती है। स्वरूप श्रृंखलाओं के गहराई में व्यवस्थित, क्लस्टर्ड या स्टैक्ड होने पर निर्भर करता है। अलग‑अलग श्रृंखलाओं के बीच दूरी की स्पष्ट तुलना के लिए [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास से `ChartType.Column3D` का उपयोग करें।

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | गहराई अक्ष पर श्रृंखलाओं के बीच की दूरी, मार्कर की चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | सन्निहित बार या कॉलम क्लस्टर के बीच की दूरी, बार या कॉलम की चौड़ाई के प्रतिशत के रूप में। |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | चार्ट की कुल गहराई, चार्ट की चौड़ाई के प्रतिशत के रूप में। |

निम्न स्वयंसम्पूर्ण उदाहरण डिफ़ॉल्ट चार्ट डेटा (तीन श्रृंखलाएँ और चार श्रेणियाँ) का उपयोग करता है। यह दो प्रस्तुतियों को सहेजता है जहाँ डेटा, घूर्णन, दूरी चौड़ाई और चार्ट गहराई समान होते हैं; केवल दूरी की गहराई बदलती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्न छवियाँ समान गहराई दूरी सेटिंग को समान .NET उदाहरण में दर्शाती हैं और Microsoft PowerPoint का उपयोग करके निर्यात की गई हैं।

| गहराई दूरी: 0% | गहराई दूरी: 500% |
| --- | --- |
| ![गहराई अक्ष पर श्रृंखलाओं के बीच कोई दूरी नहीं होने वाला 3D कॉलम चार्ट](gap_depth_0.png) | ![गहराई अक्ष पर श्रृंखलाओं के बीच 500 % दूरी वाला 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

एक क्लस्टर्ड सिलिंडर चार्ट में, पहली श्रृंखला का बार आकार सिलिंडर से शुरू होता है। यह उदाहरण [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) और [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) द्वारा लौटाए गए पूर्णांक मानों को प्रत्येक परिवर्तन से पहले और बाद में प्रिंट करता है। तालिका संबंधित स्थिर नाम देती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| पहली श्रृंखला में परिवर्तन | श्रृंखला प्रकार | बार आकार |
| --- | --- | --- |
| चार्ट बनाएं | `ClusteredCylinder` | `Cylinder` |
| श्रृंखला प्रकार को `ClusteredCone` में सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` में सेट करें | `ClusteredColumn3D` | `Box` |

बार आकार को `Box` में सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` में बदल जाता है। यदि आपका कोड श्रृंखला प्रकार पर शाखा बनाता है, तो आकार बदलने के बाद `series.getType()` कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा का चयन करेगा।

![बाएँ से दाएँ क्रम में सिलिंडर, शंकु और आयताकार कॉलम को दर्शाता PowerPoint तुलना छवि](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन‑से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट—Column 3D, Clustered Column 3D, Stacked Column 3D, और 100 % Stacked Column 3D—के साथ-साथ संबंधित 3D प्रकारों को [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास के माध्यम से सपोर्ट करता है। सटीक और अद्यतन सूची के लिए, अपने इंस्टॉल किए संस्करण की API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) के सदस्य देखें।

**क्या मैं किसी रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हां। आप [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) या पूरे स्लाइड को [render the entire slide](/slides/hi/python-java/convert-powerpoint-to-png/) करके PNG या JPEG जैसे फ़ॉर्मेट में निर्यात कर सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर पूर्वावलोकन चाहिए या चार्ट को दस्तावेज़, डैशबोर्ड या वेब पेज में एम्बेड करना है बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट को बनाना और रेंडर करना कितना प्रदर्शन‑सक्षम है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणाम के लिए 3D इफ़ेक्ट को न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा बिंदुओं की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार उचित रिज़ॉल्यूशन और आयामों के साथ आउटपुट रेंडर करें।