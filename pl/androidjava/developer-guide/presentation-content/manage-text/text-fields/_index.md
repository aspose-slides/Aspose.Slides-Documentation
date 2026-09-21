---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint na Androidzie
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/androidjava/text-fields/
keywords:
- pole tekstowe
- tekst automatyczny
- numer slajdu
- data i godzina
- nagłówek
- stopka
- część tekstu
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Tworzenie, przeglądanie, modyfikowanie i usuwanie pól tekstowych w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w języku Java. Zachowaj formatowanie i weryfikuj zapisane pliki PPTX i PPT."
---
## **Przegląd**

Akapit tekstowy składa się z części. Zwykły [IPortion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/) zawiera dosłowny tekst; część pola posiada także [IField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifield/), którego typ określa automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwie części mogą wyświetlać te same znaki, ale tylko jedna zawiera pole.

Użyj [IPortion.getField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getField--) aby je odróżnić: zwraca `null` dla zwykłego tekstu. [IPortion.addField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) konwertuje istniejącą część na pole. Przechowuj etykietę i jej dynamiczną wartość w osobnych częściach, aby konwersja wartości nie zastąpiła również etykiety.

Ten przewodnik opisuje pola w tekście, ich formatowanie oraz zapisywanie ich w formatach PPTX i PPT. Informacje o ramkach tekstowych i akapitach znajdziesz w [Manage Text](/slides/pl/androidjava/manage-text/).

## **Utworzenie pola numeru slajdu**

Poniższy kompletny przykład tworzy pole tekstowe zawierające dosłowną etykietę `Slide ` oraz automatycznie aktualizowany numer. Ustawia rozmiar, grubość i kolor liczby przed dodaniem pola, a następnie ponownie otwiera zapisany prezentację i sprawdza typ pola, tekst oraz formatowanie. Żaden plik wejściowy nie jest wymagany.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Nowa prezentacja rozpoczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia zwracają `true`. Numer pozostaje polem po ponownym otwarciu; nie jest to dosłowny `1`. Rzutowania i indeksy w weryfikacji odnoszą się do kształtu i części utworzonych w tym przykładzie.

## **Wybór typu pola**

