---
title: Mejorar el procesamiento de imágenes con la API Moderna
linktitle: API Moderna
type: docs
weight: 280
url: /es/cpp/modern-api/
keywords:
- System.Drawing
- API moderna
- dibujo
- miniatura de diapositiva
- diapositiva a imagen
- miniatura de forma
- forma a imagen
- miniatura de presentación
- presentación a imágenes
- agregar imagen
- agregar foto
- C++
- Aspose.Slides
description: "Modernice el procesamiento de imágenes de diapositivas reemplazando las API de imágenes obsoletas con la API Moderna de C++ para una automatización fluida de PowerPoint y OpenDocument."
---

## **Introducción**

Actualmente, la biblioteca Aspose.Slides para C++ tiene dependencias en su API pública en las siguientes clases de System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Para eliminar las dependencias de System::Drawing en la API pública, agregamos la llamada “Modern API”. Los métodos con System::Drawing::Image y System::Drawing::Bitmap se declaran obsoletos y serán reemplazados por los métodos correspondientes de la Modern API. Los métodos con System::Graphics se declaran obsoletos y su soporte será eliminado de la API pública.

La eliminación de la API pública obsoleta con dependencias en System::Drawing será en la versión 24.8.

## **API Moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- Aspose::Slides::IImage - representa la imagen raster o vectorial.
- Aspose::Slides::ImageFormat - representa el formato de archivo de la imagen.
- Aspose::Slides::Images - métodos para instanciar y trabajar con la interfaz IImage.

Un escenario típico de uso de la nueva API puede verse como sigue:
```cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instanciar una instancia descartable de IImage desde el archivo en el disco.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// añadir una forma de imagen en la diapositiva #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// obtener una instancia de IImage que representa la diapositiva #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// guardar la imagen en el disco.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```


## **Reemplazar Código Antiguo con la API Moderna**

Para facilitar la transición, la interfaz del nuevo IImage repite las firmas separadas de las clases Image y Bitmap. En general, sólo necesitará reemplazar la llamada al método antiguo que utiliza System::Drawing por la nueva.

### **Obtener la Miniatura de una Diapositiva**

Código que usa una API obsoleta:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```


API Moderna:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```


### **Obtener la Miniatura de una Forma**

Código que usa una API obsoleta:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```


API Moderna:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```


### **Obtener la Miniatura de una Presentación**

Código que usa una API obsoleta:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```


API Moderna:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```


### **Agregar una Imagen a una Presentación**

Código que usa una API obsoleta:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


API Moderna:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


## **Métodos/Propiedades que serán Eliminados y su Reemplazo en la API Moderna**

### **Presentation Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|Se eliminará completamente|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|Se eliminará completamente|

### **Slide Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|Se eliminará completamente|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|Se eliminará completamente|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|Se eliminará completamente|

### **Shape Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData Class**
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **El Soporte de la API para System::Drawing::Graphics será Descontinuado**

Los métodos con [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) se declaran obsoletos y su soporte será eliminado de la API pública.

La parte de la API que lo usa será eliminada:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **Preguntas Frecuentes**

**¿Por qué se eliminó System::Drawing::Graphics?**

El soporte para `Graphics` se está eliminando de la API pública para unificar el trabajo con renderizado e imágenes, eliminar vínculos con dependencias específicas de la plataforma y cambiar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). Todos los métodos de renderizado a `Graphics` serán eliminados.

**¿Cuál es el beneficio práctico de IImage comparado con Image/Bitmap?**

[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales, simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), reduce la dependencia de `System::Drawing` y hace el código más portable entre entornos.

**¿Afectará la API Moderna al rendimiento de la generación de miniaturas?**

Cambiar de `GetThumbnail` a `GetImage` no empeora los escenarios: los nuevos métodos proporcionan las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.