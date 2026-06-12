---
title: Crea un visualizzatore di presentazioni in Java
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "Crea un visualizzatore di presentazioni personalizzato in Java usando Aspose.Slides. Visualizza facilmente file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides for Java è usato per creare file di presentazione con slide. Queste slide possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le slide come immagini nel loro visualizzatore di immagini preferito o creare il proprio visualizzatore di presentazioni. In tali casi, Aspose.Slides consente di esportare una singola slide come immagine. Questo articolo descrive come farlo.

## **Genera un'immagine SVG da una slide**

Per generare un'immagine SVG da una slide di presentazione con Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla slide per indice.
1. Apri uno stream di file.
1. Salva la slide come immagine SVG nello stream di file.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Genera un SVG con ID forma personalizzato**

Aspose.Slides può essere usato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una slide con un ID forma personalizzato. Per fare ciò, usa il metodo `setId` di [ISvgShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` può essere usato per impostare l'ID forma.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Crea un'immagine thumbnail della slide**

Aspose.Slides ti aiuta a generare immagini thumbnail delle slide. Per generare una thumbnail di una slide usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla slide per indice.
1. Ottieni l'immagine thumbnail della slide di riferimento a una scala definita.
1. Salva l'immagine thumbnail in qualsiasi formato immagine desiderato.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Crea una thumbnail della slide con dimensioni definite dall'utente**

Per creare un'immagine thumbnail della slide con dimensioni definite dall'utente, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla slide per indice.
1. Ottieni l'immagine thumbnail della slide di riferimento con le dimensioni definite.
1. Salva l'immagine thumbnail in qualsiasi formato immagine desiderato.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Crea una thumbnail della slide con note del relatore**

Per generare la thumbnail di una slide con note del relatore usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/renderingoptions/).
1. Usa il metodo `RenderingOptions.setSlidesLayoutOptions` per impostare la posizione delle note del relatore.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla slide per indice.
1. Ottieni l'immagine thumbnail della slide di riferimento con le opzioni di rendering.
1. Salva l'immagine thumbnail in qualsiasi formato immagine desiderato.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Esempio live**

Puoi provare l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa puoi implementare con l'API Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web?**

Sì. Puoi usare Aspose.Slides sul lato server per renderizzare le slide come immagini o HTML e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le slide all'interno di un visualizzatore personalizzato?**

L'approccio consigliato è renderizzare ogni slide come immagine (ad esempio PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare l'output in un picture box (per desktop) o contenitore HTML (per web).

**Come gestire presentazioni di grandi dimensioni con molte slide?**

Per deck di grandi dimensioni, considera il lazy-loading o il rendering on-demand delle slide. Questo significa generare il contenuto di una slide solo quando l'utente vi naviga, riducendo memoria e tempo di caricamento.