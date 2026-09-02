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
- visuella gränser
- formgränser
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för .NET – skapa och exportera enkelt presentationsminiatyrer."
---
## **Introduktion**

Aspose.Slides for .NET används för att skapa presentationsfiler där varje sida är en bildspelssida. Dessa bildspel kan visas genom att öppna presentationsfilerna med Microsoft PowerPoint. Men ibland kan utvecklare behöva se bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides for .NET dig att generera miniatyrbilder av bildspelskropparna. Hur du använder denna funktion beskrivs i den här artikeln.  
Den här artikeln förklarar hur du genererar bildspelsminiatyrer på olika sätt:

- Skapa en miniatyr för en form inuti ett bildspel.  
- Skapa en miniatyr för en form med användardefinierade dimensioner.  
- Skapa en miniatyr för en form inom ramen för formens utseende.

## **Generera en form‑miniatyr från ett bildspel**
För att generera en form‑miniatyr från valfritt bildspel med Aspose.Slides for .NET:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta referensen till valfritt bildspel med dess ID eller index.
1. Hämta formens miniatyrbild för det refererade bildspelet med standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en form‑miniatyr.

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

## **Generera en miniatyr med användardefinierad skalningsfaktor**
För att generera form‑miniatyr för valfri bildspelsform med Aspose.Slides for .NET:

1. Skapa en instans av klassen `Presentation`.
1. Hämta referensen till valfritt bildspel med dess ID eller index.
1. Hämta miniatyrbilden för det refererade bildspelet med formens begränsning.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyr med användardefinierad skalningsfaktor.

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

## **Skapa en miniatyr baserad på begränsning av formens utseende**
Denna metod för att skapa miniatyrbilder av former låter utvecklare generera en miniatyr inom ramen för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade form‑miniatyren begränsas av bildspelsramarna. För att generera en miniatyr av valfri bildspelsform inom dess utseenderam, använd följande exempel kod:

1. Skapa en instans av klassen `Presentation`.
1. Hämta referensen till valfritt bildspel med dess ID eller index.
1. Hämta miniatyrbilden för det refererade bildspelet med formens begränsning som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan skapar en miniatyr med användardefinierad skalningsfaktor.

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

## **Hämta de faktiska visuella gränserna för en form**

Rammeegenskaperna för [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/) — dess `X`, `Y`, `Width` och `Height`‑egenskaper — beskriver den rektangel som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller uppta en annan axelriktad rektangel. Rotation, konturer, pilspetsar, textlayout och översvämning, genererad SmartArt‑geometri och andra renderingseffekter kan alla förändra det upptagna området.

Använd [GetVisualBounds](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getvisualbounds/) för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar en [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) i bildspelskoordinater. Den returnerade rektangeln är inte beskuren till bildspelet, så dess koordinater kan vara negativa när innehållet sträcker sig bortom bildspelsursprunget.

[GetVisualBounds](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getvisualbounds/) är för närvarande inte deklarerad av [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)‑gränssnittet. Därför bör du behålla formen som hämtas från bildspelets formsamling som ett gränssnittsvärde och kasta den först när du anropar metoden.

Följande exempel hämtar och jämför ramen och de visuella gränserna:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Samma [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) kan användas för att justera närliggande former mot dess `Left`, `Right`, `Top` eller `Bottom`‑kant; reservera tillräckligt med utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar det fullständiga renderade resultatet.

Använd [GetVisualBounds](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getvisualbounds/) när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [IShape.GetImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/getimage/) när du behöver rendera formen. Med [ShapeThumbnailBounds](https://reference.aspose.com/slides/sv/net/aspose.slides/shapethumbnailbounds/) bestämmer `ShapeThumbnailBounds.Shape` bildens storlek utifrån formens begränsningar, inklusive konturinställningar, medan `ShapeThumbnailBounds.Appearance` bestämmer den utifrån formens utseende och begränsar resultatet till bildspelsramarna. I kontrast returnerar [GetVisualBounds](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getvisualbounds/) endast den beräknade rektangeln och beskär den inte till bildspelet.

## **FAQ**

**Vilka bildformat kan användas när man sparar form‑miniatyrer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/net/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser vid rendering av en miniatyr?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/net/shape-effect/) (skuggor, glöd osv.).

**Vad händer om en form är markerad som dold? Kommer den fortfarande att renderas som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bildspelsvisning men hindrar inte genereringen av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/net/custom-font/) (eller [konfigurera typsnittssubstitutioner](/slides/sv/net/font-substitution/)) för att undvika oönskade återgångar och textomflyttning.