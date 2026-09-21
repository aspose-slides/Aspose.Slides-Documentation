---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w Pythonie za pośrednictwem Java
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/python-java/text-fields/
keywords:
- pole tekstowe
- tekst automatyczny
- numer slajdu
- data i godzina
- nagłówek
- stopka
- fragment tekstu
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Twórz, przeglądaj, modyfikuj i usuwaj pola tekstowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona przez Java. Zachowuj formatowanie i weryfikuj zapisane pliki PPTX i PPT."
---
## **Przegląd**

Akapit tekstowy składa się z fragmentów. Zwykły [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) zawiera dosłowny tekst; fragment pola ma także [Field](https://reference.aspose.com/slides/pl/python-java/aspose.slides/field/) którego typ identyfikuje automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, podczas gdy tylko jeden zawiera pole.

Użyj [Portion.getField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getField), aby je odróżnić: zwraca `None` dla zwykłego tekstu. [Portion.addField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#addField) zamienia istniejący fragment w pole. Trzymaj etykietę i jej dynamiczną wartość w osobnych fragmentach, aby konwersja wartości nie zastąpiła również etykiety.

Ten przewodnik opisuje pola w tekście, ich formatowanie oraz zapisywanie ich w formatach PPTX i PPT. Dla ramek tekstowych i akapitów zobacz [Manage Text](/slides/pl/python-java/manage-text/).

## **Utwórz pole numeru slajdu**

Poniższy kompletny przykład tworzy pole tekstowe zawierające dosłowną etykietę `Slide ` oraz automatycznie aktualizowany numer. Ustawia rozmiar, wagę i kolor liczby przed dodaniem pola, a następnie ponownie otwiera zapisaną prezentację i sprawdza typ pola, tekst oraz formatowanie. Nie wymaga pliku wejściowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Nowa prezentacja zaczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia wypisują `True`. Numer pozostaje polem po ponownym otwarciu; nie jest dosłownym `1`. Indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Wybierz typ pola**

[FieldType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/) udostępnia następujące metody do uzyskiwania predefiniowanych wartości. Przekaż odpowiednią wartość do [addField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#addField).

| Metoda | Cel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getSlideNumber) | Aktualny numer slajdu. |
| [getDateTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getDateTime) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [getDateTime1](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getDateTime9) | Predefiniowane formaty daty lub połączonych dat/godzin. |
| [getDateTime10](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getDateTime13) | Predefiniowane formaty czasu, z opcjami sekund i 12‑godzinnego zegara. |
| [getHeader](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getHeader) | Pole nagłówka; zobacz ograniczenia placeholdera i formatu poniżej. |
| [getFooter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getFooter) | Pole stopki. |

Na przykład [getDateTime3](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getDateTime3) reprezentuje dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne ciągi formatu daty Pythona. Język ustawiony przy użyciu [setLanguageId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setLanguageId) oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Utwórz pole z wewnętrznego ciągu**

Przeciążenie metodą przyjmującą ciąg w [addField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#addField) akceptuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, która nie ma predefiniowanej wartości. Możesz także utworzyć [FieldType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#FieldType) z tego identyfikatora. [FieldType.getInternalString](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fieldtype/#getInternalString) udostępnia ten identyfikator do inspekcji.

Ten przykład przechowuje aplikacyjne pole `custom-report-id` z tekstem rezerwowym `Report-042`. Identyfikator nie rejestruje obliczeń: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja, która rozumie ten identyfikator, musi dostarczyć jego znaczenie i zaktualizować wartość.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Po tym obiegu PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie ciągu takiego jak `yyyy-MM-dd` nazwałoby typ pola; nie skonfigurowałoby to niestandardowego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Sprawdź, zmodyfikuj i usuń pola daty/godziny**

Zmień istniejące pole za pomocą [Field.setType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/field/#setType). Sprawdź, czy pole istnieje przed dostępem do jego typu. Aby zatrzymać automatyczne aktualizacje, wywołaj [Portion.removeField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#removeField). Dzięki temu zachowujesz fragment i jego bieżący tekst, usuwając jednocześnie powiązanie z polem. Jeśli potrzebujesz konkretnej stałej wartości, przypisz ten tekst po usunięciu pola.

Dla ustawienia API związanego z przetwarzaniem pól daty/godziny zobacz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#setCurrentDateTime). Poniższy przykład używa wyraźnej daty zatwierdzenia przy konwersji pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera on dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny, oraz zwykłe etykiety tekstowe. Poniższy przykład przechodzi po kształtach tekstowych najwyższego poziomu na zwykłych slajdach. Zmienia pola daty/godziny na format długiej daty i ustawia je na kursywę, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Próbka rozpoznaje wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13`. Grupy, tabele, notatki, układy i mastery wymagają przejścia ich własnych kontenerów tekstowych i są poza zakresem tego przykładu.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Użyj angielskich nazw miesięcy niezależnie od ustawień regionalnych systemu.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Po ponownym otwarciu `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma pola i zawiera `05 April 2030`. Oba fragmenty daty są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostały niezmienione. Zwykłe etykiety tekstowe nie uległy zmianie. Weryfikacja odczytuje pierwszy fragment z dwóch znanych kształtów w dostarczonej próbce.

## **Zachowaj formatowanie tekstu**

Pracuj z istniejącym fragmentem przy dodawaniu pola, zmianie jego typu lub usuwaniu. Operacje te zachowują formatowanie tego fragmentu. Użyj [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getPortionFormat), aby zmienić tylko wymagane właściwości, tak jak w przykładach dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko po to, by zaktualizować jedno pole: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Rozróżniaj także formatowanie ustawione explicite od formatowania odziedziczonego po akapicie, układzie lub motywie. Zobacz [Text Formatting](/slides/pl/python-java/text-formatting/) po więcej opcji formatowania.

## **Pola i placeholdery nagłówka/stopki**

Pole jest częścią fragmentu tekstowego. Placeholder to kształt z rolą w prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie przekształca tego kształtu w placeholder.

Managerzy nagłówków/stopki kontrolują tekst placeholderów i ich widoczność na slajdach, układach i masterach, włączając propagację do zależnych slajdów. Dlatego pole liczby w niestandardowym polu tekstowym może być przydatne, nawet gdy nie używasz placeholdera numeru slajdu. Z kolei zmiana widoczności placeholdera nie usuwa pola z niepowiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im placeholderów ani nie dostarczają ich treści. W szczególności zwykły slajd PowerPoint nie ma placeholdera nagłówka; nagłówki należą do stron notatek i materiałów drukowanych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie otrzyma tekst skonfigurowany przez managera placeholderów. Dla takiego scenariusza zobacz [Presentation Headers and Footers](/slides/pl/python-java/presentation-header-and-footer/).

## **Ograniczenia PPTX i PPT**

Sprawdź zarówno typ pola, jak i wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól obok tekstu pola. W testach obrotowych predefiniowane typy oraz użyty powyżej identyfikator niestandardowy przetrwały zapis i ponowne otwarcie. Nieznany typ niestandardowy zachował tekst rezerwowy; nie uzyskał automatycznej logiki obliczeniowej. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. W testach obrotowych pola numeru slajdu oraz predefiniowane pola daty/godziny przetrwały zapis i ponowne otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otworzyło się z jego identyfikatorem, ale z tekstem `*`; pole nagłówka w tym samym kontekście również dało `*`. Nie polegaj na tym, że pola niestandardowe lub nieobsługiwane konteksty pola zachowają widoczny tekst. |

Aby uzyskać przenośny, stały wynik, skonwertuj nieobsługiwane pola na zwykły tekst i jawnie przypisz pożądaną wartość przed zapisaniem. Zachowuje to wybrany tekst, ale celowo zatrzymuje automatyczne aktualizacje. Przetestuj także aplikację docelową, jeśli jej własne przeliczanie pól jest częścią Twojego procesu.

## **FAQ**

**Jak mogę stwierdzić, czy wyświetlana liczba lub data jest polem?**

Sprawdź [Portion.getField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#getField). Wartość różna od `None` identyfikuje pole; sam wyświetlany tekst nie pozwala tego określić.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [removeField](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/#removeField) konwertuje istniejący fragment na zwykły tekst. Przypisz wyraźną wartość później, jeśli potrzebujesz określonej zamrożonej daty lub tekstu rezerwowego.

**Czy wewnętrzny ciąg może definiować nowy format daty lub formułę?**

Nie. Identifikuje typ pola. Nieznany identyfikator nie dostarcza evaluatora ani wzorca formatu daty Pythona. Użyj obsługiwanego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego ponownie sprawdzać prezentację po jej zapisaniu?**

Identyfikatory pól, wyliczony tekst i formatowanie to odrębne rzeczy do weryfikacji. Konwersja formatu może zmienić widoczny wynik, nawet gdy identyfikator pola nadal istnieje.