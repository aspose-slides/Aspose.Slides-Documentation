---
title: Python में PPT, PPTX और ODP को JPG में परिवर्तित करें
linktitle: स्लाइड्स को JPG छवियों में परिवर्तित करें
type: docs
weight: 60
url: /hi/python-net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint को JPG में परिवर्तित करें
- प्रस्तुति को JPG में परिवर्तित करें
- स्लाइड को JPG में परिवर्तित करें
- PPT को JPG में परिवर्तित करें
- PPTX को JPG में परिवर्तित करें
- ODP को JPG में परिवर्तित करें
- PowerPoint से JPG
- प्रस्तुति से JPG
- स्लाइड से JPG
- PPT से JPG
- PPTX से JPG
- ODP से JPG
- PowerPoint को JPEG में परिवर्तित करें
- प्रस्तुति को JPEG में परिवर्तित करें
- स्लाइड को JPEG में परिवर्तित करें
- PPT को JPEG में परिवर्तित करें
- PPTX को JPEG में परिवर्तित करें
- ODP को JPEG में परिवर्तित करें
- PowerPoint से JPEG
- प्रस्तुति से JPEG
- स्लाइड से JPEG
- PPT से JPEG
- PPTX से JPEG
- ODP से JPEG
- Python
- Aspose.Slides
description: "Python में कुछ ही पंक्तियों के कोड से PowerPoint और OpenDocument प्रस्तुतियों की स्लाइड्स को उच्च गुणवत्ता वाली JPEG छवियों में परिवर्तित करना सीखें। वेब उपयोग, साझा करने और संग्रहण के लिए प्रस्तुतियों को अनुकूलित करें। पूरी गाइड अभी पढ़ें!"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में परिवर्तित करना स्लाइड्स को साझा करने, प्रदर्शन को अनुकूलित करने, और सामग्री को वेबसाइटों या अनुप्रयोगों में संलग्न करने में मदद करता है। Aspose.Slides for Python आपको PPTX, PPT और ODP फ़ाइलों को उच्च गुणवत्ता वाली JPEG छवियों में बदलने की अनुमति देता है। यह मार्गदर्शिका रूपांतरण के विभिन्न तरीकों को समझाती है।

इन सुविधाओं के साथ, अपना स्वयं का प्रस्तुति व्यूअर लागू करना और प्रत्येक स्लाइड के लिए एक थंबनेल बनाना आसान है। यह उपयोगी हो सकता है यदि आप प्रस्तुति स्लाइड्स को कॉपी से बचाना चाहते हैं या उन्हें केवल-रीड मोड में प्रदर्शित करना चाहते हैं। Aspose.Slides आपको संपूर्ण प्रस्तुति या किसी विशिष्ट स्लाइड को छवि स्वरूपों में बदलने की अनुमति देता है।

