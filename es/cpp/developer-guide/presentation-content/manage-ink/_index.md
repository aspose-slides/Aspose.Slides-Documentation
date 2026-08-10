---
title: Administrar objetos de tinta de PowerPoint en C++
linktitle: Administrar tinta
type: docs
weight: 95
url: /es/cpp/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- administrar tinta
- dibujar tinta
- dibujo
- exportación de tinta
- renderizado de tinta
- ocultar tinta
- IInkOptions
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Administrar objetos de tinta de PowerPoint, editar trazos y propiedades del pincel, y controlar la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF y imágenes con Aspose.Slides para C++."
---
## **Introducción**

PowerPoint ofrece una función de tinta que permite dibujar trazos libres. La tinta puede usarse para resaltar otros objetos, mostrar conexiones y procesos, y atraer la atención a elementos específicos en una diapositiva.

El espacio de nombres [Aspose.Slides.Ink](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/) contiene las clases e interfaces necesarias para trabajar con objetos de tinta. Por ejemplo, la interfaz [IInk](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint suelen estar representados por objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para obtener más información, consulte [Shape Layout Format](https://docs.aspose.com/slides/es/cpp/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los métodos estándar [IShape::get_Width](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_width/) y [IShape::get_Height](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de tinta**

Un trazo de tinta es un elemento básico utilizado para registrar la trayectoria de un lápiz mientras el usuario escribe tinta digital. Un trazo almacena una secuencia de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Se utiliza un pincel para dibujar líneas que conectan los puntos de un trazo de tinta. El pincel tiene su propio color y tamaño, representados por los métodos [IInkBrush::get_Color](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iinkbrush/get_color/) y [IInkBrush::get_Size](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iinkbrush/get_size/) .

### **Establecer color del pincel de tinta**

Este código C++ muestra cómo establecer el color de un pincel de tinta:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Establecer tamaño del pincel de tinta**

Este código C++ muestra cómo establecer el tamaño de un pincel de tinta:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

En general, la anchura y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente está atenuada). Cuando la anchura y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, se debe tener en cuenta el tamaño del pincel de sus trazos. Aquí, el objeto objetivo (el trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar la apariencia de la tinta durante la exportación y el renderizado**

Aspose.Slides proporciona la interfaz [IInkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puede usar sus métodos para ocultar la tinta completamente o cambiar cómo se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Método de opciones de tinta |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Los mismos dos ajustes están disponibles a través de estos métodos:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/set_hideink/) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `true`; establézcalo a `false` para utilizar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

De forma predeterminada, los objetos de tinta permanecen visibles durante la exportación. Llame a [IInkOptions::set_HideInk](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/set_hideink/) con `true` cuando necesite una salida limpia sin anotaciones manuscritas u otro contenido de tinta.

El siguiente ejemplo en C++ exporta una presentación a PDF mientras oculta todos los objetos de tinta:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Ocultar objetos de tinta al renderizar una diapositiva como imagen**

Para ocultar los objetos de tinta al renderizar diapositivas como imágenes bitmap, configure [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) y pase las opciones de renderizado al método [ISlide::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/getimage/).

El siguiente ejemplo en C++ renderiza la primera diapositiva como una imagen PNG sin objetos de tinta:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Controlar el renderizado de la máscara de tinta**

El método [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `true`, lo que utiliza opacidad. Llame al método con `false` para usar la operación ROP en su lugar.

El siguiente ejemplo en C++ exporta una diapositiva a SVG y utiliza renderizado basado en ROP para las operaciones de máscara de tinta:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

El mismo ajuste puede aplicarse a través de [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) al exportar una presentación o renderizar una diapositiva a TIFF.

### **Elegir si ocultar o conservar la tinta**

Utilice [IInkOptions::set_HideInk](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/set_hideink/) con `true` cuando el archivo exportado deba ser una versión limpia de una presentación anotada, por ejemplo, una copia final destinada a la distribución sin marcas de revisión.

Deje la tinta visible (configuración predeterminada `false`) cuando las anotaciones de tinta formen parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales separadas a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtenga el trazo mediante [IInk::get_Traces](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iink/get_traces/), luego cambie su [IInkTrace::get_Brush](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iinktrace/get_brush/). Puede llamar a [IInkBrush::set_Color](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iinkbrush/set_color/) y [IInkBrush::set_Size](https://reference.aspose.com/slides/es/cpp/aspose.slides.ink/iinkbrush/set_size/) sobre el pincel.

**¿Ocultar la tinta modifica la presentación original?**

No. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/iinkoptions/set_hideink/) afecta solo al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación original.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puede configurar opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las opciones de exportación o renderizado correspondientes mostradas arriba.

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/es/cpp/powerpoint-shapes/).
* Para obtener más información sobre valores efectivos, vea [Shape Effective Properties](https://docs.aspose.com/slides/es/cpp/shape-effective-properties/#get-effective-font-height-value).
* Para obtener detalles sobre la exportación a PDF, vea [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/es/cpp/convert-powerpoint-to-pdf/).
* Para obtener detalles sobre la exportación a HTML, vea [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/es/cpp/convert-powerpoint-to-html/).
* Para obtener detalles sobre la exportación a SVG, vea [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/es/cpp/render-a-slide-as-an-svg-image/).
* Para obtener detalles sobre la exportación a TIFF, vea [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/es/cpp/convert-powerpoint-to-tiff/).
* Para obtener detalles sobre renderizado de diapositiva a imagen, vea [Convert Presentation Slides to Images](https://docs.aspose.com/slides/es/cpp/convert-slide/).