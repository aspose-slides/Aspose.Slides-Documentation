---
title: Applica o Modifica Layout di Diapositive in .NET
linktitle: Layout Diapositiva
type: docs
weight: 60
url: /it/net/slide-layout/
keywords:
- layout diapositiva
- layout contenuto
- segnaposto
- design della presentazione
- design diapositiva
- layout non utilizzato
- visibilità piè di pagina
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
description: "Applica, crea e modifica i layout delle diapositive in Aspose.Slides per .NET, aggiungi segnaposti, rimuovi layout non utilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout diapositive definisce le posizioni e la formattazione dei segnaposti come titoli, testo, immagini, grafici e tabelle. L'applicazione di un layout conferisce alle diapositive una struttura coerente consentendo a ciascuna diapositiva di contenere il proprio contenuto.

- **Diapositiva Titolo**: Contiene segnaposti per il titolo e il sottotitolo.
- **Titolo e Contenuto**: Contiene un segnaposto titolo e un segnaposto contenuto generico.
- **Vuota**: Non contiene segnaposti di contenuto ed è utile quando ogni forma verrà posizionata manualmente.

## **Comprendere l'ereditarietà del layout**

Una presentazione ha tre livelli correlati:

1. Una [diapositiva master](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
1. Una [diapositiva layout](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/) appartiene a un master e definisce una particolare disposizione di segnaposti.
1. Una [diapositiva normale](https://reference.aspose.com/slides/it/net/aspose.slides/islide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una diapositiva normale eredita tema e formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una diapositiva normale sovrascrive il valore ereditato a quel livello. Quando viene creata una diapositiva normale, le forme dei segnaposti vengono generate dal layout selezionato, mentre il contenuto inserito in tali segnaposti appartiene alla diapositiva normale.

Aggiungere i segnaposti richiesti a un layout prima di creare diapositive da esso. Aggiungere in seguito un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle diapositive normali esistenti.

Questa relazione ha due conseguenze importanti:

- Modificare la formattazione ereditata o la geometria dei segnaposti esistenti su un layout può aggiornare ogni diapositiva che dipende da esso. Prima di modificare un layout già in uso, esamina le diapositive dipendenti e rivedi la presentazione risultante.
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le diapositive dipendenti a un altro layout, oppure rimuovi solo i layout non utilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, vedi [Master della diapositiva](/slides/it/net/slide-master/).

## **Selezionare e Applicare un Layout Diapositiva**

Usa un tipo di layout quando la presentazione segue le definizioni di layout standard di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello di origine.

L'esempio seguente cerca **Titolo e Contenuto** nel primo master. Se quel layout non è disponibile, ricade deliberatamente su **Vuota**. Il secondo controllo di null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima diapositiva normale tramite la proprietà [ISlide.LayoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide/layoutslide/).

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

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposti, la formattazione ereditata e la corrispondenza tra i segnaposti esistenti e il nuovo layout possono cambiare, quindi controlla l'output quando passi da un layout sostanzialmente diverso a un altro.

## **Aggiungere una Diapositiva Layout**

Selezione e creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/it/net/aspose.slides/masterlayoutslidecollection/add/) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Titolo e Contenuto** denominato `Report Title and Content`, quindi aggiunge una diapositiva normale basata su di esso. I nomi dei layout devono essere unici all'interno della collezione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Aggiungi un layout solo quando il modello necessita realmente di un'altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere Segnaposti a una Diapositiva Layout**

La proprietà [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/placeholdermanager/) fornisce un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint               | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

L'esempio seguente verifica che il layout **Vuota** esista, aggiunge quattro segnaposti ad esso e poi crea una diapositiva normale che utilizza il layout modificato. L'ordine è intenzionale: i segnaposti vengono aggiunti prima della creazione della diapositiva normale, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella diapositiva.

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
Modificare la formattazione ereditata o la geometria dei segnaposti di layout esistenti può influenzare le diapositive dipendenti. Un segnaposto di layout aggiunto di recente non viene retroattivamente inserito nelle diapositive normali esistenti. Testa le modifiche al layout su una copia della presentazione e controlla ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere Diapositive Layout Non Utilizzate**

Usa il metodo [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere i layout a cui non fa riferimento alcuna diapositiva normale. Il metodo mantiene intatti i layout ancora in uso.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Per rimuovere un layout specifico, usa innanzitutto la sua proprietà [HasDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/hasdependingslides/) o il metodo [GetDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/getdependingslides/). Riassegna le diapositive dipendenti prima di chiamare [ILayoutSlide.Remove](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/remove/). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Footer su una Diapositiva Layout**

Un layout ha i propri segnaposti per footer, numero diapositiva e data/ora. Usa la proprietà [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/headerfootermanager/) per controllare quei segnaposti su un singolo layout. È utile, ad esempio, quando i layout di contenuto devono mostrare i footer ma i layout di titolo no.

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

## **Controllare la Visibilità del Footer su un Master e sui suoi Layout Figlio**

Per applicare impostazioni di footer coerenti su tutta la gerarchia di un master, usa la proprietà [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/headerfootermanager/). I metodi di propagazione di [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslideheaderfootermanager/) operano sul master e sui suoi layout e diapositive normali dipendenti; non colpiscono una sola diapositiva normale.

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

**Qual è la differenza tra una diapositiva master e una diapositiva layout?**

Una diapositiva master definisce il tema della presentazione e la formattazione condivisa. Una diapositiva layout appartiene a un master e definisce una disposizione riutilizzabile di segnaposti. Le diapositive normali usano questi layout e memorizzano il contenuto specifico della diapositiva.

**Posso copiare una diapositiva layout da una presentazione all'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/globallayoutslidecollection/addclone/). Quando copi tra presentazioni, verifica anche i caratteri, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede se modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout, a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposti e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [GetDependingSlides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/getdependingslides/) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides lancia una [PptxEditException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure usa [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/it/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) per rimuovere solo i layout non referenziati.