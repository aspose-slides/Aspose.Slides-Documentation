---
title: Zarządzanie tłami prezentacji w JavaScript
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/nodejs-java/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- kolor jednolity
- kolor gradientowy
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js, z wskazówkami kodu zwiększającymi jakość Twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **standardowego slajdu** (pojedynczego slajdu) lub **slajdu wzorca** (dotyczy wielu slajdów jednocześnie).

![PowerPoint background](powerpoint-background.png)

## **Ustaw jednolite kolorowe tło dla standardowego slajdu**

Aspose.Slides pozwala ustawić jednolity kolor jako tło konkretnego slajdu w prezentacji — nawet jeśli prezentacja korzysta ze slajdu wzorca. Zmiana dotyczy wyłącznie wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Ustaw właściwość slajdu [BackgroundType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/backgroundtype/) na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) na obiekcie [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript pokazuje, jak ustawić niebieski jednolity kolor jako tło standardowego slajdu:

```js
// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ustaw kolor tła slajdu na niebieski.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Zapisz prezentację na dysk.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw jednolite kolorowe tło dla slajdu wzorca**

Aspose.Slides pozwala ustawić jednolity kolor jako tło slajdu wzorca w prezentacji. Slajd wzorca działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc wybór jednolitego koloru tła dla slajdu wzorca powoduje jego zastosowanie do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Ustaw właściwość slajdu wzorca [BackgroundType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/backgroundtype/) (przez `getMasters`) na `OwnBackground`.
3. Ustaw tło slajdu wzorca [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript pokazuje, jak ustawić jednolity zielony kolor jako tło slajdu wzorca:

```js
// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Ustaw kolor tła slajdu Master na zielony leśny.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Zapisz prezentację na dysk.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Użyty jako tło slajdu, może sprawić, że prezentacja będzie wyglądać bardziej artystycznie i profesjonalnie. Aspose.Slides pozwala ustawić gradientowy kolor jako tło slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Ustaw właściwość slajdu [BackgroundType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/backgroundtype/) na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) na `Gradient`.
4. Użyj metody [getGradientFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#getGradientFormat) na obiekcie [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript pokazuje, jak ustawić gradientowy kolor jako tło slajdu:

```js
// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Zastosuj efekt gradientu w tle.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Zapisz prezentację na dysk.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides umożliwia użycie obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Ustaw właściwość slajdu [BackgroundType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/backgroundtype/) na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) na `Picture`.
4. Załaduj obraz, który ma być użyty jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [getPictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) na obiekcie [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript pokazuje, jak ustawić obraz jako tło slajdu:

```js
// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Ustaw właściwości obrazu tła.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Załaduj obraz.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Dodaj obraz do kolekcji obrazów prezentacji.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Zapisz prezentację na dysk.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na obraz kafelkowany i zmodyfikować właściwości kafelkowania:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ustaw obraz używany do wypełnienia tła.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ustaw tryb wypełnienia obrazu na Kafelkowanie i dostosuj właściwości kafelków.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Czytaj więcej: [**Użyj obrazu jako tekstury**](/slides/pl/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Zmienianie przezroczystości obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby zawartość slajdu lepiej się wyróżniała. Poniższy kod JavaScript pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```js
var transparencyValue = 30; // Na przykład.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Pobieranie wartości tła slajdu**

Aspose.Slides udostępnia klasę `BackgroundEffectiveData` do pobierania efektywnych wartości tła slajdu. Klasa ta udostępnia efektywne [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/) i [EffectFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effectformat/).

Korzystając z metody `getBackground` klasy [BaseSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/), możesz uzyskać efektywne tło dla slajdu.

Poniższy przykład JavaScript pokazuje, jak pobrać efektywne wartości tła slajdu:

```js
// Utwórz instancję klasy Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Pobierz efektywne tło, uwzględniając master, układ i motyw.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę zresetować niestandardowe tło i przywrócić tło z motywu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/nodejs-java/slide-layout/)/[master](/slides/pl/nodejs-java/slide-master/) (czyli z [theme background](/slides/pl/nodejs-java/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/nodejs-java/slide-layout/)/[master](/slides/pl/nodejs-java/slide-master/), zostanie zaktualizowane, aby pasowało do nowego motywu.