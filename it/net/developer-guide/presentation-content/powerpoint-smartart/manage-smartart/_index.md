---
title: Gestire SmartArt in presentazioni PowerPoint in .NET
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/net/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo di layout
- Proprietà nascosta
- Diagramma organizzativo
- Diagramma organizzativo con immagini
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per .NET usando chiari esempi di codice C# che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma di PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per .NET, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organizzativi e creare diagrammi organizzativi con immagini.

## **Ottieni testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo dalle forme del nodo, iterare attraverso [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), quindi leggere il [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) restituito da [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

L'esempio richiede una presentazione con almeno una diapositiva e un oggetto SmartArt come prima forma su quella diapositiva. Stampa ogni frame di testo disponibile sulla console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Modifica il tipo di layout di un oggetto SmartArt**

Il layout di SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) , lo cambia al valore `BasicProcess` e salva la presentazione. La posizione e le dimensioni passate a [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) sono misurate in punti. Impostare [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) per modificare il layout.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Verifica se un nodo SmartArt è nascosto**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) , e verifica lo stato nascosto del nodo aggiunto. Stampa un messaggio se il nodo è nascosto e salva il diagramma.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Ottieni o imposta il layout del diagramma organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di diagramma organizzativo, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) definisce come i nodi figli sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figli per pendere a sinistra, destra o entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un diagramma organizzativo e imposta il layout per il primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/). L'indice basato su zero `0` seleziona il primo nodo di livello superiore; i suoi nodi figli utilizzano la disposizione selezionata. La presentazione modificata viene quindi salvata.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Crea un diagramma organizzativo con immagine**

Un diagramma organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposto di immagine. Utilizzare il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) quando si aggiunge l'oggetto SmartArt a una diapositiva. Questo esempio salva un diagramma con segnaposto di immagine; non popola i segnaposto con immagini.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Converti diagrammi legacy in gruppi di forme**

Durante la modernizzazione di una presentazione esistente, potrebbe essere necessario aggiornare un diagramma organizzativo originariamente creato in PowerPoint 97–2003. Aspose.Slides rappresenta questi diagrammi legacy come oggetti [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Utilizzare [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) per convertire un diagramma in un gruppo di forme così da poter modificare elementi visivi individuali. Consultare il [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) per i dettagli.

La conversione aggiunge un nuovo gruppo alla collezione di forme senza rimuovere il diagramma originale. Dopo una conversione riuscita, rimuovere l'originale con [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) per evitare contenuti duplicati. Raccogliere i diagrammi legacy in un array prima di convertirli in modo che l'aggiunta e la rimozione di forme non interrompano l'iterazione.

L'esempio seguente apre una presentazione, ricerca ogni diapositiva, converte i diagrammi in gruppi di forme e salva la presentazione aggiornata come PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

La presentazione salvata contiene gruppi di forme modificabili al posto dei diagrammi legacy convertiti, senza diagrammi originali accanto. Aprire il PPTX in PowerPoint per modificare elementi individuali all'interno di ciascun gruppo, come testo, riempimento o posizione.

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. La proprietà [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/net/shape-manipulations/) con [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) oppure [clonare l'intera diapositiva](/slides/it/net/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci preservano dimensioni, posizione e formattazione.

**Come posso renderizzare SmartArt come immagine raster per l'anteprima o l'esportazione web?**

[Renderizza la diapositiva](/slides/it/net/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare uno specifico oggetto SmartArt su una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo di [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) o [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) sulla forma SmartArt, cerca quel valore in [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), e poi verifica che la forma corrispondente sia un [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).