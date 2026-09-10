---
title: Python में Treemap और Sunburst चार्ट में डेटा पॉइंट को कस्टमाइज़ करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट
type: docs
url: /hi/python-java/data-points-of-treemap-and-sunburst-chart/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ Treemap और Sunburst चार्ट में पदानुक्रमिक डेटा बनाने और स्तर, लेबल और रंग को कस्टमाइज़ करना सीखें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट समान प्रकार के श्रेणीबद्ध डेटा को प्रदर्शित करते हैं, लेकिन वे अलग‑अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में दर्शाता है जहाँ प्रत्येक आयत का क्षेत्रफल पत्ती मान को दर्शाता है। एक Sunburst इसे अभिकेंद्रित रिंगों के रूप में दर्शाता है: शीर्ष‑स्तर के समूह केंद्र के पास होते हैं, और पत्ती श्रेणियाँ बाहरी रिंग पर रहती हैं।

Aspose.Slides for Python via Java में प्रत्येक संख्यात्मक मान एक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/) है। इसका [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) मेथड पत्ती और उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और दिखाता है कि समान नमूना डेटा से दोनों प्रकार के चार्ट कैसे बनाएं और फ़ॉर्मेट करें।

![उपभोक्ता और व्यापार शाखाओं के साथ एक ट्रेमैप चार्ट](treemap-hierarchy.png)

![एक सनबर्स्ट चार्ट जिसमें समान उपभोक्ता और व्यापार श्रेणी संरचना है](sunburst-hierarchy.png)

## **श्रेणियाँ, डेटा पॉइंट और स्तर समझें**

नीचे उपयोग किया गया नमूना तीन श्रेणी स्तरों और एक संख्यात्मक श्रृंखला को दर्शाता है:

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

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी समूह स्तर उस पत्ती से उसके पैरेंट्स तक के पथ का वर्णन करते हैं। प्रथम पंक्ति के लिए पथ है `Consumer > Computers > Laptops`।

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) द्वारा लौटाए गए इंडेक्स पत्ती से ऊपर की ओर चलते हैं:

| `getDataPointLevels()` index | तार्किक स्तर | ट्रेमैप प्रतिनिधान | सनबर्स्ट प्रतिनिधान |
| ---: | --- | --- | --- |
| `0` | पत्ती | मान आयत | बाहरी‑रिंग खंड |
| `1` | स्टेम | पैरेंट आयत या हेडर | मध्य‑रिंग खंड |
| `2` | शाखा | शीर्ष‑स्तर आयत या हेडर | आंतरिक‑रिंग खंड |

