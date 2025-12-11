---
title: Crear un visor de presentaciones en C++
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/cpp/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Crear un visor de presentaciones personalizado en C++ usando Aspose.Slides. Visualice fácilmente archivos PowerPoint y OpenDocument sin Microsoft PowerPoint."
---

Aspose.Slides for C++ se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, a veces los desarrolladores pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o crear su propio visor de presentaciones. En esos casos, Aspose.Slides le permite exportar una diapositiva individual como imagen. Este artículo describe cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de presentación con Aspose.Slides, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de la diapositiva por su índice.
1. Abrir un flujo de archivo.
1. Guardar la diapositiva como una imagen SVG en el flujo de archivo.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **Generar un SVG con un ID de forma personalizado**

Aspose.Slides puede usarse para generar un [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de una diapositiva con un ID de forma personalizado. Para ello, use el método `set_Id` de [ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` puede usarse para establecer el ID de la forma.
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **Crear una imagen miniatura de una diapositiva**

Aspose.Slides le ayuda a generar imágenes miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de la diapositiva por su índice.
1. Obtener la imagen miniatura de la diapositiva referenciada con una escala definida.
1. Guardar la imagen miniatura en cualquier formato de imagen deseado.
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de la diapositiva por su índice.
1. Obtener la imagen miniatura de la diapositiva referenciada con las dimensiones definidas.
1. Guardar la imagen miniatura en cualquier formato de imagen deseado.
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Crear una miniatura de diapositiva con notas del orador**

Para generar la miniatura de una diapositiva con notas del orador usando Aspose.Slides, siga los pasos a continuación:

1. Crear una instancia de la clase [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/).
1. Utilice el método `RenderingOptions.set_SlidesLayoutOptions` para establecer la posición de las notas del orador.
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener la referencia de la diapositiva por su índice.
1. Obtener la imagen miniatura de la diapositiva referenciada con las opciones de renderizado.
1. Guardar la imagen miniatura en cualquier formato de imagen deseado.
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Ejemplo en vivo**

Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web?**

Sí. Puede usar Aspose.Slides del lado del servidor para renderizar diapositivas como imágenes o HTML y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor forma de mostrar diapositivas dentro de un visor personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una imagen (p. ej., PNG o SVG) o convertirla a HTML usando Aspose.Slides, y luego mostrar la salida dentro de un cuadro de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga diferida o el renderizado bajo demanda de las diapositivas. Esto implica generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo la memoria y el tiempo de carga.