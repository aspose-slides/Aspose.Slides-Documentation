---
title: Gestionar marcos de imagen en presentaciones usando C++
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/cpp/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- añadir imagen
- crear imagen
- extraer imagen
- imagen rasterizada
- imagen vectorial
- recortar imagen
- área recortada
- propiedad StretchOff
- formato de marco de imagen
- propiedades del marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- transparencia de imagen
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Añade marcos de imagen a presentaciones de PowerPoint y OpenDocument con Aspose.Slides para C++. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---
## **Introducción**

Un marco de imagen es una forma que contiene una imagen—es como una foto dentro de un marco. 

Puedes añadir una imagen a una diapositiva mediante un marco de imagen. De esta forma, puedes dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Tip" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que permiten a los usuarios crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un marco de imagen**

1. Cree una instancia de la clase [Presentation class](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Cree un objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_p_p_image) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_image_collection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y la altura de la imagen.
5. Cree un [PictureFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_frame) basado en el ancho y la altura de la imagen mediante el método `AddPictureFrame` expuesto por el objeto de forma asociado a la diapositiva referenciada.
6. Añada un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarde la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de imagen:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carga la imagen que se añadirá a la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Añade una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Añade un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y alto
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Aplica algo de formato al marco de imagen
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Escribe el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Los marcos de imagen le permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combina el marco de imagen con las opciones de guardado de Aspose.Slides, puede manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Es posible que desee ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/es/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/es/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/es/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/es/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/es/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Crear un marco de imagen con escala relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complejo. 

1. Cree una instancia de la clase [Presentation class](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Añada una imagen a la colección de imágenes de la presentación.
4. Cree un objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_p_p_image) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_image_collection) asociada al objeto de presentación que se utilizará para rellenar la forma.
5. Especifique el ancho y la altura relativos de la imagen en el marco de imagen.
6. Guarde la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de imagen con escala relativa:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carga la imagen que se añadirá a la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Añade una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Añade un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y alto
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Escribe el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extraer imágenes rasterizadas de marcos de imagen**

Puedes extraer imágenes rasterizadas de objetos [PictureFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_frame) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

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

## **Extraer imágenes SVG de marcos de imagen**

