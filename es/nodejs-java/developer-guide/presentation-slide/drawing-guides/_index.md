---
title: Gestionar guías de dibujo en presentaciones en JavaScript
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/nodejs-java/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- máster de notas
- máster de folletos
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Añadir, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint utilizando Aspose.Slides para Node.js a través de Java."
---
## **Descripción general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma constante mientras editan una presentación en PowerPoint. Son especialmente útiles cuando una aplicación genera una presentación que luego se refinará manualmente: la aplicación puede guardar los mismos auxiliares de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación o en la salida renderizada. Aspose.Slides for Node.js via Java las expone a través de la clase [DrawingGuidesCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguidescollection/). Una guía está representada por [DrawingGuide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o la plantilla correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Agregar guías a la vista de diapositiva**

Utilice [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) para gestionar las guías mostradas mientras se editan diapositivas normales. Llame a [DrawingGuidesCollection.add](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguidescollection/#add) con un valor de [Orientation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo agrega una guía vertical a la derecha del centro de la diapositiva y una guía horizontal debajo de ella:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acceder a las guías de dibujo**

Los métodos [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguidescollection/#getCount) y [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) proporcionan acceso a las guías existentes. Los métodos [DrawingGuide.getOrientation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguide/#getPosition) y [DrawingGuide.getColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguide/#getColor) devuelven valores que también pueden modificarse mediante los métodos setter correspondientes.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada anteriormente:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Agregar guías a la diapositiva maestra y a las diapositivas de diseño**

Una diapositiva maestra y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) para una diapositiva maestra y [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) para una diapositiva de diseño.

El siguiente ejemplo agrega una guía vertical a la primera diapositiva maestra y una guía horizontal a la primera diapositiva de diseño:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Agregar guías a los máster de notas y de folletos**

Los máster de notas y los máster de folletos también admiten guías de dibujo. Utilice [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) y [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) para acceder a sus colecciones. Si una presentación no contiene uno de estos máster, `MasterNotesSlideManager.setDefaultMasterNotesSlide` o `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` crea el máster predeterminado y lo devuelve.

El siguiente ejemplo agrega una guía horizontal a un máster de notas y una guía vertical a un máster de folletos:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eliminar guías de dibujo**

Llame a [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguidescollection/#clear) para eliminar todas las guías de una colección concreta. El borrado de una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo elimina las guías de la vista de diapositiva y todas las guías en las diapositivas maestra, las diapositivas de diseño, el máster de notas y el máster de folletos sin crear másteres faltantes:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Aparecen las guías de dibujo en una presentación o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías separadas para diapositivas maestras, diapositivas de diseño, máster de notas y máster de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las posiciones horizontales se miden desde el borde superior.

**¿El borrado de las guías de dibujo elimina formas o cambia el contenido de la diapositiva?**

No. El método [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/drawingguidescollection/#clear) elimina solo las guías de la colección seleccionada. Las formas y demás contenido de la diapositiva permanecen sin cambios.