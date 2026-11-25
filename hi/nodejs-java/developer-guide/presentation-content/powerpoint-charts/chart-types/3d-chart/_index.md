---
title: JavaScript का उपयोग करके प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/nodejs-java/3d-chart/
keywords:
- 3D चार्ट
- घूर्णन
- गहराई
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। JavaScript उदाहरणों के साथ घूर्णन, ऊँचाई अनुपात, चार्ट गहराई, और सीरीज़ के बीच की दूरी को समायोजित करें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java आपको 3D चार्ट का दृश्य [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) विधि के माध्यम से अनुकूलित करने देता है। यह लेख दिखाता है कि कैसे घूर्णन, ऊंचाई अनुपात, गहराई, समकोण अक्ष, और श्रृंखलाओं के बीच की दूरी को समायोजित किया जाए, और फिर प्रस्तुति को PPTX प्रारूप में सहेजा जाए।

## **3D चार्ट का घूर्णन और गहराई सेट करना**

निचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाता है और [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) का उपयोग करके अपनी पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट सीरीज़ और श्रेणियों को दो सीरीज़ से बदलता है, जिनमें प्रत्येक में तीन मान होते हैं। वर्कशीट इंडेक्स `0` चार्ट की पहली डेटा वर्कशीट की पहचान करता है; पंक्ति `0` में सीरीज़ नाम होते हैं, और कॉलम `0` में श्रेणी लेबल होते हैं।

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) और [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) विधियां क्रमशः चार्ट का घूर्णन 40 और 270 डिग्री पर सेट करती हैं। [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) इसकी गहराई को उसकी चौड़ाई के 150% पर सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) परिप्रेक्ष्य के बजाय समकोण अक्ष सक्षम करता है। परिणामी प्रस्तुति इन 3D दृश्य सेटिंग्स के साथ भराए गए चार्ट को शामिल करती है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3D चार्ट सतह पर चित्र भराव लागू करना**

आप एक 3D चार्ट की [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/), और [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) को अलग-अलग भर सकते हैं। सतह की [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) को `Picture` पर सेट करें और एक चित्र असाइन करें। दोनों [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) और सतह की [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) को `Stretch` पर सेट करें ताकि चित्र की एक प्रति पूरे सतह में फिट हो जाए।

[arrow.png](arrow.png) को कार्य निर्देशिका में सहेजें। उदाहरण चार्ट को घुमाता है और लंबवत अक्ष पर अधिकतम मान बढ़ाता है ताकि कॉलम के बीच फ़र्श दिखाई दे। फिर यह स्लाइड को दो बार क्लोन करता है और प्रत्येक स्लाइड पर तीर को अलग सतह पर लागू करता है। सभी तीन चार्ट समान डेटा, दृश्य कोण, और पृष्ठभूमि रखते हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint तीन स्लाइड्स को इस प्रकार दिखाता है।

| पार्श्व दीवार | पिछली दीवार | फ़र्श |
| --- | --- | --- |
| ![पार्श्व दीवार के साथ चार्ट की ओर संकेत करने वाला तीर](side-wall.png) | ![पिछली दीवार के पार दाएँ दिशा में संकेत करने वाला तीर](back-wall.png) | ![कॉलम के बीच फ़र्श पर दाएँ दिशा में संकेत करने वाला तीर](floor.png) |

## **3D चार्ट की ऊंचाई अनुपात समायोजित करना**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) का उपयोग करके 3D चार्ट की ऊंचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट किया जा सकता है। यह स्लाइड पर चार्ट ऑब्जेक्ट का आकार बदले बिना 3D दृश्य के अनुपात बदलता है।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ एक [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) चार्ट बनाता है: तीन सीरीज़ और चार श्रेणियां। यह 50%, 100%, और 200% ऊंचाई अनुपात के साथ तीन प्रस्तुतियां सहेजता है। चार्ट की स्थिति, चौड़ाई और ऊंचाई समान रहती हैं। सभी तीन फ़ाइलों में डेटा, घूर्णन, गहराई, सीरीज़ स्पेसिंग, और स्वरूपण समान हैं; केवल ऊंचाई प्रतिशत बदलता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

निम्न चित्र समान ऊंचाई सेटिंग्स को समतुल्य .NET उदाहरण में दर्शाते हैं और Microsoft PowerPoint का उपयोग कर निर्यात किए गए हैं। छोटा प्रतिशत एक समतलीय दृश्य बनाता है, जबकि बड़ा प्रतिशत उसी चार्ट ऑब्जेक्ट में ऊँचा दृश्य बनाता है। PowerPoint दृश्य के अनुरूप अक्ष टिक अंतराल और लेबल स्थान को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![अपनी चौड़ाई के 50% पर सेट की गई ऊँचाई के साथ 3D कॉलम चार्ट](height_percent_50.png) | ![अपनी चौड़ाई के 100% पर सेट की गई ऊँचाई के साथ 3D कॉलम चार्ट](height_percent_100.png) | ![अपनी चौड़ाई के 200% पर सेट की गई ऊँचाई के साथ 3D कॉलम चार्ट](height_percent_200.png) |

ये विधियां चार्ट के विभिन्न पहलुओं को नियंत्रित करती हैं:

