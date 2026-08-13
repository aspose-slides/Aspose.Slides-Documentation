---
title: "Gestionar nodos de forma SmartArt en presentaciones en Android"
linktitle: "Nodo de forma SmartArt"
type: docs
weight: 30
url: /es/androidjava/manage-smartart-shape-node/
keywords:
- "nodo SmartArt"
- "nodo secundario"
- "agregar nodo"
- "posición del nodo"
- "acceder al nodo"
- "eliminar nodo"
- "posición personalizada"
- "nodo asistente"
- "formato de relleno"
- "renderizar nodo"
- "PowerPoint"
- "presentación"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Gestiona nodos de forma SmartArt en PPT y PPTX con Aspose.Slides para Android. Obtén ejemplos claros de código Java y consejos para optimizar tus presentaciones."
---
## **Visión general**

Los gráficos SmartArt en presentaciones de PowerPoint se organizan mediante nodos que contienen texto y definen la estructura del diagrama. Aspose.Slides le permite trabajar con estos nodos SmartArt de forma programática: agregar nodos y nodos secundarios, insertar nodos secundarios en una posición específica, acceder a nodos existentes y leer su texto, nivel y posición.

Este artículo explica cómo administrar los nodos de forma SmartArt. Muestra cómo eliminar nodos, trabajar con nodos secundarios por índice o posición, cambiar un nodo asistente a un nodo normal, ajustar la posición, el tamaño y la rotación de los nodos de forma SmartArt, establecer formatos de relleno de los nodos y generar una imagen en miniatura para un nodo SmartArt.

## **Agregar un nodo SmartArt**
Aspose.Slides for Android via Java ha proporcionado la API más sencilla para administrar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo le ayudará a agregar un nodo y un nodo secundario dentro de una forma SmartArt.

1. Crear una instancia de la clase [Presentation] y cargar la presentación con una forma SmartArt.  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Recorrer todas las formas dentro de la primera diapositiva.  
1. Comprobar si la forma es de tipo [SmartArt] y convertir la forma seleccionada a [SmartArt] si es SmartArt.  
1. [Agregar un nuevo nodo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) en la forma SmartArt mediante la [**NodeCollection**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) y establecer el texto en el TextFrame.  
1. Ahora, [Agregar](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) al nodo SmartArt recién añadido y establecer el texto en el TextFrame.  
1. Guardar la presentación.

```java
import com.aspose.slides.*;

// Cargar la presentación deseada
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Comprobar si la forma es de tipo SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertir la forma a SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Agregar un nuevo nodo SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Agregar texto
            TemNode.getTextFrame().setText("Test");
    
            // Agregar un nuevo nodo secundario en el nodo padre. Se añadirá al final de la colección
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

## **Agregar un nodo SmartArt en una posición específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos secundarios que pertenecen a los nodos respectivos de una forma SmartArt en una posición concreta.

1. Crear una instancia de la clase [Presentation].  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Agregar una forma SmartArt de tipo [**StackedList**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) en la diapositiva accedida.  
1. Acceder al primer nodo de la forma SmartArt añadida.  
1. Ahora, agregar el [**Child Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) para el [**Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtNode) seleccionado en la posición 2 y establecer su texto.  
1. Guardar la presentación.

```java
import com.aspose.slides.*;

