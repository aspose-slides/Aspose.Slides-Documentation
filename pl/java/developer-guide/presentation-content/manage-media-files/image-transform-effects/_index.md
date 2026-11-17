---
title: Zarządzanie efektami transformacji obrazu w prezentacjach w języku Java
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/java/image-transform-effects/
keywords:
- transformacja obrazu
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
- Java
- Aspose.Slides
description: "Stosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazów przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) i uzyskaj dostęp do [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). Zwrócona [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) umożliwia dołączanie, wyliczanie, inspekcję, usuwanie i czyszczenie efektów bez przepisania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji w trybie round‑trip PPTX.

## **Zrozumienie własności efektów i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlany w ramce to różne obiekty:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) przechowuje lub odwołuje się do danych obrazu źródłowego będących własnością prezentacji.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Gdy ten sam `IPPImage` jest przekazywany do [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `ISlidesPicture` i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie powoduje, że pozostałe ramki będą w odcieniach szarości, mimo że wszystkie używają tego samego wbudowanego zasobu obrazu.

Ten sam model `ISlidesPicture.getImageTransform` jest także wykorzystywany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Przykłady poniżej koncentrują się na ramkach obrazu.

## **Używanie prawidłowych zakresów parametrów i jednostek**

Prezentowane metody wykorzystują następujące semantyczne zakresy i jednostki. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej wartości spoza zakresu; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub podczas otwierania pliku w PowerPoint.

| Operacja | Parametry | Poprawny zakres i jednostka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent bez zmian. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Brak | Brak parametrów liczbowych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają wartości od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Barwa od `0` (włącznie) do `360` (wyłącznie) stopni; ilość od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Barwa od `0` (włącznie) do `360` (wyłącznie) stopni; nasycenie i luminancja od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Kolor zastępczy używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` jest wartością Boolean określającą, czy rozmyta zawartość może wykraczać poza pierwotne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nieujemny procent. Użyj `0` do `100` dla typowego skalowania nieprzezroczystości: `0` to całkowita transparentność, `100` zachowuje istniejącą wartość alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej stają się przezroczyste; wartości równe lub powyżej stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przejrzystość i nieprzezroczystość są komplementarne. Na przykład 35 % przejrzystości odpowiada modulacji alfa o wartości 65 %.

## **Zastosowanie jasności i kontrastu**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) zwraca operację [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Jej ustawienia skalarne są podawane w momencie tworzenia operacji. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) zwraca obliczone wartości tylko do odczytu, które mogą być inspekcjonowane lub logowane.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji osadzonego obrazu:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po round‑trip PPTX, użyj [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) i zweryfikuj rezultat po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosowanie transformacji kolorów**

Efekty kolorów mogą być stosowane niezależnie do różnych ramek obrazu, które ponownie używają tego samego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje odcienie szarości, duoton, tonowanie, regulację HSL oraz zamianę koloru.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, a `color2` mapuje jasne piksele. To czyni go przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) zamienia każdy piksel na jeden stały kolor, zachowując alfa. Różni się od [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), który mapuje jeden kolor źródłowy na inny i udostępnia oba formaty koloru źródłowego i docelowego.

### **Zastosowanie progu luminancji**

Próg luminancji może ułatwić odróżnienie słabych znaków na zeskanowanej stronie od tła. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) zachowuje pośrednie odcienie szarości. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mapuje luminancję na czarny lub biały, podczas gdy [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) stosuje próg do nieprzezroczystości.

Próg luminancji mieści się w przedziale od 0 % do 100 %, włącznie. Piksele poniżej progu stają się czarne. Piksele równi lub powyżej progu stają się białe. Podniesienie progu sprawia, że więcej odcieni staje się czarnych, ponieważ więcej z nich spada poniżej limitu.

Pobierz [grayscale-swatches.png](grayscale-swatches.png) do katalogu roboczego. Każda etykieta podaje oryginalny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Otwórz wynikową prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona 96 ma około 38 % luminancji (96 z 255). Staje się biała przy progu 20 % i czarna przy progu 60 %.

![Oryginalne próbki odcieni szarości obok wyników czarno‑białych przy progach luminancji 20% i 60%](luminance-threshold.png)

## **Dodawanie rozmycia, przejrzystości i efektów alfa**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wykraczać poza pierwotne granice obrazu.

Dla jednolitej przejrzystości użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) natomiast przypisuje jedną wartość alfa wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konwertuje alfa na dwa poziomy w oparciu o prog.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Inne efekty alfa nie wymagające parametrów to [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), który sprawia, że każdy niezerowy alfa jest w pełni nieprzezroczysty; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), który czyni każdy alfa poniżej 100 % całkowicie przezroczystym; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), który zmienia alfa na `100% - alpha`.

## **Budowanie uporządkowanego łańcucha efektów**

Każda metoda `add...Effect` dołącza nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład, odcienie szarości, a następnie tonowanie najpierw usuwają informacje chromatyczne, a potem recolorują wynik luminancji. Tonowanie, a potem odcienie szarości usuwa ponownie tonowanie. Podobnie, zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje cztero‑operacyjny łańcuch, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, oraz renderuje ponownie otwarty wynik:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje kolorów, alfa i rozmycia do oddzielnych łańcuchów. Mogą być one łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariacje RGB wyprodukowane przez wcześniejsze efekty kolorystyczne; odcienie szarości po duotonie usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replace lub bi‑level mogą odrzucać szczegóły alfa utworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.


<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi najpierw przez odcienie szarości, potem przez odcień, oraz najpierw przez odcień, potem przez odcienie szarości. Dwa końcowe obrazy w odcieniach szarości mają różne tony.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*W tym ilustracyjnym renderze Aspose.Slides for .NET 26.11, odcień 220° przy 25% nie zmienia obrazu w odcieniach szarości. Zastosowanie tego samego odcienia przed odcieniami szarości daje różne tony.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspekcja wartości edytowalnych i efektywnych**

Operacja edytowalna to obiekt przechowywany w `ISlidesPicture.getImageTransform`. W zależności od efektu może ona udostępniać zapisywalne członki bezpośrednio. Na przykład, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) udostępnia zapisywalne wartości `radius` i `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) udostępnia zapisywalny `amount`, a [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) udostępnia zapisywalny `threshold`. Efekty kolorów, takie jak [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/), udostępniają mutowalne obiekty [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/).

