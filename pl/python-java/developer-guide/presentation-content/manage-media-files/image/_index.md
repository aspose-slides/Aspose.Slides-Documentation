---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/python-java/image/
keywords:
- dodaj obraz
- dodaj grafikę
- zamień obraz
- kolekcja obrazów
- ramka obrazu
- obraz łączony
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG do kształtów
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie wykorzystywać, łączyć, zamieniać i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez Javę."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java udostępnia kilka sposobów pracy z obrazami, przy czym każdy z nich służy innemu celowi. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać jako tła slajdu, łączyć się z zewnętrznym obrazem, zamienić współdzielony zasób obrazu lub skonwertować zawartość SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazów i ich użyciu w prezentacji. Aby uzyskać informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatowaniach stosowanych do pojedynczej ramki obrazu, zobacz [Ramka obrazu](/slides/pl/python-java/picture-frame/).

## **Zrozumienie modelu obrazu**

Poniższe pojęcia API są ze sobą ściśle powiązane, ale nie są wymienne:

- The [kolekcja obrazów prezentacji](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/) przechowuje zasoby obrazów używane w prezentacji. Użyj [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage), aby dodać dane obrazu i uzyskać zasób [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/).
- A [ramka obrazu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) jest kształtem, który wyświetla obraz na slajdzie, układzie lub szablonie. Użyj [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addPictureFrame), aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. W związku z tym nie zachowuje się jak ramka obrazu.
- [PPImage.replaceImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#replaceImage) zamienia zasób obrazu. Jeśli kilka elementów prezentacji korzysta z tego zasobu, wszystkie używają zamiany.
- Konwersja SVG na kształty tworzy edytowalne kształty slajdu. Po konwersji zawartość nie jest już zarządzana jako pojedynczy zasób obrazu.

Typowy przepływ pracy wygląda więc następująco: dodaj dane obrazu do kolekcji obrazów, otrzymaj [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/), a następnie użyj tego zasobu w jednej lub kilku ramkach obrazu lub wypełnieniach.

## **Dodanie osadzonego obrazu**

Aby wstawić lokalny obraz, załaduj plik, dodaj go do kolekcji obrazów i utwórz ramkę obrazu, która używa zwróconego [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Obraz dodany w ten sposób jest osadzony w prezentacji, więc wynikowy plik nie zależy od dostępności oryginalnego pliku obrazu.

### **Dodaj obraz z sieci**

Gdy obraz jest dostępny przez HTTP lub HTTPS, pobierz jego bajty, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu w taki sam sposób, jak przy obrazie lokalnym.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W aplikacjach o długim czasie działania, ponownie używaj klienta HTTP lub strategii zarządzania połączeniami odpowiedniej dla aplikacji, zamiast wielokrotnie tworzyć niepotrzebną infrastrukturę sieciową. Zawsze również weryfikuj zdalne adresy URL, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane.

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny więcej niż raz, dodaj go do prezentacji jednokrotnie i ponownie użyj otrzymanego [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) przy tworzeniu kolejnych ramek obrazu. Dzięki temu unikasz wielokrotnego ładowania tych samych danych źródłowych i wyraźnie określasz związek między współdzielonym zasobem obrazu a jego użyciem.

Dla grafik, które powinny pojawiać się automatycznie na wielu slajdach, takich jak logo firmy, rozważ umieszczenie ramki obrazu na [szablonie slajdu](/slides/pl/python-java/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użycie obrazu jako tło slajdu**

Obraz tła jest przypisywany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz powinien pokrywać tło slajdu i nie powinien być manipulowany jak zwykły obiekt slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby uzyskać dodatkowe opcje tła, w tym tła szablonów i układów, zobacz [Tło prezentacji](/slides/pl/python-java/presentation-background/).

## **Obrazy osadzone i obrazy łączone**

Obrazy osadzone i obrazy łączone mają różne kompromisy pod względem przenośności i rozmiaru pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku obejmuje dane obrazu.
- **Obraz łączony:** prezentacja przechowuje ścieżkę lub URL do zewnętrznego obrazu. To może zmniejszyć rozmiar prezentacji, ale zewnętrzny zasób musi pozostać dostępny, gdy prezentacja jest otwierana lub renderowana.

Obraz łączony można utworzyć, przypisując zewnętrzną ścieżkę lub URL za pomocą [Picture.setLinkPathLong](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#setLinkPathLong) zamiast osadzania danych obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Używaj obrazów łączonych tylko wtedy, gdy środowisko wdrożeniowe może niezawodnie uzyskać dostęp do zewnętrznego zasobu. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, więc może być przydatny dla ikon, diagramów i innych grafik, które powinny skalować się bez utraty szczegółów charakterystycznych dla obrazów rastrowych. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/), dodaj go do kolekcji obrazów i umieść wynikowy zasób obrazu w ramce obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pliki SVG z zasobami zewnętrznymi**

SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W takich przypadkach [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/) udostępnia konstruktory przyjmujące [ExternalResourceResolver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/externalresourceresolver/) oraz bazowy URI. Resolver może mapować względny URI na dozwolony bezwzględny URI i zwracać strumień żądanego zasobu.

Resolver udostępnia zasoby zewnętrzne podczas przetwarzania SVG przez Aspose.Slides, ale nie przepisuje SVG na dokument samodzielny. Jeśli SVG ma pozostać przenośny, osadź wymagane zasoby bezpośrednio w SVG, na przykład używając adresów `data:` dla obrazów łączonych.

Gdy pliki SVG pochodzą z niewiarygodnych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może uzyskać dostęp. Rozwiązania sieciowe powinny także stosować limity czasu, ograniczenia rozmiaru odpowiedzi oraz walidację treści.

### **Konwersja SVG do edytowalnych kształtów**

Aspose.Slides może konwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiadające polecenie w PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Użyj przeciążenia [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addGroupShape), które przyjmuje [SvgImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgimage/), aby wykonać konwersję.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Używaj konwersji SVG‑do‑kształtów, gdy poszczególne elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być jedynie wyświetlany, pozostawienie go jako obrazu jest prostsze i nie wymaga tworzenia wielu oddzielnych kształtów.

## **Zastąpienie istniejącego zasobu obrazu**

Użyj [PPImage.replaceImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#replaceImage), gdy chcesz zamienić istniejący zasób obrazu. Jest to szczególnie przydatne w przypadku współdzielonych grafik, takich jak logotypy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jeśli wiele ramek obrazu, tła, szablonów lub układów używa tego samego zasobu obrazu, jego zamiana aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę obrazu, przypisz inny obraz do tej ramki zamiast zastępować współdzielony zasób.

[PPImage.replaceImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#replaceImage) udostępnia także przeciążenia przyjmujące tablicę bajtów lub inny [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/).

## **Praktyczne wskazówki zarządzania obrazami**

### **Kontrola rozmiaru prezentacji**

Duże obrazy rastrowe mogą niepotrzebnie zwiększać rozmiar prezentacji. Używaj obrazów źródłowych o wymiarach odpowiednich do zamierzonego rozmiaru wyświetlania, ponownie wykorzystuj współdzielone zasoby obrazów, gdzie to możliwe, i unikaj osadzania wielokrotnych kopii tego samego grafiki w pełnej rozdzielczości.

Dla obrazów rastrowych już umieszczonych w ramkach obrazu, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#compressImage) może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycinania. To jest przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Ramka obrazu](/slides/pl/python-java/picture-frame/) po związane operacje formatowania.

### **Wybór między treścią osadzoną a łączoną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie wymagane dane obrazu podróżują razem z plikiem. Łączenie może zmniejszyć rozmiar pliku, ale wprowadza zależność zewnętrzną. Używaj łączy tylko wtedy, gdy ta zależność jest akceptowalna i stabilna.

### **Ponowne wykorzystanie wspólnej identyfikacji marki**

W przypadku powtarzających się logotypów, znaków wodnych lub grafik dekoracyjnych, użyj jednego zasobu obrazu i ponownie go wykorzystaj. Jeśli grafika należy do projektu prezentacji, a nie do treści slajdu, umieść ją na szablonie lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymanie zasobów SVG w formie przenośnej**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania konsekwentnie niż SVG zależny od plików zewnętrznych lub zasobów sieciowych. Gdy to możliwe, osadź wymagane zasoby przed importem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Użycie nowoczesnego, wieloplatformowego API obrazu**

W nowym kodzie Python via Java używaj wieloplatformowych obiektów obrazu Aspose.Slides oraz API [Images](https://reference.aspose.com/slides/pl/python-java/aspose.slides/images/) zamiast przestarzałego publicznego API opartego na `java.awt.image.BufferedImage`. Zobacz [Nowoczesne API](/slides/pl/python-java/modern-api/) po wskazówki migracyjne.

WMF i EMF wymagają specjalnego traktowania. Kiedy te formaty są przekazywane przez wieloplatformowy obiekt obrazu, [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage) konwertuje metaplikę na reprezentację rastrową PNG przed wstawieniem. Jeśli zachowanie danych metapliku jest istotne, użyj przeciążenia opartego na strumieniu [ImageCollection.addImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/#addImage). Generowanie zawartości EMF z arkuszy kalkulacyjnych lub innych produktów jest osobnym procesem integracyjnym i wykracza poza zakres tego artykułu.

## **FAQ**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje współdzielone zasoby obrazów. Ramka obrazu jest kształtem slajdu, który wyświetla jeden z tych zasobów i zapewnia formatowanie specyficzne dla obrazu, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób na zastąpienie tego samego logotypu wszędzie?**

Jeśli logotyp jest już udostępniony jako jeden zasób obrazu, zamień ten zasób przy użyciu [PPImage.replaceImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#replaceImage). Dla branding’u obejmującego całą prezentację, umieszczenie logotypu na szablonie lub układzie także zmniejsza duplikację treści slajdów.

**Dlaczego łączony obraz znika na innym komputerze?**

Łączony obraz zależy od zewnętrznego pliku lub URL. Jeśli ten zasób nie jest dostępny z innego komputera, łączony obraz może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG można edytować jako kształty PowerPoint?**

Tak. Konwertuj SVG przy użyciu [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addGroupShape); wynikowa grupa zawiera edytowalne kształty slajdu zamiast jednego obrazu SVG.

**Jak mogę utrzymać prezentacje z wieloma obrazami w mniejszym rozmiarze?**

Ponownie wykorzystuj współdzielone zasoby obrazów, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w miarę potrzeb, utrzymuj powtarzający się branding na szablonach lub układach oraz używaj łączonych obrazów tylko wtedy, gdy zależność zewnętrzna jest akceptowalna.