---
title: एंड्रॉइड पर प्रेजेंटेशन चार्ट में ट्रेंड लाइनों को जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/androidjava/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्स्पोनेन्शियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग एवरेज ट्रेंड लाइन
- पॉलीनोमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint चार्ट में तेजी से ट्रेंड लाइनों को जोड़ें और अनुकूलित करें — अपने दर्शकों को आकर्षित करने के लिए एक व्यावहारिक गाइड।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके प्रेजेंटेशन चार्ट में ट्रेंड लाइनों को जोड़ने के बारे में समझाता है। यह दिखाता है कि चार्ट कैसे बनाया जाए, चार्ट सीरीज़ में ट्रेंड लाइनों को कैसे जोड़ा जाए, और एक्स्पोनेन्शियल, लीनियर, लॉगरिदमिक, मूविंग एवरेज, पॉलीनोमियल और पॉवर सहित कई प्रकार की ट्रेंड लाइनों के साथ कैसे काम किया जाए।

यह यह भी बताता है कि एक लाइन आकार डालकर चार्ट में कस्टम लाइन कैसे जोड़ी जाए, और फ़ॉरवर्ड तथा बैकवर्ड ट्रेंडलाइन प्रोजेक्शन मानों और क्या ट्रेंड लाइनों को PDF या SVG में निर्यात करते समय या चार्ट को छवि के रूप में रेंडर करते समय संरक्षित रखा जाता है, इस पर एक छोटा FAQ शामिल करता है।

## **ट्रेंड लाइन जोड़ें**
Aspose.Slides for Android via Java विभिन्न चार्ट ट्रेंड लाइनों को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और इच्छित प्रकार में से कोई भी (इस उदाहरण में ChartType.ClusteredColumn का उपयोग किया गया है)।
4. चार्ट सीरीज़ 1 के लिए एक्स्पोनेन्शियल ट्रेंड लाइन जोड़ना।
5. चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ना।
6. चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ना।
7. चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ना।
8. चार्ट सीरीज़ 3 के लिए पॉलीनोमियल ट्रेंड लाइन जोड़ना।
9. चार्ट सीरीज़ 3 के लिए पॉवर ट्रेंड लाइन जोड़ना।
10. संसोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

निम्न कोड ट्रेंड लाइनों के साथ चार्ट बनाने के लिए उपयोग किया जाता है।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    // क्लस्टर्ड कॉलम चार्ट बनाना
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // चार्ट सीरीज़ 1 के लिए एक्स्पोनेन्शियल ट्रेंड लाइन जोड़ना
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ना
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ना
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ना
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // चार्ट सीरीज़ 3 के लिए पॉलीनोमियल ट्रेंड लाइन जोड़ना
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ना
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // प्रेजेंटेशन सहेजना
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **कस्टम लाइन जोड़ें**
Aspose.Slides for Android via Java चार्ट में कस्टम लाइनों को जोड़ने के लिए एक सरल API प्रदान करता है। प्रेजेंटेशन के चयनित स्लाइड में एक साधारण सीधी लाइन जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ
- उसका इंडेक्स उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddChart मेथड का उपयोग करके एक नया चार्ट बनाएँ
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके लाइन प्रकार की AutoShape जोड़ें
- आकार की लाइनों का रंग सेट करें।
- संसोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें

निम्न कोड कस्टम लाइनों के साथ चार्ट बनाने के लिए उपयोग किया जाता है।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सामान्य प्रश्न**

**ट्रेंडलाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

These are the lengths of the trendline projected forward/backward: for scatter (XY) charts — in axis units; for non‑scatter charts — in number of categories. Only non‑negative values are allowed.

**क्या प्रेजेंटेशन को PDF या SVG में निर्यात करते समय या स्लाइड को छवि के रूप में रेंडर करते समय ट्रेंडलाइन संरक्षित रहती है?**

Yes. Aspose.Slides प्रेजेंटेशन को [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/) में बदलता है और चार्ट को छवियों में रेंडर करता है; ट्रेंडलाइन, जो चार्ट का हिस्सा है, इन ऑपरेशनों के दौरान संरक्षित रहती है। एक मेथड भी उपलब्ध है जो चार्ट की खुद की छवि को [export an image of the chart](/slides/hi/androidjava/create-shape-thumbnails/) कर सकती है।