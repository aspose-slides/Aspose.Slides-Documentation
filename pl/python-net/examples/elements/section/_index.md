---
title: Sekcja
type: docs
weight: 90
url: /pl/python-net/examples/elements/section/
keywords:
- sekcja
- sekcja slajdu
- dodaj sekcję
- pobierz sekcję
- usuń sekcję
- zmień nazwę sekcji
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w Pythonie przy użyciu Aspose.Slides: twórz, zmieniaj nazwę, łatwo zmieniaj kolejność, przenoś slajdy pomiędzy sekcjami i kontroluj widoczność dla PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmiana nazwy programowo przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj sekcję**

Utwórz sekcję, która zaczyna się od określonego slajdu.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj nową sekcję i określ slajd, który oznacza początek sekcji.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do sekcji**

Pobierz sekcję z prezentacji.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Uzyskaj dostęp do sekcji po indeksie.
        section = presentation.sections[0]
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Usuń sekcję.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Zmień nazwę sekcji.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```