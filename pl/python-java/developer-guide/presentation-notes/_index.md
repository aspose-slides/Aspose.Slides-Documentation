---
title: Zarządzanie notatkami prezentacji w Pythonie przy użyciu Java
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/python-java/presentation-notes/
keywords:
- notatki
- slajd notatek
- dodawanie notatek
- usuwanie notatek
- styl notatek
- notatki główne
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dostosuj notatki prezentacji za pomocą Aspose.Slides dla Pythona przy użyciu Java. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. Ten temat wprowadza tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides pozwala usunąć notatki z dowolnego slajdu i zastosować formatowanie do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usunięcie notatek z określonego slajdu w prezentacji.
- Usunięcie notatek ze wszystkich slajdów w prezentacji.

## **Usuwanie notatek ze slajdu**

Notatki z określonego slajdu można usunąć, tak jak pokazano w poniższym przykładzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji.
presentation = Presentation("presWithNotes.pptx")
try:
    # Usuń notatki z pierwszego slajdu.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Zapisz prezentację na dysku.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usuwanie notatek z prezentacji**

Notatki ze wszystkich slajdów w prezentacji można usunąć, tak jak pokazano w poniższym przykładzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji.
presentation = Presentation("presWithNotes.pptx")
try:
    # Usuń notatki ze wszystkich slajdów.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Zapisz prezentację na dysku.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodanie stylu notatek**

Metoda [getNotesStyle](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslide/#getNotesStyle) klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslide/) zapewnia dostęp do stylu tekstu notatek. Implementacja została przedstawiona w poniższym przykładzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Pobierz styl tekstu master slajdu notatek.
        notes_style = notes_master.getNotesStyle()

        # Ustaw wypunktowanie symbolem dla akapitów pierwszego poziomu.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Który element API zapewnia dostęp do notatek określonego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notesslidemanager/) oraz metodę [getNotesSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notesslidemanager/#getNotesSlide), która zwraca obiekt notatek lub `None`, jeśli notatki nie istnieją.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi współpracuje biblioteka?**

Biblioteka obsługuje szeroką gamę formatów Microsoft PowerPoint (97 i późniejsze) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej kopii programu PowerPoint.