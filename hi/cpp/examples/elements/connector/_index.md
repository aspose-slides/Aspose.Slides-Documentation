---
title: कनेक्टर
type: docs
weight: 190
url: /hi/cpp/examples/elements/connector/
keywords:
- कोड उदाहरण
- Connector
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके आकारों के बीच कनेक्टर जोड़ने, मार्ग निर्धारित करने और शैलीबद्ध करने के तरीके सीखें, जिसमें PPT, PPTX और ODP प्रस्तुतियों के उदाहरण शामिल हैं।"
---
यह लेख दिखाता है कि **Aspose.Slides for C++** का उपयोग करके आकारों को कनेक्टरों से कैसे जोड़ें और उनके लक्ष्य को कैसे बदलें।

## **कनेक्टर जोड़ें**

स्लाइड पर दो बिंदुओं के बीच एक कनेक्टर आकार सम्मिलित करें।

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **कनेक्टर तक पहुँचें**

स्लाइड में जोड़े गए पहले कनेक्टर आकार को प्राप्त करें।

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // स्लाइड पर पहले कनेक्टर तक पहुँचें।
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **कनेक्टर हटाएँ**

स्लाइड से एक कनेक्टर हटाएँ।

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **आकारों को फिर से जोड़ें**

आरंभ और अंत लक्ष्य असाइन करके दो आकारों से एक कनेक्टर संलग्न करें।

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```