---
title: Creare un visualizzatore di presentazioni in .NET
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/net/presentation-viewer/
keywords:
- visualizzare presentazione
- visualizzatore di presentazioni
- creare visualizzatore di presentazioni
- visualizzare PPT
- visualizzare PPTX
- visualizzare ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Creare un visualizzatore di presentazioni personalizzato in .NET usando Aspose.Slides. Visualizza facilmente file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides per .NET viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, gli sviluppatori a volte hanno bisogno di visualizzare le diapositive come immagini nel loro visualizzatore di immagini preferito o di usarle in un visualizzatore di presentazioni personalizzato. In questi casi, Aspose.Slides consente di esportare singole diapositive come immagini. Questo articolo spiega come farlo.

## **Generare un'immagine SVG da una diapositiva**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Apri un flusso di file.
1. Salva la diapositiva come immagine SVG nel flusso di file.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Generare un SVG con un ID Forma Personalizzato**

Aspose.Slides può essere usato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una diapositiva con un `ID` forma personalizzato. Per ottenere ciò, utilizza la proprietà Id dell'interfaccia [ISvgShape](https://reference.aspose.com/slides/it/net/aspose.slides.export/isvgshape). La classe `CustomSvgShapeFormattingController` può essere usata per impostare l'ID della forma.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Creare un'immagine miniatura di una diapositiva**

Aspose.Slides ti aiuta a generare immagini miniatura delle diapositive. Per generare una miniatura di una diapositiva usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Crea un'immagine miniatura della diapositiva di riferimento alla scala desiderata.
1. Salva l'immagine miniatura nel formato immagine preferito.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Creare una miniatura di diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura di diapositiva con dimensioni definite dall'utente, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Genera un'immagine miniatura della diapositiva di riferimento con le dimensioni specificate.
1. Salva l'immagine miniatura nel formato immagine preferito.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Creare una miniatura di diapositiva con note del relatore**

Per generare una miniatura di una diapositiva con note del relatore usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/renderingoptions/).
1. Usa la proprietà `RenderingOptions.SlidesLayoutOptions` per impostare la posizione delle note del relatore.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni un riferimento alla diapositiva tramite il suo indice.
1. Genera un'immagine miniatura della diapositiva di riferimento usando le opzioni di rendering.
1. Salva l'immagine miniatura nel formato immagine preferito.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Esempio live**

Prova l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa puoi implementare con l'API di Aspose.Slides:

[![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/it/viewer/)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web ASP.NET?**

Sì. Puoi usare Aspose.Slides sul lato server per renderizzare le diapositive come immagini o HTML e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore .NET personalizzato?**

Il metodo consigliato è renderizzare ogni diapositiva come immagine (ad esempio PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare l'output all'interno di un picture box (per desktop) o di un contenitore HTML (per il web).

**Come gestire presentazioni di grandi dimensioni con molte diapositive?**

Per presentazioni di grandi dimensioni, valuta il lazy-loading o il rendering on-demand delle diapositive. Questo significa generare il contenuto di una diapositiva solo quando l'utente vi naviga, riducendo l'uso della memoria e i tempi di caricamento.