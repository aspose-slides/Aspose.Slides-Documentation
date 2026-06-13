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
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ PowerPoint और OpenDocument फ़ाइलों में टेक्स्ट बॉक्स बनाना, संपादित करना और क्लोन करना आसान बनाता है, जिससे आपकी प्रेजेंटेशन ऑटोमेशन में सुधार होता है।"
---
## **परिचय**

स्लाइड्स पर टेक्स्ट आमतौर पर टेक्स्ट बॉक्स या शेप्स में होते हैं। इसलिए, स्लाइड में टेक्स्ट जोड़ने के लिए, आपको एक टेक्स्ट बॉक्स जोड़ना होगा और फिर टेक्स्ट बॉक्स के अंदर कुछ टेक्स्ट डालना होगा। Aspose.Slides for C++ [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape) इंटरफ़ेस प्रदान करता है जो आपको टेक्स्ट वाला शेप जोड़ने की अनुमति देता है।

{{% alert title="सूचना" color="info" %}}
Aspose.Slides भी [IShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_shape) इंटरफ़ेस प्रदान करता है जो स्लाइड्स में शेप्स जोड़ने की अनुमति देता है। हालांकि, `IShape` इंटरफ़ेस के माध्यम से जोड़े गए सभी शेप्स टेक्स्ट नहीं रख सकते। लेकिन [IAutoShape](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_auto_shape) इंटरफ़ेस के माध्यम से जोड़े गए शेप्स में टेक्स्ट हो सकता है। 
{{% /alert %}}

