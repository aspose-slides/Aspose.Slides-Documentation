---
title: Excel चार्ट बनाएं और उन्हें प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड करें
type: docs
weight: 30
url: /hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Cells for Python via Java का उपयोग करके एक Excel चार्ट बनाएं और Aspose.Slides के साथ PowerPoint प्रस्तुति में वर्कबुक को एम्बेड करें, जिसमें चार्ट का प्रीव्यू शामिल है।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Cells for Python via Java के साथ Excel कॉलम चार्ट कैसे बनाया जाए और इसे Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुति में एम्बेड किया जाए। एम्बेडेड वर्कबुक में स्रोत डेटा और चार्ट दोनों होते हैं। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट को दिखाता है, इससे पहले कि OLE ऑब्जेक्ट सक्रिय हो।

परिणाम एक एम्बेडेड Excel ऑब्जेक्ट होता है, न कि मूल PowerPoint चार्ट। OLE के माध्यम से वर्कबुक को संपादित करने के लिए एक डेस्कटॉप एप्लिकेशन चाहिए जो OLE सक्रियण का समर्थन करता हो और संगत Excel इंस्टॉलेशन हो।

## **आवश्यकताएँ**

`aspose-cells` और `aspose-slides-java` Python पैकेज और एक संगत Java रनटाइम स्थापित करें। दोनों पैकेज को JVM शुरू करने से पहले इम्पोर्ट करें ताकि उनके Java लाइब्रेरी JPype के लिए उपलब्ध हों। इन लाइब्रेरीज़ के साथ प्रस्तुति उत्पन्न करने के लिए Microsoft Office की आवश्यकता नहीं है।

कोई इनपुट फ़ाइल आवश्यक नहीं है: उदाहरण डेटा और चार्ट को मेमोरी में बनाता है, फिर `OutputChart.pptx` को वर्तमान कार्य निर्देशिका में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लिए लाइसेंस लागू करें।

## **एम्बेडिंग कैसे काम करती है**

1. डेटा कार्यपत्रक और चार्ट शीट के साथ एक वर्कबुक बनाएं।
2. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।
3. वर्कबुक की OLE डिस्प्ले रेंज सेट करें और चार्ट को PNG में रेंडर करें।
4. वर्कबुक को मेमोरी में XLSX के रूप में सहेजें और उन बाइट्स को स्लाइड में एम्बेड करें।
5. PNG को OLE ऑब्जेक्ट के प्रीव्यू के रूप में असाइन करें और प्रस्तुति को PPTX के रूप में सहेजें।

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ्रेम की अलग-अलग भूमिकाएँ होती हैं। [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) शून्य-आधारित प्रारंभ/समाप्ति पंक्ति और स्तंभ सूचकांक लेता है। [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) इसके बजाय शीर्ष पंक्ति, बायाँ स्तंभ, निचली पंक्ति और दायाँ स्तंभ लेता है। उदाहरण में पंक्ति सूचकांक 55 और स्तंभ सूचकांक 25 को निचले-दाएँ सीमाओं के रूप में उपयोग किया गया है; ये मान लेआउट विकल्प हैं, न कि डेटा पंक्तियों या स्तंभों की संख्या।

स्लाइड फ्रेम पॉइंट्स में होता है। उदाहरण इसे स्लाइड के भीतर फिट करता है और केंद्रित करता है जबकि PNG के अनुपात को बनाए रखता है, बजाय इसके कि प्रीव्यू को स्लाइड भरने के लिए खींचा जाए।

## **चार्ट बनाएं और एम्बेड करें**

नीचे दिया गया पूर्ण उदाहरण `DataSheet` को चार पंक्तियों और पाँच स्तंभों के मानों से भरता है। प्रत्येक पंक्ति एक चार्ट सीरीज़ बनती है। `ChartSheet` को वर्कबुक सहेजने से पहले सक्रिय शीट के रूप में चुना जाता है।

