---
title: Android पर प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/androidjava/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। Java उदाहरणों के साथ रोटेशन, ऊँचाई अनुपात, चार्ट गहराई और श्रृंखला के बीच की दूरी को समायोजित करें।"
---
## **समीक्षा**

Aspose.Slides for Android via Java आपको 3D चार्ट का दृश्य [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) मेथड के माध्यम से अनुकूलित करने देता है। यह लेख रोटेशन, ऊँचाई अनुपात, गहराई, समकोण एक्सिस, और श्रृंखला के बीच की दूरी को कैसे समायोजित किया जाए, तथा प्रस्तुति को PPTX स्वरूप में कैसे सहेजा जाए, यह दर्शाता है।

## **3D चार्ट का घूर्णन और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाता है और [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) का उपयोग करके उसकी पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट श्रृंखला और श्रेणियों को दो श्रृंखलाओं से बदल देता है, जिनमें प्रत्येक में तीन मान होते हैं। वर्कशीट इंडेक्स `0` चार्ट की पहली डेटा वर्कशीट को दर्शाता है; पंक्ति `0` में श्रृंखला के नाम होते हैं, और कॉलम `0` में श्रेणी लेबल होते हैं।

The [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) और [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) मेथड्स क्रमशः चार्ट का घूर्णन 40 और 270 डिग्री सेट करते हैं। [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) उसकी गहराई को उसकी चौड़ाई के 150% पर सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) परिप्रेक्ष्य के बजाय समकोण एक्सिस सक्षम करता है। परिणामी प्रस्तुति में इन 3D दृश्य सेटिंग्स के साथ भराए गए चार्ट का समावेश होता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3D चार्ट की ऊँचाई अनुपात समायोजित करें**

एक 3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करने के लिए [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) का उपयोग करें। यह स्लाइड पर चार्ट ऑब्जेक्ट का आकार बदले बिना 3D दृश्य के अनुपात बदलता है।

निम्न उदाहरण डिफ़ॉल्ट डेटा के साथ एक [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) चार्ट बनाता है: तीन श्रृंखलाएँ और चार श्रेणियाँ। यह 50%, 100% और 200% की ऊँचाई अनुपात के साथ तीन प्रस्तुतियों को सहेजता है। चार्ट की स्थिति, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घूर्णन, गहराई, श्रृंखला की दूरी और स्वरूपण सभी तीन फाइलों में समान होते हैं; केवल ऊँचाई प्रतिशत बदलता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

निम्न चित्र समान ऊँचाई सेटिंग्स को समकक्ष .NET उदाहरण में दर्शाते हैं और माइक्रोसॉफ्ट पावरपॉइंट का उपयोग करके निर्यात किए गए हैं। कम प्रतिशत एक समतल दृश्य उत्पन्न करता है, जबकि बड़ा प्रतिशत उसी चार्ट ऑब्जेक्ट के भीतर एक ऊँचा दृश्य बनाता है। पावरपॉइंट दृश्य के फिट के लिए अक्ष टिक अंतराल और लेबल प्लेसमेंट भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![3D कॉलम चार्ट जिसमें ऊँचाई उसकी चौड़ाई के 50 प्रतिशत पर सेट है](height_percent_50.png) | ![3D कॉलम चार्ट जिसमें ऊँचाई उसकी चौड़ाई के 100 प्रतिशत पर सेट है](height_percent_100.png) | ![3D कॉलम चार्ट जिसमें ऊँचाई उसकी चौड़ाई के 200 प्रतिशत पर सेट है](height_percent_200.png) |

इन मेथड्स चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D दृश्य की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में। |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D दृश्य की गहराई को उसकी चौड़ाई के प्रतिशत के रूप में। |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | मार्कर की चौड़ाई के प्रतिशत के रूप में गहराई धुरी पर श्रृंखलाओं के बीच की दूरी। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट्स को प्रभावित करती है, जिसमें सिलेंडर, कोन और पिरामिड वेरिएंट्स, साथ ही 3D लाइन, एरिया, पाई और सतह चार्ट्स शामिल हैं। ऊपर दिया गया तुलनात्मक उदाहरण सत्यापित `Column3D` प्रकार का उपयोग करता है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति को नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) क्लास के सदस्य हैं। अन्य चार्ट उपस्थिति सेटिंग्स के लिए, देखें [चार्ट स्वरूपण](/slides/hi/androidjava/chart-formatting/)।

