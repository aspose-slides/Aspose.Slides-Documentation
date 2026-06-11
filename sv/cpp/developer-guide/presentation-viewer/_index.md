---
title: Skapa en presentationsvisare i C++
linktitle: Presentationsvisare
type: docs
weight: 50
url: /sv/cpp/presentation-viewer/
keywords:
- visa presentation
- presentationsvisare
- skapa presentationsvisare
- visa PPT
- visa PPTX
- visa ODP
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Skapa en anpassad presentationsvisare i C++ med Aspose.Slides. Visa enkelt PowerPoint- och OpenDocument-filer utan Microsoft PowerPoint."
---
## **Introduktion**

Aspose.Slides för C++ används för att skapa presentationsfiler med bildspel. Dessa bildspel kan visas genom att öppna presentationerna i Microsoft PowerPoint, till exempel. I vissa fall kan utvecklare behöva visa bildspel som bilder i sin föredragna bildvisare eller skapa sin egen presentationsvisare. I sådana fall låter Aspose.Slides dig exportera en enskild bild som en bild. Den här artikeln beskriver hur du gör det.

## **Generera en SVG-bild från en bild**

För att generera en SVG-bild från en presentationsbild med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Öppna en filström.
1. Spara bilden som en SVG-bild till filströmmen.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Generera en SVG med ett anpassat form-ID**

Aspose.Slides kan användas för att generera en [SVG](https://docs.fileformat.com/page-description-language/svg/) från en bild med ett anpassat form-ID. För att göra detta, använd metoden `set_Id` från [ISvgShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` kan användas för att ange form-ID:t.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Skapa en miniatyrbild av en bild**

Aspose.Slides hjälper dig att generera miniatyrbilder av bildspel. För att generera en miniatyrbild av en bild med hjälp av Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med en definierad skala.
1. Spara miniatyrbilden i valfritt bildformat.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Skapa en miniatyrbild av en bild med användardefinierade dimensioner**

För att skapa en miniatyrbild av en bild med användardefinierade dimensioner, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med de definierade dimensionerna.
1. Spara miniatyrbilden i valfritt bildformat.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Skapa en miniatyrbild av en bild med presentatörsanteckningar**

För att generera miniatyrbilden av en bild med presentatörsanteckningar med Aspose.Slides, följ stegen nedan:

1. Skapa en instans av klassen [RenderingOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/).
1. Använd metoden `RenderingOptions.set_SlidesLayoutOptions` för att ange positionen för presentatörsanteckningarna.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta bildreferensen med dess index.
1. Hämta miniatyrbilden av den refererade bilden med renderingsalternativen.
1. Spara miniatyrbilden i valfritt bildformat.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Live-exempel**

Du kan prova den kostnadsfria appen [**Aspose.Slides Viewer**](https://products.aspose.app/slides/sv/viewer/) för att se vad du kan implementera med Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Kan jag bädda in en presentationsvisare i en webbapplikation?**

Ja. Du kan använda Aspose.Slides på serversidan för att rendera bildspel som bilder eller HTML och visa dem i webbläsaren. Navigations- och zoomfunktioner kan implementeras med JavaScript för en interaktiv upplevelse.

**Vad är det bästa sättet att visa bildspel i en anpassad visare?**

Den rekommenderade metoden är att rendera varje bild som en bild (t.ex. PNG eller SVG) eller konvertera den till HTML med Aspose.Slides, och sedan visa resultatet i en bildruta (för skrivbord) eller en HTML‑behållare (för webben).

**Hur hanterar jag stora presentationer med många bilder?**

För stora presentationer, överväg lazy‑loading eller rendera bilderna på begäran. Det innebär att generera en bilds innehåll endast när användaren navigerar till den, vilket minskar minnesanvändning och laddningstid.