---
title: PPTX में चार्ट आकार बदलने के लिए कार्यशील समाधान
type: docs
weight: 40
url: /hi/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- एक्सेल चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करना
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करने पर PPTX में अनपेक्षित चार्ट आकार बदलने को ठीक करें। चार्ट और OLE फ्रेम के आकार को सुसंगत रखने के लिए निश्चित चार्ट आयाम सेट करें।"
---
## **अवलोकन**

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुतियों में OLE वस्तुओं के रूप में एम्बेड किए गए Excel चार्ट पहली बार सक्रिय होने के बाद आकार बदल सकते हैं। इससे सक्रिय करने से पहले और बाद चार्ट की उपस्थिति में स्पष्ट अंतर हो सकता है। यह लेख बताता है कि आकार बदलना क्यों होता है और इसे कैसे रोका जाए, इसके लिए निश्चित चार्ट आयामों को OLE फ्रेम से मिलान करके।

In [प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel चार्ट बनाना](/slides/hi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), हमने बताया कि कैसे Aspose.Cells for Node.js via Java के साथ Excel चार्ट बनाते हैं और Aspose.Slides for Node.js via Java के साथ PowerPoint प्रस्तुति में एम्बेड करते हैं। [ऑब्जेक्ट पूर्वावलोकन समस्या](/slides/hi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) को संबोधित करने के लिए, हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुतीकरण में, जब आप चार्ट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर दो बार क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। उपयोगकर्ता एम्बेड किए गए Excel वर्कबुक को संपादित कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस जा सकते हैं। जब उपयोगकर्ता स्लाइड पर वापस आता है तो OLE ऑब्जेक्ट फ्रेम का आकार बदल जाता है, और री‑साइज़िंग कारक दोनों OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के मूल आकारों पर निर्भर करता है।

## **आकार बदलने का कारण**

एम्बेडेड Excel वर्कबुक की अपनी विंडो आयाम होते हैं, जिन्हें Excel पहली बार ऑब्जेक्ट सक्रिय होने पर बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम के अपने अलग परिभाषित आयाम होते हैं। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint एम्बेडिंग प्रक्रिया के हिस्से के रूप में ऑब्जेक्ट के अनुपात को बनाए रखने के लिए आकार पर बातचीत करते हैं। वर्कबुक विंडो और OLE फ्रेम के बीच अंतर ऑब्जेक्ट के आकार बदलने का कारण बन सकता है।

## **कार्यशील समाधान**

चार्ट के आकार को स्लाइड पर OLE फ्रेम के आकार से मिलाएँ और चार्ट के आयामों को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्प्लेट दोनों के साथ काम करता है।

उदाहरण में Aspose.Cells for Node.js via Java और Aspose.Slides for Node.js via Java की आवश्यकता होती है। `aspose.cells`, `aspose.slides.via.java`, और `java` Node.js पैकेज स्थापित करें। नीचे दिए गए दो CommonJS स्क्रिप्टों को अलग-अलग Node.js प्रक्रियाओं में, समान कार्यशील निर्देशिका का उपयोग करके चलाएँ, क्योंकि दोनों Aspose पैकेज लोड होते समय Java ब्रिज को प्रारंभ करते हैं। यह सक्रिय चार्ट शीट पर एक सरल कॉलम चार्ट बनाता है और वर्कबुक को XLS स्वरूप में एम्बेड करता है। कोई चार्ट पूर्वावलोकन छवि निर्धारित नहीं की गई है; चार्ट PowerPoint में OLE ऑब्जेक्ट सक्रिय होने पर दिखाई देता है।

