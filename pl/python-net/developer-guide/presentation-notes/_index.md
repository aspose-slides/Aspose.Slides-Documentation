---
title: Zarządzanie notatkami prezentacji w Pythonie
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/python-net/presentation-notes/
keywords:
- notatki
- slajd notatek
- dodaj notatki
- usuń notatki
- styl notatek
- notatki główne
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dostosuj notatki prezentacji przy użyciu Aspose.Slides dla Pythona w .NET. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją produktywność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usunąć notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides pozwala usunąć notatki z dowolnego slajdu oraz zastosować formatowanie do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuwanie notatek z określonego slajdu w prezentacji.
- Usuwanie notatek ze wszystkich slajdów w prezentacji.

## **Usuwanie notatek ze slajdu**
Notatki wybranego slajdu można usunąć, jak pokazano w poniższym przykładzie:

```py
import aspose.slides as slides

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Usuwanie notatek pierwszego slajdu
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # zapisz prezentację na dysk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie notatek ze wszystkich slajdów**
Notatki ze wszystkich slajdów prezentacji można usunąć, jak pokazano w poniższym przykładzie:

```py
import aspose.slides as slides

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Usuwanie notatek ze wszystkich slajdów
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # zapisz prezentację na dysk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj styl notatek**
Właściwość [notes_style](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslide/notes_style/) została dodana do klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslide/). Właściwość ta określa styl tekstu notatek. Implementacja została przedstawiona w poniższym przykładzie.

```py
import aspose.slides as slides

# Utwórz klasę Presentation, która reprezentuje plik prezentacji
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Pobierz styl tekstu MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Ustaw symbol wypunktowania dla akapitów pierwszego poziomu
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # zapisz plik PPTX na dysk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Który podmiot API zapewnia dostęp do notatek określonego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslidemanager/) oraz [property](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslidemanager/notes_slide/) zwracające obiekt notatek lub `None`, jeśli notatek nie ma.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi biblioteka współpracuje?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97‑nowsze) oraz ODP; notatki są obsługiwane w tych formatach bez konieczności posiadania zainstalowanej kopii PowerPoint.