---
title: Python के साथ प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन
type: docs
weight: 10
url: /hi/python-net/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- छवि बदलें
- छवि संग्रह
- चित्र फ्रेम
- लिंक्ड छवि
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- SVG को आकारों में बदलें
- बाहरी SVG संसाधन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में रास्टर और SVG छवियों को जोड़ना, पुन: उपयोग करना, लिंक करना, बदलना और प्रबंधित करना सीखें।"
---
## **परिचय**

Aspose.Slides for Python via .NET कई तरीके प्रदान करता है चित्रों के साथ काम करने के लिए, और प्रत्येक का अलग उद्देश्य होता है। आप प्रस्तुति में एक चित्र संग्रहित कर सकते हैं, इसे चित्र फ्रेम में प्रदर्शित कर सकते हैं, इसे स्लाइड पृष्ठभूमि के रूप में उपयोग कर सकते हैं, बाहरी चित्र से लिंक कर सकते हैं, साझा चित्र संसाधन को बदल सकते हैं, या SVG सामग्री को संपादन योग्य आकारों में परिवर्तित कर सकते हैं।  

यह लेख चित्र संसाधनों और उन्हें प्रस्तुति में कैसे उपयोग किया जाता है, पर केंद्रित है। व्यक्तिगत चित्र फ्रेम पर लागू क्रॉपिंग, पारदर्शिता, प्रभाव, स्ट्रेचिंग और अन्य स्वरूपण के लिए, देखें [Picture Frame](/slides/hi/python-net/picture-frame/)।

## **छवि मॉडल को समझें**

- प्रस्तुति छवि संग्रह ([presentation image collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/)) प्रस्तुति द्वारा प्रयुक्त छवि संसाधनों को संग्रहीत करता है। छवि डेटा जोड़ने और एक [IPPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/) संसाधन प्राप्त करने के लिए [ImageCollection.add_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/add_image/) का उपयोग करें।  
- चित्र फ्रेम ([picture frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ipictureframe/)) एक आकार है जो स्लाइड, लेआउट या मास्टर पर छवि प्रदर्शित करता है। स्लाइड पर छवि संसाधन रखने के लिए [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) का उपयोग करें।  
- स्लाइड पृष्ठभूमि छवि को स्लाइड भराव के भाग के रूप में उपयोग करती है, न कि आकार के रूप में। इसलिए यह चित्र‑फ़्रेम जैसा व्यवहार नहीं करती है।  
- [IPPImage.replace_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/replace_image/) एक छवि संसाधन को बदलता है। यदि कई प्रस्तुति तत्व उस संसाधन का उपयोग करते हैं, तो वे सभी प्रतिस्थापन का उपयोग करेंगे।  
- SVG को आकारों में बदलने से संपादन योग्य स्लाइड आकार बनते हैं। रूपांतरण के बाद, सामग्री अब एक चित्र संसाधन के रूप में प्रबंधित नहीं रहती।  

एक सामान्य कार्यप्रवाह इस प्रकार है: छवि डेटा को छवि संग्रह में जोड़ें, एक [IPPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/) प्राप्त करें, और फिर उस संसाधन को एक या अधिक चित्र फ्रेम या भराव में उपयोग करें।

## **एम्बेडेड छवि जोड़ें**

स्थानीय छवि सम्मिलित करने के लिए, फ़ाइल पढ़ें, उसका डेटा छवि संग्रह में जोड़ें, और एक चित्र फ्रेम बनाएं जो लौटाए गए `IPPImage` का उपयोग करता है।

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

इस प्रकार जोड़ी गई छवि प्रस्तुति में एम्बेडेड रहती है, इसलिए परिणामी फ़ाइल मूल छवि फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से छवि जोड़ें**

जब कोई छवि HTTP या HTTPS के माध्यम से उपलब्ध हो, तो उसके बाइट्स डाउनलोड करें, उन्हें प्रस्तुति छवि संग्रह में जोड़ें, और लौटाए गए छवि संसाधन का उपयोग स्थानीय छवि की तरह ही करें।

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

