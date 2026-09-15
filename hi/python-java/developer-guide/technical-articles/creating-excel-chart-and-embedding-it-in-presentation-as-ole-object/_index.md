---
title: Excel चार्ट बनाएं और उन्हें प्रेजेंटेशन में OLE ऑब्जेक्ट के रूप में एंबेड करें
type: docs
weight: 30
url: /hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एंबेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Python के साथ Excel चार्ट बनाएं और उन्हें PowerPoint और OpenDocument प्रेजेंटेशन में OLE ऑब्जेक्ट के रूप में एंबेड करें। कोड नमूने सहित चरण-दर-चरण गाइड।"
---
## **पृष्ठभूमि**

PowerPoint में, डेटा को ग्राफ़िक रूप से प्रदर्शित करने के लिए संपादन योग्य चार्ट्स का उपयोग एक सामान्य प्रथा है। Aspose, Aspose.Cells for Python via Java के साथ Excel चार्ट बनाने का समर्थन करता है, और इन चार्ट्स को फिर Aspose.Slides for Python via Java के माध्यम से PowerPoint स्लाइड्स में OLE ऑब्जेक्ट के रूप में एंबेड किया जा सकता है। यह लेख आवश्यक चरणों को कवर करता है और Aspose.Cells और Aspose.Slides का उपयोग करके Excel चार्ट बनाने और उसे PowerPoint प्रेजेंटेशन में OLE ऑब्जेक्ट के रूप में एंबेड करने के लिए एक Python कोड उदाहरण प्रदान करता है।

## **आवश्यक चरण**

PowerPoint स्लाइड में Excel चार्ट को OLE ऑब्जेक्ट के रूप में बनाने और एंबेड करने के लिए निम्न क्रम में चरणों की आवश्यकता है:

1. Aspose.Cells का उपयोग करके Excel चार्ट बनाएं।
1. Aspose.Cells का उपयोग करके Excel चार्ट का OLE आकार सेट करें।
1. Aspose.Cells से Excel चार्ट की छवि प्राप्त करें।
1. Aspose.Slides का उपयोग करके Excel चार्ट को PPTX प्रेजेंटेशन में OLE ऑब्जेक्ट के रूप में एंबेड करें।
1. स्टेप 3 में प्राप्त छवि के साथ "EMBEDDED OLE OBJECT" छवि को बदलें ताकि [ऑब्जेक्ट पूर्वावलोकन समस्या](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/) को हल किया जा सके।
1. प्रेजेंटेशन को डिस्क पर PPTX फ़ॉर्मेट में सहेजें।

## **आवश्यक चरणों का कार्यान्वयन**

उपरोक्त चरणों की Python कार्यान्वयन इस प्रकार है:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # सेल नामों की एक सूची।
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # सेल डेटा की एक सूची।
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # डेटा के साथ कोशिकाओं को भरने के लिए एक नया वर्कशीट जोड़ें।
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # डेटा शीट को डेटा से भरें।
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # एक चार्ट शीट जोड़ें।
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # डेटा शीट से डेटा सीरीज़ के साथ चार्ट शीट में एक चार्ट जोड़ें।
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # चार्ट शीट को सक्रिय शीट सेट करें।
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # वर्कबुक को एम्बेडेड OLE डेटा के रूप में वर्णित करें।
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# वर्कबुक बनाएं।
workbook = Workbook()

# एक Excel चार्ट जोड़ें।
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# चार्ट का OLE आकार सेट करें।
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# चार्ट की छवि प्राप्त करें और उसे स्ट्रीम में सहेजें।
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# वर्कबुक को स्ट्रीम में सहेजें।
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# एक प्रेजेंटेशन बनाएं।
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # वर्कबुक को एक स्लाइड में जोड़ें।
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

उपरोक्त विधि द्वारा निर्मित प्रेजेंटेशन में Excel चार्ट OLE ऑब्जेक्ट के रूप में होगा, जिसे OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करके सक्रिय किया जा सकता है।

## **निष्कर्ष**

Aspose.Cells for Python via Java को Aspose.Slides for Python via Java के साथ उपयोग करके, हम Aspose.Cells द्वारा समर्थित कोई भी Excel चार्ट बना सकते हैं और चार्ट को PowerPoint स्लाइड में OLE ऑब्जेक्ट के रूप में एंबेड कर सकते हैं। Excel चार्ट का OLE आकार भी परिभाषित किया जा सकता है। अंत उपयोगकर्ता तब Excel चार्ट को किसी अन्य OLE ऑब्जेक्ट की तरह संपादित कर सकते हैं।

## **संबंधित अनुभाग**

- [PPTX में चार्ट आकार बदलने के लिए कार्यशील समाधान](/slides/hi/python-java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट पूर्वावलोकन समस्या](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **अक्सर पूछे जाने वाले प्रश्न**

**Excel चार्ट बनाने और एंबेड करने के लिए कौन सी लाइब्रेरीज़ उपयोग की जाती हैं?**

Aspose.Cells for Python via Java Excel चार्ट बनाता है, और Aspose.Slides for Python via Java इसे PowerPoint स्लाइड में OLE ऑब्जेक्ट के रूप में एंबेड करता है।

**उपयोगकर्ता एंबेड किए गए Excel चार्ट को कैसे संपादित कर सकते हैं?**

उपयोगकर्ता OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करके चार्ट को सक्रिय कर सकते हैं और इसे किसी अन्य OLE ऑब्जेक्ट की तरह संपादित कर सकते हैं।

**डिफ़ॉल्ट OLE ऑब्जेक्ट पूर्वावलोकन को कैसे बदलते हैं?**

उदाहरण Aspose.Cells से Excel चार्ट की छवि प्राप्त करता है और इसे "EMBEDDED OLE OBJECT" छवि को बदलने के लिए उपयोग करता है।