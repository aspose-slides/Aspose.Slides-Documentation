---
title: Administrar objetos de tinta de presentación en C++
linktitle: Administrar tinta
type: docs
weight: 95
url: /es/cpp/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- administrar tinta
- dibujar tinta
- dibujo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Administre los objetos de tinta de PowerPoint: cree, edite y dé estilo a la tinta digital con Aspose.Slides para C++. Obtenga ejemplos de código para trazos, color y tamaño del pincel."
---

PowerPoint proporciona la función de tinta para permitirle dibujar figuras no estándar, que pueden usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva. 

Aspose.Slides proporciona la interfaz [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/), que contiene los tipos que necesita para crear y gestionar objetos de tinta. 

## **Diferencias entre Objetos Regulares y Objetos de Tinta**

Los objetos en una diapositiva de PowerPoint suelen representarse mediante objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del propio objeto (su marco) junto con sus propiedades. Estas últimas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para obtener información, consulte [Formato de diseño de forma](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata con un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los valores estándar `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de Inkshape**

Un trazo es un elemento básico o estándar utilizado para registrar la trayectoria de un lápiz mientras un usuario escribe tinta digital. Los trazos son grabaciones que describen secuencias de puntos conectados. 

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Puede usar un pincel para dibujar líneas que conecten los puntos de los elementos de trazo. El pincel tiene su propio color y tamaño, que corresponden a las propiedades `Brush.Color` y `Brush.Size`. 

### **Establecer color del pincel de tinta**

Este código C++ le muestra cómo establecer el color de un pincel:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **Establecer tamaño del pincel de tinta** 

Este código C++ le muestra cómo establecer el tamaño de un pincel:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de la siguiente manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (vea la última imagen). 

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de trazo. Aquí, el objeto objetivo (el objeto de trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel permanece constante y viceversa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint muestra el mismo comportamiento al tratar con textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [Formas de PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-shapes/). 
* Para obtener más información sobre valores efectivos, consulte [Propiedades efectivas de forma](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).