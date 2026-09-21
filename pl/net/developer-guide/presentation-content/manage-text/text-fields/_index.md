---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w .NET
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/net/text-fields/
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
- C#
- Aspose.Slides
description: "Twórz, przeglądaj, modyfikuj i usuwaj pola tekstowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET. Zachowuj formatowanie i weryfikuj zapisane pliki PPTX i PPT."
---
## **Przegląd**

Akapit tekstowy składa się z fragmentów. Zwykły [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/) zawiera tekst literałowy; fragment pola dodatkowo posiada [IField](https://reference.aspose.com/slides/pl/net/aspose.slides/ifield/), którego typ określa automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, ale tylko jeden z nich zawiera pole.

Użyj [IPortion.Field](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/field/), aby je odróżnić: dla zwykłego tekstu jest on `null`. [IPortion.AddField](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/addfield/) konwertuje istniejący fragment na pole. Przechowuj etykietę i jej dynamiczną wartość w osobnych fragmentach, aby konwersja wartości nie zastąpiła jednocześnie etykiety.

Ten przewodnik opisuje pola wewnątrz tekstu, ich formatowanie oraz zapisywanie ich w formatach PPTX i PPT. Dla ramek tekstowych i akapitów zobacz [Manage Text](/slides/pl/net/manage-text/).

## **Utworzenie pola numeru slajdu**

Poniższy kompletny przykład tworzy pole tekstowe zawierające literał `Slide ` jako etykietę, a po niej automatycznie aktualizowany numer. Ustawia rozmiar, grubość i kolor liczby przed dodaniem pola, a następnie otwiera ponownie zapisaną prezentację i sprawdza typ pola, tekst oraz formatowanie. Nie wymaga pliku wejściowego.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Nowa prezentacja rozpoczyna się od numeru slajdu 1, więc tekst to `Slide 1`, a oba sprawdzenia wypisują `True`. Liczba pozostaje polem po ponownym otwarciu; nie jest to literał `1`. Rzutowania i indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Wybór typu pola**

[FieldType](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/pl/net/aspose.slides/ifieldtype/) i udostępnia następujące predefiniowane wartości. Przekaż odpowiednią wartość do [AddField](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/addfield/).

| Wartość | Zastosowanie |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/slidenumber/) | Aktualny numer slajdu. |
| [DateTime](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/datetime/) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [DateTime1](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/datetime9/) | Predefiniowane formaty daty lub kombinacji data/godzina. |
| [DateTime10](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/datetime13/) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [Header](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/header/) | Pole nagłówka; zobacz ograniczenia dotyczącą symboli zastępczych i formatów poniżej. |
| [Footer](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/footer/) | Pole stopki. |

Na przykład [DateTime3](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/datetime3/) reprezentuje dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne ciągi formatu daty .NET. [LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/languageid/) fragmentu oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Utworzenie pola z wewnętrznego ciągu znaków**

