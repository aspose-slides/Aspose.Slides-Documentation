---
title: Python में प्रस्तुति व्यू प्रॉपर्टीज़ को प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/python-net/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- सामान्य दृश्य
- आउटलाइन कंटेंट
- आउटलाइन आइकॉन
- वर्टिकल स्प्लिटर स्नैप
- सिंगल दृश्य
- बार स्टेट
- डायमेन्शन साइज
- ऑटो एडेजस्ट
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के व्यू प्रॉपर्टीज़ की खोज करें ताकि PPT, PPTX और ODP स्लाइड्स के फ़ॉर्मेट को कस्टमाइज़ किया जा सके—लेआउट, ज़ूम लेवल और डिस्प्ले सेटिंग्स को समायोजित किया जा सके।"
---
## **परिचय**

Normal view में तीन कंटेंट क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड कंटेंट क्षेत्र, और नीचे का कंटेंट क्षेत्र। विभिन्न कंटेंट क्षेत्रों की पोजिशनिंग से संबंधित प्रॉपर्टीज़। यह जानकारी एप्लिकेशन को उसके view state को फ़ाइल में Save करने की अनुमति देती है, ताकि पुनः खोलने पर view वही स्थिति में हो जैसा कि प्रस्तुति आखिरी बार Save की गई थी।

Property [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/normal_view_properties/) को प्रस्तुति के normal view प्रॉपर्टीज़ तक पहुंच प्रदान करने के लिए जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/normalviewrestoredproperties/) क्लासेज़ और उनके descendants, [SplitterBarStateType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/splitterbarstatetype/) enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

Normal view प्रॉपर्टीज़ का प्रतिनिधित्व करता है।

Property **ShowOutlineIcons** यह निर्दिष्ट करता है कि normal view मोड में किसी भी कंटेंट क्षेत्र में outline कंटेंट प्रदर्शित करते समय एप्लिकेशन को आइकॉन दिखाने चाहिए या नहीं।

Property **SnapVerticalSplitter** यह निर्दिष्ट करता है कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को मिनिमाइज़्ड स्थिति में स्नैप किया जाना चाहिए या नहीं।

Property **PreferSingleView** यह निर्दिष्ट करता है कि उपयोगकर्ता पूर्ण-विंडो सिंगल-कंटेंट क्षेत्र को standard normal view के तीन कंटेंट क्षेत्रों के ऊपर देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में एक कंटेंट क्षेत्र को प्रदर्शित करना चुन सकता है।

Property **VerticalBarState** और **HorizontalBarState** यह निर्धारित करते हैं कि होरिज़ॉन्टल या वर्टिकल स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक होरिज़ॉन्टल स्प्लिटर बार स्लाइड को नीचे के कंटेंट क्षेत्र से अलग करता है, वर्टिकल स्प्लिटर बार स्लाइड को साइड कंटेंट क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

Property **RestoredLeft** और **RestoredTop** यह निर्दिष्ट करते हैं कि normal view में टॉप या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब **VerticalBarState** और **HorizontalBarState** के लिए **SplitterBarStateType.Restored** मान लागू किया गया हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

यह निर्दिष्ट करता है कि normal view में स्लाइड क्षेत्र (चाइल्ड होने पर RestoredTop के लिए चौड़ाई, RestoredLeft के लिए ऊँचाई) का आकार क्या होना चाहिए, जब क्षेत्र variable restored size (न तो मिनिमाइज़्ड न ही मैक्सिमाइज़्ड) में हो।

Property **DimensionSize** स्लाइड क्षेत्र का आकार (RestoredTop का चाइल्ड होने पर चौड़ाई, RestoredLeft का चाइल्ड होने पर ऊँचाई) निर्दिष्ट करती है।

Property **AutoAdjust** निर्दिष्ट करता है कि जब विंडो को रिसाइज़ किया जाता है तो साइड कंटेंट क्षेत्र का आकार नई साइज के अनुसार समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दर्शाता है कि आप एक प्रस्तुति के लिए **ViewProperties.NormalViewProperties** प्रॉपर्टीज़ तक कैसे पहुंच सकते हैं।

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # प्रेजेंटेशन की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

Aspose.Slides for Python via .NET अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है जिससे जब प्रस्तुति खोली जाती है, तो ज़ूम पहले से ही सेट हो जाता है। यह presentation के [view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) को सेट करके किया जा सकता है। Slide View Properties और [notes_view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/notes_view_properties/) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ दिखाएंगे कि Aspose.Slides में Presentation के View Properties कैसे सेट करें।

