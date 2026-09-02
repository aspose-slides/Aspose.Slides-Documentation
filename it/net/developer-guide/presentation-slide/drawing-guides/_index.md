---
title: Gestire le guide di disegno nelle presentazioni in .NET
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/net/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- visualizzazione diapositiva
- master diapositiva
- diapositiva layout
- master note
- master di distribuzione
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungere, accedere e rimuovere le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per .NET."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che verrà successivamente perfezionata manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori devono seguire quando aggiungono o spostano contenuti.

Le guide di disegno sono ausili per la modifica, non contenuti della diapositiva. Non compaiono in una presentazione o nell'output renderizzato. Aspose.Slides for .NET le espone tramite l'interfaccia [IDrawingGuidesCollection](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguidescollection/) . Una guida è rappresentata da [IDrawingGuide](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguide/) e possiede un'orientazione, una posizione e un colore.

La posizione è misurata in punti rispetto all'angolo superiore sinistro della diapositiva o del master rilevante. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungere guide alla visualizzazione diapositiva**

Utilizza [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/it/net/aspose.slides/icommonslideviewproperties/drawingguides/) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiama [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguidescollection/add/) con un valore [Orientation](https://reference.aspose.com/slides/it/net/aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale sotto di essa:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Accedere alle guide di disegno**

La proprietà [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguidescollection/count/) e l'indicizzatore forniscono l'accesso alle guide esistenti. Le proprietà [IDrawingGuide.Orientation](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguide/position/), e [IDrawingGuide.Color](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguide/color/) possono essere lette o modificate.

Il seguente esempio legge le guide della visualizzazione diapositiva dalla presentazione creata sopra:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Aggiungere guide a master e diapositive layout**

Un master diapositiva e ciascuna delle sue diapositive layout possono avere le proprie collezioni di guide di disegno. Usa [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/it/net/aspose.slides/imasterslide/drawingguides/) per una diapositiva master e [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/it/net/aspose.slides/ilayoutslide/drawingguides/) per una diapositiva layout.

Il seguente esempio aggiunge una guida verticale alla prima diapositiva master e una guida orizzontale alla prima diapositiva layout:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Aggiungere guide a master note e master handout**

I master note e i master handout supportano anche le guide di disegno. Usa [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslide/drawingguides/) e [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/it/net/aspose.slides/imasterhandoutslide/drawingguides/) per accedere alle loro collezioni. Se una presentazione non contiene uno di questi master, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) o [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/it/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) crea il master predefinito e lo restituisce.

Il seguente esempio aggiunge una guida orizzontale a un master note e una guida verticale a un master handout:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Rimuovere le guide di disegno**

Chiama [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/it/net/aspose.slides/idrawingguidescollection/clear/) per rimuovere tutte le guide da una determinata collezione. La cancellazione di una collezione non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio cancella le guide della visualizzazione diapositiva e tutte le guide sui master diapositive, diapositive layout, il master note e il master handout senza creare master mancanti:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Le guide di disegno compaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili per l'allineamento durante la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono memorizzate nelle proprietà della visualizzazione diapositiva della presentazione. Collezioni di guide separate sono disponibili per i master diapositive, le diapositive layout, i master note e i master handout.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali vengono misurate dal bordo sinistro, e le posizioni orizzontali dal bordo superiore.

**La cancellazione delle guide di disegno rimuove forme o modifica il contenuto della diapositiva?**

No. Il metodo `Clear` rimuove solo le guide nella collezione selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.