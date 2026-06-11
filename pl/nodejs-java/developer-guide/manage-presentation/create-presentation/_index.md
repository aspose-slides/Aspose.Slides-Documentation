---
title: Tworzenie prezentacji w JavaScript
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/nodejs-java/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- utwórz PPT
- nowy PPT
- utwórz PPTX
- nowy PPTX
- utwórz ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz prezentacje przy użyciu Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać prostą treść do slajdu i zapisać wynik jako plik.

## **Utwórz prezentację PowerPoint**

Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj następujące kroki:

1. Utwórz instancję klasy Presentation.  
2. Uzyskaj referencję do slajdu, używając jego indeksu.  
3. Dodaj AutoShape typu Linia, używając metody addAutoShape udostępnionej przez obiekt Shapes.  
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Dodaj autoshape typu linia
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie formaty mogę zapisać nową prezentację?**  
Możesz zapisać jako [PPTX, PPT i ODP](/slides/pl/nodejs-java/save-presentation/), a także wyeksportować do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/pl/nodejs-java/convert-powerpoint-to-png/), oraz [obrazów](/slides/pl/nodejs-java/convert-powerpoint-to-png/), i inne.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako standardowy PPTX?**  
Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/nodejs-java/supported-file-formats/).

**Jak kontrolować rozmiar slajdu lub proporcje przy tworzeniu prezentacji?**  
Ustaw [rozmiar slajdu](/slides/pl/nodejs-java/slide-size/) (w tym predefiniowane rozmiary takie jak 4:3 i 16:9 lub niestandardowe wymiary) i wybierz, jak ma skalować się zawartość.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**  
W punktach: 1 cal to 72 jednostki.

**Jak obsługiwać bardzo duże prezentacje (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**  
Użyj [strategii zarządzania BLOB](/slides/pl/nodejs-java/manage-blob/), ogranicz przechowywanie w pamięci, korzystając z plików tymczasowych, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**  
Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) z [wielu wątków](/slides/pl/nodejs-java/multithreading/). Uruchamiaj oddzielne, izolowane instancje w każdym wątku lub procesie.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**  
[Zastosuj licencję](/slides/pl/nodejs-java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane jest wiele wątków.

**Czy mogę cyfrowo podpisać tworzony przeze mnie plik PPTX?**  
Tak. [Podpisy cyfrowe](/slides/pl/nodejs-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane dla prezentacji.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**  
Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/nodejs-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.