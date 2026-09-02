---
title: C++ का उपयोग करके प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/cpp/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के लिए Aspose.Slides PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाना, संपादित करना और क्लोन करना आसान बनाता है, जिससे आपके प्रस्तुति स्वचालन को बेहतर बनाया जाता है।"
---
## **परिचय**

स्लाइड्स पर पाठ आमतौर पर टेक्स्ट बॉक्स या आकार में मौजूद होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए आपको एक टेक्स्ट बॉक्स जोड़ना पड़ता है और फिर उस टेक्स्ट बॉक्स में कुछ पाठ डालना पड़ता है। Aspose.Slides for C++ [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape) इंटरफ़ेस प्रदान करता है जो आपको कुछ पाठ वाला आकार जोड़ने की अनुमति देता है।

{{% alert title="Info" color="info" %}}

Aspose.Slides भी [IShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape) इंटरफ़ेस प्रदान करता है जो स्लाइड्स में आकार जोड़ने की सुविधा देता है। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी आकार टेक्स्ट धारण नहीं कर सकते। लेकिन [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape) इंटरफ़ेस के माध्यम से जोड़े गए आकार में टेक्स्ट हो सकता है। 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

इसलिए, जब आप किसी आकार को टेक्स्ट जोड़ने के लिए प्रयोग करना चाहते हैं, तो आपको यह जांचना और पुष्टि करना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया है। तभी आप `IAutoShape` के तहत स्थित [TextFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame) के साथ काम कर पाएंगे। इस पृष्ठ पर [Update Text](https://docs.aspose.com/slides/hi/cpp/manage-textbox/#update-text) सेक्शन देखें। 

{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

स्लाइड पर टेक्स्ट बॉक्स बनाने के लिए इन चरणों का पालन करें:

1. एक नई [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं। 
2. नए बनाए गए प्रेजेंटेशन में पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में सेट किया गया [ShapeType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) के साथ एक [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape) ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `IAutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जिसमें टेक्स्ट हो। नीचे के उदाहरण में हमने यह टेक्स्ट जोड़ा: *Aspose TextBox*  
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह C++ कोड—उपरोक्त चरणों का कार्यान्वयन—दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ा जाए:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// प्रस्तुति का इंस्टेंस बनाता है
auto pres = System::MakeObject<Presentation>();

// प्रस्तुति में पहली स्लाइड प्राप्त करता है
auto sld = pres->get_Slides()->idx_get(0);

// एक ऑटोशेप जोड़ता है जिसका प्रकार Rectangle सेट है
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Rectangle में TextFrame जोड़ता है
ashp->AddTextFrame(u" ");

// टेक्स्ट फ्रेम तक पहुँचता है
auto txtFrame = ashp->get_TextFrame();

// टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// पैराग्राफ के लिए पोर्शन ऑब्जेक्ट बनाता है
auto portion = para->get_Portions()->idx_get(0);

// टेक्स्ट सेट करता है
portion->set_Text(u"Aspose TextBox");

// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **टेक्स्ट बॉक्स आकार की जाँच करें**

Aspose.Slides [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) इंटरफ़ेस से [get_IsTextBox](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/get_istextbox/) मेथड प्रदान करता है, जिससे आप आकारों की जांच कर टेक्स्ट बॉक्स पहचान सकते हैं।

![Text box and shape](istextbox.png)

यह C++ कोड दिखाता है कि किसी आकार को टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

ध्यान दें कि यदि आप केवल `AddAutoShape` मेथड का उपयोग करके [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस से एक ऑटोशेप जोड़ते हैं, तो ऑटोशेप की `get_IsTextBox` मेथड `false` लौटाएगी। हालांकि, जब आप `AddTextFrame` मेथड या `set_Text` मेथड से ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `get_IsTextBox` मेथड `true` लौटाएगी।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() false लौटाता है
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() true लौटाता है

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() false लौटाता है
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() true लौटाता है

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() false लौटाता है
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() false लौटाता है

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() false लौटाता है
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() false लौटाता है
```

## **टेक्स्ट फ्रेम का मालिक आकार ढूँढ़ें**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड में, आप एक [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) प्राप्त कर सकते हैं बिना यह जाने कि कौन सा प्रेजेंटेशन ऑब्जेक्ट उसमें है। मालिक [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) पर नेविगेट करने के लिए [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) का उपयोग करें।

यदि टेक्स्ट फ्रेम किसी [IAutoShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/) या किसी अन्य टेक्स्ट‑धारी आकार का हिस्सा है, तो [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) मालिक को लौटाता है और [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` लौटाता है। दोनों मेथड केवल रीड‑ओनली नेविगेशन प्रदान करते हैं, इसलिए उनका कॉल करने से स्वामित्व नहीं बदलता। आकार को एक्सेस करने से पहले हमेशा लौटाए गए मान को `nullptr` के लिए जाँचें।

स्मार्टआर्ट नोड्स सहित आकार और टेबल‑सेल मालिकों की पहचान करने वाले संपूर्ण उदाहरण के लिए देखें: [Search and Replace Text](/slides/hi/cpp/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [set_ColumnCount](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) और [set_ColumnSpacing](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) मेथड (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format) इंटरफ़ेस और [TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format) क्लास से हैं) प्रदान करता है, जिससे आप टेक्स्टबॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलम की संख्या निर्धारित कर सकते हैं और कॉलमों के बीच पॉइंट्स में स्पेसिंग सेट कर सकते हैं। 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
auto slide = presentation->get_Slides()->idx_get(0);

// Rectangle प्रकार सेट के साथ एक ऑटोशेप जोड़ता है
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Rectangle में TextFrame जोड़ता है
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// TextFrame का टेक्स्ट फॉर्मेट प्राप्त करता है
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// TextFrame में कॉलमों की संख्या निर्दिष्ट करता है
format->set_ColumnCount(3);

// कॉलमों के बीच की स्पेसिंग निर्दिष्ट करता है
format->set_ColumnSpacing(10);

// प्रेजेंटेशन सहेजता है
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**

Aspose.Slides for C++ [set_ColumnCount](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) मेथड (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format) इंटरफ़ेस से है) प्रदान करता है, जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस मेथड के द्वारा आप टेक्स्ट फ्रेम में वांछित कॉलम संख्या निर्दिष्ट कर सकते हैं। 

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **टेक्स्ट अपडेट करें**

Aspose.Slides आपको टेक्स्ट बॉक्स में या पूरी प्रेजेंटेशन में सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है। 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //पाठ बदलता है
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //फ़ॉर्मेटिंग बदलता है
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//संशोधित प्रस्तुति सहेजता है
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें** 

आप टेक्स्ट बॉक्स के अंदर एक लिंक डाल सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक को खोलने के लिए निर्देशित होते हैं। 

हाइपरलिंक युक्त टेक्स्ट बॉक्स जोड़ने के लिए इन चरणों का पालन करें:

1. `Presentation` क्लास की एक इंस्टेंस बनाएं। 
2. नए बनाए गए प्रेजेंटेशन में पहली स्लाइड का रेफ़रेंस प्राप्त करें। 
3. स्लाइड पर निर्दिष्ट स्थिति पर `Rectangle` के रूप में सेट किया गया `ShapeType` वाला `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें। 
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट *Aspose TextBox* हो। 
5. `IHyperlinkManager` क्लास का एक इंस्टेंस बनाएं। 
6. अपनी पसंदीदा `TextFrame` भाग पर लागू `set_HyperlinkClick` मेथड के साथ `IHyperlinkManager` ऑब्जेक्ट असाइन करें। 
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाता है
auto presentation = System::MakeObject<Presentation>();

// प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
auto slide = presentation->get_Slides()->idx_get(0);

// टाइप को Rectangle सेट कर एक AutoShape ऑब्जेक्ट जोड़ता है
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// shape को AutoShape में कास्ट करता है
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShape से संबंधित ITextFrame प्रॉपर्टी तक पहुँचता है
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// फ़्रेम में कुछ टेक्स्ट जोड़ता है
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// portion टेक्स्ट के लिए हाइपरलिंक सेट करता है
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTX प्रेजेंटेशन को सहेजता है
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/cpp/manage-placeholder/) शैली/स्थिति को [master](https://reference.aspose.com/slides/hi/cpp/aspose.slides/masterslide/) से विरासत में लेता है और इसे [layouts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि एक सामान्य टेक्स्ट बॉक्स किसी विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट होता है और लेआउट बदलने पर नहीं बदलता।

**मैं चार्ट्स, टेबल्स और SmartArt के अंदर के टेक्स्ट को छुए बिना पूरी प्रेजेंटेशन में एक साथ टेक्स्ट रिप्लेसमेंट कैसे कर सकता हूँ?**

इटरेशन को केवल उन ऑटो‑शेप्स तक सीमित रखें जिनमें टेक्स्ट फ्रेम हैं और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartart/)) को उनके कलेक्शन को अलग‑अलग ट्रैवर्स करके या उन ऑब्जेक्ट प्रकारों को स्किप करके बाहर रखें।