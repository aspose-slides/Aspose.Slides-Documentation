---
title: Zarządzaj efektami transformacji obrazu w prezentacjach przy użyciu Pythona
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/python-net/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- odcienie szarości
- dwutonowy
- odcień
- HSL
- zamiana koloru
- rozmycie
- przezroczystość
- efekt alfa
- łańcuch efektów
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zastosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Aspose.Slides przedstawia regulacje obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu, rozpocznij od [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) i uzyskaj jej właściwość [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). Zwrócona [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) pozwala dodawać, wyliczać, przeglądać, usuwać i czyścić efekty bez przepisywania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przeźroczystości, uporządkowanych łańcuchów efektów, wartości skutecznych, usuwania oraz weryfikacji cyklu PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlający go są różnymi obiektami:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) przechowuje lub odwołuje się do danych obrazu źródłowego będących własnością prezentacji.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia oraz inne formatowanie na poziomie ramki.

W związku z tym operacje transformacji obrazu nie modyfikują bajtów w [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Gdy ten sam `PPImage` jest przekazywany do [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) więcej niż raz, każdy nowy frame obrazu otrzymuje własny `Picture` i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie powoduje, że pozostałe ramki również będą w odcieniach szarości, mimo że wszystkie korzystają z tego samego wbudowanego zasobu obrazu.

Ten sam model `Picture.image_transform` jest również używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramkach obrazu.

## **Używanie prawidłowych zakresów parametrów i jednostek**

Prezentowane metody używają następujących zakresów semantycznych i jednostek. Trzymaj wartości w tych zakresach, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej wartości spoza zakresu; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub gdy PowerPoint otwiera plik.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmienionym. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa używają wartości od `0` do `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Barwa (`hue`) jest od `0` (włącznie) do `360` (wyłącznie), w stopniach; ilość (`amount`) od `-100` do `100`, procent. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Barwa (`hue`) od `0` (włącznie) do `360` (wyłącznie), w stopniach; nasycenie (`saturation`) i luminancja (`luminance`) od `-100` do `100`, procent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Kolor zastępczy używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Promień jest nieujemny i mierzy się w punktach; `grow` jest wartością logiczną sterującą, czy rozmyta zawartość może wyjść poza pierwotne granice. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Procent nieujemny. Użyj `0` do `100` dla zwykłego skalowania nieprzezroczystości: `0` oznacza całkowitą przezroczystość, a `100` zachowuje istniejącą alfę. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35% przezroczystości odpowiada wartości modulacji alfa 65%.

## **Zastosowanie jasności i kontrastu**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) zwraca operację [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Jej ustawienia skalarne są podawane podczas tworzenia operacji. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) zwraca obliczone wartości tylko do odczytu, które można przeglądać lub logować.

Poniższy przykład zwiększa jasność o 15% i kontrast o 20%, po czym renderuje podgląd bez modyfikacji osadzonego obrazu:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po cyklu PPTX, użyj [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę szczegółowo.

## **Zastosowanie transformacji kolorów**

Efekty kolorów mogą być stosowane niezależnie do różnych ramek obrazu, które wykorzystują ten sam zasób obrazu. Poniższy przykład tworzy pięć ramek i stosuje odcienie szarości, duotone, tint, korektę HSL oraz zamianę koloru.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, natomiast `color2` mapuje jasne piksele. To czyni go przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) zastępuje kolor każdego piksela jedną stałą barwą, zachowując alfa. Jest inny niż [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), który mapuje jeden kolor źródłowy na inny i udostępnia formaty zarówno koloru źródłowego, jak i docelowego.

### **Zastosowanie progu luminancji**

Próg luminancji może ułatwić rozróżnienie słabych znaków na zeskanowanej stronie od tła. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) zachowuje pośrednie odcienie szarości. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) mapuje luminancję na czarny lub biały, podczas gdy [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) stosuje próg do nieprzezroczystości.

Próg luminancji mieści się w przedziale od 0% do 100%, włącznie. Piksele poniżej progu stają się czarne. Piksele równi lub powyżej progu stają się białe. Podniesienie progu sprawia, że więcej odcieni staje się czarnych, ponieważ więcej z nich spada poniżej granicy.

Pobierz [grayscale-swatches.png](grayscale-swatches.png) do katalogu roboczego. Każda etykieta podaje oryginalny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Otwórz wygenerowaną prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona 96 ma około 38% luminancji (96 z 255). Staje się biała przy progu 20% i czarna przy progu 60%.

![Oryginalne próbki w odcieniach szarości obok wyników czarno-białych przy progach luminancji 20% i 60%](luminance-threshold.png)

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `True`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Dla jednolitej przezroczystości użyj [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Mnoży on każdą istniejącą wartość alfa, dzięki czemu częściowo przezroczyste piksele pozostają proporcjonalnie różne. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) zamiast tego przypisuje jedną wartość alfa wszystkim pikselom. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) przekształca alfę na dwa poziomy na podstawie progu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Inne operacje alfa bez parametrów obejmują [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), które sprawiają, że każda niezerowa alfa jest w pełni nieprzezroczysta; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), które sprawiają, że każda alfa poniżej 100% jest w pełni przezroczysta; oraz [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), które zmienia alfę na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `add_..._effect` dodaje nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wynik operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą wygenerować inny obraz.

Na przykład odcienie szarości po tint najpierw usuwa informacje chromatyczne, a potem ponownie koloruje wynik luminancji. Tint po odcieniach szarości usuwa tint ponownie. Podobnie, zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, oraz renderuje ponownie otwarty wynik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

Kolekcja nie narzuca macierzy kompatybilności ograniczającej operacje koloru, alfa i rozmycia do oddzielnych łańcuchów. Mogą być łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariację RGB wygenerowaną przez wcześniejsze efekty kolorów; odcienie szarości po duotone usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement czy bi-level mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, zamiast traktować jego elementy jako nieuporządkowane flagi formatowania.

<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi najpierw przez odcienie szarości, potem tint, oraz tint najpierw, potem odcienie szarości. Dwa końcowe obrazy w odcieniach szarości mają różne tony.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*W tym ilustracyjnym renderze Aspose.Slides dla .NET 26.11, tint 220° przy 25% pozostawia obraz w odcieniach szarości niezmieniony. Zastosowanie tego samego tinu przed odcieniami szarości powoduje różne tony.*  
<!-- visual-explanation:image-transform-effects:end -->

## **Inspekcja wartości edytowalnych i skutecznych**

Operacja edytowalna to obiekt przechowywany w `Picture.image_transform`. W zależności od efektu może ona bezpośrednio udostępniać zapisywalne członki. Na przykład [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) udostępnia zapisywalne właściwości `radius` i `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) udostępnia zapisywalną właściwość `amount`, a [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) udostępnia zapisywalną właściwość `threshold`. Efekty kolorów, takie jak [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/), udostępniają mutowalne obiekty [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/).