view properties सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं
1. प्रस्तुति के [view properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) सेट करें
1. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिया गया उदाहरण स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट करता है।

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करना
    presentation.view_properties.slide_view_properties.scale = 100 # स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.view_properties.notes_view_properties.scale = 100 # नोट्स व्यू के लिए प्रतिशत में ज़ूम मान 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ग्रिड स्पेसिंग सेट करें**

Presentation के view settings तक पहुंचने के लिए [Presentation.view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) का उपयोग करें। Property [ViewProperties.grid_spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/grid_spacing/) मूल एडिटिंग ग्रिड का अंतराल पढ़ता या बदलता है। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API डॉक्यूमेंटेशन के अनुसार आवश्यक मान सकारात्मक होना चाहिए।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक क्वार्टर-इंच अंतराल सेट करता है, और परिणाम को सहेजता है।

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

ग्रिड [drawing guides](/slides/hi/python-net/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि drawing guides व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। drawing guides को जोड़ना, स्थानांतरित करना या साफ़ करना ग्रिड स्पेसिंग को बदलता नहीं है।

ग्रिड और drawing guides दोनों ही एडिटिंग सहायक हैं। वे PDF, images, SVG, या स्लाइड शो में स्लाइड कंटेंट के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को स्टोर करने से यह गारंटी नहीं मिलती कि कोई एडिटर ग्रिड दिखाएगा: इसकी दृश्यता viewer या editor की प्राथमिकताओं पर भी निर्भर करती है।

## **प्रेजेंटेशन खोलते समय टिप्पणियों को दिखाएँ या छिपाएँ**

Presentation के view settings तक पहुंचने के लिए [Presentation.view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) का उपयोग करें। [ViewProperties.show_comments](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/show_comments/) को पढ़ें या बदलें ताकि यह Preference स्टोर हो सके कि PowerPoint या किसी अन्य संगत एडिटर में प्रेजेंटेशन खोलते समय टिप्पणियाँ दिखानी चाहिए या नहीं।

यह सेटिंग केवल स्टोर किए गए view Preference को नियंत्रित करती है। यह टिप्पणियों को जोड़ती, हटाती, संपादित या हल नहीं करती। टिप्पणियों को छिपाने से उनकी सामग्री, लेखक, स्थितियाँ, उत्तर और स्थिति संरक्षित रहती है। टिप्पणी संचालन के बारे में अधिक जानकारी के लिए देखें [Presentation Comments](/slides/hi/python-net/presentation-comments/)।

निम्न उदाहरण के लिए एक मौजूदा `comments.pptx` आवश्यक है जिसमें टिप्पणियाँ हों। यह वर्तमान दृश्यता सेटिंग प्रिंट करता है, टिप्पणियों को छिपाने का अनुरोध करता है, और कोई टिप्पणी हटाए बिना नया PPTX सहेजता है। यह zudem [ViewProperties.last_view](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/last_view/) को [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewtype/) पर सेट करता है ताकि प्रारंभिक एडिटिंग व्यू टिप्पणी दृश्यता के साथ कॉन्फ़िगर हो सके।

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियाँ PDF, HTML, image, notes, या handout निर्यात में शामिल हैं या नहीं। संबंधित निर्यात-विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **FAQ**

**ग्रिड को पुनः खोलने के बाद क्यों नहीं दिख रहा है?**

फ़ाइल ग्रिड स्पेसिंग को स्टोर करती है, लेकिन एडिटर नियंत्रित करता है कि ग्रिड प्रदर्शित होना चाहिए या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स जाँचें।

**क्या drawing guides को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। drawing guides और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से स्टोर किए गए ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग-अलग view सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/slide_view_properties/)), न कि सेक्शन प्रति, इसलिए जब दस्तावेज़ खुलता है तो एक ही सेट पैरामीटर पूरे दस्तावेज़ पर लागू होते हैं।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग view states पहले से परिभाषित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। Viewer एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, लेकिन फ़ाइल में केवल एक सेट view प्रॉपर्टीज़ होती हैं।

**क्या मैं एक टेम्प्लेट बना सकता हूँ जिसमें पहले से परिभाषित View Properties हों ताकि नई प्रस्तुतियाँ उसी तरह खुलें?**

हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एम्बेड कर सकते हैं और उसी प्रारंभिक view कॉन्फ़िगरेशन के साथ नई दस्तावेज़ बना सकते हैं।