Przeciążenie metodą string [AddField](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/addfield/) przyjmuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, dla której nie istnieje predefiniowana wartość. Możesz także skonstruować [FieldType](https://reference.aspose.com/slides/pl/net/aspose.slides/fieldtype/fieldtype/) z tego identyfikatora. [IFieldType.InternalString](https://reference.aspose.com/slides/pl/net/aspose.slides/ifieldtype/internalstring/) udostępnia ten identyfikator do inspekcji.

Ten przykład zapisuje pole specyficzne dla aplikacji `custom-report-id` z tekstem zastępczym `Report-042`. Identyfikator nie rejestruje obliczenia: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja, która rozumie ten identyfikator, musi dostarczyć jego znaczenie i zaktualizować wartość.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Po tym cyklu PPTX typ to `custom-report-id`, a tekst to `Report-042`. Przekazanie ciągu takiego jak `yyyy-MM-dd` nazwałoby typ pola; nie skonfigurowałoby to niestandardowego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Inspekcja, modyfikacja i usuwanie pól daty/godziny**

Odczytuj i zmieniaj istniejące pole poprzez [IField.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ifield/type/). Sprawdź, czy pole istnieje, zanim odwołasz się do jego typu. Aby zatrzymać automatyczne aktualizacje, wywołaj [IPortion.RemoveField](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/removefield/). Zachowuje to fragment i jego bieżący tekst, jednocześnie usuwając powiązanie z polem. Jeśli potrzebujesz konkretnej stałej wartości, przypisz ten tekst po usunięciu pola.

Ustawienie API związane z przetwarzaniem pól daty/godziny znajdziesz w [Presentation.CurrentDateTime](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/currentdatetime/). Poniższy przykład używa wyraźnej daty zatwierdzenia przy konwertowaniu pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera on dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny oraz zwykłe etykiety tekstowe. Poniższy przykład iteruje po kształtach tekstowych najwyższego poziomu na zwykłych slajdach. Zmienia pola daty/godziny na długi format daty i ustawia kursywę, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Identyfikatory wewnętrzne wbudowane `datetime` oraz `datetime1`‑`datetime13` są rozpoznawane. Grupy, tabele, notatki, układy i wzorce wymagają przejścia po ich własnych kontenerach tekstu i nie są objęte zakresem tego przykładu.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Po ponownym otwarciu `UpdatedAt` ma typ `datetime3` i pozostaje dynamiczny. `ApprovedDate` nie ma pola i zawiera `05 April 2030`. Oba fragmenty daty są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe pozostają bez zmian. Weryfikacja odczytuje pierwszy fragment z dwóch znanych kształtów w dostarczonym przykładzie.

## **Zachowanie formatowania tekstu**

Działaj na istniejącym fragmencie przy dodawaniu pola, zmianie jego typu lub usuwaniu go. Operacje te zachowują formatowanie tego fragmentu. Użyj [IPortion.PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/portionformat/) aby zmienić tylko wymagane właściwości, tak jak w przykładach dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko po to, by zaktualizować jedno pole: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Rozróżniaj również formatowanie ustawione explicite od formatowania dziedziczonego z akapitu, układu lub motywu. Zobacz [Text Formatting](/slides/pl/net/text-formatting/) po więcej opcji formatowania.

## **Pola a symbole zastępcze nagłówka/stopki**

Pole jest częścią fragmentu tekstowego. Symbol zastępczy to kształt z określoną rolą w prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie przekształca tego kształtu w symbol zastępczy.

Menedżery nagłówka i stopki kontrolują tekst symbolu zastępczego oraz jego widoczność na slajdach, układach i wzorcach, w tym propagację do slajdów zależnych. Pole numeru w niestandardowym polu tekstowym może więc być przydatne, nawet gdy nie używasz symbolu zastępczego numeru slajdu. Odwrotnie, zmiana widoczności symbolu zastępczego nie usuwa pola z niepowiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im symboli zastępczych ani nie dostarczają ich zawartości. W szczególności standardowy slajd PowerPoint nie ma symbolu zastępczego nagłówka; nagłówki należą do stron notatek i materiałów rozdawniczych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie otrzyma tekst skonfigurowany przez menedżera symboli zastępczych. Dla takiego przepływu pracy zobacz [Presentation Headers and Footers](/slides/pl/net/presentation-header-and-footer/).

## **Ograniczenia PPTX i PPT**

Sprawdzaj zarówno typ pola, jak i jego wynikowy tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól wraz z tekstem pola. W testach cyklicznych predefiniowane typy oraz niestandardowy identyfikator użyty powyżej przetrwały zapis i otwarcie. Nieznany typ niestandardowy zachował tekst zastępczy; nie uzyskał logiki automatycznych obliczeń. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. W testach cyklicznych pola numeru slajdu oraz predefiniowane pola daty/godziny przetrwały zapis i otwarcie. Niestandardowe pole w zwykłym polu tekstowym slajdu otworzyło się z identyfikatorem, ale jego tekst to `*`; pole nagłówka w tym samym kontekście również zwróciło `*`. Nie polegaj na tym, że pola niestandardowe lub nieobsługiwane konteksty pól zachowają widoczny tekst. |

Aby uzyskać przenośny, stały wynik, przekształć nieobsługiwane pola w zwykły tekst i wyraźnie przypisz pożądaną wartość przed zapisaniem. Zachowuje to wybrany tekst, ale celowo zatrzymuje automatyczne aktualizacje. Przetestuj także docelową aplikację, jeśli jej własna rekalkulacja pól jest częścią Twojego przepływu pracy.

## **FAQ**

**Jak mogę stwierdzić, czy wyświetlany numer lub data jest polem?**

Sprawdź [IPortion.Field](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/field/). Nie‑nullowa wartość identyfikuje pole; sam wyświetlony tekst nie pozwala tego określić.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [RemoveField](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/removefield/) konwertuje istniejący fragment na zwykły tekst. Jeśli potrzebujesz konkretnej zamrożonej daty lub tekstu zastępczego, przypisz go po usunięciu pola.

**Czy wewnętrzny ciąg może definiować nowy format daty lub formułę?**

Nie. Określa on typ pola. Nieznany identyfikator nie dostarcza oceniającego ani wzorca formatu daty .NET. Użyj obsługiwanego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego warto ponownie sprawdzić prezentację po jej zapisaniu?**

Identyfikatory pól, wyliczony tekst i formatowanie to odrębne elementy, które trzeba zweryfikować. Konwersja formatu może zmienić widoczny rezultat, nawet jeśli identyfikator pola nadal jest obecny.