---
title: Zarządzaj efektami przekształceń obrazu w prezentacjach za pomocą JavaScript
linktitle: Efekty przekształceń obrazu
type: docs
weight: 11
url: /pl/nodejs-java/image-transform-effects/
keywords:
- przekształcenie obrazu
- efekt obrazu
- jasność
- kontrast
- odcienie szarości
- duoton
- nalewka
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
description: "Zastosuj, łącz, przeglądaj, usuwaj i weryfikuj efekty przekształceń obrazu dla ramek obrazu przy użyciu Aspose.Slides dla Node.js w Java."
---
## **Przegląd**

Aspose.Slides reprezentuje regulacje obrazu jako uporządkowaną kolekcję operacji przekształceń obrazu. Dla ramki obrazu zacznij od właściwości [Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/) ramki i uzyskaj dostęp do [Picture.getImageTransform](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/). Zwrócona [ImageTransformOperationCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) pozwala na dołączanie, wyliczanie, przeglądanie, usuwanie i czyszczenie efektów bez przepisywania oryginalnych bajtów obrazu.

Ten artykuł prezentuje kompletny przepływ pracy dla jasności i kontrastu, transformacji kolorów, rozmycia, przezroczystości, uporządkowanych łańcuchów efektów, wartości skutecznych, usuwania oraz weryfikacji okrągłego przejścia PPTX.

## **Zrozumienie własności efektu i ponownego użycia obrazu**

Zasób obrazu i obraz wyświetlany w ramce to różne obiekty:

- [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) przechowuje lub odwołuje się do danych źródłowego obrazu będących własnością prezentacji.
- [Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/) należy do wypełnienia obrazu i odwołuje się do zasobu obrazu, jednocześnie przechowując kolekcję przekształceń obrazu.
- [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) jest kształtem slajdu, który posiada odpowiednie wypełnienie obrazu, geometrię, ustawienia przycięcia i inne formatowanie na poziomie ramki.

Dlatego operacje przekształceń obrazu nie modyfikują bajtów w [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/). Gdy ten sam [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) zostanie przekazany do [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/) więcej niż raz, każda nowa ramka obrazu otrzymuje własny [Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/) i własną kolekcję przekształceń. Zastosowanie odcieni szarości do jednej ramki nie powoduje, że pozostałe ramki również stają się szare, mimo że wszystkie używają tego samego osadzonego zasobu obrazu.

Ten sam model [Picture.getImageTransform](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/) jest także używany przez inne wypełnienia obrazu, takie jak kształt lub tło slajdu. Poniższe przykłady koncentrują się na ramkach obrazu.

## **Używaj prawidłowych zakresów parametrów i jednostek**

Prezentowane metody używają następujących semantycznych zakresów i jednostek. Trzymaj się tych zakresów, nawet jeśli konkretna wersja biblioteki nie odrzuca od razu każdej wartości poza zakresem; docelowy format prezentacji może znormalizować, pominąć lub odrzucić nieprawidłowe dane podczas zapisu lub otwierania pliku w PowerPoint.

