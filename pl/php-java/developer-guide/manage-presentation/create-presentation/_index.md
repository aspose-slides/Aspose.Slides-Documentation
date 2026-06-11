---
title: Tworzenie prezentacji w PHP
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/php-java/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- tworzenie PPT
- nowy PPT
- tworzenie PPTX
- nowy PPTX
- tworzenie ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz prezentacje przy użyciu Aspose.Slides dla PHP poprzez Java — generuj pliki PPT, PPTX i ODP i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać prostą zawartość do slajdu i zapisać wynik jako plik. Demonstruje także, jak stworzyć i zapisać nową prezentację, otworzyć istniejącą prezentację w obsługiwanym formacie i zapisać ją w innym formacie. Dodatkowo artykuł zawiera krótkie FAQ obejmujące typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wątkowości, licencjonowania, podpisów cyfrowych oraz obsługi VBA.

## **Utworzenie prezentacji**

Aby dodać prostą prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

1. Utwórz instancję klasy Presentation.  
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.  
3. Dodaj AutoShape typu Linia, używając metody addAutoShape udostępnionej przez obiekt Shapes.  
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Dodaj autoshape typu linia
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**W jakich formatach mogę zapisać nową prezentację?**  
Możesz zapisać w formatach [PPTX, PPT i ODP](/slides/pl/php-java/save-presentation/), a także eksportować do [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/php-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/php-java/convert-powerpoint-to-html/), [SVG](/slides/pl/php-java/convert-powerpoint-to-png/) oraz [obrazki](/slides/pl/php-java/convert-powerpoint-to-png/), i nie tylko.

**Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?**  
Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/php-java/supported-file-formats/).

**Jak kontrolować rozmiar slajdu i stosunek proporcji przy tworzeniu prezentacji?**  
Ustaw [rozmiar slajdu](/slides/pl/php-java/slide-size/) (w tym predefiniowane, takie jak 4:3 i 16:9 lub własne wymiary) i wybierz, jak treść ma być skalowana.

**W jakich jednostkach mierzone są rozmiary i współrzędne?**  
W punktach: 1 cal równa się 72 jednostkom.

**Jak obsługiwać bardzo duże prezentacje (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?**  
Użyj [strategii zarządzania BLOB](/slides/pl/php-java/manage-blob/), ogranicz przechowywanie w pamięci, korzystając z plików tymczasowych, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

**Czy mogę tworzyć/zapisywać prezentacje równolegle?**  
Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) z [wielu wątków](/slides/pl/php-java/multithreading/). Uruchom oddzielne, izolowane instancje dla każdego wątku lub procesu.

**Jak usunąć znak wodny wersji próbnej i ograniczenia?**  
[Zastosuj licencję](/slides/pl/php-java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wiele wątków.

**Czy mogę cyfrowo podpisać utworzony przeze mnie PPTX?**  
Tak. [Podpisy cyfrowe](/slides/pl/php-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

**Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?**  
Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/php-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.