Niektóre operacje, w tym [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/) i [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), nie udostępniają swoich parametrów tworzenia jako zapisywalne właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane skuteczne zwracane przez `get_effective()` są obliczane i tylko do odczytu. Są przydatne do rozwiązywania kolorów zależnych od motywu oraz odczytu znormalizowanych wartości używanych przez renderer, ale nie są kolejną powierzchnią edycji. Poniższy przykład wylicza łańcuch i przegląda wartości skuteczne, gdzie odpowiednie API je udostępnia:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Efekty bez parametrów, takie jak odcienie szarości, alpha ceiling i alpha inverse, nadal mają obiekt danych skutecznych, ale nie ma skalarnych ustawień do wydrukowania. Ich obecność i pozycja w kolekcji są istotnymi informacjami.

## **Usuwanie lub czyszczenie transformacji obrazu**

Użyj [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/), aby usunąć jedną operację według indeksu. Ponieważ indeksy zmieniają się po usunięciu, najpierw znajdź docelową operację, a następnie usuń ją po wyliczeniu. Użyj `clear()`, aby usunąć cały łańcuch.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Usuwanie lub czyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie rekompresuje ani nie zmienia w żaden inny sposób ponownie używanego zasobu [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, dlatego PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet w PPTX nie wszystkie operacje mają taką samą przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duotone, tint, HSL, rozmycie i typowe operacje alfa, mają największą szansę przetrwać cykl PPTX. Zawsze ponownie otwórz wygenerowany plik i sprawdź kolekcję, gdy zachowanie jest wymagane.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że pozostanie edytowalną operacją `BrightnessContrast` po zapisaniu i ponownym otwarciu PPTX. Preferuj [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT powstał przed pełnym modelem efektów DrawingML. Zapis do PPT może pomijać nieobsługiwane operacje, redukować łańcuch do obsługiwanego podzbioru lub przybliżać wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innego wyjścia wizualnego stosuje obsługiwany łańcuch do wyglądu renderowanego. Te wyjścia nie zawierają edytowalnej `ImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów lub wektorów przechowują własną reprezentację renderowania.
- Efekty nie sprawiają, że obraz powiązany staje się samodzielny. Renderowanie powiązanego obrazu nadal zależy od dostępności powiązanego zasobu podczas ładowania prezentacji.

Różni odbiorcy prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są liczne operacje alfa lub kwantyzacji koloru. Dla krytycznych wyników przetestuj zarówno edytowalny cykl, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides stosowanej w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do `Picture` używanego w wypełnieniu obrazu. Bajty podstawowego `PPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które ponownie używają tego samego obrazu, będą współdzielić swoje efekty?**

Nie. Ponowne użycie `PPImage` unika duplikowania danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny `Picture` i kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa można łączyć?**

Tak. Kolekcja akceptuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości skuteczne są tylko do odczytu?**

Dane skuteczne reprezentują obliczone wartości używane do renderowania, w tym rozpoznane kolory. Edytuj operację przechowywaną w kolekcji transformacji tam, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jakiego formatu powinienem używać, aby zachować łańcuch transformacji?**

Używaj PPTX i zweryfikuj plik przez ponowne otwarcie. Starszy format PPT nie może odzwierciedlić pełnego modelu efektów DrawingML, a formaty eksportu renderowanego zachowują jedynie wygląd, a nie edytowalne operacje transformacji.