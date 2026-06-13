---
title: "C++ में प्रस्तुति स्लाइड्स को क्लोन करें"
linktitle: "स्लाइड्स को क्लोन करें"
type: docs
weight: 40
url: /hi/cpp/clone-slides/
keywords:
- "स्लाइड क्लोन"
- "स्लाइड कॉपी"
- "स्लाइड सहेजें"
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइड्स को तेज़ी से डुप्लिकेट करें। सेकंडों में PPT बनाना स्वचालित करने और मैनुअल कार्य को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरणों का पालन करें।"
---
## **परिचय**

क्लोनिंग किसी वस्तु की बिल्कुल समान प्रति या प्रतिरूप बनाने की प्रक्रिया है। Aspose.Slides for C++ किसी भी स्लाइड की प्रति या क्लोन बनाने और फिर उस क्लोन की स्लाइड को वर्तमान या किसी अन्य खुले प्रेजेंटेशन में सम्मिलित करने को संभव बनाता है। स्लाइड क्लोनिंग की प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभावित तरीके हैं:

- प्रेजेंटेशन के भीतर अंत में क्लोन।
- प्रेजेंटेशन के भीतर किसी अन्य स्थान पर क्लोन।
- दूसरे प्रेजेंटेशन में अंत में क्लोन।
- दूसरे प्रेजेंटेशन में किसी अन्य स्थान पर क्लोन।
- दूसरे प्रेजेंटेशन में विशेष स्थान पर क्लोन।

Aspose.Slides for C++ में, [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वस्तु द्वारा प्रदर्शित (एक [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) वस्तुओं का संग्रह) [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) और [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) विधियाँ प्रदान करता है जिससे उपरोक्त प्रकार की स्लाइड क्लोनिंग की जा सकती है।

## **प्रेजेंटेशन के अंत में एक स्लाइड को क्लोन करें**
यदि आप कोई स्लाइड क्लोन करके उसे उसी प्रेजेंटेशन फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) विधि का प्रयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वस्तु द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास की instance बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) वस्तु द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) विधि को कॉल करें और क्लोन की जानी वाली स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने एक स्लाइड (जो प्रेजेंटेशन में प्रथम स्थिति – शून्य इंडेक्स – पर थी) को प्रेजेंटेशन के अंत में क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **प्रेजेंटेशन के भीतर दूसरे स्थान पर स्लाइड को क्लोन करें**
यदि आप स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल में लेकिन अलग स्थान पर उपयोग करना चाहते हैं, तो [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) विधि का प्रयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वस्तु द्वारा प्रदर्शित **Slides** संग्रह को संदर्भित करके क्लास की instance बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) वस्तु द्वारा प्रदर्शित [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) विधि को कॉल करें और क्लोन की जानी वाली स्लाइड को नई स्थिति के इंडेक्स के साथ पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने एक स्लाइड (जो प्रेजेंटेशन में शून्य इंडेक्स – स्थिति 1 – पर थी) को इंडेक्स 1 – स्थिति 2 – पर क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **दूसरे प्रेजेंटेशन के अंत में स्लाइड को क्लोन करें**
यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके उसे किसी अन्य प्रेजेंटेशन फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना है:

1. स्लाइड के स्रोत प्रेजेंटेशन को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. स्लाइड को जोड़ने वाले लक्ष्य प्रेजेंटेशन को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. लक्ष्य प्रेजेंटेशन के Presentation वस्तु द्वारा प्रदर्शित **Slides** संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास की instance बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) वस्तु द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) विधि को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के प्रथम इंडेक्स से स्लाइड को लक्ष्य प्रेजेंटेशन के अंत में क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **दूसरे प्रेजेंटेशन में दूसरे स्थान पर स्लाइड को क्लोन करें**
यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके उसे किसी अन्य प्रेजेंटेशन फ़ाइल में किसी विशिष्ट स्थान पर उपयोग करना है:

