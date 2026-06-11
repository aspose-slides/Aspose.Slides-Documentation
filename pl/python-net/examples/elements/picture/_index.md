---
title: Obraz
type: docs
weight: 50
url: /pl/python-net/examples/elements/picture/
keywords:
- obraz
- ramka obrazu
- dodaj obraz
- dostęp do obrazu
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Praca z obrazami w Pythonie przy użyciu Aspose.Slides: wstawianie, zamiana, przycinanie, kompresja, regulacja przezroczystości i efektów, wypełnianie kształtów oraz eksport do formatów PPT, PPTX i ODP."
---
Pokazuje, jak wstawiać i uzyskiwać dostęp do obrazów z pamięci przy użyciu **Aspose.Slides for Python via .NET**. Przykłady poniżej tworzą obraz w pamięci, umieszczają go na slajdzie i następnie go pobierają.

## **Dodaj obraz**

Ten kod ładuje obraz z pliku i wstawia go jako ramkę obrazu na pierwszym slajdzie.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Wczytaj obraz z pliku.
        with open("image.png", "rb") as image_stream:
            # Dodaj obraz do zasobów prezentacji.
            image = presentation.images.add_image(image_stream)

        # Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do obrazu**

Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej znalezionej.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszej ramki obrazu na slajdzie.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```