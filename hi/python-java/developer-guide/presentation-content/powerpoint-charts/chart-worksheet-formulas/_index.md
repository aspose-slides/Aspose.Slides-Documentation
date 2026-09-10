---
title: Python के माध्यम से Java में प्रस्तुतियों में चार्ट कार्यपत्रक सूत्र लागू करना
linktitle: कार्यपत्रक सूत्र
type: docs
weight: 70
url: /hi/python-java/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट कार्यपत्रक
- चार्ट सूत्र
- कार्यपत्रक सूत्र
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में चार्ट कार्यपत्रकों पर Excel-शैली के सूत्र लागू करें, मानों की पुनर्गणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें।"
---
## **सारांश**

PowerPoint चार्ट आम तौर पर अपने स्रोत डेटा को एक एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Python via Java में, आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुंच सकते हैं, इनपुट मान लिख सकते हैं, कोशिकाओं में सूत्र असाइन कर सकते हैं, समर्थित सूत्रों की गणना कर सकते हैं, और गणना किए गए कोशिकाओं को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूरी सूत्र कार्यप्रवाह को समझाता है: एक चार्ट बनाना, उसकी वर्कशीट भरना, A1-शैली या R1C1-शैली के सूत्र असाइन करना, उन्हें पुनर्गणना करना, गणना किए गए मूल्यों को पढ़ना, उन कोशिकाओं को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति को सहेजना। यह समर्थित सूत्र सिंटैक्स, निर्मित फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित सूत्र, और स्प्रेडशीट-विशिष्ट त्रुटियों का भी विवरण देता है।

## **चार्ट कार्यपत्रक और सूत्र**

एक चार्ट कार्यपत्रक में वह श्रेणियाँ, सीरीज़ नाम, और मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर कार्यपत्रक का निरीक्षण कर सकते हैं:

![PowerPoint चार्ट जिसमें उसका एम्बेडेड कार्यपत्रक खुला है, श्रेणी और सीरीज़ डेटा दिखा रहा है](chart-worksheet-formulas_1.png)

