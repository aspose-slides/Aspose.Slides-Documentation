---
title: Python का उपयोग करके प्रस्तुतियों में OLE प्रबंधन करें
linktitle: OLE प्रबंधन करें
type: docs
weight: 40
url: /hi/python-java/manage-ole/
keywords:
- OLE ऑब्जेक्ट
- ऑब्जेक्ट लिंकिंग और एम्बेडिंग
- OLE जोड़ें
- OLE एम्बेड करें
- ऑब्जेक्ट जोड़ें
- ऑब्जेक्ट एम्बेड करें
- फ़ाइल जोड़ें
- फ़ाइल एम्बेड करें
- लिंक्ड ऑब्जेक्ट
- लिंक्ड फ़ाइल
- OLE बदलें
- OLE आइकन
- OLE शीर्षक
- OLE निकालें
- ऑब्जेक्ट निकालें
- फ़ाइल निकालें
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) एक Microsoft तकनीक है जो एक एप्लिकेशन में बनाए गए डेटा और ऑब्जेक्ट को लिंक या एम्बेडिंग के माध्यम से दूसरे एप्लिकेशन में रखने की अनुमति देती है।

{{% /alert %}}

एक चार्ट को MS Excel में बनाया गया मान लीजिए। फिर यह चार्ट PowerPoint स्लाइड में रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है।

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपने संबंधित एप्लिकेशन (Excel) में खुल जाता है, या आपसे ऑब्जेक्ट को खोलने या संपादित करने के लिए एप्लिकेशन चुनने को कहा जाता है।
- एक OLE ऑब्जेक्ट अपना वास्तविक सामग्री, जैसे चार्ट की सामग्री, प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट के डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/hi/python-java/) आपको OLE ऑब्जेक्ट को OLE ऑब्जेक्ट फ्रेम ([OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/)) के रूप में स्लाइड में सम्मिलित करने की अनुमति देती है।

## **स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें**

मान लीजिए आप पहले से Microsoft Excel में एक चार्ट बना चुके हैं और उसे Aspose.Slides for Python via Java का उपयोग करके OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. Excel फ़ाइल को बाइट ऐरे के रूप में पढ़ें।  
4. स्लाइड में बाइट ऐरे और OLE ऑब्जेक्ट की अन्य जानकारी के साथ [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) जोड़ें।  
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में, हमने Aspose.Slides for Python via Java का उपयोग करके Excel फ़ाइल से एक चार्ट को OLE ऑब्जेक्ट फ्रेम के रूप में स्लाइड में जोड़ा है।  
**Note** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleembeddeddatainfo/) कंस्ट्रक्टर दूसरे पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से पहचानने और इस OLE ऑब्जेक्ट को खोलने के लिए उचित एप्लिकेशन चुनने में मदद करता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # OLE ऑब्जेक्ट के लिए डेटा तैयार करें।
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # स्लाइड में OLE ऑब्जेक्ट फ्रेम जोड़ें।
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **लिंकटेड OLE ऑब्जेक्ट फ्रेम जोड़ें**

Aspose.Slides for Python via Java आपको डेटा एम्बेड किए बिना केवल फ़ाइल लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) जोड़ने की अनुमति देती है।

यह Python कोड दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) को स्लाइड में जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # एक लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ्रेम जोड़ें।
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE ऑब्जेक्ट फ्रेम तक पहुँचें**

यदि किसी OLE ऑब्जेक्ट को पहले से ही स्लाइड में एम्बेड किया गया है, तो आप इसे इस प्रकार आसानी से खोज या पहुँच सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाला प्रस्तुति लोड करें।  
2. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।  
3. [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) शेप तक पहुँचें।  
   हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक शेप था। फिर हमने जांचा कि ऑब्जेक्ट एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) है। यही वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया जाना था।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (एक स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच प्राप्त की गई है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # एम्बेडेड फ़ाइल डेटा प्राप्त करें।
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # एम्बेडेड फ़ाइल का एक्सटेंशन प्राप्त करें।
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **लिंक्ड OLE ऑब्जेक्ट फ्रेम प्रॉपर्टीज़ एक्सेस करें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ्रेम की प्रॉपर्टीज़ एक्सेस करने की अनुमति देती है।

यह Python कोड दिखाता है कि कैसे जांचें कि कोई OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक किए गए फ़ाइल का पथ प्राप्त करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # जाँचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
        if ole_frame.isObjectLink():
            # लिंक्ड फ़ाइल का पूर्ण पाथ प्रिंट करें।
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पाथ प्रिंट करें।
            # केवल PPT प्रस्तुति में रिलेटिव पाथ हो सकता है।
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}

इस अनुभाग में नीचे दिया गया कोड उदाहरण [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) का उपयोग करता है।

{{% /alert %}}

यदि कोई OLE ऑब्जेक्ट पहले से ही स्लाइड में एम्बेड किया गया है, तो आप उस ऑब्जेक्ट को आसानी से एक्सेस कर उसके डेटा को इस प्रकार संशोधित कर सकते हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट वाला प्रस्तुति लोड करें।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. OLE ऑब्जेक्ट फ्रेम शेप तक पहुँचें।  
   हमारे उदाहरण में, हमने पहले बनाए गए PPTX जिसका पहले स्लाइड पर एक शेप है, का उपयोग किया। फिर हमने पुष्टि की कि ऑब्जेक्ट एक [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) है। यही वह वांछित OLE ऑब्जेक्ट फ्रेम था जिसे एक्सेस किया गया।  
