---
title: Gestire SmartArt nelle presentazioni PowerPoint usando JavaScript
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo di layout
- Proprietà nascosta
- Organigramma
- Organigramma con immagine
- PowerPoint
- Presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per Node.js utilizzando chiari esempi di codice JavaScript che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma di PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per Node.js via Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei grafici organizzativi e creare grafici organizzativi con immagini.

## **Recuperare il Testo da un Oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, scorrere [SmartArt.getAllNodes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/#getAllNodes--), quindi leggere il [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) restituito da [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Modificare il Tipo di Layout di un Oggetto SmartArt**

Il layout di SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartlayouttype/), lo cambia al valore `BasicProcess` e salva la presentazione.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificare se un Nodo SmartArt è Nascosto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartnode/ishidden/) indica se il nodo è nascosto nel modello di dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi diagramma visibili.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartlayouttype/) e verifica lo stato nascosto del nodo.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottenere o Impostare il Layout del Grafico Organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di grafico organizzativo, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) definiscono come i nodi figlio sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figlio in modo che pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un grafico organizzativo e imposta il layout per il primo nodo sul valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/organizationchartlayouttype/).

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Creare un Grafico Organizzativo con Immagine**

Un grafico organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposto immagine. Utilizzare il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartlayouttype/) quando si aggiunge l'oggetto SmartArt a una diapositiva.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per lingue RTL?**

Sì. Il metodo [SmartArt.setReversed](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/setreversed/) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/nodejs-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/addclone/) o [clonare l'intera diapositiva](/slides/it/nodejs-java/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensione, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Render la diapositiva](/slides/it/nodejs-java/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo per [Shape.setAlternativeText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/setalternativetext/) o [Shape.setName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/setname/) sulla forma SmartArt, cerca quel valore in [BaseSlide.getShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getShapes) e verifica che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/).