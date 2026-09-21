---
title: Edytuj dokumenty PDF w JavaScript
linktitle: Edytuj PDF
type: docs
weight: 65
url: /pl/nodejs-java/edit-pdf/
keywords:
- edytuj PDF
- zamień tekst PDF
- PDF do PPTX
- PPTX do PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Edytuj dokumenty PDF w JavaScript, importując je do Aspose.Slides, zamieniając tekst i zapisując zmodyfikowaną prezentację z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for Node.js via Java umożliwia edytowanie treści PDF poprzez importowanie jego stron jako slajdów, modyfikowanie prezentacji i eksportowanie jej z powrotem do PDF. W tym artykule przedstawiono prostą zamianę tekstu. Prezentacja pozostaje w pamięci, więc zapisanie pośredniego pliku PPTX jest opcjonalne.

## **Zamiana tekstu w pliku PDF**

Użyj [addFromPdf](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/#addFromPdf) aby zaimportować strony, [replaceText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#replaceText) aby zaktualizować tekst oraz [save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) aby wyeksportować wynik.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo "Draft" jako edytowalny tekst po imporcie. Zastępuje ono to słowo na "Final" i zapisuje `edited.pdf`. Wyczyszczenie początkowego slajdu przed importem zapobiega dodatkowej pustej stronie w wyniku. Wyszukiwanie dopasowuje całe słowa z taką samą wielkością liter; `null` oznacza, że nie jest potrzebna funkcja zwrotna wyniku.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Aby uzyskać więcej opcji, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/nodejs-java/search-and-replace-text/) oraz [Konwertowanie PowerPoint do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zamiana tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, dlatego należy przeglądać wynik, szczególnie gdy zamieniany tekst jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed eksportem do PDF?**

Nie. Można edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować jej edycję w PowerPoint; zobacz [Zapisz prezentacje](/slides/pl/nodejs-java/save-presentation/).

**Dlaczego niektóry tekst może pozostać niezmieniony?**

Przykład dopasowuje całe słowo "Draft" z dokładnym uwzględnieniem wielkości liter. Tekst zaimportowany jako obraz lub podzielony na osobne ramki tekstowe niekoniecznie zostanie dopasowany. Sprawdź zaimportowaną zawartość i dostosuj wyszukiwanie do swojego dokumentu.