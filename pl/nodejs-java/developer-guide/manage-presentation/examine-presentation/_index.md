---
title: Pobieranie i aktualizacja informacji o prezentacji w JavaScript
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/nodejs-java/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczyt właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu JavaScript, aby szybciej uzyskać informacje i przeprowadzać bardziej inteligentne audyty treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak przeglądać informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania całego pliku, odczytać jej właściwości dokumentu i zaktualizować te właściwości w razie potrzeby.

Przykłady opierają się na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/) oraz demonstrują typowe operacje pracy z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Przed rozpoczęciem pracy z prezentacją możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się obecnie plik.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Pobierz właściwości prezentacji**

Ten kod JavaScript pokazuje, jak pobrać właściwości prezentacji (informacje o prezentacji):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Zaktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), która umożliwia wprowadzanie zmian w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu pokazanymi poniżej.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu przedstawiono poniżej.

![Zmodyfikowane właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, mogą Ci się przydać następujące linki:

- [Prezentacje zabezpieczone hasłem](/slides/pl/nodejs-java/password-protected-presentation/)
- [Prezentacje zabezpieczone przed zapisem](/slides/pl/nodejs-java/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj [informacji o osadzonych czcionkach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek faktycznie używanych w treści](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/), aby zidentyfikować, które czcionki są krytyczne dla renderowania.

**Jak szybko stwierdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/) i sprawdzaj [flagi widoczności](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/gethidden/) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru i orientacji slajdu oraz czy różnią się od wartości domyślnych?**

Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslidesize/) i orientację ze standardowymi ustawieniami; pomoże to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) i zanotuj, czy dane są wewnętrzne, czy odwołują się do linków, włączając ewentualne uszkodzone odnośniki.

**Jak ocenić „ciężkie” slajdy, które mogą spowolnić renderowanie lub eksport do PDF?**

Dla każdego slajdu podlicz liczbę obiektów i wyszukaj duże obrazy, przejrzystość, cienie, animacje oraz multimedia; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.