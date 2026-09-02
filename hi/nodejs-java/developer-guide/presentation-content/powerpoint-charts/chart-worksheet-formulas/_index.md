---
title: प्रेज़ेंटेशन में जावास्क्रिप्ट का उपयोग करके चार्ट वर्कशीट फ़ॉर्मूले लागू करें
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
- पसंदीदा संस्कृति
- संस्कृति-विशिष्ट फ़ॉर्मूला
- DBCS
- तार्किक स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलनात्मक ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वनिर्धारित फ़ंक्शन
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के लिए जावा चार्ट वर्कशीट्स के माध्यम से एक्सेल-शैली फ़ॉर्मूले लागू करें, मानों को पुनः गणना करें, और परिणामों को PowerPoint चार्ट्स में उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एम्बेडेड वर्कशीट में संग्रहित करते हैं। Aspose.Slides for Node.js via Java में आप इस वर्कशीट तक चार्ट डेटा वर्कबुक के माध्यम से पहुंच सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूले असाइन कर सकते हैं, समर्थित फ़ॉर्मूले गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख संपूर्ण फ़ॉर्मूला वर्कफ़्लो को समझाता है: एक चार्ट बनाना, उसकी वर्कशीट को भरना, A1-शैली या R1C1-शैली के फ़ॉर्मूले असाइन करना, उन्हें पुनः गणना करना, गणना किए गए मान पढ़ना, उन सेल्स को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति को सहेजना। यह समर्थित फ़ॉर्मूला सिंटैक्स, निर्मित फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट्स और फ़ॉर्मूले**

