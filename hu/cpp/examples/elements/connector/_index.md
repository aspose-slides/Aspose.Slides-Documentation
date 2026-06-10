---
title: Csatlakozó
type: docs
weight: 190
url: /hu/cpp/examples/elements/connector/
keywords:
- kód példa
- Csatlakozó
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet alakzatok közötti csatlakozókat hozzáadni, irányítani és formázni az Aspose.Slides for C++ használatával, PPT, PPTX és ODP bemutatók példáival."
---
Ez a cikk bemutatja, hogyan lehet alakzatokat összekapcsolni csatlakozókkal, és módosítani a célpontjaikat az **Aspose.Slides for C++** használatával.

## **Csatlakozó hozzáadása**

Helyezzen el egy csatlakozó alakzatot a dia két pontja között.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Csatlakozó elérése**

Szerezze meg az első a diára hozzáadott csatlakozó alakzatot.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Az első csatlakozót a dián.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Csatlakozó eltávolítása**

Törölje a csatlakozót a diáról.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **Alakzatok újrakapcsolása**

Csatlakoztasson egy csatlakozót két alakzathoz, úgy, hogy megadja a kezdő és végcélpontokat.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```