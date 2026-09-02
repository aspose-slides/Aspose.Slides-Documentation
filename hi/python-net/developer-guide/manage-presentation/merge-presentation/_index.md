---
title: Python के साथ प्रभावी रूप से प्रस्तुतियों को मिलाएं
linktitle: प्रस्तुतियों को मिलाएं
type: docs
weight: 40
url: /hi/python-net/merge-presentation/
keywords:
- PowerPoint मिलाएं
- प्रस्तुतियों को मिलाएं
- स्लाइड्स को मिलाएं
- PPT मिलाएं
- PPTX मिलाएं
- ODP मिलाएं
- PowerPoint संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT संयोजित करें
- PPTX संयोजित करें
- ODP संयोजित करें
- Python
- Aspose.Slides
description: "Python में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री को रिसाइज़ करके, सेक्शनों को संरक्षित करके, और सुरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज किया जाए, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET स्लाइड को क्लोन करके एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) से दूसरी में मिलाकर प्रेज़ेंटेशन को मर्ज करता है। मुख्य ऑपरेशन है [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/), जो स्रोत स्लाइड का फॉर्मेटिंग बनाए रख सकता है या क्लोन किए गए स्लाइड को लक्ष्य प्रस्तुति के मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे आम मर्जिंग वर्कफ़्लो को कवर करता है:

- सभी स्लाइड को उनके स्रोत फॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड को मर्ज करें;
- लक्ष्य प्रस्तुति के मास्टर को लागू करें;
- लक्ष्य प्रस्तुति के विशिष्ट लेआउट को लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्य करें;
- क्लोन किए गए स्लाइड को एक सेक्शन में जोड़ें;
- कई प्रस्तुति को एक अंत‑से‑अंत वर्कफ़्लो में सुरक्षित रूप से मर्ज करें;
- मास्टर, रिसोर्स, नोट्स, टिप्पणियां, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइल और मल्टीथ्रेडिंग संबंधी मामलों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश हिस्सा अपने लेआउट और मास्टर से विरासत में प्राप्त करता है। इसलिए, आप जिस क्लोन ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड को लक्ष्य प्रस्तुति में कैसे एकीकृत किया जाएगा।

इनमें से किसी एक तरीके से [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) का उपयोग करें:

- `add_clone(source_slide)` — स्रोत स्लाइड का लेआउट और फॉर्मेटिंग बनाए रखें। यदि आवश्यक हो, तो स्रोत मास्टर को स्वचालित रूप से लक्ष्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि समान स्रोत मास्टर वाले दोहराए गए स्लाइड्स लगातार क्लोन न हों।
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — क्लोन किए गए स्लाइड को एक विशिष्ट लक्ष्य [IMasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट टाइप या नाम से मेल खाने वाले लेआउट की तलाश करता है।
- `add_clone(source_slide, destination_layout)` — क्लोन किए गए स्लाइड को सीधे एक विशिष्ट लक्ष्य [ILayoutSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilayoutslide/) से जोड़ें।

`add_clone` ओवरलोड को पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फॉर्मेटिंग बनाए रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से हर स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त है जब आयातित स्लाइड को अपने मूल थीम, मास्टर और लेआउट संबंधों को बनाए रखना हो।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और लक्ष्य अलग‑अलग डिज़ाइन उपयोग कर रहे हों। यह तब अपेक्षित है जब स्रोत फॉर्मेटिंग जानबूझकर संरक्षित की जाती है।

## **चयनित स्लाइड को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल स्रोत प्रस्तुति से चयनित स्लाइड इंडेक्स को आयात करता है।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने वाले स्लाइड इंडेक्स को क्लोन करने से पहले सत्यापित करें।

## **लक्ष्य मास्टर का उपयोग करके स्लाइड मर्ज करें**

जब आयातित स्लाइड को लक्ष्य प्रस्तुति के मौज़ूद मास्टर का पालन करना चाहिए, तो [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) ओवरलोड का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides निर्दिष्ट मास्टर के तहत उपयुक्त लेआउट का चयन स्रोत लेआउट के टाइप या नाम से मेल करके करता है। यदि उपयुक्त लेआउट मौजूद नहीं है और `allow_clone_missing_layout` `True` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड को जोड़ा जा सके। यदि यह `False` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxeditexception/) उत्पन्न होगा।

`False` का उपयोग तब करें जब आप मर्ज को विफल करना चाहते हैं न कि लक्ष्य मास्टर में अतिरिक्त लेआउट जोड़ना।

## **विशिष्ट लक्ष्य लेआउट का उपयोग करके स्लाइड मर्ज करें**

जब आप ठीक जानते हैं कि आयातित स्लाइड को कौन-सा लक्ष्य लेआउट उपयोग करना चाहिए, तो [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) ओवरलोड का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

लक्ष्य लेआउट को लागू करने से विरासत में मिला हुआ लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट की प्लेसहोल्डर संरचनाएं अलग हैं, तो परिणाम की जाँच करें ताकि विरासत में मिला फॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हो।

