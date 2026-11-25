---
title: Python का उपयोग करके प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
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
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। Python उदाहरणों के साथ घूर्णन, ऊँचाई अनुपात, चार्ट गहराई, और श्रृंखलाओं के बीच की दूरी समायोजित करें।"
---
## **परिचय**

Aspose.Slides for Python via Java आपको 3D चार्ट के दृश्य को [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) मेथड के माध्यम से अनुकूलित करने देता है। यह लेख घूर्णन, ऊँचाई अनुपात, गहराई, समकोण अक्ष, और श्रृंखलाओं के बीच की दूरी को समायोजित करने, तथा प्रस्तुति को PPTX फ़ॉर्मेट में सहेजने का प्रदर्शन करता है।

## **3D चार्ट का घूर्णन और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाता है और [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके उसकी पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट श्रृंखला और श्रेणियों को दो श्रृंखलाओं से बदल देता है, जिनमें प्रत्येक में तीन मान होते हैं। कार्यपत्रक सूचकांक `0` चार्ट की पहली डेटा कार्यपत्रक को पहचानता है; पंक्ति `0` में श्रृंखला नाम होते हैं, और कॉलम `0` में श्रेणी लेबल होते हैं।

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) और [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) मेथड क्रमशः चार्ट का घूर्णन 40 और 270 डिग्री पर सेट करते हैं। [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) इसकी गहराई को इसकी चौड़ाई के 150 % पर सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) परिप्रेक्ष्य के बजाय समकोण अक्ष सक्षम करता है। परिणामी प्रस्तुति इन 3D दृश्य सेटिंग्स के साथ निर्मित चार्ट को सम्मिलित करती है।

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

## **3D चार्ट सतह पर चित्र भरण लागू करें**

एक 3D चार्ट में तीन सतहें होती हैं जिन्हें आप स्वतंत्र रूप से भर सकते हैं: [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall), और [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor)। सतह के [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) को `Picture` पर सेट करें और एक छवि असाइन करें। सतह के [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) और [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) दोनों को `Stretch` पर सेट करें ताकि छवि की एक प्रति पूरी सतह को भर दे।

[arrow.png](arrow.png) को कार्य निर्देशिका में सहेजें। उदाहरण चार्ट को घुमाता है और लंबवत अक्ष पर अधिकतम मान बढ़ाता है ताकि फ़्लोर कॉलम के बीच दिखाई दे। फिर यह स्लाइड को दो बार क्लोन करता है और प्रत्येक स्लाइड पर अलग सतह पर तीर लागू करता है। सभी तीन चार्ट समान डेटा, दृश्य कोण, और पृष्ठभूमि रखते हैं।

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint तीन स्लाइडों को इस प्रकार दिखाता है।

| साइड वॉल | बैक वॉल | फ़्लोर |
| --- | --- | --- |
| ![चार्ट में साइड वॉल के साथ इशारा करने वाला तीर](side-wall.png) | ![बैक वॉल के पार दाहिनी ओर इशारा करने वाला तीर](back-wall.png) | ![कॉलम के बीच फ़्लोर पर दाहिनी ओर इशारा करने वाला तीर](floor.png) |

## **3D चार्ट की ऊँचाई अनुपात समायोजित करें**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) का उपयोग करके 3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करें। यह स्लाइड पर चार्ट ऑब्जेक्ट के आकार को बदले बिना 3D दृश्य के अनुपात को बदलता है।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ एक [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) चार्ट बनाता है: तीन श्रृंखलाएँ और चार श्रेणियाँ। यह 50 %, 100 %, और 200 % ऊँचाई अनुपात के साथ तीन प्रस्तुतियों को सहेजता है। चार्ट की स्थिति, चौड़ाई, और ऊँचाई स्थिर रहती है। डेटा, घूर्णन, गहराई, श्रृंखला अंतराल, और फ़ॉर्मेटिंग सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

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

निम्न छवियाँ समान ऊँचाई सेटिंग को .NET समतुल्य उदाहरण में दर्शाती हैं और Microsoft PowerPoint का उपयोग करके निर्यात की गई हैं। छोटा प्रतिशत flatter दृश्य उत्पन्न करता है, जबकि बड़ा प्रतिशत उसी चार्ट ऑब्जेक्ट के भीतर ऊँचा दृश्य बनाता है। दृश्य को फिट करने के लिए PowerPoint अक्ष टिक अंतराल और लेबल प्लेसमेंट को भी समायोजित कर सकता है।

| ऊँचाई: 50 % | ऊँचाई: 100 % | ऊँचाई: 200 % |
| --- | --- | --- |
| ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 50 % पर सेट है](height_percent_50.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 100 % पर सेट है](height_percent_100.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 200 % पर सेट है](height_percent_200.png) |

ये विधियाँ चार्ट के विभिन्न पहलुओं को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D दृश्य की ऊँचाई, उसकी चौड़ाई के प्रतिशत में। |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D दृश्य की गहराई, उसकी चौड़ाई के प्रतिशत में। |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत में। |

