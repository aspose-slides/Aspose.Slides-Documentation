---
title: Python में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 41
url: /hi/python-net/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PPT, PPTX और ODP प्रस्तुतियों से स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य इमेज फ़ॉर्मैट्स में Python के साथ Aspose.Slides का उपयोग करके बदलें।"
---
## **परिचय**

Aspose.Slides for Python via .NET व्यक्तिगत स्लाइड्स को PowerPoint और OpenDocument प्रस्तुतियों से PNG, JPEG, GIF, TIFF, और अन्य इमेज फ़ॉर्मैट्स में रेंडर कर सकता है।

एक स्लाइड को इमेज में बदलने के लिए, निम्नलिखित चरणों का पालन करें:

1. प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास के साथ लोड करें।
2. जिस स्लाइड को आप रेंडर करना चाहते हैं, उसे चुनें।
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास के साथ कॉन्फ़िगर करें।
4. [Slide.get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/) मेथड को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) ऑब्जेक्ट लौटाता है।
5. [IImage.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/save/) मेथड को कॉल करें और आउटपुट फ़ॉर्मेट को एक [ImageFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imageformat/) वैल्यू से निर्दिष्ट करें।

## **स्लाइड को PNG इमेज में बदलें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। प्राप्त [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सेव किया जा सकता है।

निम्नलिखित Python उदाहरण प्रथम स्लाइड को रेंडर करता है और इसे PNG इमेज के रूप में सहेजता है:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **कस्टम साइज के साथ स्लाइड्स को इमेज में बदलें**

स्लाइड को सटीक पिक्सेल आयामों के साथ रेंडर करने के लिए, वह [Slide.get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) ओवरलोड उपयोग करें जो एक [Size](https://reference.aspose.com/slides/hi/python-net/aspose.pydrawing/size/) वैल्यू को स्वीकार करता है।

निम्नलिखित उदाहरण 1820 × 1040 JPEG इमेज बनाता है:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **नोट्स और कमेंट्स के साथ स्लाइड्स को इमेज में बदलें**

डिफ़ॉल्ट रूप से, स्लाइड इमेज में नोट्स या कमेंट्स शामिल नहीं होते हैं। नोट्स और कमेंट्स कहां दिखाई दें, इसे नियंत्रित करने के लिए एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) प्रॉपर्टी में असाइन करें।

निम्नलिखित उदाहरण ट्रंकेटेड नोट्स को स्लाइड के नीचे और कमेंट्स को दाईं ओर रखता है:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
स्लाइड-से-इमेज रूपांतरण के लिए, [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) प्रॉपर्टी को [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notespositions/) पर सेट न करें। नोट्स में स्थिर इमेज आकार से अधिक टेक्स्ट हो सकता है। इसके बजाय [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notespositions/) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास आपको रेंडर किए गए TIFF इमेज का साइज, रिज़ॉल्यूशन और अन्य प्रॉपर्टीज़ को नियंत्रित करने देती है।

निम्नलिखित उदाहरण प्रथम स्लाइड को 2160 × 2880 TIFF इमेज 300 DPI पर रेंडर करता है:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **सभी स्लाइड्स को इमेज में बदलें**

सभी स्लाइड्स को इमेजों की श्रृंखला में बदलने के लिए स्लाइड कलेक्शन पर इटररेट करें। छिपी हुई स्लाइड्स भी शामिल की जाती हैं जब तक आप स्पष्ट रूप से उन्हें स्किप न करें।

निम्नलिखित उदाहरण हर स्लाइड को क्षैतिज और लंबवत स्केल फैक्टर 2 के साथ JPEG इमेज में रेंडर करता है:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Enhanced Metafile आउटपुट बनाएं**

Enhanced Metafile (EMF) तब उपयोगी होता है जब वेक्टर-आधारित ग्राफिक्स को Microsoft Office या अन्य Windows एप्लिकेशन में एक्सचेंज करना हो जो Windows metafiles को सपोर्ट करते हैं। पिक्सेल-आधारित इमेज के विपरीत, EMF वेक्टर ड्राइंग ऑपरेशन्स को बरकरार रख सकता है जो स्केल होने पर भी स्पष्टता नहीं खोते। हालांकि, EMF मुख्यतः उन एप्लिकेशन के लिए एक कम्पैटिबिलिटी फ़ॉर्मेट है जो Windows metafile सपोर्ट रखते हैं, न कि एक सार्वभौमिक इंटरचेंज फ़ॉर्मेट। इसके अतिरिक्त, जटिल स्लाइड कंटेंट, जैसे बिटमैप इमेजेज और कुछ इफ़ेक्ट्स, वेक्टर मेटाफाइल कंटेनर के भीतर रॅस्टराइज़्ड तत्वों के रूप में संग्रहीत हो सकते हैं।

