---
title: Crea un Visualizzatore di Presentazioni su Android
linktitle: Visualizzatore di Presentazioni
type: docs
weight: 50
url: /it/androidjava/presentation-viewer/
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
- Android
- Java
- Aspose.Slides
description: "Crea un visualizzatore di presentazioni personalizzato in Java utilizzando Aspose.Slides per Android. Visualizza facilmente file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides per Android via Java viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le diapositive come immagini nel loro visualizzatore di immagini preferito o di creare il proprio visualizzatore di presentazioni. In tal caso, Aspose.Slides consente di esportare una singola diapositiva come immagine. Questo articolo descrive come farlo.

## **Generare un'immagine SVG da una diapositiva**

Per generare un'immagine SVG da una diapositiva di una presentazione con Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Apri un flusso di file.
1. Salva la diapositiva come immagine SVG nel flusso di file.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generare un SVG con un ID di forma personalizzato**

Aspose.Slides può essere utilizzato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una diapositiva con un ID di forma personalizzato. Per fare ciò, utilizza il metodo `setId` di [ISvgShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` può essere usato per impostare l'ID della forma.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Creare un'immagine miniatura di una diapositiva**

Aspose.Slides ti aiuta a generare immagini miniatura delle diapositive. Per generare una miniatura di una diapositiva usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento a una scala definita.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

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

## **Creare una miniatura di diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura di una diapositiva con dimensioni definite dall'utente, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le dimensioni definite.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Creare una miniatura di diapositiva con note del relatore**

Per generare la miniatura di una diapositiva con le note del relatore usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/renderingoptions/).
1. Usa il metodo `RenderingOptions.setSlidesLayoutOptions` per impostare la posizione delle note del relatore.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le opzioni di rendering.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

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

![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web?**

Sì. È possibile utilizzare Aspose.Slides sul lato server per renderizzare le diapositive come immagini o HTML e visualizzarle nel browser. Le funzioni di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore personalizzato?**

L'approccio consigliato è renderizzare ogni diapositiva come immagine (ad esempio PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare il risultato all'interno di un picture box (per desktop) o di un contenitore HTML (per il web).

**Come gestire presentazioni di grandi dimensioni con molte diapositive?**

Per presentazioni di grandi dimensioni, considera il caricamento lazy o il rendering su richiesta delle diapositive. Ciò significa generare il contenuto di una diapositiva solo quando l'utente vi naviga, riducendo memoria e tempi di caricamento.