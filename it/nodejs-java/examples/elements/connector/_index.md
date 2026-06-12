---
title: Connettore
type: docs
weight: 190
url: /it/nodejs-java/examples/elements/connector/
keywords:
- esempio di codice
- Connettore
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere, instradare e formattare i connettori tra le forme usando Aspose.Slides per Node.js, con esempi JavaScript per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come collegare le forme con i connettori e modificare i loro target utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungere un connettore**

Inserisci una forma connettore tra due punti sulla diapositiva.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedere a un connettore**

Recupera la prima forma connettore aggiunta a una diapositiva.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi al primo connettore sulla diapositiva.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere un connettore**

Elimina un connettore dalla diapositiva.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supponi che la prima forma sia un connettore e rimuovila.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ricollegare le forme**

Collega un connettore a due forme assegnando i target di inizio e fine.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```