---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में 3D चार्ट को कस्टमाइज़ करें
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
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। जावास्क्रिप्ट उदाहरणों के साथ घूर्णन, ऊँचाई अनुपात, चार्ट गहराई और श्रृंखलाओं के बीच की दूरी समायोजित करें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java आपको 3D चार्ट के दृश्य को [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) मेथड के माध्यम से अनुकूलित करने देता है। यह लेख दिखाता है कि घूर्णन, ऊँचाई अनुपात, गहराई, समकोण अक्ष, और श्रृंखलाओं के बीच की दूरी को कैसे समायोजित किया जाए, फिर प्रस्तुति को PPTX फ़ॉर्मेट में सहेजा जाए।

## **3D चार्ट का घूर्णन और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) बनाता है और [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) का उपयोग करके पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट श्रृंखला और श्रेणियों को दो श्रृंखलाओं से बदलता है, प्रत्येक में तीन मान होते हैं। वर्कशीट इंडेक्स `0` चार्ट की पहली डेटा वर्कशीट की पहचान करता है; पंक्ति `0` श्रृंखला नाम रखती है, और कॉलम `0` श्रेणी लेबल रखता है।

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) और [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) मेथड क्रमशः चार्ट का घूर्णन 40 और 270 डिग्री पर सेट करते हैं। [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) इसकी गहराई को उसकी चौड़ाई के 150% पर सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) पर्स्पेक्टिव के बजाय समकोण अक्ष सक्षम करता है। परिणामी प्रस्तुति इन 3D दृश्य सेटिंग्स वाले भरपूर चार्ट को सम्मिलित करती है।

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

## **3D चार्ट की ऊँचाई अनुपात समायोजित करें**

3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करने के लिए [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) का प्रयोग करें। यह स्लाइड पर चार्ट ऑब्जेक्ट का आकार बदले बिना 3D दृश्य के अनुपात को बदलता है।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ एक [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) चार्ट बनाता है: तीन श्रृंखलाएँ और चार श्रेणियाँ। यह 50%, 100% और 200% ऊँचाई अनुपात के साथ तीन प्रस्तुतियां सहेजता है। चार्ट की स्थिती, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घूर्णन, गहराई, श्रृंखला spacing, और फॉर्मेटिंग सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

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

निम्न चित्र समान ऊँचाई सेटिंग्स को समान .NET उदाहरण में दर्शाते हैं और Microsoft PowerPoint का उपयोग करके निर्यात किए गए हैं। एक छोटा प्रतिशत एक सपाट दृश्य पैदा करता है, जबकि बड़ा प्रतिशत उसी चार्ट ऑब्जेक्ट में एक ऊँचा दृश्य बनाता है। PowerPoint दृश्य के अनुरूप अक्ष टिक अंतराल और लेबल प्लेसमेंट को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 50 प्रतिशत पर सेट है](height_percent_50.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 100 प्रतिशत पर सेट है](height_percent_100.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 200 प्रतिशत पर सेट है](height_percent_200.png) |

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D दृश्य की ऊँचाई, उसकी चौड़ाई के प्रतिशत के रूप में। |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D दृश्य की गहराई, उसकी चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर की चौड़ाई के प्रतिशत के रूप में। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट को प्रभावित करती है, जिसमें सिलिंडर, शंकु, और पिरामिड वेरिएंट शामिल हैं, साथ ही 3D लाइन, एरिया, पाई, और सर्फेस चार्ट भी। ऊपर का तुलनात्मक उदाहरण सत्यापित `Column3D` प्रकार का उपयोग करता है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति को नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) क्लास के सदस्य हैं। अन्य चार्ट उपस्थिति सेटिंग्स के लिए, देखें [Chart Formatting](/slides/hi/nodejs-java/chart-formatting/)।

## **श्रृंखलाओं के बीच गैप समायोजित करें**