## **श्रृंखलाओं के बीच अंतराल समायोजित करें**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) का उपयोग करके 3D चार्ट की गहराई धुरी पर डेटा श्रृंखलाओं के बीच की दूरी को मार्कर चौड़ाई के प्रतिशत के रूप में नियंत्रित करें। मान **0 से 500** (समावेशी) का उपयोग करें: `0` अंतराल हटाता है, जबकि बड़े मान दूरी बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, अंतराल बढ़ाने से गहराई धुरी पर मार्कर पतले हो जाते हैं।

[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) के माध्यम से समूह तक पहुँचें। यह सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है, न कि केवल वह श्रृंखला जिसपर पहुँचने के लिए उपयोग किया गया है। [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) गहराई अंतराल लौटाता है और पैरेंट समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट्स को प्रभावित करती है, जिसमें उनके सिलेंडर, कोन, और पिरामिड वेरिएंट्स, साथ ही 3D लाइन और एरिया चार्ट्स शामिल हैं। दिखावट इस बात पर निर्भर करती है कि श्रृंखलाएँ गहराई में व्यवस्थित हैं, क्लस्टर की गई हैं या स्टैक्ड हैं। अलग-अलग श्रृंखलाओं के बीच अंतराल की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) क्लास से `ChartType.Column3D` का उपयोग करें।

इन मेथड्स चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | मार्कर की चौड़ाई के प्रतिशत के रूप में गहराई धुरी पर श्रृंखलाओं के बीच की दूरी। |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | बार या कॉलम की चौड़ाई के प्रतिशत के रूप में आसन्न बार या कॉलम क्लस्टर्स के बीच की दूरी। |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | चार्ट की चौड़ाई के प्रतिशत के रूप में समग्र चार्ट गहराई। |

निम्न स्व-निहित उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है, जिसमें तीन श्रृंखलाएँ और चार श्रेणियाँ हैं। यह दो प्रस्तुतियों को सहेजता है जिनमें डेटा, घूर्णन, गैप चौड़ाई, और चार्ट गहराई समान होते हैं; केवल गैप गहराई बदलती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

निम्न चित्र समान गैप गहराई सेटिंग्स को समकक्ष .NET उदाहरण में दिखाते हैं और माइक्रोसॉफ्ट पावरपॉइंट का उपयोग करके निर्यात किए गए हैं।

| गैप गहराई: 0% | गैप गहराई: 500% |
| --- | --- |
| ![गहराई धुरी पर श्रृंखलाओं के बीच कोई अंतराल न रखने वाला 3D कॉलम चार्ट](gap_depth_0.png) | ![गहराई धुरी पर श्रृंखलाओं के बीच 500 प्रतिशत अंतराल वाला 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

एक क्लस्टर्ड सिलेंडर चार्ट में, पहली श्रृंखला एक सिलेंड्रिकल बार आकार से शुरू होती है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) और [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) द्वारा लौटाए गए पूर्णांक मान को प्रिंट करता है। तालिका संबंधित स्थायी नाम देती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| पहली श्रृंखला में बदलाव | श्रृंखला प्रकार | बार आकार |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` में बदल जाता है। यदि आपका कोड श्रृंखला प्रकार के आधार पर शाखा बनाता है, तो आकार बदलने के बाद `series.getType()` कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा को चुनेगा।

![पावरपॉइंट तुलना दिखाती है कि पहली श्रृंखला बाएँ से दाएँ सिलेंडर, कोन और आयताकार कॉलम के रूप में है](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट्स को समर्थन देता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) क्लास के माध्यम से उपलब्ध हैं। सटीक, अद्यतन सूची के लिए, अपने स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) सदस्यों की जाँच करें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हां। आप एक चार्ट को छवि में निर्यात करने के लिए [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) या पूरे स्लाइड को [पूरा स्लाइड रेंडर करें](/slides/hi/androidjava/convert-powerpoint-to-png/) का उपयोग करके PNG या JPEG जैसे स्वरूपों में निर्यात कर सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर पूर्वावलोकन की आवश्यकता होती है या चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पृष्ठों में एम्बेड करना चाहते हैं बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाना और रेंडर करना कितना प्रदर्शनकारी है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D प्रभावों को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा बिंदुओं की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार उचित रिज़ॉल्यूशन और आयामों के साथ आउटपुट को रेंडर करें।