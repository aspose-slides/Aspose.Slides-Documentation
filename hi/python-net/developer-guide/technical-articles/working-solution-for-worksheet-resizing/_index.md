---
title: वर्कशीट आकार परिवर्तन के लिए कार्य समाधान
type: docs
weight: 40
url: /hi/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रीव्यू छवि
- छवि आकार परिवर्तन
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "प्रेजेंटेशन में Excel वर्कशीट OLE आकार परिवर्तन को ठीक करें: दो तरीके जिससे ऑब्जेक्ट फ्रेम स्थिर रहें—फ्रेम को स्केल करें या शीट को—PPT और PPTX फ़ॉर्मैट्स में।"
---
{{% alert color="info" title="Note" %}}

एक्सेल कार्यपत्रकों को OLE ऑब्जेक्ट के रूप में PowerPoint प्रस्तुति में Aspose घटकों का उपयोग करके एम्बेड करने पर पहली सक्रियता के बाद उनका आकार अप्रत्याशित रूप से बदल सकता है। यह व्यवहार OLE ऑब्जेक्ट के सक्रिय होने से पहले और बाद में एक स्पष्ट दृश्य अंतर पैदा करता है। यह लेख इस समस्या की व्याख्या करता है और इसे हल करने के दो तरीके बताता है।

{{% /alert %}} 

## **पृष्ठभूमि**

लेख में [OLE प्रबंधन](/slides/hi/python-net/manage-ole/) हमने Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें, बताया था। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/python-net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने OLE ऑब्जेक्ट फ्रेम में चयनित कार्यपत्रक क्षेत्र की छवि असाइन की। आउटपुट प्रस्तुति में, जब आप OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं जो कार्यपत्रक की छवि दिखा रहा है, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकता है और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकता है। उपयोगकर्ता के स्लाइड पर लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। आकार परिवर्तन का अनुपात OLE ऑब्जेक्ट फ्रेम और एम्बेड किए गए Excel वर्कबुक के आकार पर निर्भर करता है। 

## **आकार परिवर्तन का कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार का समन्वय करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बनाए रखा जा सके। आकार परिवर्तन Excel विंडो के आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होता है।

## **कार्य समाधान**

आकार परिवर्तन प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम को चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुरूप स्केल करें।  
- OLE फ्रेम का आकार स्थिर रखें और चयनित पंक्तियों और स्तंभों को उसके भीतर फिट होने के लिए स्केल करें।  

### **OLE फ्रेम आकार स्केल करें**

यह विधि एम्बेडेड Excel कार्यपत्रक में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुरूप OLE फ्रेम का आकार निर्धारित करती है।

उदाहरण मौजूदा Excel वर्कबुक को लोड करता है और शून्य‑आधारित सूचकांकों का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) प्रदर्शित रेंज को 정의 करता है। प्रीव्यू 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को 72 पॉइंट प्रति इंच का उपयोग करके पॉइंट में परिवर्तित किया जाता है। [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) उन आयामों के साथ संशोधित वर्कबुक को फ्रेम में एम्बेड करता है। प्रीव्यू को [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) के माध्यम से असाइन किया जाता है ताकि सहेजी गई प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदल दिया जाए।

प्रीव्यू हेल्पर [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) को चयनित रेंज पर सेट करता है और मार्जिन, हेडर तथा फुटर को हटा देता है। [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) सक्षम होने पर, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर इमेज स्ट्रीम को पुनः स्थापित करता है और इसे प्रस्तुति में उपयोग के लिए लौटाता है।

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

नीचे पूरा उदाहरण हेल्पर को वर्कबुक एम्बेडिंग के साथ मिलाता है और प्रस्तुति को `output.pptx` के रूप में सहेजता है।

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE छवि की चौड़ाई और ऊँचाई पॉइंट में प्राप्त करें।
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # हमें संशोधित वर्कबुक का उपयोग करना है।
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # प्रस्तुतिकरण संसाधनों में OLE छवि जोड़ें।
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # OLE ऑब्जेक्ट फ्रेम बनाएं।
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **सेल रेंज आकार स्केल करें**

यह विधि चयनित पंक्तियों की ऊँचाई और चयनित स्तंभों की चौड़ाई को एक कस्टम OLE फ्रेम आकार के अनुरूप स्केल करती है।

