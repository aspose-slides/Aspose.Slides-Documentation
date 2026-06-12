---
title: Skupinový tvar
type: docs
weight: 170
url: /cs/cpp/examples/elements/group-shape/
keywords:
- ukázka kódu
- skupinový tvar
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Spravujte seskupené tvary v Aspose.Slides pro C++: vytvářejte, vnořujte, zarovnávejte, přeskupujte a stylizujte skupinové tvary pomocí ukázek v C++ v prezentacích PPT, PPTX a ODP."
---
Příklady vytváření skupin tvarů, jejich přístupu, rozbalení a odebrání pomocí **Aspose.Slides for C++**.

## **Přidat skupinový tvar**

Vytvořte skupinu obsahující dva základní tvary.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **Přístup ke skupinovému tvaru**

Získejte první skupinový tvar ze snímku.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Odstranit skupinový tvar**

Odstraňte skupinový tvar ze snímku.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **Rozdělit tvary**

Přesuňte tvary mimo kontejner skupiny.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Přesunout tvar mimo skupinu.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```