उदाहरण 9.5 × 4 इंच के OLE फ्रेम के साथ एक नई प्रस्तुति बनाता है, जो बाएँ किनारे से 0.5 इंच और ऊपर से 1 इंच की दूरी पर स्थित है। स्लाइड समन्वय और आयाम पॉइंट में होते हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [टेम्प्लेट का उपयोग करें](#use-a-template)।

## **एक निश्चित चार्ट आकार निर्धारित करें**

सेट [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) को false करें ताकि चार्ट के आयाम वर्कबुक विंडो से स्वतंत्र रहें। सेट [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) के आयाम को [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) और [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight) के माध्यम से, 96 पिक्सेल प्रति इंच का उपयोग करके पॉइंट को पिक्सेल में बदलते हुए: 684 × 288 पॉइंट के फ्रेम का मतलब 912 × 384 पिक्सेल का चार्ट है। सेट [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) को `PrintSizeType` के CUSTOM मान पर सेट करें। उदाहरण कार्यपत्र को [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) के साथ एम्बेड करता है और 9.5 × 4‑इंच के OLE फ्रेम के साथ प्रस्तुति को सहेजता है।

इस पहले स्क्रिप्ट को `create-fixed-chart.js` के रूप में सहेजें। यह `chart-fixed-size.xls` बनाता है जिसमें 912 × 384 पिक्सेल का चार्ट होता है, जो दूसरे स्क्रिप्ट द्वारा उपयोग किए गए 684 × 288‑पॉइंट फ्रेम से मेल खाता है। कोई इनपुट कार्यपत्र आवश्यक नहीं है।

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // OLE फ्रेम के आयाम बिंदुओं में मिलाएँ (प्रति इंच 72 बिंदु)।
    const width = 684; // 9.5 इंच।
    const height = 288; // 4 इंच।

    chart.setSizeWithWindow(false);
    // बिंदुओं को चार्ट पिक्सेल में बदलें, 96 पिक्सेल प्रति इंच का उपयोग करके।
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// सभी सिंक्रोनस कार्य पूर्ण हो चुके हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

दूसरे स्क्रिप्ट को `embed-fixed-chart.js` के रूप में सहेजें और इसे `create-fixed-chart.js` के बाद चलाएँ। यह उत्पन्न XLS कार्यपत्र को पढ़ता है और `chart-fixed-size.pptx` सहेजता है। Java ब्रिज को कार्यपत्र डेटा के लिए स्पष्ट Java बाइट एरे और फ्रेम समन्वय एवं आयामों के लिए Java फ्लोट मानों की आवश्यकता होती है। `xls` एक्सटेंशन कार्यपत्र के सहेजे गए स्वरूप से मेल खाता है।

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // स्लाइड निर्देशांक और आयाम बिंदुओं में हैं (प्रति इंच 72 बिंदु)।
    const width = 684; // 9.5 इंच।
    const height = 288; // 4 इंच।
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// सभी सिंक्रोनस कार्य पूर्ण हो चुके हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

## **टेम्प्लेट का उपयोग करें**

मौजूदा प्रस्तुति के लिए आकार निर्धारण तर्क समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाने के बजाय टेम्प्लेट प्रस्तुति को लोड करें।  
2. जाँचें कि पहली स्लाइड में कम से कम तीन शैलियाँ हों, फिर इंडेक्स 2 पर मौजूद शैलियों को प्लेसहोल्डर के रूप में उपयोग करें।  
3. फ्रेम की चौड़ाई और ऊँचाई को उस शैलियों से लें, स्थिर मान 684 और 288 के बजाय। कार्यपत्र‑निर्माण स्क्रिप्ट में वही आयाम उपयोग करें, आकार गणना को बिना बदले रखें, और एम्बेड करने से पहले XLS कार्यपत्र को पुनः उत्पन्न करें।  
4. स्थिर कोऑर्डिनेट 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें।  
5. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में सक्रिय करने के बाद मेरा एम्बेडेड Excel चार्ट आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel पहली बार सक्रिय होने पर मूल विंडो आकार को पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम के अपने आयाम होते हैं। PowerPoint और Excel अनुपात बनाए रखने के लिए आकार पर बातचीत करते हैं, जिससे री‑साइज़िंग हो सकती है।

**मैं चार्ट और OLE फ्रेम के आकार को निरंतर कैसे रखूँ?**

OLE फ्रेम से मिलते‑जुलते निश्चित चार्ट आयाम सेट करें और कार्यपत्र को एम्बेड करने से पहले कस्टम चार्ट प्रिंट आकार का उपयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और इकाई रूपांतरण दिखाता है।

**क्या केवल कार्यपत्र विंडो आकार को मिलाना पर्याप्त है?**

केवल कार्यपत्र विंडो आकार को मिलाने से सक्रियकरण के बाद OLE फ्रेम के आकार बदलने को विश्वसनीय रूप से रोका नहीं जा सकता। उदाहरण में दिखाए अनुसार निश्चित चार्ट आयाम उपयोग करें।

**क्या यह समाधान टेम्प्लेट‑आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों के साथ काम करता है?**

हां। टेम्प्लेट के लिए, प्लेसहोल्डर के आयाम और स्थिति उपयोग करें। नई प्रस्तुति के लिए, फ्रेम के आयाम और स्थिति सीधे निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्रामों में बनाए गए चार्ट के साथ उपयोग कर सकता हूं?**

यह उदाहरण Aspose.Cells से बनाए गए Excel कार्यपत्र का उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्रामों के लिए सक्रियकरण व्यवहार को नहीं दिखाता।

## **संबंधित अनुभाग**

- [प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel चार्ट बनाना](/slides/hi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)