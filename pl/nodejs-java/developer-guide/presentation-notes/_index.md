---
title: Zarządzaj notatkami prezentacji w JavaScript
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj notatki prezentacji w JavaScript przy użyciu Aspose.Slides dla Node.js. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak stosować styl do slajdów z notatkami w prezentacji. Aspose.Slides umożliwia usunięcie notatek z dowolnego slajdu oraz zastosowanie stylizacji istniejącym notatkom. Programiści mogą usuwać notatki w następujący sposób:

- Usuwanie notatek z określonego slajdu w prezentacji.  
- Usuwanie notatek ze wszystkich slajdów w prezentacji.

Aby przeczytać lub zmienić wymiary strony notatek, przełączyć orientację oraz sprawdzić zachowanie eksportu, zobacz [Rozmiar strony notatek](/slides/pl/nodejs-java/notes-size/).

## **Usuwanie notatek ze slajdu**
Notatki z określonego slajdu można usunąć, jak pokazano w poniższym przykładzie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek pierwszego slajdu
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Zapisywanie prezentacji na dysku
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie notatek z prezentacji**
Notatki ze wszystkich slajdów w prezentacji można usunąć, jak pokazano w poniższym przykładzie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek ze wszystkich slajdów
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Zapisywanie prezentacji na dysku
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodaj NotesStyle**
Metoda [getNotesStyle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) została dodana do klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterNotesSlide) i klasy [MasterNotesSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterNotesSlide). Ta właściwość określa styl tekstu notatek. Implementację przedstawiono w poniższym przykładzie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Pobierz styl tekstu MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Ustaw symbol wypunktowania dla akapitów pierwszego poziomu
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie API zapewnia dostęp do notatek określonego slajdu?**

Notatki są dostępne za pośrednictwem menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslidemanager/) i [method](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), który zwraca obiekt notatek lub `null`, jeśli notatki nie istnieją.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi działa biblioteka?**

Biblioteka obsługuje szeroką gamę formatów Microsoft PowerPoint (97‑nowsze) oraz ODP; notatki są wspierane w tych formatach niezależnie od zainstalowanej kopii PowerPoint.