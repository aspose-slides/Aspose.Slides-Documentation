---
title: Aspose.Slides para C++
second_title: Aspose.Slides para C++
type: docs
weight: 30
url: /es/cpp/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Empiece aquí: instale Aspose.Slides para C++, cree su primera presentación y encuentre las guías para tareas comunes, la referencia de la API y el soporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ es una biblioteca nativa de C++ para crear, leer, editar y convertir presentaciones de PowerPoint y OpenDocument, sin Microsoft PowerPoint ni Automatización de Office.

Carga y guarda PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Empezar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/cpp/installation/">Instalación</a></li>
<li><a href="/slides/es/cpp/create-presentation/">Crear su primera presentación</a></li>
<li><a href="/slides/es/cpp/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/cpp/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/cpp/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/cpp/licensing/">Licenciamiento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construir con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/cpp/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/cpp/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/cpp/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/cpp/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/cpp/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/cpp/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/cpp/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/cpp/manage-media-files/">Audio y video</a></li>
<li><a href="/slides/es/cpp/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/cpp/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/cpp/examples/">Ejemplos por elemento de diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Ejemplos en GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia y Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Referencia de la API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/cpp/known-issues/">Problemas conocidos</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">Página del producto</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Descargar</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Mesa de ayuda de soporte de pago</a></li>
</ul>
</div>
</div>

------

## **Su primera presentación**

En Windows, cree un proyecto C++ **Console App** en Visual Studio e instale el paquete NuGet en la **Package Manager Console** (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

En Linux, descargue el paquete ZIP para Linux y configure el proyecto CMake descrito en [Instalación](/slides/es/cpp/installation/#linux).

Luego use este código como el archivo fuente principal de su programa. Crea una presentación con un cuadro de texto y la guarda:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Para ejecutarlo en Windows, seleccione la plataforma **x64** en la barra de herramientas y presione **Ctrl+F5**. En Linux, guárdelo como *main.cpp* en la carpeta del proyecto, luego compile y ejecute allí:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

El programa guarda *hello.pptx* con una diapositiva que contiene un cuadro de texto. Sin una licencia, el archivo guardado incluye una marca de agua de evaluación — vea [Licenciamiento](/slides/es/cpp/licensing/). Para más formas de crear y rellenar una presentación, consulte [Crear presentaciones](/slides/es/cpp/create-presentation/).