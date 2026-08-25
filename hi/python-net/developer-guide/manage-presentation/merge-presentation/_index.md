---
title: Python के साथ प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/python-net/merge-presentation/
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
- Aspose.Slides
description: "Python में स्लाइड्स को क्लोन करके, मास्टर्स और लेआउट्स को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, और संरक्षित या बड़े फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को मर्ज करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET प्रस्तुतियों को एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) से दूसरे में स्लाइड क्लोन करके मर्ज करता है। मुख्य ऑपरेशन है [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/), जो स्रोत स्लाइड की फ़ॉर्मेटिंग को संरक्षित रख सकता है या क्लोन की गई स्लाइड को गंतव्य प्रस्तुति में मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्ज वर्कफ़्लो को कवर करता है:

- सभी स्लाइड को मर्ज करें जबकि स्रोत फ़ॉर्मेटिंग को संरक्षित रखें;
- चयनित स्लाइड को मर्ज करें;
- गंतव्य प्रस्तुति से एक मास्टर लागू करें;
- गंतव्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड को एक सेक्शन में जोड़ें;
- एक एंड-टु-एंड वर्कफ़्लो में कई प्रस्तुतियों को मर्ज करें;
- मास्टर्स, रिसोर्सेज, नोट्स, कमेंट्स, मीडिया, फोंट्स, पासवर्ड, बड़े फ़ाइलें, और मल्टीथ्रेडिंग चिंताओं को संभालें।

## **स्लाइड क्लोनिंग का मास्टर्स और लेआउट्स पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश भाग अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिसके ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड को गंतव्य प्रस्तुति में कैसे इंटीग्रेट किया जाता है।

इनमें से किसी एक तरीके से [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) का उपयोग करें:

- `add_clone(source_slide)` — स्रोत स्लाइड का लेआउट और फ़ॉर्मेटिंग संरक्षित रखें। आवश्यकता पर, स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स को ट्रैक करता है ताकि समान स्रोत मास्टर का उपयोग करने वाली दोहराई गई स्लाइड्स मास्टर को बार‑बार क्लोन न करें।
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — क्लोन की गई स्लाइड को एक विशिष्ट गंतव्य [IMasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/) से संलग्न करें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम द्वारा मिलते‑जुलते लेआउट की तलाश करता है।
- `add_clone(source_slide, destination_layout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गंतव्य [ILayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilayoutslide/) से संलग्न करें।

`add_clone` ओवरलोड को पास किया गया मास्टर या लेआउट **गंतव्य** प्रस्तुति से संबंधित होना चाहिए, न कि स्रोत प्रस्तुति से।

## **सभी प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेटिंग संरक्षित रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से प्रत्येक स्लाइड को गंतव्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त चुनाव है जब आयातित स्लाइडों को अपना मूल थीम, मास्टर, और लेआउट संबंध बनाए रखना चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

यदि स्रोत और गंतव्य विभिन्न डिज़ाइनों का उपयोग करते हैं तो परिणामी प्रस्तुति में कई मास्टर्स हो सकते हैं। यह अपेक्षित है जब स्रोत फ़ॉर्मेटिंग को जानबूझकर संरक्षित किया जाता है।

## **निर्दिष्ट स्लाइड्स को मर्ज करें**

आपको प्रत्येक स्लाइड क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण स्रोत प्रस्तुति से केवल चयनित स्लाइड इंडेक्स को आयात करता है।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने पर क्लोन करने से पहले स्लाइड इंडेक्स को वैधता जाँचें।

## **गंतव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड को गंतव्य प्रस्तुति में पहले से मौजूद एक मास्टर का पालन करना चाहिए, तो [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) ओवरलोड का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मिलते‑जुलते उचित लेआउट का चयन करता है। यदि उपयुक्त लेआउट नहीं मिलता और `allow_clone_missing_layout` `True` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड को जोड़ा जा सके। यदि यह `False` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) फेंका जाता है।

`False` का उपयोग करें जब आप मर्ज को विफल होना चाहते हैं बजाए गंतव्य मास्टर में अतिरिक्त लेआउट जोड़ने के।

## **विशिष्ट गंतव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक जानते हैं कि आयातित स्लाइड को कौन सा गंतव्य लेआउट उपयोग करना चाहिए, तो [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) ओवरलोड का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

गंतव्य लेआउट लागू करने से विरासत वाला लेआउट संबंध बदल जाता है; यह स्रोत स्लाइड की सामग्री को फिर से डिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट में प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम का निरीक्षण करें और सुनिश्चित करें कि विरासत फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हैं।

## **भिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को किसी अन्य स्लाइड आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री स्वचालित रूप से नए कैनवास के लिए पुनः डिज़ाइन नहीं होती। इसलिए आकार, स्केल या अस्थायी रूप से दृश्यमान स्लाइड क्षेत्र के बाहर शिफ्ट हो सकती हैं।

व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize.set_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/set_size/) मेथड मौजूदा सामग्री को स्केल कर सकता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट होने के लिए स्केल करता है।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

रिसाइज़िंग स्रोत प्रस्तुति ऑब्जेक्ट को मेमोरी में बदल देती है। यदि आपको अन्य ऑपरेशनों के लिए मूल स्रोत प्रस्तुति अपरिवर्तित चाहिए, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदक्रम को पुनः निर्मित नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो गंतव्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) के साथ उन में क्लोन करें।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

क्लोन की गई स्लाइड निर्दिष्ट गंतव्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, [Presentation.sections](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/sections/) को इटरेट करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [Section.get_slides_list_of_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/get_slides_list_of_section/) से प्राप्त करें, गंतव्य में सेक्शन पुनः बनाएं, और प्रत्येक लौटाई गई स्लाइड को उसके संबंधित गंतव्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑इटरेशन उदाहरण के लिए [Manage Slide Sections](/slides/hi/python-net/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न एंड‑टु‑एंड उदाहरण पहले प्रस्तुति को गंतव्य मानता है, प्रत्येक अतिरिक्त स्रोत की स्लाइड आकार को सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तब तक खोलता है जब वह कॉपी हो रहा हो, और अंत में फ़ाइल को सेव करता है।

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

यह आयातित स्लाइड की स्रोत फ़ॉर्मेटिंग को संरक्षित करने के लिए एक उपयोगी बेसलाइन है। यदि आपके आउटपुट को एकल गंतव्य थीम उपयोग करनी है, तो सरल `add_clone(slide)` कॉल को पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर्स, लेआउट्स, और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को गंतव्य प्रस्तुति में स्वचालित रूप से ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स का एक आंतरिक रजिस्ट्री रखता है ताकि समान मास्टर का दोहराव न हो। मैन्युअली क्लोन किए गए मास्टर्स इस रजिस्ट्री द्वारा ट्रैक नहीं होते, इसलिए जब तक आपको मास्टर संरचना पर स्पष्ट नियंत्रण न चाहिए, प्री‑क्लोनिंग से बचें।

एक ही नाम वाले दो मास्टर या लेआउट को दृश्य रूप से समकक्ष न समझें। यदि कॉर्पोरेट टेम्प्लेट अंतिम लुक को नियंत्रित करता है, तो स्पष्ट रूप से गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की जाँच करें।

### **नोट्स और कमेंट्स**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides समर्पित API भी प्रदान करता है जैसे [presentation notes](/slides/hi/python-net/presentation-notes/) और [presentation comments](/slides/hi/python-net/presentation-comments/)।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति की जाँच करें क्योंकि नोट्स‑मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। रिव्यू वर्कफ़्लो में, विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद कमेंट लेखकों और थ्रेडेड कमेंट्स की भी पुष्टि करें।

### **इमेजेज, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स, और एक्सटरनल लिंकस**

स्लाइड्स प्रस्तुति‑स्तर के रिसोर्सेज जैसे इमेजेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा का संदर्भ दे सकते हैं। केवल दृश्य शैप्स को कॉपी करने की बजाय स्लाइड को स्वयं क्लोन करें ताकि Aspose.Slides उसके रिसोर्सेज के साथ संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्सेज को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट, या हाइपरलिंक अपने बाहरी टार्गेट पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। मर्ज की गई प्रस्तुति जहाँ खोली जाएगी, उस वातावरण में लिंक्ड‑रिसोर्स पाथ्स और URLs का परीक्षण करें।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर्स को ट्रैक करता है, लेकिन यह सामान्य गारंटी नहीं है कि अलग‑अलग स्रोत प्रस्तुतियों के समान बाइनरी रिसोर्सेज हमेशा डिडुप्लिकेट हो जाएँ। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज पैकेज की जाँच करें और परिणाम मापें, न कि अप्रत्यक्ष डिडुप्लिकेशन पर भरोसा करें।

### **एम्बेडेड फोंट्स और फोंट उपलब्धता**

फोंट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी मशीनों के बीच सुसंगत रहनी चाहिए, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि हर आवश्यक फोंट गंतव्य वातावरण में उपलब्ध होगा। आप [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) से एम्बेडेड फोंट देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/python-net/embedded-font/) में बताए अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

साथ ही जाँचें कि आप स्रोत फ़ाइलों द्वारा उपयोग किए गए फोंट को एम्बेड करने के लिए अनुमति प्राप्त हैं या नहीं। फोंट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑प्रोटेक्टेड प्रस्तुतियां**

एक पासवर्ड‑प्रोटेक्टेड स्रोत को पहले सफलतापूर्वक खोलना आवश्यक है, तभी उसकी स्लाइड्स को क्लोन किया जा सकता है। पासवर्ड को [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) के माध्यम से प्रदान करें।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

एक एन्क्रिप्टेड स्रोत को खोलना गंतव्य प्रस्तुति पर वही सुरक्षा स्वचालित रूप से नहीं लगाता। आवश्यक होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियां और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेजेज, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट्स वाली बड़ी प्रस्तुतियां काफी मेमोरी ले सकती हैं। [LoadOptions.blob_management_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/blob_management_options/) BLOB हैंडलिंग और अस्थायी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](/slides/hi/python-net/manage-blob/)।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को उसी क्षण बंद करें जब वह मर्ज हो चुका हो, और मध्यवर्ती परिणामों को बार‑बार सेव करने से बचें जब तक वर्कफ़्लो में चेकपॉइंट की आवश्यकता न हो। `with slides.Presentation(...)` का उपयोग करने से कंटेक्स्ट समाप्त होने पर प्रस्तुति रिसोर्सेज रिलीज़ हो जाते हैं।

### **थ्रेड सेफ़्टी**

कई थ्रेड्स से किसी भी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को एक साथ लोड, सेव या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन को सिंगल‑थ्रेडेड रखें। यदि आप स्वतंत्र मर्ज जॉब्स को समानांतर बनाते हैं, तो अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस और स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें जैसा कि [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](/slides/hi/python-net/multithreading/) में बताया गया है।

## **FAQ**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे बना कर रखूँ?**

एक गंतव्य मास्टर या लेआउट प्रदान किए बिना [add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) का उपयोग करें। आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन कर देगा।

**मैं आयातित स्लाइड को गंतव्य थीम कैसे उपयोग करवाऊँ?**

ऐसा ओवरलोड उपयोग करें जो गंतव्य मास्टर स्वीकार करता हो। गंतव्य प्रस्तुति से मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**किस स्थिति में गंतव्य लेआउट का उपयोग करना चाहिए न कि गंतव्य मास्टर?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट इस्तेमाल करना हो, तो विशिष्ट लेआउट उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के लेआउट में से चयन करे, तो मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड सामग्री स्वचालित रूप से गंतव्य आयामों के लिए पुनः डिज़ाइन नहीं होती। जब निश्चित प्लेसमेंट चाहिए, तो स्रोत प्रस्तुति को पहले रिसाइज़ करें, उदाहरण के लिए [SlideSize.set_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/set_size/) और [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesizescaletype/) के साथ।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति लोड करें, आवश्यक स्लाइड्स को एक गंतव्य में क्लोन करें, और गंतव्य को समर्थित आउटपुट फ़ॉर्मेट में सेव करें। क्योंकि प्रस्तुति फ़ॉर्मेट्स की फीचर सेट समान नहीं होती, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की जाँच करें। देखें [Supported File Formats](/slides/hi/python-net/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

केवल स्लाइड्स को क्लोन करने वाले बेसिक लूप से नहीं। गंतव्य में आवश्यक सेक्शन पुनः बनाएं और सेक्शन‑ओवरलोड वाले [add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) का उपयोग करें जब सेक्शन संरचना संरक्षित करनी हो।

**क्या स्पीकर नोट्स और कमेंट्स संरक्षित होते हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी होते हैं। नोट‑मास्टर स्टाइलिंग, कमेंट लेखकों, या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो में, मर्ज परिणाम की जाँच करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर संरचनाओं के साथ स्लाइड‑स्तर सामग्री को भी प्रभावित करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और हाइपरलिंक्स का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड की रिसोर्स रिलेशनशिप का हिस्सा बन जाता है। बाहरी लिंक बाहरी रहते हैं, इसलिए मर्ज के बाद उनके टार्गेट फ़ाइलें या URLs उपलब्ध हों यह सुनिश्चित करें।

**क्या प्रत्येक स्रोत से एम्बेडेड फोंट स्वचालित रूप से मर्ज प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग अकेले फोंट डिप्लॉयमेंट की गारंटी नहीं देता। गंतव्य में एम्बेडेड फोंट की जाँच करें और जब टाइपोग्राफी महत्वपूर्ण हो तो फोंट एम्बेडिंग या बाहरी फोंट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑प्रोटेक्टेड फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) के साथ उसे खोलें, फिर स्लाइड्स को सामान्य रूप से क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर किया जाता है।

**बड़ी प्रस्तुतियों को मैं कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी का बड़ा हिस्सा लेते हों, तो BLOB मैनेजमेंट का उपयोग करें, बहुत बड़े फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को शीघ्र बंद करें, और अंतिम परिणाम केवल आवश्यक होने पर ही सेव करें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

कई थ्रेड्स से किसी भी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को लोड, सेव या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन को सिंगल‑थ्रेडेड रखें; यदि अलग‑अलग मर्ज जॉब्स को समानांतर करना आवश्यक है, तो स्वतंत्र सिंगल‑थ्रेडेड प्रोसेस और स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें।