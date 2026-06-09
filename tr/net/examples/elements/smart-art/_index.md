---
title: SmartArt
type: docs
weight: 140
url: /tr/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt ekle
- SmartArt erişimi
- SmartArt kaldırma
- SmartArt düzeni
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde SmartArt ile çalışın: PowerPoint ve OpenDocument sunumları için C# kullanarak diyagramları oluşturun, düzenleyin, dönüştürün ve stillendirin."
---
Bu makale, **Aspose.Slides for .NET** kullanarak SmartArt grafiklerini eklemeyi, onlara erişmeyi, kaldırmayı ve düzenleri değiştirmeyi göstermektedir.

## **SmartArt Ekle**

Yerleşik düzenlerden birini kullanarak bir SmartArt grafiği ekleyin.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **SmartArt'a Erişim**

Bir slayttaki ilk SmartArt nesnesini alın.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt'ı Kaldır**

Slayttan bir SmartArt şeklini silin.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt Düzenini Değiştir**

Mevcut bir SmartArt grafiğinin düzen tipini güncelleyin.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```