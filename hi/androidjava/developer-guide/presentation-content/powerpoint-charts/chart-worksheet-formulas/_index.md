---
title: Android पर प्रस्तुतियों में चार्ट कार्यपत्रक फ़ॉर्मूले लागू करें
linktitle: कार्यपत्रक फ़ॉर्मूले
type: docs
weight: 70
url: /hi/androidjava/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट कार्यपत्रक
- चार्ट फ़ॉर्मूला
- कार्यपत्रक फ़ॉर्मूला
- स्प्रेडशीट फ़ॉर्मूला
- चार्ट डेटा वर्कबुक
- फ़ॉर्मूला गणना
- तार्किक कॉन्स्टैंट
- संख्यात्मक कॉन्स्टैंट
- स्ट्रिंग कॉन्स्टैंट
- त्रुटि कॉन्स्टैंट
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वनिर्धारित फ़ंक्शन
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java चार्ट कार्यपत्रकों के माध्यम से Excel-शैली के फ़ॉर्मूले लागू करें, मानों की पुनः गणना करें, और परिणामों का उपयोग PowerPoint चार्ट्स में करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Android via Java में, आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुंच सकते हैं, इनपुट मान लिख सकते हैं, कोशिकाओं को फ़ॉर्मूला असाइन कर सकते हैं, समर्थित फ़ॉर्मूलों की गणना कर सकते हैं, और गणना किए गए कोशिकाओं को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला कार्यप्रवाह को समझाता है: एक चार्ट बनाएं, उसकी वर्कशीट को भरें, A1-स्टाइल या R1C1-स्टाइल फ़ॉर्मूला असाइन करें, उन्हें पुनः गणना करें, गणना किए गए मान पढ़ें, उन कोशिकाओं को एक चार्ट सीरीज़ से जोड़ें, और प्रस्तुति सहेजें। यह समर्थित फ़ॉर्मूला सिंटैक्स, निर्मित फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट-विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट और फ़ॉर्मूले**

