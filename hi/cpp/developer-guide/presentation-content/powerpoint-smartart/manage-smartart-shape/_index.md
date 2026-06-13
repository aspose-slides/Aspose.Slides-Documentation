---
title: C++ का उपयोग करके प्रस्तुतियों में SmartArt ग्राफ़िक्स प्रबंधित करें
linktitle: SmartArt ग्राफ़िक्स
type: docs
weight: 20
url: /hi/cpp/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफ़िक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt तक पहुंचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में PowerPoint SmartArt निर्माण, संपादन और स्टाइलिंग को स्वचालित करें, संक्षिप्त कोड उदाहरणों और प्रदर्शन-केंद्रित मार्गदर्शन के साथ।"
---
## **सारांश**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स बनाने और प्रबंधित करने की अनुमति देता है। यह लेख समझाता है कि कैसे एक SmartArt आकार को स्लाइड में जोड़ें, मौजूदा SmartArt आकारों तक पहुँचें, विशेष लेआउट प्रकार द्वारा SmartArt खोजें, और SmartArt शैली या रंग शैली बदलकर उसके दृश्य स्वरूप को अपडेट करें।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड के आकार संग्रह के माध्यम से SmartArt आकारों के साथ कैसे काम करें, जाँचें कि कोई आकार SmartArt है या नहीं, और फिर उसकी विशेषताओं को संशोधित या निरीक्षण करें।

## **SmartArt आकार बनाएं**
Aspose.Slides for C++ अब शुरू से अपनी स्लाइड में कस्टम SmartArt आकार जोड़ना संभव बनाता है। Aspose.Slides for C++ ने SmartArt आकार बनाने के लिए सबसे सरल API प्रदान किया है। स्लाइड में SmartArt आकार बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
- इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- LayoutType सेट करके एक SmartArt आकार जोड़ें।
- संशोधित प्रस्तुतिकरण को PPTX फ़ाइल के रूप में लिखें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **स्लाइड पर SmartArt आकार तक पहुँचें**
निम्नलिखित कोड का उपयोग प्रस्तुति स्लाइड में जोड़े गए SmartArt आकारों तक पहुँचने के लिए किया जाएगा। नमूना कोड में हम स्लाइड के भीतर प्रत्येक आकार के माध्यम से यात्रा करेंगे और जाँचेंगे कि क्या वह SmartArt आकार है। यदि आकार SmartArt प्रकार का है तो हम उसे SmartArt उदाहरण में टाइपकास्ट करेंगे।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **विशिष्ट लेआउट प्रकार के साथ SmartArt आकार तक पहुँचें**
निम्नलिखित नमूना कोड विशिष्ट LayoutType वाले SmartArt आकार तक पहुँचने में मदद करेगा। कृपया ध्यान दें कि आप SmartArt का LayoutType नहीं बदल सकते क्योंकि यह केवल पढ़ने योग्य है और केवल SmartArt आकार जोड़े जाने के समय ही सेट किया जाता है।

- `Presentation` क्लास का एक उदाहरण बनाएँ और SmartArt आकार के साथ प्रस्तुति लोड करें।
- इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से यात्रा करें।
- जाँचें कि आकार SmartArt प्रकार का है और यदि है तो चयनित आकार को SmartArt में टाइपकास्ट करें।
- विशिष्ट LayoutType वाले SmartArt आकार को जाँचें और उसके बाद आवश्यक कार्य करें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **SmartArt आकार शैली बदलें**
निम्नलिखित नमूना कोड विशिष्ट LayoutType वाले SmartArt आकार तक पहुँचने में मदद करेगा।

- `Presentation` क्लास का एक उदाहरण बनाएँ और SmartArt आकार के साथ प्रस्तुति लोड करें।
- इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से यात्रा करें।
- जाँचें कि आकार SmartArt प्रकार का है और यदि है तो चयनित आकार को SmartArt में टाइपकास्ट करें।
- विशिष्ट शैली वाले SmartArt आकार को खोजें।
- SmartArt आकार के लिए नई शैली सेट करें।
- प्रस्तुति को सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **SmartArt आकार रंग शैली बदलें**
इस उदाहरण में, हम किसी भी SmartArt आकार की रंग शैली बदलना सीखेंगे। निम्नलिखित नमूना कोड विशिष्ट रंग शैली वाले SmartArt आकार तक पहुँचाएगा और उसकी शैली बदल देगा।

- `Presentation` क्लास का एक उदाहरण बनाएँ और SmartArt आकार के साथ प्रस्तुति लोड करें।
- इंडेक्स का उपयोग करके पहली स्लाइड का संदर्भ प्राप्त करें।
- पहली स्लाइड के भीतर प्रत्येक आकार के माध्यम से यात्रा करें।
- जाँचें कि आकार SmartArt प्रकार का है और यदि है तो चयनित आकार को SmartArt में टाइपकास्ट करें।
- विशिष्ट रंग शैली वाले SmartArt आकार को खोजें।
- SmartArt आकार के लिए नई रंग शैली सेट करें।
- प्रस्तुति को सहेजें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Can I animate SmartArt as a single object?**

हाँ। SmartArt एक आकार है, इसलिए आप एनीमेशन API के माध्यम से [standard animations](/slides/hi/cpp/powerpoint-animation/) (प्रवेश, निकास, ज़ोर, गति पथ) लागू कर सकते हैं, बिलकुल अन्य आकारों की तरह।

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

वैकल्पिक टेक्स्ट (AltText) सेट करके उसे उपयोग करें और उस मान द्वारा आकार को खोजें—यह लक्ष्य आकार खोजने का अनुशंसित तरीका है।

**Can I group SmartArt with other shapes?**

हाँ। आप SmartArt को अन्य आकारों (चित्र, तालिकाएँ, आदि) के साथ समूहित कर सकते हैं और फिर [manipulate the group](/slides/hi/cpp/group/)।

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

आकार का एक थंबनेल/इमेज निर्यात करें; लाइब्रेरी [render individual shapes](/slides/hi/cpp/create-shape-thumbnails/) को रास्टर फ़ाइलों (PNG/JPG/TIFF) में रेंडर कर सकती है।

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

हाँ। रेंडरिंग इंजन [PDF export](/slides/hi/cpp/convert-powerpoint-to-pdf/) के लिए उच्च सटीकता लक्षित करता है, जिसमें गुणवत्ता और संगतता विकल्पों की एक श्रृंखला है।