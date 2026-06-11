---
title: Obiekt OLE
type: docs
weight: 210
url: /pl/python-net/examples/elements/ole-object/
keywords:
- Obiekt OLE
- dodaj obiekt OLE
- uzyskaj dostęp do obiektu OLE
- usuń obiekt OLE
- zaktualizuj obiekt OLE
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Pracuj z obiektami OLE w Pythonie przy użyciu Aspose.Slides: wstawiaj lub aktualizuj osadzone pliki, ustaw ikony lub odnośniki, wyodrębniaj zawartość, kontroluj zachowanie dla PPT, PPTX i ODP."
---
Prezentuje osadzanie pliku jako obiektu OLE oraz aktualizowanie jego danych przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj obiekt OLE**
Osadź plik PDF w prezentacji.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Załaduj dane PDF do osadzenia.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Dodaj ramkę obiektu OLE do slajdu.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do obiektu OLE**
Pobierz pierwszą ramkę obiektu OLE na slajdzie.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Pobierz pierwszą ramkę obiektu OLE na slajdzie.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Usuń obiekt OLE**
Usuń osadzony obiekt OLE ze slajdu.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest obiektem OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zaktualizuj dane obiektu OLE**
Zastąp dane osadzone w istniejącym obiekcie OLE.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest obiektem OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Zaktualizuj obiekt OLE nowymi osadzonymi danymi.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```