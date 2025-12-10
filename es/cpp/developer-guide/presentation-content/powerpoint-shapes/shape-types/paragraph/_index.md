---
title: "Obtener los límites de párrafo de presentaciones en C++"
linktitle: "Párrafo"
type: docs
weight: 60
url: /es/cpp/paragraph/
keywords:
- "límites de párrafo"
- "límites de porción de texto"
- "coordenada de párrafo"
- "coordenada de porción"
- "tamaño de párrafo"
- "tamaño de porción de texto"
- "marco de texto"
- "PowerPoint"
- "presentación"
- "C++"
- "Aspose.Slides"
description: "Aprenda cómo obtener los límites de párrafo y de porción de texto en Aspose.Slides para C++ para optimizar la ubicación del texto en presentaciones de PowerPoint."
---

## **Obtener coordenadas de párrafo y porción en un TextFrame**
Con Aspose.Slides para C++, los desarrolladores ahora pueden obtener las coordenadas rectangulares del Paragraph dentro de la colección de Paragraphs de un TextFrame. También permite obtener las coordenadas de la Portion dentro de la colección de Portions de un Paragraph. En este tema, vamos a demostrar con un ejemplo cómo obtener las coordenadas rectangulares del Paragraph junto con la posición de la Portion dentro de un Paragraph.

## **Obtener coordenadas rectangulares de un Paragraph**
Se ha añadido el nuevo método **GetRect()**. Permite obtener el rectángulo de los límites del Paragraph.
``` cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```


## **Obtener el tamaño de un Paragraph y una Portion dentro de un TextFrame de celda de tabla**
Para obtener el tamaño y las coordenadas de la [Portion](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) o del [Paragraph](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) en un TextFrame de celda de tabla, puede utilizar los métodos [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) y [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).
``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```


## **FAQ**

**¿En qué unidades se devuelven las coordenadas de un Paragraph y de las porciones de texto?**

En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿Afecta el ajuste de línea a los límites del Paragraph?**

Sí. Si el [wrapping](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/), el texto se divide para ajustarse al ancho del área, lo que cambia los límites reales del Paragraph.

**¿Se pueden mapear de forma fiable las coordenadas del Paragraph a píxeles en la imagen exportada?**

Sí. Convierta los puntos a píxeles usando: pixels = points × (DPI / 72). El resultado depende del DPI seleccionado para el renderizado/exportación.

**¿Cómo obtener los parámetros de formato “effective” del Paragraph, teniendo en cuenta la herencia de estilos?**

Utilice la [effective paragraph formatting data structure](/slides/es/cpp/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, wrapping, RTL y más.