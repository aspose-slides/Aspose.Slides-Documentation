---
title: Správa pozadí prezentací na Androidu
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/androidjava/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednobarevná barva
- přechodová barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Android v jazyce Java, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, přechody a obrázky jsou běžně používány jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo pro **hlavní snímek** (platí pro více snímků najednou).

![Pozadí PowerPointu](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá hlavní snímek. Změna se použije pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) na [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/) a určete jednobarevnou barvu pozadí.
5. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí normálního snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Nastavte barvu pozadí snímku na modrou.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Uložte prezentaci na disk.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení jednobarevného pozadí pro hlavní snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí hlavního snímku v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednobarevnou barvu pro pozadí hlavního snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/backgroundtype/) hlavního snímku (pomocí `getMasters`) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) pozadí hlavního snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) k určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit jednobarevnou barvu (zelenou) jako pozadí hlavního snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Nastavte barvu pozadí hlavního snímku na lesní zelenou.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Uložte prezentaci na disk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení přechodu jako pozadí snímku**

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může přechod učinit prezentaci umělečtější a profesionálnější. Aspose.Slides umožňuje nastavit barvu přechodu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte metodu [getGradientFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) na [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/) a nakonfigurujte požadované nastavení přechodu.
5. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit barvu přechodu jako pozadí snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Použijte přechodový efekt na pozadí.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Uložte prezentaci na disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a přechodových výplní umožňuje Aspose.Slides používat obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [getPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) na [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fillformat/) a přiřaďte obrázek jako pozadí.
7. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit obrázek jako pozadí snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Nastavte vlastnosti obrázku pozadí.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Načtěte obrázek.
    IImage image = Images.fromFile("Tulips.jpg");
    // Přidejte obrázek do kolekce obrázků prezentace.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Uložte prezentaci na disk.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Následující ukázkový kód ukazuje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dlaždicování:

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

    // Nastavte obrázek použitý pro výplň pozadí.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Nastavte režim výplně obrázku na Dlaždice a upravte vlastnosti dlaždic.
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
Přečtěte si více: [**Tile Picture As Texture**](/slides/cs/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku na pozadí**

Možná budete chtít upravit průhlednost obrázku na pozadí snímku, aby se obsah snímku lépe vyčlenil. Následující kód v jazyce Java ukazuje, jak změnit průhlednost obrázku na pozadí snímku:

```java
int transparencyValue = 30; // Například.

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

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní exponuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) a [EffectFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Pomocí metody `getBackground` třídy [BaseSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující ukázka v jazyce Java ukazuje, jak získat efektivní hodnotu pozadí snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Získejte efektivní pozadí s ohledem na hlavní snímek, rozvržení a motiv.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/rozvržení?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího [rozvržení](/slides/cs/androidjava/slide-layout/)/[hlavního snímku](/slides/cs/androidjava/slide-master/) (tj. z [pozadí motivu](/slides/cs/androidjava/presentation-theme/)).

**Co se stane s pozadím, když později změníme motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [rozvržení](/slides/cs/androidjava/slide-layout/)/[hlavního snýmku](/slides/cs/androidjava/slide-master/), aktualizuje se tak, aby odpovídalo novému motivu.