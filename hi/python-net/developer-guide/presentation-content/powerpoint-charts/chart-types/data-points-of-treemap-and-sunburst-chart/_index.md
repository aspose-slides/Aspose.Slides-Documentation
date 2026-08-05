---
title: Python में Treemap और Sunburst चार्ट्स में डेटा पॉइंट्स को कस्टमाइज़ करें
linktitle: Treemap और Sunburst चार्ट्स में डेटा पॉइंट्स
type: docs
url: /hi/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap चार्ट
- sunburst चार्ट
- पदानुक्रम चार्ट
- डेटा पॉइंट
- डेटा लेबल
- ब्रांच रंग
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ Treemap और Sunburst चार्ट्स में पदानुक्रमिक डेटा बनाना और स्तर, लेबल, और रंग को कस्टमाइज़ करना सीखें।"
---
## **अवलोकन**

Treemap और Sunburst चार्ट एक ही प्रकार के पदानुक्रमित डेटा को दिखाते हैं, लेकिन वे अलग‑अलग लेआउट का उपयोग करते हैं। एक Treemap पदानुक्रम को नेस्टेड आयतों के रूप में खींचता है जहाँ प्रत्येक आयत का क्षेत्र पत्ती (leaf) मान का प्रतिनिधित्व करता है। एक Sunburst इसे गोलाकार रिंग्स के रूप में दर्शाता है: शीर्ष‑स्तर के समूह केंद्र के पास होते हैं, और पत्ती श्रेणियाँ बाहरी रिंग पर स्थित होती हैं।

Aspose.Slides for Python via .NET में प्रत्येक संख्यात्मक मान एक [ChartDataPoint](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/) होता है। इसका [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) संग्रह पत्ती और उसके पैरेंट समूहों तक पहुँच प्रदान करता है। यह लेख उस मैपिंग को समझाता है और दिखाता है कि समान नमूना डेटा से दोनों चार्ट प्रकार कैसे बनाएं और स्वरूपित करें।

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **श्रेणियों, डेटा पॉइंट्स और स्तरों को समझना**

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

प्रत्येक पंक्ति एक पत्ती श्रेणी और एक डेटा पॉइंट बनाती है। श्रेणी समूहिंग स्तर पत्ती से उसके पैरेंट तक का पथ दर्शाते हैं। पहली पंक्ति के लिए पथ `Consumer > Computers > Laptops` है।

[ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) में इंडेक्स पत्ती से ऊपर की ओर बढ़ते हैं:

| `data_point_levels` अनुक्रमांक | तार्किक स्तर | Treemap प्रतिनिधित्व | Sunburst प्रतिनिधित्व |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

यह क्रम दोनों चार्ट प्रकारों में समान है, भले ही उनका दृश्य लेआउट भिन्न हो। एक पैरेंट सेगमेंट कई पत्तियों द्वारा साझा किया जाता है। इसे स्वरूपित करने के लिए उस समूह के पहले डेटा पॉइंट के अनुरूप स्तर का उपयोग करें। उदाहरण के लिए, `Consumer` शाखा `Laptops` पॉइंट से शुरू होती है, जबकि `Software` स्टेम `Licenses` पॉइंट से शुरू होता है। उन पॉइंट्स के लिए संदर्भ रखना अस्पष्ट अभिव्यक्तियों जैसे `data_points[0]` या `data_points[6]` से अधिक स्पष्ट और सुरक्षित है।

## **दोनों चार्ट प्रकार बनाना और कस्टमाइज़ करना**

