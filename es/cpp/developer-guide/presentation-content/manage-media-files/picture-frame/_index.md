---
title: Gestionar marcos de imagen en presentaciones con C++
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/cpp/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- imagen incrustada
- imagen vinculada
- extraer imagen
- imagen raster
- imagen SVG
- recortar imagen
- eliminar áreas recortadas
- comprimir imagen
- StretchOffset
- formato de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Crear, dar formato, vincular, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para C++."
---
## **Visión general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) posee recursos de imágenes incrustadas a través de su [colección de imágenes](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_images/), mientras que un [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación resulta útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG y imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Agregar y dar formato a una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapecollection/addpictureframe/). La imagen pasa a ser parte del paquete de la presentación, de modo que la presentación permanece autocontenida cuando se mueve a otro equipo.

El siguiente ejemplo añade una imagen JPEG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustada. Esta distinción cobra importancia al recortar o comprimir una imagen más adelante.

## **Utilizar escala relativa**

[IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) expone el escalado relativo de ancho y alto para el marco. Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita conservar una relación con el tamaño de la imagen fuente en lugar de calcular manualmente las dimensiones finales.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La escala relativa cambia la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por lo tanto, es la opción más segura para la portabilidad y una renderización predecible. Una imagen vinculada almacena una ubicación externa a través de la ruta de enlace del [ISlidesPicture](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidespicture/) en lugar de incrustar los datos de la imagen de la misma forma.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe permanecer accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo electrónico, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Agregar una imagen vinculada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Solo trata el enlace de imágenes; el enlace de vídeo es un flujo de trabajo multimedia separado y deliberadamente no se mezcla en este ejemplo.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilice enlaces cuando la gestión de archivos externos es intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación mayor autocontenida.

## **Extraer imágenes de marcos de imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma sea realmente un [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) y que contenga una imagen incrustada. Los marcos de imagen vinculados pueden no contener bytes de imagen que puedan extraerse de la misma manera.

### **Extraer una imagen raster**

La API moderna de imágenes utiliza [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) directamente. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Guardar mediante [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, use los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) expone un objeto [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/). Esto le permite recuperar los datos SVG directamente en lugar de rasterizar primero la imagen.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG necesariamente renderizan ese contenido vectorial en píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia byte a byte del SVG incrustado original; use los datos del [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) incrustado cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

Recortar cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [IPictureFillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/) son porcentajes de las dimensiones de la imagen fuente. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo modifica la región visible.

El siguiente ejemplo localiza de forma segura un marco de imagen y aplica valores de recorte:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse más adelante sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la siguiente sección.

## **Eliminar datos de imagen recortados**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: después de guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de “desrecorte” posterior.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también es usada por otros marcos de imagen, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/compressimage/) reduce la resolución de la imagen raster en relación con el tamaño en que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `true` cuando la imagen se redimensionó o recortó y `false` cuando no fue necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

También puede pasarse un valor DPI positivo personalizado en lugar de un valor de enumeración cuando se requiere un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y los metafiles no se reducen con este flujo de trabajo de compresión raster. Además, recuerde que una resolución menor y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño al que la imagen será visualizada o exportada, en lugar de aplicar el DPI más bajo globalmente.

## **Administrar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Image Transform Effects](/slides/es/cpp/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

La configuración de [IPictureFrameLock](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframelock/) controla qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, el [bloqueo de relación de aspecto](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) preserva las proporciones de la forma mientras se redimensiona.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen fuente sea remuestreada o modificada permanentemente para que tenga la misma relación de aspecto.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es “stretch”, los valores stretch‑offset en [IPictureFillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una expansión.

Esto es diferente del recorte. Los valores de recorte seleccionan qué parte de la imagen fuente es visible; los offsets de estiramiento cambian el rectángulo en el que el relleno de imagen visible se estira.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilice offsets de estiramiento para la ubicación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Consideraciones de almacenamiento, tamaño de archivo y exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autocontenida y son las más fiables para compartir y renderizar en el servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminan explícitamente o se quitan durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución original. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) existente cuando sea posible, en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño de visualización real, elimine píxeles recortados solo cuando no se requiera edición posterior y evite enlaces externos a menos que la gestión de dependencias forme parte del diseño de despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) representa un recurso de imagen asociado a la presentación. Un [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) es una forma en una diapositiva que muestra una imagen y almacena la geometría y el formato a nivel de marco, como el tamaño, la rotación, los valores de recorte, los efectos y los bloqueos.

**¿Debo incrustar o vincular imágenes?**

Incruste imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí solo. La configuración de recorte normal oculta partes de la imagen fuente pero conserva los píxeles subyacentes. Utilice [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) o la compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen fuente original fuera de la presentación si posteriormente se requiere edición en alta resolución.

**¿Cómo deben manejarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo puedo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marcos de imagen. Verifique la forma con [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) antes de aplicar un casting en tiempo de ejecución y asigne el resultado del casting a una variable local antes de acceder a los miembros específicos del marco de imagen.