---
title: Часть
type: docs
weight: 70
url: /cpp/portion/
---

## **Получить координаты позиции части**
Метод **GetCoordinates()** был добавлен в интерфейс IPortion и класс Portion, что позволяет получать координаты начала части:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Координаты X =") + point.get_X() + u" Координаты Y =" + point.get_Y());
    }
}
```