निम्नलिखित पूरा उदाहरण पहली स्लाइड पर एक Treemap और दूसरी स्लाइड पर एक Sunburst बनाता है। यह पदानुक्रम बनाता है, `Tablets` के लिए मान दिखाता है, चयनित स्तरों को निश्चित रंग लागू करता है, एक शाखा लेबल को स्वरूपित करता है, और प्रस्तुति को सहेजता है।

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # पत्ती श्रेणियों को जोड़ें। एक समूह आइटम केवल तब सेट किया जाता है जब नया समूह शुरू हो;
    # आगे की श्रेणियाँ उस समूह में रहती हैं जब तक कोई अन्य आइटम सेट न किया जाए।
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Tablets पत्ती पर श्रेणी और मान दिखाएँ।
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Consumer शाखा को उस शाखा की पहली पत्ती के माध्यम से स्वरूपित करें।
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Software स्टेम को उस स्टेम की पहली पत्ती के माध्यम से स्वरूपित करें।
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout Treemap के पैरेंट लेबल को प्रभावित करता है; Sunburst रिंग सेगमेंट का उपयोग करता है।
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

श्रेणी सेल्स और मान सेल्स एक ही वर्कशीट पंक्ति का उपयोग करते हैं, इसलिए उनका संग्रह स्थान संरेखित रहता है। जब आप मौजूदा चार्ट के साथ काम करते हैं बजाय नया बनाने के, तो पहले श्रेणी पंक्तियों का निरीक्षण करें और उन डेटा पॉइंट्स और स्तरों के लिए नामित संदर्भ संग्रहीत करें जिन्हें आप स्वरूपित करना चाहते हैं।

## **व्यवहार और व्यावहारिक विचार**

### **Treemap और Sunburst में अंतर**

- Treemap मूल्य को दर्शाने के लिए क्षेत्रफल और पदानुक्रम को दर्शाने के लिए नेस्टेड आयतें का उपयोग करता है। इस चार्ट प्रकार में पैरेंट लेबल की अभिव्यक्ति [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/parent_label_layout/) गुण द्वारा नियंत्रित होती है।
- Sunburst मूल्य को दर्शाने के लिए कोण और पदानुक्रम को दर्शाने के लिए रिंग गहराई का उपयोग करता है। [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartseries/parent_label_layout/) इसके रिंग लेबल को नियंत्रित नहीं करता।
- दोनों चार्ट प्रकार समान श्रेणी समूह स्तरों और `data_point_levels` में समान पत्ती‑से‑पैरेंट क्रम का उपयोग करते हैं, इसलिए डेटा‑बिल्डिंग और स्तर‑स्वरूपण कोड को साझा किया जा सकता है।
- पैरेंट मान उनके अधीनस्थ पत्तियों से गणना किए जाते हैं। शाखाओं या स्टेम्स के लिए अलग संख्यात्मक पॉइंट न जोड़ें।

### **सॉर्टिंग और सेगमेंट क्रम**

चार्ट लेआउट इंजन आयतों और रिंग सेगमेंट की अंतिम स्थिति निर्धारित करता है। जोड़ने से पहले संबंधित श्रेणी पंक्तियों को साथ रखें, लेकिन किसी विशिष्ट आयत स्थिति या प्रारम्भिक कोण पर भरोसा न करें। यदि क्रम का अर्थ है, तो उसे लेबल में शामिल करें या स्पष्ट श्रेणी एक्सिस वाला चार्ट उपयोग करें।

### **थीम और निश्चित रंग**

अस्वरूपित चार्ट स्तर प्रस्तुति थीम से रंग विरासत में लेते हैं। उदाहरण में पूर्वानुमेय आउटपुट के लिए स्पष्ट RGB फिल्स का उपयोग किया गया है। यदि चार्ट को थीम परिवर्तन के साथ मेल ख़ाना चाहिए, तो फिक्स्ड RGB मानों के बजाय स्कीम रंगों का प्रयोग करें और प्रत्येक स्तर को ओवरराइड करने से बचें। साथ ही शाखा या स्टेम फिल बदलने के बाद लेबल कंट्रास्ट जांचें।

### **लेबल और उपलब्ध स्थान**

