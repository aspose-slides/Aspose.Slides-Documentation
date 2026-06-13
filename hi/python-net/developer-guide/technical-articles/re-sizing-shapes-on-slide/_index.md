---
title: Python के साथ प्रस्तुतियों में आकार बदलें
linktitle: आकार बदलना
type: docs
weight: 130
url: /hi/python-net/re-sizing-shapes-on-slide/
keywords:
- आकार बदलना
- आकार का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स पर आकार आसानी से बदलें—स्लाइड लेआउट समायोजन को स्वचालित करें और उत्पादकता बढ़ाएँ।"
---
## **Overview**

Aspose.Slides for Python ग्राहकों के सबसे सामान्य प्रश्नों में से एक है कि कैसे आकारों को री‑साइज़ किया जाए ताकि जब स्लाइड का आकार बदलता है, डेटा कट न जाए। यह संक्षिप्त तकनीकी लेख दिखाता है कि यह कैसे किया जाए।

## **Resize Shapes**

स्लाइड का आकार बदलने पर आकारों के असँगत होने से बचने के लिए, प्रत्येक आकार की स्थिति और आयाम को अपडेट करें ताकि वे नई स्लाइड लेआउट के अनुरूप हो जाएँ।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("sample.pptx") as presentation:
    # मूल स्लाइड आकार प्राप्त करें।
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # मौजूदा आकारों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # नया स्लाइड आकार प्राप्त करें।
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # प्रत्येक स्लाइड पर आकारों को री-साइज़ और पुनःस्थापित करें।
    for slide in presentation.slides:
        for shape in slide.shapes:
            # आकार का आकार स्केल करें।
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # आकार की स्थिति को स्केल करें।
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

यदि स्लाइड में एक टेबल है, तो उपरोक्त कोड सही से काम नहीं करेगा। उस स्थिति में टेबल की प्रत्येक सेल को री‑साइज़ करना आवश्यक है।

{{% /alert %}} 

टेबल वाली स्लाइड्स को री‑साइज़ करने के लिए अपने अंत में नीचे दिया गया कोड उपयोग करें। टेबल के लिए चौड़ाई या ऊँचाई सेट करना एक विशेष केस है: आपको टेबल के कुल आकार को बदलने हेतु व्यक्तिगत पंक्तियों की ऊँचाई और कॉलम की चौड़ाई को समायोजित करना होगा।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # मूल स्लाइड आकार प्राप्त करें।
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # मौजूदा आकारों को स्केल किए बिना स्लाइड आकार बदलें।
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # नया स्लाइड आकार प्राप्त करें।
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # आकार के आकार को स्केल करें।
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # आकार की स्थिति को स्केल करें।
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # आकार के आकार को स्केल करें।
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # आकार की स्थिति को स्केल करें।
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # आकार के आकार को स्केल करें।
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # आकार की स्थिति को स्केल करें।
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**  
जब स्लाइड को री‑साइज़ किया जाता है, तो आकार अपनी मूल स्थिति और आकार बनाए रखते हैं जब तक कि स्केल स्पष्ट रूप से नहीं बदला जाता। इससे सामग्री कट सकती है या आकार असँगत हो सकते हैं।

**Does the provided code work for all shape types?**  
बेसिक उदाहरण अधिकांश आकार प्रकारों (जैसे टेक्स्ट बॉक्स, इमेज, चार्ट आदि) के लिए काम करता है। हालांकि, टेबल के लिए आपको पंक्तियों और कॉलमों को अलग से संभालना होगा, क्योंकि टेबल की ऊँचाई और चौड़ाई व्यक्तिगत कोशिकाओं के आयामों से निर्धारित होती है।

**How do I resize tables when resizing a slide?**  
आपको टेबल की सभी पंक्तियों और कॉलमों पर लूप करना होगा और उनकी ऊँचाई तथा चौड़ाई को अनुपातिक रूप से री‑साइज़ करना होगा, जैसा कि दूसरे कोड उदाहरण में दिखाया गया है।

**Will this resizing work for master slides and layout slides?**  
हां, लेकिन आपको [Masters](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/masters/) और [Layout slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/layout_slides/) के माध्यम से भी लूप करना चाहिए और उनके आकारों पर समान स्केलिंग लॉजिक लागू करना चाहिए ताकि प्रस्तुति में स्थिरता बनी रहे।

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**  
हां। आप [presentation.slide_size.orientation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/islidesize/orientation/) का उपयोग करके अभिविन्यास बदल सकते हैं। सुनिश्चित करें कि आप लेआउट को बनाए रखने के लिए स्केलिंग लॉजिक उसी के अनुसार सेट करें।

**Is there a limit to the slide size I can set?**  
Aspose.Slides कस्टम आकारों का समर्थन करता है, लेकिन बहुत बड़े आकार प्रदर्शन या कुछ PowerPoint संस्करणों के साथ संगतता को प्रभावित कर सकते हैं।

**How can I prevent fixed aspect ratio shapes from becoming distorted?**  
आप स्केल करने से पहले shape की `aspect_ratio_locked` प्रॉपर्टी को जांच सकते हैं। यदि यह लॉक है, तो व्यक्तिगत रूप से स्केल करने के बजाय चौड़ाई या ऊँचाई को अनुपातिक रूप से समायोजित करें।