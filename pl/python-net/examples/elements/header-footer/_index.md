---
title: Nagłówek i stopka
type: docs
weight: 220
url: /pl/python-net/examples/elements/header-footer/
keywords:
- nagłówek i stopka
- dodaj nagłówek i stopkę
- zaktualizuj nagłówek i stopkę
- ustaw datę i czas
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Kontroluj nagłówki i stopki w Pythonie przy użyciu Aspose.Slides: dodawaj lub edytuj datę i czas, numery slajdów oraz tekst stopki, pokazuj lub ukrywaj pola zastępcze w plikach PPT, PPTX i ODP."
---
Pokazuje, jak dodać stopki i zaktualizować pola zastępcze daty i czasu przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki slajdu i spraw, aby był widoczny.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Zaktualizuj datę i godzinę**

Zmień pole zastępcze daty i czasu na slajdzie.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```