---
title: ".NET में प्रेज़ेंटेशन में चार्ट वर्कशीट फ़ॉर्मूले लागू करें"
linktitle: "वर्कशीट फ़ॉर्मूले"
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
- पसंदीदा संस्कृति
- संस्कृति-विशिष्ट फ़ॉर्मूला
- DBCS
- तर्कीय कॉन्स्टेंट
- संख्यात्मक कॉन्स्टेंट
- स्ट्रिंग कॉन्स्टेंट
- एरर कॉन्स्टेंट
- अंकगणितीय ऑपरेटर
- तुलनात्मक ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वपरिभाषित फ़ंक्शन
- PowerPoint
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides में Excel-शैली के फ़ॉर्मूले लागू करें, चार्ट वर्कशीट्स में मानों को पुनर्गणना करें, और परिणामों को PowerPoint चार्ट्स में उपयोग करें."
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for .NET में, आप उस वर्कशीट तक चार्ट डेटा वर्कबुक के माध्यम से पहुँच सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूला असाइन कर सकते हैं, समर्थित फ़ॉर्मूले की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख संपूर्ण फ़ॉर्मूला कार्यप्रवाह को समझाता है: चार्ट बनाना, उसकी वर्कशीट को भरना, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूले असाइन करना, उन्हें पुनर्गणना करना, गणना किए गए मान पढ़ना, उन सेल्स को चार्ट सीरीज़ से जोड़ना, और प्रेज़ेंटेशन सहेजना। यह समर्थित फ़ॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित फ़ॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी विवरण देता है।

## **चार्ट वर्कशीट्स और फ़ॉर्मूले**

एक चार्ट वर्कशीट में कैटेगरीज, सीरीज़ नाम, और मान होते हैं जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट को देख सकते हैं:

