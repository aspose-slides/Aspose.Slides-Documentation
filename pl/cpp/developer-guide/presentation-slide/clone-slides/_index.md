---
title: "Klonowanie slajdów prezentacji w C++"
linktitle: "Klonuj slajdy"
type: docs
weight: 40
url: /pl/cpp/clone-slides/
keywords:
- klonowanie slajdu
- kopiuj slajd
- zapisz slajd
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Szybko duplikuj slajdy PowerPoint przy użyciu Aspose.Slides for C++. Skorzystaj z naszych przejrzystych przykładów kodu, aby w kilka sekund zautomatyzować tworzenie PPT i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for C++ umożliwia również wykonanie kopii lub klonu dowolnego slajdu i wstawienie tego sklonowanego slajdu do bieżącej lub innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który można modyfikować bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innej pozycji w prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innej pozycji w innej prezentacji.
- Klonowanie w określonej pozycji w innej prezentacji.

W ramach Aspose.Slides for C++ (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/)) zapewnia metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) i [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/), które pozwalają wykonać opisane wyżej typy klonowania slajdów.

## **Klonowanie slajdu na końcu prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
3. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd do sklonowania jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
4. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – prezentacji) na koniec prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klonowanie slajdu w inną pozycję w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej pozycji, użyj metody [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Zainicjalizuj klasę, odwołując się do kolekcji **Slides** udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
3. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie zero – pozycja 1 – prezentacji) na indeks 1 – pozycję 2 – prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klonowanie slajdu na końcu innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację, z której slajd będzie klonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej docelową prezentację, do której slajd zostanie dodany.
3. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) odwołując się do kolekcji **Slides** udostępnionej przez obiekt Presentation prezentacji docelowej.
4. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd z prezentacji źródłowej jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
5. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec prezentacji docelowej.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonowanie slajdu w inną pozycję w innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej źródłową prezentację, z której slajd będzie klonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację, do której slajd zostanie dodany.
3. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation prezentacji docelowej.
4. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/).
5. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) na indeks 1 (pozycja 2) prezentacji docelowej.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonowanie slajdu w określonej pozycji w innej prezentacji**
Jeśli potrzebujesz sklonować slajd wraz z master slajdem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master slajd ze źródłowej prezentacji do prezentacji docelowej. Następnie użyj tego master slajdu do klonowania slajdu z masterem. Metoda **AddClone(ISlide, IMasterSlide)** oczekuje master slajd z prezentacji docelowej, a nie ze źródłowej. Aby sklonować slajd z masterem, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej źródłową prezentację, z której slajd będzie klonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację docelową, do której slajd zostanie sklonowany.
3. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z master slajdem.
4. Zainicjalizuj klasę [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) prezentacji docelowej.
5. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnioną przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/) i przekaż master z pliku PPTX źródłowego jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
6. Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) ustawiając odniesienie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) prezentacji docelowej.
7. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd z prezentacji źródłowej oraz master slajd jako parametry do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
8. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zero prezentacji źródłowej) na koniec prezentacji docelowej, używając mastera ze slajdu źródłowego.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klonowanie slajdu na końcu określonej sekcji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**AddClone()**](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnionej przez interfejs [**ISlideCollection**](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ umożliwia klonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić go do określonej sekcji.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona notatek i komentarze recenzenta są zawarte w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/cpp/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie oraz osadzone dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. skoroszytem OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/cpp/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje klonu?**

Tak. Możesz wstawić klon na określonym indeksie slajdu i umieścić go w wybranej [sekcji](/slides/pl/cpp/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a potem przenieś slajd do niej.