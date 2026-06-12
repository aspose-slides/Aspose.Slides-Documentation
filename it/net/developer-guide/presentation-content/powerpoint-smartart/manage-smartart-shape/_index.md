---
title: Gestire la grafica SmartArt nelle presentazioni in .NET
linktitle: Grafica SmartArt
type: docs
weight: 20
url: /it/net/manage-smartart-shape/
keywords:
- Oggetto SmartArt
- Grafica SmartArt
- Stile SmartArt
- Colore SmartArt
- Creare SmartArt
- Aggiungere SmartArt
- Modificare SmartArt
- Cambiare SmartArt
- Accedere a SmartArt
- Tipo di layout SmartArt
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Automatizza la creazione, la modifica e lo styling di SmartArt in PowerPoint su .NET usando Aspose.Slides, con esempi di codice concisi e indicazioni focalizzate sulle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafica SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere alle forme SmartArt esistenti, trovare SmartArt per un tipo di layout specifico e aggiornare l’aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt attraverso la collezione di forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificarne o ispezionarne le proprietà.

## **Creare una forma SmartArt**
Aspose.Slides per .NET ora permette di aggiungere forme SmartArt personalizzate nelle diapositive da zero. Aspose.Slides per .NET fornisce l’API più semplice per creare forme SmartArt nel modo più agevole. Per creare una forma SmartArt in una diapositiva, seguire i passaggi seguenti:

- Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere una forma SmartArt impostando il suo LayoutType.
- Scrivere la presentazione modificata come file PPTX.

```c#
// Istanziare la presentazione
using (Presentation pres = new Presentation())
{

    // Accedere alla diapositiva della presentazione
    ISlide slide = pres.Slides[0];

    // Aggiungere una forma SmartArt
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Salvataggio della presentazione
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Accedere a una forma SmartArt su una diapositiva**
Il codice seguente sarà utilizzato per accedere alle forme SmartArt aggiunte nella diapositiva della presentazione. Nel codice di esempio attraverseremo ogni forma all’interno della diapositiva e verificheremo se è una forma SmartArt. Se la forma è di tipo SmartArt, la convertirà in un’istanza SmartArt.

```c#
// Caricare la presentazione desiderata
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Attraversare ogni forma nella prima diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verificare se la forma è di tipo SmartArt
        if (shape is ISmartArt)
        {
            // Eseguire il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```

## **Accedere a una forma SmartArt con un particolare tipo di layout**
Il codice di esempio seguente aiuterà ad accedere alla forma SmartArt con un LayoutType specifico. Si noti che non è possibile modificare il LayoutType di SmartArt poiché è di sola lettura e viene impostato solo quando la forma SmartArt viene aggiunta.

- Creare un’istanza della classe `Presentation` e caricare la presentazione contenente la forma SmartArt.
- Ottenere il riferimento della prima diapositiva usando il suo indice.
- Attraversare tutte le forme della prima diapositiva.
- Verificare se la forma è di tipo SmartArt e, se lo è, effettuare il cast della forma selezionata a SmartArt.
- Controllare la forma SmartArt con il LayoutType specifico ed eseguire le operazioni necessarie successivamente.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Attraversare ogni forma nella prima diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificare se la forma è di tipo SmartArt
        if (shape is ISmartArt)
        {
            // Eseguire il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Controllare il layout di SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```

## **Modificare lo stile di una forma SmartArt**
Il codice di esempio seguente aiuterà ad accedere alla forma SmartArt con un LayoutType specifico.

- Creare un’istanza della classe `Presentation` e caricare la presentazione contenente la forma SmartArt.
- Ottenere il riferimento della prima diapositiva usando il suo indice.
- Attraversare tutte le forme della prima diapositiva.
- Verificare se la forma è di tipo SmartArt e, se lo è, effettuare il cast della forma selezionata a SmartArt.
- Trovare la forma SmartArt con lo stile specifico.
- Impostare il nuovo stile per la forma SmartArt.
- Salvare la presentazione.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Attraversare ogni forma nella prima diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificare se la forma è di tipo SmartArt
        if (shape is ISmartArt)
        {
            // Eseguire il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Controllare lo stile di SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Cambiare lo stile di SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Salvataggio della presentazione
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```

## **Modificare lo stile colore di una forma SmartArt**
In questo esempio impareremo a cambiare lo stile colore di qualsiasi forma SmartArt. Nel codice di esempio verrà acceduta la forma SmartArt con uno stile colore specifico e ne verrà modificato lo stile.

- Creare un’istanza della classe `Presentation` e caricare la presentazione contenente la forma SmartArt.
- Ottenere il riferimento della prima diapositiva usando il suo indice.
- Attraversare tutte le forme della prima diapositiva.
- Verificare se la forma è di tipo SmartArt e, se lo è, effettuare il cast della forma selezionata a SmartArt.
- Trovare la forma SmartArt con lo stile colore specifico.
- Impostare il nuovo stile colore per la forma SmartArt.
- Salvare la presentazione.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Attraversare ogni forma nella prima diapositiva
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Verificare se la forma è di tipo SmartArt
        if (shape is ISmartArt)
        {
            // Eseguire il cast della forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Controllare il tipo di colore di SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Cambiare il tipo di colore di SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Salvataggio della presentazione
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso animare SmartArt come un singolo oggetto?**

Sì. SmartArt è una forma, quindi è possibile applicare [standard animations](/slides/it/net/powerpoint-animation/) tramite l’API delle animazioni (entrata, uscita, enfatizzazione, percorsi di movimento) proprio come per altre forme.

**Come posso trovare uno SmartArt specifico su una diapositiva se non ne conosco l’ID interno?**

Impostare e utilizzare il Testo Alternativo (AltText) e cercare la forma tramite quel valore: è il metodo consigliato per individuare la forma target.

**Posso raggruppare SmartArt con altre forme?**

Sì. È possibile raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e quindi [manipolare il gruppo](/slides/it/net/group/).

**Come ottengo un’immagine di uno SmartArt specifico (ad es. per un’anteprima o un report)?**

Esportare una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/net/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L’aspetto di SmartArt verrà preservato quando si converte l’intera presentazione in PDF?**

Sì. Il motore di rendering punta a un’elevata fedeltà per [PDF export](/slides/it/net/convert-powerpoint-to-pdf/), con una gamma di opzioni di qualità e compatibilità.