एक 3D चार्ट के गहराई अक्ष के साथ डेटा श्रृंखलाओं के बीच की दूरी को प्रतिशत में व्यक्त करने के लिए [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) का उपयोग करें। **0 से 500** तक के मानों का प्रयोग करें, दोनों सहित: `0` गैप को हटा देता है, जबकि बड़े मान स्पेसिंग बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, गैप बढ़ाने से मार्कर गहराई अक्ष पर पतले हो जाते हैं।

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) के माध्यम से समूह तक पहुंचें। यह सेटिंग उस समूह की हर श्रृंखला पर लागू होती है, केवल उस श्रृंखला पर नहीं जिसका उपयोग करके इसे एक्सेस किया गया। [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) गहराई गैप लौटाता है और पैरेंट समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट को प्रभावित करती है, जिसमें उनके सिलिंडर, शंकु, और पिरामिड वेरिएंट शामिल हैं, साथ ही 3D लाइन और एरिया चार्ट भी। उपस्थिति इस पर निर्भर करती है कि श्रृंखलाएँ गहराई में व्यवस्थित हैं, क्लस्टर्ड हैं, या स्टैक्ड हैं। अलग-अलग श्रृंखलाओं के बीच गैप की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) क्लास से `ChartType.Column3D` का उपयोग करें।

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर की चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | सन्निहित बार या कॉलम क्लस्टर के बीच की दूरी, बार या कॉलम की चौड़ाई के प्रतिशत के रूप में। |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | कुल चार्ट गहराई, चार्ट की चौड़ाई के प्रतिशत के रूप में। |

निम्न स्व-समाहित उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है, जिसमें तीन श्रृंखलाएँ और चार श्रेणियाँ होती हैं। यह दो प्रस्तुतियां सहेजता है जिनमें डेटा, घूर्णन, गैप चौड़ाई, और चार्ट गहराई समान है; केवल गैप गहराई बदलती है।

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

निम्न चित्र समान गैप गहराई सेटिंग्स को समान .NET उदाहरण में दर्शाते हैं और Microsoft PowerPoint का उपयोग करके निर्यात किए गए हैं।

| गैप गहराई: 0% | गैप गहराई: 500% |
| --- | --- |
| ![3D कॉलम चार्ट जिसमें गहराई अक्ष के साथ श्रृंखलाओं के बीच कोई गैप नहीं है](gap_depth_0.png) | ![3D कॉलम चार्ट जिसमें गहराई अक्ष के साथ श्रृंखलाओं के बीच 500 प्रतिशत गैप है](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार रूप बदलें**

क्लस्टर्ड सिलिंडर चार्ट में, पहली श्रृंखला सिलिंड्रिकल बार आकार से शुरू होती है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) और [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) द्वारा लौटाए गए पूर्णांक मान प्रिंट करता है। तालिका संबंधित स्थिरांक नाम देती है।

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

| पहली श्रृंखला में परिवर्तन | श्रृंखला प्रकार | बार आकार |
| --- | --- | --- |
| चार्ट बनाते हैं | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` प्रकार की श्रृंखला सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` पर सेट करें | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` हो जाता है। यदि आपका कोड श्रृंखला प्रकार के आधार पर शाखा बनाता है, तो आकार बदलने के बाद `series.getType()` को कॉल करें। असाइनमेंट से पहले कैश किया हुआ मान अभी भी `ClusteredCone` शाखा को चुन सकता है।

![PowerPoint तुलना दर्शाती है कि पहली श्रृंखला बाएँ से दाएँ सिलिंडर, शंकु, और आयताकार कॉलम के रूप में है](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड को सपोर्ट करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट को सपोर्ट करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) क्लास के माध्यम से उपलब्ध हैं। सटीक, अद्यतित सूची के लिए, अपने स्थापित संस्करण की API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) सदस्य देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हाँ। आप [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) या [पूरी स्लाइड को रेंडर करें](/slides/hi/nodejs-java/convert-powerpoint-to-png/) का उपयोग करके चार्ट को PNG या JPEG जैसे फ़ॉर्मैट में निर्यात कर सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर प्रीव्यू चाहिए या PowerPoint की आवश्यकता के बिना दस्तावेज़ों, डैशबोर्ड या वेब पेजों में चार्ट एम्बेड करना है।

**बड़े 3D चार्ट बनाना और रेंडर करना कितना तेज़ है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D प्रभावों को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा पॉइंट की संख्या सीमित करें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुरूप उपयुक्त आकार (रिज़ॉल्यूशन और डायमेंशन) में आउटपुट रेंडर करें।