एक चार्ट वर्कशीट में वह श्रेणियाँ, श्रृंखला नाम, और मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में आप चार्ट डेटा एडिटर खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![एंबेडेड वर्कशीट के साथ खुला PowerPoint चार्ट, जिसमें वर्गीकरण और श्रृंखला डेटा दिखाया गया है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) क्लास के माध्यम से उजागर किया जाता है। A1-शैली फ़ॉर्मूले के लिए [ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) और R1C1-शैली फ़ॉर्मूले के लिए [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) का उपयोग करें। इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, समर्थित फ़ॉर्मूले पुनः गणना करने और संबंधित सेल मान अपडेट करने के लिए [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करें।

एक गणना किया गया सेल अभी भी अपने परिणाम को [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) के माध्यम से उजागर करता है। यह उस समय महत्वपूर्ण है जब आपको कोड में फ़ॉर्मूला परिणाम का निरीक्षण करना हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाएं और वर्कशीट फ़ॉर्मूले गणना करें**

निम्न उदाहरण एक एंड‑टू‑एंड वर्कफ़्लो दिखाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फ़ॉर्मूले के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मान के रूप में उपयोग करता है, और प्रस्तुति को सहेजता है।

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

चार्ट डेटा पॉइंट्स `D2:D4` का संदर्भ देते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनः गणना करें, फिर गणना किए गए सेल्स को उपयोग या सहेजें।

## **A1‑शैली फ़ॉर्मूले उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचानता है। [ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) के माध्यम से A1‑शैली अभिव्यक्तियों को असाइन करें।

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

सामान्य A1 संदर्भ रूप हैं:

| संदर्भ | सापेक्ष | पूर्ण | मिश्रित |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष संदर्भ स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूला को स्थानांतरित या कॉपी करने पर बदल सकते हैं। पूर्ण संदर्भ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित संदर्भ केवल पंक्ति या कॉलम को स्थिर करता है।

## **R1C1‑शैली फ़ॉर्मूले उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम को संख्यात्मक रूप से पहचानता है। सापेक्ष संदर्भ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करता है। इस सिंटैक्स को [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) के माध्यम से असाइन करें।

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

सामान्य R1C1 संदर्भ रूप हैं:

| संदर्भ | सापेक्ष | पूर्ण | मिश्रित |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में, `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ वाला सेल (`B2`)।

## **फ़ॉर्मूला कॉन्स्टेंट्स और ऑपरेटर्स**

निर्मित फ़ॉर्मूला इवैल्युएटर तार्किक मान, संख्यात्मक लिटेरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर्स, और तुलना ऑपरेटर्स का समर्थन करता है।

### **कॉन्स्टेंट्स और लिटेरल्स**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| Logical | `TRUE`, `FALSE` | `A2=TRUE` जैसे तार्किक अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| String | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटेरल्स को फ़ॉर्मूला के अंदर डबल कोट्स में encloses किया जाता है। |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | वैध फ़ॉर्मूला स्प्रेडशीट त्रुटि मान का परिणाम दे सकता है। |

यह उदाहरण कई कॉन्स्टेंट प्रकारों का उपयोग करता है:

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

### **गणितीय ऑपरेटर्स**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नेगेशन | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठकों का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलनात्मक ऑपरेटर्स**

तुलनात्मक अभिव्यक्तियां तार्किक मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट्स के लिए एक निर्मित फ़ॉर्मूला इवैल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ित फ़ंक्शन सेट नीचे की तालिका तक सीमित है। यह मानें कि कोई भी मनमाने Excel फ़ंक्शन को [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) द्वारा पुनः गणना नहीं किया जा सकता।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | पूर्ण मान | `ABS(A2)` |
| `AVERAGE` | अंकात्मक औसत | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर बहुगुणक पर गोल करें | `CEILING(A2,5)` |
| `CHOOSE` | इंडेक्स द्वारा मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मानों को जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मानों को जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग कर तिथि बनाएं | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाएं | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट मान को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | संदर्भ रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | लंबवत खोज | `VLOOKUP(A2,B2:D10,3,FALSE)` |

तालिका में दिखाए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को संदर्भ रूप में दस्तावेज़ित किया गया है, जबकि `LOOKUP` और `MATCH` को उनके वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहां सूचीबद्ध नहीं किए गए फ़ीचर और फ़ंक्शन को Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माना जाना चाहिए जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पसंदीदा संस्कृति के साथ फ़ॉर्मूले गणना करें**

कुछ चार्ट वर्कबुक फ़ंक्शन टेक्स्ट को संस्कृति‑विशिष्ट नियमों के अनुसार व्याख्या करते हैं। यह विशेष रूप से उन फ़ंक्शनों के लिए महत्वपूर्ण है जो दो‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिए हैं। ऐसे फ़ॉर्मूलों को सही ढंग से गणना करने के लिए, [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) बनाएं, [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) के साथ पसंदीदा संस्कृति सेट करें, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) के माध्यम से स्प्रेडशीट विकल्प असाइन करें, और फिर प्रस्तुति लोड करें।

निम्न उदाहरण जापानी संस्कृति का चयन करता है, कॉन्फ़िगर किए गए लोड विकल्पों के साथ प्रस्तुति खोलता है, और प्रत्येक चार्ट वर्कबुक के लिए [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करता है:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

पसंदीदा संस्कृति प्रस्तुति लोडिंग कॉन्फ़िगरेशन का हिस्सा है, इसलिए इसे [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस बनाने से पहले निर्दिष्ट करें। फ़ॉर्मूला द्वारा अपेक्षित संस्कृति का उपयोग करें; उदाहरण के लिए, जापानी DBCS गणना नियमों के लिए `ja-JP` का उपयोग करें।

## **पुनः गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर फ़ॉर्मूला और उसकी अंतिम गणना किए गए मान दोनों को संग्रहीत करती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा बदला न गया हो तो [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) से कैश्ड मान पढ़ सकता है।

इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, पुराने कैश्ड परिणाम पर भरोसा न करें। गणना किए गए मान पढ़ने या उनपर निर्भर चार्ट डेटा सहेजने से पहले [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फ़ॉर्मूलों के लिए, Aspose.Slides फ़ॉर्मूला को पार्स करने या उसकी निर्भरताओं को स्थापित करने में असमर्थ हो सकता है। यदि वर्कबुक संशोधित की गई है, तो पिछले कैश्ड मान अब विश्वसनीय नहीं माना जा सकता। ऐसी स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ना [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellunsupporteddataexception/) को उठा सकता है।

यदि आपका चार्ट उन Excel फ़ंक्शनों पर निर्भर करता है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ॉर्मूलों को ऐसे स्प्रेडशीट इंजन के साथ गणना करें जो उनका समर्थन करता हो और परिणामी मानों को चार्ट वर्कबुक में वापस लिखें। असमर्थित फ़ॉर्मूलों को अनुमानित मानों से बदलें नहीं।

## **फ़ॉर्मूला त्रुटियों को संभालें**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` दे सकता है। इस मामले में, त्रुटि टोकन एक सेल परिणाम होता है और इसे [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, संदर्भ, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः गणना और मान पहुंच के आसपास त्रुटियों को पकड़ें। त्रुटि विवरण नीचे स्प्रेडशीट समस्या को पहचानते हैं:

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

चार्ट वर्कशीट्स में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिए अभिप्रेत है, न कि पूर्ण Excel संगतता के लिए। इन प्रतिबंधों को रिपोर्टिंग वर्कफ़्लो डिजाइन करते समय ध्यान में रखें:

- जब आपको Aspose.Slides को फ़ॉर्मूले पुनः गणना करना हो, तो केवल दस्तावेज़ित कॉन्स्टेंट्स, ऑपरेटर्स, रेफ़रेंसेज़, और फ़ंक्शन का उपयोग करें।
- उन सेल्स को बदलने के बाद पुनः गणना करें जिन पर फ़ॉर्मूला परिणाम निर्भर करते हैं।
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड मानों को स्नैपशॉट मानें, संपादन के बाद पुनः गणना के विकल्प के रूप में नहीं।
- मौजूदा टेम्प्लेट से फ़ॉर्मूले का परीक्षण करें, विशेषकर जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन का उपयोग करते हैं।
- उन फ़ॉर्मूलों के लिए जिन्हें पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता होती है, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणामस्वरूप मानों से अपडेट करें।

## **FAQ**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) और [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) में क्या अंतर है?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) `B2-C2` जैसी A1‑शैली अभिव्यक्ति संग्रहीत करता है। [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) `RC[-2]-RC[-1]` जैसी R1C1‑शैली अभिव्यक्ति संग्रहीत करता है। उस नोटेशन का उपयोग करें जो आपके फ़ॉर्मूले जेनरेट या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**क्या मुझे गणना के बाद सेल स्वयं या उसका मान पढ़ना चाहिए?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) एक [ChartDataCell](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/) लौटाता है। गणना परिणाम प्राप्त करने के लिए, पुनः गणना के बाद उस सेल के [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatacell/#getValue--) मेथड को कॉल करें।

**मुझे कब [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूले बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) कॉल करें। यह निर्मित इवैल्युएटर द्वारा समर्थित फ़ॉर्मूलों के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। निर्मित इवैल्युएटर फ़ंक्शन का दस्तावेज़ित उपसमुच्चय ही समर्थन करता है। इस उपसमुच्चय के बाहर के फ़ंक्शन को सही ढंग से पुनः गणना माना नहीं जाना चाहिए। यदि पूर्ण Excel फ़ॉर्मूला संगतता आवश्यक है, तो उपयुक्त स्प्रेडशीट इंजन के साथ गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित फ़ॉर्मूला हो तो क्या होगा?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया हुआ कैश्ड मान रह सकता है। संबंधित डेटा संशोधित होने पर वह कैश्ड मान वैध नहीं रह सकता। ऐसी स्थिति में, असमर्थित फ़ॉर्मूला वाले सेल को एक्सेस करने पर [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellunsupporteddataexception/) उठ सकता है।

**क्या फ़ॉर्मूला त्रुटि मान अपवाद के समान होते हैं?**

नहीं। `#DIV/0!` जैसे परिणाम वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान होते हैं। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/cellcircularreferenceexception/) जैसी अपत्तियाँ दर्शाती हैं कि फ़ॉर्मूला सामान्य रूप से प्रोसेस नहीं हो सका।

**क्या फ़ॉर्मूला सेल बदलने पर चार्ट स्वचालित रूप से अपडेट होता है?**

एक चार्ट सीरीज़ वर्कबुक सेल्स को संदर्भित कर सकती है। पहले वर्कबुक को पुनः गणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट उन अद्यतन सेल मानों का उपयोग करता है; इस वर्कफ़्लो के लिए कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक उपयोग करने के लिए कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्यप्रवाह चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकन किए गए फ़ॉर्मूला उपसमुच्चय से संबंधित है। यह न मानें कि [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) बाहरी XLSX फ़ाइल में मनमाने फ़ॉर्मूलों की पूर्ण पुनः गणना प्रदान करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो अन्य वर्कशीट या वर्कबुक को संदर्भित करते हैं?**

Excel‑शैली के संदर्भ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट से सीमित है। यदि क्रॉस‑शीट या बाहरी संदर्भ आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ सटीक फ़ॉर्मूला सत्यापित करें। उन वर्कफ़्लो के लिए जो व्यापक Excel संदर्भ संगतता चाहते हैं, वर्कबुक को बाहरी रूप से गणना करें और समाधान मानों को चार्ट डेटा में वापस लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण अभिव्यक्तियों को `B2-C2` या `SUM(B2:B5)` बिना प्रारंभिक `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न फ़ॉर्मूला दस्तावेज़ित API उदाहरणों के साथ संगत रहते हैं।