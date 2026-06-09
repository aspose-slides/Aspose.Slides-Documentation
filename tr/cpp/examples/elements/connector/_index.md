---
title: Bağlayıcı
type: docs
weight: 190
url: /tr/cpp/examples/elements/connector/
keywords:
- kod örneği
- Bağlayıcı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak şekiller arasına bağlayıcı eklemeyi, yönlendirmeyi ve biçimlendirmeyi, PPT, PPTX ve ODP sunumları için örneklerle öğrenin."
---
Bu makale, şekilleri bağlayıcılarla nasıl bağlayacağınızı ve hedeflerini **Aspose.Slides for C++** kullanarak nasıl değiştireceğinizi gösterir.

## **Bağlayıcı Ekle**

Sunum slaytında iki nokta arasında bir bağlayıcı şekli ekleyin.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Bağlayıcıya Erişim**

Bir slayta eklenen ilk bağlayıcı şeklini alın.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Slayttaki ilk bağlayıcıya eriş.
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

## **Bağlayıcıyı Kaldır**

Bağlayıcıyı slayttan silin.

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

## **Şekilleri Yeniden Bağla**

Başlangıç ve bitiş hedeflerini atayarak bir bağlayıcıyı iki şekle bağlayın.

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