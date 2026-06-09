---
title: Köprü
type: docs
weight: 130
url: /tr/net/examples/elements/hyperlink/
keywords:
- köprü
- köprü ekle
- köprüyü eriş
- köprüyü kaldır
- köprüyü güncelle
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde köprüleri ekleyin ve yönetin: metin, şekil ve görsellere köprü ekleyin, PPT, PPTX ve ODP için hedef ve eylemleri ayarlayın, C# örnekleriyle."
---
Bu makale, **Aspose.Slides for .NET** kullanarak şekillerdeki köprüleri eklemeyi, erişmeyi, kaldırmayı ve güncellemeyi göstermektedir.

## **Köprü Ekle**

Dış bir web sitesine yönelen bir köprüye sahip bir dikdörtgen şekil oluşturun.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Köprüyü Eriş**

Bir şeklin metin bölümünden köprü bilgilerini okuyun.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Köprüyü Kaldır**

Bir şeklin metnindeki köprüyü temizleyin.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Köprüyü Güncelle**

Mevcut bir köprünün hedefini değiştirin. `HyperlinkManager` kullanarak zaten bir köprü içeren metni değiştirin; bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Mevcut metin içinde bir köprünün değiştirilmesi,
    // HyperlinkManager kullanılarak yapılmalı, özelliği doğrudan ayarlamaktan ziyade.
    // Bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```