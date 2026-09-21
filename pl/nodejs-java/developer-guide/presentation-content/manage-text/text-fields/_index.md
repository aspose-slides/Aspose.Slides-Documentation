---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w JavaScript
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/nodejs-java/text-fields/
keywords:
- pole tekstowe
- tekst automatyczny
- numer slajdu
- data i godzina
- nagłówek
- stopka
- fragment tekstowy
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz, przeglądaj, modyfikuj i usuwaj pola tekstowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js w Java. Zachowuj formatowanie i weryfikuj zapisane pliki PPTX i PPT."
---
## **Przegląd**

Akapit tekstowy składa się z fragmentów. Zwykły [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) zawiera dosłowny tekst; fragment pola ma także [Field](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/field/), którego typ określa automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, podczas gdy tylko jeden zawiera pole.

Użyj [Portion.getField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getField), aby je odróżnić: dla zwykłego tekstu zwraca `null`. [Portion.addField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#addField) konwertuje istniejący fragment na pole. Trzymaj etykietę i jej dynamiczną wartość w oddzielnych fragmentach, aby konwersja wartości nie zastąpiła również etykiety.

Ten przewodnik opisuje pola wewnątrz tekstu, ich formatowanie oraz zapisywanie w formatach PPTX i PPT. Informacje o ramkach tekstowych i akapitach znajdziesz w [Manage Text](/slides/pl/nodejs-java/manage-text/).

## **Utwórz pole numeru slajdu**

Przykład poniżej tworzy pole tekstowe zawierające dosłowną etykietę `Slide ` oraz automatycznie aktualizowany numer. Ustawia rozmiar, grubość i kolor liczby przed dodaniem pola, następnie otwiera zapisany plik prezentacji i sprawdza typ pola, tekst oraz formatowanie. Żadne pliki wejściowe nie są wymagane.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Nowa prezentacja zaczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia wypisują `true`. Numer pozostaje polem po ponownym otwarciu; nie jest to dosłowny `1`. Indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Wybierz typ pola**

[FieldType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/) udostępnia następujące metody uzyskiwania predefiniowanych wartości. Przekaż odpowiednią wartość do [addField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#addField).

| Metoda | Cel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Obecny numer slajdu. |
| [getDateTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [getDateTime1](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Predefiniowane formaty daty lub połączone formaty daty/godziny. |
| [getDateTime10](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [getHeader](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getHeader) | Pole nagłówka; zobacz ograniczenia dotyczące symboli zastępczych i formatów poniżej. |
| [getFooter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getFooter) | Pole stopki. |

Na przykład [getDateTime3](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getDateTime3) reprezentuje dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne ciągi formatu daty. Język ustawiony przy pomocy [setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Utwórz pole z wewnętrznego ciągu**

Przeciążenie metodą ciągu znaków w [addField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#addField) przyjmuje wewnętrzny identyfikator pola. Użyj go, aby zachować identyfikator dostarczony przez inną aplikację, nieposiadającą predefiniowanej wartości. Można również utworzyć [FieldType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/) na podstawie identyfikatora. [FieldType.getInternalString](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fieldtype/#getInternalString) udostępnia ten identyfikator do wglądu.

Przykład ten przechowuje specyficzne dla aplikacji pole `custom-report-id` z tekstem awaryjnym `Report-042`. Identyfikator nie rejestruje obliczenia: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja rozumiejąca ten identyfikator musi dostarczyć jego znaczenie i zaktualizować wartość.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po tym cyklu PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie ciągu takiego jak `yyyy-MM-dd` nazwałoby typ pola; nie skonfigurowałoby własnego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Sprawdź, zmodyfikuj i usuń pola daty/godziny**

Zmień istniejące pole za pomocą [Field.setType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/field/#setType). Sprawdź, czy pole istnieje przed dostępem do jego typu. Aby zatrzymać automatyczne aktualizacje, wywołaj [Portion.removeField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#removeField). Zachowuje to fragment i jego bieżący tekst, usuwając powiązanie z polem. Jeśli potrzebny jest określony stały wartość, przypisz ten tekst po usunięciu pola.

Dla ustawienia API związanego z przetwarzaniem pól daty/godziny zobacz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Poniższy przykład używa określonej daty zatwierdzenia przy konwersji pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny, oraz zwykłe etykiety tekstowe. Poniższy przykład przegląda kształty tekstowe najwyższego poziomu na standardowych slajdach. Zmienia pola daty/godziny na format długiej daty i ustawia je jako kursywę, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Data zatwierdzenia to 5 kwietnia 2030; indeksy miesięcy w JavaScript zaczynają się od zera, więc kwiecień to `3`. Do konstrukcji i formatowania użyto UTC, aby data była niezależna od lokalnej strefy czasowej.

Przykład rozpoznaje wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13`. Grupy, tabele, notatki, układy i szablony wymagają przejścia po własnych kontenerach tekstowych i nie są objęte zakresem tego przykładu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po ponownym otwarciu `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma pola i zawiera `05 April 2030`. Oba fragmenty dat są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe pozostają bez zmian. Weryfikacja odczytuje pierwszy fragment dwóch znanych kształtów w dostarczonym przykładzie.

## **Zachowaj formatowanie tekstu**

Pracuj na istniejącym fragmencie przy dodawaniu pola, zmianie jego typu lub usuwaniu. Operacje te zachowują formatowanie tego fragmentu. Użyj [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getPortionFormat), aby zmienić tylko wymagane właściwości, tak jak w przykładach dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko po to, aby zaktualizować jedno pole: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Rozróżniaj także formatowanie ustawione explicite od formatowania dziedziczonego z akapitu, układu lub motywu. Zobacz [Text Formatting](/slides/pl/nodejs-java/text-formatting/) po więcej opcji formatowania.

## **Pola i symbole zastępcze nagłówka/stopki**

Pole jest częścią fragmentu tekstu. Symbol zastępczy to kształt o roli w prezentacji, takiej jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie przekształca tego kształtu w symbol zastępczy.

Menadżery nagłówka/stopki kontrolują tekst i widoczność symboli zastępczych na slajdach, układach i szablonach, w tym ich propagację do zależnych slajdów. Pole liczby w niestandardowym polu tekstowym może więc być przydatne, nawet gdy nie używasz symbolu zastępczego numeru slajdu. Odwrotnie, zmiana widoczności symbolu zastępczego nie usuwa pola z niepowiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im symboli zastępczych ani nie dostarczają ich treści. W szczególności zwykły slajd PowerPoint nie ma symbolu zastępczego nagłówka; nagłówki należą do stron notatek i materiałów rozdawczych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie uzyska tekst skonfigurowany w menedżerze symboli zastępczych. Dla takiego przepływu pracy zobacz [Presentation Headers and Footers](/slides/pl/nodejs-java/presentation-header-and-footer/).

## **Ograniczenia PPTX i PPT**

Sprawdź zarówno typ pola, jak i wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól wraz z tekstem pola. W testach cyklu zapisu/odczytu, predefiniowane typy oraz użyty powyżej niestandardowy identyfikator przetrwały zapis i ponowne otwarcie. Nieznany niestandardowy typ zachował swój tekst awaryjny; nie uzyskał logiki automatycznego obliczania. Inna aplikacja może inaczej traktować nieobsługiwane identyfikatory. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. W testach cyklu zapisu/odczytu, pola numeru slajdu oraz predefiniowane pola daty/godziny przetrwały zapis i ponowne otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otworzyło się z jego identyfikatorem, ale z tekstem `*`; pole nagłówka w tym samym kontekście również wyświetliło `*`. Nie polegaj na tym, że niestandardowe pola lub nieobsługiwane konteksty pól zachowają swój widoczny tekst. |

Aby uzyskać przenośny, stały wynik, skonwertuj nieobsługiwane pola na zwykły tekst i jawnie przypisz pożądaną wartość przed zapisem. Zachowuje to wybrany tekst, ale celowo zatrzymuje automatyczne aktualizacje. Przetestuj również docelową aplikację, jeśli jej własne przeliczanie pól jest częścią twojego przepływu pracy.

## **FAQ**

**Jak mogę sprawdzić, czy wyświetlana liczba lub data jest polem?**

Sprawdź [Portion.getField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getField). Nie‑nullowa wartość identyfikuje pole; sam wyświetlony tekst nie pozwala tego określić.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [removeField](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#removeField) konwertuje istniejący fragment na zwykły tekst. Przypisz explicite wartość po usunięciu, jeśli potrzebny jest konkretny zamrożony tekst lub tekst awaryjny.

**Czy wewnętrzny ciąg może definiować nowy format daty lub formułę?**

Nie. Identyfikuje typ pola. Nieznany identyfikator nie zapewnia ewaluatora ani wzorca formatu daty. Użyj wspieranego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego sprawdzać prezentację ponownie po jej zapisaniu?**

Identyfikatory pól, obliczony tekst i formatowanie to odrębne elementy, które należy zweryfikować. Konwersja formatu może zmienić widoczny wynik, nawet gdy identyfikator pola pozostaje.