4. एक बार OLE ऑब्जेक्ट फ्रेम एक्सेस हो जाने पर, आप उस पर कोई भी ऑपरेशन कर सकते हैं।  
5. [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ऑब्जेक्ट बनाकर OLE डेटा तक पहुँचें।  
6. वांछित [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) को एक्सेस करके डेटा संशोधित करें।  
7. अपडेटेड [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) को एक स्ट्रीम में सहेजें।  
8. स्ट्रीम से OLE ऑब्जेक्ट डेटा बदलें।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) को एक्सेस किया गया और उसकी फ़ाइल डेटा को बदलकर चार्ट डेटा को अपडेट किया गया है।

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # OLE ऑब्जेक्ट डेटा को Workbook ऑब्जेक्ट के रूप में पढ़ें।
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # वर्कबुक डेटा को संशोधित करें।
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE फ्रेम ऑब्जेक्ट डेटा को बदलें।
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for Python via Java आपको स्लाइड में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देती है। उदाहरण के तौर पर, आप HTML, PDF और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में सम्मिलित कर सकते हैं। जब उपयोगकर्ता सम्मिलित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो यह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने के लिए प्रेरित किया जाता है।

यह Python कोड दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड करें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए फ़ाइल प्रकार सेट करें**

प्रस्तुति के साथ काम करते समय, आपको पुरानी OLE ऑब्जेक्ट्स को नई ऑब्जेक्ट्स से बदलना या असमर्थित OLE ऑब्जेक्ट को समर्थित ऑब्जेक्ट से बदलना पड़ सकता है। Aspose.Slides for Python via Java आपको एम्बेडेड ऑब्जेक्ट के फ़ाइल प्रकार को सेट करने की सुविधा देती है, जिससे आप OLE फ्रेम डेटा या उसकी एक्सटेंशन को अपडेट कर सकते हैं।

यह Python कोड दिखाता है कि कैसे एम्बेडेड OLE ऑब्जेक्ट का फ़ाइल प्रकार `zip` सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # फ़ाइल प्रकार को ZIP में बदलें।
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एम्बेडेड ऑब्जेक्ट्स के लिए आइकन इमेज और शीर्षक सेट करें**

एक OLE ऑब्जेक्ट को एम्बेड करने के बाद, एक प्रीव्यू जिसमें आइकन इमेज होती है, स्वचालित रूप से जोड़ी जाती है। यही वह प्रीव्यू है जो उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप प्रीव्यू में विशिष्ट इमेज और टेक्स्ट का उपयोग करना चाहते हैं, तो आप Aspose.Slides for Python via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह Python कोड दिखाता है कि कैसे एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक सेट करें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # प्रस्तुति संसाधनों में एक छवि जोड़ें।
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # OLE प्रीव्यू के लिए एक शीर्षक और छवि सेट करें।
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE ऑब्जेक्ट फ्रेम को रिसाइज़ और रीपोजिशन से रोकें**

जब आप किसी लिंक्ड OLE ऑब्जेक्ट को प्रस्तुति स्लाइड में जोड़ते हैं और PowerPoint में प्रस्तुति खोलते हैं, तो आपको लिंक अपडेट करने का संदेश दिख सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट प्रीव्यू को रिफ्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने हेतु, [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) क्लास की [setUpdateAutomatic](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) मेथड को `False` सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एम्बेडेड फ़ाइलें निकालें**

Aspose.Slides for Python via Java आपको स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलें इस प्रकार निकालने की अनुमति देती है:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।  
2. प्रेजेंटेशन में सभी शेप्स को लूप करके [OleObjectFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/oleobjectframe/) शेप्स तक पहुँचें।  
3. OLE ऑब्जेक्ट फ्रेम से एम्बेडेड फ़ाइलों का डेटा एक्सेस करके उसे डिस्क पर लिखें।

यह Python कोड दिखाता है कि कैसे स्लाइड में OLE ऑब्जेक्ट्स के रूप में एम्बेडेड फ़ाइलें निकाली जाएँ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**क्या OLE कंटेंट को PDF/छवियों में निर्यात करते समय रेंडर किया जाएगा?**

स्लाइड पर जो दिखता है वह रेंडर किया जाता है—आइकॉन/सब्स्टीट्यूट इमेज (प्रीव्यू)। "लाइव" OLE कंटेंट रेंडरिंग के दौरान निष्पादित नहीं होता। यदि आवश्यक हो, तो निर्यातित PDF में अपेक्षित रूप दिखाने के लिए अपना स्वयं का प्रीव्यू इमेज सेट करें।

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक करूं ताकि उपयोगकर्ता PowerPoint में उसे मूव/एडिट न कर सकें?**

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/python-java/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन अनजाने संपादन और मूवमेंट को प्रभावी रूप से रोकता है।

**जब मैं प्रस्तुति खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" करता है या आकार बदलता है, क्यों?**

PowerPoint लिंक्ड OLE का प्रीव्यू रिफ्रेश कर सकता है। स्थिर लुक के लिए, [Working Solution for Worksheet Resizing](/slides/hi/python-java/working-solution-for-worksheet-resizing/) प्रैक्टिसेज़ अपनाएँ—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को फिक्स्ड फ्रेम में स्केल करें और उपयुक्त सब्स्टीट्यूट इमेज सेट करें।

**क्या PPTX फ़ॉर्मेट में लिंक्ड OLE ऑब्जेक्ट्स के लिए रिलेटिव पाथ्स संरक्षित रहते हैं?**

PPTX में "relative path" जानकारी उपलब्ध नहीं है—केवल पूर्ण पाथ रहता है। रिलेटिव पाथ्स पुराने PPT फ़ॉर्मेट में ही मिलते हैं। पोर्टेबिलिटी के लिए विश्वसनीय एब्सोल्यूट पाथ/एक्सेसिबल URI या एम्बेडिंग का उपयोग करें।