---
title: SmartArt
type: docs
weight: 140
url: /tr/cpp/examples/elements/smart-art/
keywords:
- kod örneği
- SmartArt
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta SmartArt ile çalışın: PowerPoint ve OpenDocument sunumları için C++ kullanarak diyagramları oluşturun, düzenleyin, dönüştürün ve stillendirin."
---
Bu makale, **Aspose.Slides for C++** kullanarak SmartArt grafikleri eklemeyi, onlara erişmeyi, kaldırmayı ve düzenleri değiştirmeyi gösterir.

## **SmartArt Ekle**

Yerleşik düzenlerden birini kullanarak bir SmartArt grafik ekleyin.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **SmartArt Erişimi**

Bir slayttaki ilk SmartArt nesnesini alın.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **SmartArt Kaldırma**

Slayttan bir SmartArt şekli silin.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **SmartArt Düzenini Değiştir**

Mevcut bir SmartArt grafiğinin düzen tipini güncelleyin.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```