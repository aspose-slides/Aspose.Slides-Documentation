---
title: Administrar Tinta
type: docs
weight: 95
url: /cpp/manage-ink/
keywords: "Tinta en PowerPoint, herramientas de tinta, C++ Tinta, Dibujar en PowerPoint, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Utiliza herramientas de tinta para dibujar objetos en PowerPoint C++"
---

PowerPoint proporciona la función de tinta para permitirte dibujar figuras no estándar, que se pueden usar para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.

Aspose.Slides proporciona la interfaz [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/), que contiene los tipos que necesitas para crear y administrar objetos de tinta.

## **Diferencias entre Objetos Regulares y Objetos de Tinta**

Los objetos en una diapositiva de PowerPoint generalmente están representados por objetos de forma. Un objeto de forma, en su forma más simple, es un contenedor que define el área del objeto en sí (su marco) junto con sus propiedades. Estas últimas incluyen el tamaño del área del contenedor, la forma del contenedor, el fondo del contenedor, etc. Para más información, consulta [Formato de Diseño de Forma](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata con un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor está determinado por los valores estándar de `width` y `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastros de Formas de Tinta**

El rastro es un elemento básico o estándar utilizado para registrar la trayectoria de un lápiz a medida que un usuario escribe tinta digital. Los rastros son grabaciones que describen secuencias de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## Propiedades del Pincel para Dibujar

Puedes usar un pincel para dibujar líneas que conecten los puntos de elementos de trazo. El pincel tiene su propio color y tamaño, correspondientes a las propiedades `Brush.Color` y `Brush.Size`.

### **Establecer el Color del Pincel de Tinta**

Este código C++ te muestra cómo establecer el color de un pincel:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Establecer el Tamaño del Pincel de Tinta** 

Este código C++ te muestra cómo establecer el tamaño de un pincel:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Generalmente, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos está atenuada). Pero cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no considera el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la última imagen).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, debemos considerar el tamaño del pincel de los objetos de trazo. Aquí, el objeto objetivo (el objeto de trazo de texto manuscrito) ha sido escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor (marco) cambia, el tamaño del pincel permanece constante y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint presenta el mismo comportamiento al manejar textos:

![ink_powerpoint6](ink_powerpoint6.png)

**Lectura adicional**

* Para leer sobre formas en general, consulta la sección [Formas de PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-shapes/).
* Para más información sobre valores efectivos, consulta [Propiedades Efectivas de Forma](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).