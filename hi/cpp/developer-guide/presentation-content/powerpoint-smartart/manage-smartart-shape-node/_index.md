---
title: C++ का उपयोग करके प्रस्तुतियों में SmartArt Shape Nodes प्रबंधित करें
linktitle: SmartArt Shape नोड
type: docs
weight: 30
url: /hi/cpp/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड एक्सेस करें
- नोड हटाएँ
- कस्टम स्थिति
- असिस्टेंट नोड
- फिल फ़ॉर्मेट
- नोड रेंडर करें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PPT और PPTX में SmartArt shape नोड्स को प्रबंधित करें। अपने प्रस्तुतियों को सुव्यवस्थित करने के लिए स्पष्ट कोड नमूने और टिप्स प्राप्त करें।"
---
## **समीक्षा**

PowerPoint प्रस्तुतियों में SmartArt ग्राफिक्स को उन नोड्स के द्वारा व्यवस्थित किया जाता है जो टेक्स्ट रखते हैं और डायग्राम की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की सुविधा देता है: नए नोड और चाइल्ड नोड जोड़ना, चाइल्ड नोड को विशिष्ट स्थिति में सम्मिलित करना, मौजूदा नोड्स तक पहुंचना, तथा उनका टेक्स्ट, लेवल और पोजीशन पढ़ना।

यह लेख SmartArt शेप नोड्स को प्रबंधित करने के तरीकों को समझाता है। यह दर्शाता है कि नोड्स को कैसे हटाएँ, इंडेक्स या पोजीशन द्वारा चाइल्ड नोड्स के साथ कैसे काम करें, एक असिस्टेंट नोड को सामान्य नोड में बदलें, SmartArt नोड शेप की पोजीशन, साइज और रोटेशन को एडजस्ट करें, नोड फाइल फ़ॉर्मेट सेट करें, और SmartArt चाइल्ड नोड के लिए थंबनेल इमेज जेनरेट करें।

## **SmartArt नोड जोड़ें**
Aspose.Slides for C++ ने SmartArt शेप्स को सबसे आसान तरीके से मैनेज करने के लिए सबसे सरल API प्रदान किया है। नीचे दिया गया नमूना कोड SmartArt शेप के अंदर नोड और चाइल्ड नोड जोड़ने में मदद करेगा।

- एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वर्ग की इंस्टेंस बनाएँ और SmartArt Shape के साथ प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है या नहीं और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- SmartArt शेप की NodeCollection में एक नया Node जोड़ें और TextFrame में टेक्स्ट सेट करें।
- अब, नए जोड़े गए SmartArt Node में एक चाइल्ड Node जोड़ें और TextFrame में टेक्स्ट सेट करें।
- प्रेजेंटेशन को सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
नीचे दिए गए नमूना कोड में हम समझाते हैं कि कैसे SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को विशेष स्थिति पर जोड़ें।

- `Presentation` वर्ग की एक इंस्टेंस बनाएँ।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- एक्सेस की गई स्लाइड में एक StackedList प्रकार का SmartArt शेप जोड़ें।
- जोड़े गए SmartArt शेप में पहला नोड एक्सेस करें।
- अब, चयनित नोड के लिए स्थिति 2 पर चाइल्ड Node जोड़ें और उसका टेक्स्ट सेट करें।
- प्रेजेंटेशन को सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **SmartArt नोड एक्सेस करें**
निम्न नमूना कोड SmartArt शेप के भीतर नोड्स को एक्सेस करने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt की LayoutType को नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल तब सेट होती है जब SmartArt शेप जोड़ा जाता है।

- `Presentation` वर्ग की एक इंस्टेंस बनाएँ और SmartArt Shape के साथ प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है या नहीं और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- SmartArt Shape के भीतर सभी नोड्स को ट्रैवर्स करें।
- SmartArt नोड की पोजीशन, लेवल और टेक्स्ट जैसी जानकारी एक्सेस और प्रदर्शित करें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **SmartArt चाइल्ड नोड एक्सेस करें**
निम्न नमूना कोड आपको SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को एक्सेस करने में मदद करेगा।

