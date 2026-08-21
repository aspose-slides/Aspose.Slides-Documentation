---
title: Python के साथ प्रस्तुतियों में चार्ट कार्यपत्रक सूत्र लागू करें
linktitle: कार्यपत्रक सूत्र
type: docs
weight: 70
url: /hi/python-net/chart-worksheet-formulas/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के चार्ट कार्यपत्रकों में Excel-शैली के सूत्र लागू करें, मानों की पुनः गणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपना स्रोत डेटा एम्बेडेड कार्यपत्रक में संग्रहीत करते हैं। Aspose.Slides for Python via .NET में आप चार्ट डेटा कार्यपुस्तिका के माध्यम से उस कार्यपत्रक तक पहुंच सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को सूत्र असाइन कर सकते हैं, समर्थित सूत्रों की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण सूत्र कार्यफ़्लो समझाता है: एक चार्ट बनाएं, उसकी कार्यपत्रक को भरें, A1‑स्टाइल या R1C1‑स्टाइल सूत्र असाइन करें, उन्हें पुनः गणना करें, गणना किए गए मान पढ़ें, उन सेल्स को चार्ट सीरीज़ से जोड़ें, और प्रस्तुति सहेजें। यह समर्थित सूत्र सिंटैक्स, अंतर्निहित फ़ंक्शन उपसमुच्चय, कैश किए गए मान, असमर्थित सूत्र, और कार्यपत्रक‑विशिष्ट त्रुटियों का भी विवरण देता है।

## **चार्ट कार्यपत्रक और सूत्र**

एक चार्ट कार्यपत्रक में उन श्रेणियों, श्रृंखला नामों और मानों को शामिल किया जाता है जो चार्ट द्वारा उपयोग होते हैं। PowerPoint में आप चार्ट डेटा संपादक खोलकर कार्यपत्रक का निरीक्षण कर सकते हैं:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides में, कार्यपत्रक को [chart data workbook](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdataworkbook/) के माध्यम से उजागर किया जाता है। A1‑स्टाइल सूत्रों के लिए [formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/formula/) प्रॉपर्टी और R1C1‑स्टाइल सूत्रों के लिए [r1c1_formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) प्रॉपर्टी का उपयोग करें। इनपुट सेल्स या सूत्र बदलने के बाद, समर्थित सूत्रों को पुनः गणना करने और संबंधित सेल मानों को अपडेट करने के लिए [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) कॉल करें।

