---
title: Convertir presentaciones a HTML5 en C++
linktitle: Presentación a HTML5
type: docs
weight: 40
url: /es/cpp/export-to-html5/
keywords:
- PowerPoint a HTML5
- OpenDocument a HTML5
- presentación a HTML5
- diapositiva a HTML5
- PPT a HTML5
- PPTX a HTML5
- ODP a HTML5
- guardar PPT como HTML5
- guardar PPTX como HTML5
- guardar ODP como HTML5
- exportar PPT a HTML5
- exportar PPTX a HTML5
- exportar ODP a HTML5
- C++
- Aspose.Slides
description: "Exporta presentaciones de PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para C++. Conserva el formato, las animaciones y la interactividad."
---
## **Visión general**

Este artículo explica cómo convertir presentaciones de PowerPoint a HTML5 utilizando Aspose.Slides. Cubre la exportación básica a HTML5 sin extensiones web ni dependencias adicionales, así como opciones para controlar las animaciones de formas y las transiciones de diapositivas. El artículo también muestra el proceso estándar de exportación de PowerPoint a HTML, explica cómo generar salida HTML5 en modo vista de diapositivas y demuestra cómo incluir comentarios en el documento exportado configurando su disposición.

## **Exportar PowerPoint a HTML5**

Este código C++ muestra cómo exportar una presentación a HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
En este caso, obtienes HTML limpio. 
{{% /alert %}}

Puede que desees especificar la configuración para las animaciones de formas y las transiciones de diapositivas de esta manera:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Exportar PowerPoint a HTML**

Este C++ demuestra el proceso estándar de PowerPoint a HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

En este caso, el contenido de la presentación se representa mediante SVG en un formato como este:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Nota" color="warning" %}} 
Al usar este método para exportar PowerPoint a HTML, debido a la representación en SVG, no podrás aplicar estilos ni animar elementos específicos. 
{{% /alert %}}

## **Exportar PowerPoint a HTML5 Vista de diapositivas**

**Aspose.Slides** permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo vista de diapositivas. En este caso, al abrir el archivo HTML5 resultante en un navegador, verás la presentación en modo vista de diapositivas en una página web. 

Este código C++ demuestra el proceso de exportación de PowerPoint a HTML5 Vista de diapositivas:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Convertir una presentación a un documento HTML5 con comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o retroalimentación en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias o observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

Al convertir una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si se incluyen los comentarios de la presentación en el documento de salida. Para ello, debes indicar los parámetros de visualización de los comentarios en el método `get_NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/).

El ejemplo de código a continuación convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

El documento "output.html" se muestra en la imagen inferior.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

### ¿Puedo controlar si se reproducen las animaciones de objetos y las transiciones de diapositivas en HTML5?

Sí, HTML5 proporciona opciones independientes para habilitar o desactivar [animaciones de formas](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/set_animateshapes/) y [transiciones de diapositivas](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### ¿Se admiten los comentarios en la salida y dónde pueden situarse respecto a la diapositiva?

Sí, los comentarios pueden agregarse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante la configuración de disposición para notas y comentarios.

### ¿Puedo omitir enlaces que invocan JavaScript por motivos de seguridad o CSP?

Sí, existe una [configuración](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) que permite omitir hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.