### **स्लाइड को EMF में एक्सपोर्ट करें**

[Slide.write_as_emf](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/write_as_emf/) मेथड एक [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) को लक्ष्य स्ट्रीम में EMF फ़ॉर्मेट में लिखता है। निम्नलिखित उदाहरण एक प्रस्तुति लोड करता है, प्रथम स्लाइड चुनता है, और उसे EMF फ़ाइल स्ट्रीम में लिखता है:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

कॉलर को [Slide.write_as_emf](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/write_as_emf/) को पास किए गए स्ट्रीम का स्वामित्व होता है और उसे बंद करना चाहिए। Aspose.Slides स्ट्रीम की वर्तमान पोजीशन पर लिखता है और स्ट्रीम को खुला छोड़ देता है।

### **SVG इमेज को EMF में बदलें और प्रस्तुति में जोड़ें**

[SvgImage.write_as_emf](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/write_as_emf/) का उपयोग करके SVG कंटेंट को EMF में बदलें। प्राप्त बाइट्स को [ImageCollection.add_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/add_image/) के ज़रिए प्रस्तुति में जोड़ा जा सकता है और [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) के साथ स्लाइड पर रख सकते हैं।

निम्नलिखित उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) बनाता है, इसे मेमोरी में EMF में बदलता है, पहले स्लाइड पर मेटाफाइल डालता है, और प्रस्तुति को सहेजता है:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/write_as_emf/) डेस्टिनेशन स्ट्रीम का स्वामित्व नहीं लेता। लिखने के बाद, स्ट्रीम पोजीशन उत्पन्न डेटा के अंत में होती है। वर्तमान स्ट्रीम पोजीशन की परवाह किए बिना पूरे बफ़र को प्राप्त करने के लिए `getvalue` कॉल करें, जैसा कि ऊपर दिखाया गया है। डेटा पढ़े जाने तक स्ट्रीम को खुला रखें, और बाद में इसे बंद करें।

EMF जनरेशन उन ऑपरेटिंग सिस्टम्स पर उपलब्ध है जो Aspose.Slides for Python via .NET द्वारा समर्थित हैं, लेकिन जब फ़ॉन्ट्स या नेटिव ग्राफ़िक्स डिपेंडेंसीज़ उपलब्ध न हों तो रेंडरिंग प्लेटफ़ॉर्म के अनुसार अलग हो सकती है। स्रोत कंटेंट द्वारा उपयोग किए गए फ़ॉन्ट्स को इंस्टॉल करें या उपयुक्त प्रतिस्थापन सेट करें, Aspose.Slides के लिए [platform requirements](/slides/hi/python-net/system-requirements/) का पालन करें, और लक्ष्य EMF उपयोग करने वाले एप्लिकेशन में परिणाम को वैलिडेट करें। Linux और macOS एप्लिकेशन्स अक्सर Windows metafiles को दिखाने और एडिट करने में सीमित या असंगत सपोर्ट रखती हैं।

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
जब प्रस्तुति स्लाइड्स को इमेज में बदलते हैं तो कलर इमोजी को सही ढंग से रेंडर करने के लिए, प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट्स को इंस्टॉल किया जाना चाहिए और वह सिस्टम पर उपलब्ध होना चाहिए जहाँ रूपांतरण हो रहा है। उदाहरण के लिए, यदि प्रस्तुति में **Segoe UI Emoji** उपयोग किया गया है और यह फ़ॉन्ट अनुपलब्ध है, तो आउटपुट इमेजेज में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने को सपोर्ट करता है?**

नहीं। [Slide.get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/) मेथड स्लाइड की स्थैतिक इमेज रेंडर करता है और एनीमेशन को एक्सपोर्ट नहीं करता।

**क्या छिपी स्लाइड्स को इमेज के रूप में एक्सपोर्ट किया जा सकता है?**

हाँ। छिपी स्लाइड्स को नियमित स्लाइड्स की तरह रेंडर किया जा सकता है। उन्हें प्रोसेसिंग लूप में शामिल करें, जैसा कि ऊपर के उदाहरण में दिखाया गया है।

**क्या शैडोज़ और अन्य इफ़ेक्ट्स स्लाइड इमेज में संरक्षित रहते हैं?**

हाँ। Aspose.Slides शैडोज़, ट्रांसपरेंसी और अन्य समर्थित ग्राफ़िकल इफ़ेक्ट्स को स्लाइड इमेज में रेंडर करता है।