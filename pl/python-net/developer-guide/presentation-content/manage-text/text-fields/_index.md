---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w Pythonie
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/python-net/text-fields/
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
- Aspose.Slides
description: "Tworzenie, przeglądanie, modyfikowanie i usuwanie pól tekstowych w prezentacjach PowerPoint za pomocą Aspose.Slides dla Pythona w .NET. Zachowanie formatowania i weryfikacja zapisanych plików PPTX i PPT."
---
## **Przegląd**

Akapit tekstowy składa się z fragmentów. Zwykły [Fragment](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/) zawiera tekst dosłowny; fragment pola zawiera również [Pole](https://reference.aspose.com/slides/pl/python-net/aspose.slides/field/), którego typ określa automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, podczas gdy tylko jeden zawiera pole.

Użyj [Portion.field](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/field/), aby je odróżnić: ma wartość `None` dla zwykłego tekstu. [Portion.add_field](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/add_field/) konwertuje istniejący fragment na pole. Umieść etykietę i jej dynamiczną wartość w oddzielnych fragmentach, aby konwersja wartości nie zastąpiła także etykiety.

Ten przewodnik opisuje pola w tekście, ich formatowanie oraz zapisywanie ich w formatach PPTX i PPT. Dla ramek tekstowych i akapitów zobacz [Zarządzanie tekstem](/slides/pl/python-net/manage-text/).

## **Utworzenie pola numeru slajdu**

Poniższy kompletny przykład tworzy pole tekstowe zawierające dosłowną etykietę `Slide `, po której następuje automatycznie aktualizowany numer. Przed dodaniem pola ustawia rozmiar, wagę i kolor numeru, a następnie ponownie otwiera zapisaną prezentację i sprawdza typ pola, tekst oraz formatowanie. Nie jest wymagany żaden plik wejściowy.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Nowa prezentacja zaczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia wypisują `True`. Numer pozostaje polem po ponownym otwarciu; nie jest to dosłowna `1`. Indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Wybór typu pola**

[FieldType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/) udostępnia następujące predefiniowane wartości. Przekaż odpowiednią wartość do [add_field](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/add_field/).

| Wartość | Cel |
|---|---|
| [slide_number](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/slide_number/) | Aktualny numer slajdu. |
| [date_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/date_time/) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [date_time1](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/date_time9/) | Predefiniowane formaty daty lub połączone formaty daty/godziny. |
| [date_time10](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/date_time13/) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [header](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/header/) | Pole nagłówka; zobacz ograniczenia dotyczące placeholderów i formatów poniżej. |
| [footer](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/footer/) | Pole stopki. |

Na przykład [date_time3](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/date_time3/) oznacza dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne łańcuchy formatu daty w Pythonie. Identyfikator języka fragmentu ([language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseportionformat/language_id/)) oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Utworzenie pola z łańcucha wewnętrznego**

Przeciążenie metod `add_field` przyjmujące łańcuch wewnętrzny akceptuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, która nie ma predefiniowanej wartości. Można także skonstruować [FieldType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/__init__) z tego identyfikatora. [FieldType.internal_string](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fieldtype/internal_string/) udostępnia ten identyfikator do inspekcji.

Ten przykład przechowuje pole specyficzne dla aplikacji `custom-report-id` z tekstem zastępczym `Report-042`. Identyfikator nie rejestruje obliczeń: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja rozumiejąca ten identyfikator musi dostarczyć jego znaczenie i zaktualizować wartość.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Po tej wymianie PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie łańcucha takiego jak `%Y-%m-%d` nazwałoby typ pola; nie skonfigurowałoby to niestandardowego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Inspekcja, modyfikacja i usuwanie pól daty/godziny**

Odczytuj i zmieniaj istniejące pole poprzez [Field.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/field/type/). Sprawdź, czy pole istnieje, zanim odwołasz się do jego typu. Aby zatrzymać automatyczne aktualizacje, wywołaj [Portion.remove_field](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/remove_field/). Operacja ta zachowuje fragment i jego bieżący tekst, usuwając jedynie powiązanie z polem. Jeśli potrzebna jest konkretna stała wartość, przypisz ten tekst po usunięciu pola.

Ustawienie API związane z przetwarzaniem pól daty/godziny znajduje się w [Presentation.current_date_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/current_date_time/). Poniższy przykład używa jawnej daty zatwierdzenia przy konwersji pola na zwykły tekst. Krotka z nazwami miesięcy w języku angielskim utrzymuje stałą datę niezależnie od ustawień regionalnych systemu.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera on dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny, plus zwykłe etykiety tekstowe. Następujący przykład przechodzi po kształtach tekstowych najwyższego poziomu na zwykłych slajdach. Zmienia pola daty/godziny na format długiej daty i ustawia je kursywą, zachowując jednocześnie pozostałe formatowanie. Tylko pola w `ApprovedDate` zostają zamienione na stały tekst.

Wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13` są rozpoznawane. Grupy, tabele, notatki, układy i szablony wymagają przeglądania własnych kontenerów tekstu i nie są objęte zakresem tego przykładu.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Po ponownym otwarciu `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma już pola i zawiera `05 April 2030`. Oba fragmenty daty są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe pozostają bez zmian. Weryfikacja odczytuje pierwszy fragment dwóch znanych kształtów w dostarczonym przykładzie.

## **Zachowanie formatowania tekstu**

Pracuj z istniejącym fragmentem przy dodawaniu pola, zmianie jego typu lub usuwaniu go. Operacje te zachowują formatowanie tego fragmentu. Użyj [Portion.portion_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/portion_format/), aby zmienić tylko wymagane właściwości, tak jak w przykładach dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko po to, by zaktualizować jedno pole: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Również odróżniaj formatowanie ustawione jawnie od formatowania dziedziczonego z akapitu, układu lub motywu. Zobacz [Formatowanie tekstu](/slides/pl/python-net/text-formatting/) po więcej opcji formatowania.

## **Pola a placeholdery nagłówka/stopki**

Pole jest częścią fragmentu tekstowego. Placeholder to kształt z rolą w prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie zmienia tego kształtu w placeholder.

Menedżery nagłówka i stopki kontrolują tekst placeholdera oraz jego widoczność na slajdach, układach i szablonach, włącznie z propagacją do slajdów zależnych. Pole numeru w niestandardowym polu tekstowym może więc być przydatne, nawet jeśli nie używasz placeholdera numeru slajdu. Z kolei zmiana widoczności placeholdera nie usuwa pola z niezwiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających placeholderów ani nie dostarczają ich zawartości. W szczególności zwykły slajd PowerPoint nie ma placeholdera nagłówka; nagłówki należą do stron notatek i materiałów rozdawniczych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie uzyska tekst skonfigurowany przez menedżera placeholderów. Dla takiego scenariusza zobacz [Nagłówki i stopki prezentacji](/slides/pl/python-net/presentation-header-and-footer/).

## **Ograniczenia formatu PPTX i PPT**

Sprawdzaj zarówno typ pola, jak i wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól wraz z ich tekstem. W testach przebiegowych predefiniowane typy i niestandardowy identyfikator użyty powyżej przetrwały zapis i ponowne otwarcie. Nieznany typ niestandardowy zachował tekst zastępczy; nie uzyskał logiki automatycznego obliczania. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. W testach przebiegowych pola numeru slajdu oraz predefiniowane pola daty/godziny przetrwały zapis i otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otwarto z jego identyfikatorem, ale z `*` jako tekstem; pole nagłówka w tym samym kontekście również zwróciło `*`. Nie polegaj na tym, że niestandardowe pola lub nieobsługiwane konteksty pól zachowają widoczny tekst. |

Aby uzyskać przenośny, stały wynik, konwertuj nieobsługiwane pola na zwykły tekst i jawnie przypisz pożądaną wartość przed zapisem. Zachowuje to wybrany tekst, ale świadomie wyłącza automatyczne aktualizacje. Przetestuj również docelową aplikację, jeśli jej własne przeliczenie pól jest częścią Twojego przepływu pracy.

## **FAQ**

**Jak mogę stwierdzić, czy wyświetlana liczba lub data jest polem?**

Sprawdź [Portion.field](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/field/). Wartość różna od `None` identyfikuje pole; sam wyświetlany tekst nie daje takiej informacji.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [remove_field](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/remove_field/) konwertuje istniejący fragment na zwykły tekst. Przypisz jawnie wartość później, jeśli potrzebujesz konkretnej, zamrożonej daty lub tekstu zastępczego.

**Czy wewnętrzny łańcuch może definiować nowy format daty lub formułę?**

Nie. Określa typ pola. Nieznany identyfikator nie dostarcza oceniającego ani wzorca formatu daty w Pythonie. Użyj wspieranego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego po zapisaniu prezentacji trzeba ją ponownie sprawdzić?**

Identyfikatory pól, wyliczony tekst i formatowanie to odrębne elementy wymagające weryfikacji. Konwersja formatu może zmienić widoczny rezultat, nawet gdy identyfikator pola nadal istnieje.