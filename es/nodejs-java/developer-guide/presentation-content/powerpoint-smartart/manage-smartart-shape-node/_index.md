---
title: Crear o administrar nodo de forma SmartArt de PowerPoint en JavaScript
linktitle: Administrar nodo de forma SmartArt
type: docs
weight: 30
url: /es/nodejs-java/manage-smartart-shape-node/
keywords: smartart PowerPoint, nodos smartart, posición smartart, eliminar smartart, agregar nodos smartart, presentación PowerPoint, PowerPoint Java, API JavaScript de PowerPoint
description: Administrar nodo de smart art y nodo hijo en presentaciones PowerPoint con JavaScript
---

## **Agregar nodo SmartArt en presentación de PowerPoint usando JavaScript**
Aspose.Slides for Node.js via Java ha proporcionado la API más simple para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si es SmartArt.
5. Agregue un [nuevo nodo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) en la forma SmartArt [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) y establezca el texto en TextFrame.
6. Ahora, [agregue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) en el nodo SmartArt recién agregado y establezca el texto en TextFrame.
7. Guarde la presentación.
```javascript
// Cargar la presentación deseada
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar si la forma es del tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Convertir la forma a SmartArt
            var smart = shape;
            // Añadir un nuevo nodo SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Añadir texto
            TemNode.getTextFrame().setText("Test");
            // Añadir un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
            var newNode = TemNode.getChildNodes().addNode();
            // Añadir texto
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Guardar la presentación
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar nodo SmartArt en posición específica**
En el siguiente código de ejemplo hemos explicado cómo agregar los nodos hijo pertenecientes a los nodos respectivos de la forma SmartArt en una posición particular.

1. Cree una instancia de la clase Presentation.
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Agregue una forma [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) de tipo [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) en la diapositiva accedida.
4. Acceda al primer nodo en la forma SmartArt añadida.
5. Ahora, agregue el [**Child Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) para el [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) seleccionado en la posición 2 y establezca su texto.
6. Guarde la presentación.
```javascript
// Creando una instancia de presentación
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la diapositiva de la presentación
    var slide = pres.getSlides().get_Item(0);
    // Agregar Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accediendo al nodo SmartArt en el índice 0
    var node = smart.getAllNodes().get_Item(0);
    // Añadiendo nuevo nodo hijo en la posición 2 del nodo padre
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Agregar texto
    chNode.getTextFrame().setText("Sample Text Added");
    // Guardar presentación
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder al nodo SmartArt en presentación de PowerPoint usando JavaScript**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y solo se establece cuando se agrega la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si es SmartArt.
5. Recorra todos los [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
6. Acceda y muestre información como la posición del nodo SmartArt, nivel y texto.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Verificar si la forma es del tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArt
            var smart = shape;
            // Recorrer todos los nodos dentro de SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Accediendo al nodo SmartArt en el índice i
                var node = smart.getAllNodes().get_Item(j);
                // Imprimiendo los parámetros del nodo SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder al nodo hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijo pertenecientes a los nodos respectivos de la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si es SmartArt.
5. Recorra todos los [**Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) dentro de la forma SmartArt.
6. Para cada [**Node**] de la forma SmartArt seleccionada, recorra todos los [**Child Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) dentro del nodo particular.
7. Acceda y muestre información como la posición, nivel y texto del [**Child Node**].
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Obtener la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Recorrer cada forma dentro de la primera diapositiva
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Verificar si la forma es del tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArt
            var smart = shape;
            // Recorrer todos los nodos dentro de SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Accediendo al nodo SmartArt en el índice i
                var node0 = smart.getAllNodes().get_Item(i);
                // Recorriendo los nodos hijo en el nodo SmartArt en el índice i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Accediendo al nodo hijo en el nodo SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Imprimiendo los parámetros del nodo hijo SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder al nodo hijo SmartArt en posición específica**
En este ejemplo, aprenderemos a acceder a los nodos hijo en una posición particular pertenecientes a los nodos respectivos de la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Agregue una forma SmartArt de tipo [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
4. Acceda a la forma SmartArt añadida.
5. Acceda al nodo en el índice 0 de la forma SmartArt accedida.
6. Ahora, acceda al [**Child Node**] en la posición 1 del nodo SmartArt accedido utilizando el método **get_Item()**.
7. Acceda y muestre información como la posición, nivel y texto del [**Child Node**].
```javascript
// Instanciar la presentación
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregando la forma SmartArt en la primera diapositiva
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accediendo al nodo SmartArt en el índice 0
    var node = smart.getAllNodes().get_Item(0);
    // Accediendo al nodo hijo en la posición 1 del nodo padre
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Imprimiendo los parámetros del nodo hijo SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eliminar nodo SmartArt en presentación de PowerPoint usando JavaScript**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si es SmartArt.
5. Verifique si el [SmartArt] tiene más de 0 nodos.
6. Seleccione el nodo SmartArt a eliminar.
7. Ahora, elimine el nodo seleccionado usando el método [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
8. Guarde la presentación.
```javascript
// Cargar la presentación deseada
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar si la forma es del tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accediendo al nodo SmartArt en el índice 0
                var node = smart.getAllNodes().get_Item(0);
                // Eliminando el nodo seleccionado
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Guardar la presentación
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eliminar nodo SmartArt en posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la primera diapositiva usando su índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si es SmartArt.
5. Seleccione el nodo de la forma SmartArt en el índice 0.
6. Ahora, verifique si el nodo SmartArt seleccionado tiene más de 2 nodos hijo.
7. Ahora, elimine el nodo en la **Posición 1** usando el método [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
8. Guarde la presentación.
```javascript
// Cargar la presentación deseada
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar si la forma es del tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Convertir la forma a SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accediendo al nodo SmartArt en el índice 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Eliminando el nodo hijo en la posición 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Guardar la presentación
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer posición personalizada para el nodo hijo en SmartArt**
Ahora Aspose.Slides for Node.js via Java admite la configuración de las propiedades [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) **X** y **Y**. El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizados de SmartArtShape; tenga en cuenta que agregar nuevos nodos provoca un recálculo de las posiciones y tamaños de todos los nodos. Además, con la configuración de posición personalizada, el usuario puede establecer los nodos según sus requisitos.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Mover la forma SmartArt a una nueva posición
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Cambiar los anchos de la forma SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Cambiar la altura de la forma SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Cambiar la rotación de la forma SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Verificar nodo Asistente**
{{% alert color="primary" %}} 

En este artículo investigaremos más a fondo las características de las formas SmartArt añadidas en diapositivas de presentación de forma programática usando Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Usaremos la siguiente forma SmartArt de origen para nuestra investigación en diferentes secciones de este artículo.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origen en la diapositiva**|

En el siguiente código de ejemplo investigaremos cómo identificar **Assistant Nodes** en la colección de nodos SmartArt y modificarlos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) y cargue la presentación con la forma SmartArt.
2. Obtenga la referencia de la segunda diapositiva usando su índice.
3. Recorra cada forma dentro de la primera diapositiva.
4. Verifique si la forma es del tipo [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) y convierta la forma seleccionada a [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si es SmartArt.
5. Recorra todos los nodos dentro de la forma SmartArt y verifique si son [**Assistant Nodes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
6. Cambie el estado del Assistant Node a nodo normal.
7. Guarde la presentación.
```javascript
// Crear una instancia de presentación
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Recorrer cada forma dentro de la primera diapositiva
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Verificar si la forma es de tipo SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forma a SmartArt
            var smart = shape;
            // Recorrer todos los nodos de la forma SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Verificar si el nodo es un nodo Asistente
                if (node.isAssistant()) {
                    // Establecer el nodo Asistente a false y convertirlo en nodo normal
                    node.isAssistant();
                }
            }
        }
    }
    // Guardar la presentación
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodos Asistente modificados en la forma SmartArt dentro de la diapositiva**|

