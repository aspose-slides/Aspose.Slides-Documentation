---
title: Gestionar marcos de imagen en presentaciones usando C++
linktitle: Marco de Imagen
type: docs
weight: 10
url: /es/cpp/picture-frame/
keywords:
- marco de imagen
- agregar marco de imagen
- crear marco de imagen
- agregar imagen
- crear imagen
- extraer imagen
- imagen raster
- imagen vectorial
- recortar imagen
- área recortada
- propiedad StretchOff
- formateo de marco de imagen
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
description: "Agregue marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para C++. Optimice su flujo de trabajo y mejore el diseño de las diapositivas."
---

Un marco de imagen es una forma que contiene una imagen—es como una foto en un marco. 

Puede agregar una imagen a una diapositiva mediante un marco de imagen. De esta manera, puede dar formato a la imagen formateando el marco de imagen.

{{% alert  title="Consejo" color="primary" %}} 

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a los usuarios crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

## **Crear un Marco de Imagen**

1. Cree una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Cree un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) asociada con el objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y alto de la imagen.
5. Cree un [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) basado en el ancho y alto de la imagen mediante el método `AddPictureFrame` expuesto por el objeto shape asociado a la diapositiva referenciada.
6. Agregue un marco de imagen (que contiene la foto) a la diapositiva.
7. Guarde la presentación modificada como un archivo PPTX.

Este código C++ le muestra cómo crear un marco de imagen:
```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Cargar la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carga la imagen que se agregará a la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Añade una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Añade un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y alto
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Aplica algo de formato al Marco de Imagen
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Escribe el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="warning" %}} 

Los marcos de imagen le permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combina el marco de imagen con las opciones de guardado de Aspose.Slides, puede manipular operaciones de entrada/salida para convertir imágenes de un formato a otro. Puede consultar estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **Crear un Marco de Imagen con Escala Relativa**

Al modificar la escala relativa de una imagen, puede crear un marco de imagen más complejo. 

1. Cree una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Añada una imagen a la colección de imágenes de la presentación.
4. Cree un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) asociada con el objeto de presentación que se utilizará para rellenar la forma.
5. Especifique el ancho y alto relativos de la imagen en el marco de imagen.
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

// Carga la imagen que se agregará a la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Añade una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Añade un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y alto
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Escribe el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Extraer Imágenes Raster de Marcos de Imagen**

Puede extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.
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


## **Extraer Imágenes SVG de Marcos de Imagen**

Cuando una presentación contiene gráficos SVG ubicados dentro de formas [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), Aspose.Slides para C++ le permite recuperar las imágenes vectoriales originales con fidelidad total. Al recorrer la colección de formas de la diapositiva, puede identificar cada [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/), comprobar si el [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) subyacente contiene contenido SVG y luego guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código demuestra cómo extraer una imagen SVG de un marco de imagen:
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


## **Obtener Transparencia de una Imagen**

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
Todos los efectos aplicados a imágenes se pueden encontrar en [Aspose::Slides::Effects](https://reference.aspose.com/slides/cpp/aspose.slides.effects/).
{{% /alert %}}

## **Formatado de Marcos de Imagen**

Aspose.Slides ofrece muchas opciones de formato que pueden aplicarse a un marco de imagen. Con esas opciones, puede modificar un marco de imagen para que cumpla requisitos específicos.

1. Cree una instancia de la [clase Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Cree un objeto [IPPImage](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_p_p_image) añadiendo una imagen a la [IImagescollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) asociada con el objeto de presentación que se utilizará para rellenar la forma.
4. Especifique el ancho y alto de la imagen.
5. Cree un `PictureFrame` basado en el ancho y alto de la imagen mediante el método [AddPictureFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection) asociado a la diapositiva referenciada.
6. Agregue el marco de imagen (que contiene la foto) a la diapositiva.
7. Establezca el color de línea del marco de imagen.
8. Establezca el ancho de línea del marco de imagen.
9. Gire el marco de imagen asignándole un valor positivo o negativo. 
   * Un valor positivo rota la imagen en sentido horario. 
   * Un valor negativo rota la imagen en sentido antihorario.
10. Agregue el marco de imagen (que contiene la foto) a la diapositiva.
11. Guarde la presentación modificada como un archivo PPTX.

Este código C++ demuestra el proceso de formateo del marco de imagen:
```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carga la presentación deseada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede a la primera diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Carga la imagen que se agregará a la colección de imágenes de la presentación
// Obtiene la imagen
auto image = Images::FromFile(filePath);

