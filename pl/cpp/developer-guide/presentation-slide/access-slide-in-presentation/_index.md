---
title: Dostęp do slajdów prezentacji w C++
linktitle: Dostęp do slajdu
type: docs
weight: 20
url: /pl/cpp/access-slide-in-presentation/
keywords:
- dostęp do slajdu
- indeks slajdu
- identyfikator slajdu
- pozycja slajdu
- zmiana pozycji
- właściwości slajdu
- numer slajdu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak uzyskać dostęp i zarządzać slajdami w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Zwiększ wydajność dzięki przykładom kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać dostęp i zarządzać slajdami w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak pobrać slajdy według ich zerowego indeksu z kolekcji slajdów oraz jak uzyskać dostęp do slajdu po jego unikalnym identyfikatorze za pomocą metody `GetSlideById`.

Dowiesz się także, jak zmienić pozycję slajdu, używając metody `set_SlideNumber`, oraz jak określić początkowy numer slajdu w prezentacji przy pomocy metody `set_FirstSlideNumber`. Przykłady demonstrują wczytywanie prezentacji, uzyskiwanie referencji do slajdów, aktualizowanie kolejności lub numeracji slajdów oraz zapisywanie zmodyfikowanej prezentacji.

## **Dostęp do slajdu według indeksu**

Wszystkie slajdy w prezentacji są ułożone numerycznie w oparciu o pozycję slajdu, zaczynając od 0. Pierwszy slajd jest dostępny pod indeksem 0; drugi slajd pod indeksem 1; itp.

Klasa Presentation, reprezentująca plik prezentacji, udostępnia wszystkie slajdy jako kolekcję [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) (kolekcję obiektów [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/)). Ten kod w C++ pokazuje, jak uzyskać dostęp do slajdu za pośrednictwem jego indeksu: 

```c++
	// Ścieżka do katalogu z dokumentami.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Tworzy instancję klasy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Pobiera referencję do slajdu za pomocą jego indeksu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Dostęp do slajdu według identyfikatora**

Każdy slajd w prezentacji ma przypisany unikalny identyfikator. Możesz użyć metody [GetSlideById()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/getslidebyid/) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/)), aby odwołać się do tego identyfikatora. Ten kod w C++ pokazuje, jak podać prawidłowy identyfikator slajdu i uzyskać dostęp do tego slajdu za pomocą metody [GetSlideById()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Ścieżka do katalogu z dokumentami.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Tworzy instancję klasy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Pobiera identyfikator slajdu
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Uzyskuje dostęp do slajdu za pośrednictwem jego identyfikatora
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Zmienianie pozycji slajdu**

Aspose.Slides umożliwia zmianę pozycji slajdu. Na przykład możesz określić, że pierwszy slajd ma stać się drugim slajdem.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz referencję do slajdu (którego pozycję chcesz zmienić) za pomocą jego indeksu
1. Ustaw nową pozycję slajdu przy użyciu właściwości [set_SlideNumber()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/set_slidenumber/).
1. Zapisz zmodyfikowaną prezentację.

Ten kod w C++ demonstruje operację, w której slajd na pozycji 1 zostaje przeniesiony na pozycję 2:

```c++
	// Ścieżka do katalogu z dokumentami.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Tworzy instancję klasy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Pobiera slajd, którego pozycja zostanie zmieniona
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ustawia nową pozycję slajdu
	slide->set_SlideNumber(2);

	// Zapisuje zmodyfikowaną prezentację
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Pierwszy slajd stał się drugim; drugi slajd stał się pierwszym. Gdy zmieniasz pozycję slajdu, pozostałe slajdy są automatycznie dostosowywane.

## **Ustaw numer slajdu**

Korzystając z właściwości [set_FirstSlideNumber()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/set_firstslidenumber/) (udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/)), możesz określić nowy numer pierwszego slajdu w prezentacji. Ta operacja powoduje przeliczenie pozostałych numerów slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz numer slajdu.
1. Ustaw numer slajdu.
1. Zapisz zmodyfikowaną prezentację.

Ten kod w C++ demonstruje operację, w której numer pierwszego slajdu jest ustawiony na 10: 

```c++
	// Ścieżka do katalogu z dokumentami.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Tworzy instancję klasy Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Pobiera numer slajdu
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Ustawia numer slajdu
	pres->set_FirstSlideNumber(2);
	
	// Zapisuje zmodyfikowaną prezentację
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Jeśli chcesz pominąć pierwszy slajd, możesz rozpocząć numerację od drugiego slajdu (i ukryć numerację pierwszego slajdu) w ten sposób:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy numer slajdu widziany przez użytkownika odpowiada zerowemu indeksowi kolekcji?**

Numer wyświetlany na slajdzie może zaczynać się od dowolnej wartości (np. 10) i nie musi odpowiadać indeksowi; zależność jest kontrolowana przez ustawienie [pierwszego numeru slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/set_firstslidenumber/) w prezentacji.

**Czy ukryte slajdy wpływają na indeksowanie?**

Tak. Ukryty slajd pozostaje w kolekcji i jest liczony przy indeksowaniu; „ukryty” odnosi się do wyświetlania, a nie do jego pozycji w kolekcji.

**Czy indeks slajdu zmienia się, gdy dodawane lub usuwane są inne slajdy?**

Tak. Indeksy zawsze odzwierciedlają bieżącą kolejność slajdów i są przeliczane po operacjach wstawiania, usuwania i przenoszenia.