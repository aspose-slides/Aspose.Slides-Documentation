---
title: Gestionar SmartArt
type: docs
weight: 10
url: /es/nodejs-java/manage-smartart/
---

## **Obtener texto de SmartArt**
Now TextFrame method has been added to [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) class and [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) class respectively. This property allows you to get all text from [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it has not only nodes text. The following sample code will help you to get text from SmartArt node.
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


## **Cambiar tipo de diseño de SmartArt**
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Change [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) to BasicProcess.
- Write the presentation as a PPTX file.
In the example given below, we have added a connector between two shapes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agregar SmartArt BasicProcess
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


## **Comprobar la propiedad oculta de SmartArt**
Please note: method [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Add node on SmartArt.
- Check [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--) property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agregar SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // Agregar nodo en SmartArt
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
Methods [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) , [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
- Get or [set the organization chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Write the presentation as a PPTX file.
In the example given below, we have added a connector between two shapes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Agregar SmartArt BasicProcess
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
Aspose.Slides for Node.js via Java provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.
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
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
1. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) or [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) the state of SmartArt Diagram.
1. Write the presentation as a PPTX file.

The following code is used to create a chart.
```javascript
// Instanciar la clase Presentation que representa el archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Agregar SmartArt BasicProcess
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

**¿SmartArt admite reflejo/inversión para idiomas RTL?**

Yes. The [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) method switches the diagram direction (LTR/RTL) if the selected SmartArt type supports reversal.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

You can [clone the SmartArt shape](/slides/es/nodejs-java/shape-manipulations/) via the shapes collection ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) or [clone the entire slide](/slides/es/nodejs-java/clone-slides/) containing this shape. Both approaches preserve size, position, and styling.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Render the slide](/slides/es/nodejs-java/convert-powerpoint-to-png/) (or the whole presentation) to PNG/JPEG through the API that converts slides/presentations to images—SmartArt will be drawn as part of the slide.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

A common practice is to use [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt Text) or [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) and search for the shape by that attribute using [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), then check the type to confirm it’s [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). The documentation describes typical techniques for finding and working with shapes.