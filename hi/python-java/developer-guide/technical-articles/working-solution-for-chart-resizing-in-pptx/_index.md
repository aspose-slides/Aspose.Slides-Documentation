---
title: PPTX में चार्ट आकार बदलने के समाधान के लिए कार्यशील विधि
type: docs
weight: 40
url: /hi/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करना
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके एम्बेडेड Excel OLE ऑब्जेक्ट्स के साथ PPTX में अप्रत्याशित चार्ट आकार बदलने को ठीक करें। आकार को स्थिर रखने के लिए दो विधियों और कोड सीखें।"
---
## **पृष्ठभूमि**

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में सम्मिलित Excel चार्ट पहली सक्रियता के बाद अनिश्चित अनुपात में पुनः आकारित हो जाते हैं। यह व्यवहार चार्ट की सक्रियता से पहले और बाद की स्थिति में प्रस्तुति में एक स्पष्ट दृश्य अंतर पैदा करता है। Aspose टीम ने इस मुद्दे की विस्तृत जाँच की है और समाधान पाया है। यह लेख समस्या के कारणों और संबंधित सुधार का वर्णन करता है।

हमने [पिछला लेख](/slides/hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में बताया कि Aspose.Cells for Python via Java का उपयोग करके Excel चार्ट कैसे बनाएं और Aspose.Slides for Python via Java का उपयोग करके इसे PowerPoint प्रस्तुति में कैसे एम्बेड करें। [ऑब्जेक्ट पूर्वावलोकन समस्या](/slides/hi/python-java/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए, हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप चार्ट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। अंतिम उपयोगकर्ता अंतर्निहित Excel वर्कबुक में इच्छित कोई भी परिवर्तन कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके संबंधित स्लाइड पर वापस जा सकते हैं। उपयोगकर्ता जब स्लाइड पर वापस आता है तो OLE ऑब्जेक्ट फ्रेम का आकार बदल जाता है, और पुनः आकार कारक दोनों OLE ऑब्जेक्ट फ्रेम और सम्मिलित Excel वर्कबुक के मूल आकारों पर निर्भर करता है।

## **पुनः आकार का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने की कोशिश करता है। OLE ऑब्जेक्ट फ्रेम के पास भी अपना आकार होता है। माइक्रोसॉफ्ट के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार के बारे में बातचीत करते हैं और एम्बेडिंग प्रक्रिया के हिस्से के रूप में उचित अनुपात बनाए रखते हैं। Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार या स्थिति के बीच अंतर के आधार पर पुनः आकार की स्थिति उत्पन्न होती है।

## **कार्यशील समाधान**

Aspose.Slides for Python via Java का उपयोग करके PowerPoint प्रस्तुतियों को बनाने के दो संभावित परिदृश्य हैं।

**Scenario 1:** मौजूदा टेम्पलेट के आधार पर प्रस्तुति बनाना।

**Scenario 2:** शून्य से प्रस्तुति बनाना।

यहाँ प्रदान किया गया समाधान दोनों परिदृश्यों पर लागू होता है। सभी समाधान दृष्टिकोणों का आधार समान है: **एम्बेडेड OLE ऑब्जेक्ट का विंडो आकार PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार से मेल खाना चाहिए**। अब हम इस समाधान के दो दृष्टिकोणों पर चर्चा करेंगे।

## **पहला दृष्टिकोण**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक के विंडो आकार को कैसे सेट करें ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार से मेल खाए।

**Scenario 1**

मान लें कि हमने एक टेम्पलेट परिभाषित किया है और उसके आधार पर प्रस्तुतियों को बनाना चाहते हैं। टेम्पलेट में इंडेक्स 2 पर एक शेप है जहाँ हम एम्बेडेड Excel वर्कबुक वाला OLE फ्रेम रखना चाहते हैं। इस परिदृश्य में OLE ऑब्जेक्ट फ्रेम का आकार पहले से निर्धारित है—यह टेम्पलेट में इंडेक्स 2 पर शेप के आकार से मेल खाता है। हमें केवल वर्कबुक का विंडो आकार उसी शेप के आकार के बराबर सेट करना है। नीचे दिया गया कोड स्निपेट इस उद्देश्य की पूर्ति करता है:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# चार्ट वाले Excel वर्कबुक को लोड करें।
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # वर्कबुक विंडो आकार को इंच में सेट करें (PowerPoint प्रत्येक इंच के लिए 72 पॉइंट उपयोग करता है)।
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

मान लें हम शून्य से एक प्रस्तुति बनाते हैं और किसी भी आकार के OLE ऑब्जेक्ट फ्रेम में एम्बेडेड Excel वर्कबुक शामिल करना चाहते हैं। नीचे दिए गए कोड स्निपेट में, हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँचा और 9.5 इंच चौड़ा OLE ऑब्जेक्ट फ्रेम बनाते हैं। फिर हम Excel वर्कबुक विंडो को उसी आकार—4 इंच ऊँचा और 9.5 इंच चौड़ा—पर सेट करते हैं।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpide.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# चार्ट वाले Excel वर्कबुक को लोड करें।
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 इंच (4 * 72)।
    desired_width = 684  # 9.5 इंच (9.5 * 72)।

    # विंडो के साथ चार्ट का आकार निर्धारित करें।
    chart.setSizeWithWindow(True)

    # वर्कबुक विंडो आकार को इंच में सेट करें (PowerPoint प्रत्येक इंच के लिए 72 पॉइंट उपयोग करता है)।
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **दूसरा दृष्टिकोण**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक में चार्ट का आकार कैसे सेट करें ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार से मेल खाए। यह दृष्टिकोण तब उपयोगी है जब चार्ट का आकार शुरू में ज्ञात हो और आगे नहीं बदलेगा।

**Scenario 1**

मान लें कि हमने एक टेम्पलेट परिभाषित किया है और उसके आधार पर प्रस्तुतियों को बनाना चाहते हैं। टेम्पलेट में इंडेक्स 2 पर एक शेप है जहाँ हम एम्बेडेड Excel वर्कबुक वाला OLE फ्रेम रखना चाहते हैं। इस परिदृश्य में OLE फ्रेम का आकार पहले से निर्धारित है—यह टेम्पलेट में इंडेक्स 2 पर शेप के आकार से मेल खाता है। हमें केवल वर्कबुक में चार्ट का आकार उसी शेप के आकार के बराबर सेट करना है। नीचे दिया गया कोड स्निपेट इस उद्देश्य की पूर्ति करता है:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# चार्ट वाला Excel वर्कबुक लोड करें।
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # विंडो के बिना चार्ट का आकार निर्धारित करें।
    chart.setSizeWithWindow(False)

    # चार्ट का आकार पिक्सेल में सेट करें (Excel प्रत्येक इंच के लिए 96 पिक्सेल उपयोग करता है)।
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # चार्ट का प्रिंट आकार निर्धारित करें।
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

मान लें हम शून्य से एक प्रस्तुति बनाते हैं और किसी भी आकार के OLE ऑब्जेक्ट फ्रेम में एम्बेडेड Excel वर्कबुक शामिल करना चाहते हैं। नीचे दिए गए कोड स्निपेट में, हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँचा और 9.5 इंच चौड़ा OLE ऑब्जेक्ट फ्रेम बनाते हैं। हम साथ ही चार्ट का आकार भी उसी आयाम—ऊँचाई 4 इंच और चौड़ाई 9.5 इंच—पर सेट करते हैं।

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# चार्ट वाले Excel वर्कबुक को लोड करें।
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 इंच (4 * 72).
    desired_width = 684  # 9.5 इंच (9.5 * 72).

    # विंडो के बिना चार्ट का आकार निर्धारित करें।
    chart.setSizeWithWindow(False)

    # चार्ट का आकार पिक्सेल में सेट करें (Excel प्रति इंच 96 पिक्सेल उपयोग करता है)।
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **निष्कर्ष**

चार्ट पुनः आकार समस्या को ठीक करने के दो दृष्टिकोण हैं। दृष्टिकोण का चयन आवश्यकताओं और उपयोग के केस पर निर्भर करता है। दोनों दृष्टिकोण समान रूप से काम करते हैं, चाहे प्रस्तुतियाँ टेम्पलेट से बनायीँ जाएँ या शून्य से। इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

## **FAQ**

**मेरे एम्बेडेड Excel चार्ट का आकार PowerPoint में सक्रिय करने के बाद क्यों बदल जाता है?**

यह इसलिए होता है क्योंकि Excel पहली सक्रियता पर मूल विंडो आकार को पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। PowerPoint और Excel आकार पर बातचीत करके अनुपात बनाए रखते हैं, जिससे पुनः आकार हो सकता है।

**क्या इस पुनः आकार समस्या को पूरी तरह रोका जा सकता है?**

हां। एम्बेड करने से पहले Excel वर्कबुक विंडो आकार या चार्ट आकार को OLE ऑब्जेक्ट फ्रेम के आकार से मिलाकर आप चार्ट आकार को स्थिर रख सकते हैं।

**मुझे कौन सा दृष्टिकोण अपनाना चाहिए, विंडो आकार सेट करना या चार्ट आकार सेट करना?**

यदि आप वर्कबुक के अनुपात को बनाए रखना चाहते हैं और बाद में संभवतः रीसाइज़ करना चाहते हैं तो **दृष्टिकोण 1 (विंडो आकार)** उपयोग करें।  
यदि चार्ट के आयाम स्थिर हैं और एम्बेडिंग के बाद नहीं बदलेंगे तो **दृष्टिकोण 2 (चार्ट आकार)** उपयोग करें।

**क्या ये विधियाँ टेम्पलेट-आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों में काम करती हैं?**

हां। दोनों दृष्टिकोण टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों में समान रूप से काम करते हैं।

**OLE ऑब्जेक्ट फ्रेम के आकार की कोई सीमा है क्या?**

नहीं। आप OLE फ्रेम को किसी भी आकार में सेट कर सकते हैं, बशर्ते वह वर्कबुक या चार्ट आकार के अनुसार उचित रूप से स्केल हो।

**क्या मैं इन विधियों को अन्य स्प्रेडशीट प्रोग्राम में बनाए गए चार्ट पर उपयोग कर सकता हूँ?**

उदाहरण Excel चार्ट के लिए Aspose.Cells का उपयोग करके बनाए गए हैं, लेकिन सिद्धांत उन अन्य OLE‑संगत स्प्रेडशीट प्रोग्रामों पर भी लागू होते हैं जो समान आकार विकल्पों को समर्थन देते हैं।

## **संयुक्त अनुभाग**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)