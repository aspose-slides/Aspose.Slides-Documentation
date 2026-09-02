---
title: "Zarządzanie polami tekstowymi w prezentacjach przy użyciu C++"
linktitle: "Zarządzanie polem tekstowym"
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
description: "Aspose.Slides for C++ ułatwia tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając możliwości automatyzacji prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe i umieścić w nim tekst. Aspose.Slides for C++ udostępnia interfejs [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape) pozwalający dodać kształt zawierający tekst.

{{% alert title="Info" color="info" %}}

Aspose.Slides udostępnia również interfejs [IShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_shape) pozwalający dodawać kształty do slajdów. Jednak nie wszystkie kształty dodane przez interfejs `IShape` mogą zawierać tekst. Natomiast kształty dodane przez interfejs [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape) mogą zawierać tekst. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Dlatego, pracując z kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został rzutowany przy użyciu interfejsu `IAutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.text_frame), który jest właściwością interfejsu `IAutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/cpp/manage-textbox/#update-text) na tej stronie. 

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation). 
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape) z [ShapeType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu `IAutoShape`. 
4. Dodaj właściwość `TextFrame` do obiektu `IAutoShape`, która będzie zawierać tekst. W poniższym przykładzie dodaliśmy następujący tekst: *Aspose TextBox*
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod C++—implementacja powyższych kroków—pokazuje, jak dodać tekst do slajdu:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Tworzy instancję Presentation
auto pres = System::MakeObject<Presentation>();

// Pobiera pierwszy slajd w prezentacji
auto sld = pres->get_Slides()->idx_get(0);

// Dodaje AutoShape z typem ustawionym na Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Dodaje TextFrame do prostokąta
ashp->AddTextFrame(u" ");

// Dostęp do ramki tekstowej
auto txtFrame = ashp->get_TextFrame();

// Tworzy obiekt Paragraph dla ramki tekstowej
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Tworzy obiekt Portion dla akapitu
auto portion = para->get_Portions()->idx_get(0);

// Ustawia tekst
portion->set_Text(u"Aspose TextBox");

// Zapisuje prezentację na dysku
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [get_IsTextBox](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_istextbox/) z interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) , umożliwiającą badanie kształtów i identyfikację pól tekstowych.

![Pole tekstowe i kształt](istextbox.png)

Ten kod C++ pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Zauważ, że jeśli po prostu dodasz autokształt za pomocą metody `AddAutoShape` z interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/) , metoda `get_IsTextBox` tego autokształtu zwróci `false`. Jednak po dodaniu tekstu do autokształtu metodą `AddTextFrame` lub metodą `set_Text`, metoda `get_IsTextBox` zwróci `true`.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() zwraca false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() zwraca true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() zwraca false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() zwraca true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() zwraca false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() zwraca false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() zwraca false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() zwraca false
```

## **Znajdowanie kształtu, który posiada ramkę tekstową**

W ogólnym kodzie przetwarzania tekstu możesz otrzymać obiekt [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) , nie wiedząc, który obiekt prezentacji go zawiera. Użyj [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentshape/) , aby przejść z powrotem do właściciela [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/).

Dla ramki tekstowej należącej do [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) lub innego kształtu zawierającego tekst, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentshape/) zwraca właściciela, a [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/get_parentcell/) zwraca `nullptr`. Obie metody zapewniają nawigację tylko do odczytu, więc ich wywołanie nie zmienia własności. Zawsze sprawdzaj zwróconą wartość pod kątem `nullptr` przed dostępem do kształtu.

Pełny przykład identyfikujący właścicieli kształtów i komórek tabeli, włącznie z kształtami powiązanymi z węzłami SmartArt, znajdziesz w [Search and Replace Text](/slides/pl/cpp/search-and-replace-text/).

## **Dodawanie kolumn do pola tekstowego**

Aspose.Slides udostępnia metody [set_ColumnCount](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) i [set_ColumnSpacing](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format) oraz klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format)), które pozwalają dodawać kolumny do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz ustawić odległość pomiędzy kolumnami wyrażoną w punktach.

Ten kod w C++ demonstruje opisaną operację: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Pobiera pierwszy slajd w prezentacji
auto slide = presentation->get_Slides()->idx_get(0);

// Dodaje AutoShape z typem ustawionym na Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Dodaje TextFrame do prostokąta
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Pobiera format tekstu z TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Określa liczbę kolumn w TextFrame
format->set_ColumnCount(3);

// Określa odstęp między kolumnami
format->set_ColumnSpacing(10);

// Zapisuje prezentację
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Dodawanie kolumn do ramki tekstowej**

Aspose.Slides for C++ udostępnia metodę [set_ColumnCount](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_text_frame_format)), która pozwala dodawać kolumny w ramkach tekstowych. Dzięki tej metodzie możesz określić preferowaną liczbę kolumn w ramce tekstowej. 

Ten kod C++ pokazuje, jak dodać kolumnę w ramce tekstowej:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Aktualizacja tekstu**

Aspose.Slides pozwala zmienić lub zaktualizować tekst zawarty w polu tekstowym lub wszystkie teksty w prezentacji. 

Ten kod C++ demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Zmienia tekst
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Zmienia formatowanie
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Zapisuje zmodyfikowaną prezentację
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Dodawanie pola tekstowego z hiperłączem** 

Możesz wstawić łącze wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy są przekierowywani do otwarcia łącza. 

Aby dodać pole tekstowe zawierające łącze, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu AutoShape. 
4. Dodaj `TextFrame` do obiektu `AutoShape`, które zawiera *Aspose TextBox* jako domyślny tekst. 
5. Utwórz instancję klasy `IHyperlinkManager`. 
6. Przypisz obiekt `IHyperlinkManager` do metody [set_HyperlinkClick](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) powiązanej z wybraną częścią `TextFrame`. 
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod C++ — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Tworzy instancję klasy Presentation reprezentującej plik PPTX
auto presentation = System::MakeObject<Presentation>();

// Pobiera pierwszy slajd w prezentacji
auto slide = presentation->get_Slides()->idx_get(0);

// Dodaje obiekt AutoShape z typem ustawionym na Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Rzutuje kształt do AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Dostępuje do właściwości ITextFrame powiązanej z AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Dodaje tekst do ramki
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Ustawia hiperłącze dla tekstu części
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Zapisuje prezentację PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a placeholderem tekstowym podczas pracy z master slajdami?**

Placeholder [/slides/pl/cpp/manage-placeholder/] dziedziczy styl/pozycję z [mastera](https://reference.aspose.com/slides/pl/cpp/aspose.slides/masterslide/) i może być nadpisany w [layoutach](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/), natomiast zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy zmianie layoutów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie modyfikując tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do autokształtów posiadających ramki tekstowe i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pl/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartart/)), przeglądając ich kolekcje osobno lub pomijając te typy obiektów.