## **विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री नए कैनवास के अनुरूप स्वतः पुनः डिज़ाइन नहीं होती। परिणामस्वरूप आकार बदलने, स्थान बदलने या स्लाइड के दृश्य क्षेत्र से बाहर जाने की संभावना रहती है।

व्यावहारिक रूप से पहले स्रोत प्रस्तुति को रिसाइज़ करना उचित है। [SlideSize.set_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/set_size/) मेथड मौजूदा सामग्री को स्केल करता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार के भीतर फिट करने के लिए स्केल करता है।

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

रिसाइज़ करने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको मूल स्रोत प्रस्तुति को अन्य ऑपरेशनों के लिए अपरिवर्तित रखना है, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **प्रेज़ेंटेशन सेक्शन में स्लाइड मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः उत्पन्न नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएँ या चुनें और स्लाइड को स्पष्ट रूप से [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) के साथ उनमें क्लोन करें।

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

क्लोन किए गए स्लाइड निर्दिष्ट लक्ष्य सेक्शन में जोड़े जाते हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, लक्ष्य में उन सेक्शनों को [SectionCollection.append_empty_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/append_empty_section/) के साथ पुनः बनाएँ और प्रत्येक स्रोत स्लाइड को उचित लक्ष्य सेक्शन से मैप करें।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंत‑से‑अंत उदाहरण पहले प्रस्तुति को लक्ष्य के रूप में लेता है, प्रत्येक अतिरिक्त स्रोत के स्लाइड आकार को सामान्य करता है, प्रत्येक स्रोत को केवल कॉपी के दौरान खुला रखता है, और अंत में फाइल को सहेजता है।

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

यह आयातित स्लाइड के स्रोत फॉर्मेटिंग को बनाए रखने के लिए एक उपयोगी बेसलाइन है। यदि आपका आउटपुट एकल लक्ष्य थीम का उपयोग करना चाहिए, तो सरल `add_clone(slide)` कॉल को पहले दिखाए गए उचित लक्ष्य‑मास्टर या लक्ष्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से ला सकता है। Aspose.Slides दोहराए गए मास्टर को लगातार क्लोन करने से बचने के लिए स्वचालित क्लोन किए गए मास्टर का एक आंतरिक रजिस्ट्री रखता है। मैनुअली क्लोन किए गए मास्टर उस रजिस्ट्री में नहीं होते, इसलिए स्पष्ट नियंत्रण की आवश्यकता नहीं होने तक पहले से मास्टर क्लोन न करें।

दो मास्टर या लेआउट के समान नाम होने पर यह मत मानें कि वे दृश्य रूप से समान हैं। यदि कॉरपोरेट टेम्पलेट को अंतिम रूप से नियंत्रित करना है, तो लक्ष्य मास्टर या लेआउट को स्पष्ट रूप से चुनें और मर्ज के बाद परिणाम सत्यापित करें।

### **नोट्स और टिप्पणियां**

