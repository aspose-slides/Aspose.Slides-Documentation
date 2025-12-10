---
title: Gestionar objetos de tinta de presentación en .NET
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/net/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- gestionar tinta
- dibujar tinta
- dibujo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona los objetos de tinta de PowerPoint—crea, edita y da estilo a la tinta digital con Aspose.Slides para .NET. Obtén ejemplos de código para trazos, color y tamaño del pincel."
---

PowerPoint proporciona la función de tinta para permitirle dibujar figuras no estándar, que pueden usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva. 

Aspose.Slides proporciona la interfaz [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/), que contiene los tipos que necesita para crear y gestionar objetos de tinta. 

## **Diferencias entre objetos regulares y objetos de tinta**

Los objetos en una diapositiva de PowerPoint se representan típicamente como objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del propio objeto (su marco) junto con sus propiedades. Estas últimas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para obtener información, consulte [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina por los valores estándar `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de Inkshape**

Un trazo es un elemento básico o estándar usado para registrar la trayectoria de un lápiz mientras un usuario escribe tinta digital. Los trazos son grabaciones que describen secuencias de puntos conectados. 

La forma más simple de codificación especifica las coordenadas X y Y de cada punto de muestra. Cuando todos los puntos conectados se representan, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Puede usar un pincel para dibujar líneas que conecten los puntos de los elementos de trazo. El pincel tiene su propio color y tamaño, que corresponden a las propiedades `Brush.Color` y `Brush.Size`. 

### **Establecer color del pincel de tinta**

Este código C# le muestra cómo establecer el color para un pincel:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```


### **Establecer tamaño del pincel de tinta** 

Este código C# le muestra cómo establecer el tamaño para un pincel:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```


En general, el ancho y alto de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y alto del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la última imagen). 

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de trazo. Aquí, el objeto objetivo (el objeto de trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel permanece constante y viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint muestra el mismo comportamiento al manejar textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lecturas adicionales**

* Para leer sobre las formas en general, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/). 
* Para obtener más información sobre valores efectivos, vea [Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).