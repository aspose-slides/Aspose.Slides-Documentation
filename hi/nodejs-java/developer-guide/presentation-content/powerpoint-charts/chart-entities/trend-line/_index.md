---
title: जावास्क्रिप्ट में प्रस्तुति चार्ट्स में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/nodejs-java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेनशियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरेज ट्रेंड लाइन
- पॉलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- पावरपॉइंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के माध्यम से Java के साथ PowerPoint चार्ट्स में ट्रेंड लाइन्स को तेज़ी से जोड़ें और कस्टमाइज़ करें — आपके दर्शकों को जोड़े रखने के लिए एक व्यावहारिक गाइड।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट्स में ट्रेंड लाइन्स जोड़ने का तरीका बताता है। यह दिखाता है कि चार्ट कैसे बनाएं, चार्ट सीरीज़ में ट्रेंड लाइन्स कैसे जोड़ें, और एक्सपोनेनशियल, लीनियर, लॉगरिदमिक, मूविंग एवरेज, पॉलीनॉमियल और पावर सहित कई ट्रेंड लाइन प्रकारों के साथ कैसे काम किया जाए।

यह यह भी वर्णन करता है कि लाइन शैप सम्मिलित करके चार्ट में एक कस्टम लाइन कैसे जोड़ें, और इसमें 'फ़ॉरवर्ड' और 'बैकवर्ड' ट्रेंड लाइन प्रोजेक्शन मानों के बारे में तथा PDF या SVG में निर्यात करते समय या चार्ट को इमेज के रूप में रेंडर करते समय ट्रेंड लाइन्स संरक्षित रहती हैं या नहीं, के बारे में एक संक्षिप्त FAQ शामिल है।

## **ट्रेंड लाइन जोड़ें**

एक चार्ट सीरीज़ में ट्रेंड लाइन जोड़ने के लिए [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) का उपयोग करें, और उसका प्रकार [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/) से चुनें। उदाहरण एक डिफ़ॉल्ट डेटा के साथ क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक तीन सीरीज़ में दो ट्रेंड लाइन्स जोड़ता है।

एक्सपोनेनशियल ट्रेंड लाइन अपनी समीकरण और R‑स्क्वायर मान को [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) और [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue) के माध्यम से छिपाती है, जबकि लीनियर ट्रेंड लाइन लाल होती है। लॉगरिदमिक ट्रेंड लाइन कस्टम लेबल के लिए [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) का उपयोग करती है। मूविंग एवरेज तीन डेटा पॉइंट्स की [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) और एक कस्टम [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName) का उपयोग करती है।

पॉलीनॉमियल ट्रेंड लाइन का [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) तीन है और [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward) के द्वारा एक श्रेणी आगे बढ़ती है। पावर ट्रेंड लाइन [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward) के द्वारा एक श्रेणी पीछे जाती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ट्रेंड लाइन इंटरसेप्ट सेट करें**

[setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) का उपयोग करके X = 0 पर ट्रेंड लाइन का Y मान स्थिर किया जाता है। यह सेटिंग लीनियर, एक्सपोनेनशियल और पॉलीनॉमियल ट्रेंड लाइन्स के लिए समर्थित है।

उदाहरण के लिए, किसी उत्पादन लागत मॉडल को ज्ञात स्थिर लागत 100 से शुरू होना पड़ सकता है, भले ही शून्य के गैर‑शून्य उत्पादन मात्रा पर माप अलग बेसलाइन सुझाते हों। लीनियर ट्रेंड लाइन के लिए, इंटरसेप्ट को स्थिर करने से समीकरण `y = ax + b` को `b = 100` पर प्रतिबंधित किया जाता है; ढाल डेटा के अनुसार उस प्रतिबंध के तहत फिट की जाती है। यह केवल पहले से फिट की गई लाइन को नहीं ले जाता। एक्सिस क्रॉसिंग सेटिंग्स निर्धारित करती हैं कि चार्ट की एक्सिस कहाँ मिलती हैं, न कि फिटेड ट्रेंड लाइन के गुणांक।

निम्न उदाहरण 1 से 4 तक के उत्पादन मात्रा और 170, 200, 230, और 260 की लागत के साथ एक स्कैटर (XY) चार्ट बनाता है। यह चार्ट को डिफ़ॉल्ट ऑटोमैटिक इंटरसेप्ट के साथ सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरा PPTX सहेजता है। दोनों फ़ाइलें केवल इंटरसेप्ट सेटिंग में अंतर रखती हैं। ट्रेंड लाइन अपनी समीकरण दिखाती है और X = 0 तक पीछे विस्तारित होती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ऑटोमैटिक गणना के साथ, ये डेटा `y = 30x + 140` उत्पन्न करते हैं। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिटेड मान ज्ञात बेसलाइन से मेल खाता है, जबकि लाइन अब हर डेटा पॉइंट से नहीं गुजरती।

| ऑटोमैटिक इंटरसेप्ट | 100 का स्थिर इंटरसेप्ट |
| --- | --- |
| ![ऑटोमैटिक रूप से गणना किए गए इंटरसेप्ट 140 के साथ लीनियर ट्रेंड लाइन](intercept-automatic.png) | ![स्थिर इंटरसेप्ट 100 के साथ लीनियर ट्रेंड लाइन](intercept-fixed.png) |

दोनों छवियों में समान डेटा और अक्ष स्केल का उपयोग किया गया है। ट्रेंड लाइन्स को उनके इंटरसेप्ट दिखाने के लिए X = 0 तक पीछे विस्तारित किया गया है।

डिफ़ॉल्ट रूप से, [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) `NaN` लौटाता है, जो शून्य के बजाय एक अनिर्दिष्ट इंटरसेप्ट का प्रतिनिधित्व करता है। फिर इंटरसेप्ट डेटा से स्वतः गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

एक कस्टम लाइन वह शैप है जो चार्ट के ऊपर खींची जाती है, न कि सीरीज़ डेटा से गणना की गई ट्रेंड लाइन। यह उदाहरण [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) का उपयोग करके चार्ट के ऊपर स्लाइड में एक क्षैतिज लाइन जोड़ता है। लाइन की स्थिति स्लाइड निर्देशांक में पॉइंट्स में मापी गई है, इसलिए यह चार्ट के बाएँ किनारे से शुरू होती है और चार्ट के मध्य में स्थित होती है। इसकी चौड़ाई चार्ट की चौड़ाई के बराबर है। [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) लाइन को ठोस लाल रंग देती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंड लाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

यह ट्रेंड लाइन की आगे/पीछे की प्रोजेक्शन लंबाई है: स्कैटर (XY) चार्ट के लिए — एक्सिस इकाइयों में; गैर‑स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर‑नकारात्मक मान अनुमति प्राप्त हैं।

**क्या प्रस्तुति को PDF या SVG में निर्यात करते समय, या स्लाइड को इमेज के रूप में रेंडर करते समय ट्रेंड लाइन संरक्षित रहती है?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट्स को इमेज में रेंडर करता है; ट्रेंड लाइन्स, जो चार्ट का हिस्सा हैं, इन कार्यों के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जिससे सीधे [चार्ट की इमेज निर्यात](/slides/hi/nodejs-java/create-shape-thumbnails/) की जा सकती है।