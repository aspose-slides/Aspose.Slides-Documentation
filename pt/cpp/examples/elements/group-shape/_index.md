---
title: Grupo de Formas
type: docs
weight: 170
url: /pt/cpp/examples/elements/group-shape/
keywords:
- exemplo de código
- grupo de formas
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Gerencie formas agrupadas no Aspose.Slides for C++: crie, aninhe, alinhe, reorganize e estilize grupos de formas com exemplos em C++ em apresentações PPT, PPTX e ODP."
---
Exemplos de criação de grupos de formas, acesso a eles, desagrupamento e remoção usando **Aspose.Slides for C++**.

## **Adicionar um Grupo de Formas**

Crie um grupo contendo duas formas básicas.

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

## **Acessar um Grupo de Formas**

Recupere o primeiro grupo de formas de um slide.

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

## **Remover um Grupo de Formas**

Exclua um grupo de formas do slide.

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

## **Desagrupar Formas**

Mova as formas para fora de um contêiner de grupo.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Mover a forma para fora do grupo.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```