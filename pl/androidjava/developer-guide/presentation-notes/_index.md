---
title: Zarządzanie notatkami prezentacji na Androidzie
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/androidjava/presentation-notes/
keywords:
- notatki
- slajd notatek
- dodaj notatki
- usuń notatki
- styl notatek
- główne notatki
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dostosuj notatki prezentacji za pomocą Aspose.Slides dla Androida w języku Java. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides pozwala usuwać notatki z dowolnego slajdu oraz stosować formatowanie do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuwanie notatek z konkretnego slajdu w prezentacji.  
- Usuwanie notatek ze wszystkich slajdów w prezentacji.

Aby odczytać lub zmienić wymiary strony notatek, przełączyć orientację i sprawdzić zachowanie przy eksporcie, zobacz [Rozmiar strony notatek](/slides/pl/androidjava/notes-size/).

## **Usuwanie notatek ze slajdu**
Notatki z konkretnego slajdu mogą być usunięte, jak pokazano w poniższym przykładzie:

```java
import com.aspose.slides.*;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek z pierwszego slajdu
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Zapisanie prezentacji na dysku
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie notatek z prezentacji**
Notatki ze wszystkich slajdów w prezentacji mogą być usunięte, jak pokazano w poniższym przykładzie:

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
    
    // Zapisywanie prezentacji na dysku
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodaj styl notatek**
Metoda [getNotesStyle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) została dodana do interfejsu [IMasterNotesSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMasterNotesSlide) oraz klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/MasterNotesSlide). Ta właściwość określa styl tekstu notatek. Implementacja jest przedstawiona w poniższym przykładzie.

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
    
        //Set Ustaw symbol wypunktowania dla akapitów pierwszego poziomu
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Która jednostka API zapewnia dostęp do notatek konkretnego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notesslidemanager/) oraz [method](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) zwracający obiekt notatek lub `null`, jeśli notatki nie istnieją.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi biblioteka współpracuje?**

Biblioteka obsługuje szeroką gamę formatów Microsoft PowerPoint (97‑nowsze) oraz ODP; notatki są wspierane w tych formatach bez zależności od zainstalowanej kopii PowerPoint.