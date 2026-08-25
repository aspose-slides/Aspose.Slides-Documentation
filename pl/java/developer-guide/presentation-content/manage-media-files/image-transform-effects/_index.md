---
title: Zarządzanie efektami transformacji obrazu w prezentacjach w Javie
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
- odcieniowanie
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
description: "Zastosuj, łącz, sprawdzaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu, rozpocznij od [ISlidesPicture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidespicture/) i uzyskaj dostęp do [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidespicture/#getImageTransform--). Zwrócona [IImageTransformOperationCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/) pozwala na dołączanie, enumerowanie, inspekcję, usuwanie i czyszczenie efektów bez nadpisywania oryginalnych bajtów obrazu.

Ten artykuł demonstruje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości efektywnych, usuwania oraz weryfikacji rundowej w formacie PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlający go to różne obiekty:

- [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [ISlidesPicture](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidespicture/) należy do wypełnienia obrazu i odnosi się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje transformacji obrazu nie modyfikują bajtów w [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/). Gdy ten sam `IPPImage` jest przekazywany do [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) więcej niż raz, każda nowa ramka obrazu otrzymuje własny `ISlidesPicture` i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie sprawia, że pozostałe ramki stają się odcieniami szarości, mimo że wszystkie używają tego samego wbudowanego zasobu obrazu.

Ten sam model `ISlidesPicture.getImageTransform` jest również wykorzystywany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Przykłady poniżej koncentrują się na ramkach obrazu.

## **Używanie prawidłowych zakresów parametrów i jednostek**

Prezentowane metody używają następujących semantycznych zakresów i jednostek. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu wartości spoza zakresu; docelowy format prezentacji może znormalizować, pominąć lub odrzucić nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Zakres i jednostka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Brak | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają wartości od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Barwa (hue) w zakresie od `0` (włącznie) do `360` (wyłącznie), w stopniach; ilość (amount) od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Barwa w zakresie od `0` (włącznie) do `360` (wyłącznie), w stopniach; nasycenie i luminancja od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Zastępczy kolor używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` jest wartością boolowską określającą, czy rozmyta treść może wyjść poza pierwotne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Procent nieujemny. Użyj `0` do `100` dla typowego skalowania nieprzezroczystości: `0` oznacza całkowitą przezroczystość, a `100` zachowuje istniejącą wartość alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub powyżej progu stają się nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35% przezroczystości odpowiada wartości modulacji alfa 65%.

## **Zastosowanie jasności i kontrastu**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) zwraca operację [IBrightnessContrast](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibrightnesscontrast/). Jej ustawienia skalarne są podawane przy tworzeniu operacji. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) zwraca obliczone wartości tylko do odczytu, które można inspekować lub logować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji wbudowanego obrazu:

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

[BrightnessContrast](https://reference.aspose.com/slides/pl/java/com.aspose.slides/brightnesscontrast/) jest rozszerzeniem efektu obrazu w Office 2010 i jest mniej przenośny niż standardowy efekt luminancji w DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po rundzie PPTX, użyj [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę bardziej szczegółowo.

## **Zastosowanie transformacji kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które korzystają z jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje odcienie szarości, duoton, odcieniowanie, regulację HSL oraz zamianę koloru.

[IDuotone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iduotone/) zawiera dwa niezależnie edytowalne parametry kolorów: `color1` mapuje ciemne piksele, natomiast `color2` mapuje jasne piksele. Dzięki temu jest użytecznym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) zamienia każdy piksel na jeden stały kolor, zachowując alfa. Różni się od [addColorChangeEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), które mapuje jeden kolor źródłowy na inny i udostępnia oba formaty kolorów źródłowego i docelowego.

## **Dodawanie rozmycia, przezroczystości i efektów alfa**

[addBlurEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Dla jednolitej przezroczystości użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) zamiast tego przydziela jedną wartość alfa wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) konwertuje alfa na dwa poziomy w oparciu o próg.

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

Inne operacje alfa nie wymagające parametrów to [addAlphaCeilingEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), które czyni każdy niezerowy alfa w pełni nieprzezroczystym; [addAlphaFloorEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), które czyni każdy alfa poniżej 100 % całkowicie przezroczystym; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), które zmienia alfa na `100% - alfa`.

## **Budowanie uporządkowanego łańcucha efektów**

Każda metoda `add...Effect` dołącza nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład odcienie szarości a potem odcieniowanie najpierw usuwają informacje chromatyczne, a potem kolorują wynik luminancji. Odcieniowanie a potem odcienie szarości usuwa ponownie odcieniowanie. Podobnie zamiana alfa może nadpisać wartości alfa wyliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, a następnie renderuje ponownie otwarty wynik:

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

Kolekcja nie narzuca matrycy kompatybilności ograniczającej operacje koloru, alfa i rozmycia do osobnych łańcuchów. Mogą być łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariacje RGB wytworzone przez wcześniejsze efekty koloru; odcienie szarości po duotonie usuwają dwa wybrane kolory; a operacje alfa typu sufit, podłoga, zamiana lub dwupoziomowe mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.

## **Inspekcja wartości edytowalnych i efektywnych**

Edytowalna operacja to obiekt przechowywany w `ISlidesPicture.getImageTransform`. W zależności od efektu, może ona bezpośrednio udostępniać zapisywalne członki. Na przykład [IBlur](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iblur/) udostępnia zapisywalne wartości `radius` i `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ialphamodulatefixed/) udostępnia zapisywalny `amount`, a [IAlphaBiLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ialphabilevel/) udostępnia zapisywalny `threshold`. Efekty koloru, takie jak [IDuotone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iduotone/), udostępniają mutowalne obiekty [IColorFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icolorformat/).

