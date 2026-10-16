---
title: एंड्रॉइड पर प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/androidjava/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेन्शियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरज ट्रेंड लाइन
- पोलिनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "एंड्रॉइड के लिए जावा के माध्यम से Aspose.Slides का उपयोग करके पावरपॉइंट चार्ट में ट्रेंड लाइन्स को जल्दी जोड़ें और अनुकूलित करें — आपके दर्शकों को आकर्षित करने के लिए एक व्यावहारिक गाइड।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ने के तरीके को समझाता है। यह दर्शाता है कि कैसे एक चार्ट बनाया जाता है, चार्ट सीरीज़ में ट्रेंड लाइन्स जोड़ी जाती हैं, और कई प्रकार की ट्रेंड लाइन्स के साथ काम किया जाता है, जिसमें एक्सपोनेन्शियल, लीनियर, लॉगरिदमिक, मूविंग एवरज, पोलिनॉमियल और पावर शामिल हैं।

यह भी बताता है कि कैसे एक लाइन शेप डालकर चार्ट में कस्टम लाइन जोड़ी जा सकती है, और आगे-पीछे ट्रेंड लाइन प्रोजेक्शन मान और PDF या SVG में निर्यात के दौरान या चार्ट को छवि के रूप में रेंडर करने पर ट्रेंड लाइन्स संरक्षित रहती हैं, इस बारे में एक संक्षिप्त FAQ शामिल है।

## **ट्रेंड लाइन जोड़ें**

[ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) का उपयोग करके किसी चार्ट सीरीज़ में ट्रेंड लाइन जोड़ी जा सकती है, जिसका प्रकार [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) से चुना जाता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और उसकी तीन सीरीज़ में प्रत्येक दो ट्रेंड लाइन्स जोड़ता है।

एक्सपोनेन्शियल ट्रेंड लाइन अपनी समीकरण और R‑स्क्वेयर्ड मान को [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) और [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) द्वारा छुपा देती है, जबकि लीनियर ट्रेंड लाइन लाल रंग की होती है। लॉगरिदमिक ट्रेंड लाइन एक कस्टम लेबल के लिए [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) का उपयोग करती है। मूविंग एवरज तीन डेटा पॉइंट की अवधि के लिए [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) और कस्टम [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) का उपयोग करती है।

पोलिनॉमियल ट्रेंड लाइन की [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) तीन है और वह [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-) द्वारा एक श्रेणी आगे बढ़ती है। पावर ट्रेंड लाइन [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-) द्वारा एक श्रेणी पीछे जाती है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ट्रेंड लाइन इंटरसेप्ट सेट करें**

[setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) का उपयोग करके X = 0 पर ट्रेंड लाइन के Y मान को फिक्स किया जा सकता है। यह सेटिंग लीनियर, एक्सपोनेन्शियल और पोलिनॉमियल ट्रेंड लाइन्स के लिए समर्थित है।

उदाहरण के लिए, किसी उत्पादन लागत मॉडल को ज्ञात स्थिर लागत 100 से शुरू करना पड़ सकता है, जबकि शून्य‑रहित उत्पादन मात्रा के माप विभिन्न बेसलाइन दर्शाते हों। लीनियर ट्रेंड लाइन के लिए, इंटरसेप्ट फिक्स करने से समीकरण `y = ax + b` का `b = 100` बन जाता है; ढलान डेटा के अनुसार इस प्रतिबंध के तहत फिट होती है। यह केवल पहले से फिट की गई लाइन को नहीं हटाता। एक्सिस क्रॉसिंग सेटिंग्स नियंत्रित करती हैं कि चार्ट की एक्सिस कहाँ मिलती हैं, न कि फिटेड ट्रेंड लाइन के गुणांक।

नीचे दिया गया उदाहरण 1 से 4 तक के उत्पादन मात्रा और 170, 200, 230, तथा 260 की लागत के साथ एक स्कैटर (XY) चार्ट बनाता है। यह डिफ़ॉल्ट ऑटोमैटिक इंटरसेप्ट के साथ चार्ट को सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरा PPTX सहेजता है। दोनों फ़ाइलें केवल इंटरसेप्ट सेटिंग में अंतर रखती हैं। ट्रेंड लाइन अपनी समीकरण दिखाती है और X = 0 तक विस्तार करती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ऑटोमैटिक गणना के साथ, ये डेटा `y = 30x + 140` देती हैं। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिटेड मान ज्ञात बेसलाइन से मेल खाता है, जबकि लाइन अब प्रत्येक डेटा पॉइंट से नहीं गुज़रती।

| ऑटोमैटिक इंटरसेप्ट | 100 का फिक्स्ड इंटरसेप्ट |
| --- | --- |
| ![ऑटोमैटिक रूप से गणना किए गए 140 इंटरसेप्ट वाली लीनियर ट्रेंड लाइन](intercept-automatic.png) | ![100 के फिक्स्ड इंटरसेप्ट वाली लीनियर ट्रेंड लाइन](intercept-fixed.png) |

दोनों छवियाँ समान डेटा और एक्सिस स्केल का उपयोग करती हैं। ट्रेंड लाइन्स को X = 0 तक विस्तारित किया गया है ताकि उनका इंटरसेप्ट दिखाया जा सके।

डिफ़ॉल्ट रूप से, [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) `Double.NaN` लौटाता है, जो अनिर्दिष्ट इंटरसेप्ट को दर्शाता है, शून्य नहीं। इंटरसेप्ट तब डेटा से स्वतः गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

कस्टम लाइन एक ऐसी श形 है जो चार्ट के ऊपर खींची जाती है, न कि सीरीज़ डेटा से गणना की गई ट्रेंड लाइन। यह उदाहरण [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) का उपयोग करके स्लाइड पर चार्ट के ऊपर एक क्षैतिज लाइन जोड़ता है। लाइन की स्थिति स्लाइड कोऑर्डिनेट्स में पॉइंट्स में निर्दिष्ट होती है, इसलिए यह चार्ट के बाएँ किनारे से शुरू होती है और चार्ट के मध्य में स्थित होती है। इसकी चौड़ाई चार्ट की चौड़ाई के बराबर होती है। [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) लाइन को सॉलिड रेड रंग देती है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**'फ़ॉरवर्ड' और 'बैकवर्ड' का अर्थ ट्रेंड लाइन के लिए क्या है?**

वे ट्रेंड लाइन की आगे/पीछे प्रोजेक्ट की गई लंबाई हैं: स्कैटर (XY) चार्ट के लिए — एक्सिस इकाइयों में; गैर‑स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर‑नकारात्मक मान अनुमत हैं।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को छवि के रूप में रेंडर करने पर ट्रेंड लाइन बनी रहती है?**

हां। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; ट्रेंड लाइन्स, जो चार्ट का हिस्सा हैं, इन प्रक्रियाओं के दौरान संरक्षित रहती हैं। चार्ट की छवि निर्यात करने के लिए एक मेथड भी उपलब्ध है: [चार्ट की छवि निर्यात करें](/slides/hi/androidjava/create-shape-thumbnails/)।