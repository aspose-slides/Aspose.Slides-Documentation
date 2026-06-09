---
title: Mürekkep
type: docs
weight: 180
url: /tr/net/examples/elements/ink/
keywords:
- mürekkep
- mürekkebe eriş
- mürekkebi kaldır
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde Mürekkep ile çalışın: çizim yapın, içe aktarın ve darbeleri düzenleyin, renk ve genişliği ayarlayın, ve C# örnekleri kullanarak PPT, PPTX ve ODP olarak dışa aktarın."
---
Bu makale, mevcut mürekkep şekillerine erişme ve **Aspose.Slides for .NET** kullanarak bunları kaldırma örnekleri sunar.

> ❗ **Not:** Mürekkep şekilleri, özel cihazlardan gelen kullanıcı girişini temsil eder. Aspose.Slides programatik olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkepe erişebilir ve bunu değiştirebilirsiniz.

## **Mürekkebi Eriş**

Bir slayttaki ilk mürekkep şekline ait etiketleri okuyun.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // tagName'i gerektiği gibi kullanın.
        }
    }
}
```

## **Mürekkebi Kaldır**

Eğer mevcutsa, slayttan bir mürekkep şekli silin.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```