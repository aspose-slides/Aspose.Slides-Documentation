---
title: Zarządzanie polami tekstowymi w prezentacjach PowerPoint w C++
linktitle: Pola tekstowe
type: docs
weight: 52
url: /pl/cpp/text-fields/
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
- C++
- Aspose.Slides
description: "Twórz, przeglądaj, modyfikuj i usuwaj pola tekstowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++. Zachowuj formatowanie i sprawdzaj zapisane pliki PPTX i PPT."
---
## **Przegląd**

Akapit tekstowy składa się z fragmentów. Zwykły [IPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/) zawiera dosłowny tekst; fragment pola posiada również [IField](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifield/), którego typ określa automatycznie aktualizowaną wartość, taką jak numer slajdu lub data. Dwa fragmenty mogą wyświetlać te same znaki, ale tylko jeden zawiera pole.

Użyj [IPortion::get_Field](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/get_field/), aby je odróżnić: zwraca `nullptr` dla zwykłego tekstu. [IPortion::AddField](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/addfield/) konwertuje istniejący fragment w pole. Przechowuj etykietę i jej dynamiczną wartość w osobnych fragmentach, aby konwersja wartości nie zastępowała jednocześnie etykiety.

Ten przewodnik opisuje pola wewnątrz tekstu, ich formatowanie oraz zapisywanie ich w formatach PPTX i PPT. Dla ramek tekstowych i akapitów zobacz [Manage Text](/slides/pl/cpp/manage-text/).

## **Utwórz pole numeru slajdu**

Poniższy przykład tworzy pole tekstowe zawierające dosłowną etykietę `Slide ` oraz automatycznie aktualizowany numer. Ustawia rozmiar, grubość i kolor liczby przed dodaniem pola, a następnie ponownie otwiera zapisany zestaw i sprawdza typ pola, tekst oraz formatowanie. Plik wejściowy nie jest wymagany.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Nowa prezentacja zaczyna się od numeru slajdu 1, więc oczekiwany tekst to `Slide 1`, a oba sprawdzenia powinny wypisać `True`. Numer pozostaje polem po ponownym otwarciu; nie jest to dosłowny `1`. Rzutowanie i indeksy w weryfikacji odnoszą się do kształtu i fragmentów utworzonych w tym przykładzie.

## **Wybierz typ pola**

[FieldType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifieldtype/) i udostępnia następujące predefiniowane wartości. Przekaż odpowiednią wartość do [AddField](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/addfield/).

| Akcesor | Cel |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_slidenumber/) | Aktualny numer slajdu. |
| [get_DateTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_datetime/) | Data/godzina w domyślnym formacie aplikacji renderującej. |
| [get_DateTime1](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_datetime9/) | Predefiniowane formaty dat lub połączonych dat/godzin. |
| [get_DateTime10](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_datetime13/) | Predefiniowane formaty czasu, z opcjami sekund i zegarem 12‑godzinnym. |
| [get_Header](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_header/) | Pole nagłówka; zobacz ograniczenia dotyczące symbolu zastępczego i formatu poniżej. |
| [get_Footer](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_footer/) | Pole stopki. |

Na przykład [get_DateTime3](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/get_datetime3/) zwraca dzień, pełną nazwę miesiąca i rok w języku angielskim. Są to predefiniowane formaty pól, a nie dowolne ciągi formatu daty. Język fragmentu, ustawiany za pomocą [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/set_languageid/), oraz aplikacja przetwarzająca prezentację mogą wpływać na wyświetlany wynik.

## **Utwórz pole z wewnętrznego ciągu znaków**

Przeciążenie metodą string [AddField](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/addfield/) przyjmuje wewnętrzny identyfikator pola. Użyj go, gdy chcesz zachować identyfikator dostarczony przez inną aplikację, która nie ma predefiniowanej wartości. Możesz także utworzyć [FieldType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fieldtype/fieldtype/) z tego identyfikatora. [IFieldType::get_InternalString](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifieldtype/get_internalstring/) udostępnia ten identyfikator do inspekcji.

