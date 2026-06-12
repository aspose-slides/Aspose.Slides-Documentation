---
title: Správa pozadí prezentace v Javě
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/java/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednotná barva
- přechodová barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Java a získejte tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednotné barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo pro **hlavní snímek** (platí pro více snímků najednou).

![Pozadí PowerPointu](powerpoint-background.png)

## **Nastavení jednotné barvy pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednotnou barvu jako pozadí konkrétního snímku v prezentaci – i když prezentace používá hlavní snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getSolidFillColor--) na [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) k určení jednotné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v jazyce Java ukazuje, jak nastavit modrou jednotnou barvu jako pozadí normálního snímku:

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

## **Nastavení jednotné barvy pozadí pro hlavní snímek**

Aspose.Slides umožňuje nastavit jednotnou barvu jako pozadí hlavního snímku v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednotnou barvu pro pozadí hlavního snímku, aplikuje se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) hlavního snímku (přes `getMasters`) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí hlavního snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getSolidFillColor--) k určení jednotné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v jazyce Java ukazuje, jak nastavit jednotnou barvu (zelenou) jako pozadí hlavního snímku:

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

## **Nastavení přechodového pozadí pro snímek**

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku, může přechod učinit prezentaci umělečtější a profesionálnější. Aspose.Slides umožňuje nastavit přechodovou barvu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte metodu [getGradientFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getGradientFormat--) na [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) pro nastavení požadovaných parametrů přechodu.
5. Uložte upravenou prezentaci.

Následující příklad v jazyce Java ukazuje, jak nastavit přechodovou barvu jako pozadí snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Použijte gradientový efekt na pozadí.
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

Kromě jednotných a přechodových výplní umožňuje Aspose.Slides použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [getPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getPictureFillFormat--) na [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) pro přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v jazyce Java ukazuje, jak nastavit obrázek jako pozadí snímku:

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
Další informace: [**Obrázek jako textura dlaždice**](/slides/cs/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku pozadí**

Možná budete chtít upravit průhlednost obrázku na pozadí snímku, aby se obsah snímku lépe vyzdvihl. Následující kód v jazyce Java vám ukáže, jak změnit průhlednost obrázku pozadí snímku:

```java
int transparencyValue = 30; // Například.

// Získejte kolekci operací transformace obrázku.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Najděte existující efekt transparentnosti s pevně daným procentem.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Nastavte novou hodnotu průhlednosti.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní odhaluje efektivní [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) a [EffectFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Pomocí metody `getBackground` třídy [BaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad v jazyce Java ukazuje, jak získat efektivní hodnotu pozadí snímku:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Získejte efektivní pozadí s ohledem na hlavní snímek, rozložení a motiv.
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

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/layoutu?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího snímku [rozložení](/slides/cs/java/slide-layout/)/[hlavní snímek](/slides/cs/java/slide-master/) (tj. z [pozadí motivu](/slides/cs/java/presentation-theme/)).

**Co se stane s pozadím, pokud později změníme motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [rozložení](/slides/cs/java/slide-layout/)/[hlavního snímku](/slides/cs/java/slide-master/), aktualizuje se tak, aby odpovídalo [novému motivu](/slides/cs/java/presentation-theme/).