जब सेगमेंट बहुत छोटा हो तो PowerPoint लेबल को छिपा या कट सकता है। चार्ट का आकार बढ़ाना, श्रेणी नाम छोटा करना, या कम लेबल फ़ील्ड दिखाना आमतौर पर स्पष्ट परिणाम देता है। लेबल को [DataLabelFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/) के माध्यम से श्रेणी नाम, श्रृंखला नाम और मान के संयोजन से बनाया जा सकता है, लेकिन सभी फ़ील्ड सक्रिय करने से पदानुक्रमिक चार्ट पढ़ना कठिन हो सकता है।

### **निर्यात और रेंडरिंग**

PPTX में सहेजने से चार्ट संपादन योग्य रहता है। जब Aspose.Slides प्रस्तुति को PDF या इमेज में रेंडर करता है, तो समर्थित फिल्स और लेबल सेटिंग्स चार्ट के साथ रेंडर होते हैं। फ़ॉन्ट प्रतिस्थापन और उपलब्ध लेआउट स्थान में छोटे‑छोटे अंतर लाइन‑रैपिंग या लेबल दृश्यता को बदल सकते हैं, इसलिए आवश्यक फ़ॉन्ट स्थापित करें और प्रमुख निर्यात लक्ष्यों का परीक्षण करें।

## **अधिक पूछे जाने वाले प्रश्न**

**पैरेंट स्तर बदलने पर कई पत्तियों पर असर क्यों पड़ता है?**

एक शाखा या स्टेम साझा दृश्य सेगमेंट होता है। इसका [ChartDataPointLevel](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdatapointlevel/) किसी अधीनस्थ पत्ती के माध्यम से पहुँचा जा सकता है, लेकिन स्वरूपण साझा पैरेंट सेगमेंट को लागू होता है, न कि केवल उस पत्ती को।

**डेटा लेबल क्यों नहीं दिख रहा है?**

पहले लेबल के आवश्यक फ़ील्ड को उसके [DataLabelFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/datalabelformat/) ऑब्जेक्ट पर सक्षम करें। फिर जांचें कि सेगमेंट में पर्याप्त स्थान है या नहीं। Treemap पैरेंट‑लेबल लेआउट, चार्ट आयाम, लेबल लंबाई, फ़ॉन्ट आकार और सक्षम फ़ील्ड की संख्या सभी यह निर्धारित करती है कि लेबल दिखेगा या नहीं।

**सेगमेंट के क्रम या निर्देशांक को बिल्कुल सेट कर सकता हूँ?**

आप स्रोत‑पंक्ति क्रम को नियंत्रित कर सकते हैं और प्रत्येक समूह को क्रमबद्ध रख सकते हैं, लेकिन आप सटीक Treemap आयतें या Sunburst कोण नहीं सौंप सकते। चार्ट लेआउट इंजन उन्हें पदानुक्रम, मान और उपलब्ध स्थान से गणना करता है।

**प्रेजेंटेशन थीम बदलने पर रंग क्यों बदलते हैं?**

थीम‑आधारित फिल्स प्रस्तुति पैलेट के अनुसार बदलते हैं। उन स्तरों के लिए स्पष्ट RGB रंग लागू करें जिन्हें स्थिर रहना चाहिए, या नई थीम के अनुरूप स्कीम रंगों को बनाए रखें।

**PDF और इमेज निर्यात में कस्टम स्वरूपण बना रहेगा?**

हाँ, समर्थित चार्ट फिल्स और लेबल सेटिंग्स रेंडरिंग के दौरान शामिल होते हैं। संगत परिणामों के लिए आवश्यक फ़ॉन्ट उपलब्ध कराएँ और अंतिम निर्यात आकार का परीक्षण करें क्योंकि लेबल फिटिंग लेआउट‑निर्भर है।

## **संबंधित लेख**

- [Create Treemap charts](/slides/hi/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hi/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hi/python-net/export-chart/)
- [Manage presentation themes](/slides/hi/python-net/presentation-theme/)