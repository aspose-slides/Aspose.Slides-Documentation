---
title: वर्कशीट आकार बदलने के लिए कार्यशील समाधान
type: docs
weight: 40
url: /hi/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- पूर्वावलोकन छवि
- छवि आकार बदलना
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "प्रस्तुति में Excel वर्कशीट OLE आकार बदलने की समस्या को ठीक करें: ऑब्जेक्ट फ्रेम को सुसंगत रखने के दो तरीके—फ़्रेम को स्केल करें या शीट को—PPT और PPTX फ़ॉर्मेट्स में।"
---
{{% alert color="primary" %}} 

यह देखा गया है कि Aspose कॉम्पोनेंट्स के माध्यम से PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel वर्कशीट को पहली सक्रियता के बाद एक अनजान स्केल पर री‑साइज़ किया जाता है। यह व्यवहार OLE ऑब्जेक्ट की सक्रियता से पहले और बाद की स्थिति के बीच एक स्पष्ट दृश्य अंतर पैदा करता है। हमने इस समस्या की विस्तृत जाँच की है और एक समाधान प्रदान किया है, जिसका विवरण इस लेख में दिया गया है।

{{% /alert %}} 

## **पृष्ठभूमि**

लेख में [OLE प्रबंधित करें](/slides/hi/python-net/manage-ole/) हमने बताया था कि Aspose.Slides for Python via .NET का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ा जाए। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/python-net/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चयनित वर्कशीट क्षेत्र की छवि को OLE ऑब्जेक्ट फ्रेम को असाइन किया। आउटपुट प्रस्तुति में, जब आप उस OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं जो वर्कशीट की छवि दिखा रहा है, तो Excel वर्कबुक सक्रिय हो जाता है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित परिवर्तन कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस आने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाएगा। री‑साइज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **आकार बदलने का कारण**

चूँकि Excel वर्कबुक की अपनी विंडो आकार होती है, यह पहली सक्रियता पर अपनी मूल आकार को बनाए रखने की कोशिश करता है। दूसरी ओर, OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। माइक्रोसॉफ़्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के भाग के रूप में उचित अनुपात बना रहे। री‑साइज़िंग Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार एवं स्थिति के अंतर के आधार पर होती है।

## **कार्यशील समाधान**

आकार बदलने के प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम का आकार उन पंक्तियों और स्तंभों की इच्छित संख्या की ऊँचाई और चौड़ाई से मिलाने के लिए स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और भाग लेने वाली पंक्तियों और स्तंभों के आकार को चयनित OLE फ्रेम के भीतर फिट करने के लिए स्केल करें।

### **OLE फ़्रेम आकार को स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का OLE फ्रेम आकार कैसे सेट किया जाए ताकि वह Excel वर्कशीट की भाग लेने वाली पंक्तियों और स्तंभों के सम्मिलित आकार से मेल खाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, OLE ऑब्जेक्ट फ्रेम का आकार पहले वर्कबुक में भाग लेने वाली पंक्तियों की ऊँचाइयों और स्तंभों की चौड़ाइयों के सम्मिलित मान के आधार पर गणना किया जाएगा। फिर हम OLE फ्रेम का आकार इस गणना किए गए मान पर सेट करेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने हेतु, हम वर्कबुक में इच्छित पंक्तियों और स्तंभों के भाग की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint में वर्कबुक फाइल को OLE ऑब्जेक्ट के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें।
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE छवि की चौड़ाई और ऊँचाई को पॉइंट में प्राप्त करें।
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # हमें संशोधित वर्कबुक का उपयोग करना होगा।
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE छवि को प्रस्तुति संसाधनों में जोड़ें।
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # OLE ऑब्जेक्ट फ्रेम बनाएं।
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **सेल रेंज आकार को स्केल करें**

इस दृष्टिकोण में हम सीखेंगे कि भाग लेने वाली पंक्तियों की ऊँचाइयों और भाग लेने वाले स्तंभों की चौड़ाइयों को एक कस्टम OLE फ्रेम आकार के साथ मेल खाने के लिए कैसे स्केल किया जाए।

मान लीजिए हमारे पास एक टेम्पलेट Excel शीट है और हम इसे OLE फ्रेम के रूप में प्रस्तुति में जोड़ना चाहते हैं। इस स्थिति में, हम OLE फ्रेम का आकार सेट करेंगे और उस क्षेत्र में भाग लेने वाली पंक्तियों और स्तंभों के आकार को स्केल करेंगे। फिर हम परिवर्तन लागू करने के लिए वर्कबुक को एक स्ट्रीम में सहेजेंगे और OLE फ्रेम में जोड़ने के लिए इसे बाइट ऐरे में बदलेंगे। PowerPoint में OLE फ्रेम के लिए लाल "EMBEDDED OLE OBJECT" संदेश से बचने हेतु, हम वर्कबुक में इच्छित पंक्तियों और स्तंभों के भाग की छवि भी कैप्चर करेंगे और उसे OLE फ्रेम की छवि के रूप में सेट करेंगे।

```py
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint में वर्कबुक फाइल को OLE ऑब्जेक्ट के रूप में उपयोग करने पर प्रदर्शित आकार सेट करें.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # फ्रेम आकार में फिट होने के लिए सेल रेंज को स्केल करें.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # हमें संशोधित वर्कबुक का उपयोग करना आवश्यक है.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE छवि को प्रस्तुति संसाधनों में जोड़ें.
            ole_image = presentation.images.add_image(image_stream)

            # OLE ऑब्जेक्ट फ्रेम बनाएं.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **निष्कर्ष**

{{% alert color="primary" %}}

वर्कशीट री‑साइज़िंग समस्या को ठीक करने के दो तरीके हैं। उपयुक्त तरीके का चयन विशिष्ट आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों तरीकों का काम करने का तरीका समान है, चाहे प्रस्तुति टेम्पलेट से बनाई गई हो या शून्य से। इसके अतिरिक्त, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

{{% /alert %}}