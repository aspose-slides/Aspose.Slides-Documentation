---
title: Optimizar la gestión de imágenes en presentaciones usando C++
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/cpp/image/
keywords:
- añadir imagen
- añadir foto
- reemplazar imagen
- colección de imágenes
- marco de imagen
- imagen enlazada
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- SVG a formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo añadir, reutilizar, enlazar, reemplazar y gestionar imágenes raster y SVG en presentaciones PowerPoint y OpenDocument con Aspose.Slides para C++."
---
## **Introducción**

Aspose.Slides for C++ ofrece varias formas de trabajar con imágenes, y cada una sirve para un propósito diferente. Puede almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, reemplazar un recurso de imagen compartido o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y cómo se usan en toda una presentación. Para recorte, transparencia, efectos, estirado y otros formatos aplicados a un marco de imagen individual, consulte [Marco de imagen](/slides/es/cpp/picture-frame/).

## **Comprender el modelo de imagen**

Los siguientes conceptos de API están estrechamente relacionados pero no son intercambiables:

- La [colección de imágenes de la presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/) almacena los recursos de imagen utilizados por la presentación. Utilice [IImageCollection::AddImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/addimage/) para agregar datos de imagen y obtener un recurso [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Utilice [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addpictureframe/) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva utiliza una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/replaceimage/) reemplaza un recurso de imagen. Si varios elementos de la presentación usan ese recurso, todos utilizan el reemplazo.
- Convertir un SVG a formas crea formas de diapositiva editables. Después de la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por tanto: añadir datos de imagen a la colección de imágenes, recibir un [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/), y luego usar ese recurso en uno o más marcos de imagen o rellenos.

## **Agregar una imagen incrustada**

Para insertar una imagen local, lea el archivo, añada sus datos a la colección de imágenes y cree un marco de imagen que utilice el recurso [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) devuelto.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La imagen añadida de esta manera se incrusta en la presentación, por lo que el archivo resultante no depende de que el archivo de imagen original siga estando disponible.

### **Agregar una imagen desde la web**

Cuando una imagen está disponible a través de HTTP o HTTPS, descargue sus bytes, añádalos a la colección de imágenes de la presentación y utilice el recurso de imagen devuelto de la misma manera que una imagen local.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Valide las URLs remotas, los tamaños de respuesta y los tipos de contenido cuando la fuente no sea de confianza. En aplicaciones que ya utilizan otro cliente HTTP, puede descargar la imagen con ese cliente y pasar los bytes o el flujo resultante a [IImageCollection::AddImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/addimage/).

## **Reutilizar imágenes en varias diapositivas**

Si la misma imagen se necesita más de una vez, añádala a la presentación una sola vez y reutilice el [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para gráficos que deberían aparecer automáticamente en muchas diapositivas, como el logotipo de la empresa, considere colocar el marco de imagen en un [maestro de diapositiva](/slides/es/cpp/slide-master/) o diseño en lugar de añadir una forma equivalente en cada diapositiva.

## **Usar una imagen como fondo de diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir el fondo de la diapositiva y no debe manipularse como un objeto de diapositiva normal.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para opciones de fondo adicionales, incluidos fondos de maestros y diseños, consulte [Fondo de presentación](/slides/es/cpp/presentation-background/).

## **Imágenes incrustadas e imágenes enlazadas**

Las imágenes incrustadas y las imágenes enlazadas tienen diferentes compensaciones de portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es autónoma, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen enlazada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe seguir siendo accesible cuando la presentación se abra o se renderice.

Una imagen enlazada puede crearse asignando la ruta o URL externa mediante [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidespicture/set_linkpathlong/) en lugar de incrustar los datos de la imagen.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilice imágenes enlazadas solo cuando el entorno de despliegue pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas son generalmente más seguras.

## **Trabajar con imágenes SVG**

SVG es un formato vectorial, por lo que puede ser útil para iconos, diagramas y otros gráficos que deben escalar sin la misma pérdida de detalle que las imágenes raster. Aspose.Slides admite SVG tanto como recurso de imagen como fuente para formas de diapositiva editables.

### **Agregar un SVG como imagen**

Cree un [SvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/svgimage/), añádalo a la colección de imágenes y coloque el recurso de imagen resultante en un marco de imagen.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Archivos SVG con recursos externos**

Un SVG puede referenciar imágenes externas, hojas de estilo o fuentes. Para estos casos, [SvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/svgimage/) proporciona constructores que aceptan un [IExternalResourceResolver](https://reference.aspose.com/slides/es/cpp/aspose.slides.import/iexternalresourceresolver/) y una URI base. El resolvedor puede mapear una URI relativa a una URI absoluta permitida y devolver un flujo para el recurso solicitado.

El resolvedor pone los recursos externos a disposición mientras Aspose.Slides procesa el SVG, pero no reescribe el SVG en un documento autónomo. Si el SVG debe seguir siendo portátil, incruste sus recursos necesarios en el propio SVG, por ejemplo utilizando URIs `data:` para imágenes enlazadas.

Cuando los archivos SVG provienen de fuentes no fiables, restrinja los esquemas, ubicaciones de archivos y hosts a los que el resolvedor puede acceder. Los resolvedores de red también deben aplicar tiempos de espera, límites de tamaño de respuesta y validación de contenido.

### **Convertir SVG a formas editables**

Aspose.Slides puede convertir un SVG en un grupo de formas de diapositiva editables, similar al comando correspondiente de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilice la sobrecarga [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addgroupshape/) que acepta un [ISvgImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/isvgimage/) para realizar la conversión.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilice la conversión de SVG a formas cuando los elementos vectoriales individuales necesiten editarse como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más sencillo y evita crear muchas formas separadas.

## **Reemplazar un recurso de imagen existente**

Utilice [IPPImage::ReplaceImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/replaceimage/) cuando desee reemplazar un recurso de imagen existente. Esto es especialmente útil para gráficos compartidos como logotipos.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Si varios marcos de imagen, fondos, maestros o diseños utilizan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigne una imagen diferente a ese marco en lugar de reemplazar el recurso compartido.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/replaceimage/) también ofrece sobrecargas que aceptan un [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) o otro [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/).

## **Guía práctica de gestión de imágenes**

### **Controlar el tamaño de la presentación**

Las imágenes raster grandes pueden hacer que una presentación sea innecesariamente grande. Utilice imágenes de origen con dimensiones adecuadas al tamaño de visualización previsto, reutilice recursos de imagen compartidos cuando sea posible y evite incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes raster que ya se han colocado en marcos de imagen, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/compressimage/) puede reducir los datos de la imagen según la resolución seleccionada y los ajustes de recorte. Esto es un procesamiento de marco de imagen en lugar de una gestión de la colección de imágenes, por lo que consulte [Marco de imagen](/slides/es/cpp/picture-frame/) para operaciones de formato relacionadas.

