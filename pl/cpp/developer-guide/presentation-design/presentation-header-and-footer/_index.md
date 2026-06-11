---
title: Zarządzanie nagłówkami i stopkami prezentacji w C++
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/cpp/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- rozdanie
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Użyj Aspose.Slides dla C++ aby dodać i dostosować nagłówki oraz stopki w prezentacjach PowerPoint i OpenDocument, zapewniając profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie ustawieniami nagłówka i stopki w prezentacjach PowerPoint. Nagłówki i stopki są obsługiwane na poziomie głównego szablonu prezentacji, a API udostępnia metody do ustawiania tekstu stopki, zmiany widoczności stopki oraz aktualizowania tekstu nagłówka na głównych slajdach notatek.

Możesz także zarządzać nagłówkami i stopkami dla slajdów rozdania i notatek. Obejmuje to zmianę widoczności i tekstu pól zastępczych nagłówka, stopki, numeru slajdu oraz daty i czasu dla głównego szablonu notatek, wszystkich podrzędnych slajdów notatek lub pojedynczego slajdu notatek.

## **Zarządzanie tekstem nagłówka i stopki**

Notatki niektórych konkretnych slajdów można zaktualizować, jak pokazano w przykładzie poniżej:

``` cpp
// Funkcja ustawia tekst nagłówka/stopki
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Wczytaj prezentację
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Ustawianie stopki
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Dostęp i aktualizacja nagłówka
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Zapisz prezentację
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Zarządzanie nagłówkami i stopkami na slajdach rozdania i notatek**

Aspose.Slides dla C++ obsługuje nagłówki i stopki w slajdach rozdania i notatek. Postępuj zgodnie z poniższymi krokami:

- Load a [Prezentację](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation)containing a video.
- Zmień ustawienia nagłówka i stopki dla głównego szablonu notatek i wszystkich slajdów notatek.
- Ustaw widoczność pól zastępczych Footer w głównym slajdzie notatek i wszystkich podrzędnych.
- Ustaw widoczność pól zastępczych Date i time w głównym slajdzie notatek i wszystkich podrzędnych.
- Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek.
- Ustaw widoczność pola zastępczego Header w slajdzie notatek.
- Ustaw tekst w polu zastępczym Header slajdu notatek.
- Ustaw tekst w polu zastępczym Date-time slajdu notatek.
- Zapisz zmodyfikowany plik prezentacji.

Fragment kodu podany w poniższym przykładzie.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Zmień ustawienia nagłówka i stopki dla głównego szablonu notatek i wszystkich slajdów notatek
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// spraw, aby główny slajd notatek i wszystkie podrzędne pola zastępcze stopki były widoczne
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// spraw, aby główny slajd notatek i wszystkie podrzędne pola zastępcze nagłówka były widoczne
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// spraw, aby główny slajd notatek i wszystkie podrzędne pola zastępcze numeru slajdu były widoczne
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// spraw, aby główny slajd notatek i wszystkie podrzędne pola zastępcze daty i czasu były widoczne
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// ustaw tekst na głównym slajdzie notatek i wszystkich podrzędnych polach zastępczych nagłówka
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// ustaw tekst na głównym slajdzie notatek i wszystkich podrzędnych polach zastępczych stopki
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// ustaw tekst na głównym slajdzie notatek i wszystkich podrzędnych polach zastępczych daty i czasu
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// ustaw widoczny pole zastępcze nagłówka tego slajdu notatek
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// ustaw widoczny pole zastępcze stopki tego slajdu notatek
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// ustaw widoczny pole zastępcze numeru slajdu tego slajdu notatek
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// ustaw widoczny pole zastępcze daty i czasu tego slajdu notatek
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// ustaw tekst w polu zastępczym nagłówka slajdu notatek
	headerFooterManager->SetHeaderText(u"New header text");
	// ustaw tekst w polu zastępczym stopki slajdu notatek
	headerFooterManager->SetFooterText(u"New footer text");
	// ustaw tekst w polu zastępczym daty i czasu slajdu notatek
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę dodać „header” do zwykłych slajdów?**

W programie PowerPoint „Header” istnieje tylko dla notatek i rozdania; na zwykłych slajdach obsługiwane elementy to stopka, data/godzina oraz numer slajdu. W Aspose.Slides obowiązują te same ograniczenia: nagłówek tylko dla Notes/Handout, a na slajdach — Footer/DateTime/SlideNumber.

**Co zrobić, jeśli układ nie zawiera obszaru stopki — czy mogę „włączyć” jej widoczność?**

Tak. Sprawdź widoczność przy pomocy menedżera nagłówka/stopki i włącz ją w razie potrzeby. Te wskaźniki i metody API są przeznaczone do sytuacji, gdy pole zastępcze jest brakujące lub ukryte.

**Jak sprawić, by numer slajdu zaczynał się od wartości innej niż 1?**

Ustaw [pierwszy numer slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/set_firstslidenumber/); po tym wszystkie numery są przeliczane ponownie. Na przykład możesz rozpocząć od 0 lub 10 i ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami przy eksportowaniu do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. Oznacza to, że jeśli elementy są widoczne na slajdach/stronach notatek, pojawią się również w formacie wyjściowym wraz z resztą treści.