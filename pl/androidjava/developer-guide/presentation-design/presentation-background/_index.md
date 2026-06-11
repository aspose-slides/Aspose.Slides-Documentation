---
title: Zarządzaj tłami prezentacji w systemie Android
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Javie, wraz ze wskazówkami kodu, które wzmocnią Twoje prezentacje."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **zwykłego slajdu** (pojedynczego slajdu) lub **slajdu wzorca** (obowiązuje dla wielu slajdów jednocześnie).

![PowerPoint background](powerpoint-background.png)

## **Ustaw jednolite tło koloru dla zwykłego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu wzorca. Zmiana dotyczy wyłącznie wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) tła slajdu na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) na [FillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

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

## **Ustaw jednolite tło koloru dla slajdu wzorca**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła slajdu wzorca w prezentacji. Slajd wzorca działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc wybór jednolitego koloru tła dla slajdu wzorca ma wpływ na każdy slajd.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/backgroundtype/) slajdu wzorca (poprzez `getMasters`) na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) tła slajdu wzorca na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) , aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

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

Gradient to efekt graficzny uzyskany poprzez stopniową zmianę koloru. Używany jako tło slajdu, gradient może sprawić, że prezentacje będą wyglądały bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie gradientowego koloru jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) tła slajdu na `Gradient`.
4. Użyj metody [getGradientFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) na [FillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

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

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides umożliwia użycie obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) tła slajdu na `Picture`.
4. Załaduj obraz, którego chcesz użyć jako tła slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [getPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) na [FillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

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

    // Ustaw tryb wypełnienia obrazu na Tile i dostosuj właściwości kafelków.
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

Czytaj więcej: [**Tile Picture As Texture**](/slides/pl/androidjava/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby zawartość slajdu wyróżniała się. Poniższy kod Java pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```java
int transparencyValue = 30; // Na przykład.

// Pobierz kolekcję operacji transformacji obrazu.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Znajdź istniejący efekt przezroczystości o stałym procencie.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Ustaw nową wartość przezroczystości.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Pobierz wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibackgroundeffectivedata/) do pobierania efektywnych wartości tła slajdu. Interfejs ten udostępnia efektywne [FillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) oraz [EffectFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Korzystając z metody `getBackground` klasy [BaseSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

```java
// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Pobierz efektywne tło, uwzględniając master, układ i motyw.
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

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/androidjava/slide-layout/)/[master](/slides/pl/androidjava/slide-master/) (tj. [theme background](/slides/pl/androidjava/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/androidjava/slide-layout/)/[master](/slides/pl/androidjava/slide-master/), zostanie zaktualizowane, aby odpowiadało nowemu motywowi.