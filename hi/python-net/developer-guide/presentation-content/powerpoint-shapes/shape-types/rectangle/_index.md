---
title: Python में प्रस्तुतियों में आयतें जोड़ें
linktitle: आयत
type: docs
weight: 80
url: /hi/python-net/rectangle/
keywords:
- आयत जोड़ें
- आयत बनाएं
- आयत आकार
- सरल आयत
- फ़ॉर्मेटेड आयत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ आयतें जोड़कर अपने PowerPoint और OpenDocument प्रस्तुतियों को बूस्ट करें—आकारों को आसानी से प्रोग्रामेटिक रूप से डिज़ाइन और संशोधित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में आयत आकार जोड़ने के तरीके को दर्शाता है। यह एक सरल आयत बनाने, फ़ॉर्मेटेड आयत बनाने, और अपडेट की गई प्रस्तुति को PPTX फ़ाइल के रूप में सहेजने को कवर करता है।

आप देखेंगे कि कैसे मूल आयत फ़ॉर्मेटिंग लागू की जा सकती है, जैसे ठोस भराव रंग, रेखा रंग, और रेखा की चौड़ाई। इसके अतिरिक्त, लेख के FAQ में संबंधित आयत कार्यों की ओर संकेत किया गया है, जिनमें गोल कोने, चित्र भराव, दृश्य प्रभाव, हाइपरलिंक, आकार लॉक, निर्यात विकल्प, और प्रभावी प्रॉपर्टीज़ शामिल हैं।

## **सरल आयत बनाएं**
पिछले विषयों की तरह, यह भी आकार जोड़ने के बारे में है और इस बार हम जिस आकार पर चर्चा करेंगे वह आयत है। इस विषय में हमने बताया है कि डेवलपर्स Aspose.Slides for Python via .NET का उपयोग करके अपनी स्लाइड्स में सरल या फ़ॉर्मेटेड आयतें कैसे जोड़ सकते हैं। प्रस्तुति की किसी चयनित स्लाइड में सरल आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation ](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
3. IShapes ऑब्जेक्ट द्वारा प्रदर्शित AddAutoShape मेथड का उपयोग करके Rectangle प्रकार का IAutoShape जोड़ें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने प्रस्तुति की पहली स्लाइड में एक सरल आयत जोड़ी है।

```py
import aspose.slides as slides

# PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
with slides.Presentation() as pres:
    # पहली स्लाइड प्राप्त करें
    sld = pres.slides[0]

    # rectangle प्रकार का ऑटोषेप जोड़ें
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **फ़ॉर्मेटेड आयत बनाएं**
स्लाइड में फ़ॉर्मेटेड आयत जोड़ने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation ](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. स्लाइड का संदर्भ उसके Index का उपयोग करके प्राप्त करें।
3. IShapes ऑब्जेक्ट द्वारा प्रदर्शित AddAutoShape मेथड का उपयोग करके Rectangle प्रकार का IAutoShape जोड़ें।
4. आयत का Fill Type Solid पर सेट करें।
5. IShape ऑब्जेक्ट से जुड़े FillFormat ऑब्जेक्ट द्वारा प्रदर्शित SolidFillColor.Color प्रॉपर्टी का उपयोग करके आयत का रंग सेट करें।
6. आयत की रेखाओं का रंग सेट करें।
7. आयत की रेखाओं की चौड़ाई सेट करें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  
ऊपर दिए गए चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
with slides.Presentation() as pres:
    # पहली स्लाइड प्राप्त करें
    sld = pres.slides[0]

    # rectangle प्रकार का ऑटोषेप जोड़ें
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # rectangle आकार पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # rectangle की रेखा पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं आयत में गोल कोनों के साथ कैसे जोड़ सकता हूँ?**

गोल-कोना [आकार प्रकार](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapetype/) का उपयोग करें और आकार की प्रॉपर्टीज़ में कोना त्रिज्या समायोजित करें; गोलाई को ज्यामिति समायोजनों के द्वारा प्रत्येक कोने पर भी लागू किया जा सकता है।

**मैं आयत को चित्र (टेक्सचर) से कैसे भरूँ?**

चित्र [भराव प्रकार](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) चुनें, चित्र स्रोत प्रदान करें, और [विस्तार/टाइलिंग मोड](https://reference.aspose.com/slides/hi/python-net/aspose.slides/picturefillmode/) कॉन्फ़िगर करें।

**क्या आयत में छाया और चमक हो सकती है?**

हां। [बाहरी/आंतरिक छाया, चमक, और मुलायम किनारे](/slides/hi/python-net/shape-effect/) उपलब्ध हैं और इनके पैरामीटर समायोज्य हैं।

**क्या मैं आयत को हाइपरलिंक के साथ बटन में बदल सकता हूं?**

हां। आकार पर क्लिक करने पर (स्लाइड, फ़ाइल, वेब पता या ई‑मेल पर जाने के लिए) [हाइपरलिंक असाइन करें](/slides/hi/python-net/manage-hyperlinks/)।

**मैं आयत को स्थानांतरित होने और बदलावों से कैसे सुरक्षित रखूँ?**

[आकार लॉक](/slides/hi/python-net/applying-protection-to-presentation/) का उपयोग करें: आप लेआउट को स्थिर रखने के लिए स्थानांतरण, आकार बदलना, चयन या टेक्स्ट संपादन को प्रतिबंधित कर सकते हैं।

**क्या मैं आयत को रास्टर इमेज या SVG में बदल सकता हूँ?**

हां। आप [आकार को रेंडर करें](http://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_image/) एक निर्दिष्ट आकार/स्केल के साथ इमेज में या [इसे SVG के रूप में निर्यात करें](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/write_as_svg/) वेक्टर उपयोग के लिए।

**मैं थीम और विरासत को ध्यान में रखते हुए आयत की वास्तविक (प्रभावी) प्रॉपर्टीज़ जल्दी से कैसे प्राप्त करूँ?**

[आकार की प्रभावी प्रॉपर्टीज़ का उपयोग करें](/slides/hi/python-net/shape-effective-properties/): API ऐसे गणितीय मान लौटाता है जो थीम शैलियों, लेआउट और स्थानीय सेटिंग्स को ध्यान में रखता है, जिससे फ़ॉर्मेटिंग विश्लेषण सरल हो जाता है।