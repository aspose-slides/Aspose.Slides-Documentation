---
title: Zarządzaj efektami transformacji obrazu w prezentacjach przy użyciu JavaScript
linktitle: Efekty transformacji obrazu
type: docs
weight: 11
url: /pl/nodejs-java/image-transform-effects/
keywords:
- transformacja obrazu
- efekt obrazu
- jasność
- kontrast
- odcień szarości
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Stosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty transformacji obrazu dla ramek obrazu przy użyciu Aspose.Slides dla Node.js za pośrednictwem Java."
---
## **Przegląd**

Aspose.Slides reprezentuje korekty obrazu jako uporządkowaną kolekcję operacji transformacji obrazu. Dla ramki obrazu rozpocznij od ramki **[Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)** i uzyskaj dostęp do **[Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)**. Zwrócona **[ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** pozwala dodawać, wyliczać, przeglądać, usuwać i wyczyścić efekty bez przepisywania pierwotnych bajtów obrazu.

Ten artykuł przedstawia kompletny przepływ pracy dotyczący jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości skutecznych, usuwania oraz weryfikacji obrotu PPTX.

## **Zrozum własność efektów i ponowne użycie obrazu**

Obiekt zasobu obrazu i obraz wyświetlający go to różne obiekty:

- **[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)** przechowuje lub odwołuje się do danych obrazu źródłowego będących własnością prezentacji.
- **[Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)** należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję transformacji obrazu.
- **[PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)** jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

W związku z tym operacje transformacji obrazu nie modyfikują bajtów w **[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)**. Gdy ten sam **[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)** zostanie przekazany do **[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)** więcej niż raz, każda nowa ramka obrazu otrzymuje własny **[Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)** i własną kolekcję transformacji. Zastosowanie odcieni szarości do jednej ramki nie sprawia, że inne ramki stają się odcieniami szarości, mimo że wszystkie ponownie używają tego samego osadzonego zasobu obrazu.

Ten sam model **[Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)** jest również używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramkach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Prezentowane metody używają następujących zakresów semantycznych i jednostek. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej wartości poza zakresem; docelowy format prezentacji może normalizować, pomijać lub odrzucać nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Prawidłowy zakres i jednostka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Brak | Brak parametrów liczbowych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają wartości od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Barwa (hue) wynosi od `0` (włącznie) do `360` (wyłącznie) stopni; ilość (amount) od `-100` do `100` procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Barwa od `0` (włącznie) do `360` (wyłącznie) stopni; nasycenie i luminancja od `-100` do `100` procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Zastępowany kolor używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Promień jest nieujemny i mierzony w punktach; `grow` jest wartością logiczną określającą, czy rozmyta treść może wykraczać poza pierwotne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nieujemny procent. Użyj `0`‑`100` do typowego skalowania nieprzezroczystości: `0` to całkowicie przezroczyste, a `100` zachowuje istniejącą alfę. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0`‑`100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0`‑`100`, procentowy próg alfa. Wartości poniżej stają się przezroczyste; wartości równe lub powyżej stają się nieprzezroczyste. |

Przy stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Na przykład 35% przezroczystości odpowiada modulacji alfa o wartości 65%.

## **Zastosuj jasność i kontrast**

**[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** zwraca operację **[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)**. Jej ustawienia skalara są podawane w momencie tworzenia operacji. **[BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)** zwraca obliczone wartości tylko do odczytu, które można przejrzeć lub zalogować.

Poniższy przykład zwiększa jasność o 15 % i kontrast o 20 %, a następnie renderuje podgląd bez modyfikacji osadzonego obrazu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

**[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)** jest rozszerzeniem efektu obrazu Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po obrocie PPTX, użyj **[ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatu wyjaśnia tę różnicę szczegółowo.

## **Zastosuj transformacje kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które ponownie używają jednego zasobu obrazu. Poniższy przykład tworzy pięć ramek i stosuje odcienie szarości, duotone, tint, regulację HSL oraz zamianę koloru.

**[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/)** zawiera dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, a `color2` mapuje jasne piksele. Dzięki temu jest przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** zastępuje każdy piksel stałym kolorem, zachowując jednocześnie alfa. Różni się od **[addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**, które mapuje jeden kolor źródłowy na inny i udostępnia formaty zarówno koloru źródłowego, jak i docelowego.

### **Zastosuj próg luminancji**

Próg luminancji może ułatwić odróżnienie słabych śladów na zeskanowanej stronie od tła. **[addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** zachowuje pośrednie odcienie szarości. **[addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** mapuje luminancję na czarny lub biały, podczas gdy **[addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** stosuje próg do nieprzezroczystości.

Próg luminancji wynosi od 0 % do 100 %, włącznie. Piksele poniżej progu stają się czarne. Piksele równe lub powyżej progu stają się białe. Podniesienie progu powoduje, że więcej odcieni staje się czarnych, ponieważ więcej z nich spada poniżej granicy.

Pobierz **[grayscale-swatches.png](grayscale-swatches.png)** do katalogu roboczego. Każda etykieta podaje oryginalny poziom szarości w skali od 0 do 255. Przykład umieszcza oryginał obok dwóch kopii i zapisuje próg każdej kopii w prezentacji.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otwórz wygenerowaną prezentację w PowerPoint, aby porównać trzy ramki. Próbka oznaczona 96 ma około 38 % luminancji (96 z 255). Staje się biała przy progu 20 % i czarna przy progu 60 %.

![Oryginalne próbki odcieni szarości obok wyników czarno‑białych przy progach luminancji 20% i 60%](luminance-threshold.png)

## **Dodaj rozmycie, przezroczystość i efekty alfa**

**[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wykraczać poza pierwotne granice obrazu.

Aby uzyskać jednolitą przezroczystość, użyj **[addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**. Mnoży on każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele zachowują proporcjonalne różnice. **[addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** natomiast przypisuje jedną wartość alfa wszystkim pikselom. **[addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** konwertuje alfa na dwa poziomy na podstawie progu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Inne operacje alfa bez parametrów obejmują **[addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**, które sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; **[addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**, które sprawia, że każda alfa poniżej 100 % staje się całkowicie przezroczysta; oraz **[addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**, które zmienia alfa na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `add...Effect` dopisuje nową operację na końcu kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji te same operacje w innej kolejności mogą dawać inny obraz.

Na przykład odcienie szarości, po których następuje tint, najpierw usuwają informacje chromatyczne, a potem recolorują wynik luminancji. Tint, po którym następuje odcień szarości, usuwa tint ponownie. Podobnie zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

Poniższy przykład buduje łańcuch czterech operacji, zapisuje go jako PPTX, ponownie otwiera prezentację, sprawdza zarówno typy operacji, jak i ich kolejność, a następnie renderuje ponownie otwarty wynik:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Kolekcja nie narzuca macierzy kompatybilności, która ogranicza operacje koloru, alfa i rozmycia do osobnych łańcuchów. Mogą być one łączone, ale kombinacje nie zawsze są użyteczne. Stała zamiana koloru usuwa wariację RGB spowodowaną wcześniejszymi efektami koloru; odcienie szarości po duotone usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement czy bi‑level mogą odrzucić szczegóły alfa utworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, a nie traktuj jego elementów jako nieuporządkowane flagi formatowania.

<!-- visual-explanation:image-transform-effects:start -->
[![Ten sam obraz przechodzi kolejno przez odcienie szarości, a następnie tint, oraz tint, a następnie odcienie szarości. Dwa końcowe obrazy w odcieniach szarości mają różne odcienie.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*W tym ilustracyjnym renderze Aspose.Slides dla .NET 26.11, tint 220° przy 25% nie zmienia obrazu w odcieniach szarości. Zastosowanie tego samego tint przed odcieniami szarości powoduje inne odcienie.*
<!-- visual-explanation:image-transform-effects:end -->

## **Sprawdź edytowalne i skuteczne wartości**

Edytowalna operacja to obiekt przechowywany w **[Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)**. W zależności od efektu, może ona bezpośrednio udostępniać zapisywalne człony. Na przykład **[Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/)** udostępnia zapisywalne wartości `radius` i `grow`, **[AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/)** udostępnia zapisywalny `amount`, a **[AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/)** udostępnia zapisywalny `threshold`. Efekty kolorystyczne, takie jak **[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/)**, udostępniają zmienne obiekty **[ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/)**.

Niektóre operacje, w tym **[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)**, **[HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/)**, **[Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/)** i **[AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/)**, nie udostępniają swoich skalarnych parametrów tworzenia jako zapisywalnych właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zastępnik w wymaganej pozycji.

Dane skuteczne zwracane przez `getEffective()` są obliczone i tylko do odczytu. Są przydatne do rozwiązywania zależnych od motywu kolorów oraz odczytywania znormalizowanych wartości używanych przez renderer, ale nie stanowią dodatkowej powierzchni edycji. Poniższy przykład wylicza łańcuch i sprawdza wartości skuteczne tam, gdzie odpowiednie API je udostępnia:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efekty bez parametrów, takie jak odcienie szarości, alfa ceiling i alfa inverse, nadal mają obiekt danych skutecznych, ale nie ma skalarnych ustawień do wypisania. Ich obecność i pozycja w kolekcji są istotną informacją.

## **Usuń lub wyczyść transformacje obrazu**

Użyj **[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**, aby usunąć jedną operację według indeksu. Ponieważ indeksy przesuwają się po usunięciu, najpierw wyszukaj docelowy element, a potem usuń go po iteracji. Użyj **[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**, aby usunąć cały łańcuch.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Usuwanie lub czyszczenie transformacji zmienia tylko formatowanie obrazu. Nie usuwa, nie kompresuje ani w żaden inny sposób nie zmienia ponownie używanego zasobu **[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)**.

## **Rozważ formaty prezentacji i cele eksportu**

Transformacje obrazu pochodzą z DrawingML, dlatego PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet przy PPTX nie każda operacja ma taką samą przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duotone, tint, HSL, rozmycie i typowe operacje alfa, mają największą szansę przetrwać obrót PPTX. Zawsze otwieraj ponownie wygenerowany plik i sprawdzaj kolekcję, gdy zachowanie jest wymagane.
- **[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)** jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że pozostanie edytowalnym **[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)** po zapisaniu i ponownym otwarciu PPTX. Preferuj **[addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)** dla trwałych korekt jasności i kontrastu.
- Binarny format PPT istniał przed pełnym modelem efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonego edytowalnego łańcucha.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innego wyjścia wizualnego stosuje obsługiwany łańcuch do renderowanego obrazu. Te wyjścia nie zawierają edytowalnego **[ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)**; formaty rastrowe spłaszczają wynik do pikseli, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią połączonego obrazu samodzielnym. Renderowanie połączonego obrazu nadal zależy od dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni odbiorcy prezentacji mogą renderować przypadki brzegowe inaczej, zwłaszcza gdy połączone są kilka operacji alfa lub kwantyzacji kolorów. Dla krytycznego rezultatu przetestuj zarówno edytowalny obrót, jak i ostateczny format eksportu przy użyciu tej samej wersji Aspose.Slides, której używasz w produkcji.

## **FAQ**

**Czy efekty transformacji obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do **[Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)** używanego przez wypełnienie obrazu. Bajty podstawowego **[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)** pozostają niezmienione.

**Czy dwie ramki obrazu, które ponownie używają tego samego obrazu, będą współdzielić swoje efekty?**

Nie. Ponowne użycie **[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)** eliminuje duplikowanie danych obrazu, ale każda ramka obrazu zazwyczaj ma osobny **[Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)** i własną kolekcję transformacji obrazu.

**Czy efekty koloru, rozmycia i alfa mogą być łączone?**

Tak. Kolekcja akceptuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucić wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości skuteczne są tylko do odczytu?**

Dane skuteczne reprezentują obliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji transformacji, gdzie istnieją zapisywalne człony; w przeciwnym razie usuń ją i dodaj nową z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch transformacji?**

Używaj PPTX i zweryfikuj plik, otwierając go ponownie. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu wizualnego zachowują jedynie wygląd, a nie edytowalne operacje transformacji.