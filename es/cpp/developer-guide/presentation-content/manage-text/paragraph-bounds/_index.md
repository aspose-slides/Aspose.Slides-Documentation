---
title: Obtener límites de párrafo de presentaciones en C++
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/cpp/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo obtener los límites de párrafo en Aspose.Slides para C++ y optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Descripción general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo recuperar un rectángulo de párrafo a partir de un [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) mediante [IParagraph::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getrect/), cómo obtener las coordenadas del párrafo dentro de un marco de texto de celda de tabla, y destaca detalles importantes como unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivos.

## **Obtener coordenadas rectangulares de un párrafo**

Utilice [IParagraph::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getrect/) para obtener el rectángulo delimitador de un párrafo.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Obtener el tamaño de un párrafo dentro de un marco de texto de celda de tabla**

Para obtener el tamaño y las coordenadas de un [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) en un marco de texto de una celda de tabla, utilice [IParagraph::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getrect/). El rectángulo devuelto es relativo al marco de texto de la celda de tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizar esos límites:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿En qué unidades se miden las coordenadas de los párrafos?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿Afecta el ajuste de texto a los límites de un párrafo?**

Sí. Si [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_wraptext/) está habilitado para el [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/), el texto se divide para ajustarse al ancho del área, lo que modifica los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando esta fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para la renderización o exportación.

**¿Cómo obtener los parámetros de formato de párrafo “efectivo”, teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/cpp/shape-effective-properties/); devuelve los valores finales consolidados para sangrías, espaciado, ajuste, RTL y más.