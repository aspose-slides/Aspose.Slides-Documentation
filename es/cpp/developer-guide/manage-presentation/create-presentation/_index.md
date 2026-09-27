---
title: Crear presentaciones en C++
linktitle: Crear presentación
type: docs
weight: 10
url: /es/cpp/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PPT
- nuevo PPT
- crear PPTX
- nuevo PPTX
- crear ODP
- nuevo ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Cree presentaciones en C++ con Aspose.Slides: genere archivos PPT, PPTX y ODP, aproveche la compatibilidad con OpenDocument y guárdelos programáticamente para obtener resultados fiables."
---
## **Descripción general**

Este artículo muestra cómo crear una presentación en Aspose.Slides, agregar un cuadro de texto a su primera diapositiva y guardar el resultado como un archivo. Al final hay una breve FAQ que cubre preguntas comunes sobre formatos, plantillas, tamaño de diapositivas, unidades, uso de memoria, subprocesos, licencias, firmas digitales y soporte de VBA.

Antes de comenzar, agregue Aspose.Slides a su proyecto: desde NuGet en un proyecto de Visual Studio en Windows, o desde el paquete ZIP con CMake en Linux. Consulte [Instalación](/slides/es/cpp/installation/).

## **Crear una presentación de PowerPoint**

Para crear una presentación y colocar un cuadro de texto en su primera diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
1. Obtenga esa diapositiva con el método [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) y su índice, 0.
1. Añada un rectángulo con el método [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) y establezca su texto con el método [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/).
1. Guarde la presentación como un archivo PPTX con el método [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

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

La esquina superior izquierda del rectángulo está a 50 puntos del borde izquierdo y a 50 puntos del borde superior de la diapositiva, y el rectángulo tiene 400 puntos de ancho y 100 puntos de alto. El programa guarda *hello.pptx* en su directorio de trabajo, con una diapositiva que contiene el rectángulo y su texto. Sin una licencia, Aspose.Slides también agrega una marca de agua de evaluación a cada diapositiva que guarda; consulte [Licencias](/slides/es/cpp/licensing/).

## **Preguntas frecuentes**

### ¿En qué formatos puedo guardar una presentación nueva?

Puede guardarla en [PPTX, PPT y ODP](/slides/es/cpp/save-presentation/), y exportarla a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/es/cpp/convert-powerpoint-to-xps/), [HTML](/slides/es/cpp/convert-powerpoint-to-html/), [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/) e [imágenes](/slides/es/cpp/convert-powerpoint-to-png/), entre otros.

### ¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [están soportados](/slides/es/cpp/supported-file-formats/).

### ¿Cómo controlo el tamaño/rela tion de aspecto de la diapositiva al crear una presentación?

Configure el [tamaño de diapositiva](/slides/es/cpp/slide-size/) (incluyendo preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?

Utilice [estrategias de gestión de BLOB](/slides/es/cpp/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos en lugar de streams exclusivamente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) desde [varios hilos](/slides/es/cpp/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

### ¿Cómo elimino la marca de agua de prueba y las limitaciones?

[Aplicar una licencia](/slides/es/cpp/licensing/) una vez por proceso. El XML de licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si intervienen varios hilos.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/cpp/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

### ¿Se admiten macros (VBA) en presentaciones creadas?

Sí. Puede [crear/editar proyectos VBA](/slides/es/cpp/presentation-via-vba/) y guardar archivos con macros habilitadas como PPTM/PPSM.