// Crear una instancia de presentación
Presentation pres = new Presentation();
try {
    // Acceder a la diapositiva de la presentación
    ISlide slide = pres.getSlides().get_Item(0);

    // Añadir IShape SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Acceder al nodo SmartArt con índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Añadir nuevo nodo secundario en la posición 2 del nodo padre
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
El siguiente código de ejemplo le ayudará a acceder a los nodos dentro de una forma SmartArt. Tenga en cuenta que el LayoutType del SmartArt se elige cuando se añade la forma; cambiarlo después con **setLayout** reconstruye todo el diagrama, por lo que las posiciones y tamaños de los nodos que haya establecido se recalculan.

1. Crear una instancia de la clase [Presentation] y cargar la presentación con una forma SmartArt.  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Recorrer todas las formas dentro de la primera diapositiva.  
1. Comprobar si la forma es de tipo [SmartArt] y convertir la forma seleccionada a [SmartArt] si es SmartArt.  
1. Recorrer todos los [**Nodes**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.  
1. Acceder y mostrar información como la posición del nodo SmartArt, su nivel y su texto.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Comprobar si la forma es de tipo SmartArt
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

## **Acceder a un nodo secundario de SmartArt**
El siguiente código de ejemplo le ayudará a acceder a los nodos secundarios que pertenecen a los nodos respectivos de una forma SmartArt.

1. Crear una instancia de la clase [Presentation] y cargar la presentación con una forma SmartArt.  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Recorrer todas las formas dentro de la primera diapositiva.  
1. Comprobar si la forma es de tipo [SmartArt] y convertir la forma seleccionada a [SmartArt] si es SmartArt.  
1. Recorrer todos los [**Nodes**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.  
1. Para cada [**Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtNode) de SmartArt seleccionado, recorrer todos los [**Child Nodes**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) dentro de ese nodo particular.  
1. Acceder y mostrar información como la posición, el nivel y el texto del [**Child Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtener la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : slide.getShapes()) 
    {
        // Comprobar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Recorrer todos los nodos dentro de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Acceder al nodo SmartArt en el índice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Recorrer los nodos secundarios del nodo SmartArt en el índice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Acceder al nodo secundario en el nodo SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimir los parámetros del nodo secundario SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a un nodo secundario de SmartArt en una posición específica**
En este ejemplo aprenderemos a acceder a los nodos secundarios en una posición concreta que pertenecen a los nodos respectivos de una forma SmartArt.

1. Crear una instancia de la clase [Presentation].  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Agregar una forma SmartArt de tipo [**StackedList**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
1. Acceder a la forma SmartArt añadida.  
1. Acceder al nodo con índice 0 de la forma SmartArt accedida.  
1. Ahora, acceder al [**Child Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) en la posición 1 del nodo SmartArt accedido mediante el método **get_Item()**.  
1. Acceder y mostrar información como la posición, el nivel y el texto del [**Child Node**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir la forma SmartArt en la primera diapositiva
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Acceder al nodo SmartArt en el índice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Acceder al nodo secundario en la posición 1 del nodo padre
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimir los parámetros del nodo secundario SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar un nodo SmartArt**
En este ejemplo aprenderemos a eliminar los nodos dentro de una forma SmartArt.

1. Crear una instancia de la clase [Presentation] y cargar la presentación con una forma SmartArt.  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Recorrer todas las formas dentro de la primera diapositiva.  
1. Comprobar si la forma es de tipo [SmartArt] y convertir la forma seleccionada a [SmartArt] si es SmartArt.  
1. Comprobar si el [SmartArt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArt) tiene más de 0 nodos.  
1. Seleccionar el nodo SmartArt que se va a eliminar.  
1. Ahora, eliminar el nodo seleccionado mediante el método [**RemoveNode**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .  
1. Guardar la presentación.

```java
import com.aspose.slides.*;

// Cargar la presentación deseada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Comprobar si la forma es de tipo SmartArt
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
En este ejemplo aprenderemos a eliminar los nodos dentro de una forma SmartArt en una posición concreta.

1. Crear una instancia de la clase [Presentation] y cargar la presentación con una forma SmartArt.  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Recorrer todas las formas dentro de la primera diapositiva.  
1. Comprobar si la forma es de tipo [SmartArt] y convertir la forma seleccionada a [SmartArt] si es SmartArt.  
1. Seleccionar el nodo de la forma SmartArt con índice 0.  
1. Ahora, comprobar si el nodo SmartArt seleccionado tiene más de 2 nodos secundarios.  
1. Ahora, eliminar el nodo en la **Posición 1** mediante el método [**RemoveNode**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .  
1. Guardar la presentación.

```java
import com.aspose.slides.*;

// Cargar la presentación deseada
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Comprobar si la forma es de tipo SmartArt
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
                    // Eliminar el nodo secundario en la posición 1
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
Ahora Aspose.Slides for Android via Java admite la configuración de las propiedades [SmartArtShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShape#setX-float-) y [Y](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShape#setY-float-). El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizados de SmartArtShape; tenga en cuenta que agregar nuevos nodos provoca una recalculación de las posiciones y tamaños de todos los nodos. Además, con la configuración de posición personalizada, el usuario puede colocar los nodos según sus requisitos.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Mover la forma SmartArt a una nueva posición
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Cambiar el ancho de la forma SmartArt
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
{{% alert color="info" %}} 

En este artículo investigaremos más a fondo las funciones de las formas SmartArt añadidas en diapositivas de presentación de forma programática mediante Aspose.Slides for Android via Java.

{{% /alert %}} 

Utilizaremos la siguiente forma SmartArt de origen para nuestra investigación en las distintas secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origen en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **Assistant Nodes** en la colección de nodos SmartArt y cómo cambiarlos.

1. Crear una instancia de la clase [Presentation] y cargar la presentación con una forma SmartArt.  
1. Obtener la referencia de la primera diapositiva mediante su índice.  
1. Recorrer todas las formas dentro de la primera diapositiva.  
1. Comprobar si la forma es de tipo [SmartArt] y convertir la forma seleccionada a [SmartArt] si es SmartArt.  
1. Recorrer todos los nodos dentro de la forma SmartArt y comprobar si son [**Assistant Nodes**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
1. Cambiar el estado del nodo asistente a nodo normal.  
1. Guardar la presentación.

```java
import com.aspose.slides.*;

// Crear una instancia de presentación
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Recorrer todas las formas dentro de la primera diapositiva
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Comprobar si la forma es de tipo SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forma a SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Recorrer todos los nodos de la forma SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Comprobar si el nodo es un nodo asistente
                if (node.isAssistant()) 
                {
                    // Establecer el nodo asistente a false y convertirlo en nodo normal
                    node.setAssistant(false);
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
|**Figura: Nodos asistentes modificados en la forma SmartArt dentro de la diapositiva**|

## **Establecer el formato de relleno de un nodo**
Aspose.Slides for Android via Java permite añadir formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for Android via Java.

Siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation].  
1. Obtener la referencia de una diapositiva mediante su índice.  
1. Añadir una forma [SmartArt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Establecer el [**FillFormat**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IShape#getFillFormat--) para los nodos de la forma SmartArt.  
1. Guardar la presentación modificada como un archivo PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar la presentación
Presentation pres = new Presentation();
try {
    // Acceder a la diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir forma SmartArt y nodos
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Establecer el color de relleno del nodo
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

## **Generar una miniatura de un nodo SmartArt**
Los desarrolladores pueden generar una miniatura de un nodo de SmartArt siguiendo los pasos a continuación:

1. Crear una instancia de la clase [Presentation].  
1. [Agregar SmartArt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Obtener la referencia de un nodo mediante su índice.  
1. Obtener la imagen en miniatura.  
1. Guardar la imagen en miniatura en el formato de imagen deseado.

```java
import com.aspose.slides.*;

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

## **FAQ**

### ¿Se admite la animación de SmartArt?

Sí. SmartArt se trata como una forma normal, por lo que puede [aplicar animaciones estándar](/slides/es/androidjava/shape-animation/) (entrada, salida, énfasis, rutas de movimiento) y ajustar la sincronización. También puede animar las formas dentro de los nodos SmartArt cuando sea necesario.

### ¿Cómo puedo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?

Asigne y busque mediante [texto alternativo](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getAlternativeText--). Establecer un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de identificadores internos.

### ¿Se conservará la apariencia del SmartArt al convertir la presentación a PDF?

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), preservando el diseño, los colores y los efectos.

### ¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) o a [SVG](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) para obtener una salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.