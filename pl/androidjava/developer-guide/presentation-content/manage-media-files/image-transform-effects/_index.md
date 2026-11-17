---
title: Zarządzanie efektami transformacji obrazu w prezentacjach na Androidzie
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/androidjava/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- skala szarości
- duoton
- odcień
- HSL
- zamiana koloru
- rozmycie
- przezroczystość
- efekt alfa
- łańcuch efektów
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Stosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) ramki i uzyskaj dostęp do [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Zwrócona [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) pozwala na dodawanie, wyliczanie, przeglądanie, usuwanie i czyszczenie efektów bez ponownego zapisywania oryginalnych bajtów obrazu.

Ten artykuł przedstawia kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji pełnego cyklu PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlający go to różne obiekty:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). Gdy ten sam `IPPImage` zostanie przekazany do [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `ISlidesPicture` i własną kolekcję transformacji. Zastosowanie skalowania szarości do jednej ramki nie powoduje, że pozostałe ramki również stają się szare, mimo że wszystkie korzystają z tego samego osadzonego zasobu obrazu.

Ten sam model `ISlidesPicture.getImageTransform` jest również używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramach obrazu.

## **Używanie prawidłowych zakresów parametrów i jednostek**

Pokazane metody używają następujących semantycznych zakresów i jednostek. Trzymaj wartości w tych zakresach, nawet jeśli dana wersja biblioteki nie odrzuca od razu każdego nieprawidłowego zakresu; docelowy format prezentacji może normalizować, pomijać lub odrzucać niepoprawne dane podczas zapisu lub gdy PowerPoint otwiera plik.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Brak parametrów numerycznych. Alpha pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Wartości RGB i kanału alfa używane przez `android.graphics.Color` mieszczą się w przedziale od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue (odcień) jest od `0` włącznie do `360` wyłącznie, w stopniach; amount (ilość) od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue od `0` włącznie do `360` wyłącznie, w stopniach; saturation i luminance od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Zastępowany kolor używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` jest wartością logiczną określającą, czy rozmyty kontent może wyjść poza oryginalne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nieujemny procent. Użyj `0` do `100` dla zwykłego skalowania nieprzezroczystości: `0` to w pełni przezroczyste, a `100` zachowuje istniejącą alfę. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej stają się przezroczyste; wartości równe lub powyżej stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35% przezroczystości odpowiada wartości modulacji alfa wynoszącej 65%.

## **Zastosowanie jasności i kontrastu**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) zwraca operację [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Jej skalarne ustawienia są podawane w momencie tworzenia operacji. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) zwraca obliczone wartości tylko do odczytu, które można przeglądać lub logować.

Poniższy przykład zwiększa jasność o 15% i kontrast o 20%, a następnie renderuje podgląd bez modyfikacji osadzonego obrazu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po pełnym cyklu PPTX, użyj [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosowanie transformacji kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które korzystają z jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje skalowanie szarości, duoton, odcień, regulację HSL oraz zamianę koloru.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) zawiera dwa niezależnie edytowalne parametry kolorów: `color1` mapuje ciemne piksele, natomiast `color2` mapuje jasne piksele. Dzięki temu jest przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) zastępuje kolor każdego piksela jednym stałym kolorem, zachowując alfa. Różni się to od [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), który mapuje jeden kolor źródłowy na inny i udostępnia formaty zarówno koloru źródłowego, jak i docelowego.

### **Zastosowanie progu luminancji**

Próg luminancji może ułatwić rozróżnienie słabych znaków na zeskanowanej stronie od tła. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) zachowuje pośrednie odcienie szarości. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mapuje luminancję na czarny lub biały, natomiast [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) stosuje próg do nieprzezroczystości.

Próg luminancji mieści się w przedziale od 0% do 100%, włącznie. Piksele poniżej progu stają się czarne. Piksele równe lub powyżej progu stają się białe. Podniesienie progu powoduje, że więcej odcieni staje się czarnych, ponieważ więcej z nich spada poniżej granicy.

Pobierz [grayscale-swatches.png](grayscale-swatches.png) do katalogu roboczego. Każda etykieta podaje oryginalny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otwórz wyjściową prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona 96 ma około 38% luminancji (96 z 255). Staje się biała przy progu 20% i czarna przy progu 60%.

![Oryginalne próbki w skali szarości obok czarno-białych wyników przy progach luminancji 20% i 60%](luminance-threshold.png)

## **Dodanie rozmycia, przezroczystości i efektów alfa**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wyjść poza oryginalne granice obrazu.

Do jednolitej przezroczystości użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) zamiast tego przypisuje jedną wartość alfa wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konwertuje alfę na dwa poziomy w oparciu o próg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Inne operacje alfa bez parametrów obejmują [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), który czyni każdą niezerową alfę w pełni nieprzezroczystą; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), który czyni każdą alfę poniżej 100% w pełni przezroczystą; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), który zmienia alfę na `100% - alpha`.

## **Budowanie uporządkowanego łańcucha efektów**

Każda metoda `add...Effect` dodaje nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wynik operacji 0 staje się wejściem operacji 1, i tak dalej. W konsekwencji, te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład, skalowanie szarości po którym następuje odcień najpierw usuwa informacje chromatyczne, a następnie recoloruje wynik luminancji. Odcień po skalowaniu szarości usuwa odcień ponownie. Podobnie, zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, i renderuje ponownie otwarty wynik:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje koloru, alfa i rozmycia do osobnych łańcuchów. Mogą być łączone, ale kombinacje nie zawsze są przydatne. Stała zamiana koloru usuwa wariację RGB wytworzoną przez wcześniejsze efekty koloru; skalowanie szarości po duotonie usuwa dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement lub bi-level mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną kolejnością przetwarzania pikseli, zamiast traktować jego elementy jako nieuporządkowane flagi formatowania.


<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi najpierw przez skalowanie szarości, potem odcień, a odcień potem przez skalowanie szarości. Dwa końcowe obrazy w skali szarości mają różne odcienie.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*W tym ilustracyjnym renderze Aspose.Slides dla .NET 26.11, odcień 220° przy 25% pozostawia obraz w skali szarości niezmieniony. Zastosowanie tego samego odcienia przed skalowaniem szarości daje różne odcienie.*
<!-- visual-explanation:image-transform-effects:end -->

## **Sprawdzanie edytowalnych i efektywnych wartości**

Edytowalna operacja to obiekt przechowywany w `ISlidesPicture.getImageTransform`. W zależności od efektu, może bezpośrednio udostępniać zapisywalne pola. Na przykład, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) udostępnia zapisywalne wartości `radius` i `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) udostępnia zapisywalny `amount`, a [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) udostępnia zapisywalny `threshold`. Efekty kolorystyczne, takie jak [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/), udostępniają mutowalne obiekty [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/).

