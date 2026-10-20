---
title: कार्यपत्रक आकार बदलने के लिए कार्यशील समाधान
type: docs
weight: 20
url: /hi/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रीव्यू छवि
- छवि आकार बदलना
- Excel
- कार्यपत्रक
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "प्रेजेंटेशन में Excel कार्यपत्रक OLE आकार बदलने को ठीक करें: दो तरीके जिससे ऑब्जेक्ट फ्रेम स्थिर रहें—फ़्रेम या शीट को स्केल करें—PPT और PPTX फॉर्मैट में।"
---
{{% alert color="info" title="Note" %}}
Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड किए गए Excel कार्यपत्रक पहली सक्रियता के बाद अप्रत्याशित रूप से आकार बदल सकते हैं। यह व्यवहार OLE वस्तु के सक्रिय होने से पहले और बाद में एक उल्लेखनीय दृश्य अंतर पैदा करता है। यह लेख इस समस्या को समझाता है और इसे समाधान करने के दो तरीकों का वर्णन करता है।
{{% /alert %}}

## **पृष्ठभूमि**

विषय [OLE प्रबंधन](/slides/hi/python-java/manage-ole/) में, हमने बताया कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/) को समाधान करने के लिए, हमने चयनित कार्यपत्रक क्षेत्र की एक छवि को OLE ऑब्जेक्ट फ्रेम को असाइन किया। आउटपुट प्रस्तुति में, जब आप कार्यपत्रक छवि प्रदर्शित करने वाले OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित बदलाव कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। आकार बदलने का कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **आकार बदलने का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने का प्रयास करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के भाग के रूप में सही अनुपात बना रहे। आकार बदलना Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार और स्थिति के बीच अंतर के आधार पर होता है।

## **कार्य करने वाला समाधान**

आकार बदलने के प्रभाव को रोकने के लिए दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम को चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और चयनित पंक्तियों व स्तंभों को उसके भीतर फिट होने के लिए स्केल करें।

### **OLE फ्रेम आकार स्केल करें**

यह तरीका एम्बेड किए गए Excel कार्यपत्रक में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार OLE फ्रेम का आकार सेट करता है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित सूचकांक का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) प्रदर्शित रेंज को परिभाषित करता है। प्रीव्यू 96 DPI पर रेंडर किया गया है, और इसके पिक्सेल आयामों को 72 पॉइंट प्रति इंच का उपयोग करके पॉइंट में परिवर्तित किया जाता है। [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) संशोधित वर्कबुक को उन आयामों वाले फ़्रेम में एम्बेड करता है। प्रीव्यू को [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन किया जाता है ताकि सहेजे गए प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदला जा सके।

प्रीव्यू हेल्पर चयनित रेंज के लिए [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) सेट करता है और मार्जिन, हेडर और फुटर को हटाता है। [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) सक्रिय होने पर, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर एक नया इनपुट स्ट्रीम लौटाता है जिसमें PNG छवि होती है, जो प्रस्तुति में उपयोग के लिए उसकी शुरुआत पर स्थित होती है।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # PowerPoint में OLE ऑब्जेक्ट के रूप में वर्कबुक उपयोग किए जाने पर प्रदर्शित आकार सेट करें।
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # OLE छवि की चौड़ाई और ऊँचाई को पॉइंट में प्राप्त करें।
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Use the modified workbook.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE ऑब्जेक्ट फ्रेम बनाएं।
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **सेल रेंज आकार स्केल करें**

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित सूचकांक का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) प्रदर्शित रेंज को परिभाषित करता है, और scale_cell_range हेल्पर उस रेंज को 400 पॉइंट चौड़ी और 100 पॉइंट ऊँची फ़्रेम में फिट करने के लिए स्केल करता है। संशोधित वर्कबुक को स्ट्रीम में सहेजने के बाद, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) उसे निर्दिष्ट आकार पर एम्बेड करता है। 96 DPI पर रेंडर किया गया प्रीव्यू [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन किया जाता है, जिससे सहेजे गए प्रस्तुति में डिफ़ॉल्ट प्लेसहोल्डर के बजाय चयनित सेल्स दिखाए जाते हैं।

स्केलिंग हेल्पर चयनित रेंज के लिए अलग-अलग चौड़ाई और ऊँचाई अनुपात गणना करता है, जिससे उसके स्तंभों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई बनी रहती है। यह गणना किए गए आयामों को पॉइंट से इंच में परिवर्तित करता है, फिर उन्हें [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) और [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) के साथ लागू करता है। चयनित रेंज की चौड़ाई और ऊँचाई शून्य नहीं होनी चाहिए।

यह प्रीव्यू हेल्पर [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) का उपयोग करके रीसाइज़्ड रेंज को रेंडर करता है। यह [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) को उसी रेंज तक सीमित करता है, मार्जिन, हेडर और फुटर हटाता है, और एक PNG स्ट्रीम लौटाता है जो उसकी शुरुआत पर स्थित होती है।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # सेल रेंज की अपेक्षित चौड़ाई और ऊँचाई पॉइंट में हैं।
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # जब वर्कबुक को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # सेल रेंज को फ्रेम आकार के अनुसार स्केल करें।
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # संशोधित वर्कबुक का उपयोग करें।
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE ऑब्जेक्ट फ्रेम बनाएं।
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **निष्कर्ष**
{{% alert color="info" title="Note" %}} 
वर्कशीट आकार बदलने की समस्या को ठीक करने के दो तरीके हैं। वह तरीका चुनें जो आपकी आवश्यकताओं और उपयोग के मामलों के लिए सबसे उपयुक्त हो। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुतियों को टेम्पलेट से बनाया गया हो या शून्य से। अतिरिक्त रूप से, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**जब PowerPoint में एम्बेडेड Excel कार्यपत्रक पहली बार सक्रिय होता है तो उसका आकार क्यों बदल जाता है?**  
यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने का प्रयास करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम की अपनी परिमाण होती है। PowerPoint और Excel आकार पर बातचीत करके अनुपात को बनाए रखते हैं, जिससे आकार बदल सकता है।

**क्या इस आकार बदलने की समस्या को पूरी तरह से रोकना संभव है?**  
हां। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार के अनुसार स्केल करके आप अनचाहे आकार बदलने को रोक सकते हैं।

**मुझे कौन सा स्केलिंग तरीका उपयोग करना चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**  
यदि आप मूल Excel पंक्ति और स्तंभ आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे टेम्पलेट-आधारित प्रस्तुति पर भी काम करेंगे?**  
हां। दोनों समाधान टेम्पलेट से बनाए गए और शून्य से बनाए गए प्रस्तुतियों दोनों पर काम करते हैं।

**इन तरीकों का उपयोग करते समय OLE फ्रेम के आकार पर कोई सीमा है क्या?**  
नहीं। आप OLE ऑब्जेक्ट फ्रेम का कोई भी आकार बना सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।

**"EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट को PowerPoint में कैसे हटाया जा सकता है?**  
हां। लक्षित Excel सेल रेंज की स्नैपशॉट लेकर और उसे OLE फ्रेम के प्लेसहोल्डर चित्र के रूप में सेट करके, आप डिफ़ॉल्ट प्लेसहोल्डर की जगह एक कस्टम प्रीव्यू छवि प्रदर्शित कर सकते हैं।

## **संबंधित लेख**

[एक्सेल चार्ट बनाना और उसे OLE ऑब्जेक्ट के रूप में प्रस्तुति में एम्बेड करना](/slides/hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड-इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)