Ten przykład przechowuje pole specyficzne dla aplikacji `custom-report-id` z tekstem awaryjnym `Report-042`. Plik wejściowy nie jest wymagany. Identyfikator nie rejestruje obliczeń: Aspose.Slides nie generuje identyfikatorów raportów dla nieznanego typu. Aplikacja rozumiejąca ten identyfikator musi dostarczyć jego znaczenie i aktualizować wartość.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

Po tym przebiegu PPTX oczekiwany typ to `custom-report-id`, a oczekiwany tekst to `Report-042`. Przekazanie ciągu takiego jak `yyyy-MM-dd` nazwie typ pola; nie skonfiguruje to własnego formatu daty. Dla stałej daty w dowolnym formacie użyj zwykłego tekstu.

## **Sprawdzaj, modyfikuj i usuwaj pola daty/godziny**

Odczytaj istniejący typ pola za pomocą [IField::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifield/get_type/) i zmień go za pomocą [IField::set_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifield/set_type/). Upewnij się, że pole istnieje przed odczytaniem jego typu. Aby zatrzymać automatyczne aktualizacje, wywołaj [IPortion::RemoveField](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/removefield/). Zachowuje to fragment i jego bieżący tekst, usuwając powiązanie pola. Jeśli potrzebna jest konkretna stała wartość, przypisz ten tekst po usunięciu pola.

Dla ustawień API związanych z przetwarzaniem pól daty/godziny zobacz [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/set_currentdatetime/). Poniższy przykład używa wyraźnej daty zatwierdzenia przy konwersji pola na zwykły tekst.

Pobierz [sample.pptx](sample.pptx) i umieść go w katalogu roboczym. Zawiera on dwa nazwane kształty tekstowe, `UpdatedAt` i `ApprovedDate`, każdy z polem daty/godziny, oraz zwykłe etykiety tekstowe. Następujący przykład przechodzi po wszystkich kształtach tekstowych na zwykłych slajdach. Zmienia pola daty/godziny na format długiej daty i ustawia kursywę, zachowując pozostałe formatowanie. Tylko pola w `ApprovedDate` stają się stałym tekstem.

Próbka rozpoznaje wbudowane wewnętrzne identyfikatory `datetime` oraz `datetime1`‑`datetime13`. Grupy, tabele, notatki, układy i szablony wymagają przeglądania własnych kontenerów tekstowych i nie są omawiane w tym przykładzie.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Po ponownym otwarciu `UpdatedAt` powinien mieć typ `datetime3` i pozostać dynamiczny. `ApprovedDate` nie powinien już mieć pola i powinien zawierać `05 April 2030`. Oba fragmenty daty są kursywą, a ich pierwotny rozmiar czcionki, pogrubienie i kolor pozostają niezmienione. Zwykłe etykiety tekstowe pozostają bez zmian. Weryfikacja odczytuje pierwszy fragment z dwóch znanych kształtów w dostarczonej próbce.

## **Zachowaj formatowanie tekstu**

Pracuj z istniejącym fragmentem przy dodawaniu pola, zmianie jego typu lub usuwaniu. Operacje te zachowują formatowanie tego fragmentu. Użyj [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/get_portionformat/), aby zmienić tylko wymagane właściwości, tak jak w przykładach dla koloru lub kursywy.

Unikaj przebudowy całej ramki tekstowej tylko po to, aby zaktualizować jedno pole: może to spowodować utratę pierwotnych granic fragmentów i ich indywidualnego formatowania. Również odróżniaj formatowanie ustawione explicite od formatowania odziedziczonego po akapicie, układzie lub temacie. Zobacz [Text Formatting](/slides/pl/cpp/text-formatting/) po więcej opcji formatowania.

## **Pola i symbole zastępcze nagłówka/stopki**

Pole jest częścią fragmentu tekstowego. Symbol zastępczy jest kształtem z przypisaną rolą w prezentacji, taką jak stopka lub numer slajdu. Dodanie pola do zwykłego pola tekstowego nie zamienia tego kształtu w symbol zastępczy.

