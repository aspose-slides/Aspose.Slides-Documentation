---
title: PHP में Treemap और Sunburst चार्ट में डेटा पॉइंट्स को अनुकूलित करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap चार्ट
- Sunburst चार्ट
- पदानुक्रमित चार्ट
- डेटा पॉइंट
- डेटा लेबल
- शाखा रंग
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ Treemap और Sunburst चार्ट में पदानुक्रमित डेटा बनाने और स्तर, लेबल और रंग को अनुकूलित करने का तरीका जानें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट समान प्रकार के पदानुक्रमित डेटा को प्रदर्शित करते हैं, लेकिन वे अलग‑अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में प्रस्तुत करता है, जिनका क्षेत्रफल पत्ती के मान को दर्शाता है। एक Sunburst इसे समकोणीय छल्लों के रूप में दर्शाता है: शीर्ष‑स्तर के समूह केंद्र के निकट होते हैं, और पत्ती श्रेणियाँ बाहरी छल्ले पर होती हैं।

Aspose.Slides for PHP via Java में प्रत्येक संख्यात्मक मान एक [ChartDataPoint](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/) होता है। इसका [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) मेथड पत्ती और उसके माता‑पिता समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और दिखाता है कि समान नमूना डेटा से दोनों प्रकार के चार्ट कैसे बनाएं और फ़ॉर्मेट करें।

![Consumer और Business शाखाओं के साथ Treemap चार्ट](treemap-hierarchy.png)

![एक ही Consumer और Business पदानुक्रम के साथ Sunburst चार्ट](sunburst-hierarchy.png)

## **श्रेणियों, डेटा बिंदुओं, और स्तरों को समझें**

नीचे उपयोग किया गया नमूना तीन श्रेणी स्तरों और एक संख्यात्मक श्रृंखला वाला है:

| शाखा | स्टेम | पत्ती | राजस्व |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा बिंदु बनाती है। श्रेणी समूह स्तर पत्ती से उसके अभिभावकों तक का पथ दर्शाते हैं। पहली पंक्ति के लिए पथ है `Consumer > Computers > Laptops`।

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) द्वारा लौटाए गए सूचकांक पत्ती से ऊपर की ओर चलते हैं:

