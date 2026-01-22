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
- organigrama de imagen
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para Node.js usando claros ejemplos de código JavaScript que aceleran el diseño y la automatización de diapositivas."
---

## **Obtener texto de SmartArt**
Ahora se ha añadido el método TextFrame a la clase [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) y a la clase [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) respectivamente. Esta propiedad le permite obtener todo el texto de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) aunque no solo contenga texto de los nodos. El siguiente código de ejemplo le ayudará a obtener el texto de un nodo de SmartArt.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar el tipo de diseño de SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su índice.
- Añada [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Cambie [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) a BasicProcess.
- Grabe la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Añadir SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Cambiar LayoutType a BasicProcess
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // Guardar presentación
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Comprobar la propiedad Visibility de SmartArt**
Nota: el método [SmartArtNode.isHidden()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) devuelve true si este nodo está oculto en el modelo de datos. Para comprobar la propiedad oculta de cualquier nodo de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Añada [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Añada un nodo en SmartArt.
- Compruebe la propiedad [visibility](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/).
- Grabe la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Añadir SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // Añadir nodo en SmartArt
    var node = smart.getAllNodes().addNode();
    // Comprobar la propiedad isHidden
    var hidden = node.isHidden();// Devuelve true
    if (hidden) {
        // Realizar algunas acciones o notificaciones
    }
    // Guardar presentación
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtener o establecer el tipo de organigrama**
Los métodos [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) y [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) permiten obtener o establecer el tipo de organigrama asociado al nodo actual. Para obtener o establecer el tipo de organigrama, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Añada [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
- Obtenga o [establezca el tipo de organigrama](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Grabe la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Añadir SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Obtener o establecer el tipo de organigrama
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // Guardar presentación
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Crear organigrama de imagen**
Aspose.Slides for Node.js via Java ofrece una API simple para crear gráficos PictureOrganization de forma fácil. Para crear un gráfico en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados y el tipo deseado (ChartType.PictureOrganizationChart).
4. Grabe la presentación modificada en un archivo PPTX

El siguiente código se utiliza para crear un gráfico.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtener o establecer el estado de SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Añada [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
3. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) o [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) el estado del diagrama SmartArt.
4. Grabe la presentación como un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.
```javascript
// Instanciar la clase Presentation que representa el archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Añadir SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // Obtener o establecer el estado del diagrama SmartArt
    smart.setReversed(true);
    var flag = smart.isReversed();
    // Guardar la presentación
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿SmartArt admite la inversión/volteado para idiomas RTL?**

Sí. El método [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) cambia la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puede [clone the SmartArt shape](/slides/es/nodejs-java/shape-manipulations/) a través de la colección de formas ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) o [clone the entire slide](/slides/es/nodejs-java/clone-slides/) que contiene esta forma. Ambos enfoques preservan el tamaño, la posición y el estilo.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Render the slide](/slides/es/nodejs-java/convert-powerpoint-to-png/) (o toda la presentación) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones en imágenes—SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt concreto en una diapositiva si hay varios?**

Una práctica habitual es utilizar [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt Text) o [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) y buscar la forma por ese atributo usando [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.