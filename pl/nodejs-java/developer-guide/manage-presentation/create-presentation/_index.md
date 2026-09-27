---
title: Tworzenie prezentacji w JavaScript
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz prezentacje za pomocą Aspose.Slides — generuj pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne rezultaty."
---
## **Omówienie**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać pole tekstowe do pierwszego slajdu i zapisać wynik jako plik.

Przed rozpoczęciem zainstaluj pakiet `aspose.slides.via.java` z npm, wraz z wymaganym JDK, Pythonem i narzędziami budowania C++. Zobacz [Instalacja](/slides/pl/nodejs-java/installation/).

## **Utworzenie prezentacji PowerPoint**

Aby utworzyć prezentację i umieścić pole tekstowe na pierwszym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Nowa prezentacja już zawiera jeden pusty slajd.
1. Pobierz ten slajd z [kolekcji slajdów](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) według jego indeksu, 0.
1. Dodaj prostokąt przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) i ustaw jego tekst metodą [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/).
1. Zapisz prezentację jako plik PPTX przy pomocy metody [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/).
1. Zwolnij prezentację metodą [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/), a następnie zakończ proces.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides działa w maszynie wirtualnej Javy, która utrzymuje Node.js w działaniu, więc zakończ proces jawnie.
process.exit(0);
```

Górny lewy róg prostokąta znajduje się 50 punktów od lewej krawędzi i 50 punktów od górnej krawędzi slajdu, a prostokąt ma szerokość 400 punktów i wysokość 100 punktów. Zapisz kod jako *hello.js* w folderze projektu i uruchom `node hello.js`: zapisze on *hello.pptx* z jednym slajdem zawierającym ten prostokąt i jego tekst w bieżącym folderze.

Aspose.Slides działa w maszynie wirtualnej Javy, którą pakiet `java` uruchamia wewnątrz procesu Node.js. Ta maszyna wirtualna uniemożliwia samodzielne zakończenie działania Node.js po zakończeniu skryptu, dlatego przykład kończy się wywołaniem `process.exit(0)`.

Bez licencji Aspose.Slides dodaje również znak wodny oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/nodejs-java/licensing/).

## **FAQ**

### Jakie formaty mogę zapisać nową prezentację?

Możesz zapisać w formatach [PPTX, PPT i ODP](/slides/pl/nodejs-java/save-presentation/), a także eksportować do [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/) oraz [obrazów](/slides/pl/nodejs-java/convert-powerpoint-to-png/), między innymi.

### Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/nodejs-java/supported-file-formats/).

### Jak kontrolować rozmiar slajdu/ proporcje podczas tworzenia prezentacji?

Ustaw [rozmiar slajdu](/slides/pl/nodejs-java/slide-size/) (w tym presety takie jak 4:3 i 16:9 lub własne wymiary) oraz wybierz sposób skalowania treści.

### W jakich jednostkach mierzone są rozmiary i współrzędne?

W punktach: 1 cal to 72 jednostki.

### Jak obsługiwać bardzo duże prezentacje (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?

Użyj [strategii zarządzania BLOB](/slides/pl/nodejs-java/manage-blob/), ogranicz przechowywanie w pamięci, korzystając z plików tymczasowych, oraz preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

### Czy mogę tworzyć/zapisywać prezentacje równolegle?

Nie możesz operować na tej samej instancji [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) z [wielu wątków](/slides/pl/nodejs-java/multithreading/). Uruchom oddzielne, izolowane instancje na każdy wątek lub proces.

### Jak usunąć znak wodny wersji próbnej i ograniczenia?

[Zastosuj licencję](/slides/pl/nodejs-java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są liczne wątki.

### Czy mogę cyfrowo podpisać tworzony przeze mnie plik PPTX?

Tak. [Podpisy cyfrowe](/slides/pl/nodejs-java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

### Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/nodejs-java/presentation-via-vba/) i zapisywać pliki z włączonymi makrami, takie jak PPTM/PPSM.