---
title: Python के साथ प्रस्तुतियों में चार्ट वर्कशीट सूत्र लागू करें
linktitle: वर्कशीट सूत्र
type: docs
weight: 70
url: /hi/python-net/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट सूत्र
- वर्कशीट सूत्र
- स्प्रेडशीट सूत्र
- चार्ट डेटा वर्कबुक
- सूत्र गणना
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के चार्ट वर्कशीट में Excel‑शैली के सूत्र लागू करें, मानों को पुनःगणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें।"
---
## **परिचय**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एक एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for Python via .NET में, आप उस वर्कशीट तक चार्ट डेटा वर्कबुक के माध्यम से पहुंच सकते हैं, इनपुट मान लिख सकते हैं, कोशिकाओं को सूत्र असाइन कर सकते हैं, समर्थित सूत्रों की गणना कर सकते हैं, और गणना किए गए कोशिकाओं को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूरी सूत्र कार्यप्रवाह को समझाता है: चार्ट बनाना, उसकी वर्कशीट को भरना, A1-स्टाइल या R1C1-स्टाइल सूत्र असाइन करना, उन्हें पुनःगणना करना, गणना किए गए मान पढ़ना, उन कोशिकाओं को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति को सहेजना। यह समर्थित सूत्र सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित सूत्र, और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट्स और सूत्र**

एक चार्ट वर्कशीट में चार्ट द्वारा उपयोग किए जाने वाले श्रेणियाँ, सीरीज़ नाम, और मान शामिल होते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट की जांच कर सकते हैं:

