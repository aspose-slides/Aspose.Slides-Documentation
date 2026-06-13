---
title: C++ में प्रस्तुतियों में लाइन शैप्स जोड़ें
linktitle: लाइन
type: docs
weight: 50
url: /hi/cpp/line/
keywords:
- लाइन
- लाइन बनाएं
- लाइन जोड़ें
- साधारण लाइन
- लाइन कॉन्फ़िगर करें
- लाइन अनुकूलित करें
- डैश शैली
- तीर सिरा
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में लाइन फॉर्मेटिंग को संशोधित करना सीखें। गुण, मेथड और उदाहरण जानें।"
---
## **सारांश**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint स्लाइडों में लाइन शेप्स जोड़ने की अनुमति देता है। यह लेख दिखाता है कि कैसे एक साधारण रेखा बनाई जाए और कैसे रेखा को इस प्रकार अनुकूलित किया जाए कि वह तीर जैसा दिखे।

आप सीखेंगे कि कैसे स्लाइड में एक लाइन शेप जोड़ा जाए, उसकी दृश्य उपस्थिति को समायोजित किया जाए, और अद्यतन प्रस्तुति को सहेजा जाए। उदाहरण व्यावहारिक लाइन फ़ॉर्मेटिंग सेटिंग्स जैसे शैली, चौड़ाई, डैश पैटर्न, तीर सिरों के विकल्प, और भरने के रंग पर केंद्रित हैं।

## **साधारण रेखा बनाएँ**
प्रेज़ेंटेशन की चयनित स्लाइड में एक साधारण रेखा जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation class](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) का उदाहरण बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए [AddAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addautoshape/) मेथड का उपयोग करके लाइन प्रकार का AutoShape जोड़ें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **तीर-आकार की रेखा बनाएँ**
Aspose.Slides for C++ डेवलपर्स को रेखा की कुछ संपत्तियों को कॉन्फ़िगर करने की सुविधा भी देता है ताकि वह अधिक आकर्षक दिखे। चलिए रेखा की कुछ संपत्तियों को इस प्रकार कॉन्फ़िगर करते हैं कि वह तीर जैसा दिखे। ऐसा करने के लिए नीचे दिए गए चरणों का पालन करें:

- एक [Presentation class](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) का उदाहरण बनाएं।
- इंडेक्स का उपयोग करके स्लाइड का संदर्भ प्राप्त करें।
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए [AddAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addautoshape/) मेथड का उपयोग करके लाइन प्रकार का AutoShape जोड़ें।
- Aspose.Slides for C++ द्वारा प्रस्तुत शैलियों में से एक को Line Style के रूप में सेट करें।
- रेखा की चौड़ाई सेट करें।
- रेखा के [Dash Style](https://reference.aspose.com/slides/hi/cpp/aspose.slides/linedashstyle/) को Aspose.Slides for C++ द्वारा पेश की गई शैलियों में से एक पर सेट करें।
- रेखा के प्रारम्भ बिंदु के [Arrow Head Style](https://reference.aspose.com/slides/hi/cpp/aspose.slides/lineformat/) और लंबाई सेट करें।
- रेखा के अंत बिंदु के Arrow Head Style और लंबाई सेट करें।
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक सामान्य रेखा को कनेक्टर में बदल सकता हूँ ताकि वह आकारों पर “स्नैप” हो जाए?**

नहीं। एक सामान्य रेखा (एक [AutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/autoshape/) प्रकार [Line](https://reference.aspose.com/slides/hi/cpp/aspose.slides/shapetype/)) स्वतः ही कनेक्टर नहीं बनती। इसे आकारों पर स्नैप करने के लिए, समर्पित [Connector](https://reference.aspose.com/slides/hi/cpp/aspose.slides/connector/) प्रकार और कनेक्शनों के लिए [corresponding APIs](/slides/hi/cpp/connector/) का उपयोग करें।

**यदि किसी रेखा की विशेषताएँ थीम से विरासत में मिली हों और अंतिम मान निर्धारित करना कठिन हो, तो मुझे क्या करना चाहिए?**

[इन प्रभावी गुणों को पढ़ें](/slides/hi/cpp/shape-effective-properties/) [ILineFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ilinefillformateffectivedata/) इंटरफ़ेस के माध्यम से — ये पहले से ही विरासत और थीम शैलियों को ध्यान में रखते हैं।

**क्या मैं रेखा को संपादन (स्थानांतरित करना, आकार बदलना) से लॉक कर सकता हूँ?**

हाँ। Shapes [lock objects](https://reference.aspose.com/slides/hi/cpp/aspose.slides/autoshape/get_autoshapelock/) प्रदान करती हैं जो आपको [editing operations को निषिद्ध करने](/slides/hi/cpp/applying-protection-to-presentation/) देती हैं।