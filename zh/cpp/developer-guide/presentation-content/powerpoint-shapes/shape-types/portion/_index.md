---
title: 部分
type: docs
weight: 70
url: /cpp/portion/
---

## **获取部分的位置信息**
**GetCoordinates()** 方法已添加到 IPortion 和 Portion 类，可以获取部分开始位置的坐标：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"坐标 X =") + point.get_X() + u" 坐标 Y =" + point.get_Y());
    }
}
```