Niektóre interfejsy operacji, w tym [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/) i [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), nie udostępniają swoich parametrów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `getEffective()` są obliczane i tylko do odczytu. Są przydatne do rozwiązywania zależnych od motywu kolorów i odczytywania znormalizowanych wartości używanych przez renderer, ale nie stanowią innej powierzchni edycji. Poniższy przykład wylicza łańcuch i sprawdza wartości efektywne tam, gdzie odpowiednie API je udostępnia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efekty bez parametrów, takie jak skalowanie szarości, alfa ceiling i alfa inverse, nadal mają obiekt danych efektywnych, ale nie ma skalarnych ustawień do wypisania. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuwanie lub czyszczenie transformacji obrazu**

Użyj [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) , aby usunąć jedną operację według indeksu. Ponieważ indeksy przesuwają się po usunięciu, najpierw znajdź docelową operację, a następnie usuń ją po wyliczeniu. Użyj [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) , aby usunąć cały łańcuch.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Usunięcie lub wyczyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie rekompresuje ani w żaden inny sposób nie modyfikuje ponownie używanego zasobu [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).

## **Rozważanie formatów prezentacji i docelowych formatów eksportu**

Transformacje obrazu pochodzą z DrawingML, więc PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet przy PPTX nie każda operacja ma taką samą przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, skalowanie szarości, duoton, odcień, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwać pełny cykl PPTX. Zawsze ponownie otwieraj wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymagane.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że po zapisaniu i ponownym otwarciu PPTX pozostanie edytowalnym [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Preferuj [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT powstał przed pełnym modelem efektów DrawingML. Zapis do PPT może pomijać nieobsługiwane operacje, skracać łańcuch do obsługiwanego podzbioru lub przybliżać wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych formatów wizualnych stosuje obsługiwany łańcuch do renderowanego wyglądu. Te wyjścia nie zawierają edytowalnej `IImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie sprawiają, że połączony obraz jest samodzielny. Renderowanie połączonego obrazu nadal zależy od dostępności połączonego zasobu podczas ładowania prezentacji.

Różni odbiorcy prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznych rezultatów przetestuj zarówno edytowalny pełny cykl, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, która jest używana w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do `ISlidesPicture` używanego przez wypełnienie obrazu. Bajty podstawowego `IPPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które ponownie używają tego samego obrazu, będą współdzielić swoje efekty?**

Nie. Ponowne użycie `IPPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj posiada osobny `ISlidesPicture` oraz kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa można łączyć?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowania mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują obliczone wartości używane do renderowania, w tym rozwiązywane kolory. Edytuj operację przechowywaną w kolekcji transformacji tam, gdzie istnieją zapisywalne pola; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch transformacji?**

Użyj PPTX i zweryfikuj plik, ponownie go otwierając. Starszy format PPT nie może odzwierciedlić pełnego modelu efektów DrawingML, a wyjściowe formaty eksportu zachowują jedynie wygląd, nie edytowalne operacje transformacji.