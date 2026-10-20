---
title: Ridimensiona forme sulle diapositive di presentazione in .NET
type: docs
weight: 130
url: /it/net/resizing-shapes-on-slide/
aliases:
  - /it/net/re-sizing-shapes-on-slide/
keywords:
- ridimensiona forma
- cambia dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per .NET — automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando modifichi le dimensioni della diapositiva di una presentazione, potresti dover anche ridimensionare e riposizionare le forme per adattarle alle nuove dimensioni. Questo articolo mostra come scalare le forme manualmente e come gestire le tabelle su diapositive, master e layout.

## **Ridimensiona forme**

Per preservare la posizione e le dimensioni relative di ciascuna forma, moltiplica le sue coordinate orizzontali e la larghezza per il rapporto tra la nuova larghezza della diapositiva e quella originale. Applica il corrispondente rapporto di altezza alle sue coordinate verticali e all’altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, cambia le dimensioni della diapositiva in A4 e salva il risultato. Utilizza [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) in modo che il ciclo successivo controlli la scalatura. I rapporti sono privi di unità; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti diversi per larghezza e altezza possono distorcere le forme e modificare le dimensioni di una forma non scala le dimensioni del carattere.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calcola fattori di scala orizzontali e verticali indipendenti.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Le tabelle richiedono una gestione separata: scala la larghezza delle colonne e l’altezza delle righe invece di assegnare la larghezza e l’altezza complessive della tabella. Le altezze delle righe possono rimanere più grandi rispetto a quanto richiesto se il contenuto delle celle richiede più spazio.
{{% /alert %}}

Il secondo esempio supporta le tabelle ed elabora le forme su master e layout così come sulle singole diapositive prima di salvare la presentazione ridimensionata. Il suo helper gestisce ogni [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) scalando [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) e [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Quindi scala la posizione della tabella senza scalare separatamente le sue dimensioni complessive.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calcola fattori di scala orizzontali e verticali indipendenti.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Ridimensiona le forme definite su master e layout così come su diapositive individuali.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Le dimensioni della tabella sono controllate dalla larghezza delle colonne e dall'altezza delle righe.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Perché le forme risultano distorte o tagliate dopo aver ridimensionato una diapositiva?**

Se cambi le dimensioni della diapositiva senza scalare le forme, queste mantengono le loro posizioni e dimensioni originali e possono estendersi oltre i bordi della diapositiva. Scalare larghezza e altezza con rapporti diversi può anche distorcere le forme.

**Il codice fornito funziona per tutti i tipi di forma?**

Il primo esempio modifica direttamente i limiti delle forme ed è destinato alle diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Controlla il layout risultante, in particolare il testo e le tabelle, poiché questi esempi non scalano le dimensioni dei caratteri e il contenuto delle tabelle può limitare le altezze delle righe.

**Come ridimensionare le tabelle durante il ridimensionamento di una diapositiva?**

Scala le larghezze delle colonne secondo il rapporto di larghezza e le altezze minime delle righe secondo il rapporto di altezza, quindi scala la posizione della tabella, come mostrato nel secondo esempio.

**Questo ridimensionamento funziona per le diapositive master e per le diapositive layout?**

Sì. Il secondo esempio itera attraverso [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) e le [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) di ciascun master e applica la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Imposta [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) dopo aver cambiato le dimensioni della diapositiva e prima di leggere le dimensioni target, in modo che i fattori di scala riflettano l'orientamento finale.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Puoi specificare dimensioni personalizzate della diapositiva con [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Le dimensioni supportate dipendono anche dal formato della presentazione e dall'applicazione usata per aprire il file.

**Come posso impedire che le forme con un rapporto d'aspetto fisso si distorcano?**

Usa lo stesso fattore di scala per larghezza e altezza. Per adattare il layout originale alle nuove dimensioni della diapositiva, utilizza il più piccolo dei rapporti di larghezza e altezza per entrambe le dimensioni e posizioni. Questo preserva le proporzioni ma può lasciare spazio inutilizzato lungo un bordo.