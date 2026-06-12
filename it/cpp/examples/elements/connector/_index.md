---
title: Connettore
type: docs
weight: 190
url: /it/cpp/examples/elements/connector/
keywords:
- esempio di codice
- Connettore
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Impara come aggiungere, instradare e formattare i connettori tra forme utilizzando Aspose.Slides per C++, con esempi per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come collegare forme con connettori e modificare i loro target utilizzando **Aspose.Slides for C++**.

## **Aggiungi un connettore**

Inserisci una forma di connettore tra due punti nella diapositiva.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Accedi a un connettore**

Recupera la prima forma di connettore aggiunta a una diapositiva.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Accedi al primo connettore nella diapositiva.
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

## **Rimuovi un connettore**

Elimina un connettore dalla diapositiva.

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

## **Ricollega le forme**

Collega un connettore a due forme assegnando i target di partenza e di arrivo.

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