---
title: Applica o Modifica Layout di Diapositive in .NET
linktitle: Layout di Diapositiva
type: docs
weight: 60
url: /it/net/slide-layout/
keywords:
- layout di diapositiva
- layout di contenuto
- segnaposto
- design della presentazione
- design della diapositiva
- layout inutilizzato
- visibilità del piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione sezione
- due contenuti
- confronto
- solo titolo
- layout vuoto
- contenuto con didascalia
- immagine con didascalia
- titolo e testo verticale
- titolo verticale e testo
- PowerPoint
- OpenDocument
- presentazione
- C#
- .NET
- Aspose.Slides
description: "Applica, crea e modifica i layout di diapositive in Aspose.Slides per .NET, aggiungi segnaposti, rimuovi i layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout diapositive definisce le posizioni e la formattazione dei segnaposti come titoli, testo, immagini, grafici e tabelle. Applicare un layout conferisce alle diapositive una struttura coerente consentendo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Diapositiva Titolo**: Contiene segnaposti per titolo e sottotitolo.
- **Titolo e Contenuto**: Contiene un segnaposto per il titolo e un segnaposto di contenuto generico.
- **Vuota**: Non contiene segnaposti di contenuto ed è utile quando ogni forma sarà posizionata manualmente.

## **Comprendere l'ereditarietà dei layout**

Una presentazione ha tre livelli correlati:

1. Una [master slide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
2. Una [layout slide](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/) appartiene a una master e definisce una disposizione particolare di segnaposti.
3. Una [normal slide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una normal slide eredita tema e formattazione dal suo layout, e il layout eredita dalla sua master. Un valore impostato direttamente su una normal slide sovrascrive il valore ereditato a quel livello. Quando una normal slide viene creata, le sue forme segnaposto sono generate dal layout selezionato, mentre il contenuto inserito in tali segnaposti appartiene alla normal slide.

Aggiungi i segnaposti richiesti a un layout prima di creare diapositive da esso. Aggiungere successivamente un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle diapositive normal esistenti.

Questa relazione ha due importanti conseguenze:

- Modificare la formattazione ereditata o la geometria dei segnaposti esistenti su un layout può aggiornare ogni diapositiva che dipende da esso. Prima di modificare un layout già in uso, ispeziona le diapositive dipendenti e rivedi la presentazione risultante.
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le sue diapositive dipendenti a un altro layout, o rimuovi solo i layout inutilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, vedere [Slide Master](/slides/it/net/slide-master/).

Per nascondere loghi ereditati o forme decorative della master su una diapositiva o tramite un layout condiviso, vedere [Control the Visibility of Master Graphics](/slides/it/net/slide-master/). L'esempio confronta due diapositive che usano la stessa master.

## **Selezionare e Applicare un Layout Diapositiva**

Usa un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che tu non controlli il modello sorgente.

L'esempio seguente cerca **Titolo e Contenuto** nella prima master. Se quel layout non è disponibile, ricade deliberatamente su **Vuota**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima diapositiva normal tramite la proprietà [ISlide.LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposti, la formattazione ereditata e la corrispondenza tra i segnaposti esistenti e il nuovo layout possono cambiare, quindi ispeziona l'output quando passi da layout sostanzialmente diversi.

## **Aggiungere una Diapositiva Layout**

Selezione e creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/it/net/aspose.slides/masterlayoutslidecollection/add/) sulla collezione di layout della master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Titolo e Contenuto** denominato `Report Title and Content`, quindi aggiunge una diapositiva normal basata su di esso. I nomi dei layout devono essere unici all'interno della collezione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Aggiungi un layout solo quando il modello necessita davvero di un'altra struttura riusabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere Segnaposti a una Diapositiva Layout**

La proprietà [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/placeholdermanager/) fornisce un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint              | Metodo `ILayoutPlaceholderManager` |
| ----------------------------------- | ---------------------------------- |
| ![Contenuto](content.png)          | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenuto (Verticale)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Testo](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Testo (Verticale)](textV.png)    | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Immagine](picture.png)           | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Grafico](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabella](table.png)              | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)          | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Immagine Online](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

L'esempio seguente verifica che il layout **Vuota** esista, aggiunge quattro segnaposti ad esso, quindi crea una diapositiva normal che utilizza il layout modificato. L'ordine è intenzionale: i segnaposti vengono aggiunti prima che la diapositiva normal sia creata, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella diapositiva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Il risultato:

![I segnaposti sulla diapositiva layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposti esistenti del layout può influire sulle diapositive dipendenti. Un segnaposto appena aggiunto al layout non viene retroattivamente inserito nelle diapositive normal esistenti. Prova le modifiche al layout su una copia della presentazione e ispeziona ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere Diapositive Layout Inutilizzate**

Usa il metodo [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere i layout a cui nessuna diapositiva normal fa riferimento. Il metodo lascia intatti i layout ancora in uso.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Per rimuovere un layout specifico, usa prima la sua proprietà [HasDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/hasdependingslides/) o il metodo [GetDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/getdependingslides/). Riassegna eventuali diapositive dipendenti prima di chiamare [ILayoutSlide.Remove](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/remove/). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Piè di Pagina su una Diapositiva Layout**

Un layout ha i propri segnaposti per piè di pagina, numero diapositiva e data/ora. Usa la proprietà [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/headerfootermanager/) per controllare questi segnaposti per un singolo layout. È utile quando, ad esempio, i layout di contenuto devono mostrare il piè di pagina ma i layout di titolo no.

L'esempio seguente seleziona in modo sicuro un layout e rende visibili i suoi elementi di piè di pagina:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Controllare la Visibilità del Piè di Pagina su una Master e sui suoi Layout Figli**

Per applicare impostazioni di piè di pagina coerenti su tutta la gerarchia della master, usa la proprietà [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/headerfootermanager/). I metodi di propagazione di [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslideheaderfootermanager/) operano sulla master e sui suoi layout dipendenti e sulle diapositive normal; non mirano a una singola diapositiva normal.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qual è la differenza tra una Master Slide e una Layout Slide?**

Una master slide definisce il tema della presentazione e la formattazione condivisa. Una layout slide appartiene a una master e definisce una disposizione riusabile di segnaposti. Le diapositive normal utilizzano quei layout e memorizzano il contenuto specifico della diapositiva.

**Posso copiare una Layout Slide da una presentazione a un'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/globallayoutslidecollection/addclone/). Quando copi tra presentazioni, verifica anche font, temi, immagini e altre risorse utilizzate dal layout sorgente.

**Cosa succede quando modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposti e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [GetDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/getdependingslides/) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure usa [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere solo i layout non referenziati.