Niektóre interfejsy operacji, w tym [IBrightnessContrast](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itint/), oraz [IAlphaReplace](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ialphareplace/), nie udostępniają swoich skalarnych wartości tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane efektywne zwracane przez `getEffective()` są wyliczane i tylko do odczytu. Są przydatne do rozwiązywania kolorów zależnych od motywu oraz odczytywania znormalizowanych wartości, których używa renderer, ale nie stanowią dodatkowej warstwy edycji. Poniższy przykład enumeruje łańcuch i inspekcjonuje wartości efektywne tam, gdzie odpowiednie API je udostępnia:

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

Efekty bez parametrów, takie jak odcienie szarości, sufit alfa i odwrócenie alfa, nadal mają obiekt danych efektywnych, ale nie mają skalarnych ustawień do wydruku. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuwanie lub czyszczenie transformacji obrazu**

Użyj [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) aby usunąć jedną operację według indeksu. Ponieważ indeksy przesuwają się po usunięciu, najpierw znajdź docelowy element, a następnie usuń go po przeiterowaniu. Użyj [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imagetransformoperationcollection/#clear--) aby usunąć cały łańcuch.

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

Usunięcie lub wyczyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie rekompresuje ani nie zmienia w żaden sposób ponownie używanego zasobu [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).

## **Rozważanie formatów prezentacji i celów eksportu**

Transformacje obrazu pochodzą z DrawingML, więc PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet przy PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duoton, odcieniowanie, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwać rundę PPTX. Zawsze ponownie otwórz wygenerowany plik i sprawdź kolekcję, gdy zachowanie jest wymogiem.
- [BrightnessContrast](https://reference.aspose.com/slides/pl/java/com.aspose.slides/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że pozostanie edytowalnym [IBrightnessContrast](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibrightnesscontrast/) po zapisaniu i ponownym otwarciu PPTX. Preferuj [addLuminanceEffect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) dla trwałych korekt jasności i kontrastu.
- Binarny format PPT powstał przed pełnym modelem efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innego wyjścia wizualnego stosuje obsługiwany łańcuch do wyglądu renderowanego. Te wyjścia nie zawierają edytowalnej `IImageTransformOperationCollection`; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie sprawiają, że połączony obraz staje się samodzielny. Renderowanie połączonego obrazu nadal wymaga dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe inaczej, zwłaszcza gdy łączy się kilka operacji alfa lub kwantyzacji koloru. Dla krytycznych rezultatów testuj zarówno edytowalną rundę, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, która jest używana w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują wbudowane dane obrazu?**

Nie. Operacje należą do `ISlidesPicture` używanego przez wypełnienie obrazu. Bajty leżącego pod spodem `IPPImage` pozostają niezmienione.

**Czy dwie ramki obrazu, które używają tego samego obrazu, dzielą swoje efekty?**

Nie. Ponowne użycie `IPPImage` unika duplikowania danych obrazu, ale każda ramka obrazu zazwyczaj ma oddzielny `ISlidesPicture` i kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wyjściem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucać wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości efektywne są tylko do odczytu?**

Dane efektywne reprezentują wyliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch transformacji?**

Używaj PPTX i weryfikuj plik, ponownie go otwierając. Starszy format PPT nie jest w stanie przedstawić pełnego modelu efektów DrawingML, a formaty eksportu renderują wygląd, a nie edytowalne operacje transformacji.