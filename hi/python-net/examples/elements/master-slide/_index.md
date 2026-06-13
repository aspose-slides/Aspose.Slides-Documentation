---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/python-net/examples/elements/master-slide/
keywords:
- मास्टर स्लाइड
- मास्टर स्लाइड जोड़ें
- मास्टर स्लाइड तक पहुँचें
- मास्टर स्लाइड हटाएँ
- अनुपयोगी मास्टर स्लाइड
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में मास्टर स्लाइड्स का प्रबंधन: स्लाइड्स बनाना, संपादन, क्लोन करना और थीम, बैकग्राउंड, प्लेसहोल्डर को फ़ॉर्मेट करना ताकि PowerPoint और OpenDocument में स्लाइड्स को एकसाथ रखा जा सके।"
---
मास्टर स्लाइड्स PowerPoint में स्लाइड इनहेरिटेंस पदानुक्रम के शीर्ष स्तर का गठन करती हैं। एक **मास्टर स्लाइड** बैकग्राउंड, लोगो, और टेक्स्ट फ़ॉर्मेटिंग जैसे सामान्य डिज़ाइन तत्वों को परिभाषित करती है। **लेआउट स्लाइड्स** मास्टर स्लाइड्स से विरासत में मिलती हैं, और **नॉर्मल स्लाइड्स** लेआउट स्लाइड्स से विरासत में मिलती हैं।

यह लेख Aspose.Slides for Python via .NET का उपयोग करके मास्टर स्लाइड्स को बनाने, संशोधित करने और प्रबंधित करने का तरीका दर्शाता है।

## **मास्टर स्लाइड जोड़ें**

यह उदाहरण दिखाता है कि डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करके नई मास्टर स्लाईड कैसे बनाई जाए।

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें।
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **टिप 1:** मास्टर स्लाइड्स सभी स्लाइड्स में स्थिर ब्रांडिंग या साझा डिज़ाइन तत्वों को लागू करने का तरीका प्रदान करती हैं। मास्टर में किए गए किसी भी परिवर्तन का स्वचालित रूप से निर्भर लेआउट और नॉर्मल स्लाइड्स पर प्रतिबिंबित होगा।

> 💡 **टिप 2:** मास्टर स्लाइड में जोड़े गए कोई भी आकार या फॉर्मेटिंग लेआउट स्लाइड्स द्वारा विरासत में मिलती है और बदले में, उन लेआउट्स का उपयोग करने वाली सभी नॉर्मल स्लाइड्स में भी।  
> नीचे की छवि दर्शाती है कि कैसे मास्टर स्लाइड में जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वचालित रूप से रेंडर होता है।

![मास्टर इनहेरिटेंस उदाहरण](master-slide-banner.png)

## **मास्टर स्लाइड तक पहुँचें**

`Presentation.masters` संग्रह का उपयोग करके आप मास्टर स्लाइड्स तक पहुँच सकते हैं। यहाँ बताया गया है कि उन्हें कैसे प्राप्त करें और उनके साथ काम करें:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # पहली मास्टर स्लाइड तक पहुँचें।
        first_master_slide = presentation.masters[0]
```

## **मास्टर स्लाइड हटाएँ**

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # इंडेक्स द्वारा हटाएं।
        presentation.masters.remove_at(0)

        # या रेफ़रेंस द्वारा हटाएं।
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कुछ प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो उपयोग में नहीं हैं। इन स्लाइड्स को हटाने से फ़ाइल आकार कम करने में मदद मिल सकती है।

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # सभी अप्रयुक्त मास्टर स्लाइड्स हटाएँ (भले ही वे Preserve के रूप में चिह्नित हों)।
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **टिप:** अनउपयोगी मास्टर स्लाइड्स को साफ़ करने और प्रस्तुति के आकार को न्यूनतम करने के लिए `remove_unused(True)` का उपयोग करें।