स्पीकर नोट्स और स्लाइड टिप्पणियां स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी होती हैं। Aspose.Slides [presentation notes](https://docs.aspose.com/slides/hi/python-net/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/python-net/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति को सत्यापित करें क्योंकि नोट्स मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों के बीच भिन्न हो सकते हैं। समीक्षा वर्कफ़्लो में विभिन्न लेखकों या टेम्पलेट्स से फाइलें मिलाने के बाद टिप्पणी लेखकों और थ्रेडेड टिप्पणियों की जाँच भी आवश्यक है।

### **छवि, ऑडियो, वीडियो, OLE ऑब्जेक्ट और बाहरी लिंक**

स्लाइड प्रस्तुति‑स्तर के रिसोर्स जैसे छवियां, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा का संदर्भ दे सकते हैं। केवल दृश्य आकारों को कॉपी न करके पूरे स्लाइड को क्लोन करें ताकि Aspose.Slides उसके रिसोर्स संबंधों को बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्स को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। लिंक्ड रिसोर्स पाथ और URL को उस वातावरण में टेस्ट करें जहाँ मर्ज की गई प्रस्तुति खुली जाएगी।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह सामान्य गारंटी नहीं है कि असंबंधित स्रोत प्रस्तुतियों से समान बायनरी रिसोर्स हमेशा डिडुप्लिकेट हो जाएंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज किए गए पैकेज का निरीक्षण करें और परिणाम मापें बजाय इम्प्लिसिट डिडुप्लीकेशन पर भरोसा करने के।

### **एम्बेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों पर समान रहना चाहिए, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि आवश्यक सभी फ़ॉन्ट लक्ष्य वातावरण में उपलब्ध होंगे। आप [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) से एम्बेडेड फ़ॉन्ट देख सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/python-net/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

यह भी सत्यापित करें कि स्रोत फ़ाइलों में उपयोग किए गए फ़ॉन्ट को एम्बेड करने की अनुमति है या नहीं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियां**

पासवर्ड‑सुरक्षित स्रोत को पहले सफलतापूर्वक खोलना आवश्यक है, फिर उसके स्लाइड को क्लोन किया जा सकता है। पासवर्ड को [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) के माध्यम से पास करें।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

एन्क्रिप्टेड स्रोत को खोलने से लक्ष्य प्रस्तुति पर वही सुरक्षा स्वतः लागू नहीं होती। आवश्यकता पड़ने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियां और मेमोरी उपयोग**

उच्च‑रेज़ोल्यूशन छवियों, ऑडियो, वीडियो या अन्य बड़े बायनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियां काफी मेमोरी उपयोग कर सकती हैं। [LoadOptions.blob_management_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/blob_management_options/) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए [Manage Presentation BLOBs](https://docs.aspose.com/slides/hi/python-net/manage-blob/) देखें।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करना पसंद करें, प्रत्येक स्रोत प्रस्तुति को मर्ज होने के तुरंत बाद बंद करें, और कार्यप्रवाह में चेकपॉइंट की आवश्यकता न हो तो मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें। `with slides.Presentation(...)` का उपयोग करने से कॉन्टेक्स्ट समाप्त होने पर प्रस्तुति रिसोर्स रिलीज़ हो जाते हैं।

### **थ्रेड सुरक्षा**

एक ही समय में कई थ्रेड से एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को लोड, सहेज या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन को सिंगल‑थ्रेडेड रखें। यदि आप स्वतंत्र मर्ज जॉब को पैरललाइज़ करना चाहते हैं, तो अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस और स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें जैसा कि [Aspose.Slides मल्टीथ्रेडिंग मार्गदर्शन](https://docs.aspose.com/slides/hi/python-net/multithreading/) में बताया गया है।

## **बार‑बार पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन को कैसे बरकरार रखूँ?**

`add_clone(source_slide)` को बिना लक्ष्य मास्टर या लेआउट के पास किए उपयोग करें। Aspose.Slides आयातित स्लाइड द्वारा आवश्यक होने पर स्रोत मास्टर को स्वचालित रूप से क्लोन कर सकता है।

**आयातित स्लाइड को लक्ष्य थीम का उपयोग कैसे कराऊँ?**

ऐसे ओवरलोड का उपयोग करें जो लक्ष्य मास्टर स्वीकार करता है। लक्ष्य प्रस्तुति के मास्टर को पास करें, स्रोत का नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**कब मुझे लक्ष्य मास्टर के बजाय विशिष्ट लक्ष्य लेआउट का उपयोग करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो, तो विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट टाइप या नाम के आधार पर उस मास्टर के लेआउट में से चुनें, तो मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियां मर्ज की जा सकती हैं?**

हां, लेकिन स्लाइड सामग्री को लक्ष्य आयामों के अनुसार स्वतः पुनः डिज़ाइन नहीं किया जाता। पूर्व में [SlideSize.set_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/set_size/) और [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesizescaletype/) के साथ स्रोत प्रस्तुति को रिसाइज़ करके पूर्वानुमानित प्लेसमेंट प्राप्त करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड को एक ही लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि प्रस्तुति फ़ॉर्मेट में फीचर सेट समान नहीं हो सकता, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की जाँच करें। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/python-net/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

केवल स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। लक्ष्य में आवश्यक सेक्शन को पुनः बनाएं और जब सेक्शन संरचना को बनाए रखना हो तो [add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और टिप्पणियां संरक्षित रहती हैं?**

वे क्लोन किए गए स्लाइड के साथ कॉपी हो जाती हैं। यदि नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों या थ्रेडेड समीक्षात्मक डेटा पर निर्भर वर्कफ़्लो है, तो मर्ज परिणाम को सत्यापित करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर की संरचनाओं के साथ स्लाइड‑स्तर की सामग्री को भी शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन किए गए स्लाइड के रिसोर्स रिलेशनशिप के हिस्से के रूप में ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए उनके लक्ष्य फ़ाइल या URL को मर्ज के बाद भी उपलब्ध रखना आवश्यक है।

**क्या सभी स्रोतों से एम्बेडेड फ़ॉन्ट मर्ज की गई प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग अकेले फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देती। लक्ष्य के एम्बेडेड फ़ॉन्ट की जाँच करें और टाइपोग्राफी महत्वपूर्ण हो तो फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.password](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/password/) के साथ इसे खोलें, फिर सामान्य रूप से उसके स्लाइड को क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बड़ी प्रस्तुतियों को कैसे संभालूँ?**

बड़े बाइनरी ऑब्जेक्ट के कारण मेमोरी उपयोग प्रमुख होता है, इसलिए BLOB मैनेजमेंट उपयोग करें, बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोड करना प्राथमिकता दें, स्रोत प्रस्तुतियों को शीघ्र बंद करें, और अंतिम परिणाम को केवल आवश्यक होने पर ही सहेजें।

**क्या मैं कई थ्रेड से स्लाइड मर्ज कर सकता हूँ?**

एक ही समय में कई थ्रेड से [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस को लोड, सहेज या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन सिंगल‑थ्रेडेड रखें; यदि आपको अलग‑अलग मर्ज कार्यों को समानांतर चलाना है, तो अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस और स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें।