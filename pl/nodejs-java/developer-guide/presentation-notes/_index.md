---
title: Zarządzanie notatkami prezentacji w JavaScript
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/nodejs-java/presentation-notes/
keywords:
- notatki
- slajd notatek
- dodawanie notatek
- usuwanie notatek
- styl notatek
- główne notatki
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj notatki prezentacji w JavaScript przy użyciu Aspose.Slides dla Node.js. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją produktywność."
---
## **Overview**

Aspose.Slides obsługuje usuwanie slajdów notatek z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów notatek w prezentacji. Aspose.Slides umożliwia usuwanie notatek z dowolnego slajdu oraz stosowanie formatowania do istniejących notatek. Deweloperzy mogą usuwać notatki w następujący sposób:

- Usunięcie notatek z określonego slajdu w prezentacji.
- Usunięcie notatek ze wszystkich slajdów w prezentacji.

## **Remove Notes from Slide**
Notatki wybranego slajdu można usunąć, jak pokazano w poniższym przykładzie:

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek z pierwszego slajdu
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Zapis prezentacji na dysku
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Remove Notes from Presentation**
Notatki ze wszystkich slajdów prezentacji można usunąć, jak pokazano w poniższym przykładzie:

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek ze wszystkich slajdów
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Zapis prezentacji na dysku
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) metoda została dodana do klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterNotesSlide) oraz klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterNotesSlide). Ta właściwość określa styl tekstu notatek. Implementacja jest przedstawiona w poniższym przykładzie.

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Pobierz styl tekstu MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Ustaw symbol wypunktowania dla akapitów pierwszego poziomu
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notatki są dostępne przez menedżera notatek slajdu: slajd ma [NotesSlideManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslidemanager/) oraz [method](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) który zwraca obiekt notatek, lub `null` jeśli notatek nie ma.

**Are there differences in notes support across the PowerPoint versions the library works with?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97‑nowe) oraz ODP; notatki są obsługiwane w tych formatach bez konieczności posiadania zainstalowanej kopii PowerPointa.