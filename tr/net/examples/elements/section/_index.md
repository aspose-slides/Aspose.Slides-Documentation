---
title: Bölüm
type: docs
weight: 90
url: /tr/net/examples/elements/section/
keywords:
- bölüm
- slayt bölümü
- bölüm ekle
- bölüme eriş
- bölüm kaldır
- bölüm yeniden adlandır
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te slayt bölümlerini yönetin: C# örnekleriyle PPT, PPTX ve ODP için slaytları oluşturun, yeniden adlandırın, yeniden sıralayın ve gruplayın."
---
Sunum bölümlerini yönetme örnekleri—programlı olarak **Aspose.Slides for .NET** kullanarak ekleme, erişme, kaldırma ve yeniden adlandırma.

## **Bölüm Ekle**

Belirli bir slaytta başlayan bir bölüm oluşturun.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Bölümün başlangıcını belirten slaytı belirtin.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Bölüme Eriş**

Bir sunumdan bölüm bilgilerini okuyun.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Dizine göre bir bölüme eriş.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Bölümü Kaldır**

Daha önce eklenmiş bir bölümü silin.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // İlk bölümü kaldır.
    presentation.Sections.RemoveSection(section);
}
```

## **Bölümü Yeniden Adlandır**

Mevcut bir bölümün adını değiştirin.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```