एक गणना किया गया सेल अभी भी अपना परिणाम [value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी के माध्यम से उजागर करता है। यह तब महत्वपूर्ण होता है जब आपको कोड में सूत्र परिणाम की जांच करने या सेल को चार्ट डेटा बिंदु के रूप में उपयोग करने की आवश्यकता हो।

## **एक चार्ट बनाएं और कार्यपत्रक सूत्रों की गणना करें**

निम्न उदाहरण एक अंत‑से‑अंत कार्यफ़्लो दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा को साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, सूत्रों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

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

चार्ट डेटा पॉइंट्स `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यफ़्लो में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले कार्यपुस्तिका को पुनः गणना करें, फिर गणना किए गए सेल्स को उपयोग करें या सहेजें।

## **A1‑स्टाइल सूत्रों का उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों और पंक्तियों को संख्याओं से पहचानता है। [IChartDataCell.formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/formula/) के माध्यम से A1‑स्टाइल अभिव्यक्तियां असाइन करें।

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

आम A1 संदर्भ रूप हैं:

| संदर्भ | सापेक्ष | निरपेक्ष | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| स्तम्भ | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष संदर्भ स्प्रेडशीट अनुप्रयोग द्वारा सूत्र को स्थानांतरित या कॉपी करने पर बदल सकते हैं। निरपेक्ष संदर्भ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित संदर्भ केवल पंक्ति या स्तम्भ को स्थिर करता है।

## **R1C1‑स्टाइल सूत्रों का उपयोग करें**

R1C1 नोटेशन दोनों पंक्तियों और स्तम्भों को संख्यात्मक रूप से पहचानता है। सापेक्ष संदर्भ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करते हैं। इस सिंटैक्स को [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) के माध्यम से असाइन करें।

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

आम R1C1 संदर्भ रूप हैं:

| संदर्भ | सापेक्ष | निरपेक्ष | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| स्तम्भ | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में `RC[-2]` का अर्थ है समान पंक्ति में दो स्तम्भ बाएँ वाला सेल (`B2`)।

## **सूत्र स्थिरांक और ऑपरेटर**

अंतर्निहित सूत्र मूल्यांकनकर्ता तर्कात्मक मान, संख्यात्मक लिटरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर, और तुलना ऑपरेटर का समर्थन करता है।

### **स्थिरांक और लिटरल**

| प्रकार | उदाहरण | नोट |
|---|---|---|
| तर्कात्मक | `TRUE`, `FALSE` | `A2=TRUE` जैसी तर्क अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| संख्यात्मक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरल को सूत्र के भीतर डबल कोट्स में रखा जाता है। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | मान्य सूत्र कभी‑कभी सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान दे सकता है। |

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

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनेरि प्लस | `2+3` |
| `-` | घटाव या नकारात्मक | `2-3`, `-3` |
| `*` | गुणन | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठकों का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियां तर्कात्मक मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides में चार्ट कार्यपत्रकों के लिए एक अंतर्निहित सूत्र मूल्यांकनकर्ता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ीकृत फ़ंक्शन सेट नीचे दिए गए फ़ंक्शनों तक सीमित है। यह न मानें कि कोई भी Excel फ़ंक्शन [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) द्वारा पुनः गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | निरपेक्ष मान | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय माध्य | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर गुणक तक गोल करें | `CEILING(A2,5)` |
| `CHOOSE` | सूचकांक द्वारा मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि बनाएं | `DATE(2026,8,19)` |
| `DAYS` | तिथियों के बीच दिन गिनें | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट‑उन्मुख टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | संदर्भ रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मान जोड़ें | `SUM(B2:B5)` |
| `VLOOKUP` | लंबवत खोज | `VLOOKUP(A2,B2:D10,3,FALSE)` |

तालिका में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को संदर्भ रूप में प्रलेखित किया गया है, जबकि `LOOKUP` और `MATCH` को उनके वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ नहीं सूचीबद्ध फ़ंक्शन को Aspose.Slides सूत्र मूल्यांकनकर्ता द्वारा असमर्थित माना जाना चाहिए, जब तक कि वे अलग से प्रलेखित न हों।

## **पसंदीदा संस्कृति के साथ सूत्रों की गणना**

कुछ कार्यपुस्तिका फ़ंक्शन टेक्स्ट को संस्कृति‑विशिष्ट नियमों के अनुसार व्याख्या करते हैं। यह विशेष रूप से डबल‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिए महत्वपूर्ण है। ऐसे सूत्रों की सही गणना के लिए, [LoadOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/) बनाएं, [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/spreadsheet_options/) के माध्यम से [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/hi/python-net/aspose.slides/spreadsheetoptions/) सेट करें, और फिर प्रस्तुति लोड करें।

निम्न उदाहरण जापानी संस्कृति चुनता है, कॉन्फ़िगर किए गए लोड विकल्पों के साथ प्रस्तुति खोलता है, और प्रत्येक चार्ट कार्यपुस्तिका के लिए [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) कॉल करता है:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

पसंदीदा संस्कृति प्रस्तुति लोडिंग कॉन्फ़िगरेशन का हिस्सा है, इसलिए इसे [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाने से पहले निर्दिष्ट करें। कार्यपुस्तिका सूत्रों के लिए अपेक्षित संस्कृति उपयोग करें; उदाहरण के लिए, जापानी DBCS गणना नियमों के लिए `ja-JP` उपयोग करें।

## **पुनः गणना और कैश किए गए मान**

स्प्रेडशीट फ़ाइलें आमतौर पर सूत्र और उसका अंतिम गणना किया गया मान दोनों सहेजती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर जब संबंधित चार्ट डेटा में बदलाव नहीं किया गया हो, तब [IChartDataCell.value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/value/) से एक कैश किया गया मान पढ़ सकता है।

इनपुट सेल्स या सूत्र बदलने के बाद, पुराने कैश परिणाम पर भरोसा न करें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा को सहेजने से पहले [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) कॉल करें।

समर्थित उपसमुच्चय के बाहर के सूत्रों के लिए, Aspose.Slides संभवतः सूत्र को पार्स नहीं कर पाएगा या उसकी निर्भरताएँ निर्धारित नहीं कर पाएगा। यदि कार्यपुस्तिका संशोधित की गई है, तो पूर्व कैश मान अब विश्वसनीय नहीं रह सकता। ऐसी स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उत्पन्न हो सकता है।

यदि आपका चार्ट Excel फ़ंक्शन पर निर्भर है जिसे Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ंक्शन को किसी समर्थन योग्य स्प्रेडशीट इंजन से गणना करें और परिणाम मानों को चार्ट कार्यपुस्तिका में वापस लिखें। अनुमानित मानों से असमर्थित सूत्रों को प्रतिस्थापित न करें।

## **सूत्र त्रुटियों को संभालें**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

एक सूत्र वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` दे सकता है। इस स्थिति में त्रुटि टोकन सेल परिणाम है और `value` के माध्यम से लौटाया जा सकता है।

एक सूत्र पार्सिंग, संदर्भ, निर्भरताओं, या समर्थित‑डेटा स्तर पर विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)।

जब सूत्र टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः गणना और मान एक्सेस के आसपास इन अपवादों को संभालें:

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

## **व्यवहारिक सीमाएँ**

चार्ट कार्यपत्रकों में सूत्र समर्थन एक परिभाषित उपसमुच्चय के लिए है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग कार्यफ़्लो डिज़ाइन करते समय इन प्रतिबंधों को याद रखें:

