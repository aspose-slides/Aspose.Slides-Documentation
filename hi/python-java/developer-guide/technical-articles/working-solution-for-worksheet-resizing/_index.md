---
title: कार्यपत्रक रिसाइज़िंग के लिए कार्यशील समाधान
type: docs
weight: 20
url: /hi/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रीव्यू छवि
- छवि रिसाइज़िंग
- Excel
- कार्यपत्रक
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "प्रेजेंटेशन में Excel कार्यपत्रक OLE रिसाइज़िंग को ठीक करें: वस्तु फ्रेम की स्थिरता बनाए रखने के दो तरीके—फ़्रेम को स्केल करें या शीट को—PPT और PPTX स्वरूपों में।"
---
{{% alert color="info" title="ध्यान" %}}

यह देखा गया है कि Excel वर्कशीट्स को OLE ऑब्जेक्ट के रूप में Aspose कम्पोनेंट्स के माध्यम से PowerPoint प्रस्तुति में एम्बेड करने पर पहली सक्रियता के बाद उनका आकार अनिश्चित स्केल पर बदल जाता है। यह व्यवहार OLE ऑब्जेक्ट की पूर्व-और-पोस्ट सक्रियता स्थितियों के बीच एक स्पष्ट दृश्य अंतर बनाता है। हमने इस समस्या की विस्तार से जाँच की है और एक समाधान प्रदान किया है, जिसका विवरण इस लेख में दिया गया है।

{{% /alert %}}

## **पृष्ठभूमि**

लेख [Manage OLE](/slides/hi/python-java/manage-ole/) में, हमने बताया था कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [object preview issue](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने OLE ऑब्जेक्ट फ्रेम में चयनित वर्कशीट क्षेत्र की छवि असाइन की। आउटपुट प्रस्तुति में, जब आप OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं जो वर्कशीट छवि दिखा रहा है, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकता है और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकता है। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। रिसाइज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **रिसाइज़िंग का कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर समझौता करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बना रहे। रिसाइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होती है।

## **कार्यशील समाधान**

रिसाइज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम का आकार उन पंक्तियों और कॉलमों की इच्छित संख्या की ऊँचाई और चौड़ाई के अनुसार स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और भाग लेने वाली पंक्तियों और कॉलमों का आकार ताकि वह चयनित OLE फ्रेम के भीतर फिट हो सके, स्केल करें।

### **OLE फ्रेम आकार को स्केल करें**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का OLE फ्रेम आकार Excel वर्कशीट की भाग लेने वाली पंक्तियों और कॉलमों के संचयी आकार के साथ मिलान करने के लिए कैसे सेट करें।

मान लें कि हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक में भाग लेने वाली पंक्तियों की ऊँचाई और कॉलमों की चौड़ाई के संचयी मान के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए हुए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में भाग लेने वाली पंक्तियों और कॉलमों के इच्छित भाग की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

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

    # जब वर्कबुक को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग किया जाता है तो प्रदर्शित आकार सेट करें।
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # OLE छवि की चौड़ाई और ऊँचाई पॉइंट्स में प्राप्त करें।
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

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

            # OLE ऑब्जेक्ट फ्रेम बनाएँ।
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

### **सेल रेंज आकार को स्केल करें**

इस दृष्टिकोण में, हम सीखेंगे कि भाग लेने वाली पंक्तियों की ऊँचाई और भाग लेने वाले कॉलमों की चौड़ाई को एक कस्टम OLE फ्रेम आकार के साथ मिलाने के लिए कैसे स्केल करें।

मान लें कि हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, हम OLE फ्रेम का आकार सेट करेंगे और OLE फ्रेम क्षेत्र में भाग लेने वाली पंक्तियों और कॉलमों के आकार को स्केल करेंगे। फिर हम बदलावों को लागू करने के लिए वर्कबुक को एक स्ट्रीम में सेव करेंगे और इसे एक बाइट एरे में बदलेंगे ताकि इसे OLE फ्रेम में जोड़ा जा सके। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने के लिए, हम वर्कबुक में भाग लेने वाली पंक्तियों और कॉलमों के इच्छित भाग की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम छवि के रूप में सेट करेंगे।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpime.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpime.JClass("java.io.ByteArrayOutputStream")


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
    # सेल रेंज की अपेक्षित चौड़ाई और ऊँचाई पॉइंट्स में है।
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
    # फ्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें।
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

            # OLE ऑब्जेक्ट फ्रेम बनाएँ।
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

{{% alert color="info" title="ध्यान" %}} 

वर्कशीट रिसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। उचित विधि का चयन विशिष्ट आवश्यकताओं और उपयोग मामलों पर निर्भर करता है। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। अतिरिक्त रूप से, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एम्बेडेड Excel वर्कशीट PowerPoint में पहली बार सक्रिय होने पर आकार क्यों बदलती है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार पर बातचीत करके अनुपात बनाए रखते हैं, जिससे रिसाइज़िंग हो सकती है।

**क्या इस रिसाइज़िंग समस्या को पूरी तरह रोकना संभव है?**

हां। OLE फ्रेम को Excel सेल रेंज आकार में फिट करके या सेल रेंज को इच्छित OLE फ्रेम आकार में फिट करके आप अनपेक्षित रिसाइज़िंग को रोक सकते हैं।

**कौन सा स्केलिंग तरीका उपयोग करना चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और कॉलमों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम का निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान मेरे टेम्पलेट‑आधारित प्रस्तुति में भी काम करेंगे?**

हां। दोनों समाधान टेम्पलेट से बनाए गए और शून्य से बनाए गए प्रस्तुतियों दोनों में काम करते हैं।

**इन तरीकों का उपयोग करने पर OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को किसी भी आकार में बना सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट को हटाने का कोई तरीका है?**

हां। लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करने से आप डिफ़ॉल्ट प्लेसहोल्डर की जगह एक कस्टम प्रीव्यू इमेज दिखा सकते हैं।

## **संबंधित लेख**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)