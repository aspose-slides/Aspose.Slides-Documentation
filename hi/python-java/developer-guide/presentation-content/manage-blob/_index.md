---
title: Python के माध्यम से Java में प्रस्तुति BLOB को प्रभावी मेमोरी उपयोग के लिए प्रबंधित करें
linktitle: BLOB प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-blob/
keywords:
- बड़ा ऑब्जेक्ट
- बड़ा आइटम
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी घटाएँ
- मेमोरी उपभोग
- बड़ी प्रस्तुति
- अस्थायी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के लिए Aspose.Slides में BLOB डेटा को Java के माध्यम से प्रबंधित करके PowerPoint और OpenDocument फ़ाइल संचालन को सरल बनाकर प्रभावी प्रस्तुति संभाल सुनिश्चित करें।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों में बड़े बाइनरी डेटा को संभालने के लिए BLOB-आधारित प्रक्रिया प्रदान करता है जिससे बड़ी छवियों, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करते समय मेमोरी उपयोग कम करने में मदद मिलती है।

यह लेख दर्शाता है कि BLOB-आधारित प्रोसेसिंग का उपयोग करके प्रस्तुति में बड़ी मीडिया कैसे जोड़ी जाए, प्रस्तुति से बड़ी मीडिया कैसे निर्यात की जाए, और बड़ी प्रस्तुतियों को अधिक कुशलता से कैसे लोड किया जाए। यह यह भी बताता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें संग्रहित करने के लिए फोल्डर को कैसे बदलें।

## **BLOB के बारे में**

एक **BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़, या मीडिया) होता है जिसे बाइनरी स्वरूप में सहेजा जाता है।

Aspose.Slides for Python via Java आपको BLOB का उपयोग करके ऑब्जेक्ट्स को इस प्रकार संभालने की सुविधा देता है जिससे बड़े फ़ाइलों के साथ काम करने पर मेमोरी उपयोग कम हो जाता है।

{{% alert color="info" title="ध्यान दें" %}}
स्ट्रीम्स के साथ इंटरैक्ट करते समय कुछ सीमाओं को दूर करने के लिए Aspose.Slides स्ट्रीम की सामग्री को कॉपी कर सकता है। एक बड़े प्रस्तुति को उसके स्ट्रीम के माध्यम से लोड करने पर प्रस्तुति की सामग्री कॉपी हो जाती है और लोडिंग धीमी हो जाती है। इसलिए, जब आप बड़े प्रस्तुति को लोड करना चाहते हैं, तो हम दृढ़ता से अनुशंसा करते हैं कि आप प्रस्तुति फ़ाइल पथ का उपयोग करें, न कि उसका स्ट्रीम।
{{% /alert %}}

## **BLOBs का उपयोग करके मेमोरी उपयोग कम करें**

### **BLOBs का उपयोग करके प्रस्तुति में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/python-java/) for Python via Java आपको बड़े फ़ाइलों (इस मामले में, एक बड़ी वीडियो फ़ाइल) को BLOB प्रक्रिया के माध्यम से जोड़ने की अनुमति देता है जिससे मेमोरी उपयोग कम हो जाता है।

यह Python कोड आपको दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़ी वीडियो फ़ाइल को प्रस्तुति में कैसे जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# एक नई प्रस्तुति बनाएँ जिसमें वीडियो जोड़ा जाएगा।
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # स्ट्रीम को लॉक रखें क्योंकि हम वीडियो फ़ाइल तक पहुँचने का इरादा नहीं रखते।
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # प्रस्तुति को सहेजें जबकि मेमोरी उपभोग को कम रखें।
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **BLOBs का उपयोग करके प्रस्तुति से बड़ी फ़ाइल निर्यात करें**
Aspose.Slides for Python via Java आपको BLOB प्रक्रिया के माध्यम से बड़ी फ़ाइलें (इस मामले में, एक ऑडियो या वीडियो फ़ाइल) प्रस्तुतियों से निर्यात करने की सुविधा देता है। उदाहरण के लिए, आपको प्रस्तुति से बड़ी मीडिया फ़ाइल निकालनी हो सकती है लेकिन फ़ाइल को अपने कंप्यूटर की मेमोरी में लोड नहीं करना चाहते। BLOB प्रक्रिया के माध्यम से फ़ाइल निर्यात करने से मेमोरी उपयोग कम रहता है।

यह Python कोड ऊपर वर्णित प्रक्रिया को प्रदर्शित करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# स्रोत फ़ाइल को मेमोरी में लोड करने के बजाय लॉक करें।
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # मेमोरी उपभोग को कम रखने के लिए वीडियो डेटा को बफ़र के माध्यम से ट्रांसफ़र करें।
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # पूरे वीडियो को बाइट ऐरे में लोड करने के बजाय स्ट्रीम का उपयोग करें।
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # यदि आवश्यक हो, तो ऑडियो फ़ाइलों पर भी वही कदम लागू करें।
finally:
    presentation.dispose()
