---
title: Crear miniaturas de formas de presentación en C++
linktitle: Miniaturas de Forma
type: docs
weight: 70
url: /es/cpp/shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Genera miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides para C++ – crea y exporta fácilmente miniaturas de presentaciones."
---

## **Crear una miniatura de forma**
Aspose.Slides for C++ se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden verse al abrir los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides for C++ le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta función se describe en este artículo.
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.
- Generar una miniatura del nodo hijo de SmartArt.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva usando Aspose.Slides for C++:

1. Crear una instancia de la clase[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtener la referencia de cualquier diapositiva usando su ID o índice.
3. Obtener la imagen en miniatura de la forma de la diapositiva referenciada con la escala predeterminada.
4. Guardar la imagen en miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura de forma.
```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Generar una miniatura con factor de escala definido por el usuario**
Para generar la miniatura de forma de cualquier forma de diapositiva usando Aspose.Slides for C++:

1. Crear una instancia de la clase[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtener la referencia de cualquier diapositiva usando su ID o índice.
3. Obtener la imagen en miniatura de la diapositiva referenciada con los límites de la forma.
4. Guardar la imagen en miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura con un factor de escala definido por el usuario.
```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Escalado en los ejes X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Crear una miniatura de apariencia de forma basada en límites**
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, utilice el siguiente código de ejemplo:

1. Crear una instancia de la clase[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtener la referencia de cualquier diapositiva usando su ID o índice.
3. Obtener la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
4. Guardar la imagen en miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación crea una miniatura.
```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Escalado en los ejes X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Preguntas frecuentes**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites Shape y Appearance al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/cpp/shape-effect/) (sombras, resplandores, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá renderizando como miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera oculta afecta la visualización de la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas agrupadas, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/) y [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) puede guardarse como miniatura o como SVG.

**¿Afectan las fuentes instaladas en el sistema a la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes necesarias](/slides/es/cpp/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/cpp/font-substitution/)) para evitar sustituciones no deseadas y el reajuste de texto.