---
title: "Python में PowerPoint जेनरेशन का स्वचालन: सरलता से डायनेमिक प्रस्तुतियाँ बनाएँ"
linktitle: "PowerPoint जेनरेशन का स्वचालन"
type: docs
weight: 20
url: /hi/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- क्लाउड प्लेटफ़ॉर्म
- क्लाउड एकीकरण
- PowerPoint जेनरेशन स्वचालित करें
- कार्यक्रमात्मक रूप से प्रस्तुतियाँ बनाएँ
- PowerPoint स्वचालन
- डायनेमिक स्लाइड निर्माण
- स्वचालित व्यावसायिक रिपोर्ट
- PPT स्वचालन
- Python प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint जेनरेशन स्वचालित करें: क्लाउड अनुप्रयोगों में चार्ट, तालिका और बुलेट पॉइंट्स के साथ व्यावसायिक प्रस्तुति बनाएँ।"
---
## **परिचय**

जब सामग्री अक्सर बदलती है, तो प्रस्तुतियों को मैन्युअल रूप से बनाना दोहरावपूर्ण हो जाता है। साप्ताहिक रिपोर्ट, प्रशिक्षण सामग्री, और ग्राहक प्रस्तुतियों में अक्सर समान संरचना होती है लेकिन प्रत्येक वितरण के लिए नई डेटा की आवश्यकता होती है।

Aspose.Slides for Python via Java आपको Python एप्लिकेशन से ये प्रस्तुतियां उत्पन्न करने देता है। आप डेटाबेस, API, या अपलोड की गई फ़ाइलों से डेटा का उपयोग करके स्लाइड निर्माण को वेब पोर्टलों, निर्धारित कार्यों, और क्लाउड वर्कर्स में एकीकृत कर सकते हैं।

## **Python में PowerPoint ऑटोमेशन के सामान्य उपयोग मामलों**

- **व्यवसाय रिपोर्ट और डैशबोर्ड:** बिक्री आँकड़े और प्रदर्शन मेट्रिक्स को चार्ट और तालिकाओं में बदलें।
- **व्यक्तिगत बिक्री प्रस्तुतियां:** क्लाइंट-विशिष्ट डेटा के साथ स्लाइड भरें जबकि समान डिज़ाइन बनाए रखें।
- **शिक्षा सामग्री:** संरचित सामग्री से पाठ, क्विज़, और कोर्स सारांश एकत्रित करें।
- **डेटा और AI-आधारित अंतर्दृष्टि:** एनालिटिक्स या भाषा-प्रसंस्करण सेवाओं के परिणामों को प्रस्तुति सामग्री के रूप में उपयोग करें।
- **मीडिया-आधारित स्लाइड:** अपलोड की गई छवियों या स्क्रीनशॉट को व्याख्यात्मक टेक्स्ट के साथ मिलाएँ।
- **दस्तावेज़ वर्कफ़्लो:** अन्य टूल्स द्वारा निकाली गई सामग्री को प्रस्तुति लेआउट में मानचित्रित करें।
- **डेवलपर टूल्स:** प्रोजेक्ट डेटा से रिलीज़ सारांश, तकनीकी अवलोकन, या डेमो जनरेट करें।

## **पूर्वापेक्षाएँ**

Python, Java, JPype, और Aspose.Slides सेट अप करने के लिए [Installation](/slides/hi/python-java/installation/) देखें। क्लाउड पर तैनाती के लिए, [Slides on Cloud Platforms](/slides/hi/python-java/slides-on-cloud-platforms/) भी देखें।

यह उदाहरण स्थिर व्यावसायिक डेटा का उपयोग करता है ताकि इसे बिना डेटाबेस या बाहरी सेवा के चलाया जा सके। इसे रिपोर्ट वर्कफ़्लो में एकीकृत करते समय इन मानों को अपने एप्लिकेशन के डेटा से बदलें।

{{% alert color="info" title="Note" %}}
आप लाइसेंस के बिना इस उदाहरण को चला सकते हैं, लेकिन मूल्यांकन आउटपुट में वॉटरमार्क होगा और मूल्यांकन प्रतिबंधों के अंतर्गत रहेगा। विवरण और अस्थायी लाइसेंस जानकारी के लिए [Evaluate Aspose.Slides](/slides/hi/python-java/evaluate-aspose-slides/) देखें।
{{% /alert %}}

## **प्रस्तुति बनाएँ**

नीचे दिया गया पूर्ण स्क्रिप्ट चार स्लाइड वाली एक प्रस्तुति बनाता है। प्रत्येक चरण समान प्रस्तुति का उपयोग करता है, और अंतिम चरण इसे `presentation.pptx` के रूप में सहेजता है।

### **टाइटल स्लाइड बनाएँ**

एक नई [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) में प्रारंभिक स्लाइड का उपयोग करके टाइटल लेआउट लागू करें। रिपोर्ट शीर्षक और दर्शकों के साथ शीर्षक और उपशीर्षक प्लेसहोल्डर भरें।

![The title slide](slide_0.png)

### **कॉलम चार्ट वाली स्लाइड जोड़ें**