यह सेटिंग 3D कॉलम और बार चार्ट, जिसमें सिलिंडर, शंकु और पिरामिड वैरिएंट शामिल हैं, साथ ही 3D लाइन, एरिया, पाई, और सतह चार्ट को प्रभावित करती है। ऊपर का तुलना प्रमाणित `Column3D` प्रकार का उपयोग करती है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति को नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास के सदस्य हैं। अन्य चार्ट फ़ॉर्मेट सेटिंग्स के लिए देखें [Chart Formatting](/slides/hi/python-java/chart-formatting/)।

## **श्रृंखलाओं के बीच अंतराल समायोजित करें**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) का उपयोग करके 3D चार्ट के गहराई अक्ष पर डेटा श्रृंखलाओं के बीच की दूरी को मार्कर चौड़ाई के प्रतिशत के रूप में नियंत्रित करें। **0 से 500** तक के मान उपयोग करें: `0` अंतराल को हटाता है, जबकि बड़े मान अंतराल बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, अंतराल बढ़ाने से मार्कर गहराई अक्ष पर पतले हो जाते हैं।

समूह तक पहुँचने के लिए [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) का उपयोग करें। यह सेटिंग समूह की प्रत्येक श्रृंखला पर लागू होती है, न कि केवल उस श्रृंखला पर जिससे इसे पहुँचा गया। [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) गहराई अंतराल लौटाता है और मूल समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट, जिसमें उनके सिलिंडर, शंकु और पिरामिड वैरिएंट शामिल हैं, साथ ही 3D लाइन और एरिया चार्ट को प्रभावित करती है। उपस्थिति इस पर निर्भर करती है कि श्रृंखलाएँ गहराई में व्यवस्थित हैं, क्लस्टर्ड हैं, या स्टैक्ड हैं। अलग-अलग श्रृंखलाओं के बीच अंतराल की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास से `ChartType.Column3D` का उपयोग करें।

ये विधियाँ चार्ट के विभिन्न पहलुओं को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत में। |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | सटे हुए बार या कॉलम क्लस्टर्स के बीच की दूरी, बार या कॉलम चौड़ाई के प्रतिशत में। |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | कुल चार्ट गहराई, चार्ट चौड़ाई के प्रतिशत में। |

निम्न स्वावलंबी उदाहरण डिफ़ॉल्ट चार्ट डेटा (तीन श्रृंखलाएँ और चार श्रेणियाँ) का उपयोग करता है। यह दो प्रस्तुतियों को समान डेटा, घूर्णन, अंतराल चौड़ाई, और चार्ट गहराई के साथ सहेजता है; केवल अंतराल गहराई बदलती है।

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

निम्न छवियाँ समान अंतराल गहराई सेटिंग को .NET समतुल्य उदाहरण में दर्शाती हैं और Microsoft PowerPoint का उपयोग करके निर्यात की गई हैं।

| अंतराल गहराई: 0 % | अंतराल गहराई: 500 % |
| --- | --- |
| ![गहराई अक्ष पर श्रृंखलाओं के बीच कोई अंतराल नहीं वाला 3D कॉलम चार्ट](gap_depth_0.png) | ![गहराई अक्ष पर श्रृंखलाओं के बीच 500 % अंतराल वाला 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

क्लस्टर्ड सिलिंडर चार्ट में पहली श्रृंखला शुरू में सिलिंडर बार आकार से शुरू होती है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) और [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) द्वारा लौटाए गए पूर्णांक मानों को प्रिंट करता है। तालिका संबंधित स्थिरांक नाम देती है।

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
| श्रृंखला प्रकार को `ClusteredCone` पर सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` पर सेट करें | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` में बदल जाता है। यदि आपका कोड श्रृंखला प्रकार के आधार पर शाखा बनाता है, तो आकार बदलने के बाद `series.getType()` कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा को चुन लेगा।

![बाएँ से दाएँ पहले श्रृंखला को सिलिंडर, कोन, और आयताकार कॉलम के रूप में दिखाने वाला PowerPoint तुलना छवि](series-shapes.png)

## **FAQ**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D रूपों का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100 % Stacked Column 3D शामिल हैं, साथ ही [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) क्लास के माध्यम से एक्सपोज़ किए गए संबंधित 3D प्रकार। सटीक, अद्यतित सूची के लिए अपने स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) के सदस्य देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हाँ। आप [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) का उपयोग करके चार्ट को छवि में निर्यात कर सकते हैं या [render the entire slide](/slides/hi/python-java/convert-powerpoint-to-png/) को PNG या JPEG जैसी फ़ॉर्मेट में निर्यात कर सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर प्रीव्यू चाहिए या PowerPoint की आवश्यकता के बिना दस्तावेज़, डैशबोर्ड, या वेब पेज में चार्ट एम्बेड करना हो।

**बड़े 3D चार्ट बनाने और रेंडर करने में प्रदर्शन कैसा है?**

प्रदर्शन डेटा मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणाम के लिए 3D प्रभाव को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा बिंदुओं की संख्या सीमित रखें, और आउटपुट (रेज़ोल्यूशन और आकार) को लक्षित डिस्प्ले या प्रिंट आवश्यकता के अनुसार उपयुक्त आकार में रेंडर करें।