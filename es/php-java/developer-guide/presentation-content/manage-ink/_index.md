---
title: Administrar Tinta
type: docs
weight: 95
url: /php-java/manage-ink/
keywords: "Tinta en PowerPoint, herramientas de tinta, Java Ink, Dibujar en PowerPoint, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Utiliza herramientas de tinta para dibujar objetos en PowerPoint Java"
---

PowerPoint proporciona la función de tinta para permitirte dibujar figuras no estándar, que pueden ser utilizadas para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.

Aspose.Slides proporciona todos los tipos de Tinta (por ejemplo, [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/) clase) que necesitas para crear y gestionar objetos de tinta.

## **Diferencias entre Objetos Regulares y Objetos de Tinta**

Los objetos en una diapositiva de PowerPoint se representan típicamente mediante objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del objeto en sí (su marco) junto con sus propiedades. Estas últimas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para más información, consulta [Formato de Diseño de Forma](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata con un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor está determinado por los valores estándar de `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastros de Forma de Tinta**

Un rastro es un elemento básico o estándar utilizado para registrar la trayectoria de un bolígrafo mientras un usuario escribe tinta digital. Los rastros son grabaciones que describen secuencias de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando todos los puntos conectados se representan, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## Propiedades del Pincel para Dibujar 

Puedes usar un pincel para dibujar líneas que conectan los puntos de los elementos de rastro. El pincel tiene su propio color y tamaño, correspondientes a las propiedades `Brush.Color` y `Brush.Size`.

### **Establecer el Color del Pincel de Tinta**

Este código PHP te muestra cómo establecer el color de un pincel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Establecer el Tamaño del Pincel de Tinta** 

Este código PHP te muestra cómo establecer el tamaño de un pincel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la última imagen).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de rastro. Aquí, el objeto objetivo (el objeto de trazo de texto manuscrito) ha sido escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel se mantiene constante y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint exhibe el mismo comportamiento al tratar con textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lectura adicional**

* Para leer sobre formas en general, consulta la sección [Formas de PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* Para más información sobre valores efectivos, consulta [Propiedades Efectivas de Forma](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).