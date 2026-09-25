---
title: Zarządzanie dostępnością prezentacji w Javie
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/java/presentation-accessibility/
keywords:
- dostępność prezentacji
- tekst alternatywny
- tytuł tekstu alternatywnego
- opis tekstu alternatywnego
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for Java pomaga automatyzować sprawdzanie dostępności prezentacji w plikach PPT, PPTX i ODP — zwiększ doświadczenie czytników ekranu i popraw zgodność."
---
## **Wprowadzenie**

Tekst alternatywny pomaga osobom korzystającym z technologii wspomagających zrozumieć znaczenie obrazów, wykresów i innych informacyjnych kształtów. Ten artykuł wyjaśnia, jak odczytywać i aktualizować tytuły oraz opisy tekstu alternatywnego w Aspose.Slides for Java, jak odróżnić opisy dostępności od nazw kształtów używanych w kodzie oraz jak sprawdzić, czy kształt jest oznaczony jako dekoracyjny.

Te funkcje wspierają dostępność prezentacji, ale nie gwarantują jej. Należy również przejrzeć kolejność czytania, kontrast kolorów, czytelność tekstu oraz inne wymagania dostępności.

## **Zarządzanie tytułami i opisami tekstu alternatywnego**

Używaj tekstu alternatywnego, aby wyjaśnić znaczenie obrazów, wykresów i innych informacyjnych kształtów osobom, które ich nie widzą. Poniższe metody i zawartość służą różnym celom:

| Metoda lub zawartość | Cel |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Krótki tytuł dla alternatywnego opisu. |
| [getAlternativeText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getAlternativeText--) | Znaczący opis zawartości lub przeznaczenia kształtu w kontekście slajdu. |
| [getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getName--) | Nazwa kształtu, którą kod może używać do znalezienia konkretnego kształtu w prezentacji. |
| Widoczny tekst | Treść wyświetlana na slajdzie, np. tekst kształtu lub tytuł i etykiety wykresu. Aktualizacja tekstu alternatywnego nie zmienia tej treści. |

Gdy prezentacja jest używana jako szablon, kod może znaleźć kształt po nazwie zwróconej przez [getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getName--) przed jego aktualizacją. Nazwa służy innemu celowi niż tekst alternatywny, który wyjaśnia, co wizualnie przekazuje odbiorcy. Wyszukiwanie po nazwie pozwala autorom ulepszać lub tłumaczyć opisy bez zmiany sposobu, w jaki kod znajduje kształt. Nazwy można edytować i nie są gwarantowane jako unikalne, więc sprawdź, czy nazwa odpowiada zamierzonemu kształtowi; zobacz [Identify and Find Shapes](/slides/pl/java/shape-manipulations/#identify-and-find-shapes).

Poniższy przykład wymaga pliku `input.pptx` z obrazem wejścia biurowego jako pierwszym kształtem na pierwszym slajdzie. Obraz nie powinien być oznaczony jako dekoracyjny. Przykład odczytuje i wypisuje bieżący tytuł oraz opis tekstu alternatywnego, aktualizuje oba pola i zapisuje prezentację jako `output.pptx`. Dostosuj sformułowania do rzeczywistego obrazu i przekazywanych przez niego informacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dodanie samego tekstu alternatywnego nie gwarantuje dostępności prezentacji ani zgodności ze standardami dostępności. Przejrzyj opisy pod kątem dokładności i istotności, a także sprawdź kolejność czytania, kontrast kolorów, czytelny tekst i inne wymagania dostępności. Informacyjne elementy wizualne nie powinny być oznaczane jako dekoracyjne; w następnym rozdziale pokazano, jak sprawdzić [isDecorative](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#isDecorative--).

## **Oznacz jako dekoracyjne**

Flaga oznaczająca jako dekoracyjne służy wyłącznie ozdobnym elementom wizualnym, aby czytniki ekranu je pomijały, zmniejszając szum i koncentrując się na istotnej treści. Stosuj ją do tła, ozdobnych elementów i odstępów – nigdy do wykresów, ikon ani obrazów przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając zautomatyzowane kontrole dostępności oraz czyszczenie.

![Oznacz jako dekoracyjne](mark_as_decorative.png)

Poniższy fragment kodu pokazuje, jak określić, czy kształt jest oznaczony jako dekoracyjny.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Co powinno znajdować się w tytule i opisie tekstu alternatywnego?**

Użyj krótkiego tytułu, aby zidentyfikować temat, oraz opisu, aby wyjaśnić informacje, które wizualny element przekazuje w kontekście slajdu. Dla wykresu opisz istotny trend lub porównanie, zamiast jedynie pisać „wykres”.

**Czy powinienem używać tekstu alternatywnego do znajdowania kształtów w szablonie?**

Preferuj znajdowanie kształtu po nazwie zwróconej przez [getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getName--) i sprawdzaj, czy jest to oczekiwany kształt. Tekst alternatywny może być edytowany lub tłumaczony, co może przerwać kod wyszukujący dokładny opis; zobacz [Identify and Find Shapes](/slides/pl/java/shape-manipulations/).

**Kiedy kształt powinien być oznaczony jako dekoracyjny?**

Użyj flagi dekoracyjnej dla elementów wizualnych, które nie niosą informacji, takich jak ozdobne wzory. Obrazy i wykresy, które przekazują znaczenie, wymagają odpowiedniego opisu zamiast oznaczenia ich jako dekoracyjne.

**Czy dodanie tekstu alternatywnego sprawia, że prezentacja jest w pełni dostępna?**

Nie. Tekst alternatywny rozwiązuje tylko część zagadnień dostępności. Należy także przejrzeć kolejność czytania, kontrast kolorów, czytelność tekstu i inne obowiązujące wymagania; samo ustawienie tych właściwości nie zapewnia zgodności.