---
title: ポーション
type: docs
weight: 70
url: /cpp/portion/
---

## **ポーションの位置座標を取得する**
**GetCoordinates()** メソッドが IPortion および Portion クラスに追加され、ポーションの先頭の座標を取得することができます：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"座標 X =") + point.get_X() + u" 座標 Y =" + point.get_Y());
    }
}
```