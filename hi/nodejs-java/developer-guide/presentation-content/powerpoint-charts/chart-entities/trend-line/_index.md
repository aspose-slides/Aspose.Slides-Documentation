---
title: JavaScript में प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/nodejs-java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेंशियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरेज ट्रेंड लाइन
- पॉलीनोमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js via Java के साथ PowerPoint चार्ट में तेज़ी से ट्रेंड लाइन्स जोड़ें और कस्टमाइज़ करें — अपने दर्शकों को जोड़ने के लिए एक व्यावहारिक गाइड।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ने के तरीके को समझाता है। यह दिखाता है कि चार्ट कैसे बनाएं, चार्ट सीरीज़ में ट्रेंड लाइन्स जोड़ें, और एक्सपोनेंशियल, लीनियर, लॉगरिदमिक, मूविंग एवरेज, पॉलीनोमियल और पावर सहित कई ट्रेंड लाइन प्रकारों के साथ कैसे काम करें।

यह यह भी वर्णन करता है कि लाइन शेप डालकर चार्ट में कस्टम लाइन कैसे जोड़ें, और फॉरवर्ड और बैकवर्ड ट्रेंडलाइन प्रोजेक्शन मानों तथा PDF या SVG में निर्यात करते समय या चार्ट को छवि के रूप में रेंडर करते समय ट्रेंड लाइन्स संरक्षित रहती हैं या नहीं, के बारे में एक छोटा FAQ शामिल करता है।

## **ट्रेंड लाइन जोड़ें**

Aspose.Slides for Node.js via Java विभिन्न चार्ट ट्रेंड लाइन्स प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स द्वारा स्लाइड का रेफरेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें तथा इच्छित प्रकार (इस उदाहरण में ChartType.ClusteredColumn उपयोग किया गया है) चुनें।
1. चार्ट सीरीज़ 1 के लिए एक्सपोनेंशियल ट्रेंड लाइन जोड़ना।
1. चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ना।
1. चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ना।
1. चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ना।
1. चार्ट सीरीज़ 3 के लिए पॉलीनोमियल ट्रेंड लाइन जोड़ना।
1. चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ना।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```javascript
// Presentation वर्ग का एक इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation();
try {
    // क्लस्टर्ड कॉलम चार्ट बना रहे हैं
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // चार्ट सीरीज़ 1 के लिए एक्सपोनेंशियल ट्रेंड लाइन जोड़ना
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ना
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ना
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ना
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // चार्ट सीरीज़ 3 के लिए पॉलीनोमियल ट्रेंड लाइन जोड़ना
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ना
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // प्रस्तुति सहेज रहे हैं
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **कस्टम लाइन जोड़ें**

Aspose.Slides for Node.js via Java चार्ट में कस्टम लाइन्स जोड़ने के लिए एक सरल API प्रदान करता है। प्रस्तुति की चुनी हुई स्लाइड में एक साधारण सीधी लाइन जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं
- इंडेक्स का उपयोग करके स्लाइड का रेफरेंस प्राप्त करें
- Shapes ऑब्जेक्ट द्वारा प्रदर्शित AddChart मेथड का उपयोग करके नया चार्ट बनाएं
- Shapes ऑब्जेक्ट द्वारा प्रदर्शित AddAutoShape मेथड का उपयोग करके लाइन प्रकार का AutoShape जोड़ें
- शेप की लाइनों का रंग सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

```javascript
// Presentation वर्ग का एक इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **प्रश्नोत्तर**

**ट्रेंडलाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

ये ट्रेंडलाइन की फॉरवर्ड/बैकवर्ड प्रोजेक्शन की लंबाइयाँ हैं: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर-स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर-नकारात्मक मानों की अनुमति है।

**प्रेज़ेंटेशन को PDF या SVG में निर्यात करने पर, या स्लाइड को छवि के रूप में रेंडर करने पर, क्या ट्रेंडलाइन संरक्षित रहेगी?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; ट्रेंडलाइन, जो चार्ट का हिस्सा है, इन ऑपरेशनों के दौरान संरक्षित रहती है। एक मेथड भी उपलब्ध है जो चार्ट की छवि को [एक्सपोर्ट](/slides/hi/nodejs-java/create-shape-thumbnails/) करता है।