---
title: OleObjekt
type: docs
weight: 210
url: /cs/python-net/examples/elements/ole-object/
keywords:
- OLE objekt
- přidat OLE objekt
- přístup k OLE objektu
- odstranit OLE objekt
- aktualizovat OLE objekt
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Práce s OLE objekty v Pythonu pomocí Aspose.Slides: vkládejte nebo aktualizujte vložené soubory, nastavujte ikony nebo odkazy, extrahujte obsah, ovládejte chování pro PPT, PPTX a ODP."
---
Ukazuje vložení souboru jako OLE objektu a aktualizaci jeho dat pomocí **Aspose.Slides for Python via .NET**.

## **Přidat OLE objekt**

Vložte PDF soubor do prezentace.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Načíst data PDF pro vložení.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Přidat rámeček OLE objektu do snímku.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k OLE objektu**

Získejte první rámeček OLE objektu na snímku.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Získat první rámec OLE objektu na snímku.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Odstranit OLE objekt**

Odstraňte vložený OLE objekt ze snímku.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je objekt OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizovat data OLE objektu**

Nahraďte data vložená v existujícím OLE objektu.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je objekt OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Aktualizovat OLE objekt novými vloženými daty.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```