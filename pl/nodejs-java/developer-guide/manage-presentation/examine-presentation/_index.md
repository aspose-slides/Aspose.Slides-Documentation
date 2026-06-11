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
- badanie PPTX
- badanie PPT
- badanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu JavaScript, aby uzyskać szybsze wnioski i bardziej inteligentne audyty treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak przeglądać informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania całego pliku, odczytać jej właściwości dokumentu i w razie potrzeby zaktualizować te właściwości.

Przykłady oparte są na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/) i demonstrują typowe operacje pracy z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Przed pracą z prezentacją możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i innych) znajduje się prezentacja w danej chwili.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod JavaScript:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Uzyskaj właściwości prezentacji**

Ten kod JavaScript pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Zaktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), która pozwala wprowadzać zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu przedstawionymi poniżej.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu przedstawiono poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, mogą przydać się następujące linki:

- [Sprawdzanie, czy prezentacja jest zaszyfrowana](https://docs.aspose.com/slides/pl/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sprawdzanie, czy prezentacja jest chroniona przed zapisem (tylko do odczytu)](https://docs.aspose.com/slides/pl/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sprawdzanie, czy prezentacja jest chroniona hasłem przed jej załadowaniem](https://docs.aspose.com/slides/pl/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potwierdzanie hasła użytego do ochrony prezentacji](https://docs.aspose.com/slides/pl/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj [informacji o osadzonych czcionkach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek faktycznie używanych w treści](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/), aby zidentyfikować, które czcionki są krytyczne dla renderowania.

**Jak szybko stwierdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj po [kolekcji slajdów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/) i sprawdź flagę [widoczności](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/gethidden/) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od ustawień domyślnych?**

Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getslidesize/) i orientację ze standardowymi ustawieniami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), i zauważ, czy dane są wewnętrzne czy oparte na odnośnikach, włączając ewentualne uszkodzone linki.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu policz liczbę obiektów i poszukaj dużych obrazów, przezroczystości, cieni, animacji oraz multimediów; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.