---
title: Bläck
type: docs
weight: 180
url: /sv/cpp/examples/elements/ink/
keywords:
- kodexempel
- bläck
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med bläck i Aspose.Slides for C++: rita, importera och redigera streck, justera färg och bredd samt exportera till PPT, PPTX och ODP med C++-exempel."
---
Denna artikel ger exempel på hur man får åtkomst till befintliga bläckformer och tar bort dem med **Aspose.Slides for C++**.

> ❗ **Obs:** Bläckformer representerar användarinmatning från specialiserade enheter. Aspose.Slides kan inte skapa nya bläckstreck programatiskt, men du kan läsa och modifiera befintligt bläck.

## **Åtkomst till bläck**

Läs taggarna från den första bläckformen på en bild.

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
            // Använd tagName vid behov.
        }
    }

    presentation->Dispose();
}
```

## **Ta bort bläck**

Ta bort en bläckform från bilden om en sådan finns.

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