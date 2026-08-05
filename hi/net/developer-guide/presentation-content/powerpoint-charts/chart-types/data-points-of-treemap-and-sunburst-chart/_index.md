---
title: .NET में Treemap और Sunburst चार्ट के डेटा पॉइंट्स को अनुकूलित करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap चार्ट
- Sunburst चार्ट
- पदानुक्रमित चार्ट
- डेटा पॉइंट
- डेटा लेबल
- शाखा रंग
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ Treemap और Sunburst चार्ट में पदानुक्रमित डेटा बनाने और स्तरों, लेबलों तथा रंगों को अनुकूलित करने का तरीका जानें।"
---
## **परिचय**

Treemap और Sunburst चार्ट एक ही प्रकार के पदानुक्रमित डेटा को प्रदर्शित करते हैं, लेकिन वे अलग‑अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में बनाता है, जिनका क्षेत्रफल लीफ़ मानों को दर्शाता है। एक Sunburst इसे समद्विभुज छल्लों के रूप में दर्शाता है: शीर्ष‑स्तर समूह केंद्र के निकट होते हैं, और लीफ़ श्रेणियाँ बाहरी छल्ले पर स्थित होती हैं।

Aspose.Slides for .NET में, प्रत्येक संख्यात्मक मान एक [IChartDataPoint](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/) है। इसका [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) संग्रह लीफ़ और उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और दिखाता है कि समान नमूना डेटा से दोनों चार्ट प्रकारों को कैसे बनाएं और फॉर्मेट करें।

![उपभोक्ता और व्यवसाय शाखाओं के साथ एक Treemap चार्ट](treemap-hierarchy.png)

![उपभोक्ता और व्यवसाय पदानुक्रम के समान Sunburst चार्ट](sunburst-hierarchy.png)

## **श्रेणियों, डेटा पॉइंट्स और स्तरों को समझें**

नीचे उपयोग किए गए नमूने में तीन श्रेणी स्तर और एक संख्यात्मक श्रृंखला है:

| शाखा | मुख्य शाखा | पत्ती | राजस्व |
| --- | --- | --- | ---: |
| उपभोक्ता | कंप्यूटर | लैपटॉप | 12 |
| उपभोक्ता | कंप्यूटर | डेस्कटॉप | 8 |
| उपभोक्ता | मोबाइल | फ़ोन | 15 |
| उपभोक्ता | मोबाइल | टैबलेट | 6 |
| व्यवसाय | सेवाएं | परामर्श | 10 |
| व्यवसाय | सेवाएं | समर्थन | 7 |
| व्यवसाय | सॉफ़्टवेयर | लाइसेंस | 11 |
| व्यवसाय | सॉफ़्टवेयर | सब्सक्रिप्शन | 14 |

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी समूह स्तर उस पत्ती से उसके पैरेंट तक का पथ दर्शाते हैं। पहली पंक्ति के लिए, पथ है `उपभोक्ता > कंप्यूटर > लैपटॉप`।

[IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) में इंडेक्स पत्ती से ऊपर की ओर चलते हैं:

