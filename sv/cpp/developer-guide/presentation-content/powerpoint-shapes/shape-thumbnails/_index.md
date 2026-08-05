---
title: Skapa miniatyrbilder av presentationsformer i C++
linktitle: Formminiatyrer
type: docs
weight: 70
url: /sv/cpp/shape-thumbnails/
keywords:
- formminiatyr
- form bild
- rendera form
- formrendering
- visuella gränser
- formgränser
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Generera högkvalitativa formminiatyrer från PowerPoint-bilder med Aspose.Slides för C++ – skapa och exportera enkelt presentationsminiatyrer."
---
## **Introduktion**

Aspose.Slides används för att skapa presentationsfiler där varje sida är ett bildspel. Dessa bildspel kan visas genom att öppna presentationsfilerna med Microsoft PowerPoint. Men ibland kan utvecklare behöva se bilderna av formerna separat i en bildvisare. I sådana fall hjälper Aspose.Slides dig att generera miniatyrbilder av bildspelsformer. Hur du använder denna funktion beskrivs i den här artikeln.

Den här artikeln förklarar hur du genererar bildspelsminiatyrer på olika sätt:

- Generera en miniatyrbild av en form inom ett bildspel.
- Generera en miniatyrbild av en form för en bildspelsform med användardefinierade dimensioner.
- Generera en miniatyrbild av en form inom gränserna för formens utseende.

## **Generera en miniatyrbild av en form från ett bildspel**

För att generera en miniatyrbild av en form från ett bildspel med Aspose.Slides för C++:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
1. Hämta referensen till ett bildspel med dess ID eller index.
1. Hämta miniatyrbilden av formen för det refererade bildspelsbladet i standardskala.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyrbild av en form.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Generera en miniatyrbild med användardefinierad skalningsfaktor**

För att generera en miniatyrbild av en form för ett bildspelsobjekt med Aspose.Slides för C++:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
1. Hämta referensen till ett bildspel med dess ID eller index.
1. Hämta miniatyrbilden för det refererade bildspelsbladet med formens avgränsningar.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyrbild med en användardefinierad skalningsfaktor.

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

## **Skapa en miniatyrbild av formens utseende baserat på avgränsningar**

Denna metod för att skapa miniatyrbilder av former låter utvecklare generera en miniatyrbild inom avgränsningarna för formens utseende. Den tar hänsyn till alla formeffekter. Den genererade formminiatyrbilden begränsas av bildspelsavgränsningarna. För att generera en miniatyrbild av en form i ett bildspel inom dess utseendes avgränsningar, använd följande exempel kod:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
1. Hämta referensen till ett bildspel med dess ID eller index.
1. Hämta miniatyrbilden för det refererade bildspelsbladet med formens avgränsningar som utseende.
1. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan skapar en miniatyrbild med en användardefinierad skalningsfaktor.

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

## **Hämta de faktiska visuella gränserna för en form**

Ram‑egenskaperna för [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/) — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` och `IShape::get_Height()` — beskriver rektangeln som lagras i presentationsmodellen. Innehållet som faktiskt renderas kan sträcka sig utanför den ramen eller uppta en annan axelriktad rektangel. Rotation, konturer, pilspetsar, textlayout och översvämning, genererad SmartArt-geometri och andra renderingeffekter kan alla förändra det upptagna området.

Använd [Shape::GetVisualBounds](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getvisualbounds/) för att beräkna det upptagna området utan att skapa en bild. Metoden returnerar en [RectangleF](https://reference.aspose.com/slides/sv/cpp/system.drawing/rectanglef/) i bildspelskoordinater. Den returnerade rektangeln är inte beskuren till bildspelet, så dess koordinater kan vara negativa när innehållet sträcker sig bortom bildspelsursprunget.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getvisualbounds/) är för närvarande inte deklarerad i [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/)‑gränssnittet. Därför bör du behålla formen som hämtas från bildspels formsamling som ett gränssnittsvärde och endast kasta den när du anropar metoden.

Följande exempel hämtar och jämför ram‑ och visuella gränser:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Samma [RectangleF](https://reference.aspose.com/slides/sv/cpp/system.drawing/rectanglef/) kan användas för att rikta in närliggande former mot dess `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` eller `RectangleF::get_Bottom()` kant; reservera tillräckligt utrymme i en genererad layout; eller upptäcka innehåll utanför ett tillåtet område. Visuella gränser är särskilt användbara för SmartArt, textrutor, pilar, bilder, roterade former och gruppformer, där den lagrade ramen kanske inte representerar det fullständiga renderade resultatet.

Använd [Shape::GetVisualBounds](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getvisualbounds/) när du behöver koordinater för layout eller validering och inte behöver en bitmap. Använd [IShape::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/getimage/) när du behöver rendera formen. Med [ShapeThumbnailBounds](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapethumbnailbounds/) använder `ShapeThumbnailBounds::Shape` bildens storlek från formens avgränsningar, inklusive konturinställningar, medan `ShapeThumbnailBounds::Appearance` storlekar den utifrån formens utseende och begränsar resultatet till bildspelsgränserna. Däremot returnerar [Shape::GetVisualBounds](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getvisualbounds/) endast den beräknade rektangeln och beskär den inte till bildspelet.

## **FAQ**

**Vilka bildformat kan användas när du sparar miniatyrbilder av former?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/sv/cpp/aspose.slides/imageformat/), och andra. Former kan också [exporteras som vektor‑SVG](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/) genom att spara formens innehåll som SVG.

**Vad är skillnaden mellan Shape‑ och Appearance‑gränser när du renderar en miniatyrbild?**

`Shape` använder formens geometri; `Appearance` tar hänsyn till [visuella effekter](/slides/sv/cpp/shape-effect/) (skuggor, glöd, osv).

**Vad händer om en form är markerad som dold? Kommer den fortfarande att renderas som en miniatyrbild?**

En dold form förblir en del av modellen och kan renderas; den dolda flaggan påverkar bildspelsvisning men hindrar inte genereringen av formens bild.

**Stöds gruppformer, diagram, SmartArt och andra komplexa objekt?**

Ja. Alla objekt som representeras som [Shape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/) (inklusive [GroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/), och [SmartArt](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartart/)) kan sparas som en miniatyrbild eller som SVG.

**Påverkar systeminstallerade teckensnitt kvaliteten på miniatyrbilder för textformer?**

Ja. Du bör [tillhandahålla de erforderliga teckensnitten](/slides/sv/cpp/custom-font/) (eller [konfigurera teckensnitts substitutioner](/slides/sv/cpp/font-substitution/)) för att undvika oönskade ersättningar och textomflyttning.