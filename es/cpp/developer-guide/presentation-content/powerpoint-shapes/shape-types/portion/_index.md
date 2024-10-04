---
title: Porción
type: docs
weight: 70
url: /cpp/portion/
---

## **Obtener coordenadas de posición de la porción**
El método **GetCoordinates()** ha sido agregado a las clases IPortion y Portion, lo que permite recuperar las coordenadas del inicio de la porción:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordenadas X =") + point.get_X() + u" Coordenadas Y =" + point.get_Y());
    }
}
```