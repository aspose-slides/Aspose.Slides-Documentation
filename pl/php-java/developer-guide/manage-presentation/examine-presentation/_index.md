---
title: Pobieranie i aktualizacja informacji o prezentacji w PHP
linktitle: Informacje o prezentacji
type: docs
weight: 30
url: /pl/php-java/examine-presentation/
keywords:
- format prezentacji
- właściwości prezentacji
- właściwości dokumentu
- pobieranie właściwości
- odczytywanie właściwości
- zmiana właściwości
- modyfikacja właściwości
- aktualizacja właściwości
- badanie PPTX
- badanie PPT
- badanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP, aby szybciej uzyskać wgląd i prowadzić inteligentniejsze audyty treści."
---
## **Przegląd**

Ten artykuł pokazuje, jak sprawdzić informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez ładowania pełnego pliku, odczytać jej właściwości dokumentu i zaktualizować te właściwości w razie potrzeby.

Przykłady oparte są na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/) i demonstrują typowe operacje pracy z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Przed rozpoczęciem pracy z prezentacją może być konieczne ustalenie, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się prezentacja w danym momencie.

Możesz sprawdzić format prezentacji bez jej ładowania. Zobacz ten kod PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **Pobierz właściwości prezentacji**

Ten kod PHP pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/documentproperties/#DocumentProperties--) class.

## **Zaktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) która pozwala wprowadzać zmiany w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z właściwościami dokumentu pokazanymi poniżej.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Wyniki zmiany właściwości dokumentu są pokazane poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach bezpieczeństwa, przydatne mogą być następujące linki:

- [Sprawdzanie, czy prezentacja jest zaszyfrowana](https://docs.aspose.com/slides/pl/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Sprawdzanie, czy prezentacja jest zabezpieczona przed zapisem (tylko do odczytu)](https://docs.aspose.com/slides/pl/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Sprawdzanie, czy prezentacja jest chroniona hasłem przed jej załadowaniem](https://docs.aspose.com/slides/pl/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potwierdzanie hasła użytego do ochrony prezentacji](https://docs.aspose.com/slides/pl/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**

Poszukaj informacji o [osadzonych czcionkach](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek faktycznie używanych w treści](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getfonts/), aby zidentyfikować, które czcionki są kluczowe dla renderowania.

**Jak szybko sprawdzić, czy plik zawiera ukryte slajdy i ile ich jest?**

Iteruj przez [kolekcję slajdów](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/) i sprawdź flagę [widoczności](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/gethidden/) każdego slajdu.

**Czy mogę wykryć, czy używany jest niestandardowy rozmiar i orientacja slajdu oraz czy różnią się od domyślnych?**

Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getslidesize/) i orientację ze standardowymi ustawieniami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**

Tak. Przejdź wszystkie [wykresy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdata/getdatasourcetype/), i zanotuj, czy dane są wewnętrzne, czy oparte na linkach, w tym wszelkie uszkodzone odnośniki.

**Jak mogę ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**

Dla każdego slajdu zlicz liczbę obiektów i poszukaj dużych obrazów, przezroczystości, cieni, animacji oraz multimediów; przydziel przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.