| `DataPointLevels` index | तार्किक स्तर | Treemap प्रतिनिधित्व | Sunburst प्रतिनिधित्व |
| ---: | --- | --- | --- |
| `0` | पत्ती | Value rectangle | Outer-ring segment |
| `1` | मुख्य | Parent rectangle or header | Middle-ring segment |
| `2` | शाखा | Top-level rectangle or header | Inner-ring segment |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है, भले ही उनके दृश्य लेआउट में अंतर हो। एक पैरेंट सेगमेंट कई पत्तियों द्वारा साझा किया जाता है। इसे फॉर्मेट करने के लिए, उस समूह में पहले डेटा पॉइंट के संबंधित स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` मुख्य `Licenses` पॉइंट से शुरू होता है। उन पॉइंट्स के रेफरेंस को रखना अस्पष्ट अभिव्यक्तियों जैसे `dataPoints[0]` या `dataPoints[6]` की तुलना में स्पष्ट और सुरक्षित है।

## **दोनों चार्ट प्रकारों को बनाना और अनुकूलित करना**

निम्न पूर्ण उदाहरण पहले स्लाइड पर एक Treemap तथा दूसरे स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम बनाता है, `Tablets` के मान को दिखाता है, चयनित स्तरों पर निश्चित रंग लागू करता है, एक शाखा लेबल को फॉर्मेट करता है, और प्रस्तुति को सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // लीफ़ श्रेणियों को जोड़ें। एक समूह वस्तु केवल तब ही सेट होती है जब नया समूह शुरू होता है;
    // अगली श्रेणियाँ उसी समूह में रहती हैं जब तक कोई अन्य वस्तु सेट नहीं की जाती।
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // टैबलेट्स लीफ़ पर श्रेणी और मान दिखाएँ।
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // उपभोक्ता शाखा को उस शाखा की पहली लीफ़ के माध्यम से फ़ॉर्मेट करें।
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // सॉफ़्टवेयर मुख्य को उस मुख्य की पहली लीफ़ के माध्यम से फ़ॉर्मेट करें।
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout Treemap पैरेंट लेबल को प्रभावित करता है; Sunburst रिंग सेगमेंट का उपयोग करता है।
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

श्रेणी सेल और मान सेल एक ही कार्यपत्र पंक्ति का उपयोग करते हैं, जिससे उनका संग्रह स्थितियों में संरेखित रहता है। जब आप एक मौजूदा चार्ट के साथ काम कर रहे हों बजाय नया बनाने के, तो पहले श्रेणी पंक्तियों की जाँच करें और उन डेटा पॉइंट्स और स्तरों के नामित रेफ़रेंस संग्रहीत करें जिन्हें आप फॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- Treemap क्षेत्र का उपयोग मान संप्रेषित करने और नेस्टेड आयतों के द्वारा पदानुक्रम दर्शाने के लिये करता है। इस चार्ट प्रकार में पैरेंट लेबल कैसे दिखते हैं, इसे [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/parentlabellayout/) प्रॉपर्टी नियंत्रित करती है।
- Sunburst कोण का उपयोग मान संप्रेषित करने और रिंग गहराई से पदानुक्रम दर्शाने के लिये करता है। इसके रिंग लेबल [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartseries/parentlabellayout/) द्वारा नियंत्रित नहीं होते हैं।
- दोनों चार्ट प्रकार समान श्रेणी समूह स्तर और `DataPointLevels` में वही पत्ती‑से‑पैरेंट क्रम उपयोग करते हैं, इसलिए डेटा‑बिल्डिंग और स्तर‑फ़ॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान उनके अवकल पत्तियों से गणना किए जाते हैं। शाखाओं या मुख्यों के लिये अलग संख्यात्मक पॉइंट्स न जोड़ें।

### **क्रमबद्धता और सेगमेंट क्रम**

चार्ट लेआउट इंजन आयतों और रिंग सेगमेंटों के अंतिम स्थान को निर्धारित करता है। उन्हें जोड़ने से पहले संबंधित श्रेणी पंक्तियों को साथ रखें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारंभिक कोण पर निर्भर न रहें। यदि क्रम का अर्थ है, तो उसे लेबल में शामिल करें या स्पष्ट श्रेणी अक्ष वाले चार्ट प्रकार का उपयोग करें।

### **थीम और निश्चित रंग**

अफ़ॉर्मेटेड चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण भविष्यवाणी योग्य आउटपुट के लिये स्पष्ट RGB फ़िल्स का उपयोग करता है। यदि चार्ट को थीम परिवर्तन के साथ अनुकूलित रहना है, तो स्थिर RGB मानों के बजाय स्कीम रंगों का उपयोग करें तथा हर स्तर को ओवरराइड करने से बचें। एक शाखा या मुख्य फ़िल बदलने के बाद लेबल कंट्रास्ट भी जाँचें।

### **लेबल्स और उपलब्ध स्थान**

जब सेगमेंट बहुत छोटा हो तो PowerPoint लेबल छुपा या ट्रंकेट कर सकता है। चार्ट आकार बढ़ाना, श्रेणी नाम छोटा करना, या कम लेबल फ़ील्ड दिखाना अक्सर स्पष्ट परिणाम देता है। एक लेबल [IDataLabelFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabelformat/) के माध्यम से श्रेणी नाम, श्रृंखला नाम और मान को संयोजन कर सकता है, लेकिन सभी फ़ील्ड को सक्षम करने से पदानुक्रम चार्ट पढ़ने में कठिन हो सकते हैं।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने पर चार्ट संपादन योग्य रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित फ़िल्स और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्थान में छोटे अंतर लाइन‑रैपिंग या लेबल दृश्यता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट स्थापित करें और महत्वपूर्ण निर्यात लक्ष्यों को सत्यापित करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**किस कारण से पैरेंट स्तर बदलने पर कई लीव्स प्रभावित होते हैं?**

एक शाखा या मुख्य एक साझा दृश्य सेगमेंट है। उसका [IChartDataPointLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/ichartdatapointlevel/) एक अवकल पत्ती द्वारा पहुँचा जा सकता है, लेकिन फॉर्मेटिंग साझा पैरेंट सेगमेंट को लागू होती है, न कि केवल उस पत्ती को।

**डेटा लेबल क्यों गायब है?**

पहले लेबल के [IDataLabelFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/idatalabelformat/) ऑब्जेक्ट पर आवश्यक फ़ील्ड को सक्षम करें। फिर जांचें कि सेगमेंट के पास पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार, और सक्षम फ़ील्ड की संख्या सभी यह निर्धारित करते हैं कि लेबल दिखाया जा सकेगा या नहीं।

**क्या मैं सेगमेंट्स का सटीक क्रम या निर्देशांक सेट कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर सकते हैं और प्रत्येक समूह को निरंतर रख सकते हैं, लेकिन आप Treemap आयतों या Sunburst कोणों को सटीक रूप से निर्दिष्ट नहीं कर सकते। चार्ट लेआउट इंजन उन्हें पदानुक्रम, मान और उपलब्ध स्थान से गणना करता है।

**प्रेजेंटेशन थीम बदलने पर रंग क्यों बदलते हैं?**

थीम‑आधारित फ़िल्स प्रस्तुति पैलेट का पालन करने के लिये डिज़ाइन किए गये हैं। उन स्तरों के लिये स्पष्ट RGB रंग लागू करें जिन्हें निश्चित रहना चाहिए, या नई थीम के अनुरूप स्कीम रंग रखें।

**क्या कस्टम फ़ॉर्मेटिंग PDF और इमेज निर्यात में संरक्षित रहेगी?**

हां, समर्थित चार्ट फ़िल्स और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होते हैं। स्थिर परिणामों के लिये आवश्यक फ़ॉन्ट उपलब्ध रखें और अंतिम निर्यात आकार का परीक्षण करें क्योंकि लेबल फ़िटिंग लेआउट‑निर्भर है।

## **संदर्भ**

- [Treemap चार्ट बनाएं](/slides/hi/net/create-chart/#create-tree-map-charts)
- [Sunburst चार्ट बनाएं](/slides/hi/net/create-chart/#create-sunburst-charts)
- [प्रेजेंटेशन चार्ट निर्यात](/slides/hi/net/export-chart/)
- [प्रेजेंटेशन थीम प्रबंधित करें](/slides/hi/net/presentation-theme/)