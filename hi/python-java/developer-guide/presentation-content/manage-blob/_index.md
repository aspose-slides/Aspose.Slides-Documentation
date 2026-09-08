---
title: Python के माध्यम से Java में प्रस्तुति BLOBs को प्रबंधित करें प्रभावी मेमोरी उपयोग के लिए
linktitle: BLOB प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-blob/
keywords:
- बड़ा ऑब्जेक्ट
- बड़ी वस्तु
- बड़ी फ़ाइल
- BLOB जोड़ें
- BLOB निर्यात करें
- छवि को BLOB के रूप में जोड़ें
- मेमोरी घटाएँ
- मेमोरी खपत
- बड़ी प्रस्तुति
- अस्थायी फ़ाइल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के लिए Python के माध्यम से Java में BLOB डेटा का प्रबंधन करके PowerPoint और OpenDocument फ़ाइल संचालन को सुगम बनाएं और प्रभावी प्रस्तुति हैंडलिंग प्राप्त करें।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों में बड़े बाइनरी डेटा के लिए BLOB-आधारित हैंडलिंग प्रदान करता है ताकि बड़े चित्र, ऑडियो, वीडियो और प्रस्तुति फ़ाइलों के साथ काम करने पर मेमोरी की खपत को कम किया जा सके।

यह लेख दिखाता है कि BLOB-आधारित प्रोसेसिंग का उपयोग करके बड़ी मीडिया को प्रस्तुति में कैसे जोड़ा जाए, प्रस्तुति से बड़ी मीडिया को कैसे निर्यात किया जाए, और बड़ी प्रस्तुतियों को अधिक कुशलता से कैसे लोड किया जाए। यह यह भी समझाता है कि प्रोसेसिंग के दौरान अस्थायी फ़ाइलों का उपयोग कैसे किया जा सकता है और उन्हें संग्रहित करने वाले फ़ोल्डर को कैसे बदला जाए।

## **BLOB के बारे में**

**BLOB** (**Binary Large Object**) आमतौर पर एक बड़ा आइटम (फ़ोटो, प्रस्तुति, दस्तावेज़ या मीडिया) होता है जिसे बाइनरी फ़ॉर्मेट में सहेजा जाता है।

Aspose.Slides for Python via Java आपको बड़े फ़ाइलों के साथ काम करने पर मेमोरी की खपत को कम करने के लिए ऑब्जेक्ट्स के लिए BLOBs का उपयोग करने की अनुमति देता है।

{{% alert color="info" title="Note" %}}
स्ट्रीम्स के साथ इंटरैक्ट करते समय कुछ प्रतिबंधों को दूर करने के लिए Aspose.Slides स्ट्रीम की सामग्री की प्रति बनाता है। स्ट्रीम के माध्यम से बड़ी प्रस्तुति लोड करने पर प्रस्तुति की सामग्री की प्रतिलिपि बनती है और लोडिंग धीमी हो जाती है। इसलिए, जब आप बड़ी प्रस्तुति लोड करना चाहते हैं, तो हम दृढ़ता से सलह देते हैं कि आप प्रस्तुति फ़ाइल पाथ का उपयोग करें, न कि उसकी स्ट्रीम का।
{{% /alert %}}

## **BLOB का उपयोग करके मेमोरी खपत घटाएँ**

### **BLOB के माध्यम से प्रस्तुतियों में बड़ी फ़ाइल जोड़ें**

[Aspose.Slides](/slides/hi/python-java/) for Python via Java आपको BLOB प्रक्रिया के माध्यम से बड़ी फ़ाइलें (इस केस में बड़ी वीडियो फ़ाइल) जोड़ने की अनुमति देता है ताकि मेमोरी की ख़पत कम हो सके।

