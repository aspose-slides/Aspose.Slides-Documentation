---
title: Python के माध्यम से Java में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/python-java/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को मिलाएँ
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स को मिलाएँ
- PPT को मिलाएँ
- PPTX को मिलाएँ
- ODP को मिलाएँ
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java में PowerPoint और OpenDocument प्रस्तुतियों को स्लाइड क्लोनिंग, मास्टर और लेआउट नियंत्रण, स्लाइड सामग्री का रिसाइज़िंग, सेक्शन को संरक्षित करने और संरक्षित या बड़ी फ़ाइलों को संभालने के द्वारा कैसे मर्ज करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java प्रस्तुतियों को एक प्रस्तुति से दूसरी में स्लाइड को क्लोन करके मिलाता है। मुख्य ऑपरेशन है [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone), जो स्रोत स्लाइड का फॉर्मेट बरकरार रख सकता है या क्लोन की गई स्लाइड को गंतव्य प्रस्तुति के एक मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्ज वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फॉर्मेट को बरकरार रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- गंतव्य प्रस्तुति से मास्टर लागू करें;
- गंतव्य प्रस्तुति से विशिष्ट लेआउट लागू करें;
- मर्ज से पहले विभिन्न स्लाइड आकारों को सामान्य करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- एक एंड‑टू‑एंड वर्कफ़्लो में कई प्रस्तुतियों को मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणियाँ, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइलों और मल्टीथ्रेडिंग के मुद्दों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपना अधिकांश स्वरूप अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिस क्लोनिंग ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड गंतव्य प्रस्तुति में कैसे एकीकृत होगी।

इनमें से किसी एक तरीके से [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) का उपयोग करें:

