---
title: Zarządzaj ramkami obrazu w prezentacjach przy użyciu Pythona
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/python-java/picture-frame/
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
- skompresuj obraz
- StretchOffset
- formatowanie ramki obrazu
- skala względna
- efekt obrazu
- proporcje
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz, formatuj, linkuj, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Obrazek ramka jest kształtem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoją [ImageCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/), natomiast [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) steruje pozycją obrazu, rozmiarem, formatowaniem linii, obrotem, przycinaniem, efektami obrazu i innymi ustawieniami na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/), i używaj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą także odwoływać się do obrazów powiązanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany przed zastosowaniem formatowania lub optymalizacji.

## **Dodaj i sformatuj osadzony obraz**

Dla obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy użyciu [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addPictureFrame). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę w natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rama obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia pierwotnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to jest istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użyj skali względnej**

[PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) udostępnia względne skalowanie szerokości i wysokości ramki poprzez [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Wartość `1.0` odpowiada 100 % pierwotnego rozmiaru obrazu. Skala względna jest przydatna, gdy przepływ pracy wymaga zachowania stosunku do rozmiaru obrazu źródłowego zamiast ręcznego obliczania wymiarów końcowych.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Skala względna zmienia ustawienia skali ramki; nie powoduje przetworzenia ani kompresji osadzonego obrazu.

## **Obrazy osadzone i powiązane**

Obraz osadzony zapisuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Obraz powiązany przechowuje zewnętrzną lokalizację za pomocą metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#setLinkPathLong) zamiast osadzania danych obrazu w ten sam sposób.

Obrazy powiązane mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zewnętrzne zależności. Plik powiązany musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób będzie niedostępny, powiązany obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodaj obraz powiązany**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy wyłącznie powiązania obrazu; powiązanie wideo jest osobnym przepływem multimedialnym i celowo nie jest łączone w tym przykładzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały plik PPTX z uszkodzonymi zależnościami obrazu jest zazwyczaj mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Zanim wyodrębnisz obraz z istniejącej prezentacji, sprawdź, czy kształt jest rzeczywiście [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) i czy zawiera osadzony obraz. Powiązane ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazu współpracuje bezpośrednio z obrazami rastrowymi i nie wymaga starszego wrappera Java. Poniższy przykład znajduje pierwszy osadzony rastrowy obraz na slajdzie i zapisuje go jako PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Zapis rastrowego obrazu konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj danych binarnych zasobu obrazu.

### **Wyodrębnij obraz SVG**

W przypadku obrazu SVG, [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) udostępnia obiekt [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/). Dzięki temu możesz pobrać dane SVG bezpośrednio, zamiast rasteryzować obraz najpierw.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, muszą renderować tę treść wektorową do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako dokładna kopia oryginalnego osadzonego SVG; użyj danych [SvgImage.getSvgData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/#getSvgData), gdy wymagany jest sam wektorowy zasób.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [PictureFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie nie usuwa od razu ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład znajduje ramkę obrazu w sposób bezpieczny i stosuje wartości przycięcia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie można zmienić później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte obszary mogą być fizycznie usunięte, jak opisano w następnym sekcji.

## **Usuń przycięte dane obrazu**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) usuwa dane obrazu spoza bieżącego prostokąta przycięcia i zwraca powstały zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest destrukcyjną optymalizacją: po zapisaniu prezentacji usunięte piksele nie są już dostępne dla późniejszej operacji odprzycinania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest używany także przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie treści WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#compressImage) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte obszary w tej samej operacji. Metoda zwraca `True`, gdy obraz został zmieniony rozmiarem lub przycięty oraz `False`, gdy nie było konieczności żadnej zmiany.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturescompression/), gdy wystarcza standardowa docelowa rozdzielczość:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zamiast predefiniowanej wartości można podać własną dodatnią wartość DPI, gdy wymagany jest konkretny cel.

Kompresja jest przeznaczona dla obrazów rastrowych. Treść SVG i metaplików nie jest zmniejszana przez ten workflow kompresji rastrowej. Pamiętaj również, że niższa rozdzielczość i usunięte przycięte obszary nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie rzeczywiście oglądany lub eksportowany, a nie stosuj najniższego DPI globalnie.

## **Zarządzaj efektami transformacji obrazu**

Kompletny workflow obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy uporządkowane, inspekcję, usuwanie oraz weryfikację dwukierunkową znajdziesz w [Image Transform Effects](/slides/pl/python-java/image-transform-effects/).

## **Zablokuj geometrie ramki obrazu**

Ustawienia [PictureFrameLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) zachowuje proporcje kształtu podczas zmiany rozmiaru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona przetworzenia źródłowego obrazu ani trwałej zmiany proporcji.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset w [PictureFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, a ujemne procenty tworzą występ.

To różni się od przycinania. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Używaj offsetów rozciągnięcia do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i uwagi przy eksporcie**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Obrazy osadzone** czynią prezentację samodzielną i są najniebardziej niezawodne przy udostępnianiu oraz renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy powiązane** mogą utrzymać mniejszy rozmiar pakietu, ale prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo nie­destrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną explicite usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacznie zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródła. Powinna być stosowana po określeniu docelowego rozmiaru obrazu na slajdzie.
- **Obrazy SVG** powinny pozostać jako SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksporty slajdów do formatu rastrowego zawsze konwertują renderowany slajd do pikseli.
- **Powtarzające się obrazy** powinny ponownie używać istniejącego zasobu [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/), kiedy to możliwe, zamiast wielokrotnie ładować ten sam plik w przepływie pracy prezentacji.

W dużych prezentacjach optymalizacja obrazu jest najskuteczniejsza, gdy jest wykonywana selektywnie: utrzymuj logotypy i diagramy jako zawartość wektorową, kompresuj fotografie zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy dalsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) reprezentuje zasób obrazu powiązany z prezentacją. [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) jest kształtem na slajdzie wyświetlającym obraz i przechowuje geometrię oraz formatowanie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy powiązywać obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Powiązuj obrazy tylko wtedy, gdy celowe jest utrzymywanie plików obrazu poza PPTX i miejsca zewnętrzne mogą być niezawodnie utrzymywane.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podkład pikseli. Użyj [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak należy postępować z obrazami SVG?**

Trzymaj treść SVG jako SVG, gdy liczy się wierność wektora. Osadzony [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego takiego jak PNG lub JPEG rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczycie istniejących slajdów?**

Sprawdź typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Kontrola `isinstance` względem [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) zapobiega nieprawidłowym rzutowaniom i pozwala kodowi obsłużyć slajdy, które nie zawierają ramek obrazu.