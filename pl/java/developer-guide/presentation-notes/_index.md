---
title: "Zarządzanie notatkami prezentacji w Java"
linktitle: "Notatki prezentacji"
type: docs
weight: 110
url: /pl/java/presentation-notes/
keywords:
- "notatki"
- "slajd z notatkami"
- "dodaj notatki"
- "usuń notatki"
- "styl notatek"
- "notatki główne"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Java"
- "Aspose.Slides"
description: "Dostosuj notatki prezentacji przy użyciu Aspose.Slides dla Javy. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides umożliwia usunięcie notatek z dowolnego slajdu oraz zastosowanie stylu do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuwanie notatek z konkretnego slajdu w prezentacji.
- Usuwanie notatek ze wszystkich slajdów w prezentacji.

## **Usuwanie notatek ze slajdu**
Notatki wybranego slajdu można usunąć, jak pokazano w poniższym przykładzie:

```java
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek z pierwszego slajdu
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Zapisywanie prezentacji na dysk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie notatek z prezentacji**
Notatki ze wszystkich slajdów w prezentacji można usunąć, jak pokazano w poniższym przykładzie:

```java
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Usuwanie notatek ze wszystkich slajdów
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Zapisywanie prezentacji na dysk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodanie stylu notatek**
[getNotesStyle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) method has been added to [IMasterNotesSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMasterNotesSlide) interface and [MasterNotesSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/MasterNotesSlide) class respectively. This property specifies the style of a notes text. The implementation is demonstrated in the example below.

```java
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

**Który podmiot API zapewnia dostęp do notatek konkretnego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notesslidemanager/) oraz [method](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) zwracający obiekt notatek lub `null`, jeśli notatki nie istnieją.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi współpracuje biblioteka?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97 i nowsze) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej kopii PowerPoint.