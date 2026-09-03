---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu C++
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/cpp/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- aktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Tworzenie, identyfikowanie, formatowanie i aktualizowanie pól tekstowych w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++."
---
## **Wprowadzenie**

W bibliotece Aspose.Slides for C++ tekst slajdu jest przechowywany w ramach tekstowych, które należą do kształtów. Interfejs [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) reprezentuje najczęstszy kształt zawierający tekst i udostępnia jego tekst za pośrednictwem metody [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Note" %}}

Każdy automatyczny kształt implementuje [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/), ale nie każdy kształt jest automatycznym kształtem ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji należy sprawdzić, czy kształt implementuje [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) przed dostępem do jego tekstu.

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj automatyczny kształt do slajdu, dodaj tekst do jego ramki tekstowej i zapisz prezentację. Poniższy przykład tworzy prostokątne pole tekstowe:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

Współrzędne i wymiary przekazywane do [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addautoshape/) są mierzone w punktach. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/addtextframe/) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdzenie, czy kształt jest polem tekstowym**

Użyj metody [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_istextbox/) aby określić, czy automatyczny kształt jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty z tekstem, jak i czysto graficzne automatyczne kształty.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład sprawdza każdy automatyczny kształt w prezentacji:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Nowo dodany automatyczny kształt nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Możesz dostarczyć ten tekst za pomocą [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/addtextframe/) lub [ITextFrame::set_Text](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/set_text/). Dodanie lub przypisanie pustego ciągu powoduje, że [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_istextbox/) zwraca `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Pierwsze dwa sprawdzenia zwracają `true`; ostatnie dwa zwracają `false`.

## **Znajdź kształt, który posiada ramkę tekstową**

Ogólny kod przetwarzający tekst może otrzymać obiekt [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj metody [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentshape/) aby przejść z powrotem do jego właściciela, czyli [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/).

Dla ramki tekstowej będącej własnością automatycznego kształtu lub innego kształtu z tekstem, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentshape/) zwraca właściciela, a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentcell/) zwraca `nullptr`. Obie metody zapewniają nawigację tylko do odczytu. Sprawdź zwróconą wartość pod kątem `nullptr` przed dostępem. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabel, w tym kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/cpp/search-and-replace-text/).

## **Dodaj kolumny do pola tekstowego**

Metoda [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_columncount/) dzieli ramkę tekstową na kolumny, a metoda [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_columnspacing/) ustawia odstęp między kolumnami w punktach. Obie metody należą do [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/) i mogą być wywoływane poprzez ramkę tekstową istniejącego pola tekstowego. Tekst jest zawijany pomiędzy kolumnami wewnątrz tego samego kształtu; nie przechodzi do innego kształtu.

Poniższy przykład tworzy pole tekstowe o trzech kolumnach z odstępem 10 punktów, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Wyodrębnij tekst z poszczególnych kolumn**

Użyj [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/splittextbycolumns/), aby pobrać tekst przypisany do każdej wizualnej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden ciąg znaków dla każdej kolumny, w kolejności czytania opartej na kolumnach. Ramka jednokolumnowa zwraca tablicę z jednym elementem, a pusta kolumna jest reprezentowana pustym ciągiem. Zwrócone ciągi zawierają wyłącznie tekst zwykły; formatowanie na poziomie fragmentu nie jest zachowane.

Jest to przydatne, gdy potrzebujesz:

- Wyodrębnić tekst zachowując kolejność czytania opartą na kolumnach.
- Indeksować lub porównać zawartość slajdów wielokolumnowych.
- Wyeksportować każdą kolumnę do osobnego pliku, pola bazy danych lub innego miejsca docelowego.
- Sprawdzić, jak tekst zostaje przemiesczany po ustawieniu liczby kolumn za pomocą [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_columncount/) lub odstępu za pomocą [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/set_columnspacing/), lub po zmianie czcionki lub rozmiaru ramki tekstowej.

Metoda raportuje tekst rozłożony w bieżącym [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/); nie przepływa automatycznie pomiędzy oddzielnymi kształtami lub polami tekstowymi. Rozkład kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, dlatego upewnij się, że wymagane czcionki są dostępne, gdy istotna jest spójność wyników.

Poniższy przykład ładuje prezentację, znajduje pierwszy automatyczny kształt wielokolumnowy z ramką tekstową na pierwszym slajdzie, odczytuje jego skonfigurowaną liczbę kolumn i zapisuje tekst z każdej kolumny do osobnego pliku. Kształty nieposiadające ramki tekstowej są pomijane.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Aktualizuj tekst**

Aby zaktualizować tekst w całej prezentacji, przeiteruj slajdy i kształty, wybierz automatyczne kształty i edytuj ich fragmenty tekstowe. Praca na poziomie fragmentu pozwala zmienić zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zamienia każde wystąpienie `years` na `months` w poszczególnych fragmentach tekstu automatycznych kształtów i pogrubia każdy dotknięty fragment:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Ta iteracja aktualizuje tekst wyłącznie w automatycznych kształtach. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga przeiterowania ich własnych kolekcji.

## **Dodaj pole tekstowe z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, dzięki czemu tylko ten fragment działa jako klikalny link. Użyj [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), aby powiązać fragment z zewnętrznym adresem URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go w prezentacji:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem zastępczym tekstu na slajdzie mistrza lub układu?**

[Placeholder](/slides/pl/cpp/manage-placeholder/) może dziedziczyć swoją pozycję i formatowanie z [master slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/masterslide/) lub [layout slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone i nie przejmuje zachowania symbolu zastępczego po zmianie układu.

**Jak mogę zamienić tekst nie zmieniając tekstu w wykresach, tabelach ani w SmartArt?**

Ogranicz iterację do kształtów implementujących [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/), tak jak pokazano w przykładzie Aktualizuj tekst. Wykresy, tabele i SmartArt przechowują tekst w własnych modelach obiektów, więc nie są modyfikowane przez tę pętlę.