---
title: Convertir PPT y PPTX a JPG en C++
linktitle: PowerPoint a JPG
type: docs
weight: 60
url: /es/cpp/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a JPG
- presentación a JPG
- diapositiva a JPG
- PPT a JPG
- PPTX a JPG
- guardar PowerPoint como JPG
- guardar presentación como JPG
- guardar diapositiva como JPG
- guardar PPT como JPG
- guardar PPTX como JPG
- exportar PPT a JPG
- exportar PPTX a JPG
- C++
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint (PPT, PPTX) a imágenes JPG de alta calidad en C++ con Aspose.Slides utilizando ejemplos de código rápidos y fiables."
---

## **Visión general**

Convertir presentaciones de PowerPoint y OpenDocument a imágenes JPG ayuda a compartir diapositivas, optimizar el rendimiento e incrustar contenido en sitios web o aplicaciones. Aspose.Slides for C++ le permite transformar archivos PPTX, PPT y ODP en imágenes JPEG de alta calidad. Esta guía explica los diferentes métodos de conversión.

Con estas funciones, es fácil crear su propio visor de presentaciones y generar una miniatura para cada diapositiva. Esto puede ser útil si desea proteger las diapositivas de la copia o demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva específica a formatos de imagen.

## **Convertir diapositivas de presentación a imágenes JPG**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Obtenga el objeto diapositiva del tipo [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) de la colección de diapositivas de la presentación.
3. Cree una imagen de la diapositiva usando el método [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).
4. Llame al método [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) del objeto imagen. Pase el nombre del archivo de salida y el formato de imagen como argumentos.

{{% alert color="primary" %}} 
**Nota:** La conversión de PPT, PPTX o ODP a JPG difiere de la conversión a otros formatos en la API de Aspose.Slides for C++. Para otros formatos, normalmente se utiliza el método [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). Sin embargo, para la conversión a JPG, debe usar el método [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).
{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Crear una imagen de diapositiva con la escala especificada.
    auto image = slide->GetImage(scaleX, scaleY);

    // Guardar la imagen en disco en formato JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Convertir diapositivas a JPG con dimensiones personalizadas**

Para cambiar las dimensiones de las imágenes JPG resultantes, puede establecer el tamaño de la imagen pasándolo al método [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Esto le permite generar imágenes con valores específicos de ancho y alto, garantizando que la salida cumpla con sus requisitos de resolución y relación de aspecto. Esta flexibilidad es particularmente útil al generar imágenes para aplicaciones web, informes o documentación, donde se requieren dimensiones de imagen precisas.
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Crear una imagen de diapositiva del tamaño especificado.
    auto image = slide->GetImage(imageSize);

    // Guardar la imagen en disco en formato JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Renderizar comentarios al guardar diapositivas como imágenes**

Aspose.Slides for C++ ofrece una función que permite renderizar los comentarios en las diapositivas de una presentación al convertirlas en imágenes JPG. Esta funcionalidad es especialmente útil para preservar anotaciones, retroalimentación o discusiones añadidas por colaboradores en presentaciones de PowerPoint. Al habilitar esta opción, garantiza que los comentarios sean visibles en las imágenes generadas, facilitando la revisión y el intercambio de comentarios sin necesidad de abrir el archivo original de la presentación.

Supongamos que tenemos un archivo de presentación, "sample.pptx", con una diapositiva que contiene comentarios:

![La diapositiva con comentarios](slide_with_comments.png)

El siguiente código C++ convierte la diapositiva a una imagen JPG conservando los comentarios:
```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Establecer opciones para los comentarios de la diapositiva.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Convertir la primera diapositiva a una imagen.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```


El resultado:

![La imagen JPG con comentarios](image_with_comments.png)

## **Ver también**

Consulte otras opciones para convertir PPT, PPTX o ODP a imágenes, como:

- [Convertir PowerPoint a GIF](/slides/es/cpp/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint a PNG](/slides/es/cpp/convert-powerpoint-to-png/)
- [Convertir PowerPoint a TIFF](/slides/es/cpp/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint a SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, pruebe estos convertidores en línea gratuitos: PowerPoint [PPTX a JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT a JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}}

![Convertidor gratuito en línea de PPTX a JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [aplicación web GRATUITA Collage](https://products.aspose.app/slides/collage). Con este servicio en línea, puede combinar imágenes [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

Usando los mismos principios descritos en este artículo, puede convertir imágenes de un formato a otro. Para más información, consulte estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Preguntas frecuentes**

**¿Este método admite la conversión por lotes?**

Sí, Aspose.Slides permite la conversión por lotes de múltiples diapositivas a JPG en una sola operación.

**¿La conversión admite SmartArt, gráficos y otros objetos complejos?**

Sí, Aspose.Slides renderiza todo el contenido, incluidos SmartArt, gráficos, tablas, formas y más. Sin embargo, la precisión del renderizado puede variar ligeramente respecto a PowerPoint, sobre todo al usar fuentes personalizadas o faltantes.

**¿Existen limitaciones en la cantidad de diapositivas que se pueden procesar?**

Aspose.Slides en sí no impone límites estrictos al número de diapositivas que puede procesar. No obstante, puede encontrarse con errores de falta de memoria al trabajar con presentaciones muy grandes o imágenes de alta resolución.