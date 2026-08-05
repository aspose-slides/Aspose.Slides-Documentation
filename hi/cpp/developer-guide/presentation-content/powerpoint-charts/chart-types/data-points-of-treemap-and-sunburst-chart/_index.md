---
title: "C++ में Treemap और Sunburst चार्ट में डेटा पॉइंट्स को कस्टमाइज़ करें"
linktitle: "Treemap और Sunburst चार्ट में डेटा पॉइंट्स"
type: docs
url: /hi/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap चार्ट
- Sunburst चार्ट
- पदानुक्रमित चार्ट
- डेटा पॉइंट
- डेटा लेबल
- ब्रांच रंग
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ Treemap और Sunburst चार्ट में पदानुक्रमित डेटा बनाने तथा स्तर, लेबल और रंग को कस्टमाइज़ करने का तरीका जानें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट समान प्रकार के पदानुक्रमित डेटा को प्रदर्शित करते हैं, लेकिन वे अलग‑अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में खींचता है, जिनके क्षेत्र leaf मानों का प्रतिनिधित्व करते हैं। एक Sunburst इसे concentric रिंग के रूप में दर्शाता है: शीर्ष‑स्तर के समूह केंद्र के पास होते हैं, और leaf श्रेणियाँ बाहरी रिंग पर होती हैं।

Aspose.Slides for C++ में प्रत्येक संख्यात्मक मान एक [IChartDataPoint](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/) है। इसका [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) मेथड leaf तथा उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और समान नमूना डेटा से दोनों चार्ट प्रकारों को बनाने और फॉर्मेट करने का तरीका दिखाता है।

![Consumer और Business शाखाओं के साथ एक Treemap चार्ट](treemap-hierarchy.png)

![उसी Consumer और Business पदानुक्रम के साथ एक Sunburst चार्ट](sunburst-hierarchy.png)

## **श्रेणियों, डेटा पॉइंट्स और स्तरों को समझें**

नीचे उपयोग किया गया नमूना तीन श्रेणी स्तरों और एक संख्यात्मक श्रृंखला को दर्शाता है:

| शाखा | संरचना | पत्ती | राजस्व |
| --- | --- | --- | ---: |
| उपभोक्ता | कंप्यूटर | लैपटॉप | 12 |
| उपभोक्ता | कंप्यूटर | डेस्कटॉप | 8 |
| उपभोक्ता | मोबाइल | फ़ोन | 15 |
| उपभोक्ता | मोबाइल | टैबलेट | 6 |
| व्यवसाय | सेवाएँ | परामर्श | 10 |
| व्यवसाय | सेवाएँ | समर्थन | 7 |
| व्यवसाय | सॉफ़्टवेयर | लाइसेंस | 11 |
| व्यवसाय | सॉफ़्टवेयर | सब्सक्रिप्शन | 14 |

प्रत्येक पंक्ति एक leaf श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी समूह स्तर leaf से उसके पैरेंट तक का पथ दर्शाते हैं। पहली पंक्ति के लिए पथ `Consumer > Computers > Laptops` है।

[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) द्वारा लौटाए गए इंडेक्स leaf से ऊपर की ओर क्रमबद्ध होते हैं:

