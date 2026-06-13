---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/cpp/examples/elements/hyperlink/
keywords:
- कोड उदाहरण
- हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में हाइपरलिंक जोड़ें और प्रबंधित करें: लिंक टेक्स्ट, आकार, और छवियों को, PPT, PPTX, और ODP के लिए लक्ष्य और कार्य निर्धारित करें C++ उदाहरणों के साथ."
---
यह लेख **Aspose.Slides for C++** का उपयोग करके आकारों पर हाइपरलिंक जोड़ने, पहुँचने, हटाने और अपडेट करने का प्रदर्शन करता है।

## **एक हाइपरलिंक जोड़ें**

एक आयताकार आकार बनाएं जिसमें बाहरी वेबसाइट की ओर इशारा करने वाला हाइपरलिंक हो।

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **एक हाइपरलिंक तक पहुँचें**

एक आकार के पाठ भाग से हाइपरलिंक जानकारी पढ़ें।

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **हाइपरलिंक हटाएँ**

एक आकार के पाठ से हाइपरलिंक साफ़ करें।

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **हाइपरलिंक अपडेट करें**

मौजूदा हाइपरलिंक का लक्ष्य बदलें। `HyperlinkManager` का उपयोग करके उन पाठ को संशोधित करें जिसमें पहले से हाइपरलिंक मौजूद है, जिससे PowerPoint सुरक्षित रूप से हाइपरलिंक अपडेट करता है।

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // मौजूदा टेक्स्ट के भीतर हाइपरलिंक को बदलना चाहिए
    // HyperlinkManager के माध्यम से, सीधे प्रॉपर्टी सेट करने के बजाय।
    // यह PowerPoint के सुरक्षित हाइपरलिंक अपडेट करने के तरीक़े की नकल करता है।
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```