- `addClone(source_slide)` — स्रोत स्लाइड के लेआउट और फॉर्मेट को बरकरार रखें। आवश्यक होने पर स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि वही मास्टर कई बार क्लोन न हो।
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — क्लोन की गई स्लाइड को एक विशिष्ट गंतव्य [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम से मिलते‑जुलते लेआउट की खोज करता है।
- `addClone(source_slide, destination_layout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गंतव्य [LayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/) से जोड़ें।

`addClone` ओवरलोड को पास किया गया मास्टर या लेआउट **गंतव्य** प्रस्तुति से सम्बंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फॉर्मेट बरकरार रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से सभी स्लाइड्स को गंतव्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखने चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

यदि स्रोत और गंतव्य अलग‑अलग डिज़ाइन उपयोग कर रहे हों तो परिणामस्वरूप प्रस्तुति में कई मास्टर हो सकते हैं। यह वही अपेक्षित परिणाम है जब स्रोत फॉर्मेट इरादे से बरकरार रखा जाता है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। नीचे दिया गया उदाहरण केवल स्रोत प्रस्तुति से चयनित स्लाइड इंडेक्स को आयात करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आए स्लाइड इंडेक्स को क्लोन करने से पहले सत्यापित करें।

## **गंतव्य मास्टर के साथ स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को उस मास्टर का अनुसरण करना हो जो पहले से गंतव्य प्रस्तुति में मौजूद है, तब [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) ओवरलोड का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मिलते‑जुलते लेआउट को चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allow_clone_missing_layout` `True` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `False` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।

यदि आप मर्ज को विफल करना चाहते हैं बजाय अतिरिक्त लेआउट जोड़ने के, तो `False` का उपयोग करें।

## **विशिष्ट गंतव्य लेआउट के साथ स्लाइड्स को मर्ज करें**

जब आपको पता हो कि आयातित स्लाइड्स को कौन सा गंतव्य लेआउट उपयोग करना चाहिए, तो [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) ओवरलोड का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

गंतव्य लेआउट लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड सामग्री को पुन:डिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट में प्लेसहोल्डर संरचना अलग है, तो परिणाम का निरीक्षण करें ताकि विरासत में मिला फॉर्मेट और प्लेसहोल्डर व्यवहार उपयुक्त हों।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री स्वचालित रूप से नए कैनवास के लिए पुनःडिज़ाइन नहीं होती। परिणामस्वरूप आकार बदलने, स्केलिंग या स्लाइड सीमा से बाहर जाने की संभावना होती है।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize.setSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#setSize) मेथड मौजूदा सामग्री को स्केल करते हुए स्लाइड आयाम बदल सकता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने हेतु स्केल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

रिसाइज़िंग स्रोत प्रस्तुति के ऑब्जेक्ट को मेमोरी में बदल देती है। यदि आपको मूल स्रोत प्रस्तुति को अन्य ऑपरेशनों के लिए अपरिवर्तित रखना है, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनःनिर्मित नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो गंतव्य प्रस्तुति में सेक्शन बनाएं या चुनें और [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) के साथ स्पष्ट रूप से उनमें स्लाइड्स क्लोन करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

क्लोन की गई स्लाइड्स निर्दिष्ट गंतव्य सेक्शन में जोड़ी जाती हैं। कई स्रोत सेक्शन को बरकरार रखने के लिए, [Presentation.getSections](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSections) को क्रमांकित करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSlidesListOfSection) से प्राप्त करें, गंतव्य में सेक्शन पुनः बनाएं, और प्रत्येक प्राप्त स्लाइड को उसके अनुरूप गंतव्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑एन्‍युमरेशन उदाहरण के लिए [Manage Slide Sections](/slides/hi/python-java/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्नलिखित एंड‑टू‑एंड उदाहरण पहला प्रस्तुति को गंतव्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्य करता है, प्रत्येक स्रोत को केवल कॉपी करते समय खोलता है, और अंतिम फ़ाइल को केवल एक बार सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

यह आयातित स्लाइड्स के स्रोत फॉर्मेट को बरकरार रखने के लिए एक उपयोगी बेसलाइन है। यदि आपके आउटपुट को एकल गंतव्य थीम उपयोग करना है, तो सरल `addClone(slide)` कॉल को पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फॉर्मेटिंग की सटीकता**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में ला सकती है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि दोहराए गए स्लाइड्स जिससे वही स्रोत मास्टर प्रयोग हो रहा हो, वह बार‑बार क्लोन न हो। मैन्युअल क्लोन किए गए मास्टर इस रजिस्ट्री में नहीं आते, इसलिए स्पष्ट नियंत्रण की आवश्यकता न होने तक पूर्व‑क्लोनिंग से बचें।

दो मास्टर या लेआउट जिनका नाम समान है, यह मानना सुरक्षित नहीं है कि वे दृश्य रूप से समान होंगे। यदि कॉर्पोरेट टेम्प्लेट को अंतिम स्वरूप नियंत्रित करना है, तो स्पष्ट रूप से गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम को सत्यापित करें।

### **नोट्स और टिप्पणियाँ**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री के साथ जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides इसी हेतु समर्पित API प्रदान करता है: [presentation notes](/slides/hi/python-java/presentation-notes/) और [presentation comments](/slides/hi/python-java/presentation-comments/)।

यदि नोट‑पेज फॉर्मेट महत्वपूर्ण है, तो मर्ज्ड प्रस्तुति को जांचें क्योंकि नोट‑मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में भिन्न हो सकते हैं। समीक्षा वर्कफ़्लो में विभिन्न लेखक या टेम्प्लेट से फ़ाइलों को मिलाते समय टिप्पणी लेखक और थ्रेडेड कमेंट्स को भी सत्यापित करें।

### **इमेज, ऑडियो, वीडियो, OLE ऑब्जेक्ट और बाहरी लिंक**

स्लाइड्स प्रस्तुति‑स्तर संसाधनों जैसे इमेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्यमान शेप्स को कॉपी करने के बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides संसाधनों के बीच संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपना बाहरी टारगेट पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री में नहीं बदलता। मर्ज्ड प्रस्तुति के खुले जाने वाले वातावरण में लिंक्ड‑रिसोर्स पाथ और URL का परीक्षण करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह यह गारंटी नहीं देता कि असंबंधित स्रोत प्रस्तुतियों से समान बाइनरी संसाधन हमेशा डिडुप्लीकेट हो जाएंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज्ड पैकेज की जाँच करें और परिणाम को मापें, न कि अंतर्निहित डिडुप्लीकेशन पर भरोसा करें।

### **एम्बेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को सभी मशीनों पर समान रखना है, तो केवल स्लाइड क्लोनिंग से यह सुनिश्चित नहीं किया जा सकता कि आवश्यक फ़ॉन्ट गंतव्य वातावरण में उपलब्ध हों। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) से एम्बेडेड फ़ॉन्ट्स देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/python-java/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

साथ ही यह सत्यापित करें कि स्रोत फ़ाइलों में उपयोग किए गए फ़ॉन्ट को एम्बेड करने की अनुमति आपके पास है। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियाँ**

पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) के माध्यम से प्रदान करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # डिक्रिप्ट की गई प्रस्तुति के साथ काम करें.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

