---
title: Konwertuj PowerPoint do PDF w Node.js via .NET
linktitle: PowerPoint do PDF
type: docs
weight: 30
url: /pl/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint do PDF
- konwertuj PowerPoint do PDF
- PPTX do PDF
- PPT do PDF
- ODP do PDF
- zapisz prezentację jako PDF
- PDF/A
- PdfOptions
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PPTX, PPT i ODP do PDF w JavaScript przy użyciu Aspose.Slides for Node.js via .NET i twórz archiwalne pliki PDF/A przy użyciu PdfOptions."
---
## **Przegląd**

Aspose.Slides for Node.js via .NET konwertuje prezentacje PowerPoint i OpenDocument do PDF bez Microsoft PowerPoint. Każdy widoczny slajd staje się jedną stroną PDF o tym samym rozmiarze co slajd, a tekst pozostaje wybieralny i przeszukiwalny. Ten artykuł pokazuje domyślną konwersję oraz konwersję do PDF/A przy użyciu [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

Przykłady zakładają, że w katalogu projektu znajduje się prezentacja o nazwie `sample.pptx`, którą utworzyłeś w sekcji [Instalacja](/slides/pl/nodejs-net/installation/). Każda prezentacja PowerPoint będzie działać. Zapisz każdy przykład jako plik `.js` w katalogu projektu i uruchom go z tego katalogu za pomocą `node`.

{{% alert color="info" title="Uwaga" %}}
Aspose.Slides for Node.js via .NET nie posiada własnej dokumentacji API. Odzwierciedla API Aspose.Slides for .NET z nazwami w stylu camelCase, więc odnośniki API w tym artykule prowadzą do odpowiadających klas i elementów w dokumentacji API Aspose.Slides for .NET.
{{% /alert %}}

## **Konwertuj prezentację do PDF**

Aby skonwertować prezentację do PDF, wykonaj następujące kroki:

1. Otwórz prezentację, przekazując jej ścieżkę do konstruktora [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) . Ten sam kod działa dla plików PPTX, PPT i ODP.
1. Wywołaj metodę [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) , podając ścieżkę wyjściową oraz `SaveFormat.Pdf`.
1. Wywołaj `dispose` w bloku `finally`, aby zwolnić zasoby .NET używane przez prezentację.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Skrypt zapisuje `sample.pdf` w katalogu projektu. Konwersja używa ustawień domyślnych: każdy slajd, który nie jest ukryty, staje się stroną, w kolejności slajdów. Bez licencji każda strona zawiera znak wodny oceny; zobacz [Licencjonowanie](/slides/pl/nodejs-net/licensing/).

## **Konwertuj prezentację do PDF/A**

Aby kontrolować wynik, przekaż obiekt [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) jako trzeci argument metody `save`. Poniższy przykład ustawia właściwość [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) na `PdfCompliance.PdfA2b`, co generuje plik PDF/A-2b. PDF/A jest standardem ISO dla długoterminowego archiwizowania: między innymi wymaga, aby każda czcionka używana w dokumencie była osadzona w pliku.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Skrypt zapisuje `sample-pdfa.pdf` z taką samą liczbą stron jak domyślna konwersja. Aby potwierdzić, że plik spełnia standard, sprawdź go przy użyciu walidatora PDF/A, takiego jak [veraPDF](https://verapdf.org/). Inne wartości [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) wybierają inne standardy, np. `PdfA1b`, `PdfA2a` lub `PdfUa` dla dostępności.

## **FAQ**

**Jak uwzględnić ukryte slajdy w pliku PDF?**

Ukryte slajdy są pomijane domyślnie. Ustaw właściwość [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) obiektu `PdfOptions` na `true` i przekaż opcje do metody `save`.

**Czy mogę zabezpieczyć PDF hasłem?**

Tak. Ustaw właściwość [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) obiektu `PdfOptions` przed wywołaniem `save`. Czytniki PDF poproszą wtedy o podanie hasła przed otwarciem pliku.

**Czy mogę konwertować tylko wybrane slajdy?**

Tak. Przekaż tablicę pozycji slajdów jako czwarty argument metody `save`. Pozycje są numerowane od 1, a trzeci argument może być `null`, jeśli nie potrzebujesz opcji: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` zapisuje PDF z pierwszym i trzecim slajdem.

**Dlaczego tekst wygląda inaczej po konwersji na Linuksie?**

Aspose.Slides może korzystać tylko z czcionek zainstalowanych na maszynie, na której wykonywana jest konwersja. Gdy prezentacja używa czcionki, której brakuje, np. Calibri na typowym serwerze Linux, Aspose.Slides używa zamiast niej zainstalowanej czcionki, co może zmienić wygląd tekstu i miejsca podziału linii. Zainstaluj czcionki używane w Twoich prezentacjach, aby uzyskać taki sam rezultat jak w systemie Windows.

**Czy mogę otrzymać PDF jako Buffer zamiast pliku?**

Tak. `presentation.saveToBuffer(SaveFormat.Pdf)` zwraca PDF jako obiekt `Buffer` w Node.js, co jest wygodne przy wysyłaniu wyniku w odpowiedzi HTTP. Przyjmuje również `PdfOptions` jako drugi argument.