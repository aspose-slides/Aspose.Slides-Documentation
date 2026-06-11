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
description: "Dostosuj notatki do prezentacji przy użyciu Aspose.Slides for .NET. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją produktywność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów notatek z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów notatek w prezentacji. Aspose.Slides pozwala usuwać notatki z dowolnego slajdu oraz stosować formatowanie do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuń notatki z określonego slajdu w prezentacji.
- Usuń notatki ze wszystkich slajdów w prezentacji.

## **Usuń notatki ze slajdu**
Notatki z wybranego slajdu można usunąć, jak pokazano w poniższym przykładzie:

```c#
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// Usuwanie notatek z pierwszego slajdu
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Zapisz prezentację na dysk
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Usuń notatki ze wszystkich slajdów**
Notatki ze wszystkich slajdów prezentacji można usunąć, jak pokazano w poniższym przykładzie:

```c#
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

## **Dodaj styl notatek**
Dodano właściwość NotesStyle do [IMasterNotesSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/imasternotesslide) interfejsu i [MasterNotesSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/masternotesslide) klasy. Ta właściwość określa styl tekstu notatek. Implementacja została przedstawiona w poniższym przykładzie.

```c#
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Pobierz styl tekstu MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Ustaw symbol wypunktowania dla akapitów pierwszego poziomu
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Zapisz plik PPTX na dysku
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

**Który element API zapewnia dostęp do notatek określonego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/net/aspose.slides/notesslidemanager/) i [property](https://reference.aspose.com/slides/pl/net/aspose.slides/notesslidemanager/notesslide/) zwracającą obiekt notatek lub `null`, jeśli nie ma notatek.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi działa biblioteka?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97‑nowsze) oraz ODP; notatki są obsługiwane w tych formatach bez konieczności posiadania zainstalowanej kopii PowerPointa.