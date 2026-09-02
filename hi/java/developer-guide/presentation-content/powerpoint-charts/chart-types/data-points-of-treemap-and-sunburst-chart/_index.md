---
title: "Java में Treemap और Sunburst चार्ट में डेटा पॉइंट्स को अनुकूलित करें"
linktitle: "Treemap और Sunburst चार्ट में डेटा पॉइंट्स"
type: docs
url: /hi/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ट्रीमैप चार्ट
- सनबर्स्ट कार्ड
- पदानुक्रमित चार्ट
- डेटा पॉइंट
- डेटा लेबल
- शाखा रंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ Treemap और Sunburst चार्ट में पदानुक्रमित डेटा बनाने और स्तरों, लेबल्स और रंगों को अनुकूलित करने का तरीका जानें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट समान प्रकार के पदानुक्रमित डेटा को दर्शाते हैं, लेकिन वे विभिन्न लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में ड्रॉ करता है, जहाँ क्षेत्रों का आकार पत्ती मूल्यों का प्रतिनिधित्व करता है। एक Sunburst इसे अभिलंब रिंगों के रूप में दर्शाता है: शीर्ष‑स्तर के समूह मध्य के पास होते हैं, और पत्ती श्रेणियाँ बाहरी रिंग पर होती हैं।

Aspose.Slides for Java में, प्रत्येक संख्यात्मक मान एक [IChartDataPoint](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/) है। इसका [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) मेथड पत्ती और उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और दिखाता है कि समान सैंपल डेटा से दोनों चार्ट प्रकार कैसे बनाएँ और फॉर्मेट करें।

![Consumer और Business शाखाओं के साथ एक Treemap चार्ट](treemap-hierarchy.png)

![उसी Consumer और Business पदानुक्रम के साथ एक Sunburst चार्ट](sunburst-hierarchy.png)

## **श्रेणियों, डेटा पॉइंट्स और स्तरों को समझें**

नीचे उपयोग किया गया सैंपल तीन श्रेणी स्तरों और एक संख्यात्मक श्रृंखला वाला है:

| शाखा | उपशाखा | पत्ती | राजस्व |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी समूह स्तर उस पत्ती से उसके पैरेंट तक का पाथ दर्शाते हैं। पहली पंक्ति के लिए पाथ `Consumer > Computers > Laptops` है।

[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) द्वारा लौटाए गए इंडेक्स पत्ती से ऊपर की ओर चलते हैं:

