---
title: Zarządzanie nagłówkami i stopkami prezentacji w .NET
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/net/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- wersja robocza
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Użyj Aspose.Slides for .NET, aby dodać i dostosować nagłówki oraz stopki w prezentacjach PowerPoint i OpenDocument, zapewniając profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie ustawieniami nagłówka i stopki w prezentacjach PowerPoint. Nagłówki i stopki są obsługiwane na poziomie mastera prezentacji, a API udostępnia metody do ustawiania tekstu stopki, zmiany widoczności stopki oraz aktualizacji tekstu nagłówka na slajdach notatek mastera.

Możesz także zarządzać nagłówkami i stopkami dla slajdów notatek i wersji roboczych. Obejmuje to zmianę widoczności i tekstu pól nagłówka, stopki, numeru slajdu oraz daty i czasu dla mastera notatek, wszystkich podrzędnych slajdów notatek lub pojedynczego slajdu notatek.

## **Zarządzanie tekstem nagłówka i stopki**

Notatki niektórych konkretnych slajdów mogą być zaktualizowane, jak pokazano w poniższym przykładzie:

```c#
// Wczytaj prezentację
Presentation pres = new Presentation("headerTest.pptx");

// Ustawianie stopki
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Dostęp i aktualizacja nagłówka
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Zapisz prezentację
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Metoda ustawiająca tekst nagłówka/stopki
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **Zarządzanie nagłówkami i stopkami na wersjach roboczych i slajdach notatek**
Aspose.Slides for .NET obsługuje nagłówki i stopki w wersjach roboczych i slajdach notatek. Proszę postępować zgodnie z poniższymi krokami:

- Wczytaj [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) zawierający wideo.
- Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek.
- Ustaw widoczność pól stopki w masterze notatek oraz we wszystkich podrzędnych slajdach.
- Ustaw widoczność pól daty i czasu w masterze notatek oraz we wszystkich podrzędnych slajdach.
- Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek.
- Ustaw widoczność pola nagłówka w slajdzie notatek.
- Ustaw tekst w polu nagłówka slajdu notatek.
- Ustaw tekst w polu daty i czasu slajdu notatek.
- Zapisz zmodyfikowany plik prezentacji.

Fragment kodu podany w poniższym przykładzie.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Zmień ustawienia nagłówka i stopki dla mastera notatek i wszystkich slajdów notatek
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola stopki były widoczne
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola nagłówka były widoczne
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola numeru slajdu były widoczne
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // spraw, aby master slajd notatek i wszystkie podrzędne pola daty i czasu były widoczne

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach nagłówka
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach stopki
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // ustaw tekst w master slajdzie notatek oraz wszystkich podrzędnych polach daty i czasu
	}

	// Zmień ustawienia nagłówka i stopki tylko dla pierwszego slajdu notatek
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // spraw, aby pole nagłówka tego slajdu notatek było widoczne

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // spraw, aby pole stopki tego slajdu notatek było widoczne

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // spraw, aby pole numeru slajdu tego slajdu notatek było widoczne

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // spraw, aby pole daty i czasu tego slajdu notatek było widoczne

		headerFooterManager.SetHeaderText("New header text"); // ustaw tekst w polu nagłówka slajdu notatek
		headerFooterManager.SetFooterText("New footer text"); // ustaw tekst w polu stopki slajdu notatek
		headerFooterManager.SetDateTimeText("New date and time text"); // ustaw tekst w polu daty i czasu slajdu notatek
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Czy mogę dodać „nagłówek” do zwykłych slajdów?**

W programie PowerPoint „nagłówek” istnieje tylko w notatkach i wersjach roboczych; na zwykłych slajdach obsługiwane elementy to stopka, data/godzina oraz numer slajdu. W Aspose.Slides obowiązują te same ograniczenia: nagłówek tylko dla notatek/wersji roboczych, a na slajdach — stopka/data‑czas/numery slajdów.

**Co zrobić, jeśli układ nie zawiera obszaru stopki — czy mogę „włączyć” jej widoczność?**

Tak. Sprawdź widoczność za pomocą menedżera nagłówka/stopki i włącz ją w razie potrzeby. Te wskaźniki i metody API są przeznaczone do sytuacji, gdy pole jest brakujące lub ukryte.

**Jak ustawić, aby numeracja slajdów zaczynała się od wartości innej niż 1?**

Ustaw [pierwszy numer slajdu](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/firstslidenumber/) prezentacji; po tym wszystkie numery zostaną przeliczone. Na przykład możesz rozpocząć od 0 lub 10 oraz ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami podczas eksportu do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. Oznacza to, że jeśli elementy są widoczne na slajdach lub stronach notatek, pojawią się również w formacie wyjściowym wraz z resztą treści.