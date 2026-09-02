---
title: Android पर प्रस्तुतियों में चार्ट वर्कशीट सूत्र लागू करें
linktitle: वर्कशीट सूत्र
type: docs
weight: 70
url: /hi/androidjava/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट सूत्र
- वर्कशीट सूत्र
- स्प्रेडशीट सूत्र
- चार्ट डेटा वर्कबुक
- सूत्र गणना
- पसंदीदा संस्कृति
- संस्कृति-विशिष्ट सूत्र
- DBCS
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java चार्ट वर्कशीट में Excel-शैली के सूत्र लागू करें, मानों को पुनर्गणना करें, और PowerPoint चार्ट में परिणामों का उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एक एंबेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Android via Java में आप उस वर्कशीट को चार्ट डेटा वर्कबुक के माध्यम से एक्सेस कर सकते हैं, इनपुट मान लिख सकते हैं, कोशिकाओं को सूत्र (फ़ॉर्मूला) असाइन कर सकते हैं, समर्थित सूत्रों की गणना कर सकते हैं, और गणना की गई कोशिकाओं को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण सूत्र कार्यप्रवाह को समझाता है: एक चार्ट बनाएं, उसकी वर्कशीट को भरें, A1‑स्टाइल या R1C1‑स्टाइल सूत्र असाइन करें, उन्हें पुनःगणना करें, गणना किए गए मान पढ़ें, उन कोशिकाओं को चार्ट सीरीज़ से जोड़ें, और प्रस्तुति सहेजें। यह समर्थित सूत्र सिंटैक्स, अंतर्निहित फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित सूत्र और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट और सूत्र**

