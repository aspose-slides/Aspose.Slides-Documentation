---
title: Administrar objetos de tinta de presentación en Android
linktitle: Administrar tinta
type: docs
weight: 95
url: /es/androidjava/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- gestionar tinta
- dibujar tinta
- dibujo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Administre los objetos de tinta de PowerPoint—crea, edita y da estilo a la tinta digital con Aspose.Slides para Android. Obtenga ejemplos de código Java para trazos, color y tamaño del pincel."
---

PowerPoint ofrece la función de tinta para permitirle dibujar figuras no estándar, que pueden usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva. 

Aspose.Slides proporciona todos los tipos de Ink (p. ej., [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) clase) que necesita para crear y administrar objetos de tinta.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint se representan típicamente mediante objetos shape. Un objeto shape, en su forma más simple, es un contenedor que define el área del propio objeto (su marco) junto con sus propiedades. Estas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para obtener información, consulte [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los valores estándar `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de Inkshape**

Un trazado es un elemento básico o estándar utilizado para registrar la trayectoria de un lápiz mientras un usuario escribe tinta digital. Los trazados son grabaciones que describen secuencias de puntos conectados. 

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Puede usar un pincel para dibujar líneas que conecten los puntos de los elementos de trazado. El pincel tiene su propio color y tamaño, correspondientes a las propiedades `Brush.Color` y `Brush.Size`. 

### **Establecer color del pincel de tinta**

Este código Java muestra cómo establecer el color para un pincel:
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

Este código Java muestra cómo establecer el tamaño para un pincel:
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


En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, incrementemos la altura del objeto de tinta y revisemos las dimensiones importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la última imagen). 

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de trazado. Aquí, el objeto objetivo (el objeto de trazado de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel permanece constante y viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint muestra el mismo comportamiento al manejar textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Para obtener más información sobre valores efectivos, consulte [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).