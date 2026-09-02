---
title: Skapa miniatyrbilder av presentationsformer i Python
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/python-net/create-shape-thumbnails/
keywords:
- formminiatyr
- form bild
- rendera form
- formrendering
- visuella gränser
- formgränser
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint- och OpenDocument‑slides med Aspose.Slides för Python via .NET – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides for Python via .NET används för att skapa presentationsfiler där varje sida är en slide. Du kan visa dessa slides i Microsoft PowerPoint genom att öppna presentationsfilen. I vissa situationer kan utvecklare behöva visa bilder av former separat i en bildvisare. I sådana fall kan Aspose.Slides generera miniatyrbilder för slide‑former. Denna artikel förklarar hur du använder den här funktionen.

## **Generera miniatyrbilder för former från presentationer**

När du bara behöver en förhandsgranskning av ett specifikt objekt istället för hela sliden kan du rendera en miniatyr för en enskild form. Aspose.Slides låter dig exportera vilken form som helst till en bild, vilket gör det enkelt att skapa lätta förhandsgranskningar, ikoner eller resurser för vidare bearbetning.

För att generera en miniatyr från någon form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en slide med dess ID eller index.
1. Hämta en referens till en form på den sliden.
1. Rendera formens miniatyrbild.
1. Spara miniatyrbilden i önskat format.

Exemplet nedan genererar en miniatyr för en form.

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

## **Generera miniatyrbilder med en anpassad skalningsfaktor**

Detta avsnitt visar hur du genererar miniatyrbilder för former med en användardefinierad skalningsfaktor i Aspose.Slides. Genom att kontrollera skalan kan du finjustera miniatyrstorleken för förhandsgranskningar, export eller hög‑DPI‑skärmar.

För att generera en miniatyr för någon form på en slide:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en slide med dess ID eller index.
1. Hämta målformen på den sliden.
1. Rendera miniatyrbilden av formen med den angivna skalan.
1. Spara miniatyrbilden i önskat format.

Exemplet nedan genererar en miniatyr med en användardefinierad skalningsfaktor.

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
        # Spara bilden till disk i PNG-format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Generera miniatyrbilder med en forms utseendegränser**

Detta avsnitt visar hur du genererar en miniatyr inom en formens utseendegränser. Alla form‑effekter tas i beaktande. Den genererade miniatyren begränsas av slide‑gränserna.

För att generera en miniatyr av någon slide‑form inom dess utseendegränser:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en slide med dess ID eller index.
1. Hämta målformen på den sliden.
1. Rendera miniatyrbilden av formen med de angivna gränserna.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan skapar en miniatyr med användardefinierade gränser.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instansiera Presentation-klassen för att öppna presentationsfilen.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Skapa en bild av formen med utseendegränser.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Spara bilden till disk i PNG-format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Hämta den faktiska visuella gränsen för en form**

Ram‑egenskaperna för ett [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) — `Shape.x`, `Shape.y`, `Shape.width` och `Shape.height` — beskriver rektangeln som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller inneha en annan axel‑aligned rektangel. Rotation, konturer, pilspetsar, textlayout och översvämning, genererad SmartArt‑geometri och andra render‑effekter kan alla förändra det upptagna området.

Använd [Shape.get_visual_bounds](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_visual_bounds/) för att beräkna det området utan att skapa en bild. Metoden returnerar en flyttal‑rektangel i slide‑koordinater. Den returnerade rektangeln är inte klippt till sliden, så dess koordinater kan vara negativa när innehållet sträcker sig bortom slide‑ursprunget.

Följande exempel hämtar och jämför ramen och de visuella gränserna:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Samma rektangel kan användas för att justera närliggande former mot dess `left`, `right`, `top` eller `bottom` kant; reservera tillräckligt med utrymme i en genererad layout; eller upptäcka innehåll utanför en tillåten region. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar hela det renderade resultatet.

Använd [Shape.get_visual_bounds](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_visual_bounds/) när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [Shape.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/) när du behöver rendera formen. Med [ShapeThumbnailBounds](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.SHAPE` storlekar bilden efter formens gränser, inklusive konturinställningar, medan `ShapeThumbnailBounds.APPEARANCE` storlekar den efter formens utseende och begränsar resultatet till slide‑gränserna. I kontrast returnerar `Shape.get_visual_bounds` endast den beräknade rektangeln och klipper den inte till sliden.

## **FAQ**

**Vilka bildformat kan användas när du sparar miniatyrbilder för former?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan SHAPE‑ och APPEARANCE‑gränser när du renderar en miniatyr?**

`SHAPE` använder formens geometri; `APPEARANCE` tar hänsyn till [visuella effekter](/slides/sv/python-net/shape-effect/) (skuggor, glöd osv.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bara bildspelsvisning och hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de erforderliga typsnitten](/slides/sv/python-net/custom-font/) (eller [konfigurera typsnitts‑substitutioner](/slides/sv/python-net/font-substitution/)) för att undvika oönskade fallback‑typsnitt och text‑omflöde.