## **प्रस्तुति स्लाइड्स को JPG छवियों में बदलें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) संग्रह से [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) प्रकार का स्लाइड ऑब्जेक्ट प्राप्त करें।
1. स्लाइड की छवि बनाने के लिए [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#float-float) मेथड का उपयोग करें।
1. [IImage.save(filename, format)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/save/#str-imageformat) मेथड को इमेज ऑब्जेक्ट पर कॉल करें। आउटपुट फ़ाइल नाम और इमेज फ़ॉर्मेट को तर्कों के रूप में पास करें।

{{% alert color="primary" %}}

**नोट:** PPT, PPTX, या ODP से JPG रूपांतरण Aspose.Slides Python API में अन्य स्वरूपों के रूपांतरण से अलग होता है। अन्य स्वरूपों के लिए, आप सामान्यतः [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिए, आपको [IImage.save(filename, format)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/save/#str-imageformat) मेथड का उपयोग करना होगा।

{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # इमेज को डिस्क पर JPEG फ़ॉर्मेट में सहेजें।
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **कस्टमाइज़्ड आयामों के साथ स्लाइड्स को JPG में परिवर्तित करें**

परिणामी JPG छवियों के आयाम बदलने के लिए, आप [Slide.get_image(image_size)](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) मेथड में इसे पास करके इमेज आकार सेट कर सकते हैं। यह आपको विशिष्ट चौड़ाई और ऊँचाई मानों के साथ छवियों को उत्पन्न करने की सुविधा देता है, जिससे आउटपुट आपकी रिज़ॉल्यूशन और आस्पेक्ट अनुपात आवश्यकताओं को पूरा करता है। यह लचीलापन विशेष रूप से वेब अनुप्रयोगों, रिपोर्टों या दस्तावेज़ों के लिए छवियों को उत्पन्न करते समय उपयोगी है, जहाँ सटीक इमेज आयाम आवश्यक होते हैं।

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # निर्दिष्ट आकार की स्लाइड छवि बनाएं।
        with slide.get_image(image_size) as thumbnail:
            # इमेज को डिस्क पर JPEG फ़ॉर्मेट में सहेजें।
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **स्लाइड्स को छवियों के रूप में सेव करते समय टिप्पणियों को रेंडर करें**

Aspose.Slides for Python एक सुविधा प्रदान करता है जो आपको प्रस्तुति स्लाइड्स पर टिप्पणियों को JPG छवियों में परिवर्तित करते समय रेंडर करने की अनुमति देता है। यह कार्यक्षमता विशेष रूप से PowerPoint प्रस्तुतियों में सहयोगियों द्वारा जोड़े गए एनोटेशन, फीडबैक या चर्चा को संरक्षित रखने में उपयोगी है। इस विकल्प को सक्षम करके, आप सुनिश्चित करते हैं कि टिप्पणियाँ उत्पन्न छवियों में दिखें, जिससे मूल प्रस्तुति फ़ाइल को खोले बिना फीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास एक प्रस्तुति फ़ाइल "sample.pptx" है, जिसमें एक स्लाइड पर टिप्पणियाँ हैं:

![टिप्पणियों के साथ स्लाइड](slide_with_comments.png)

निम्नलिखित Python कोड स्लाइड को JPG छवि में परिवर्तित करता है जबकि टिप्पणियों को संरक्षित रखता है:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # स्लाइड टिप्पणियों के विकल्प सेट करें।
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # पहली स्लाइड को छवि में बदलें।
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

परिणाम:

![टिप्पणियों के साथ JPG छवि](image_with_comments.png)

## **संबंधित देखें**

- [PowerPoint को GIF में परिवर्तित करें](/slides/hi/python-net/convert-powerpoint-to-animated-gif/)
- [PowerPoint को PNG में परिवर्तित करें](/slides/hi/python-net/convert-powerpoint-to-png/)
- [PowerPoint को TIFF में परिवर्तित करें](/slides/hi/python-net/convert-powerpoint-to-tiff/)
- [PowerPoint को SVG में परिवर्तित करें](/slides/hi/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides PowerPoint को JPG छवियों में कैसे परिवर्तित करता है, यह देखने के लिए, इन मुफ्त ऑनलाइन कन्वर्टर्स को आज़माएँ: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT to JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)। 

{{% /alert %}} 

![नि:शुल्क ऑनलाइन PPTX से JPG कनवर्टर](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके, आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG छवियों को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके, आप एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवियों को परिवर्तित कर सकते हैं। अधिक जानकारी के लिए, इन पृष्ठों को देखें: परिवर्तित करें [छवि को JPG में](https://products.aspose.com/slides/hi/python-net/conversion/image-to-jpg/); परिवर्तित करें [JPG को छवि में](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-image/); परिवर्तित करें [JPG को PNG में](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-png/), परिवर्तित करें [PNG को JPG में](https://products.aspose.com/slides/hi/python-net/conversion/png-to-jpg/); परिवर्तित करें [PNG को SVG में](https://products.aspose.com/slides/hi/python-net/conversion/png-to-svg/), परिवर्तित करें [SVG को PNG में](https://products.aspose.com/slides/hi/python-net/conversion/svg-to-png/)।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह विधि बैच रूपांतरण का समर्थन करती है?**

हाँ, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूपांतरण की अनुमति देता है।

**क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल वस्तुओं का समर्थन करता है?**

हाँ, Aspose.Slides सभी सामग्री, सहित SmartArt, चार्ट, तालिका, आकार आदि को रेंडर करता है। हालांकि, रेंडरिंग सटीकता PowerPoint की तुलना में थोड़ा भिन्न हो सकती है, विशेषकर कस्टम या गायब फ़ॉन्ट का उपयोग करने पर।

**क्या प्रक्रिया की जा सकने वाली स्लाइड्स की संख्या पर कोई सीमा है?**

Aspose.Slides स्वयं प्रक्रिया की जा सकने वाली स्लाइड्स की संख्या पर कोई कड़ी सीमा नहीं लगाता। हालांकि, बड़े प्रस्तुतियों या उच्च-रिज़ॉल्यूशन छवियों के साथ काम करते समय आपको मेमोरी समाप्ति त्रुटि का सामना करना पड़ सकता है।