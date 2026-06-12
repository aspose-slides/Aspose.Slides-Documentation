---
title: Gestire SmartArt nelle presentazioni PowerPoint su Android
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/androidjava/manage-smartart/
keywords:
- SmartArt
- testo SmartArt
- tipo di layout
- proprietà nascosta
- diagramma organizzativo
- diagramma organizzativo con immagine
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per Android usando chiari esempi di codice Java che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per Android via Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organizzativi e creare diagrammi organizzativi con immagini.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, itera attraverso [ISmartArt.getAllNodes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartart/#getAllNodes--), quindi leggi il [ITextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) restituito da [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout di SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType), lo cambia al valore `BasicProcess` e salva la presentazione.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificare se un nodo SmartArt è nascosto**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi diagramma visibili.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType) e verifica lo stato di nascondimento del nodo.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ottenere o impostare il layout del diagramma organizzativo**

Per i diagrammi SmartArt che utilizzano un layout di diagramma organizzativo, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) e [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) definiscono come i nodi figlio sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figlio in modo che pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OrganizationChartLayoutType) selezionato.

L'esempio seguente crea un diagramma organizzativo e imposta il layout per il primo nodo al valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/OrganizationChartLayoutType).

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Creare un diagramma organizzativo con immagine**

Un diagramma organizzativo con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti immagine. Usa il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SmartArtLayoutType) quando aggiungi l'oggetto SmartArt a una diapositiva.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. Il metodo [ISmartArt.setReversed](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come posso copiare SmartArt nella stessa diapositiva o in un'altra presentazione preservando la formattazione?**

Puoi [clonare la forma SmartArt](/slides/it/androidjava/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) o [clonare l'intera diapositiva](/slides/it/androidjava/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensioni, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per anteprima o esportazione web?**

Puoi [renderizzare la diapositiva](/slides/it/androidjava/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Imposta un valore distintivo per [Shape.getAlternativeText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getAlternativeText--) o [Shape.getName](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getName--) sulla forma SmartArt, cerca quel valore in [BaseSlide.getShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/baseslide/#getShapes--), quindi verifica che la forma corrispondente sia un [ISmartArt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ismartart/).