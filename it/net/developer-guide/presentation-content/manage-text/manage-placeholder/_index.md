---
title: Gestire i segnaposti di presentazione in .NET
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/net/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a ispezionare e modificare i segnaposti di testo, immagine, grafico e contenuto e a capire l'eredità dei segnaposti con Aspose.Slides per .NET."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono i segnaposti per titolo, corpo, immagine, grafico e contenuto generico. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva di layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposti tramite la proprietà [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). La proprietà restituisce un oggetto [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) o `null` per una forma normale. Usa [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) per determinare cosa il segnaposto dovrebbe contenere.

L'interfaccia della forma è ancora rilevante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) sia l'interfaccia di forma al runtime invece di assumere che ogni segnaposto sia un [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) descrive il ruolo di un segnaposto; non garantisce il tipo di forma al runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'eredità dei segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva di layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) per spostarti di un livello verso l'alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto di base.

Il seguente esempio elenca i segnaposti nella prima diapositiva e segnala i loro segnaposti di base:

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

Modificare un segnaposto su una diapositiva normale crea o modifica una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influire su tutte le diapositive che ancora ereditano quell'impostazione. Una forma locale ordinaria non ha un segnaposto di base e non inizia a ereditare semplicemente perché occupa le stesse coordinate.

## **Rimuovere lo stato di segnaposto**

Quando si adatta un modello, usa [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) per mantenere un oggetto esistente come forma ordinaria. La sua proprietà [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) diventa `null`, ma la forma rimane nella collezione della diapositiva. Al contrario, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) elimina la forma da quella collezione.

Il seguente esempio richiede `template.pptx` con almeno una diapositiva e un segnaposto di testo non vuoto nella prima diapositiva. Usa un segnaposto con formattazione ereditata dal suo layout o master per vedere l'effetto della rimozione di quella relazione. L'esempio verifica che la stessa forma rimanga, chiama nuovamente il metodo sulla forma ora ordinaria e salva il risultato.

{{% alert color="warning" title="Warning" %}}
Rimuovere lo stato di segnaposto non preserva automaticamente le impostazioni di aspetto ereditate. L'esempio sottostante lascia deliberatamente tali impostazioni invariate, quindi l'output potrebbe apparire diverso. Una forma la cui posizione e dimensione sono completamente ereditate può avere coordinate e dimensioni pari a zero dopo la chiamata e diventare invisibile anche se rimane nella collezione.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Chiamare il metodo su una forma ordinaria non ha alcun effetto.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Per un segnaposto corrispondente, tutti e tre i controlli stampano `True`. Il testo rimane, ma posizione, dimensione, rotazione, carattere, allineamento del paragrafo, margini del riquadro di testo, ancoraggio verticale, riempimento e impostazioni della linea ereditate possono cambiare quando la relazione del segnaposto viene rimossa. Ad esempio, la formattazione del titolo ereditata può tornare alla formattazione del testo ordinario. Vedi [Slide Layout](/slides/it/net/slide-layout/) per ulteriori informazioni sui layout.

Per preservare l'aspetto desiderato, acquisisci la posizione, dimensione e rotazione risolte prima della chiamata e copia i valori di formattazione effettiva richiesti in variabili separate. Recupera tali valori tramite [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), e [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Non fare affidamento solo sugli oggetti di formattazione efficace, poiché i loro valori di formattazione del testo possono cambiare dopo la rimozione della relazione. Applica esplicitamente i valori acquisiti alla forma ordinaria in seguito, includendo la famiglia di caratteri, dimensione, stile, colore, impostazioni del paragrafo, impostazioni del riquadro di testo, riempimento e linea utilizzati dal tuo modello.

