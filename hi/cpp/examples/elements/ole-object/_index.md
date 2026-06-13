---
title: OLE ऑब्जेक्ट
type: docs
weight: 210
url: /hi/cpp/examples/elements/ole-object/
keywords:
- कोड उदाहरण
- OLE ऑब्जेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में OLE ऑब्जेक्ट्स को संभालें: C++ का उपयोग करके PPT, PPTX और ODP प्रस्तुतियों में एम्बेडेड सामग्री को डालें, लिंक करें, अपडेट करें और निकालें।"
---
यह लेख फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड करने और **Aspose.Slides for C++** का उपयोग करके उसके डेटा को अपडेट करने का प्रदर्शन करता है।

## **OLE ऑब्जेक्ट जोड़ें**

एक PDF फ़ाइल को प्रस्तुति में एम्बेड करें।

```cpp
static void AddOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    presentation->Dispose();
}
```

## **OLE ऑब्जेक्ट तक पहुँचें**

स्लाइड पर पहला OLE ऑब्जेक्ट फ़्रेम प्राप्त करें।

```cpp
static void AccessOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto firstOleFrame = SharedPtr<IOleObjectFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IOleObjectFrame>(shape))
        {
            firstOleFrame = ExplicitCast<IOleObjectFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एम्बेड किया हुआ OLE ऑब्जेक्ट हटाएँ।

```cpp
static void RemoveOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide->get_Shapes()->Remove(oleFrame);

    presentation->Dispose();
}
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

मौजूदा OLE ऑब्जेक्ट में एम्बेड किए गए डेटा को बदलें।

```cpp
static void UpdateOleObjectData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto newData = File::ReadAllBytes(u"Picture.png");
    auto newDataInfo = MakeObject<OleEmbeddedDataInfo>(newData, u"png");
    oleFrame->SetEmbeddedData(newDataInfo);

    presentation->Dispose();
}
```