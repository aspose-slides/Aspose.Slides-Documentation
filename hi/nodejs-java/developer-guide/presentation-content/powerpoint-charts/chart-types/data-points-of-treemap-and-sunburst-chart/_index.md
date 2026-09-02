---
title: "Treemap और Sunburst चार्ट्स में डेटा पॉइंट्स को JavaScript का उपयोग करके कस्टमाइज़ करें"
linktitle: "Treemap और Sunburst चार्ट्स में डेटा पॉइंट्स"
type: docs
url: /hi/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ट्रीमैप चार्ट
- सनबर्स्ट चार्ट
- पदानुक्रमिक चार्ट
- डेटा पॉइंट
- डेटा लेबल
- शाखा रंग
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ Treemap और Sunburst चार्ट्स में पदानुक्रमिक डेटा बनाने और स्तर, लेबल और रंग को कस्टमाइज़ करने के बारे में जानें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट एक ही प्रकार का पदानुक्रमिक डेटा दिखाते हैं, लेकिन वे अलग-अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में चित्रित करता है जहाँ क्षेत्रों का आकार पत्ती मानों का प्रतिनिधित्व करता है। एक Sunburst इसे समवर्ती रिंगों के रूप में दर्शाता है: शीर्ष‑स्तर के समूह केंद्र के निकट होते हैं, और पत्ती श्रेणियाँ बाहरी रिंग पर होती हैं।

Aspose.Slides for Node.js via Java में, प्रत्येक संख्यात्मक मान एक [ChartDataPoint](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/). इसका [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) मेथड पत्ती और उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और दिखाता है कि समान नमूना डेटा से दोनों चार्ट प्रकारों को कैसे बनाएं और फ़ॉर्मेट करें।

![Consumer और Business शाखाओं के साथ एक Treemap चार्ट](treemap-hierarchy.png)

![समान Consumer और Business पदानुक्रम के साथ एक Sunburst चार्ट](sunburst-hierarchy.png)

## **श्रेणियों, डेटा पॉइंट्स, और स्तरों को समझें**

नीचे उपयोग किया गया नमूना तीन श्रेणी स्तर और एक संख्यात्मक श्रृंखला रखता है:

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

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी समूह स्तर पत्ती से उसके पैरेंट तक का पथ वर्णित करते हैं। पहली पंक्ति के लिए, पथ है `Consumer > Computers > Laptops`।

इंडेक्स जो [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) द्वारा लौटाए जाते हैं, पत्ती से ऊपर की ओर चलते हैं:

