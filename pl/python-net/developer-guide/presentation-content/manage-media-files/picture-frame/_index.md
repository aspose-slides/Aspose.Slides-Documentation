---
title: Zarządzanie ramkami obrazu w prezentacjach przy użyciu Pythona
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/python-net/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- osadzony obraz
- powiązany obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- kompresuj obraz
- StretchOffset
- formatowanie ramki obrazu
- skala względna
- efekt obrazu
- proporcje obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach za pomocą Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu, który wyświetla obraz. W Aspose.Slides zasób obrazu i kształt go wyświetlający są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoją [ImageCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imagecollection/), podczas gdy [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany wielokrotnie. Dodaj obraz do prezentacji raz, zachowaj zwrócony [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG oraz obrazy wektorowe SVG. Mogą także odwoływać się do obrazów powiązanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany, zanim zastosuje się formatowanie lub optymalizację.

## **Dodaj i sformatuj osadzony obraz**

Dla obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy pomocy [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę w natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia oryginalnych wymiarów pikseli przechowywanych w zasobie obrazu osadzonego. Rozróżnienie to staje się istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użyj skali względnej**

[PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) udostępnia [relative_scale_width](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/relative_scale_width/) i [relative_scale_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/relative_scale_height/) dla ramki. Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skala względna jest przydatna, gdy proces wymaga zachowania proporcji względem rozmiaru źródłowego obrazu zamiast ręcznego obliczania wymiarów końcowych.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Skala względna zmienia ustawienia skali ramki; nie przetwarza ani nie kompresuje obrazu osadzonego.

## **Obrazy osadzone i powiązane**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod kątem przenośności i przewidywalnego renderowania. Obraz powiązany przechowuje zewnętrzną lokalizację za pomocą ścieżki linku [Picture](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picture/) zamiast osadzania danych obrazu w ten sam sposób.

Obrazy powiązane mogą zmniejszyć ilość danych obrazu przechowywaną w pliku PPTX, ale wprowadzają zależność zewnętrzną. Powiązany plik musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka ulegnie zmianie, plik zostanie przeniesiony lub zasób będzie niedostępny, powiązany obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodaj obraz powiązany**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy wyłącznie linkowania obrazów; linkowanie wideo jest osobnym przepływem mediów i celowo nie zostało wymieszane w tym przykładzie.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały plik PPTX z uszkodzonymi zależnościami obrazu jest zwykle mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest faktycznie [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) i czy zawiera osadzony obraz. Ramki obrazu powiązane mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/). Poniższy przykład znajduje pierwszy osadzony obraz rastrowy na slajdzie i zapisuje go jako PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Zapisywanie za pomocą [IImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iimage/) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj właściwości [PPImage.binary_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/binary_data/).

### **Wyodrębnij obraz SVG**

Dla obrazu SVG, [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) udostępnia obiekt [SvgImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/). Umożliwia to bezpośrednie pobranie danych SVG zamiast rasteryzacji obrazu najpierw.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło wewnątrz prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, koniecznie renderują tę zawartość wektorową do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako dokładna kopia osadzonego SVG; użyj osadzonego [SvgImage.svg_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/svg_data/) gdy wymagana jest oryginalna wektorowa zasoba.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [PictureFillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/) są procentami wymiarów obrazu źródłowego. Przycięcie nie usuwa początkowo ukrytych pikseli z obrazu osadzonego; zmienia jedynie widoczny obszar.

Poniższy przykład bezpiecznie znajduje ramkę obrazu i stosuje wartości przycięcia:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie można później zmienić bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte obszary można usunąć fizycznie, jak opisano w następnej sekcji.

## **Usuń przycięte dane obrazu**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) usuwa dane obrazu poza aktualnym prostokątem przycięcia i zwraca wynikowy zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne do późniejszej operacji odprzycinania.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie treści WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/compress_image/) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usuwać przycięte regiony w tej samej operacji. Metoda zwraca `True`, gdy obraz został zmieniony rozmiar lub przycięty, oraz `False`, gdy nie było konieczności żadnej zmiany.

Użyj zdefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/picturescompression/) gdy standardowa docelowa rozdzielczość jest wystarczająca:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Zamiast wartości wyliczeniowej można przekazać własną dodatnią wartość DPI, gdy wymagany jest konkretny cel.

Kompresja jest przeznaczona dla obrazów rastrowych. Zawartość SVG i metafili nie jest zmniejszana przez ten przepływ kompresji rastrowej. Pamiętaj także, że niższa rozdzielczość i usunięte przycięte regiony nie mogą zostać przywrócone z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie rzeczywiście oglądany lub eksportowany, zamiast stosować najniższe DPI globalnie.

## **Zarządzaj efektami transformacji obrazu**

Aby uzyskać kompletny przepływ obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy kolejności, inspekcję, usuwanie i weryfikację dwukierunkową, zobacz [Image Transform Effects](/slides/pl/python-net/image-transform-effects/).

## **Zablokuj geometrię ramki obrazu**

Ustawienia [PictureFrameLock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład właściwość [aspect_ratio_locked](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) zachowuje proporcje kształtu podczas zmiany jego rozmiaru.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona przetworzenia źródłowego obrazu ani trwałej zmiany jego proporcji.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset w [PictureFillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, a ujemne procenty tworzą występ.

Jest to inne niż przycinanie. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągnięte.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Używaj offsetów rozciągnięcia do rozmieszczania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i kwestie eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Obrazy osadzone** czynią prezentację samodzielną i są najniebezpieczniejsze przy udostępnianiu i renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy powiązane** mogą utrzymać paczkę mniejszą, ale prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo nie destrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną wyraźnie usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacznie zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale poświęca rozdzielczość źródła. Powinna być stosowana po określeniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać jako SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksport slajdu do formatu rastrowego zawsze konwertuje renderowany slajd na piksele.
- **Powtarzające się obrazy** powinny ponownie wykorzystywać istniejący zasób [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/), gdy to możliwe, zamiast wielokrotnie ładować ten sam plik w przepływie pracy prezentacji.

Dla dużych prezentacji optymalizacja obrazu jest zazwyczaj najskuteczniejsza, gdy jest stosowana selektywnie: zachowaj loga i diagramy jako treść wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) reprezentuje zasób obrazu powiązany z prezentacją. [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy linkować obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Linkuj obrazy tylko wtedy, gdy celowe jest przechowywanie plików obrazu poza PPTX i zewnętrzne lokalizacje mogą być utrzymywane niezawodnie.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podkładowe piksele. Użyj [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak należy obsługiwać obrazy SVG?**

Zachowuj treść SVG jako SVG, gdy istotna jest wierność wektora. Osadzony [SvgImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/svgimage/) można wyodrębnić bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczytywaniu istniejących slajdów?**

Sprawdź typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Użycie `isinstance(shape, slides.PictureFrame)` unika nieprawidłowych rzutowań i pozwala kodowi obsłużyć slajdy, które nie zawierają ramek obrazu.