Menedżery nagłówka/stopki kontrolują tekst symboli zastępczych oraz ich widoczność na slajdach, układach i szablonach, w tym propagację do zależnych slajdów. Pole numeru w niestandardowym polu tekstowym może więc być przydatne, nawet gdy nie używasz symbolu zastępczego numeru slajdu. Odwrotnie, zmiana widoczności symbolu zastępczego nie usuwa pola z niepowiązanego pola tekstowego.

Predefiniowane typy nagłówka i stopki nie tworzą odpowiadających im symboli zastępczych ani nie dostarczają ich treści. W szczególności zwykły slajd PowerPoint nie posiada symbolu zastępczego nagłówka; nagłówki należą do stron notatek i materiałów rozdawczych. Nie zakładaj, że pole nagłówka lub stopki w dowolnym kształcie automatycznie otrzyma tekst skonfigurowany przez menedżera symboli zastępczych. Dla takiego scenariusza zobacz [Presentation Headers and Footers](/slides/pl/cpp/presentation-header-and-footer/).

## **Ograniczenia PPTX i PPT**

Sprawdzaj zarówno typ pola, jak i uzyskany tekst po zapisaniu i ponownym otwarciu. Zachowanie identyfikatora nie dowodzi, że aplikacja potrafi obliczyć lub wyświetlić jego wartość.

| Format | Zachowanie pola i ograniczenia |
|---|---|
| PPTX | Przechowuje wewnętrzne identyfikatory pól obok tekstu pola. Użyj powyższych przykładów, aby po zapisaniu i ponownym otwarciu sprawdzić predefiniowane typy oraz własne identyfikatory. Nieznany typ niestandardowy nie uzyskuje logiki automatycznych obliczeń. Inna aplikacja może traktować nieobsługiwane identyfikatory inaczej. |
| PPT | Używa starszych reprezentacji pól i ma bardziej ograniczoną kompatybilność. Pola numeru slajdu i predefiniowane daty/godziny mają starsze reprezentacje. Nieobsługiwane pola niestandardowe lub pola nagłówka w zwykłym polu tekstowym slajdu mogą wyświetlać `*` jako tekst. Nie polegaj na tym, że pola niestandardowe lub nieobsługiwane konteksty pól zachowają widoczny tekst. |

Aby uzyskać przenośny, stały wynik, skonwertuj nieobsługiwane pola na zwykły tekst i jawnie przypisz pożądany wartość przed zapisaniem. Zachowuje to wybrany tekst, ale celowo zatrzymuje automatyczne aktualizacje. Przetestuj również docelową aplikację, jeśli jej własne przeliczanie pól jest częścią Twojego przepływu pracy.

## **FAQ**

**Jak mogę sprawdzić, czy wyświetlana liczba lub data jest polem?**

Sprawdź [IPortion::get_Field](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/get_field/). Wartość nie‑null wskazuje pole; sam wyświetlany tekst nie pozwala to określić.

**Czy usunięcie pola usuwa jego tekst lub formatowanie?**

Nie. [RemoveField](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportion/removefield/) konwertuje istniejący fragment na zwykły tekst. Przypisz wyraźną wartość po usunięciu, jeśli potrzebny jest określony zamrożony tekst lub wartość awaryjna.

**Czy wewnętrzny ciąg może definiować nowy format daty lub formułę?**

Nie. Identyfikuje typ pola. Nieznany identyfikator nie dostarcza mechanizmu oceny ani wzorca formatu daty. Użyj wspieranego predefiniowanego typu lub sformatuj wartość samodzielnie jako zwykły tekst.

**Dlaczego po zapisaniu prezentacji trzeba ją ponownie sprawdzić?**

Identyfikatory pól, obliczony tekst i formatowanie to odrębne elementy wymagające weryfikacji. Konwersja formatu może zmienić widoczny wynik, nawet gdy identyfikator pola nadal istnieje.