---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu Pythona
linktitle: ActiveX
type: docs
weight: 80
url: /pl/python-net/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikowanie ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek oraz ponownie użyj kontrolki Windows Media Player w prezentacjach PowerPoint za pomocą Aspose.Slides for Python via .NET."
---
## **Wprowadzenie**

Kontrolki ActiveX zapewniają slajdowi PowerPoint elementy interaktywne, takie jak pola tekstowe, przyciski poleceń i odtwarzacze multimediów. Aspose.Slides for Python via .NET udostępnia kontrolki slajdu poprzez [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Użyj tej kolekcji, aby edytować kontrolkę, przenieść ją na slajdzie lub usunąć.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

Aby sprawdzić nieznany szablon, otwórz go w trybie odczytu i iteruj po kontrolkach na każdym slajdzie. Przykład podaje numer slajdu, nazwę kontrolki, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/) oraz każdą parę klucz‑wartość w [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Prezentacja jest odczytywana bez aktywacji kontrolek, wywoływania zdarzeń lub makr, zmieniania wartości ani zapisywania pliku.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

Wybrany wynik z `ActiveX.pptm` pokazuje pole tekstowe i przycisk polecenia.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Pusta kolekcja właściwości pojawia się jako `[]`. Dla kontrolek używających binarnego przechowywania, `properties` może zwrócić `None`, wyświetlane jako `Properties unavailable`. Jeśli potrzebujesz tylko nazw, użyj [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) po sprawdzeniu, czy nie jest `None`. Raport wymienia właściwości dostępne w prezentacji. Kontrolka może obsługiwać dodatkowe właściwości w czasie wykonywania.

## **Modyfikacja kontrolek ActiveX**

Przykład zakłada prezentację z włączonymi makrami, zawierającą pole tekstowe o nazwie `TextBox1` i przycisk polecenia o nazwie `CommandButton1` na pierwszym slajdzie. Wykorzystuje [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) do zmiany wartości pola tekstowego oraz podpisu przycisku. Każda kontrolka posiada także statyczny podgląd, który PowerPoint może wyświetlić przed aktywacją. Dostarcz PNG dla każdej kontrolki przedstawiające zaktualizowany tekst i wygląd. Przykład przypisuje te obrazy za pomocą [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Przykład przesuwa każdą kontrolkę na pierwszym slajdzie w dół o 100 punktów, zmieniając jej [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Zapisuje zmodyfikowaną prezentację w formacie PPTM, a następnie używa [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) do zapisania drugiej kopii z usuniętymi wszystkimi kontrolkami ActiveX z tego slajdu.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Dodanie kontrolki odtwarzacza multimediów ActiveX**

Aby ponownie użyć skonfigurowanej kontrolki Windows Media Player, rozpocznij od szablonu, którego pierwszy slajd zawiera odtwarzacz o nazwie `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) kopiuje cały slajd do nowej prezentacji. Przykład ustawia `URL` odtwarzacza w jego [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) i zapisuje sklonowany slajd jako jedyny slajd w wyjściu. Film pozostaje zewnętrzny, więc wybierz ścieżkę dostępną dla odtwarzacza podczas odtwarzania.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**

Tak. Aspose.Slides może odczytywać i zapisywać kontrolki, włącznie z ich właściwościami i pozycjami, bez ich aktywacji.

**Czym różnią się kontrolki ActiveX od obiektów OLE?**

Kontrolki ActiveX pozwalają użytkownikom wchodzić w interakcję ze slajdem, np. wprowadzając tekst lub klikając przycisk. [OLE object](/slides/pl/python-net/manage-ole/) umożliwia slajdowi zawieranie lub łączenie się z treścią zarządzaną przez inną aplikację, taką jak arkusz Excel.

**Czy zdarzenia ActiveX nadal wywołają makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**

Zapisz prezentację w formacie obsługującym makra, takim jak PPTM, aby zachować projekt VBA. PowerPoint dla Windows może uruchomić istniejące obsługi zdarzeń, gdy jego ustawienia zabezpieczeń pozwalają zarówno na kontrolki ActiveX, jak i na makra.