- जब आपको Aspose.Slides को सूत्र पुनः गणना करने की आवश्यकता हो, तब केवल दस्तावेज़ीकृत स्थिरांक, ऑपरेटर, संदर्भ और फ़ंक्शन का उपयोग करें।
- उन सेल्स को बदलने के बाद पुनः गणना करें जिनके आधार पर सूत्र परिणाम निर्भर करते हैं।
- लोड की गई प्रस्तुतियों से प्राप्त कैश मान स्नैपशॉट के रूप में मानें, संपादन के बाद पुनः गणना का विकल्प न समझें।
- मौजूदा टेम्प्लेट से सूत्रों का परीक्षण करें और उनके गणना किए गए मानों पर भरोसा करने से पहले पुष्टि करें, विशेषकर जब वे दस्तावेज़ीकृत सूची के बाहर के फ़ंक्शन उपयोग करते हों।
- उन सूत्रों के लिए जिनके लिए पूर्ण स्प्रेडशीट गणना इंजन आवश्यक है, उन्हें बाहरी रूप से गणना करें और फिर चार्ट कार्यपुस्तिका को परिणाम मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`formula` और `r1c1_formula` में क्या अंतर है?**

[formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/formula/) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [r1c1_formula](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। वह नोटेशन चुनें जो आपके सूत्र उत्पन्न या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**गणना के बाद मुझे सेल स्वयं पढ़नी चाहिए या उसका मान?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) एक `IChartDataCell` लौटाता है। पुनः गणना के बाद उस सेल की [value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी पढ़ें ताकि गणना किया गया परिणाम प्राप्त हो सके।

**`calculate_formulas` को कब कॉल करना चाहिए?**

इनपुट मान या सूत्र बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) कॉल करें। यह अंतर्निहित मूल्यांकनकर्ता द्वारा समर्थित सूत्रों के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। अंतर्निहित मूल्यांकनकर्ता केवल दस्तावेज़ीकृत उपसमुच्चय का समर्थन करता है। इस उपसमुच्चय के बाहर के फ़ंक्शन को सही ढंग से पुनः गणना मानने की उम्मीद न करें। यदि पूर्ण Excel सूत्र संगतता आवश्यक है, तो गणना को उचित स्प्रेडशीट इंजन से करें और अंतिम मानों को चार्ट कार्यपुस्तिका में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित सूत्र हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला गया है, तो कार्यपुस्तिका में पहले से गणना किया हुआ कैश मान मौजूद हो सकता है। संबंधित डेटा संशोधित करने के बाद वह कैश मान वैध नहीं रह सकता। ऐसे सूत्र वाले सेल को एक्सेस करने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उत्पन्न हो सकता है।

**क्या सूत्र त्रुटि मान Python अपवाद के समान हैं?**

नहीं। `#DIV/0!` जैसी त्रुटि मान एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) जैसे अपवाद दर्शाते हैं कि सूत्र सामान्य रूप से प्रोसेस नहीं किया जा सका।

**क्या सूत्र सेल बदलने पर चार्ट स्वतः अपडेट होता है?**

चार्ट श्रृंखला कार्यपुस्तिका सेल को संदर्भित कर सकती है। पहले कार्यपुस्तिका को पुनः गणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट उन अद्यतन मानों का उपयोग करेगा; इस कार्यफ़्लो के लिए कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel कार्यपुस्तिका का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी कार्यपुस्तिका के साथ कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित सूत्र गणना कार्यफ़्लो चार्ट डेटा कार्यपुस्तिका और Aspose.Slides द्वारा मूल्यांकित सूत्र उपसमुच्चय पर केंद्रित है। यह न मानें कि [calculate_formulas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) किसी भी बाहरी XLSX फ़ाइल में सभी सूत्रों को पूर्ण रूप से पुनः गणना करता है।

**क्या मैं ऐसे सूत्र उपयोग कर सकता हूँ जो किसी अन्य कार्यपत्रक या कार्यपुस्तिका को संदर्भित करते हों?**

Excel‑स्टाइल संदर्भ चार्ट कार्यपुस्तिकाओं में मौजूद हो सकते हैं, लेकिन सूत्र मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी संदर्भ अनिवार्य है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ उस विशिष्ट सूत्र को सत्यापित करें। व्यापक Excel संदर्भ संगतता की आवश्यकता वाले कार्यफ़्लो के लिए, कार्यपुस्तिका को बाहरी रूप से गणना करें और हल किए गए मानों को चार्ट डेटा में वापस लिखें।

**क्या सूत्र स्ट्रिंग `=` से शुरू होनी चाहिए?**

Aspose.Slides API उदाहरण अभिव्यक्तियों को `B2-C2` या `SUM(B2:B5)` के रूप में बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न सूत्र दस्तावेज़ीकृत API उदाहरणों के साथ संगत रहते हैं।