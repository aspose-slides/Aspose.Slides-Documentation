---
title: Zarządzanie notatkami prezentacji w Javie
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/java/presentation-notes/
keywords:
- notatki
- slajd z notatkami
- dodaj notatki
- usuń notatki
- styl notatek
- notatki główne
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dostosuj notatki prezentacji za pomocą Aspose.Slides dla Javy. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją produktywność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym sposób usuwania notatek oraz stosowania stylu do slajdów z notatkami w prezentacji. Aspose.Slides pozwala usunąć notatki z dowolnego slajdu oraz zastosować formatowanie do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuń notatki z określonego slajdu w prezentacji.
- Usuń notatki ze wszystkich slajdów w prezentacji.

Aby odczytać lub zmienić wymiary strony notatek, przełączyć orientację i sprawdzić zachowanie przy eksporcie, zobacz [Notes Page Size](/slides/pl/java/notes-size/).

## **Usuwanie notatek ze slajdu**
Notatki z określonego slajdu można usunąć, jak pokazano w przykładzie poniżej:

```java
import com.aspose.slides.*;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek z pierwszego slajdu
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Zapis prezentacji na dysk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie notatek z prezentacji**
Notatki ze wszystkich slajdów w prezentacji można usunąć, jak pokazano w przykładzie poniżej:

```java
import com.aspose.slides.*;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek ze wszystkich slajdów
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Zapis prezentacji na dysk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodanie stylu notatek**
Metoda [getNotesStyle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) została dodana do interfejsu [IMasterNotesSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMasterNotesSlide) oraz klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/MasterNotesSlide). Ta właściwość określa styl tekstu notatek. Implementacja jest pokazana w przykładzie poniżej.

```java
import com.aspose.slides.*;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Pobierz styl tekstu MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Ustaw symbol wypunktowania dla akapitów pierwszego poziomu
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Który element API zapewnia dostęp do notatek konkretnego slajdu?**

Do notatek dostęp uzyskuje się za pośrednictwem menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notesslidemanager/) oraz [metodę](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) zwracającą obiekt notatek, lub `null`, jeśli notatki nie istnieją.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi działa biblioteka?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97‑nowsze) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej kopii PowerPointa.