यह क्रम दोनों चार्ट प्रकारों के लिए समान है भले ही उनका दृश्य लेआउट अलग हो। एक पैरेंट खंड कई पत्तियों द्वारा साझा किया जाता है। इसे फ़ॉर्मेट करने के लिए, उस समूह में पहले डेटा पॉइंट के संबंधित स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` स्टेम `Licenses` पॉइंट से शुरू होता है। उन पॉइंट्स के रेफ़रेंस को रखना अस्पष्ट अभिव्यक्तियों जैसे `data_points.get_Item(0)` या `data_points.get_Item(6)` की तुलना में स्पष्ट और सुरक्षित है।

## **दोनों प्रकार के चार्ट बनाएं और अनुकूलित करें**

निम्न पूर्ण उदाहरण पहले स्लाइड पर एक Treemap और दूसरे स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम बनाता है, `Tablets` के लिए मान प्रदर्शित करता है, चयनित स्तरों को स्थायी रंग देता है, शाखा लेबल को फ़ॉर्मेट करता है, और प्रस्तुति को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # पत्ती श्रेणियों को जोड़ें। एक समूह आइटम केवल तब सेट किया जाता है जब नया समूह शुरू होता है;
        # इसके बाद की श्रेणियाँ उसी समूह में रहती हैं जब तक कोई अन्य आइटम सेट न हो।
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Tablets पत्ती पर श्रेणी और मान दिखाएँ।
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Consumer शाखा को उस शाखा की पहली पत्ती के माध्यम से फ़ॉर्मेट करें।
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Software स्टेम को उस स्टेम की पहली पत्ती के माध्यम से फ़ॉर्मेट करें।
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout Treemap पैरेंट लेबल को प्रभावित करता है; Sunburst रिंग खंडों का उपयोग करता है।
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

श्रेणी कोशिकाएँ और मान कोशिकाएँ समान वर्कशीट पंक्ति का उपयोग करती हैं, इसलिए उनकी संग्रह स्थितियाँ संरेखित रहती हैं। जब आप मौजूदा चार्ट के साथ काम कर रहे हों न कि नया बना रहे हों, तो पहले श्रेणी पंक्तियों की जांच करें और उन डेटा पॉइंट और स्तरों के नामित रेफ़रेंस सहेजें जिन्हें आप फ़ॉर्मेट करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst अंतर**

- Treemap मूल्य को संप्रेषित करने के लिए क्षेत्रफल और पदानुक्रम को दिखाने के लिए नेस्टेड आयतों का उपयोग करता है। इस चार्ट प्रकार में पैरेंट लेबल की उपस्थिति को नियंत्रित करने के लिए [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setParentLabelLayout) मेथड का उपयोग किया जाता है।
- Sunburst मूल्य को संप्रेषित करने के लिए कोण और पदानुक्रम को दिखाने के लिए रिंग गहराई का उपयोग करता है। इसके रिंग लेबल को नियंत्रित करने के लिए [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartseries/#setParentLabelLayout) लागू नहीं होता।
- दोनों चार्ट प्रकार समान श्रेणी समूह स्तर और वही पत्ती‑से‑पैरेंट क्रम उपयोग करते हैं जो [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) द्वारा लौटाया जाता है, इसलिए डेटा‑बिल्डिंग और स्तर‑फ़ॉर्मेटिंग कोड साझा किया जा सकता है।
- पैरेंट मान उनके अवतरित पत्तियों से गणना किए जाते हैं। शाखाओं या स्टेम्स के लिए अलग संख्यात्मक पॉइंट न जोड़ें।

### **सॉर्टिंग और खंड क्रम**

चार्ट लेआउट इंजिन आयतों और रिंग खंडों की अंतिम स्थिति निर्धारित करता है। उन्हें जोड़ने से पहले संबंधित श्रेणी पंक्तियों को साथ रखें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारंभिक कोने पर भरोसा न करें। यदि क्रम का अर्थ है, तो उसे लेबल में शामिल करें या स्पष्ट श्रेणी अक्ष वाले चार्ट प्रकार का उपयोग करें।

### **थीम और स्थायी रंग**

फ़ॉर्मेट न किए गए चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण में पूर्वानुमेय आउटपुट के लिए स्पष्ट RGB भराव का उपयोग किया गया है। यदि चार्ट को थीम परिवर्तन के साथ रखना है, तो स्थिर RGB मूल्यों के बजाय स्कीम रंगों का उपयोग करें और प्रत्येक स्तर को ओवरराइड करने से बचें। साथ ही शाखा या स्टेम भराव बदलने पर लेबल कंट्रास्ट की जाँच करें।

### **लेबल और उपलब्ध स्थान**

जब कोई खंड बहुत छोटा हो तो PowerPoint लेबल को छिपा या काट सकता है। चार्ट आकार बढ़ाकर, श्रेणी नाम छोटा करके, या कम लेबल फ़ील्ड दिखाकर आमतौर पर स्पष्ट परिणाम मिलता है। लेबल को [DataLabelFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/) के माध्यम से श्रेणी‑नाम, श्रृंखला‑नाम और मान को मिलाकर बनाया जा सकता है, लेकिन सभी फ़ील्ड सक्रिय करने से पदानुक्रमिक चार्ट पढ़ना कठिन हो जाता है।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने से चार्ट संपादनीय रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित भराव और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्थान में छोटे अंतर लाइन‑रैपिंग या लेबल दृश्यता बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट स्थापित करें और प्रमुख निर्यात लक्ष्य को सत्यापित करें।

## **बार‑बार पूछे जाने वाले प्रश्न**

**किसी पैरेंट स्तर को बदलने से कई पत्तियों पर असर क्यों पड़ता है?**  
एक शाखा या स्टेम एक साझा दृश्य खंड होता है। उसका [ChartDataPointLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdatapointlevel/) एक अवतरित पत्ती से पहुँचा जा सकता है, लेकिन फ़ॉर्मेटिंग साझा पैरेंट खंड के लिए होती है, न कि केवल उस पत्ती के लिए।

**डेटा लेबल क्यों नहीं दिख रहा है?**  
पहले लेबल के [DataLabelFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/datalabelformat/) ऑब्जेक्ट पर आवश्यक फ़ील्ड सक्षम करें। फिर जांचें कि खंड के पास पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार और सक्रिय फ़ील्ड संख्या सभी यह निर्धारित करते हैं कि लेबल प्रदर्शित हो सकेगा या नहीं।

**क्या मैं खंडों का सटीक क्रम या निर्देशांक सेट कर सकता हूँ?**  
आप स्रोत‑पंक्ति क्रम को नियंत्रित कर प्रत्येक समूह को क्रमबद्ध रख सकते हैं, लेकिन आप Treemap आयतों या Sunburst कोणों को सटीक रूप से असाइन नहीं कर सकते। चार्ट लेआउट इंजिन उन्हें पदानुक्रम, मान और उपलब्ध स्थान से गणना करता है।

**प्रेजेंटेशन थीम बदलने पर रंग क्यों बदलते हैं?**  
थीम‑आधारित भराव प्रस्तुति पैलेट का अनुसरण करने के लिये बने होते हैं। उन स्तरों के लिए स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रखना है, या नई थीम के साथ अनुकूलन हेतु स्कीम रंग रखें।

**क्या कस्टम फ़ॉर्मेटिंग PDF और इमेज निर्यात में संरक्षित रहती है?**  
हां, समर्थित चार्ट भराव और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल की जाती हैं। निरंतर परिणामों के लिये आवश्यक फ़ॉन्ट उपलब्ध करवाएँ और निर्यात आकार की जाँच करें क्योंकि लेबल फिटिंग लेआउट‑निर्भर होती है।

## **संबंधित लिंक**

- [Create Treemap charts](/slides/hi/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hi/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hi/python-java/export-chart/)
- [Manage presentation themes](/slides/hi/python-java/presentation-theme/)