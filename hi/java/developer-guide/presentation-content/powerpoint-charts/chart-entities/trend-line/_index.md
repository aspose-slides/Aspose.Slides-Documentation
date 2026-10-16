---
title: जावा में प्रस्तुति चार्ट्स में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- घातीय ट्रेंड लाइन
- रेखीय ट्रेंड लाइन
- लघुगणकीय ट्रेंड लाइन
- चल औसत ट्रेंड लाइन
- बहुपदीय ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint चार्ट्स में तेजी से ट्रेंड लाइन्स जोड़ें और अनुकूलित करें — अपने दर्शकों को आकर्षित करने के लिए एक व्यावहारिक मार्गदर्शिका।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ने के तरीके को समझाता है। यह एक चार्ट बनाने, चार्ट सीरीज़ में ट्रेंड लाइन्स जोड़ने, और कई ट्रेंड लाइन प्रकारों के साथ काम करने को दर्शाता है, जिनमें एक्स्पोनेन्शियल, लीनियर, लॉगरिदमिक, मूविंग औसत, पॉलीनॉमियल और पावर शामिल हैं।

यह यह भी बताता है कि लाइन शेप सम्मिलित करके चार्ट में एक कस्टम लाइन कैसे जोड़ें, और फॉरवर्ड और बैकवर्ड ट्रेंड लाइन प्रोजेक्शन मानों तथा PDF या SVG में निर्यात के दौरान तथा चार्ट को छवि के रूप में रेंडर करने पर ट्रेंड लाइन्स की सुरक्षा के बारे में एक छोटा FAQ शामिल करता है।

## **ट्रेंड लाइन जोड़ें**

एक चार्ट सीरीज़ में ट्रेंड लाइन जोड़ने के लिए [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) का उपयोग करें, और इसका प्रकार [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) के साथ चुनें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और इसके प्रत्येक तीन सीरीज़ में दो ट्रेंड लाइन्स जोड़ता है।

एक्स्पोनेन्शियल ट्रेंड लाइन अपनी समीकरण और R-स्क्वेयर्ड मान को [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) और [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) के माध्यम से छिपाती है, जबकि लीनियर ट्रेंड लाइन लाल होती है। लॉगरिदमिक ट्रेंड लाइन कस्टम लेबल के लिए [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) का उपयोग करती है। मूविंग औसत तीन डेटा पॉइंट्स की [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) और एक कस्टम [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) का उपयोग करता है।

पॉलीनॉमियल ट्रेंड लाइन का [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) तीन है और [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-) के माध्यम से एक श्रेणी आगे बढ़ती है। पावर ट्रेंड लाइन [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-) के माध्यम से एक श्रेणी पीछे घटती है।

```java
import com.aspose.slides.*;
import java.awt.Color;

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

[setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) का उपयोग करके ट्रेंड लाइन का Y मान X = 0 पर स्थिर किया जाता है। यह सेटिंग लीनियर, एक्स्पोनेन्शियल और पॉलीनॉमियल ट्रेंड लाइन्स के लिए समर्थित है।

उदाहरण के लिए, उत्पादन लागत मॉडल को ज्ञात स्थिर लागत 100 से शुरू होना पड़ सकता है, भले ही शून्य नहीं वाले उत्पादन मात्रा के माप अलग बेसलाइन का सुझाव दें। एक लीनियर ट्रेंड लाइन के लिए, इंटरसेप्ट को स्थिर करने से समीकरण `y = ax + b` को `b = 100` पर बाध्य किया जाता है; ढाल को उस बाधा के तहत डेटा के अनुसार फिट किया जाता है। यह केवल पहले से फिट लाइन्स को नहीं हटाता। अक्ष कटाई सेटिंग्स यह नियंत्रित करती हैं कि चार्ट की एक्सिसें कहाँ मिलती हैं, न कि फिटेड ट्रेंड लाइन के गुणांक।

निम्न उदाहरण एक स्कैटर (XY) चार्ट बनाता है जिसमें उत्पादन मात्रा 1 से 4 और लागत 170, 200, 230, और 260 हैं। यह चार्ट को डिफ़ॉल्ट स्वचालित इंटरसेप्ट के साथ सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरा PPTX सहेजता है। दोनों फ़ाइलों में केवल इंटरसेप्ट सेटिंग भिन्न है। ट्रेंड लाइन अपना समीकरण दिखाती है और X = 0 तक विस्तारित होती है।

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

स्वचालित गणना के साथ, यह डेटा `y = 30x + 140` देती है। इंटरसेप्ट को 100 सेट करने पर लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिटेड मान ज्ञात बेसलाइन से मेल खाता है, जबकि लाइन अब हर डेटा पॉइंट से नहीं गुजरती।

| स्वचालित इंटरसेप्ट | 100 का स्थिर इंटरसेप्ट |
| --- | --- |
| ![स्वचालित रूप से गणना किए गए 140 इंटरसेप्ट वाली लीनियर ट्रेंड लाइन](intercept-automatic.png) | ![100 के स्थिर इंटरसेप्ट वाली लीनियर ट्रेंड लाइन](intercept-fixed.png) |

दोनों छवियों में वही डेटा और अक्ष स्केल प्रयोग किए गए हैं। ट्रेंड लाइन्स को उनके इंटरसेप्ट दिखाने के लिए X = 0 तक वापस विस्तारित किया गया है।

डिफ़ॉल्ट रूप से, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) `Double.NaN` लौटाता है, जो शून्य के बजाय अनिर्दिष्ट इंटरसेप्ट को दर्शाता है। फिर इंटरसेप्ट डेटा से स्वचालित रूप से गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

कस्टम लाइन वह शेप है जो चार्ट के ऊपर खींची जाती है, न कि सीरीज़ डेटा से गणना किया गया ट्रेंड लाइन। यह उदाहरण [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) का उपयोग करके चार्ट के ऊपर स्लाइड में एक क्षैतिज लाइन जोड़ता है। लाइन की स्थिति स्लाइड निर्देशांक में पॉइंट्स में निर्दिष्ट की गई है, इसलिए यह चार्ट के बाएँ किनारे से शुरू होती है और चार्ट के मध्य में आधे रास्ते पर स्थित होती है। इसकी चौड़ाई चार्ट की चौड़ाई के बराबर है। [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) लाइन को ठोस लाल रंग देता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

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

**ट्रेंड लाइन के लिए 'फॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

ये ट्रेंड लाइन की आगे/पीछे प्रोजेक्ट की गई लंबाई हैं: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर-स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल शून्य या उससे बड़े मान अनुमति हैं।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने पर, या स्लाइड को छवि के रूप में रेंडर करने पर ट्रेंड लाइन सुरक्षित रहती है?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/java/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/java/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; चार्ट के भाग के रूप में ट्रेंड लाइन्स इन कार्यों के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जो [चार्ट की छवि को निर्यात](/slides/hi/java/create-shape-thumbnails/) करता है।