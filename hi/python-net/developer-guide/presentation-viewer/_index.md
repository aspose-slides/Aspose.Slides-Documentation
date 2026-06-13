---
title: "Python में प्रेज़ेंटेशन व्यूअर बनाएं"
linktitle: "प्रेज़ेंटेशन व्यूअर"
type: docs
weight: 50
url: /hi/python-net/presentation-viewer/
keywords:
- "प्रेज़ेंटेशन देखें"
- "प्रेज़ेंटेशन व्यूअर"
- "प्रेज़ेंटेशन व्यूअर बनाएं"
- "PPT देखें"
- "PPTX देखें"
- "ODP देखें"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके Python में एक कस्टम प्रेज़ेंटेशन व्यूअर बनाना सीखें। Microsoft PowerPoint या अन्य ऑफिस सॉफ़्टवेयर के बिना आसानी से PowerPoint (PPTX, PPT) और OpenDocument (ODP) फ़ाइलें प्रदर्शित करें।"
---
## **परिचय**

Aspose.Slides for Python का उपयोग स्लाइड वाले प्रेज़ेंटेशन फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइड्स को उदाहरण के तौर पर Microsoft PowerPoint में प्रेज़ेंटेशन खोलकर देखा जा सकता है। हालांकि, डेवलपर्स को कभी‑कभी अपने पसंदीदा इमेज व्यूअर में स्लाइड्स को इमेज के रूप में देखना या उन्हें कस्टम प्रेज़ेंटेशन व्यूअर में उपयोग करना पड़ सकता है। ऐसे मामलों में, Aspose.Slides आपको व्यक्तिगत स्लाइड्स को इमेज के रूप में निर्यात करने की सुविधा देता है। यह लेख बताता है कि यह कैसे किया जाए।

## **एक स्लाइड से SVG इमेज बनाना**

Aspose.Slides के साथ प्रेज़ेंटेशन स्लाइड से SVG इमेज बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [प्रेज़ेंटेशन](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. फ़ाइल स्ट्रीम खोलें।  
4. स्लाइड को SVG इमेज के रूप में फ़ाइल स्ट्रीम में सहेजें।

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **स्लाइड थंबनेल इमेज बनाएं**

Aspose.Slides आपको स्लाइड की थंबनेल इमेज बनाने में मदद करता है। Aspose.Slides का उपयोग करके स्लाइड की थंबनेल बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [प्रेज़ेंटेशन](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. संदर्भित स्लाइड का थंबनेल इमेज वांछित स्केल पर बनाएं।  
4. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **उपयोगकर्ता-परिभाषित आयामों के साथ स्लाइड थंबनेल बनाएं**

उपयोगकर्ता-परिभाषित आयामों के साथ स्लाइड थंबनेल इमेज बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [प्रेज़ेंटेशन](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
3. संदर्भित स्लाइड का थंबनेल इमेज निर्दिष्ट आयामों के साथ बनाएं।  
4. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ स्लाइड का थंबनेल बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/) क्लास का एक इंस्टेंस बनाएं।  
2. `RenderingOptions.slides_layout_options` प्रॉपर्टी का उपयोग करके स्पीकर नोट्स की स्थिति सेट करें।  
3. [प्रेज़ेंटेशन](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
4. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।  
5. रेंडरिंग विकल्पों का उपयोग करके संदर्भित स्लाइड का थंबनेल इमेज बनाएं।  
6. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **लाइव उदाहरण**

Aspose.Slides API के साथ आप क्या लागू कर सकते हैं, इसे देखने के लिए मुफ्त एप्लिकेशन [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) आज़माएँ:

[![ऑनलाइन पॉवरपॉइंट व्यूअर](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/hi/viewer/)

## **प्रश्नोत्तर**

**क्या मैं ASP.NET वेब एप्लिकेशन में प्रेज़ेंटेशन व्यूअर एम्बेड कर सकता हूँ?**

हाँ। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइड्स को [इमेजेज](/slides/hi/python-net/convert-powerpoint-to-png/) या [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) के रूप में रेंडर कर सकते हैं और ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम सुविधाओं को इंटरएक्टिव अनुभव के लिए जावास्क्रिप्ट के साथ लागू किया जा सकता है।

**कस्टम .NET व्यूअर में स्लाइड्स दिखाने का सर्वोत्तम तरीका क्या है?**

सिफारिश की गई विधि यह है कि प्रत्येक स्लाइड को एक [इमेज](/slides/hi/python-net/convert-powerpoint-to-png/) (उदा., PNG या SVG) के रूप में रेंडर करें या Aspose.Slides का उपयोग करके उसे [HTML](/slides/hi/python-net/convert-powerpoint-to-html/) में बदलें, फिर आउटपुट को पिक्चर बॉक्स (डेस्कटॉप के लिए) या HTML कंटेनर (वेब के लिए) के भीतर प्रदर्शित करें।

**बहुत सारी स्लाइड्स वाले बड़े प्रेज़ेंटेशन को कैसे संभालूँ?**

बड़े डेक के लिए, स्लाइड्स को लेज़ी-लोडिंग या ऑन‑डिमांड रेंडरिंग पर विचार करें। इसका मतलब है कि उपयोगकर्ता जब स्लाइड पर नेविगेट करे तभी उसकी सामग्री उत्पन्न करें, जिससे मेमोरी और लोड समय कम हो जाता है।