---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w Javie
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/java/text-fields/
keywords:
- pole tekstowe
- automatyczny tekst
- numer slajdu
- data i godzina
- nagłówek
- stopka
- fragment tekstu
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Twórz, przeglądaj, modyfikuj i usuwaj pola tekstowe w prezentacjach PowerPoint za pomocą Aspose.Slides dla Javy. Zachowaj formatowanie i zweryfikuj zapisane pliki PPTX i PPT."
---
## **Overview**

Akapit tekstowy składa się z fragmentów. Zwykły [IPortion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/) zawiera dosłowny tekst; fragment pola posiada również [IField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifield/), którego typ identyfikuje automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, podczas gdy tylko jeden zawiera pole.

Użyj [IPortion.getField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#getField--) aby je odróżnić: zwraca `null` dla zwykłego tekstu. [IPortion.addField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) konwertuje istniejący fragment na pole. Przechowuj etykietę i jej dynamiczną wartość w osobnych fragmentach, aby konwersja wartości nie zastąpiła również etykiety.

Ten przewodnik omawia pola w tekście, ich formatowanie oraz zapisywanie w formatach PPTX i PPT. Informacje o ramkach tekstowych i akapitach znajdziesz w sekcji [Manage Text](/slides/pl/java/manage-text/).

## **Create a Slide Number Field**

Poniższy kompletny przykład tworzy pole tekstowe zawierające dosłowną etykietę `Slide ` oraz automatycznie aktualizowany numer. Ustawia rozmiar, grubość i kolor numeru przed dodaniem pola, a następnie otwiera ponownie zapisaną prezentację i sprawdza typ pola, tekst oraz formatowanie. Plik wejściowy nie jest wymagany.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

Nowa prezentacja zaczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia zwracają `true`. Numer pozostaje polem po ponownym otwarciu; nie jest dosłownym `1`. Rzutowania i indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifieldtype/) i udostępnia następujące metody służące do uzyskania predefiniowanych wartości. Przekaż odpowiednią wartość do [addField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metoda | Zastosowanie |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Obecny numer slajdu. |
| [getDateTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getDateTime--) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [getDateTime1](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getDateTime9--) | Predefiniowane formaty daty lub połączonych dat/godzin. |
| [getDateTime10](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getDateTime13--) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [getHeader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getHeader--) | Pole nagłówka; zobacz ograniczenia placeholdera i formatowania poniżej. |
| [getFooter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getFooter--) | Pole stopki. |

Na przykład, [getDateTime3](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#getDateTime3--) reprezentuje dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne łańcuchy formatu daty w Javie. Język ustawiony za pomocą [setLanguageId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Create a Field from an Internal String**

Przeciążenie metodą łańcucha w [addField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#addField-java.lang.String-) przyjmuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, która nie ma predefiniowanej wartości. Możesz również utworzyć [FieldType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) z tego identyfikatora. [IFieldType.getInternalString](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifieldtype/#getInternalString--) udostępnia ten identyfikator do inspekcji.

Ten przykład przechowuje pole specyficzne dla aplikacji `custom-report-id` z tekstem zastępczym `Report-042`. Identyfikator nie rejestruje obliczenia: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja, która rozumie ten identyfikator, musi dostarczyć jego znaczenie i aktualizować jego wartość.

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

Po tym cyklu PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie łańcucha takiego jak `yyyy-MM-dd` nazwałoby typ pola; nie skonfigurowałoby niestandardowego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Inspect, Modify, and Remove Date/Time Fields**

Zmień istniejące pole za pomocą [IField.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Sprawdź, czy pole istnieje przed dostępem do jego typu. Aby wyłączyć automatyczne aktualizacje, wywołaj [IPortion.removeField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#removeField--). Zachowuje to fragment i jego bieżący tekst, usuwając powiązanie pola. Jeśli potrzebujesz konkretnej stałej wartości, przypisz ten tekst po usunięciu pola.

Ustawienie API związane z przetwarzaniem pól daty/czasu znajdziesz w [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Poniższy przykład używa wyraźnej daty zatwierdzenia przy konwersji pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera on dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/czasu, oraz zwykłe etykiety tekstowe. Poniższy przykład przegląda kształty tekstowe najwyższego poziomu na zwykłych slajdach. Zmienia pola daty/czasu na format długiej daty i ustawia je kursywą, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Przykład rozpoznaje wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13`. Grupy, tabele, notatki, układy i mastery wymagają przeglądania własnych kontenerów tekstu i nie są objęte zakresem tego przykładu.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

Po ponownym otwarciu, `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma pola i zawiera `05 April 2030`. Oba fragmenty daty są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe są niezmienione. Weryfikacja odczytuje pierwszy fragment dwóch znanych kształtów w dostarczonym przykładzie.

## **Preserve Text Formatting**

Pracuj z istniejącym fragmentem przy dodawaniu pola, zmianie jego typu lub usuwaniu. Operacje te zachowują formatowanie tego fragmentu. Użyj [IPortion.getPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#getPortionFormat--) , aby zmienić tylko wymagane właściwości, tak jak przykłady robią to dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko w celu zaktualizowania jednego pola: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Rozróżniaj także formatowanie ustawione explicite od formatowania odziedziczonego po akapicie, układzie lub motywie. Zobacz [Text Formatting](/slides/pl/java/text-formatting/) po bardziej rozbudowane opcje formatowania.

## **Fields and Header/Footer Placeholders**

Pole jest częścią fragmentu tekstu. Placeholder to kształt z rolą prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie przekształca tego kształtu w placeholder.

Menedżery nagłówka/stopki kontrolują tekst placeholdera i jego widoczność na slajdach, układach i masterach, włączając propagację do zależnych slajdów. Pole liczby w niestandardowym polu tekstowym może być więc przydatne, nawet gdy nie używasz placeholdera numeru slajdu. Przeciwnie, zmiana widoczności placeholdera nie usuwa pola z niepowiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im placeholderów ani nie dostarczają ich treści. W szczególności zwykły slajd PowerPoint nie ma placeholdera nagłówka; nagłówki należą do stron notatek i materiałów rozdawniczych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie uzyska tekst skonfigurowany przez menedżera placeholderów. Dla takiego scenariusza zobacz [Presentation Headers and Footers](/slides/pl/java/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Sprawdź zarówno typ pola, jak i wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól obok tekstu pola. W testach cyklu zapis‑odczyt, predefiniowane typy oraz użyty powyżej niestandardowy identyfikator przetrwały zapis i ponowne otwarcie. Nieznany typ niestandardowy zachował swój tekst zastępczy; nie uzyskał logiki automatycznego obliczania. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma ograniczoną kompatybilność. W testach cyklu zapis‑odczyt, pola numeru slajdu oraz predefiniowane pola daty/czasu przetrwały zapis i ponowne otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otworzyło się z identyfikatorem, ale z tekstem `*`; pole nagłówka w tym samym kontekście również zwróciło `*`. Nie polegaj na tym, że pola niestandardowe lub nieobsługiwane konteksty pól zachowają swój widoczny tekst. |

Aby uzyskać przenośny, stały wynik, skonwertuj nieobsługiwane pola na zwykły tekst i jawnie przypisz pożądaną wartość przed zapisaniem. Zachowuje to wybrany tekst, ale celowo wyłącza automatyczne aktualizacje. Przetestuj również docelową aplikację, gdy jej własne przeliczenie pól jest częścią Twojego przepływu pracy.

## **FAQ**

**How can I tell whether a displayed number or date is a field?**  
Sprawdź [IPortion.getField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#getField--). Nie‑nullowa wartość identyfikuje pole; sam wyświetlany tekst nie pozwala tego określić.

**Does removing a field remove its text or formatting?**  
Nie. [removeField](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportion/#removeField--) konwertuje istniejący fragment na zwykły tekst. Przypisz jawnie wartość później, jeśli potrzebujesz określonej zamrożonej daty lub tekstu zastępczego.

**Can an internal string define a new date format or formula?**  
Nie. Identyfikuje on typ pola. Nieznany identyfikator nie dostarcza evalutora ani wzorca formatu daty w Javie. Użyj obsługiwanego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Why check a presentation again after saving it?**  
Identyfikatory pól, obliczony tekst i formatowanie to odrębne elementy do weryfikacji. Konwersja formatu może zmienić widoczny wynik, nawet jeśli identyfikator pola nadal jest obecny.