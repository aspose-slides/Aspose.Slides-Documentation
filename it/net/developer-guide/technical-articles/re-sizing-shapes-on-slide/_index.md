---
title: Ridimensiona le forme sulle diapositive di presentazione in .NET
type: docs
weight: 130
url: /it/net/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- modificare dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Ridimensiona facilmente forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per .NET—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più comuni dei clienti di Aspose.Slides per .NET è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano tagliati. Questo breve articolo tecnico mostra come farlo.

## **Ridimensiona forme**

Per evitare che le forme si disallineino quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ciascuna forma affinché si conformino al nuovo layout della diapositiva.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Carica il file di presentazione.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Ottieni le dimensioni originali della diapositiva.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Cambia le dimensioni della diapositiva senza ridimensionare le forme esistenti.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Ottieni le nuove dimensioni della diapositiva.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ridimensiona e riposiziona le forme su ogni diapositiva.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Scala le dimensioni della forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scala la posizione della forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Se una diapositiva contiene una tabella, il codice sopra non funzionerà correttamente. In tal caso, è necessario ridimensionare ciascuna cella della tabella.
{{% /alert %}}

Utilizza il seguente codice per ridimensionare le diapositive che contengono tabelle. Per le tabelle, scala le altezze delle righe e le larghezze delle colonne individuali invece della larghezza e altezza della forma—applicare entrambi ridimensionerebbe la tabella due volte e la sposterebbe fuori dalla diapositiva.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Ottieni le dimensioni originali della diapositiva.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Modifica le dimensioni della diapositiva senza scalare le forme esistenti.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Ottieni le nuove dimensioni della diapositiva.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Scala le dimensioni della forma.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scala la posizione della forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Scala le dimensioni della forma.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Scala la posizione della forma.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Scala le dimensioni della tabella attraverso le sue righe e colonne.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Scala le dimensioni della forma.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Scala la posizione della forma.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Perché le forme vengono distorte o tagliate dopo aver ridimensionato una diapositiva?

Quando si ridimensiona una diapositiva, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Questo può causare il ritaglio del contenuto o il disallineamento delle forme.

### Il codice fornito funziona per tutti i tipi di forma?

L'esempio di base funziona per la maggior parte dei tipi di forma (caselle di testo, immagini, grafici, ecc.). Tuttavia, per le tabelle è necessario gestire righe e colonne separatamente, poiché l'altezza e la larghezza di una tabella sono determinate dalle dimensioni delle singole celle.

### Come posso ridimensionare le tabelle quando ridimensiono una diapositiva?

È necessario scorrere tutte le righe e le colonne della tabella e ridimensionare la loro altezza e larghezza proporzionalmente, come mostrato nel secondo esempio di codice.

### Questo ridimensionamento funzionerà per le diapositive master e le diapositive layout?

Sì, ma dovresti anche scorrere [Masters](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/masters/) e [LayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/layoutslides/) e applicare la stessa logica di scala alle loro forme per garantire la coerenza nella presentazione.

### Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?

Sì. Puoi impostare [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/it/net/aspose.slides/islidesize/orientation/) per cambiare l'orientamento. Assicurati di impostare la logica di scala di conseguenza per preservare il layout.

### Esiste un limite alle dimensioni della diapositiva che posso impostare?

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

### Come posso impedire che le forme con rapporto d'aspetto fisso vengano distorte?

Puoi verificare la proprietà `AspectRatioLocked` della forma prima di effettuare lo scaling. Se è bloccata, regola la larghezza o l'altezza proporzionalmente invece di scalarle singolarmente.