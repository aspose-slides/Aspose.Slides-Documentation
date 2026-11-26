---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu Pythona
linktitle: ActiveX
type: docs
weight: 80
url: /pl/python-java/activex/
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
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek oraz ponownie wykorzystaj kontrolkę Windows Media Player w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Wprowadzenie**

Kontrolki ActiveX dają slajdowi PowerPoint elementy interaktywne, takie jak pola tekstowe, przyciski poleceń i odtwarzacze multimedialne. Aspose.Slides for Python via Java udostępnia kontrolki slajdu poprzez [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Użyj tej kolekcji, aby edytować kontrolkę, przenieść ją na slajdzie lub usunąć.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

Aby zbadać nieznany szablon, otwórz go w trybie odczytu i przeiteruj kontrolki na każdym slajdzie. Przykład podaje numer slajdu, nazwę kontrolki, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), oraz każdą parę klucz‑wartość w [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Odczytuje prezentację bez aktywacji kontrolek, wywoływania zdarzeń lub makr, zmieniania wartości czy zapisywania pliku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
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

Pusta kolekcja właściwości pojawia się jako `[]`. Dla kontrolek używających binarnego przechowywania, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) może zwrócić `None`, wyświetlane jako `Properties unavailable`. Jeśli potrzebujesz tylko nazw, użyj [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) po sprawdzeniu, że kolekcja jest dostępna. Raport wymienia właściwości dostępne w prezentacji. Kontrolka może obsługiwać dodatkowe właściwości w czasie wykonywania.

## **Modyfikowanie kontrolek ActiveX**

Przykład zakłada prezentację z włączonymi makrami, zawierającą pole tekstowe o nazwie `TextBox1` oraz przycisk polecenia o nazwie `CommandButton1` na pierwszym slajdzie. Używa [collection właściwości kontrolki](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) aby zmienić wartość pola tekstowego i podpis przycisku. Każda kontrolka ma także statyczny podgląd, który PowerPoint może wyświetlić przed aktywacją. Dostarcz plik PNG dla każdej kontrolki, przedstawiający zaktualizowany tekst i wygląd. Przykład przypisuje te obrazy poprzez [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Przykład przesuwa każdą kontrolkę na pierwszym slajdzie w dół o 100 punktów, ustawiając jej ramkę za pomocą [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Zapisuje zmodyfikowaną prezentację w formacie PPTM, a następnie używa [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear), aby zapisać drugą kopię z usuniętymi wszystkimi kontrolkami ActiveX z tego slajdu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Dodanie kontrolki ActiveX Media Player**

Aby ponownie użyć skonfigurowanej kontrolki Windows Media Player, rozpocznij od szablonu, którego pierwszy slajd zawiera odtwarzacz o nazwie `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) kopiuje cały slajd do nowej prezentacji. Przykład ustawia `URL` odtwarzacza w jego [kolekcji właściwości](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) i zapisuje sklonowany slajd jako jedyny slajd w wyniku. Wideo pozostaje zewnętrzne, więc wybierz ścieżkę dostępną dla odtwarzacza podczas odtwarzania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**

Tak. Aspose.Slides może odczytywać i zapisywać kontrolki, wraz z ich właściwościami i pozycjami, bez ich aktywacji.

**Czym różnią się kontrolki ActiveX od obiektów OLE?**

Kontrolki ActiveX pozwalają użytkownikom na interakcję ze slajdem, na przykład poprzez wprowadzanie tekstu lub klikanie przycisku. [Obiekt OLE](/slides/pl/python-java/manage-ole/) umożliwia slajdowi zawieranie lub łączenie się z treścią zarządzaną przez inną aplikację, taką jak arkusz Excel.

**Czy zdarzenia ActiveX nadal wywołają makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**

Zapisz prezentację w formacie obsługującym makra, takim jak PPTM, aby zachować projekt VBA. PowerPoint dla systemu Windows może uruchomić istniejące obsługi zdarzeń, gdy ustawienia zabezpieczeń zezwalają zarówno na kontrolki ActiveX, jak i makra.