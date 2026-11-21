---
title: Zarządzanie notatkami prezentacji w .NET
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Dostosuj notatki prezentacji za pomocą Aspose.Slides dla .NET. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides umożliwia usunięcie notatek z dowolnego slajdu oraz zastosowanie formatowania do istniejących notatek. Deweloperzy mogą usuwać notatki w następujący sposób:

- Usunięcie notatek z określonego slajdu w prezentacji.
- Usunięcie notatek ze wszystkich slajdów w prezentacji.

Aby odczytać lub zmienić wymiary strony notatek, przełączyć orientację i sprawdzić zachowanie przy eksporcie, zobacz [Notes Page Size](/slides/pl/net/notes-size/).

## **Usuwanie notatek ze slajdu**
Notatki wybranego slajdu mogą zostać usunięte, jak pokazano w poniższym przykładzie:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation presentation = new Presentation("AccessSlides.pptx");

// Usuwanie notatek z pierwszego slajdu
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Zapisz prezentację na dysk
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Usuwanie notatek ze wszystkich slajdów**
Notatki ze wszystkich slajdów prezentacji mogą zostać usunięte, jak pokazano w poniższym przykładzie:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Usuwanie notatek ze wszystkich slajdów
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Zapisz prezentację na dysk
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Dodanie stylu notatek**
Właściwość NotesStyle została dodana do interfejsu [IMasterNotesSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslide) oraz klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslide). Ta właściwość określa styl tekstu notatek. Implementacja jest pokazana w poniższym przykładzie.

```c#
using Aspose.Slides;

// Utwórz obiekt klasy Presentation, który reprezentuje plik prezentacji
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Pobierz styl tekstu MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Ustaw symbol wypunktowania dla paragrafów pierwszego poziomu
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Zapisz plik PPTX na dysku
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Która jednostka API zapewnia dostęp do notatek określonego slajdu?

Dostęp do notatek odbywa się przez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/net/aspose.slides/notesslidemanager/) oraz [property](https://reference.aspose.com/slides/pl/net/aspose.slides/notesslidemanager/notesslide/), które zwracają obiekt notatek lub `null`, jeśli notatki nie istnieją.

### Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi biblioteka współpracuje?

Biblioteka obsługuje szeroką gamę formatów Microsoft PowerPoint (97 i nowsze) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej kopii programu PowerPoint.