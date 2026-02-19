---
title: OLE-Objekt
type: docs
weight: 210
url: /de/cpp/examples/elements/ole-object/
keywords:
- Codebeispiel
- OLE-Objekt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie OLE-Objekte in Aspose.Slides für C++: Einfügen, Verlinken, Aktualisieren und Extrahieren eingebetteter Inhalte mit C++ in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert das Einbetten einer Datei als OLE-Objekt und das Aktualisieren ihrer Daten mit **Aspose.Slides for C++**.

## **Ein OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in die Präsentation ein.

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

## **Zugriff auf ein OLE-Objekt**

Rufen Sie das erste OLE-Objekt‑Frame auf einer Folie ab.

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

## **Ein OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.

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

## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem vorhandenen OLE-Objekt eingebetteten Daten.

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