![PowerPoint चार्ट जिसके एम्बेडेड वर्कशीट खुला है, जिसमें कैटेगरी और सीरीज़ डेटा दिखाया गया है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [chart data workbook](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/) के माध्यम से एक्सपोज़ किया जाता है। A1‑स्टाइल फ़ॉर्मूले के लिये [Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/formula/) प्रॉपर्टी और R1C1‑स्टाइल फ़ॉर्मूले के लिये [R1C1Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) प्रॉपर्टी का उपयोग करें। इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, समर्थित फ़ॉर्मूले को पुनर्गणना करने और सम्बंधित सेल मानों को अपडेट करने के लिये [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

एक गणना किया गया सेल अभी भी अपने परिणाम को [Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी के माध्यम से उजागर करता है। यह तब महत्वपूर्ण होता है जब आपको कोड में फ़ॉर्मूला परिणाम की जाँच करनी हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाएं और वर्कशीट फ़ॉर्मूले गणना करें**

निम्न उदाहरण एक एंड‑टू‑एंड कार्यप्रवाह को दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, तिमाही राजस्व और खर्च मान लिखता है, फ़ॉर्मूले से लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मानों के रूप में उपयोग करता है, और प्रेज़ेंटेशन सहेजता है।

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

चार्ट डेटा पॉइंट्स `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनर्गणना करें, फिर उन कैल्क्युलेटेड सेल्स को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले उपयोग करें**

A1 नोटेशन में कॉलम को अक्षरों से और पंक्तियों को अंकों से पहचाना जाता है। [IChartDataCell.Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/formula/) के माध्यम से A1‑स्टाइल अभिव्यक्तियां असाइन करें।

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

सामान्य A1 संदर्भ रूप इस प्रकार हैं:

| संदर्भ | सापेक्ष | परिपूर्ण | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष संदर्भ स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूला को ले जाने या कॉपी करने पर बदल सकते हैं। परिपूर्ण संदर्भ दोनों निर्देशांक को स्थिर रखता है, जबकि मिश्रित संदर्भ केवल पंक्ति या कॉलम को स्थिर रखता है।

## **R1C1‑स्टाइल फ़ॉर्मूले उपयोग करें**

R1C1 नोटेशन में पंक्तियों और कॉलम दोनों को संख्यात्मक रूप में पहचाना जाता है। सापेक्ष संदर्भ वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करते हैं। इस सिंटैक्स को [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) के माध्यम से असाइन करें।

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

सामान्य R1C1 संदर्भ रूप इस प्रकार हैं:

| संदर्भ | सापेक्ष | परिपूर्ण | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ वाला सेल (`B2`)।

## **फ़ॉर्मूला कॉन्स्टेंट्स और ऑपरेटर्स**

बिल्ट‑इन फ़ॉर्मूला इवैल्यूएटर लॉजिकल वैल्यूज़, न्यूमेरिक लिटेरल्स, स्ट्रिंग्स, स्प्रेडशीट एरर वैल्यूज़, एरिथ्मेटिक ऑपरेटर्स, और कम्पेरेज़न ऑपरेटर्स को सपोर्ट करता है।

### **कॉन्स्टेंट्स और लिटेरल्स**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | सीधे लॉजिकल अभिव्यक्तियों जैसे `A2=TRUE` में उपयोग किया जा सकता है। |
| न्यूमेरिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | टेक्स्ट लिटेरल्स फ़ॉर्मूला के भीतर डबल कोट्स में लिखे जाते हैं। |
| एरर परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | एक वैध फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट एरर वैल्यू में भीevaluate हो सकता है। |

यह उदाहरण कई कॉन्स्टेंट प्रकारों का उपयोग करता है:

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

### **अंकगणितीय ऑपरेटर्स**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या निगेटिव | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घात | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिये कोष्ठकों का प्रयोग करें, उदाहरण के लिये `(A2+B2)*C2`।

### **कम्पेरेज़न ऑपरेटर्स**

कम्पेरेज़न अभिव्यक्तियां लॉजिकल मान देती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित प्री‑डिफ़ाइंड फ़ंक्शन्स**

Aspose.Slides चार्ट वर्कशीट्स के लिये एक बिल्ट‑इन फ़ॉर्मूला इवैल्यूएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शन्स तक सीमित है। यह मान कर न चलें कि कोई भी मनचाहा Excel फ़ंक्शन [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) द्वारा पुनर्गणित किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | पूर्ण मान | `ABS(A2)` |
| `AVERAGE` | औसत | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर निकटतम गुणज तक राउंड | `CEILING(A2,5)` |
| `CHOOSE` | सूचकांक द्वारा मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मानों को जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मानों को जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तारीख प्रणाली का उपयोग कर तिथि मान बनाएं | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड टेक्स्ट सर्च | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए प्रतिबंध महत्वपूर्ण हैं: `INDEX` रेफ़रेंस रूप में दस्तावेज़ित है, जबकि `LOOKUP` और `MATCH` अपने वेक्टर रूप में हैं। `DATE` 1900 प्रणाली का उपयोग करता है। यहाँ न सूचीबद्ध फीचर्स और फ़ंक्शन Aspose.Slides फ़ॉर्मूला इवैल्यूएटर द्वारा असमर्थित माने जाएंगे, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पसंदीदा संस्कृति के साथ फ़ॉर्मूले गणना करें**

कुछ चार्ट वर्कबुक फ़ंक्शन टेक्स्ट को संस्कृति‑विशिष्ट नियमों के अनुसार व्याख्या करते हैं। यह विशेष रूप से उन फ़ंक्शनों के लिये महत्वपूर्ण है जो डबल‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिये होते हैं। ऐसे फ़ॉर्मूले सही ढंग से गणना करने के लिये, [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) बनाएं, [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/spreadsheetoptions/) के माध्यम से [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/hi/net/aspose.slides/ispreadsheetoptions/preferredculture/) सेट करें, और फिर प्रेज़ेंटेशन लोड करें।

निम्न उदाहरण जापानी संस्कृति चुनता है, कॉन्फ़िगर्ड लोड ऑप्शन्स के साथ प्रेज़ेंटेशन खोलता है, और प्रत्येक चार्ट वर्कबुक के लिये [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करता है:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

पसंदीदा संस्कृति प्रेज़ेंटेशन लोडिंग कॉन्फ़िगरेशन का हिस्सा है, इसलिए इसे [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस बनाने से पहले निर्दिष्ट करें। वर्कबुक फ़ॉर्मूले द्वारा अपेक्षित संस्कृति का उपयोग करें; उदाहरण के लिये, जापानी DBCS गणना नियमों के लिये `ja-JP` उपयोग करें।

## **पुनर्गणना और कैश्ड वैल्यूज़**

स्प्रेडशीट फ़ाइलें सामान्यतः फ़ॉर्मूला और उसके अंतिम गणना किए गए मान दोनों को संग्रहीत करती हैं। Aspose.Slides इसलिए [IChartDataCell.Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) से कैश्ड वैल्यू पढ़ सकता है, जब प्रेज़ेंटेशन लोड किया जाता है और सम्बंधित चार्ट डेटा में कोई बदलाव नहीं हुआ है।

इनपुट सेल्स या फ़ॉर्मूले बदलने के बाद, पुराने कैश्ड परिणाम पर भरोसा न करें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा सहेजने से पहले [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फ़ॉर्मूले के लिये, Aspose.Slides को फ़ॉर्मूला पार्स करने या उसकी निर्भरताओं को स्थापित करने में असमर्थता हो सकती है। यदि वर्कबुक बदल दिया गया है, तो पूर्व कैश्ड मान अब भरोसेमंद नहीं माना जा सकता। ऐसे में असमर्थित डेटा वाले सेल के मान को पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उठाया जा सकता है।

यदि आपका चार्ट उन Excel फ़ंक्शन्स पर निर्भर है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ॉर्मूलों को किसी ऐसे स्प्रेडशीट इंजन से गणना करें जो उनका समर्थन करता हो और उत्पन्न मानों को चार्ट वर्कबुक में लिखें। असमर्थित फ़ॉर्मूले को अनुमानित मानों से न बदलें।

## **फ़ॉर्मूला त्रुटियों को संभालें**

दो प्रकार की समस्याओं को अलग‑अलग पहचानना आवश्यक है।

एक फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` दे सकता है। इस मामले में, त्रुटि टोकन सेल परिणाम है और `Value` के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिये स्प्रेडशीट‑विशिष्ट एक्सेप्शन प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)।

जब फ़ॉर्मूले टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनर्गणना और वैल्यू एक्सेस के चारों ओर इन एक्सेप्शन को हैंडल करें:

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

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिये है, न कि पूर्ण Excel संगतता के लिये। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन प्रतिबंधों को याद रखें:

- जब आप Aspose.Slides को फ़ॉर्मूले पुनर्गणना करवाना चाहते हैं, केवल दस्तावेज़ित कॉन्स्टेंट्स, ऑपरेटर्स, रेफ़रेंसेस और फ़ंक्शन्स का उपयोग करें।
- उन सेल्स को बदलने के बाद पुनर्गणना करें जिनपर फ़ॉर्मूला परिणाम निर्भर करता है।
- लोड किए गए प्रेज़ेंटेशनों से प्राप्त कैश्ड मानों को स्नैपशॉट मानें, संशोधनों के बाद पुनर्गणना के विकल्प के रूप में न लें।
- मौजूदा टेम्प्लेट्स के फ़ॉर्मूले को उनके गणना किए गए मानों पर भरोसा करने से पहले परीक्षण करें, विशेषकर जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन्स का उपयोग करते हों।
- उन फ़ॉर्मूलों के लिये जो पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता रखते हैं, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणामी मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`Formula` और `R1C1Formula` में क्या अंतर है?**

[Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/formula/) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` को संग्रहीत करता है। [R1C1Formula](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/r1c1formula/) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` को संग्रहीत करता है। वह नोटेशन प्रयोग करें जो आपके फ़ॉर्मूले उत्पन्न या कॉपी करने के तरीके से मेल खाता हो।

**गणना के बाद क्या मुझे सेल स्वयं पढ़ना चाहिए या उसका मान?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/getcell/) एक `IChartDataCell` लौटाता है। पुनर्गणना के बाद उस सेल की [Value](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatacell/value/) प्रॉपर्टी को पढ़कर गणना किया गया परिणाम प्राप्त करें।

**`CalculateFormulas` को कब कॉल करना चाहिए?**

इनपुट मानों या फ़ॉर्मूलों को बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें। यह बिल्ट‑इन इवैल्यूएटर द्वारा समर्थित फ़ॉर्मूलों के मानों को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन को समर्थन देता है?**

नहीं। बिल्ट‑इन इवैल्यूएटर दस्तावेज़ित फ़ंक्शनों के उपसमुच्चय को समर्थन देता है। उस उपसमुच्चय के बाहर के फ़ंक्शन यह मान कर न चलें कि वे सही ढंग से पुनर्गणित होंगे। अगर पूर्ण Excel फ़ॉर्मूला संगतता आवश्यक है, तो गणना को उपयुक्त स्प्रेडशीट इंजन से करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड किए गए प्रेज़ेंटेशन में असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान मौजूद रह सकता है। संबंधित डेटा बदलने के बाद वह कैश्ड मान अब मान्य नहीं रह सकता। ऐसा फ़ॉर्मूला वाला सेल एक्सेस करने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) उठ सकता है।

