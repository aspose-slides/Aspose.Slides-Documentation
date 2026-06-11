---
title: Pobieranie i aktualizacja informacji o prezentacji w Javie
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Javy, aby uzyskać szybszy wgląd i bardziej inteligentną ocenę treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak przeglądać informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania całego pliku, odczytać jej właściwości dokumentu oraz zaktualizować te właściwości w razie potrzeby.

Przykłady opierają się na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/), oraz demonstrują typowe operacje pracy z metadanymi prezentacji.

## **Sprawdzenie formatu prezentacji**

Przed rozpoczęciem pracy z prezentacją możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się prezentacja w danym momencie.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Pobieranie właściwości prezentacji**

Ten kod Java pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#DocumentProperties--).

## **Aktualizacja właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), która pozwala wprowadzać zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z poniżej pokazanymi właściwościami dokumentu.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu są przedstawione poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, mogą okazać się przydatne następujące linki:

- [Sprawdzanie, czy prezentacja jest zaszyfrowana](https://docs.aspose.com/slides/pl/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sprawdzanie, czy prezentacja jest chroniona przed zapisem (tylko do odczytu)](https://docs.aspose.com/slides/pl/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sprawdzanie, czy prezentacja jest chroniona hasłem przed jej załadowaniem](https://docs.aspose.com/slides/pl/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potwierdzanie hasła użytego do ochrony prezentacji](https://docs.aspose.com/slides/pl/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj informacji o [osadzonych czcionkach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek faktycznie używanych w treści](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getFonts--), aby zidentyfikować, które czcionki są kluczowe dla renderowania.

**Jak szybko stwierdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/) i sprawdź flagę [widoczności](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getHidden--) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od domyślnych?**

Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlideSize--) oraz orientację ze standardowymi ustawieniami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getDataSourceType--), i zanotuj, czy dane są wewnętrzne czy oparte na odnośnikach, włączając ewentualne uszkodzone linki.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu policz liczbę obiektów i sprawdź obecność dużych obrazów, przezroczystości, cieni, animacji oraz multimediów; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.