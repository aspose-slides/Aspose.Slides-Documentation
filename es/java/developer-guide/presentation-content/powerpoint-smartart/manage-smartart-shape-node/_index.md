---
title: Crear o Gestionar Nodos de Formas SmartArt en PowerPoint utilizando Java
linktitle: Gestionar Nodos de Formas SmartArt
type: docs
weight: 30
url: /es/java/manage-smartart-shape-node/
keywords: smartart powerpoint, nodos smartart, posición smartart, eliminar smartart, agregar nodos smartart, presentación de powerpoint, powerpoint java, api de powerpoint java
description: Gestionar nodos de arte inteligente y nodos hijos en presentaciones de PowerPoint en Java
---

## **Agregar Nodo SmartArt en Presentación de PowerPoint utilizando Java**
Aspose.Slides para Java ha proporcionado la API más simple para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y realizar un casting de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si lo es.
1. [Agregar un nuevo Nodo](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) en la forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) y establecer el texto en TextFrame.
1. Ahora, [Agregar](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Nodo Hijo**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) en el nodo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) recién agregado y establecer el texto en TextFrame.
1. Guardar la Presentación.

```java
// Cargar la presentación deseada
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Hacer casting de la forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Agregar un nuevo Nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Agregar texto
            TemNode.getTextFrame().setText("Prueba");
    
            // Agregar un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Agregar texto
            newNode.getTextFrame().setText("Nuevo Nodo Agregado");
        }
    }
    
    // Guardar Presentación
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Nodo SmartArt en una Posición Específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos hijos pertenecientes a nodos respectivos de la forma SmartArt en una posición particular.

1. Crear una instancia de la clase Presentation.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Agregar una forma [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) de tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) en la diapositiva accedida.
1. Acceder al primer nodo en la forma SmartArt agregada.
1. Ahora, agregar el [**Nodo Hijo**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) para el [**Nodo**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) seleccionado en la posición 2 y establecer su texto.
1. Guardar la Presentación.

```java
// Crear una instancia de presentación
Presentation pres = new Presentation();
try {
    // Acceder a la diapositiva de presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Agregar forma Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Acceder al nodo SmartArt en el índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Agregar un nuevo nodo hijo en la posición 2 en el nodo padre
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Agregar texto
    chNode.getTextFrame().setText("Texto de Ejemplo Agregado");

    // Guardar Presentación
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a Nodo SmartArt en Presentación de PowerPoint utilizando Java**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y realizar un casting de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si lo es.
1. Recorrer todos los [**Nodos**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
1. Acceder y mostrar información como posición del nodo SmartArt, nivel y texto.

```java
// Instanciar la clase Presentación
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Hacer casting de la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Recorrer todos los nodos dentro de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accediendo al nodo SmartArt en el índice i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Imprimiendo los parámetros del nodo SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a Nodo Hijo de SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos pertenecientes a nodos respectivos de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y realizar un casting de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si lo es.
1. Recorrer todos los [**Nodos**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
1. Para cada nodo SmartArt seleccionado [**Nodo**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode), recorrer todos los [**Nodos Hijos**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) dentro de ese nodo particular.
1. Acceder y mostrar información como posición, nivel y texto del [**Nodo Hijo**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instanciar la clase Presentación
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Hacer casting de la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Recorrer todos los nodos dentro de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accediendo al nodo SmartArt en el índice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Recorrer los nodos hijos en el nodo SmartArt en el índice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Accediendo al nodo hijo en el nodo SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimiendo los parámetros del nodo hijo SmartArt
                    System.out.print("j = " + j + ", Texto = " + node.getTextFrame().getText() + ",  Nivel = " + node.getLevel() + ", Posición = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a Nodo Hijo de SmartArt en una Posición Específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular pertenecientes a nodos respectivos de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Agregar una forma de tipo [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) SmartArt.
1. Acceder a la forma SmartArt agregada.
1. Acceder al nodo en el índice 0 para la forma SmartArt accedida.
1. Ahora, acceder al [**Nodo Hijo**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) en la posición 1 para el nodo SmartArt accedido utilizando el método **get_Item()**.
1. Acceder y mostrar información como posición, nivel y texto del [**Nodo Hijo**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregando la forma SmartArt en la primera diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accediendo al nodo SmartArt en el índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accediendo al nodo hijo en la posición 1 en el nodo padre
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimiendo los parámetros del nodo hijo SmartArt
    System.out.print("Texto = " + chNode.getTextFrame().getText() + ",  Nivel = " + chNode.getLevel() + ", Posición = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Nodo SmartArt en Presentación de PowerPoint utilizando Java**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y realizar un casting de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si lo es.
1. Verificar si el [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) tiene más de 0 nodos.
1. Seleccionar el nodo SmartArt a eliminar.
1. Ahora, eliminar el nodo seleccionado utilizando el método [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Guardar la Presentación.

```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Hacer casting de la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accediendo al nodo SmartArt en el índice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Eliminando el nodo seleccionado
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Guardar Presentación
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Nodo SmartArt en una Posición Específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la primera diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y realizar un casting de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si lo es.
1. Seleccionar el nodo forma SmartArt en el índice 0.
1. Ahora, verificar si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
1. Ahora, eliminar el nodo en la **Posición 1** utilizando el método [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Guardar la Presentación.

```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Hacer casting de la forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accediendo al nodo SmartArt en el índice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Eliminando el nodo hijo en la posición 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Guardar Presentación
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Posición Personalizada para Nodo Hijo en SmartArt**
Ahora Aspose.Slides para Java proporciona soporte para establecer propiedades [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) y [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-) de [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape). El siguiente fragmento de código muestra cómo establecer la posición, tamaño y rotación personalizada de SmartArtShape, también tenga en cuenta que agregar nuevos nodos causa un recálculo de las posiciones y tamaños de todos los nodos. Además, con la configuración de posición personalizada, el usuario puede establecer los nodos según los requisitos.

```java
// Instanciar la clase Presentación
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Mover la forma SmartArt a una nueva posición
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Cambiar los anchos de las formas SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Cambiar la altura de la forma SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Cambiar la rotación de la forma SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Comprobar Nodo Asistente**
{{% alert color="primary" %}} 

En este artículo investigaremos más a fondo las características de las formas SmartArt agregadas en las diapositivas de presentación programáticamente usando Aspose.Slides para Java.

{{% /alert %}} 

Utilizaremos la siguiente forma SmartArt de origen para nuestra investigación en diferentes secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origen en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **Nodos Asistentes** en la colección de nodos SmartArt y cómo cambiarlos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargar la presentación con la forma SmartArt.
1. Obtener la referencia de la segunda diapositiva utilizando su índice.
1. Recorrer cada forma dentro de la primera diapositiva.
1. Verificar si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y realizar un casting de la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si lo es.
1. Recorrer todos los nodos dentro de la forma SmartArt y verificar si son [**Nodos Asistentes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. Cambiar el estado del Nodo Asistente a nodo normal.
1. Guardar la Presentación.

```java
// Crear una instancia de presentación
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es del tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Hacer casting de la forma a SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Recorrer todos los nodos de la forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verificar si el nodo es un nodo asistente
                if (node.isAssistant()) 
                {
                    // Establecer el nodo asistente como falso y convertirlo en nodo normal
                    node.isAssistant();
                }
            }
        }
    }
    
    // Guardar Presentación
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodos Asistentes Cambiados en la forma SmartArt dentro de la diapositiva**|

## **Establecer Formato de Relleno de Nodo**
Aspose.Slides para Java permite agregar formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno utilizando Aspose.Slides para Java.

Por favor, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Agregar una forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Establecer el [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) para los nodos de la forma SmartArt.
1. Escribir la presentación modificada como un archivo PPTX.

```java
// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Accediendo a la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregando forma SmartArt y nodos
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Algun texto");
    
    // Estableciendo el color de relleno del nodo
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Guardar la presentación
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generar Miniatura del Nodo Hijo de SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. [Agregar SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtener la referencia de un nodo utilizando su índice.
1. Obtener la imagen de miniatura.
1. Guardar la imagen de miniatura en cualquier formato de imagen deseado.

```java
// Instanciar la clase Presentación que representa el archivo PPTX 
Presentation pres = new Presentation();
try {
    // Agregar SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Obtener la referencia de un nodo utilizando su índice  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Obtener miniatura
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Guardar miniatura
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```