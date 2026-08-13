---
title: Zarządzanie tłami prezentacji w Javie
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/java/presentation-background/
keywords:
- tło prezentacji
- tło slajdu
- jednolity kolor
- kolor gradientu
- tło obrazu
- przezroczystość tła
- właściwości tła
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy, z wskazówkami kodowymi, które wzmocnią Twoje prezentacje."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **zwykłego slajdu** (pojedynczego slajdu) lub **slajdu master** (obowiązującego dla wielu slajdów naraz).

![Tło PowerPoint](powerpoint-background.png)

## **Ustaw jednolity kolor tła dla zwykłego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła konkretnego slajdu w prezentacji — nawet jeśli prezentacja korzysta ze slajdu master. Zmiana dotyczy wyłącznie wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) tła slajdu na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getSolidFillColor--) na [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić niebieski jednolity kolor jako tło zwykłego slajdu:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Ustaw jednolity kolor tła dla slajdu master**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła slajdu master w prezentacji. Slajd master działa jako szablon kontrolujący formatowanie wszystkich slajdów, więc wybranie jednolitego koloru tła slajdu master powoduje, że zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu master (przez `getMasters`) na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) tła slajdu master na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getSolidFillColor--) aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić zielony jednolity kolor jako tło slajdu master:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Ustaw kolor tła slajdu master na zielony.
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

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Stosowany jako tło slajdu, może sprawić, że prezentacja będzie wyglądać bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie gradientowego koloru jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) tła slajdu na `Gradient`.
4. Użyj metody [getGradientFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getGradientFormat--) na [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić gradientowy kolor jako tło slajdu:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Zastosuj efekt gradientu do tła.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Dodaj kolory gradientu. Bez punktów gradientu tło przechodzi do domyślnej czarno-białej skali.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Zapisz prezentację na dysku.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides pozwala używać obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Ustaw [BackgroundType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/backgroundtype/) slajdu na `OwnBackground`.
3. Ustaw [FillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) tła slajdu na `Picture`.
4. Załaduj obraz, który ma być użyty jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów prezentacji.
6. Użyj metody [getPictureFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/#getPictureFillFormat--) na [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Java pokazuje, jak ustawić obraz jako tło slajdu:

```java
import com.aspose.slides.*;

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

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na kafelkowy obraz i zmodyfikować właściwości kafelkowania:

```java
import com.aspose.slides.*;

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

    // Ustaw tryb wypełnienia obrazu na Kafelkowanie i dostosuj właściwości kafelkowania.
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

{{% alert color="info" %}}
Więcej informacji: [**Kafelkowy obraz jako tekstura**](/slides/pl/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby zawartość slajdu lepiej się wyróżniała. Poniższy kod w języku Java pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Na przykład.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj wartość tła slajdu**

Aspose.Slides udostępnia interfejs [IBackgroundEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibackgroundeffectivedata/) służący do pobierania efektywnych wartości tła slajdu. Interfejs ten eksponuje efektywne [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) oraz [EffectFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Korzystając z metody `getBackground` klasy [BaseSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslide/), możesz uzyskać efektywne tło slajdu.

Poniższy przykład w języku Java pokazuje, jak pobrać efektywną wartość tła slajdu:

```java
import com.aspose.slides.*;

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

### Czy mogę zresetować własne tło i przywrócić tło motywu/układu?

Tak. Usuń własne wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego slajdu [layout](/slides/pl/java/slide-layout/)/[master](/slides/pl/java/slide-master/) (czyli z [theme background](/slides/pl/java/presentation-theme/)).

### Co się stanie z tłem, jeśli później zmienię motyw prezentacji?

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/java/slide-layout/)/[master](/slides/pl/java/slide-master/), zostanie zaktualizowane, aby pasować do [new theme](/slides/pl/java/presentation-theme/).