```

### **एक छवि को BLOB के रूप में प्रस्तुति में जोड़ें**
[ImageCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/) क्लास की विधियों का उपयोग करके आप एक बड़ी छवि को स्ट्रीम के रूप में जोड़ सकते हैं ताकि उसे BLOB माना जाए।

यह Python कोड आपको दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़ी छवि को कैसे जोड़ें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# एक नई प्रस्तुति बनाएँ जिसमें छवि जोड़ी जाएगी।
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # स्ट्रीम को लॉक रखें क्योंकि हम छवि फ़ाइल तक पहुँचने का इरादा नहीं रखते।
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # प्रस्तुति को सहेजें जबकि मेमोरी उपभोग को कम रखें।
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **मेमोरी और बड़ी प्रस्तुतियाँ**

आमतौर पर, एक बड़ी प्रस्तुति को लोड करने के लिए कंप्यूटर को बड़ी अस्थायी मेमोरी चाहिए होती है। सभी प्रस्तुति की सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड हुई थी) उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB वीडियो फ़ाइल शामिल है। इस प्रस्तुति को लोड करने की मानक विधि नीचे दिए गए Python कोड में दर्शाई गई है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

लेकिन यह विधि लगभग 1.6 GB अस्थायी मेमोरी उपयोग करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB हैंडलिंग का उपयोग करके आप कम मेमोरी के साथ बड़ी प्रस्तुति लोड कर सकते हैं। यह Python कोड दर्शाता है कि BLOB हैंडलिंग के माध्यम से बड़ी प्रस्तुति फ़ाइल (large.pptx) को कैसे लोड करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **अस्थायी फ़ाइलों के लिए फ़ोल्डर बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, तो आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइलों के फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अन्य फ़ोल्डर में रखी जाएँ, तो आप [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) का उपयोग करके स्टोरेज सेटिंग्स बदल सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="ध्यान दें" %}}
जब आप [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) का उपयोग करते हैं, तो Aspose.Slides अस्थायी फ़ाइलों को संग्रहीत करने के लिए फ़ोल्डर स्वचालित रूप से नहीं बनाता है। आपको फ़ोल्डर मैन्युअल रूप से बनाना होगा।
{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति ऑब्जेक्ट्स को डिस्पोज़ करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को ठीक से डिस्पोज़ किया गया है ताकि वह जिस मेमोरी का उपयोग कर रहा था वह मुक्त हो सके। प्रस्तुति के उपयोग को समाप्त करने के बाद अनमैनेज्ड रिसोर्सेस को मुक्त करने के लिए [Presentation.dispose](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#dispose) को कॉल करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...प्रस्तुति को प्रोसेस करें...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # संसाधनों को स्पष्ट रूप से रिलीज़ करें।
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB के रूप में माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**

छवियों, ऑडियो और वीडियो जैसी बड़ी बाइनरी वस्तुएँ BLOB के रूप में मानी जाती हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सेव करते समय BLOB हैंडलिंग में शामिल होती है। इन वस्तुओं को BLOB नीतियों द्वारा नियंत्रित किया जाता है जो मेमोरी उपयोग और आवश्यकता पड़ने पर अस्थायी फ़ाइलों में स्पिल को प्रबंधित करती हैं।

**प्रस्तुति लोड करते समय BLOB हैंडलिंग नियमों को कहाँ कॉन्फ़िगर करें?**

[LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) को [BlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/) के साथ उपयोग करें। यहाँ आप BLOB के लिए इन‑मेमोरी सीमा सेट कर सकते हैं, अस्थायी फ़ाइलों को अनुमति या निषेध कर सकते हैं, अस्थायी फ़ाइलों के रूट पाथ को चुन सकते हैं, और स्रोत लॉकिंग व्यवहार को चुन सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करें?**

हाँ। BLOB को मेमोरी में रखना गति को अधिकतम करता है लेकिन RAM उपयोग बढ़ाता है; मेमोरी सीमा को कम करने से अधिक कार्य अस्थायी फ़ाइलों पर शिफ्ट हो जाता है, जिससे RAM कम होती है लेकिन अतिरिक्त I/O का बोझ बढ़ता है। उचित संतुलन पाने के लिए आप [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) मेथड का उपयोग कर सकते हैं।

**क्या BLOB विकल्पों से अत्यधिक बड़ी प्रस्तुतियों (जैसे कई गीगाबाइट) खोलते समय मदद मिलती है?**

हाँ। [BlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/) ऐसे परिदृश्यों के लिए बनाए गए हैं: अस्थायी फ़ाइलें सक्षम करना और स्रोत लॉकिंग का उपयोग करना पीक RAM उपयोग को काफी घटा सकता है और बहुत बड़ी डेक्स के प्रोसेसिंग को स्थिर बना सकता है।

**क्या मैं स्ट्रीम्स से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**

हाँ। वही नियम स्ट्रीम्स पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को स्वामित्व और लॉक कर सकता है (चुने गए लॉकिंग मोड के अनुसार), और जब अनुमति दी जाए तो अस्थायी फ़ाइलें उपयोग की जाती हैं, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमेय रहता है।