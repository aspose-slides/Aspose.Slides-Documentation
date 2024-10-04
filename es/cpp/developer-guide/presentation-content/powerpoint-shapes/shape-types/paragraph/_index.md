---
title: Párrafo
type: docs
weight: 60
url: /cpp/paragraph/
---

## **Obtener coordenadas de párrafo y porción en TextFrame**
Utilizando Aspose.Slides para C++, los desarrolladores ahora pueden obtener las coordenadas rectangulares para el Párrafo dentro de la colección de párrafos de TextFrame. También permite obtener las coordenadas de la porción dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con la ayuda de un ejemplo cómo obtener las coordenadas rectangulares para el párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener coordenadas rectangulares del párrafo**
Se ha añadido el nuevo método **GetRect()**. Permite obtener el rectángulo de límites del párrafo.

``` cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Obtener tamaño de párrafo y porción dentro del texto de la celda de la tabla**

Para obtener el tamaño y las coordenadas de la [Porción](https://reference.aspose.com/slides/cpp/class/aspose.slides.portion) o [Párrafo](https://reference.aspose.com/slides/cpp/class/aspose.slides.paragraph) dentro del texto de la celda de una tabla, puedes usar los métodos [IPortion::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) y [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Este código de muestra demuestra la operación descrita:

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