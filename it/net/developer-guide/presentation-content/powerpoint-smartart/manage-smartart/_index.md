---
title: Gestire SmartArt nelle presentazioni PowerPoint in .NET
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/net/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo di layout
- Proprietà nascosta
- Organigramma
- Organigramma con immagine
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per .NET usando chiari esempi di codice C# che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per .NET, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dell'organigramma e creare organigrammi con immagini.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, iterare attraverso [ISmartArt.AllNodes](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartart/allnodes/), quindi leggere il [ITextFrame](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/) restituito da [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout SmartArt controlla come i nodi vengono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartartlayouttype/), lo cambia al valore `BasicProcess` e salva la presentazione.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Verificare se un nodo SmartArt è nascosto**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartartnode/ishidden/) indica se il nodo è nascosto nel modello di dati SmartArt. I nodi nascosti possono essere presenti nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartartlayouttype/) e verifica lo stato nascosto del nodo.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Ottenere o impostare il layout dell'organigramma**

Per i diagrammi SmartArt che utilizzano un layout di organigramma, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) definisce come i nodi figlio sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figlio affinché pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un organigramma e imposta il layout del primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/organizationchartlayouttype/).

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Creare un organigramma con immagine**

Un organigramma con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposto per immagini. Utilizzare il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartartlayouttype/) quando si aggiunge l'oggetto SmartArt a una diapositiva.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. La proprietà [IsReversed](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/smartart/isreversed/) cambia la direzione del diagramma da sinistra-destra a destra-sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/net/shape-manipulations/) con [ShapeCollection.AddClone](https://reference.aspose.com/slides/it/net/aspose.slides/shapecollection/addclone/) o [clonare l'intera diapositiva](/slides/it/net/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensioni, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Renderizza la diapositiva](/slides/it/net/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo di [AlternativeText](https://reference.aspose.com/slides/it/net/aspose.slides/shape/alternativetext/) o [Name](https://reference.aspose.com/slides/it/net/aspose.slides/shape/name/) sulla forma SmartArt, cerca quel valore in [Slide.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides/baseslide/shapes/), quindi verifica che la forma corrispondente sia un [ISmartArt](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartart/).