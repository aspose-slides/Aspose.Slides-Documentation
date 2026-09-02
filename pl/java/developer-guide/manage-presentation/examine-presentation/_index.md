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
- modyfikowanie właściwości
- aktualizacja właściwości
- analiza PPTX
- analiza PPT
- analiza ODP
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: Poznaj slajdy, strukturę i metadane w prezentacjach PowerPoint i OpenDocument przy użyciu Javy, aby szybciej uzyskać wgląd i lepiej kontrolować zawartość.
---
## **Przegląd**

Ten artykuł pokazuje, jak przeglądać informacje o prezentacji w Aspose.Slides. Wyjaśnia, jak określić bieżący format prezentacji bez wczytywania całego pliku, odczytać jej właściwości dokumentu oraz zaktualizować te właściwości w razie potrzeby.

Przykłady opierają się na interfejsach API [PresentationInfo](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationinfo/) i [DocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/) i demonstrują typowe operacje związane z metadanymi prezentacji.

## **Sprawdź format prezentacji**

Przed rozpoczęciem pracy z prezentacją możesz chcieć dowiedzieć się, w jakim formacie (PPT, PPTX, ODP i inne) znajduje się ona w danym momencie.

Możesz sprawdzić format prezentacji bez wczytywania jej. Zobacz ten kod Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Pobierz właściwości prezentacji**

Ten kod Java pokazuje, jak uzyskać właściwości prezentacji (informacje o prezentacji):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Możesz chcieć zobaczyć [właściwości w klasie DocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Zaktualizuj właściwości prezentacji**

Aspose.Slides udostępnia metodę [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), która umożliwia wprowadzanie zmian w właściwościach prezentacji.

Załóżmy, że mamy prezentację PowerPoint z poniższymi właściwościami dokumentu.

![Oryginalne właściwości dokumentu prezentacji PowerPoint](input_properties.png)

Ten przykład kodu pokazuje, jak edytować niektóre właściwości prezentacji:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Wyniki zmiany właściwości dokumentu przedstawiono poniżej.

![Zmienione właściwości dokumentu prezentacji PowerPoint](output_properties.png)

## **Przydatne linki**

Aby uzyskać więcej informacji o prezentacji i jej atrybutach zabezpieczeń, przydatne mogą być następujące linki:

- [Zabezpiecz prezentacje hasłem](/slides/pl/java/password-protected-presentation/)
- [Zabezpiecz prezentacje przed zapisem](/slides/pl/java/write-protected-presentation/)

## **FAQ**

**Jak mogę sprawdzić, czy czcionki są osadzone i które to są?**  
Sprawdź [informacje o osadzonych czcionkach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) na poziomie prezentacji, a następnie porównaj te wpisy z zestawem [czcionek rzeczywiście użytych w treści](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getFonts--) aby zidentyfikować, które czcionki są krytyczne dla renderowania.

**Jak szybko określić, czy plik zawiera ukryte slajdy i ile ich jest?**  
Iteruj po [kolekcji slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/) i sprawdź flagę [widoczności](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#getHidden--) każdego slajdu.

**Czy mogę wykryć, czy użyto niestandardowego rozmiaru i orientacji slajdu oraz czy różnią się one od domyślnych?**  
Tak. Porównaj bieżący [rozmiar slajdu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlideSize--) i orientację ze standardowymi presetami; pomaga to przewidzieć zachowanie przy drukowaniu i eksporcie.

**Czy istnieje szybki sposób, aby sprawdzić, czy wykresy odwołują się do zewnętrznych źródeł danych?**  
Tak. Przejdź przez wszystkie [wykresy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/), sprawdź ich [źródło danych](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chartdata/#getDataSourceType--) i zanotuj, czy dane są wewnętrzne czy oparte na linkach, w tym wszelkie uszkodzone linki.

**Jak ocenić „ciężkie” slajdy, które mogą spowalniać renderowanie lub eksport do PDF?**  
Dla każdego slajdu zlicz liczbę obiektów i poszukaj dużych obrazów, przezroczystości, cieni, animacji i multimediów; przypisz przybliżoną ocenę złożoności, aby oznaczyć potencjalne wąskie gardła wydajności.