---
title: Python में प्रस्तुतियों में अंडाकार जोड़ें
linktitle: अंडाकार
type: docs
weight: 30
url: /hi/python-net/ellipse/
keywords:
- अंडाकार
- आकार
- अंडाकार जोड़ें
- अंडाकार बनाएं
- अंडाकार खींचें
- फ़ॉर्मेटेड अंडाकार
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में PPT, PPTX और ODP प्रस्तुतियों के लिए अंडाकार आकृतियों को बनाने, फ़ॉर्मेट करने और नियंत्रित करने के तरीके सीखें—कोड उदाहरण सहित."
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint स्लाइड्स में अंडाकार बनावट जोड़ने का तरीका दिखाता है। इसमें एक साधारण अंडाकार बनाना, फ़ॉर्मेटेड अंडाकार बनाना, और अपडेटेड प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सेव करना शामिल है। यह अंडाकार की स्थिति और आकार, स्टैकिंग क्रम को नियंत्रित करने, और एनीमेशन इफ़ेक्ट्स लागू करने से संबंधित प्रश्नों को भी छूता है।

## **अंडाकार बनाएं**

इस विषय में, हम डेवलपर्स को Aspose.Slides for Python via .NET का उपयोग करके अपने स्लाइड्स में अंडाकार बनावट जोड़ने के बारे में परिचित कराएंगे। Aspose.Slides for Python via .NET कुछ ही लाइनों के कोड से विभिन्न प्रकार की आकृतियों को खींचने के लिए एक आसान API सेट प्रदान करता है। प्रस्तुति की किसी चयनित स्लाइड में एक साधारण अंडाकार जोड़ने के लिए नीचे दी गई चरणों का पालन करें:

1. एक [Presentation ](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)क्लास का इंस्टेंस बनाएं
1. स्लाइड का रेफ़रेंस उसके Index का उपयोग करके प्राप्त करें
1. IShapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके Ellipse प्रकार का AutoShape जोड़ें
1. बदलित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने पहली स्लाइड में एक अंडाकार जोड़ दिया है।

```py
import aspose.slides as slides

# PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
with slides.Presentation() as pres:
    # पहला स्लाइड प्राप्त करें
    sld = pres.slides[0]

    # अंडाकार प्रकार का ऑटोशेप जोड़ें
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **फ़ॉर्मेटेड अंडाकार बनाएं**
एक बेहतर फ़ॉर्मेटेड अंडाकार स्लाइड में जोड़ने के लिए, नीचे दी गई चरणों का पालन करें:

1. एक [Presentation ](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)क्लास का इंस्टेंस बनाएं।
1. स्लाइड का रेफ़रेंस उसके Index का उपयोग करके प्राप्त करें।
1. IShapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके Ellipse प्रकार का AutoShape जोड़ें।
1. अंडाकार की Fill Type को Solid सेट करें।
1. FillFormat ऑब्जेक्ट से जुड़ी IShape ऑब्जेक्ट के SolidFillColor.Color प्रॉपर्टी का उपयोग करके अंडाकार का रंग सेट करें।
1. अंडाकार की रेखाओं का रंग सेट करें।
1. अंडाकार की रेखाओं की चौड़ाई सेट करें।
1. बदलित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक फ़ॉर्मेटेड अंडाकार जोड़ा है।

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
with slides.Presentation() as pres:
    # पहला स्लाइड प्राप्त करें
    sld = pres.slides[0]

    # अंडाकार प्रकार का ऑटोशेप जोड़ें
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # अंडाकार आकार पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # अंडाकार की रेखा पर कुछ फ़ॉर्मेटिंग लागू करें
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #PPTX फ़ाइल को डिस्क पर लिखें
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड की इकाइयों के सापेक्ष अंडाकार की सटीक स्थिति और आकार कैसे सेट करूँ?**

निर्देशांक और आकार सामान्यतः **पॉइंट्स** में निर्दिष्ट किए जाते हैं। पूर्वानुमेय परिणामों के लिए, अपनी गणनाओं को स्लाइड के आकार पर आधारित रखें और आवश्यक मिलीमीटर या इंच को पॉइंट्स में बदलकर मान असाइन करें।

**मैं अंडाकार को अन्य वस्तुओं के ऊपर या नीचे कैसे रखूँ (स्टैकिंग क्रम नियंत्रित करें)?**

ऑब्जेक्ट को फ़्रंट में लाकर या बैक में भेजकर उसकी ड्रॉइंग ऑर्डर समायोजित करें। इससे अंडाकार अन्य वस्तुओं के ऊपर ओवरलैप या नीचे स्थित वस्तुओं को उजागर कर सकता है।

**मैं अंडाकार के प्रकट होने या ज़ोर देने के एनीमेशन कैसे लागू करूँ?**

[Apply](/slides/hi/python-net/shape-animation/) एंट्रेंस, इमफ़ेसेस या एग्ज़िट इफ़ेक्ट्स को आकार पर लागू करें, तथा ट्रिगर्स और टाइमिंग को कॉन्फ़िगर करें ताकि एनीमेशन कब और कैसे चले, इसे नियंत्रित किया जा सके।