---
title: Tinta
type: docs
weight: 180
url: /hu/cpp/examples/elements/ink/
keywords:
- kód példa
- tinta
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Dolgozzon a Tintával az Aspose.Slides for C++-ban: rajzoljon, importáljon és szerkesszen vonalakat, állítsa be a színt és a szélességet, valamint exportáljon PPT, PPTX és ODP formátumokba C++ példák használatával."
---
Ez a cikk példákat mutat be a már meglévő tintaalakzatok elérésére és eltávolítására a **Aspose.Slides for C++** használatával.

> ❗ **Megjegyzés:** A tintaalakzatok a speciális eszközök felhasználói bemenetét képviselik. Az Aspose.Slides programozottan nem képes új tintavonalakat létrehozni, de a meglévő tintát olvashatja és módosíthatja.

## **Tinta elérése**

Olvassa el a címkéket az első tintaalakzatról a dián.

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
            // Használja a tagName-et szükség szerint.
        }
    }

    presentation->Dispose();
}
```

## **Tinta eltávolítása**

Törölje a tintaalakzatot a diáról, ha létezik.

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