1. स्लाइड के स्रोत प्रेजेंटेशन को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. स्लाइड को जोड़ने वाले प्रेजेंटेशन को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. लक्ष्य प्रेजेंटेशन के Presentation वस्तु द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास की instance बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) वस्तु द्वारा प्रदर्शित [InsertClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/insertclone/) विधि को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को वांछित स्थिति के साथ पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स से स्लाइड को लक्ष्य प्रेजेंटेशन के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **दूसरे प्रेजेंटेशन में विशिष्ट स्थान पर स्लाइड को क्लोन करें**
यदि आपको एक प्रेजेंटेशन से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके उसे दूसरे प्रेजेंटेशन में उपयोग करना है, तो पहले स्रोत प्रेजेंटेशन से वांछित मास्टर स्लाइड को लक्ष्य प्रेजेंटेशन में क्लोन करना होगा। फिर उस मास्टर स्लाइड का उपयोग करके मास्टर स्लाइड के साथ स्लाइड को क्लोन करें। **AddClone(ISlide, IMasterSlide)** विधि लक्ष्य प्रेजेंटेशन की मास्टर स्लाइड की अपेक्षा करती है, स्रोत प्रेजेंटेशन की नहीं। स्लाइड को मास्टर के साथ क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. स्रोत प्रेजेंटेशन को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. लक्ष्य प्रेजेंटेशन को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की instance बनाएं।
1. मास्टर स्लाइड के साथ क्लोन की जाने वाली स्लाइड तक पहुँचें।
1. लक्ष्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वस्तु द्वारा प्रदर्शित Masters संग्रह को संदर्भित करके [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) क्लास की instance बनाएं।
1. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imasterslidecollection/) वस्तु द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) विधि को कॉल करें और स्रोत PPTX से क्लोन की जाने वाली मास्टर को पैरामीटर के रूप में पास करें।
1. लक्ष्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) वस्तु द्वारा प्रदर्शित Slides संग्रह का संदर्भ सेट करके [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) क्लास की instance बनाएं।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) वस्तु द्वारा प्रदर्शित [AddClone](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) विधि को कॉल करें और स्रोत प्रेजेंटेशन से क्लोन की जाने वाली स्लाइड तथा मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स पर स्थित मास्टर के साथ स्लाइड को स्रोत स्लाइड की मास्टर का उपयोग करके लक्ष्य प्रेजेंटेशन के अंत में क्लोन किया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **निर्दिष्ट सेक्शन के अंत में स्लाइड को क्लोन करें**
यदि आप कोई स्लाइड क्लोन करके उसे समान प्रेजेंटेशन फ़ाइल में लेकिन अलग सेक्शन में उपयोग करना चाहते हैं, तो [**ISlideCollection**](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/) इंटरफ़ेस द्वारा प्रदर्शित [**AddClone()**](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidecollection/addclone/) विधि का प्रयोग करें। Aspose.Slides for C++ को पहली सेक्शन से स्लाइड को क्लोन करके उसी प्रेजेंटेशन की दूसरी सेक्शन में सम्मिलित करने की सुविधा देता है।

निम्नलिखित कोड स्निपेट दिखाता है कि कैसे स्लाइड को क्लोन करें और क्लोन की गई स्लाइड को एक निर्दिष्ट सेक्शन में सम्मिलित करें।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन होते हैं?**

हाँ। नोट्स पेज और रिव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते, तो सम्मिलन के बाद [उन्हें हटाएँ](/slides/hi/cpp/presentation-notes/) ।

**चार्ट्स और उनके डेटा स्रोतों को कैसे संभाला जाता है?**

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग, और एम्बेडेड डेटा कॉपी हो जाता है। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से लिंक्ड था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/cpp/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरण के बाद, डेटा उपलब्धता और रिफ्रेश व्यवहार को सत्यापित करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन को नियंत्रित कर सकता हूँ?**

हाँ। आप क्लोन को एक विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चयनित [सेक्शन](/slides/hi/cpp/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।