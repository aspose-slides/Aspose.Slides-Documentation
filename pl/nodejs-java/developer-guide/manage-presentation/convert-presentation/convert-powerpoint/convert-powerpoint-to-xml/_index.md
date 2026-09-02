---
title: Konwertuj prezentacje PowerPoint do XML w JavaScript
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /pl/nodejs-java/convert-powerpoint-to-xml/
keywords:
- konwertuj PowerPoint do XML
- konwertuj prezentację do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- Prezentacja PowerPoint XML
- SaveFormat.Xml
- zapisz prezentację jako XML
- eksportuj prezentację do XML
- strumień XML
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint i OpenDocument na pliki lub strumienie PowerPoint XML w JavaScript przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java może konwertować prezentacje PowerPoint do formatu PowerPoint XML Presentation. Wyjście XML jest przydatne, kiedy potrzebna jest tekstowa reprezentacja do analizy struktury prezentacji, rozwiązywania problemów z wygenerowanymi dokumentami, porównywania wyników w testach automatycznych lub integracji z procesem, który konsumuje XML zamiast pakietu prezentacji.

Użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save) z wartością `Xml` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveformat/). Wynik można zapisać bezpośrednio do pliku lub do strumienia.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` tworzy PowerPoint XML Presentation. Nie wyodrębnia on pojedynczych części Office Open XML przechowywanych w pakiecie PPTX. Jeśli potrzebujesz dokładnych części pakietu PPTX, takich jak `ppt/presentation.xml` lub poszczególnych plików XML slajdów, sprawdź sam pakiet PPTX.
{{% /alert %}}

## **Konwertuj prezentację do pliku XML**

Załaduj źródłową prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i przekaż ścieżkę wyjściową oraz `SaveFormat.Xml` do [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save). Źródłem może być dowolny format prezentacji obsługiwany przy ładowaniu, np. PPT, PPTX lub ODP.

Poniższy przykład konwertuje prezentację PPTX na plik XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Zapisz wyjście XML do strumienia**

Użyj przeciążenia strumieniowego [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save), gdy XML musi pozostać w pamięci lub być przekazany do innego komponentu, takiego jak usługa sieciowa, dostawca magazynu lub potok przetwarzania XML. Poniższy przykład zapisuje wynik do Java `ByteArrayOutputStream` i kopiuje wygenerowane dane do Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Przekaż xmlBuffer do następnego komponentu w przepływie pracy.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Porównaj XML z formatami prezentacji i eksportu**

Wybierz format wyjściowy w zależności od tego, jak wynik będzie używany:

| Format | Wyjście | Typowe zastosowanie |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentacja PowerPoint XML | Inspekcja struktury, rozwiązywanie problemów, porównywanie wygenerowanego wyjścia oraz integracja oparta na XML |
| PPT (`.ppt`) | Plik prezentacji w starszym formacie binarnym | Zgodność ze starszymi przepływami pracy PowerPoint |
| PPTX (`.pptx`) | Pakiet Office Open XML zawierający wiele części | Standardowa edycja PowerPoint i wymiana prezentacji |
| PDF lub TIFF | Strony o stałym układzie lub obraz wielostronicowy | Przeglądanie, drukowanie i archiwizacja |
| PNG, JPEG lub SVG | Wyrenderowana reprezentacja pojedynczego slajdu | Miniaturki, podglądy i zasoby graficzne |
| HTML lub HTML5 | Wyjście prezentacji przeznaczone dla sieci | Wyświetlanie w przeglądarce i publikowanie w sieci |

W przeciwieństwie do PPT i PPTX, wyjście XML jest przeznaczone głównie do inspekcji i przepływów pracy opartych na danych. W przeciwieństwie do PDF, TIFF, HTML i formatów obrazów slajdów, reprezentuje ono dane prezentacji, a nie renderuje slajdów jako strony lub zasoby wizualne. Tabela [supported file formats](/slides/pl/nodejs-java/supported-file-formats/) wymienia PowerPoint XML Presentation jako format wyłącznie do zapisu, więc nie używaj go, gdy przepływ pracy wymaga wczytania wyeksportowanego pliku z powrotem do Aspose.Slides w celu dalszej edycji.

## **FAQ**

**Czy `SaveFormat.Xml` to to samo co zapisywanie pliku PPTX?**

Nie. PPTX jest pakietem zawierającym wiele części Office Open XML, natomiast `SaveFormat.Xml` tworzy plik PowerPoint XML Presentation.

**Czy mogę zapisać wyjście XML bez tworzenia pliku na dysku?**

Tak. Przekaż zapisywalny strumień do [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save). Na przykład użyj Java `ByteArrayOutputStream` i skopiuj jego dane do Node.js `Buffer` w celu przetwarzania w pamięci.

**Czy Aspose.Slides może ponownie wczytać wyeksportowany plik XML?**

Nie. PowerPoint XML Presentation jest obecnie obsługiwany wyłącznie do zapisu, a nie do wczytywania. Użyj PPTX lub innego obsługiwanego formatu prezentacji, gdy wymagana jest edycja w obie strony.

**Czy konwersja XML renderuje każdy slajd jako stronę lub obraz?**

Nie. Konwersja XML zapisuje ustrukturyzowane dane prezentacji. Użyj PDF lub TIFF dla wyjścia ukierunkowanego na strony lub PNG, JPEG i SVG dla pojedynczych obrazów slajdów.