Anche la geometria della forma ereditata potrebbe dover essere assegnata esplicitamente tramite [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Per un segnaposto di testo rettangolare, ciò significa assegnare [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); ripristinare solo il riempimento e la linea potrebbe non ripristinare il rettangolo visibile. I modelli con effetti aggiuntivi o formattazione più complessa richiedono che tali impostazioni vengano gestite anch'esse.

## **Modificare il testo in un segnaposto**

I segnaposti di titolo, titolo centrato, sottotitolo, corpo e testo supportano normalmente il testo. Verifica la presenza di [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) prima di utilizzare la sua proprietà [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

Questo esempio aggiorna il primo segnaposto di titolo nella prima diapositiva e salva il risultato:

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

Questo schema evita il casting di segnaposti di immagine, grafico, tabella o media a [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Identifica inoltre il segnaposto per scopo invece di fare affidamento su un indice di forma fragile.

## **Impostare il testo di suggerimento su un layout**

Il testo di suggerimento è l'istruzione di progettazione visualizzata in un segnaposto vuoto, ad esempio *Fare clic per aggiungere il titolo*. Imposta testo di suggerimento personalizzato sul segnaposto del layout invece di cercare di raggiungerlo tramite la collezione di forme di una diapositiva normale. Accedi al layout tramite [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) e iteri su [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Il seguente esempio modifica i suggerimenti di titolo e sottotitolo sul layout usato dalla prima diapositiva:

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

Il testo di suggerimento non è contenuto normale della diapositiva. È destinato ai segnaposti vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il suggerimento non viene più visualizzato. Modificare un suggerimento inoltre non sostituisce il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), sostituisci l'immagine tramite [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) e [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Se è ancora un segnaposto vuoto, aggiungi un riquadro immagine alle coordinate del segnaposto con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) e rimuovi il segnaposto vuoto.

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

La sostituzione creata per un segnaposto vuoto è un riquadro immagine locale, non un nuovo segnaposto, poiché [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) è di sola lettura. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione del segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) risultante con Aspose.Slides.

Per la trasparenza dell'immagine, il ritaglio e altri effetti specifici delle immagini, vedi [Manage Picture Frames](/slides/it/net/picture-frame/). tali operazioni appartengono al riquadro immagine o al riempimento dell'immagine, non ai metadati del segnaposto.

## **Lavorare con segnaposti grafico e contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Questo esempio trova tale grafico sia per tipo di segnaposto che per interfaccia runtime, modifica il suo titolo e salva il file:

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

Un segnaposto di contenuto generale solitamente ha [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona l'interfaccia della forma reale per capire cosa contiene. I layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), o [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vuoto in un [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) semplicemente cambiando [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); il tipo è di sola lettura. Per riempire programmaticamente un'area di grafico o contenuto vuota, aggiungi l'oggetto necessario alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. Il seguente esempio lo fa per un grafico:

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

Il grafico aggiunto è un grafico locale ordinario. Occupra l'area del segnaposto ma non eredita dal segnaposto del layout. Usa gli [articoli di gestione dei grafici](/slides/it/net/powerpoint-charts/) quando è necessario sostituire le sue categorie, serie o dati della cartella di lavoro.

## **Esempio completo: aggiornare testo o contenuto immagine**

Il seguente esempio end-to-end apre un modello, ricerca nella prima diapositiva un segnaposto di titolo o immagine, verifica i tipi di segnaposto e di forma, aggiorna il contenuto appropriato e salva il risultato. L'esempio evita deliberatamente di assumere un indice di forma o di castare ogni segnaposto alla stessa interfaccia.

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

**Cos'è un segnaposto di base?**

Un segnaposto di base è la forma corrispondente nel layout o nel master da cui un altro segnaposto eredita. Usa [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposti.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto di layout?**

È possibile modificare la formattazione ereditata o il testo di suggerimento tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo reale dei titoli in tutta la presentazione, itera sulle diapositive e aggiorna ogni segnaposto di titolo.

**Come gestisco i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nello scope appropriato (diapositiva, layout, master, note o opuscolo). Vedi [Gestire intestazione e piè di pagina della presentazione](/slides/it/net/presentation-header-and-footer/) per esempi completi.