वर्कबुक को स्पष्ट रूप से XLSX के रूप में सहेजा जाता है, जो `xlsx` एक्सटेन्शन के साथ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) को पास किया जाता है। Java बाइट-एरे स्ट्रीम वर्कबुक और इमेज को मेमोरी में रखती हैं और Java API द्वारा आवश्यक बाइट एरे प्रदान करती हैं। PNG को उसके बाइट्स से सीधे लोड किया जाता है बिना किसी मध्यवर्ती बिटमैप रूपांतरण के। इसे [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन करने से डिफ़ॉल्ट OLE प्लेसहोल्डर बदल जाता है।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # चार्ट का प्रीव्यू रेंडर करें और संपादन योग्य वर्कबुक को अलग से सीरियलाइज़ करें।
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # प्रीव्यू को स्लाइड के भीतर फिट करें बिना उसके अनुपात को बदले।
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` में एक स्लाइड होती है जिसमें एम्बेडेड Excel वर्कबुक और चार्ट प्रीव्यू होता है। वर्कबुक में मूल डेटा और चार पंक्तियों वाला कॉलम चार्ट होता है। प्रीव्यू स्लाइड पर केंद्रित होता है और अपने अनुपात को बनाए रखता है।

![एक्सेल कॉलम चार्ट जो एम्बेडेड वर्कबुक के प्रीव्यू के रूप में दिखाया गया है](excel-chart-ole-preview.png)

एक संगत डेस्कटॉप PowerPoint वातावरण में जहाँ Excel उपलब्ध है, ऑब्जेक्ट को डबल‑क्लिक करके एम्बेडेड वर्कबुक को सक्रिय और संपादित किया जा सकता है। सक्रियण और संपादन होस्ट एप्लिकेशन के OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करता है।

## **FAQ**

**प्रिव्यू इमेज की आवश्यकता क्यों है?**

एम्बेडेड वर्कबुक और उसकी स्लाइड प्रीव्यू अलग‑अलग सामग्री हैं। चार्ट इमेज प्रदान करने से स्लाइड पर डिफ़ॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखता है। देखें [ऑब्जेक्ट प्रीव्यू इश्यू जब OleObjectFrame जोड़ रहे हैं](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/)।

**क्या कोड में वर्कबुक बदलने पर प्रीव्यू स्वचालित रूप से अपडेट होता है?**

प्रीव्यू को स्नैपशॉट के रूप में माना जाता है। जब प्रोग्रामेटिक रूप से वर्कबुक डेटा अपडेट किया जाता है, तो चार्ट इमेज को फिर से जनरेट करना और प्रीव्यू तथा एम्बेडेड वर्कबुक डेटा दोनों को बदलना आवश्यक है।

**क्या मैं XLS को XLSX की जगह उपयोग कर सकता हूँ?**

हां। वर्कबुक को XLS फ़ॉर्मेट में सहेजें और एम्बेडेड डेटा एक्सटेन्शन के रूप में `xls` उपयोग करें। एक्सटेन्शन को वास्तविक वर्कबुक फ़ॉर्मेट से मेल खाना चाहिए; केवल एक्सटेन्शन बदलने से डेटा नहीं बदलता।

**सक्रियण के बाद ऑब्जेक्ट का आकार क्यों बदल सकता है?**

होस्ट एप्लिकेशन वर्कबुक सक्रिय होने पर OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ्रेम आयाम दोनों ही महत्वपूर्ण हैं। देखें [पीपीटीएक्स में चार्ट रिसाइज़िंग के लिए कार्यकारी समाधान](/slides/hi/python-java/working-solution-for-chart-resizing-in-pptx/)।

## **संबंधित अनुभाग**

- [पीपीटीएक्स में चार्ट रिसाइज़िंग के लिए कार्यकारी समाधान](/slides/hi/python-java/working-solution-for-chart-resizing-in-pptx/)
- [ऑब्जेक्ट प्रीव्यू इश्यू जब OleObjectFrame जोड़ रहे हैं](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/)