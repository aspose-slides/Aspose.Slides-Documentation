---
title: .NET में प्रस्तुतियों में चार्ट वर्कशीट फ़ॉर्मूले लागू करें
linktitle: वर्कशीट फ़ॉर्मूले
type: docs
weight: 70
url: /hi/net/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट फ़ॉर्मूला
- वर्कशीट फ़ॉर्मूला
- स्प्रेडशीट फ़ॉर्मूला
- चार्ट डेटा वर्कबुक
- फ़ॉर्मूला गणना
- लॉजिकल स्थिरांक
- न्यूमेरिकल स्थिरांक
- स्ट्रिंग स्थिरांक
- एरर स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- प्री‑डिफाइंड फ़ंक्शन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET चार्ट वर्कशीट्स में एक्सेल‑स्टाइल फ़ॉर्मूले लागू करें, मानों को पुनः गणना करें, और परिणामों को PowerPoint चार्ट्स में उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एक एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for .NET में, आप उस वर्कशीट तक चार्ट डेटा वर्कबुक के माध्यम से पहुँच सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूले असाइन कर सकते हैं, समर्थित फ़ॉर्मूलों की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला वर्कफ़्लो को समझाता है: चार्ट बनाएं, उसकी वर्कशीट को भरें, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूले असाइन करें, उन्हें पुनः गणना करें, गणना किए गए मान पढ़ें, उन सेल्स को चार्ट सीरीज़ से जोड़ें, और प्रस्तुति सहेजें। यह समर्थित फ़ॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैशेड मान, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट्स और फ़ॉर्मूले**

