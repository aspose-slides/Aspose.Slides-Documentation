---
title: "C++ में प्रस्तुति चार्ट निर्यात करें"
linktitle: "चार्ट निर्यात करें"
type: docs
weight: 90
url: /hi/cpp/export-chart/
keywords:
- "चार्ट"
- "चार्ट से इमेज"
- "चार्ट इमेज के रूप में"
- "चार्ट इमेज निकालें"
- "PowerPoint"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ प्रस्तुति चार्ट को निर्यात करना सीखें, PPT और PPTX फ़ॉर्मेट का समर्थन करता है, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सरल बनाएं।"
---
## **समीक्षा**

Aspose.Slides आपको प्रस्तुति से चार्ट को छवि के रूप में निर्यात करने की सुविधा देता है। यह लेख दिखाता है कि चार्ट से छवि कैसे प्राप्त करें और उसे सहेजें, जो तब उपयोगी होता है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट विज़ुअल को पुन: उपयोग करना हो।

## **चार्ट छवि प्राप्त करें**
Aspose.Slides for C++ विशेष चार्ट की छवि निकालने के लिए समर्थन प्रदान करता है। नीचे एक उदाहरण दिया गया है।

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट को रास्टर छवि के बजाय वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हाँ। एक चार्ट एक आकार है, और इसकी सामग्री को SVG में सहेजा जा सकता है, इसके लिए [shape-to-SVG saving method](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/writeassvg/) का उपयोग करें।

**निर्यात किए गए चार्ट का सटीक आकार पिक्सेल में कैसे निर्धारित करूँ?**

आकार या स्केल निर्दिष्ट करने के लिए इमेज-रेंडरिंग ओवरलोड का उपयोग करें—लाइब्रेरी दिए गए आयाम/स्केल के साथ वस्तुओं को रेंडर करने का समर्थन करती है।

**निर्यात के बाद लेबल और लेजेंड में फ़ॉन्ट गलत दिख रहे हों तो मुझे क्या करना चाहिए?**

[आवश्यक फ़ॉन्ट लोड करें](/slides/hi/cpp/custom-font/) को [FontsLoader](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/) के माध्यम से ताकि चार्ट रेंडरिंग मेट्रिक्स और टेक्स्ट के रूप को बरकरार रखे।

**क्या निर्यात PowerPoint थीम, शैलियों और प्रभावों का सम्मान करता है?**

हाँ। Aspose.Slides का रेंडरर प्रस्तुति के फॉर्मैटिंग (थीम, शैलियाँ, भराव, प्रभाव) का पालन करता है, इसलिए चार्ट की उपस्थिति बनी रहती है।

**चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/निर्यात क्षमताएँ मैं कहाँ खोज सकता हूँ?**

आऊटपुट टार्गेट्स ([PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/hi/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hi/cpp/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्पों के लिए [API](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/)/[documentation](/slides/hi/cpp/convert-powerpoint/) के निर्यात अनुभाग को देखें।