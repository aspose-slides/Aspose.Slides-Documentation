---
title: Python में स्लाइड शो प्रबंधन
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/python-net/manage-slide-show/
keywords:
- शो प्रकार
- प्रस्तुतकर्ता द्वारा प्रस्तुत
- व्यक्ति द्वारा ब्राउज़
- कियोस्क पर ब्राउज़
- शो विकल्प
- लगातार लूप
- वर्णन बिना शो
- एनिमेशन बिना शो
- पेन रंग
- स्लाइड्स दिखाएँ
- कस्टम शो
- स्लाइड्स को आगे बढ़ाएँ
- मैन्युअल रूप से
- टाइमिंग का उपयोग करके
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET में स्लाइड शो को कैसे प्रबंधित करें, सीखें। PPT, PPTX और ODP फ़ॉर्मेट्स में स्लाइड ट्रांज़िशन, टाइमिंग और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint में, **Slide Show** सेटिंग्स पेशेवर प्रस्तुतियों को तैयार करने और प्रस्तुत करने के लिए एक प्रमुख उपकरण हैं। इस भाग की सबसे महत्वपूर्ण सुविधाओं में से एक **Set Up Show** है, जो आपको अपनी प्रस्तुति को विशिष्ट स्थितियों और दर्शकों के अनुसार अनुकूलित करने की अनुमति देती है, जिससे लचीलापन और सुविधा सुनिश्चित होती है। इस सुविधा के साथ, आप शो प्रकार चुन सकते हैं (जैसे, प्रस्तुतकर्ता द्वारा प्रस्तुत किया गया, व्यक्तिगत द्वारा ब्राउज़ किया गया, या कियोस्क पर ब्राउज़ किया गया), लूपिंग सक्षम या अक्षम कर सकते हैं, दिखाने के लिए विशिष्ट स्लाइड्स चुन सकते हैं, और टाइमिंग का उपयोग कर सकते हैं। तैयारी में यह कदम आपकी प्रस्तुति को अधिक प्रभावी और पेशेवर बनाने के लिए अत्यंत महत्वपूर्ण है।

`slide_show_settings` एक प्रॉपर्टी है [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की, जिसका प्रकार [SlideShowSettings](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slideshowsettings/) है, जो आपको PowerPoint प्रस्तुति में स्लाइड शो सेटिंग्स का प्रबंधन करने की अनुमति देता है। इस लेख में, हम देखेंगे कि इस प्रॉपर्टी का उपयोग करके स्लाइड शो सेटिंग्स के विभिन्न पहलुओं को कैसे कॉन्फ़िगर और नियंत्रित किया जा सकता है। 

## **शो प्रकार चुनें**

`SlideShowSettings.slide_show_type` स्लाइड शो के प्रकार को परिभाषित करता है, जो निम्नलिखित क्लासों में से किसी एक का उदाहरण हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/python-net/aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/python-net/aspose.slides/browsedatkiosk/). इस प्रॉपर्टी का उपयोग करके आप प्रस्तुति को विभिन्न उपयोग स्थितियों के अनुसार अनुकूलित कर सकते हैं, जैसे स्वचालित कियोस्क या मैन्युअल प्रस्तुतियां।

नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और शो प्रकार को "Browsed by an individual" सेट करता है, बिना स्क्रॉलबार दिखाए।

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **शो विकल्प सक्षम करें**

`SlideShowSettings.loop` निर्धारित करता है कि स्लाइड शो को मैन्युअल रूप से रोके जाने तक लूप में दोहराया जाना चाहिए या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिन्हें लगातार चलना आवश्यक होता है। `SlideShowSettings.show_narration` निर्धारित करता है कि स्लाइड शो के दौरान आवाज़ी वर्णन चलाए जाने चाहिए या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिनमें दर्शकों के लिए आवाज़ मार्गदर्शन शामिल होता है। `SlideShowSettings.show_animation` निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़ी गई एनिमेशन चलाए जाने चाहिए या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने के लिए उपयोगी है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप करता है।

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **दर्शाने के लिए स्लाइड्स चुनें**

`SlideShowSettings.slides` प्रॉपर्टी आपको प्रस्तुति के दौरान दिखाने के लिए स्लाइड्स की एक रेंज चुनने की अनुमति देती है। यह तब उपयोगी होता है जब आपको पूरी प्रस्तुति के बजाय केवल कुछ भाग दिखाने की आवश्यकता होती है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड रेंज को `2` से `9` तक सेट करता है।

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड्स को अग्रिम रूप से उपयोग करें**

`SlideShowSettings.use_timings` प्रॉपर्टी आपको प्रत्येक स्लाइड के लिए पूर्वनिर्धारित टाइमिंग का उपयोग सक्षम या अक्षम करने की अनुमति देती है। यह पूर्व निर्धारित प्रदर्शन अवधि के साथ स्लाइड्स को स्वचालित रूप से दिखाने के लिए उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग के उपयोग को अक्षम करता है।

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **मीडिया नियंत्रण दिखाएँ**

`SlideShowSettings.show_media_controls` प्रॉपर्टी निर्धारित करती है कि मल्टीमीडिया सामग्री (जैसे वीडियो या ऑडियो) चलाते समय स्लाइड शो के दौरान मीडिया नियंत्रण (जैसे प्ले, पॉज़, और स्टॉप) दिखाए जाने चाहिए या नहीं। यह तब उपयोगी होता है जब आप प्रस्तुति के दौरान प्रस्तुतकर्ता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रण को प्रदर्शित करने के लिए सक्षम करता है।

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Can I save a presentation so it opens directly in slide show mode?**

हां। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फ़ॉर्मेट PowerPoint में खोलने पर सीधे स्लाइड शो में शुरू होते हैं। Aspose.Slides में, उपयुक्त सहेजने का फ़ॉर्मेट चुनें [एक्सपोर्ट के दौरान](/slides/hi/python-net/save-presentation/)।

**Can I exclude individual slides from the show without deleting them from the file?**

हां। एक स्लाइड को [hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/hidden/) के रूप में चिह्नित करें। छुपी हुई स्लाइड्स प्रस्तुति में बनी रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीं।

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलों को संपादित, विश्लेषित और परिवर्तित करता है; वास्तविक प्लेबैक PowerPoint जैसे व्यूअर एप्लिकेशन द्वारा संभाला जाता है।