---
title: Crea un visualizzatore di presentazioni in PHP
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/php-java/presentation-viewer/
keywords:
- visualizza presentazione
- visualizzatore di presentazioni
- crea visualizzatore di presentazioni
- visualizza PPT
- visualizza PPTX
- visualizza ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea un visualizzatore di presentazioni personalizzato utilizzando Aspose.Slides per PHP via Java. Visualizza facilmente file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides per PHP via Java viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le diapositive come immagini nel loro visualizzatore di immagini preferito o di creare il proprio visualizzatore di presentazioni. In tali casi, Aspose.Slides consente di esportare una diapositiva singola come immagine. Questo articolo descrive come farlo.

## **Generare un'immagine SVG da una diapositiva**

Per generare un'immagine SVG da una diapositiva di presentazione con Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Apri un flusso di file.
1. Salva la diapositiva come immagine SVG sul flusso di file.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Generare un SVG con un ID forma personalizzato**

Aspose.Slides può essere usato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una diapositiva con un ID forma personalizzato. Per fare ciò, utilizza il metodo `setId` di [SvgShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` può essere usato per impostare l'ID della forma.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Creare un'immagine miniatura di una diapositiva**

Aspose.Slides ti aiuta a generare immagini miniature delle diapositive. Per generare una miniatura di una diapositiva usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento a una scala definita.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Creare una miniatura di diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura di diapositiva con dimensioni definite dall'utente, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le dimensioni definite.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Creare una miniatura di diapositiva con note del relatore**

Per generare la miniatura di una diapositiva con le note del relatore usando Aspose.Slides, segui i passaggi seguenti:

1. Crea un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/renderingoptions/).
1. Usa il metodo `RenderingOptions.setSlidesLayoutOptions` per impostare la posizione delle note del relatore.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le opzioni di rendering.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Esempio live**

Puoi provare l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa puoi implementare con l'API di Aspose.Slides:

![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web?**

Sì. Puoi utilizzare Aspose.Slides sul lato server per renderizzare le diapositive come immagini o HTML e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore personalizzato?**

L'approccio consigliato è renderizzare ogni diapositiva come immagine (ad es., PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare il risultato all'interno di una picture box (per desktop) o di un contenitore HTML (per il web).

**Come gestire presentazioni di grandi dimensioni con molte diapositive?**

Per deck di grandi dimensioni, considera il caricamento lazy (lazy-loading) o il rendering on-demand delle diapositive. Ciò significa generare il contenuto di una diapositiva solo quando l'utente vi naviga, riducendo l'uso di memoria e i tempi di caricamento.