यह Python कोड आपको दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़ी वीडियो फ़ाइल को प्रस्तुति में कैसे जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# नई प्रस्तुति बनाएं जिसमें वीडियो जोड़ा जाएगा.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # स्ट्रीम को लॉक रखें क्योंकि हम वीडियो फ़ाइल को एक्सेस नहीं करने वाले हैं.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # प्रस्तुति को इस तरह सहेजें कि मेमोरी खपत कम रहे.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **प्रस्तुति से BLOB के माध्यम से बड़ी फ़ाइल निर्यात करें**
Aspose.Slides for Python via Java आपको BLOB प्रक्रिया के माध्यम से बड़ी फ़ाइलें (जैसे ऑडियो या वीडियो फ़ाइल) प्रस्तुतियों से निर्यात करने की अनुमति देता है। उदाहरण के लिए, आपको प्रस्तुति से बड़ी मीडिया फ़ाइल निकालनी पड़ सकती है, लेकिन आप नहीं चाहते कि फ़ाइल आपके कंप्यूटर की मेमोरी में लोड हो। BLOB प्रक्रिया के माध्यम से फ़ाइल निर्यात करके आप मेमोरी ख़पत को कम रख सकते हैं।

यह Python कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

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
    # मेमोरी खपत कम रखने के लिए बफ़र के माध्यम से वीडियो डेटा स्थानांतरित करें।
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # पूरी वीडियो को बाइट एरे में लोड करने के बजाय स्ट्रीम का उपयोग करें।
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
    # यदि आवश्यक हो तो, ऑडियो फ़ाइलों पर वही चरण लागू करें।
finally:
    presentation.dispose()
