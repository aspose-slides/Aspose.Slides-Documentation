---
title: Klonowanie slajdów prezentacji w C++
linktitle: Klonuj slajdy
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
description: "Szybko duplikuj slajdy PowerPoint przy użyciu Aspose.Slides for C++. Skorzystaj z naszych klarownych przykładów kodu, aby w kilka sekund zautomatyzować tworzenie prezentacji PPT i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie jest procesem tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for C++ umożliwia także wykonanie kopii lub klonu dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub dowolnej innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innym miejscu w prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie w określonym miejscu w innej prezentacji.

W Aspose.Slides for C++, (kolekcja obiektów [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) ) udostępniana przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zapewnia metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) i [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/), które umożliwiają wykonanie powyższych rodzajów klonowania slajdów.

## **Klonowanie slajdu na końcu prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Zainstancjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) odwołując się do kolekcji Slides udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
3. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnianą przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd do sklonowania jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
4. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Klonowanie slajdu w innym miejscu w prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innym miejscu, użyj metody [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Zainstancjuj klasę, odwołując się do kolekcji **Slides** udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
3. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/) udostępnianą przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie zero – pozycja 1 – w prezentacji) na indeks 1 – pozycja 2 – w prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Klonowanie slajdu na końcu innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej docelową prezentację, do której slajd zostanie dodany.
3. Zainstancjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) odwołując się do kolekcji **Slides** udostępnianej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnianą przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd z prezentacji źródłowej jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec prezentacji docelowej.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonowanie slajdu w innym miejscu w innej prezentacji**
Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej prezentacji, w określonym miejscu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację, do której slajd zostanie dodany.
3. Zainstancjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) odwołując się do kolekcji Slides udostępnianej przez obiekt Presentation docelowej prezentacji.
4. Wywołaj metodę [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/) udostępnianą przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/insertclone/).
5. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) na indeks 1 (pozycja 2) w prezentacji docelowej.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Klonowanie slajdu w określonym miejscu w innej prezentacji**
Jeśli potrzebujesz sklonować slajd wraz z masterem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master ze źródła do prezentacji docelowej. Następnie użyj tego mastera do klonowania slajdu z masterem. Metoda **AddClone(ISlide, IMasterSlide)** oczekuje mastera z prezentacji docelowej, a nie z źródłowej. Aby sklonować slajd z masterem, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację źródłową, z której slajd zostanie sklonowany.
2. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) zawierającej prezentację docelową, do której slajd zostanie sklonowany.
3. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z jego masterem.
4. Zainstancjuj klasę [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/) odwołując się do kolekcji Masters udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) prezentacji docelowej.
5. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnianą przez obiekt [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/) i przekaż master z pliku PPTX źródłowego jako parametr do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
6. Zainstancjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) ustawiając odniesienie do kolekcji Slides udostępnianej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) prezentacji docelowej.
7. Wywołaj metodę [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnianą przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) i przekaż slajd z prezentacji źródłowej oraz master jako parametry do metody [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).
8. Zapisz zmodyfikowany plik prezentacji docelowej.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zero w prezentacji źródłowej) na koniec prezentacji docelowej, używając mastera ze slajdu źródłowego.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Klonowanie slajdu na końcu określonej sekcji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, ale w innej sekcji, użyj metody [**AddClone()**](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) udostępnianej przez interfejs [**ISlideCollection**](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ umożliwia sklonowanie slajdu z pierwszej sekcji i wstawienie go do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić go do określonej sekcji.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Zapewnienie dopasowanego rozmiaru slajdu**

Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów różnią się, Aspose.Slides nie przeskalowuje automatycznie sklonowanych kształtów – ich pierwotne współrzędne i wymiary pozostają zachowane, co może spowodować nieprawidłowe wyrównanie treści lub jej wyjście poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby odpowiadał rozmiarowi źródłowemu przed klonowaniem mastera i slajdu:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Zrób to przed klonowaniem mastera i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona notatek i komentarze recenzji są włączone do klonu. Jeśli ich nie chcesz, [usuń je](/slides/pl/cpp/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i osadzone dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. zeszytem osadzonym jako OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/cpp/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/cpp/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś slajd do niej.