---
title: Aplicación Hello World usando Aspose.Slides para C++
type: docs
weight: 80
url: /es/cpp/hello-world-application-using-aspose-slides/
keywords:
- hola mundo
- aplicación
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Crea tu primera aplicación C++ con Aspose.Slides, un sencillo ejemplo Hello World que te prepara para automatizar presentaciones PPT, PPTX y ODP."
---

## **Pasos para crear una aplicación Hello World**
En esta aplicación simple, crearemos una presentación de PowerPoint que contiene el texto **Hello World** en una posición especificada de una diapositiva. Por favor, siga los pasos a continuación para crear la aplicación **Hello World** utilizando la API de Aspose.Slides para C++:

- Crear una instancia de la clase Presentation
- Obtener la referencia de la primera diapositiva de la presentación, que se crea al instanciar Presentation.
- Agregar un AutoShape con ShapeType como Rectangle en una posición especificada de la diapositiva.
- Agregar un TextFrame al AutoShape que contenga Hello World como texto predeterminado
- Cambiar el color del texto a negro, ya que es blanco por defecto y no es visible en la diapositiva con fondo blanco
- Cambiar el color de línea de la forma a blanco para ocultar el borde de la forma
- Eliminar el formato de relleno predeterminado de la forma
- Finalmente, guardar la presentación en el formato de archivo deseado usando el objeto Presentation

La implementación de los pasos anteriores se muestra a continuación en un ejemplo.
``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // obtener la primera diapositiva
    auto slide = pres->get_Slides()->idx_get(0);

    // agregar un AutoShape de tipo Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // agregar TextFrame al rectángulo
    shape->AddTextFrame(u"Hello World");

    // cambiar el color del texto a negro (que es blanco por defecto)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // cambiar el color de línea del rectángulo a blanco
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // eliminar cualquier formato de relleno en la forma
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // guardar la presentación en disco
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
