---
title: Csoport alakzat
type: docs
weight: 170
url: /hu/cpp/examples/elements/group-shape/
keywords:
- kódpélda
- csoport alakzat
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Kezelje a csoportosított alakzatokat az Aspose.Slides for C++-ban: hozzon létre, ágyazzon be, igazítson, rendezzen át és formázza a csoport alakzatokat C++ példákkal PPT, PPTX és ODP prezentációkban."
---
Példák alakzatcsoportok létrehozására, elérésére, felbontására és eltávolítására a **Aspose.Slides for C++** használatával.

## **Csoport alakzat hozzáadása**

Hozzon létre egy csoportot két alap alakzattal.

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

## **Csoport alakzat elérése**

Szerezze meg az első csoport alakzatot egy dián.

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

## **Csoport alakzat eltávolítása**

Törölje a csoport alakzatot a diáról.

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

## **Alakzatok csoportjának felbontása**

Mozgassa ki az alakzatokat a csoport tárolóból.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Mozgassa ki az alakzatot a csoportból.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```