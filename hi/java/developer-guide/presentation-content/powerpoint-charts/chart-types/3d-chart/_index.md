---
title: Java का उपयोग करके प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/java/3d-chart/
keywords:
- 3D चार्ट
- घुमाव
- गहराई
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। Java उदाहरणों के साथ घुमाव, ऊँचाई अनुपात, चार्ट की गहराई, और श्रृंखलाओं के बीच की दूरी समायोजित करें।"
---
## **सारांश**

Aspose.Slides for Java आपको 3D चार्ट का दृश्य **[IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--)** मेथड के जरिए अनुकूलित करने की अनुमति देता है। यह लेख घुमाव, ऊँचाई अनुपात, गहराई, समकोण एक्सिस और श्रृंखलाओं के बीच की दूरी को कैसे समायोजित करें, फिर प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें, यह दर्शाता है।

## **3D चार्ट का घुमाव और गहराई सेट करना**

निम्न उदाहरण एक **[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)** बनाता है और **[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-)** का उपयोग करके पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट श्रृंखलाओं और श्रेणियों को दो श्रृंखलाओं से बदल देता है, जिनमें प्रत्येक में तीन मान होते हैं। कार्यपत्रक निर्देशांक `0` चार्ट के पहले डेटा कार्यपत्रक की पहचान करता है; पंक्ति `0` में श्रृंखला नाम होते हैं, और कॉलम `0` में श्रेणी लेबल होते हैं।

**[setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-)** और **[setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-)** मेथड क्रमशः चार्ट का घुमाव 40 और 270 डिग्री पर सेट करते हैं। **[setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-)** इसकी गहराई को उसकी चौड़ाई के 150 % पर सेट करता है, जबकि **[setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-)** पर्स्पेक्टिव के बजाय समकोण एक्सिस को सक्षम करता है। परिणामस्वरूप प्रस्तुति में इन 3D दृश्य सेटिंग्स के साथ भरपूर चार्ट सम्मिलित रहता है।

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

**[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-)** का उपयोग करके 3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट किया जाता है। यह स्लाइड पर चार्ट ऑब्जेक्ट का आकार बदले बिना 3D सीन के अनुपात को बदलता है।

निम्न उदाहरण एक **[Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)** चार्ट को डिफ़ॉल्ट डेटा (तीन श्रृंखलाएँ और चार श्रेणियाँ) के साथ बनाता है। यह 50 %, 100 % और 200 % ऊँचाई अनुपात के साथ तीन प्रस्तुतियों को सहेजता है। चार्ट की स्थिति, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घुमाव, गहराई, श्रृंखला अंतराल और स्वरूपण सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

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

निम्न छवियाँ समान ऊँचाई सेटिंग को .NET उदाहरण में दर्शाती हैं और Microsoft PowerPoint से निर्यात की गई हैं। छोटा प्रतिशत एक सपाट सीन बनाता है, जबकि बड़ा प्रतिशत समान चार्ट ऑब्जेक्ट के भीतर एक ऊँचा सीन बनाता है। PowerPoint सीन के अनुरूप अक्ष टिक अंतराल और लेबल प्लेसमेंट को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![3D column chart with height set to 50 percent of its width](height_percent_50.png) | ![3D column chart with height set to 100 percent of its width](height_percent_100.png) | ![3D column chart with height set to 200 percent of its width](height_percent_200.png) |

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D सीन की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में निर्धारित करता है। |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D सीन की गहराई को उसकी चौड़ाई के प्रतिशत के रूप में निर्धारित करता है। |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | मार्कर की चौड़ाई के प्रतिशत के रूप में गहराई एक्सिस पर श्रृंखलाओं के बीच की दूरी। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट, जिसमें सिलेंडर, शंकु और पिरामिड वैरिएंट शामिल हैं, साथ ही 3D लाइन, एरिया, पाई और सरफ़ेस चार्ट पर प्रभाव डालती है। ऊपर दिया गया तुलनात्मक उदाहरण सत्यापित `Column3D` प्रकार का उपयोग करता है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति नहीं बदलती; ये नाम **[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)** क्लास के सदस्य हैं। अन्य चार्ट स्वरूपण सेटिंग्स के लिये देखें **[Chart Formatting](/slides/hi/java/chart-formatting/)**।

## **श्रृंखलाओं के बीच अंतराल समायोजित करें**

