---
title: PPTX में चार्ट रिसाइज़िंग के लिए कार्य समाधान
type: docs
weight: 40
url: /hi/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- एक्सेल चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करना
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके एम्बेडेड Excel OLE ऑब्जेक्ट्स के साथ PPTX में अप्रत्याशित चार्ट आकार बदलने को ठीक करें। चार्ट और OLE फ्रेम के आकार को सुसंगत रखने के लिए स्थिर चार्ट आयाम निर्धारित करें।"
---
## **पृष्ठभूमि**

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुतियों में OLE वस्तुओं के रूप में एम्बेड किए गए Excel चार्ट पहली सक्रियता के बाद आकार बदल सकते हैं। इससे सक्रियता से पहले और बाद में चार्ट की उपस्थिति में एक उल्लेखनीय अंतर हो सकता है। यह लेख बताता है कि पुनः आकार बदलना क्यों होता है और स्थिर चार्ट आयामों को OLE फ्रेम के साथ मिलाकर इसे कैसे रोका जाए।

In [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Python via Java and embed it in a PowerPoint presentation using Aspose.Slides for Python via Java. To address the [object preview issue](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **रीसाइज़िंग का कारण**

एम्बेड किया गया Excel वर्कबुक अपने स्वयं के विंडो आयाम रखता है, जिसे Excel पहली बार सक्रिय होने पर बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम के आयाम स्वतंत्र रूप से परिभाषित होते हैं। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint वस्तु के आकार पर बातचीत करते हैं ताकि एम्बेड प्रक्रिया के हिस्से के रूप में अनुपात बनाए रखा जा सके। वर्कबुक विंडो और OLE फ्रेम के बीच अंतर वस्तु को पुनः आकार बदलने का कारण बन सकता है।

## **कार्यशील समाधान**

चार्ट के आकार को स्लाइड पर OLE फ्रेम के साथ मिलाएँ और चार्ट के आयाम को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्प्लेट दोनों के साथ काम करता है।

उदाहरण को Aspose.Cells for Python via Java और Aspose.Slides for Python via Java की आवश्यकता है। यह सक्रिय चार्ट शीट पर एक साधारण कॉलम चार्ट बनाता है और वर्कबुक को XLS प्रारूप में एम्बेड करता है। कोई चार्ट प्रीव्यू इमेज असाइन नहीं की गई है; चार्ट PowerPoint में OLE ऑब्जेक्ट सक्रिय होने पर दृश्य हो जाता है।

उदाहरण 9.5 × 4‑इंच के OLE फ्रेम के साथ एक नई प्रस्तुति बनाता है, जो बाएँ किनारे से 0.5 इंच और ऊपर से 1 इंच पर स्थित है। स्लाइड निर्देशांक और आयाम पॉइंट्स में हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [टेम्प्लेट का उपयोग करें](#use-a-template)।

## **स्थिर चार्ट आकार सेट करें**

Set [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) को false सेट करें ताकि चार्ट के आयाम workbook window से स्वतंत्र हों। Set the [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) dimensions through [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) और [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height), converting points to pixels using 96 pixels per inch: 684 × 288 पॉइंट के फ्रेम का आकार 912 × 384 पिक्सेल के चार्ट के बराबर है। Set [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) को CUSTOM मान पर सेट करें, जो [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) का हिस्सा है। उदाहरण वर्कबुक को [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) के साथ एम्बेड करता है और 9.5 × 4‑इंच के OLE फ्रेम के साथ प्रस्तुति सहेजता है।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # स्लाइड के निर्देशांक और आयाम पॉइंट्स में हैं (प्रति इंच 72 पॉइंट)।
        width = 684.0  # 9.5 इंच।
        height = 288.0  # 4 इंच।

        chart.setSizeWithWindow(False)
        # बिंदुओं को चार्ट पिक्सेल में बदलने के लिए 96 पिक्सेल प्रति इंच का उपयोग करें।
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **टेम्प्लेट का उपयोग करें**

आकार तर्क मौजूदा प्रस्तुति के लिए भी समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाने के बजाय टेम्प्लेट प्रस्तुति लोड करें।
1. सुनिश्चित करें कि पहली स्लाइड में कम से कम तीन आकृतियाँ हैं, फिर इंडेक्स 2 वाली आकृति को प्लेसहोल्डर के रूप में उपयोग करें।
1. स्थिर मान 684 और 288 के बजाय उस आकृति से फ्रेम की चौड़ाई और ऊँचाई ले लें। आकार गणनाएँ अपरिवर्तित रखें।
1. स्थिर निर्देशांक 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें।
1. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में सक्रिय करने के बाद मेरा एम्बेड किया गया Excel चार्ट आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel पहली सक्रियता पर मूल विंडो आकार पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम के अपने आयाम होते हैं। PowerPoint और Excel आकार पर बातचीत करके अनुपात बनाए रखने की कोशिश करते हैं, जिससे पुनः आकार बदलना हो सकता है।

**मैं चार्ट और OLE फ्रेम के आकार को कैसे सुसंगत रख सकता हूँ?**

स्थिर चार्ट आयाम सेट करें जो OLE फ्रेम से मेल खाते हों और वर्कबुक को एम्बेड करने से पहले एक कस्टम चार्ट प्रिंट आकार का उपयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और इकाई रूपांतरण दिखाता है।

**क्या केवल वर्कबुक विंडो आकार मिलाना पर्याप्त है?**

केवल वर्कबुक विंडो आकार मिलाना OLE फ्रेम के सक्रियता के बाद आकार बदलने से विश्वसनीय रूप से रोक नहीं पाता। उदाहरण में दिखाए अनुसार स्थिर चार्ट आयाम उपयोग करें।

**क्या यह समाधान टेम्प्लेट‑आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों के साथ काम करता है?**

हाँ। टेम्प्लेट के लिए प्लेसहोल्डर के आयाम और स्थिति का उपयोग करें। नई प्रस्तुति के लिए सीधे फ्रेम के आयाम और स्थिति निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्रामों में बनाए गए चार्ट के साथ उपयोग कर सकता हूँ?**

यह उदाहरण Aspose.Cells द्वारा निर्मित Excel वर्कबुक का उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्रामों के सक्रियण व्यवहार को प्रदर्शित नहीं करता।

## **संबंधित अनुभाग**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)