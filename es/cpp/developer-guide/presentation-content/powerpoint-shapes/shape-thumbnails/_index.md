---
title: Crear miniaturas de formas de presentación en C++
linktitle: Miniaturas de formas
type: docs
weight: 70
url: /es/cpp/shape-thumbnails/
keywords:
- miniatura de forma
- imagen de forma
- renderizar forma
- renderizado de forma
- límites visuales
- límites de forma
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Genera miniaturas de forma de alta calidad a partir de diapositivas de PowerPoint con Aspose.Slides para C++ – crea y exporta fácilmente miniaturas de presentaciones."
---
## **Introducción**

Aspose.Slides se utiliza para crear archivos de presentación donde cada página es una diapositiva. Estas diapositivas pueden verse abriendo los archivos de presentación con Microsoft PowerPoint. Pero a veces, los desarrolladores pueden necesitar ver las imágenes de las formas por separado en un visor de imágenes. En esos casos, Aspose.Slides le ayuda a generar imágenes en miniatura de las formas de la diapositiva. Cómo usar esta función se describe en este artículo.  
Este artículo explica cómo generar miniaturas de diapositivas de diferentes maneras:

- Generar una miniatura de forma dentro de una diapositiva.  
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.  
- Generar una miniatura de forma dentro de los límites de la apariencia de una forma.

## **Generar una miniatura de forma a partir de una diapositiva**
Para generar una miniatura de forma a partir de cualquier diapositiva utilizando Aspose.Slides para C++:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).  
2. Obtener la referencia de cualquier diapositiva mediante su ID o índice.  
3. Obtener la imagen en miniatura de la forma de la diapositiva referenciada con la escala predeterminada.  
4. Guardar la imagen en miniatura en el formato de imagen deseado.

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
Para generar la miniatura de forma de cualquier forma de diapositiva utilizando Aspose.Slides para C++:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).  
2. Obtener la referencia de cualquier diapositiva mediante su ID o índice.  
3. Obtener la imagen en miniatura de la diapositiva referenciada con los límites de la forma.  
4. Guardar la imagen en miniatura en el formato de imagen deseado.

El ejemplo a continuación genera una miniatura con un factor de escala definido por el usuario.

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

## **Crear una miniatura de forma basada en los límites de la apariencia**
Este método para crear miniaturas de formas permite a los desarrolladores generar una miniatura dentro de los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está limitada por los límites de la diapositiva. Para generar una miniatura de cualquier forma de diapositiva dentro de los límites de su apariencia, utilice el siguiente código de ejemplo:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).  
2. Obtener la referencia de cualquier diapositiva mediante su ID o índice.  
3. Obtener la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.  
4. Guardar la imagen en miniatura en el formato de imagen deseado.

El ejemplo a continuación crea una miniatura con un factor de escala definido por el usuario.

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

## **Obtener los límites visuales reales de una forma**

Las propiedades del marco de [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` y `IShape::get_Height()`—describen el rectángulo almacenado en el modelo de la presentación. El contenido que realmente se renderiza puede extenderse más allá de ese marco o ocupar un rectángulo alineado con los ejes diferente. La rotación, los contornos, las puntas de flecha, la disposición y desbordamiento del texto, la geometría generada de SmartArt y otros efectos de renderizado pueden cambiar el área ocupada.

Utilice [Shape::GetVisualBounds](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getvisualbounds/) para calcular esa área ocupada sin crear una imagen. El método devuelve un [RectangleF](https://reference.aspose.com/slides/es/cpp/system.drawing/rectanglef/) en coordenadas de diapositiva. El rectángulo devuelto no está recortado a la diapositiva, por lo que sus coordenadas pueden ser negativas cuando el contenido se extiende más allá del origen de la diapositiva.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getvisualbounds/) no está declarado actualmente en la interfaz [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/). Por lo tanto, mantenga la forma obtenida de la colección de formas de la diapositiva como un valor de interfaz y realice el casting solo al llamar al método.

El siguiente ejemplo obtiene y compara los límites del marco y los límites visuales:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

El mismo [RectangleF](https://reference.aspose.com/slides/es/cpp/system.drawing/rectanglef/) puede usarse para alinear formas cercanas a su borde `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` o `RectangleF::get_Bottom()`; reservar suficiente espacio en un diseño generado; o detectar contenido fuera de una región permitida. Los límites visuales son especialmente útiles para SmartArt, cuadros de texto, flechas, imágenes, formas rotadas y formas de grupo, donde el marco almacenado puede no representar el resultado renderizado completo.

Utilice [Shape::GetVisualBounds](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getvisualbounds/) cuando necesite coordenadas para diseño o validación y no precise un mapa de bits. Utilice [IShape::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/getimage/) cuando necesite renderizar la forma. Con [ShapeThumbnailBounds](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensiona la imagen a partir de los límites de la forma, incluidos los ajustes de contorno, mientras que `ShapeThumbnailBounds::Appearance` la dimensiona a partir de la apariencia de la forma y restringe el resultado a los límites de la diapositiva. En cambio, [Shape::GetVisualBounds](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getvisualbounds/) solo devuelve el rectángulo calculado y no lo recorta a la diapositiva.

## **FAQ**

**¿Qué formatos de imagen se pueden usar al guardar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/), y otros. Las formas también pueden [exportarse como SVG vectorial](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/writeassvg/) guardando el contenido de la forma como SVG.

**¿Cuál es la diferencia entre los límites de Forma y de Apariencia al renderizar una miniatura?**

`Shape` utiliza la geometría de la forma; `Appearance` tiene en cuenta los [efectos visuales](/slides/es/cpp/shape-effect/) (sombras, brillos, etc.).

**¿Qué ocurre si una forma está marcada como oculta? ¿Se seguirá generando su miniatura?**

Una forma oculta sigue formando parte del modelo y puede renderizarse; la bandera de oculto afecta la visualización en la presentación pero no impide generar la imagen de la forma.

**¿Se admiten formas de grupo, gráficos, SmartArt y otros objetos complejos?**

Sí. Cualquier objeto representado como [Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/) (incluidos [GroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chart/) y [SmartArt](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartart/)) puede guardarse como miniatura o como SVG.

**¿Los fuentes instaladas en el sistema afectan la calidad de las miniaturas de formas de texto?**

Sí. Debe [proporcionar las fuentes requeridas](/slides/es/cpp/custom-font/) (o [configurar sustituciones de fuentes](/slides/es/cpp/font-substitution/)) para evitar sustituciones no deseadas y reflujo de texto.