**क्या फ़ॉर्मूला एरर वैल्यूज़ .NET एक्सेप्शन के समान हैं?**

नहीं। `#DIV/0!` जैसी परिणाम एक वैध फ़ॉर्मूला द्वारा उत्पन्न स्प्रेडशीट वैल्यू है। इसके विपरीत, [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) जैसे एक्सेप्शन दर्शाते हैं कि फ़ॉर्मूला सामान्य रूप से प्रोसेस नहीं हो सका।

**क्या फ़ॉर्मूले वाले सेल बदलने पर चार्ट स्वतः अपडेट होता है?**

चार्ट सीरीज़ वर्कबुक सेल्स को संदर्भित कर सकती है। पहले वर्कबुक को पुनर्गणना करें, फिर प्रेज़ेंटेशन सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को संदर्भित करते हैं, तो चार्ट उन अपडेटेड मानों का उपयोग करेगा; इस कार्यप्रवाह के लिये कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक से कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकन किए जाने वाले फ़ॉर्मूला उपसमुच्चय से सम्बंधित है। यह मान कर न चलें कि [CalculateFormulas](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) बाहरी XLSX फ़ाइल में मनचाहे फ़ॉर्मूलों की पूर्ण पुनर्गणना करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को संदर्भित करते हैं?**

Excel‑स्टाइल रेफ़रेंसेस चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट से सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ सटीक फ़ॉर्मूला को सत्यापित करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले कार्यप्रवाहों के लिये, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को वापस चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न फ़ॉर्मूले दस्तावेज़ित API उदाहरणों के साथ संगत रहते हैं।