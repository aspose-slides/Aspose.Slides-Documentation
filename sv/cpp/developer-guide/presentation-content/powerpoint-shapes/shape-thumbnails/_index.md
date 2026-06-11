---
title: Skapa miniatyrbilder av presentationsformer i C++
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/cpp/shape-thumbnails/
keywords:
- formminiatyr
- formbild
- rendera form
- formrendering
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för C++ – skapa och exportera presentationsminiatyrer enkelt."
---
## **Introduktion**

Aspose.Slides används för att skapa presentationsfiler där varje sida är en bild. Dessa bilder kan visas genom att öppna presentationsfilerna med Microsoft PowerPoint. Men ibland kan utvecklare behöva se bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides dig att generera miniatyrbilder av bildformerna. Hur du använder den här funktionen beskrivs i den här artikeln.  
Den här artikeln förklarar hur man genererar bildminiatyrer på olika sätt:

- Skapa en miniatyr av en form inuti en bild.  
- Skapa en miniatyr av en form för en bildform med användardefinierade dimensioner.  
- Skapa en miniatyr av en form inom gränserna för formens utseende.

## **Skapa en miniatyr av en form från en bild**
För att skapa en miniatyr av en form från någon bild med Aspose.Slides för C++:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).  
1. Hämta referensen till någon bild genom dess ID eller index.  
1. Hämta miniatyrbilden av formen för den refererade bilden i standardskala.  
1. Spara miniatyrbilden i önskat bildformat.  

Exemplet nedan genererar en formminiatyr.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Skapa en miniatyr med användardefinierad skalningsfaktor**
För att skapa en miniatyr av en form för någon bildform med Aspose.Slides för C++:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).  
1. Hämta referensen till någon bild genom dess ID eller index.  
1. Hämta miniatyrbilden av den refererade bilden med formens gränser.  
1. Spara miniatyrbilden i önskat bildformat.  

Exemplet nedan genererar en miniatyr med en användardefinierad skalningsfaktor.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Skalning längs X- och Y-axlarna.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Skapa en miniatyr av formens utseende baserat på gränser**
Denna metod för att skapa miniatyrer av former låter utvecklare generera en miniatyr inom gränserna för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade formminiatyren begränsas av bildens gränser. För att skapa en miniatyr av någon bildform inom dess utseendes gränser, använd följande exempel kod:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).  
1. Hämta referensen till någon bild genom dess ID eller index.  
1. Hämta miniatyrbilden av den refererade bilden med formens gränser som utseende.  
1. Spara miniatyrbilden i önskat bildformat.  

Exemplet nedan skapar en miniatyr med en användardefinierad skalningsfaktor.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Skalning längs X- och Y-axlarna.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Vilka bildformat kan användas när man sparar form‑miniatyrer?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape- och Appearance-gränser när en miniatyr renderas?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/cpp/shape-effect/) (skuggor, glöd, etc.).

**Vad händer om en form är markerad som dold? Kommer den fortfarande att renderas som en miniatyr?**

En dold form förblir en del av modellen och kan renderas; dolda‑flaggan påverkar endast bildspelsvisning men hindrar inte generering av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/) och [SmartArt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartart/)) kan sparas som en miniatyr eller som SVG.

**Påverkar systeminstallerade typsnitt kvaliteten på miniatyrer för textformer?**

Ja. Du bör [tillhandahålla de nödvändiga typsnitten](/slides/sv/cpp/custom-font/) (eller [konfigurera typsnittsersättningar](/slides/sv/cpp/font-substitution/)) för att undvika oönskade fallback‑typsnitt och textomflyttning.