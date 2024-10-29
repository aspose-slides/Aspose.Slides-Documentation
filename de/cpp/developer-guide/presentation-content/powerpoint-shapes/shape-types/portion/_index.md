---
title: Portion
type: docs
weight: 70
url: /de/cpp/portion/
---

## **Positionkoordinaten der Portion abrufen**
Die **GetCoordinates()**-Methode wurde zur IPortion- und Portion-Klasse hinzugefügt, die es ermöglicht, die Koordinaten des Anfangs der Portion abzurufen:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Koordinaten X =") + point.get_X() + u" Koordinaten Y =" + point.get_Y());
    }
}
```