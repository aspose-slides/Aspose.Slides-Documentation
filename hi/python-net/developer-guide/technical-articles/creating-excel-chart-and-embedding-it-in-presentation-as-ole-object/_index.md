---
title: Excel चार्ट बनाएं और उन्हें प्रस्तुति में OLE ऑब्जेक्ट के रूप में एंबेड करें
type: docs
weight: 50
url: /hi/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एंबेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- Python
- Python via .NET
- Aspose.Slides
description: "Aspose.Cells for Python via .NET के साथ एक Excel चार्ट बनाएं और Aspose.Slides के साथ PowerPoint प्रस्तुति में कार्यपुस्तिका को एंबेड करें, जिसमें चार्ट प्रीव्यू शामिल हो।"
---
## **अवलोकन**

यह लेख दर्शाता है कि Aspose.Cells for Python via .NET के साथ Excel कॉलम चार्ट कैसे बनाया जाए और Aspose.Slides for Python via .NET के साथ उसके वर्कबुक को PowerPoint प्रस्तुति में एंबेड किया जाए। एंबेडेड वर्कबुक में स्रोत डेटा और चार्ट दोनों होते हैं। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट को OLE ऑब्जेक्ट सक्रिय होने से पहले प्रदर्शित करता है।

परिणाम एक एंबेडेड Excel ऑब्जेक्ट है, न कि मूल PowerPoint चार्ट। OLE के माध्यम से वर्कबुक को संपादित करने के लिए OLE सक्रियता का समर्थन करने वाला डेस्कटॉप एप्लिकेशन और संगत Excel इंस्टॉलेशन आवश्यक है।

## **पूर्वापेक्षाएँ**

अपने Python पर्यावरण में `aspose-cells-python` और `aspose-slides` पैकेज स्थापित करें। इन लाइब्रेरीज़ के साथ प्रस्तुति बनाने के लिए Microsoft Office की आवश्यकता नहीं है।

कोई इनपुट फ़ाइल आवश्यक नहीं है: उदाहरण डेटा और चार्ट को मेमोरी में बनाता है, फिर `OutputChart.pptx` को वर्तमान कार्यशील डायरेक्टरी में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लिए लाइसेंस लागू करें।

## **एंबेडिंग कैसे कार्य करती है**

1. डेटा वर्कशीट और चार्ट शीट के साथ एक वर्कबुक बनाएँ।  
2. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।  
3. वर्कबुक की OLE डिस्प्ले रेंज सेट करें और चार्ट को PNG में रेंडर करें।  
4. वर्कबुक को मेमोरी में XLSX के रूप में सहेजें और उन बाइट्स को स्लाइड में एंबेड करें।  
5. PNG को OLE ऑब्जेक्ट के प्रीव्यू के रूप में असाइन करें और प्रस्तुति को PPTX के रूप में सहेजें।

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ़्रेम की अलग भूमिकाएँ हैं। [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) शून्य‑आधारित शुरू/समाप्ति पंक्ति और स्तम्भ संकेतांक लेता है। [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) इसके बजाय ऊपर की पंक्ति, बाएँ स्तम्भ, नीचे की पंक्ति, और दाएँ स्तम्भ लेता है। उदाहरण पंक्ति संकेतांक 55 और स्तम्भ संकेतांक 25 को निचले‑दाएँ सीमाओं के रूप में उपयोग करता है; ये मान लेआउट विकल्प हैं, न कि डेटा पंक्तियों या स्तम्भों की संख्या।

स्लाइड फ़्रेम पॉइंट्स में मापा जाता है। उदाहरण इसे स्लाइड के भीतर फिट करता है और PNG के अनुपात को बनाए रखते हुए केंद्रित करता है, बजाय प्रीव्यू को स्लाइड भरने के लिए खींचे।

## **चार्ट बनाना और एंबेड करना**

