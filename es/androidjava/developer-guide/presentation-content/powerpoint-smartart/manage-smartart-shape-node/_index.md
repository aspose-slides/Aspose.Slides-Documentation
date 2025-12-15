---
title: Gestionar nodos de forma SmartArt en presentaciones en Android
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/androidjava/manage-smartart-shape-node/
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
- Android
- Java
- Aspose.Slides
description: "Gestiona los nodos de forma SmartArt en PPT y PPTX con Aspose.Slides para Android. Obtén ejemplos claros de código Java y consejos para optimizar tus presentaciones."
---

## **Agregar un nodo SmartArt**
Aspose.Slides for Android via Java ha proporcionado la API más simple para administrar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de una forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Recorra todas las formas dentro de la primera diapositiva.  
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si es SmartArt.  
1. [Add a new Node](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) en la colección **NodeCollection** de la forma SmartArt y establezca el texto en TextFrame.  
1. Ahora, [Add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) un **Child Node** en el nodo SmartArt recién agregado y establezca el texto en TextFrame.  
1. Guarde la presentación.  
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
            // Convertir la forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Añadir un nuevo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Añadir texto
            TemNode.getTextFrame().setText("Test");
    
            // Añadir un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Añadir texto
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Guardar la presentación
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar un nodo SmartArt en una posición específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos hijos que pertenecen a los nodos respectivos de una forma SmartArt en una posición particular.

1. Cree una instancia de la clase Presentation.  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Agregue una forma SmartArt del tipo [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) en la diapositiva accedida.  
1. Acceda al primer nodo de la forma SmartArt añadida.  
1. Ahora, agregue el **Child Node** para el **Node** seleccionado en la posición 2 y establezca su texto.  
1. Guarde la presentación.  
```java
// Crear una instancia de presentación
Presentation pres = new Presentation();
try {
    // Acceder a la diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir Smart Art IShape
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
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de una forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece únicamente cuando se agrega la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y cargue la presentación con la forma SmartArt.  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Recorra todas las formas dentro de la primera diapositiva.  
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si es SmartArt.  
1. Recorra todos los **Nodes** dentro de la forma SmartArt.  
1. Acceda y muestre información como la posición del nodo SmartArt, el nivel y el texto.  
```java
// Instanciar la clase Presentation
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


## **Acceder a un nodo hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos que pertenecen a los nodos respectivos de una forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y cargue la presentación con la forma SmartArt.  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Recorra todas las formas dentro de la primera diapositiva.  
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si es SmartArt.  
1. Recorra todos los **Nodes** dentro de la forma SmartArt.  
1. Para cada **Node** de la forma SmartArt seleccionado, recorra todos los **Child Nodes** dentro del nodo particular.  
1. Acceda y muestre información como la posición, el nivel y el texto del **Child Node**.  
```java
// Instanciar la clase Presentation
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
            // Convertir la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Recorrer todos los nodos dentro del SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Acceder al nodo SmartArt en el índice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Recorrer los nodos hijos del nodo SmartArt en el índice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Acceder al nodo hijo en el nodo SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimir los parámetros del nodo hijo del SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a un nodo hijo SmartArt en una posición específica**
En este ejemplo aprenderemos a acceder a los nodos hijos en una posición particular que pertenecen a los nodos respectivos de una forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Agregue una forma SmartArt del tipo [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
1. Acceda a la forma SmartArt añadida.  
1. Acceda al nodo en el índice 0 de la forma SmartArt accedida.  
1. Ahora, acceda al **Child Node** en la posición 1 del nodo SmartArt accedido usando el método **get_Item()**.  
1. Acceda y muestre información como la posición, el nivel y el texto del **Child Node**.  
```java
// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agregar la forma SmartArt en la primera diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Acceder al nodo SmartArt en el índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Acceder al nodo hijo en la posición 1 del nodo padre
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimir los parámetros del nodo hijo del SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar un nodo SmartArt**
En este ejemplo aprenderemos a eliminar los nodos dentro de una forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y cargue la presentación con la forma SmartArt.  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Recorra todas las formas dentro de la primera diapositiva.  
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si es SmartArt.  
1. Verifique si el SmartArt tiene más de 0 nodos.  
1. Seleccione el nodo SmartArt que se eliminará.  
1. Ahora, elimine el nodo seleccionado usando el método [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
1. Guarde la presentación.  
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
En este ejemplo aprenderemos a eliminar los nodos dentro de una forma SmartArt en una posición particular.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y cargue la presentación con la forma SmartArt.  
1. Obtenga la referencia de la primera diapositiva usando su índice.  
1. Recorra todas las formas dentro de la primera diapositiva.  
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si es SmartArt.  
1. Seleccione el nodo de la forma SmartArt en el índice 0.  
1. Ahora, verifique si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.  
1. Ahora, elimine el nodo en la **Posición 1** usando el método [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
1. Guarde la presentación.  
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


## **Establecer una posición personalizada para un nodo hijo en un objeto SmartArt**
Ahora Aspose.Slides for Android via Java admite la configuración de las propiedades [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) y [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-). El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizados de SmartArtShape; también tenga en cuenta que agregar nuevos nodos provoca una recalculación de las posiciones y tamaños de todos los nodos. Con la configuración de posición personalizada, el usuario puede establecer los nodos según los requisitos.  
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

En este artículo investigaremos más a fondo las características de las formas SmartArt añadidas en diapositivas de presentación de forma programática usando Aspose.Slides for Android via Java. 

{{% /alert %}} 

Usaremos la siguiente forma SmartArt fuente para nuestra investigación en diferentes secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt fuente en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **Assistant Nodes** en la colección de nodos SmartArt y cambiarlos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) y cargue la presentación con la forma SmartArt.  
1. Obtenga la referencia de la segunda diapositiva usando su índice.  
1. Recorra todas las formas dentro de la primera diapositiva.  
1. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si es SmartArt.  
1. Recorra todos los nodos dentro de la forma SmartArt y compruebe si son [**Assistant Nodes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
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
                // Verificar si el nodo es nodo asistente
                if (node.isAssistant()) 
                {
                    // Establecer el nodo asistente a false y convertirlo en nodo normal
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
|**Figura: Nodos asistentes cambiados en la forma SmartArt dentro de la diapositiva**|

## **Establecer el formato de relleno de un nodo**
Aspose.Slides for Android via Java permite agregar formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for Android via Java.

Siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Obtenga la referencia de una diapositiva usando su índice.  
1. Agregue una forma [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Establezca el [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) para los nodos de la forma SmartArt.  
1. Escriba la presentación modificada como un archivo PPTX.  
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
    
    // Configurando el color de relleno del nodo
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


## **Generar una miniatura de un nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. [Add SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Obtenga la referencia de un nodo usando su índice.  
1. Obtenga la imagen en miniatura.  
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.  
```java
// Instanciar la clase Presentation que representa el archivo PPTX 
Presentation pres = new Presentation();
try {
    // Agregar SmartArt 
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


## **FAQ**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma regular, por lo que puede [aplicar animaciones estándar](/slides/es/androidjava/shape-animation/) (entrada, salida, énfasis, trayectorias) y ajustar la sincronización. También puede animar formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [texto alternativo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--). Establecer un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se preservará la apariencia del SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), preservando el diseño, colores y efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) o a [SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para obtener una salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.