[FieldType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifieldtype/) i udostępnia następujące metody do uzyskiwania predefiniowanych wartości. Przekaż odpowiednią wartość do [addField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metoda | Zastosowanie |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Aktualny numer slajdu. |
| [getDateTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [getDateTime1](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Predefiniowane formaty daty lub połączonych dat/godzin. |
| [getDateTime10](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [getHeader](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Pole nagłówka; zobacz ograniczenia dotyczące zastępczych znaków i formatów poniżej. |
| [getFooter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Pole stopki. |

Na przykład [getDateTime3](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) reprezentuje dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne ciągi formatu daty Javy. Język ustawiony za pomocą [setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Utworzenie pola z wewnętrznego ciągu znaków**

Przeciążenie ciągu znaków metody [addField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) przyjmuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, która nie posiada predefiniowanej wartości. Możesz także skonstruować [FieldType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) z tego identyfikatora. [IFieldType.getInternalString](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) udostępnia ten identyfikator do inspekcji.

Ten przykład przechowuje pole specyficzne dla aplikacji o nazwie `custom-report-id` z tekstem zapasowym `Report-042`. Identyfikator nie rejestruje obliczeń: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanych typów. Aplikacja, która rozumie ten identyfikator, musi dostarczyć jego znaczenie i zaktualizować wartość.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po tym cyklu PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie łańcucha takiego jak `yyyy-MM-dd` stworzyłoby typ pola; nie skonfigurowałoby ono niestandardowego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Inspekcja, modyfikacja i usuwanie pól daty/godziny**

Zmieniaj istniejące pole za pomocą [IField.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Sprawdź, czy pole istnieje, zanim odwołasz się do jego typu. Aby zatrzymać automatyczne aktualizacje, wywołaj [IPortion.removeField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#removeField--). Operacja zachowuje część i jej bieżący tekst, usuwając jednocześnie powiązanie pola. Jeśli potrzebujesz konkretnej stałej wartości, przypisz ten tekst po usunięciu pola.

Dla ustawień API związanych z przetwarzaniem pól daty/godziny zobacz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Poniższy przykład używa wyraźnej daty zatwierdzenia przy konwersji pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny oraz zwykłymi etykietami tekstowymi. Następny przykład przechodzi po kształtach tekstowych najwyższego poziomu na zwykłych slajdach. Zmienia pola daty/godziny na format długiej daty i ustawia je jako kursywę, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Próbka rozpoznaje wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13`. Grupy, tabele, notatki, układy i wzorce wymagają przeglądania ich własnych kontenerów tekstowych i nie są objęte zakresem tego przykładu.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po ponownym otwarciu `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma pola i zawiera `05 April 2030`. Obie części dat są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe są nienaruszone. Weryfikacja odczytuje pierwszą część dwóch znanych kształtów w dostarczonym przykładzie.

## **Zachowanie formatowania tekstu**

Pracuj na istniejącej części przy dodawaniu pola, zmianie jego typu lub usuwaniu. Te operacje zachowują formatowanie tej części. Użyj [IPortion.getPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getPortionFormat--) aby zmienić tylko wymagane właściwości, tak jak przykłady robią to dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko po to, by zaktualizować jedno pole: może to spowodować utratę oryginalnych granic części i ich indywidualnego formatowania. Rozróżniaj także formatowanie ustawione wyraźnie od formatowania dziedziczonego z akapitu, układu lub motywu. Zobacz [Text Formatting](/slides/pl/androidjava/text-formatting/) po więcej opcji formatowania.

## **Pola a zastępcze elementy nagłówka/stopki**

Pole jest częścią fragmentu tekstu. Zastępczy element (placeholder) to kształt z określoną rolą w prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie zamienia tego kształtu w zastępczy element.

Menedżery nagłówków i stopek kontrolują tekst zastępczy i jego widoczność na slajdach, układach i wzorcach, włączając propagację do slajdów zależnych. Pole numeru w niestandardowym polu tekstowym może być więc przydatne, nawet jeśli nie używasz zastępczego pola numeru slajdu. Odwrotnie, zmiana widoczności zastępczego elementu nie usuwa pola z niepowiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im zastępczych elementów ani nie dostarczają ich treści. W szczególności zwykły slajd PowerPoint nie ma zastępczego elementu nagłówka; nagłówki należą do stron notatek i wersji rozdania. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie uzyska tekst skonfigurowany poprzez menedżera zastępczych elementów. Dla takiego scenariusza zobacz [Presentation Headers and Footers](/slides/pl/androidjava/presentation-header-and-footer/).

## **Ograniczenia PPTX i PPT**

Sprawdzaj zarówno typ pola, jak i wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól wraz z tekstem pola. W testach cyklu życia predefiniowane typy i niestandardowy identyfikator użyty powyżej przetrwały zapis i otwarcie. Nieznany typ niestandardowy zachował tekst zapasowy; nie uzyskał automatycznej logiki obliczeniowej. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. W testach cyklu życia pola numeru slajdu i predefiniowane pola daty/godziny przetrwały zapis i otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otworzyło się z identyfikatorem, ale z `*` jako tekstem; pole nagłówka w tym samym kontekście także dało `*`. Nie polegaj na tym, że niestandardowe pola lub nieobsługiwane konteksty pól zachowają widoczny tekst. |

Aby uzyskać przenośny, stały wynik, konwertuj nieobsługiwane pola na zwykły tekst i jawnie przypisz pożądaną wartość przed zapisaniem. Zachowuje to wybrany tekst, ale celowo zatrzymuje automatyczne aktualizacje. Przetestuj także docelową aplikację, jeśli jej własne przeliczanie pól jest częścią Twojego przepływu pracy.

## **FAQ**

**Jak mogę sprawdzić, czy wyświetlana liczba lub data jest polem?**

Sprawdź [IPortion.getField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getField--). Nie‑nullowa wartość identyfikuje pole; sam wyświetlany tekst tego nie ujawnia.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [removeField](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#removeField--) konwertuje istniejącą część na zwykły tekst. Przypisz wyraźną wartość później, jeśli potrzebujesz zamrożonej daty lub tekstu zapasowego.

**Czy wewnętrzny ciąg może definiować nowy format daty lub formułę?**

Nie. Identifikuje typ pola. Nieznany identyfikator nie zapewnia evaluatora ani wzorca formatu daty Javy. Użyj wspieranego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego po zapisaniu prezentacji trzeba ją ponownie sprawdzić?**

Identyfikatory pól, wyliczony tekst i formatowanie to odrębne elementy do weryfikacji. Konwersja formatu może zmienić widoczny wynik, nawet gdy identyfikator pola nadal istnieje.