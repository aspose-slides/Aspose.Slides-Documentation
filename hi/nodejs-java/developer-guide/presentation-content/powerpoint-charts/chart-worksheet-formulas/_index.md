---
title: JavaScript का उपयोग करके प्रस्तुतियों में चार्ट वर्कशीट फ़ॉर्मूले लागू करें
linktitle: वर्कशीट फ़ॉर्मूले
type: docs
weight: 70
url: /hi/nodejs-java/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट फ़ॉर्मूला
- वर्कशीट फ़ॉर्मूला
- स्प्रेडशीट फ़ॉर्मूला
- चार्ट डेटा वर्कबुक
- फ़ॉर्मूला गणना
- तार्किक स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वनिर्धारित फ़ंक्शन
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में Java चार्ट वर्कशीट के माध्यम से Excel-शैली के फ़ॉर्मूले लागू करें, मानों को पुनः गणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपना स्रोत डेटा एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Node.js via Java में, आप उस वर्कशीट को चार्ट डेटा वर्कबुक के माध्यम से एक्सेस कर सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूले असाइन कर सकते हैं, समर्थित फ़ॉर्मूले की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला वर्कफ़्लो समझाता है: एक चार्ट बनाना, उसकी वर्कशीट भरना, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूले असाइन करना, उन्हें पुनःगणना करना, गणना किए गए मान पढ़ना, उन सेल्स को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति सहेजना। यह समर्थित फ़ॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट और फ़ॉर्मूले**

एक चार्ट वर्कशीट में उन श्रेणियों, सीरीज़ नामों, और मानों का समावेश होता है जो चार्ट द्वारा प्रयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![एम्बेडेड वर्कशीट खुली हुई PowerPoint चार्ट, जिसमें श्रेणी और श्रृंखला डेटा दिखाया गया है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) क्लास के माध्यम से एक्सपोज़ किया जाता है। A1‑स्टाइल फ़ॉर्मूले के लिए [ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) और R1C1‑स्टाइल फ़ॉर्मूले के लिए [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) का उपयोग करें। इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, समर्थित फ़ॉर्मूले को पुनःगणना करने और संबंधित सेल मानों को अपडेट करने के लिए [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करें।

गणना किया गया सेल अपना परिणाम अभी भी [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) के माध्यम से प्रकट करता है। यह तभी महत्वपूर्ण है जब आपको कोड में फ़ॉर्मूला परिणाम का निरीक्षण करना हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **चार्ट बनाना और वर्कशीट फ़ॉर्मूले गणना करना**

निम्न उदाहरण एक अंत‑से‑अंत वर्कफ़्लो दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, सैंपल डेटा को साफ़ करता है, तिमाही राजस्व और खर्च मान लिखता है, फ़ॉर्मूले के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति को सहेजता है।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों को उपयोग करता है। इस वर्कफ़्लो में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनःगणना करें, फिर गणना किए गए सेल्स को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले उपयोग करना**

A1 नोटेशन कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियाँ [ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) के माध्यम से असाइन करें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

आम A1 रेफरेंस रूप:

| संदर्भ | सापेक्ष | निरपेक्ष | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| स्तंभ | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष रेफरेंसेज़ को स्प्रेडशीट एप्लिकेशन में फ़ॉर्मूला को स्थानांतरित या कॉपी करने पर बदल सकता है। निरपेक्ष रेफरेंसेज़ दोनों निर्देशांक को स्थिर रखती हैं, जबकि मिश्रित रेफरेंसेज़ केवल पंक्ति या कॉलम को स्थिर करती हैं।

## **R1C1‑स्टाइल फ़ॉर्मूले उपयोग करना**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। सापेक्ष रेफरेंसेज़ को वर्ग कोष्ठकों में ऑफ़सेट द्वारा दर्शाया जाता है। इस सिंटैक्स को [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) के माध्यम से असाइन करें।

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

आम R1C1 रेफरेंस रूप:

| संदर्भ | सापेक्ष | निरपेक्ष | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| स्तंभ | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में, `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ वाला सेल (`B2`)।

## **फ़ॉर्मूला स्थिरांक और ऑपरेटर**

बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर तर्कात्मक मान, संख्यात्मक लिटरेल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर, और तुलना ऑपरेटर का समर्थन करता है।

### **स्थिरांक और लिटरेल**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| तर्कात्मक | `TRUE`, `FALSE` | `A2=TRUE` जैसी तर्कात्मक अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| संख्यात्मक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक संकेतन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरेल को फ़ॉर्मूला के भीतर डबल कोट्स में रखा जाता है। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | वैध फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान दे सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या निगेटिव | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घात | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठक प्रयोग करें, उदाहरण स्वरूप `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियों के परिणाम तर्कात्मक होते हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट के लिए एक बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शनों तक सीमित है। यह मानें नहीं कि कोई भी Excel फ़ंक्शन [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) द्वारा पुनःगणना किया जाएगा।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | निरपेक्ष मान | `ABS(A2)` |
| `AVERAGE` | औसत | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की बहुता तक राउंड | `CEILING(A2,5)` |
| `CHOOSE` | इंडेक्स द्वारा मान चुनना | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 डेट सिस्टम का उपयोग करके तिथि बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिन गिनना | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे में खोजना | `FIND("-",A2)` |
| `FINDB` | बाइट‑उन्मुख टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफरेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` रेफरेंस रूप में दस्तावेज़ित है, जबकि `LOOKUP` और `MATCH` उनके वेक्टर रूप में। `DATE` 1900 डेट सिस्टम का उपयोग करता है। यहाँ नहीं सूचीबद्ध विशेषताएँ और फ़ंक्शन Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माने जाने चाहिए जब तक कि वे अलग से प्रलेखित न हों।

## **पुनःगणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर एक फ़ॉर्मूला और उसका अंतिम गणना किया गया मान दोनों संग्रहीत करती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा बदला न गया हो तो [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) से एक कैश्ड मान पढ़ सकता है।

इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, पुराने कैश्ड परिणाम पर भरोसा न रखें। गणना किए गए मान पढ़ने या उन पर निर्भर रहने से पहले [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फ़ॉर्मूले के लिए, Aspose.Slides फ़ॉर्मूला को पार्स करने या उसकी निर्भरताओं को स्थापित करने में असमर्थ हो सकता है। यदि वर्कबुक संशोधित की गई है, तो पूर्व कैश्ड मान अब विश्वसनीय नहीं रहेगा। इस स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ने पर [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellunsupporteddataexception/) उठाया जा सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शन पर निर्भर करता है जिन्हें Aspose.Slides मूल्यांकित नहीं करता, तो उन फ़ॉर्मूलों को किसी ऐसे स्प्रेडशीट इंजन से गणना करें जो उनका समर्थन करता हो और परिणामित मानों को चार्ट वर्कबुक में लिखें। असमर्थित फ़ॉर्मूलों को अनुमानित मानों से बदलना न करें।

## **फ़ॉर्मूला त्रुटियों को संभालना**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम दे सकता है, जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!`। इस मामले में त्रुटि टोकन एक सेल परिणाम है और इसे [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, रेफरेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। इन मामलों के लिए Aspose.Slides स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनःगणना और मान पहुँच के आसपास त्रुटियों को पकड़ें। त्रुटि विवरण आधारभूत स्प्रेडशीट समस्या की पहचान करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिए निर्धारित है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग वर्कफ़्लो डिजाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- दस्तावेज़ित स्थिरांक, ऑपरेटर, रेफरेंस और फ़ंक्शन ही उपयोग करें जब आप चाहते हैं कि Aspose.Slides फ़ॉर्मूले पुनःगणना करे।
- उन सेल्स को बदलने के बाद पुनःगणना करें जिन पर फ़ॉर्मूला परिणाम निर्भर करता है।
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड मान केवल स्नैपशॉट हैं, संपादन के बाद पुनःगणना का विकल्प नहीं।
- मौजूदा टेम्पलेट से फ़ॉर्मूले का परीक्षण करें, विशेषकर जब वे दस्तावेज़ित सूची के बाहर के फ़ंक्शन उपयोग करते हों।
- पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता वाले फ़ॉर्मूले को बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को अद्यतन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) और [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) में क्या अंतर है?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` को संग्रहीत करता है। [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` को संग्रहीत करता है। वह नोटेशन चुनें जो आपके फ़ॉर्मूले जेनरेशन या कॉपी करने के तरीके से बेहतर मेल खाता हो।

**पुनःगणना के बाद क्या मुझे सेल खुद पढ़ना चाहिए या उसका मान?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) एक [ChartDataCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/) लौटाता है। गणना के बाद, उस सेल के [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) मेथड को कॉल करके गणना परिणाम प्राप्त करें।