Cuando una presentación contiene gráficos SVG insertados dentro de formas [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/), Aspose.Slides for C++ le permite recuperar las imágenes vectoriales originales con total fidelidad. Al recorrer la colección de formas de la diapositiva, puedes identificar cada [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código muestra cómo extraer una imagen SVG de un marco de imagen:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Obtener la transparencia de una imagen**

Aspose.Slides le permite obtener el efecto de transparencia aplicado a una imagen. Este código C++ demuestra la operación:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Todos los efectos aplicados a las imágenes se pueden encontrar en [Aspose::Slides::Effects](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Obtener el brillo y el contraste de una imagen**

Aspose.Slides le permite obtener el efecto de brillo y contraste aplicado a una imagen. La interfaz [ILuminance](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iluminance/) representa este efecto de transformación de imagen.

Este código C++ muestra cómo obtener la configuración de brillo y contraste de un marco de imagen:

```c++
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **Formato de marco de imagen**

Aspose.Slides proporciona muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puedes alterar un marco de imagen para que cumpla requisitos específicos.

1. Cree una instancia de la clase [Presentation class](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
2. Obtenga una referencia a una diapositiva mediante su índice. 
3. Cree un objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_p_p_image) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_image_collection) asociada al objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y la altura de la imagen.
5. Cree un `PictureFrame` basado en el ancho y la altura de la imagen mediante el método [AddPictureFrame](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_shape_collection) asociado a la diapositiva referenciada.
6. Añada el marco de imagen (que contiene la foto) a la diapositiva.
7. Establezca el color de línea del marco de imagen.
8. Establezca el ancho de línea del marco de imagen.
9. Gire el marco de imagen asignándole un valor positivo o negativo.  
   * Un valor positivo gira la imagen en sentido horario.  
   * Un valor negativo gira la imagen en sentido antihorario.
10. Añada el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarde la presentación modificada como un archivo PPTX.

Este código C++ muestra el proceso de formato del marco de imagen:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Carga la imagen que se añadirá a la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Añade una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Añade un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y alto
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Escribe el archivo PPTX en disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose desarrolló recientemente un [Collage Maker gratuito](https://products.aspose.app/slides/es/collage). Si alguna vez necesitas [fusionar JPG/JPEG](https://products.aspose.app/slides/es/collage/jpg) o imágenes PNG, [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/es/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Añadir una imagen como enlace**

Para evitar presentaciones de gran tamaño, puedes añadir imágenes (o videos) mediante enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código C++ muestra cómo añadir una imagen y un video en un marcador de posición:

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

## **Recortar imágenes**

Este código C++ muestra cómo recortar una imagen existente en una diapositiva: 

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Crea un nuevo objeto de imagen
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Añade un PictureFrame a una diapositiva
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Recorta la imagen (valores en porcentaje)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Guarda el resultado
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Eliminar áreas recortadas de una imagen**

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código C++ muestra la operación: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

El método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) añade la imagen recortada a la colección de imágenes de la presentación. Si la imagen se utiliza únicamente en el [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, aumentará el número de imágenes en la presentación resultante.

Este método convierte archivos WMF/EMF en imágenes PNG rasterizadas durante la operación de recorte. 

{{% /alert %}}

## **Comprimir imágenes**

Puedes comprimir una imagen en una presentación usando el método [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/compressimage/).  
Este método comprime una imagen reduciendo su tamaño en función del tamaño de la forma y la resolución especificada, con la opción de eliminar áreas recortadas.

Ajusta el tamaño y la resolución de la imagen de forma similar a la función **Formato de imagen → Comprimir imágenes → Resolución** de PowerPoint.

Los siguientes ejemplos en C++ demuestran cómo comprimir una imagen en una presentación especificando una resolución objetivo y, opcionalmente, eliminando áreas recortadas:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Comprime la imagen con una resolución objetivo de 150 DPI (resolución web) y elimina las áreas recortadas.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Comprueba el resultado de la compresión.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O usando directamente un valor DPI personalizado:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Comprime la imagen a 150 DPI (resolución web), eliminando áreas recortadas.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

El método convierte la imagen a una resolución inferior en función del tamaño de la forma y el DPI proporcionado. Las regiones recortadas también pueden eliminarse para optimizar el tamaño del archivo.  
Si la imagen es un metarchivo (WMF/EMF) o SVG, no se aplicará compresión. Además, la calidad JPEG se conserva o se reduce ligeramente según la resolución, al igual que PowerPoint con JPEG de alta resolución.

{{% /alert %}}

## **Bloquear relación de aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de cambiar las dimensiones de la imagen, puedes usar el método [set_AspectRatioLocked()](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) para establecer la opción *Bloquear relación de aspecto*. 

Este código C++ muestra cómo bloquear la relación de aspecto de una forma:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// establecer que la forma preserve la relación de aspecto al redimensionarla
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

Esta configuración de *Bloquear relación de aspecto* preserva únicamente la relación de aspecto de la forma y no la de la imagen que contiene.

{{% /alert %}}

## **Usar la propiedad StretchOff**

Usando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) y [StretchOffsetBottom](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_picture_fill_format) y la clase [PictureFillFormat](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.picture_fill_format), puedes especificar un rectángulo de relleno. 

Cuando se especifica el estiramiento de una imagen, un rectángulo de origen se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción. Un porcentaje negativo indica una expansión.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
2. Obtenga una referencia a una diapositiva mediante su índice.
3. Añada un rectángulo `AutoShape`. 
4. Cree una imagen.
5. Establezca el tipo de relleno de la forma.
6. Establezca el modo de relleno de imagen de la forma.
7. Añada una imagen establecida para rellenar la forma.
8. Especifique los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma.
9. Guarde la presentación modificada como un archivo PPTX.

Este código C++ muestra un proceso en el que se utiliza la propiedad StretchOff:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen asignado a un [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de docenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes aumenta el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener reducido el tamaño de la presentación, pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides ofrece la posibilidad de añadir imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utilice los bloqueos de forma ([shape locks](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/get_pictureframelock/)) para un [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/) (por ejemplo, desactivar el movimiento o el redimensionado). El mecanismo de bloqueo se describe para formas en un [artículo de protección](/slides/es/cpp/applying-protection-to-presentation/) y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial del SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/cpp/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/cpp/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.