उदाहरण मौजूदा Excel वर्कबुक को लोड करता है और शून्य‑आधारित सूचकांकों का उपयोग करके उसकी पहली कार्यपत्रक की पहली 10 पंक्तियों और 13 स्तंभों का चयन करता है। [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) प्रदर्शित रेंज को 정의 करता है, और नीचे दिया गया हेल्पर उस रेंज को 400 पॉइंट चौड़ा और 100 पॉइंट ऊँचा फ्रेम में फिट करने के लिए स्केल करता है। संशोधित वर्कबुक को स्ट्रीम में सहेजने के बाद, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) निर्दिष्ट आकार पर एम्बेड किया जाता है। 96 DPI पर रेंडर किया गया प्रीव्यू [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) के माध्यम से असाइन किया जाता है, ताकि सहेजी गई प्रस्तुति चयनित कोशिकाओं को डिफ़ॉल्ट प्लेसहोल्डर के बजाय प्रदर्शित करे।

स्केलिंग हेल्पर चयनित रेंज के लिए अलग‑अलग चौड़ाई और ऊँचाई अनुपात की गणना करता है, जिससे उसके स्तंभों की आपस में संबंधित चौड़ाई और पंक्तियों की आपस में संबंधित ऊँचाई बनी रहती है। यह गणना किए गए आयामों को पॉइंट से इंच में परिवर्तित करता है और उन्हें [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) तथा [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) के साथ लागू करता है। चयनित रेंज की चौड़ाई और ऊँचाई शून्य नहीं होनी चाहिए।

```py
import aspose.cells as cells

# <param name="width">सेल रेंज की अपेक्षित चौड़ाई पॉइंट में।</param>
# <param name="height">सेल रेंज की अपेक्षित ऊँचाई पॉइंट में।</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

यह प्रीव्यू हेल्पर [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) का उपयोग करके रिसाइज़्ड रेंज को रेंडर करता है। यह [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) को उस रेंज तक सीमित करता है, मार्जिन, हेडर तथा फुटर को हटाता है, और एक PNG स्ट्रीम को उसकी शुरुआत पर स्थित करके लौटाता है।

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

नीचे पूरा उदाहरण हेल्पर को वर्कबुक एम्बेडिंग के साथ मिलाता है और प्रस्तुति को `output.pptx` के रूप में सहेजता है।

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">सेल रेंज की अपेक्षित चौड़ाई पॉइंट में।</param>
# <param name="height">सेल रेंज की अपेक्षित ऊँचाई पॉइंट में।</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # वर्कबुक फ़ाइल को PowerPoint में OLE ऑब्जेक्ट के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # सेल रेंज को फ्रेम आकार के अनुसार स्केल करें।
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # हमें संशोधित वर्कबुक का उपयोग करना है।
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # प्रेज़ेंटेशन संसाधनों में OLE छवि जोड़ें।
            ole_image = presentation.images.add_image(image_stream)

            # OLE ऑब्जेक्ट फ्रेम बनाएं।
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **निष्कर्ष**

{{% alert color="info" title="Note" %}}

वर्कशीट आकार परिवर्तन समस्या को ठीक करने के दो तरीके हैं। अपनी आवश्यकताओं और उपयोग‑केस के अनुसार उपयुक्त तरीका चुनें और प्रयोग करें। दोनों तरीके समान रूप से काम करते हैं, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। इसके अलावा इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एम्बेडेड Excel कार्यपत्रक PowerPoint में पहली सक्रियता पर आकार क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel सक्रिय होने पर अपना मूल विंडो आकार बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार का समन्वय करके अनुपात बनाए रखते हैं, जिससे आकार परिवर्तन हो सकता है।

**क्या इस आकार परिवर्तन समस्या को पूरी तरह से रोका जा सकता है?**

हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को इच्छित OLE फ्रेम आकार के अनुसार स्केल करके अनचाहे आकार परिवर्तन को रोका जा सकता है।

**कौन सी स्केलिंग विधि उपयोग करनी चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**

यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए स्थिर आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।

**क्या ये समाधान टेम्पलेट‑आधारित प्रस्तुति में भी काम करेंगे?**

हाँ। दोनों समाधान टेम्पलेट से बनाई गई और शून्य से बनाई गई प्रस्तुतियों दोनों में काम करेंगे।

**इन विधियों का उपयोग करने पर OLE फ्रेम के आकार पर कोई सीमा है क्या?**

नहीं। आप OLE ऑब्जेक्ट फ्रेम को कोई भी आकार दे सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से कैसे बचें?**

हाँ। लक्ष्य Excel सेल रेंज की स्नैपशॉट लेकर उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करने से डिफ़ॉल्ट प्लेसहोल्डर की जगह कस्टम प्रीव्यू इमेज दिखाया जा सकता है।