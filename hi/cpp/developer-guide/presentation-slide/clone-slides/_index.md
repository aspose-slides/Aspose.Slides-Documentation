---
title: C++ में प्रेजेंटेशन स्लाइड्स क्लोन करें
linktitle: स्लाइड क्लोन करें
type: docs
weight: 40
url: /hi/cpp/clone-slides/
keywords:
- स्लाइड क्लोन
- स्लाइड कॉपी
- स्लाइड सहेजें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइड्स को शीघ्रता से दोहराएँ। सेकंडों में PPT निर्माण को स्वचालित करने और मैन्युअल कार्य को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरणों का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसमें किसी चीज़ की बिल्कुल समान प्रतिलिपि या प्रतिरूप बनाया जाता है। Aspose.Slides for C++ यह भी संभव बनाता है कि किसी भी स्लाइड की प्रतिलिपि या क्लोन बनाया जाए और फिर उस क्लोन की गई स्लाइड को वर्तमान या किसी अन्य खुले प्रेजेंटेशन में सम्मिलित किया जाए। स्लाइड क्लोनिंग की प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभावित तरीके हैं:

- प्रेजेंटेशन के भीतर अंत में क्लोन करें।
- प्रेजेंटेशन के भीतर किसी अन्य स्थिति में क्लोन करें।
- दूसरे प्रेजेंटेशन में अंत में क्लोन करें।
- दूसरे प्रेजेंटेशन में किसी अन्य स्थिति में क्लोन करें।
- दूसरे प्रेजेंटेशन में विशिष्ट स्थिति में क्लोन करें।

Aspose.Slides for C++ में, (एक संग्रह [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) ऑब्जेक्ट्स) जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट द्वारा प्रदर्शित होता है, [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) और [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) मेथड्स प्रदान करता है ताकि ऊपर बताए गए स्लाइड क्लोनिंग प्रकारों को किया जा सके।

## **प्रेजेंटेशन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसी प्रेजेंटेशन फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास का उदहारण बनाएं, जो [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करता है।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड के पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन फ़ाइल लिखें।

