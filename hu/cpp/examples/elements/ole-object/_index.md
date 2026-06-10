---
title: OLE objektum
type: docs
weight: 210
url: /hu/cpp/examples/elements/ole-object/
keywords:
- kódrészlet
- OLE objektum
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Az OLE objektumok kezelése az Aspose.Slides for C++-ban: beillesztés, hivatkozás, frissítés és beágyazott tartalom kinyerése C++-val PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet egy fájlt OLE objektumként beágyazni, és annak adatait frissíteni a **Aspose.Slides for C++** segítségével.

## **OLE objektum hozzáadása**

PDF-fájlt ágyazzon be a prezentációba.

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

## **OLE objektum elérése**

Szerezze meg az első OLE objektumkeretet egy dián.

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

## **OLE objektum eltávolítása**

Törölje a beágyazott OLE objektumot a diáról.

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

## **OLE objektum adatainak frissítése**

Cserélje le egy meglévő OLE objektumba beágyazott adatokat.

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