---
title: Gestionar Tinta
type: docs
weight: 95
url: /es/net/manage-ink/
keywords: "Tinta en PowerPoint, herramientas de tinta, C# Tinta, Dibujar en PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET "
description: "Use herramientas de tinta para dibujar objetos en PowerPoint C#"
---

PowerPoint proporciona la función de tinta para permitirte dibujar figuras no estándar, que se pueden usar para resaltar otros objetos, mostrar conexiones y procesos, y atraer la atención a elementos específicos en una diapositiva.

Aspose.Slides proporciona la interfaz [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/), que contiene los tipos que necesitas para crear y gestionar objetos de tinta.

## **Diferencias entre Objetos Regulares y Objetos de Tinta**

Los objetos en una diapositiva de PowerPoint suelen estar representados por objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del objeto en sí (su marco) junto con sus propiedades. Estas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para más información, consulta [Formato de Diseño de Forma](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata con un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina por los valores estándar de `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastros de Tinta**

Un rastro es un elemento básico o estándar utilizado para registrar la trayectoria de un bolígrafo a medida que un usuario escribe tinta digital. Los rastros son grabaciones que describen secuencias de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se representan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## Propiedades del Pincel para Dibujar

Puedes utilizar un pincel para dibujar líneas que conectan los puntos de los elementos de rastro. El pincel tiene su propio color y tamaño, correspondientes a las propiedades `Brush.Color` y `Brush.Size`.

### **Establecer Color del Pincel de Tinta**

Este código C# te muestra cómo establecer el color para un pincel:

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

### **Establecer Tamaño del Pincel de Tinta**

Este código C# te muestra cómo establecer el tamaño para un pincel:

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

Generalmente, el ancho y alto de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y el alto del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la última imagen).

Por lo tanto, para determinar el área visible del objeto de tinta completo, debemos considerar el tamaño del pincel de los objetos de rastro. Aquí, el objeto objetivo (el objeto de rastro de texto escrito a mano) ha sido escalado al tamaño del contenedor (marco). Cuando cambia el tamaño del contenedor (marco), el tamaño del pincel permanece constante y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint exhibe el mismo comportamiento al tratar con textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lectura adicional**

* Para leer sobre formas en general, consulta la sección [Formas de PowerPoint](https://docs.aspose.com/slides/net/powerpoint-shapes/).
* Para más información sobre valores efectivos, consulta [Propiedades Efectivas de Forma](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value). 
