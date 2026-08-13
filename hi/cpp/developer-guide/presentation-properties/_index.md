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
- अंतर्निर्मित गुण
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
description: "Aspose.Slides for C++ में प्रस्तुति गुणों को पूर्ण रूप से नियंत्रित करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और वर्कफ़्लो को सरल बनाएं।"
---
## **परिचय**

Aspose.Slides दो प्रकार की दस्तावेज़ गुणों का समर्थन करता है: **Built-in** और **Custom**। इन दोनों प्रकार के गुणों को Aspose.Slides API का उपयोग करके आसानी से एक्सेस और प्रबंधित किया जा सकता है।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ कार्य करने की अनुमति देता है [IDocumentProperties](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_document_properties) इंटरफ़ेस के माध्यम से। इस इंटरफ़ेस का एक उदाहरण [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_documentproperties/) मेथड द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" %}} 
कृपया ध्यान दें कि आप **Application** और **Producer** फ़ील्ड के मान सेट नहीं कर सकते हैं, क्योंकि Aspose Ltd. और Aspose.Slides for C++ x.x.x इन फ़ील्ड्स में प्रदर्शित होंगे। 
{{% /alert %}} 

## **प्रेज़ेंटेशन गुणों का प्रबंधन**

Microsoft PowerPoint प्रस्तुति फ़ाइलों में कुछ गुण जोड़ने की सुविधा प्रदान करता है। ये दस्तावेज़ गुण उपयोगी जानकारी को दस्तावेज़ों (प्रेज़ेंटेशन फ़ाइलों) के साथ संग्रहीत करने की अनुमति देते हैं। दस्तावेज़ गुण दो प्रकार के होते हैं:

- सिस्टम परिभाषित (Built-in) गुण
- उपयोगकर्ता परिभाषित (Custom) गुण

**Built-in** गुण दस्तावेज़ के बारे में सामान्य जानकारी रखते हैं जैसे दस्तावेज़ शीर्षक, लेखक का नाम, दस्तावेज़ आँकड़े आदि। **Custom** गुण वे होते हैं जो उपयोगकर्ता द्वारा **Name/Value** जोड़े के रूप में परिभाषित किए जाते हैं, जहाँ नाम और मान दोनों उपयोगकर्ता द्वारा निर्धारित होते हैं। Aspose.Slides for C++ का उपयोग करके डेवेलपर्स बिल्ट‑इन गुणों और कस्टम गुणों दोनों के मानों तक पहुंच और उन्हें संशोधित कर सकते हैं। Microsoft PowerPoint 2007 प्रस्तुति फ़ाइलों के दस्तावेज़ गुणों को प्रबंधित करने की अनुमति देता है। आपको केवल Office आइकन पर क्लिक करना है और फिर Microsoft PowerPoint 2007 के **Prepare | Properties | Advanced Properties** मेनू आइटम पर जाना है। **Advanced Properties** मेनू आइटम चुनने के बाद, एक डायलॉग दिखाई देगा जो PowerPoint फ़ाइल के दस्तावेज़ गुणों का प्रबंधन करने की सुविधा देता है। **Properties Dialog** में आप देख सकते हैं कि कई टैब पेज हैं जैसे **General, Summary, Statistics, Contents and Custom**। ये सभी टैब पेज PowerPoint फ़ाइलों से संबंधित विभिन्न प्रकार की जानकारी को कॉन्फ़िगर करने की अनुमति देते हैं। **Custom** टैब PowerPoint फ़ाइलों के कस्टम गुणों को प्रबंधित करने के लिए उपयोग किया जाता है।

## **बिल्ट‑इन गुणों तक पहुँच**

इन गुणों को **IDocumentProperties** ऑब्जेक्ट द्वारा प्रस्तुत किया गया है जिसमें शामिल हैं: **Creator(Author)**, **Description**, **KeyWords**, **Created** (सृजन तिथि), **Modified** (संशोधन तिथि), **Printed** (अंतिम प्रिंट तिथि), **LastModifiedBy**, **Keywords**, **SharedDoc** (क्या विभिन्न उत्पादकों के बीच साझा किया गया है?), **PresentationFormat**, **Subject** और **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **बिल्ट‑इन गुण संशोधित करें**