Aspose.Slides में, कार्यपत्रक को [ChartDataWorkbook](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/) क्लास के माध्यम से एक्सपोज़ किया जाता है। A1-शैली के सूत्रों के लिए [ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setFormula) और R1C1-शैली के सूत्रों के लिए [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setR1C1Formula) का उपयोग करें। इनपुट कोशिकाओं या सूत्रों को बदलने के बाद, समर्थित सूत्रों को पुनर्गणना करने और संबंधित कोशिका मूल्यों को अपडेट करने के लिए [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें।

एक गणना की गई कोशिका अभी भी अपना परिणाम [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#getValue) के माध्यम से प्रकट करती है। यह तब महत्वपूर्ण होता है जब आपको कोड में सूत्र परिणाम का निरीक्षण करना हो या कोशिका को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाएं और कार्यपत्रक सूत्रों की गणना करें**

निम्न उदाहरण अंत‑से‑अंत कार्यप्रवाह को प्रदर्शित करता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, सूत्रों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना की गई कोशिकाओं को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रीफ़्रेश कॉल नहीं है: पहले वर्कबुक को पुनर्गणना करें, फिर उन गणना की गई कोशिकाओं की ओर इशारा करने वाले चार्ट डेटा का उपयोग करें या सहेजें।

## **A1-शैली के सूत्रों का उपयोग करें**

A1 नोटेशन में कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचाना जाता है। [ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setFormula) के माध्यम से A1‑शैली अभिव्यक्तियों को असाइन करें।

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

सामान्य A1 रिफरेंस रूप नीचे दिए गए हैं:

| संदर्भ | सापेक्ष | परम | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| स्तंभ | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष रिफरेंसेज़ स्प्रेडशीट एप्लिकेशन द्वारा सूत्र को स्थानांतरित या कॉपी करने पर बदल सकती हैं। परम रिफरेंसेज़ दोनों निर्देशांक को स्थिर रखती हैं, जबकि मिश्रित रिफरेंसेज़ केवल पंक्ति या कॉलम को ही स्थिर करती हैं।

## **R1C1-शैली के सूत्रों का उपयोग करें**

R1C1 नोटेशन में पंक्तियों और स्तंभों दोनों को संख्यात्मक रूप से पहचाना जाता है। सापेक्ष रिफरेंसेज़ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करती हैं। इस सिंटैक्स को [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setR1C1Formula) के माध्यम से असाइन करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

सामान्य R1C1 रिफरेंस रूप नीचे दिए गए हैं:

| संदर्भ | सापेक्ष | परम | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| स्तंभ | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, `D2` सेल में, `RC[-2]` उसी पंक्ति में दो कॉलम बाईं ओर की कोशिका (`B2`) को दर्शाता है।

## **सूत्र स्थिरांक और ऑपरेटर**

निर्मित सूत्र मूल्यांकनकर्ता तर्कशुद्ध मान, संख्यात्मक लिटेरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर, और तुलना ऑपरेटर को समर्थन देता है।

### **स्थिरांक और लिटेरल**

| प्रकार | उदाहरण | टिप्पणी |
|---|---|---|
| तार्किक | `TRUE`, `FALSE` | `A2=TRUE` जैसी तर्कशुद्ध अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| संख्यिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटेरल सूत्र के भीतर डबल कोटेशन में enclosed होते हैं। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | एक वैध सूत्र सामान्य परिणाम की बजाय स्प्रेडशीट त्रुटि मान दे सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # गलत
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नकारा | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठकों का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियों के परिणाम तर्कशुद्ध मान होते हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides में चार्ट कार्यपत्रकों के लिए निर्मित फ़ॉर्मूला इवैल्युएटर है, लेकिन यह पूरी Excel गणना इंजन नहीं है। प्रलेखित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शन तक सीमित है। यह न मानें कि कोई भी Excel फ़ंक्शन [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) द्वारा पुनर्गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | परम मान | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय माध्य | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को निकटतम बहु पर ऊपर की ओर गोल करना | `CEILING(A2,5)` |
| `CHOOSE` | अनुक्रम द्वारा मान चुनना | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | पाठ मानों को जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | पाठ मानों को जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाना | `DAYS(B2,A2)` |
| `FIND` | एक पाठ मान को दूसरे में ढूँढना | `FIND("-",A2)` |
| `FINDB` | बाइट‑उन्मुख पाठ खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | ऊर्ध्वाधर खोज | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दर्शाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` रेफ़रेंस रूप में प्रलेखित है, जबकि `LOOKUP` और `MATCH` वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध न किए गए फीचर्स और फ़ंक्शन Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माने जाते हैं, जब तक कि वे अलग से प्रलेखित न हों।

## **पसंदीदा संस्कृति के साथ सूत्रों की गणना करें**

कुछ चार्ट वर्कबुक फ़ंक्शन पाठ को संस्कृति‑विशिष्ट नियमों के अनुसार व्याख्यायित करते हैं। यह विशेष रूप से उन फ़ंक्शनों के लिये महत्वपूर्ण है जो डबल‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिये बनाए गए हैं। ऐसी सूत्रों की सही गणना करने हेतु, [LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) बनाएं, [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) के साथ पसंदीदा संस्कृति सेट करें, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) के माध्यम से स्प्रेडशीट विकल्प असाइन करें, और फिर प्रस्तुति लोड करें।

निम्न उदाहरण जापानी संस्कृति का चयन करता है, कॉन्फ़िगर किए गए लोड विकल्पों के साथ प्रस्तुति खोलता है, और प्रत्येक चार्ट वर्कबुक के लिये [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

पसंदीदा संस्कृति प्रस्तुति लोडिंग कॉन्फ़िगरेशन का भाग है, इसलिए इसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाने से पहले निर्दिष्ट करें। उस संस्कृति का उपयोग करें जो वर्कबुक सूत्रों के लिये अपेक्षित हो; उदाहरण के लिये जापानी DBCS गणना नियमों के लिये `ja-JP` का उपयोग करें।

## **पुनर्गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर एक सूत्र और उसका अंतिम गणना किया गया मान दोनों संग्रहीत करती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा में परिवर्तन न होने पर [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#getValue) से कैश्ड मान पढ़ सकता है।

इनपुट कोशिकाओं या सूत्रों को बदलने के बाद, पुराने कैश्ड परिणाम पर भरोसा न करें। गणना किए गए मानों को पढ़ने या उन पर निर्भर करने वाले चार्ट डेटा को सहेजने से पहले [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें।

समर्थित उपसमुच्चय से बाहर के सूत्रों के लिये, Aspose.Slides को सूत्र पार्स करने या उसकी निर्भरताओं को स्थापित करने में असमर्थता हो सकती है। यदि वर्कबुक संशोधित हो गई है, तो पिछला कैश्ड मान अब विश्वसनीय नहीं रहता। ऐसे मामलों में, असमर्थित डेटा वाली कोशिका का मान पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellunsupporteddataexception/) उत्पन्न हो सकता है।

यदि आपका चार्ट उन Excel फ़ंक्शनों पर निर्भर करता है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन सूत्रों को किसी ऐसे स्प्रेडशीट इंजन से कैलकुलेट करें जो उन्हें समर्थन करता हो और परिणामी मानों को चार्ट वर्कबुक में लिखें। असमर्थित सूत्रों को अनुमानित मानों से प्रतिस्थापित न करें।

## **सूत्र त्रुटियों को संभालें**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक सूत्र वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` दे सकता है। इस स्थिति में, त्रुटि टोकन एक कोशिका परिणाम है और इसे [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#getValue) के माध्यम से वापस किया जा सकता है।

एक सूत्र पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिये स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellunsupporteddataexception/)।

जब सूत्र टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनर्गणना और मान अभिगम के चारों ओर इन अपवादों को संभालें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **व्यावहारिक सीमाएँ**

चार्ट कार्यपत्रकों में सूत्र समर्थन एक परिभाषित उपसमुच्चय के लिये तैयार किया गया है, न कि पूरी Excel संगतता के लिये। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन प्रतिबंधों को याद रखें:

- जब आप चाहते हैं कि Aspose.Slides सूत्रों को पुनर्गणना करे, केवल प्रलेखित स्थिरांक, ऑपरेटर, रेफ़रेंसेज़ और फ़ंक्शन उपयोग करें।
- उन कोशिकाओं को बदलने के बाद पुनर्गणना करें जिन पर सूत्र परिणाम निर्भर करते हैं।
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड मान स्नैपशॉट हैं, संशोधनों के बाद पुनर्गणना का विकल्प नहीं हैं।
- मौजूदा टेम्पलेट से सूत्रों का परीक्षण करें, विशेषकर जब वे प्रलेखित सूची से बाहर के फ़ंक्शन उपयोग करते हों।
- उन सूत्रों के लिये जो पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता रखते हैं, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणामों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setFormula) और [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setR1C1Formula) में क्या अंतर है?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setFormula) A1‑शैली अभिव्यक्ति जैसे `B2-C2` को संग्रहीत करता है। [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#setR1C1Formula) R1C1‑शैली अभिव्यक्ति जैसे `RC[-2]-RC[-1]` को संग्रहीत करता है। वह नोटेशन चुनें जो आपके सूत्र निर्माण या कॉपी करने की शैली से सबसे अधिक मेल खाता हो।

**गणना के बाद क्या मुझे स्वयं कोशिका पढ़नी चाहिए या उसका मान?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#getCell) एक [ChartDataCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/) लौटाता है। गणना के बाद गणना परिणाम प्राप्त करने के लिये उस कोशिका की [ChartDataCell.getValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatacell/#getValue) मेथड को कॉल करें।

**मुझे कब [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करना चाहिए?**

इनपुट मान या सूत्र बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें। यह निर्मित मूल्यांकक द्वारा समर्थित सूत्रों के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। निर्मित मूल्यांकक केवल दस्तावेज़ित उपसमुच्चय के फ़ंक्शन का समर्थन करता है। इस उपसमुच्चय से बाहर के फ़ंक्शन को पुनर्गणना के लिये मान नहीं किया जाना चाहिए। यदि पूर्ण Excel सूत्र संगतता आवश्यक है, तो उपयुक्त स्प्रेडशीट इंजन से गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोडेड प्रस्तुति में असमर्थित सूत्र हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान हो सकता है। संबंधित डेटा बदलने के बाद वह कैश्ड मान अब मान्य नहीं रह सकता। ऐसे सूत्र वाले कोशिका को एक्सेस करने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellunsupporteddataexception/) उत्पन्न हो सकता है।

**क्या सूत्र त्रुटि मान और अपवाद एक ही चीज़ हैं?**

नहीं। `#DIV/0!` जैसे परिणाम वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान हैं। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellcircularreferenceexception/) जैसे अपवाद दर्शाते हैं कि सूत्र सामान्य रूप से प्रोसेस नहीं किया जा सका।

**क्या सूत्र कोशिका बदलने पर चार्ट स्वतः अपडेट होता है?**

एक चार्ट सीरीज़ वर्कबुक कोशिकाओं को संदर्भित कर सकती है। पहले वर्कबुक को पुनर्गणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट गणना की गई कोशिकाओं को संदर्भित करता है, तो चार्ट उन अद्यतन मानों का उपयोग करता है; इस कार्यप्रवाह के लिये कोई अलग चार्ट‑रीफ़्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक उपयोग करने के लिये कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित सूत्र गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित सूत्र उपसमुच्चय पर केंद्रित है। यह न मानें कि [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) बाहरी XLSX फ़ाइल में मनमाने सूत्रों की पूरी पुनर्गणना प्रदान करता है।

**क्या मैं ऐसे सूत्र उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को संदर्भित करते हैं?**

Excel‑शैली के रेफ़रेंसेज़ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन सूत्र मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ सटीक सूत्र को सत्यापित करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले कार्यप्रवाहों के लिये, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को चार्ट डेटा में लिखें।

**क्या सूत्र स्ट्रिंग को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न सूत्र दस्तावेज़ित API उदाहरणों के साथ संगत रहते हैं।