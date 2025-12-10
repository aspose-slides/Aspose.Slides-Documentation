---
title: Gestionar nodos de forma SmartArt en presentaciones usando Java
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo hijo
- agregar nodo
- posición del nodo
- acceder nodo
- eliminar nodo
- posición personalizada
- nodo asistente
- formato de relleno
- renderizar nodo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Gestiona los nodos de forma SmartArt en PPT y PPTX con Aspose.Slides para Java. Obtén ejemplos de código claros y consejos para optimizar tus presentaciones."
---

## **Añadir un nodo SmartArt**
Aspose.Slides for Java ha proporcionado la API más simple para administrar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a añadir un nodo y un nodo secundario dentro de una forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y cargue la presentación con una forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si es SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) en la forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) y establezca el texto en TextFrame.
1. Ahora, [Add](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) en el nodo SmartArt recién añadido y establezca el texto en TextFrame.
1. Guarde la presentación.
```java
// Cargar la presentación deseada
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertir la forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Agregar un nuevo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Agregar texto
            TemNode.getTextFrame().setText("Test");
    
            // Agregar un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Agregar texto
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Guardar la presentación
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Añadir un nodo SmartArt en una posición específica**
En el siguiente código de ejemplo hemos explicado cómo añadir los nodos secundarios correspondientes a los nodos respectivos de la forma SmartArt en una posición determinada.

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Añada una forma SmartArt de tipo [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) en la diapositiva accedida.
1. Acceda al primer nodo en la forma SmartArt añadida.
1. Ahora, añada el [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) para el [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) seleccionado en la posición 2 y establezca su texto.
1. Guarde la presentación.
```java
// Crear una instancia de presentación
Presentation pres = new Presentation();
try {
    // Acceder a la diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir IShape de Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Acceder al nodo SmartArt en el índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Añadir nuevo nodo hijo en la posición 2 del nodo padre
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Añadir texto
    chNode.getTextFrame().setText("Sample Text Added");

    // Guardar la presentación
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a un nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de una forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece únicamente cuando se añade la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargue la presentación con una forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si es SmartArt.
1. Recorra todos los [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
1. Acceda y muestre información como la posición del nodo SmartArt, nivel y texto.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Recorrer todos los nodos dentro de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Acceder al nodo SmartArt en el índice i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Imprimir los parámetros del nodo SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a un nodo secundario SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos secundarios correspondientes a los nodos respectivos de la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargue la presentación con una forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si es SmartArt.
1. Recorra todos los [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
1. Para cada [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) de SmartArt seleccionado, recorra todos los [**Child Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) dentro del nodo particular.
1. Acceda y muestre información como la posición del [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , nivel y texto.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Recorrer todos los nodos dentro de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Acceder al nodo SmartArt en el índice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Recorrer los nodos hijo en el nodo SmartArt en el índice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Acceder al nodo hijo en el nodo SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimir los parámetros del nodo hijo SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a un nodo secundario SmartArt en una posición específica**
En este ejemplo, aprenderemos a acceder a los nodos secundarios en una posición determinada correspondiente a los nodos respectivos de la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Añada una forma SmartArt de tipo [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Acceda a la forma SmartArt añadida.
1. Acceda al nodo en el índice 0 de la forma SmartArt accedida.
1. Ahora, acceda al [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) en la posición 1 del nodo SmartArt accedido usando el método **get_Item()**.
1. Acceda y muestre información como la posición del [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , nivel y texto.
```java
// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadiendo la forma SmartArt en la primera diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accediendo al nodo SmartArt en el índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accediendo al nodo hijo en la posición 1 del nodo padre
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimiendo los parámetros del nodo hijo SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar un nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de una forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargue la presentación con una forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si es SmartArt.
1. Verifique si el [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) tiene más de 0 nodos.
1. Seleccione el nodo SmartArt que se eliminará.
1. Ahora, elimine el nodo seleccionado usando el método [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Guarde la presentación.
```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Acceder al nodo SmartArt en el índice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Eliminar el nodo seleccionado
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Guardar la presentación
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar un nodo SmartArt de una posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de una forma SmartArt en una posición determinada.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargue la presentación con una forma SmartArt.
1. Obtenga la referencia de la primera diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt) si es SmartArt.
1. Seleccione el nodo de la forma SmartArt en el índice 0.
1. Ahora, verifique si el nodo SmartArt seleccionado tiene más de 2 nodos secundarios.
1. Ahora, elimine el nodo en la **Posición 1** usando el método [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Guarde la presentación.
```java
// Cargar la presentación deseada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertir la forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Acceder al nodo SmartArt en el índice 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Eliminar el nodo hijo en la posición 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Guardar la presentación
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer una posición personalizada para un nodo secundario en un objeto SmartArt**
Ahora Aspose.Slides for Java admite la configuración de las propiedades [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) y [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-). El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizados de SmartArtShape; también tenga en cuenta que añadir nuevos nodos provoca un recalculo de las posiciones y tamaños de todos los nodos. Con la configuración de posición personalizada, el usuario puede establecer los nodos según sus requisitos.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Mover la forma SmartArt a una nueva posición
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Cambiar los anchos de la forma SmartArt
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


## **Comprobar un nodo asistente**
{{% alert color="primary" %}} 

En este artículo investigaremos más a fondo las características de las formas SmartArt añadidas en diapositivas de presentación de forma programática usando Aspose.Slides for Java.

{{% /alert %}} 

Utilizaremos la siguiente forma SmartArt de origen para nuestra investigación en distintas secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origen en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **Assistant Nodes** en la colección de nodos SmartArt y modificarlos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) y cargue la presentación con una forma SmartArt.
1. Obtenga la referencia de la segunda diapositiva usando su índice.
1. Recorra cada forma dentro de la primera diapositiva.
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt) si es SmartArt.
1. Recorra todos los nodos dentro de la forma SmartArt y verifique si son [**Assistant Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--) .
1. Cambie el estado del nodo asistente a nodo normal.
1. Guarde la presentación.
```java
// Crear una instancia de presentación
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Recorrer todos los nodos de la forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Verificar si el nodo es un nodo Asistente
                if (node.isAssistant()) 
                {
                    // Establecer el nodo Asistente a false y convertirlo en nodo normal
                    node.isAssistant();
                }
            }
        }
    }
    
    // Guardar la presentación
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodos asistente modificados en la forma SmartArt dentro de la diapositiva**|

## **Establecer el formato de relleno de un nodo**
Aspose.Slides for Java permite añadir formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for Java.

Siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva usando su índice.
1. Añada una forma [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Establezca el [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) para los nodos de la forma SmartArt.
1. Guarde la presentación modificada como un archivo PPTX.
```java
// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Accediendo a la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadiendo forma SmartArt y nodos
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Configurando color de relleno del nodo
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


## **Generar una miniatura de un nodo secundario SmartArt**
Los desarrolladores pueden generar una miniatura del nodo secundario de un SmartArt siguiendo los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. [Add SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArtNodeCollection#addNode--).
1. Obtenga la referencia de un nodo usando su índice.
1. Obtenga la imagen en miniatura.
1. Guarde la imagen en miniatura en el formato de imagen deseado.
```java
// Instanciar la clase Presentation que representa el archivo PPTX
Presentation pres = new Presentation();
try {
    // Añadir SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Obtener la referencia de un nodo usando su índice
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


## **Preguntas frecuentes**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma regular, por lo que puede [aplicar animaciones estándar](/slides/es/java/shape-animation/) (entrada, salida, énfasis, rutas de movimiento) y ajustar la sincronización. También puede animar formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [texto alternativo](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) . Establecer un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se conservará la apariencia del SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/java/convert-powerpoint-to-pdf/), conservando el diseño, los colores y los efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) o a [SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para obtener una salida vectorial escalable, lo que lo hace adecuado para miniaturas, informes o uso web.