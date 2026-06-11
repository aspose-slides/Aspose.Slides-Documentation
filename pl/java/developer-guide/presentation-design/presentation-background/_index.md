---
title: Zarządzanie tłlem prezentacji w Javie
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/java/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- jednolity kolor
- gradientowy kolor
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy, z wskazówkami kodu zwiększającymi jakość Twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są często używane jako tło slajdów. Możesz ustawić tło dla **normalnego slajdu** (pojedynczego slajdu) lub **slajdu mistrza** (obowiązuje dla wielu slajdów jednocześnie).

![PowerPoint background](powerpoint-background.png)

## **Ustaw jednolite tło koloru dla normalnego slajdu**

Aspose.Slides pozwala ustawić jednolity kolor jako tło dla konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu mistrza. Zmiana dotyczy wyłącznie wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw właściwość [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getSolidFillColor--) na [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić niebieski jednolity kolor jako tło normalnego slajdu:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ustaw kolor tła slajdu na niebieski.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Zapisz prezentację na dysku.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw jednolite tło koloru dla slajdu mistrza**

Aspose.Slides pozwala ustawić jednolity kolor jako tło dla slajdu mistrza w prezentacji. Slajd mistrza działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc gdy wybierzesz jednolity kolor tła slajdu mistrza, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw właściwość [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu mistrza (poprzez `getMasters`) na `OwnBackground`.
3. Ustaw tło slajdu mistrza [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getSolidFillColor--) aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić zielony jednolity kolor jako tło slajdu mistrza:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ustaw kolor tła slajdu Master na zielony leśny.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Zapisz prezentację na dysku.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Używany jako tło slajdu, gradient może sprawić, że prezentacje będą wyglądać bardziej artystycznie i profesjonalnie. Aspose.Slides pozwala ustawić gradientowy kolor jako tło slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw właściwość [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) na `Gradient`.
4. Użyj metody [getGradientFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getGradientFormat--) na [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić gradientowy kolor jako tło slajdu:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Zastosuj efekt gradientu do tła.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Zapisz prezentację na dysku.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides pozwala używać obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw właściwość [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) na `Picture`.
4. Załaduj obraz, który chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [getPictureFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getPictureFillFormat--) na [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić obraz jako tło slajdu:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ustaw właściwości obrazu tła.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Załaduj obraz.
    IImage image = Images.fromFile("Tulips.jpg");
    // Dodaj obraz do kolekcji obrazów prezentacji.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Zapisz prezentację na dysku.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na obraz kaflowany i zmodyfikować właściwości kafelkowania:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Ustaw obraz używany do wypełnienia tła.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Ustaw tryb wypełnienia obrazu na Kafelkowanie i dostosuj właściwości kafelków.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Czytaj więcej: [**Użyj obrazu jako tekstury**](/slides/pl/java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby treść slajdu lepiej się wyróżniała. Poniższy kod w języku Java pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```java
int transparencyValue = 30; // Na przykład.

// Get the collection of picture transform operations.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Pobierz wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibackgroundeffectivedata/) do pobierania efektywnych wartości tła slajdu. Interfejs ten eksponuje efektywne [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) oraz [EffectFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Korzystając z metody `getBackground` klasy [BaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

Poniższy przykład w języku Java pokazuje, jak pobrać efektywną wartość tła slajdu:

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Pobierz efektywne tło, uwzględniając slajd mistrza, układ i motyw.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę zresetować niestandardowe tło i przywrócić tło motywu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [układu](/slides/pl/java/slide-layout/)/[mistrza](/slides/pl/java/slide-master/) (czyli z [tła motywu](/slides/pl/java/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [układu](/slides/pl/java/slide-layout/)/[mistrza](/slides/pl/java/slide-master/), zostanie zaktualizowane, aby odpowiadało nowemu motywowi.