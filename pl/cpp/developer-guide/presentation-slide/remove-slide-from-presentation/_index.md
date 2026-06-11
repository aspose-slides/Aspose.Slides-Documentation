---
title: Usuwanie slajdów z prezentacji w C++
linktitle: Usuń slajd
type: docs
weight: 30
url: /pl/cpp/remove-slide-from-presentation/
keywords:
- usuń slajd
- usuń slajd
- usuń nieużywany slajd
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Bezproblemowo usuń slajdy z prezentacji PowerPoint i OpenDocument za pomocą Aspose.Slides dla C++. Uzyskaj przejrzyste przykłady kodu i zwiększ wydajność swojego przepływu pracy."
---
## **Wprowadzenie**

Jeśli slajd (lub jego zawartość) stanie się zbędny, możesz go usunąć. Aspose.Slides udostępnia klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) , która enkapsuluje [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) , będące repozytorium wszystkich slajdów w prezentacji. Korzystając z wskaźników (referencji lub indeksu) do znanego obiektu [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) , możesz określić slajd, który chcesz usunąć. 

## **Usuwanie slajdu przez referencję**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj referencję do slajdu, który chcesz usunąć, poprzez jego ID lub indeks.
1. Usuń referencyjny slajd z prezentacji.
1. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ pokazuje, jak usunąć slajd poprzez jego referencję: 

```c++
	// Ścieżka do katalogu dokumentów
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Dostęp do slajdu przez jego indeks w kolekcji slajdów
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Usuwa slajd za pomocą jego referencji
	pres->get_Slides()->Remove(slide);

	// Zapisuje zmodyfikowaną prezentację
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Usuwanie slajdu po indeksie**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Usuń slajd z prezentacji za pomocą jego pozycji indeksowej.
1. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ pokazuje, jak usunąć slajd przez jego indeks: 

```c++
	// Ścieżka do katalogu dokumentów
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Usuwa slajd za pomocą jego indeksu
	pres->get_Slides()->RemoveAt(0);

	// Zapisuje zmodyfikowaną prezentację
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Usuwanie nieużywanych slajdów układu**

Aspose.Slides udostępnia metodę [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (z klasy [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) ) , aby umożliwić usunięcie niechcianych i nieużywanych slajdów układu. Ten kod C++ pokazuje, jak usunąć slajd układu z prezentacji PowerPoint: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Usuwanie nieużywanych slajdów master**

Aspose.Slides udostępnia metodę [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (z klasy [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) ) , aby umożliwić usunięcie niechcianych i nieużywanych slajdów master. Ten kod C++ pokazuje, jak usunąć slajd master z prezentacji PowerPoint: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Co się dzieje z indeksami slajdów po usunięciu slajdu?**

Po usunięciu, [kolekcja](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidecollection/) jest ponownie indeksowana: każdy kolejny slajd przesuwa się w lewo o jedną pozycję, więc poprzednie numery indeksów stają się nieaktualne. Jeśli potrzebujesz stabilnej referencji, użyj trwałego ID każdego slajdu zamiast jego indeksu.

**Czy ID slajdu różni się od jego indeksu i czy zmienia się, gdy usunięte zostaną sąsiednie slajdy?**

Tak. Indeks jest pozycją slajdu i zmieni się, gdy slajdy zostaną dodane lub usunięte. ID slajdu jest trwałym identyfikatorem i nie zmienia się, gdy usunięte zostaną inne slajdy.

**Jak usunięcie slajdu wpływa na sekcje slajdów?**

Jeśli slajd należał do sekcji, ta sekcja po prostu będzie zawierać o jeden slajd mniej. Struktura sekcji pozostaje; jeśli sekcja stanie się pusta, możesz [usunąć lub zreorganizować sekcje](/slides/pl/cpp/slide-section/) w razie potrzeby.

**Co się dzieje z notatkami i komentarzami dołączonymi do slajdu po jego usunięciu?**

[Notatki](/slides/pl/cpp/presentation-notes/) i [komentarze](/slides/pl/cpp/presentation-comments/) są powiązane z konkretnym slajdem i zostają usunięte wraz z nim. Zawartość innych slajdów pozostaje niezmieniona.

**Czym różni się usuwanie slajdów od czyszczenia nieużywanych układów/masterów?**

Usuwanie usuwa konkretne zwykłe slajdy z prezentacji. Czyszczenie nieużywanych układów/masterów usuwa slajdy układu lub master, do których nie odwołuje się nic, zmniejszając rozmiar pliku bez zmiany pozostałej zawartości slajdów. Te działania są komplementarne: zazwyczaj najpierw usuwa się slajdy, a potem czyści nieużywane układy/mastery.