| `getDataPointLevels()` इंडेक्स | तर्कसंगत स्तर | Treemap प्रतिनिधित्व | Sunburst प्रतिनिधित्व |
| ---: | --- | --- | --- |
| `0` | पत्ती | मान आयत | बाहरी‑छल्ला खंड |
| `1` | स्टेम | अभिभावक आयत या हेडर | मध्य‑छल्ला खंड |
| `2` | शाखा | शीर्ष‑स्तर आयत या हेडर | भीतरी‑छल्ला खंड |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है, हालांकि उनके दृश्य लेआउट भिन्न होते हैं। एक अभिभावक खंड कई पत्तियों द्वारा साझा किया जाता है। उसे फ़ॉर्मेट करने के लिए, उस समूह के पहले डेटा बिंदु के अनुरूप स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` बिंदु से शुरू होती है, जबकि `Software` स्टेम `Licenses` बिंदु से शुरू होता है। उन बिंदुओं के संदर्भ रखना अस्पष्ट अभिव्यक्तियों जैसे `$dataPoints->get_Item(0)` या `$dataPoints->get_Item(6)` की तुलना में अधिक स्पष्ट और सुरक्षित है।

## **दोनों चार्ट प्रकार बनाएं और अनुकूलित करें**

निम्न पूर्ण उदाहरण पहली स्लाइड पर एक Treemap और दूसरी स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम तैयार करता है, `Tablets` के मान को प्रदर्शित करता है, चयनित स्तरों पर निश्चित रंग लागू करता है, एक शाखा लेबल को फ़ॉर्मेट करता है, और प्रस्तुति को सहेजता है।

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // पत्ती श्रेणियाँ जोड़ें। एक समूह वस्तु केवल तब सेट की जाती है जब नया समूह शुरू हो;
        // बाद की श्रेणियाँ उसी समूह में रहती हैं जब तक कोई अन्य वस्तु सेट न की जाए।
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Tablets पत्ती पर श्रेणी और मान दिखाएँ।
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Consumer शाखा को उस शाखा की पहली पत्ती के माध्यम से फॉर्मेट करें।
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Software स्टेम को उस स्टेम की पहली पत्ती के माध्यम से फॉर्मेट करें।
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout Treemap के पैरेंट लेबल को प्रभावित करता है; Sunburst रिंग खंडों का उपयोग करता है।
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

श्रेणी कोशिकाएँ और मान कोशिकाएँ समान वर्कशीट पंक्ति का उपयोग करती हैं, इसलिए उनके संग्रह स्थितियाँ संरेखित रहती हैं। जब आप मौजूदा चार्ट के साथ काम करते हैं बजाय नया बनाने के, तो पहले श्रेणी पंक्तियों का निरीक्षण करें और उन डेटा बिंदुओं और स्तरों के लिए नामित संदर्भ संग्रहीत करें जिन्हें आप फ़ॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- एक Treemap मूल्य को संप्रेषित करने के लिए क्षेत्रफल और पदानुक्रम को दर्शाने के लिए नेस्टेड आयतों का उपयोग करता है। इस चार्ट प्रकार में पैरेंट लेबल कैसे दिखते हैं, इसे [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/#setParentLabelLayout) मेथड नियंत्रित करता है।
- एक Sunburst मूल्य को संप्रेषित करने के लिए कोण और पदानुक्रम को दर्शाने के लिए छल्ले की गहराई का उपयोग करता है। इसके छल्ले लेबल को यह मेथड नियंत्रित नहीं करता।
- दोनों चार्ट प्रकार वही श्रेणी समूह स्तर और वही पत्ती‑से‑अभिभावक क्रम उपयोग करते हैं, जो [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) द्वारा लौटाया जाता है, इसलिए डेटा‑निर्माण और स्तर‑फ़ॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान उनके उत्तराधिकारियों पत्तियों से गणना किए जाते हैं। शाखाओं या स्टेमों के लिए अलग संख्यात्मक बिंदु न जोड़ें।

### **क्रमबद्धता और खंड क्रम**

चार्ट लेआउट इंजन आयतों और छल्ले खंडों के अंतिम स्थान का निर्धारण करता है। उन्हें जोड़ने से पहले संबंधित श्रेणी पंक्तियों को एक साथ व्यवस्थित करें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारंभिक कोण पर निर्भर न रहें। यदि क्रम का अर्थ है, तो इसे लेबल में शामिल करें या स्पष्ट श्रेणी अक्ष वाला चार्ट उपयोग करें।

### **थीम और निश्चित रंग**

अस्वरूपित चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण में पूर्वानुमानित आउटपुट के लिए स्पष्ट RGB फ़िल्स का उपयोग किया गया है। यदि चार्ट को थीम परिवर्तन के अनुसार बदलना है, तो फिक्स्ड RGB मानों के बजाय स्कीम रंग उपयोग करें और हर स्तर को ओवरराइड करने से बचें। साथ ही शाखा या स्टेम फ़िल बदलने के बाद लेबल कंट्रास्ट जांचें।

### **लेबल और उपलब्ध स्थान**

जब कोई खंड बहुत छोटा हो तो PowerPoint लेबल को छिपा या काट सकता है। चार्ट आकार बढ़ाकर, श्रेणी नाम छोटा करके, या कम लेबल फ़ील्ड दिखाकर आमतौर पर स्पष्ट परिणाम मिलता है। लेबल को श्रेणी नाम, श्रृंखला नाम और मान के साथ [DataLabelFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/) द्वारा संयोजित किया जा सकता है, लेकिन सभी फ़ील्ड सक्षम करने से पदानुक्रमित चार्ट पढ़ने में कठिन हो सकते हैं।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने से चार्ट संपादन योग्य रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित फ़िल्स और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्थान में छोटे अंतर लाइन रैपिंग या लेबल दृश्यता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट इंस्टॉल करें और महत्वपूर्ण निर्यात लक्ष्य की जाँच करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक पैरेंट स्तर को बदलने से कई पत्तियों पर प्रभाव क्यों पड़ता है?**

एक शाखा या स्टेम एक साझा दृश्य खंड है। इसका [ChartDataPointLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevel/) उत्तराधिकार पत्ती के माध्यम से पहुँचा जा सकता है, लेकिन फ़ॉर्मेटिंग साझा पैरेंट खंड को लागू होती है, न कि केवल उस पत्ती को।

**डेटा लेबल क्यों नहीं दिखाई देता?**

पहले लेबल के [DataLabelFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabelformat/) वस्तु पर आवश्यक फ़ील्ड सक्षम करें। फिर जांचें कि खंड के पास पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार, और सक्षम फ़ील्ड की संख्या सभी यह निर्धारित करते हैं कि लेबल दिखाया जा सकता है या नहीं।

**क्या मैं खंडों का सटीक क्रम या निर्देशांक सेट कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर सकते हैं और प्रत्येक समूह को क्रमबद्ध रख सकते हैं, लेकिन आप सटीक Treemap आयतें या Sunburst कोण नहीं निर्धारित कर सकते। चार्ट लेआउट इंजन इन्हें पदानुक्रम, मान और उपलब्ध स्थान से गणना करता है।

**प्रस्तुति थीम बदलने के बाद रंग क्यों बदलते हैं?**

थीम‑आधारित फ़िल्स प्रस्तुति पैलेट का पालन करने के लिए बनाए गए हैं। उन स्तरों के लिए स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रहना चाहिए, या नई थीम के लिए स्कीम रंग रखें।

**क्या कस्टम फ़ॉर्मेटिंग PDF और इमेज निर्यात में बनी रहेगी?**

हाँ, समर्थित चार्ट फ़िल्स और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होती हैं। स्थिर परिणामों के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ और अंतिम निर्यात आकार का परीक्षण करें, क्योंकि लेबल फिट होना लेआउट‑निर्भर है।

## **संबंधित देखें**

- [Treemap चार्ट बनाएं](/slides/hi/php-java/create-chart/#create-tree-map-charts)
- [Sunburst चार्ट बनाएं](/slides/hi/php-java/create-chart/#create-sunburst-charts)
- [प्रेजेंटेशन चार्ट निर्यात](/slides/hi/php-java/export-chart/)
- [प्रेजेंटेशन थीम प्रबंधित करें](/slides/hi/php-java/presentation-theme/)