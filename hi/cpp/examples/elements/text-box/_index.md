---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/cpp/examples/elements/text-box/
keywords:
- कोड उदाहरण
- टेक्स्ट बॉक्स
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में टेक्स्ट बॉक्स के साथ काम करें: PPT, PPTX, और ODP प्रस्तुतियों के लिए C++ का उपयोग करके टेक्स्ट जोड़ें, स्वरूपित करें, संरेखित करें, रैप करें, ऑटोफ़िट करें, और शैली दें।"
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** को `AutoShape` द्वारा दर्शाया जाता है। लगभग सभी आकार टेक्स्ट रख सकते हैं, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई भराव या सीमा नहीं होती और यह केवल टेक्स्ट प्रदर्शित करता है।

यह गाइड प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स जोड़ने, एक्सेस करने और हटाने के तरीके को समझाती है।

## **टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स केवल एक `AutoShape` है जिसमें कोई भराव या सीमा नहीं होती और कुछ स्वरूपित टेक्स्ट होता है। यहाँ एक बनाने का तरीका है:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक आयत आकार बनाएँ (डिफ़ॉल्ट रूप से बॉर्डर वाला भरा हुआ और कोई टेक्स्ट नहीं)।
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // भरण और बॉर्डर हटाएँ ताकि यह सामान्य टेक्स्ट बॉक्स जैसा दिखे।
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // टेक्स्ट फ़ॉर्मेट सेट करें।
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // वास्तविक टेक्स्ट सामग्री असाइन करें।
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **नोट:** कोई भी `AutoShape` जिसमें खाली नहीं `TextFrame` हो, वह टेक्स्ट बॉक्स के रूप में कार्य कर सकता है।

## **सामग्री द्वारा टेक्स्ट बॉक्स एक्सेस करें**

किसी विशिष्ट कुंजीशब्द (जैसे "Slide") को शामिल करने वाले सभी टेक्स्ट बॉक्स खोजने के लिए, आकारों पर इटररेट करें और उनके टेक्स्ट की जाँच करें:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // केवल AutoShapes संपादन योग्य टेक्स्ट रख सकते हैं।
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // मिलते हुए टेक्स्ट बॉक्स के साथ कुछ करें।
            }
        }
    }

    presentation->Dispose();
}
```

## **सामग्री द्वारा टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहले स्लाइड पर सभी टेक्स्ट बॉक्स खोजता और हटाता है जो किसी विशिष्ट कुंजीशब्द को शामिल करता है:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **सलाह:** इटररेशन के दौरान उसे संशोधित करने से पहले हमेशा आकार संग्रह की एक प्रति बनाएँ ताकि संग्रह संशोधन त्रुटियों से बचा जा सके।