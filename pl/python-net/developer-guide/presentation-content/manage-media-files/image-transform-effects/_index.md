---
title: Zarządzanie efektami przekształceń obrazu w prezentacjach przy użyciu Pythona
linktitle: Efekty przekształceń obrazu
type: docs
weight: 11
url: /pl/python-net/image-transform-effects/
keywords:
- przekształcenie obrazu
- efekt obrazu
- jasność
- kontrast
- odcienie szarości
- duoton
- tonowanie
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
description: "Stosuj, łącz, sprawdzaj, usuwaj i weryfikuj efekty przekształceń obrazu dla ramek obrazów przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji przekształceń obrazu. Dla ramki obrazu zacznij od [Picture](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picture/) ramki i uzyskaj dostęp do jej właściwości [image_transform](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picture/image_transform/). Zwrócona [ImageTransformOperationCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/) pozwala dodawać, wyliczać, sprawdzać, usuwać i czyścić efekty bez przepisania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, przekształceń kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji „round‑trip” PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlany w ramce to różne obiekty:

- [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/) przechowuje lub odwołuje się do danych źródłowych obrazu będących własnością prezentacji.
- [Picture](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picture/) należy do wypełnienia obrazu i odnosi się do zasobu obrazu, jednocześnie przechowując kolekcję przekształceń obrazu.
- [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) to kształt slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje przekształcenia obrazu nie modyfikują bajtów w [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/). Gdy ten sam `PPImage` zostanie przekazany do [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_picture_frame/) więcej niż raz, każdy nowy ramka obrazu otrzymuje własny `Picture` i własną kolekcję przekształceń. Zastosowanie odcieni szarości do jednej ramki nie powoduje, że pozostałe ramki również stają się szare, mimo że wszystkie używają tego samego wbudowanego zasobu obrazu.

Ten sam model `Picture.image_transform` jest także używany przez inne wypełnienia obrazu, takie jak wypełnienie kształtu lub tła slajdu. Poniższe przykłady koncentrują się na ramkach obrazu.

## **Używanie prawidłowych zakresów parametrów i jednostek**

Demonstrowane metody korzystają z następujących semantycznych zakresów i jednostek. Utrzymuj wartości w tych zakresach, nawet jeśli konkretna wersja biblioteki nie odrzuca natychmiast każdej wartości poza zakresem; docelowy format prezentacji może znormalizować, pominąć lub odrzucić nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100`‑`100`, procent; `0` pozostawia komponent niezmieniony. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Brak | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [add_duotone_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa używają `0`‑`255`. |
| [add_tint_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Odcień `0` (włącznie)‑`360` (wyłącznie) stopni; ilość `-100`‑`100`, procent. |
| [add_hsl_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Odcień `0`‑`360` stopni; nasycenie i luminancja `-100`‑`100`, procent. |
| [add_color_replace_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Kolor zastępczy używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [add_blur_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Promień nieujemny, mierzony w punktach; `grow` to wartość logiczna określająca, czy rozmyta zawartość może wykraczać poza oryginalne granice. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Nieujemny procent. Użyj `0`‑`100` dla zwykłego skalowania nieprzezroczystości: `0` to w pełni przezroczyste, `100` zachowuje istniejącą alfy. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0`‑`100`, procent nieprzezroczystości. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0`‑`100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równi lub powyżej – nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35 % przezroczystości odpowiada wartości modulacji alfa 65 %.

## **Zastosowanie jasności i kontrastu**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) zwraca operację [BrightnessContrast](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/brightnesscontrast/). Jej skalarne ustawienia są podawane przy tworzeniu operacji. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) zwraca obliczone wartości tylko do odczytu, które można sprawdzić lub zalogować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikowania wbudowanego obrazu:

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