| Operacja | Parametry | Poprawny zakres i jednostka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` do `100`, procent; `0` pozostawia komponent niezmieniony. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Brak | Brak parametrów numerycznych. Alfa pozostaje niezmieniona. |
| [addDuotoneEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dwa kolory dla ciemnych i jasnych pikseli. Kanały RGB i alfa w `java.awt.Color` używają wartości od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Odcień od `0` (włącznie) do `360` (wyłącznie), w stopniach; natężenie od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Odcień od `0` (włącznie) do `360` (wyłącznie), w stopniach; nasycenie i luminancja od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Kolor zamienny używa wartości kanałów od `0` do `255`. Istniejące wartości alfa pozostają niezmienione. |
| [addBlurEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Promień nieujemny, mierzony w punktach; `grow` to wartość logiczna określająca, czy rozmyta treść może wyjść poza oryginalne granice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nieujemny procent. Użyj `0` do `100` dla zwykłej regulacji nieprzezroczystości: `0` to w pełni przezroczyste, `100` zachowuje istniejącą alfę. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` do `100`, procent nieprzezroczystości. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` do `100`, procentowy próg alfa. Wartości poniżej progu stają się przezroczyste; wartości równe lub wyższe – nieprzezroczyste. |

Dla stałej modulacji alfa, przezroczystość i nieprzezroczystość są komplementarne. Przykładowo, 35% przezroczystości odpowiada modulacji alfa wynoszącej 65%.

## **Zastosuj jasność i kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) zwraca operację [BrightnessContrast](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/brightnesscontrast/). Jej ustawienia skalarne są podawane w momencie tworzenia operacji. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/brightnesscontrast/) zwraca wyliczone wartości tylko do odczytu, które można przeglądać lub logować.

Poniższy przykład zwiększa jasność o 15% i kontrast o 20%, a następnie renderuje podgląd bez modyfikacji osadzonego obrazu:

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

[BrightnessContrast](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/brightnesscontrast/) jest rozszerzeniem efektu obrazu z Office 2010 i jest mniej przenośny niż standardowy efekt luminancji DrawingML. Gdy jasność i kontrast muszą pozostać edytowalne po okrągłym przejściu PPTX, użyj [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) i zweryfikuj wynik po ponownym otwarciu pliku. Sekcja ograniczeń formatów wyjaśnia tę różnicę szczegółowo.

## **Zastosuj transformacje kolorów**

Efekty kolorystyczne mogą być stosowane niezależnie do różnych ramek obrazu, które używają tego samego zasobu obrazu. Poniższy przykład tworzy pięć ramek i aplikuje kolejno odcienie szarości, duoton, nalewkę, regulację HSL oraz zamianę koloru.

[Duotone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/duotone/) posiada dwa niezależnie edytowalne parametry koloru: `color1` mapuje ciemne piksele, a `color2` mapuje jasne piksele. To czyni go przydatnym przykładem efektu, którego ustawienia są bardziej złożone niż pojedyncza wartość skalarna.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) zastępuje każdy piksel stałym kolorem, zachowując alfa. Różni się to od [addColorChangeEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/), który mapuje jeden kolor źródłowy na inny i udostępnia oba formaty koloru źródłowego i docelowego.

## **Dodaj rozmycie, przezroczystość i efekty alfa**

[addBlurEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) wpływa na wszystkie kanały kolorów, w tym alfa. Ustaw `grow` na `true`, gdy rozmyta krawędź może wyjść poza pierwotne granice obrazu.

Aby uzyskać jednolitą przezroczystość, użyj [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/). Mnoży ona każdą istniejącą wartość alfa, więc częściowo przezroczyste piksele pozostają proporcjonalnie różne. [addAlphaReplaceEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) natomiast przypisuje jedną wartość alfa wszystkim pikselom. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) konwertuje alfa na dwa poziomy w oparciu o określony próg.

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

Inne operacje alfa nie wymagające parametrów to [addAlphaCeilingEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/), które sprawia, że każda niezerowa alfa staje się w pełni nieprzezroczysta; [addAlphaFloorEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/), które czyni każdą alfę poniżej 100 % w pełni przezroczystą; oraz [addAlphaInverseEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/), które zmienia alfa na `100% - alpha`.

## **Zbuduj uporządkowany łańcuch efektów**

Każda metoda `add...Effect` dołącza nową operację na koniec kolekcji. Renderer używa kolekcji jako uporządkowanego potoku: wyjście operacji 0 staje się wejściem operacji 1 i tak dalej. W konsekwencji, te same operacje w innej kolejności mogą dać inny obraz.

Na przykład odcienie szarości, a potem nalewka najpierw usuwają informacje chromatyczne, a potem recolorują wynik luminancji. Nalewka przed odcieniami szarości usuwa nalewkę ponownie. Podobnie, zamiana alfa może nadpisać wartości alfa obliczone przez wcześniejsze operacje, podczas gdy modulacja alfa zachowuje ich względne różnice.

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

Kolekcja nie narzuca macierzy kompatybilności, która ograniczałaby operacje koloru, alfa i rozmycia do osobnych łańcuchów. Mogą być one łączone, ale nie zawsze jest to użyteczne. Stała zamiana koloru usuwa zmienność RGB wytworzoną przez wcześniejsze efekty koloru; odcienie szarości po duotonie usuwają dwa wybrane kolory; a operacje alfa typu ceiling, floor, replacement lub bi‑level mogą odrzucić szczegóły alfa stworzone wcześniej. Buduj łańcuch zgodnie z pożądaną sekwencją przetwarzania pikseli, a nie jako nieuporządkowane flagi formatowania.

## **Przeglądaj edytowalne i skuteczne wartości**

Edytowalna operacja to obiekt przechowywany w [Picture.getImageTransform](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/). W zależności od efektu może ona udostępniać bezpośrednio zapisywalne członki. Na przykład [Blur](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/blur/) udostępnia zapisywalne `radius` i `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/alphamodulatefixed/) udostępnia zapisywalny `amount`, a [AlphaBiLevel](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/alphabilevel/) udostępnia zapisywalny `threshold`. Efekty koloru, takie jak [Duotone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/duotone/), udostępniają mutowalne obiekty [ColorFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/colorformat/).

Niektóre operacje, w tym [BrightnessContrast](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tint/) i [AlphaReplace](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/alphareplace/), nie udostępniają swoich scalarnych parametrów tworzenia jako zapisywalne właściwości. Aby zmienić te ustawienia, usuń operację i dodaj zamiennik w wymaganej pozycji.

Dane skuteczne zwracane przez `getEffective()` są obliczone i tylko do odczytu. Są przydatne do rozwiązywania zależności koloru od motywu oraz do odczytywania znormalizowanych wartości, które wykorzystuje renderer, ale nie są kolejną powierzchnią edycji. Poniższy przykład wylicza łańcuch i przegląda wartości skuteczne tam, gdzie odpowiednie API je udostępnia:

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