एक एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से गंतव्य प्रस्तुति पर वही सुरक्षा लागू नहीं करता। आवश्यक होने पर आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेज, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियों में काफी मेमोरी खर्च हो सकता है। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](/slides/hi/python-java/manage-blob/)।

बड़े फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को मर्ज के बाद तुरंत डिस्पोज़ करें, और मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें जब तक कि वर्कफ़्लो में चेकपॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, संशोधित, सहेज या क्लोन नहीं करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र जॉब्स को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग गाइडलाइन्स](/slides/hi/python-java/multithreading/) का पालन करें।

## **FAQ**

**मैं प्रत्येक स्रोत प्रस्तुति के मूल डिज़ाइन को कैसे बनाए रखूँ?**

डेस्टिनेशन मास्टर या लेआउट प्रदान किए बिना `[addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone)` का उपयोग करें। आवश्यक होने पर Aspose.Slides स्रोत मास्टर को स्वचालित रूप से क्लोन कर सकता है।

**आयातित स्लाइड्स को गंतव्य थीम का उपयोग कैसे कराऊँ?**

ऐसा ओवरलोड उपयोग करें जो गंतव्य मास्टर को स्वीकार करता है। गंतव्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के उपयुक्त लेआउट से मैप करने का प्रयास करेगा।

**जब मैं मास्टर के बजाय विशिष्ट गंतव्य लेआउट उपयोग करूँ तो कब?**

जब सभी आयातित स्लाइड्स को एक ज्ञात लेआउट का उपयोग करना हो, तो विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के भीतर उपयुक्त लेआउट चुनें, तो मास्टर चुनें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हां, लेकिन स्लाइड सामग्री स्वचालित रूप से गंतव्य आयामों के लिए पुनःडिज़ाइन नहीं होगी। पूर्व‑रिसाइज़िंग के लिए उदाहरण के तौर पर [SlideSize.setSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#setSize) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक डेस्टिनेशन में क्लोन करें, और डेस्टिनेशन को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूंकि विभिन्न फ़ॉर्मेट समान फीचर सेट का समर्थन नहीं करते, इसलिए क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की जाँच करें। देखें [Supported File Formats](/slides/hi/python-java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित रहते हैं?**

बेसिक लूप जो केवल स्लाइड्स को क्लोन करता है, सेक्शन को नहीं रखता। गंतव्य में आवश्यक सेक्शन को पुनःनिर्मित करें और सेक्शन‑ओवरलोड वाले `addClone` का उपयोग करें जब सेक्शन संरचना को बनाए रखना हो।

**क्या स्पीकर नोट्स और टिप्पणियाँ संरक्षित रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। यदि नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो है, तो मर्ज के बाद परिणाम की जाँच करें क्योंकि ये दोनों प्रस्तुति‑स्तर और स्लाइड‑स्तर संरचनाओं को प्रभावित करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के संसाधन संबंधों के साथ ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं; उनका लक्ष्य फ़ाइल या URL मर्ज के बाद भी उपलब्ध होना चाहिए।

**क्या प्रत्येक स्रोत से एम्बेडेड फ़ॉन्ट हमेशा मर्ज्ड प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग केवल फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देती। गंतव्य में एम्बेडेड फ़ॉन्ट्स की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही `[LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword)` के साथ इसे खोलें, फिर सामान्य रूप से स्लाइड्स क्लोन करें। आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

**मैं बहुत बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी का अधिकांश हिस्सा ले रहे हों तो BLOB मैनेजमेंट उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को शीघ्र डिस्पोज़ करें, और केवल आवश्यक होने पर अंतिम परिणाम सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को अपने स्वयं के प्रस्तुति इंस्टेंस तक सीमित रखें।