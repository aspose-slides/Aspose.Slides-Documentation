---
title: C++ का उपयोग करके प्रस्तुतियों में 3D चार्ट को कस्टमाइज़ करें
linktitle: 3D चार्ट
type: docs
url: /hi/cpp/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में 3‑D चार्ट बनाना और कस्टमाइज़ करना सीखें, PPT और PPTX फ़ाइलों के समर्थन के साथ—आज ही अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **सारांश**

यह लेख Aspose.Slides में `Rotation3D` सेटिंग्स जैसे `RotationX`, `RotationY`, `DepthPercents` और `RightAngleAxes` को कॉन्फ़िगर करके 3D चार्ट को कैसे कस्टमाइज़ किया जाए, समझाता है। यह एक प्रेजेंटेशन बनाने, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ने, आवश्यक 3D व्यू सेटिंग्स लागू करने और संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सहेजने की प्रक्रिया को दर्शाता है।

## **3D चार्ट की RotationX, RotationY और DepthPercents प्रॉपर्टीज़ सेट करना**
Aspose.Slides for C++ इन प्रॉपर्टीज़ को सेट करने के लिए एक सरल API प्रदान करता है। नीचे दिया गया लेख आपको X, Y Rotation, **DepthPercents** आदि जैसी विभिन्न प्रॉपर्टीज़ सेट करने में मदद करेगा। नमूना कोड ऊपर बताई गई प्रॉपर्टीज़ को लागू करता है।

1. Presentation क्लास का एक उदाहरण बनाएं।[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/)
2. पहली स्लाइड तक पहुंचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. Rotation3D प्रॉपर्टीज़ सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन सी चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D संस्करणों का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/charttype/) एन्नुमरेशन के माध्यम से उपलब्ध होते हैं। सटीक और अद्यतन सूची के लिए अपने स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/charttype/) सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हां। आप चार्ट को इमेज में एक्सपोर्ट करने के लिए [chart API](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/getimage/) का उपयोग कर सकते हैं या पूरे स्लाइड को [/slides/hi/cpp/convert-powerpoint-to-png/](/slides/hi/cpp/convert-powerpoint-to-png/) के माध्यम से PNG या JPEG जैसे फॉर्मेट में रेंडर कर सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल-परफेक्ट प्रीव्यू चाहिए या चार्ट को दस्तावेज़, डैशबोर्ड या वेब पेज में एम्बेड करना हो без PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाने और रेंडर करने में प्रदर्शन कैसा रहता है?**

प्रदर्शन डेटा की मात्रा और विज़ुअल जटिलता पर निर्भर करता है। सर्वश्रेष्ठ परिणाम के लिए 3D इफ़ेक्ट्स को न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रति श्रृंखला डेटा बिंदुओं की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुरूप आउटपुट (रेज़ोल्यूशन और डाइमेंशन) को उचित आकार में रेंडर करें।