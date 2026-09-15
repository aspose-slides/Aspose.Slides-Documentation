---
title: Aspose.Slides for Python via Java में मल्टीथ्रेडिंग
linktitle: मल्टीथ्रेडिंग
type: docs
weight: 310
url: /hi/python-java/multithreading/
keywords:
- मल्टीथ्रेडिंग
- एकाधिक थ्रेड्स
- समांतर कार्य
- स्लाइड्स को बदलें
- स्लाइड्स से छवियां
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java की मल्टीथ्रेडिंग PowerPoint और OpenDocument प्रसंस्करण को तेज़ बनाती है। कुशल प्रस्तुति कार्यप्रवाहों के लिए सर्वश्रेष्ठ प्रथाओं की खोज करें।"
---
## **परिचय**

हालाँकि प्रस्तुतियों के साथ समानांतर कार्य (पार्सिंग, लोडिंग और क्लोनिंग को छोड़कर) संभव है और आमतौर पर ठीक से काम करता है, लेकिन लाइब्रेरी को कई थ्रेड्स में उपयोग करने पर गलत परिणामों की थोड़ी संभावना रहती है।

हम दृढ़ता से सलाह देते हैं कि आप मल्टीथ्रेडेड परिवेश में **एक ही** [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) उदाहरण **का उपयोग न करें**, क्योंकि इससे अप्रत्याशित त्रुटियां या विफलताएँ हो सकती हैं जो आसानी से पता नहीं चल पातीं।

कई थ्रेड्स में एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) उदाहरण को लोड, सेव या/और क्लोन करना **सुरक्षित नहीं** है। ऐसे संचालन **समर्थित नहीं** हैं। यदि आपको ऐसे कार्य करने की आवश्यकता है, तो आपको कई एकल‑थ्रेडेड प्रक्रियाओं का उपयोग करके संचालन को समानांतर करना होगा—और प्रत्येक प्रक्रिया को अपना स्वयं का प्रस्तुति उदाहरण उपयोग करना चाहिए।

## **समांतर रूप से प्रस्तुति स्लाइड्स को छवियों में बदलें**

मान लीजिए हम PowerPoint प्रस्तुति की सभी स्लाइड्स को PNG छवियों में समांतर रूप से बदलना चाहते हैं। चूँकि कई थ्रेड्स में एक ही [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) उदाहरण का उपयोग असुरक्षित है, हम प्रस्तुति स्लाइड्स को अलग-अलग प्रस्तुतियों में विभाजित करते हैं और प्रत्येक प्रस्तुति को अलग थ्रेड में छवियों में बदलते हैं। निम्नलिखित कोड उदाहरण यह दर्शाता है कि इसे कैसे किया जाए।

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # स्लाइड को एक अलग प्रस्तुति में निकालें।
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # स्लाइड को एक अलग कार्य में छवि में बदलें।
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # सभी कार्यों के पूर्ण होने की प्रतीक्षा करें।
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे हर थ्रेड में लाइसेंस सेटअप को कॉल करना चाहिए?**

नहीं। थ्रेड्स शुरू होने से पहले प्रक्रिया के लिए इसे एक बार करना पर्याप्त है। यदि [license setup](/slides/hi/python-java/licensing/) को समानांतर रूप से बुलाया जा सकता है (उदाहरण के लिए, लेज़ी इनिशियलाइज़ेशन के दौरान), तो उस कॉल को समन्वयित करें क्योंकि लाइसेंस सेटअप मेथड स्वयं थ्रेड‑सेफ नहीं है।

**क्या मैं थ्रेड्स के बीच [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) या [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) ऑब्जेक्ट्स पास कर सकता हूँ?**

"जीवंत" प्रस्तुति ऑब्जेक्ट्स को थ्रेड्स के बीच पास करना अनुशंसित नहीं है: प्रत्येक थ्रेड के लिए स्वतंत्र उदाहरण उपयोग करें या प्रत्येक थ्रेड के लिए अलग प्रस्तुतियों या स्लाइड कंटेनरों को पहले से बनायें। यह दृष्टिकोण एकल प्रस्तुति उदाहरण को थ्रेड्स में साझा न करने की सामान्य सिफारिश के अनुरूप है।

**क्या प्रत्येक थ्रेड के पास अपना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) उदाहरण होने पर विभिन्न फॉर्मेट्स (PDF, HTML, छवियों) में निर्यात को समानांतर करना सुरक्षित है?**

हां। स्वतंत्र उदाहरणों और अलग आउटपुट पाथ्स के साथ, ऐसे कार्य आमतौर पर सही ढंग से समानांतर होते हैं; किसी भी साझा प्रस्तुति ऑब्जेक्ट और साझा I/O स्ट्रीम से बचें।

**मल्टीथ्रेडिंग में ग्लोबल फ़ॉन्ट सेटिंग्स (फ़ोल्डर, सब्स्टिट्यूशन) के साथ मुझे क्या करना चाहिए?**

थ्रेड्स शुरू करने से पहले सभी ग्लोबल [font settings](/slides/hi/python-java/powerpoint-fonts/) को इनिशियलाइज़ करें और समानांतर कार्य के दौरान उन्हें बदलें नहीं। यह साझा फ़ॉन्ट संसाधनों तक पहुंचते समय होने वाली रेस कंडीशन को समाप्त करता है।