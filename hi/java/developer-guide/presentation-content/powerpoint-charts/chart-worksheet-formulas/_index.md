---
title: जावा में प्रस्तुतियों में चार्ट वर्कशीट फ़ॉर्मूले लागू करें
linktitle: वर्कशीट फ़ॉर्मूले
type: docs
weight: 70
url: /hi/java/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट फ़ॉर्मूला
- वर्कशीट फ़ॉर्मूला
- स्प्रेडशीट फ़ॉर्मूला
- चार्ट डेटा वर्कबुक
- फ़ॉर्मूला गणना
- लॉजिकल स्थिरांक
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के चार्ट वर्कशीट में एक्सेल-स्टाइल फ़ॉर्मूले लागू करें, मानों को पुनः‑गणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एक एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Java में, आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुँच सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूला असाइन कर सकते हैं, समर्थित फ़ॉर्मूले की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला कार्यप्रवाह को समझाता है: चार्ट बनाना, उसकी वर्कशीट को भरना, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूले असाइन करना, उन्हें पुनः‑गणना करना, गणना किए गए मान पढ़ना, उन सेल्स को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति को सहेजना। इसमें समर्थित फ़ॉर्मूले की सिंटैक्स, निर्मित फ़ंक्शन उपसमुच्चय, कैश्ड वैल्यूज़, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का विवरण भी दिया गया है।

## **चार्ट वर्कशीट और फ़ॉर्मूले**

