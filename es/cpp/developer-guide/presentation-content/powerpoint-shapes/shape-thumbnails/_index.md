---
title: Miniaturas de Formas
type: docs
weight: 70
url: /cpp/shape-thumbnails/
keywords: 
- miniatura de forma
- imagen de forma
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: "Extraer miniaturas de formas de presentaciones de PowerPoint en C++"
---


## **Crear Miniatura de Forma**
Aspose.Slides para C++ se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas se pueden ver abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En tales casos, Aspose.Slides para C++ te ayuda a generar imágenes de miniaturas de las formas de la diapositiva. Cómo utilizar esta función se describe en este artículo.
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generando una miniatura de forma dentro de una diapositiva.
- Generando una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generando una miniatura de forma dentro de los límites de la apariencia de una forma.
- Generando una miniatura de un nodo hijo de SmartArt.

## **Generar Miniatura de Forma desde Diapositiva**
Para generar una miniatura de forma desde cualquier diapositiva usando Aspose.Slides para C++:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) clase.
1. Obtén la referencia de cualquier diapositiva usando su ID o índice.
1. Obtén la imagen de miniatura de la forma de la diapositiva referenciada en la escala predeterminada.
1. Guarda la imagen de miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura de forma.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Generar Miniatura con Factor de Escalado Definido por el Usuario**
Para generar la miniatura de forma de cualquier forma de diapositiva usando Aspose.Slides para C++:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) clase.
1. Obtén la referencia de cualquier diapositiva usando su ID o índice.
1. Obtén la imagen de miniatura de la diapositiva referenciada con los límites de la forma.
1. Guarda la imagen de miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura con un factor de escalado definido por el usuario.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Escalado a lo largo de los ejes X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Crear Miniatura de la Apariencia de los Límites de la Forma**
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, utiliza el siguiente código de muestra:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) clase.
1. Obtén la referencia de cualquier diapositiva usando su ID o índice.
1. Obtén la imagen de miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarda la imagen de miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación crea una miniatura generando una miniatura con un factor de escalado definido por el usuario.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Escalado a lo largo de los ejes X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```