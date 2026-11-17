---
title: Zarządzanie efektami transformacji obrazu w prezentacjach przy użyciu Pythona
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/python-java/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- odcienie szarości
- duoton
- tonacja
- HSL
- zastąpienie koloru
- rozmycie
- przezroczystość
- efekt alfa
- łańcuch efektów
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla Pythona przez Javę."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu, rozpocznij od ramki [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) i uzyskaj dostęp do [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). Zwrócona [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) umożliwia dodawanie, wyliczanie, przeglądanie, usuwanie i czyszczenie efektów bez przepisania oryginalnych bajtów obrazu.

Ten artykuł prezentuje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji pełnego cyklu PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obrazek, który go wyświetla, to różne obiekty:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) przechowuje lub odwołuje się do danych źródłowego obrazu należących do prezentacji.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) należy do wypełnienia obrazu i odnosi się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) to kształt slajdu, który własnościowo zarządza odpowiednim wypełnieniem obrazu, geometrią, ustawieniami przycięcia i innymi formatowaniami na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). Gdy ten sam `PPImage` zostanie przekazany do [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `Picture` i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie spowoduje, że pozostałe ramki będą również w odcieniach szarości, pomimo że wszystkie używają tego samego wbudowanego zasobu obrazu.

Ten sam model `Picture.getImageTransform` jest także używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Pokazane metody używają następujących zakresów semantycznych i jednostek. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej wartości spoza zakresu; format docelowej prezentacji może znormalizować, pominąć lub odrzucić nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | od `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Brak | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają wartości od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | `hue` od `0` (włącznie) do `360` (wyłącznie), w stopniach; `amount` od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | `hue` od `0` (włącznie) do `360` (wyłącznie), w stopniach; nasycenie i luminancja od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Kolor zastępujący używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Promień jest nieujemny i podawany w punktach; `grow` jest wartością logiczną określającą, czy rozmyta zawartość może wyjść poza pierwotne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Nieujemny procent. Użyj `0`‑`100` dla zwykłego skalowania nieprzezroczystości: `0` to całkowita przezroczystość, `100` zachowuje istniejącą alfę. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0`‑`100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0`‑`100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35 % przezroczystości odpowiada wartości modulacji alfa 65 %.

## **Zastosuj jasność i kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) zwraca operację [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). Jej ustawienia skalarne są podawane w momencie tworzenia operacji. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) zwraca obliczone wartości tylko do odczytu, które można przeglądać lub logować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji wbudowanego obrazu:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po pełnym cyklu PPTX, użyj [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosuj transformacje kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu ponownie wykorzystujących ten sam zasób obrazu. Poniższy przykład tworzy pięć ramek i stosuje kolejno odcienie szarości, duoton, tonację, regulację HSL oraz zamianę koloru.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, natomiast `color2` mapuje jasne piksele. To czyni go przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) zastępuje każdy piksel stałym kolorem, zachowując jednocześnie alfę. Różni się od [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), które mapuje jeden kolor źródłowy na inny i udostępnia oba formaty kolorów źródłowego i docelowego.

### **Zastosuj próg luminancji**

Próg luminancji może ułatwić odróżnienie słabych znaków na zeskanowanej stronie od tła. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) zachowuje pośrednie odcienie szarości. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) mapuje luminancję na czarny lub biały, podczas gdy [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) stosuje próg do nieprzezroczystości.

Próg luminancji mieści się w przedziale od 0 % do 100 % (łącznie). Piksele poniżej progu stają się czarne. Piksele równe lub powyżej progu stają się białe. Podniesienie progu powoduje, że więcej odcieni staje się czarnych, ponieważ więcej z nich spada poniżej progu.

Pobierz plik [grayscale-swatches.png](grayscale-swatches.png) do katalogu roboczego. Każda etykieta podaje oryginalny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otwórz wynikową prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona 96 ma około 38 % luminancji (96 z 255). Staje się biała przy progu 20 % i czarna przy progu 60 %.

![Oryginalne próbki odcieni szarości obok wyników czarno‑białych przy progach luminancji 20 % i 60 %](luminance-threshold.png)

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) działa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `True`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Dla jednolitej przezroczystości użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) zamiast tego przypisuje jedną wartość alfa wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) konwertuje alfę na dwa poziomy w oparciu o próg.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Inne operacje alfa bez parametrów obejmują [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), które sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), które sprawia, że każda alfa poniżej 100 % staje się w pełni przezroczysta; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), które zamienia alfę na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `add...Effect` dołącza nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład, odcienie szarości, a następnie tonacja najpierw usuwają informację chromatyczną, a potem kolorują wynik luminancji. Tonacja, a następnie odcienie szarości usuwa ponownie tonację. Podobnie, zamiana alfa może nadpisać wartości alfa wyliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, otwiera ponownie prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, a następnie renderuje wynik po ponownym otwarciu:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Kolekcja nie narzuca macierzy kompatybilności, która ograniczałaby operacje koloru, alfa i rozmycia do oddzielnych łańcuchów. Mogą być one łączone, ale nie zawsze jest to przydatne. Stała zamiana koloru usuwa wariacje RGB wygenerowane przez wcześniejsze efekty kolorystyczne; odcienie szarości po duotonie usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement lub bi‑level mogą odrzucić szczegóły alfy utworzone wcześniej. Buduj łańcuch zgodnie z pożądaną kolejnością przetwarzania pikseli, a nie jako nieuporządkowany zestaw flag formatowania.


<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi najpierw przez odcienie szarości, a potem odcień, i odwrotnie. Dwa ostateczne obrazy w odcieniach szarości mają różne tonacje.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*W tym ilustracyjnym renderze Aspose.Slides dla .NET 26.11, odcień 220° przy 25% nie zmienia obrazu w odcieniach szarości. Zastosowanie tego samego odcienia przed konwersją do szarości daje różne tonacje.*
<!-- visual-explanation:image-transform-effects:end -->

## **Sprawdź wartości edytowalne i efektywne**

Operacja edytowalna to obiekt przechowywany w `Picture.getImageTransform`. W zależności od efektu może ona udostępniać zapisywalne pola bezpośrednio. Na przykład, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) udostępnia zapisywalne wartości `radius` i `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) udostępnia zapisywalne `amount`, a [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) udostępnia zapisywalny `threshold`. Efekty kolorystyczne, takie jak [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/), udostępniają mutowalne obiekty [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/).

