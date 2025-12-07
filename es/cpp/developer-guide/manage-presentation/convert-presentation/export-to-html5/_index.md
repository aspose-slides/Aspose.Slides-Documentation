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
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML5 responsivo con Aspose.Slides para C++. Conservar el formato, las animaciones y la interactividad."
---

{{% alert title="Info" color="info" %}}

En [Aspose.Slides 21.9](/slides/es/cpp/aspose-slides-for-cpp-21-9-release-notes/), implementamos soporte para la exportación a HTML5.

{{% /alert %}} 

El proceso de exportación a HTML5 aquí le permite convertir PowerPoint a HTML. De esta manera, usando sus propias plantillas, puede aplicar opciones muy flexibles que definen el proceso de exportación y el HTML, CSS, JavaScript y atributos de animación resultantes. 

## **Exportar PowerPoint a HTML5**

Este código C++ muestra cómo exportar una presentación a HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

En este caso, obtiene HTML limpio. 

{{% /alert %}}

Puede especificar configuraciones para animaciones de formas y transiciones de diapositivas de esta manera:
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


En este caso, el contenido de la presentación se renderiza mediante SVG de la siguiente forma:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 

Cuando utiliza este método para exportar PowerPoint a HTML, debido a la renderización SVG, no podrá aplicar estilos ni animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint a Vista de Diapositivas HTML5**

**Aspose.Slides** le permite convertir una presentación PowerPoint a un documento HTML5 en el que las diapositivas se presentan en modo de vista de diapositiva. En este caso, al abrir el archivo HTML5 resultante en un navegador, verá la presentación en modo de vista de diapositiva en una página web. 

Este código C++ demuestra el proceso de exportación a Vista de Diapositivas HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Convertir una Presentación a un Documento HTML5 con Comentarios**

Los comentarios en PowerPoint son una herramienta que permite a los usuarios dejar notas o comentarios en las diapositivas de la presentación. Son especialmente útiles en proyectos colaborativos, donde varias personas pueden añadir sus sugerencias o observaciones a elementos específicos de la diapositiva sin alterar el contenido principal. Cada comentario muestra el nombre del autor, facilitando rastrear quién dejó la observación.

Supongamos que tenemos la siguiente presentación PowerPoint guardada en el archivo "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

Al convertir una presentación PowerPoint a un documento HTML5, puede especificar fácilmente si incluir los comentarios de la presentación en el documento de salida. Para ello, debe especificar los parámetros de visualización de los comentarios en el método `get_NotesCommentsLayouting` de la clase [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

El siguiente ejemplo de código convierte una presentación a un documento HTML5 con los comentarios mostrados a la derecha de las diapositivas.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


El documento "output.html" se muestra en la imagen a continuación.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**¿Puedo controlar si las animaciones de objetos y las transiciones de diapositivas se reproducen en HTML5?**

Sí, HTML5 proporciona opciones separadas para habilitar o deshabilitar [animaciones de formas](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) y [transiciones de diapositivas](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**¿Se admite la salida de comentarios y dónde pueden colocarse respecto a la diapositiva?**

Sí, los comentarios pueden añadirse en HTML5 y posicionarse (por ejemplo, a la derecha de la diapositiva) mediante la configuración de diseño para notas y comentarios.

**¿Puedo omitir enlaces que invocan JavaScript por razones de seguridad o CSP?**

Sí, existe una [configuración](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) que permite omitir hipervínculos con llamadas a JavaScript durante el guardado. Esto ayuda a cumplir con políticas de seguridad estrictas.