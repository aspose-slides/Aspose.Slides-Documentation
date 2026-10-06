---
title: Gestire SmartArt nelle presentazioni PowerPoint usando JavaScript
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo layout
- Proprietà nascosta
- Organigramma
- Organigramma con immagine
- PowerPoint
- Presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per Node.js usando esempi di codice JavaScript chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma di PowerPoint costituito da nodi, forme dei nodi e un layout. Con Aspose.Slides per Node.js tramite Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organizzativi e creare diagrammi organizzativi con immagini.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo dalle forme del nodo, iterare tramite [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), quindi leggere il [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) restituito da [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

L'esempio richiede una presentazione con almeno una diapositiva e un oggetto SmartArt come prima forma su tale diapositiva. Stampa ogni frame di testo disponibile sulla console.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout di SmartArt controlla come i nodi sono disposti e collegati. Il seguente esempio crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/), lo cambia al valore `BasicProcess` e salva la presentazione. La posizione e le dimensioni passate a [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) sono misurate in punti. Usa [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) per modificare il layout.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi diagramma visibili.

Il seguente esempio aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/), e verifica lo stato di visibilità del nodo aggiunto. Stampa un messaggio se il nodo è nascosto e salva il diagramma.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottenere o impostare il layout del diagramma organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di organigramma, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) e [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) definiscono come i nodi figli sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figli affinché pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) selezionato.

Il seguente esempio crea un organigramma e imposta il layout per il primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/). L'indice base zero `0` seleziona il primo nodo di livello superiore; i suoi nodi figli utilizzano la disposizione selezionata. La presentazione modificata viene quindi salvata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Creare un organigramma con immagine**

Un organigramma con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti immagine. Usa il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) quando aggiungi l'oggetto SmartArt a una diapositiva. Questo esempio salva un diagramma con segnaposti immagine; non popola i segnaposti con immagini.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convertire diagrammi legacy in gruppi di forme**

Durante la modernizzazione di una presentazione esistente, potrebbe essere necessario aggiornare un organigramma creato originariamente in PowerPoint 97–2003. Aspose.Slides rappresenta questi diagrammi legacy come oggetti [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Usa [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) per convertire un diagramma in un gruppo di forme così da poter modificare gli elementi visivi individuali. Consulta il [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) per i dettagli.

La conversione aggiunge un nuovo gruppo alla collezione di forme senza rimuovere il diagramma originale. Dopo una conversione riuscita, rimuovi l'originale con [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) per evitare contenuti duplicati. Raccogli i diagrammi legacy in un elenco prima di convertirli in modo che l'aggiunta e la rimozione di forme non interrompa l'iterazione.

Il seguente esempio apre una presentazione, ricerca ogni diapositiva, converte i diagrammi in gruppi di forme e salva la presentazione aggiornata come PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La presentazione salvata contiene gruppi di forme modificabili al posto dei diagrammi legacy convertiti, senza diagrammi originali rimasti accanto. Apri il PPTX in PowerPoint per modificare gli elementi individuali all'interno di ciascun gruppo, come il testo, il riempimento o la posizione.

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. Il metodo [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

Puoi [clonare la forma SmartArt](/slides/it/nodejs-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) o [clonare l'intera diapositiva](/slides/it/nodejs-java/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensione, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Renderizzare la diapositiva](/slides/it/nodejs-java/convert-powerpoint-to-png/) oppure l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Usa [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) o [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) per assegnare un testo alternativo o un nome distintivo alla forma SmartArt, ricerca quel valore in [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), e quindi verifica che la forma corrispondente sia una [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).