Niektóre klasy operacji, w tym [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/), oraz [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/), nie udostępniają swoich parametrów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zastępczą w wymaganej pozycji.

Dane efektywne zwracane przez `getEffective` są wyliczane i tylko do odczytu. Są przydatne przy rozwiązywaniu zależnych od motywu kolorów oraz odczytywaniu znormalizowanych wartości używanych przez renderer, ale nie stanowią kolejnej powierzchni edycyjnej. Poniższy przykład wylicza łańcuch i przegląda wartości efektywne tam, gdzie odpowiednie API je udostępnia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Efekty bez parametrów, takie jak odcienie szarości, alfa ceiling i alfa inverse, nadal posiadają obiekt danych efektywnych, ale nie mają skalarnych ustawień do wydrukowania. Ich obecność i pozycja w kolekcji to istotne informacje.

## **Usuń lub wyczyść transformacje obrazu**

Użyj [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt), aby usunąć jedną operację według indeksu. Ponieważ indeksy przesuwają się po usunięciu, najpierw odszukaj docelową operację, a potem usuń ją po wyliczeniu. Użyj [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear), aby usunąć cały łańcuch.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usuwanie lub czyszczenie transformacji zmienia wyłącznie formatowanie obrazu. Nie usuwa, nie kompresuje ani nie modyfikuje ponownie używanego zasobu [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, dlatego PPTX jest preferowanym edytowalnym formatem dla łańcuchów efektów. Nawet w PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duoton, tonacja, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwać pełny cykl PPTX. Zawsze otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymogiem.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że pozostanie edytowalnym [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) po zapisaniu i ponownym otwarciu PPTX. Preferuj [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) dla trwałych regulacji jasności i kontrastu.
- Binarny format PPT jest starszy niż pełny model efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacyjnego dla złożonych edytowalnych łańcuchów.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych formatów wizualnych stosuje obsługiwany łańcuch do wyglądu renderowanego. Te wyjścia nie zawierają edytowalnego `ImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią powiązanego obrazu samodzielnym. Renderowanie powiązanego obrazu nadal zależy od dostępności powiązanego zasobu podczas ładowania prezentacji.

Różni odbiorcy prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznych wyników przetestuj zarówno edytowalny cykl, jak i finalny format eksportu przy użyciu tej samej wersji Aspose.Slides, której używasz w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują wbudowane dane obrazu?**

Nie. Operacje należą do `Picture` używanego w wypełnieniu obrazu. Bajty podstawowego `PPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które ponownie wykorzystują ten sam obraz, będą współdzielić swoje efekty?**

Nie. Ponowne użycie `PPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny `Picture` i własną kolekcję transformacji obrazu.

**Czy efekty kolorów, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują wyliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji transformacji tam, gdzie istnieją zapisywalne pola; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem wybrać, aby zachować łańcuch transformacji?**

Użyj PPTX i zweryfikuj plik, otwierając go ponownie. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu wizualnego zachowują jedynie wygląd, a nie edytowalne operacje transformacji.