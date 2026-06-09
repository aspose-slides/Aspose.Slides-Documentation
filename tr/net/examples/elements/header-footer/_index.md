---
title: Üstbilgi Altbilgi
type: docs
weight: 220
url: /tr/net/examples/elements/header-footer/
keywords:
- üstbilgi altbilgi
- üstbilgi altbilgi ekle
- üstbilgi altbilgi güncelle
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile slayt üstbilgi ve altbilgilerini yönetin: PPT, PPTX ve ODP formatlarında tarih, slayt numarası ve özel metin ekleyin, C# örnekleriyle."
---
Bu makale, **Aspose.Slides for .NET** kullanarak altbilgileri eklemeyi ve tarih ve saat yer tutucularını güncellemeyi göstermektedir.

## **Altbilgi Ekle**

Bir slaytın altbilgi alanına metin ekleyin ve görünür hale getirin.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Tarih ve Saati Güncelle**

Bir slayt üzerindeki tarih ve saat yer tutucusunu değiştirin.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```