### **Elegir entre contenido incrustado y enlazado**

Incrustar hace que la presentación sea portátil porque todos los datos de imagen requeridos viajan con el archivo. Enlazar puede reducir el tamaño del archivo, pero introduce una dependencia externa. Utilice enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la marca compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, utilice un recurso de imagen y reutilícelo. Si el gráfico pertenece al diseño de la presentación más que al contenido de la diapositiva, colóquelo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los recursos SVG portátiles**

Un SVG autónomo es más fácil de mover y renderizar de forma coherente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incruste los recursos necesarios antes de importar el SVG. Convierta SVG a formas solo cuando los elementos vectoriales individuales necesiten editarse.

### **Utilizar la API de imagen de Aspose.Slides**

Para flujos de trabajo de imágenes en C++, utilice las APIs [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/) y [Images](https://reference.aspose.com/slides/es/cpp/aspose.slides/images/) de Aspose.Slides cuando necesite un objeto de imagen, y utilice [IImageCollection::AddImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/addimage/) cuando necesite registrar datos de imagen como recurso de la presentación. Las sobrecargas de la colección también admiten matrices de bytes y flujos, lo que es útil cuando los datos de imagen provienen de archivos, clientes de red, bases de datos u otras bibliotecas.

Generar contenido EMF a partir de hojas de cálculo u otro producto es un flujo de integración independiente y está fuera del alcance de este artículo. Si un archivo WMF o EMF existente solo necesita insertarse en una presentación, pase sus datos a una sobrecarga adecuada de [IImageCollection::AddImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimagecollection/addimage/) sin añadir una dependencia de un segundo producto al flujo de gestión de imágenes.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y proporciona formato específico de imagen como recorte y efectos.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en todas partes?**

Si el logotipo ya se comparte como un único recurso de imagen, reemplace ese recurso con [IPPImage::ReplaceImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/replaceimage/). Para la marca en toda la presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué una imagen enlazada desaparece en otro ordenador?**

Una imagen enlazada depende de su archivo o URL externos. Si ese recurso no se puede alcanzar desde el otro ordenador, la imagen enlazada puede no estar disponible. Incruste la imagen cuando la presentación deba ser autónoma.

**¿Puede un SVG insertado editarse como formas de PowerPoint?**

Sí. Convierta el SVG con [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addgroupshape/); el grupo resultante contiene formas de diapositiva editables en lugar de una única imagen SVG.

**¿Cómo puedo mantener las presentaciones con muchas imágenes más pequeñas?**

Reutilice recursos de imagen compartidos, evite fuentes raster innecesariamente grandes, comprima las imágenes raster adecuadas cuando sea apropiado, mantenga la marca repetida en maestros o diseños y use imágenes enlazadas solo cuando una dependencia externa sea aceptable.