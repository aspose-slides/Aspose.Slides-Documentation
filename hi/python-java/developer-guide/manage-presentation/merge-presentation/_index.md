---
title: Python via Java में प्रभावी रूप से प्रस्तुतियों को मर्ज करें
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
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- Python
- Java
- Aspose.Slides
description: "Python via Java में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड कंटेंट को री‑साइज़ करके, सेक्शन्स को संरक्षित करके, और संरक्षित या बड़े फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को मर्ज करना सीखें।"
---
## **समीक्षा**

Aspose.Slides for Python via Java प्रस्तुतियों को एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) से दूसरी में स्लाइड्स को क्लोन करके मिलाता है। मुख्य ऑपरेशन [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) है, जो स्रोत स्लाइड की फ़ॉर्मेटिंग को सुरक्षित रख सकता है या क्लोन किए गए स्लाइड को गंतव्य प्रस्तुति में किसी मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग कार्यप्रवाहों को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- गंतव्य प्रस्तुति से एक मास्टर लागू करें;
- गंतव्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक अंत‑से‑अंत कार्यप्रवाह में सुरक्षित रूप से मर्ज करें;
- मास्टर, रिसोर्सेज, नोट्स, कमेंट्स, मीडिया, फ़ॉन्ट्स, पासवर्ड, बड़े फ़ाइलें, और मल्टीथ्रेडिंग संबंधी चिंताओं को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपना अधिकांश लुक अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जो क्लोनिंग ओवरलोड चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड गंतव्य प्रस्तुति में कैसे इंटीग्रेट होगी।

इनमें से किसी एक तरीके से [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) का उपयोग करें:

