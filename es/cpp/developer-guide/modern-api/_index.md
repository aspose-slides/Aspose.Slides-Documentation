---
title: Mejorar el procesamiento de imágenes con la API moderna
linktitle: API moderna
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
- añadir imagen
- añadir foto
- C++
- Aspose.Slides
description: "Moderniza el procesamiento de imágenes de diapositivas reemplazando las API de imágenes obsoletas por la API Moderna de C++ para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

Actualmente, la biblioteca Aspose.Slides para C++ tiene dependencias en su API pública en las siguientes clases de System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/es/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/es/cpp/system.drawing/bitmap/)

A partir de la versión 24.4, esta API pública se declara obsoleta.

Para eliminar las dependencias de System::Drawing en la API pública, añadimos la llamada “API moderna”. Los métodos con [System::Drawing::Image](https://reference.aspose.com/slides/es/cpp/system.drawing/image/) y [System::Drawing::Bitmap](https://reference.aspose.com/slides/es/cpp/system.drawing/bitmap/) se declaran obsoletos y deben sustituirse por los métodos correspondientes de la API moderna. Los métodos con [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/) se declaran obsoletos y no tienen un reemplazo directo en la API moderna.

En versiones actuales, trate la API pública que depende de tipos System::Drawing como heredada/obsoleta. Utilice la API moderna para código nuevo y al migrar flujos de trabajo de procesamiento de imágenes existentes.

## **API moderna**

Se añadieron las siguientes clases y enumeraciones a la API pública:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) – representa la imagen raster o vectorial.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/) – representa el formato de archivo de la imagen.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/es/cpp/aspose.slides/images/) – métodos para instanciar y trabajar con la interfaz [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/).

Utilice `GetImage` para renderizar una sola diapositiva o forma. Utilice `GetImages` para renderizar varias diapositivas de la presentación. Use los métodos de [Images](https://reference.aspose.com/slides/es/cpp/aspose.slides/images/) para cargar imágenes, `AddImage` con [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) para añadirlas a una presentación y `ReplaceImage` con [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) para actualizar una imagen existente de la presentación.

Un escenario típico de uso de la nueva API puede ser el siguiente:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// Instanciar una instancia desechable de IImage desde el archivo en disco.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// Crear una imagen de PowerPoint añadiendo una instancia de IImage a las imágenes de la presentación.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// Añadir una forma de imagen en la diapositiva #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// Obtener una instancia de IImage que representa la diapositiva #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// Guardar la imagen en el disco.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Reemplazando código antiguo con la API moderna**

Para facilitar la transición, la interfaz del nuevo [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) repite las distintas firmas de las clases [System::Drawing::Image](https://reference.aspose.com/slides/es/cpp/system.drawing/image/) y [System::Drawing::Bitmap](https://reference.aspose.com/slides/es/cpp/system.drawing/bitmap/). En general, solo tendrá que sustituir la llamada al método antiguo que usa System::Drawing por la nueva.

### **Obtener una miniatura de diapositiva**

API heredada/depreciada:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Obtener una miniatura de forma**

API heredada/depreciada:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Obtener una miniatura de presentación**

API heredada/depreciada:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Añadir una imagen a una presentación**

API heredada/depreciada:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API moderna:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Métodos/Propiedades obsoletos y su reemplazo en la API moderna**

### **Clase Presentation**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Clase Slide**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Clase Shape**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Clase ImageCollection**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Clase PPImage**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Clase PatternFormat**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Clase IPatternFormatEffectiveData**
|Firma del método|Firma del método de reemplazo|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Compatibilidad de la API para System::Drawing::Graphics**

Los métodos con [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/) se declaran obsoletos y no tienen un reemplazo directo en la API moderna.

Utilice los métodos de renderizado de imágenes de la API moderna en lugar de la API que renderiza a [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **Preguntas frecuentes**

**¿Por qué se eliminó [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/)?**

El soporte para [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/) está obsoleto en la API pública para unificar el trabajo con renderizado e imágenes, eliminar dependencias específicas de la plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/). Utilice `GetImage` o `GetImages` en lugar de renderizar a [System::Drawing::Graphics](https://reference.aspose.com/slides/es/cpp/system.drawing/graphics/).

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) frente a [System::Drawing::Image](https://reference.aspose.com/slides/es/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/es/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales, simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/), reduce la dependencia de `System::Drawing` y hace que el código sea más portátil entre entornos.

**¿Afectará la API moderna al rendimiento de la generación de miniaturas?**

Cambiar de `GetThumbnail` a `GetImage` no empeora los escenarios: los nuevos métodos ofrecen las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.