प्रेज़ेंटेशन फ़ाइलों के बिल्ट‑इन गुणों को संशोधित करना उतना ही आसान है जितना कि उन्हें एक्सेस करना। आप बस किसी भी इच्छित गुण को स्ट्रिंग मान असाइन कर सकते हैं और वह गुण मान संशोधित हो जाएगा। नीचे दिए गए उदाहरण में हमने दर्शाया है कि हम प्रेज़ेंटेशन फ़ाइल के बिल्ट‑इन दस्तावेज़ गुणों को कैसे संशोधित कर सकते हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **कस्टम प्रेज़ेंटेशन गुण जोड़ें**

Aspose.Slides for C++ डेवलपर्स को प्रस्तुति दस्तावेज़ गुणों के लिए कस्टम मान जोड़ने की अनुमति भी देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि कैसे प्रेज़ेंटेशन के लिए कस्टम गुण सेट किए जाएँ।

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class
// Presentation क्लास का इंस्टेंस बनाएं
auto presentation = System::MakeObject<Presentation>();

// Getting Document Properties
// दस्तावेज़ गुण प्राप्त करना
auto documentProperties = presentation->get_DocumentProperties();

// Adding Custom properties
// कस्टम गुण जोड़ना
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Getting property name at particular index
// विशिष्ट अनुक्रमांक पर गुण का नाम प्राप्त करना
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Removing selected property
// चयनित गुण को हटाना
documentProperties->RemoveCustomProperty(getPropertyName);

// Saving presentation
// प्रेज़ेंटेशन सहेजना
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **कस्टम गुणों तक पहुँच और संशोधन**

Aspose.Slides for C++ डेवलपर्स को कस्टम गुणों के मानों तक पहुँचने की भी अनुमति देता है। नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रेज़ेंटेशन के सभी कस्टम गुणों तक कैसे पहुँच सकते हैं और उन्हें संशोधित कर सकते हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [LanguageId](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_languageid/) प्रॉपर्टी ([PortionFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portionformat/) क्लास द्वारा प्रस्तुत) प्रदान करता है जो आपको PowerPoint दस्तावेज़ के लिए प्रूफिंग भाषा सेट करने देता है। प्रूफिंग भाषा वह भाषा है जिसके लिए PowerPoint में वर्तनी और व्याकरण की जाँच की जाती है।

यह C++ कोड आपको दिखाता है कि PowerPoint के लिए प्रूफिंग भाषा कैसे सेट करें:

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

यह C++ कोड आपको दिखाता है कि संपूर्ण PowerPoint प्रेज़ेंटेशन की डिफ़ॉल्ट भाषा कैसे सेट करें:

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

// नए आयताकार आकार को टेक्स्ट के साथ जोड़ता है
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// पहले भाग की भाषा की जाँच करता है
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **सजीव उदाहरण**

Aspose.Slides API के माध्यम से दस्तावेज़ गुणों के साथ काम करने का तरीका देखने के लिए ऑनलाइन ऐप [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hi/metadata) आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hi/metadata)

## ***अक्सर पूछे जाने वाले प्रश्न**

### प्रेज़ेंटेशन से बिल्ट‑इन गुण को कैसे हटाएँ?

बिल्ट‑इन गुण प्रेज़ेंटेशन का अभिन्न हिस्सा होते हैं और उन्हें पूरी तरह से हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।

### यदि मैं पहले से मौजूद कस्टम गुण जोड़ूँ तो क्या होगा?

यदि आप किसी मौज़ूद कस्टम गुण को जोड़ते हैं, तो उसका मौजूदा मान नई मान से ओवरराइट हो जाएगा। आपको गुण को पहले हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण का मान अपडेट कर देता है।

### क्या मैं प्रेज़ेंटेशन को पूरी तरह लोड किए बिना उसकी गुणों तक पहुँच सकता हूँ?

हाँ, आप [PresentationFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/) क्लास की `GetPresentationInfo` मेथड का उपयोग करके प्रेज़ेंटेशन को पूरी तरह लोड किए बिना उसके गुणों तक पहुँच सकते हैं। फिर, आप [IPresentationInfo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationinfo/) इंटरफ़ेस द्वारा प्रदान की गई `ReadDocumentProperties` मेथड का उपयोग करके गुणों को कुशलतापूर्वक पढ़ सकते हैं, जिससे मेमोरी बचती है और प्रदर्शन में सुधार होता है।