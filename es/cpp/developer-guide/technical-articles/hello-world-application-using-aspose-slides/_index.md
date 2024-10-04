---
title: Aplicación Hola Mundo utilizando Aspose.Slides
type: docs
weight: 80
url: /cpp/hello-world-application-using-aspose-slides/
---

## **Pasos para Crear la Aplicación Hola Mundo**
En esta sencilla aplicación, crearemos una presentación de PowerPoint con el texto **Hola Mundo** en una posición especificada de una diapositiva. Por favor, siga los pasos a continuación para crear la aplicación **Hola Mundo** utilizando la API de Aspose.Slides para C++:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de la primera diapositiva en la presentación que se crea al instanciar la clase Presentation.
- Agregue una AutoShape con el ShapeType como Rectángulo en una posición especificada de la diapositiva.
- Agregue un TextFrame a la AutoShape que contenga Hola Mundo como texto predeterminado
- Cambie el Color del Texto a Negro ya que es blanco por defecto y no es visible en la diapositiva con fondo blanco
- Cambie el Color de Línea de la forma a blanco para ocultar el borde de la forma
- Elimine el formato de Relleno predeterminado de la forma
- Finalmente, escriba la presentación en el formato de archivo deseado utilizando el objeto Presentation

La implementación de los pasos anteriores se demuestra a continuación en un ejemplo.

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

    // agregar una AutoShape de tipo Rectángulo
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // agregar TextFrame al Rectángulo
    shape->AddTextFrame(u"Hola Mundo");

    // cambiar el color del texto a Negro (que es Blanco por defecto)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // cambiar el color de línea del rectángulo a Blanco
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // eliminar cualquier formato de relleno en la forma
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // guardar la presentación en el disco
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```