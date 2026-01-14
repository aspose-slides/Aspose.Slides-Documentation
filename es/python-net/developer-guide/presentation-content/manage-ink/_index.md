---
title: Gestionar objetos de tinta en presentaciones con Python
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/python-net/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- gestionar tinta
- dibujar tinta
- dibujo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestionar objetos de tinta de PowerPoint—crear, editar y dar estilo a la tinta digital con Aspose.Slides para Python mediante .NET. Obtén ejemplos de código para trazos, color y tamaño del pincel."
---

PowerPoint proporciona la función de tinta para permitirle dibujar figuras no estándar, que pueden usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva. 

Aspose.Slides proporciona el espacio de nombres [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) , que contiene los tipos que necesita para crear y gestionar objetos de tinta. 

## **Diferencias entre objetos regulares y objetos de tinta**

Los objetos en una diapositiva de PowerPoint suelen estar representados por objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del propio objeto (su marco) junto con sus propiedades. Estas últimas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para información, vea [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata con un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los valores estándar `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de Inkshape**

El trazo es un elemento básico o estándar usado para registrar la trayectoria de un lápiz mientras un usuario escribe tinta digital. Los trazos son grabaciones que describen secuencias de puntos conectados. 

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## Propiedades del pincel para dibujar 

Puede usar un pincel para dibujar líneas que conecten los puntos de los elementos de trazo. El pincel tiene su propio color y tamaño, correspondientes a las propiedades `Brush.color` y `Brush.size`. 

### **Establecer color del pincel de tinta**

Este código Python le muestra cómo establecer el color para un pincel:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```


### **Establecer tamaño del pincel de tinta** 

Este código Python le muestra cómo establecer el tamaño para un pincel:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```


En general, el ancho y el alto de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y el alto del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, incrementemos la altura del objeto de tinta y revisemos las dimensiones importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles: siempre asume que el grosor de la línea es cero (ver la última imagen). 

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de trazo. Aquí, el objeto objetivo (el objeto de trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel permanece constante y viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint muestra el mismo comportamiento al tratar con textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lectura adicional**

* Para leer sobre formas en general, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/) . 
* Para más información sobre valores efectivos, vea [Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value).