---
title: Python का उपयोग करके प्रस्तुतियों में OLE प्रबंधित करें
linktitle: OLE प्रबंधित करें
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
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint और OpenDocument फ़ाइलों में OLE ऑब्जेक्ट प्रबंधन को अनुकूलित करें। OLE सामग्री को सहजता से एम्बेड, अपडेट और निर्यात करें।"
---
## **परिचय**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) माइक्रोसॉफ्ट तकनीक है जो डेटा और ऑब्जेक्ट्स को एक एप्लिकेशन में बनाई गई चीज़ों को लिंकिंग या एम्बेडिंग के ज़रिए दूसरे एप्लिकेशन में रखने की अनुमति देती है।

{{% /alert %}}

MS Excel में बनाई गई एक चार्ट को विचार करें। फिर वह चार्ट PowerPoint स्लाइड के अंदर रखा जाता है। वह Excel चार्ट एक OLE ऑब्जेक्ट माना जाता है।

- एक OLE ऑब्जेक्ट आइकन के रूप में दिखाई दे सकता है। इस स्थिति में, जब आप आइकन पर डबल‑क्लिक करते हैं, तो चार्ट अपनी सम्बद्ध एप्लिकेशन (Excel) में खुल जाता है, या आपसे ऑब्जेक्ट को खोलने या संपादित करने के लिए एप्लिकेशन चुनने को कहा जाता है।
- एक OLE ऑब्जेक्ट अपने वास्तविक सामग्री, जैसे कि चार्ट की सामग्री, भी प्रदर्शित कर सकता है। इस स्थिति में, चार्ट PowerPoint में सक्रिय हो जाता है, चार्ट इंटरफ़ेस लोड होता है, और आप PowerPoint के भीतर चार्ट डेटा को संशोधित कर सकते हैं।

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) आपको OLE ऑब्जेक्ट फ़्रेम ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)) के रूप में स्लाइड में OLE ऑब्जेक्ट डालने की अनुमति देता है।

## **स्लाइड्स में OLE ऑब्जेक्ट फ़्रेम जोड़ें**

मान लीजिए आप पहले से ही Microsoft Excel में एक चार्ट बना चुके हैं और Aspose.Slides for Python via Java का उपयोग करके उसे एक OLE ऑब्जेक्ट फ़्रेम के रूप में स्लाइड में एम्बेड करना चाहते हैं, तो आप इसे इस प्रकार कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स द्वारा एक स्लाइड का रेफ़रेंस प्राप्त करें।
1. Excel फ़ाइल को बाइट एरे के रूप में पढ़ें।
1. स्लाइड में बाइट एरे और OLE ऑब्जेक्ट संबंधी अन्य जानकारी के साथ [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) जोड़ें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में, हमने Excel फ़ाइल से एक चार्ट को Aspose.Slides for Python via Java का उपयोग करके एक OLE ऑब्जेक्ट फ़्रेम के रूप में स्लाइड में जोड़ा।  
**नोट** कि [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) कंस्ट्रक्टर दूसरा पैरामीटर के रूप में एम्बेडेबल ऑब्जेक्ट एक्सटेंशन लेता है। यह एक्सटेंशन PowerPoint को फ़ाइल प्रकार को सही ढंग से व्याख्या करने और इस OLE ऑब्जेक्ट को खोलने के लिए सही एप्लिकेशन चुनने की अनुमति देता है।

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

    # स्लाइड में OLE ऑब्जेक्ट फ़्रेम जोड़ें।
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **लिंक्ड OLE ऑब्जेक्ट फ़्रेम जोड़ें**

Aspose.Slides for Python via Java आपको एम्बेडेड डेटा की बजाय फ़ाइल के लिंक के साथ एक [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) जोड़ने की अनुमति देता है।

यह Python कोड आपको दिखाता है कि कैसे एक लिंक्ड Excel फ़ाइल के साथ [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) को स्लाइड में जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # लिंक्ड Excel फ़ाइल के साथ OLE ऑब्जेक्ट फ़्रेम जोड़ें।
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE ऑब्जेक्ट फ़्रेम तक पहुँचें**

यदि किसी स्लाइड में OLE ऑब्जेक्ट पहले से एम्बेडेड है, तो आप इसे इस तरह आसानी से खोज या पहुँच सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट के साथ एक प्रेज़ेंटेशन लोड करें।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) आकार तक पहुँचें।  
   हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें पहली स्लाइड पर केवल एक शेप है। फिर हमने जाँच किया कि ऑब्जेक्ट एक [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) है। यही वह इच्छित OLE ऑब्जेक्ट फ़्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ़्रेम तक पहुँच लेने पर, आप उस पर कोई भी संचालन कर सकते हैं।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ़्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) और उसकी फ़ाइल डेटा तक पहुँच बनाई गई है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

### **लिंक्ड OLE ऑब्जेक्ट फ़्रेम गुणों तक पहुँचें**

Aspose.Slides आपको लिंक्ड OLE ऑब्जेक्ट फ़्रेम गुणों तक पहुँचने की अनुमति देता है।

