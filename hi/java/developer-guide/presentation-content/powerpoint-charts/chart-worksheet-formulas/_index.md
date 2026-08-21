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
- पसंदीदा संस्कृति
- संस्कृति-विशिष्ट फ़ॉर्मूला
- DBCS
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
description: "Aspose.Slides for Java चार्ट वर्कशीट में Excel-शैली फ़ॉर्मूले लागू करें, मानों को पुनः गणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें."
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Java में, आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुँच सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूले असाइन कर सकते हैं, समर्थित फ़ॉर्मूले की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला कार्यप्रवाह को समझाता है: एक चार्ट बनाना, उसकी वर्कशीट को भरना, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूले असाइन करना, उन्हें पुन: गणना करना, गणना किए गए मान पढ़ना, उन सेल्स को एक चार्ट सीरीज़ से जोड़ना, और प्रेजेंटेशन को सहेजना। यह समर्थित फ़ॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश्ड वैल्यूज़, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी विवरण देता है।

## **चार्ट वर्कशीट और फ़ॉर्मूले**

एक चार्ट वर्कशीट में वह श्रेणियाँ, सीरीज़ नाम और मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![एंबेडेड वर्कशीट खुले हुए PowerPoint चार्ट, जिसमें श्रेणी और सीरीज़ डेटा दिखाया गया है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [IChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/) इंटरफ़ेस के माध्यम से एक्सपोज़ किया जाता है। A1‑स्टाइल फ़ॉर्मूले के लिए [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और R1C1‑स्टाइल फ़ॉर्मूले के लिए [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) का उपयोग करें। इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, समर्थित फ़ॉर्मूले को पुन: गणना करने और संबंधित सेल मानों को अपडेट करने के लिए [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

एक गणना किया गया सेल अभी भी अपना परिणाम [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से उपलब्ध कराता है। यह तब महत्वपूर्ण होता है जब आपको कोड में फ़ॉर्मूला परिणाम को जांचना हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाएं और वर्कशीट फ़ॉर्मूले गणना करें**

निम्नलिखित उदाहरण एक पूर्ण कार्यप्रवाह को प्रदर्शित करता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फ़ॉर्मूलों के साथ मुनाफ़ा गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मानों के रूप में उपयोग करता है, और प्रेजेंटेशन को सहेजता है।

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

चार्ट डेटा पॉइंट्स `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए मुनाफ़ा मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुन: गणना करें, फिर उन कैल्क्युलेटेड सेल्स को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले का उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) के माध्यम से असाइन करें।

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

आम A1 रेफ़रेंस रूपन्तरण:

| संदर्भ | रिलेटिव | एब्सॉल्यूट | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव रेफ़रेंसेज़ को फ़ॉर्मूला को स्प्रेडशीट एप्लिकेशन द्वारा मूव या कॉपी करने पर बदल सकते हैं। एब्सॉल्यूट रेफ़रेंसेज़ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित रेफ़रेंसेज़ केवल पंक्ति या कॉलम को फिक्स करती हैं।

## **R1C1‑स्टाइल फ़ॉर्मूले का उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव रेफ़रेंसेज़ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करती हैं। इस सिंटैक्स को [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) के माध्यम से असाइन करें।

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

आम R1C1 रेफ़रेंस रूपान्तरण:

| संदर्भ | रिलेटिव | एब्सॉल्यूट | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ वाला सेल (`B2`)।

## **फ़ॉर्मूला स्थिरांक और ऑपरेटर**

बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर लॉजिकल मान, न्यूमेरिक लिटेरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को समर्थन देता है।

### **स्थिरांक और लिटेरल**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | `A2=TRUE` जैसी लॉजिकल अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| न्यूमेरिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक दोनों नोटेशन समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटेरल को फ़ॉर्मूला के भीतर दोहरे उद्धरण में लिखा जाता है। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | वैध फ़ॉर्मूला सामान्य परिणाम की बजाय स्प्रेडशीट त्रुटि मूल्य भी दे सकता है। |

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
| `+` | जोड़ या युनरी प्लस | `2+3` |
| `-` | घटाव या निगेशन | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम को स्पष्ट करने के लिए कोष्ठकों का प्रयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियाँ लॉजिकल मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides में चार्ट वर्कशीट के लिए एक बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। प्रलेखित फ़ंक्शन सेट नीचे दर्शाए गए फ़ंक्शनों तक सीमित है। यह मान कर न चलें कि कोई भी arbitrary Excel फ़ंक्शन [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) द्वारा पुनः गणना किया जाएगा।

| फ़ंक्शन | प्रयोजन या समर्थित फॉर्म | उदाहरण |
|---|---|---|
| `ABS` | पूर्ण मान | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय औसत | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर बहुगुणक तक राउंड | `CEILING(A2,5)` |
| `CHOOSE` | सूचकांक द्वारा मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | पाठ मानों को जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | पाठ मानों को जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि बनाएं | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाएं | `DAYS(B2,A2)` |
| `FIND` | एक पाठ को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड पाठ खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस फॉर्म | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर फॉर्म | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर फॉर्म | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` रेफ़रेंस फॉर्म में प्रलेखित है, जबकि `LOOKUP` और `MATCH` अपने वेक्टर फॉर्म में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध नहीं किए गए फीचर और फ़ंक्शन को Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माना जाना चाहिए, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पसंदीदा संस्कृति के साथ फ़ॉर्मूले गणना करें**

कुछ चार्ट वर्कबुक फ़ंक्शन टेक्स्ट की व्याख्या संस्कृति‑विशिष्ट नियमों के आधार पर करते हैं। यह विशेष रूप से उन फ़ंक्शन के लिए महत्वपूर्ण है जो डबल‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिए बनाए गए हैं। ऐसे फ़ॉर्मूले को सही ढंग से गणना करने के लिए, [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) बनाएं, [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hi/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) के साथ पसंदीदा संस्कृति सेट करें, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) के माध्यम से स्प्रेडशीट विकल्प असाइन करें, और फिर प्रेजेंटेशन लोड करें।

निम्न उदाहरण जापानी संस्कृति का चयन करता है, कॉन्फ़िगर किए गए लोड विकल्पों के साथ प्रेजेंटेशन खोलता है, और प्रत्येक चार्ट वर्कबुक के लिए [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करता है:

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

पसंदीदा संस्कृति प्रेजेंटेशन लोडिंग कॉन्फ़िगरेशन का हिस्सा है, इसलिए इसे [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस बनाने से पहले निर्दिष्ट करें। फ़ॉर्मूला द्वारा अपेक्षित संस्कृति का उपयोग करें; उदाहरण के लिए, जापानी DBCS गणना नियमों का पालन करने वाले फ़ॉर्मूले के लिए `ja-JP` प्रयोग करें।

## **पुनः गणना और कैश्ड वैल्यूज़**

स्प्रेडशीट फ़ाइलें आमतौर पर फ़ॉर्मूला और उसका अंतिम गणना किया गया मान दोनों संग्रहीत करती हैं। Aspose.Slides तब [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) से एक कैश्ड मान पढ़ सकता है, जब प्रेजेंटेशन लोड किया जाता है और संबंधित चार्ट डेटा में कोई परिवर्तन नहीं हुआ है।

इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, पुराने कैश्ड परिणाम पर निर्भर न रहें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा को सहेजने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फ़ॉर्मूले के लिए, Aspose.Slides फ़ॉर्मूला को पार्स नहीं कर सकता या उसकी निर्भरताएँ स्थापित नहीं कर सकता। यदि वर्कबुक में परिवर्तन हुआ है, तो पूर्व कैश्ड मान अब भरोसेमंद नहीं माना जा सकता। ऐसे में असमर्थित डेटा वाले सेल के मान को पढ़ने पर [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellunsupporteddataexception/) उत्पन्न हो सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शन पर निर्भर है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन्हें किसी ऐसे स्प्रेडशीट इंजन के साथ गणना करें जो उनका समर्थन करता हो और परिणामस्वरूप मानों को चार्ट वर्कबुक में लिखें। असमर्थित फ़ॉर्मूले को अनुमानित मानों से बदलने से बचें।

## **फ़ॉर्मूला त्रुटियों को संभालें**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` दे सकता है। इस स्थिति में त्रुटि टोकन एक सेल परिणाम है और इसे [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः गणना और मान पहुंच के आसपास इन अपवादों को संभालें:

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

चार्ट वर्कशीट में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिए है, पूर्ण Excel संगतता के लिए नहीं। इस बात को ध्यान में रखें जब आप रिपोर्टिंग कार्यप्रवाह डिजाइन कर रहे हों:

- केवल प्रलेखित स्थिरांक, ऑपरेटर, रेफ़रेंस और फ़ंक्शन का उपयोग करें जब आप चाहते हैं कि Aspose.Slides फ़ॉर्मूले पुनः गणना करे।
- उन सेल्स को बदलने के बाद पुनः गणना करें जिन पर फ़ॉर्मूला परिणाम निर्भर करता है।
- लोड किए गए प्रेजेंटेशन से प्राप्त कैश्ड मानों को स्नैपशॉट मानें, संपादन के बाद पुनः गणना के विकल्प के रूप में न उपयोग करें।
- मौजूदा टेम्प्लेट्स से फ़ॉर्मूले को परीक्षण करें और उनके गणना किए गए मानों पर भरोसा करने से पहले पुष्टि करें, विशेष रूप से जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन का उपयोग करते हों।
- उन फ़ॉर्मूलों के लिए जिन्हें पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता है, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) और [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) में क्या अंतर है?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` को सहेजता है। [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` को सहेजता है। वह नोटेशन चुनें जो आपके फ़ॉर्मूला निर्माण या कॉपी करने के तरीके से मेल खाता हो।

**क्या मुझे पुनः गणना के बाद सेल स्वयं पढ़ना चाहिए या उसका मान?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) एक [IChartDataCell](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/) लौटाता है। गणना के बाद, उस सेल के [IChartDataCell.getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#getValue--) मेथड को कॉल करके गणना परिणाम प्राप्त करें।

**मुझे कब [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूले बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) को कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित फ़ॉर्मूलों के मानों को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर दस्तावेज़ित फ़ंक्शन उपसमुच्चय को ही समर्थन करता है। उस उपसमुच्चय से बाहर के फ़ंक्शन को सही ढंग से पुनः गणना माना न जाए। यदि पूर्ण Excel फ़ॉर्मूला संगतता चाहिए, तो उपयुक्त स्प्रेडशीट इंजन का उपयोग करके गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड किए गए प्रेजेंटेशन में असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा बदलता नहीं है, तो वर्कबुक में पहले से गणना किया हुआ कैश्ड मान मौजूद रह सकता है। संबंधित डेटा बदलने पर वह कैश्ड मान अब वैध नहीं रह सकता। ऐसी स्थिति में, असमर्थित फ़ॉर्मूला वाले सेल को पढ़ने पर [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellunsupporteddataexception/) उभरा सकता है।

**क्या फ़ॉर्मूला त्रुटि मान जावा अपवाद के समान हैं?**

नहीं। `#DIV/0!` जैसी परिणाम एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/cellcircularreferenceexception/) जैसे अपवाद संकेत देते हैं कि फ़ॉर्मूला सामान्य रूप से प्रोसेस नहीं हो सका।

**क्या फ़ॉर्मूला सेल बदलने पर चार्ट स्वतः अपडेट हो जाता है?**

एक चार्ट सीरीज़ वर्कबुक सेल्स को संदर्भित कर सकती है। पहले वर्कबुक को पुनः गणना करें, फिर प्रेजेंटेशन को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट उन अपडेटेड मानों का उपयोग करता है; इस कार्यप्रवाह के लिए कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाह्य Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को बाह्य वर्कबुक के माध्यम से कॉन्फ़िगर किया जा सकता है। हालाँकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसमुच्चय तक सीमित है। यह न मानें कि [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) बाह्य XLSX फ़ाइल में किसी भी फ़ॉर्मूला की पूर्ण पुनः गणना करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो अन्य वर्कशीट या वर्कबुक को संदर्भित करते हों?**

Excel‑स्टाइल रेफ़रेंसेज़ चार्ट वर्कबुक में हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाह्य रेफ़रेंस आवश्यक है, तो अपने Aspose.Slides संस्करण के साथ सटीक फ़ॉर्मूला को मान्य करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले कार्यप्रवाहों के लिए, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को वापस चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूले स्ट्रिंग `=` से शुरू होनी चाहिए?**

Aspose.Slides API के उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रिम `=` के असाइन करते हैं। इस रूप का उपयोग करने से निर्मित फ़ॉर्मूले दस्तावेज़ित API उदाहरणों के साथ सुसंगत रहते हैं।