| `getDataPointLevels()` index | पत्ती | मान आयत | बाहरी‑रिंग खंड |
| `0` | पत्ती | मान आयत | बाहरी‑रिंग खंड |
| `1` | स्टेम | पैरेंट आयत या हेडर | मध्य‑रिंग खंड |
| `2` | शाखा | शीर्ष‑स्तर आयत या हेडर | भीतरी‑रिंग खंड |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है जबकि उनके दृश्य लेआउट अलग हैं। एक पैरेंट खंड कई पत्तियों द्वारा साझा किया जाता है। इसे फ़ॉर्मेट करने के लिए, उस समूह में पहले डेटा पॉइंट के अनुरूप स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` स्टेम `Licenses` पॉइंट से शुरू होता है। इन पॉइंट्स के रेफ़रेंसेस को रखना स्पष्ट और सुरक्षित होता है बनिस्बत उन अभिव्यक्तियों के जैसे `dataPoints.get_Item(0)` या `dataPoints.get_Item(6)`।

## **दोनों चार्ट प्रकारों को बनाएं और अनुकूलित करें**

निम्नलिखित पूर्ण उदाहरण पहले स्लाइड पर एक Treemap और दूसरे स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम बनाता है, `Tablets` के लिए मान दिखाता है, चयनित स्तरों पर स्थिर रंग लागू करता है, एक शाखा लेबल को फ़ॉर्मेट करता है, और प्रस्तुति को सहेजता है।

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // पत्ती श्रेणियों को जोड़ें। एक समूह वस्तु केवल तब सेट होती है जब नया समूह शुरू होता है;
        // उसके बाद की श्रेणियां उस समूह में रहती हैं जब तक कोई अन्य वस्तु सेट न हो।
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Tablets पत्ती पर श्रेणी और मान दिखाएँ।
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Consumer शाखा को उस शाखा की पहली पत्ती के माध्यम से फ़ॉर्मेट करें।
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Software स्टेम को उस स्टेम की पहली पत्ती के माध्यम से फ़ॉर्मेट करें।
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout Treemap पैरेंट लेबलों को प्रभावित करता है; Sunburst रिंग खंडों का उपयोग करता है।
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

श्रेणी कोशिकाएँ और मान कोशिकाएँ एक ही वर्कशीट पंक्ति का उपयोग करती हैं, इसलिए उनके संग्रह स्थितियाँ संरेखित रहती हैं। जब आप नया चार्ट बनाने के बजाय मौजूदा चार्ट के साथ काम करते हैं, तो पहले श्रेणी पंक्तियों की जाँच करें और उन डेटा पॉइंट्स और स्तरों के नामित रेफ़रेंसेस को संग्रहीत करें जिन्हें आप फ़ॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- एक Treemap मान संप्रेषित करने के लिए क्षेत्र का उपयोग करता है और पदानुक्रम संप्रेषित करने के लिए नेस्टेड आयतों का। इस चार्ट प्रकार में पैरेंट लेबल कैसे दिखते हैं, इसे [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) मेथड नियंत्रित करता है।
- एक Sunburst मान संप्रेषित करने के लिए कोण का उपयोग करता है और पदानुक्रम संप्रेषित करने के लिए रिंग गहराई का। [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) उसके रिंग लेबल को नियंत्रित नहीं करता।
- दोनों चार्ट प्रकार समान श्रेणी समूह स्तरों और समान पत्ती‑से‑पैरेंट क्रम का उपयोग करते हैं, इसलिए डेटा‑बिल्डिंग और स्तर‑फ़ॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान उनके उत्तराधिकारी पत्तियों से गणना किए जाते हैं। शाखाओं या स्टेम्स के लिए अलग संख्यात्मक पॉइंट न जोड़ें।

### **सॉर्टिंग और खंड क्रम**

चार्ट लेआउट इंजन आयतों और रिंग खंडों की अंतिम स्थिति निर्धारित करता है। संबंधित श्रेणी पंक्तियों को जोड़ने से पहले एक साथ व्यवस्थित करें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारंभिक कोण पर निर्भर न रहें। यदि क्रम का अर्थ है, तो उसे लेबल में शामिल करें या स्पष्ट श्रेणी अक्ष वाले चार्ट प्रकार का उपयोग करें।

### **थीम और स्थिर रंग**

बिना फ़ॉर्मेट किए चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण अनुमानित आउटपुट के लिए स्पष्ट RGB फ़िल का उपयोग करता है। यदि चार्ट को थीम परिवर्तन के साथ अनुसरण करना चाहिए, तो स्थिर RGB मानों के बजाय स्कीम रंगों का उपयोग करें और प्रत्येक स्तर को ओवरराइड करने से बचें। साथ ही शाखा या स्टेम फ़िल बदलने के बाद लेबल कंट्रास्ट जाँचें।

### **लेबल और उपलब्ध स्थान**

PowerPoint तब लेबल को छिपा या छोटा कर सकता है जब खंड बहुत छोटा हो। चार्ट आकार बढ़ाने, श्रेणी नाम संक्षिप्त करने, या कम लेबल फ़ील्ड दिखाने से अक्सर स्पष्ट परिणाम मिलता है। लेबल को [DataLabelFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabelformat/) के माध्यम से श्रेणी नाम, श्रृंखला नाम, और मान को संयोजित किया जा सकता है, लेकिन सभी फ़ील्ड सक्षम करने से पदानुक्रम चार्ट पढ़ने में कठिन हो जाता है।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने से चार्ट संपादनीय रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित फ़िल और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्पेस में छोटे अंतर लाइन रैपिंग या लेबल दृश्यता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट इंस्टॉल करें और महत्वपूर्ण निर्यात लक्ष्यों की जाँच करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**किसी पैरेंट स्तर को बदलने से कई पत्तियों पर असर क्यों पड़ता है?**

एक शाखा या स्टेम एक साझा दृश्य खंड है। उसका [ChartDataPointLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdatapointlevel/) उत्तराधिकारी पत्ती के माध्यम से पहुँचा जा सकता है, लेकिन फ़ॉर्मेटिंग साझा पैरेंट खंड की होती है न कि केवल उस पत्ती की।

**डेटा लेबल क्यों गायब है?**

सबसे पहले लेबल के [DataLabelFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabelformat/) ऑब्जेक्ट पर आवश्यक फ़ील्ड सक्षम करें। फिर जाँचें कि खंड के पास पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार, और सक्षम फ़ील्ड की संख्या सभी इस बात को प्रभावित करते हैं कि लेबल प्रदर्शित हो सकता है या नहीं।

**क्या मैं खंडों का सटीक क्रम या निर्देशांक सेट कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर सकते हैं और प्रत्येक समूह को क्रमबद्ध रख सकते हैं, लेकिन आप सटीक Treemap आयतें या Sunburst कोण नहीं आवंटित कर सकते। चार्ट लेआउट इंजन इन्हें पदानुक्रम, मान, और उपलब्ध स्थान से गणना करता है।

**प्रस्तुति थीम बदलने के बाद रंग क्यों बदलते हैं?**

थीम‑आधारित फ़िल प्रस्तुति पैलेट का पालन करने के लिए डिजाइन किए गए हैं। उन स्तरों पर स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रहना चाहिए, या नई थीम के अनुकूलन के लिए स्कीम रंग रखें।

**क्या कस्टम फ़ॉर्मेटिंग PDF और इमेज निर्यात में संरक्षित रहेगी?**

हाँ, समर्थित चार्ट फ़िल और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होते हैं। विभिन्न सिस्टमों पर संगत परिणामों के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ और अंतिम निर्यात आकार का परीक्षण करें क्योंकि लेबल फिटिंग लेआउट‑निर्भर है।

## **देखें भी**

- [Treemap चार्ट्स बनाएं](/slides/hi/nodejs-java/create-chart/#creating-tree-map-charts)
- [Sunburst चार्ट्स बनाएं](/slides/hi/nodejs-java/create-chart/#creating-sunburst-charts)
- [प्रस्तुति चार्ट निर्यात करें](/slides/hi/nodejs-java/export-chart/)
- [प्रेजेंटेशन थीम प्रबंधित करें](/slides/hi/nodejs-java/presentation-theme/)