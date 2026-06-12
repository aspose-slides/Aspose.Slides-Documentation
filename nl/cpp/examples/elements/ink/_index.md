---
title: Inkt
type: docs
weight: 180
url: /nl/cpp/examples/elements/ink/
keywords:
- codevoorbeeld
- inkt
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werken met inkt in Aspose.Slides voor C++: teken, importeer en bewerk streken, pas kleur en breedte aan, en exporteer naar PPT, PPTX en ODP met C++-voorbeelden."
---
Dit artikel geeft voorbeelden van het benaderen van bestaande inktvormen en het verwijderen ervan met **Aspose.Slides for C++**.

> ❗ **Opmerking:** Inktvormen vertegenwoordigen invoer van gebruikers via gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmatisch maken, maar u kunt bestaande inkt lezen en aanpassen.

## **Ink benaderen**

Lees de tags van de eerste inktvorm op een dia.

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
            // Gebruik tagName indien nodig.
        }
    }

    presentation->Dispose();
}
```

## **Ink verwijderen**

Verwijder een inktvorm van de dia als deze bestaat.

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