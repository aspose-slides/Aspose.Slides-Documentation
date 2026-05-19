---
title: Gestionar SmartArt en presentaciones de PowerPoint usando JavaScript
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/nodejs-java/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama con imágenes
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para Node.js usando ejemplos claros de código JavaScript que aceleran el diseño y la automatización de diapositivas."
---
## **Resumen**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodo y un diseño. Con Aspose.Slides para Node.js a través de Java, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas de imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo SmartArt puede contener una o más formas. Para leer el texto visible, recorre [SmartArt.getAllNodes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartart/#getAllNodes--), luego lee el [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/) devuelto por [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

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

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor [SmartArtLayoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, lo cambia al valor `BasicProcess` y guarda la presentación.

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

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartnode/ishidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor [SmartArtLayoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` y comprueba el estado oculto del nodo.

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

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que usan un diseño de organigrama, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) y [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) definen cómo se disponen los nodos secundarios bajo un nodo principal. Por ejemplo, puedes establecer que los nodos secundarios cuelguen por la izquierda, la derecha o ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

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

## **Crear un organigrama de imágenes**

Un organigrama de imágenes es un diseño SmartArt pensado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Usa el valor [SmartArtLayoutType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` al añadir el objeto SmartArt a una diapositiva.

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

**¿SmartArt admite la reflexión o inversión para idiomas RTL?**

Sí. El método [SmartArt.setReversed](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartart/setreversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

Puedes [Clonar la forma SmartArt](/slides/es/nodejs-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/addclone/) o [Clonar toda la diapositiva](/slides/es/nodejs-java/clone-slides/) que contiene el SmartArt. Ambos métodos conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderizar la diapositiva](/slides/es/nodejs-java/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt concreto en una diapositiva si hay varios?**

Establece un valor distintivo en [Shape.setAlternativeText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/setalternativetext/) o [Shape.setName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/setname/) del objeto SmartArt, busca ese valor en [BaseSlide.getShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/baseslide/#getShapes) y luego verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/smartart/).