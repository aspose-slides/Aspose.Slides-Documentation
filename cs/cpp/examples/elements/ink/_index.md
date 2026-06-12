---
title: Inkoust
type: docs
weight: 180
url: /cs/cpp/examples/elements/ink/
keywords:
- ukázka kódu
- inkoust
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Práce s inkoustem v Aspose.Slides pro C++: kreslete, importujte a upravujte tahy, nastavujte barvu a šířku a exportujte do PPT, PPTX a ODP pomocí příkladů v C++."
---
Tento článek poskytuje příklady, jak přistupovat k existujícím inkoustovým tvarům a odstraňovat je pomocí **Aspose.Slides for C++**.

> ❗ **Poznámka:** Inkoustové tvary představují vstup uživatele ze speciálních zařízení. Aspose.Slides neumí programově vytvořit nové tahy inkoustu, ale můžete číst a upravovat existující inkoust.

## **Přístup k inkoustu**

Přečtěte si značky z prvního inkoustového tvaru na snímku.

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
            // Použijte tagName podle potřeby.
        }
    }

    presentation->Dispose();
}
```

## **Odstranění inkoustu**

Odstraňte inkoustový tvar ze snímku, pokud existuje.

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