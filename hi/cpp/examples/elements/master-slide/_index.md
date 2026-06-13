---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/cpp/examples/elements/master-slide/
keywords:
- कोड उदाहरण
- मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के मास्टर स्लाइड उदाहरणों का पता लगाएँ: PPT, PPTX और ODP में स्पष्ट C++ कोड के साथ मास्टर, प्लेसहोल्डर और थीम बनाएँ, संपादित करें और शैली दें।"
---
मास्टर स्लाइड्स PowerPoint में स्लाइड विरासत पदानुक्रम के शीर्ष स्तर का गठन करती हैं। एक **मास्टर स्लाइड** पृष्ठभूमि, लोगो, और टेक्स्ट फ़ॉर्मेटिंग जैसे सामान्य डिजाइन तत्वों को परिभाषित करती है। **लेआउट स्लाइड्स** मास्टर स्लाइड्स से विरासत में प्राप्त होती हैं, और **नॉर्मल स्लाइड्स** लेआउट स्लाइड्स से विरासत में प्राप्त होती हैं।

यह लेख Aspose.Slides for C++ का उपयोग करके मास्टर स्लाइड्स को बनाने, संशोधित करने और प्रबंधित करने का प्रदर्शन करता है।

## **मास्टर स्लाइड जोड़ें**

यह उदाहरण डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करके नई मास्टर स्लाइड बनाने का तरीका दर्शाता है। फिर यह लेआउट विरासत के माध्यम से सभी स्लाइड्स में कंपनी का नाम बैनर जोड़ता है।

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें।
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // मास्टर स्लाइड के शीर्ष पर कंपनी नाम के साथ बैनर जोड़ें।
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // नए मास्टर स्लाइड को लेआउट स्लाइड को असाइन करें।
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // लेआउट स्लाइड को प्रस्तुति की पहली स्लाइड को असाइन करें।
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **नोट 1:** मास्टर स्लाइड्स सभी स्लाइड्स में सुसंगत ब्रांडिंग या साझा डिजाइन तत्व लागू करने का तरीका प्रदान करती हैं। मास्टर में किए गए कोई भी परिवर्तन स्वचालित रूप से संबंधित लेआउट और नॉर्मल स्लाइड्स पर प्रतिबिंबित होते हैं।

> 💡 **नोट 2:** मास्टर स्लाइड में जोड़े गए कोई भी आकार या फ़ॉर्मेटिंग लेआउट स्लाइड्स द्वारा विरासत में प्राप्त होती है और बदले में उन लेआउट्स का उपयोग करने वाली सभी नॉर्मल स्लाइड्स में लागू होती है।  
> नीचे दिया गया चित्र दिखाता है कि कैसे मास्टर स्लाइड पर जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वचालित रूप से रेंडर होता है।

![मास्टर इनहेरिटेंस उदाहरण](master-slide-banner.png)

## **मास्टर स्लाइड तक पहुँचें**

आप प्रस्तुति मास्टर कलेक्शन का उपयोग करके मास्टर स्लाइड्स तक पहुँच सकते हैं। नीचे दिया गया कोड उन्हें प्राप्त करने और उनके साथ कार्य करने का तरीका दर्शाता है:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // पृष्ठभूमि प्रकार बदलें।
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **मास्टर स्लाइड हटाएँ**

मास्टर स्लाइड्स को इंडेक्स या रेफ़रेंस द्वारा हटाया जा सकता है।

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // इंडेक्स द्वारा एक मास्टर स्लाइड हटाएँ।
    presentation->get_Masters()->RemoveAt(0);

    // संदर्भ द्वारा एक मास्टर स्लाइड हटाएँ।
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

कुछ प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो उपयोग में नहीं होतीं। इन स्लाइड्स को हटाने से फ़ाइल आकार कम करने में मदद मिलती है।

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // सभी अप्रयुक्त मास्टर स्लाइड्स हटाएँ (यहां तक कि वे जो Preserve के रूप में चिह्नित हैं) ।
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```