| Method | Effect |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D दृश्य की ऊँचाई, उसकी चौड़ाई के प्रतिशत के रूप में। |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D दृश्य की गहराई, उसकी चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | डीप्थ अक्ष के साथ सीरीज़ के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत के रूप में। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट को प्रभावित करती है, जिसमें सिलेंडर, शंकु और पिरामिड रूपांतर शामिल हैं, साथ ही 3D लाइन, एरिया, पाई, और सतह चार्ट भी। ऊपर की तुलना सत्यापित `Column3D` प्रकार का उपयोग करती है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) क्लास के सदस्य हैं। अन्य चार्ट उपस्थिति सेटिंग्स के लिए, देखें [Chart Formatting](/slides/hi/nodejs-java/chart-formatting/)।

## **सीरीज़ के बीच गैप समायोजित करना**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) का उपयोग करके 3D चार्ट के डीप्थ अक्ष के साथ डेटा सीरीज़ के बीच की दूरी को नियंत्रित किया जाता है, जो मार्कर चौड़ाई के प्रतिशत में व्यक्त होती है। मान **0 से 500** तक उपयोग करें, जिसमें `0` गैप को हटाता है, और बड़े मान स्पेसिंग बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, गैप बढ़ाने से मार्कर डीप्थ अक्ष पर पतले हो जाते हैं।

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) के माध्यम से समूह तक पहुंचें। यह सेटिंग उस समूह की प्रत्येक सीरीज़ पर लागू होती है, न कि केवल वह सीरीज़ जिसको उपयोग करके इसे पहुँचा गया है। [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) गहराई गैप लौटाता है और पैरेंट समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट को प्रभावित करती है, जिसमें उनके सिलेंडर, शंकु, और पिरामिड रूपांतर शामिल हैं, साथ ही 3D लाइन और एरिया चार्ट भी। उपस्थिति इस पर निर्भर करती है कि सीरीज़ डीप्थ में, क्लस्टर्ड, या स्टैक्ड हैं या नहीं। अलग-अलग सीरीज़ के बीच गैप की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) क्लास से `ChartType.Column3D` का उपयोग करें।

| Method | Effect |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | डीप्थ अक्ष के साथ सीरीज़ के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | सन्निकट बार या कॉलम क्लस्टर्स के बीच की दूरी, बार या कॉलम चौड़ाई के प्रतिशत के रूप में। |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | समग्र चार्ट गहराई, चार्ट चौड़ाई के प्रतिशत के रूप में। |

निम्न स्व-निहित उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है, जिसमें तीन सीरीज़ और चार श्रेणियां होती हैं। यह दो प्रस्तुतियां सहेजता है जिनमें डेटा, घूर्णन, गैप चौड़ाई और चार्ट गहराई समान होते हैं; केवल गैप गहराई बदलती है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

निम्न चित्र समतुल्य .NET उदाहरण में समान गैप गहराई सेटिंग्स को दर्शाते हैं और Microsoft PowerPoint का उपयोग करके निर्यात किए गए हैं।

| गैप गहराई: 0% | गैप गहराई: 500% |
| --- | --- |
| ![डीप्थ अक्ष के साथ सीरीज़ के बीच कोई गैप न होने वाला 3D कॉलम चार्ट](gap_depth_0.png) | ![डीप्थ अक्ष के साथ सीरीज़ के बीच 500 प्रतिशत गैप वाला 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D सीरीज़ प्रकार और बार आकार बदलें**

एक क्लस्टर्ड सिलेंडर चार्ट में, पहली सीरीज़ सिलेंड्रिकल बार आकार से शुरू होती है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) और [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) द्वारा लौटाए गए पूर्णांक मान प्रिंट करता है। तालिका संबंधित स्थिरांक नाम देती है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| पहली सीरीज़ में परिवर्तन | सीरीज़ प्रकार | बार आकार |
| --- | --- | --- |
| चार्ट बनाएं | `ClusteredCylinder` | `Cylinder` |
| सीरीज़ प्रकार को `ClusteredCone` सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` सेट करें | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से सीरीज़ प्रकार भी `ClusteredColumn3D` में बदल जाता है। यदि आपका कोड सीरीज़ प्रकार पर निर्भर करता है, तो आकार परिवर्तन के बाद `series.getType()` कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा का चयन करेगा।

![PowerPoint तुलना जो पहली सीरीज़ को बाएँ से दाएँ सिलेंडर, शंकु, और आयताकार कॉलम के रूप में दिखाती है](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D रूपांतर का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) क्लास के माध्यम से उजागर किए गए संबंधित 3D प्रकार भी। सटीक और अद्यतन सूची के लिए, अपने स्थापित संस्करण के API रेफरेंस में [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) के सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हां। आप [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) के साथ चार्ट को एक छवि में निर्यात कर सकते हैं या [संपूर्ण स्लाइड को रेंडर](/slides/hi/nodejs-java/convert-powerpoint-to-png/) करके PNG या JPEG जैसे फ़ॉर्मेट में बदल सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर प्रीव्यू चाहिए या आप PowerPoint की आवश्यकता के बिना चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पेजों में एम्बेड करना चाहते हैं।

**बड़े 3D चार्ट का निर्माण और रेंडरिंग कितना प्रभावी है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणाम के लिए, 3D प्रभावों को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक सीरीज़ में डेटा पॉइंट्स की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुरूप रिज़ॉल्यूशन और आयामों के साथ उपयुक्त आकार के आउटपुट में रेंडर करें।