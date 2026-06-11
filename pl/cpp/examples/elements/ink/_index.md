---
title: Atrament
type: docs
weight: 180
url: /pl/cpp/examples/elements/ink/
keywords:
- przykład kodu
- atrament
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Pracuj z atramentem w Aspose.Slides for C++: rysuj, importuj i edytuj pociągnięcia, dostosowuj kolor i szerokość oraz eksportuj do PPT, PPTX i ODP przy użyciu przykładów w C++."
---
Ten artykuł zawiera przykłady dostępu do istniejących kształtów atramentu i ich usuwania przy użyciu **Aspose.Slides for C++**.

> ❗ **Uwaga:** Kształty atramentu reprezentują dane wprowadzane przez specjalistyczne urządzenia. Aspose.Slides nie może programowo tworzyć nowych pociągnięć atramentu, ale możesz odczytywać i modyfikować istniejący atrament.

## **Access Ink**
Odczytaj znaczniki z pierwszego kształtu atramentu na slajdzie.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Użyj tagName w razie potrzeby.
        }
    }

    presentation->Dispose();
}
```

## **Remove Ink**
Usuń kształt atramentu ze slajdu, jeśli istnieje.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```