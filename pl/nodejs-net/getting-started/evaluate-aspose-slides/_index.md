---
title: Testowanie Aspose.Slides
type: docs
weight: 120
url: /pl/nodejs-net/evaluate-aspose-slides/
keywords:
- testowanie Aspose.Slides
- wersja ewaluacyjna
- znak wodny wersji ewaluacyjnej
- ograniczenia wersji próbnej
- licencja tymczasowa
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Co ogranicza wersja ewaluacyjna Aspose.Slides for Node.js via .NET, z przykładowym skryptem pokazującym oba ograniczenia i sposób ich usunięcia przy użyciu licencji."
---
## **Przegląd**

Wersja ewaluacyjna Aspose.Slides for Node.js via .NET jest tym samym pakietem npm co wersja licencjonowana. Bez licencji działa w trybie ewaluacyjnym: wszystkie funkcje działają, ale zapisane prezentacje i większość eksportów zawierają znak wodny, a tekst, który Twój kod odczytuje, jest obcinany. Ten artykuł opisuje oba ograniczenia i pokazuje, jak je usunąć.

## **Ograniczenia ewaluacyjne**

**Znak wodny ewaluacji na każdym slajdzie.** Gdy zapisujesz prezentację bez licencji, Aspose.Slides dodaje pole tekstowe w środku każdego slajdu zapisanego pliku. Pole tekstowe jest zablokowane i zawiera tekst „Evaluation only.” wraz z linią produktu i liną praw autorskich. Znak wodny trafia do zapisanego pliku, a nie do prezentacji w pamięci, i otwarcie prezentacji nie dodaje go. Plik, który został zapisany w trybie ewaluacyjnym, już zawiera to pole tekstowe, więc otwarcie i ponowne zapisanie go dodaje drugi znak wodny do każdego slajdu.

Ten sam znak wodny jest rysowany w wyniku eksportu do PDF, XPS lub HTML oraz przy renderowaniu slajdów jako obrazy. Jeśli renderujesz prezentację, która już została zapisana w trybie ewaluacyjnym, obraz pokazuje zarówno zapisany znak wodny, jak i renderowany.

**Obcinany tekst, gdy Twój kod go odczytuje.** Tekst odczytywany przez Twój kod za pomocą właściwości `text` ramki tekstowej, akapitu lub części jest obcinany do pierwszych pięciu znaków, po których następuje komunikat „... text has been truncated due to evaluation version limitation.” Tekst składający się z pięciu znaków lub mniej jest zwracany w całości. Dotyczy to każdego slajdu, a także tekstu, który Twój kod właśnie przypisał. Eksporty Markdown i HTML5 są obcinane w ten sam sposób.

Tekst, który Twój kod zapisuje, jest zachowywany w całości: pliki PPTX, strony PDF i obrazy slajdów zawierają pełny tekst.

## **Zobacz ograniczenia w skrypcie**

Poniższy skrypt pokazuje oba ograniczenia. Zakłada, że zainstalowałeś pakiet zgodnie z opisem w [Instalacja](/slides/pl/nodejs-net/installation/) i uruchamiasz go z katalogu projektu. Dodaje prostokąt z zdaniem do pierwszego slajdu, odczytuje zdanie, zapisuje prezentację jako `evaluation.pptx`, a następnie ponownie otwiera plik, aby policzyć kształty na slajdzie.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Bez licencji zwracane są tylko pierwsze pięć znaków.
    console.log("Text read back:", rectangle.textFrame.text);

    // Zapisywanie dodaje znak wodny wersji ewaluacyjnej do każdego slajdu w pliku.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // Slajd teraz zawiera prostokąt i pole tekstowe znaku wodnego.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Bez licencji skrypt wypisuje:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

Drugi kształt to pole tekstowe znaku wodnego. Otwórz `evaluation.pptx`, aby zobaczyć pełne zdanie w prostokącie i znak wodny w środku slajdu.

## **Usunięcie ograniczeń**

Aby usunąć oba ograniczenia, zastosuj licencję przed utworzeniem jakiegokolwiek obiektu `Presentation`. [Licencjonowanie](/slides/pl/nodejs-net/licensing/) pokazuje, jak zastosować plik licencji.

{{% alert color="success" title="Wskazówka" %}}

Aby przetestować Aspose.Slides bez ograniczeń ewaluacyjnych przed zakupem, poproś o darmową **30‑dniową licencję tymczasową**. Zobacz [How to get a Temporary License?](https://purchase.aspose.com/temporary-license), aby uzyskać szczegóły.

{{% /alert %}}

## **FAQ**

**Czy tryb ewaluacji ogranicza liczbę slajdów?**

Nie. Prezentacje są tworzone, otwierane i zapisywane ze wszystkimi swoimi slajdami. Znak wodny i obcinanie tekstu dotyczą każdego slajdu w ten sam sposób.

**Dlaczego moje wyeksportowane obrazy slajdów pokazują znak wodny podwójnie?**

Prezentacja została zapisana w trybie ewaluacyjnym przed renderowaniem, więc już zawiera pole tekstowe znaku wodnego, a renderowanie bez licencji rysuje kolejny znak na wierzchu.

**Czy mogę sprawdzić, czy mój kod generuje prawidłowy tekst w trybie ewaluacyjnym?**

Tak. Otwórz zapisany plik lub wyeksportowany PDF: zawierają pełny tekst. Tylko tekst, który Twój kod odczytuje, oraz wyjścia Markdown lub HTML5 są obcinane.