[BrightnessContrast](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po „round‑trip” PPTX, użyj [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosowanie przekształceń kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które używają tego samego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje kolejno odcienie szarości, duoton, tint, korektę HSL oraz zamianę koloru.

[Duotone](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/duotone/) zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, a `color2` mapuje jasne piksele. Dzięki temu jest przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

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

[add_color_replace_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) zastępuje każdy piksel stałym kolorem, zachowując alfa. Różni się od [add_color_change_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), który mapuje jeden kolor źródłowy na inny i udostępnia formaty zarówno koloru źródłowego, jak i docelowego.

## **Dodawanie rozmycia, przezroczystości i efektów alfa**

[add_blur_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) wpływa na wszystkie kanały kolorów, w tym alfy. Ustaw `grow` na `True`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Dla jednolitej przezroczystości użyj [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele zachowują proporcjonalne różnice. [add_alpha_replace_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) natomiast nadaje jedną wartość alfa wszystkim pikselom. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) konwertuje alfy na dwa poziomy w oparciu o próg.

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

Inne operacje alfa nie wymagające parametrów to [add_alpha_ceiling_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), które sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; [add_alpha_floor_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), które czyni każdą alę poniżej 100 % całkowicie przezroczystą; oraz [add_alpha_inverse_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), które zamienia alfa na `100% - alpha`.

## **Budowanie uporządkowanego łańcucha efektów**

Każda metoda `add_..._effect` dołącza nową operację na końcu kolekcji. Renderujący używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład odcienie szarości a potem tint najpierw usuwają informacje chromatyczne, a potem recolorują wynik luminancji. Tint a potem odcienie szarości usuwa tint ponownie. Podobnie zamiana alfa może nadpisać wartości alfa wyliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, otwiera prezentację ponownie, sprawdza zarówno typy operacji, jak i ich kolejność, oraz renderuje ponownie otwarty wynik:

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

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje kolorów, alfa i rozmycia do osobnych łańcuchów. Mogą być łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariancję RGB wytworzoną przez wcześniejsze efekty kolorystyczne; odcienie szarości po duotonie usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement czy bi‑level mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.

## **Sprawdzanie wartości edytowalnych i efektywnych**

Edytowalna operacja to obiekt przechowywany w `Picture.image_transform`. W zależności od efektu może ona udostępniać zapisywalne członki bezpośrednio. Na przykład [Blur](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/blur/) udostępnia zapisywalne właściwości `radius` i `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/alphamodulatefixed/) udostępnia zapisywalną właściwość `amount`, a [AlphaBiLevel](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/alphabilevel/) udostępnia zapisywalną właściwość `threshold`. Efekty kolorystyczne, takie jak [Duotone](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/duotone/), udostępniają mutowalne obiekty [ColorFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/colorformat/).

Niektóre operacje, w tym [BrightnessContrast](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/tint/) i [AlphaReplace](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/alphareplace/), nie udostępniają swoich skalarnych parametrów jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `get_effective()` są wyliczane i tylko do odczytu. Są przydatne do rozwiązywania zależności od motywu i odczytywania znormalizowanych wartości używanych przez renderer, ale nie stanowią dodatkowej powierzchni edycji. Poniższy przykład wylicza łańcuch i sprawdza wartości efektywne tam, gdzie odpowiednie API je udostępnia:

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

Efekty bez parametrów, takie jak odcienie szarości, alpha ceiling i alpha inverse, mają nadal obiekt danych efektywnych, ale nie ma skalarnych ustawień do wypisania. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuwanie lub czyszczenie przekształceń obrazu**

Użyj [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) aby usunąć jedną operację według indeksu. Ponieważ indeksy przesuwają się po usunięciu, najpierw znajdź docelowy element, a potem usuń go po wyliczeniu. Użyj `clear()` aby usunąć cały łańcuch.

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

Usuwanie lub czyszczenie przekształceń zmienia wyłącznie formatowanie obrazu. Nie usuwa, nie rekompresuje ani nie modyfikuje ponownie używanego zasobu [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/).

## **Rozważanie formatów prezentacji i docelowych eksportów**

Przekształcenia obrazu pochodzą z DrawingML, dlatego PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet w PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duoton, tint, HSL, rozmycie i typowe operacje alfa, mają największą szansę przetrwania „round‑trip” PPTX. Zawsze otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymogiem.
- [BrightnessContrast](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że po zapisaniu i ponownym otwarciu PPTX pozostanie edytowalnym operacją `BrightnessContrast`. Preferuj [add_luminance_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT jest starszy niż pełny model efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych formatów wizualnych stosuje obsługiwany łańcuch do wyglądu wynikowego. Te wyjścia nie zawierają edytowalnej `ImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów lub wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią połączonego obrazu samodzielnym. Renderowanie połączonego obrazu nadal wymaga dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są kilka operacji alfa lub kwantyzacji kolorów. Dla krytycznych rezultatów testuj zarówno edytowalny „round‑trip”, jak i końcowy format eksportu przy użyciu tej samej wersji Aspose.Slides, co w produkcji.

## **FAQ**

**Czy efekty przekształcenia obrazu modyfikują wbudowane dane obrazu?**

Nie. Operacje należą do `Picture` używanego w wypełnieniu obrazu. Bajty podstawowego `PPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które używają tego samego obrazu, współdzielą swoje efekty?**

Nie. Ponowne użycie `PPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny `Picture` i własną kolekcję przekształceń obrazu.

**Czy efekty koloru, rozmycia i alfa można łączyć?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucić wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują obliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji przekształceń, gdy istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jakiego formatu używać, aby zachować łańcuch przekształceń?**

Używaj PPTX i weryfikuj plik poprzez ponowne otwarcie. Starszy PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu renderują jedynie wygląd, a nie edytowalne operacje przekształcenia.