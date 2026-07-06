---
title: Obtener los límites de la porción de texto de presentaciones en C++
linktitle: Límites de la porción
type: docs
weight: 47
url: /es/cpp/portion-bounds/
keywords:
- límites de la porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo obtener los límites de la porción de texto en presentaciones de PowerPoint usando Aspose.Slides para C++."
---
## **Descripción general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesitas obtener los límites de un fragmento de texto, aplicar formato solo a parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción mediante [IPortion::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/getrect/). También muestra cómo obtener las coordenadas del comienzo de una porción mediante [IPortion::GetCoordinates](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/getcoordinates/). Además, destaca escenarios comunes relacionados con porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la herencia de porción, párrafo, marco de texto y tema, y manejar casos en los que una fuente especificada no está disponible.

## **Obtener los límites de una porción de texto**

Utiliza [IPortion::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/getrect/) para obtener el rectángulo delimitador de una porción de texto:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Obtener las coordenadas de una porción de texto**

Utiliza [IPortion::GetCoordinates](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/getcoordinates/) para obtener las coordenadas del comienzo de una porción de texto:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/cpp/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una porción y qué se hereda de un párrafo o marco de texto?**

Las propiedades a nivel de porción tienen la mayor precedencia. Si una propiedad no está establecida en el [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/), Aspose.Slides la toma del [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/). Si tampoco está establecida allí, Aspose.Slides utiliza el estilo del [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) o del [theme](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una porción falta en la máquina o servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/cpp/font-selection-sequence/). El texto puede reorganizarse: las métricas, la guionización y el ancho pueden cambiar, lo que influye en el posicionamiento preciso.

**¿Puedo establecer la transparencia o un degradado de relleno de texto específico de la porción de forma independiente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel del [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/) pueden diferir de los fragmentos vecinos.