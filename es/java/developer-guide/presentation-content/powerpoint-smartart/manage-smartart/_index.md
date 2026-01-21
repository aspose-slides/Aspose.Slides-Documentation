---
title: Gestionar SmartArt en presentaciones de PowerPoint con Java
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
- organigrama de imagen
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para Java mediante ejemplos de código claros que aceleran el diseño de diapositivas y la automatización."
---

## **Obtener texto de un objeto SmartArt**
Ahora se ha añadido el método TextFrame a la interfaz [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) y a la clase [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) respectivamente. Esta propiedad le permite obtener todo el texto de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) si no solo tiene texto en los nodos. El siguiente fragmento de código le ayudará a obtener texto de un nodo SmartArt.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar el tipo de diseño de un objeto SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Añada [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Cambie [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) a BasicProcess.
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```java
Presentation pres = new Presentation();
try {
    // Añadir SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Cambiar LayoutType a BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Guardar presentación
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Comprobar la propiedad Visibility de un objeto SmartArt**
Tenga en cuenta: el método [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) devuelve true si este nodo está oculto en el modelo de datos. Para comprobar la propiedad oculta de cualquier nodo de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Añada [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Añada un nodo en SmartArt.
- Compruebe la propiedad [visibility](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--).
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```java
Presentation pres = new Presentation();
try {
    // Añadir SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Añadir nodo en SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Comprobar la propiedad isHidden
    boolean hidden = node.isHidden(); // Devuelve true

    if (hidden)
    {
        // Realizar algunas acciones o notificaciones
    }
    // Guardar presentación
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener o establecer el tipo de organigrama**
Los métodos [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) y [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permiten obtener o establecer el tipo de organigrama asociado al nodo actual. Para obtener o establecer el tipo de organigrama, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Añada [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
- Obtenga o [establezca el tipo de organigrama](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```java
Presentation pres = new Presentation();
try {
    // Añadir SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtener o establecer el tipo de organigrama
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Guardar presentación
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Crear un organigrama de imagen**
Aspose.Slides for Java ofrece una API sencilla para crear diagramas PictureOrganization de forma fácil. Para crear un diagrama en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva por su índice.
3. Añada un diagrama con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
4. Guarde la presentación modificada en un archivo PPTX

El siguiente código se utiliza para crear un diagrama.
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener o establecer el estado de SmartArt**
Para obtener o establecer el estado de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Añada [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
1. [Obtener](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) o [Establecer](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) el estado del diagrama SmartArt.
1. Guarde la presentación como un archivo PPTX.

El siguiente código se utiliza para crear un diagrama.
```java
// Instanciar la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Añadir SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Obtener o establecer el estado del diagrama SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Guardar presentación
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿SmartArt admite el reflejo/inversión para idiomas RTL?**

Sí. El método [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) cambia la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

Puede [clonar la forma SmartArt](/slides/es/java/shape-manipulations/) a través de la colección de formas ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) o [clonar la diapositiva completa](/slides/es/java/clone-slides/) que contiene esta forma. Ambos enfoques preservan el tamaño, la posición y el estilo.

**¿Cómo puedo renderizar SmartArt a una imagen rasterizada para vista previa o exportación web?**

[Renderice la diapositiva](/slides/es/java/convert-powerpoint-to-png/) (o toda la presentación) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones a imágenes; SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

Una práctica común es usar [texto alternativo](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) o un [nombre](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) y buscar la forma por ese atributo dentro de [formas de la diapositiva](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.