लंबी चलने वाली अनुप्रयोगों में, प्रत्येक अनुरोध के लिए नई कनेक्शन बनाने के बजाय उपयुक्त रूप से HTTP क्लाइंट या कनेक्शन पूल को पुन: उपयोग करें। साथ ही जब स्रोत विश्वसनीय न हो, तो दूरस्थ URL, प्रतिक्रिया आकार और सामग्री प्रकार को सत्यापित करें।

## **स्लाइड्स में छवियों का पुन: उपयोग**

यदि एक ही छवि कई बार आवश्यक हो, तो उसे प्रस्तुति में एक बार जोड़ें और अतिरिक्त चित्र फ्रेम बनाते समय लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/) को पुन: उपयोग करें। इससे समान स्रोत डेटा को बार-बार लोड करने से बचा जा सकता है और साझा छवि संसाधन और उसके उपयोगों के बीच संबंध स्पष्ट हो जाता है।

ऐसे ग्राफ़िक्स जो कई स्लाइड्स पर स्वचालित रूप से दिखने चाहिए, जैसे कंपनी लोगो, प्रत्येक स्लाइड में समान आकार जोड़ने के बजाय [slide master](/slides/hi/python-net/slide-master/) या लेआउट पर चित्र फ्रेम रखने पर विचार करें।

## **छवि को स्लाइड पृष्ठभूमि के रूप में उपयोग करें**

एक पृष्ठभूमि छवि को स्लाइड भराव में सौंपा जाता है; इसे चित्र‑फ़्रेम आकार के रूप में नहीं जोड़ा जाता। यह तब उपयोगी होता है जब चित्र को स्लाइड पृष्ठभूमि को कवर करना चाहिए और उसे सामान्य स्लाइड वस्तु के रूप में बदलना नहीं चाहिए।

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

अतिरिक्त पृष्ठभूमि विकल्पों के लिए, जिसमें मास्टर और लेआउट पृष्ठभूमि शामिल हैं, देखें [Presentation Background](/slides/hi/python-net/presentation-background/)।

## **एम्बेडेड छवियां और लिंक्ड छवियां**

एम्बेडेड और लिंक्ड छवियों के पोर्टेबिलिटी और फ़ाइल आकार में विभिन्न ट्रेडऑफ़ होते हैं:

- **Embedded image:** छवि डेटा प्रस्तुति के अंदर संग्रहीत होता है। प्रस्तुति स्वयं-सम्पूर्ण है, लेकिन फ़ाइल आकार में छवि डेटा शामिल होता है।  
- **Linked image:** प्रस्तुति एक बाहरी छवि का पथ या URL संग्रहीत करती है। इससे प्रस्तुति का आकार कम हो सकता है, लेकिन जब प्रस्तुति खोली या रेंडर की जाती है तो बाहरी संसाधन उपलब्ध रहना चाहिए।  

एक लिंक्ड चित्र को बाहरी पथ या URL को [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/hi/python-net/aspose.slides/islidespicture/link_path_long/) के माध्यम से असाइन करके बनाया जा सकता है, बजाय छवि डेटा को एम्बेड करने के।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

लिंक्ड छवियों का उपयोग केवल तभी करें जब डिप्लॉयमेंट पर्यावरण बाहरी संसाधन तक विश्वसनीय रूप से पहुँच सकता हो। उन प्रस्तुतियों के लिए जो ऑफ़लाइन काम करनी हों या प्रणालियों के बीच स्थानांतरित होनी हों, एम्बेडेड छवियां आमतौर पर सुरक्षित रहती हैं।

## **SVG छवियों के साथ काम करें**

SVG एक वेक्टर प्रारूप है, इसलिए यह आइकन, आरेख और अन्य ग्राफ़िक्स के लिए उपयोगी हो सकता है जिन्हें रास्टर चित्रों की तरह विवरण के नुकसान के बिना स्केल किया जा सके। Aspose.Slides SVG को छवि संसाधन और संपादन योग्य स्लाइड आकारों के स्रोत दोनों रूप में समर्थन करता है।