| `getDataPointLevels()` index | तार्किक स्तर | Treemap प्रस्तुति | Sunburst प्रस्तुति |
| ---: | --- | --- | --- |
| `0` | पत्ती | वैल्यू आयत | बाहरी‑रिंग सेगमेंट |
| `1` | उपशाखा | पैरेंट आयत या हेडर | मध्य‑रिंग सेगमेंट |
| `2` | शाखा | शीर्ष‑स्तर आयत या हेडर | आंतरिक‑रिंग सेगमेंट |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है, भले ही उनके दृश्य लेआउट अलग‑अलग हों। एक पैरेंट सेगमेंट कई पत्तियों द्वारा साझा किया जाता है। इसे फॉर्मेट करने के लिए उसी समूह के पहले डेटा पॉइंट के संबंधित स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` उपशाखा `Licenses` पॉइंट से शुरू होती है। उन पॉइंट्स के रेफ़रेंस रखना बिना स्पष्टीकरण वाले अभिव्यक्तियों जैसे `dataPoints.get_Item(0)` या `dataPoints.get_Item(6)` के उपयोग से कहीं स्पष्ट और सुरक्षित है।

## **दोनों चार्ट प्रकार बनाएं और अनुकूलित करें**

निम्न पूरा उदाहरण पहले स्लाइड पर एक Treemap और दूसरे स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम बनाता है, `Tablets` के लिए मान दिखाता है, चयनित स्तरों पर स्थिर रंग लागू करता है, एक शाखा लेबल फॉर्मेट करता है, और प्रेज़ेंटेशन को सेव करता है।

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // पत्ती श्रेणियों को जोड़ें। एक समूह आइटम केवल तभी सेट किया जाता है जब नया समूह शुरू हो;
        // अगली श्रेणियां उस समूह में रहती हैं जब तक कि कोई अन्य आइटम सेट न किया जाए.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // टैबलेट पत्ती पर श्रेणी और मान दिखाएँ.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // उसी शाखा की पहली पत्ती के माध्यम से Consumer शाखा को फ़ॉर्मेट करें.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // उसी स्टेम की पहली पत्ती के माध्यम से Software स्टेम को फ़ॉर्मेट करें.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout Treemap पैरेंट लेबल को प्रभावित करता है; Sunburst रिंग सेगमेंट का उपयोग करता है.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

श्रेणी सेल और वैल्यू सेल एक ही वर्कशीट पंक्ति का उपयोग करते हैं, इसलिए उनका कलेक्शन पोज़िशन असाइन रहने में संरेखित रहता है। जब आप एक मौज़ूद चार्ट के साथ काम कर रहे हों न कि नया बना रहे हों, तो पहले श्रेणी पंक्तियों का निरीक्षण करें और उन डेटा पॉइंट्स व स्तरों के नामित रेफ़रेंस संग्रहीत करें जिन्हें आप फॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- Treemap मूल्य को संचारित करने के लिए क्षेत्र का उपयोग करता है और पदानुक्रम को प्रदर्शित करने के लिए नेस्टेड आयतों का। इस चार्ट प्रकार में पैरेंट लेबल की उपस्थिति को नियंत्रित करने वाला मेथड [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) है।
- Sunburst मूल्य को संचारित करने के लिए कोण का उपयोग करता है और पदानुक्रम को दिखाने के लिए रिंग की गहराई। इसके रिंग लेबल को नियंत्रित करने वाला कोई समान मेथड नहीं है; [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) इसके लिए लागू नहीं होता।
- दोनों चार्ट प्रकार समान श्रेणी समूह स्तर और समान पत्ती‑से‑पैरेंट क्रम का उपयोग करते हैं, जो [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) द्वारा लौटाया जाता है; इसलिए डेटा‑बिल्डिंग और स्तर‑फॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान उनके अवतरित पत्तियों से गणना किए जाते हैं। शाखाओं या उपशाखाओं के लिए अलग संख्यात्मक पॉइंट नहीं जोड़ें।

### **क्रमबद्धता और सेगमेंट क्रम**

चार्ट लेआउट इंजन आयतों और रिंग सेगमेंटों की अंतिम स्थिति निर्धारित करता है। संबंधित श्रेणी पंक्तियों को जोड़ने से पहले एक साथ व्यवस्थित करें, लेकिन किसी विशिष्ट आयत पोज़िशन या प्रारम्भिक कोण पर निर्भर न रहें। यदि क्रम का अर्थ है, तो उसे लेबल में सम्मिलित करें या स्पष्ट श्रेणी अक्ष वाले चार्ट प्रकार का उपयोग करें।

### **थीम और फ़िक्स्ड रंग**

अफ़ॉर्मेटेड चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण पूर्वानुमेय आउटपुट के लिए स्पष्ट RGB फ़िल्स का उपयोग करता है। यदि चार्ट को थीम परिवर्तन के साथ तालमेल रखना है, तो स्थिर RGB मूल्यों के बजाय स्कीम रंगों का उपयोग करें और हर स्तर को ओवरराइड करने से बचें। साथ ही किसी शाखा या उपशाखा फ़िल बदलने पर लेबल कंट्रास्ट भी जाँचें।

### **लेबल्स और उपलब्ध स्थान**

यदि कोई सेगमेंट बहुत छोटा हो तो PowerPoint लेबल को छिपा या ट्रंकेट कर सकता है। चार्ट का आकार बढ़ाने, श्रेणी नाम संक्षिप्त करने, या कम लेबल फ़ील्ड दिखाने से अक्सर स्पष्ट परिणाम मिलता है। लेबल को श्रेणी नाम, श्रृंखला नाम और मान को [IDataLabelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatalabelformat/) के माध्यम से संयोजित किया जा सकता है, लेकिन सभी फ़ील्ड सक्षम करने से पदानुक्रमित चार्ट पढ़ना कठिन हो जाता है।

### **निर्यात और रेंडरिंग**

PPTX में सेव करने से चार्ट संपाद्य रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित फ़िल्स और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट सब्स्टिट्यूशन और उपलब्ध लेआउट स्थान में छोटे अंतर लाइन रैपिंग या लेबल दृश्यता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट इंस्टॉल करें और महत्वपूर्ण निर्यात लक्ष्यों की पुष्टि करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**पैरेंट स्तर बदलने से कई पत्तियों पर क्यों प्रभाव पड़ता है?**

एक शाखा या उपशाखा एक साझा दृश्य सेगमेंट है। इसका [IChartDataPointLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatapointlevel/) किसी अवतरित पत्ती से पहुँचा जा सकता है, लेकिन फॉर्मेटिंग साझा पैरेंट सेगमेंट पर लागू होती है, केवल उस पत्ती पर नहीं।

**डेटा लेबल क्यों गायब है?**

पहले लेबल के [IDataLabelFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idatalabelformat/) ऑब्जेक्ट पर आवश्यक फ़ील्ड सक्षम करें। फिर जांचें कि सेगमेंट में पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आकार, लेबल लंबाई, फ़ॉन्ट आकार और सक्षम फ़ील्ड की संख्या सभी निर्धारित करते हैं कि लेबल दिखाया जा सकता है या नहीं।

**क्या मैं सेगमेंट्स का सटीक क्रम या निर्देशांक सेट कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर सकते हैं और प्रत्येक समूह को सतत रख सकते हैं, लेकिन आप सटीक Treemap आयत या Sunburst कोण असाइन नहीं कर सकते। चार्ट लेआउट इंजन इन्हें पदानुक्रम, मान और उपलब्ध स्थान से गणना करता है।

**प्रेज़ेंटेशन थीम बदलने के बाद रंग क्यों बदलते हैं?**

थीम‑आधारित फ़िल्स प्रस्तुति पैलेट का अनुसरण करने के लिए डिज़ाइन किए गए हैं। उन स्तरों पर स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रहना चाहिए, या नई थीम के साथ अनुकूलन के लिए स्कीम रंग रखें।

**क्या कस्टम फॉर्मेटिंग PDF और इमेज निर्यात में संरक्षित रहेगी?**

हाँ, समर्थित चार्ट फ़िल्स और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होते हैं। निरंतर परिणामों के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ और अंतिम निर्यात आकार का परीक्षण करें क्योंकि लेबल फिटिंग लेआउट‑निर्भर होती है।

## **अधिक देखें**

- [Create Treemap charts](/slides/hi/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hi/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hi/java/export-chart/)
- [Manage presentation themes](/slides/hi/java/presentation-theme/)