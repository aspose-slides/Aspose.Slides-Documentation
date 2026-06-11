---
title: OLE-objekt
type: docs
weight: 210
url: /sv/cpp/examples/elements/ole-object/
keywords:
- kodexempel
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera OLE-objekt i Aspose.Slides for C++: infoga, länka, uppdatera och extrahera inbäddat innehåll med C++ i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man bäddar in en fil som ett OLE-objekt och uppdaterar dess data med **Aspose.Slides for C++**.

## **Lägg till ett OLE-objekt**

Bädda in en PDF-fil i presentationen.

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

## **Kom åt ett OLE-objekt**

Hämta den första OLE-objektramen på en bild.

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

## **Ta bort ett OLE-objekt**

Ta bort ett inbäddat OLE-objekt från bilden.

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

## **Uppdatera OLE-objektdata**

Ersätt den data som är inbäddad i ett befintligt OLE-objekt.

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