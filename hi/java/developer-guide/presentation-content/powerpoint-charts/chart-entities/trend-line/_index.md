---
title: जावा में प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- घातांक ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- चल औसत ट्रेंड लाइन
- बहुपद ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- पावरपॉइंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ पावरपॉइंट चार्ट में जल्दी से ट्रेंड लाइन्स जोड़ें और अनुकूलित करें — आपका दर्शकों को जोड़ने के लिए एक व्यावहारिक मार्गदर्शिका।"
---
## **संक्षिप्त परिचय**

यह लेख बताता है कि Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स कैसे जोड़ी जाएँ। यह दिखाता है कि चार्ट कैसे बनाया जाए, चार्ट सीरीज में ट्रेंड लाइन्स कैसे जोड़ी जाएँ, और एक्स्पोनेन्शियल, लीनियर, लॉगरिदमिक, मूविंग एवरेज, पॉलीनोमियल और पॉवर सहित कई प्रकार की ट्रेंड लाइन्स के साथ कैसे काम किया जाए।

यह यह भी वर्णन करता है कि एक लाइन शेप डालकर चार्ट में कस्टम लाइन कैसे जोड़ी जाए और आगे‑पीछे ट्रेंडलाइन प्रोजेक्शन मानों तथा पीडीएफ या एसवीजी में निर्यात करते समय या चार्ट को चित्र के रूप में रेंडर करते समय ट्रेंड लाइन्स संरक्षित रहती हैं या नहीं, के बारे में एक छोटा FAQ शामिल करता है।

## **ट्रेंड लाइन जोड़ें**
Aspose.Slides for Java विभिन्न चार्ट ट्रेंड लाइन्स को प्रबंधित करने के लिए एक सरल API प्रदान करता है:

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
1. स्लाइड का संदर्भ उसके अनुक्रमांक द्वारा प्राप्त करें।
1. इच्छित प्रकार (इस उदाहरण में ChartType.ClusteredColumn) के साथ डिफ़ॉल्ट डेटा वाली एक चार्ट जोड़ें।
1. चार्ट सीरीज 1 के लिए एक्स्पोनेन्शियल ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज 1 के लिए लीनियर ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज 3 के लिए पॉलीनोमियल ट्रेंड लाइन जोड़ें।
1. चार्ट सीरीज 3 के लिए पॉवर ट्रेंड लाइन जोड़ें।
1. संशोधित प्रस्तुति को एक PPTX फ़ाइल में लिखें।

ट्रेंड लाइन्स के साथ चार्ट बनाने के लिए निम्नलिखित कोड उपयोग किया जाता है।

```java
// Presentation वर्ग का एक उदाहरण बनाएं
Presentation pres = new Presentation();
try {
    // क्लस्टर्ड कॉलम चार्ट बना रहे हैं
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // चार्ट सीरीज़ 1 के लिए एक्स्पोनेन्शियल ट्रेंड लाइन जोड़ रहे हैं
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // चार्ट सीरीज़ 1 के लिए लीनियर ट्रेंड लाइन जोड़ रहे हैं
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // चार्ट सीरीज़ 2 के लिए लॉगरिदमिक ट्रेंड लाइन जोड़ रहे हैं
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // चार्ट सीरीज़ 2 के लिए मूविंग एवरेज ट्रेंड लाइन जोड़ रहे हैं
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // चार्ट सीरीज़ 3 के लिए पॉलीनोमियल ट्रेंड लाइन जोड़ रहे हैं
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // चार्ट सीरीज़ 3 के लिए पावर ट्रेंड लाइन जोड़ रहे हैं
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // प्रस्तुति सहेज रहे हैं
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **कस्टम लाइन जोड़ें**
Aspose.Slides for Java चार्ट में कस्टम लाइन्स जोड़ने के लिए एक सरल API प्रदान करता है। प्रस्तुति की चयनित स्लाइड में एक साधारण सीधी लाइन जोड़ने के लिए नीचे दिए गए चरणों का पालन करें:

- [प्रस्तुति](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ
- स्लाइड का संदर्भ उसके अनुक्रमांक का उपयोग करके प्राप्त करें
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddChart मेथड से एक नया चार्ट बनाएँ
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड से लाइन प्रकार की एक AutoShape जोड़ें
- शेप की लाइनों का रंग सेट करें।
- संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

कस्टम लाइन्स के साथ चार्ट बनाने के लिए निम्नलिखित कोड उपयोग किया जाता है।

```java
// Presentation वर्ग का एक उदाहरण बनाएं
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

## **FAQ**

**'फ़ॉरवर्ड' और 'बैकवर्ड' ट्रेंडलाइन के लिए क्या अर्थ रखते हैं?**

वे ट्रेंडलाइन की उन लंबाइयों को दर्शाते हैं जो आगे/पीछे प्रोजेक्ट की गई हैं: स्कैटर (XY) चार्ट के लिए — अक्ष इकाइयों में; गैर‑स्कैटर चार्ट के लिए — श्रेणियों की संख्या में। केवल गैर‑नकारात्मक मान ही अनुमत हैं।

**क्या प्रस्तुति को PDF या SVG में निर्यात करते समय या स्लाइड को चित्र के रूप में रेंडर करते समय ट्रेंडलाइन बरकरार रहती है?**

हां। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/java/convert-powerpoint-to-pdf/)/[SVG](/slides/hi/java/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को चित्रों में रेंडर करता है; चार्ट का भाग होने के कारण ट्रेंडलाइन इन कार्यों के दौरान संरक्षित रहती है। एक मेथड भी उपलब्ध है जो स्वयं चार्ट की छवि को [एक्सपोर्ट](/slides/hi/java/create-shape-thumbnails/) कर सकता है।