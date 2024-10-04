---
title: Marco de Imagen
type: docs
weight: 10
url: /cpp/picture-frame/
keywords: "Agregar marco de imagen, crear marco de imagen, agregar imagen, crear imagen, extraer imagen, propiedad StretchOff, formato de marco de imagen, propiedades de marco de imagen, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Agregar marco de imagen a la presentación de PowerPoint en C++"
---

Un marco de imagen es una forma que contiene una imagen; es como una imagen en un marco.

Puedes agregar una imagen a una diapositiva a través de un marco de imagen. De esta manera, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Crea una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) asociada con el objeto presentación que se utilizará para llenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) basado en el ancho y alto de la imagen a través del método `AddPictureFrame` expuesto por el objeto de forma asociado con la diapositiva referenciada.
6. Agrega un marco de imagen (conteniendo la imagen) a la diapositiva.
7. Escribe la presentación modificada como un archivo PPTX.

Este código C++ muestra cómo crear un marco de imagen:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carga la imagen que se añadirá en la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Agrega una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Agrega un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y altura
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Aplica algún formato al PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Escribe el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Puede que desees ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Crear Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complicado. 

1. Crea una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) asociada con el objeto presentación que se utilizará para llenar la forma.
5. Especifica el ancho y la altura relativa de la imagen en el marco de imagen.
6. Escribe la presentación modificada como un archivo PPTX.

Este código C++ muestra cómo crear un marco de imagen con escala relativa:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carga la imagen que se añadirá en la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Agrega una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Agrega un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y altura
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Escribe el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extraer Imagen del Marco de Imagen**

Puedes extraer imágenes de objetos [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) y guardarlas en formatos PNG, JPG y otros. El ejemplo de código a continuación demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Obtener Transparencia de Imagen**

Aspose.Slides te permite obtener la transparencia de una imagen. Este código C++ demuestra la operación:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Transparencia de la imagen: ") + transparencyValue);
    }
}
```

## **Formato de Marco de Imagen**

Aspose.Slides proporciona muchas opciones de formato que se pueden aplicar a un marco de imagen. Usando esas opciones, puedes alterar un marco de imagen para hacerlo coincidir con requisitos específicos.

1. Crea una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) agregando una imagen a la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) asociada con el objeto presentación que se utilizará para llenar la forma.
4. Especifica el ancho y alto de la imagen.
5. Crea un `PictureFrame` basado en el ancho y alto de la imagen a través del [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) asociado con la diapositiva referenciada.
6. Agrega el marco de imagen (conteniendo la imagen) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen dándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en sentido horario. 
   * Un valor negativo rota la imagen en sentido antihorario.
10. Agrega el marco de imagen (conteniendo la imagen) a la diapositiva.
11. Escribe la presentación modificada como un archivo PPTX.

Este código C++ demuestra el proceso de formateo de un marco de imagen:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Carga la imagen que se añadirá en la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Agrega una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Agrega un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y altura
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Escribe el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Consejo" color="primary" %}}

Aspose desarrolló recientemente un [creador de collages gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Agregar Imagen como Enlace**

Para evitar tamaños de presentación grandes, puedes agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código C++ muestra cómo agregar una imagen y un video en un marcador de posición:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Recortar Imagen**

Este código C++ muestra cómo recortar una imagen existente en una diapositiva: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Crea un nuevo objeto de imagen
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Agrega un PictureFrame a una Diapositiva
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Recorta la imagen (valores en porcentaje)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Guarda el resultado
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## Eliminar Áreas Recortadas de la Imagen

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código C++ demuestra la operación: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Obtiene el PictureFrame de la primera diapositiva
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Elimina las áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Guarda el resultado
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTA" color="warning" %}} 

El método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen solo se usa en el [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte archivos WMF/EMF a imágenes PNG rasterizadas en la operación de recorte. 

{{% /alert %}}

## **Bloquear la Relación de Aspecto**

Si deseas que una forma que contenga una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar el método [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) para establecer la configuración *Bloquear Relación de Aspecto*.

Este código C++ muestra cómo bloquear la relación de aspecto de una forma:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// establece la forma para preservar la relación de aspecto al cambiar el tamaño
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTA" color="warning" %}} 

Esta configuración *Bloquear Relación de Aspecto* solo preserva la relación de aspecto de la forma y no de la imagen que contiene.

{{% /alert %}}

## **Usar Propiedad StretchOff**

Utilizando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) y [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) y la clase [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format), puedes especificar un rectángulo de relleno.

Cuando se especifica el estiramiento de una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada lado del rectángulo de relleno se define por un desplazamiento porcentual desde el lado correspondiente del cuadro delimitador de la forma. Un porcentaje positivo especifica un inseto. Un porcentaje negativo especifica un outset.

1. Crea una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un rectángulo `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de relleno de la forma.
6. Establece el modo de relleno de imagen de la forma.
7. Agrega una imagen establecida para llenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma.
9. Escribe la presentación modificada como un archivo PPTX.

Este código C++ demuestra un proceso en el que se usa una propiedad StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Establece la imagen estirada desde cada lado en el cuerpo de la forma
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```