**किस स्थिति में मुझे [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूले बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित फ़ॉर्मूले के मानों को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर दस्तावेज़ित फ़ंक्शन उपसमुच्चय का समर्थन करता है। उस उपसमुच्चय के बाहर के फ़ंक्शन को सही ढंग से पुनःगणना किया जाएगा, इसका अनुमान न लगाएँ। यदि पूर्ण Excel फ़ॉर्मूला संगतता आवश्यक है, तो गणना को उपयुक्त स्प्रेडशीट इंजन से करवाएँ और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित फ़ॉर्मूला मौजूद हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला गया है, तो वर्कबुक में पहले से गणना किया हुआ कैश्ड मान रह सकता है। संबंधित डेटा बदलने पर वह कैश्ड मान अब वैध नहीं रहेगा। ऐसी स्थिति में, जिसमें फ़ॉर्मूला असमर्थित है, उस सेल को एक्सेस करने पर [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellunsupporteddataexception/) उठाया जा सकता है।

**क्या फ़ॉर्मूला त्रुटि मान अपवादों के समान होते हैं?**

नहीं। `#DIV/0!` जैसी त्रुटि मान वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellcircularreferenceexception/) जैसे अपवाद दर्शाते हैं कि फ़ॉर्मूले को सामान्य रूप से प्रोसेस नहीं किया जा सका।

**क्या फ़ॉर्मूला सेल बदलने पर चार्ट स्वचालित रूप से अपडेट होता है?**

चार्ट सीरीज़ वर्कबुक सेल्स को संदर्भित कर सकते हैं। पहले वर्कबुक को पुनःगणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट उन अपडेटेड मानों का उपयोग करता है; इस वर्कफ़्लो के लिए कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हां, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक इस्तेमाल करने के लिए कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना वर्कफ़्लो केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसमुच्चय से संबंधित है। यह मानें नहीं कि [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) किसी भी बाहरी XLSX फ़ाइल में सभी फ़ॉर्मूले की पूर्ण पुनःगणना प्रदान करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूं जो दूसरी वर्कशीट या वर्कबुक को संदर्भित करते हों?**

Excel‑स्टाइल रेफरेंसेज़ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफरेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ उस फ़ॉर्मूले को सत्यापित करें। व्यापक Excel रेफरेंस संगतता की आवश्यकता वाले वर्कफ़्लो के लिए, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से जेनरेट किए गए फ़ॉर्मूले दस्तावेज़ित API उदाहरणों के साथ संगत रहते हैं।