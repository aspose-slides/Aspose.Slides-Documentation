---
title: C++ में प्रस्तुति गुण प्रबंधित करें
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/cpp/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट-इन गुण
- कस्टम गुण
- उन्नत गुण
- गुण प्रबंधित करें
- गुण संशोधित करें
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादित करें
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint एवं OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को आसान बनाएं."
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों को समर्थन देता है: **Built-in** और **Custom**. इन दोनों प्रकार के गुणों को आसानी से Aspose.Slides API का उपयोग करके पहुँच और प्रबंधन किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है जो कि [IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_document_properties) इंटरफ़ेस के माध्यम से किया जाता है। इस इंटरफ़ेस की एक instance [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_documentproperties/) मेथड द्वारा लौटायी जाती है। निम्नलिखित उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।

{{% alert color="info" title="Note" %}}
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड्स के लिए मान सेट नहीं कर सकते हैं, क्योंकि इन फ़ील्ड्स में Aspose Ltd. और Aspose.Slides for C++ x.x.x प्रदर्शित होंगे।
{{% /alert %}} 

## **प्रेज़ेंटेशन गुणों का प्रबंधन**

Microsoft PowerPoint एक सुविधा प्रदान करता है जिससे आप प्रस्तुति फ़ाइलों में कुछ गुण जोड़ सकते हैं। ये दस्तावेज़ गुण दस्तावेज़ों (प्रेज़ेंटेशन फ़ाइलों) के साथ उपयोगी जानकारी संग्रहीत करने की अनुमति देते हैं। दस्तावेज़ गुणों के दो प्रकार हैं:

- सिस्टम-परिभाषित (Built-in) गुण
- उपयोगकर्ता-परिभाषित (Custom) गुण

**Built-in** गुण दस्तावेज़ के सामान्य जानकारी जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि को सम्मिलित करते हैं। **Custom** गुण वे होते हैं जिन्हें उपयोगकर्ता **Name/Value** युग्म के रूप में परिभाषित करता है, जहाँ दोनों नाम और मान उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for C++ का उपयोग करके, डेवलपर्स Built-in गुणों और Custom गुणों दोनों के मानों तक पहुँच और संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों का प्रबंधन करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और फिर Microsoft PowerPoint 2007 में **Prepare | Properties | Advanced Properties** मेन्यू आइटम चुनना है। **Advanced Properties** मेन्यू आइटम चुनने के बाद, एक डायलॉग बॉक्स प्रदर्शित होगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों का प्रबंधन करने की सुविधा देता है। **Properties Dialog** में, आप देख सकते हैं कि कई टैब पृष्ठ हैं जैसे **General, Summary, Statistics, Contents and Custom**। ये सभी टैब पृष्ठ PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणों का प्रबंधन करने के लिए उपयोग किया जाता है।

## **Built-in गुणों तक पहुँच**

इन गुणों को **IDocumentProperties** ऑब्जेक्ट के माध्यम से उजागर किया गया है, जिनमें शामिल हैं: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न प्रोड्यूसर्स के बीच साझा किया गया है?), **PresentationFormat**, **Subject**, और **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Built-in गुणों को संशोधित करें**

प्रेज़ेंटेशन फ़ाइलों के Built-in गुणों को संशोधित करना उतना ही आसान है जितना उन्हें पहुँचना। आप बस किसी भी इच्छित गुण को एक स्ट्रिंग मान असाइन कर सकते हैं और वह गुण का मान बदल जाएगा। नीचे दिए गए उदाहरण में, हमने यह प्रदर्शित किया है कि हम प्रस्तुति फ़ाइल के Built-in दस्तावेज़ गुणों को कैसे संशोधित कर सकते हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **कस्टम प्रेज़ेंटेशन गुण जोड़ें**

Aspose.Slides for C++ विकासकों को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि प्रस्तुति के लिए कस्टम गुण कैसे सेट करें।

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation क्लास को इंस्टैंसिएट करें
auto presentation = System::MakeObject<Presentation>();

// दस्तावेज़ गुण प्राप्त कर रहे हैं
auto documentProperties = presentation->get_DocumentProperties();

// कस्टम गुण जोड़ रहे हैं
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// विशिष्ट इंडेक्स पर गुण का नाम प्राप्त करना
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// चयनित गुण को हटाना
documentProperties->RemoveCustomProperty(getPropertyName);

// प्रेज़ेंटेशन सहेजना
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **कस्टम गुणों तक पहुँच और संशोधन**

Aspose.Slides for C++ विकासकों को कस्टम गुणों के मानों तक पहुँच की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रस्तुति के सभी कस्टम गुणों तक कैसे पहुँच सकते हैं और उन्हें संशोधित कर सकते हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) प्रॉपर्टी (जो [PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/) क्लास द्वारा उजागर की गई है) प्रदान करता है जिससे आप PowerPoint दस्तावेज़ के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह C++ कोड दिखाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट की जाए:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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
// प्रूफिंग भाषा का Id सेट करें

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **डिफ़ॉल्ट भाषा सेट करें**

यह C++ कोड दिखाता है कि पूरे PowerPoint प्रेज़ेंटेशन के लिए डिफ़ॉल्ट भाषा कैसे सेट की जाए:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// एक नया आयताकार आकार टेक्स्ट के साथ जोड़ता है
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// पहले भाग की भाषा की जाँच करता है
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **लाइव उदाहरण**

Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ कैसे काम करें, यह देखने के लिए [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) ऑनलाइन ऐप आज़माएँ:

[![PowerPoint मेटाडेटा देखें और संपादित करें](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से एक Built-in गुण कैसे हटा सकता हूँ?**

Built-in गुण प्रस्तुति का अभिन्न भाग होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशेष गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं पहले से मौजूद कस्टम गुण जोड़ता हूँ तो क्या होता है?**

यदि आप पहले से मौजूद कस्टम गुण जोड़ते हैं, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले से हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट कर देता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना प्रेज़ेंटेशन गुणों तक पहुँच सकता हूँ?**

हाँ। [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) का उपयोग करें और फिर [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) का उपयोग करके संग्रहीत दस्तावेज़ मेटाडेटा को बिना [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस बनाए पढ़ सकते हैं। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट-विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/cpp/examine-presentation/)।