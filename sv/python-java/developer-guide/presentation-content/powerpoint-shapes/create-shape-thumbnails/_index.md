---
title: Skapa miniatyrbilder av presentationsformer i Python via Java
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/python-java/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- visuella gränser
- formgränser
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Generera högkvalitativa miniatyrbilder av former från PowerPoint‑bilder med Aspose.Slides för Python via Java – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides för Python via Java kan användas för att skapa presentationsfiler där varje sida motsvarar en bild. Bilderna kan visas genom att öppna presentationsfilerna i Microsoft PowerPoint. Ibland behöver utvecklare dock visa formernas bilder separat i en bildvisare. I sådana fall hjälper Aspose.Slides för Python via Java dem att generera miniatyrbilder av bildformerna.

Denna artikel förklarar hur man genererar miniatyrbilder för former på olika sätt:

- Generera en miniatyrbild för en form inom en bild.
- Generera en miniatyrbild för en bildform med användardefinierade dimensioner.
- Generera en miniatyrbild inom gränserna för en forms utseende.

## **Generera en miniatyrbild för en form från en bild**
För att generera en miniatyrbild för en form från vilken bild som helst med Aspose.Slides för Python via Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess ID eller index.
1. [Hämta miniatyrbilden för en form](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) på den refererade bilden med standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod visar hur du genererar en miniatyrbild för en form från en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Instansiera en Presentation‑klass som representerar presentationsfilen.
presentation = Presentation("Thumbnail.pptx")
try:
    # Skapa en bild i full skala.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Spara bilden till disk i PNG‑format.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Generera en miniatyrbild med en användardefinierad skalningsfaktor**
För att generera miniatyrbilden för en form på en bild med Aspose.Slides för Python via Java, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess ID eller index.
1. [Hämta miniatyrbilden för en form](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) på den refererade bilden med användardefinierade dimensioner.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod visar hur du genererar en miniatyrbild för en form baserat på en definierad skalningsfaktor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instansiera en Presentation‑klass som representerar presentationsfilen.
presentation = Presentation("Thumbnail.pptx")
try:
    # Skapa en bild skalad med en faktor på 2 i båda riktningarna.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Spara bilden till disk i PNG‑format.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Skapa en miniatyrbild baserad på formens gränser**
Denna metod för att skapa miniatyrbilder av former gör det möjligt för utvecklare att generera en miniatyrbild inom formens utseendets gränser. Den tar hänsyn till alla formeffekter. Den genererade miniatyrbilden begränsas av bildens gränser. För att generera en miniatyrbild av en bildform inom dess utseendegränser, gör så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess ID eller index.
1. Hämta miniatyrbilden för en form på den refererade bilden med hjälp av dess utseendegränser.
1. Spara miniatyrbilden i önskat bildformat.

Denna exempelkod är baserad på stegen ovan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Instansiera en Presentation-klass som representerar presentationsfilen.
presentation = Presentation("Thumbnail.pptx")
try:
    # Skapa en bild i full skala.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Spara bilden till disk i PNG-format.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Hämta de faktiska visuella gränserna för en form**

Ramverksegenskaperna för [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/)—dess [getX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getWidth) och [getHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getHeight)‑metoder—beskriver rektangeln som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller uppta en annan axel‑justerad rektangel. Rotation, konturer, pilspetsar, textlayout och översvämning, genererad SmartArt‑geometri och andra renderingseffekter kan alla förändra det upptagna området.

Använd [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getVisualBounds) för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar ett [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) i bildkoordinater. Den returnerade rektangeln är inte beskuren till bilden, så dess koordinater kan vara negativa när innehållet sträcker sig utanför bildens ursprung.

Följande exempel hämtar och jämför ramen och de visuella gränserna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Samma [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kan användas för att justera intilliggande former till dess vänstra, högra, övre eller nedre kant; reservera tillräckligt utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar det fullständiga renderade resultatet.

Använd [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getVisualBounds) när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [Shape.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) när du behöver rendera formen. Med [ShapeThumbnailBounds](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapethumbnailbounds/) storlekar [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapethumbnailbounds/#Shape) bilden utifrån formens gränser, inklusive konturinställningar, medan [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapethumbnailbounds/#Appearance) storlekar den utifrån formens utseende och begränsar resultatet till bildens gränser. I kontrast returnerar [Shape.getVisualBounds](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getVisualBounds) endast den beräknade rektangeln och beskär den inte till bilden.

## **FAQ**

**Vilka bildformat kan användas när man sparar miniatyrbilder för former?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#writeAsSvgToBytes) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser när en miniatyrbild renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/python-java/shape-effect/) (skuggor, glöd osv.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyrbild?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bildspelsvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/) och [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)) kan sparas som en miniatyrbild eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrbilder för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/python-java/custom-font/) (eller [konfigurera typsnittsbyten](/slides/sv/python-java/font-substitution/)) för att undvika oönskade fallback‑typsnitt och textomflyttning.