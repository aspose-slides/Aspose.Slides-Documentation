---
title: Aspose.Slides for Python में मल्टीथ्रेडिंग
linktitle: मल्टीथ्रेडिंग
type: docs
weight: 200
url: /hi/python-net/multithreading/
keywords:
- मल्टीथ्रेडिंग
- एकाधिक थ्रेड्स
- समानांतर कार्य
- स्लाइड्स रूपांतरित करें
- स्लाइड्स को छवियों में
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python द्वारा .NET मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रोसेसिंग को तेज़ बनाता है। कुशल प्रस्तुति कार्यप्रवाहों के लिए सर्वोत्तम प्रथाएँ खोजें।"
---
## **परिचय**

जबकि प्रस्तुतियों के साथ समानांतर कार्य (पार्सिंग/लोडिंग/क्लोनिंग के अलावा) संभव है और अधिकांश समय सब ठीक चलता है, लेकिन लाइब्रेरी को कई थ्रेड्स में उपयोग करने पर गलत परिणाम मिलने की थोड़ी संभावना रहती है।

हम दृढ़ता से सलाह देते हैं कि आप मल्टी-थ्रेडिंग पर्यावरण में एक ही [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस का उपयोग **न** करें क्योंकि इससे अप्रत्याशित त्रुटियाँ या विफलताएँ हो सकती हैं जिन्हें आसानी से पता नहीं लगाया जा सकता।

कई थ्रेड्स में एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस को लोड, सहेजना और/या क्लोन करना **सुरक्षित नहीं** है। ऐसे ऑपरेशन्स **समर्थित** नहीं हैं। यदि आपको ऐसे कार्य करने की आवश्यकता है, तो आपको कई सिंगल-थ्रेडेड प्रक्रियाओं का उपयोग करके ऑपरेशन्स को समानांतर करना होगा—और इन प्रक्रियाओं में से प्रत्येक को अपनी खुद की प्रस्तुति इंस्टेंस उपयोग करनी चाहिए।

## **समानांतर रूप से प्रस्तुति स्लाइड्स को छवियों में बदलना**

मान लीजिए हम सभी स्लाइड्स को एक PowerPoint प्रस्तुति से PNG छवियों में समानांतर रूप से बदलना चाहते हैं। क्योंकि कई थ्रेड्स में एक ही `Presentation` इंस्टेंस का उपयोग असुरक्षित है, हम प्रस्तुति स्लाइड्स को अलग-अलग प्रस्तुतियों में विभाजित करते हैं और प्रत्येक प्रस्तुति को अलग थ्रेड में उपयोग करके स्लाइड्स को छवियों में समानांतर रूप से बदलते हैं। निम्नलिखित कोड उदाहरण दिखाता है कि इसे कैसे किया जाए।

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # स्लाइड i को एक अलग प्रस्तुति में निकालें।
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # स्लाइड को छवि में बदलें।
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# सभी कार्यों के पूरा होने की प्रतीक्षा करें।
for task in conversion_tasks:
    task.result()

del presentation
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे प्रत्येक थ्रेड में लाइसेंस सेटअप कॉल करना आवश्यक है?**

नहीं। थ्रेड्स शुरू होने से पहले प्रक्रिया/ऐप डोमेन में एक बार यह करने से पर्याप्त है। यदि [license setup](/slides/hi/python-net/licensing/) को एक साथ बुलाया जा सकता है (उदाहरण के लिए, लेज़ी इनिशियलाइज़ेशन के दौरान), तो उस कॉल को सिंक्रोनाइज़ करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड-सेफ़ नहीं है।

**क्या मैं `Presentation` या `Slide` ऑब्जेक्ट्स को थ्रेड्स के बीच पास कर सकता हूँ?**

थ्रेड्स के बीच 'लाइव' प्रस्तुति ऑब्जेक्ट्स को पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र इंस्टेंस उपयोग करें या प्रत्येक थ्रेड के लिए अलग प्रस्तुतियां/स्लाइड कंटेनर पहले से बनाएं। यह तरीका सामान्य सिफारिश का अनुसरण करता है कि कई थ्रेड्स में एक ही प्रस्तुति इंस्टेंस साझा न करें।

**क्या प्रत्येक थ्रेड के पास अपना `Presentation` इंस्टेंस हो तो विभिन्न फ़ॉर्मैट (PDF, HTML, छवियों) में निर्यात को समानांतर करना सुरक्षित है?**

हाँ। स्वतंत्र इंस्टेंस और अलग आउटपुट पाथ के साथ, ऐसे कार्य सामान्यतः सही तरीके से समानांतर होते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम से बचें।

**मल्टीथ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर्स, प्रतिस्थापन) के साथ मुझे क्या करना चाहिए?**

थ्रेड्स शुरू करने से पहले सभी ग्लोबल फ़ॉन्ट सेटिंग्स को इनिशियलाइज़ करें और समानांतर कार्य के दौरान उन्हें न बदलें। इससे साझा फ़ॉन्ट संसाधनों तक पहुँचने पर होने वाले रेस समाप्त हो जाते हैं।