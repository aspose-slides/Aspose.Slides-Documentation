---
title: Convertir diapositivas de presentación a imágenes en C++
linktitle: Diapositiva a imagen
type: docs
weight: 41
url: /es/cpp/convert-slide/
keywords:
- convertir diapositiva
- exportar diapositiva
- diapositiva a imagen
- guardar diapositiva como imagen
- diapositiva a EMF
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a bitmap
- diapositiva a TIFF
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Convierta diapositivas de presentaciones PPT, PPTX y ODP a PNG, JPEG, GIF, TIFF, EMF y otros formatos de imagen en C++ con Aspose.Slides para C++."
---
## **Introducción**

Aspose.Slides for C++ puede renderizar diapositivas individuales de presentaciones PowerPoint y OpenDocument como PNG, JPEG, GIF, TIFF y otros formatos de imagen.

Para convertir una diapositiva en una imagen, siga estos pasos:

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Seleccione la diapositiva que desea renderizar.
3. Si es necesario, configure la renderización con la clase [RenderingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/).
4. Llame al método [ISlide::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/getimage/). Devuelve un objeto [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/).
5. Llame al método [IImage::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/save/) y especifique el formato de salida con un valor [ImageFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/imageformat/).

## **Convertir una diapositiva a una imagen PNG**

La conversión más simple utiliza la configuración de renderizado predeterminada. El objeto [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) resultante puede procesarse en memoria o guardarse en un archivo.

El siguiente ejemplo en C++ renderiza la primera diapositiva y la guarda como una imagen PNG:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convertir diapositivas a imágenes con tamaños personalizados**

Utilice la sobrecarga [ISlide::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/getimage/) que acepta un valor [Size](https://reference.aspose.com/slides/es/cpp/system.drawing/size/) para renderizar una diapositiva con dimensiones de píxeles exactas.

El siguiente ejemplo crea una imagen JPEG de 1820 × 1040:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convertir diapositivas con notas y comentarios a imágenes**

Por defecto, las imágenes de diapositivas no incluyen notas ni comentarios. Asigne un objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/) al método [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) para controlar dónde aparecen las notas y los comentarios.

El siguiente ejemplo coloca notas truncadas debajo de la diapositiva y comentarios a su derecha:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
Para la conversión de diapositiva a imagen, no establezca el método [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) a [BottomFull](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notespositions/). Las notas pueden contener más texto del que el tamaño de imagen fijo puede acomodar. Use [BottomTruncated](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notespositions/) en su lugar.
{{% /alert %}}

## **Convertir diapositivas a imágenes usando opciones TIFF**

La clase [TiffOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/) le permite controlar el tamaño, la resolución y otras propiedades de la imagen TIFF renderizada.

El siguiente ejemplo renderiza la primera diapositiva como una imagen TIFF de 2160 × 2880 a 300 DPI:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convertir todas las diapositivas a imágenes**

Itere a través de la colección de diapositivas para convertir toda la presentación en una serie de imágenes. Las diapositivas ocultas se incluyen a menos que las omita explícitamente.

El siguiente ejemplo renderiza cada diapositiva como una imagen JPEG con factores de escala horizontal y vertical de 2:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **Crear salida de Metarchivo Mejorado**

Enhanced Metafile (EMF) es útil cuando los gráficos basados en vectores deben intercambiarse con Microsoft Office u otras aplicaciones de Windows que admiten metarchivos de Windows. A diferencia de una imagen basada en píxeles, un EMF puede conservar operaciones de dibujo vectorial que se escalan sin la misma pérdida de nitidez. Sin embargo, EMF es principalmente un formato de compatibilidad para aplicaciones con soporte de metarchivos de Windows, no un formato de intercambio universal. Además, el contenido complejo de la diapositiva, como imágenes de mapa de bits y algunos efectos, puede almacenarse como elementos rasterizados dentro del contenedor de metarchivo vectorial.

### **Exportar una diapositiva a EMF**

El método [ISlide::WriteAsEmf](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/writeasemf/) escribe un [ISlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/) en un flujo de destino en formato EMF. El siguiente ejemplo carga una presentación, selecciona la primera diapositiva y la escribe en un flujo de archivo EMF:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

El llamador posee el flujo pasado a [ISlide::WriteAsEmf](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/writeasemf/) y debe cerrarlo o disponerlo. Aspose.Slides escribe en la posición actual del flujo y lo deja abierto.

### **Convertir una imagen SVG a EMF y añadirla a una presentación**

Utilice [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/writeasemf/) para convertir contenido SVG a EMF. Los bytes resultantes pueden añadirse a la presentación a través de [IImageCollection::AddImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/addimage/) y colocarse en una diapositiva con [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides.ishapecollection/addpictureframe/).

El siguiente ejemplo crea un [SvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/svgimage/) a partir de marcado SVG, lo convierte a un EMF en memoria, inserta el metarchivo en la primera diapositiva y guarda la presentación:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/writeasemf/) no toma posesión del flujo de destino. Después de escribir, la posición del flujo está al final de los datos generados. El ejemplo llama a [MemoryStream::ToArray](https://reference.aspose.com/slides/es/cpp/system.io/memorystream/toarray/) para obtener el búfer completo sin importar la posición actual del flujo, y luego pasa ese arreglo de bytes a [IImageCollection::AddImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/addimage/). Mantenga el flujo abierto hasta que el consumidor haya terminado de leerlo y ciérrelo después.

La generación de EMF está disponible en los sistemas operativos compatibles con Aspose.Slides for C++, pero el renderizado puede variar entre plataformas cuando faltan fuentes o dependencias gráficas nativas. Instale las fuentes utilizadas por el contenido original o configure sustituciones adecuadas, siga los [requisitos de plataforma](/slides/es/cpp/system-requirements/) para Aspose.Slides for C++ y valide el resultado en la aplicación que consumirá el EMF. Las aplicaciones en Linux y macOS a menudo tienen un soporte limitado o inconsistente para mostrar y editar metarchivos de Windows.

## **Renderizado de Emoji en Color**

{{% alert title="Note" color="info" %}}
Para renderizar correctamente los emojis en color al convertir diapositivas de presentación a imágenes, las fuentes de emoji usadas en la presentación deben estar instaladas y disponibles en el sistema que realiza la conversión. Por ejemplo, si la presentación usa **Segoe UI Emoji** y esa fuente falta, los emojis pueden aparecer en monocromo en las imágenes de salida.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Aspose.Slides admite renderizar diapositivas con animaciones?**

No. El método [ISlide::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/getimage/) renderiza una imagen estática de la diapositiva y no exporta animaciones.

**¿Se pueden exportar diapositivas ocultas como imágenes?**

Sí. Las diapositivas ocultas pueden renderizarse como diapositivas normales. Inclúyalas en el bucle de procesamiento, como se muestra en el ejemplo anterior.

**¿Se conservan las sombras y otros efectos en las imágenes de diapositiva?**

Sí. Aspose.Slides renderiza sombras, transparencias y otros efectos gráficos compatibles en las imágenes de diapositiva.