एक चार्ट वर्कशीट में उन श्रेणियों, सीरीज़ नामों और मानों को संग्रहीत किया जाता है जो चार्ट द्वारा प्रयुक्त होते हैं। PowerPoint में आप चार्ट डेटा एडिटर खोलकर वर्कशीट को निरीक्षण कर सकते हैं:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/) इंटरफ़ेस के माध्यम से एक्सपोज़ किया जाता है। A1‑स्टाइल सूत्रों के लिए [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और R1C1‑स्टाइल सूत्रों के लिए [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) का उपयोग करें। इनपुट कोशिकाओं या सूत्रों को बदलने के बाद, समर्थित सूत्रों को पुनःगणना करने और संबंधित कोशिका मानों को अपडेट करने के लिए [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

गणना की गई कोशिका अभी भी अपना परिणाम [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से एक्सपोज़ करती है। यह तब महत्वपूर्ण होता है जब आपको कोड में सूत्र परिणाम की जांच करनी हो या कोशिका को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **चार्ट बनाएं और वर्कशीट सूत्रों की गणना करें**

निम्न उदाहरण एक पूर्‍ण कार्य‑प्रवाह दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, सूत्रों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना की गई कोशिकाओं को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

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

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्य‑प्रवाह में कोई अलग चार्ट‑रीफ़्रेश कॉल नहीं है: पहले वर्कबुक को पुनःगणना करें, फिर गणना की गई कोशिकाओं को उपयोग या सहेजें।

## **A1‑स्टाइल सूत्रों का उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) के माध्यम से असाइन करें।

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

आम A1 संदर्भ रूप नीचे दिए गए हैं:

| संदर्भ | रिलेटिव | एब्सोल्यूट | मिक्स्ड |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव रेफ़रेंसेज़ को फ़ॉर्मूला को स्प्रेडशीट एप्लिकेशन द्वारा स्थानांतरित या कॉपी करने पर बदल सकते हैं। एब्सोल्यूट रेफ़रेंसेज़ दोनों निर्देशांक को स्थिर रखती हैं, जबकि मिक्स्ड रेफ़रेंसेज़ केवल पंक्ति या कॉलम को स्थिर करती हैं।

## **R1C1‑स्टाइल सूत्रों का उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव रेफ़रेंसेज़ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करती हैं। इस सिंटैक्स को [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) के माध्यम से असाइन करें।

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

आम R1C1 संदर्भ रूप नीचे दिए गए हैं:

| संदर्भ | रिलेटिव | एब्सोल्यूट | मिक्स्ड |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में `RC[-2]` का अर्थ है समान पंक्ति में दो कॉलम बाईं ओर स्थित सेल (`B2`)।

## **सूत्र स्थिरांक और ऑपरेटर**

बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर लॉजिकल मान, संख्यात्मक लिटरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को सपोर्ट करता है।

### **स्थिरांक और लिटरल**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| Logical | `TRUE`, `FALSE` | `A2=TRUE` जैसी लॉजिकल अभिव्यक्तियों में सीधे उपयोग किए जा सकते हैं। |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| String | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरल फ़ॉर्मूला के भीतर डबल कोटेशन मार्क्स में बंद होते हैं। |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | एक वैध फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान पर मूल्यांकन हो सकता है। |

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // गलत
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

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठक प्रयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियों के परिणाम लॉजिकल मान होते हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | समान | `A2=3` |
| `<>` | असमान | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट के लिए एक बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ित फ़ंक्शन सेट नीचे सूचीबद्ध फ़ंक्शनों तक सीमित है। यह मान न लें कि कोई भी मनचाहा Excel फ़ंक्शन [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) द्वारा पुनःगणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | Absolute value | `ABS(A2)` |
| `AVERAGE` | Arithmetic mean | `AVERAGE(B2:B5)` |
| `CEILING` | Round a number upward to a multiple | `CEILING(A2,5)` |
| `CHOOSE` | Select a value by index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Join text values | `CONCAT(A2,B2)` |
| `CONCATENATE` | Join text values | `CONCATENATE(A2," ",B2)` |
| `DATE` | Create a date value using the 1900 date system | `DATE(2026,8,19)` |
| `DAYS` | Return the number of days between dates | `DAYS(B2,A2)` |
| `FIND` | Find one text value inside another | `FIND("-",A2)` |
| `FINDB` | Byte-oriented text search | `FINDB("a",A2)` |
| `IF` | Conditional result | `IF(A2>0,A2,0)` |
| `INDEX` | Reference form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum value | `MAX(B2:B5)` |
| `SUM` | Sum values | `SUM(B2:B5)` |
| `VLOOKUP` | Vertical lookup | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को रेफ़रेंस फ़ॉर्म में दस्तावेज़ित किया गया है, जबकि `LOOKUP` और `MATCH` को उनके वेक्टर फ़ॉर्म में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध न होने वाले फ़ंक्शन को Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माना जाना चाहिए, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पसंदीदा संस्कृति के साथ सूत्रों की गणना करें**

कुछ चार्ट वर्कबुक फ़ंक्शन टेक्स्ट को संस्कृति‑विशिष्ट नियमों के अनुसार व्याख्या करते हैं। यह विशेष रूप से उन फ़ंक्शनों के लिए महत्वपूर्ण है जो डबल‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिए हैं। ऐसे सूत्रों की सही गणना के लिए, [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) बनाएं, [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) के साथ पसंदीदा संस्कृति सेट करें, इस विकल्प को [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) के माध्यम से असाइन करें, और फिर प्रस्तुति को लोड करें।

निम्न उदाहरण जापानी संस्कृति को चुनता है, कॉन्फ़िगर किए गए लोड विकल्पों के साथ प्रस्तुति खोलता है, और प्रत्येक चार्ट वर्कबुक के लिए [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करता है:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

पसंदीदा संस्कृति प्रस्तुति लोड करने की कॉन्फ़िगरेशन का हिस्सा है, इसलिए इसे [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाने से पहले निर्दिष्ट करें। वर्कबुक सूत्रों के लिए अपेक्षित संस्कृति का उपयोग करें; उदाहरण के लिए, जापानी DBCS गणना नियमों के लिए `ja-JP` उपयोग करें।

## **पुनःगणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर एक सूत्र और उसका अंतिम गणना किया गया मान दोनों संग्रहीत करती हैं। Aspose.Slides प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा बदला न गया हो तो [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) से कैश्ड मान पढ़ सकता है।

इनपुट कोशिकाओं या सूत्रों को बदलने के बाद, पुरानी कैश्ड मान पर भरोसा न करें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा सहेजने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के सूत्रों के लिए, Aspose.Slides को सूत्र पार्स करने या उसकी निर्भरताओं को स्थापित करने में समस्या हो सकती है। यदि वर्कबुक को संशोधित किया गया है, तो पहले का कैश्ड मान अब विश्वसनीय नहीं माना जा सकता। ऐसी स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ने पर [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellunsupporteddataexception/) उत्पन्न हो सकता है।

यदि आपके चार्ट को ऐसे Excel फ़ंक्शन की आवश्यकता है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ॉर्मूलों को ऐसे स्प्रेडशीट इंजन से गणना करें जो उन्हें सपोर्ट करता हो और परिणामस्वरूप मानों को चार्ट वर्कबुक में लिखें। असमर्थित सूत्रों को अनुमानित मानों से बदलने से बचें।

## **सूत्र त्रुटियों को संभालें**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक सूत्र वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` उत्पन्न कर सकता है। इस स्थिति में, त्रुटि टोकन एक सेल परिणाम है और इसे [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से लौटाया जा सकता है।

एक सूत्र पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellunsupporteddataexception/)।

जब सूत्र टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनःगणना और मान पहुँच के आसपास इन अपवादों को संभालें:

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

## **व्यवहारिक सीमाएँ**

चार्ट वर्कशीट में सूत्र समर्थन एक परिभाषित उपसमुच्चय के लिए लक्षित है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- Aspose.Slides को सूत्र पुनःगणना करने के लिए केवल दस्तावेज़ित स्थिरांक, ऑपरेटर, रेफ़रेंसेज़ और फ़ंक्शन का उपयोग करें।  
- उन कोशिकाओं को बदलने के बाद पुनःगणना करें जिन पर सूत्र परिणाम निर्भर करते हैं।  
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड मान को स्नैपशॉट मानें, संपादन के बाद पुनःगणना के विकल्प के रूप में न उपयोग करें।  
- मौजूदा टेम्पलेट्स से सूत्रों का परीक्षण करें तथा सुनिश्चित करें कि वे दस्तावेज़ित सूची के बाहर के फ़ंक्शन नहीं उपयोग कर रहे हों।  
- उन सूत्रों के लिए जो पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता रखते हैं, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणाम मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) में क्या अंतर है?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। वह नोटेशन उपयोग करें जो आपके सूत्र निर्माण या कॉपी करने के तरीके से सबसे बेहतर मेल खाता हो।

**गणना के बाद मुझे सेल स्वयं पढ़ना चाहिए या उसका मान?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) एक [IChartDataCell](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/) लौटाता है। गणना के बाद उस सेल के [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#getValue--) मेथड को कॉल करके गणना परिणाम प्राप्त करें।

**मुझे कब [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करना चाहिए?**

इनपुट मान या सूत्र बदलने के बाद और गणना परिणामों पर निर्भर होने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित सूत्रों के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर दस्तावेज़ित फ़ंक्शन उपसमुच्चय को सपोर्ट करता है। इस उपसमुच्चय से बाहर के फ़ंक्शन को सही रूप से पुनःगणना माना नहीं जाना चाहिए। यदि पूर्ण Excel फ़ॉर्मूला संगतता चाहिए, तो उचित स्प्रेडशीट इंजन का उपयोग करके गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान रह सकता है। संबंधित डेटा संशोधित होने पर वह कैश्ड मान अब वैध नहीं रह सकता। ऐसी स्थिति में, उस सेल को एक्सेस करना जिसके फ़ॉर्मूला को संभाला नहीं जा सका, [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellunsupporteddataexception/) उत्पन्न कर सकता है।

**क्या सूत्र त्रुटि मान जावा अपवाद के समान होते हैं?**

नहीं। `#DIV/0!` जैसी परिणाम एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/cellcircularreferenceexception/) जैसी अपवाद दर्शाते हैं कि सूत्र को सामान्य रूप से प्रोसेस नहीं किया जा सका।

**क्या किसी फ़ॉर्मूला सेल के बदलने पर चार्ट स्वतः अपडेट होता है?**

एक चार्ट सीरीज़ वर्कबुक कोशिकाओं को संदर्भित कर सकती है। पहले वर्कबुक को पुनःगणना करें, फिर प्रस्तुति सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट गणना की गई कोशिकाओं को संदर्भित करते हैं, तो चार्ट उन अपडेटेड मानों का उपयोग करेगा; इस कार्य‑प्रवाह के लिए कोई अलग चार्ट‑रीफ़्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक का उपयोग करने के लिए कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्य‑प्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसमुच्चय पर लागू होता है। यह मानें नहीं कि [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) बाहरी XLSX फ़ाइल में मनचाहे सूत्रों की पूर्ण पुनःगणना प्रदान करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को संदर्भित करते हों?**

Excel‑स्टाइल रेफ़रेंसेज़ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ सटीक फ़ॉर्मूला को वैध करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले कार्य‑प्रवाहों के लिए, वर्कबुक को बाहरी रूप से गणना करें और हल किए हुए मानों को चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग को `=` से शुरू करना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रिम `=` के असाइन करते हैं। इस रूप को अपनाने से उत्पन्न फ़ॉर्मूले दस्तावेज़ित API उदाहरणों के साथ सुसंगत रहते हैं।