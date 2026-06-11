---
title: Skapa miniatyrbilder av presentationsformer i Python
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/python-net/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrbilder från PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via .NET – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides för Python via .NET används för att skapa presentationsfiler där varje sida är en bild. Du kan visa dessa bilder i Microsoft PowerPoint genom att öppna presentationsfilen. Ibland kan utvecklare behöva se bilder av former separat i en bildvisare. I sådana fall kan Aspose.Slides skapa miniatyrbilder för bildformer. Den här artikeln förklarar hur du använder denna funktion.

## **Skapa miniatyrbilder för former från bilder**

När du behöver en förhandsgranskning av ett specifikt objekt istället för hela bilden kan du rendera en miniatyr för en enskild form. Aspose.Slides låter dig exportera vilken form som helst till en bild, vilket gör det enkelt att skapa lätta förhandsgranskningar, ikoner eller resurser för vidare bearbetning.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild via dess ID eller index.
1. Hämta en referens till en form på den bilden.
1. Rendera formens miniatyrbild.
1. Spara miniatyrbilden i önskat format.

Exempel nedan skapar en miniatyr av en form.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen för att öppna presentationsfilen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Skapa en bild med standardskalan.
    with shape.get_image() as thumbnail:
        # Spara bilden till disk i PNG-format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Skapa miniatyrbilder med en anpassad skalningsfaktor**

Detta avsnitt visar hur du genererar miniatyrbilder för former med en användardefinierad skalningsfaktor i Aspose.Slides. Genom att styra skalan kan du finjustera miniatyrstorleken för att passa förhandsgranskningar, export eller hög DPI-skärmar.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en bild via dess ID eller index.
1. Hämta målformen på den bilden.
1. Rendera miniatyrbilden av formen med den angivna skalan.
1. Spara miniatyrbilden i önskat format.

Exempel nedan genererar en miniatyr med en användardefinierad skalningsfaktor.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instansiera Presentation-klassen för att öppna presentationsfilen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Skapa en bild med den definierade skalan.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Spara bilden till disken i PNG-format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Skapa miniatyrbilder med en bilds visuella gränser**

Detta avsnitt visar hur du genererar en miniatyr inom en bilds utseendegränser. Det tar hänsyn till alla bildeffekter. Den genererade miniatyren begränsas av bildens gränser.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en bild via dess ID eller index.
1. Hämta målformen på den bilden.
1. Rendera miniatyrbilden av formen med de angivna gränserna.
1. Spara miniatyrbilden i önskat bildformat.

Exempel nedan skapar en miniatyr med användardefinierade gränser.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instansiera Presentation-klassen för att öppna presentationsfilen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Skapa en bild av formen med utseendegränser.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Spara bilden till disken i PNG-format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Vilka bildformat kan användas när man sparar miniatyrbilder för former?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/) genom att spara bildens innehåll som SVG.

**Vad är skillnaden mellan SHAPE- och APPEARANCE‑gränser när man renderar en miniatyr?**

`SHAPE` använder bildens geometri; `APPEARANCE` tar [visuella effekter](/slides/sv/python-net/shape-effect/) (skuggor, glöd, etc.) i beaktande.

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bara bildspelsvisning men hindrar inte bildgenerering för formen.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/) och [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/python-net/custom-font/) (eller [konfigurera typsnittsersättningar](/slides/sv/python-net/font-substitution/)) för att undvika oönskade reservtypsnitt och textomflyttning.