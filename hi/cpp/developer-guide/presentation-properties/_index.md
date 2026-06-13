---
title: C++ में प्रस्तुति प्रॉपर्टीज़ का प्रबंधन
linktitle: प्रस्तुति प्रॉपर्टीज़
type: docs
weight: 70
url: /hi/cpp/presentation-properties/
keywords:
- PowerPoint प्रॉपर्टीज़
- प्रस्तुति प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- बिल्ट‑इन प्रॉपर्टीज़
- कस्टम प्रॉपर्टीज़
- एडवांस्ड प्रॉपर्टीज़
- प्रॉपर्टीज़ का प्रबंधन
- प्रॉपर्टीज़ का संशोधन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में प्रस्तुति प्रॉपर्टीज़ को पूर्ण रूप से नियंत्रित करें और अपने PowerPoint तथा OpenDocument फ़ाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सहज बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ प्रॉपर्टी को सपोर्ट करता है: **Built-in** और **Custom**। इन दोनों प्रॉपर्टी प्रकारों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ प्रॉपर्टी के साथ काम करने की अनुमति देता है जो [IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_document_properties) इंटरफ़ेस के माध्यम से है। इस इंटरफ़ेस का एक उदाहरण [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_documentproperties/) मेथड द्वारा लौटाया जाता है। निम्नलिखित उदाहरण दिखाते हैं कि इन प्रॉपर्टी को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="primary" %}} 
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड के मान सेट नहीं कर सकते हैं, क्योंकि Aspose Ltd. और Aspose.Slides for C++ x.x.x इन फ़ील्ड्स में प्रदर्शित होंगे।
{{% /alert %}} 

## **प्रेजेंटेशन प्रॉपर्टीज़ को प्रबंधित करें**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में कुछ प्रॉपर्टी जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ प्रॉपर्टी उपयोगी जानकारी को दस्तावेज़ों (प्रेजेंटेशन फ़ाइलों) के साथ संग्रहीत करने देती हैं। दस्तावेज़ प्रॉपर्टी दो प्रकार की होती हैं:

- System Defined (Built-in) प्रॉपर्टी
- User Defined (Custom) प्रॉपर्टी

**Built-in** प्रॉपर्टी दस्तावेज़ के सामान्य जानकारी जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ सांख्यिकी आदि को समाहित करती हैं। **Custom** प्रॉपर्टी वह होती हैं, जिन्हें उपयोगकर्ता **Name/Value** जोड़ों के रूप में परिभाषित करते हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for C++ का उपयोग करके डेवलपर Built-in और Custom दोनों प्रकार की प्रॉपर्टी के मानों को एक्सेस और संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ प्रॉपर्टी को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करके आगे **Prepare | Properties | Advanced Properties** मेनू आइटम चुनना है। **Advanced Properties** मेनू आइटम चुनने के बाद एक डायलॉग दिखाई देगा जो PowerPoint फ़ाइल की दस्तावेज़ प्रॉपर्टी को प्रबंधित करने की अनुमति देता है। **Properties Dialog** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General, Summary, Statistics, Contents and Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न जानकारी को कॉन्फ़िगर करने की सुविधा देते हैं। **Custom** टैब PowerPoint फ़ाइलों की कस्टम प्रॉपर्टी को प्रबंधित करने के लिए उपयोग किया जाता है।

## **Built-in प्रॉपर्टी का एक्सेस**

इन प्रॉपर्टी जो **IDocumentProperties** ऑब्जेक्ट द्वारा प्रदर्शित की गई हैं, में शामिल हैं: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न प्रोducers के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in प्रॉपर्टी का संशोधन**

प्रेजेंटेशन फ़ाइलों की Built-in प्रॉपर्टी को संशोधित करना उतना ही आसान है जितना उन्हें एक्सेस करना। आप किसी भी वांछित प्रॉपर्टी को सरलता से स्ट्रिंग मान असाइन कर सकते हैं और प्रॉपर्टी का मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दिखाया है कि कैसे प्रेजेंटेशन फ़ाइल की Built-in दस्तावेज़ प्रॉपर्टी को संशोधित किया जा सकता है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **कस्टम प्रेजेंटेशन प्रॉपर्टी जोड़ें**

Aspose.Slides for C++ डेवलपर्स को प्रस्तुति दस्तावेज़ प्रॉपर्टी के लिए कस्टम मान जोड़ने की सुविधा भी देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि प्रेजेंटेशन के लिए कस्टम प्रॉपर्टी कैसे सेट करें।

``` cpp
// Presentation क्लास का उदाहरण बनाएं
auto presentation = System::MakeObject<Presentation>();

// दस्तावेज़ प्रॉपर्टीज़ प्राप्त करना
auto documentProperties = presentation->get_DocumentProperties();

// कस्टम प्रॉपर्टीज़ जोड़ना
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// विशिष्ट इंडेक्स पर प्रॉपर्टी का नाम प्राप्त करना
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// चयनित प्रॉपर्टी को हटाना
documentProperties->RemoveCustomProperty(getPropertyName);

// प्रेजेंटेशन को सहेजना
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **कस्टम प्रॉपर्टी का एक्सेस और संशोधन**

Aspose.Slides for C++ डेवलपर्स को कस्टम प्रॉपर्टी के मानों को एक्सेस करने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रेजेंटेशन के सभी कस्टम प्रॉपर्टी को कैसे एक्सेस और संशोधित कर सकते हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) प्रॉपर्टी ([PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/) क्लास द्वारा प्रदर्शित) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ की प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण जांचा जाता है।

यह C++ कोड आपको दिखाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट करें:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह C++ कोड आपको दिखाता है कि पूरे PowerPoint प्रेजेंटेशन की डिफ़ॉल्ट भाषा कैसे सेट करें:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// टेक्स्ट के साथ एक नया आयताकार आकार जोड़ता है
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// पहले भाग की भाषा जाँचता है
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **लाइव उदाहरण**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन ऐप को आज़माएँ ताकि आप Aspose.Slides API के माध्यम से दस्तावेज़ प्रॉपर्टी के साथ कैसे काम करें, देख सकें:

[![PowerPoint मेटाडाटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***FAQ**

**मैं किसी प्रेजेंटेशन से Built-in प्रॉपर्टी को कैसे हटाऊँ?**

Built-in प्रॉपर्टी प्रस्तुति का अभिन्न हिस्सा हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उन मानों को बदल सकते हैं या यदि विशिष्ट प्रॉपर्टी अनुमति देती है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसी कस्टम प्रॉपर्टी जोड़ूँ जो पहले से मौजूद है तो क्या होता है?**

यदि आप ऐसी कस्टम प्रॉपर्टी जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले प्रॉपर्टी को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वतः प्रॉपर्टी के मान को अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना प्रेज़ेंटेशन प्रॉपर्टी को एक्सेस कर सकता हूँ?**

हां, आप [PresentationFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/) क्लास की `GetPresentationInfo` मेथड का उपयोग करके प्रेज़ेंटेशन को पूरी तरह लोड किए बिना उसकी प्रॉपर्टी को एक्सेस कर सकते हैं। फिर, आप [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) इंटरफ़ेस की `ReadDocumentProperties` मेथड का उपयोग कर प्रॉपर्टी को कुशलतापूर्वक पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन बेहतर होता है।