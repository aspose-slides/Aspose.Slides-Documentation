---
title: Grup Şekli
type: docs
weight: 170
url: /tr/cpp/examples/elements/group-shape/
keywords:
- kod örneği
- grup şekli
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta gruplanmış şekilleri yönetin: oluşturun, iç içe yerleştirin, hizalayın, yeniden sırala ve stil uygulayın grup şekillerini C++ örnekleriyle PPT, PPTX ve ODP sunumlarında."
---
Şekil grupları oluşturma, onlara erişme, gruplamayı kaldırma ve silme işlemlerine ilişkin örnekler, **Aspose.Slides for C++** kullanılarak.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

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

## **Grup Şekline Eriş**

Bir slayttan ilk grup şekli alın.

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

## **Grup Şekli Kaldır**

Grup şekli slayttan sil.

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

## **Şekilleri Gruplamadan Çıkar**

Şekilleri grup konteynerinden dışarı taşı.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Şekli grup dışına taşı.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```