Niektóre interfejsy operacji, w tym [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), i [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), nie udostępniają swoich skalarnych parametrów tworzenia jako zapisywalnych własności. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `getEffective()` są obliczane i tylko do odczytu. Są przydatne do rozwiązywania zależnych od motywu kolorów oraz odczytywania znormalizowanych wartości, których używa renderer, ale nie stanowią dodatkowej powierzchni edycji. Poniższy przykład wylicza łańcuch i inspekcjonuje wartości efektywne tam, gdzie odpowiednie API je udostępnia:

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

Efekty nie wymagające parametrów, takie jak odcienie szarości, alpha ceiling i alpha inverse, nadal mają obiekt danych efektywnych, ale nie mają ustawień skalarnych do wyświetlenia. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuwanie lub czyszczenie transformacji obrazu**

Użyj [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) aby usunąć jedną operację po indeksie. Ponieważ indeksy przesuwają się po usunięciu, najpierw wyszukaj docelową operację, a następnie usuń ją po wyliczeniu. Użyj [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) aby usunąć cały łańcuch.

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

Usunięcie lub wyczyszczenie transformacji zmienia wyłącznie formatowanie obrazu. Nie usuwa, nie recompresuje ani nie modyfikuje ponownie używanego zasobu [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).

## **Rozważanie formatów prezentacji i docelowych formatów eksportu**

Transformacje obrazu pochodzą z DrawingML, więc PPTX jest preferowanym edytowalnym formatem dla łańcuchów efektów. Nawet w PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duoton, tonowanie, HSL, rozmycie i typowe operacje alfa, mają najlepszą szansę przetrwania round‑trip PPTX. Zawsze ponownie otwieraj wygenerowany plik i inspekcjonuj kolekcję, gdy zachowanie jest wymogiem.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Można go używać do renderowania w pamięci, ale nie ma gwarancji, że pozostanie edytowalnym [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) po zapisaniu i ponownym otwarciu PPTX. Preferuj [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT jest starszy od pełnego modelu efektów DrawingML. Zapis do PPT może pomijać nieobsługiwane operacje, redukować łańcuch do obsługiwanego podzbioru lub aproksymować wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innego wyjścia wizualnego stosuje obsługiwany łańcuch do wyglądu renderowanego. Te wyjścia nie zawierają edytowalnej `IImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik w piksele, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią połączonego obrazu samodzielnym. Renderowanie połączonego obrazu nadal zależy od dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, szczególnie gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznego wyjścia przetestuj zarówno edytowalny round‑trip, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, co w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do `ISlidesPicture` używanego przez wypełnienie obrazu. Bajty leżącego pod spodem `IPPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które ponownie używają tego samego obrazu, dzielą swoje efekty?**

Nie. Ponowne użycie `IPPImage` eliminuje duplikację danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny `ISlidesPicture` i własną kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa można łączyć?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują obliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch transformacji?**

Używaj PPTX i weryfikuj plik, ponownie go otwierając. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu renderują tylko wygląd, a nie edytowalne operacje transformacji.