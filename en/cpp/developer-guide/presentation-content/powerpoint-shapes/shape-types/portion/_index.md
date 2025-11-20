---
title: Manage Text Portions in Presentations Using C++
linktitle: Text Portion
type: docs
weight: 70
url: /cpp/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint presentations using Aspose.Slides for C++, boosting performance and customization."
---

## **Get Position Coordinates of Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```