एक चार्ट वर्कशीट में वह श्रेणियाँ, सीरीज़ नाम, और मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![PowerPoint चार्ट जिसका एम्बेडेड वर्कशीट खुला है, जिसमें श्रेणी और सीरीज़ डेटा दिख रहा है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) इंटरफ़ेस के माध्यम से उजागर किया जाता है। A1‑स्टाइल फ़ॉर्मूले के लिए [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और R1C1‑स्टाइल फ़ॉर्मूले के लिए [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) का उपयोग करें। इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, समर्थित फ़ॉर्मूले को पुनः‑गणना करने और संबंधित सेल मानों को अपडेट करने के लिए [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

एक गणना किया गया सेल अभी भी अपने परिणाम को [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से उजागर करता है। यह तब महत्वपूर्ण होता है जब आपको कोड में फ़ॉर्मूला परिणाम का निरीक्षण करना हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **चार्ट बनाएं और वर्कशीट फ़ॉर्मूले गणना करें**

निम्न उदाहरण एक एंड‑टू‑एंड कार्यप्रवाह दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, सैंपल डेटा को साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फ़ॉर्मूले के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति को सहेजता है।

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

चार्ट डेटा पॉइंट्स `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनः‑गणना करें, फिर उन गणना किए गए सेल्स को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों और पंक्तियों को संख्याओं से पहचानती है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) के माध्यम से असाइन करें।

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

सामान्य A1 रेफ़रेंस रूप हैं:

| संदर्भ | सापेक्ष | पूर्ण | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष रेफ़रेंस स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूला को स्थानांतरित या कॉपी करने पर बदल सकते हैं। पूर्ण रेफ़रेंस दोनों निर्देशांक को स्थिर रखता है, जबकि मिश्रित रेफ़रेंस केवल पंक्ति या कॉलम को स्थिर करता है।

## **R1C1‑स्टाइल फ़ॉर्मूले उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्या के रूप में पहचानती है। सापेक्ष रेफ़रेंस वर्ग कोष्ठकों में ऑफसेट का उपयोग करते हैं। इस सिंटैक्स को [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) के माध्यम से असाइन करें।

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

सामान्य R1C1 रेफ़रेंस रूप हैं:

| संदर्भ | सापेक्ष | पूर्ण | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, `D2` सेल में, `RC[-2]` का अर्थ है समान पंक्ति में दो कॉलम बाएँ वाला सेल (`B2`)।

## **फ़ॉर्मूला स्थिरांक और ऑपरेटर**

निर्मित फ़ॉर्मूला इवैल्युएटर लॉजिकल मान, संख्यात्मक लिटरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर, और तुलना ऑपरेटर को सपोर्ट करता है।

### **स्थिरांक और लिटरल**

| प्रकार | उदाहरण | नोट |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | `A2=TRUE` जैसी लॉजिकल अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| संख्यात्मक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | फ़ॉर्मूला में स्ट्रिंग को दोहरे उद्धरण चिह्नों में घेरा जाता है। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | एक मान्य फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान दे सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
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
| `-` | घटाव या नकारात्मक | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम को स्पष्ट करने के लिए कोष्ठकों का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

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

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट के लिए एक निर्मित फ़ॉर्मूला इवैल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। प्रलेखित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शनों तक सीमित है। यह न मानें कि कोई भी यादृच्छिक Excel फ़ंक्शन [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) द्वारा पुनः‑गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | पूर्ण मान | `ABS(A2)` |
| `AVERAGE` | औसत | `AVERAGE(B2:B5)` |
| `CEILING` | ऊपर की ओर किसी मल्टिपल तक क्रमबद्ध करना | `CEILING(A2,5)` |
| `CHOOSE` | अनुक्रमांक द्वारा मान चुनना | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि मान बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाना | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट मान को दूसरे के भीतर ढूंढना | `FIND("-",A2)` |
| `FINDB` | बाइट‑आधारित टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को रेफ़रेंस रूप में प्रलेखित किया गया है, जबकि `LOOKUP` और `MATCH` उनके वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध न किए गए फ़ीचर और फ़ंक्शन Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माने जाने चाहिए, जब तक कि वे अलग से प्रलेखित न हों।

## **पुनः‑गणना और कैश्ड वैल्यूज़**

स्प्रेडशीट फ़ाइलें आमतौर पर फ़ॉर्मूला और उसके अंतिम गणना किए गए मान दोनों को संग्रहीत करती हैं। इसलिए Aspose.Slides प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा बदला न गया हो तो [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) से एक कैश्ड वैल्यू पढ़ सकता है।

इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, पुराने कैश्ड परिणाम पर भरोसा न करें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा सहेजने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

समर्थित उपसमुच्चय से बाहर के फ़ॉर्मूले के लिए, Aspose.Slides फ़ॉर्मूला को पार्स नहीं कर सकता या उसकी निर्भरताओं को स्थापित नहीं कर सकता। यदि वर्कबुक संशोधित की गई है, तो पहले का कैश्ड मान अब विश्वसनीय नहीं माना जा सकता। ऐसी स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellunsupporteddataexception/) उठ सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शनों पर निर्भर है जिन्हें Aspose.Slides इवैल्युएट नहीं करता, तो उन फ़ॉर्मूलों को किसी समर्थित स्प्रेडशीट इंजन से गणना करें और परिणाम मूल्य को चार्ट वर्कबुक में वापस लिखें। असमर्थित फ़ॉर्मूले को अनुमानित मानों से बदलें नहीं।

## **फ़ॉर्मूला त्रुटियों को संभालें**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक फ़ॉर्मूला मान्य हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` उत्पन्न कर सकता है। इस मामले में, त्रुटि टोकन एक सेल परिणाम है और इसे [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। इन मामलों के लिए Aspose.Slides स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः‑गणना और मान एक्सेस के आसपास इन अपवादों को संभालें:

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

चार्ट वर्कशीट में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिए अभिप्रेत है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन बंधनों को ध्यान में रखें:

- केवल प्रलेखित स्थिरांक, ऑपरेटर, रेफ़रेंस और फ़ंक्शन का उपयोग करें जब आपको Aspose.Slides द्वारा फ़ॉर्मूला पुनः‑गणना चाहिए।
- उन सेल्स को बदलने के बाद पुनः‑गणना करें जिन पर फ़ॉर्मूला परिणाम निर्भर करते हैं।
- लोड की गई प्रस्तुति से प्राप्त कैश्ड मानों को स्नैपशॉट मानें, संपादन के बाद पुनः‑गणना के विकल्प के रूप में नहीं।
- मौजूदा टेम्पलेट्स के फ़ॉर्मूले का उपयोग करने से पहले उनका परीक्षण करें, विशेषकर यदि वे प्रलेखित सूची के बाहर के फ़ंक्शन उपयोग करते हैं।
- उन फ़ॉर्मूलों के लिए जो पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता रखते हैं, बाहरी रूप से उन्हें गणना करें और फिर चार्ट वर्कबुक को प्राप्त मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) में क्या अंतर है?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। वह नोटेशन चुनें जो आपके फ़ॉर्मूला उत्पन्न या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**क्या मुझे गणना के बाद सेल स्वयं पढ़ना चाहिए या उसका मान?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) एक [IChartDataCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/) लौटाता है। गणना के बाद, उस सेल की [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) विधि को कॉल करके गणना किया गया परिणाम प्राप्त करें।

**मुझे कब [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूले बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें। यह निर्मित इवैल्युएटर द्वारा समर्थित फ़ॉर्मूलों के मानों को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। निर्मित इवैल्युएटर फ़ंक्शन के प्रलेखित उपसमुच्चय को ही सपोर्ट करता है। सूची के बाहर के फ़ंक्शन को सही ढंग से पुनः‑गणना करने की अपेक्षा न करें। यदि पूर्ण Excel फ़ॉर्मूला संगतता आवश्यक है, तो गणना को उचित स्प्रेडशीट इंजन से करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया हुआ कैश्ड मान मौजूद हो सकता है। संबंधित डेटा में परिवर्तन होने पर वह कैश्ड मान अब मान्य नहीं रह सकता। ऐसी स्थिति में, जिस सेल का फ़ॉर्मूला संभाला नहीं जा सकता, उसे पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellunsupporteddataexception/) उठ सकता है।

**क्या फ़ॉर्मूला त्रुटि मान जावा अपवाद के समान हैं?**

नहीं। `#DIV/0!` जैसे परिणाम एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान होते हैं। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellcircularreferenceexception/) जैसे अपवाद संकेत देते हैं कि फ़ॉर्मूला सामान्य रूप से प्रोसेस नहीं हो सका।

**क्या फ़ॉर्मूला सेल बदलने पर चार्ट स्वतः अपडेट हो जाता है?**

एक चार्ट सीरीज़ वर्कबुक सेल्स को संदर्भित कर सकती है। पहले वर्कबुक को पुनः‑गणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट अपडेटेड सेल मानों का उपयोग करता है; इस कार्यप्रवाह के लिए अलग चार्ट‑रिफ्रेश विधि आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हां, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक से कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकन किए गए फ़ॉर्मूला उपसमुच्चय से संबंधित है। यह न मानें कि [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) किसी बाहरी XLSX फ़ाइल में यादृच्छिक फ़ॉर्मूलों की पूर्ण पुनः‑गणना करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूं जो किसी अन्य वर्कशीट या वर्कबुक को संदर्भित करते हैं?**

Excel‑स्टाइल रेफ़रेंस चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ उस फ़ॉर्मूले को सत्यापित करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले कार्यप्रवाहों के लिए, वर्कबुक को बाहरी रूप से गणना करें और समाधान मानों को फिर से चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण अभिव्यक्तियों को `B2-C2` या `SUM(B2:B5)` के रूप में बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न फ़ॉर्मूले API उदाहरणों के साथ सुसंगत रहते हैं।