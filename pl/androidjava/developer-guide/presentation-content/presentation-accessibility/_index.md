---
title: Zarządzanie dostępnością prezentacji na Androidzie
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/androidjava/presentation-accessibility/
keywords:
- dostępność prezentacji
- tekst alternatywny
- tytuł tekstu alternatywnego
- opis tekstu alternatywnego
- oznacz jako dekoracyjny
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for Android via Java pomaga automatyzować kontrole dostępności prezentacji w plikach PPT, PPTX i ODP — usprawnia doświadczenie czytników ekranu i zwiększa zgodność."
---
## **Wprowadzenie**

Tekst alternatywny pomaga osobom korzystającym z technologii asystujących zrozumieć znaczenie obrazów, wykresów i innych informacyjnych kształtów. Ten artykuł wyjaśnia, jak odczytywać i aktualizować tytuły oraz opisy tekstu alternatywnego w Aspose.Slides for Android via Java, odróżniać opisy dostępności od nazw kształtów używanych w kodzie oraz sprawdzać, czy kształt jest oznaczony jako dekoracyjny.

Te funkcje wspierają dostępność prezentacji, ale nie gwarantują jej. Należy również przeanalizować kolejność odczytu, kontrast kolorów, czytelność tekstu i inne wymagania dostępności.

## **Zarządzanie tytułami i opisami tekstu alternatywnego**

Używaj tekstu alternatywnego, aby wyjaśnić znaczenie obrazów, wykresów i innych informacyjnych kształtów osobom, które nie mogą ich zobaczyć. Poniższe metody i zawartość służą różnym celom:

| Metoda lub zawartość | Cel |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Krótki tytuł dla alternatywnego opisu. |
| [getAlternativeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Znaczący opis zawartości kształtu lub jego przeznaczenia w kontekście slajdu. |
| [getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) | Nazwa kształtu, której kod może używać do odnalezienia konkretnego kształtu w prezentacji. |
| Visible text | Zawartość wyświetlana na slajdzie, np. tekst kształtu lub tytuł i etykiety wykresu. Aktualizacja tekstu alternatywnego nie zmienia tej zawartości. |

Gdy prezentacja jest używana jako szablon, kod może znaleźć kształt po nazwie zwróconej przez [getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) przed jego aktualizacją. Ta nazwa służy innemu celowi niż tekst alternatywny, który wyjaśnia, co wizualnie przekazuje odbiorcy. Wyszukiwanie po nazwie pozwala autorom ulepszać lub tłumaczyć opisy bez zmiany sposobu, w jaki kod znajduje kształt. Nazwy można edytować i nie są gwarantowane jako unikalne, więc należy sprawdzić, czy nazwa odpowiada zamierzonemu kształtowi; zobacz [Identify and Find Shapes](/slides/pl/androidjava/shape-manipulations/#identify-and-find-shapes).

Poniższy przykład wymaga pliku `input.pptx` z obrazem wejścia biurowego jako pierwszego kształtu na pierwszym slajdzie. Obraz nie powinien być oznaczony jako dekoracyjny. Przykład odczytuje i wypisuje bieżący tytuł oraz opis tekstu alternatywnego, aktualizuje oba wartości i zapisuje prezentację jako `output.pptx`. Dostosuj sformułowanie do rzeczywistego obrazu i przekazywanych informacji.

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

Dodanie samego tekstu alternatywnego nie gwarantuje dostępności prezentacji ani zgodności ze standardami dostępności. Należy sprawdzić opisy pod kątem dokładności i trafności, a także zweryfikować kolejność odczytu, kontrast kolorów, czytelność tekstu i inne wymagania dostępności. Informacyjne elementy wizualne nie powinny być oznaczane jako dekoracyjne; w następnym rozdziale pokazano, jak sprawdzić [isDecorative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Oznacz jako dekoracyjny**

Flaga oznaczająca dekoracyjność służy do wyłączania z czytników ekranu czysto ozdobnych elementów wizualnych, co zmniejsza szumy i skupia uwagę na istotnej treści. Stosuj ją do teł, ozdobników i elementów odstępu — nigdy do wykresów, ikon ani obrazów, które przekazują informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności oraz czyszczenie.

![Oznacz jako dekoracyjny](mark_as_decorative.png)

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

**Co powinienem umieścić w tytule i opisie tekstu alternatywnego?**

Użyj krótkiego tytułu identyfikującego temat oraz opisu wyjaśniającego informacje, które wizualny element przekazuje w kontekście slajdu. Dla wykresu opisuj istotny trend lub porównanie, a nie tylko „wykres”.

**Czy powinienem używać tekstu alternatywnego do lokalizowania kształtów w szablonie?**

Lepszym rozwiązaniem jest znajdowanie kształtu po nazwie zwróconej przez [getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) i sprawdzenie, czy jest to oczekiwany kształt. Tekst alternatywny może być edytowany lub tłumaczony, co może przerwać kod wyszukujący dokładny opis; zobacz [Identify and Find Shapes](/slides/pl/androidjava/shape-manipulations/).

**Kiedy kształt powinien być oznaczony jako dekoracyjny?**

Używaj flagi dekoracyjnej dla elementów wizualnych, które nie dodają żadnych informacji, np. ozdobnych ornamentów. Obrazy i wykresy, które przekazują znaczenie, wymagają odpowiedniego opisu zamiast flagi dekoracyjnej.

**Czy dodanie tekstu alternatywnego sprawia, że prezentacja jest w pełni dostępna?**

Nie. Tekst alternatywny rozwiązuje tylko część problemów dostępności. Należy również przejrzeć kolejność odczytu, kontrast kolorów, czytelność tekstu i inne obowiązujące wymagania; samo ustawienie tych właściwości nie zapewnia zgodności.