एक चार्ट वर्कशीट में वह श्रेणियाँ, श्रृंखला नाम, और मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा संपादक खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/) इंटरफ़ेस के माध्यम से उजागर किया जाता है। A1-स्टाइल फ़ॉर्मूलों के लिए [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और R1C1-स्टाइल फ़ॉर्मूलों के लिए [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) का उपयोग करें। इनपुट कोशिकाओं या फ़ॉर्मूलों को बदलने के बाद, समर्थित फ़ॉर्मूलों को पुनः गणना करने और संबंधित कोशिका मानों को अपडेट करने के लिए [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

गणना की गई कोशिका अभी भी अपने परिणाम को [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से उजागर करती है। यह तब महत्वपूर्ण होता है जब आपको कोड में फ़ॉर्मूला परिणाम की जाँच करनी हो या कोशिका को चार्ट डेटा बिंदु के रूप में उपयोग करना हो।

## **चार्ट बनाएं और वर्कशीट फ़ॉर्मूले गणना करें**

निम्नलिखित उदाहरण एक एन्ड-टू-एन्ड कार्यप्रवाह प्रदर्शित करता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फ़ॉर्मूलों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए कोशिकाओं को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

चार्ट डेटा बिंदु `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट-रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनः गणना करें, फिर उन गणना किए गए कोशिकाओं को संदर्भित करने वाले चार्ट डेटा का उपयोग या सहेजें।

## **A1-स्टाइल फ़ॉर्मूले उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों और पंक्तियों को संख्याओं से पहचानता है। [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) के माध्यम से A1-स्टाइल अभिव्यक्तियों को असाइन करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

सामान्य A1 संदर्भ रूप हैं:

| संदर्भ | रिलेटिव | एब्सॉल्यूट | मिक्स्ड |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव संदर्भ स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूला को स्थानांतरित या कॉपी करने पर बदल सकते हैं। एब्सॉल्यूट संदर्भ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिक्स्ड संदर्भ केवल पंक्ति या कॉलम को स्थिर करता है।

## **R1C1-स्टाइल फ़ॉर्मूले उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव संदर्भ वर्ग कोष्ठकों में ऑफसेट का उपयोग करते हैं। इस सिंटैक्स को [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) के माध्यम से असाइन करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

सामान्य R1C1 संदर्भ रूप हैं:

| संदर्भ | रिलेटिव | एब्सॉल्यूट | मिक्स्ड |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में, `RC[-2]` का अर्थ उसी पंक्ति में दो कॉलम बाएँ की कोशिका (`B2`) है।

## **फ़ॉर्मूला कॉन्स्टैंट और ऑपरेटर**

निर्मित फ़ॉर्मूला इवैल्युएटर लॉजिकल मान, संख्यात्मक लिटरेल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर, और तुलना ऑपरेटर को समर्थन देता है।

### **कॉन्स्टैंट और लिटरेल**

| प्रकार | उदाहरण | नोट |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | `A2=TRUE` जैसे लॉजिकल अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| न्यूमेरिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | टेक्स्ट लिटरेल फ़ॉर्मूला के भीतर डबल कोट्स में रखे जाते हैं। |
| एरर रिजल्ट | `#DIV/0!`, `#N/A`, `#REF!` | एक वैध फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान दे सकता है। |

यह उदाहरण कई कॉन्स्टैंट प्रकारों का उपयोग करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // झूठा
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नेगेशन | `2-3`, `-3` |
| `*` | गुणन | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठक का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियां लॉजिकल मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित प्री-डिफाइन्ड फ़ंक्शन**

Aspose.Slides में चार्ट वर्कशीट के लिए एक निर्मित फ़ॉर्मूला इवैल्युएटर शामिल है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। प्रलेखित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शनों तक सीमित है। यह मानना अनुचित है कि कोई भी मनचाहा Excel फ़ंक्शन [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) द्वारा पुनः गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | एब्सॉल्यूट वैल्यू | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय औसत | `AVERAGE(B2:B5)` |
| `CEILING` | किसी संख्या को ऊपर की ओर निकटतम गुणज पर राउंड | `CEILING(A2,5)` |
| `CHOOSE` | इंडेक्स द्वारा मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि बनाएं | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाएं | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट-ओरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस फ़ॉर्म | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वैक्टर फ़ॉर्म | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वैक्टर फ़ॉर्म | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` रेफ़रेंस फ़ॉर्म में प्रलेखित है, जबकि `LOOKUP` और `MATCH` उनके वैक्टर फ़ॉर्म में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध नहीं किए गए फ़ीचर और फ़ंक्शन Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माने जाएँगे, जब तक वे अलग से प्रलेखित न हों।

## **पुनः गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर फ़ॉर्मूला और उसके अंतिम गणना किए गए मान दोनों को संग्रहीत करती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा में परिवर्तन न होने पर [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) से एक कैश्ड मान पढ़ सकता है।

इनपुट कोशिकाओं या फ़ॉर्मूलों को बदलने के बाद, पुराने कैश्ड परिणाम पर निर्भर न रहें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा सहेजने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फ़ॉर्मूलों के लिए, Aspose.Slides फ़ॉर्मूला को पार्स करने या उसकी निर्भरताएं स्थापित करने में असमर्थ हो सकता है। यदि वर्कबुक संशोधित की गई है, तो पहले का कैश्ड मान अब विश्वसनीय नहीं रहता। ऐसी स्थिति में, असमर्थित डेटा वाली कोशिका का मान पढ़ना [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellunsupporteddataexception/) उत्पन्न कर सकता है।

यदि आपका चार्ट ऐसी Excel फ़ंक्शन पर निर्भर है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ॉर्मूलों को किसी समर्थन करने वाले स्प्रेडशीट इंजन से गणना करें और परिणामी मान वापस चार्ट वर्कबुक में लिखें। असमर्थित फ़ॉर्मूलों को अनुमानित मानों से प्रतिस्थापित न करें।

## **फ़ॉर्मूला त्रुटियों का हैंडलिंग**

दो प्रकार की समस्याओं को अलग करना आवश्यक है।

फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम दे सकता है जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!`। इस मामले में त्रुटि टोकन एक कोशिका परिणाम है और इसे [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से वापस किया जा सकता है।

फ़ॉर्मूला पार्सिंग, संदर्भ, निर्भरताओं, या समर्थित डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट-विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः गणना और मान अभिगम के आसपास इन अपवादों को संभालें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिए है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- केवल दस्तावेज़ित कॉन्स्टैंट, ऑपरेटर, रेफ़रेंसेज़, और फ़ंक्शन उपयोग करें जब आप चाहते हैं कि Aspose.Slides फ़ॉर्मूलों को पुनः गणना करे।
- उन कोशिकाओं को बदलने के बाद पुनः गणना करें जिन पर फ़ॉर्मूला परिणाम निर्भर करता है।
- लोड किए गए प्रस्तुतियों से प्राप्त कैश्ड मान को स्नैपशॉट मानें, संपादन के बाद पुनः गणना का विकल्प न समझें।
- मौजूदा टेम्पलेट से फ़ॉर्मूलों का परीक्षण करें ताकि उनके गणना किए गए मानों पर भरोसा किया जा सके, विशेषकर जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन का उपयोग करते हों।
- उन फ़ॉर्मूलों के लिए जो पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता रखते हैं, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणामी मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) में क्या अंतर है?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1-स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1-स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। उस नोटेशन का उपयोग करें जो आपके फ़ॉर्मूले उत्पन्न या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**गणना के बाद मुझे स्वयं कोशिका पढ़नी चाहिए या उसका मान?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) एक [IChartDataCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/) लौटाता है। गणना के बाद उस कोशिका के [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) मेथड को कॉल करके गणना किया गया परिणाम प्राप्त करें।

**मुझे कब [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूले बदलने के बाद और गणना किए गए परिणाम पर निर्भर होने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) कॉल करें। यह निर्मित इवैल्युएटर द्वारा समर्थित फ़ॉर्मूलों के मान को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। निर्मित इवैल्युएटर फ़ंक्शन के एक प्रलेखित उपसमुच्चय का समर्थन करता है। उस उपसमुच्चय से बाहर के फ़ंक्शन मान लें कि सही ढंग से पुनः गणना नहीं होंगे। यदि पूरी Excel फ़ॉर्मूला संगतता आवश्यक है, तो उपयुक्त स्प्रेडशीट इंजन से गणना करें और अंतिम मान चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में एक असमर्थित फ़ॉर्मूला है तो क्या होगा?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान मौजूद हो सकता है। संबंधित डेटा संशोधित करने के बाद वह कैश्ड मान अब वैध नहीं रह सकता। ऐसी फ़ॉर्मूला वाली कोशिका तक पहुंचना [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellunsupporteddataexception/) उत्पन्न कर सकता है।

**क्या फ़ॉर्मूला त्रुटि मान Java अपवादों के समान हैं?**

नहीं। `#DIV/0!` जैसा परिणाम एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellcircularreferenceexception/) जैसे अपवाद संकेत देते हैं कि फ़ॉर्मूले को सामान्य रूप से प्रोसेस नहीं किया जा सका।

**क्या फ़ॉर्मूला कोशिका बदलने पर चार्ट स्वचालित रूप से अपडेट होता है?**

एक चार्ट श्रृंखला वर्कबुक कोशिकाओं को संदर्भित कर सकती है। पहले वर्कबुक को पुनः गणना करें, फिर प्रस्तुति सहेजें या रेंडर करें। यदि चार्ट डेटा बिंदु गणना की गई कोशिकाओं को संदर्भित करते हैं, तो चार्ट उन अद्यतन मानों का उपयोग करता है; इस कार्यप्रवाह के लिए कोई अलग चार्ट-रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हां, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक उपयोग करने के लिए कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसमुच्चय पर केंद्रित है। यह मानना अनुचित है कि [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) बाहरी XLSX फ़ाइल में मनचाहे फ़ॉर्मूलों की पूर्ण पुनः गणना प्रदान करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को रेफ़रेंस करते हों?**

Excel-स्टाइल रेफ़रेंस चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस-शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ सटीक फ़ॉर्मूला को सत्यापित करें। उन कार्यप्रवाहों के लिए जो व्यापक Excel रेफ़रेंस संगतता की मांग करते हैं, वर्कबुक को बाहरी रूप से गणना करें और परिणामी मानों को चार्ट डेटा में वापस लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू करना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न फ़ॉर्मूले दस्तावेज़ित API उदाहरणों के साथ सुसंगत रहते हैं।