- `PresentationEx` वर्ग की एक इंस्टेंस बनाएँ और SmartArt Shape के साथ प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है या नहीं और यदि है तो चयनित शेप को SmartArtEx में टाइपकास्ट करें।
- SmartArt Shape के भीतर सभी नोड्स को ट्रैवर्स करें।
- प्रत्येक चयनित SmartArt शेप नोड के लिए, विशेष नोड के भीतर सभी चाइल्ड नोड्स को ट्रैवर्स करें।
- चाइल्ड नोड की पोजीशन, लेवल और टेक्स्ट जैसी जानकारी एक्सेस और प्रदर्शित करें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **विशिष्ट स्थिति पर SmartArt चाइल्ड नोड एक्सेस करें**
इस उदाहरण में हम सीखेंगे कि कैसे SmartArt शेप के संबंधित नोड्स के चाइल्ड नोड्स को कुछ विशिष्ट स्थिति पर एक्सेस करें।

- `Presentation` वर्ग की एक इंस्टेंस बनाएँ।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- StackedList प्रकार का SmartArt शेप जोड़ें।
- जोड़े गए SmartArt शेप को एक्सेस करें।
- एक्सेस किए गए SmartArt शेप के लिए इंडेक्स 0 पर नोड एक्सेस करें।
- अब, GetNodeByPosition() मेथड का उपयोग करके एक्सेस किए गए SmartArt नोड के लिए स्थिति 1 पर चाइल्ड नोड एक्सेस करें।
- चाइल्ड नोड की पोजीशन, लेवल और टेक्स्ट जैसी जानकारी एक्सेस और प्रदर्शित करें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि SmartArt शेप के भीतर नोड्स को कैसे हटाएँ।

- `Presentation` वर्ग की एक इंस्टेंस बनाएँ और SmartArt Shape के साथ प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है या नहीं और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- जांचें कि SmartArt में 0 से अधिक नोड्स हैं या नहीं।
- हटाने के लिए SmartArt नोड चुनें।
- अब, RemoveNode() मेथड का उपयोग करके चयनित नोड को हटाएँ और प्रेजेंटेशन सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **विशिष्ट स्थिति पर SmartArt नोड हटाएँ**
इस उदाहरण में हम सीखेंगे कि कैसे SmartArt शेप के भीतर नोड्स को विशिष्ट स्थिति पर हटाएँ।

- `Presentation` वर्ग की एक इंस्टेंस बनाएँ और SmartArt Shape के साथ प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके पहली स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है या नहीं और यदि है तो चयनित शेप को SmartArt में टाइपकास्ट करें।
- इंडेक्स 0 पर SmartArt शेप नोड चुनें।
- अब, जांचें कि चयनित SmartArt नोड में 2 से अधिक चाइल्ड नोड्स हैं या नहीं।
- अब, RemoveNodeByPosition() मेथड का उपयोग करके स्थिति 1 पर नोड हटाएँ।
- प्रेजेंटेशन को सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **SmartArt चाइल्ड नोड के लिए कस्टम पोजीशन सेट करें**
अब Aspose.Slides SmartArtShape की X और Y प्रॉपर्टीज़ सेट करने का समर्थन करता है। नीचे दिया गया कोड स्निपेट दिखाता है कि कैसे कस्टम SmartArtShape पोजीशन, साइज और रोटेशन सेट करें; साथ ही कृपया ध्यान दें कि नए नोड जोड़ने से सभी नोड्स की पोजीशन और साइज का पुनर्गणना होती है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **एक असिस्टेंट नोड जांचें**
निम्न नमूना कोड में हम यह जांचेंगे कि कैसे SmartArt नोड्स कलेक्शन में असिस्टेंट नोड्स की पहचान करें और उन्हें बदलें।

