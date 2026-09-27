---
title: Otwieranie prezentacji w Node.js via .NET
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/nodejs-net/open-presentation/
keywords:
- otwórz prezentację
- otwórz PowerPoint
- otwórz PPTX
- otwórz PPT
- otwórz ODP
- załaduj prezentację
- prezentacja z bufora
- liczba slajdów
- konwertuj prezentację
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Otwieraj prezentacje PPTX, PPT i ODP w JavaScript przy użyciu Aspose.Slides for Node.js via .NET: ładuj z ścieżki pliku lub bufora, odczytuj liczbę slajdów i zapisuj w innym formacie."
---
## **Przegląd**

Aspose.Slides for Node.js via .NET otwiera prezentacje PowerPoint i OpenDocument, takie jak pliki PPTX, PPT oraz ODP, z podanej ścieżki pliku lub z obiektu Node.js `Buffer`. Ten artykuł pokazuje oba sposoby, odczytuje liczbę slajdów i zapisuje otwartą prezentację w innym formacie.

Przykłady zakładają, że w folderze projektu znajduje się prezentacja o nazwie `sample.pptx`, którą utworzyłeś w [Installation](/slides/pl/nodejs-net/installation/). Każda prezentacja PowerPoint się sprawdzi. Zapisz każdy przykład jako plik `.js` w folderze projektu i uruchom go z tego folderu poleceniem `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET nie posiada własnej dokumentacji API. Odzwierciedla API Aspose.Slides for .NET z nazwami w stylu camelCase, więc odnośniki do API w tym artykule prowadzą do odpowiednich klas i członków w [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/pl/net/).
{{% /alert %}}

## **Otwórz prezentację z pliku**

Aby otworzyć prezentację, przekaż jej ścieżkę do konstruktora [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/presentation/). Aspose.Slides wykrywa format na podstawie zawartości pliku, a nie jego rozszerzenia, więc ten sam kod otwiera pliki PPTX, PPT i ODP. Ścieżka względna jest rozwiązywana względem bieżącego katalogu roboczego, którym jest katalog projektu, gdy uruchamiasz skrypt z tego miejsca.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skrypt wypisuje liczbę slajdów w `sample.pptx`, np. `Slide count: 9`. Właściwość `count` kolekcji [slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slides/pl/) obejmuje także ukryte slajdy. Wywołaj `dispose` w bloku `finally`, jak pokazano, aby zasoby .NET powiązane z prezentacją zostały zwolnione, nawet jeśli kod zakończy się błędem.

## **Otwórz prezentację z bufora**

Gdy prezentacja pochodzi z bazy danych, przesyłki HTTP lub innego źródła, które dostarcza bajty zamiast ścieżki pliku, przekaż obiekt Node.js `Buffer` jako drugi argument konstruktora i `null` jako pierwszy. Poniższy przykład wczytuje `sample.pptx` do bufora, aby zasymulować takie źródło:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skrypt wypisuje tę samą liczbę slajdów co poprzedni przykład. Drugi argument musi być typu `Buffer`. Dla innego typu, takiego jak `Uint8Array`, konstruktor nie zgłasza błędu; tworzy nową prezentację z jednym pustym slajdem. Najpierw skonwertuj inne typy binarne przy użyciu `Buffer.from`.

## **Zapisz prezentację w innym formacie**

Aby przekonwertować prezentację na inny format, otwórz ją i zapisz z inną wartością [SaveFormat](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveformat/). Poniższy przykład wypisuje format wykryty przez Aspose.Slides, zwracany przez właściwość [sourceFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/sourceformat/), i zapisuje prezentację jako dokument OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Skrypt wypisuje `Source format: Pptx` i tworzy plik `sample.odp`, który zawiera te same slajdy. `sourceFormat` zwraca `Ppt`, `Pptx` lub `Odp`. Aby zapisać jako PDF lub obrazy, zobacz [Convert PowerPoint to PDF](/slides/pl/nodejs-net/convert-powerpoint-to-pdf/) oraz [Convert Slides to Images](/slides/pl/nodejs-net/convert-slide/).

## **FAQ**

**Jak otworzyć prezentację zabezpieczoną hasłem?**

Utwórz obiekt [LoadOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/), ustaw jego właściwość [password](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/password/) i przekaż obiekt jako trzeci argument konstruktora: `new Presentation("protected.pptx", null, loadOptions)`. Bez poprawnego hasła konstruktor zgłasza błąd.

**Dlaczego konstruktor zgłasza `Error` z pustą wiadomością?**

Kiedy konstruktor `Presentation` nie powiedzie się w .NET, np. z powodu brakującego pliku, niewłaściwego formatu lub nieprawidłowego hasła, JavaScript otrzymuje `Error` bez komunikatu. Przed otwarciem pliku sprawdź, czy istnieje względem katalogu roboczego, np. przy użyciu `fs.existsSync`.

**Jakie formaty mogę otworzyć?**

Formaty prezentacji PowerPoint i OpenDocument, w tym PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP oraz FODP.