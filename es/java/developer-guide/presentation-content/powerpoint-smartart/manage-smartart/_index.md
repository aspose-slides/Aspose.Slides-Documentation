---
title: Gestionar SmartArt en presentaciones de PowerPoint usando Java
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/java/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama con imágenes
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprende a crear y editar SmartArt en PowerPoint con Aspose.Slides para Java usando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Visión general**

SmartArt es un diagrama de PowerPoint compuesto por nodos, formas de nodo y un diseño. Con Aspose.Slides for Java, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo SmartArt puede contener una o más formas. Para leer el texto visible, itera a través de [ISmartArt.getAllNodes](https://reference.aspose.com/slides/es/java/com.aspose.slides/ismartart/#getAllNodes--), luego lee el [ITextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/) devuelto por [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/java/com.aspose.slides/SmartArtLayoutType), lo cambia al valor `BasicProcess` y guarda la presentación.

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

## **Comprobar si un nodo SmartArt está oculto**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/es/java/com.aspose.slides/ismartartnode/#isHidden--) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/java/com.aspose.slides/SmartArtLayoutType) y comprueba el estado oculto del nodo.

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

## **Obtener o establecer el diseño del organigrama**

Para los diagramas SmartArt que utilizan un diseño de organigrama, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/es/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) y [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/es/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) definen cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes hacer que los nodos hijos cuelguen a la izquierda, a la derecha o en ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/java/com.aspose.slides/OrganizationChartLayoutType) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/java/com.aspose.slides/OrganizationChartLayoutType).

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

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño SmartArt creado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Usa el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/java/com.aspose.slides/SmartArtLayoutType) al añadir el objeto SmartArt a una diapositiva.

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

## **Preguntas frecuentes**

**¿SmartArt admite reflejo o inversión para idiomas RTL?**

Sí. El método [ISmartArt.setReversed](https://reference.aspose.com/slides/es/java/com.aspose.slides/ismartart/#setReversed-boolean-) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación preservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) o [clonar toda la diapositiva](/slides/es/java/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderiza la diapositiva](/slides/es/java/convert-powerpoint-to-png/) o la presentación completa a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Asigna un valor distintivo a [Shape.getAlternativeText](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getAlternativeText--) o a [Shape.getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getName--) en la forma SmartArt, busca ese valor en [BaseSlide.getShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/baseslide/#getShapes--), y luego verifica que la forma coincidente sea un [ISmartArt](https://reference.aspose.com/slides/es/java/com.aspose.slides/ismartart/).