---
title: Gestire i segnaposti della presentazione in .NET
linktitle: Gestisci i segnaposti
type: docs
weight: 10
url: /it/net/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto di contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposto di testo, immagine, grafico e contenuto e comprendere l'ereditarietà dei segnaposto con Aspose.Slides per .NET."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposto per titolo, corpo, immagine, grafico e segnaposto di contenuto di uso generale. Diversamente da una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposto tramite la proprietà [IShape.Placeholder](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/placeholder/). La proprietà restituisce un oggetto [IPlaceholder](https://reference.aspose.com/slides/it/net/aspose.slides/iplaceholder/) o `null` per una forma normale. Usa [IPlaceholder.Type](https://reference.aspose.com/slides/it/net/aspose.slides/iplaceholder/type/) per determinare cosa dovrebbe contenere il segnaposto.

L'interfaccia della forma è ancora importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [IPlaceholder.Type](https://reference.aspose.com/slides/it/net/aspose.slides/iplaceholder/type/) sia l'interfaccia della forma a runtime invece di presumere che ogni segnaposto sia un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Attenzione" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/it/net/aspose.slides/iplaceholder/type/) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'ereditarietà dei segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione utilizzata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getbaseplaceholder/) per spostarti di un livello verso l'alto nella gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto di base.

Il seguente esempio elenca i segnaposti nella prima diapositiva e riporta i loro segnaposti di base:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che ereditano ancora quella impostazione. Una forma locale ordinaria non ha un segnaposto di base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il testo in un segnaposto**

I segnaposti di titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Controlla la presenza di un [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) prima di usare la sua proprietà [TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/textframe/).

Questo esempio aggiorna il primo segnaposto titolo nella prima diapositiva e salva il risultato:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Questo schema evita il casting di segnaposto immagine, grafico, tabella o media a [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/). Identifica inoltre il segnaposto per scopo invece di fare affidamento su un indice di forma fragile.

## **Impostare il testo di suggerimento su un layout**

Il testo di suggerimento è l'istruzione a tempo di progettazione visualizzata in un segnaposto vuoto, ad esempio *Fare clic per aggiungere il titolo*. Imposta un testo di suggerimento personalizzato sul segnaposto del layout invece di provare a raggiungerlo attraverso la raccolta di forme di una diapositiva normale. Accedi al layout tramite [ISlide.LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/layoutslide/) e itera su [ILayoutSlide.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/shapes/).

Il seguente esempio cambia i suggerimenti di titolo e sottotitolo nel layout utilizzato dalla prima diapositiva:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Il testo di suggerimento non è contenuto normale della diapositiva. È destinato ai segnaposto vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il suggerimento non è più visualizzato. Modificare un suggerimento inoltre non sostituisce il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/), sostituisci l'immagine tramite [IPictureFillFormat.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/ipicturefillformat/picture/) e [ISlidesPicture.Image](https://reference.aspose.com/slides/it/net/aspose.slides/islidespicture/image/).
- Se è ancora un segnaposto vuoto, aggiungi un picture frame alle coordinate del segnaposto con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addpictureframe/) e rimuovi il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

La sostituzione creata per un segnaposto vuoto è un picture frame locale, non un nuovo segnaposto, perché [IShape.Placeholder](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/placeholder/) è di sola lettura. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se è essenziale conservare la relazione del segnaposto, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) risultante con Aspose.Slides.

Per trasparenza dell'immagine, ritaglio e altri effetti specifici dell'immagine, vedi [Manage Picture Frames](/slides/it/net/picture-frame/). Quelle operazioni appartengono al picture frame o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con segnaposti grafico e contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per interfaccia a runtime, ne cambia il titolo e salva il file:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Un segnaposto di contenuto generale di solito ha [PlaceholderType.Object](https://reference.aspose.com/slides/it/net/aspose.slides/placeholdertype/). In PowerPoint agisce come avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona l'interfaccia della forma reale per capire cosa contiene. Layout specializzati possono inoltre esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/it/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/it/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/it/net/aspose.slides/placeholdertype/) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/it/net/aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) vuoto in un [IChart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/) semplicemente cambiando [IPlaceholder.Type](https://reference.aspose.com/slides/it/net/aspose.slides/iplaceholder/type/); il tipo è di sola lettura. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungi l'oggetto necessario alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. Il seguente esempio lo fa per un grafico:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto del layout. Usa gli articoli dedicati alla gestione dei grafici [chart management articles](/slides/it/net/powerpoint-charts/) quando devi sostituire categorie, serie o dati della cartella di lavoro.

## **Esempio completo: aggiornare testo o contenuto immagine**

Il seguente esempio end‑to‑end apre un modello, cerca nella prima diapositiva un segnaposto titolo o immagine, controlla i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva il risultato. L'esempio evita deliberatamente di presumere un indice di forma o di castare ogni segnaposto alla stessa interfaccia.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Che cos'è un segnaposto di base?**

Un segnaposto di base è la forma corrispondente sul layout o sul master da cui un altro segnaposto eredita. Usa [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/getbaseplaceholder/) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposto.

**Posso modificare tutti i titoli delle diapositive modificando un segnaposto del layout?**

Puoi modificare la formattazione ereditata o il testo di suggerimento tramite un layout, ma il contenuto effettivo dei titoli è memorizzato sulle diapositive normali. Per sostituire il testo dei titoli in tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto titolo.

**Come gestire i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nell'ambito della diapositiva, del layout, del master, delle note o del handout appropriato. Vedi [Manage Presentation Header and Footer](/slides/it/net/presentation-header-and-footer/) per esempi completi.