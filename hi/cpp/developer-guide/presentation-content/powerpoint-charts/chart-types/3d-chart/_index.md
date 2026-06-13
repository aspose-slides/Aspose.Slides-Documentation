---
title: C++ का उपयोग करके प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
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
description: "Aspose.Slides के लिए C++ में 3-D चार्ट बनाना और अनुकूलित करना सीखें, PPT और PPTX फ़ाइलों के समर्थन के साथ — आज ही अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **परिचय**

यह लेख Aspose.Slides में `Rotation3D` सेटिंग्स जैसे `RotationX`, `RotationY`, `DepthPercents` और `RightAngleAxes` को कॉन्फ़िगर करके 3D चार्ट को अनुकूलित करने की प्रक्रिया को समझाता है। यह प्रस्तुतीकरण बनाने, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ने, आवश्यक 3D दृश्य सेटिंग्स लागू करने और संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में सहेजने की प्रक्रिया को चरण‑दर‑चरण दिखाता है।

## **3D चार्ट की RotationX, RotationY और DepthPercents गुण सेट करें**

Aspose.Slides for C++ इन गुणों को सेट करने के लिए एक सरल API प्रदान करता है। यह लेख आपको X, Y Rotation और **DepthPercents** आदि जैसे विभिन्न गुण सेट करने में मदद करेगा। नमूना कोड उपर्युक्त गुणों को सेट करने को दर्शाता है।

1. [प्रस्तुतीकरण](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class का एक उदाहरण बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. Rotation3D गुण सेट करें।
5. संशोधित प्रस्तुतीकरण को PPTX फ़ाइल में लिखें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड को समर्थन देते हैं?**

Aspose.Slides कॉलम चार्ट के 3D रूपों का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/charttype/) एन्यूमरेशन में प्रदर्शित हैं। सटीक और नवीनतम सूची के लिए, अपने स्थापित संस्करण के API संदर्भ में [ChartType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/charttype/) सदस्य देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हाँ। आप चार्ट को [चार्ट API](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shape/getimage/) के माध्यम से छवि में एक्सपोर्ट कर सकते हैं या [पूरी स्लाइड को रेंडर करें](/slides/hi/cpp/convert-powerpoint-to-png/) करके PNG या JPEG जैसे फॉर्मैट में बदल सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल‑परफेक्ट प्रीव्यू चाहिए या आप चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पेजों में एम्बेड करना चाहते हैं बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाना और रेंडर करना कितना प्रदर्शन देता है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D प्रभाव को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक सीरीज़ में डेटा पॉइंट्स की संख्या सीमित करें, और आउटपुट (रिज़ॉल्यूशन और आयाम) को लक्ष्य डिस्प्ले या प्रिंट की आवश्यकताओं के अनुसार उपयुक्त आकार में रेंडर करें।