---
title: Správa pozadí prezentace v Javě
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/java/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednobarevná barva
- barva přechodu
- pozadí obrázku
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak pomocí Aspose.Slides pro Javu nastavit dynamická pozadí v souborech PowerPoint a OpenDocument, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jeden snímek) nebo pro **hlavní snímek** (platí pro více snímků najednou).

![PowerPoint background](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá hlavní snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getSolidFillColor--) na třídě [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) pro určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí normálního snímku:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) hlavního snímku (pomocí `getMasters`) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí hlavního snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getSolidFillColor--) pro určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit jednobarevnou barvu (zelenou) jako pozadí hlavního snímku:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Nastavte barvu pozadí hlavního snímku na zelenou.
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

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může přechod učinit prezentaci umělečtější a profesionálnější. Aspose.Slides umožňuje nastavit barvu přechodu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte metodu [getGradientFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getGradientFormat--) na třídě [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) pro nastavení požadovaných parametrů přechodu.
5. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit barvu přechodu jako pozadí snímku:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Použijte přechodový efekt na pozadí.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Přidejte barvy přechodu. Bez gradientových zastávek se pozadí vrátí k výchozímu černobílému přechodu.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Uložte prezentaci na disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a přechodových výplní umožňuje Aspose.Slides používat obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [getPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/#getPictureFillFormat--) na třídě [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fillformat/) pro přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující ukázka v jazyce Java ukazuje, jak nastavit obrázek jako pozadí snímku:

```java
import com.aspose.slides.*;

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

Následující ukázka kódu ukazuje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dláždění:

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

    // Nastavte obrázek použitý pro výplň pozadí.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Nastavte režim výplně obrázkem na Tile a upravte vlastnosti dláždění.
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
Více informací: [**Tile Picture As Texture**](/slides/cs/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku na pozadí**

Možná budete chtít upravit průhlednost obrázku v pozadí snímku, aby se obsah snímku lépe vyčlenil. Následující kód v jazyce Java vám ukáže, jak změnit průhlednost obrázku na pozadí snímku:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Například.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Získejte kolekci operací transformace obrázku.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Najděte existující efekt průhlednosti s pevnou procentuální hodnotou.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní zpřístupňuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) a [EffectFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Pomocí metody `getBackground` třídy [BaseSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující ukázka v jazyce Java ukazuje, jak získat efektivní hodnotu pozadí snímku:

```java
import com.aspose.slides.*;

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

### Mohu resetovat vlastní pozadí a obnovit pozadí motivu/layoutu?

Ano. Odeberte vlastní výplň snímku a pozadí bude opět zděděno z odpovídajícího snímku [layout](/slides/cs/java/slide-layout/)/[master](/slides/cs/java/slide-master/) (tj. z [theme background](/slides/cs/java/presentation-theme/)).

### Co se stane s pozadím, pokud později změníme motiv prezentace?

Pokud má snímek vlastní výplň, zůstane beze změny. Pokud je pozadí zděděno z [layout](/slides/cs/java/slide-layout/)/[master](/slides/cs/java/slide-master/), aktualizuje se tak, aby odpovídalo [novému motivu](/slides/cs/java/presentation-theme/).