---
title: "Android पर Treemap और Sunburst चार्ट में डेटा पॉइंट्स को अनुकूलित करें"
linktitle: "Treemap और Sunburst चार्ट में डेटा पॉइंट्स"
type: docs
url: /hi/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap चार्ट
- Sunburst चार्ट
- पदानुक्रमित चार्ट
- डेटा पॉइंट
- डेटा लेबल
- ब्रांच रंग
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके Treemap और Sunburst चार्ट में पदानुक्रमित डेटा बनाना और स्तरों, लेबल्स, तथा रंगों को अनुकूलित करना सीखें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट समान प्रकार के पदानुक्रमित डेटा को प्रदर्शित करते हैं, लेकिन वे अलग-अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में बनाता है, जहाँ क्षेत्रों का आकार पत्ती मानों को दर्शाता है। एक Sunburst इसे समावेशी वलयों के रूप में दर्शाता है: शीर्ष-स्तर के समूह केंद्र के निकट होते हैं, और पत्ती श्रेणियाँ बाहरी वलय पर स्थित होती हैं।

In Aspose.Slides for Android via Java, प्रत्येक संख्यात्मक मान एक [IChartDataPoint](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/) है। इसका [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) मेथड पत्ती और उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को स्पष्ट करता है और दिखाता है कि समान सैंपल डेटा से दोनों चार्ट प्रकारों को कैसे बनाया और फ़ॉर्मेट किया जाए।

![Consumer और Business शाखाओं के साथ एक Treemap चार्ट](treemap-hierarchy.png)

![उसी Consumer और Business पदानुक्रम के साथ Sunburst चार्ट](sunburst-hierarchy.png)

## **श्रेणियों, डेटा पॉइंट्स और स्तरों को समझें**

नीचे उपयोग किया गया नमूना तीन श्रेणी स्तरों और एक संख्यात्मक श्रृंखला रखता है:

| शाखा | मुख्य वर्ग | पत्ती | राजस्व |
| --- | --- | --- | ---: |
| उपभोक्ता | कंप्यूटर | लैपटॉप | 12 |
| उपभोक्ता | कंप्यूटर | डेस्कटॉप | 8 |
| उपभोक्ता | मोबाइल | फ़ोन | 15 |
| उपभोक्ता | मोबाइल | टैबलेट | 6 |
| व्यवसाय | सेवाएं | परामर्श | 10 |
| व्यवसाय | सेवाएं | समर्थन | 7 |
| व्यवसाय | सॉफ्टवेयर | लाइसेंस | 11 |
| व्यवसाय | सॉफ्टवेयर | सब्सक्रिप्शन | 14 |

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी ग्रुपिंग स्तर पत्ती से उसके पैरेंट तक का मार्ग दर्शाते हैं। पहली पंक्ति के लिए, मार्ग है `उपभोक्ता > कंप्यूटर > लैपटॉप`।

इंडेक्स जो [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) द्वारा लौटाए जाते हैं, पत्ती से ऊपर की ओर चलते हैं:

