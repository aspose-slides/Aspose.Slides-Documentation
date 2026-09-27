---
title: Licencjonowanie
description: "Zastosuj plik licencji do Aspose.Slides for Node.js via .NET, zobacz jakie są ograniczenia wersji ewaluacyjnej i uzyskaj darmową 30-dniową licencję tymczasową do testów."
type: docs
weight: 80
url: /pl/nodejs-net/licensing/
---
## **Przegląd**

Aspose.Slides for Node.js via .NET jest jednym pakietem npm przeznaczonym zarówno do oceny, jak i produkcji. Bez licencji działa w trybie ewaluacyjnym. Po zakupie licencji lub uzyskaniu darmowej 30‑dniowej licencji tymczasowej, stosujesz ją kilkoma liniami kodu i ograniczenia ewaluacyjne przestają obowiązywać.

{{% alert color="info" title="Note" %}}

Ogólne zasady dotyczące oceny, licencjonowania i zakupu produktów Aspose są zebrane w [Polityki zakupu i FAQ](https://purchase.aspose.com/policies). Ceny są podane na stronie [Informacje o cenach](https://purchase.aspose.com/pricing/slides/pl/family).

{{% /alert %}}

## **Ograniczenia wersji ewaluacyjnej**

Wersja ewaluacyjna zapewnia pełną funkcjonalność produktu, z dwoma ograniczeniami:

- **Znak wodny.** Każdy slajd każdej prezentacji, którą zapisujesz, otrzymuje znak wodny ewaluacyjny: zablokowane pole tekstowe w środku slajdu z napisem "Evaluation only." Ten sam znak wodny jest nakładany na eksporty PDF, XPS i HTML oraz na obrazy slajdów.
- **Przycięty tekst.** Tekst, który Twój kod odczytuje z ramki tekstowej, akapitu lub części, jest przycinany do pierwszych pięciu znaków, po których następuje informacja "... text has been truncated due to evaluation version limitation." Eksporty Markdown i HTML5 są przycinane w ten sam sposób. Tekst, który Twój kod zapisuje, jest zachowywany w całości.

[Ocena Aspose.Slides](/slides/pl/nodejs-net/evaluate-aspose-slides/) opisuje oba ograniczenia szczegółowo i zawiera skrypt, który je pokazuje.

{{% alert color="success" title="Tip" %}}

Aby przetestować Aspose.Slides bez ograniczeń ewaluacyjnych, zażądaj darmowej **30-dniowej licencji tymczasowej**. Zobacz [Jak uzyskać licencję tymczasową?](https://purchase.aspose.com/temporary-license) po szczegóły.

{{% /alert %}}

## **O licencji**

Licencja jest zwykłym plikiem XML, który zawiera szczegóły takie jak nazwa produktu, liczba programistów, dla których jest licencjonowana, oraz data wygaśnięcia subskrypcji. Plik jest cyfrowo podpisany, więc nie należy go modyfikować: nawet dodatkowy znak końca linii dodany przez pomyłkę unieważnia go.

## **Zastosowanie licencji**

Zastosuj licencję przy użyciu metody `setLicense` klasy `License`. Wywołaj ją raz na proces, przed utworzeniem jakiegokolwiek obiektu `Presentation`. Ponowne wywołanie nie szkodzi, ale powiela już wykonaną pracę.

Poniższy skrypt stosuje licencję z pliku o nazwie `Aspose.Slides.lic`. Zamień nazwę na nazwę lub pełną ścieżkę do swojego pliku licencji; plik może mieć dowolną nazwę.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Nazwa pliku lub ścieżka względna jest rozwiązywana względem bieżącego folderu, z którego uruchamiasz `node`. Przechowuj plik licencji w folderze projektu i uruchamiaj skrypty z tego miejsca lub podaj pełną ścieżkę.

Jeśli pliku nie można odnaleźć lub nie jest on prawidłową licencją, `setLicense` zgłasza błąd i Aspose.Slides pozostaje w trybie ewaluacyjnym. Skrypt przechwytuje błąd i wypisuje jego komunikat. Dla brakującego pliku komunikat zaczyna się od `License "Aspose.Slides.lic" doesn't exist or access is restricted.` i wymienia wszystkie lokalizacje, które zostały przeszukane.

W tym pakiecie licencja jest stosowana wyłącznie z pliku. `License` nie akceptuje strumienia, a pakiet nie udostępnia licencjonowania metrowego. Dla klasy, którą pakiet opakowuje, zobacz [License](https://reference.aspose.com/slides/pl/net/aspose.slides/license/) w dokumentacji API Aspose.Slides for .NET.