// Añade una imagen a la colección de imágenes de la presentación
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Añade un marco de imagen a la diapositiva
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Establece la escala relativa de ancho y alto
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Escribe el archivo PPTX en el disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert title="Consejo" color="primary" %}}

Aspose desarrolló recientemente un [fabricante de collages gratuito](https://products.aspose.app/slides/collage). Si necesita [fusionar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, o [crear cuadrículas a partir de fotos](https://products.aspose.app/slides/collage/photo-grid), puede usar este servicio. 

{{% /alert %}}

## **Agregar una Imagen como Enlace**

Para evitar tamaños grandes de presentación, puede agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código C++ muestra cómo agregar una imagen y un video en un marcador de posición:
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


## **Recortar Imágenes**

Este código C++ muestra cómo recortar una imagen existente en una diapositiva: 
``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Crea un nuevo objeto de imagen
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Agrega un PictureFrame a una diapositiva
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Recorta la imagen (valores en porcentaje)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Guarda el resultado
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Eliminar Áreas Recortadas de un Marco**

Si desea eliminar las áreas recortadas de una imagen contenida en un marco, puede usar el método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Este método devuelve la imagen recortada o la imagen original si el recorte no es necesario.

Este código C++ demuestra la operación: 
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


{{% alert title="NOTA" color="warning" %}} 

El método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte metarchivos WMF/EMF a imágenes raster PNG durante la operación de recorte. 

{{% /alert %}}

## **Bloquear Proporción de Aspecto**

Si desea que una forma que contiene una imagen mantenga su proporción de aspecto aun después de cambiar las dimensiones de la imagen, puede usar el método [set_AspectRatioLocked()](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) para establecer la configuración *Bloquear proporción de aspecto*. 

Este código C++ muestra cómo bloquear la proporción de aspecto de una forma:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```


{{% alert title="NOTA" color="warning" %}} 

Esta configuración *Bloquear proporción de aspecto* conserva solo la proporción de la forma y no la imagen que contiene.

{{% /alert %}}

## **Usar la Propiedad StretchOff**

Utilizando las propiedades [StretchOffsetLeft](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) y [StretchOffsetBottom](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_picture_fill_format) y la clase [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_fill_format), puede especificar un rectángulo de relleno. 

Cuando se especifica el estiramiento de una imagen, un rectángulo de origen se escala para adaptarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción. Un porcentaje negativo indica una protrusión.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un rectángulo `AutoShape`. 
4. Cree una imagen.
5. Establezca el tipo de relleno de la forma.
6. Establezca el modo de relleno de imagen de la forma.
7. Añada una imagen establecida para rellenar la forma.
8. Especifique los desplazamientos de la imagen desde el borde correspondiente del cuadro delimitador de la forma.
9. Guarde la presentación modificada como un archivo PPTX.

Este código C++ demuestra un proceso en el que se usa la propiedad StretchOff:
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


## **FAQ**

**¿Cómo puedo saber qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen que se asigna a un [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de decenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes aumenta el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener bajo el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite agregar imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utilice los [bloqueos de forma](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/get_pictureframelock/) para un [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) (por ejemplo, desactivar movimiento o redimensionado). El mecanismo de bloqueo se describe para formas en un artículo de [protección separado](/slides/es/cpp/applying-protection-to-presentation/) y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/cpp/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/cpp/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.