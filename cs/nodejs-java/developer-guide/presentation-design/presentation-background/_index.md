---
title: Správa pozadí prezentací v JavaScriptu
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/nodejs-java/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednotná barva
- gradientní barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednolité barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo **master snímek** (platí pro více snímků najednou).

![Pozadí PowerPointu](powerpoint-background.png)

## **Nastavení jednotné barvy pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednotnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá master snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) na [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/), abyste určili jednotnou barvu pozadí.
5. Uložte upravenou prezentaci.

Následující příklad JavaScript ukazuje, jak nastavit modrou jednotnou barvu jako pozadí normálního snímku:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Nastavte barvu pozadí snímku na modrou.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Uložte prezentaci na disk.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení jednotné barvy pozadí pro master snímek**

Aspose.Slides umožňuje nastavit jednotnou barvu jako pozadí pro master snímek v prezentaci. Master snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednotnou barvu pro pozadí master snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/backgroundtype/) master snímku (pomocí `getMasters`) na `OwnBackground`.
3. Nastavte pozadí master snímku [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) pro určení jednotné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad JavaScript ukazuje, jak nastavit zelenou jednotnou barvu jako pozadí master snímku:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Nastavte barvu pozadí pro master snímek na lesní zelenou.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Uložte prezentaci na disk.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení gradientového pozadí pro snímek**

Gradient je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může gradient udělat prezentaci umělečtější a profesionálnější. Aspose.Slides umožňuje nastavit barvu gradientu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) na `Gradient`.
4. Použijte metodu [getGradientFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#getGradientFormat) na [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/), abyste nakonfigurovali požadované nastavení gradientu.
5. Uložte upravenou prezentaci.

Následující příklad JavaScript ukazuje, jak nastavit gradientovou barvu jako pozadí snímku:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Aplikujte gradientový efekt na pozadí.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Uložte prezentaci na disk.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednotných a gradientních výplní umožňuje Aspose.Slides použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [getPictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) na [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/), abyste přiřadili obrázek jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad JavaScript ukazuje, jak nastavit obrázek jako pozadí snímku:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Nastavte vlastnosti obrázku pozadí.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Načtěte obrázek.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Přidejte obrázek do kolekce obrázků prezentace.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Uložte prezentaci na disk.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Následující ukázka kódu demonstruje nastavení typu výplně pozadí na dlaždicový obrázek a úpravu vlastností dlaždicování:

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

    // Nastavte obrázek použité pro výplň pozadí.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Nastavte režim výplně obrázku na dlaždice a upravte vlastnosti dlaždic.
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
Přečtěte si více: [**Obrázek dlaždic jako textura**](/slides/cs/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku na pozadí**

Možná budete chtít upravit průhlednost obrázku v pozadí snímku, aby obsah snímku vynikl. Následující JavaScript kód ukazuje, jak změnit průhlednost obrázku na pozadí snímku:

```js
var transparencyValue = 30; // Například.

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

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje třídu `BackgroundEffectiveData` pro získání efektivních hodnot pozadí snímku. Tato třída exponuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effectformat/).

Pomocí metody `getBackground` třídy [BaseSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad JavaScript ukazuje, jak získat efektivní hodnotu pozadí snímku:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Získejte efektivní pozadí s ohledem na master, layout a téma.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/podkladu?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího [layout](/slides/cs/nodejs-java/slide-layout/)/[master](/slides/cs/nodejs-java/slide-master/) snímku (tj. [theme background](/slides/cs/nodejs-java/presentation-theme/)).

**Co se stane s pozadím, pokud později změníme motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane beze změny. Pokud je pozadí zděděno z [layout](/slides/cs/nodejs-java/slide-layout/)/[master](/slides/cs/nodejs-java/slide-master/), aktualizuje se podle [new theme](/slides/cs/nodejs-java/presentation-theme/).