{{% alert title="ध्यान" color="warning" %}} 
इसलिए, जब आप ऐसे शेप से निपट रहे हैं जिसमें आप टेक्स्ट जोड़ना चाहते हैं, तो आपको जांचना चाहिए कि वह `IAutoShape` इंटरफ़ेस के माध्यम से कास्ट किया गया है या नहीं। तभी आप [TextFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.text_frame) के साथ काम कर पाएँगे, जो `IAutoShape` की प्रॉपर्टी है। इस पृष्ठ पर [Update Text](https://docs.aspose.com/slides/hi/cpp/manage-textbox/#update-text) अनुभाग देखें। 
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास की इंस्टेंस बनाएं।  
2. नए बनाए गए प्रेजेंटेशन में पहली स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` के रूप में सेट किए गए [ShapeType](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) के साथ एक [IAutoShape] ऑब्जेक्ट जोड़ें और नए जोड़े गए `IAutoShape` ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।  
4. `IAutoShape` ऑब्जेक्ट में एक `TextFrame` प्रॉपर्टी जोड़ें जो टेक्स्ट रखेगा। नीचे के उदाहरण में हमने यह टेक्स्ट जोड़ा है: *Aspose TextBox*  
5. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें।  

यह C++ कोड—उपर्युक्त चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में टेक्स्ट कैसे जोड़ें:

```cpp
// Presentation का इंस्टेंस बनाता है
auto pres = System::MakeObject<Presentation>();

// प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
auto sld = pres->get_Slides()->idx_get(0);

// Rectangle प्रकार के साथ AutoShape जोड़ता है
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Rectangle में TextFrame जोड़ता है
ashp->AddTextFrame(u" ");

// TextFrame तक पहुंचता है
auto txtFrame = ashp->get_TextFrame();

// TextFrame के लिए Paragraph ऑब्जेक्ट बनाता है
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph के लिए Portion ऑब्जेक्ट बनाता है
auto portion = para->get_Portions()->idx_get(0);

// टेक्स्ट सेट करता है
portion->set_Text(u"Aspose TextBox");

// प्रेजेंटेशन को डिस्क पर सहेजता है
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **टेक्स्ट बॉक्स शेप की जाँच करें**

Aspose.Slides [IAutoShape] इंटरफ़ेस से [get_IsTextBox](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iautoshape/get_istextbox/) मेथड प्रदान करता है, जिससे आप शेप्स की जांच कर टेक्स्ट बॉक्स पहचान सकते हैं।

![टेक्स्ट बॉक्स और शेप](istextbox.png)

यह C++ कोड दिखाता है कि कैसे जाँचें कि कोई शेप टेक्स्ट बॉक्स के रूप में बनाया गया है या नहीं: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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

ध्यान दें कि यदि आप केवल `AddAutoShape` मेथड का उपयोग करके [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस से एक ऑٹوशेप जोड़ते हैं, तो ऑटोशेप की `get_IsTextBox` मेथड `false` लौटाएगी। हालांकि, जब आप `AddTextFrame` मेथड या `set_Text` मेथड से ऑटोशेप में टेक्स्ट जोड़ते हैं, तो `get_IsTextBox` मेथड `true` लौटाती है।

```cpp
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

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

Aspose.Slides [set_ColumnCount](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) और [set_ColumnSpacing](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) मेथड (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format) इंटरफ़ेस और [TextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format) क्लास से हैं) प्रदान करता है जिससे आप टेक्स्ट बॉक्स में कॉलम जोड़ सकते हैं। आप टेक्स्ट बॉक्स में कॉलमों की संख्या निर्दिष्ट कर सकते हैं और कॉलमों के बीच पॉइंट में स्पेसिंग सेट कर सकते हैं। 

यह C++ कोड वर्णित ऑपरेशन को दर्शाता है: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
auto slide = presentation->get_Slides()->idx_get(0);

// Rectangle प्रकार के साथ AutoShape जोड़ता है
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

// कॉलमों के बीच स्पेसिंग निर्दिष्ट करता है
format->set_ColumnSpacing(10);

// प्रेजेंटेशन को सहेजता है
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **टेक्स्ट फ्रेम में कॉलम जोड़ें**

Aspose.Slides for C++ [set_ColumnCount](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) मेथड (जो [ITextFrameFormat](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_text_frame_format) इंटरफ़ेस से है) प्रदान करता है जिससे आप टेक्स्ट फ्रेम में कॉलम जोड़ सकते हैं। इस मेथड के माध्यम से आप टेक्स्ट फ्रेम में वांछित कॉलम संख्या निर्दिष्ट कर सकते हैं। 

यह C++ कोड दिखाता है कि टेक्स्ट फ्रेम के अंदर कॉलम कैसे जोड़ें:

```cpp
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

Aspose.Slides आपको टेक्स्ट बॉक्स में मौजूद टेक्स्ट या पूरी प्रेज़ेंटेशन में मौजूद सभी टेक्स्ट को बदलने या अपडेट करने की अनुमति देता है। 

यह C++ कोड एक ऑपरेशन दर्शाता है जहाँ प्रेज़ेंटेशन में सभी टेक्स्ट अपडेट या बदले जाते हैं:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //टेक्स्ट बदलता है
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //फ़ॉर्मेटिंग बदलता है
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//बदलें हुए प्रेजेंटेशन को सहेजता है
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें**

आप टेक्स्ट बॉक्स के अंदर एक लिंक सम्मिलित कर सकते हैं। जब टेक्स्ट बॉक्स पर क्लिक किया जाता है, तो उपयोगकर्ता लिंक खोलने के लिए निर्देशित होते हैं। 

लिंक वाले टेक्स्ट बॉक्स को जोड़ने के लिए, इन चरणों का पालन करें:

1. `Presentation` क्लास की एक इंस्टेंस बनाएं।  
2. नए बनाए गए प्रेजेंटेशन में पहली स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर निर्दिष्ट स्थान पर `Rectangle` सेट किए हुए `ShapeType` के साथ एक `AutoShape` ऑब्जेक्ट जोड़ें और नए जोड़े गए AutoShape ऑब्जेक्ट का रेफ़रेंस प्राप्त करें।  
4. `AutoShape` ऑब्जेक्ट में एक `TextFrame` जोड़ें जिसमें डिफ़ॉल्ट टेक्स्ट के रूप में *Aspose TextBox* हो।  
5. `IHyperlinkManager` क्लास को इन्स्टैंसिएट करें।  
6. `IHyperlinkManager` ऑब्जेक्ट को `TextFrame` के इच्छित हिस्से के साथ जुड़े [set_HyperlinkClick](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) मेथड को असाइन करें।  
7. अंत में, `Presentation` ऑब्जेक्ट के माध्यम से PPTX फ़ाइल लिखें। 

यह C++ कोड—उपर्युक्त चरणों का कार्यान्वयन—आपको दिखाता है कि स्लाइड में हाइपरलिंक के साथ टेक्स्ट बॉक्स कैसे जोड़ें:

```cpp
// PPTX को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाता है
auto presentation = System::MakeObject<Presentation>();

// प्रेजेंटेशन में पहली स्लाइड प्राप्त करता है
auto slide = presentation->get_Slides()->idx_get(0);

// Rectangle प्रकार के साथ AutoShape ऑब्जेक्ट जोड़ता है
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// शेप को AutoShape में कास्ट करता है
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShape से जुड़ी ITextFrame प्रॉपर्टी तक पहुँचता है
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// फ्रेम में कुछ टेक्स्ट जोड़ता है
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// भाग के टेक्स्ट के लिए हाइपरलिंक सेट करता है
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTX प्रेजेंटेशन को सहेजता है
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड्स के साथ काम करते समय टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

एक [placeholder](/slides/hi/cpp/manage-placeholder/) [master](https://reference.aspose.com/slides/hi/cpp/aspose.slides/masterslide/) से शैली/स्थिति विरासत में प्राप्त करता है और [layouts](https://reference.aspose.com/slides/hi/cpp/aspose.slides/layoutslide/) पर ओवरराइड किया जा सकता है, जबकि सामान्य टेक्स्ट बॉक्स एक विशिष्ट स्लाइड पर स्वतंत्र ऑब्जेक्ट है और लेआउट बदलने पर नहीं बदलता।

**मैं प्रस्तुति में चार्ट, टेबल और SmartArt के अंदर के टेक्स्ट को बदले बिना, सभी टेक्स्ट का बैच प्रतिस्थापन कैसे कर सकता हूँ?**

अपनी इटरेशन को केवल उन ऑटो-शेप्स तक सीमित रखें जिनमें टेक्स्ट फ्रेम हों और एम्बेडेड ऑब्जेक्ट्स ([charts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.smartart/smartart/)) को अलग-अलग उनकी कलेक्शनों को ट्रैवर्स करके या उन ऑब्जेक्ट प्रकारों को स्किप करके बाहर रखें।