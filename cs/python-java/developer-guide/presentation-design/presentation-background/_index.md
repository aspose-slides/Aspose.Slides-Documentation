---
title: Správa pozadí prezentace v Pythonu přes Java
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/python-java/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednobarevná barva
- gradientová barva
- pozadí s obrázkem
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, gradienty a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo pro **hlavní snímek** (aplikuje se na více snímků najednou).

![PowerPoint background](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci – i když prezentace používá hlavní snímek. Změna se projeví pouze na vybraném snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getsolidfillcolor) na [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) pro určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí pro normální snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Nastavte barvu pozadí snímku na modrou.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Uložte prezentaci na disk.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení jednobarevného pozadí pro hlavní snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí hlavního snímku v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednobarevnou barvu pro pozadí hlavního snímku, aplikuje se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/backgroundtype/) hlavního snímku (pomocí [getMasters](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getmasters)) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) pozadí hlavního snímku na `Solid`.
4. Použijte metodu [getSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getsolidfillcolor) pro určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit jednobarevnou barvu (zelenou) jako pozadí pro hlavní snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Nastavte barvu pozadí hlavního snímku na zelenou.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Uložte prezentaci na disk.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení gradientového pozadí pro snímek**

Gradient je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může gradient dodat prezentacím umělecký a profesionální vzhled. Aspose.Slides umožňuje nastavit gradientovou barvu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte metodu [getGradientFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getgradientformat) na [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) pro konfiguraci preferovaných nastavení gradientu.
5. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit gradientovou barvu jako pozadí pro snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Použijte gradientový efekt na pozadí.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Přidejte gradientové barvy. Bez gradientových zastávek se pozadí vrátí k výchozí černo-bílé škále.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Uložte prezentaci na disk.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a gradientních výplní umožňuje Aspose.Slides použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte metodu [getPictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getpicturefillformat) na [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) pro přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit obrázek jako pozadí snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Nastavte vlastnosti obrázku pozadí.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Načtěte obrázek.
    image = Images.fromFile("Tulips.jpg")
    # Přidejte obrázek do kolekce obrázků prezentace.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Uložte prezentaci na disk.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Následující ukázkový kód ukazuje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dlaždicování:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Nastavte obrázek použité pro výplň pozadí.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Nastavte režim výplně obrázku na Dlaždice a upravte vlastnosti dlaždic.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Přečtěte si více: [Tile Picture as Texture](/slides/cs/python-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Změna průhlednosti obrázku na pozadí**

Možná budete chtít upravit průhlednost obrázku v pozadí snímku, aby se obsah snímku lépe vyjímal. Následující kód v Pythonu ukazuje, jak změnit průhlednost obrázku na pozadí snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Například.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Získejte kolekci operací transformace obrázku.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Najděte existující efekt pevné procentuální průhlednosti.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Nastavte novou hodnotu průhlednosti.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides umožňuje načíst efektivní hodnoty pozadí snímku pomocí metody [getEffective](https://reference.aspose.com/slides/cs/python-java/aspose.slides/background/#geteffective) na objektu [Background](https://reference.aspose.com/slides/cs/python-java/aspose.slides/background/). Vrácená data zpřístupňují efektivní formáty výplně a efektu.

Pomocí metody [getBackground](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/#getbackground) třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslide/) můžete získat pozadí snímku.

Následující příklad v Pythonu ukazuje, jak získat efektivní hodnotu pozadí snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Vytvořte instanci třídy Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Získejte efektivní pozadí s ohledem na hlavní snímek, rozvržení a motiv.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/rozvržení?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího snímku [rozvržení](/slides/cs/python-java/slide-layout/)/[hlavní snímek](/slides/cs/python-java/slide-master/) (tj. z [pozadí motivu](/slides/cs/python-java/presentation-theme/)).

**Co se stane s pozadím, pokud později změníme motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [rozvržení](/slides/cs/python-java/slide-layout/)/[hlavní snímek](/slides/cs/python-java/slide-master/), aktualizuje se tak, aby odpovídalo [novému motivu](/slides/cs/python-java/presentation-theme/).