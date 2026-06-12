---
title: Spravovat pozadí prezentací v PHP
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/php-java/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednobarevná barva
- gradientová barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, gradienty a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jeden snímek) nebo pro **master snímek** (platí pro více snímků najednou).

![PowerPoint background](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides vám umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci – i když prezentace používá master snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/#getSolidFillColor) na [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) pro zadání jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad PHP ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí pro normální snímek:

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Nastavte barvu pozadí snímku na modrou.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Uložte prezentaci na disk.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení jednobarevného pozadí pro master snímek**

Aspose.Slides vám umožňuje nastavit jednobarevnou barvu jako pozadí pro master snímek v prezentaci. Master snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednobarevnou barvu pro pozadí master snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/backgroundtype/) master snímku (pomocí `getMasters`) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) pozadí master snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/#getSolidFillColor) pro zadání jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad PHP ukazuje, jak nastavit jednobarevnou barvu (zelenou) jako pozadí pro master snímek:

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Nastavte barvu pozadí pro master snímek na lesní zelenou.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Uložte prezentaci na disk.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení gradientového pozadí pro snímek**

Gradient je grafický efekt vytvořený postupnou změnou barvy. Použito jako pozadí snímku může gradient prezentacím dodat umělecký a profesionální vzhled. Aspose.Slides vám umožňuje nastavit gradientovou barvu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte metodu [getGradientFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/#getGradientFormat) na [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) pro konfiguraci preferovaného nastavení gradientu.
5. Uložte upravenou prezentaci.

Následující příklad PHP ukazuje, jak nastavit gradientovou barvu jako pozadí pro snímek:

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aplikujte gradientový efekt na pozadí.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Uložte prezentaci na disk.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a gradientových výplní vám Aspose.Slides umožňuje použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [getPictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/#getPictureFillFormat) na [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) pro přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad PHP ukazuje, jak nastavit obrázek jako pozadí pro snímek:

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Nastavte vlastnosti obrázku pozadí.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Načtěte obrázek.
    $image = Images::fromFile("Tulips.jpg");
    // Přidejte obrázek do kolekce obrázků prezentace.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Uložte prezentaci na disk.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Následující ukázka kódu ukazuje, jak nastavit typ výplně pozadí na tilingový obrázek a upravit vlastnosti dlaždicování:

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

    // Nastavte obrázek používaný pro výplň pozadí.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Nastavte režim výplně obrázku na dlaždice a upravte vlastnosti dlaždic.
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
Přečtěte si více: [**Tile Picture As Texture**](/slides/cs/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku pozadí**

Můžete chtít upravit průhlednost obrázku pozadí snímku, aby se obsah snímku lépe vyčlenil. Následující kód PHP vám ukáže, jak změnit průhlednost obrázku pozadí snímku:

```php
$transparencyValue = 30; // Například.

// Získat kolekci operací transformace obrázku.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Najít existující efekt průhlednosti s pevnou procentuální hodnotou.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Nastavit novou hodnotu průhlednosti.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje třídu `BackgroundEffectiveData` pro získání efektivních hodnot pozadí snímku. Tato třída vystavuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effectformat/).

Při použití metody `getBackground` třídy [BaseSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad PHP ukazuje, jak získat efektivní hodnotu pozadí snímku:

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Získejte efektivní pozadí s ohledem na master, rozvržení a motiv.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu / rozvržení?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího [layoutu](/slides/cs/php-java/slide-layout/)/[masteru](/slides/cs/php-java/slide-master/) (tj. [pozadí motivu](/slides/cs/php-java/presentation-theme/)).

**Co se stane s pozadím, pokud později změníte motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [layoutu](/slides/cs/php-java/slide-layout/)/[masteru](/slides/cs/php-java/slide-master/), aktualizuje se, aby odpovídalo [novému motivu](/slides/cs/php-java/presentation-theme/).