## **Establecer formato de relleno del nodo**
Aspose.Slides for Node.js via Java permite agregar formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for Node.js via Java.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Obtenga la referencia de una diapositiva usando su índice.
3. Agregue una forma [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) estableciendo su [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
4. Establezca el [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) para los nodos de la forma SmartArt.
5. Guarde la presentación modificada como un archivo PPTX.
```javascript
// Instanciar la presentación
var pres = new aspose.slides.Presentation();
try {
    // Accediendo a la diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Agregar forma SmartArt y nodos
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Configurar el color de relleno del nodo
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Guardar la presentación
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Generar miniatura del nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
2. Agregue SmartArt.
3. Obtenga la referencia de un nodo usando su índice.
4. Obtenga la imagen miniatura.
5. Guarde la imagen miniatura en cualquier formato de imagen deseado.
```javascript
// Instanciar la clase Presentation que representa el archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Agregar SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Obtener la referencia de un nodo usando su índice
    var node = smart.getNodes().get_Item(1);
    // Obtener miniatura
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Guardar miniatura
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma normal, por lo que puede [aplicar animaciones estándar](/slides/es/nodejs-java/shape-animation/) (entrada, salida, énfasis, trayectorias de movimiento) y ajustar la sincronización. También puede animar formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [texto alternativo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/). Establecer un AltText distintivo en el SmartArt le permite encontrarlo sin depender de los identificadores internos.

**¿Se preservará la apariencia del SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/), preservando el diseño, los colores y los efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos raster](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) o a [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) para salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.