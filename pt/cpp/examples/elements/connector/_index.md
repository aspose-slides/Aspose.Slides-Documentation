---
title: Conector
type: docs
weight: 190
url: /pt/cpp/examples/elements/connector/
keywords:
- exemplo de código
- Conector
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como adicionar, roteiar e estilizar conectores entre formas usando Aspose.Slides para C++, com exemplos para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como conectar formas com conectores e alterar seus destinos usando **Aspose.Slides for C++**.

## **Add a Connector**
Inserir uma forma de conector entre dois pontos no slide.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Access a Connector**
Recuperar a primeira forma de conector adicionada a um slide.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Acessar o primeiro conector no slide.
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

## **Remove a Connector**
Excluir um conector do slide.

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

## **Reconnect Shapes**
Anexar um conector a duas formas atribuindo destinos de início e fim.

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