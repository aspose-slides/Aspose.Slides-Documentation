---
title: Mürekkep
type: docs
weight: 180
url: /tr/cpp/examples/elements/ink/
keywords:
- kod örneği
- mürekkep
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'de Mürekkep ile çalışın: darbeleri çizin, içe aktarın ve düzenleyin, renk ve genişliği ayarlayın ve C++ örneklerini kullanarak PPT, PPTX ve ODP'ye dışa aktarın."
---
Bu makale, mevcut mürekkep şekillerine erişme ve bunları **Aspose.Slides for C++** kullanarak kaldırma örnekleri sunar.

> ❗ **Not:** Mürekkep şekilleri, özel cihazlardan gelen kullanıcı girişini temsil eder. Aspose.Slides programatik olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkebi okuyabilir ve değiştirebilirsiniz.

## **Mürekkebi Erişme**

Bir slayttaki ilk mürekkep şeklinden etiketleri okuyun.

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
            // tagName'i gerektiği gibi kullanın.
        }
    }

    presentation->Dispose();
}
```

## **Mürekkebi Kaldır**

Eğer mevcutsa, slayttan bir mürekkep şekli silin.

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