Efekty nie wymagające parametrów, takie jak odcienie szarości, alfa ceiling i alfa inverse, nadal mają obiekt danych skutecznych, ale nie mają skalarnych ustawień do wypisania. Ich obecność i pozycja w kolekcji to istotne informacje.

## **Usuń lub wyczyść przekształcenia obrazu**

Użyj [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) aby usunąć jedną operację według indeksu. Ponieważ indeksy zmieniają się po usunięciu, najpierw wyszukaj docelową operację, a potem usuń ją po wyliczeniu. Użyj [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/) aby usunąć cały łańcuch.

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

Usunięcie lub wyczyszczenie przekształceń zmienia jedynie formatowanie obrazu. Nie usuwa, nie rekombinuje ani nie modyfikuje ponownie używanego zasobu [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).

## **Rozważ formaty prezentacji i cele eksportu**

Przekształcenia obrazu pochodzą z DrawingML, więc PPTX jest preferowanym formatem edytowalnym dla łańcuchów efektów. Nawet w PPTX nie każda operacja ma identyczną przenośność:

- Standardowe operacje DrawingML, takie jak luminancja, odcienie szarości, duoton, nalewka, HSL, rozmycie i typowe operacje alfa, mają największe szanse przetrwania okrągłego przejścia PPTX. Zawsze ponownie otwórz wygenerowany plik i sprawdź kolekcję, gdy wymagana jest zachowalność.
- [BrightnessContrast](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/brightnesscontrast/) jest rozszerzeniem Office 2010, a nie standardową operacją luminancji DrawingML. Może być używany do renderowania w pamięci, ale nie ma gwarancji, że po zapisaniu i ponownym otwarciu PPTX pozostanie edytowalnym [BrightnessContrast](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/brightnesscontrast/). Dla trwałych regulacji jasności i kontrastu preferuj [addLuminanceEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/).
- Binarny format PPT jest starszy niż pełny model efektów DrawingML. Zapis do PPT może pominąć nieobsługiwane operacje, zredukować łańcuch do obsługiwanego podzbioru lub przybliżyć wygląd. Nie używaj PPT jako formatu weryfikacji dla złożonych edytowalnych łańcuchów.
- Renderowanie do PNG, JPEG, TIFF, PDF, SVG, HTML lub innych wyjść wizualnych stosuje obsługiwany łańcuch do wyglądu renderowanego. Te wyjścia nie zawierają edytowalnej [ImageTransformOperationCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagetransformoperationcollection/); formaty rastrowe spłaszczają wynik w piksele, a eksporty dokumentów/wektorów przechowują własną reprezentację renderowania.
- Efekty nie czynią połączonego obrazu samowystarczalnym. Renderowanie połączonego obrazu nadal wymaga dostępności połączonego zasobu w momencie ładowania prezentacji.

Różni konsumenci prezentacji mogą renderować przypadki brzegowe odmiennie, szczególnie gdy połączone są liczne operacje alfa lub kwantyzacji kolorów. Dla krytycznych wyników testuj zarówno edytowalny okrągły przejazd, jak i finalny format eksportu przy użyciu tej samej wersji Aspose.Slides, co w produkcji.

## **FAQ**

**Czy efekty przekształcenia obrazu modyfikują osadzone dane obrazu?**

Nie. Operacje należą do [Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/) używanego przez wypełnienie obrazu. Podstawowe bajty [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) pozostają niezmienione.

**Czy dwie ramki obrazu, które używają tego samego obrazu, będą dzielić swoje efekty?**

Nie. Ponowne użycie [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) eliminuje duplikację danych obrazu, ale każda ramka obrazu ma zwykle odrębny [Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/) i własną kolekcję przekształceń obrazu.

**Czy efekty koloru, rozmycia i alfa można łączyć?**

Tak. Kolekcja przyjmuje je w jednym uporządkowanym łańcuchu. Rozważ, co każda operacja robi z wynikiem poprzedniej, ponieważ operacje zamiany i progowe mogą odrzucić wcześniejsze szczegóły koloru lub alfa.

**Dlaczego wartości skuteczne są tylko do odczytu?**

Dane skuteczne reprezentują wyliczone wartości używane do renderowania, w tym rozwiązane kolory. Edytuj operację przechowywaną w kolekcji przekształceń, gdzie istnieją zapisywalne członki; w przeciwnym razie usuń ją i dodaj zamiennik z nowymi parametrami tworzenia.

**Jaki format powinienem używać, aby zachować łańcuch przekształceń?**

Używaj PPTX i weryfikuj plik przez ponowne otwarcie. Starszy format PPT nie może przedstawić pełnego modelu efektów DrawingML, a formaty eksportu wizualnego zachowują jedynie wygląd, a nie edytowalne operacje przekształcenia.