![PowerPoint चार्ट जिसका एम्बेडेड वर्कशीट खुला है, जिसमें श्रेणी और श्रृंखला डेटा दिखाया गया है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [chart data workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdataworkbook/) के माध्यम से उजागर किया जाता है। A1‑स्टाइल सूत्रों के लिए [formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/formula/) प्रॉपर्टी और R1C1‑स्टाइल सूत्रों के लिए [r1c1_formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) प्रॉपर्टी का उपयोग करें। इनपुट कोशिकाओं या सूत्रों को बदलने के बाद, समर्थित सूत्रों को पुनःगणना करने और संबंधित कोशिका मानों को अद्यतन करने के लिए [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) को कॉल करें।

एक गणना किया गया कोशिका अभी भी अपना परिणाम [value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी के माध्यम से उजागर करता है। यह तब महत्वपूर्ण होता है जब आपको कोड में सूत्र परिणाम की जांच करनी हो या कोशिका को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **चार्ट बनाएं और वर्कशीट सूत्रों की गणना करें**

निम्नलिखित उदाहरण एंड‑टू‑एंड कार्यप्रवाह दर्शाता है। यह क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, तिमाही राजस्व और खर्च मान लिखता है, सूत्रों से लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए कोशिकाओं को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रीफ़्रेश कॉल नहीं है: पहले वर्कबुक को पुनःगणना करें, फिर उन कोशिकाओं को उपयोग या सहेजें जो गणना किए गए कोशिकाओं की ओर इशारा करती हैं।

## **A1-शैली के सूत्रों का उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell.formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/formula/) के माध्यम से असाइन करें।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

सामान्य A1 संदर्भ रूप हैं:

| संदर्भ | रिलेटिव | एब्सोल्यूट | मिश्रित |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव संदर्भ स्प्रेडशीट एप्लिकेशन द्वारा सूत्र को ले जा या कॉपी करने पर बदल सकते हैं। एब्सोल्यूट संदर्भ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित संदर्भ केवल पंक्ति या कॉलम को स्थिर करते हैं।

## **R1C1-शैली के सूत्रों का उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप में पहचानता है। रिलेटिव संदर्भ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करते हैं। इस सिंटैक्स को [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) के माध्यम से असाइन करें।

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

सामान्य R1C1 संदर्भ रूप हैं:

| संदर्भ | रिलेटिव | एब्सोल्यूट | मिश्रित |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, कोशिका `D2` में, `RC[-2]` समान पंक्तिके दो कॉलम बाएँ वाली कोशिका (`B2`) को दर्शाता है।

## **सूत्र स्थिरांक और ऑपरेटर्स**

बिल्ट‑इन सूत्र इवैल्युएटर लॉजिकल मान, न्यूमेरिक लिटरेल्स, स्ट्रिंग्स, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर्स, और तुलना ऑपरेटर्स का समर्थन करता है।

### **स्थिरांक और लिटरेल्स**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| Logical | `TRUE`, `FALSE` | सीधे लॉजिकल अभिव्यक्तियों जैसे `A2=TRUE` में उपयोग किया जा सकता है। |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| String | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरेल्स को सूत्र के भीतर डबल कोट्स में लिखा जाता है। |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | वैध सूत्र स्प्रेडशीट त्रुटि मान के रूप में मूल्यांकन हो सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # गलत
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **अंकगणितीय ऑपरेटर्स**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नकारात्मक | `2-3`, `-3` |
| `*` | गुणन | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठकों का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर्स**

तुलना अभिव्यक्तियों का परिणाम लॉजिकल मान होता है।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | समान | `A2=3` |
| `<>` | असमान | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट्स के लिए एक बिल्ट‑इन सूत्र इवैल्युएटर प्रदान करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। प्रलेखित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शनों तक सीमित है। यह मानें नहीं कि कोई भी मनमाना Excel फ़ंक्शन [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) द्वारा पुनःगणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | परम मान | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय औसत | `AVERAGE(B2:B5)` |
| `CEILING` | किसी संख्या को ऊपर की ओर निकटतम गुणज तक गोल करना | `CEILING(A2,5)` |
| `CHOOSE` | सूचक द्वारा मान चुनना | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मानों को जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मानों को जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके दिनांक बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाना | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे के भीतर खोजना | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | संदर्भ रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | लम्बवत खोज | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को संदर्भ रूप में प्रलेखित किया गया है, जबकि `LOOKUP` और `MATCH` को उनके वेक्टर रूपों में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध न किए गए फ़ीचर और फ़ंक्शन Aspose.Slides सूत्र इवैल्युएटर द्वारा असमर्थित माने जाने चाहिए, जब तक कि वे अलग से प्रलेखित न हों।

## **पुन:गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर एक सूत्र और उसके अंतिम गणना किए गए मान दोनों को संग्रहीत करती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा नहीं बदले होने पर [IChartDataCell.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/value/) से एक कैश्ड मान पढ़ सकता है।

इनपुट कोशिकाओं या सूत्रों को बदलने के बाद, पुराने कैश्ड परिणाम पर निर्भर न रहें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा सहेजने से पहले [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के सूत्रों के लिए, Aspose.Slides संभवतः सूत्र को पार्स नहीं कर पाएगा या उसकी निर्भरताएँ स्थापित नहीं कर पाएगा। यदि वर्कबुक को संशोधित किया गया है, तो पहले का कैश्ड मान अब विश्वसनीय नहीं माना जा सकता। ऐसे मामले में, असमर्थित डेटा वाली कोशिका का मान पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उत्पन्न हो सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शन पर निर्भर करता है जो Aspose.Slides द्वारा गणना नहीं किया जाता, तो उन फ़ंक्शनों को किसी ऐसे स्प्रेडशीट इंजन के साथ गणना करें जो उनका समर्थन करता हो और प्राप्त मानों को चार्ट वर्कबुक में लिखें। असमर्थित सूत्रों को अनुमानित मानों से प्रतिस्थापित न करें।

## **सूत्र त्रुटियों को संभालें**

दो प्रकार की समस्याओं को अलग‑अलग पहचानना आवश्यक है।

एक सूत्र वैध हो सकता है लेकिन spreadsheet त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` उत्पन्न कर सकता है। इस स्थिति में त्रुटि टोकन एक कोशिका परिणाम है और `value` के माध्यम से लौटाया जा सकता है।

एक सूत्र पार्सिंग, संदर्भ, निर्भरताओं, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)।

जब सूत्र टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनःगणना और मान अभिगमन के आसपास इन अपवादों को संभालें:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट्स में सूत्र समर्थन एक परिभाषित उपसमुच्चय के लिए है, पूर्ण Excel संगतता के लिए नहीं। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन बाधाओं को ध्यान में रखें:

- Aspose.Slides को सूत्र पुनःगणना करने के लिए केवल दस्तावेज़ित स्थिरांक, ऑपरेटर्स, संदर्भ, और फ़ंक्शन ही उपयोग करें।
- उन कोशिकाओं को बदलने के बाद पुनःगणना करें जिन पर सूत्र परिणाम निर्भर होते हैं।
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड मान स्नैपशॉट हैं, संपादन के बाद पुनःगणना का विकल्प नहीं।
- मौजूदा टेम्प्लेट्स से सूत्रों का परीक्षण करें और उनके गणना किए गए मानों पर भरोसा करने से पहले सत्यापित करें, विशेषकर जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन उपयोग करते हों।
- जिन सूत्रों को पूर्ण स्प्रेडशीट गणना इंजन चाहिए, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को अंतिम मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`formula` और `r1c1_formula` में क्या अंतर है?**

[formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/formula/) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [r1c1_formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। उस नोटेशन का उपयोग करें जो आपके द्वारा सूत्र जनरेट या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**क्या मुझे पुनःगणना के बाद स्वयं कोशिका या उसका मान पढ़ना चाहिए?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) एक `IChartDataCell` लौटाता है। पुनःगणना के बाद, उस कोशिका के [value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी को पढ़कर गणना परिणाम प्राप्त करें।

**मुझे `calculate_formulas` कब कॉल करना चाहिए?**

इनपुट मान या सूत्र बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) को कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित सूत्रों के मानों को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर केवल दस्तावेज़ित फ़ंक्शन उपसमुच्चय का समर्थन करता है। इस उपसमुच्चय से बाहर के फ़ंक्शन को पुनःगणना के रूप में न मानें। यदि पूर्ण Excel सूत्र संगतता आवश्यक है, तो उचित स्प्रेडशीट इंजन से गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित सूत्र हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान मौजूद हो सकता है। संबंधित डेटा बदलने पर यह कैश्ड मान अब वैध नहीं रह सकता। ऐसी स्थिति में, असमर्थित सूत्र वाली कोशिका तक पहुँचने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उत्पन्न हो सकता है।

**क्या सूत्र त्रुटि मान Python अपवाद के समान हैं?**

नहीं। `#DIV/0!` जैसे परिणाम वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान हैं। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) जैसे अपवाद दर्शाते हैं कि सूत्र सामान्य रूप से प्रोसेस नहीं हो सका।

**क्या किसी सूत्र कोशिका के बदलने पर चार्ट स्वतः अपडेट होता है?**

चार्ट सीरीज़ वर्कबुक कोशिकाओं को संदर्भित कर सकती है। पहले वर्कबुक को पुनःगणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट गणना किए गए कोशिकाओं को संदर्भित करता है, तो चार्ट उन अपडेटेड मानों का उपयोग करता है; इस कार्यप्रवाह के लिए कोई अलग चार्ट‑रीफ़्रेश मेथड आवश्यक नहीं।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को बाहरी वर्कबुक से जोड़ने के लिए चार्ट डेटा API का उपयोग किया जा सकता है। हालांकि, इस लेख में वर्णित सूत्र गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा इवैल्युएट किए गए सूत्र उपसमुच्चय से संबंधित है। यह मानें नहीं कि [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) बाहरी XLSX फ़ाइल में मनमाने सूत्रों की पूर्ण पुनःगणना प्रदान करता है।

**क्या मैं ऐसे सूत्र उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को संदर्भित करते हैं?**

Excel‑स्टाइल संदर्भ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन सूत्र मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट तक सीमित है। यदि क्रॉस‑शीट या बाहरी संदर्भ आवश्यक है, तो अपने Aspose.Slides संस्करण के साथ ठीक‑ठीक उस सूत्र का परीक्षण करें। व्यापक Excel संदर्भ संगतता की आवश्यकता वाले कार्यप्रवाहों के लिए, वर्कबुक को बाहरी रूप से गणना करें और समाधान मानों को चार्ट डेटा में वापस लिखें।

**क्या सूत्र स्ट्रिंग `=` से शुरू होनी चाहिए?**

Aspose.Slides API उदाहरणों में `B2-C2` या `SUM(B2:B5)` जैसे अभिव्यक्तियों को बिना अग्रणी `=` के असाइन किया जाता है। इस रूप का उपयोग करने से उत्पन्न सूत्र दस्तावेज़ित API उदाहरणों के साथ सुसंगत रहते हैं।