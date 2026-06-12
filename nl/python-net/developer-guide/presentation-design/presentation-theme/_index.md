---
title: "Beheer PowerPoint-presentatiethema's in Python"
linktitle: "Presentatiethema"
type: docs
weight: 10
url: /nl/python-net/presentation-theme/
keywords:
- PowerPoint-thema
- presentatiethema
- dia-thema
- thema instellen
- thema wijzigen
- thema beheren
- themakleur
- extra palet
- themalettertype
- themastijl
- thema-effect
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer presentatiethema's in Aspose.Slides voor Python via .NET om PowerPoint-bestanden te maken, aanpassen en converteren met consistente huisstijl."
---
## **Inleiding**

Een presentatiethema definieert de eigenschappen van zijn ontwerpelementen. Wanneer u een thema selecteert, kiest u een gecoördineerde set visuele elementen en hun eigenschappen.

In PowerPoint omvat een thema kleuren, [lettertypen](/slides/nl/python-net/powerpoint-fonts/), [achtergrondstijlen](/slides/nl/python-net/presentation-background/), en effecten.

![thema-onderdelen](theme-constituents.png)

## **De themakleur wijzigen**

Een PowerPoint‑thema gebruikt een specifieke set kleuren voor verschillende elementen op een dia. Als u de standaardkleuren niet bevalt, kunt u ze wijzigen door nieuwe themakleuren toe te passen. Om u een nieuwe themakleur te laten kiezen, biedt Aspose.Slides waarden in de [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/) opsomming.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

U kunt de effectieve waarde van de resulterende kleur als volgt bepalen:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Voorbeeldoutput:
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Om de kleuraanpassing verder te demonstreren, creëren we een ander element, wijzen we het de accentkleur toe uit de eerste stap, en passen we vervolgens de themakleur aan.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

De nieuwe kleur wordt automatisch toegepast op beide elementen.

### **Een themakleur instellen vanuit het extra palet**

Wanneer u luminantietransformaties toepast op de hoofdthematiek (1), worden kleuren uit het extra palet (2) gegenereerd. U kunt vervolgens die themakleuren instellen en ophalen.

![kleuren-van-extra-palet](additional-palette-colors.png)

**1** — Hoofdthematische kleuren  
**2** — Kleuren uit het extra palet  

Deze Python‑code toont hoe extra‑paletkleuren worden afgeleid van de hoofdthematiek en vervolgens worden gebruikt in vormen:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Accent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Accent 4, 80% lichter
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Accent 4, 60% lichter
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Accent 4, 40% lichter
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Accent 4, 25% donkerder
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Accent 4, 50% donkerder
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Map `SchemeColor` naar `ColorScheme`-kleuren**

Wanneer u werkt met [SchemeColor](https://reference.aspose.com/slides/nl/python-net/aspose.slides/schemecolor/), kunt u merken dat het de volgende themakleurwaarden bevat:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` en `TEXT2`.

Echter, `Presentation.master_theme.color_scheme` retourneert [ColorScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/colorscheme/), die de overeenkomende kleuren weergeeft als:

`dark1`, `dark2`, `light1` en `light2`.

Dit verschil zit alleen in de benaming. Deze waarden verwijzen naar dezelfde themakleurposities en de toewijzing is vast:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Er is geen dynamische conversie tussen `TEXT`/`BACKGROUND` en `dark`/`light`. Het zijn simpelweg alternatieve namen voor dezelfde themakleuren.

Dit benoemingsverschil komt voort uit de terminologie van Microsoft Office. Oudere Office‑versies gebruikten `Dark 1`, `Light 1`, `Dark 2` en `Light 2`, terwijl nieuwere UI‑versies dezelfde posities tonen als `Text 1`, `Background 1`, `Text 2` en `Background 2`.

## **Themalettertype wijzigen**

Om u in staat te stellen lettertypen voor thema's en andere doeleinden te selecteren, gebruikt Aspose.Slides deze speciale identificatoren (vergelijkbaar met die in PowerPoint):

- **+mn-lt** — Body Font Latin (Minor Latin Font)
- **+mj-lt** — Heading Font Latin (Major Latin Font)
- **+mn-ea** — Body Font East Asian (Minor East Asian Font)
- **+mj-ea** — Heading Font East Asian (Major East Asian Font)

Deze Python‑code toont hoe u het Latijnse lettertype aan een themaelement toewijst:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Dit Python‑voorbeeld toont hoe u het themalettertype van de presentatie wijzigt:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Alle tekstvakjes worden bijgewerkt naar het nieuwe lettertype.

{{% alert color="primary" title="TIP" %}}
Voor meer informatie, zie [Master PowerPoint Fonts with Python](/slides/nl/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Achtergrondstijl van het thema wijzigen**

Standaard biedt PowerPoint 12 vooraf gedefinieerde achtergronden, maar een typische presentatie slaat er slechts 3 op.

![todo:image_alt_text](presentation-design_8.png)

Bijvoorbeeld, nadat u een presentatie in PowerPoint hebt opgeslagen, kunt u de volgende Python‑code uitvoeren om te bepalen hoeveel vooraf gedefinieerde achtergronden deze bevat:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Met de `background_fill_styles`‑eigenschap van de [FormatScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/) klasse kunt u achtergrondstijlen toevoegen of benaderen in een PowerPoint‑thema.
{{% /alert %}}

Dit Python‑voorbeeld toont hoe u de presentatie‑achtergrond instelt:

```python
presentation.masters[0].background.style_index = 2  # 0 betekent geen vulling; indexering start bij 1.
```

{{% alert color="primary" title="TIP" %}}
Voor meer informatie, zie [Manage Presentation Backgrounds in Python](/slides/nl/python-net/presentation-background/).
{{% /alert %}}

## **Thema‑effecten wijzigen**

Een PowerPoint‑thema bevat doorgaans drie waarden in elke stijlarray. Deze arrays combineren tot drie effectniveaus: subtiel, gematigd en intens. Bijvoorbeeld, dit is het resultaat wanneer die effecten worden toegepast op een specifieke vorm:

![todo:image_alt_text](presentation-design_10.png)

Met de drie eigenschappen—`FillStyles`, `LineStyles` en `EffectStyles`—van de [FormatScheme](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/formatscheme/) klasse kunt u themaelementen aanpassen (nog flexibeler dan in PowerPoint).

Deze Python‑code toont hoe u een thema‑effect wijzigt door delen van die elementen aan te passen:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

De resulterende wijzigingen omvatten updates van de vulkleur, vultype, schaduweffect en andere eigenschappen:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kan ik een thema toepassen op één dia zonder de master te wijzigen?**  
Ja. Aspose.Slides ondersteunt thema‑overschrijvingen op dia‑niveau, zodat u een lokaal thema kunt toepassen op alleen die dia terwijl het master‑thema onaangeroerd blijft (via de [SlideThemeManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.theme/slidethememanager/)).

**Wat is de veiligste manier om een thema van de ene presentatie naar de andere over te dragen?**  
[Clone slides](/slides/nl/python-net/clone-slides/) samen met hun master naar de doelpresentatie. Dit behoudt de oorspronkelijke master, lay‑outs en het bijbehorende thema zodat het uiterlijk consistent blijft.

**Hoe kan ik de “effectieve” waarden zien na alle overerving en overschrijvingen?**  
Gebruik de “effective” weergaven van de API [/slides/nl/python-net/shape-effective-properties/] voor thema/kleur/lettertype/effect. Deze geven de opgeloste, definitieve eigenschappen terug na het toepassen van de master en eventuele locale overschrijvingen.