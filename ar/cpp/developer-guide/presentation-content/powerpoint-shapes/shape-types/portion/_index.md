---
title: جزء
type: docs
weight: 70
url: /cpp/portion/
---

## **احصل على إحداثيات موقع الجزء**
**GetCoordinates()** تمت إضافته إلى واجهة IPortion وفئة Portion مما يسمح باسترجاع إحداثيات بداية الجزء:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"الإحداثيات X =") + point.get_X() + u" الإحداثيات Y =" + point.get_Y());
    }
}
```