---
title: Zarządzanie tłami prezentacji w PHP
linktitle: Tło slajdu
type: docs
weight: 20
url: /pl/php-java/presentation-background/
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
- PHP
- Aspose.Slides
description: "Dowiedz się, jak ustawiać dynamiczne tła w plikach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java, z wskazówkami kodu, które podniosą jakość Twoich prezentacji."
---
## **Wprowadzenie**

Jednolite kolory, gradienty i obrazy są powszechnie używane jako tła slajdów. Możesz ustawić tło dla **normalnego slajdu** (pojedynczy slajd) lub **slajdu master** (dotyczy wielu slajdów jednocześnie).

![Tło PowerPoint](powerpoint-background.png)

## **Ustaw jednolity kolor tła dla normalnego slajdu**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła dla konkretnego slajdu w prezentacji — nawet jeśli prezentacja używa slajdu master. Zmiana dotyczy tylko wybranego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType] slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType] na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/#getSolidFillColor) na [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład PHP pokazuje, jak ustawić niebieski jednolity kolor jako tło dla normalnego slajdu:

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ustaw kolor tła slajdu na niebieski.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Zapisz prezentację na dysk.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw jednolity kolor tła dla slajdu master**

Aspose.Slides umożliwia ustawienie jednolitego koloru jako tła dla slajdu master w prezentacji. Slajd master działa jako szablon, który kontroluje formatowanie wszystkich slajdów, więc gdy wybierzesz jednolity kolor tła slajdu master, zostanie on zastosowany do każdego slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType] slajdu master (poprzez `getMasters`) na `OwnBackground`.
3. Ustaw tło slajdu master [FillType] na `Solid`.
4. Użyj metody [getSolidFillColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/#getSolidFillColor), aby określić jednolity kolor tła.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład PHP pokazuje, jak ustawić jednolity kolor (zielony) jako tło dla slajdu master:

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Ustaw kolor tła slajdu Master na zielony leśny.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Zapisz prezentację na dysk.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw gradientowe tło dla slajdu**

Gradient to efekt graficzny powstający w wyniku stopniowej zmiany koloru. Używany jako tło slajdu, gradient może sprawić, że prezentacje będą wyglądały bardziej artystycznie i profesjonalnie. Aspose.Slides umożliwia ustawienie gradientowego koloru jako tła dla slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType] slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType] na `Gradient`.
4. Użyj metody [getGradientFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/#getGradientFormat) na [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/), aby skonfigurować preferowane ustawienia gradientu.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład PHP pokazuje, jak ustawić gradientowy kolor jako tło dla slajdu:

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Zastosuj efekt gradientu do tła.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Zapisz prezentację na dysk.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw obraz jako tło slajdu**

Oprócz jednolitych i gradientowych wypełnień, Aspose.Slides umożliwia użycie obrazów jako tła slajdów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Ustaw [BackgroundType] slajdu na `OwnBackground`.
3. Ustaw tło slajdu [FillType] na `Picture`.
4. Wczytaj obraz, który chcesz użyć jako tło slajdu.
5. Dodaj obraz do kolekcji obrazów w prezentacji.
6. Użyj metody [getPictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/#getPictureFillFormat) na [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/), aby przypisać obraz jako tło.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład PHP pokazuje, jak ustawić obraz jako tło dla slajdu:

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ustaw właściwości obrazu tła.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Wczytaj obraz.
    $image = Images::fromFile("Tulips.jpg");
    // Dodaj obraz do kolekcji obrazów prezentacji.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Zapisz prezentację na dysk.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Poniższy fragment kodu pokazuje, jak ustawić typ wypełnienia tła na kafelkowy obraz i zmodyfikować właściwości kafelkowania:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Ustaw obraz używany do wypełnienia tła.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Ustaw tryb wypełnienia obrazu na Kafelkowanie i dostosuj właściwości kafelków.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Czytaj więcej: [**Obraz kafelkowy jako tekstura**](/slides/pl/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Zmień przezroczystość obrazu tła**

Możesz chcieć dostosować przezroczystość obrazu tła slajdu, aby wyróżnić zawartość slajdu. Poniższy kod PHP pokazuje, jak zmienić przezroczystość obrazu tła slajdu:

```php
$transparencyValue = 30; // Na przykład.

$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Znajdź istniejący efekt przezroczystości o stałym procencie.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Ustaw nową wartość przezroczystości.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Uzyskaj wartość tła slajdu**

Aspose.Slides udostępnia klasę `BackgroundEffectiveData` do pobierania efektywnych wartości tła slajdu. Klasa ta eksponuje efektywne [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/) oraz [EffectFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/effectformat/).

Korzystając z metody `getBackground` klasy [BaseSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/), możesz uzyskać efektywne tło dla slajdu.

Poniższy przykład PHP pokazuje, jak uzyskać efektywną wartość tła slajdu:

```php
// Utwórz instancję klasy Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Pobierz efektywne tło, uwzględniając master, układ i temat.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy mogę zresetować niestandardowe tło i przywrócić tło motywu/układu?**

Tak. Usuń niestandardowe wypełnienie slajdu, a tło zostanie ponownie odziedziczone z odpowiedniego [layout](/slides/pl/php-java/slide-layout/)/[master](/slides/pl/php-java/slide-master/) (czyli z [theme background](/slides/pl/php-java/presentation-theme/)).

**Co się stanie z tłem, jeśli później zmienię motyw prezentacji?**

Jeśli slajd ma własne wypełnienie, pozostanie ono niezmienione. Jeśli tło jest dziedziczone z [layout](/slides/pl/php-java/slide-layout/)/[master](/slides/pl/php-java/slide-master/), zostanie zaktualizowane zgodnie z nowym motywem.