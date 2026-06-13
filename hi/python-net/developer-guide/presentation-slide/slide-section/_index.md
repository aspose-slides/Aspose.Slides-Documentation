---
title: पायथन के साथ प्रेजेंटेशन में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 100
url: /hi/python-net/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- पावरपॉइंट
- प्रेजेंटेशन
- पायथन
- Aspose.Slides
description: "Aspose.Slides for Python के साथ PowerPoint और OpenDocument में स्लाइड सेक्शन को सरल बनाएं — विभाजित करें, नाम बदलें, और पुनः व्यवस्थित करें ताकि PPTX और ODP कार्यप्रवाह को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for Python के साथ, आप PowerPoint प्रेजेंटेशन को सेक्शनों में व्यवस्थित कर सकते हैं जो विशिष्ट स्लाइडों को समूहित करते हैं।

आप इन स्थितियों में प्रेजेंटेशन को लॉजिकल भागों में व्यवस्थित या विभाजित करने के लिए सेक्शन बनाना चाह सकते हैं:

- जब आप एक बड़े प्रेजेंटेशन पर टीम के साथ काम कर रहे हों और कुछ स्लाइडों को विशेष सहयोगियों को असाइन करना चाहें।
- जब आप बहुत सारी स्लाइडों वाले प्रेजेंटेशन को संभाल रहे हों और सभी को एक बार में मैनेज या एडिट करना कठिन लग रहा हो।

आदर्श रूप से, ऐसे सेक्शन बनाएं जो संबंधित स्लाइडों को समूहित करें—वे जो समान थीम, टॉपिक या उद्देश्य साझा करते हों—और प्रत्येक सेक्शन को ऐसा नाम दें जो उसकी सामग्री को स्पष्ट रूप से दर्शाता हो।

## **प्रेजेंटेशनों में सेक्शन बनाना**

एक प्रेजेंटेशन में स्लाइडों को समूहित करने वाले [Section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/) को जोड़ने के लिए, Aspose.Slides [add_section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sectioncollection/add_section/) मेथड प्रदान करता है। यह आपको सेक्शन का नाम और वह स्लाइड निर्धारित करने की अनुमति देता है जहाँ सेक्शन शुरू होता है।

निम्नलिखित Python उदाहरण दिखाता है कि प्रेजेंटेशन में सेक्शन कैसे बनाएं:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # सेक्शन 1 स्लाइड2 पर समाप्त होता है; सेक्शन 2 स्लाइड3 से शुरू होता है।
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **सेक्शन के नाम बदलना**

PowerPoint प्रेजेंटेशन में एक [Section](https://reference.aspose.com/slides/hi/python-net/aspose.slides/section/) बनाने के बाद, आप उसका नाम बदलने का फैसला कर सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि प्रेजेंटेशन में सेक्शन का नाम कैसे बदलें:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर सेक्शन संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर सेक्शन समूहित करना खो जाता है।

**क्या पूरे सेक्शन को "छिपाया" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइडों को ही छिपाया जा सकता है। एक सेक्शन के रूप में किसी एंटिटी का "छिपा" स्थिति नहीं होता।

**क्या मैं किसी स्लाइड द्वारा सेक्शन को जल्दी से खोज सकता हूँ और इसके विपरीत, सेक्शन की पहली स्लाइड को पता कर सकता हूँ?**

हाँ। एक सेक्शन को उसकी प्रारंभिक स्लाइड द्वारा अद्वितीय रूप से परिभाषित किया जाता है; किसी स्लाइड से आप निर्धारित कर सकते हैं कि वह किस सेक्शन से संबंधित है, और किसी सेक्शन के लिए आप उसकी पहली स्लाइड तक पहुँच सकते हैं।