---
title: Administrar SmartArt
type: docs
weight: 10
url: /es/java/manage-smartart/
---

## **Obtener texto de SmartArt**
Ahora se ha añadido el método TextFrame a la interfaz [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) y a la clase [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) respectivamente. Esta propiedad te permite obtener todo el texto de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) si no solo tiene texto de nodos. El siguiente código de ejemplo te ayudará a obtener texto de un nodo SmartArt.

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

## **Cambiar el tipo de diseño de SmartArt**
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Cambia el [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) a BasicProcess.
- Escribe la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```java
Presentation pres = new Presentation();
try {
    // Agregar SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Cambiar LayoutType a BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Guardar presentación
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verificar la propiedad Oculta de SmartArt**
Por favor nota: el método [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) devuelve true si este nodo es un nodo oculto en el modelo de datos. Para verificar la propiedad oculta de cualquier nodo de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Agrega [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Agrega un nodo en SmartArt.
- Verifica la propiedad [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--).
- Escribe la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```java
Presentation pres = new Presentation();
try {
    // Agregar SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Agregar nodo en SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Verificar la propiedad isHidden
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

## **Obtener o establecer el tipo de gráfico organizacional**
Los métodos [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permiten obtener o establecer el tipo de gráfico organizacional asociado con el nodo actual. Para obtener o establecer el tipo de gráfico organizacional. Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Agrega [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
- Obtener o [establecer el tipo de gráfico organizacional](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Escribe la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```java
Presentation pres = new Presentation();
try {
    // Agregar SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtener o establecer el tipo de gráfico organizacional
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Guardar presentación
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crear gráfico organizacional de imagen**
Aspose.Slides para Java proporciona una API simple para crear gráficos y gráficos organizacionales de imagen de manera fácil. Para crear un gráfico en una diapositiva:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva por su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
4. Escribe la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.

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
Para cambiar el tipo de diseño de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Por favor, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Agrega [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en la diapositiva.
3. [Obtener](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) o [establecer](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) el estado del Diagrama SmartArt.
4. Escribe la presentación como un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.

```java
// Instanciar la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Agregar SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Obtener o establecer el estado del Diagrama SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Guardar presentación
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```