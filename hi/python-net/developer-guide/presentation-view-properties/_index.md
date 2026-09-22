---
title: Python में प्रस्तुति दृश्य गुणों को प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/python-net/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकॉन
- वर्टिकल स्प्लिटर को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आकार आयाम
- स्वचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के दृश्य गुणों की खोज करें ताकि PPT, PPTX और ODP स्लाइड्स के स्वरूप को अनुकूलित किया जा सके—लेआउट, ज़ूम स्तर और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

Normal view तीन सामग्री क्षेत्रों से बना होता है: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को अपना view state फ़ाइल में सहेजने की अनुमति देती है, ताकि फिर से खोलने पर view उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

प्रॉपर्टी [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/normal_view_properties/) को प्रस्तुति के normal view गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/normalviewrestoredproperties/) क्लासेस और उनके वंशज, [SplitterBarStateType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/splitterbarstatetype/) एना‍म को जोड़ा गया है।

## **About INormalViewProperties**

Normal view गुणों का प्रतिनिधित्व करता है।

प्रॉपर्टी **ShowOutlineIcons** निर्धारित करती है कि normal view मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकॉन दिखाने चाहिए या नहीं।

प्रॉपर्टी **SnapVerticalSplitter** निर्धारित करती है कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप किया जाना चाहिए या नहीं।

प्रॉपर्टी **PreferSingleView** निर्धारित करती है कि उपयोगकर्ता तीन सामग्री क्षेत्रों वाले मानक normal view के बजाय पूरी विंडो में एकल‑सामग्री क्षेत्र देखना चाहते हैं या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में इन में से किसी एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

प्रॉपर्टी **VerticalBarState** और **HorizontalBarState** निर्धारित करती है कि क्षैतिज या ऊर्ध्वाधर स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे की सामग्री क्षेत्र से अलग करता है, जबकि ऊर्ध्वाधर स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** और **SplitterBarStateType.Restored**।

प्रॉपर्टी **RestoredLeft** और **RestoredTop** normal view के शीर्ष या साइड स्लाइड क्षेत्र का आकार निर्दिष्ट करती हैं, जब **VerticalBarState** और **HorizontalBarState** के लिए **SplitterBarStateType.Restored** मान लागू हो।

## **About Restoring INormalViewProperties**

जब क्षेत्र परिवर्ती पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) में होता है, तो normal view के स्लाइड क्षेत्र (RestoredTop का बच्चा होने पर चौड़ाई, RestoredLeft का बच्चा होने पर ऊँचाई) का आकार निर्दिष्ट करता है।

प्रॉपर्टी **DimensionSize** स्लाइड क्षेत्र का आकार (restoredTop का बच्चा होने पर चौड़ाई, restoredLeft का बच्चा होने पर ऊँचाई) निर्दिष्ट करती है।

प्रॉपर्टी **AutoAdjust** निर्धारित करती है कि विंडो के आकार बदलने पर साइड सामग्री क्षेत्र का आकार नई स्थिति के अनुसार समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दर्शाता है कि कैसे आप प्रस्तुति के लिए **ViewProperties.NormalViewProperties** प्रॉपर्टीज़ तक पहुँच सकते हैं।

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Default Zoom Value**

Aspose.Slides for Python via .NET अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है, जिससे प्रस्तुति खोलते समय ज़ूम पहले से ही निर्धारित हो जाता है। यह **[view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/)** को सेट करके किया जा सकता है। स्लाइड व्यू प्रॉपर्टीज़ के साथ-साथ **[notes_view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/notes_view_properties/)** को भी प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस टॉपिक में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में प्रस्तुति की View Properties कैसे सेट करें।

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक **[Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/)** क्लास का उदाहरण बनाएँ
2. प्रस्तुति की **[view properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/)** सेट करें
3. प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # प्रस्तुति के दृश्य गुणों को सेट करना
    presentation.view_properties.slide_view_properties.scale = 100 # स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.view_properties.notes_view_properties.scale = 100 # नोट्स व्यू के लिए प्रतिशत में ज़ूम मान

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set the Grid Spacing**

परिचालन‑व्यापक व्यू सेटिंग्स तक पहुँचने के लिए **[Presentation.view_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/)** का उपयोग करें। प्रॉपर्टी **[ViewProperties.grid_spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/grid_spacing/)** अंतर्निहित एडिटिंग ग्रिड का अंतराल पढ़ती या बदलती है। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड अंतराल पॉइंट्स में निर्दिष्ट किया जाता है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ में आवश्यकतानुसार सकारात्मक मान का उपयोग करें।

निम्नलिखित उदाहरण मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग को प्रिंट करता है, एक चौथाइ‑इंच का अंतराल सेट करता है, और परिणाम को सहेजता है।

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

ग्रिड **[drawing guides](/slides/hi/python-net/drawing-guides/)** से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या ऊर्ध्वाधर संरेखण रेखाएँ होती हैं। गाइड्स को जोड़ना, स्थानांतरित करना या हटाना ग्रिड स्पेसिंग को नहीं बदलता।

ग्रिड और ड्राइंग गाइड दोनों ही एडिटिंग सहायता उपकरण हैं। वे PDF, इमेज, SVG या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को संग्रहीत करने से यह गारंटी नहीं मिलती कि कोई एडिटर ग्रिड प्रदर्शित करेगा; इसकी दृश्यता व्यूअर या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **FAQ**

**ग्रिड प्रस्तुति पुनः खोलने के बाद क्यों दिखाई नहीं देता?**

फ़ाइल ग्रिड स्पेसिंग संग्रहीत करती है, लेकिन एडिटर नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग‑अलग व्यू सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/slide_view_properties/)), न कि सेक्शन‑वार, इसलिए जब दस्तावेज़ खुलता है तो सभी सेक्शन एक ही पैरामीटर सेट को उपयोग करते हैं।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग व्यू स्टेट्स पूर्व‑निर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत रहती हैं और सभी उपयोगकर्ताओं के बीच साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को मान सकते हैं, पर फ़ाइल स्वयं केवल एक ही सेट की view properties रखती है।

**क्या मैं पूर्व‑परिभाषित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियाँ उसी तरह खुलें?**

हाँ। चूँकि **[view properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/view_properties/)** प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और नई डॉक्यूमेंट्स उसी प्रारम्भिक view कॉन्फ़िगरेशन के साथ बना सकते हैं।