एक चार्ट वर्कशीट में वह श्रेणियाँ, सीरीज़ नाम, तथा मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [chart data workbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) के माध्यम से उजागर किया जाता है। A1‑स्टाइल फ़ॉर्मूलों के लिए [Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/formula/) प्रॉपर्टी और R1C1‑स्टाइल फ़ॉर्मूलों के लिए [R1C1Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) प्रॉपर्टी का उपयोग करें। इनपुट सेल या फ़ॉर्मूले बदलने के बाद, समर्थित फ़ॉर्मूलों को पुनः गणना करने और संबंधित सेल मानों को अपडेट करने के लिए [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

एक गणना किया गया सेल अभी भी अपना परिणाम [Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी के माध्यम से उजागर करता है। यह तब महत्वपूर्ण होता है जब आपको कोड में फ़ॉर्मूला परिणाम को निरीक्षण करना हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाएं और वर्कशीट फ़ॉर्मूले गणना करें**

निम्न उदाहरण एक संपूर्ण एन्ड‑टू‑एन्ड वर्कफ़्लो दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फ़ॉर्मूलों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

चार्ट डेटा पॉइंट्स `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस वर्कफ़्लो में कोई अलग चार्ट‑रीफ़्रेश कॉल नहीं है: पहले वर्कबुक को पुनः गणना करें, फिर गणना किए गए सेल्स को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell.Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/formula/) के माध्यम से असाइन करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

सामान्य A1 रेफरेंस रूप इस प्रकार हैं:

| रेफरेंस | रिलेटिव | एब्सोल्यूट | मिक्स्ड |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव रेफरेंस स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूला को स्थानांतरित या कॉपी करने पर बदल सकते हैं। एब्सोल्यूट रेफरेंस दोनों निर्देशांक को स्थिर रखता है, जबकि मिक्स्ड रेफरेंस केवल पंक्ति या कॉलम को फिक्स करता है।

## **R1C1‑स्टाइल फ़ॉर्मूले उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव रेफरेंस वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करते हैं। इस सिंटैक्स को [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) के माध्यम से असाइन करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

सामान्य R1C1 रेफरेंस रूप इस प्रकार हैं:

| रेफरेंस | रिलेटिव | एब्सोल्यूट | मिक्स्ड |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में, `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ वाला सेल (`B2`)।

## **फ़ॉर्मूला स्थिरांक और ऑपरेटर**

बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर लॉजिकल मान, न्यूमेरिक लिटरल, स्ट्रिंग, स्प्रेडशीट एरर मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को सपोर्ट करता है।

### **स्थिरांक और लिटरल**

| प्रकार | उदाहरण | नोट |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | सीधे लॉजिकल अभिव्यक्तियों में उपयोग किए जा सकते हैं जैसे `A2=TRUE`। |
| न्यूमेरिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | फ़ॉर्मूला में स्ट्रिंग लिटरल दोहरे उद्धरण चिह्नों में रखे जाते हैं। |
| एरर परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | वैध फ़ॉर्मूला कभी‑कभी सामान्य परिणाम के बजाय स्प्रेडशीट एरर मान दे सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // गलत
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नेगेशन | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम को स्पष्ट करने के लिए कोष्ठक उपयोग करें, उदाहरण ` (A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियां लॉजिकल मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | अलग | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित प्री‑डिफाइंड फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट्स के लिए एक बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। नीचे दर्शाए गए फ़ंक्शन ही प्रलेखित सेट का भाग हैं। यह न मानें कि कोई भी Excel फ़ंक्शन [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) द्वारा पुनः गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | अभाज़्य मान | `ABS(A2)` |
| `AVERAGE` | औसत | `AVERAGE(B2:B5)` |
| `CEILING` | ऊपरी निकटतम गुणज में गोल | `CEILING(A2,5)` |
| `CHOOSE` | सूचकांक द्वारा मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि मान बनाएं | `DATE(2026,8,19)` |
| `DAYS` | तिथियों के बीच दिनों की संख्या लौटाएं | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट‑ऑरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफरेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` रेफरेंस रूप में प्रलेखित है, जबकि `LOOKUP` और `MATCH` वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध न किए गए फ़ंक्शन और सुविधाएँ Aspose.Slides के फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित मानी जानी चाहिए, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पुनर्गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें अक्सर फ़ॉर्मूला और उसका अंतिम गणना किया गया मान दोनों संग्रहीत करती हैं। इसलिए Aspose.Slides प्रस्तुति लोड होने पर [IChartDataCell.Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) से कैश्ड मान पढ़ सकता है, बशर्ते संबंधित चार्ट डेटा बदला न गया हो।

इनपुट सेल या फ़ॉर्मूले बदलने के बाद, पुरानी कैश्ड परिणाम पर निर्भर न रहें। गणना किए गए मानों को पढ़ने या उन पर निर्भर होकर चार्ट डेटा सहेजने से पहले [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फ़ॉर्मूले के लिये, Aspose.Slides फ़ॉर्मूला को पार्स करने या उसकी निर्भरताओं को स्थापित करने में सक्षम नहीं हो सकता। यदि वर्कबुक संशोधित की गई है, तो पिछला कैश्ड मान अब भरोसेमंद नहीं माना जा सकता। ऐसे मामले में असमर्थित डेटा वाले सेल का मान पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उत्पन्न हो सकता है।

यदि आपका चार्ट उन Excel फ़ंक्शनों पर निर्भर करता है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ॉर्मूलों को ऐसी स्प्रेडशीट इंजन से गणना करें जो उनका समर्थन करता हो और परिणामित मानों को चार्ट वर्कबुक में लिखें। असमर्थित फ़ॉर्मूले को अनुमानित मानों से बदलने से बचें।

## **फ़ॉर्मूला त्रुटियों को संभालें**

दो अलग‑अलग प्रकार की समस्याएं होती हैं।

एक फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम दे सकता है जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!`। इस स्थिति में त्रुटि टोकन एक सेल परिणाम है और `Value` के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिये स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनर्गणना और मान पहुँच के चारों ओर इन अपवादों को हैंडल करें:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **व्यावहारिक सीमाएं**

चार्ट वर्कशीट्स में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिये है, पूर्ण Excel संगतता नहीं। रिपोर्टिंग वर्कफ़्लो डिज़ाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- केवल प्रलेखित स्थिरांक, ऑपरेटर, रेफ़रेंस और फ़ंक्शन का उपयोग करें जब आपको Aspose.Slides से फ़ॉर्मूला पुनर्गणना चाहिए।
- उन सेल्स को बदलने के बाद पुनर्गणना करें जिन पर फ़ॉर्मूला परिणाम निर्भर करता है।
- लोडेड प्रस्तुतियों से प्राप्त कैश्ड मान स्नैपशॉट होते हैं, संपादन के बाद पुनर्गणना के विकल्प नहीं।
- मौजूदा टेम्प्लेट से फ़ॉर्मूले का परीक्षण करें, विशेष रूप से जब वे प्रलेखित सूची से बाहर के फ़ंक्शन उपयोग करते हों।
- पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता वाले फ़ॉर्मूले को बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`Formula` और `R1C1Formula` में क्या अंतर है?**

[Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/formula/) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [R1C1Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। उस नोटेशन का उपयोग करें जो आपके फ़ॉर्मूला उत्पन्न या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**गणना के बाद क्या मुझे सेल स्वयं या उसका मूल्य पढ़ना चाहिए?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/getcell/) एक `IChartDataCell` लौटाता है। गणना के बाद उस सेल के [Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी को पढ़ें ताकि गणना किया गया परिणाम प्राप्त हो सके।

**`CalculateFormulas` कब कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूले बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित फ़ॉर्मूलों के मान अपडेट करता है।

**क्या Aspose.Slides सभी Excel फ़ंक्शन को सपोर्ट करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर दस्तावेज़ित फ़ंक्शन उपसमुच्चय को ही सपोर्ट करता है। उस उपसमुच्चय से बाहर के फ़ंक्शन को सही ढंग से पुनः गणना होने की उम्मीद न करें। यदि पूर्ण Excel फ़ॉर्मूला संगतता चाहिए, तो गणना को उपयुक्त स्प्रेडशीट इंजन से करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोडेड प्रस्तुतियों में असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान रह सकता है। संबंधित डेटा में परिवर्तन के बाद वह कैश्ड मान अब वैध नहीं रह सकता। ऐसी स्थिति में असमर्थित फ़ॉर्मूला वाले सेल को एक्सेस करने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उठ सकता है।

**क्या फ़ॉर्मूला त्रुटि मान .NET अपवाद के समान हैं?**

नहीं। `#DIV/0!` जैसी त्रुटि वैध गणना से उत्पन्न स्प्रेडशीट मान है। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) जैसी अपवाद दर्शाते हैं कि फ़ॉर्मूला सामान्य रूप से प्रोसेस नहीं किया जा सका।

**क्या फ़ॉर्मूला सेल बदलने पर चार्ट अपने‑आप अपडेट हो जाता है?**

चार्ट सीरीज़ वर्कबुक सेल्स को संदर्भित कर सकते हैं। पहले वर्कबुक को पुनः गणना करें, फिर प्रस्तुति सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट उन अपडेटेड मानों का उपयोग करेगा; इस वर्कफ़्लो के लिये कोई अलग चार्ट‑रीफ़्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हां, चार्ट डेटा को API के माध्यम से बाहरी वर्कबुक की ओर संकेत करने के लिये कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना वर्कफ़्लो केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसमुच्चय से संबंधित है। यह न मानें कि [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) बाहरी XLSX फ़ाइल में मनमाने फ़ॉर्मूलों की पूर्ण पुनर्गणना करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो दूसरे वर्कशीट या वर्कबुक को संदर्भित करते हों?**

चार्ट वर्कबुक में Excel‑स्टाइल रेफ़रेंस हो सकते हैं, पर फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्षित Aspose.Slides संस्करण में उस फ़ॉर्मूले को ठीक‑ठाक टेस्ट करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले वर्कफ़्लो में, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू करना चाहिए?**

Aspose.Slides API उदाहरण ऐसे अभिव्यक्तियों को असाइन करते हैं जैसे `B2-C2` या `SUM(B2:B5)` बिना अग्रणी `=` के। इस रूप का उपयोग करने से उत्पन्न फ़ॉर्मूले API उदाहरणों के अनुरूप बने रहते हैं।