---
title: Gestionar objetos de tinta de presentación en Java
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/java/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- gestionar tinta
- dibujar tinta
- dibujo
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Gestiona objetos de tinta de PowerPoint—crea, edita y aplica estilo a la tinta digital con Aspose.Slides para Java. Obtén ejemplos de código para trazos, color y tamaño del pincel."
---

PowerPoint ofrece la función de tinta para permitirle dibujar figuras no estándar, que pueden usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.  

Aspose.Slides proporciona todos los tipos de tinta (p. ej., la clase [Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/)) que necesita para crear y gestionar objetos de tinta.  

## **Diferencias entre objetos regulares y objetos de tinta**

Los objetos en una diapositiva de PowerPoint suelen representarse mediante objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del propio objeto (su marco) junto con sus propiedades. Estas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para más información, consulte [Shape Layout Format](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata con un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los valores estándar `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de Inkshape**

Un trazo es un elemento básico o estándar utilizado para registrar la trayectoria de un lápiz mientras un usuario escribe tinta digital. Los trazos son grabaciones que describen secuencias de puntos conectados.  

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Puede usar un pincel para dibujar líneas que conecten los puntos de los elementos del trazo. El pincel tiene su propio color y tamaño, que corresponden a las propiedades `Brush.Color` y `Brush.Size`.  

### **Establecer color del pincel de tinta**

Este código Java le muestra cómo establecer el color para un pincel:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Establecer tamaño del pincel de tinta** 

Este código Java le muestra cómo establecer el tamaño para un pincel:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```


En general, el ancho y el alto de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos aparece atenuada). Pero cuando el ancho y el alto del pincel coinciden, PowerPoint muestra su tamaño de la siguiente manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la última imagen).  

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de trazo. Aquí, el objeto objetivo (el objeto de trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel permanece constante y viceversa.  

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint muestra el mismo comportamiento al trabajar con textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/java/powerpoint-shapes/).  
* Para obtener más información sobre valores efectivos, vea [Shape Effective Properties](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value).