निचे दिए गए उदाहरण में, हमने प्रेजेंटेशन की पहली स्थिति (शून्य इंडेक्स) पर स्थित एक स्लाइड को प्रेजेंटेशन के अंत में क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **प्रेजेंटेशन के भीतर किसी अन्य स्थिति में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल में लेकिन अलग स्थिति पर उपयोग करना चाहते हैं, तो [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट द्वारा प्रदर्शित **Slides** संग्रह को संदर्भित करके क्लास का उदाहरण बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को नई स्थिति के इंडेक्स के साथ पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

निचे दिए गए उदाहरण में, हमने प्रेजेंटेशन के शून्य इंडेक्स (स्थिति 1) पर स्थित एक स्लाइड को इंडेक्स 1 – स्थिति 2 पर क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **दूसरे प्रेजेंटेशन के अंत में स्लाइड क्लोन करें**
यदि आपको एक स्लाइड को एक प्रेजेंटेशन से क्लोन कर दूसरे प्रेजेंटेशन फ़ाइल में, मौजूदा स्लाइडों के अंत में उपयोग करने की आवश्यकता है:

1. स्रोत प्रेजेंटेशन को शामिल करने वाला [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन को शामिल करने वाला [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं जहाँ स्लाइड जोड़ी जाएगी।
1. गंतव्य प्रेजेंटेशन के Presentation ऑब्जेक्ट द्वारा प्रदर्शित **Slides** संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास का उदहारण बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन फ़ाइल लिखें।

निचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के पहले इंडेक्स से एक स्लाइड को गंतव्य प्रेजेंटेशन के अंत में क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **दूसरे प्रेजेंटेशन में किसी अन्य स्थिति में स्लाइड क्लोन करें**
यदि आपको एक स्लाइड को एक प्रेजेंटेशन से क्लोन कर दूसरे प्रेजेंटेशन फ़ाइल में, विशिष्ट स्थिति पर उपयोग करने की आवश्यकता है:

1. स्रोत प्रेजेंटेशन को शामिल करने वाला [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन को शामिल करने वाला [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास का उदहारण बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को इच्छित स्थिति के साथ पैरामीटर के रूप में पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन फ़ाइल लिखें।

निचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स से एक स्लाइड को गंतव्य प्रेजेंटेशन के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **दूसरे प्रेजेंटेशन में विशिष्ट स्थिति में स्लाइड क्लोन करें**
यदि आपको एक प्रेजेंटेशन से मास्टर स्लाइड के साथ स्लाइड को क्लोन कर दूसरे प्रेजेंटेशन में उपयोग करना है, तो पहले स्रोत प्रेजेंटेशन से वांछित मास्टर स्लाइड को गंतव्य प्रेजेंटेशन में क्लोन करें। फिर वह मास्टर स्लाइड का उपयोग करके मास्टर स्लाइड के साथ स्लाइड को क्लोन करें। **AddClone(ISlide, IMasterSlide)** विधि गंतव्य प्रेजेंटेशन से मास्टर स्लाइड की अपेक्षा करता है, स्रोत से नहीं। स्लाइड को मास्टर के साथ क्लोन करने के लिए नीचे दिए गये चरणों का पालन करें:

1. स्रोत प्रेजेंटेशन को शामिल करने वाला [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. गंतव्य प्रेजेंटेशन को शामिल करने वाला [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. स्लाइड को क्लोन करने के साथ-साथ मास्टर स्लाइड तक पहुंच प्राप्त करें।
1. गंतव्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट द्वारा प्रदर्शित Masters संग्रह को संदर्भित करके [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) क्लास का उदहारण बनाएं।
1. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड को कॉल करें और स्रोत PPTX से क्लोन की जाने वाली मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. गंतव्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास का उदहारण बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) ऑब्जेक्ट द्वारा प्रदान किए गए [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड तथा मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित गंतव्य प्रेजेंटेशन फ़ाइल लिखें।

निचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स पर स्थित एक स्लाइड (मास्टर के साथ) को स्रोत स्लाइड के मास्टर का उपयोग करते हुए गंतव्य प्रेजेंटेशन के अंत में क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **निर्दिष्ट सेक्शन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल में लेकिन अलग सेक्शन में उपयोग करना चाहते हैं, तो [**AddClone()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) मेथड का उपयोग करें जो [**ISlideCollection**](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) इंटरफ़ेस द्वारा प्रदान किया गया है। Aspose.Slides for C++ यह संभव बनाता है कि पहले सेक्शन से स्लाइड को क्लोन करके उसी प्रेजेंटेशन के दूसरे सेक्शन में सम्मिलित किया जाए।

निचे दिया गया कोड स्निपेट दिखाता है कि कैसे स्लाइड को क्लोन करके निर्दिष्ट सेक्शन में सम्मिलित किया जाए।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **स्लाइड आकार की संगतता सुनिश्चित करें**

जब स्लाइडों को किसी अन्य प्रेजेंटेशन में क्लोन किया जाता है, तो यह सुनिश्चित करें कि गंतव्य प्रेजेंटेशन का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार भिन्न हैं, तो Aspose.Slides क्लोन की गई आकृतियों का आकार स्वचालित रूप से नहीं बदलता—उनके मूल निर्देशांक और आयाम संरक्षित रहते हैं, जिससे सामग्री असंतुलित या स्लाइड की सीमाओं से परे दिख सकती है।

आप क्लोनिंग से पहले स्रोत के अनुरूप गंतव्य प्रेजेंटेशन के स्लाइड आकार को सेट कर सकते हैं:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

क्लोन करने से पहले यह कार्य करें।

## **अक्सर पूछे जाने वाले प्रश्न**
**क्या स्पीकर नोट्स और समीक्षक टिप्पणी क्लोन होती हैं?**  
हाँ। नोट्स पेज और रिव्यू टिप्पणी क्लोन में शामिल होते हैं। यदि आप उन्हें नहीं चाहते हैं, तो सम्मिलन के बाद [उन्हें हटाएँ](/slides/hi/cpp/presentation-notes/)।

**चार्ट और उनके डेटा स्रोत कैसे संभाले जाते हैं?**  
चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एम्बेडेड डेटा कॉपी हो जाते हैं। यदि चार्ट बाहरी स्रोत (जैसे OLE‑एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE object](/slides/hi/cpp/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रीफ़्रेश व्यवहार की पुष्टि करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन को नियंत्रित कर सकता हूँ?**  
हाँ। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर उसे चुनी हुई [section](/slides/hi/cpp/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।