```

### **BLOB के रूप में छवि को प्रस्तुति में जोड़ें**
[ImageCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imagecollection/) क्लास की विधियों का उपयोग करके आप बड़े छवि को स्ट्रीम के रूप में जोड़ सकते हैं ताकि उसे BLOB के रूप में माना जाए।

यह Python कोड आपको दिखाता है कि BLOB प्रक्रिया के माध्यम से बड़ी छवि को कैसे जोड़ा जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# नई प्रस्तुति बनाएं जिसमें छवि जोड़ी जाएगी.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # स्ट्रीम को लॉक रखें क्योंकि हम छवि फ़ाइल को एक्सेस करने वाले नहीं हैं.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # मेमोरी खपत कम रखते हुए प्रस्तुति सहेजें.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **मेमोरी और बड़ी प्रस्तुतियाँ**

आमतौर पर, बड़ी प्रस्तुति लोड करने के लिए कंप्यूटर को बहुत सारी अस्थायी मेमोरी की आवश्यकता होती है। प्रस्तुति की पूरी सामग्री मेमोरी में लोड हो जाती है और वह फ़ाइल (जिससे प्रस्तुति लोड हुई थी) अब उपयोग में नहीं रहती।

एक बड़ी PowerPoint प्रस्तुति (large.pptx) पर विचार करें जिसमें 1.5 GB का वीडियो फ़ाइल शामिल है। इस प्रस्तुति को लोड करने की मानक विधि इस Python कोड में वर्णित है:

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

हालाँकि यह विधि लगभग 1.6 GB अस्थायी मेमोरी का उपभोग करती है।

### **BLOB के रूप में बड़ी प्रस्तुति लोड करें**

BLOB प्रक्रिया के माध्यम से आप कम मेमोरी का उपयोग करके बड़ी प्रस्तुति लोड कर सकते हैं। यह Python कोड वह कार्यान्वयन दर्शाता है जहाँ BLOB प्रक्रिया का उपयोग करके बड़ी प्रस्तुति फ़ाइल (large.pptx) को लोड किया जाता है:

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

### **अस्थायी फ़ाइलों के फ़ोल्डर को बदलें**

जब BLOB प्रक्रिया का उपयोग किया जाता है, आपका कंप्यूटर डिफ़ॉल्ट अस्थायी फ़ाइलों के फ़ोल्डर में अस्थायी फ़ाइलें बनाता है। यदि आप चाहते हैं कि अस्थायी फ़ाइलें किसी अलग फ़ोल्डर में रखी जाएँ, तो आप [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) का उपयोग करके संग्रहण सेटिंग्स बदल सकते हैं:

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

{{% alert color="info" title="Note" %}}
जब आप [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) का उपयोग करते हैं, तो Aspose.Slides स्वचालित रूप से अस्थायी फ़ाइलों को संग्रहित करने के लिए फ़ोल्डर नहीं बनाता। आपको स्वयं फ़ोल्डर बनाना होगा।
{{% /alert %}}

### **मेमोरी मुक्त करने के लिए प्रस्तुति वस्तुओं को डिस्पोज़ करें**

बड़ी प्रस्तुतियों को प्रोसेस करते समय, सुनिश्चित करें कि [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को सही प्रकार से डिस्पोज़ किया गया है ताकि उसने जो मेमोरी उपयोग की थी वह मुक्त हो सके। प्रस्तुति के उपयोग के बाद [Presentation.dispose](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#dispose) को कॉल करके अनमैनेज्ड रिसोर्सेज़ को मुक्त करें।

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
    # स्पष्ट रूप से संसाधनों को मुक्त करें.
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides प्रस्तुति में कौन सा डेटा BLOB के रूप में माना जाता है और BLOB विकल्पों द्वारा नियंत्रित होता है?**

छवियों, ऑडियो तथा वीडियो जैसी बड़ी बाइनरी वस्तुएँ BLOB मानी जाती हैं। पूरी प्रस्तुति फ़ाइल भी लोड या सेव करने के समय BLOB हैंडलिंग में शामिल होती है। ये वस्तुएँ BLOB नीतियों द्वारा नियंत्रित होती हैं जो मेमोरी उपयोग को प्रबंधित करने और आवश्यक होने पर अस्थायी फ़ाइलों में स्पिल करने की अनुमति देती हैं।

**प्रस्तुति लोड करते समय BLOB हैंडलिंग नियम कहाँ कॉन्फ़िगर किए जाते हैं?**

[LoadOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/) को [BlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/) के साथ उपयोग करें। यहाँ आप इन‑मेमोरी BLOB सीमा, अस्थायी फ़ाइलों की अनुमति/अस्वीकार, अस्थायी फ़ाइलों के रूट पाथ और स्रोत लॉकिंग व्यवहार सेट कर सकते हैं।

**क्या BLOB सेटिंग्स प्रदर्शन को प्रभावित करती हैं, और गति बनाम मेमोरी को कैसे संतुलित करें?**

हाँ। मेमोरी में BLOB रखने से गति अधिक होती है लेकिन RAM की खपत बढ़ती है; मेमोरी सीमा घटाने से अधिक काम अस्थायी फ़ाइलों पर शिफ्ट हो जाता है, जिससे RAM कम उपयोग होती है पर अतिरिक्त I/O की लागत आती है। सही संतुलन पाने के लिए आप [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) मेथड का उपयोग कर सकते हैं।

**क्या BLOB विकल्प बहुत बड़ी प्रस्तुतियों (जैसे गीगाबाइट्स) के खोलने में मदद करते हैं?**

हाँ। [BlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/blobmanagementoptions/) ऐसे परिदृश्य के लिए डिज़ाइन किए गए हैं: अस्थायी फ़ाइलों को सक्षम करना और स्रोत लॉकिंग का उपयोग करना पीक RAM उपयोग को काफी घटा सकता है और बहुत बड़ी डेक्स के प्रोसेसिंग को स्थिर बना सकता है।

**क्या मैं डिस्क फ़ाइलों की बजाय स्ट्रीम से लोड करते समय BLOB नीतियों का उपयोग कर सकता हूँ?**

हाँ। वही नियम स्ट्रीम्स पर भी लागू होते हैं: प्रस्तुति इंस्टेंस इनपुट स्ट्रीम को अपने पास रख सकती है और लॉक कर सकती है (चुनी गई लॉकिंग मोड के आधार पर), और जब अनुमति हो तो अस्थायी फ़ाइलें उपयोग की जाती हैं, जिससे प्रोसेसिंग के दौरान मेमोरी उपयोग पूर्वानुमेय रहता है।