| `get_DataPointLevels()` इंडेक्स | तर्कसंगत स्तर | Treemap प्रतिनिधित्व | Sunburst प्रतिनिधित्व |
| ---: | --- | --- | --- |
| `0` | पत्ती | मान आयत | बाहरी‑रिंग खंड |
| `1` | संरचना | पैरेंट आयत या हेडर | मध्य‑रिंग खंड |
| `2` | शाखा | शीर्ष‑स्तर आयत या हेडर | भीतरी‑रिंग खंड |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है, हालांकि उनके दृश्य लेआउट भिन्न होते हैं। एक पैरेंट खंड कई leaf द्वारा साझा किया जाता है। इसे फॉर्मेट करने के लिए, उस समूह में पहले डेटा पॉइंट के अनुरूप स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` संरचना `Licenses` पॉइंट से शुरू होती है। उन पॉइंट्स के संदर्भ को रखना अस्पष्ट अभिव्यक्तियों जैसे `dataPoints->idx_get(0)` या `dataPoints->idx_get(6)` की तुलना में स्पष्ट एवं सुरक्षित रहता है।

## **दोनों चार्ट प्रकारों को बनाएं और अनुकूलित करें**

निम्नलिखित सम्पूर्ण उदाहरण पहले स्लाइड पर एक Treemap और दूसरे स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम का निर्माण करता है, `Tablets` के लिए मान प्रदर्शित करता है, चयनित स्तरों पर स्थिर रंग लागू करता है, एक शाखा लेबल को फॉर्मेट करता है, और प्रस्तुति को सहेजता है।

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // लीफ़ श्रेणियों को जोड़ें। समूह आइटम केवल तब सेट किया जाता है जब नया समूह शुरू हो;
    // इसके बाद की श्रेणियाँ उसी समूह में रहती हैं जब तक कोई अन्य आइटम सेट न किया जाए।
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Tablets leaf पर श्रेणी और मान दिखाएँ।
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Consumer शाखा को उस शाखा के पहले leaf के माध्यम से फॉर्मेट करें।
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Software स्टेम को उस स्टेम के पहले leaf के माध्यम से फॉर्मेट करें।
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout Treemap के पैरेंट लेबल्स को प्रभावित करता है; Sunburst रिंग सेगमेंट्स का उपयोग करता है।
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

श्रेणी कोशिकाएँ और मान कोशिकाएँ समान वर्कशीट पंक्ति का उपयोग करती हैं, इसलिए उनका संग्रह क्रम संरेखित रहता है। जब आप मौजूदा चार्ट के साथ काम कर रहे हों बजाय नया बनाने के, तो पहले श्रेणी पंक्तियों की जाँच करें और उन डेटा पॉइंट्स एवं स्तरों के नामित संदर्भ रखें जिन्हें आप फॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- एक Treemap मूल्य को संप्रेषित करने के लिए क्षेत्र का उपयोग करता है और पदानुक्रम को दर्शाने के लिए नेस्टेड आयतों का। इस चार्ट प्रकार में पैरेंट लेबल कैसे दिखते हैं, यह [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) मेथड नियंत्रित करता है।
- एक Sunburst मूल्य को संप्रेषित करने के लिए कोण का उपयोग करता है और पदानुक्रम को दर्शाने के लिए रिंग‑गहराई। इसका रिंग लेबल [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) द्वारा नियंत्रित नहीं होता।
- दोनों चार्ट प्रकार समान श्रेणी समूह स्तर और समान leaf‑से‑पैरेंट क्रम का उपयोग करते हैं, जो [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) द्वारा लौटाया जाता है, इसलिए डेटा‑निर्माण और स्तर‑फॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान उनके अंतिम leaf से गणना किए जाते हैं। शाखाओं या संरचनाओं के लिए अलग‑अलग संख्यात्मक पॉइंट न जोड़ें।

### **क्रमबद्धता और खंड क्रम**

चार्ट लेआउट इंजन आयतों और रिंग‑खंडों की अंतिम स्थिति निर्धारित करता है। उन्हें जोड़ने से पहले संबंधित श्रेणी पंक्तियों को साथ‑साथ रखें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारंभिक कोण पर भरोसा न करें। यदि क्रम का अर्थ है, तो उसे लेबल में शामिल करें या स्पष्ट श्रेणी अक्ष वाला चार्ट उपयोग करें।

### **थीम और स्थिर रंग**

अप्रकाशित चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण पूर्वानुमेय आउटपुट के लिए स्पष्ट RGB फ़िल्स का उपयोग करता है। यदि चार्ट को थीम परिवर्तन के साथ अनुसरण करना है, तो स्थिर RGB मानों के बजाय स्कीम‑कलर उपयोग करें और हर स्तर को अधिलेखित करने से बचें। साथ ही किसी शाखा या संरचना के फ़िल बदलने के बाद लेबल कंट्रास्ट जाँचें।

### **लेबल और उपलब्ध स्थान**

PowerPoint कभी‑कभी खंड बहुत छोटा होने पर लेबल को छिपा या काट सकता है। चार्ट आकार बढ़ाना, श्रेणी नाम छोटा करना, या कम लेबल फ़ील्ड दिखाना आमतौर पर स्पष्ट परिणाम देता है। एक लेबल श्रेणी नाम, श्रृंखला नाम और मान को [IDataLabelFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/) के माध्यम से जोड़ सकता है, लेकिन सभी फ़ील्ड सक्षम करने से पदानुक्रमित चार्ट पढ़ने में कठिन हो सकते हैं।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने से चार्ट संपादनीय रहता है। जब Aspose.Slides प्रस्तुति को PDF या छवि में रेंडर करता है, तो समर्थित फ़िल और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्थान में छोटे अंतर लाइन‑रैपिंग या लेबल दृश्यता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट स्थापित करें और महत्वपूर्ण निर्यात लक्ष्य सत्यापित करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक पैरेंट स्तर बदलने से कई leaf प्रभावित क्यों होते हैं?**

एक शाखा या संरचना एक साझा दृश्य खंड है। उसका [IChartDataPointLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/) एक अवनति leaf के माध्यम से पहुँचा जा सकता है, लेकिन फॉर्मेटिंग साझा पैरेंट खंड को लागू होती है, न कि केवल उस leaf को।

**डेटा लेबल क्यों गायब है?**

पहले लेबल के आवश्यक फ़ील्ड को उसके [IDataLabelFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatalabelformat/) ऑब्जेक्ट पर सक्षम करें। फिर जाँचें कि खंड के पास पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार और सक्षम फ़ील्ड संख्या सभी यह निर्धारित करते हैं कि लेबल दिखाया जाएगा या नहीं।

**क्या मैं खंडों का सटीक क्रम या समन्वय निर्धारित कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर प्रत्येक समूह को क्रमबद्ध रख सकते हैं, लेकिन आप सटीक Treemap आयत या Sunburst कोण नहीं तय कर सकते। चार्ट लेआउट इंजन इन्हें पदानुक्रम, मान और उपलब्ध स्थान से गणना करता है।

**प्रेज़ेंटेशन थीम बदलने के बाद रंग क्यों बदलते हैं?**

थीम‑आधारित फ़िल प्रस्तुति पैलेट के अनुरूप होते हैं। उन स्तरों पर स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रहना चाहिए, या नई थीम पर अनुकूलन के लिये स्कीम‑कलर रखें।

**क्या कस्टम फॉर्मेटिंग PDF और छवि निर्यात में संरक्षित रहती है?**

हाँ, समर्थित चार्ट फ़िल और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होते हैं। संगत परिणामों के लिये आवश्यक फ़ॉन्ट उपलब्ध कराएँ और अंतिम निर्यात आकार का परीक्षण करें, क्योंकि लेबल फिटिंग लेआउट‑निर्भर होती है।

## **संबंधित लिंक**

- [Treemap चार्ट बनाएं](/slides/hi/cpp/create-chart/#create-tree-map-charts)
- [Sunburst चार्ट बनाएं](/slides/hi/cpp/create-chart/#create-sunburst-charts)
- [प्रेज़ेंटेशन चार्ट निर्यात](/slides/hi/cpp/export-chart/)
- [प्रेज़ेंटेशन थीम प्रबंधन](/slides/hi/cpp/presentation-theme/)