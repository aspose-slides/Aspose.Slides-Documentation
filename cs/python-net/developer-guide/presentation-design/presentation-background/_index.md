---
title: Správa pozadí prezentace v Pythonu
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/python-net/presentation-background/
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
- Python
- Aspose.Slides
description: "Naučte se, jak nastavit dynamické pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo **hlavní snímek** (platí pro více snímků najednou).

![PowerPoint background](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides vám umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá hlavní snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/backgroundtype/) snímku na `OWN_BACKGROUND`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) pozadí snímku na `SOLID`.
4. Použijte vlastnost `solid_fill_color` na [FillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/) pro určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí pro normální snímek:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Nastavte barvu pozadí snímku na modrou.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Uložte prezentaci na disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení jednobarevného pozadí pro hlavní snímek**

Aspose.Slides vám umožňuje nastavit jednobarevnou barvu jako pozadí hlavního snímku v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednobarevnou barvu pro pozadí hlavního snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/backgroundtype/) hlavního snímku (prostřednictvím `masters`) na `OWN_BACKGROUND`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) pozadí hlavního snímku na `SOLID`.
4. Použijte vlastnost `solid_fill_color` na [FillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/) pro určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit jednobarevnou barvu (lesní zelená) jako pozadí pro hlavní snímek:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Nastavte barvu pozadí hlavního snímku na lesní zelenou.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Uložte prezentaci na disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení gradientového pozadí pro snímek**

Gradient je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může gradient učinit prezentaci umělečtější a profesionálnější. Aspose.Slides vám umožňuje nastavit gradientovou barvu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/backgroundtype/) snímku na `OWN_BACKGROUND`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) pozadí snímku na `GRADIENT`.
4. Použijte vlastnost `gradient_format` na [FillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/) pro konfiguraci požadovaných nastavení gradientu.
5. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit gradientovou barvu jako pozadí pro snímek:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Použijte gradientový efekt na pozadí.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Uložte prezentaci na disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a gradientních výplní vám Aspose.Slides umožňuje používat obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/backgroundtype/) snímku na `OWN_BACKGROUND`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) pozadí snímku na `PICTURE`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte vlastnost `picture_fill_format` na [FillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/) pro přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v Pythonu ukazuje, jak nastavit obrázek jako pozadí pro snímek:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Nastavte vlastnosti obrázku pozadí.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Načtěte obrázek.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Přidejte obrázek do kolekce obrázků prezentace.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Uložte prezentaci na disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Následující ukázkový kód ukazuje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dlaždicování:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Nastavte obrázek použitý pro výplň pozadí.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Nastavte režim výplně obrázku na Dlaždice a upravte vlastnosti dlaždic.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Přečtěte si více: [**Tile Picture As Texture**](/slides/cs/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku pozadí**

Možná budete chtít upravit průhlednost obrázku pozadí snímku, aby obsah snímku vynikl. Následující kód v Pythonu ukazuje, jak změnit průhlednost obrázku pozadí snímku:

```python
transparency_value = 30  # Například.

# Získejte kolekci operací transformace obrázku.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Najděte existující efekt průhlednosti s pevnou procentuální hodnotou.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Nastavte novou hodnotu průhlednosti.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje třídu [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Tato třída vystavuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/effectformat/).

Pomocí vlastnosti `background` třídy [BaseSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad v Pythonu ukazuje, jak získat efektivní hodnotu pozadí snímku:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Získejte efektivní pozadí, s ohledem na hlavní snímek, rozvržení a motiv.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **Často kladené otázky**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/rozvržení?**

Ano. Odeberte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího snímku [layout](/slides/cs/python-net/slide-layout/)/[master](/slides/cs/python-net/slide-master/) (tj. [theme background](/slides/cs/python-net/presentation-theme/)).

**Co se stane s pozadím, pokud později změníte motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane beze změny. Pokud je pozadí zděděno z [layout](/slides/cs/python-net/slide-layout/)/[master](/slides/cs/python-net/slide-master/), aktualizuje se tak, aby odpovídalo [new theme](/slides/cs/python-net/presentation-theme/).