- `addClone(source_slide)` — स्रोत स्लाइड का लेआउट और फ़ॉर्मेटिंग बनाए रखें। आवश्यकता पड़ने पर, स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है जिससे समान स्रोत मास्टर वाले दोहराए गए स्लाइड्स बार‑बार क्लोन नहीं होते।
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — क्लोन की गई स्लाइड को एक विशिष्ट गंतव्य [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम के आधार पर मिलते‑जुलते लेआउट को खोजता है।
- `addClone(source_slide, destination_layout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गंतव्य [LayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/) से जोड़ें।

`addClone` ओवरलोड को दिया गया मास्टर या लेआउट **गंतव्य** प्रस्तुति का होना चाहिए, स्रोत प्रस्तुति का नहीं।

## **पूरा प्रस्तुति मर्ज करें और स्रोत फ़ॉर्मेटिंग सुरक्षित रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति की प्रत्येक स्लाइड को गंतव्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त होता है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखना चाहिए।

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

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और गंतव्य विभिन्न डिज़ाइन उपयोग करते हैं। यह अपेक्षित है जब स्रोत फ़ॉर्मेटिंग इरादतन संरक्षित की जाती है।

## **चयनित स्लाइड्स को मर्ज करें**

हर स्लाइड क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल स्रोत प्रस्तुति से चयनित स्लाइड इंडेक्स आयात करता है।

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

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आए इंडेक्स को क्लोन करने से पहले वैधता जांचें।

## **गंतव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को गंतव्य प्रस्तुति के मौजूदा मास्टर का पालन करना चाहिए, तो [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मिलते‑जुलते लेआउट को चुनता है। यदि उपयुक्त लेआउट नहीं मिलता और `allow_clone_missing_layout` `True` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ सके। यदि यह `False` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxeditexception/) फेंकी जाती है।

जब आप चाहते हैं कि मर्ज विफल हो और गंतव्य मास्टर में अतिरिक्त लेआउट न जोड़ा जाए, तो `False` उपयोग करें।

## **विशिष्ट गंतव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आपको ठीक‑ठीक पता हो कि आयातित स्लाइड्स को कौन‑सा गंतव्य लेआउट उपयोग करना चाहिए, तो [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) ओवरलोड का उपयोग करें।

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

गंतव्य लेआउट लागू करना विरासत में मिले लेआउट संबंध को बदलता है; यह स्रोत स्लाइड सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट में प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम की जाँच करें कि विरासत में मिली फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उचित है या नहीं।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी अन्य स्लाइड आकार वाली प्रस्तुति में स्लाइड को क्लोन करने से उसकी सामग्री नई कैनवास के लिए स्वतः पुनः डिज़ाइन नहीं होती। इस कारण आकार बदलने पर आकार, स्थिति या दृश्यता में परिवर्तन हो सकते हैं।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदल दिया जाए। [SlideSize.setSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#setSize) मेथड मौजूदा सामग्री को स्केल कर स्लाइड आयाम बदल सकता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

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

रीसाइज़ करने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको मूल स्रोत प्रस्तुति को अन्य ऑपरेशनों के लिए अपरिवर्तित रखना है, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बुनियादी स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन मायने रखते हैं, तो गंतव्य प्रस्तुति में सेक्शन बनाएँ या चुनें और स्लाइड्स को स्पष्ट रूप से [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) के साथ उन सेक्शन में क्लोन करें।

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

क्लोन की गई स्लाइड निर्दिष्ट गंतव्य सेक्शन में जोड़ दी जाती है। कई स्रोत सेक्शन को संरक्षित करने के लिए, [Presentation.getSections](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSections) को क्रमांकित करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/section/#getSlidesListOfSection) से प्राप्त करें, गंतव्य में सेक्शन पुनः बनायें, और प्रत्येक प्राप्त स्लाइड को उसकी संबंधित गंतव्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑एन्हांसमेंट उदाहरण के लिए [Manage Slide Sections](/slides/hi/python-java/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंत‑से‑अंत उदाहरण पहले प्रस्तुति को गंतव्य के रूप में लेता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तभी खुला रखता है जब वह कॉपी हो रहा हो, और अंतिम फ़ाइल को केवल एक बार सहेजता है।

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

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को संरक्षित करने के लिए एक उपयोगी बेंचमार्क है। यदि आपका आउटपुट एकल गंतव्य थीम का उपयोग करना चाहिए, तो सरल `addClone(slide)` कॉल को पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में ला सकता है। Aspose.Slides दोहराए गए मास्टर को बार‑बार क्लोन करने से बचने के लिए स्वचालित क्लोन किए गए मास्टर की एक आंतरिक रजिस्ट्री रखता है। मैन्युअली क्लोन किए गए मास्टर इस रजिस्ट्री में ट्रैक नहीं होते, इसलिए जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण नहीं चाहते, तब तक पूर्व‑क्लोनिंग से बचें।

यह मान कर चलें कि दो मास्टर या लेआउट जिनका नाम समान है, दृश्य रूप से समान हैं, यह सही नहीं है। यदि कॉरपोरेट टेम्प्लेट अंतिम लुक को नियंत्रित करता है, तो स्पष्ट रूप से एक गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम सत्यापित करें।

### **नोट्स और कमेंट्स**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides [presentation notes](/slides/hi/python-java/presentation-notes/) और [presentation comments](/slides/hi/python-java/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति को सत्यापित करें क्योंकि नोट्स‑मास्टर प्रस्तुति‑स्तरीय ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। रिव्यू वर्कफ़्लो में विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद टिप्पणी लेखकों और थ्रेडेड कमेंट्स को भी जांचें।

### **इमेजेस, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स, और एक्सटर्नल लिंक**

स्लाइड्स प्रस्तुति‑स्तरीय रिसोर्सेज जैसे इमेजेस, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्य शैप्स को कॉपी करने की बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides स्लाइड‑रिसोर्स संबंधों को बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्सेज को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपनी बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। मर्ज किए गए प्रस्तुति को खोलने वाले पर्यावरण में लिंक्ड‑रिसोर्स पाथ और URL का परीक्षण करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह सामान्य गारंटी नहीं है कि अलग‑अलग स्रोत प्रस्तुतियों से समान बाइनरी रिसोर्सेज हमेशा डिडुप्लिकेट हो जाएँ। यदि आउटपुट फ़ाइल आकार मायने रखता है, तो निहित डिडुप्लिकेशन पर भरोसा न करें; पैकेज की जाँच करें और परिणाम मापें।

### **एम्बेडेड फ़ॉन्ट्स और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी कई मशीनों में सुसंगत रहनी चाहिए, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट गंतव्य पर्यावरण में उपलब्ध हों। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) से एम्बेडेड फ़ॉन्ट्स देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/python-java/embedded-font/) में वर्णित अनुसार स्पष्ट रूप से एम्बेडिंग प्रबंधित कर सकते हैं।

साथ ही यह सत्यापित करें कि स्रोत फ़ाइलों में उपयोग किए गए फ़ॉन्ट्स को एम्बेड करने की अनुमति है या नहीं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियां**

पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) के माध्यम से प्रदान करें।

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
    # डिक्रिप्ट किए गए प्रस्तुति के साथ काम करें।
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

एक एन्क्रिप्टेड स्रोत को खोलने से गंतव्य प्रस्तुति पर वही सुरक्षा स्वचालित रूप से लागू नहीं होती। आवश्यक होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियां और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेजेस, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट्स वाली बड़ी प्रस्तुतियां बड़ी मेमोरी खपत कर सकती हैं। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) BLOB हैंडलिंग और टेम्प‑फाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए [Manage Presentation BLOBs](/slides/hi/python-java/manage-blob/) देखें।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल‑पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को उसके मर्ज हो जाने पर तुरंत डिस्पोज़ करें, और मध्यवर्ती परिणाम को बार‑बार सहेजने से बचें जब तक वर्कफ़्लो में चेक‑पॉइंट आवश्यक न हो।

### **थ्रेड सेफ़्टी**

एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, मॉडिफ़ाइ, सेव या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र जॉब्स को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](/slides/hi/python-java/multithreading/) का पालन करें।

## **FAQ**

**मैं प्रत्येक स्रोत प्रस्तुति का मूल डिज़ाइन कैसे रखूँ?**

गंतव्य मास्टर या लेआउट प्रदान किए बिना `[addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone)` का उपयोग करें। आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन कर देगा।

**आयातित स्लाइड्स को गंतव्य थीम कैसे लागू करूँ?**

ऐसा ओवरलोड उपयोग करें जो गंतव्य मास्टर को स्वीकार करता हो। गंतव्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट के साथ मानचित्रित करने का प्रयास करेगा।

**मुझे गंतव्य मास्टर के बजाय विशिष्ट गंतव्य लेआउट कब उपयोग करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट उपयोग करना हो, तब विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के लेआउट में से चुन ले, तो मास्टर का उपयोग करें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड सामग्री स्वचालित रूप से नई आयामों के लिए पुनः डिज़ाइन नहीं होती। पूर्व‑रीसाइज़ करने के लिए [SlideSize.setSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#setSize) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesizescaletype/) का प्रयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक गंतव्य में क्लोन करें, और गंतव्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। क्योंकि प्रस्तुति फ़ॉर्मेट्स का फीचर सेट बिल्कुल समान नहीं होता, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल कंटेंट को सत्यापित करें। देखें [Supported File Formats](/slides/hi/python-java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

केवल स्लाइड क्लोन करने वाले बुनियादी लूप से नहीं। गंतव्य में आवश्यक सेक्शन पुनः बनाएं और सेक्शन संरचना को संरक्षित करने के लिए [addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और कमेंट्स संरक्षित होते हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी होते हैं। नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो में, मर्ज परिणाम को सत्यापित करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तरीय संरचनाओं के साथ स्लाइड‑स्तरीय कंटेंट को भी शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के रिसोर्स रिलेशनशिप का हिस्सा बनकर ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए उनके लक्ष्य फ़ाइल या URL को मर्ज के बाद भी उपलब्ध रखना आवश्यक है।

**क्या प्रत्येक स्रोत से एम्बेडेड फ़ॉन्ट्स मर्ज की गई प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग केवल फ़ॉन्ट डिप्लॉयमेंट के लिए भरोसा न करें। गंतव्य में एम्बेडेड फ़ॉन्ट्स की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setPassword) के साथ इसे खोलें, फिर सामान्य रूप से उसके स्लाइड्स क्लोन करें। आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

**बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट्स मेमोरी पर भारी हों, तो BLOB मैनेजमेंट का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को तुरंत डिस्पोज़ करें, और अंतिम परिणाम को केवल आवश्यक होने पर सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को अलग प्रस्तुति इंस्टेंस तक सीमित रखें। स्वतंत्र कार्यों के लिए स्वतंत्र इंस्टेंस बनाएँ और Aspose.Slides मल्टीथ्रेडिंग गाइडलाइन का पालन करें।