| `getDataPointLevels()` index | लॉजिकल स्तर | Treemap प्रतिनिधित्व | Sunburst प्रतिनिधित्व |
| ---: | --- | --- | --- |
| `0` | पत्ती | मान आयत | बाहरी-वृत्त खंड |
| `1` | मुख्य वर्ग | पैरेंट आयत या हेडर | मध्य-वृत्त खंड |
| `2` | शाखा | शीर्ष-स्तर आयत या हेडर | आभ्यंतरी-वृत्त खंड |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है, भले ही उनका दृश्य लेआउट अलग हो। एक पैरेंट खंड कई पत्तियों द्वारा साझा किया जाता है। इसे फ़ॉर्मेट करने के लिए, उस समूह में पहले डेटा पॉइंट के समान स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` स्टेम `Licenses` पॉइंट से शुरू होता है। उन पॉइंट्स के संदर्भ रखना स्पष्ट और सुरक्षित है, बजाय अस्पष्ट अभिव्यक्तियों जैसे `dataPoints.get_Item(0)` या `dataPoints.get_Item(6)` के।

## **दोनों चार्ट प्रकारों को बनाएं और अनुकूलित करें**

निम्नलिखित पूर्ण उदाहरण पहली स्लाइड पर एक Treemap और दूसरी स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम बनाता है, `Tablets` के लिए मान दिखाता है, चयनित स्तरों पर स्थिर रंग लागू करता है, एक शाखा लेबल को फ़ॉर्मेट करता है, और प्रस्तुति को सहेजता है।

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

        // पत्ती श्रेणियों को जोड़ें। एक समूह आइटम केवल तब सेट किया जाता है जब नया समूह शुरू होता है;
        // इसके बाद की श्रेणियाँ उस समूह में रहती हैं जब तक कि कोई अन्य आइटम सेट न किया जाए।
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

        // टैबलेट्स पत्ती पर श्रेणी और मान दिखाएँ।
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // उपभोक्ता शाखा को उस शाखा की पहली पत्ती के माध्यम से फ़ॉर्मेट करें।
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // सॉफ़्टवेयर स्टेम को उस स्टेम की पहली पत्ती के माध्यम से फ़ॉर्मेट करें।
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout Treemap पैरेंट लेबल्स को प्रभावित करता है; Sunburst रिंग सेगमेंट्स का उपयोग करता है।
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

श्रेणी कोशिकाएँ और मान कोशिकाएँ एक ही कार्यपत्रक पंक्ति का उपयोग करती हैं, इसलिए उनका संग्रह स्थान संरेखित रहता है। जब आप एक मौजूदा चार्ट के साथ काम कर रहे हों बजाय उसे बनाने के, तो पहले श्रेणी पंक्तियों की जांच करें और उन डेटा पॉइंट्स और स्तरों के नामित संदर्भ संग्रहीत करें जिन्हें आप फ़ॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- एक Treemap मान को संप्रेषित करने के लिए क्षेत्र का उपयोग करता है और पदानुक्रम को संप्रेषित करने के लिए नेस्टेड आयतों का। [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) मेथड इस चार्ट प्रकार में पैरेंट लेबल की उपस्थिति को नियंत्रित करता है।
- एक Sunburst मान को संप्रेषित करने के लिए कोण का उपयोग करता है और पदानुक्रम को संप्रेषित करने के लिए वलय की गहराई का। [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) उसकी वलय लेबल को नियंत्रित नहीं करता।
- दोनों चार्ट प्रकार समान श्रेणी समूह लेवल और समान पत्ती‑से‑पैरेंट क्रम का उपयोग करते हैं जो [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) द्वारा लौटाए जाते हैं, इसलिए डेटा‑निर्माण और स्तर‑फ़ॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान अपने अवतरण पत्तियों से गणना किए जाते हैं। शाखाओं या स्टेम्स के लिए अलग संख्यात्मक पॉइंट्स न जोड़ें।

### **क्रमबद्ध करना और खंड क्रम**

चार्ट लेआउट इंजन आयतों और वलय खंडों की अंतिम स्थिति निर्धारित करता है। उन्हें जोड़ने से पहले संबंधित श्रेणी पंक्तियों को साथ में व्यवस्थित करें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारंभ कोण पर निर्भर न रहें। यदि क्रम का अर्थ है, तो इसे लेबल में शामिल करें या स्पष्ट श्रेणी अक्ष वाले चार्ट प्रकार का उपयोग करें।

### **थीम और निश्चित रंग**

बिना फ़ॉर्मेट किए चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण पूर्वानुमेय आउटपुट के लिए स्पष्ट RGB भराव का उपयोग करता है। यदि चार्ट को थीम परिवर्तनों के साथ चलना चाहिए, तो निश्चित RGB मानों के बजाय स्कीम रंगों का उपयोग करें और प्रत्येक स्तर को ओवरराइड करने से बचें। साथ ही शाखा या स्टेम भराव बदलने के बाद लेबल कंट्रास्ट जांचें।

### **लेबल और उपलब्ध स्थान**

जब कोई खंड बहुत छोटा हो, तो PowerPoint लेबल को छुपा या कट कर सकता है। चार्ट आकार बढ़ाने, श्रेणी नामों को छोटा करने, या कम लेबल फ़ील्ड दिखाने से अक्सर स्पष्ट परिणाम मिलता है। एक लेबल [IDataLabelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabelformat/) के माध्यम से श्रेणी नाम, श्रृंखला नाम, और मान को संयोजित कर सकता है, लेकिन सभी फ़ील्ड को सक्षम करने से पदानुक्रमित चार्ट पढ़ने में मुश्किल हो सकता है।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने से चार्ट संपादन योग्य रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित भराव और लेबल सेटिंग्स चार्ट के साथ रेंडर होती हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्थान में छोटे अंतर लाइन रैपिंग या लेबल दृश्यमानता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट स्थापित करें और महत्वपूर्ण निर्यात लक्ष्य की जाँच करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**पैरेंट स्तर बदलने से कई पत्तियों पर असर क्यों होता है?**

एक शाखा या स्टेम एक साझा दृश्य खंड है। उसका [IChartDataPointLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatapointlevel/) एक अवतरण पत्ती के माध्यम से पहुँचा जा सकता है, लेकिन फ़ॉर्मेटिंग साझा पैरेंट खंड के लिए होती है, सिर्फ उस पत्ती के लिए नहीं।

**डेटा लेबल क्यों गायब है?**

पहले लेबल के [IDataLabelFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idatalabelformat/) ऑब्जेक्ट पर आवश्यक फ़ील्ड सक्षम करें। फिर देखें कि खंड के पास पर्याप्त स्थान है या नहीं। Treemap पैरेंट-लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार, और सक्षम फ़ील्डों की संख्या सभी निर्धारित करते हैं कि लेबल प्रदर्शित हो सकता है या नहीं।

**क्या मैं खंडों का सटीक क्रम या निर्देशांक सेट कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर सकते हैं और प्रत्येक समूह को क्रमबद्ध रख सकते हैं, लेकिन आप सटीक Treemap आयत या Sunburst कोण निर्दिष्ट नहीं कर सकते। चार्ट लेआउट इंजन उन्हें पदानुक्रम, मान, और उपलब्ध स्थान से गणना करता है।

**प्रस्तुति थीम बदलने के बाद रंग क्यों बदलते हैं?**

थीम‑आधारित भराव प्रस्तुति पैलेट का पालन करने के लिए बनाए गए हैं। उन स्तरों पर स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रहना चाहिए, या नई थीम के अनुकूलन के समय स्कीम रंगों को रखें।

**क्या कस्टम फ़ॉर्मेटिंग PDF और इमेज निर्यात में बरकरार रहेगी?**

हाँ, समर्थित चार्ट भराव और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होते हैं। विभिन्न सिस्टमों पर निरंतर परिणामों के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ और अंतिम निर्यात आकार का परीक्षण करें, क्योंकि लेबल फिटिंग लेआउट‑निर्भर है।

## **संबंधित लिंक**

- [Treemap चार्ट बनाएं](/slides/hi/androidjava/create-chart/#create-tree-map-charts)
- [Sunburst चार्ट बनाएं](/slides/hi/androidjava/create-chart/#create-sunburst-charts)
- [प्रस्तुति चार्ट निर्यात करें](/slides/hi/androidjava/export-chart/)
- [प्रस्तुति थीम प्रबंधित करें](/slides/hi/androidjava/presentation-theme/)