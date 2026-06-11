---
title: Skapa miniatyrbilder av presentationsformer i .NET
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/net/create-shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för .NET - skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides for .NET används för att skapa presentationsfiler där varje sida är en bild. Dessa bilder kan visas genom att öppna presentationsfilerna i Microsoft PowerPoint. Ibland kan utvecklare behöva se formernas bilder separat i en bildvisare. I sådana fall hjälper Aspose.Slides for .NET dig att generera miniatyrbilder av bildformer. Hur du använder denna funktion beskrivs i den här artikeln.
Denna artikel förklarar hur du genererar bildminiatyrer på olika sätt:

- Generera en formminiatyr inuti en bild.
- Generera en formminiatyr för en bildform med användardefinierade dimensioner.
- Generera en formminiatyr inom ramen för en forms utseende.

## **Generera en Formminiatyr Från en Bild**
För att generera en formminiatyr från vilken bild som helst med Aspose.Slides for .NET:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta referensen till vilken bild som helst med dess ID eller index.
1. Hämta formens miniatyrbild för den refererade bilden på standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en formminiatyr.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Generera en Miniatyr med Användardefinierad Skalningsfaktor**
För att generera formminiatyren för någon bildform med Aspose.Slides for .NET:

1. Skapa en instans av klassen `Presentation`.
1. Hämta referensen till vilken bild som helst med dess ID eller index.
1. Hämta miniatyrbilden för den refererade bilden med formens gränser.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyr med en användardefinierad skalningsfaktor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Skalning längs X- och Y-axlarna.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Skapa en Miniatyr Baserad på Formens Utseende och Gränser**
Denna metod för att skapa miniatyrer av former låter utvecklare generera en miniatyr inom ramen för formens utseende. Den tar hänsyn till alla formens effekter. Den genererade formminiatyren begränsas av bildens gränser. För att generera en miniatyr av någon bildform inom dess utseende, använd följande exempelkod:

1. Skapa en instans av klassen `Presentation`.
1. Hämta referensen till vilken bild som helst med dess ID eller index.
1. Hämta miniatyrbilden för den refererade bilden med formens gränser som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan skapar en miniatyr med en användardefinierad skalningsfaktor.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Skalning längs X- och Y-axlarna.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Vilka bildformat kan användas när man sparar formminiatyrer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Form‑ och Utseende‑gränser vid rendering av en miniatyr?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/net/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Renderas den fortfarande som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bara bildspelsvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade teckensnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga teckensnitten](/slides/sv/net/custom-font/) (eller [konfigurera teckensnitts‑substitution](/slides/sv/net/font-substitution/)) för att undvika oönskade fallback‑teckensnitt och textomflyttning.