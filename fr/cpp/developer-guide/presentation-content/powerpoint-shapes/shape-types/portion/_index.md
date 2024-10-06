---
title: Portion
type: docs
weight: 70
url: /cpp/portion/
---

## **Obtenir les Coordonnées de Position de la Portion**
La méthode **GetCoordinates()** a été ajoutée à l'interface IPortion et à la classe Portion, ce qui permet de récupérer les coordonnées du début de la portion :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordonnées X =") + point.get_X() + u" Coordonnées Y =" + point.get_Y());
    }
}
```