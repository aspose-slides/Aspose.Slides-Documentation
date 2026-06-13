---
title: C++ में प्रस्तुति प्लेसहोल्डर प्रबंधित करें
linktitle: प्लेसहोल्डर प्रबंधित करें
type: docs
weight: 10
url: /hi/cpp/manage-placeholder/
keywords:
- प्लेसहोल्डर
- टेक्स्ट प्लेसहोल्डर
- छवि प्लेसहोल्डर
- चार्ट प्लेसहोल्डर
- प्रॉम्प्ट टेक्स्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में प्लेसहोल्डर को सहजता से प्रबंधित करें: टेक्स्ट बदलें, प्रॉम्प्ट को अनुकूलित करें और PowerPoint तथा OpenDocument में छवि की पारदर्शिता सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको प्रेजेंटेशन प्लेसहोल्डर को प्रोग्रामेटिकली प्रबंधित करने की सुविधा देता है। यह लेख बताता है कि स्लाइड्स में प्लेसहोल्डर कैसे खोजें और उनका टेक्स्ट बदलें, प्लेसहोल्डर लेआउट्स के लिए कस्टम प्रॉम्प्ट टेक्स्ट सेट करें, और प्लेसहोल्डर बैकग्राउंड के रूप में प्रयुक्त छवि की पारदर्शिता कैसे समायोजित करें। इसमें एक छोटा FAQ भी शामिल है जो बेस प्लेसहोल्डर और लोकल शेप के बीच अंतर स्पष्ट करता है, बताता है कि प्लेसहोल्डर बदलाव लेआउट्स या मास्टर्स के माध्यम से कैसे लागू किए जा सकते हैं, और हेडर व फुटर प्लेसहोल्डर प्रबंधन की ओर संकेत करता है।

## **प्लेसहोल्डर में टेक्स्ट बदलें**

Aspose.Slides for C++ का उपयोग करके, आप प्रेजेंटेशन्स की स्लाइड्स में प्लेसहोल्डर को खोज सकते हैं और संशोधित कर सकते हैं। Aspose.Slides आपको प्लेसहोल्डर के टेक्स्ट में बदलाव करने की सुविधा देता है।

**पूर्वापेक्षा**: आपको एक ऐसी प्रेजेंटेशन की आवश्यकता है जिसमें प्लेसहोल्डर हो। आप ऐसी प्रेजेंटेशन सामान्य Microsoft PowerPoint एप्लिकेशन में बना सकते हैं।

यह है वह तरीका जिससे आप Aspose.Slides का उपयोग करके उस प्रेजेंटेशन में प्लेसहोल्डर का टेक्स्ट बदल सकते हैं:

1. `Presentation` क्लास का एक उदाहरण बनाएं और प्रेजेंटेशन को आर्गुमेंट के रूप में पास करें।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. शेप्स के माध्यम से इटररेट करके प्लेसहोल्डर खोजें।
4. प्लेसहोल्डर शेप को `AutoShape` में टाइपकैस्ट करें और `AutoShape` से जुड़ी `TextFrame` का उपयोग करके टेक्स्ट बदलें।
5. संशोधित प्रेजेंटेशन को सेव करें।

यह C++ कोड दिखाता है कि प्लेसहोल्डर में टेक्स्ट कैसे बदलें:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// वांछित प्रस्तुति को लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// स्लाइड में पहला और दूसरा प्लेसहोल्डर तक पहुँचता है और इसे AutoShape में टाइपकास्ट करता है
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें**

स्टैंडर्ड और पूर्व-निर्मित लेआउट्स में प्लेसहोल्डर प्रॉम्प्ट टेक्स्ट होते हैं जैसे ***Click to add a title*** या ***Click to add a subtitle***। Aspose.Slides का उपयोग करके, आप अपनी पसंदीदा प्रॉम्प्ट टेक्स्ट को प्लेसहोल्डर लेआउट्स में डाल सकते हैं।

यह C++ कोड दिखाता है कि प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट कैसे सेट करें:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // जब उसमें कोई टेक्स्ट नहीं होता है, PowerPoint प्रदर्शित करता है "Click to add title". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // उपशीर्षक के लिए भी यही करता है.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **प्लेसहोल्डर इमेज की पारदर्शिता सेट करें**

Aspose.Slides आपको टेक्स्ट प्लेसहोल्डर में बैकग्राउंड इमेज की पारदर्शिता सेट करने की सुविधा देता है। ऐसे फ़्रेम में चित्र की पारदर्शिता समायोजित करके, आप टेक्स्ट या चित्र को प्रमुख बना सकते हैं (टेक्स्ट और चित्र के रंगों के आधार पर)।

यह C++ कोड दिखाता है कि चित्र बैकग्राउंड (शेप के भीतर) की पारदर्शिता कैसे सेट करें:

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**बेस प्लेसहोल्डर क्या है, और यह स्लाइड पर एक लोकल शेप से कैसे अलग है?**

बेस प्लेसहोल्डर वह मूल शेप है जो लेआउट या मास्टर पर स्थित होता है और स्लाइड का शेप उससे विरासत में प्राप्त करता है—टाइप, पोज़िशन और कुछ फॉर्मैटिंग इसका हिस्सा होते हैं। एक लोकल शेप स्वतंत्र होता है; यदि बेस प्लेसहोल्डर नहीं है, तो विरासत लागू नहीं होती।

**मैं एक प्रेजेंटेशन में सभी टाइटल या कैप्शन को कैसे अपडेट कर सकता हूँ बिना हर स्लाइड पर इटररेट किए?**

लेआउट या मास्टर पर संबंधित प्लेसहोल्डर को संपादित करें। उन लेआउट्स/मास्टर पर आधारित स्लाइड्स स्वचालित रूप से बदलाव को विरासत में ले लेगी।

**मैं मानक हेडर/फूटर प्लेसहोल्डर—तारीख एवं समय, स्लाइड नंबर, और फूटर टेक्स्ट—को कैसे नियंत्रित कर सकता हूँ?**

उचित स्कोप (सामान्य स्लाइड्स, लेआउट्स, मास्टर, नोट्स/हैंडआउट्स) में HeaderFooter मैनेजर्स का उपयोग करके इन प्लेसहोल्डर्स को ऑन या ऑफ करें और उनके कंटेंट को सेट करें।