---
title: Exportar a HTML5
type: docs
weight: 40
url: /cpp/export-to-html5/
keywords:
- PowerPoint a HTML
- diapositivas a HTML
- HTML5
- exportación HTML
- exportar presentación
- convertir presentación
- convertir diapositivas
- C++
- Aspose.Slides para C++
description: "Exportar PowerPoint a HTML5 en C++" 
---

{{% alert title="Info" color="info" %}}

En [Aspose.Slides 21.9](/slides/cpp/aspose-slides-for-cpp-21-9-release-notes/), implementamos soporte para la exportación a HTML5.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí te permite convertir PowerPoint a HTML. De esta manera, utilizando tus propias plantillas, puedes aplicar opciones muy flexibles que definen el proceso de exportación y los atributos resultantes de HTML, CSS, JavaScript y animación.

## **Exportar PowerPoint a HTML5**

Este código en C++ muestra cómo exportar una presentación a HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

En este caso, obtienes HTML limpio. 

{{% /alert %}}

Puede que desees especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:

```cpp
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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

En este caso, el contenido de la presentación se renderiza a través de SVG en una forma como esta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> EL CONTENIDO DE LA DIAPOSITIVA VA AQUÍ </g>
     </svg>
</div>
</body>
```

{{% alert title="Nota" color="warning" %}} 

Cuando utilizas este método para exportar PowerPoint a HTML, debido al renderizado SVG, no podrás aplicar estilos o animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a HTML5 Vista de Diapositivas**

**Aspose.Slides** te permite convertir una presentación de PowerPoint a un documento HTML5 en el que las diapositivas se presentan en un modo de vista de diapositivas. En este caso, cuando abres el archivo HTML5 resultante en un navegador, ves la presentación en modo de vista de diapositivas en una página web. 

Este código en C++ demuestra el proceso de exportación de PowerPoint a HTML5 Vista de Diapositivas:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## Convertir una Presentación a un Documento HTML5 con Comentarios

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios sobre las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden agregar sus sugerencias o observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, lo que facilita el seguimiento de quién dejó la observación.

Supongamos que tenemos la siguiente presentación de PowerPoint guardada en el archivo "sample.pptx".

![Dos comentarios en la diapositiva de la presentación](two_comments_pptx.png)

Cuando conviertes una presentación de PowerPoint a un documento HTML5, puedes especificar fácilmente si deseas incluir comentarios de la presentación en el documento de salida. Para hacer esto, necesitas especificar los parámetros de visualización para los comentarios en el método `get_NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

El documento "output.html" se muestra en la imagen a continuación.

![Los comentarios en el documento HTML5 de salida](two_comments_html5.png)