यह Python कोड दिखाता है कि कैसे यह जांचें कि OLE ऑब्जेक्ट लिंक्ड है और फिर लिंक्ड फ़ाइल का पथ प्राप्त करें:

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

        # जांचें कि OLE ऑब्जेक्ट लिंक्ड है या नहीं।
        if ole_frame.isObjectLink():
            # लिंक्ड फ़ाइल का पूर्ण पथ प्रिंट करें।
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # यदि मौजूद हो तो लिंक्ड फ़ाइल का रिलेटिव पथ प्रिंट करें।
            # केवल PPT प्रेज़ेंटेशन में रिलेटिव पाथ हो सकता है।
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE ऑब्जेक्ट डेटा बदलें**

{{% alert color="info" title="Note" %}}

इस सेक्शन में, नीचे दिया गया कोड उदाहरण [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/) का उपयोग करता है।

{{% /alert %}}

यदि OLE ऑब्जेक्ट पहले से स्लाइड में एम्बेडेड है, तो आप इस तरह उस ऑब्जेक्ट तक आसानी से पहुँच सकते हैं और उसके डेटा को संशोधित कर सकते हैं:

1. एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाकर एम्बेडेड OLE ऑब्जेक्ट के साथ एक प्रेज़ेंटेशन लोड करें।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. OLE ऑब्जेक्ट फ़्रेम आकार तक पहुँचें।  
   हमारे उदाहरण में, हमने पहले बनाए गए PPTX का उपयोग किया जिसमें एक शेप पहली स्लाइड पर है। फिर हमने जाँच किया कि ऑब्जेक्ट एक [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) है। यही वह इच्छित OLE ऑब्जेक्ट फ़्रेम था जिसे एक्सेस किया जाना था।
4. एक बार OLE ऑब्जेक्ट फ़्रेम तक पहुँच लेने पर, आप उस पर कोई भी संचालन कर सकते हैं।
5. एक [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) ऑब्जेक्ट बनाएं और OLE डेटा तक पहुँचें।
6. इच्छित [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) तक पहुँचें और डेटा को संशोधित करें।
7. अपडेटेड [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) को एक स्ट्रिम में सहेजें।
8. स्ट्रिम से OLE ऑब्जेक्ट डेटा बदलें।

नीचे के उदाहरण में, एक OLE ऑब्जेक्ट फ़्रेम (स्लाइड में एम्बेडेड Excel चार्ट ऑब्जेक्ट) तक पहुँच बनाई गई है, और उसके फ़ाइल डेटा को चार्ट डेटा को अपडेट करने के लिए संशोधित किया गया है।

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

        # OLE ऑब्जेक्ट डेटा को एक Workbook ऑब्जेक्ट के रूप में पढ़ें।
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # workbook डेटा को संशोधित करें।
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # OLE फ़्रेम ऑब्जेक्ट डेटा बदलें।
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड्स में अन्य फ़ाइल प्रकार एम्बेड करें**

Excel चार्ट के अलावा, Aspose.Slides for Python via Java आपको स्लाइड्स में अन्य प्रकार की फ़ाइलें एम्बेड करने की अनुमति देता है। उदाहरण के लिए, आप HTML, PDF, और ZIP फ़ाइलों को ऑब्जेक्ट के रूप में डाल सकते हैं। जब उपयोगकर्ता डालित ऑब्जेक्ट पर डबल‑क्लिक करता है, तो वह स्वचालित रूप से संबंधित प्रोग्राम में खुल जाता है, या उपयोगकर्ता को इसे खोलने के लिए उपयुक्त प्रोग्राम चुनने का संकेत दिया जाता है।

यह Python कोड आपको दिखाता है कि कैसे HTML और ZIP को स्लाइड में एम्बेड किया जाए:

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

प्रेज़ेंटेशन के साथ काम करते समय, आपको पुराने OLE ऑब्जेक्ट्स को नए से बदलना पड़ सकता है या असमर्थित OLE ऑब्जेक्ट को समर्थित से बदलना पड़ सकता है। Aspose.Slides for Python via Java आपको एम्बेडेड ऑब्जेक्ट के लिए फ़ाइल प्रकार सेट करने की अनुमति देता है, जिससे आप OLE फ़्रेम डेटा या उसके एक्सटेंशन को अपडेट कर सकते हैं।

यह Python कोड आपको दिखाता है कि एम्बेडेड OLE ऑब्जेक्ट के फ़ाइल प्रकार को `zip` कैसे सेट किया जाए:

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

एक OLE ऑब्जेक्ट एम्बेड होने के बाद, एक आइकन इमेज से बनी पूर्वावलोकन स्वतः ही जोड़ी जाती है। यह पूर्वावलोकन वह है जो उपयोगकर्ता OLE ऑब्जेक्ट को एक्सेस या खोलने से पहले देखते हैं। यदि आप पूर्वावलोकन में विशिष्ट इमेज और टेक्स्ट को तत्वों के रूप में उपयोग करना चाहते हैं, तो आप Aspose.Slides for Python via Java का उपयोग करके आइकन इमेज और शीर्षक सेट कर सकते हैं।