निम्नलिखित पूर्ण उदाहरण `DataSheet` को चार पंक्तियों और पाँच स्तम्भों के मानों से भरता है। प्रत्येक पंक्ति एक चार्ट सीरीज़ बनती है। `ChartSheet` को वर्कबुक सहेजने से पहले सक्रिय शीट के रूप में चुना जाता है।

वर्कबुक स्पष्ट रूप से XLSX के रूप में सहेजी जाती है, जो `xlsx` एक्सटेंशन के साथ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) को पास किया जाता है। PNG को बिना मध्यवर्ती बिटमैप रूपांतरण के सीधे उसकी स्ट्रीम से लोड किया जाता है। इसे [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) के माध्यम से असाइन करने से डिफ़ॉल्ट OLE प्लेसहोल्डर प्रतिस्थापित हो जाता है।

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# चार्ट प्रीव्यू को रेंडर करें और संपादन योग्य वर्कबुक को अलग से सीरियलाइज़ करें।
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # प्रीव्यू को स्लाइड के भीतर फिट करें बिना इसके aspect ratio को बदले।
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` में एक स्लाइड होती है जिसमें एंबेडेड Excel वर्कबुक और एक चार्ट प्रीव्यू होता है। वर्कबुक में मूल डेटा और चार सीरीज़ वाला कॉलम चार्ट शामिल है। प्रीव्यू स्लाइड पर केंद्रित है और अपने अनुपात को बनाए रखता है।

![Excel कॉलम चार्ट जो एंबेडेड वर्कबुक का प्रीव्यू है](excel-chart-ole-preview.png)

एक संगत डेस्कटॉप PowerPoint वातावरण में जहाँ Excel उपलब्ध है, ऑब्जेक्ट को डबल‑क्लिक करके एंबेडेड वर्कबुक को सक्रिय और संपादित किया जा सकता है। सक्रियकरण और संपादन होस्ट एप्लिकेशन की OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रीव्यू इमेज की आवश्यकता क्यों है?**  
एंबेडेड वर्कबुक और उसकी स्लाइड प्रीव्यू अलग‑अलग सामग्री हैं। एक चार्ट इमेज प्रदान करें ताकि स्लाइड डिफ़ॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखाए। देखें [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/python-net/object-preview-issue-when-adding-oleobjectframe/)।

**क्या कोड में वर्कबुक बदलने पर प्रीव्यू स्वचालित रूप से अपडेट होता है?**  
प्रीव्यू को एक स्नैपशॉट मानें। जब प्रोग्रामmatically वर्कबुक डेटा अपडेट किया जाता है, तो चार्ट इमेज को पुनः उत्पन्न करके प्रीव्यू और एंबेडेड वर्कबुक डेटा दोनों को बदलें।

**क्या मैं XLS को XLSX की बजाय उपयोग कर सकता हूँ?**  
हाँ। वर्कबुक को XLS फ़ॉर्मेट में सहेजें और एंबेडेड डेटा एक्सटेंशन के रूप में `xls` उपयोग करें। एक्सटेंशन को वास्तविक वर्कबुक फ़ॉर्मेट से मेल खाना चाहिए; केवल एक्सटेंशन बदलने से डेटा परिवर्तित नहीं होता।

**सक्रियकरण के बाद ऑब्जेक्ट का आकार क्यों बदल सकता है?**  
जब होस्ट एप्लिकेशन वर्कबुक को सक्रिय करता है, तो वह OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ़्रेम के आयाम दोनों महत्वपूर्ण हैं। देखें [PowerPoint प्रस्तुतियों में OLE ऑब्जेक्ट्स को स्वचालित रूप से रिसाइज़ करना](/slides/hi/python-net/working-solution-for-worksheet-resizing/)।

## **संबंधित अनुभाग**

- [PowerPoint प्रस्तुतियों में OLE ऑब्जेक्ट्स को स्वचालित रूप से रिसाइज़ करना](/slides/hi/python-net/working-solution-for-worksheet-resizing/)  
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/python-net/object-preview-issue-when-adding-oleobjectframe/)  
- [OLE ऑब्जेक्ट्स का प्रबंधन](/slides/hi/python-net/manage-ole/)