एक खाली स्लाइड जोड़ें और [ShapeCollection.addChart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addChart) का उपयोग करके चार्ट बनाएं। एम्बेडेड वर्कबुक में पाँच क्षेत्रों और एक बिक्री श्रृंखला भरें। मान PowerPoint में संपादन योग्य रहते हैं।

![The slide with the chart](slide_1.png)

### **तालिका वाली स्लाइड जोड़ें**

[ShapeCollection.addTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addTable) का उपयोग करके तालिका बनाएं और दो कॉलम को मीट्रिक नाम और मानों से भरें। उदाहरण JPype के माध्यम से कॉलम चौड़ाई और पंक्ति ऊँचाई के लिए स्पष्ट Java double arrays पास करता है।

![The slide with the table](slide_2.png)

### **बुलेट पॉइंट्स वाली सारांश स्लाइड जोड़ें**

एक टेक्स्ट शेप बनाएं और प्रत्येक कार्य आइटम के लिए एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) जोड़ें। प्रत्येक पैराग्राफ पर प्रतीक बुलेट और काली टेक्स्ट लागू करें, तथा शेप का फ़िल और आउटलाइन हटाएँ।

![The slide with the summary](slide_3.png)

### **प्रस्तुति सहेजें**

[Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का उपयोग करके PowerPoint फ़ाइल लिखें। `finally` ब्लॉक में [Presentation.dispose](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#dispose) के साथ प्रस्तुति रिलीज़ करें।

### **पूरा Python उदाहरण**

इस स्क्रिप्ट को लिखने योग्य निर्देशिका में सहेजें और ऊपर कॉन्फ़िगर किए गए Python पर्यावरण के साथ चलाएँ। यह आवश्यक होने पर ही JVM शुरू करता है और प्रक्रिया के समाप्त होने तक उपलब्ध रहता है। नोटबुक और सेवा उपयोग के लिए [JVM lifecycle guidance](/slides/hi/python-java/limitations-and-api-differences/#import-the-library) देखें।

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # टाइटल स्लाइड बनाएँ।
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # चार्ट स्लाइड जोड़ें।
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # टेबल स्लाइड जोड़ें।
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # सारांश स्लाइड जोड़ें।
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

चित्र Java उदाहरण की संबंधित स्लाइड दर्शाते हैं। फ़ॉन्ट और मूल्यांकन मोड के आधार पर स्वरूप में भिन्नता हो सकती है।

## **क्लाउड एप्लिकेशन में उदाहरण का उपयोग करें**

प्रस्तुति बनाने से पहले रिपोर्ट डेटा प्राप्त करें, फिर उसे चार्ट, तालिका, और टेक्स्ट-जेनरेशन चरणों को पास करें। प्रत्येक कार्य के लिए अलग आउटपुट पथ उपयोग करें। सहेजने के बाद, आपका एप्लिकेशन फ़ाइल को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या डाउनलोड के रूप में वापस कर सकता है।

जॉब्स के बीच समान वर्कर प्रक्रिया में JVM चलाते रहें और प्रत्येक प्रस्तुति को उसके कार्य समाप्त होने पर रिलीज़ करें। रिपोर्ट डिज़ाइन के लिए आवश्यक फ़ॉन्ट को डिप्लॉयमेंट के साथ पैकेज करें ताकि पर्यावरणों के बीच अंतर कम हो।

## **निष्कर्ष**

यह उदाहरण Python का उपयोग करके संपादन योग्य चार्ट, तालिका, और टेक्स्ट के साथ एक पूर्ण व्यावसायिक प्रस्तुति उत्पन्न करता है। नमूना डेटा को एप्लिकेशन डेटा से बदलने से यह समान दृष्टिकोण आवर्ती रिपोर्ट, क्लाइंट प्रस्तुतियों, और शैक्षिक सामग्री के लिए उपयोगी बन जाता है।

## **FAQ**

**क्या स्क्रिप्ट को Microsoft PowerPoint या Excel की आवश्यकता है?**

नहीं। Aspose.Slides स्लाइड और चार्ट की एम्बेडेड वर्कबुक को किसी भी एप्लिकेशन के बिना बनाता है।

**तालिका उदाहरण में Java arrays क्यों उपयोग किए गए हैं?**

आधारभूत मेथड Java double arrays को स्वीकार करता है। स्पष्ट arrays JPype के माध्यम से पास किए जाने वाले संख्यात्मक प्रकार को स्पष्ट करते हैं।

**क्या मैं वही प्रस्तुति PDF या ODP के रूप में सहेज सकता हूँ?**

हां। इसे डिस्पोज़ करने से पहले, संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) मान के साथ किसी अन्य आउटपुट फ़ाइलनाम पर सहेजें। फ़ॉर्मेट-विशिष्ट क्षमताओं के लिए [Supported File Formats](/slides/hi/python-java/supported-file-formats/) देखें।

**क्या मैं एक ब्रांडेड टेम्प्लेट उपयोग कर सकता हूँ?**

हां। एक खाली प्रस्तुति बनाने के बजाय अपना टेम्प्लेट लोड करें, फिर लेआउट और प्लेसहोल्डर चयन को उस टेम्प्लेट के अनुसार अनुकूलित करें। यह नमूना नई डिफ़ॉल्ट प्रस्तुति के लेआउट और प्लेसहोल्डर क्रम को मानता है।