यह Python कोड आपको दिखाता है कि एम्बेडेड ऑब्जेक्ट के लिए आइकन इमेज और शीर्षक कैसे सेट किया जाए:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # प्रेजेंटेशन संसाधनों में एक छवि जोड़ें।
    image_data = Path("image.png").read_bytes()
    image_data = jpime.JArray(jpime.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # OLE पूर्वावलोकन के लिए शीर्षक और छवि सेट करें।
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE ऑब्जेक्ट फ़्रेम को रिसाइज़ और रीपोज़िशन से रोकें**

जब आप एक लिंक्ड OLE ऑब्जेक्ट को प्रेज़ेंटेशन स्लाइड में जोड़ते हैं, और PowerPoint में प्रेज़ेंटेशन खोलते हैं, तो आपको लिंक अपडेट करने का संदेश मिल सकता है। "Update Links" बटन पर क्लिक करने से OLE ऑब्जेक्ट फ़्रेम का आकार और स्थिति बदल सकती है क्योंकि PowerPoint लिंक्ड OLE ऑब्जेक्ट से डेटा अपडेट करता है और ऑब्जेक्ट पूर्वावलोकन को रीफ़्रेश करता है। PowerPoint को ऑब्जेक्ट डेटा अपडेट करने के लिए प्रॉम्प्ट करने से रोकने हेतु, [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) क्लास के [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) मेथड को `False` के साथ कॉल करें:

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

Aspose.Slides for Python via Java आपको इस प्रकार स्लाइड्स में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में निकालने की अनुमति देता है:

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं जिसमें आप निकालने वाले OLE ऑब्जेक्ट्स हों।
2. प्रेज़ेंटेशन में सभी शेप्स को लूप करके [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) शेप्स तक पहुँचें।
3. OLE ऑब्जेक्ट फ़्रेम्स से एम्बेडेड फ़ाइलों का डेटा एक्सेस करें और इसे डिस्क पर लिखें।

यह Python कोड आपको दिखाता है कि स्लाइड में एम्बेडेड फ़ाइलों को OLE ऑब्जेक्ट्स के रूप में कैसे निकालें:

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

**क्या OLE सामग्री को PDF/चित्रों में निर्यात करते समय रेंडर किया जाएगा?**

स्लाइड पर जो दिखता है वह रेंडर किया जाता है—आइकन/प्रतिस्थापन चित्र (पहले का पूर्वावलोकन)। "लाइव" OLE सामग्री रेंडरिंग के दौरान निष्पादित नहीं होती। यदि आवश्यक हो, तो निर्यात किए गए PDF में अपेक्षित दिखावट सुनिश्चित करने के लिए अपना अपना पूर्वावलोकन चित्र सेट करें।

एम्बेडेड फ़ाइल को PDF अटैचमेंट के रूप में भी संरक्षित करने के लिए, [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) को `True` के साथ कॉल करें। यह विकल्प डिफ़ॉल्ट रूप से निष्क्रिय है। एक उदाहरण और अटैचमेंट जांचने के निर्देशों के लिए, देखें [Preserve Embedded OLE Files as PDF Attachments](/slides/hi/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**मैं स्लाइड पर OLE ऑब्जेक्ट को कैसे लॉक कर सकता हूँ ताकि उपयोगकर्ता इसे PowerPoint में स्थानांतरित/संपादित न कर सकें?**

शेप को लॉक करें: Aspose.Slides [shape-level locks](/slides/hi/python-java/applying-protection-to-presentation/) प्रदान करता है। यह एन्क्रिप्शन नहीं है, लेकिन यह आकस्मिक संपादन और स्थानांतरित होने से प्रभावी रूप से रोकता है।

**जब मैं प्रेज़ेंटेशन खोलता हूँ तो लिंक्ड Excel ऑब्जेक्ट "जंप" क्यों करता है या आकार बदलता है?**

PowerPoint लिंक्ड OLE का पूर्वावलोकन रीफ़्रेश कर सकता है। स्थिर दिखावट के लिए, [Working Solution for Worksheet Resizing](/slides/hi/python-java/working-solution-for-worksheet-resizing/) के अभ्यासों का पालन करें—या तो फ्रेम को रेंज के अनुसार फिट करें, या रेंज को एक स्थिर फ्रेम में स्केल करें और उपयुक्त प्रतिस्थापन चित्र सेट करें।

**क्या लिंक्ड OLE ऑब्जेक्ट्स के रिलेटिव पाथ PPTX फ़ॉर्मेट में संरक्षित रहेंगे?**

PPTX में, "relative path" जानकारी उपलब्ध नहीं होती—केवल पूर्ण पाथ। रिलेटिव पाथ पुराने PPT फ़ॉर्मेट में पाए जाते हैं। पोर्टेबिलिटी के लिए, विश्वसनीय पूर्ण पाथ/एक्सेसिबल URI या एम्बेडिंग को प्राथमिकता दें।