**[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-)** का उपयोग 3D चार्ट के गहराई एक्सिस पर डेटा श्रृंखलाओं के बीच की दूरी को नियंत्रित करने के लिये किया जाता है, जो मार्कर की चौड़ाई के प्रतिशत के रूप में अभिव्यक्त होती है। मान **0 से 500** तक, समावेशी: `0` अंतराल को हटा देता है, जबकि बड़े मान अंतराल बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, अंतराल बढ़ाने से मार्कर गहराई एक्सिस पर पतले दिखाई देते हैं।

समूह तक पहुँचने के लिये **[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)** का उपयोग करें। सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है, न कि केवल उस श्रृंखला पर जिसका उपयोग करके आप पहुँच रहे हैं। **[IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--)** गहराई अंतराल को लौटाता है और पैरेंट समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट, उनके सिलेंडर, शंकु और पिरामिड वैरिएंट, साथ ही 3D लाइन और एरिया चार्ट को प्रभावित करती है। उपस्थिति इस बात पर निर्भर करती है कि श्रृंखलाएँ गहराई में व्यवस्थित हैं, क्लस्टर की गई हैं या स्टैक्ड हैं। अलग‑अलग श्रृंखलाओं के बीच अंतराल की स्पष्ट तुलना के लिये **[ChartType.Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)** का उपयोग करें।

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | गहराई एक्सिस पर श्रृंखलाओं के बीच की दूरी, मार्कर की चौड़ाई के प्रतिशत के रूप में। |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | लगते‑जुड़ते बार या कॉलम क्लस्टर के बीच की दूरी, बार या कॉलम की चौड़ाई के प्रतिशत के रूप में। |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | चार्ट की कुल गहराई, चार्ट की चौड़ाई के प्रतिशत के रूप में। |

निम्न स्वयंसन्निहित उदाहरण डिफ़ॉल्ट चार्ट डेटा (तीन श्रृंखलाएँ और चार श्रेणियाँ) का उपयोग करता है। यह दो प्रस्तुतियों को सहेजता है, जिनमें डेटा, घुमाव, अंतराल चौड़ाई और चार्ट गहराई समान हैं; केवल अंतराल गहराई बदलता है।

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

निम्न छवियाँ समान अंतराल गहराई सेटिंग को .NET उदाहरण में दर्शाती हैं और Microsoft PowerPoint से निर्यात की गई हैं।

| अंतराल गहराई: 0% | अंतराल गहराई: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

क्लस्टर्ड सिलेंडर चार्ट में, पहली श्रृंखला का प्रारम्भिक बार आकार सिलेंडर होता है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में **[IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--)** और **[IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--)** द्वारा लौटाए गए पूर्णांक मानों को प्रिंट करता है। तालिका संबंधित स्थिरांक नाम देती है।

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

| पहली श्रृंखला में परिवर्तन | श्रृंखला प्रकार | बार आकार |
| --- | --- | --- |
| चार्ट बनाएं | `ClusteredCylinder` | `Cylinder` |
| श्रृंखला प्रकार को `ClusteredCone` पर सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` पर सेट करें | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` में बदल जाता है। यदि आपका कोड श्रृंखला प्रकार के आधार पर शाखा बनाता है, तो आकार बदलने के बाद **`series.getType()`** को कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा को चुन लेगा।

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन‑से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वैरिएंट, जैसे **Column 3D**, **Clustered Column 3D**, **Stacked Column 3D**, और **100 % Stacked Column 3D**, के साथ-साथ **[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)** क्लास के माध्यम से उपलब्ध संबंधित 3D प्रकारों का समर्थन करता है। सटीक और नवीनतम सूची के लिये, अपने स्थापित संस्करण के API रेफ़रेंस में **[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)** सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिये 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हाँ। आप **[Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--)** या पूरे स्लाइड को **[render the entire slide](/slides/hi/java/convert-powerpoint-to-png/)** करके PNG या JPEG जैसे फ़ॉर्मेट में निर्यात कर सकते हैं। यह तब उपयोगी होता है जब आपको रास्टर प्रीव्यू चाहिए या चार्ट को दस्तावेज़, डैशबोर्ड या वेब पेज में बिना PowerPoint की आवश्यकता के एम्बेड करना हो।

**बड़े 3D चार्ट को बनाना और रेंडर करना कितना प्रदर्शन‑क्षम है?**

प्रदर्शन डेटा मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणाम के लिये 3D प्रभाव न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला के डेटा बिंदुओं की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुरूप आउटपुट (रिज़ॉल्यूशन और आयाम) को उचित आकार में रेंडर करें।