- `PresentationEx` वर्ग की एक इंस्टेंस बनाएँ और SmartArt Shape के साथ प्रेजेंटेशन लोड करें।
- उसके Index का उपयोग करके दूसरी स्लाइड का रेफ़रेंस प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक शेप को ट्रैवर्स करें।
- जांचें कि शेप SmartArt प्रकार का है या नहीं और यदि है तो चयनित शेप को SmartArtEx में टाइपकास्ट करें।
- SmartArt Shape के सभी नोड्स को ट्रैवर्स करें और जांचें कि वे असिस्टेंट नोड्स हैं या नहीं।
- असिस्टेंट नोड की स्थिति को सामान्य नोड में बदलें।
- प्रेजेंटेशन को सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **नोड का Fill Format सेट करें**
Aspose.Slides for C++ कस्टम SmartArt शेप्स जोड़ने और उनके Fill Format सेट करने को संभव बनाता है। यह लेख समझाता है कि कैसे SmartArt शेप्स बनाएँ और एक्सेस करें और Aspose.Slides for C++ का उपयोग करके उनका Fill Format सेट करें।

कृपया नीचे दिए गए कदमों का पालन करें:

- `Presentation` वर्ग की एक इंस्टेंस बनाएँ।
- उसके Index का उपयोग करके एक स्लाइड का रेफ़रेंस प्राप्त करें।
- LayoutType सेट करके एक SmartArt शेप जोड़ें।
- SmartArt शेप नोड्स के लिए FillFormat सेट करें।
- संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **SmartArt चाइल्ड नोड का थंबनेल जेनरेट करें**
डेवलपर्स नीचे दिए गए चरणों का पालन करके SmartArt के चाइल्ड नोड का थंबनेल जेनरेट कर सकते हैं:

1. `Presentation` वर्ग की इंस्टेंस बनाएँ जो PPTX फ़ाइल का प्रतिनिधित्व करता है।
2. SmartArt जोड़ें।
3. उसके Index का उपयोग करके एक नोड का रेफ़रेंस प्राप्त करें।
4. थंबनेल इमेज प्राप्त करें।
5. थंबनेल इमेज को किसी भी वांछित इमेज फ़ॉर्मेट में सहेजें।

नीचे दिया गया उदाहरण SmartArt चाइल्ड नोड का थंबनेल जेनरेट करता है

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**क्या SmartArt एनीमेशन समर्थित है?**

हां। SmartArt को सामान्य शेप के रूप में माना जाता है, इसलिए आप [standard animations](/slides/hi/cpp/shape-animation/) (प्रवेश, निकास, ज़ोर, मोशन पाथ) लागू कर सकते हैं और टाइमिंग समायोजित कर सकते हैं। आवश्यकता पर आप SmartArt नोड्स के भीतर शेप्स को भी एनीमेट कर सकते हैं।

**यदि किसी स्लाइड पर SmartArt का आंतरिक ID ज्ञात नहीं है तो उसे भरोसेमंद रूप से कैसे locate करें?**

[alternative text](/reference.aspose.com/slides/hi/cpp/aspose.slides/shape/set_alternativetext/) सेट करके और उसे खोजें। SmartArt पर विशिष्ट AltText सेट करने से आप उसे प्रोग्रामेटिक रूप से बिना आंतरिक पहचानकर्ताओं पर निर्भर हुए खोज सकते हैं।

**क्या प्रेजेंटेशन को PDF में कनवर्ट करने पर SmartArt का लुक बरकरार रहेगा?**

हां। Aspose.Slides PDF एक्सपोर्ट के दौरान [PDF export](/slides/hi/cpp/convert-powerpoint-to-pdf/) में SmartArt को उच्च विज़ुअल फ़िडेलिटी के साथ रेंडर करता है, जिससे लेआउट, रंग और इफ़ेक्ट्स संरक्षित रहते हैं।

**क्या मैं पूर्ण SmartArt की इमेज (प्रिव्यू या रिपोर्ट के लिए) निकाल सकता हूँ?**

हां। आप SmartArt शेप को [raster formats](/reference.aspose.com/slides/hi/cpp/aspose.slides/shape/getimage/) या [SVG](/reference.aspose.com/slides/hi/cpp/aspose.slides/shape/writeassvg/) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए स्केलेबल वेक्टर आउटपुट प्राप्त होता है।