### **SVG को छवि के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) बनाएं, उसे छवि संग्रह में जोड़ें, और परिणामस्वरूप छवि संसाधन को एक चित्र फ्रेम में रखें।

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **SVG को संपादन योग्य आकारों में परिवर्तित करें**

Aspose.Slides SVG को संपादन योग्य स्लाइड आकारों के समूह में परिवर्तित कर सकता है, जो संबंधित PowerPoint कमांड के समान है।

![PowerPoint Popup Menu](img_01_01.png)

परिवर्तन करने के लिए उस [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_group_shape/) ओवरलोड का उपयोग करें जो एक [ISvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/isvgimage/) को स्वीकार करता है।

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

जब व्यक्तिगत वेक्टर तत्वों को PowerPoint आकारों के रूप में संपादित करने की आवश्यकता हो, तब SVG‑से‑आकार रूपांतरण का उपयोग करें। यदि SVG को केवल प्रदर्शित करने की जरूरत है, तो इसे छवि के रूप में रखना आसान है और कई अलग-अलग आकार बनाने से बचाता है।

## **मौजूदा छवि संसाधन को बदलें**

जब आप किसी मौजूदा छवि संसाधन को बदलना चाहते हैं, तब [IPPImage.replace_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/replace_image/) का उपयोग करें। यह विशेष रूप से लोगो जैसे साझा ग्राफ़िक्स के लिए उपयोगी है।

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

यदि कई चित्र फ्रेम, पृष्ठभूमि, मास्टर या लेआउट एक ही छवि संसाधन का उपयोग करते हैं, तो उस संसाधन को बदलने से उन सभी उपयोगों में अपडेट हो जाएगा। यदि केवल एक चित्र फ्रेम बदलना है, तो साझा संसाधन को बदलने के बजाय उस फ्रेम को एक अलग छवि असाइन करें।

`replace_image` अतिरिक्त ओवरलोड भी प्रदान करता है जो एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) या अन्य [IPPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/) को स्वीकार करता है।

## **व्यावहारिक छवि प्रबंधन मार्गदर्शन**

### **प्रस्तुति आकार को नियंत्रित करें**

बड़े रास्टर चित्र प्रस्तुति को अनावश्यक रूप से बड़ा बना सकते हैं। स्रोत छवियों को उनके इच्छित प्रदर्शनी आकार के अनुसार आयामों के साथ उपयोग करें, जहाँ संभव हो साझा छवि संसाधनों को पुन: उपयोग करें, और समान पूर्ण‑रिज़ॉल्यूशन ग्राफ़िक की दोहराई गई प्रतियों को एम्बेड करने से बचें।  

जो रास्टर चित्र पहले ही चित्र फ्रेम में रखे जा चुके हैं, उनके लिए [PictureFillFormat.compress_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillformat/compress_image/) चयनित रिज़ॉल्यूशन और क्रॉप सेटिंग के अनुसार छवि डेटा को कम कर सकता है। यह चित्र‑फ़्रेम प्रसंस्करण है, न कि छवि‑संग्रह प्रबंधन, इसलिए संबंधित स्वरूपण संचालन के लिए [Picture Frame](/slides/hi/python-net/picture-frame/) देखें।

### **एम्बेडेड और लिंक्ड सामग्री के बीच चयन करें**

एंबेडिंग प्रस्तुति को पोर्टेबल बनाता है क्योंकि सभी आवश्यक छवि डेटा फ़ाइल के साथ चलता है। लिंकिंग फ़ाइल आकार को कम कर सकती है, लेकिन यह बाहरी निर्भरता पेश करती है। लिंक तभी उपयोग करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **साझा ब्रांडिंग का पुन: उपयोग**

बार‑बार उपयोग होने वाले लोगो, वाटरमार्क या सजावटी ग्राफ़िक के लिए, एक छवि संसाधन का उपयोग करें और उसे पुन: उपयोग करें। यदि ग्राफ़िक प्रस्तुति डिज़ाइन का भाग है न कि स्लाइड सामग्री का, तो उसे मास्टर या लेआउट पर रखें ताकि उपयुक्त स्लाइड्स द्वारा इसे विरासत में प्राप्त किया जा सके।

### **SVG संसाधनों को पोर्टेबल रखें**

