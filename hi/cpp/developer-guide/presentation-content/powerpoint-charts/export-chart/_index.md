---
title: C++ में प्रस्तुति चार्ट निर्यात करें
linktitle: चार्ट निर्यात करें
type: docs
weight: 90
url: /hi/cpp/export-chart/
keywords:
- चार्ट
- चार्ट से छवि
- छवि के रूप में चार्ट
- चार्ट छवि निकालें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुतीकरण चार्ट निर्यात करना सीखें, जो PPT और PPTX फॉर्मेट को सपोर्ट करता है, और किसी भी कार्यप्रवाह में रिपोर्टिंग को सुगम बनाता है।"
---
## **Overview**

Aspose.Slides आपको प्रस्तुति से चार्ट को छवि के रूप में निर्यात करने की अनुमति देता है। यह लेख दिखाता है कि चार्ट से छवि कैसे प्राप्त करें और उसे सहेजें, जो तब उपयोगी है जब आपको PowerPoint प्रस्तुति के बाहर चार्ट विज़ुअल को पुनः उपयोग करना हो।

## **Get a Chart Image**
Aspose.Slides for C++ विशिष्ट चार्ट की छवि निकालने के समर्थन प्रदान करता है। नीचे दिया गया उदाहरण है।

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**क्या मैं चार्ट को रास्टर छवि के बजाय वेक्टर (SVG) के रूप में निर्यात कर सकता हूँ?**

हां। चार्ट एक shape है, और इसकी सामग्री को SVG में सहेजा जा सकता है[shape-to-SVG सहेजने की विधि](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/writeassvg/) का उपयोग करके।

**निर्यातित चार्ट का सटीक आकार पिक्सेल में कैसे निर्धारित करूँ?**

इमेज-रेन्डरिंग ओवरलोड्स का उपयोग करें जो आकार या स्केल निर्दिष्ट करने की अनुमति देते हैं—लाइब्रेरी दी गई आयाम/स्केल के साथ वस्तुओं को रेंडर करने का समर्थन करती है।

**निर्यात के बाद लेबल और लेजेंड में फ़ॉन्ट्स गलत दिख रहे हों तो क्या करना चाहिए?**

[आवश्यक फ़ॉन्ट्स लोड करें](/slides/hi/cpp/custom-font/)[FontsLoader](https://reference.aspose.com/slides/hi/cpp/aspose.slides/fontsloader/) के माध्यम से ताकि चार्ट का रेंडरिंग मीट्रिक और टेक्स्ट दिखावट को संरक्षित रखे।

**क्या निर्यात PowerPoint थीम, शैलियों और प्रभावों का सम्मान करता है?**

हां। Aspose.Slides का रेंडरर प्रस्तुति के फॉर्मेटिंग (थीम, शैलियां, फ़िल, प्रभाव) का पालन करता है, इसलिए चार्ट की उपस्थिति संरक्षित रहती है।

**चार्ट छवियों के अलावा उपलब्ध रेंडरिंग/निर्यात क्षमताओं को कहाँ पा सकता हूँ?**

[API](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/)/[डॉक्यूमेंटेशन](/slides/hi/cpp/convert-powerpoint/) के निर्यात अनुभाग देखें जहाँ आउटपुट टारगेट्स ([PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/hi/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/hi/cpp/convert-powerpoint-to-xps/), [HTML](/slides/hi/cpp/convert-powerpoint-to-html/), आदि) और संबंधित रेंडरिंग विकल्पों की जानकारी मिलती है।