एक स्व-समावेशी SVG को ले जाना और लगातार रेंडर करना आसान होता है बनिस्बत उस SVG के जो बाहरी फ़ाइलों या नेटवर्क संसाधनों पर निर्भर करता है। संभव हो तो SVG आयात करने से पहले आवश्यक संसाधनों को एम्बेड करें। केवल तब SVG को आकारों में बदलें जब व्यक्तिगत वेक्टर तत्वों को संपादित करने की आवश्यकता हो।

### **आधुनिक क्रॉस‑प्लेटफ़ॉर्म इमेज API का उपयोग करें**

नए Python via .NET कोड के लिए, Aspose.Slides के [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) और [Images](https://reference.aspose.com/slides/hi/python-net/aspose.slides/images/) APIs का उपयोग करें, बजाय डिप्रिकेटेड `aspose.pydrawing.Image` या `aspose.pydrawing.Bitmap` इमेज APIs के। माइग्रेशन मार्गदर्शन के लिए देखें [Modern API](/slides/hi/python-net/modern-api/)।

WMF और EMF को विशेष विचार की आवश्यकता होती है। जब ये प्रारूप एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) के माध्यम से पास किए जाते हैं, तो [ImageCollection.add_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/add_image/) मेटाफाइल को रास्टर PNG रूप में परिवर्तित करता है इससे पहले कि वह सम्मिलित हो। यदि मेटाफाइल डेटा को संरक्षित रखना महत्वपूर्ण है, तो स्ट्रीम‑आधारित [ImageCollection.add_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imagecollection/add_image/) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य उत्पादों से EMF सामग्री बनाना एक अलग एकीकरण कार्यप्रवाह है और इस लेख के दायरे से बाहर है।

## **अक्सर पूछे जाने वाले प्रश्न**

**छवि संग्रह और चित्र फ्रेम के बीच अंतर क्या है?**  
छवि संग्रह पुन: उपयोग योग्य छवि संसाधनों को संग्रहीत करता है। चित्र फ्रेम एक स्लाइड आकार है जो उन संसाधनों में से एक को प्रदर्शित करता है और क्रॉपिंग व प्रभाव जैसे चित्र‑विशिष्ट स्वरूपण प्रदान करता है।

**सभी स्थानों पर एक ही लोगो बदलने का सबसे अच्छा तरीका क्या है?**  
यदि लोगो पहले ही एक छवि संसाधन के रूप में साझा किया गया है, तो उस संसाधन को [IPPImage.replace_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ippimage/replace_image/) से बदलें। प्रस्तुति‑व्यापी ब्रांडिंग के लिए, लोगो को मास्टर या लेआउट पर रखना भी डुप्लिकेट स्लाइड सामग्री को कम कर सकता है।

**क्यों लिंक्ड छवि दूसरे कंप्यूटर पर गायब हो जाती है?**  
लिंक्ड चित्र अपने बाहरी फ़ाइल या URL पर निर्भर करता है। यदि वह संसाधन दूसरे कंप्यूटर से पहुँचा नहीं जा सकता, तो लिंक्ड छवि उपलब्ध नहीं हो सकती। जब प्रस्तुति को स्वयं‑सम्पूर्ण होना चाहिए, तो छवि को एम्बेड करें।

**क्या डाली गई SVG को PowerPoint आकारों के रूप में संपादित किया जा सकता है?**  
हां। SVG को [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_group_shape/) से परिवर्तित करें; परिणामी समूह में एक SVG चित्र के बजाय संपादन योग्य स्लाइड आकार होते हैं।

**मैं कई छवियों वाली प्रस्तुतियों को कैसे छोटा रख सकता हूँ?**  
साझा छवि संसाधनों का पुन: उपयोग करें, अनावश्यक रूप से बड़े रास्टर स्रोतों से बचें, उपयुक्त होने पर उपयुक्त रास्टर चित्रों को संकुचित करें, दोहराई गई ब्रांडिंग को मास्टर या लेआउट पर रखें, और लिंक्ड छवियों का उपयोग तभी करें जब बाहरी निर्भरता स्वीकार्य हो।